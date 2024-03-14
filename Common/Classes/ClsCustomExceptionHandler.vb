Imports System.Threading

Public Class ClsCustomExceptionHandler

    ' Handles the exception event.
    Public Shared Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        OnThreadException(t.Exception)
    End Sub

    Public Shared Sub OnThreadException(ByVal e As Exception)
        ClsLogHandler.WriteToErrorLog(e.Message, e.StackTrace, "Error")

        If e.Message.Contains("UnauthorizedAccessException") Then
            ClsMessageDialog.Prompt_User("error", "An Unauthorized Access error was generated. Please ensure you have access to all files you're trying to work with, and that the files aren't in use by other applications.")
            Exit Sub
        End If

        Try
            If (IIf((Len(ClsRegistryHandler.GetRegistrySetting("Reports", "DontReportBugs")) = 0), 0, CInt(ClsRegistryHandler.GetRegistrySetting("Reports", "DontReportBugs")))) = 0 Then
                Dim errorBox As New FrmErrorDialog(e)
                errorBox.ShowDialog()
            Else
                Dim errorBox As New frmErrorDialogNoSend(e)
                errorBox.ShowDialog()
            End If
        Catch ex As Exception
            Dim errorBox As New frmErrorDialog(e)
            errorBox.ShowDialog()
        End Try
    End Sub

End Class
