Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports FUEL.FS
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports RDL
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Web.Script.Serialization
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class ctrlUploadFiles
        Inherits UserControl
        ' Events
        Public Custom Event JobComplete As JobCompleteEventHandler
            AddHandler(ByVal obj As JobCompleteEventHandler)
                Me.JobCompleteEvent = (Me.JobCompleteEvent + obj)
            End AddHandler
            RemoveHandler(ByVal obj As JobCompleteEventHandler)
                Me.JobCompleteEvent = (Me.JobCompleteEvent - obj)
            End RemoveHandler
        End Event

        ' Methods
        Public Sub New(ByVal FileList As Collection(Of String), ByVal TestSite As TestSites, ByVal Destination As TestSites)
            AddHandler MyBase.Disposed, New EventHandler(AddressOf Me.ctrlUploadFiles_Disposed)
            ctrlUploadFiles.__ENCAddToList(Me)
            Me._UploadInProgress = False
            Me._ErrorList = Nothing
            Me.WaitAllEvents = New AutoResetEvent(1  - 1) {}
            Try 
                Logging.AddLogEntry(Me, "ctrlUploadFiles Instantiated", EventLogEntryType.Information, 4)
                Me.InitializeComponent
                Me._SrcFileList = FileList
                Me._FileDir = Path.GetDirectoryName(FileList(0))
                Me._DestinationSite = Destination
                Me._TestSite = TestSite
                Me.rtbResponseWindow.Visible = False
            Catch exception1 As ArgumentOutOfRangeException
                Dim ex As ArgumentOutOfRangeException = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As ArgumentOutOfRangeException = ex
                Logging.AddLogEntry(Me, "ctrlUploadFiles: can't instantiate, the FileList is empty.", EventLogEntryType.Error, 0)
                Interaction.MsgBox("The list of files to upload is empty.", MsgBoxStyle.Critical, Nothing)
                Me.Dispose
                ProjectData.ClearProjectError
            Catch exception3 As Exception
                Dim ex As Exception = exception3
                ProjectData.SetProjectError(ex)
                Dim exception2 As Exception = ex
                Throw
            End Try
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlUploadFiles.__ENCList
                If (ctrlUploadFiles.__ENCList.Count = ctrlUploadFiles.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlUploadFiles.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlUploadFiles.__ENCList.RemoveRange(index, (ctrlUploadFiles.__ENCList.Count - index))
                            ctrlUploadFiles.__ENCList.Capacity = ctrlUploadFiles.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlUploadFiles.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlUploadFiles.__ENCList(index) = ctrlUploadFiles.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlUploadFiles.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub AddFileToList(ByVal FileName As String, ByVal Success As Boolean)
            Dim item As New FileUploads With { _
                .FileName = FileName.ToString, _
                .FileFinalized = Conversions.ToBoolean(ctrlUploadFiles.DetermineIfFileIsFinalized(ctrlUploadFiles.ParseFileName(FileName)).ToString), _
                .UploadDate = Conversions.ToDate(DateAndTime.Now.ToString), _
                .Success = Conversions.ToBoolean(Success.ToString) _
            }
            Me.RemoveEntryFromFileList(item.FileName)
            Me._FileUploadList.Add(item)
        End Sub

        Private Sub ChangeFileHiddenAttribute(ByVal Path As String, ByVal Hide As Boolean)
            If File.Exists(Path) Then
                Dim attributes As FileAttributes = File.GetAttributes(Path)
                If Not Hide Then
                    attributes = Me.RemoveAttribute(attributes, FileAttributes.Hidden)
                    File.SetAttributes(Path, attributes)
                    Console.WriteLine("The {0} file is no longer hidden.", Path)
                ElseIf Hide Then
                    File.SetAttributes(Path, (File.GetAttributes(Path) Or FileAttributes.Hidden))
                    Console.WriteLine("The {0} file is now hidden.", Path)
                End If
            End If
        End Sub

        Public Shared Function CheckForFileInList(ByVal FileName As String, ByVal FileUploadList As List(Of FileUploads)) As Boolean
            Dim num2 As Integer = (FileUploadList.Count - 1)
            Dim num As Integer = 0
            Do While True
                Dim flag As Boolean
                Dim num3 As Integer = num2
                If (num > num3) Then
                    flag = False
                Else
                    If (FileUploadList(num).FileName <> FileName) Then
                        num += 1
                        Continue Do
                    End If
                    flag = True
                End If
                Return flag
            Loop
        End Function

        Private Sub ctrlUploadFiles_Disposed(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Object.ReferenceEquals(Me.thdUpload, Nothing) AndAlso Me.thdUpload.IsAlive) Then
                Me.thdUpload.Abort
            End If
        End Sub

        Private Function DecodeJSON(ByVal strJSON As String) As ServerResponse
            Dim response As ServerResponse
            If (strJSON = Nothing) Then
                response = Nothing
            Else
                Dim dictionary As Dictionary(Of String, Object) = DirectCast(New JavaScriptSerializer().DeserializeObject(strJSON), Dictionary(Of String, Object))
                response = New ServerResponse With { _
                    .FileName = Conversions.ToString(dictionary("filename")), _
                    .FinalDestination = Conversions.ToString(dictionary("finaldestination")), _
                    .Status = Conversions.ToString(dictionary("status")) _
                }
            End If
            Return response
        End Function

        Public Shared Function DetermineIfFileIsFinalized(ByVal File As FileInfo) As Boolean
            Dim flag As Boolean
            Logging.AddLogEntry("ctrlUploadFiles:DetermineIfFileIsFinalized: ", ("FileName: " & File.FileName), EventLogEntryType.Information, 2)
            If Not File.ValidName Then
                Logging.AddLogEntry("ctrlUploadFiles:DetermineIfFileIsFinalized: ", "filename not valid", EventLogEntryType.Information, 3)
                flag = True
            ElseIf (File.FileType = FileType.Daily) Then
                Dim num As Integer = CInt(DateAndTime.DateDiff(DateInterval.Day, File.FileDate, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                Logging.AddLogEntry("ctrlUploadFiles:DetermineIfFileIsFinalized: ", ("Daily FileType DeltaDate (days) = " & Conversions.ToString(num)), EventLogEntryType.Information, 3)
                flag = (num > 0)
            ElseIf (File.FileType <> FileType.Monthly) Then
                flag = False
            Else
                Dim num2 As Integer = CInt(DateAndTime.DateDiff(DateInterval.Month, File.FileDate, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                Logging.AddLogEntry("ctrlUploadFiles:DetermineIfFileIsFinalized: ", ("Monthly FileType DeltaDate (months) = " & Conversions.ToString(num2)), EventLogEntryType.Information, 3)
                flag = (num2 > 0)
            End If
            Return flag
        End Function

        Public Shared Function DetermineIfFileShouldBeUploaded(ByVal FileName As String, ByVal FileUploadList As List(Of FileUploads)) As Boolean
            Dim flag3 As Boolean = False
            Dim flag2 As Boolean = False
            Dim flag4 As Boolean = False
            Dim num2 As Integer = (FileUploadList.Count - 1)
            Dim num As Integer = 0
            Do While True
                Dim num3 As Integer = num2
                If (num <= num3) Then
                    If (FileUploadList(num).FileName <> FileName) Then
                        num += 1
                        Continue Do
                    End If
                    flag3 = True
                    Logging.AddLogEntry("ctrlUploadFiles: DetermineIfFileShouldBeUploaded", ("FileNameFound: " & FileName), EventLogEntryType.Information, 3)
                    Logging.AddLogEntry("ctrlUploadFiles: DetermineIfFileShouldBeUploaded", ("File Upload Success: " & Conversions.ToString(FileUploadList(num).Success)), EventLogEntryType.Information, 3)
                    Logging.AddLogEntry("ctrlUploadFiles: DetermineIfFileShouldBeUploaded", ("File Finalized: " & Conversions.ToString(FileUploadList(num).FileFinalized)), EventLogEntryType.Information, 3)
                    If FileUploadList(num).Success Then
                        flag4 = True
                    End If
                    If FileUploadList(num).FileFinalized Then
                        flag2 = True
                    End If
                End If
                Return If(flag3, If(flag4, If(flag2, Not flag2, True), True), True)
            Loop
        End Function

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try 
                If (If((Not disposing OrElse (Me.components Is Nothing)), 0, 1) <> 0) Then
                    Me.components.Dispose
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.prgFile = New ProgressBarX
            Me.prgOverall = New ProgressBarX
            Me.lblCuFile = New LabelX
            Me.lblOverall = New LabelX
            Me.lblComplete = New LabelX
            Me.prgDLInitialize = New ProgressBarX
            Me.rtbResponseWindow = New RichTextBox
            Me.SuspendLayout
            Me.prgFile.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.prgFile.BackgroundStyle.CornerType = eCornerType.Square
            Dim point2 As New Point(30, &H2F)
            Me.prgFile.Location = point2
            Me.prgFile.Name = "prgFile"
            Dim size2 As New Size(&H11D, &H17)
            Me.prgFile.Size = size2
            Me.prgFile.Style = eDotNetBarStyle.StyleManagerControlled
            Me.prgFile.TabIndex = 0
            Me.prgFile.Text = "ProgressBarX1"
            Me.prgFile.Visible = False
            Me.prgOverall.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.prgOverall.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(30, &H62)
            Me.prgOverall.Location = point2
            Me.prgOverall.Name = "prgOverall"
            size2 = New Size(&H11D, &H17)
            Me.prgOverall.Size = size2
            Me.prgOverall.Style = eDotNetBarStyle.StyleManagerControlled
            Me.prgOverall.TabIndex = 1
            Me.prgOverall.Text = "ProgressBarX2"
            Me.prgOverall.Visible = False
            Me.lblCuFile.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.lblCuFile.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(30, &H19)
            Me.lblCuFile.Location = point2
            Me.lblCuFile.Name = "lblCuFile"
            size2 = New Size(&H11D, &H17)
            Me.lblCuFile.Size = size2
            Me.lblCuFile.TabIndex = 2
            Me.lblCuFile.Text = "LabelX1"
            Me.lblCuFile.Visible = False
            Me.lblOverall.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.lblOverall.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(30, &H4C)
            Me.lblOverall.Location = point2
            Me.lblOverall.Name = "lblOverall"
            size2 = New Size(&H11D, &H17)
            Me.lblOverall.Size = size2
            Me.lblOverall.TabIndex = 3
            Me.lblOverall.Text = "Overall Progress"
            Me.lblOverall.Visible = False
            Me.lblComplete.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.lblComplete.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblComplete.Font = New Font("Microsoft Sans Serif", 12!, (FontStyle.Italic Or FontStyle.Bold), GraphicsUnit.Point, 0)
            point2 = New Point(30, &H7F)
            Me.lblComplete.Location = point2
            Me.lblComplete.Name = "lblComplete"
            size2 = New Size(&H11D, &H17)
            Me.lblComplete.Size = size2
            Me.lblComplete.TabIndex = 5
            Me.lblComplete.Text = "Upload Complete"
            Me.lblComplete.TextAlignment = StringAlignment.Center
            Me.lblComplete.Visible = False
            Me.prgDLInitialize.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.prgDLInitialize.BackgroundStyle.CornerType = eCornerType.Square
            Me.prgDLInitialize.ColorTable = eProgressBarItemColor.Error
            point2 = New Point(30, &H48)
            Me.prgDLInitialize.Location = point2
            Me.prgDLInitialize.MarqueeAnimationSpeed = &H4B
            Me.prgDLInitialize.Name = "prgDLInitialize"
            Me.prgDLInitialize.ProgressType = eProgressItemType.Marquee
            size2 = New Size(&H11D, &H17)
            Me.prgDLInitialize.Size = size2
            Me.prgDLInitialize.Style = eDotNetBarStyle.StyleManagerControlled
            Me.prgDLInitialize.TabIndex = 6
            Me.prgDLInitialize.Text = "Initializing Upload"
            Me.prgDLInitialize.TextVisible = True
            Me.rtbResponseWindow.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            point2 = New Point(30, &H9D)
            Me.rtbResponseWindow.Location = point2
            Me.rtbResponseWindow.Name = "rtbResponseWindow"
            size2 = New Size(&H11D, &H57)
            Me.rtbResponseWindow.Size = size2
            Me.rtbResponseWindow.TabIndex = 7
            Me.rtbResponseWindow.Text = "=====================================" & ChrW(10) & "                Server Response Window" & ChrW(10) & "This will likely be removed before final release." & ChrW(10) & "=====================================" & ChrW(10)
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.rtbResponseWindow)
            Me.Controls.Add(Me.prgDLInitialize)
            Me.Controls.Add(Me.lblComplete)
            Me.Controls.Add(Me.prgOverall)
            Me.Controls.Add(Me.prgFile)
            Me.Controls.Add(Me.lblOverall)
            Me.Controls.Add(Me.lblCuFile)
            Me.Name = "ctrlUploadFiles"
            size2 = New Size(&H160, &HF7)
            Me.Size = size2
            Me.ResumeLayout(False)
        End Sub

        Public Shared Function ParseFileName(ByVal FileName As String) As FileInfo
            Dim info As FileInfo
            Dim strArray As String() = Strings.Split(Path.GetFileNameWithoutExtension(FileName), "_", -1, CompareMethod.Binary)
            Dim info2 As New FileInfo
            Try 
                If (strArray.Length < 4) Then
                    info2.FileName = strArray(0)
                    info2.Product = "Unknown"
                    info2.DataType = "Unknown"
                    info2.ValidName = False
                Else
                    info2.DataType = If(Not strArray(0).ToUpper.StartsWith("PST"), strArray(0), "PST")
                    info2.Product = strArray(1)
                    info2.ComputerName = strArray(2)
                    Dim strArray2 As String() = Strings.Split(strArray(3), "-", -1, CompareMethod.Binary)
                    info2.FileType = If((strArray2.Length <> 2), If((strArray2.Length <> 3), FileType.NA, FileType.Daily), FileType.Monthly)
                    Dim info4 As FileInfo = info2
                    Dim fileDate As DateTime = info4.FileDate
                    DateTime.TryParse(strArray(3), New CultureInfo("en-us"), DateTimeStyles.AssumeLocal, fileDate)
                    info4.FileDate = fileDate
                    Logging.AddLogEntry("ctrlUploadFiles:ParseFileName: ", ("FileType = " & info2.FileType.ToString), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("ctrlUploadFiles:ParseFileName: ", ("FileDate = " & info2.FileDate.ToString), EventLogEntryType.Information, 4)
                    info2.FileName = FileName
                    info2.ValidName = True
                End If
                info = info2
            Catch exception1 As ArgumentException
                Dim ex As ArgumentException = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As ArgumentException = ex
                info2 = New FileInfo With { _
                    .ValidName = False, _
                    .FileName = FileName _
                }
                info = info2
                ProjectData.ClearProjectError
            End Try
            Return info
        End Function

        Public Shared Function ReadFileUploadList(ByVal FileDir As String, ByVal FileUploadListName As String) As List(Of FileUploads)
            Dim list2 As New List(Of FileUploads)
            If MyProject.Computer.FileSystem.FileExists(Path.Combine(FileDir, FileUploadListName)) Then
                Dim array(,) As String(0 To .,0 To .) = FileProcessing.ReadDelimitedFile(Path.Combine(FileDir, FileUploadListName), ",")
                Dim num2 As Integer = Information.UBound(array, 1)
                Dim num As Integer = 0
                Do While True
                    Dim num3 As Integer = num2
                    If (num > num3) Then
                        Exit Do
                    End If
                    If (array(num, 0) <> Nothing) Then
                        Dim item As New FileUploads With { _
                            .FileName = array(num, 0), _
                            .FileFinalized = Conversions.ToBoolean(array(num, 1)), _
                            .UploadDate = Conversions.ToDate(array(num, 2)), _
                            .Success = Conversions.ToBoolean(array(num, 3)) _
                        }
                        list2.Add(item)
                    End If
                    num += 1
                Loop
            End If
            Return list2
        End Function

        Private Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
            Return (attributes And Not attributesToRemove)
        End Function

        Private Sub RemoveEntryFromFileList(ByVal FileName As String)
            Dim num2 As Integer = (Me._FileUploadList.Count - 1)
            Dim index As Integer = 0
            Do While True
                Dim num3 As Integer = num2
                If (index <= num3) Then
                    If (Me._FileUploadList(index).FileName.ToUpper <> FileName.ToUpper) Then
                        index += 1
                        Continue Do
                    End If
                    Me._FileUploadList.RemoveAt(index)
                End If
                Return
            Loop
        End Sub

        Private Sub SetResponseWindowVisibility(ByVal p1 As Boolean)
            If Not Me.rtbResponseWindow.InvokeRequired Then
                Me.rtbResponseWindow.Visible = p1
            Else
                Dim args As Object() = New Object() { p1 }
                Me.rtbResponseWindow.Invoke(New delResponseWindow_SetVisiblity(AddressOf Me.SetResponseWindowVisibility), args)
            End If
        End Sub

        Public Sub StartUpload()
            Me.thdUpload = New Thread(New ThreadStart(AddressOf Me.Upload))
            Me.thdUpload.IsBackground = True
            Me.thdUpload.Start
        End Sub

        Private Sub UpdateCompleteLabel(ByVal Success As Boolean)
            If Me.lblCuFile.InvokeRequired Then
                Dim args As Object() = New Object() { Success }
                Me.lblCuFile.Invoke(New lblComplete_UpdateDisplay(AddressOf Me.UpdateCompleteLabel), args)
            ElseIf Not Success Then
                Me.lblComplete.Text = (Conversions.ToString(Me._ErrorList.Count) & " files had errors wile uploading.")
                Me.lblComplete.Visible = True
            ElseIf (Me._CuFileNum > 0) Then
                Me.lblComplete.Visible = True
            Else
                Me.lblComplete.Text = "No files waiting to be uploaded"
                Me.lblComplete.Visible = True
                Me.lblCuFile.Visible = False
                Me.lblOverall.Visible = False
                Me.prgDLInitialize.Visible = False
                Me.prgFile.Visible = False
                Me.prgOverall.Visible = False
            End If
        End Sub

        Private Sub UpdateFileLabel(ByVal strLabel As String)
            If Not Me.lblCuFile.InvokeRequired Then
                Me.lblCuFile.Text = strLabel
            Else
                Dim args As Object() = New Object() { strLabel }
                Me.lblCuFile.Invoke(New lblCuFile_UpdateDisplay(AddressOf Me.UpdateFileLabel), args)
            End If
        End Sub

        Private Sub UpdateFileprg(ByVal Percentage As Double)
            If Not Me.prgFile.Visible Then
                Me.prgFile.Visible = True
                Me.prgOverall.Visible = True
                Me.lblCuFile.Visible = True
                Me.lblOverall.Visible = True
                Me.prgDLInitialize.Visible = False
            End If
            Me.prgFile.Value = CInt(Math.Round(Percentage))
        End Sub

        Private Sub UpdateOverallprg(ByVal percentage As Double)
            Me.prgOverall.Value = CInt(Math.Round(CDbl((percentage + (Me._CuFileNum * 100)))))
        End Sub

        Private Sub UpdateProgress(ByVal Percentage As Double)
            Dim objArray As Object()
            If Me.prgFile.InvokeRequired Then
                objArray = New Object() { Percentage }
                Me.prgFile.Invoke(New PrgFile_UpdateDisplay(AddressOf Me.UpdateFileprg), objArray)
            End If
            If Me.prgOverall.InvokeRequired Then
                objArray = New Object() { Percentage }
                Me.prgOverall.Invoke(New PrgFile_UpdateDisplay(AddressOf Me.UpdateOverallprg), objArray)
            End If
        End Sub

        Private Sub UpdateResponseWindow(ByVal myMSG As String)
            If Me.rtbResponseWindow.Visible Then
                If Me.rtbResponseWindow.InvokeRequired Then
                    Dim args As Object() = New Object() { myMSG }
                    Me.rtbResponseWindow.Invoke(New delResponseWindow_Update(AddressOf Me.UpdateResponseWindow), args)
                Else
                    Me.rtbResponseWindow.AppendText((myMSG & ChrW(13) & ChrW(10)))
                    Me.rtbResponseWindow.ScrollToCaret
                End If
            End If
        End Sub

        Private Sub Upload()
            Dim enumerator As IEnumerator(Of String)
            Me._FileUploadList = ctrlUploadFiles.ReadFileUploadList(Me._FileDir, ctrlUploadFiles.FileUploadListName)
            Me._ErrorList = New List(Of FileError)
            Me._FileCount = Me._SrcFileList.Count
            Logging.AddLogEntry(Me, ("Files to upload: " & Conversions.ToString(Me._FileCount)), EventLogEntryType.Information, 2)
            Me.prgOverall.Maximum = (Me._FileCount * 100)
            Dim num As Integer = 0
            Me.WaitAllEvents(0) = New AutoResetEvent(False)
            Try 
                Dim uri As Uri
                Dim hostAddresses As IPAddress()
                enumerator = Me._SrcFileList.GetEnumerator
                goto TR_003C
            TR_0018:
                num += 1
                goto TR_003C
            TR_001B:
                Logging.AddLogEntry(Me, "Upload: Upload in Async Mode", EventLogEntryType.Information, 2)
                Dim async As HTTPUploadAsync = If(Not Path.IsPathRooted(Me._TemporaryDestination), New HTTPUploadAsync(Me._CuFileName_FullName, uri.AbsoluteUri), New HTTPUploadAsync(Me._CuFileName_FullName, uri.AbsolutePath))
                AddHandler async.UploadProgressChange, New UploadProgressChangeEventHandler(AddressOf Me.UpdateProgress)
                AddHandler async.UploadComplete, New UploadCompleteEventHandler(AddressOf Me.UploadComplete)
                async.AuthAddress = uri.Authority.ToString
                async.UserName = "randalm"
                async.Password = "foobie2"
                Logging.AddLogEntry(Me, ("Destination Site: " & Me._DestinationSite.ToString), EventLogEntryType.Information, 2)
                Logging.AddLogEntry(Me, ("Destination: " & Me._TemporaryDestination.ToString), EventLogEntryType.Information, 2)
                Logging.AddLogEntry(Me, ("Translated Destination: " & uri.AbsoluteUri.ToString), EventLogEntryType.Information, 2)
                Logging.AddLogEntry(Me, ("Current File: " & Me._CuFileName_FullName.ToString), EventLogEntryType.Information, 2)
                Logging.AddLogEntry(Me, ("AuthAddress: " & async.AuthAddress.ToString), EventLogEntryType.Information, 2)
                If Not Object.ReferenceEquals(Me._Proxy, Nothing) Then
                    async.Proxy = Me._Proxy
                    Logging.AddLogEntry(Me, ("Proxy: " & Me._Proxy.Address.ToString), EventLogEntryType.Information, 2)
                End If
                async.FinalDestination = Me._FinalDesitnation
                Logging.AddLogEntry(Me, "Starting Upload", EventLogEntryType.Information, 1)
                async.StartUpload
                Me.UpdateFileLabel(Me._CuFileName)
                WaitHandle.WaitAll(Me.WaitAllEvents)
                Thread.Sleep(30)
                goto TR_0018
            TR_001D:
                uri = New Uri((uri.Scheme.ToString & Uri.SchemeDelimiter.ToString & hostAddresses(0).ToString & uri.AbsolutePath))
                goto TR_001B
            TR_003C:
                Do While True
                    Dim jobCompleteEvent As JobCompleteEventHandler
                    Dim flag2 As Boolean = enumerator.MoveNext
                    If flag2 Then
                        Dim current As String = enumerator.Current
                        If MyProject.Computer.FileSystem.FileExists(current) Then
                            Logging.AddLogEntry(Me, ("****************Starting Upload process for file: " & current), EventLogEntryType.Information, 1)
                            Select Case Me._TestSite
                                Case TestSites.HP
                                    Me._TemporaryDestination = UploadSettings.VCDServerAddress
                                    Exit Select
                                Case TestSites.DEBUG
                                    Me._TemporaryDestination = "\\vcslab\root\InkSystems\SPHINKS\Randal Morrison\FUEL\testing\howdy\"
                                    Exit Select
                                Case Else
                                    If (Me._DestinationSite = TestSites.HP) Then
                                        Me._TemporaryDestination = UploadSettings.VCDServerAddress
                                    ElseIf ((Me._DestinationSite = TestSites.NKG_China) Or (Me._DestinationSite = TestSites.NKG_Thailand)) Then
                                        Me._TemporaryDestination = UploadSettings.LocalCopyToAddress
                                    End If
                                    Exit Select
                            End Select
                            Me._CuFileName = Path.GetFileName(current)
                            Me._CuFileName_FullName = current
                            Dim flag As Boolean = ctrlUploadFiles.DetermineIfFileShouldBeUploaded(Me._CuFileName_FullName, Me._FileUploadList)
                            If Not flag Then
                                goto TR_0018
                            Else
                                If Not Path.IsPathRooted(Me._TemporaryDestination) Then
                                    Me.SetResponseWindowVisibility(False)
                                Else
                                    Me.SetResponseWindowVisibility(False)
                                    Dim directoryName As String = Path.GetDirectoryName(Me._TemporaryDestination)
                                    If (directoryName = Nothing) Then
                                        directoryName = Path.GetPathRoot(Me._TemporaryDestination)
                                    End If
                                    If Not MyProject.Computer.FileSystem.DirectoryExists(Path.GetPathRoot(Me._TemporaryDestination)) Then
                                        Interaction.MsgBox("The specified drive to upload files to does not exist. Are you sure that you set your location properly?", MsgBoxStyle.Critical, "Can't Find Specified Drive.")
                                        MySettingsProperty.Settings.CurrentSite = 0
                                        MySettingsProperty.Settings.Save
                                        jobCompleteEvent = Me.JobCompleteEvent
                                        If Not Object.ReferenceEquals(jobCompleteEvent, Nothing) Then
                                            jobCompleteEvent.Invoke(False)
                                        End If
                                        Exit Do
                                    End If
                                    Me._TemporaryDestination = Path.Combine(directoryName, Me._CuFileName)
                                    If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                                        MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                                    End If
                                End If
                                Me._CuFileNum = num
                                Dim info As FileInfo = ctrlUploadFiles.ParseFileName(Me._CuFileName)
                                Me._FinalDesitnation = (info.DataType & "|" & info.Product)
                                uri = New Uri(Me._TemporaryDestination)
                                If (uri.HostNameType <> UriHostNameType.Dns) Then
                                    goto TR_001B
                                Else
                                    Try 
                                        hostAddresses = Dns.GetHostAddresses(uri.Authority.ToString)
                                        goto TR_001D
                                    Catch exception1 As SocketException
                                        Dim ex As SocketException = exception1
                                        ProjectData.SetProjectError(ex)
                                        Dim exception As SocketException = ex
                                        Dim prompt As String = ("Unable to resolve the UploadAddress: " & uri.ToString)
                                        Logging.AddLogEntry(Me, ("Upload: GetHostName:" & exception.ToString), EventLogEntryType.Error, 0)
                                        Interaction.MsgBox(prompt, MsgBoxStyle.ApplicationModal, Nothing)
                                        jobCompleteEvent = Me.JobCompleteEvent
                                        If Not Object.ReferenceEquals(jobCompleteEvent, Nothing) Then
                                            jobCompleteEvent.Invoke(False)
                                        End If
                                        ProjectData.ClearProjectError
                                    End Try
                                End If
                            End If
                            Exit Do
                        End If
                        goto TR_0018
                    Else
                        flag2 = (Me._ErrorList.Count > 0)
                        If Not flag2 Then
                            Me.WriteFilesToUploadList
                            Me.UpdateProgress(100)
                            Thread.Sleep(30)
                            Me.UpdateCompleteLabel(True)
                            jobCompleteEvent = Me.JobCompleteEvent
                            If Not Object.ReferenceEquals(jobCompleteEvent, Nothing) Then
                                jobCompleteEvent.Invoke(True)
                            End If
                        Else
                            Me.prgFile.ColorTable = eProgressBarItemColor.Error
                            Me.prgOverall.ColorTable = eProgressBarItemColor.Error
                            Me.UpdateProgress(100)
                            Thread.Sleep(30)
                            Me.UpdateCompleteLabel(False)
                            Me.UpdateResponseWindow(ChrW(13) & ChrW(10) & "********Error List Summary********" & ChrW(13) & ChrW(10))
                            Using enumerator2 As Enumerator(Of FileError) = Me._ErrorList.GetEnumerator
                                Do While True
                                    flag2 = enumerator2.MoveNext
                                    If Not flag2 Then
                                        Exit Do
                                    End If
                                    Dim current As FileError = enumerator2.Current
                                    Dim strArray As String() = New String() { "Error on file: ", current.FileName, ChrW(13) & ChrW(10) & "Error: ", current.Err, ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) }
                                    Dim myMSG As String = String.Concat(strArray)
                                    Me.UpdateResponseWindow(myMSG)
                                Loop
                            End Using
                            jobCompleteEvent = Me.JobCompleteEvent
                            If Not Object.ReferenceEquals(jobCompleteEvent, Nothing) Then
                                jobCompleteEvent.Invoke(False)
                            End If
                        End If
                        Return
                    End If
                    Exit Do
                Loop
            Finally
                If Not Object.ReferenceEquals(enumerator, Nothing) Then
                    enumerator.Dispose
                End If
            End Try
        End Sub

        Private Sub UploadComplete(ByVal e As UploadFileCompletedEventArgs)
            If e.Cancelled Then
                Dim item As New FileError With { _
                    .FileName = Me._CuFileName_FullName, _
                    .Err = e.Cancelled.ToString _
                }
                Me._ErrorList.Add(item)
                Logging.AddLogEntry(Me, ("UploadComplete: upload cancelled:" & Me._CuFileName_FullName.ToString), EventLogEntryType.Error, 0)
                Me.AddFileToList(Me._CuFileName_FullName, False)
            ElseIf Not Object.ReferenceEquals(e.Error, Nothing) Then
                Dim item As New FileError With { _
                    .FileName = Me._CuFileName_FullName, _
                    .Err = e.Error.ToString _
                }
                Me._ErrorList.Add(item)
                Me.AddFileToList(Me._CuFileName_FullName, False)
                Dim myMSG As String = ("*****Error******" & ChrW(13) & ChrW(10) & ChrW(9) & e.Error.ToString & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10))
                Me.UpdateResponseWindow(myMSG)
                Logging.AddLogEntry(Me, ("UploadComplete: eror:" & myMSG), EventLogEntryType.Error, 0)
            Else
                Dim flag As Boolean = False
                Dim response As ServerResponse = Nothing
                If Path.IsPathRooted(Me._TemporaryDestination) Then
                    If MyProject.Computer.FileSystem.FileExists(Me._TemporaryDestination) Then
                        Logging.AddLogEntry(Me, "UploadCompleted successfully", EventLogEntryType.Information, 1)
                        flag = True
                    End If
                Else
                    response = Me.DecodeJSON(Encoding.UTF8.GetString(e.Result))
                    If (response.Status.ToLower = "success".ToLower) Then
                        flag = True
                    End If
                    Dim strArray As String() = New String() { response.FileName, ChrW(13) & ChrW(10) & ChrW(9), response.FinalDestination, ChrW(13) & ChrW(10) & ChrW(9), response.Status }
                    Dim myMSG As String = String.Concat(strArray)
                    Me.UpdateResponseWindow(myMSG)
                    If flag Then
                        Logging.AddLogEntry(Me, ("UploadComplete: Success:" & myMSG), EventLogEntryType.Information, 1)
                    Else
                        Logging.AddLogEntry(Me, ("UploadComplete: Server Error:" & myMSG), EventLogEntryType.Error, 0)
                    End If
                End If
                If flag Then
                    Me.AddFileToList(Me._CuFileName_FullName, True)
                Else
                    Dim item As New FileError With { _
                        .FileName = Me._CuFileName_FullName, _
                        .Err = response.Status _
                    }
                    Me._ErrorList.Add(item)
                End If
            End If
            Me.WaitAllEvents(0).Set
        End Sub

        Private Sub WriteFilesToUploadList()
            Dim num2 As Integer = 4
            If (num2 <> New FileUploads._ItemCnt) Then
                Throw New ApplicationException
            End If
            Dim num As Integer = (Me._FileUploadList.Count - 1)
            Dim body(,) As String(0 To .,0 To .) = New String((num + 1)  - 1, ((num2 - 1) + 1)  - 1) {}
            Dim num4 As Integer = num
            Dim num3 As Integer = 0
            Do While True
                Dim num5 As Integer = num4
                If (num3 > num5) Then
                    Me.ChangeFileHiddenAttribute(Path.Combine(Me._FileDir, ctrlUploadFiles.FileUploadListName), False)
                    FileProcessing.WriteDelimitedFile(Path.Combine(Me._FileDir, ctrlUploadFiles.FileUploadListName), Nothing, body, ",", False)
                    Me.ChangeFileHiddenAttribute(Path.Combine(Me._FileDir, ctrlUploadFiles.FileUploadListName), True)
                    Return
                End If
                body(num3, 0) = Me._FileUploadList(num3).FileName
                body(num3, 1) = Conversions.ToString(Me._FileUploadList(num3).FileFinalized)
                body(num3, 2) = Conversions.ToString(Me._FileUploadList(num3).UploadDate)
                body(num3, 3) = Conversions.ToString(Me._FileUploadList(num3).Success)
                num3 += 1
            Loop
        End Sub


        ' Properties
        Friend Overridable Property prgFile As ProgressBarX
            <DebuggerNonUserCode> _
            Get
                Return Me._prgFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ProgressBarX)
                Me._prgFile = WithEventsValue
            End Set
        End Property

        Friend Overridable Property prgOverall As ProgressBarX
            <DebuggerNonUserCode> _
            Get
                Return Me._prgOverall
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ProgressBarX)
                Me._prgOverall = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblCuFile As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblCuFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblCuFile = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblOverall As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblOverall
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblOverall = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblComplete As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblComplete
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblComplete = WithEventsValue
            End Set
        End Property

        Friend Overridable Property prgDLInitialize As ProgressBarX
            <DebuggerNonUserCode> _
            Get
                Return Me._prgDLInitialize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ProgressBarX)
                Me._prgDLInitialize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbResponseWindow As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbResponseWindow
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbResponseWindow = WithEventsValue
            End Set
        End Property

        Private Property _SrcFileList As Collection(Of String)
            <DebuggerNonUserCode> _
            Get
                Return Me.__SrcFileList
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Collection(Of String))
                Me.__SrcFileList = AutoPropertyValue
            End Set
        End Property

        Private Property _FileDir As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__FileDir
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__FileDir = AutoPropertyValue
            End Set
        End Property

        Private Property _FileCount As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__FileCount
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__FileCount = AutoPropertyValue
            End Set
        End Property

        Private Property _CuFileNum As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__CuFileNum
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__CuFileNum = AutoPropertyValue
            End Set
        End Property

        Private Property _CuFileName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__CuFileName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__CuFileName = AutoPropertyValue
            End Set
        End Property

        Private Property _CuFileName_FullName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__CuFileName_FullName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__CuFileName_FullName = AutoPropertyValue
            End Set
        End Property

        Private Property _UploadInProgress As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__UploadInProgress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__UploadInProgress = AutoPropertyValue
            End Set
        End Property

        Private Property _ErrorList As List(Of FileError)
            <DebuggerNonUserCode> _
            Get
                Return Me.__ErrorList
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of FileError))
                Me.__ErrorList = AutoPropertyValue
            End Set
        End Property

        Private Property _FileUploadList As List(Of FileUploads)
            <DebuggerNonUserCode> _
            Get
                Return Me.__FileUploadList
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of FileUploads))
                Me.__FileUploadList = AutoPropertyValue
            End Set
        End Property

        Private Property _FinalDesitnation As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__FinalDesitnation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__FinalDesitnation = AutoPropertyValue
            End Set
        End Property

        Private Property _TemporaryDestination As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__TemporaryDestination
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__TemporaryDestination = AutoPropertyValue
            End Set
        End Property

        Private Property _DestinationSite As TestSites
            <DebuggerNonUserCode> _
            Get
                Return Me.__DestinationSite
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestSites)
                Me.__DestinationSite = AutoPropertyValue
            End Set
        End Property

        Private Property _TestSite As TestSites
            <DebuggerNonUserCode> _
            Get
                Return Me.__TestSite
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestSites)
                Me.__TestSite = AutoPropertyValue
            End Set
        End Property

        Private Property _Proxy As WebProxy
            <DebuggerNonUserCode> _
            Get
                Return Me.__Proxy
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As WebProxy)
                Me.__Proxy = AutoPropertyValue
            End Set
        End Property

        Public Shared ReadOnly Property FileUploadListName As String
            Get
                Return "Uploads"
            End Get
        End Property

        Public Shared ReadOnly Property AllowedFileTypes As String()
            Get
                Return New String() { "*.csv", "*.txt", "*.xls", "*.xlsx", "*.xml", "*.zip", "*.z*" }
            End Get
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("prgFile")> _
        Private _prgFile As ProgressBarX
        <AccessedThroughProperty("prgOverall")> _
        Private _prgOverall As ProgressBarX
        <AccessedThroughProperty("lblCuFile")> _
        Private _lblCuFile As LabelX
        <AccessedThroughProperty("lblOverall")> _
        Private _lblOverall As LabelX
        <AccessedThroughProperty("lblComplete")> _
        Private _lblComplete As LabelX
        <AccessedThroughProperty("prgDLInitialize")> _
        Private _prgDLInitialize As ProgressBarX
        <AccessedThroughProperty("rtbResponseWindow")> _
        Private _rtbResponseWindow As RichTextBox
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __SrcFileList As Collection(Of String)
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __FileDir As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __FileCount As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __CuFileNum As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __CuFileName As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __CuFileName_FullName As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __UploadInProgress As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __ErrorList As List(Of FileError)
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __FileUploadList As List(Of FileUploads)
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __FinalDesitnation As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __TemporaryDestination As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __DestinationSite As TestSites
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __TestSite As TestSites
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Proxy As WebProxy
        Private WaitAllEvents As AutoResetEvent()
        Private JobCompleteEvent As JobCompleteEventHandler
        Private thdUpload As Thread

        ' Nested Types
        Private Delegate Sub delResponseWindow_SetVisiblity(ByVal Visible As Boolean)

        Private Delegate Sub delResponseWindow_Update(ByVal myMSG As String)

        Private Class FileError
            ' Properties
            Public Property FileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._FileName = AutoPropertyValue
                End Set
            End Property

            Public Property Err As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._Err
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._Err = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _FileName As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Err As String
        End Class

        Public Class FileInfo
            ' Methods
            Public Sub New()
                Me.ValidName = True
            End Sub


            ' Properties
            Public Property DataType As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._DataType
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._DataType = AutoPropertyValue
                End Set
            End Property

            Public Property FileType As FileType
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileType
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As FileType)
                    Me._FileType = AutoPropertyValue
                End Set
            End Property

            Public Property Product As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._Product
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._Product = AutoPropertyValue
                End Set
            End Property

            Public Property ComputerName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._ComputerName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._ComputerName = AutoPropertyValue
                End Set
            End Property

            Public Property FileDate As DateTime
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileDate
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As DateTime)
                    Me._FileDate = AutoPropertyValue
                End Set
            End Property

            Public Property ValidName As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me._ValidName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me._ValidName = AutoPropertyValue
                End Set
            End Property

            Public Property FileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._FileName = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _DataType As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _FileType As FileType
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _Product As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _ComputerName As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _FileDate As DateTime
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _ValidName As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _FileName As String
        End Class

        Public Enum FileType
            ' Fields
            Monthly = 0
            Daily = 1
            NA = 2
        End Enum

        Public Class FileUploads
            ' Methods
            Public Sub New()
                Me._ItemCnt = 4
            End Sub


            ' Properties
            Protected Friend Property _ItemCnt As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__ItemCnt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__ItemCnt = AutoPropertyValue
                End Set
            End Property

            Public Property FileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._FileName = AutoPropertyValue
                End Set
            End Property

            Public Property FileFinalized As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileFinalized
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me._FileFinalized = AutoPropertyValue
                End Set
            End Property

            Public Property UploadDate As DateTime
                <DebuggerNonUserCode> _
                Get
                    Return Me._UploadDate
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As DateTime)
                    Me._UploadDate = AutoPropertyValue
                End Set
            End Property

            Public Property Success As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me._Success
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me._Success = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __ItemCnt As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _FileName As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _FileFinalized As Boolean
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _UploadDate As DateTime
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Success As Boolean
        End Class

        Public Delegate Sub JobCompleteEventHandler(ByVal Status As Boolean)

        Private Delegate Sub lblComplete_UpdateDisplay(ByVal Sucess As Boolean)

        Private Delegate Sub lblCuFile_UpdateDisplay(ByVal strLabel As String)

        Private Delegate Sub PrgFile_UpdateDisplay(ByVal Percentage As Double)

        Private Delegate Sub prgOverall_UpdateDisplay(ByVal Percentage As Double)

        Private Class ServerResponse
            ' Properties
            Public Property FinalDestination As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._FinalDestination
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._FinalDestination = AutoPropertyValue
                End Set
            End Property

            Public Property FileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._FileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._FileName = AutoPropertyValue
                End Set
            End Property

            Public Property Status As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._Status
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._Status = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _FinalDestination As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _FileName As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Status As String
        End Class
    End Class
End Namespace

