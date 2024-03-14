Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class FrmLogIn
    Inherits System.Windows.Forms.Form

    Private WithEvents SplashScreen As FrmSplashScreen
    Private UserAuthenticated As Boolean
    Private LoginFailure As Integer
    Private formType As Integer = 0

    Public LogIn_Success As Boolean = True
    Public Current_State As String
    Public App_User As String
    Public App_UserID As Integer
    Public App_FName As String
    Public App_LName As String
    Public Role_ID As Integer
    Public App_Role As String
    Public Job_Desc As String
    Public Current_Date As String
    Public password As String

    Private WithEvents clsLogin As New LogIn.LogIn
    Private clsCommon As New Common.Common
    Private clsDataAccess As New DataAccess(gConnStringFileName)

    Public gifLogo As Drawing.Image = Themes.Themes.getLogo

    Private Const MSG_INVALID_PASSWORD = "Please enter a valid user name and password."
    Private Const MSG_USER_ONLINE = "User account entered is currently online. You are not allowed to use the same account in multiple terminals."
    Private Const MSG_USER_INACTIVE = "User account entered is currently disabled, and therefore can not access the system."
    Private Const REGISTRY_SECTION_LOGIN = "Login"
    Private Const REGISTRY_KEY_LOGIN = "LastUser"
    Private Const MAX_LOGIN_FAILURE = 3
    Private Const MSG_MAX_LOGIN_FAILURE = "You have reached the maximum login attempts. System will now be closed."


    Public Event loginsuccess()

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.txtPassword.Focus()
    End Sub

    Sub KeyPressed(ByVal o As [Object], ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnLogin.PerformClick()
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(27) Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub FrmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtUserName.KeyPress, AddressOf KeyPressed
        AddHandler txtPassword.KeyPress, AddressOf KeyPressed
        Themes.Themes.SetThemes(Me)
        Dim hMenu As IntPtr
        Dim menuItemCount As Integer
        hMenu = Common.Common.GetSystemMenu(Me.Handle, False)
        menuItemCount = Common.Common.GetMenuItemCount(hMenu)

        If formType = 0 Then
            btnLogin.Text = "&OK"
        Else
            btnLogin.Text = "&Login"
        End If

        With pbLogoMain
            .BackgroundImage = gifLogo
            .BackgroundImageLayout = ImageLayout.Stretch
        End With

        'retrieve last username who login to the system
        txtUserName.Text = clsCommon.GetRegistrySetting(REGISTRY_SECTION_LOGIN, REGISTRY_KEY_LOGIN)

        Me.Text = ModApp.AssemblyProduct & " Log-in Information"
        'initialize login counter
        LoginFailure = 0

        'UpdateKeyState()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim blnExist As Boolean

        If txtUserName.Text = "" Then
            clsCommon.Prompt_User("error", MSG_INVALID_PASSWORD)
            LoginFailure += 1
        Else
            Me.Cursor = WaitCursor

            'Call clsLogin class for Validation
            blnExist = clsLogin.ValidateLogin(txtUserName.Text, txtPassword.Text, LoginFailure)

            Me.Cursor = Arrow

            If blnExist And (clsLogin.Online_Fl = 0) And (clsLogin.Active_Fl = 1) Then
                UserAuthenticated = True

                App_User = txtUserName.Text
                App_UserID = clsLogin.User_ID
                App_FName = clsLogin.First_Name
                App_LName = clsLogin.Last_Name
                Role_ID = clsLogin.Role_Id
                App_Role = clsLogin.Role_Name
                Job_Desc = clsLogin.Job_Desc

                Current_Date = Format(clsDataAccess.GetServerDate(), "Short Date")
                clsCommon.SaveRegistrySetting(REGISTRY_SECTION_LOGIN, REGISTRY_KEY_LOGIN, txtUserName.Text)
                clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "")
                clsCommon.SaveRegistrySetting("Print Tax Due Worksheet", "Disabled", "")
                clsCommon.SaveRegistrySetting("Print Proof List", "Disabled", "")
                clsCommon.SaveRegistrySetting("Print OR AF 51", "Disabled", "")

                RaiseEvent LoginSuccess()

                password = txtPassword.Text
                LogIn_Success = True
                Me.Hide()

                If LCase(btnLogin.Text) = "&ok" Then
                    'SplashScreen = New frmSplashScreen
                    'SplashScreen.ShowDialog()
                    Dim myWelcomeScr As New Themes.ClsAnimate
                    myWelcomeScr.run(Themes.Themes.getLogo, Drawing.Color.Beige, Drawing.Color.Black, 0.85)
                End If

                clsLogin.SystemUserOnlineUpdate(App_UserID, 1)

                DialogResult = DialogResult.OK
                Me.Close()
            ElseIf blnExist And (clsLogin.Online_Fl = 1) And (clsLogin.Active_Fl = 1) Then
                clsCommon.Prompt_User("error", MSG_USER_ONLINE)
                If txtPassword.Text.Length > 0 Then
                    txtPassword.SelectAll()
                End If
                txtPassword.Focus()
                LoginFailure += 1
                DialogResult = DialogResult.None
            ElseIf blnExist And (clsLogin.Active_Fl = 0) Then
                clsCommon.Prompt_User("error", MSG_USER_INACTIVE)
                If txtPassword.Text.Length > 0 Then
                    txtPassword.SelectAll()
                End If
                txtPassword.Focus()
                LoginFailure += 1
                DialogResult = DialogResult.None
            Else
                clsCommon.Prompt_User("error", MSG_INVALID_PASSWORD)
                If txtPassword.Text.Length > 0 Then
                    txtPassword.SelectAll()
                End If
                txtPassword.Focus()
                LoginFailure += 1
                DialogResult = DialogResult.None
            End If
        End If

        If LoginFailure = MAX_LOGIN_FAILURE Then
            clsCommon.Prompt_User("error", MSG_MAX_LOGIN_FAILURE)
            DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub txtPassword_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPassword.MouseDown
        clsCommon.Disable_Field_Context_Menu(e, txtPassword)
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        clsCommon.Key_Down(e)
    End Sub

    Private Sub frmLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not UserAuthenticated Then
            LogIn_Success = False
            Application.Exit()
        End If
    End Sub

    Private Sub lblHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHidden.Click
        Try
            clsCommon.Prompt_User("information", clsCommon.Crypt(txtPassword.Text))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        txtUserName.Text = clsCommon.Crypt(txtPassword.Text)
    End Sub
End Class