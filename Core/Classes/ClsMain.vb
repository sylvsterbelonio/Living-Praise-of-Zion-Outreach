Imports MySql.Data.MySqlClient

Namespace Main
    Public Class Main
        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Public dtMain As DataSet
        Public dtSub As DataSet
        Public dtToolBar As DataSet
        Private dtCheck As DataSet
        Private dtRowCheck As DataRow

        Private RoleId As Integer
        Private UserId As Integer
        Private intChildCount As Integer
        Private ParentId As Integer
        Private sqlStmt As String

        Private intUserID As Integer
        Private intLogType As String
        Private intLogDetail As String

#Region "Class Main Public Property Declaration"

        Public WriteOnly Property Role_Id() As Integer
            Set(ByVal Value As Integer)
                RoleId = Value
            End Set
        End Property

        Public WriteOnly Property User_Id() As Integer
            Set(ByVal Value As Integer)
                UserId = Value
            End Set
        End Property

        Public ReadOnly Property intChild_Count() As Integer
            Get
                Return intChildCount
            End Get
        End Property

        Public ReadOnly Property dt_Main() As DataSet
            Get
                Return dtMain
            End Get
        End Property

        Public ReadOnly Property dt_Sub() As DataSet
            Get
                Return dtSub
            End Get
        End Property

        Public WriteOnly Property Parent_Id() As Integer
            Set(ByVal Value As Integer)
                ParentId = Value
            End Set
        End Property

        Public Property int_UserID() As Integer
            Get
                Return intUserID
            End Get
            Set(ByVal value As Integer)
                If intUserID = value Then
                    Return
                End If
                intUserID = value
            End Set
        End Property

        Public Property int_LogType() As String
            Get
                Return intLogType
            End Get
            Set(ByVal value As String)
                If intLogType = value Then
                    Return
                End If
                intLogType = value
            End Set
        End Property

        Public Property int_LogDetail() As String
            Get
                Return intLogDetail
            End Get
            Set(ByVal value As String)
                If intLogDetail = value Then
                    Return
                End If
                intLogDetail = value
            End Set
        End Property

#End Region

#Region "DYNAMIC MENU POPULATE"

        Public Sub PopulateMainMenu()
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL sp_Main_Menu_Get(" & CStr(RoleId) & ");"
                dtMain = clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATASET)

            Catch ex As MySqlException
                'error was encountered while populating record
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
        End Sub

        Public Sub CheckIfMenuHasChild()
            Dim sqlStmt As String

            intChildCount = 0

            Try
                sqlStmt = "CALL sp_Main_Menu_Get_Child_Count(" & CStr(ParentId) & "," & CStr(RoleId) & ");"
                Me.dtCheck = clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATASET)

                For Each Me.dtRowCheck In Me.dtCheck.Tables(0).Rows
                    intChildCount = Me.dtRowCheck(0)
                Next
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
        End Sub

        Public Sub PopulateSubMenu()
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL sp_Main_Menu_Sub_Get(" & CStr(ParentId) & "," & CStr(RoleId) & ");"
                dtSub = clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATASET)

            Catch ex As MySqlException
                'error was encountered while populating record
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
        End Sub

#End Region
    End Class
End Namespace

