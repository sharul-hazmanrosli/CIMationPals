Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL.My
    <EditorBrowsable(EditorBrowsableState.Advanced), GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated> _
    Public NotInheritable Class MySettings
        Inherits ApplicationSettingsBase
        ' Properties
        Public Shared ReadOnly Property [Default] As MySettings
            Get
                Return MySettings.defaultInstance
            End Get
        End Property

        <UserScopedSetting, DefaultSettingValue("AP41M;-102.5;105;InchesWater|AP41M;7.53375;-7.7175;InchesHg|Voltage;20;0;Volts"), DebuggerNonUserCode> _
        Public Property SensorCalibrations As String
            Get
                Return Conversions.ToString(Me("SensorCalibrations"))
            End Get
            Set(ByVal Value As String)
                Me("SensorCalibrations") = Value
            End Set
        End Property

        <DebuggerNonUserCode, UserScopedSetting> _
        Public Property UpdateCheck As DateTime
            Get
                Return Conversions.ToDate(Me("UpdateCheck"))
            End Get
            Set(ByVal Value As DateTime)
                Me("UpdateCheck") = Value
            End Set
        End Property

        <DebuggerNonUserCode, UserScopedSetting> _
        Public Property LastUploadTime As DateTime
            Get
                Return Conversions.ToDate(Me("LastUploadTime"))
            End Get
            Set(ByVal Value As DateTime)
                Me("LastUploadTime") = Value
            End Set
        End Property

        <UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue("HP|NKG")> _
        Public Property SiteList As String
            Get
                Return Conversions.ToString(Me("SiteList"))
            End Get
            Set(ByVal Value As String)
                Me("SiteList") = Value
            End Set
        End Property

        <UserScopedSetting, DefaultSettingValue("0"), DebuggerNonUserCode> _
        Public Property CurrentSite As Integer
            Get
                Return Conversions.ToInteger(Me("CurrentSite"))
            End Get
            Set(ByVal Value As Integer)
                Me("CurrentSite") = Value
            End Set
        End Property

        <DebuggerNonUserCode, DefaultSettingValue("4"), UserScopedSetting> _
        Public Property DebugLevel As Integer
            Get
                Return Conversions.ToInteger(Me("DebugLevel"))
            End Get
            Set(ByVal Value As Integer)
                Me("DebugLevel") = Value
            End Set
        End Property

        <UserScopedSetting, DefaultSettingValue("-1"), DebuggerNonUserCode> _
        Public Property TestStationType As Integer
            Get
                Return Conversions.ToInteger(Me("TestStationType"))
            End Get
            Set(ByVal Value As Integer)
                Me("TestStationType") = Value
            End Set
        End Property

        <DebuggerNonUserCode, UserScopedSetting> _
        Public Property TestStationType_Date As DateTime
            Get
                Return Conversions.ToDate(Me("TestStationType_Date"))
            End Get
            Set(ByVal Value As DateTime)
                Me("TestStationType_Date") = Value
            End Set
        End Property

        <DebuggerNonUserCode, ApplicationScopedSetting, DefaultSettingValue("mAPCaGMj4WrKdy46+tgeYMcvf9K9OYZQ3wVOeYir4eJq0kXADVReDbydeqNveZto")> _
        Public ReadOnly Property SecurePropertyKey_OverRide As String
            Get
                Return Conversions.ToString(Me("SecurePropertyKey_OverRide"))
            End Get
        End Property

        <DefaultSettingValue("mytest"), UserScopedSetting, DebuggerNonUserCode> _
        Public Property testing As String
            Get
                Return Conversions.ToString(Me("testing"))
            End Get
            Set(ByVal Value As String)
                Me("testing") = Value
            End Set
        End Property


        ' Fields
        Private Shared defaultInstance As MySettings = DirectCast(SettingsBase.Synchronized(New MySettings), MySettings)
    End Class
End Namespace

