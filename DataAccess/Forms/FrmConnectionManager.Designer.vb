<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnectionManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnectionManager))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.cboDBName = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.gbConnection = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.gbConnection.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(461, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select appropriate configuration for your system's database connection."
        '
        'txtPort
        '
        Me.txtPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPort.Location = New System.Drawing.Point(136, 50)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(300, 22)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "3306"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPort.Location = New System.Drawing.Point(20, 50)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(34, 17)
        Me.lblPort.TabIndex = 25
        Me.lblPort.Text = "Port"
        '
        'cboDBName
        '
        Me.cboDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDBName.Enabled = False
        Me.cboDBName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboDBName.FormattingEnabled = True
        Me.cboDBName.Location = New System.Drawing.Point(136, 125)
        Me.cboDBName.Name = "cboDBName"
        Me.cboDBName.Size = New System.Drawing.Size(300, 24)
        Me.cboDBName.TabIndex = 4
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Enabled = False
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(374, 291)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 30)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(20, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(416, 60)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(154, 291)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtServer
        '
        Me.txtServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtServer.Location = New System.Drawing.Point(136, 25)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(300, 22)
        Me.txtServer.TabIndex = 0
        Me.txtServer.Text = "LOCALHOST"
        '
        'gbConnection
        '
        Me.gbConnection.Controls.Add(Me.txtPort)
        Me.gbConnection.Controls.Add(Me.lblPort)
        Me.gbConnection.Controls.Add(Me.cboDBName)
        Me.gbConnection.Controls.Add(Me.Label3)
        Me.gbConnection.Controls.Add(Me.txtServer)
        Me.gbConnection.Controls.Add(Me.Label2)
        Me.gbConnection.Controls.Add(Me.txtUserID)
        Me.gbConnection.Controls.Add(Me.Label5)
        Me.gbConnection.Controls.Add(Me.Label7)
        Me.gbConnection.Controls.Add(Me.Label8)
        Me.gbConnection.Controls.Add(Me.txtPassword)
        Me.gbConnection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbConnection.Location = New System.Drawing.Point(12, 45)
        Me.gbConnection.Name = "gbConnection"
        Me.gbConnection.Size = New System.Drawing.Size(461, 240)
        Me.gbConnection.TabIndex = 10
        Me.gbConnection.TabStop = False
        Me.gbConnection.Text = "Connect to MySQL Server Instance"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Database Name"
        '
        'txtUserID
        '
        Me.txtUserID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserID.Location = New System.Drawing.Point(136, 75)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(300, 22)
        Me.txtUserID.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Server Host"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(20, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "User Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(20, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(136, 100)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(300, 22)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnTest
        '
        Me.btnTest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTest.Location = New System.Drawing.Point(264, 291)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(100, 30)
        Me.btnTest.TabIndex = 11
        Me.btnTest.Text = "&Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'FrmConnectionManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 337)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbConnection)
        Me.Controls.Add(Me.btnTest)
        Me.Name = "FrmConnectionManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Connection Manager"
        Me.gbConnection.ResumeLayout(False)
        Me.gbConnection.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents lblPort As Label
    Friend WithEvents cboDBName As ComboBox
    Friend WithEvents btnOK As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtServer As TextBox
    Friend WithEvents gbConnection As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnTest As Button
End Class
