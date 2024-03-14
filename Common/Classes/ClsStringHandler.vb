Imports System.Text

Public Class ClsStringHandler
    'This function will replace single quotes to double quotes and remove excess spaces in a string
    Public Shared Function ReplaceSingleQuotes(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("'", "''")
        Return TrimAll(sbTemp.ToString)
    End Function

    'This function will replace single quotes to double quotes and remove excess spaces in a string
    Public Shared Function ReplaceAmpersands(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("&", "")
        Return TrimAll(sbTemp.ToString)
    End Function

    ' Replace ALL Duplicate Characters in String with a Single Instance
    Public Shared Function TrimAll(ByVal TextIn As String, Optional ByVal TrimChar As String = " ", Optional ByVal CtrlChar As String = Chr(0)) As String
        Try
            TrimAll = Replace(TextIn, TrimChar, CtrlChar) ' In case of CrLf etc.

            While InStr(TrimAll, CtrlChar + CtrlChar) > 0
                TrimAll = TrimAll.Replace(CtrlChar + CtrlChar, CtrlChar)
            End While

            TrimAll = TrimAll.Trim(CtrlChar) ' Trim Begining and End
            TrimAll = TrimAll.Replace(CtrlChar, TrimChar) ' Replace with Original Trim Character(s)
        Catch Exp As Exception
            TrimAll = TextIn ' Justin Case
        End Try
        Return TrimAll
    End Function

    'This function will remove ampersands
    Public Shared Function RemoveAmpersands(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("&", "")
        Return Trim(sbTemp.ToString)
    End Function


    'This function will remove consecutive wildcards in a string
    Public Shared Function RemoveRepeatingWildcards(ByVal strSQL As String) As String
        strSQL = Replace(strSQL, "*", "%")
        While InStr(strSQL, "%%")
            strSQL = Replace(strSQL, "%%", "%")
        End While
        Return strSQL
    End Function

    Public Function ExtractNumbers(ByVal expr As String) As String
        Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(expr, "[^\d]"))
    End Function

    Public Shared Function CleanInputAlphabet(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[0-9\b\s-]", "")
    End Function

    Public Shared Function CleanInputNumber(ByVal str As String) As String
        CleanInputNumber = System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-.]", "")
        If Len(CleanInputNumber) = 0 Then
            CleanInputNumber = "0"
        End If
        Return CleanInputNumber
    End Function

    Public Shared Function CleanInputFloat(ByVal str As String, Optional ByVal digits As Integer = 2) As String
        CleanInputFloat = System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-]", "")
        If Len(CleanInputFloat) = 0 Then
            If digits = 2 Then
                CleanInputFloat = "0.00"
            Else
                CleanInputFloat = "0.000000"
            End If
        End If
        Return CleanInputFloat
    End Function
End Class
