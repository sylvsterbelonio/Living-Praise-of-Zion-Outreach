Public Class ClsSecurityHandler
    'Encrypt/Decrypt string used for XML Connection String
    Public Shared Function Crypt(ByVal Text As String) As String
        Dim strTempChar As String = ""
        Dim i As Integer

        For i = 1 To Len(Text)
            'Decrypt
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
                'Encrypt
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If
            Mid$(Text, i, 1) = Chr(strTempChar)
        Next i

        Crypt = Text
    End Function
End Class
