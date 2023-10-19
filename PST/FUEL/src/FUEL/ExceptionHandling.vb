Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports System
Imports System.Diagnostics

Namespace FUEL
    Public Class ExceptionHandling
        ' Methods
        Public Shared Sub UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            Dim str2 As String = String.Format("FUEL has encountered an error. {0}The exception has been logged in the system events log. {0} {0}The following is a description of the error: {0}", ChrW(13) & ChrW(10))
            Dim msg As String = String.Format("Sender: {1} {0}Type: {2} {0}Message: {3}", New Object() { ChrW(13) & ChrW(10), sender.ToString, "UnhandledException", e.Exception.Message.ToString })
            SysEventLog.WriteLog("FUEL", msg, EventLogEntryType.Error)
            New FUELLog().WriteLog(sender, msg, EventLogEntryType.Error)
            Interaction.MsgBox((str2 & ChrW(13) & ChrW(10) & msg), MsgBoxStyle.Critical, Nothing)
            e.ExitApplication = False
        End Sub

    End Class
End Namespace

