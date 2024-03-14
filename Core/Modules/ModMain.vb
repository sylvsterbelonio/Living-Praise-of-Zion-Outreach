Imports System.Threading
Imports System.Xml
Imports System.IO

Module ModMain

    Friend MainForm As FrmMain
    Friend clsCommon As New Common.Common
    Friend clsDataAccess As New DataAccess.DataAccess(ConnStringFileName)
    Private WithEvents frmDBConnMgr As DataAccess.frmConnectionManager = Nothing
    Private WithEvents frmLoginForm As DataAccess.frmLogin = Nothing
    Private irgsMutex As Mutex

    Public g_error As String
    Public g_ShowDetailedErrors As Boolean = True
    Public g_KillList As New ArrayList()
    Public NoPromptToSendErrors As Boolean = False

    Private strServerDate As String
    Private strLocalDate As String
    Private p_Doc As New XmlDocument
    Public isUpdate As Boolean = False
    Public isTheSamePassword As Boolean = False

    Sub Main()
        Try
            AddHandler Application.ThreadException, AddressOf Common.ClsCustomExceptionHandler.OnThreadException

            Try
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)
            Catch ex As Exception

            End Try

            'Create images directory
            If Not Directory.Exists(ImageDir) Then
                Directory.CreateDirectory(ImageDir)
            End If

            'Create presets directory
            If Not Directory.Exists(PresetDir) Then
                Directory.CreateDirectory(PresetDir)
            End If

            'Create reports directory
            If Not Directory.Exists(ReportDir) Then
                Directory.CreateDirectory(ReportDir)
            End If

            'Create plugins directory
            If Not Directory.Exists(PluginDir) Then
                Directory.CreateDirectory(PluginDir)
            End If

            irgsMutex = New Mutex(False, "Living Praise of Zion Outreach")

            'Validate if system is already running
            If irgsMutex.WaitOne(0, False) Then
                If Not File.Exists(ConnStringFileName) Then
                    frmDBConnMgr = clsDataAccess.NewfrmConnectionManager
                    With frmDBConnMgr
                        .myFileStream = myFileStream
                        .newconnection = True
                        If .ShowDialog = DialogResult.OK Then
                            Application.Exit()
                        End If
                    End With

                    Exit Sub
                End If

                'Validate mysql server is running

                If Not clsCommon.MySQLRunning(ConnStringFileName) Then
                    Exit Sub
                End If

                clsCommon.ReadConnString(ConnStringFileName, Connection_String, Server_Name, Port, UserID, Password, Database_Name)

                'Validate workstation date to server date
                If HasCorrectServerSystemDate() Then
                    'Show the login form and check the result
                    Dim frmBack As New FrmBackgroundLogIn
                    frmBack.Show()
                    frmLoginForm = clsDataAccess.NewfrmLogin(0)
                    With frmLoginForm
                        If .ShowDialog = DialogResult.OK Then

                            If .App_User = .password Then
                                isRequiredToChangePassword = True
                            Else
                                isRequiredToChangePassword = False
                            End If

                            App_User = App_User
                            App_UserID = .App_UserID
                            App_FName = .App_FName
                            App_LName = .App_LName
                            Role_ID = .Role_ID

                            App_Role = .App_Role
                            Job_Desc = .Job_Desc

                            Current_Date = Now

                            'If login is succesfull, show the main form
                            MainForm = New FrmMain
                            myFileStream = New System.IO.FileStream(ConnStringFileName, FileMode.Open, FileAccess.Read, FileShare.Read)

                            MainForm.SetFormState()
                            Application.DoEvents()
                            'Show as dialog so the sub main will not exit until the form is closed
                            frmBack.Hide()
                            Application.Run(MainForm)
                        End If
                    End With
                Else
                    clsCommon.Prompt_User("error", "The current server date is " & strServerDate & ". Please set the correct system date of your computer.")
                    Application.Exit()
                End If
                irgsMutex.ReleaseMutex()
            Else
                clsCommon.Prompt_User("error", ModApp.AssemblyProduct & " is already running.")
                Application.Exit()
            End If
        Catch e As System.ObjectDisposedException
            'Ignore, occurs when application.exit called 
        End Try
    End Sub


    Function HasCorrectServerSystemDate() As Boolean
        Try
            'strServerDate = clsDataAccess.GetServerDate()
            strServerDate = Format(CDate(Now), "MM/dd/yyyy")
            strLocalDate = Format(Now, "MM/dd/yyyy")

            If strServerDate = strLocalDate Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            clsCommon.Prompt_User("error", "Error connecting to database : " & ex.Message)
            Return False
        End Try
    End Function


End Module
