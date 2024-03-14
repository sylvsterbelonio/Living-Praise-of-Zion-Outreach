Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Xml

Public Class DataAccess
    Private connStringFileName As String
    Private objConnection As MySqlConnection
    Private objCommand As MySqlCommand
    Private objDataAdapter As MySqlDataAdapter
    Private objDataReader As MySqlDataReader
    Private dtDataTable As DataTable
    Private dsDataSet As DataSet
    Private drDataReader As MySqlDataReader

    Private ConnectionString As String

    Private clsCommon As New Common.Common

    Public Sub New(connStringFileName As String)
        Me.connStringFileName = connStringFileName
        gConnStringFileName = connStringFileName
    End Sub

    <CLSCompliant(False)>
    Public Property dbCommand() As MySqlCommand
        Get
            If IsNothing(objCommand) Then
                objCommand = New MySqlCommand
            End If
            Return objCommand
        End Get
        Set(ByVal Value As MySqlCommand)
            objCommand = Value
        End Set
    End Property

    <CLSCompliant(False)>
    Public Property dbDataAdapter() As MySqlDataAdapter
        Get
            If IsNothing(objDataAdapter) Then
                objDataAdapter = New MySqlDataAdapter
            End If
            Return objDataAdapter
        End Get
        Set(ByVal Value As MySqlDataAdapter)
            objDataAdapter = Value
        End Set
    End Property

#Region "Class DataAccess Forms Declarations"

    Public Function NewfrmAbout() As Form
        Try
            NewfrmAbout = New FrmAbout
            Return NewfrmAbout
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmChangePassword(ByVal userid As Integer) As Form
        Try
            NewfrmChangePassword = New FrmChangePassword(userid)
            Return NewfrmChangePassword
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmConnectionManager() As Form
        Try
            NewfrmConnectionManager = New FrmConnectionManager
            Return NewfrmConnectionManager
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLogin(ByVal ndx As Integer) As Form
        Try
            NewfrmLogin = New FrmLogIn
            Return NewfrmLogin
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoginOverride() As Form
        Try
            NewfrmLoginOverride = New FrmLogInOverride
            Return NewfrmLoginOverride
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmWelcomeScreen() As Form
        Try
            NewfrmWelcomeScreen = New FrmWelcomeScreen
            Return NewfrmWelcomeScreen
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmSystemLock(ByVal usr As String) As Form
        Try
            NewfrmSystemLock = New FrmSystemLock(usr)
            Return NewfrmSystemLock
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class DataAccess Public Functions"

    'Open Connection
    <CLSCompliant(False)>
    Public Function connString(ByRef dbConn As MySqlConnection) As Boolean
        Try
            Dim dbConnectionString As String
            Dim blnConnected As Boolean = True
            Dim readStr As String

            readStr = clsCommon.ReadConnString(gConnStringFileName, ConnectionString)
            dbConnectionString = ConnectionString

            If readStr <> "" Then
                Return False
            End If

            If IsNothing(dbConn) Then
                Try
                    dbConn = New MySqlConnection(dbConnectionString)
                    dbConn.Open()
                Catch ex As Exception
                    Return False
                End Try
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetServerDate() As String
        Dim strDate As String
        Try
            Dim sqlStmt As String
            Dim dtDate As DataTable

            sqlStmt = "CALL sp_Server_Date_Get();"
            dtDate = ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)
            strDate = dtDate.Rows(0)("Server_Date")
            Return strDate
        Catch err As Exception
            Throw err
        End Try
        strDate = Now
        Return strDate
    End Function

    'For Select Statement w/o parameter array
    Public Function ExecuteQuery(ByVal strSqlQry As String, ByVal blnAutoCleanUp As Boolean, ByVal ReturnType As String)
        Try
            Dim dsConnection As MySqlConnection = Nothing
            Dim dsDataAdapter As MySqlDataAdapter = dbDataAdapter
            Dim dsCommand As MySqlCommand = dbCommand

            Try
                If Not connString(dsConnection) Then
                    Throw New Exception("")
                    Exit Function
                End If
            Catch ex As Exception
                clsCommon.Prompt_User("error", "Database connection failed : " + ex.Message)
            End Try

            dsCommand.CommandText = strSqlQry
            dsCommand.CommandType = CommandType.Text
            dsCommand.Connection = dsConnection
            If ReturnType.ToUpper.Equals("DATASET") Then
                dsDataSet = New DataSet
                dsDataAdapter.SelectCommand = dsCommand
                If (strSqlQry.Trim().Length > 0) Then
                    dsDataAdapter.Fill(dsDataSet, strSqlQry)
                Else
                    Try
                        dsDataAdapter.Fill(dsDataSet)
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                Return dsDataSet
            ElseIf ReturnType.ToUpper.Equals("DATATABLE") Then
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                dsCommand.CommandText = strSqlQry
                dsCommand.CommandType = CommandType.Text
                dsCommand.Connection = dsConnection

                dtDataTable = New DataTable
                dsDataAdapter = New MySqlDataAdapter
                dsDataAdapter.SelectCommand = dsCommand
                dsDataAdapter.Fill(dtDataTable)
                dsConnection.Close()
                Return dtDataTable
            ElseIf ReturnType.ToUpper.Equals("DATAREADER") Then
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                Return dsCommand.ExecuteReader
            Else
                Throw New Exception(ReturnType & ": Is Not A Valid Database Return Type. Ex. DataReader, DataSet")
            End If
        Catch SQLex As MySqlException
            Throw SQLex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'For Select Statement w parameter array
    Public Function ExecuteQuery(ByVal strSqlQry As String, ByVal blnAutoCleanUp As Boolean, ByVal ReturnType As String, ByVal arr As ArrayList)
        Try
            Dim dsConnection As MySqlConnection = Nothing
            Dim dsDataAdapter As MySqlDataAdapter = dbDataAdapter
            Dim dsCommand As MySqlCommand = dbCommand
            Dim i As Integer

            Try
                If Not connString(dsConnection) Then
                    Throw New Exception("")
                    Exit Function
                End If
            Catch ex As Exception
                clsCommon.Prompt_User("error", "Database connection failed : " + ex.Message)
            End Try

            dsCommand.CommandText = strSqlQry
            dsCommand.CommandType = CommandType.StoredProcedure
            dsCommand.Parameters.Clear()

            For i = 0 To arr.Count - 1
                dsCommand.Parameters.Add(arr.Item(i))
            Next

            dsCommand.Connection = dsConnection
            If ReturnType.ToUpper.Equals("DATASET") Then
                dsDataSet = New DataSet
                dsDataAdapter.SelectCommand = dsCommand
                If (strSqlQry.Trim().Length > 0) Then
                    dsDataAdapter.Fill(dsDataSet, strSqlQry)
                Else
                    Try
                        dsDataAdapter.Fill(dsDataSet)
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                Return dsDataSet
            ElseIf ReturnType.ToUpper.Equals("DATATABLE") Then
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                dsCommand.CommandText = strSqlQry
                dsCommand.CommandType = CommandType.StoredProcedure
                dsCommand.Parameters.Clear()

                For i = 0 To arr.Count - 1
                    dsCommand.Parameters.Add(arr.Item(i))
                Next

                dsCommand.Connection = dsConnection

                dtDataTable = New DataTable
                dsDataAdapter = New MySqlDataAdapter
                dsDataAdapter.SelectCommand = dsCommand
                dsDataAdapter.Fill(dtDataTable)
                dsConnection.Close()
                Return dtDataTable
            ElseIf ReturnType.ToUpper.Equals("DATAREADER") Then
                If blnAutoCleanUp Then
                    CleanDbObjects()
                End If
                Return dsCommand.ExecuteReader
            Else
                Throw New Exception(ReturnType & ": Is Not A Valid Database Return Type. Ex. DataReader, DataSet")
            End If
        Catch SQLex As MySqlException
            Throw SQLex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'For Insert/Update/Delete Statement w/o parameter array
    Public Sub ExecuteNonQuery(ByVal strSql As String, ByVal blnAutoCleanUp As Boolean)
        Try
            Dim dsConnection As MySqlConnection = Nothing
            Dim dsCommand As MySqlCommand = dbCommand

            Try
                If Not connString(dsConnection) Then
                    Throw New Exception("")
                    Exit Sub
                End If
            Catch ex As Exception
                clsCommon.Prompt_User("error", "Database connection failed : " + ex.Message)
            End Try

            dsCommand.CommandText = strSql
            dsCommand.CommandType = CommandType.Text
            If dsConnection.State = ConnectionState.Closed Then
                dsConnection.Open()
            End If
            dsCommand.Connection = dsConnection
            dsCommand.ExecuteNonQuery()
            If blnAutoCleanUp Then
                CleanDbObjects()
            End If
        Catch SQLex As MySqlException
            Throw SQLex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Class DataAccess Public Subs"
    'Close DB Connection
    Public Sub CleanDbObjects()
        Try
            objConnection.Close()
            objConnection = Nothing
            objCommand = Nothing
            objDataAdapter = Nothing
            objDataReader = Nothing
            objDataReader.Close()
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
