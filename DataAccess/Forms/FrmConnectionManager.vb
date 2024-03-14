Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Reflection

Public Class FrmConnectionManager

    Private clsCommon As New Common.Common
    Dim Conn As MySqlConnection

    Private m_newconnection As Boolean
    Private m_state As State

    Private ServerName As String
    Private UserID As String
    Private Password As String
    Private DatabaseName As String
    Private Port As String
    Private ConnectionString As String
    Private RestartApplication As Boolean = False
    Private _EntryAssembly As System.Reflection.Assembly
    Public myFileStream As System.IO.FileStream

    Private Enum State
        ConnNew = 1
        ConnEdit = 2
        ConnUpdate = 3
        ConnOK = 4
    End Enum

    Public Property newconnection() As Boolean
        Get
            Return m_newconnection
        End Get
        Set(ByVal value As Boolean)
            If m_newconnection = value Then
                Return
            End If
            m_newconnection = value
        End Set
    End Property

    Public Property AppEntryAssembly() As System.Reflection.Assembly
        Get
            If _EntryAssembly Is Nothing Then
                _EntryAssembly = [Assembly].GetEntryAssembly
            End If
            If _EntryAssembly Is Nothing Then
                _EntryAssembly = [Assembly].GetExecutingAssembly
            End If

            Return _EntryAssembly
        End Get
        Set(ByVal Value As System.Reflection.Assembly)
            _EntryAssembly = Value
        End Set
    End Property


    Private Sub FrmConnectionManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim readStr As String
        Dim dsConnection As MySqlConnection = Nothing

        Me.Text = " Database Connection Manager"

        If m_newconnection = True Then
            m_state = State.ConnNew
            txtServer.Text = ServerName
            txtPort.Text = Port
        Else
            readStr = clsCommon.ReadConnString(gConnStringFileName, ConnectionString, ServerName, Port, UserID, Password, DatabaseName)

            If readStr <> "" Then
                clsCommon.Prompt_User("error", "Error reading connection string : " + readStr)
                Exit Sub
            End If

            m_state = State.ConnEdit

            txtServer.Text = ServerName
            txtPort.Text = Port
            txtUserID.Text = UserID
            txtPassword.Text = Password
            If ConnectDatabase(DatabaseName) Then
                GetDatabases()
                cboDBName.Text = DatabaseName
            End If

            btnOK.Text = "&Edit"
            btnOK.Enabled = True
            txtServer.ReadOnly = True
            txtPort.ReadOnly = True
            txtUserID.ReadOnly = True
            txtPassword.ReadOnly = True

            myFileStream = New System.IO.FileStream(gConnStringFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Inheritable)
        End If
    End Sub

    Private Function ConnectDatabase(Optional ByVal dbname As String = "") As Boolean
        If Not Conn Is Nothing Then Conn.Close()
        Dim ConnStr As String
        ConnStr = String.Format("server={0};port={1}; user id={2}; password={3}; database={4}; pooling=false",
        txtServer.Text, txtPort.Text, txtUserID.Text, txtPassword.Text, dbname)

        Try
            Conn = New MySqlConnection(ConnStr)
            Conn.Open()
            Return True
        Catch ex As MySqlException
            txtServer.Focus()
            clsCommon.Prompt_User("error", "Error connecting to the database server: " + ex.Message)
            Return False
        End Try
    End Function

    Private Sub GetDatabases()
        Dim reader As MySqlDataReader
        reader = Nothing

        Dim cmd As New MySqlCommand("SHOW DATABASES", Conn)
        Try
            reader = cmd.ExecuteReader()
            cboDBName.Items.Clear()

            While (reader.Read())
                cboDBName.Items.Add(reader.GetString(0))
            End While
        Catch ex As MySqlException
            clsCommon.Prompt_User("error", "Failed to populate database list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnCancel.Click, btnTest.Click
        Try
            Dim btnObject As Button

            If TypeOf (sender) Is Button Then
                btnObject = sender
                Select Case LCase(btnObject.Text)
                    Case "&ok", "&update"
                        Try
                            Me.Cursor = WaitCursor

                            If Not (Len(cboDBName.Text) > 0) Then
                                Me.Cursor = Arrow
                                clsCommon.Prompt_User("error", "Please select a database for your connection string.")
                                DialogResult = DialogResult.None
                                Exit Sub
                            End If

                            If Not ConnectDatabase(cboDBName.Text) Then
                                Me.Cursor = Arrow
                                DialogResult = DialogResult.None
                                Exit Sub
                            End If

                            ServerName = txtServer.Text
                            Port = txtPort.Text
                            UserID = txtUserID.Text
                            Password = txtPassword.Text
                            DatabaseName = cboDBName.Text

                            Me.Cursor = Arrow

                            If clsCommon.WriteConnString(gConnStringFileName, ServerName, Port, UserID, Password, DatabaseName, myFileStream) Then
                                m_state = State.ConnOK
                                RestartApplication = True
                                clsCommon.Prompt_User("information", "Database connection string successfully created." & vbCrLf & vbCrLf & "Restart application to be able to use the newly created database connection details.")
                                Me.Close()
                            End If
                        Catch ex As Exception
                            clsCommon.Prompt_User("error", "Unexpected error : " + ex.Message)
                        End Try
                    Case "&edit"
                        Dim iAns
                        iAns = clsCommon.Prompt_User("question", "There is no problem found in your current connection string." & vbCrLf & "Do you still want to edit your configuration?")
                        If iAns = vbYes Then
                            btnOK.Text = "&Update"
                            txtServer.ReadOnly = False
                            txtPort.ReadOnly = False
                            txtUserID.ReadOnly = False
                            txtPassword.ReadOnly = False
                            m_state = State.ConnUpdate
                            cboDBName.Enabled = True
                        End If
                        DialogResult = DialogResult.None
                    Case "&test"
                        Me.Cursor = WaitCursor
                        If ConnectDatabase() Then
                            GetDatabases()
                            cboDBName.Text = DatabaseName
                            cboDBName.Enabled = (LCase(btnOK.Text) <> "&edit")
                            btnOK.Enabled = True
                            Me.AcceptButton = btnOK
                            Me.Cursor = Arrow
                            clsCommon.Prompt_User("information", "Connection to database server [" + txtServer.Text + "] successful.")
                        Else
                            With cboDBName
                                .Items.Clear()
                                .Enabled = False
                            End With
                            Me.AcceptButton = btnTest
                            Me.Cursor = Arrow
                        End If
                    Case "&cancel"
                        If Not myFileStream Is Nothing Then
                            myFileStream.Close()
                        End If

                        Me.Close()
                End Select
            End If
        Catch ex As Exception
            clsCommon.Prompt_User("error", "Unexpected error : " + ex.Message)
        End Try
    End Sub
End Class