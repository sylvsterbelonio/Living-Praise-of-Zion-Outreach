Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO
Imports System.Xml
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Text
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared

Public Class ClsNetworkHandler

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpSFlags As Int32, ByVal dwReserved As Int32) As Boolean
    Public Shared ConnectionStateString As String
    Public Shared ConnectionQualityString As String = "Off"
    Public Shared ConnectionColor As Color

    Public Enum InetConnState
        modem = &H1
        lan = &H2
        proxy = &H4
        ras = &H10
        offline = &H20
        configured = &H40
    End Enum

    Public Shared Function CheckInetConnection() As Boolean

        Dim lngFlags As Long
        CheckInetConnection = False

        If InternetGetConnectedState(lngFlags, 0) Then
            ' True
            If lngFlags And InetConnState.lan Then
                ConnectionStateString = "LAN."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.modem Then
                ConnectionStateString = "Modem."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.configured Then
                ConnectionStateString = "Configured."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.proxy Then
                ConnectionStateString = "Proxy"
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.ras Then
                ConnectionStateString = "RAS."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.offline Then
                ConnectionStateString = "Offline."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            End If
        Else
            ' False
            ConnectionStateString = "Not Connected."
            Select Case ConnectionQualityString
                Case "Good"
                    ConnectionColor = Color.DarkOrange
                    ConnectionQualityString = "Intermittent"
                Case "Intermittent"
                    ConnectionColor = Color.Red
                    ConnectionQualityString = "Off"
                Case "Off"
                    ConnectionColor = Color.Red
                    ConnectionQualityString = "Off"
            End Select
        End If
    End Function
End Class
