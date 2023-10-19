Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
Imports FUEL.My
Imports Ionic.Zip
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class frmZipProgress
        Inherits MetroForm
        ' Methods
        Public Sub New(ByVal SourceDir As String, ByVal OutputName As String, ByVal DeleteSourceFiles As Boolean)
            Dim num As Long
            Dim enumerator As IEnumerator(Of String)
            AddHandler MyBase.Shown, New EventHandler(AddressOf Me.frmSimpleProgress_Shown)
            frmZipProgress.__ENCAddToList(Me)
            Me._BytesTransfered = 0
            Me._JobSize = 0
            Me._MaxFileSize = 0
            Me._DeleteFilesAfterZip = False
            Me._HideForm = False
            Me.InitializeComponent
            Me._SourceDir = SourceDir
            Me._OutputName = OutputName
            Me._DeleteFilesAfterZip = DeleteSourceFiles
            Dim onlys As ReadOnlyCollection(Of String) = MyProject.Computer.FileSystem.GetFiles(Me._SourceDir, SearchOption.SearchAllSubDirectories, Nothing)
            Try 
                enumerator = onlys.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As String = enumerator.Current
                    num = (num + MyProject.Computer.FileSystem.GetFileInfo(current).Length)
                Loop
            Finally
                If Not Object.ReferenceEquals(enumerator, Nothing) Then
                    enumerator.Dispose
                End If
            End Try
            Me._JobSize = num
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock frmZipProgress.__ENCList
                If (frmZipProgress.__ENCList.Count = frmZipProgress.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (frmZipProgress.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            frmZipProgress.__ENCList.RemoveRange(index, (frmZipProgress.__ENCList.Count - index))
                            frmZipProgress.__ENCList.Capacity = frmZipProgress.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = frmZipProgress.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                frmZipProgress.__ENCList(index) = frmZipProgress.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                frmZipProgress.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub DeleteSourceFiles()
            Dim enumerator As IEnumerator(Of String)
            Dim enumerator2 As IEnumerator(Of String)
            Dim onlys2 As ReadOnlyCollection(Of String) = MyProject.Computer.FileSystem.GetFiles(Me._SourceDir, SearchOption.SearchAllSubDirectories, Nothing)
            Try 
                enumerator = onlys2.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As String = enumerator.Current
                    Dim extension As String = Path.GetExtension(current)
                    If (Path.GetFileNameWithoutExtension(current) <> Path.GetFileNameWithoutExtension(Me._OutputName)) Then
                        MyProject.Computer.FileSystem.DeleteFile(current, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                    End If
                Loop
            Finally
                If Not Object.ReferenceEquals(enumerator, Nothing) Then
                    enumerator.Dispose
                End If
            End Try
            Dim onlys As ReadOnlyCollection(Of String) = MyProject.Computer.FileSystem.GetDirectories(Me._SourceDir, SearchOption.SearchAllSubDirectories, New String(0  - 1) {})
            Try 
                enumerator2 = onlys.GetEnumerator
                Do While True
                    If Not enumerator2.MoveNext Then
                        Exit Do
                    End If
                    Dim current As String = enumerator2.Current
                    MyProject.Computer.FileSystem.DeleteDirectory(current, DeleteDirectoryOption.DeleteAllContents)
                Loop
            Finally
                If Not Object.ReferenceEquals(enumerator2, Nothing) Then
                    enumerator2.Dispose
                End If
            End Try
        End Sub

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

        Private Sub frmSimpleProgress_Shown(ByVal sender As Object, ByVal e As EventArgs)
            If Me._HideForm Then
                Me.Hide
            End If
            Me.Zip
            If Me.DeleteFilesAfterZip Then
                Me.DeleteSourceFiles
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.prgMain = New ProgressBarX
            Me.prgAlternate = New ProgressBarX
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.lblFile = New LabelX
            Me.lblJob = New LabelX
            Me.TableLayoutPanel1.SuspendLayout
            Me.SuspendLayout
            Me.prgMain.BackColor = Color.White
            Me.prgMain.BackgroundStyle.CornerType = eCornerType.Square
            Me.prgMain.Dock = DockStyle.Fill
            Me.prgMain.ForeColor = Color.Black
            Dim point2 As New Point(3, &H5F)
            Me.prgMain.Location = point2
            Me.prgMain.Name = "prgMain"
            Dim size2 As New Size(&H16B, &H1A)
            Me.prgMain.Size = size2
            Me.prgMain.Step = 0
            Me.prgMain.TabIndex = 0
            Me.prgMain.Text = "ProgressBarX1"
            Me.prgAlternate.BackColor = Color.White
            Me.prgAlternate.BackgroundStyle.CornerType = eCornerType.Square
            Me.prgAlternate.Dock = DockStyle.Fill
            Me.prgAlternate.ForeColor = Color.Black
            point2 = New Point(3, &H21)
            Me.prgAlternate.Location = point2
            Me.prgAlternate.Name = "prgAlternate"
            size2 = New Size(&H16B, &H1A)
            Me.prgAlternate.Size = size2
            Me.prgAlternate.TabIndex = 1
            Me.prgAlternate.Text = "ProgressBarX1"
            Me.TableLayoutPanel1.BackColor = Color.FromArgb(&HD3, &HD3, &HD3)
            Me.TableLayoutPanel1.ColumnCount = 1
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100!))
            Me.TableLayoutPanel1.Controls.Add(Me.prgMain, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.prgAlternate, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFile, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblJob, 0, 2)
            Me.TableLayoutPanel1.Dock = DockStyle.Fill
            Me.TableLayoutPanel1.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50!))
            size2 = New Size(&H171, &H7C)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 2
            Me.lblFile.BackColor = Color.Transparent
            Me.lblFile.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblFile.ForeColor = Color.Black
            point2 = New Point(3, 3)
            Me.lblFile.Location = point2
            Me.lblFile.Name = "lblFile"
            size2 = New Size(&H4B, &H17)
            Me.lblFile.Size = size2
            Me.lblFile.TabIndex = 2
            Me.lblFile.Text = "File Progress"
            Me.lblJob.BackColor = Color.Transparent
            Me.lblJob.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblJob.ForeColor = Color.Black
            point2 = New Point(3, &H41)
            Me.lblJob.Location = point2
            Me.lblJob.Name = "lblJob"
            size2 = New Size(&H4B, &H17)
            Me.lblJob.Size = size2
            Me.lblJob.TabIndex = 3
            Me.lblJob.Text = "Job Progress"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            size2 = New Size(&H171, &H7C)
            Me.ClientSize = size2
            Me.ControlBox = False
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.Font = New Font("Segoe UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
            Me.Name = "frmZipProgress"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub SaveCompleted()
            Me.Close
        End Sub

        Private Sub StepArchiveProgress(ByVal e As SaveProgressEventArgs)
            If Me.prgMain.InvokeRequired Then
                Dim args As Object() = New Object() { e }
                Me.prgMain.Invoke(New SaveEntryProgress(AddressOf Me.StepArchiveProgress), args)
            Else
                Me._BytesTransfered = (Me._BytesTransfered + e.CurrentEntry.UncompressedSize)
                Me.prgMain.Value = CInt(Math.Round(Math.Round(CDbl(((CDbl(Me._BytesTransfered) / CDbl(Me._JobSize)) * 100)), 0)))
                MyBase.Update
            End If
        End Sub

        Private Sub StepEntryProgress(ByVal e As SaveProgressEventArgs)
            If Me.prgAlternate.InvokeRequired Then
                Dim args As Object() = New Object() { e }
                Me.prgAlternate.Invoke(New SaveEntryProgress(AddressOf Me.StepEntryProgress), args)
            Else
                Me.prgAlternate.Value = CInt(Math.Round(Math.Round(CDbl(((CDbl(e.BytesTransferred) / CDbl(e.TotalBytesToTransfer)) * 100)), 0)))
                Me.prgMain.Value = CInt(Math.Round(Math.Round(CDbl(((CDbl((Me._BytesTransfered + e.BytesTransferred)) / CDbl(Me._JobSize)) * 100)), 0)))
                MyBase.Update
            End If
        End Sub

        Private Sub Zip()
            Try 
                Dim objA As New ZipFile
                Try 
                    objA.AddDirectory(Me._SourceDir)
                    If (Me.MaxFileSize <> 0) Then
                        objA.MaxOutputSegmentSize = CInt(Me.MaxFileSize)
                    End If
                    AddHandler objA.SaveProgress, New EventHandler(Of SaveProgressEventArgs)(AddressOf Me.Zip_SaveProgress)
                    objA.Save(Me._OutputName)
                Finally
                    If Not Object.ReferenceEquals(objA, Nothing) Then
                        objA.Dispose
                    End If
                End Try
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Me.Show
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub Zip_SaveProgress(ByVal sender As Object, ByVal e As SaveProgressEventArgs)
            Select Case e.EventType
                Case ZipProgressEventType.Saving_AfterWriteEntry
                    Me.StepArchiveProgress(e)
                    Exit Select
                Case ZipProgressEventType.Saving_Completed
                    Me.SaveCompleted
                    Exit Select
                Case ZipProgressEventType.Saving_EntryBytesRead
                    Me.StepEntryProgress(e)
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End Sub


        ' Properties
        Friend Overridable Property prgMain As ProgressBarX
            <DebuggerNonUserCode> _
            Get
                Return Me._prgMain
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ProgressBarX)
                Me._prgMain = WithEventsValue
            End Set
        End Property

        Friend Overridable Property prgAlternate As ProgressBarX
            <DebuggerNonUserCode> _
            Get
                Return Me._prgAlternate
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ProgressBarX)
                Me._prgAlternate = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFile As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblFile = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblJob As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblJob
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblJob = WithEventsValue
            End Set
        End Property

        Private Property _SourceDir As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SourceDir
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SourceDir = AutoPropertyValue
            End Set
        End Property

        Private Property _OutputName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__OutputName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__OutputName = AutoPropertyValue
            End Set
        End Property

        Private Property _BytesTransfered As Long
            <DebuggerNonUserCode> _
            Get
                Return Me.__BytesTransfered
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Long)
                Me.__BytesTransfered = AutoPropertyValue
            End Set
        End Property

        Private Property _JobSize As Long
            <DebuggerNonUserCode> _
            Get
                Return Me.__JobSize
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Long)
                Me.__JobSize = AutoPropertyValue
            End Set
        End Property

        Private Property _MaxFileSize As Long
            <DebuggerNonUserCode> _
            Get
                Return Me.__MaxFileSize
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Long)
                Me.__MaxFileSize = AutoPropertyValue
            End Set
        End Property

        Private Property _DeleteFilesAfterZip As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__DeleteFilesAfterZip
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__DeleteFilesAfterZip = AutoPropertyValue
            End Set
        End Property

        Private Property _HideForm As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__HideForm
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__HideForm = AutoPropertyValue
            End Set
        End Property

        Public Property MaxFileSize As Long
            Get
                Return Me._MaxFileSize
            End Get
            Set(ByVal value As Long)
                Me._MaxFileSize = ((value * &H400) * &H400)
            End Set
        End Property

        Public Property DeleteFilesAfterZip As Boolean
            Get
                Return Me._DeleteFilesAfterZip
            End Get
            Set(ByVal value As Boolean)
                Me._DeleteFilesAfterZip = value
            End Set
        End Property

        Public Property HideForm As Boolean
            Get
                Return Me._HideForm
            End Get
            Set(ByVal value As Boolean)
                Me._HideForm = value
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("prgMain")> _
        Private _prgMain As ProgressBarX
        <AccessedThroughProperty("prgAlternate")> _
        Private _prgAlternate As ProgressBarX
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <AccessedThroughProperty("lblFile")> _
        Private _lblFile As LabelX
        <AccessedThroughProperty("lblJob")> _
        Private _lblJob As LabelX
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __SourceDir As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __OutputName As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __BytesTransfered As Long
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __JobSize As Long
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __MaxFileSize As Long
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __DeleteFilesAfterZip As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __HideForm As Boolean

        ' Nested Types
        Private Delegate Sub SaveEntryProgress(ByVal e As SaveProgressEventArgs)
    End Class
End Namespace

