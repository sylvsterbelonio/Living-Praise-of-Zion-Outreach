Imports System.Windows.Forms.Cursors
Imports System.Windows.Forms.Help
Imports System.IO
Imports System.ComponentModel

Public Class FrmMain
    Inherits System.Windows.Forms.Form

    Private WithEvents clsMain As New Main.Main
    Private WithEvents frmChangePasswordForm As DataAccess.FrmChangePassword = Nothing
    Private WithEvents frmLoginForm As DataAccess.FrmLogIn = Nothing
    Private WithEvents frmSystemLockForm As DataAccess.FrmSystemLock = Nothing
    Private WithEvents frmDBConnMgr As DataAccess.FrmConnectionManager = Nothing
    Private WithEvents frmAboutForm As DataAccess.FrmAbout = Nothing
    Private WithEvents frmWelcomeScreenForm As DataAccess.FrmWelcomeScreen = Nothing
    'Private WithEvents frmDashBoard As New frmDashBoard

    Private dtMainMenu As DataSet
    Private dtMainMenuRow As DataRow
    Private dtToolBar As DataSet
    Private dtToolBarRow As DataRow
    Private dtSubMenu As DataSet
    Private dtSubMenuRow As DataRow
    Private dtSubMenu1 As DataSet
    Private dtSubMenuRow1 As DataRow
    Private Conntimer As Timer

    Private gifBackground As Image = Themes.Themes.getMainBackground

    Public Sub SetFormState()
        'set window title
        Me.Text = ModApp.AssemblyProduct

        'set window background
        Me.BackgroundImage = gifBackground
        Me.BackgroundImageLayout = ImageLayout.Stretch

        'paint menu and sub-menus
        MainMenu()

        'paint toolbar menu
        'ToolBar()

        'paint panels
        StatusBar()

        Conntimer = New Timer
        AddHandler Conntimer.Tick, New EventHandler(AddressOf Timer_Tick)
        Conntimer.Enabled = True
        DoubleBuffered = True

        Me.UpdateStatusLabels()

        Me.MainMenuStrip = msMain

        'load system parameters
        LoadSystemParameters()
    End Sub

    Private Sub LoadSystemParameters()
        Try

        Catch ex As Exception
            clsCommon.Prompt_User("error", "An error had occured while the system tried to load default parameters: " & ex.Message)
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctl As Control
        Timer1.Start()
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                'Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor
                ctlMDI.BackgroundImage = Me.BackgroundImage


            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        'custom initializations
        InitializeMe()


    End Sub

    Private Sub InitializeMe()
        Me.Cursor = WaitCursor
        'maximize main menu
        Me.WindowState = FormWindowState.Maximized

        If (clsCommon.GetRegistrySetting("Welcome", "ShowScreen") = "1") Then
            frmWelcomeScreenForm = clsDataAccess.NewfrmWelcomeScreen
            frmWelcomeScreenForm.Show(Me)
        End If
        Me.Cursor = Arrow

    End Sub

    Private Sub MainMenu()
        'populate main menu
        Dim intMenu As Integer

        Me.msMain.Items.Clear()

        With clsMain
            .Role_Id = Role_ID
            .PopulateMainMenu()
            Me.dtMainMenu = .dtMain
            intMenu = 0
            For Each Me.dtMainMenuRow In Me.dtMainMenu.Tables(0).Rows
                Dim mpFile As New ToolStripMenuItem
                mpFile.Name = "menu" + CStr(intMenu)
                mpFile.Text = Me.dtMainMenuRow(1)
                'showBottomIcons(mpFile.Text)
                If Me.dtMainMenuRow(3) > -1 Then
                    mpFile.Image = ilMain.Images(CInt(Me.dtMainMenuRow(3)))
                End If

                If LCase(Me.dtMainMenuRow(1)) = "&window" Then
                    msMain.MdiWindowListItem = mpFile
                End If

                .Parent_Id = Me.dtMainMenuRow(0)
                .CheckIfMenuHasChild()
                If .intChild_Count > 0 Then
                    SubMainMenu(mpFile, Me.dtMainMenuRow(0))
                End If

                msMain.Items.Add(mpFile)
                intMenu = intMenu + 1
            Next
        End With
    End Sub

    Private Sub SubMainMenu(ByRef subMPFile As ToolStripMenuItem, ByVal ParentId As Integer)
        Dim intMenu As Integer
        'MsgBox(subMPFile.Text)
        With clsMain
            .Role_Id = Role_ID
            .Parent_Id = ParentId
            .PopulateSubMenu()
            Me.dtSubMenu = .dtSub
            intMenu = 0

            For Each Me.dtSubMenuRow In Me.dtSubMenu.Tables(0).Rows
                If Me.dtSubMenuRow(3) = 0 Then
                    Dim tsiMain As ToolStripItem
                    If Me.dtSubMenuRow(1) = "&About" Then
                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1) & " " & ModApp.AssemblyTitle)
                        tsiMain.ToolTipText = Me.dtSubMenuRow(1) & " " & ModApp.AssemblyTitle
                    Else

                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1))
                        'showBottomIcons(Me.dtSubMenuRow(1))
                        'tsiMain.ToolTipText = clsCommon.ReplaceAmpersands(Me.dtSubMenuRow(1))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    If Me.dtSubMenuRow(4) > -1 Then
                        Try
                            tsiMain.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                        Catch ex As Exception

                        End Try

                    End If

                    'AddHandler tsiMain.Click, AddressOf MainMenuToolbar_Click
                    'AddHandler tsiMain.MouseDown, AddressOf ReadyDrag_MouseDown

                    If Me.dtSubMenuRow(5) > 0 Then
                        'smbFile.Shortcut = CLng(Me.dtSubMenuRow(5))
                    End If

                ElseIf Me.dtSubMenuRow(3) = 1 Then
                    Dim tsmMenu As New ToolStripMenuItem
                    tsmMenu.Name = "submenu" + CStr(Me.dtSubMenuRow(0))
                    tsmMenu.Text = Me.dtSubMenuRow(1)
                    'showBottomIcons(tsmMenu.Text)
                    subMPFile.DropDownItems.Add(tsmMenu)

                    If Me.dtSubMenuRow(4) > -1 Then
                        tsmMenu.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    .Parent_Id = Me.dtSubMenuRow(0)
                    .CheckIfMenuHasChild()

                    'populate submenus
                    If .intChild_Count > 0 Then
                        SubMainMenu(tsmMenu, Me.dtSubMenuRow(0))
                    End If
                End If

                intMenu = intMenu + 1
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''I let view the user's performance CRACKED BY SYLVSTER R> BELONIO
            If subMPFile.Text = "&Modules" And Role_ID <> 0 Then
                With clsMain
                    .Role_Id = 0
                    .Parent_Id = ParentId
                    .PopulateSubMenu()
                    Me.dtSubMenu = .dtSub
                    intMenu = 0
                    Dim index As Integer = 0
                    For Each Me.dtSubMenuRow In Me.dtSubMenu.Tables(0).Rows
                        If index >= 4 Then
                            Dim tsmMenu As New ToolStripMenuItem
                            tsmMenu.Name = "submenu" + CStr(Me.dtSubMenuRow(0))
                            tsmMenu.Text = Me.dtSubMenuRow(1)
                            'showBottomIcons(tsmMenu.Text)
                            subMPFile.DropDownItems.Add(tsmMenu)

                            'AddHandler tsmMenu.MouseDown, AddressOf ReadyDrag_MouseDown

                            If Me.dtSubMenuRow(4) > -1 Then
                                tsmMenu.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                            End If

                            If Me.dtSubMenuRow(2) = 1 Then
                                Dim tssMenu As New ToolStripSeparator
                                subMPFile.DropDownItems.Add(tssMenu)
                            End If

                            .Parent_Id = Me.dtSubMenuRow(0)
                            .CheckIfMenuHasChild()

                            'populate submenus
                            If .intChild_Count > 0 Then
                                'SubMainMenu_for_User_Performance_Mode(tsmMenu, Me.dtSubMenuRow(0))
                            End If
                        End If
                        index += 1
                    Next
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        End With
    End Sub

    Private Sub UpdateStatusLabels()
        ssMain.Items(7).ForeColor = IIf(My.Computer.Keyboard.NumLock, Color.Black, Color.LightGray)
        ssMain.Items(8).ForeColor = IIf(My.Computer.Keyboard.CapsLock, Color.Black, Color.LightGray)
        ssMain.Items(9).ForeColor = IIf(My.Computer.Keyboard.ScrollLock, Color.Black, Color.LightGray)
    End Sub

    Private Sub StatusBar()
        Dim blnState As Boolean
        blnState = clsCommon.CheckInetConnection()
        'set panels

        ssMain.Items.Clear()

        Dim objPanel As New ToolStripStatusLabel
        objPanel.ToolTipText = "Current User"
        objPanel.Text = "User : " & App_FName & " " & App_LName
        objPanel.Width = 200
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "System Role"
        objPanel.Text = "Role : " & App_Role
        objPanel.Width = 175
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = ""
        objPanel.Text = ""
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.Spring = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Connection Quality"
        'objPanel.Text = "Connection Quality : " & clsCommon.ConnectionQuality_String
        'objPanel.ForeColor = clsCommon.Connection_Color
        objPanel.Width = 165
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Connection Type"
        'objPanel.Text = "Connection Type : " & clsCommon.ConnectionState_String
        objPanel.Width = 165
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Database"
        objPanel.Text = "Database: " & UCase(Database_Name)
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Current Time"
        objPanel.Width = 240
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "NUM LOCK"
        objPanel.Text = "NUM"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "CAPS LOCK"
        objPanel.Text = "CAP"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "SCROLL LOCK"
        objPanel.Text = "SCR"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)
    End Sub


    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim blnState As Boolean
        blnState = clsCommon.CheckInetConnection()
        With ssMain.Items(3)
            .Text = "Connection Quality : " & clsCommon.ConnectionQualityString
            .ForeColor = clsCommon.ConnectionColor
        End With
        ssMain.Items(4).Text = "Connection Type : " & clsCommon.ConnectionStateString

        ssMain.Refresh()
    End Sub

End Class
