Imports MySql.Data.MySqlClient

Public Class ClsMysqlHandler
    Private Shared Conn As MySqlConnection

    'Check if MySQL server is running
    Public Shared Function MySQLRunning(ByVal ConnStringFileName As String) As Boolean
        If Not Conn Is Nothing Then Conn.Close()

        Dim ConnStr As String = ""

        ClsXMLHandler.ReadConnString(ConnStringFileName, ConnStr)

        Try
            Conn = New MySqlConnection(ConnStr)
            Conn.Open()
            Return True
        Catch ex As MySqlException
            ClsMessageDialog.Prompt_User("error", "There is an error connecting to the database server: " + ex.Message + "." + vbCr + vbCr + "The host provided in your connection string maybe currently offline. Please make sure that the service is running before restarting the application. If this problem persists, please notify the system administrator immediately.")
            Return False
        End Try
    End Function
End Class
