Public Class FrmSplashScreens
    Inherits Form
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    Private Declare Function BitBlt Lib "gdi32" Alias "BitBlt" (ByVal hDestDC As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
    Private Declare Function GetDC Lib "user32" Alias "GetDC" (ByVal hwnd As IntPtr) As Integer
    Private Declare Function ReleaseDC Lib "user32" Alias "ReleaseDC" (ByVal hwnd As IntPtr, ByVal hdc As Integer) As Integer
    Private Const SRCCOPY = &HCC0020
    Public SplahImage As Image

    Private Sub FrmSplashScreens_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Read the PNG picture into PictureBox_PngSource -- the PNG is compiled as an embedded resource
        Me.PictureBox_PngSource.Image = get_Image("Type A")
        ' Me.PictureBox_SplashImage.Image = My.Resources.pbar_ani
        ' Determine the Width and Height of the splash form
        Dim FormWidth As Integer = Me.PictureBox_SplashImage.Width
        Dim FormHeight As Integer = Me.PictureBox_SplashImage.Height

        ' Determine the Left and Top parameters of the splash form -- the form will be centered on screen
        Dim ScreenSize As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        Dim FormLeft As Integer = (ScreenSize.Width - Me.PictureBox_SplashImage.Width) / 2
        Dim FormTop As Integer = (ScreenSize.Height - Me.PictureBox_SplashImage.Height) / 2

        ' Create a bitmap buffer to draw things into
        Dim BufferBitmap As Bitmap = New Bitmap(FormWidth, FormHeight)
        Dim BufferGraphics As Graphics = Graphics.FromImage(BufferBitmap)

        ' Get a screenshot of the desktop area where the splash form will show
        Dim DesktopDC As Integer = GetDC(Nothing)
        Dim BufferGraphicsDC As IntPtr = BufferGraphics.GetHdc
        BitBlt(BufferGraphicsDC.ToInt32, 0, 0, FormWidth, FormHeight, DesktopDC, FormLeft, FormTop, SRCCOPY)
        ReleaseDC(Nothing, DesktopDC)
        BufferGraphics.ReleaseHdc(BufferGraphicsDC)

        ' Draw the PNG image over the desktop screenshot
        BufferGraphics.DrawImage(Me.PictureBox_PngSource.Image, 0, 0, FormWidth, FormHeight)

        ' Draw some text -- this is where some product license info could be drawn on the splash picture
        Dim TextBrush As New SolidBrush(Me.ForeColor)
        'BufferGraphics.DrawString("This is a system", Me.Font, TextBrush, 25, 40)
        TextBrush.Dispose()

        BufferGraphics.Dispose()

        ' Put the final result into the PictureBox_SplashImage which will cover the entire splash form
        Me.PictureBox_SplashImage.Size = New Size(FormWidth, FormHeight)
        Me.PictureBox_SplashImage.Image = BufferBitmap

        ' Position the splash form exactly over the desktop area that was previously captured
        Me.Width = FormWidth
        Me.Height = FormHeight
        Me.Top = FormTop
        Me.Left = FormLeft
        Me.WindowState = FormWindowState.Normal

        ' Allow the splash form to show itself properly


        'making of progress bar

        ''pbLoading.Image = My.Resources.pbar_ani
        'FormWidth = Me.PictureBox1.Width
        'FormHeight = Me.PictureBox1.Height

        '' Determine the Left and Top parameters of the splash form -- the form will be centered on screen
        'Dim ScreenSize2 As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        'FormLeft = (ScreenSize.Width - Me.PictureBox_PngSource.Width) / 2
        'FormTop = (ScreenSize.Height - Me.PictureBox_PngSource.Height) / 2

        'PictureBox1.Location = New System.Drawing.Point(FormLeft, FormTop - 800)
        'PictureBox1.BringToFront()


        Application.DoEvents()
    End Sub

    Private Function get_Image(Optional ByVal type As String = "") As Image
        Dim mydata As New DataTable
        'mySql.setConnection(ghost, gport, guser, gpass, gdbname)
        'Connect(mySql)
        'myPicture.set_class(mySql, gThemeID, Nothing)
        'mydata = mySql.runQuery("SELECT * from reserved_tblimage_library where ClassName='PictureBox' and TagName='SplashScreen' and GroupName='User' ")
        'If mydata.Rows.Count > 0 Then
        '    'Return myPicture.get_CustomObjectThemes("PictureBox", "SplashScreen", "User")
        '    'Return My.Resources.new_logo_2013
        'Else
        '    Return My.Resources.cipg_SPASHSCREEN
        'End If
        Return My.Resources.white_logo

    End Function

End Class