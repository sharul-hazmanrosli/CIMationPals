Imports FUEL
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Text

Namespace FUEL.FS
    Public Class FileProcessing
        ' Methods
        Public Shared Function ReadDelimitedFile(ByVal Path As String, ByVal Delimiter As String) As String(0 To .,0 To .)
            Return FileProcessing.ReadDelimitedFile(Path, Delimiter, Nothing, -1, -1)
        End Function

        Public Shared Function ReadDelimitedFile(ByVal Path As String, ByVal Delimiter As String, ByVal CommentTokens As String()) As String(0 To .,0 To .)
            Return FileProcessing.ReadDelimitedFile(Path, Delimiter, CommentTokens, -1, -1)
        End Function

        Private Shared Function ReadDelimitedFile(ByVal Path As String, ByVal Delimiter As String, ByVal CommentTokens As String(), ByVal MaxFieldCnt As Integer, ByVal LineCnt As Long) As String(0 To .,0 To .)
            Dim path As String = Nothing
            Try 
                path = FileSystem.SetPath(Path, FilePurpose.ForReading)
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Throw
            End Try
            Dim flag As Boolean = False
            Dim strArray3(,) As String(0 To .,0 To .) = Nothing
            If (MaxFieldCnt <> -1) Then
                flag = True
                strArray3 = New String((CInt((LineCnt - 1)) + 1)  - 1, ((MaxFieldCnt - 1) + 1)  - 1) {}
            End If
            Dim objA As New TextFieldParser(path)
            Try 
                Dim delimiters As String() = New String() { Delimiter }
                objA.SetDelimiters(delimiters)
                objA.CommentTokens = CommentTokens
                objA.TrimWhiteSpace = True
                Dim num As Integer = 0
                Do While True
                    If objA.EndOfData Then
                        Exit Do
                    End If
                    Dim strArray As String() = objA.ReadFields
                    If Not flag Then
                        If (strArray.Length > MaxFieldCnt) Then
                            MaxFieldCnt = strArray.Length
                        End If
                    Else
                        Dim num3 As Integer = (strArray.Length - 1)
                        Dim index As Integer = 0
                        Do While True
                            Dim num4 As Integer = num3
                            If (index > num4) Then
                                num += 1
                                Exit Do
                            End If
                            strArray3(num, index) = strArray(index)
                            index += 1
                        Loop
                    End If
                    If (objA.LineNumber <> -1) Then
                        LineCnt = objA.LineNumber
                    ElseIf ((objA.LineNumber <> -1) And (LineCnt = -1)) Then
                        LineCnt = 1
                    End If
                Loop
            Finally
                If Not Object.ReferenceEquals(objA, Nothing) Then
                    DirectCast(objA, IDisposable).Dispose
                End If
            End Try
            Return If(Not flag, FileProcessing.ReadDelimitedFile(Path, Delimiter, CommentTokens, MaxFieldCnt, LineCnt), strArray3)
        End Function

        Public Shared Function ReadFile(ByVal Path As String) As Object
            Dim file As String = FileSystem.SetPath(Path, FilePurpose.ForReading)
            Return MyProject.Computer.FileSystem.ReadAllText(file)
        End Function

        Public Shared Sub WriteDelimitedFile(ByVal Path As String, ByVal Header As String(), ByVal Body As String(0 To .,0 To .), ByVal Delimiter As String)
            FileProcessing.WriteDelimitedFile(Path, Header, Body, Delimiter, True)
        End Sub

        Public Shared Sub WriteDelimitedFile(ByVal Path As String, ByVal Header As String(), ByVal Body As String(0 To .,0 To .), ByVal Delimiter As String, ByVal AppendWriteExistingFile As Boolean)
            Dim file As String = FileSystem.SetPath(Path, FilePurpose.ForWriting)
            Dim builder As New StringBuilder
            If (Not MyProject.Computer.FileSystem.FileExists(file) And (Not Header Is Nothing)) Then
                builder.Append(Strings.Join(Header, Delimiter)).AppendLine
            End If
            Dim num3 As Integer = Information.UBound(Body, 1)
            Dim num As Integer = 0
            Do While (num <= num3)
                Dim str4 As String = Nothing
                Dim num4 As Integer = Information.UBound(Body, 2)
                Dim num2 As Integer = 0
                Do While True
                    Dim num5 As Integer = num4
                    If (num2 > num5) Then
                        builder.Append(str4).AppendLine
                        num += 1
                        Exit Do
                    End If
                    str4 = (str4 & Body(num, num2))
                    If (num2 < Information.UBound(Body, 2)) Then
                        str4 = (str4 & Delimiter)
                    End If
                    num2 += 1
                Loop
            Loop
            MyProject.Computer.FileSystem.WriteAllText(file, builder.ToString, AppendWriteExistingFile)
        End Sub

        Public Shared Sub WriteToFile(ByVal Filename As String, ByVal TextToWrite As String, ByVal Append As Boolean)
            Filename = FileSystem.SetPath(Filename, FilePurpose.ForWriting)
            MyProject.Computer.FileSystem.WriteAllText(Filename, TextToWrite, Append)
        End Sub

        Public Shared Sub ZipFiles(ByVal SourceDir As String, ByVal OutputName As String)
            FileProcessing.ZipFiles(SourceDir, OutputName, 0, False)
        End Sub

        Public Shared Sub ZipFiles(ByVal SourceDir As String, ByVal OutputName As String, ByVal MaxFileSize As Double)
            FileProcessing.ZipFiles(SourceDir, OutputName, MaxFileSize, False)
        End Sub

        Public Shared Sub ZipFiles(ByVal SourceDir As String, ByVal OutputName As String, ByVal MaxFileSize As Double, ByVal DeleteFiles As Boolean)
            Dim progress As New frmZipProgress(SourceDir, OutputName, DeleteFiles) With { _
                .MaxFileSize = CLng(Math.Round(MaxFileSize)) _
            }
            Dim aHandle As IntPtr = PST.getOwner
            If (aHandle <> DirectCast(-1, IntPtr)) Then
                progress.ShowDialog(New WindowWrapper(aHandle))
            Else
                progress.ShowDialog
            End If
        End Sub

    End Class
End Namespace

