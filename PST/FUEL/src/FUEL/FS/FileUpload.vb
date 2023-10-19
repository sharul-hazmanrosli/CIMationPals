Imports FUEL
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading

Namespace FUEL.FS
    Public Class FileUpload
        ' Methods
        Public Sub New()
            Me._UploadFrequency = 2
            Me._UploadRequired = False
            Me.NewThread = False
            Me.ZipFiles = False
            Me.ZipFileName = Nothing
            Me.DeleteFilesAfterZip = False
            Me.MaxZipFileSize = 0
            Me.HideForms = False
        End Sub

        Public Sub New(ByVal SrcDir As String)
            Me._UploadFrequency = 2
            Me._UploadRequired = False
            Me.NewThread = False
            Me.ZipFiles = False
            Me.ZipFileName = Nothing
            Me.DeleteFilesAfterZip = False
            Me.MaxZipFileSize = 0
            Me.HideForms = False
            Me._SrcDir = SrcDir
            Me.UploadFiles(0)
        End Sub

        Public Sub New(ByVal SrcDir As String, ByVal UploadInterval As Integer)
            Me._UploadFrequency = 2
            Me._UploadRequired = False
            Me.NewThread = False
            Me.ZipFiles = False
            Me.ZipFileName = Nothing
            Me.DeleteFilesAfterZip = False
            Me.MaxZipFileSize = 0
            Me.HideForms = False
            Me._UploadFrequency = UploadInterval
            Me._SrcDir = SrcDir
            Me.UploadFiles(0)
        End Sub

        Public Sub AbortUpload()
            If Me._thdUpload.IsAlive Then
                Me._thdUpload.Abort
            End If
        End Sub

        Public Sub UploadFiles()
            Me.UploadFiles(0)
        End Sub

        <MethodImpl((MethodImplOptions.NoOptimization Or MethodImplOptions.NoInlining))> _
        Private Sub UploadFiles(ByVal Recursion As Integer)
            If Not Me.UploadRequired Then
                Logging.AddLogEntry(Me, "Upload not currently required.", EventLogEntryType.Information, 2)
            Else
                Try 
                    If Not UploadSettings.SettingsVerified Then
                        If (Recursion <> 0) Then
                            Logging.AddLogEntry(Me, "User did not verify settings, skipping request to upload files.", EventLogEntryType.Information, 0)
                            Interaction.MsgBox("Can not upload files until the FUEL Settings have been verified." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Please access FUEL Settings via the Windows Start Menu" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Skipping request to upload files.", MsgBoxStyle.ApplicationModal, Nothing)
                        Else
                            Logging.AddLogEntry(Me, "Cant upload files till FUEL Settings have been verified", EventLogEntryType.Information, 0)
                            Interaction.MsgBox("You must verify FUEL Settings before trying to upload data", MsgBoxStyle.ApplicationModal, Nothing)
                            Dim process As New Process
                            process.StartInfo.FileName = If(Not MyProject.Application.Info.DirectoryPath.Contains("\bin\"), Path.Combine(modCommonCode.GetDataPath, "FuelSettings.exe"), "C:\Users\morrisor\Documents\Visual Studio 2010\Projects\FUEL\AutoSendFiles\FUELSettings\bin\Debug\FUELSettings.exe")
                            process.Start
                            process.WaitForExit
                            Me.UploadFiles((Recursion + 1))
                        End If
                    Else
                        Logging.AddLogEntry("clsFileUpload", "Starting Upload", EventLogEntryType.Information, 2)
                        If Me.NewThread Then
                            Me._thdUpload = New Thread(New ThreadStart(AddressOf Me.UploadInNewThread))
                            Me._thdUpload.IsBackground = False
                            Me._thdUpload.Start
                        Else
                            Dim upload As New frmAutoUpload(Me.SrcDir)
                            Dim aHandle As IntPtr = PST.getOwner
                            If (aHandle <> DirectCast(-1, IntPtr)) Then
                                upload.ShowDialog(New WindowWrapper(aHandle))
                            Else
                                upload.ShowDialog
                            End If
                        End If
                    End If
                    MySettingsProperty.Settings.LastUploadTime = DateAndTime.Now
                    MySettingsProperty.Settings.Save
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Interaction.MsgBox(("There was a problem uploading your data to the network" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & ex.ToString), MsgBoxStyle.Critical, Nothing)
                    ProjectData.ClearProjectError
                End Try
            End If
        End Sub

        Private Sub UploadInNewThread()
            Logging.AddLogEntry("FS.UploadInNewThread", "Starting Zip process", EventLogEntryType.Information, 2)
            New frmZipProgress(Me.SrcDir, Me.ZipFileName, Me.DeleteFilesAfterZip) With { _
                .MaxFileSize = CLng(Math.Round(Me.MaxZipFileSize)), _
                .HideForm = Me.HideForms _
            }.ShowDialog
            Logging.AddLogEntry("FS.UploadInNewThread", "Done with Zip process", EventLogEntryType.Information, 2)
            Logging.AddLogEntry("FS.UploadInNewThread", "Starting Upload process", EventLogEntryType.Information, 2)
            Dim upload As New frmAutoUpload(Me.SrcDir) With { _
                .HideForm = Me.HideForms _
            }
            upload.ShowDialog
            Logging.AddLogEntry("FS.UploadInNewThread", "Done with Upload process", EventLogEntryType.Information, 2)
            upload.HideForm = Me.HideForms
        End Sub


        ' Properties
        Private Property _SrcDir As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SrcDir
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SrcDir = AutoPropertyValue
            End Set
        End Property

        Public Property SrcDir As String
            Get
                Return Me._SrcDir
            End Get
            Set(ByVal value As String)
                Me._SrcDir = value
            End Set
        End Property

        Private Property _UploadFrequency As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__UploadFrequency
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__UploadFrequency = AutoPropertyValue
            End Set
        End Property

        Public Property UploadFrequency As Integer
            Get
                Return Me._UploadFrequency
            End Get
            Set(ByVal value As Integer)
                Me._UploadFrequency = value
            End Set
        End Property

        Private Property _UploadRequired As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__UploadRequired
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__UploadRequired = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property UploadRequired As Boolean
            Get
                Dim num As Integer = CInt(DateAndTime.DateDiff(DateInterval.Minute, MySettingsProperty.Settings.LastUploadTime, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
                Logging.AddLogEntry("FileUpload: UploadRequired", ("Date Delta from last upload (minutes) = " & num.ToString), EventLogEntryType.Information, 2)
                Return (num >= (Me._UploadFrequency * 60))
            End Get
        End Property

        Public Property NewThread As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._NewThread
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._NewThread = AutoPropertyValue
            End Set
        End Property

        Public Property ZipFiles As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._ZipFiles
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._ZipFiles = AutoPropertyValue
            End Set
        End Property

        Public Property ZipFileName As String
            <DebuggerNonUserCode> _
            Get
                Return Me._ZipFileName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me._ZipFileName = AutoPropertyValue
            End Set
        End Property

        Public Property DeleteFilesAfterZip As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._DeleteFilesAfterZip
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._DeleteFilesAfterZip = AutoPropertyValue
            End Set
        End Property

        Public Property MaxZipFileSize As Double
            <DebuggerNonUserCode> _
            Get
                Return Me._MaxZipFileSize
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me._MaxZipFileSize = AutoPropertyValue
            End Set
        End Property

        Public Property HideForms As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._HideForms
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._HideForms = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property Status As String
            Get
                Return If(Not Me._thdUpload.IsAlive, "Idle", "Busy")
            End Get
        End Property


        ' Fields
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __SrcDir As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __UploadFrequency As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __UploadRequired As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _NewThread As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _ZipFiles As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _ZipFileName As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _DeleteFilesAfterZip As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _MaxZipFileSize As Double
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _HideForms As Boolean
        Private _thdUpload As Thread
    End Class
End Namespace

