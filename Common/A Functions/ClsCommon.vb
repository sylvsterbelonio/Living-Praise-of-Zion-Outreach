Imports MySql.Data.MySqlClient

Public Class Common

    Public Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Boolean
    Public Declare Function SetParent Lib "user32" (ByVal hWndChild As System.IntPtr, ByVal hWndNewParent As System.IntPtr) As System.IntPtr
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As System.IntPtr) As Integer

    Public Declare Function RemoveMenu Lib "user32" (ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Long) As IntPtr
    Public Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    Public Declare Function GetMenuItemCount Lib "user32" (ByVal hMenu As IntPtr) As Integer
    Public Declare Function DrawMenuBar Lib "user32" (ByVal hwnd As IntPtr) As Boolean

    Public Function ReadConnString(ByVal fn As String, ByRef gConnectionString As String, Optional ByRef gServerName As String = "", Optional ByRef gPort As String = "", Optional ByRef gUserID As String = "", Optional ByRef gPassword As String = "", Optional ByRef gDatabaseName As String = "") As String
        ReadConnString = ClsXMLHandler.ReadConnString(fn, gConnectionString, gServerName, gPort, gUserID, gPassword, gDatabaseName)
    End Function

    Public Function WriteConnString(ByVal fn As String,
                                    ByVal gServerName As String,
                                    ByVal gPort As String,
                                    ByVal gUserID As String,
                                    ByVal gPassword As String,
                                    ByVal gDatabaseName As String,
                                    ByRef myFileStream As System.IO.FileStream
                                    ) As Boolean
        WriteConnString = ClsXMLHandler.WriteConnString(fn, gServerName, gPort, gUserID, gPassword, gDatabaseName, myFileStream)
    End Function

    Public Function Prompt_User(ByVal MessageType As String, ByVal Message As String) As DialogResult
        Prompt_User = ClsMessageDialog.Prompt_User(MessageType, Message)
    End Function

    Public Function MySQLRunning(ByVal ConnStringFileName As String) As Boolean
        MySQLRunning = ClsMysqlHandler.MySQLRunning(ConnStringFileName)
    End Function


    Public ConnectionStateString As String
    Public ConnectionQualityString As String = "Off"
    Public ConnectionColor As Color
    Public Function CheckInetConnection() As Boolean
        ClsNetworkHandler.CheckInetConnection()
        ConnectionQualityString = ClsNetworkHandler.ConnectionQualityString
        ConnectionStateString = ClsNetworkHandler.ConnectionStateString
        ConnectionColor = ClsNetworkHandler.ConnectionColor
    End Function



    Public Function ReplaceSingleQuotes(ByVal Param As String) As String
        ReplaceSingleQuotes = ClsStringHandler.ReplaceSingleQuotes(Param)
    End Function

    Public Function Crypt(ByVal Text As String) As String
        Crypt = ClsSecurityHandler.Crypt(Text)
    End Function

    Public Sub SaveRegistrySetting(ByVal strSection As String, ByVal strKey As String, ByVal strVal As String)
        SaveSetting(ModApp.AssemblyTitle, strSection, strKey, strVal)
    End Sub

    Public Function GetRegistrySetting(ByVal strSection As String, ByVal strKey As String) As String
        GetRegistrySetting = GetSetting(ModApp.AssemblyTitle, strSection, strKey)
    End Function

    Public Sub Disable_Field_Context_Menu(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef txtBox As TextBox)
        If e.Button = MouseButtons.Right Then
            txtBox.ContextMenu = New ContextMenu
        End If
    End Sub

    Public Sub Key_Down(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.Insert Then
            e.Handled = True
        End If
    End Sub


End Class
