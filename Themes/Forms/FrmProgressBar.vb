Public Class FrmProgressBar
    Dim str As String = ""
    Dim cn As Integer = 5
    Dim max_tick_response As Integer
    Dim i As Integer = 0
    Dim ii As Integer = 0
    Dim max As Integer = 50
    Dim frmscreen As Form

    'Private myTHemes As New CustomObjects.MyObject.ThemeNames

    Public Sub New(ByRef frmini As Form)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmscreen = frmini
    End Sub

    Private Sub frmProgressBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        'connect(mySql)
        'Dim myThemes As New myFunctionLibrary.myThemes
        'myThemes.set_class(mySql, "1")
        'myThemes.get_my_Themes()
        max_tick_response = 2
        'myObject.get_all_objects_data(colObject, Me)
        'myObject.load(colObject, myTHemes)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i = 0 Then
            str = "."
        ElseIf i <= cn Then
            str += " ."
        Else
            str = "."
        End If
        If i > 5 Then
            i = 0
        End If
        If ii > max_tick_response Then
            Timer1.Stop()
            frmscreen.Close()
            Me.Close()

        End If
        Label1.Text = "Please Wait " + str


        i += 1
        ii += 1
    End Sub

End Class