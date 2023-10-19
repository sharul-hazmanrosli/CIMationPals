Imports FUEL.FS
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports RDL
Imports System
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class CheckForUpdates
        ' Methods
        Public Sub New(ByVal DLLocation As String, ByVal SaveAs As String, ByVal FUELType As CheckType)
            Me._DLLoc = DLLocation
            Me._SaveAs = SaveAs
            Me._FUELType = FUELType
            If Not Me.DownloadVersionFile Then
                Me._UpdateRequired = UpdateType.None
            Else
                Me.ReadVersionFile
                Me.DetermineIfUpdateNeeded
            End If
        End Sub

        Private Sub DetermineIfUpdateNeeded()
            Me._CurrentVersion = New Version(Assembly.GetExecutingAssembly.GetName.Version.ToString)
            Me._UpdateRequired = If(Not ((Me._CurrentVersion < Me._RequiredPSTVersion) And (Me._FUELType = CheckType.PST)), If(Not ((Me._CurrentVersion < Me._RequiredFSVersion) And (Me._FUELType = CheckType.FS)), If((Me._CurrentVersion >= Me._ServerVersion), UpdateType.None, UpdateType.OptionalUpdate), UpdateType.RequiredUpdate), UpdateType.RequiredUpdate)
        End Sub

        Private Function DownloadVersionFile() As Boolean
            Dim sync As New HTTPDownloadSync(Me._DLLoc, Me._SaveAs)
            sync.StartDownload
            Return Conversions.ToBoolean(sync.Success)
        End Function

        Private Sub ReadVersionFile()
            Dim array(,) As String(0 To .,0 To .) = FileProcessing.ReadDelimitedFile(Me._SaveAs, ":")
            Dim num2 As Integer = Information.UBound(array, 1)
            Dim num As Integer = 0
            Do While True
                Dim num3 As Integer = num2
                If (num > num3) Then
                    Return
                End If
                Dim str As String = array(num, 0).ToUpper
                If (str = "CurrentVersion".ToUpper) Then
                    Me._ServerVersion = New Version(array(num, 1))
                ElseIf (str = "RequiredPSTVersion".ToUpper) Then
                    Me._RequiredPSTVersion = New Version(array(num, 1))
                ElseIf (str = "RequiredFSVersion".ToUpper) Then
                    Me._RequiredFSVersion = New Version(array(num, 1))
                ElseIf (str = "FileList".ToUpper) Then
                    Me._FileList = array(num, 1)
                End If
                num += 1
            Loop
        End Sub


        ' Properties
        Private Property _DLLoc As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__DLLoc
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__DLLoc = AutoPropertyValue
            End Set
        End Property

        Private Property _SaveAs As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SaveAs
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SaveAs = AutoPropertyValue
            End Set
        End Property

        Private Property _FUELType As CheckType
            <DebuggerNonUserCode> _
            Get
                Return Me.__FUELType
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As CheckType)
                Me.__FUELType = AutoPropertyValue
            End Set
        End Property

        Private Property _ServerVersion As Version
            <DebuggerNonUserCode> _
            Get
                Return Me.__ServerVersion
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Version)
                Me.__ServerVersion = AutoPropertyValue
            End Set
        End Property

        Private Property _CurrentVersion As Version
            <DebuggerNonUserCode> _
            Get
                Return Me.__CurrentVersion
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Version)
                Me.__CurrentVersion = AutoPropertyValue
            End Set
        End Property

        Private Property _RequiredPSTVersion As Version
            <DebuggerNonUserCode> _
            Get
                Return Me.__RequiredPSTVersion
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Version)
                Me.__RequiredPSTVersion = AutoPropertyValue
            End Set
        End Property

        Private Property _RequiredFSVersion As Version
            <DebuggerNonUserCode> _
            Get
                Return Me.__RequiredFSVersion
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Version)
                Me.__RequiredFSVersion = AutoPropertyValue
            End Set
        End Property

        Private Property _UpdateRequired As UpdateType
            <DebuggerNonUserCode> _
            Get
                Return Me.__UpdateRequired
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As UpdateType)
                Me.__UpdateRequired = AutoPropertyValue
            End Set
        End Property

        Private Property _FileList As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__FileList
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__FileList = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property UpdateAvailable As Object
            Get
                Return Me._UpdateRequired
            End Get
        End Property

        Public ReadOnly Property ServerVersion As String
            Get
                Return Me._ServerVersion.ToString
            End Get
        End Property

        Public ReadOnly Property CurrentVersion As String
            Get
                Return Me._CurrentVersion.ToString
            End Get
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __DLLoc As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __SaveAs As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __FUELType As CheckType
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __ServerVersion As Version
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __CurrentVersion As Version
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __RequiredPSTVersion As Version
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __RequiredFSVersion As Version
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __UpdateRequired As UpdateType
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __FileList As String

        ' Nested Types
        Public Enum CheckType
            ' Fields
            PST = 0
            FS = 1
        End Enum

        Public Enum UpdateType
            ' Fields
            None = 0
            OptionalUpdate = 1
            RequiredUpdate = 2
        End Enum
    End Class
End Namespace

