Imports MySql.Data.MySqlClient

Namespace LogIn
    Public Class LogIn

#Region "Class Login Private Variable Declaration"

        Private UserID As Integer
        Private FName As String
        Private LName As String
        Private RoleID As Integer
        Private RoleName As String
        Private JobDesc As String
        Private ActiveFl As Integer
        Private OnlineFl As Integer
        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private dtLogin As DataTable
        Private clsCommon As New Common.Common
        Private clsDataAccess As New DataAccess(gConnStringFileName)
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region


#Region "Class Login Public Property Declaration"

        Public ReadOnly Property User_ID()
            Get
                Return UserID
            End Get
        End Property

        Public ReadOnly Property First_Name()
            Get
                Return FName
            End Get
        End Property

        Public ReadOnly Property Last_Name()
            Get
                Return LName
            End Get
        End Property

        Public ReadOnly Property Role_Id()
            Get
                Return RoleID
            End Get
        End Property

        Public ReadOnly Property Role_Name()
            Get
                Return RoleName
            End Get
        End Property

        Public ReadOnly Property Job_Desc() As String
            Get
                Return Me.JobDesc
            End Get
        End Property

        Public Property Active_Fl() As Integer
            Get
                Return ActiveFl
            End Get
            Set(ByVal value As Integer)
                If ActiveFl = value Then
                    Return
                End If
                ActiveFl = value
            End Set
        End Property

        Public Property Online_Fl() As Integer
            Get
                Return OnlineFl
            End Get
            Set(ByVal value As Integer)
                If OnlineFl = value Then
                    Return
                End If
                OnlineFl = value
            End Set
        End Property

#End Region

#Region "Class Login Public Functions"

        Public Function ValidateLogin(ByVal UserName As String, ByVal Password As String, ByVal LoginAttempts As Integer) As Boolean
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL sp_Validate_Log_In('" & clsCommon.ReplaceSingleQuotes(UserName) & "','" & clsCommon.ReplaceSingleQuotes(clsCommon.Crypt(Password)) & "'," & LoginAttempts & ");"
                dtLogin = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                UserID = dtLogin.Rows(0)("User_ID")
                FName = dtLogin.Rows(0)("First_Name")
                LName = dtLogin.Rows(0)("Last_Name")
                RoleID = dtLogin.Rows(0)("Role_Id")
                RoleName = dtLogin.Rows(0)("Role_Name")
                JobDesc = dtLogin.Rows(0)("Job_Desc")
                ActiveFl = dtLogin.Rows(0)("Active_Fl")
                OnlineFl = dtLogin.Rows(0)("Online_Fl")

                If UserID > -1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return False
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Sub SystemUserOnlineUpdate(ByVal uid As Integer, ByVal onlineFl As Integer)
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spSystemUserOnlineUpdate(" & uid & "," & onlineFl & ");"
                clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
        End Sub

#End Region


    End Class
End Namespace

