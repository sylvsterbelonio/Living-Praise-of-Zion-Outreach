Public Class ClsAnimate

    Public Sub run(ByVal myImage As Image, ByVal pbarBackColor As Color, ByVal pbarForeColor As Color, Optional ByVal TopPosition As Decimal = 0.75)

        Dim mySplash As New FrmSplashScreens
        mySplash.SplahImage = myImage
        mySplash.Show()

        Dim pb As New frmProgressBar(mySplash)
        'pb.set_class(myThemes)
        pb.StartPosition = FormStartPosition.Manual
        pb.BackColor = pbarBackColor
        pb.Label1.ForeColor = pbarForeColor
        pb.lblDots.ForeColor = pbarForeColor
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim top As Decimal = intY * TopPosition
        Dim left As Decimal = intX / 2

        pb.Top = (top - pb.Height)
        pb.Left = left - (pb.Width / 2)

        pb.ShowDialog()
        System.Threading.Thread.Sleep(400)

    End Sub

End Class
