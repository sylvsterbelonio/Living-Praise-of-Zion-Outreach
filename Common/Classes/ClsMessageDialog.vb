Public Class ClsMessageDialog

    'Format messagebox
    Public Shared Function Prompt_User(ByVal MessageType As String, ByVal Message As String) As DialogResult
        Select Case LCase(MessageType)
            Case "information"
                Prompt_User = MessageBox.Show(Message, ModApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case "warning"
                Prompt_User = MessageBox.Show(Message, ModApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Case "question"
                Prompt_User = MessageBox.Show(Message, ModApp.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case "error"
                Prompt_User = MessageBox.Show(Message, ModApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "yesnocancel"
                Prompt_User = MessageBox.Show(Message, ModApp.AssemblyProduct, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Case Else
                Prompt_User = DialogResult.Ignore
        End Select
    End Function
End Class
