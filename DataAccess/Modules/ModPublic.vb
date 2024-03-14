Module ModPublic
    Friend gConnStringFileName As String
    Friend gApplicationPath As String
    Friend gUserID As Integer
    Friend gRoleID As Integer
    Friend ImageDir As String
    Friend PresetDir As String
    Friend ReportDir As String
    Friend PluginDir As String

    Public Current_State As String
    Public Use_Record_State As String
    Public Use_Record_Id As String
    Public Use_Record_Cd As String
    Public Use_Record_Name As String

    Public Add_Permission As Integer
    Public Edit_Permission As Integer
    Public Delete_Permission As Integer
    Public View_Permission As Integer
    Public Approve_Permission As Integer

    'Recordset
    Public Const RETURN_TYPE_DATASET = "DATASET"
    Public Const RETURN_TYPE_DATATABLE = "DATATABLE"

    Public Const ADD_STATE = "Add"
    Public Const VIEW_STATE = "View"
    Public Const EDIT_STATE = "Edit"
    Public Const USE_STATE = "Use"
    Public Const APPROVE_STATE = "Approve"

    'Generic Message
    Public Const MSGBOX_SAVE_SUCCESSFUL = "Record has been saved successfully."
    Public Const MSGBOX_OPEN_EXPORTED_FILE_PROMPT = "Records has been exported successfully. Do you want to open your previously exported table?"
    Public Const MSGBOX_ADDED_SUCCESSFUL = "Record has been added succesfully."
    Public Const MSGBOX_CLEARED_SUCCESSFUL = "Record has been cleared."
    Public Const MSGBOX_DELETE_SUCCESSFUL = "Record has been deleted."
    Public Const MSGBOX_CANCEL_CONFIRMATION = "Are you sure you want to cancel changes made?"
    Public Const MSGBOX_DELETE_CONFIRMATION = "Are you sure you want to delete this record?"
    Public Const MSGBOX_REQUIRED_VALIDATION = "Please enter all required fields."
    Public Const MSGBOX_APPROVAL_CONFIRMATION = "Are you sure you want to approve changes made in this record?"
    Public Const MSGBOX_APPROVED_SUCCESSFUL = "Record has been approved."
    Public Const MSGBOX_PROVIDE_PASSWORD = "Please provide password for the given user name."
    Public Const MSGBOX_VERIFY_PASSWORD = "Error in saving new user record. Please verify password provided."
    Public Const MSGBOX_PROVIDE_USERNAME = "Error in saving new user record. Please provide user name for the given password."

    Public Const MSGBOX_CANCEL_SUCCESSFUL = "Record has been cancelled."
    Public Const MSGBOX_INACTIVE_SUCCESSFUL = "Record has been set inactive."
    Public Const MSGBOX_INACTIVE_CONFIRMATION = "Are you sure you want to set this record as inactive?"

    'API Constant Declarations
    Public Const SW_HIDE As Integer = 0
    Public Const SW_NORMAL = 1
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_MINIMIZE As Integer = 6
    Public Const SW_RESTORE As Integer = 9

    Public Const MF_BYPOSITION = &H400
    Public Const MF_REMOVE = &H1000
    Public Const MF_DISABLED = &H2

    Public Const WM_CAP_START = &H400S
    Public Const WS_CHILD = &H40000000
    Public Const WS_VISIBLE = &H10000000

    Public Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Public Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Public Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Public Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Public Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23

    Public Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Public Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Public Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50

    Public Const SWP_NOMOVE = &H2S
    Public Const SWP_NOSIZE = 1
    Public Const SWP_NOZORDER = &H4S
    Public Const HWND_BOTTOM = 1

End Module
