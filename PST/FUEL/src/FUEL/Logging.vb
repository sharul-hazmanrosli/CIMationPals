Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics

Namespace FUEL
    <StandardModule> _
    Public NotInheritable Class Logging
        ' Methods
        Public Shared Sub AddLogEntry(ByVal Sender As Object, ByVal Msg As String, ByVal EntryType As EventLogEntryType, ByVal Priority As Integer)
            Dim flag2 As Boolean = False
            Dim flag As Boolean = False
            flag2 = True
            If (UploadSettings.DebugLevel >= Priority) Then
                If flag2 Then
                    New FUELLog().WriteLog(Sender, Msg, EntryType)
                End If
                If flag Then
                    SysEventLog.WriteLog("FUEL", Msg, EntryType)
                End If
            End If
        End Sub

    End Class
End Namespace

