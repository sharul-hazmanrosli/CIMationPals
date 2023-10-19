Imports FUEL.FS
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO

Namespace FUEL
    Public Class FUELLog
        ' Methods
        Public Sub New()
            Me._LogFileInfo = MyProject.Computer.FileSystem.GetFileInfo(Me.LogFileName)
            If (MyProject.Computer.FileSystem.FileExists(Me.LogFileName) AndAlso ((CDbl(Me._LogFileInfo.Length) / 1048576) > 2)) Then
                Dim newName As String = (Path.GetFileNameWithoutExtension(Me.LogFileName) & " - Log Archive - " & DateAndTime.Now.Ticks.ToString & ".log")
                MyProject.Computer.FileSystem.RenameFile(Me.LogFileName, newName)
            End If
        End Sub

        Public Function ReadLastLine() As String
            Dim str As String
            If Not MyProject.Computer.FileSystem.FileExists(Me.LogFileName) Then
                str = "No log file found"
            Else
                Dim expression As String = Conversions.ToString(FileProcessing.ReadFile(Me.LogFileName))
                Dim array As String() = Nothing
                If (expression <> Nothing) Then
                    array = Strings.Split(expression, ChrW(13) & ChrW(10), -1, CompareMethod.Binary)
                End If
                str = array(Information.UBound(array, 1))
            End If
            Return str
        End Function

        Public Function ReadLog() As String
            Return If(Not MyProject.Computer.FileSystem.FileExists(Me.LogFileName), "No log file found", Conversions.ToString(FileProcessing.ReadFile(Me.LogFileName)))
        End Function

        Public Sub WriteLog(ByVal Sender As Object, ByVal Msg As String, ByVal EntryType As EventLogEntryType)
            Dim now As DateTime = DateAndTime.Now
            Dim directoryName As String = Path.GetDirectoryName(Me.LogFileName)
            If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                MyProject.Computer.FileSystem.CreateDirectory(directoryName)
            End If
            Dim strArray As String() = New String() { now.ToString, ChrW(9), Sender.ToString, ChrW(9), EntryType.ToString, ChrW(9), Msg, ChrW(13) & ChrW(10) }
            Dim textToWrite As String = String.Concat(strArray)
            Try 
                FileProcessing.WriteToFile(Me.LogFileName, textToWrite, True)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub


        ' Properties
        Public ReadOnly Property LogFileName As String
            Get
                Return Me._LogFileName
            End Get
        End Property

        Public ReadOnly Property LastWriteTime As DateTime
            Get
                Return Me._LogFileInfo.LastWriteTime
            End Get
        End Property


        ' Fields
        Private _LogFileName As String = Path.Combine(modCommonCode.GetDataPath, "FUEL.Log")
        Private _LogFileInfo As FileInfo
    End Class
End Namespace

