Public Class ClsRegistryHandler

    Public Shared Function GetRegistrySetting(ByVal strSection As String, ByVal strKey As String) As String
        Return GetSetting(ModApp.AssemblyTitle, strSection, strKey)
    End Function

End Class
