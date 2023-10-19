Imports System
Imports System.Diagnostics

Namespace FUEL
    Public Class SysEventLog
        ' Methods
        Public Shared Sub WriteLog(ByVal LogName As String, ByVal Msg As String, ByVal EntryType As EventLogEntryType)
            If Not EventLog.SourceExists(LogName) Then
                EventLog.CreateEventSource(LogName, LogName)
            End If
            EventLog.WriteEntry(LogName, Msg, EntryType)
        End Sub

    End Class
End Namespace

