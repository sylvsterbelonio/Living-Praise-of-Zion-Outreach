<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(800, 30)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'ssMain
        '
        Me.ssMain.AccessibleDescription = ""
        Me.ssMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ssMain.Location = New System.Drawing.Point(0, 428)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(800, 22)
        Me.ssMain.TabIndex = 2
        Me.ssMain.Text = "StatusStrip1"
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMain.Location = New System.Drawing.Point(0, 30)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(800, 31)
        Me.tsMain.TabIndex = 3
        Me.tsMain.Text = "ToolStrip1"
        '
        'ilMain
        '
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        Me.ilMain.Images.SetKeyName(0, "constituent.ico")
        Me.ilMain.Images.SetKeyName(1, "business.ico")
        Me.ilMain.Images.SetKeyName(2, "business_permit_application.ico")
        Me.ilMain.Images.SetKeyName(3, "user.ico")
        Me.ilMain.Images.SetKeyName(4, "exit.ico")
        Me.ilMain.Images.SetKeyName(5, "excel.ico")
        Me.ilMain.Images.SetKeyName(6, "word.ico")
        Me.ilMain.Images.SetKeyName(7, "calculator.ico")
        Me.ilMain.Images.SetKeyName(8, "logoff.ico")
        Me.ilMain.Images.SetKeyName(9, "about.ico")
        Me.ilMain.Images.SetKeyName(10, "payment.ico")
        Me.ilMain.Images.SetKeyName(11, "collectible.ico")
        Me.ilMain.Images.SetKeyName(12, "security.ico")
        Me.ilMain.Images.SetKeyName(13, "payment2.ico")
        Me.ilMain.Images.SetKeyName(14, "offline.ico")
        Me.ilMain.Images.SetKeyName(15, "taxdeclaration.ico")
        Me.ilMain.Images.SetKeyName(16, "Book keeper.png")
        Me.ilMain.Images.SetKeyName(17, "Department.png")
        Me.ilMain.Images.SetKeyName(18, "General_Tables.png")
        Me.ilMain.Images.SetKeyName(19, "Local_gov_unit.png")
        Me.ilMain.Images.SetKeyName(20, "Maintenance.png")
        Me.ilMain.Images.SetKeyName(21, "Member_management.png")
        Me.ilMain.Images.SetKeyName(22, "Member_reassign.png")
        Me.ilMain.Images.SetKeyName(23, "Member_records.png")
        Me.ilMain.Images.SetKeyName(24, "Member_replace.png")
        Me.ilMain.Images.SetKeyName(25, "Member_retire.png")
        Me.ilMain.Images.SetKeyName(26, "my_account.png")
        Me.ilMain.Images.SetKeyName(27, "Personnel_Admin.png")
        Me.ilMain.Images.SetKeyName(28, "Spatial_Country.png")
        Me.ilMain.Images.SetKeyName(29, "Spatial_lookup.png")
        Me.ilMain.Images.SetKeyName(30, "Spatial_province.png")
        Me.ilMain.Images.SetKeyName(31, "Spatial_Region.png")
        Me.ilMain.Images.SetKeyName(32, "System_access_level.png")
        Me.ilMain.Images.SetKeyName(33, "System_user.png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.msMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents ssMain As StatusStrip
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents ilMain As ImageList
    Friend WithEvents Timer1 As Timer
End Class
