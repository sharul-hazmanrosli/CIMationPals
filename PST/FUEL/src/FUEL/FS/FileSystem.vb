Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.IO

Namespace FUEL.FS
    Public Class FileSystem
        ' Methods
        Public Shared Function CheckDirectoryExists(ByVal DirName As String) As Boolean
            Return MyProject.Computer.FileSystem.DirectoryExists(DirName)
        End Function

        Public Shared Function CheckFileExists(ByVal FileName As String) As Boolean
            Return MyProject.Computer.FileSystem.FileExists(FileName)
        End Function

        Public Shared Sub CopyFile(ByVal SourceFile As String, ByVal DestFile As String)
            SourceFile = FileSystem.SetPath(SourceFile, FilePurpose.ForReading)
            MyProject.Computer.FileSystem.CopyFile(SourceFile, DestFile)
        End Sub

        Public Shared Sub CreateDir(ByVal DirectoryName As String)
            MyProject.Computer.FileSystem.CreateDirectory(DirectoryName)
        End Sub

        Public Shared Sub DeleteFile(ByVal FileName As String)
            FileSystem.DeleteFile(FileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin)
        End Sub

        Public Shared Sub DeleteFile(ByVal FileName As String, ByVal Dialogs As UIOption, ByVal Reycle As RecycleOption)
            MyProject.Computer.FileSystem.DeleteFile(FileName, Dialogs, RecycleOption.SendToRecycleBin)
        End Sub

        Public Shared Function SetPath(ByVal Path As String) As Object
            Return FileSystem.SetPath(Path, FilePurpose.ForWriting)
        End Function

        Public Shared Function SetPath(ByVal Path As String, ByVal Purpose As FilePurpose) As String
            Dim str As String
            Try 
                Dim directoryName As String = Path.GetDirectoryName(Path)
                Dim fileName As String = Path.GetFileName(Path)
                If (Purpose = FilePurpose.ForReading) Then
                    If (fileName = Nothing) Then
                        Throw New ArgumentException("No file name specified", Path)
                    End If
                    If Not MyProject.Computer.FileSystem.FileExists(Path.Combine(directoryName, fileName)) Then
                        Throw New ArgumentException(("The file '" & fileName & "' does not exist"), Path)
                    End If
                ElseIf ((Purpose = FilePurpose.ForWriting) AndAlso Not MyProject.Computer.FileSystem.DirectoryExists(directoryName)) Then
                    If (Interaction.MsgBox(("The directory '" & directoryName.ToString & "' does not exist. Would you like me to create it?"), MsgBoxStyle.YesNo, Nothing) <> MsgBoxResult.Yes) Then
                        Throw New ApplicationException(("The directory '" & directoryName & "' does not exist"))
                    End If
                    Try 
                        MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                    Catch exception1 As Exception
                        Dim ex As Exception = exception1
                        ProjectData.SetProjectError(ex)
                        Dim exception As Exception = ex
                        Throw
                    End Try
                End If
                str = Path
            Catch exception3 As ApplicationException
                Dim ex As ApplicationException = exception3
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.Message.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                str = Nothing
                ProjectData.ClearProjectError
            End Try
            Return str
        End Function

    End Class
End Namespace

