Imports FUEL.My
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Xml.Serialization

Namespace FUEL
    Public Class Serializer
        ' Methods
        Public Shared Function DeserializeMe(ByVal SpecFileName As String) As SpecFile
            Dim file2 As New SpecFile
            Logging.AddLogEntry("Serializer", "DeserializeMe: Starting", EventLogEntryType.Information, 4)
            If Not MyProject.Computer.FileSystem.FileExists(SpecFileName) Then
                Logging.AddLogEntry("Serializer", ("DeserializeMe: SpecFile doesnt exist: " & SpecFileName), EventLogEntryType.Error, 0)
            Else
                Dim stream As New FileStream(SpecFileName, FileMode.Open)
                file2 = DirectCast(New XmlSerializer(GetType(SpecFile)).Deserialize(stream), SpecFile)
                stream.Close
            End If
            Logging.AddLogEntry("Serializer", "DeserializeMe: Complete", EventLogEntryType.Information, 4)
            Return file2
        End Function

        Public Shared Function GetTestSpecs(ByVal TestID As String, ByVal TestSpecs As SpecFile) As TestSpecs
            Dim num As Integer = -1
            Dim num3 As Integer = (TestSpecs.Tests.Count - 1)
            Dim num2 As Integer = 0
            Do While True
                Dim num4 As Integer = num3
                If (num2 > num4) Then
                    If (num = -1) Then
                        Throw New ArgumentException(("Test ID " & TestID & " not found in the SpecFile"))
                    End If
                    Return New TestSpecs With { _
                        .TestID = TestID, _
                        .PST = TestSpecs.Tests(num).PST _
                    }
                End If
                If (TestSpecs.Tests(num2).TestID.ToLower = TestID.ToLower) Then
                    num = num2
                End If
                num2 += 1
            Loop
        End Function

        Public Shared Sub SerializeMe(ByVal PST As PST, ByVal SpecFileName As String)
            Logging.AddLogEntry("Serializer", "SerializeMe: Starting", EventLogEntryType.Information, 4)
            Dim item As New TestSpecs With { _
                .PST = PST _
            }
            Dim o As New SpecFile
            o = Serializer.DeserializeMe(SpecFileName)
            o.Tests.Add(item)
            Try 
                Dim writer As New StreamWriter(SpecFileName)
                New XmlSerializer(GetType(SpecFile)).Serialize(DirectCast(writer, TextWriter), o)
                writer.Close
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Logging.AddLogEntry("Serializer", ("SerializeMe: Error writing spec file..." & ex.ToString), EventLogEntryType.Error, 0)
                ProjectData.ClearProjectError
            End Try
            Logging.AddLogEntry("Serializer", "SerializeMe: Complete", EventLogEntryType.Information, 4)
        End Sub

    End Class
End Namespace

