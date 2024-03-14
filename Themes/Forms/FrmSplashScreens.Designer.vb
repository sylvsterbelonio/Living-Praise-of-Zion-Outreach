<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSplashScreens
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PictureBox_SplashImage = New System.Windows.Forms.PictureBox()
        Me.PictureBox_PngSource = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_SplashImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_PngSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_SplashImage
        '
        Me.PictureBox_SplashImage.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_SplashImage.Name = "PictureBox_SplashImage"
        Me.PictureBox_SplashImage.Size = New System.Drawing.Size(600, 600)
        Me.PictureBox_SplashImage.TabIndex = 0
        Me.PictureBox_SplashImage.TabStop = False
        '
        'PictureBox_PngSource
        '
        Me.PictureBox_PngSource.Location = New System.Drawing.Point(806, 78)
        Me.PictureBox_PngSource.Name = "PictureBox_PngSource"
        Me.PictureBox_PngSource.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox_PngSource.TabIndex = 1
        Me.PictureBox_PngSource.TabStop = False
        '
        'FrmSplashScreens
        '
        Me.ClientSize = New System.Drawing.Size(10, 10)
        Me.Controls.Add(Me.PictureBox_SplashImage)
        Me.Controls.Add(Me.PictureBox_PngSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSplashScreens"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.PictureBox_SplashImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_PngSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox_SplashImage As PictureBox
    Friend WithEvents PictureBox_PngSource As PictureBox
End Class
