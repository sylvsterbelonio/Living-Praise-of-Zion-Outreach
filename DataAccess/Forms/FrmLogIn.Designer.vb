<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pbLogoMapping = New System.Windows.Forms.PictureBox()
        Me.lblHidden = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tooltipPassword = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.pbLogoMain = New System.Windows.Forms.PictureBox()
        CType(Me.pbLogoMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbLogoMapping
        '
        Me.pbLogoMapping.Location = New System.Drawing.Point(12, 122)
        Me.pbLogoMapping.Name = "pbLogoMapping"
        Me.pbLogoMapping.Size = New System.Drawing.Size(100, 100)
        Me.pbLogoMapping.TabIndex = 32
        Me.pbLogoMapping.TabStop = False
        '
        'lblHidden
        '
        Me.lblHidden.AutoSize = True
        Me.lblHidden.Location = New System.Drawing.Point(425, 234)
        Me.lblHidden.Name = "lblHidden"
        Me.lblHidden.Size = New System.Drawing.Size(16, 17)
        Me.lblHidden.TabIndex = 9
        Me.lblHidden.Text = "+"
        Me.lblHidden.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(122, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(319, 30)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "This application manipulates sensitive data. Only registered users are allowed ac" &
    "cess."
        '
        'tooltipPassword
        '
        Me.tooltipPassword.Active = False
        Me.tooltipPassword.IsBalloon = True
        Me.tooltipPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.tooltipPassword.ToolTipTitle = "Caps Lock is On"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(122, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(319, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Caution : If you lose or forget the password, it can not be recovered. (Remember " &
    "that passwords are case sensitive.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(122, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "User Name     :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(122, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password      :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(122, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(319, 30)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "If you've been registered, please supply the following data:"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(231, 157)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(210, 22)
        Me.txtPassword.TabIndex = 6
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserName.Location = New System.Drawing.Point(231, 127)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(210, 22)
        Me.txtUserName.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(231, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLogin.Location = New System.Drawing.Point(341, 192)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 30)
        Me.btnLogin.TabIndex = 8
        Me.btnLogin.Text = "&OK"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'pbLogoMain
        '
        Me.pbLogoMain.Location = New System.Drawing.Point(12, 12)
        Me.pbLogoMain.Name = "pbLogoMain"
        Me.pbLogoMain.Size = New System.Drawing.Size(100, 100)
        Me.pbLogoMain.TabIndex = 31
        Me.pbLogoMain.TabStop = False
        '
        'FrmLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 265)
        Me.Controls.Add(Me.pbLogoMapping)
        Me.Controls.Add(Me.lblHidden)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.pbLogoMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbLogoMapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbLogoMapping As PictureBox
    Friend WithEvents lblHidden As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tooltipPassword As ToolTip
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents pbLogoMain As PictureBox
End Class
