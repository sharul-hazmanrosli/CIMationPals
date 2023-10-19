Imports FUEL.My
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Xml.Serialization

Namespace FUEL
    Public Class SettingsSerializer
        ' Methods
        Public Shared Function DeSerialize(ByVal FileName As String) As clsUploadSettings2
            Dim settings As clsUploadSettings2
            Dim settings2 As New clsUploadSettings2
            If Not MyProject.Computer.FileSystem.FileExists(FileName) Then
                settings = Nothing
            Else
                Dim stream As New FileStream(FileName, FileMode.Open)
                settings2 = DirectCast(New XmlSerializer(GetType(clsUploadSettings2)).Deserialize(stream), clsUploadSettings2)
                stream.Close
                settings = settings2
            End If
            Return settings
        End Function

        Public Shared Sub Serialize(ByVal Setting As clsUploadSettings2)
            Logging.AddLogEntry("SettingsSerializer", "Serialize: Starting", EventLogEntryType.Information, 4)
            Try 
                Dim writer As New StreamWriter(Setting.SettingsFileLocation)
                New XmlSerializer(GetType(clsUploadSettings2)).Serialize(DirectCast(writer, TextWriter), Setting)
                writer.Close
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                ProjectData.ClearProjectError
            End Try
        End Sub

    End Class
End Namespace

