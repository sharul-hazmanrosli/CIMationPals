Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class clsUploadSettings2
        ' Methods
        Public Sub Reset()
            Me._InstallLocation = TestSites.HP
            Me._LocalCopyToAddress = "M:\"
            Me._VCDServerAddress = "http://pst1.vcd.hp.com/PST/upload.php"
            Me._SettingsVerified = False
            Me._DebugLevel = 4
        End Sub


        ' Properties
        Private Property _InstallLocation As TestSites
            <DebuggerNonUserCode> _
            Get
                Return Me.__InstallLocation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestSites)
                Me.__InstallLocation = AutoPropertyValue
            End Set
        End Property

        Private Property _VCDServerAddress As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__VCDServerAddress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__VCDServerAddress = AutoPropertyValue
            End Set
        End Property

        Private Property _LocalCopyToAddress As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__LocalCopyToAddress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__LocalCopyToAddress = AutoPropertyValue
            End Set
        End Property

        Private Property _SettingsVerified As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__SettingsVerified
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__SettingsVerified = AutoPropertyValue
            End Set
        End Property

        Private Property _DebugLevel As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__DebugLevel
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__DebugLevel = AutoPropertyValue
            End Set
        End Property

        Friend ReadOnly Property SettingsFileLocation As String
            Get
                Return If(Not modCommonCode.GetDataPath.ToLower.Contains("\bin\"), Path.Combine(modCommonCode.GetDataPath, "Uploadsettings2.xml"), "C:\Users\morrisor\Documents\Visual Studio 2010\Projects\FUEL\AutoSendFiles\FUEL\Uploadsettings2.xml")
            End Get
        End Property

        Public Property InstallLocation As TestSites
            Get
                Return Me._InstallLocation
            End Get
            Set(ByVal value As TestSites)
                Me._InstallLocation = value
            End Set
        End Property

        Public Property VCDServerAddress As String
            Get
                Return Me._VCDServerAddress
            End Get
            Set(ByVal value As String)
                Me._VCDServerAddress = value
            End Set
        End Property

        Public Property LocalCopyToAddress As String
            Get
                Return Me._LocalCopyToAddress
            End Get
            Set(ByVal value As String)
                Me._LocalCopyToAddress = value
            End Set
        End Property

        Public Property SettingsVerified As Boolean
            Get
                Return Me._SettingsVerified
            End Get
            Set(ByVal value As Boolean)
                Me._SettingsVerified = value
            End Set
        End Property

        Public Property DebugLevel As Integer
            Get
                Return Me._DebugLevel
            End Get
            Set(ByVal value As Integer)
                Me._DebugLevel = value
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __InstallLocation As TestSites
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __VCDServerAddress As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __LocalCopyToAddress As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __SettingsVerified As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __DebugLevel As Integer
    End Class
End Namespace

