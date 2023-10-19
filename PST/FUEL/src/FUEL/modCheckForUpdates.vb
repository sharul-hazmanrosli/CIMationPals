Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports RDL
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading

Namespace FUEL
    <StandardModule> _
    Friend NotInheritable Class modCheckForUpdates
        ' Methods
        <DebuggerStepThrough, CompilerGenerated> _
        Private Shared Sub _Lambda$__1(ByVal a0 As Object)
            modCheckForUpdates.CheckForUpdates(DirectCast(Conversions.ToInteger(a0), CheckType))
        End Sub

        Friend Shared Sub CheckForUpdate(ByVal FUELType As CheckType)
            Try 
                Dim flag As Boolean = True
                Try 
                    If modCheckForUpdates.thdUpdateCheck.IsAlive Then
                        flag = False
                    End If
                Catch exception1 As NullReferenceException
                    Dim ex As NullReferenceException = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As NullReferenceException = ex
                    flag = True
                    ProjectData.ClearProjectError
                End Try
                If Not New NetworkConnection().CheckForNetworkConnection(Nothing) Then
                    flag = False
                End If
                If (flag AndAlso (DateAndTime.DateDiff("h", MySettingsProperty.Settings.UpdateCheck.ToString, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > &H18)) Then
                    modCheckForUpdates.thdUpdateCheck = New Thread(New ParameterizedThreadStart(AddressOf modCheckForUpdates._Lambda$__1))
                    modCheckForUpdates.thdUpdateCheck.IsBackground = True
                    modCheckForUpdates.thdUpdateCheck.Start(FUELType)
                End If
            Catch exception3 As Exception
                Dim ex As Exception = exception3
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(("Error while checking for update." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & ex.ToString), MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Shared Sub CheckForUpdates(ByVal FUELType As CheckType)
            MySettingsProperty.Settings.UpdateCheck = DateAndTime.Now
            MySettingsProperty.Settings.Save
            Dim dLLocation As String = "\\vcslab.vcd.hp.com\root\InkSystems\SPHINKS\Randal Morrison\FUEL\VersionInfo.txt"
            Dim updates As New CheckForUpdates(dLLocation, Path.Combine(modCommonCode.GetDataPath, "VersionInfo.txt"), FUELType)
            If Operators.ConditionalCompareObjectNotEqual(updates.UpdateAvailable, UpdateType.None, False) Then
                Dim strArray As String()
                Dim prompt As String = Nothing
                Dim title As String = "Update Available"
                Dim flag As Boolean = False
                If Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(updates.UpdateAvailable, UpdateType.OptionalUpdate, False), (FUELType <> CheckType.PST))) Then
                    strArray = New String() { "There is a new version of FUEL available." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Installed Version: ", updates.CurrentVersion, ChrW(13) & ChrW(10) & "New Version: ", updates.ServerVersion, ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Go to the location below to install the new version:" & ChrW(13) & ChrW(10), Path.GetDirectoryName(dLLocation) }
                    prompt = String.Concat(strArray)
                    flag = True
                ElseIf Operators.ConditionalCompareObjectEqual(updates.UpdateAvailable, UpdateType.RequiredUpdate, False) Then
                    strArray = New String() { "There is a CRITICAL new version of FUEL available." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Installed Version: ", updates.CurrentVersion, ChrW(13) & ChrW(10) & "New Version: ", updates.ServerVersion, ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Critical updates are reserved for occasions where a significant bug was fixed, or a required new feature was added. Please update your version of FUEL as soon as possible." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Go to the location below to install the new version:" & ChrW(13) & ChrW(10), Path.GetDirectoryName(dLLocation) }
                    prompt = String.Concat(strArray)
                    title = "Critical Update Available"
                    flag = True
                End If
                If flag Then
                    Interaction.MsgBox(prompt, MsgBoxStyle.ApplicationModal, title)
                End If
            End If
        End Sub


        ' Fields
        Private Shared thdUpdateCheck As Thread
    End Class
End Namespace

