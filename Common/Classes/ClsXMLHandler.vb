Imports System.Xml
Imports System.IO

Public Class ClsXMLHandler

    Private Shared p_Doc As New XmlDocument

    'Fetch xml file
    Public Shared Function ReadConnString(ByVal fn As String, ByRef gConnectionString As String, Optional ByRef gServerName As String = "", Optional ByRef gPort As String = "", Optional ByRef gUserID As String = "", Optional ByRef gPassword As String = "", Optional ByRef gDatabaseName As String = "") As String
        Dim Doc As New XmlDocument
        Dim Root As XmlElement

        Try
            Doc.Load(fn)
            Root = Doc.DocumentElement.Item("Connection")

            With Root
                gConnectionString = ClsSecurityHandler.Crypt(.InnerText)
                If gServerName = "" Then
                    gServerName = ClsSecurityHandler.Crypt(.Attributes("Server").InnerText)
                End If
                If gPort = "" Then
                    gPort = ClsSecurityHandler.Crypt(.Attributes("Port").InnerText)
                End If
                If gUserID = "" Then
                    gUserID = ClsSecurityHandler.Crypt(.Attributes("UserID").InnerText)
                End If
                If gPassword = "" Then
                    gPassword = ClsSecurityHandler.Crypt(.Attributes("Password").InnerText)
                End If
                If gDatabaseName = "" Then
                    gDatabaseName = ClsSecurityHandler.Crypt(.Attributes("Database").InnerText)
                End If
            End With

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    'Write xml file
    Public Shared Function WriteConnString(ByVal fn As String,
                                    ByVal gServerName As String,
                                    ByVal gPort As String,
                                    ByVal gUserID As String,
                                    ByVal gPassword As String,
                                    ByVal gDatabaseName As String,
                                    ByRef myFileStream As System.IO.FileStream
                                    ) As Boolean
        Dim Root As XmlElement
        Dim Path As String
        Dim Reader As System.IO.StreamReader
        Dim tStr As String
        Dim aFileInfo As New System.IO.FileInfo(fn)

        Try
            If Not myFileStream Is Nothing Then
                myFileStream.Close()
            End If

            If File.Exists(fn) Then
                If (aFileInfo.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    aFileInfo.Attributes = aFileInfo.Attributes And Not FileAttributes.Hidden
                End If
            End If

            Path = System.IO.Path.GetTempFileName()
            Reader = New System.IO.StreamReader(Path)
            tStr = Reader.ReadToEnd()
            'add the following elements to connection string
            p_Doc = New XmlDocument
            p_Doc.LoadXml("<" + ModApp.AssemblyTitle + " Type='Connection String' Product='" + ModApp.AssemblyProduct + "' Company='" + ModApp.AssemblyCompany + "' Copyright='" + ModApp.AssemblyCopyright + "' Version='" + ModApp.AssemblyVersion + "'>" + tStr + "</" + ModApp.AssemblyTitle + ">")
            Root = p_Doc.DocumentElement
            Dim ConnStr As XmlElement = p_Doc.CreateElement("Connection")
            Dim Server As XmlAttribute = p_Doc.CreateAttribute("Server")
            Dim Port As XmlAttribute = p_Doc.CreateAttribute("Port")
            Dim UserID As XmlAttribute = p_Doc.CreateAttribute("UserID")
            Dim Password As XmlAttribute = p_Doc.CreateAttribute("Password")
            Dim Database As XmlAttribute = p_Doc.CreateAttribute("Database")

            Server.InnerText = ClsSecurityHandler.Crypt(gServerName)
            Port.InnerText = ClsSecurityHandler.Crypt(gPort)
            UserID.InnerText = ClsSecurityHandler.Crypt(gUserID)
            Password.InnerText = ClsSecurityHandler.Crypt(gPassword)
            Database.InnerText = ClsSecurityHandler.Crypt(gDatabaseName)

            With ConnStr.Attributes
                .Append(Server)
                .Append(Port)
                .Append(UserID)
                .Append(Password)
                .Append(Database)
            End With

            ConnStr.InnerText = ClsSecurityHandler.Crypt("server=" & gServerName & "; port=" & gPort & "; uid=" & gUserID & "; pwd=" & gPassword & "; database=" & gDatabaseName & "; pooling=false")
            Root.AppendChild(ConnStr)

            Reader.Close()
            System.IO.File.Delete(Path)

            p_Doc.Save(fn)
            aFileInfo.Attributes = aFileInfo.Attributes Or FileAttributes.Hidden
            Return True
        Catch ex As System.Exception
            Throw ex
            Return False
        End Try
    End Function

End Class
