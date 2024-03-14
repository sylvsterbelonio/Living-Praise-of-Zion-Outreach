Imports System.Xml
Imports System.Windows.Forms

Module ModPublic
    Friend ConnStringFileName As String = modApp.Path + "\ConnString.xml"
    Friend UpdateManifestFileName As String = modApp.Path + "\UpdateManifest.xml"
    Friend ImageDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & modApp.AssemblyProduct & "\images"
    Friend PresetDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & modApp.AssemblyProduct & "\presets"
    Friend ReportDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & modApp.AssemblyProduct & "\templates"
    Friend PluginDir As String = modApp.Path & "\Plugin"
    Friend FTPHost As String = "ftp.jamediasolutions.net"
    Friend FTPUser As String = "update@jamediasolutions.net"
    Friend FTPPswrd As String = "z3tVV}a!Hc>."
    Friend myFileStream As System.IO.FileStream

    Public isRequiredToChangePassword As Boolean = True
    Public LogIn_Success As Boolean = True
    Public Current_State As String
    Public App_User As String
    Public App_UserID As Integer
    Public App_FName As String
    Public App_LName As String
    Public Role_ID As Integer
    Public App_Role As String
    Public Job_Desc As String
    Public Current_Date As String
    Public Connection_String As String
    Public Server_Name As String
    Public Port As String
    Public UserID As String
    Public Password As String
    Public Database_Name As String

    Public Use_Record_State As String
    Public Use_Record_Id As String
    Public Use_Record_Cd As String
    Public Use_Record_Name As String

    'Recordset
    Public Const RETURN_TYPE_DATASET = "DATASET"
    Public Const RETURN_TYPE_DATATABLE = "DATATABLE"

    'Form State
    Public Const ADD_STATE = "Add"
    Public Const VIEW_STATE = "View"
    Public Const EDIT_STATE = "Edit"
    Public Const USE_STATE = "Use"
    Public Const APPROVE_STATE = "Approve"

    'Generic Message
    Public Const MSGBOX_SAVE_SUCCESSFUL = "Record has been saved successfully."
    Public Const MSGBOX_OPEN_EXPORTED_FILE_PROMPT = "Records has been exported successfully. Do you want to open your previously exported table?"
    Public Const MSGBOX_ADDED_SUCCESSFUL = " record has been added succesfully."
    Public Const MSGBOX_CLEARED_SUCCESSFUL = "Record has been cleared."
    Public Const MSGBOX_DELETE_SUCCESSFUL = "Record has been deleted."
    Public Const MSGBOX_CANCEL_CONFIRMATION = "Are you sure you want to cancel changes made?"
    Public Const MSGBOX_DELETE_CONFIRMATION = "Are you sure you want to delete this record?"
    Public Const MSGBOX_REQUIRED_VALIDATION = "Please enter all required fields."
    Public Const MSGBOX_EXIT_CONFIRMATION = "Are you sure you want to exit application?"

    'API Constant Declarations
    Public Const SW_HIDE As Integer = 0
    Public Const SW_NORMAL = 1
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_MINIMIZE As Integer = 6
    Public Const SW_RESTORE As Integer = 9

    Public Const MF_BYPOSITION = &H400
    Public Const MF_REMOVE = &H1000
    Public Const MF_DISABLED = &H2

    Public Enum Hash_Codes As Long
        Add = 65537
        Edit = 327685
        Delete = 262148
        Find = 393222
        Save = 1245203
        Cancel = 1769499
        Enter_Key = 851981
        History = 524296
    End Enum

End Module
