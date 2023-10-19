Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Xml

Namespace FUEL
    Public Class UploadSettings
        ' Methods
        Shared Sub New()
            UploadSettings._InstallLocation = TestSites.HP
            UploadSettings._LocalCopyToAddress = "M:\"
            UploadSettings._VCDServerAddress = "https://pst1.vcd.hp.com/PST/upload.php"
            UploadSettings._SettingsVerified = False
            UploadSettings._DebugLevel = MySettingsProperty.Settings.DebugLevel
        End Sub

        Private Shared Sub Create()
            Try 
                Dim settings As New XmlWriterSettings With { _
                    .Indent = True _
                }
                Dim objA As XmlWriter = XmlWriter.Create(UploadSettings.SettingsFileLocation, settings)
                Try 
                    objA.WriteStartDocument
                    objA.WriteStartElement("Settings")
                    objA.WriteStartElement("Setting")
                    objA.WriteAttributeString("Name", "InstallLocation")
                    objA.WriteAttributeString("Value", Conversions.ToString(CInt(UploadSettings._InstallLocation)))
                    objA.WriteEndElement
                    objA.WriteStartElement("Setting")
                    objA.WriteAttributeString("Name", "VCDServerAddress")
                    objA.WriteAttributeString("Value", UploadSettings._VCDServerAddress)
                    objA.WriteEndElement
                    objA.WriteStartElement("Setting")
                    objA.WriteAttributeString("Name", "LocalCopyToAddress")
                    objA.WriteAttributeString("Value", UploadSettings._LocalCopyToAddress)
                    objA.WriteEndElement
                    objA.WriteStartElement("Setting")
                    objA.WriteAttributeString("Name", "SettingsVerified")
                    objA.WriteAttributeString("Value", Conversions.ToString(UploadSettings._SettingsVerified))
                    objA.WriteEndElement
                    objA.WriteEndElement
                    objA.WriteEndDocument
                    objA.Flush
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: Settings file location = " & UploadSettings.SettingsFileLocation), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: SettingsVerified = " & Conversions.ToString(UploadSettings._SettingsVerified)), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: InstallLocation = " & Conversions.ToString(CInt(UploadSettings._InstallLocation))), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: VCDServerAddress = " & UploadSettings._VCDServerAddress), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: LocalCopyToAddress = " & UploadSettings._LocalCopyToAddress), EventLogEntryType.Information, 4)
                    Logging.AddLogEntry("UploadSettings.Create", ("UploadSettings: DebugLevel = " & Conversions.ToString(UploadSettings.DebugLevel)), EventLogEntryType.Information, 4)
                Finally
                    If Not Object.ReferenceEquals(objA, Nothing) Then
                        objA.Dispose
                    End If
                End Try
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Logging.AddLogEntry("UploadSettings.Create", ("Error: " & exception.ToString), EventLogEntryType.Error, 0)
                Interaction.MsgBox("UploadSettings.Create", DirectCast(Conversions.ToInteger(("Error: " & ChrW(13) & ChrW(10) & exception.ToString)), MsgBoxStyle), MsgBoxStyle.Critical)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Shared Function GetVal(ByVal Name As String) As String
            Dim flag2 As Boolean = UploadSettings.VerifySettings
            If Not flag2 Then
                Logging.AddLogEntry("clsUploadSettings: GetVal", "Couldn't create settings file", EventLogEntryType.Error, 0)
                Throw New ArgumentException("Couldn't create settings file")
            End If
            Dim objA As XmlReader = XmlReader.Create(UploadSettings.SettingsFileLocation)
            Try 
                Dim flag As Boolean = False
                Do While True
                    Dim flag3 As Boolean = objA.Read
                    If flag3 Then
                        flag2 = ((objA.NodeType = XmlNodeType.Element) And objA.HasAttributes)
                        If (Not flag2 OrElse (objA("Name").ToUpper <> Name.ToString.ToUpper)) Then
                            Continue Do
                        End If
                        flag = True
                        Return objA("Value")
                    ElseIf Not flag Then
                        Logging.AddLogEntry("clsUploadSettings: GetVal", ("Couldn't find requested setting" & ChrW(13) & ChrW(10) & "Setting: " & Name), EventLogEntryType.Error, 0)
                        UploadSettings.Create
                    End If
                    Exit Do
                Loop
            Finally
                If Not Object.ReferenceEquals(objA, Nothing) Then
                    objA.Dispose
                End If
            End Try
            Return Nothing
        End Function

        Public Shared Sub Reset()
            UploadSettings._InstallLocation = TestSites.HP
            UploadSettings._LocalCopyToAddress = "M:\"
            UploadSettings._VCDServerAddress = "https://pst1.vcd.hp.com/PST/upload.php"
            UploadSettings._SettingsVerified = False
            MySettingsProperty.Settings.DebugLevel = 4
            UploadSettings.Save
        End Sub

        Public Shared Sub Save()
            MySettingsProperty.Settings.Save
            UploadSettings.Create
        End Sub

        Private Shared Function VerifySettings() As Boolean
            Return UploadSettings.VerifySettings(0)
        End Function

        Private Shared Function VerifySettings(ByVal Recursion As Integer) As Boolean
            Dim flag As Boolean
            If Not (Not MyProject.Computer.FileSystem.FileExists(UploadSettings.SettingsFileLocation) And (Recursion <= 1)) Then
                flag = Not (Not MyProject.Computer.FileSystem.FileExists(UploadSettings.SettingsFileLocation) And (Recursion >= 1))
            Else
                UploadSettings.Create
                flag = UploadSettings.VerifySettings((Recursion + 1))
            End If
            Return flag
        End Function


        ' Properties
        Private Shared ReadOnly Property SettingsFileLocation As String
            Get
                Return If(Not modCommonCode.GetDataPath.ToLower.Contains("\bin\"), Path.Combine(modCommonCode.GetDataPath, "Uploadsettings.xml"), "C:\Users\morrisor\Documents\Visual Studio 2010\Projects\FUEL\AutoSendFiles\FUEL\Uploadsettings.xml")
            End Get
        End Property

        Private Shared Property _InstallLocation As TestSites
            <DebuggerNonUserCode> _
            Get
                Return UploadSettings.__InstallLocation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestSites)
                UploadSettings.__InstallLocation = AutoPropertyValue
            End Set
        End Property

        Public Shared Property InstallLocation As TestSites
            Get
                Return DirectCast(Conversions.ToInteger(UploadSettings.GetVal("InstallLocation")), TestSites)
            End Get
            Set(ByVal value As TestSites)
                UploadSettings._InstallLocation = value
            End Set
        End Property

        Private Shared Property _LocalCopyToAddress As String
            <DebuggerNonUserCode> _
            Get
                Return UploadSettings.__LocalCopyToAddress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                UploadSettings.__LocalCopyToAddress = AutoPropertyValue
            End Set
        End Property

        Public Shared Property LocalCopyToAddress As String
            Get
                Return UploadSettings.GetVal("LocalCopyToAddress")
            End Get
            Set(ByVal value As String)
                UploadSettings._LocalCopyToAddress = value
            End Set
        End Property

        Private Shared Property _VCDServerAddress As String
            <DebuggerNonUserCode> _
            Get
                Return UploadSettings.__VCDServerAddress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                UploadSettings.__VCDServerAddress = AutoPropertyValue
            End Set
        End Property

        Public Shared Property VCDServerAddress As String
            Get
                Return UploadSettings.GetVal("VCDServerAddress")
            End Get
            Set(ByVal value As String)
                UploadSettings._VCDServerAddress = value
            End Set
        End Property

        Private Shared Property _SettingsVerified As Boolean
            <DebuggerNonUserCode> _
            Get
                Return UploadSettings.__SettingsVerified
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                UploadSettings.__SettingsVerified = AutoPropertyValue
            End Set
        End Property

        Public Shared Property SettingsVerified As Boolean
            Get
                Return Conversions.ToBoolean(UploadSettings.GetVal("SettingsVerified"))
            End Get
            Set(ByVal value As Boolean)
                UploadSettings._SettingsVerified = value
            End Set
        End Property

        Private Shared Property _DebugLevel As Integer
            <DebuggerNonUserCode> _
            Get
                Return UploadSettings.__DebugLevel
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                UploadSettings.__DebugLevel = AutoPropertyValue
            End Set
        End Property

        Public Shared Property DebugLevel As Integer
            Get
                Return MySettingsProperty.Settings.DebugLevel
            End Get
            Set(ByVal value As Integer)
                UploadSettings._DebugLevel = value
                MySettingsProperty.Settings.DebugLevel = value
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared __InstallLocation As TestSites
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared __LocalCopyToAddress As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared __VCDServerAddress As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared __SettingsVerified As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared __DebugLevel As Integer
    End Class
End Namespace

