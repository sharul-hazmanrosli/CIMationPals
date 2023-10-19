Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization

Namespace FUEL
    Public Class Specifications
        ' Methods
        Protected Sub New()
            Me._VentDxDt2Threshold = -75
            Me._DerivCnt = 12
            Me._LeakMin = -1
            Me._LeakMax = 0
            Me._TubeEvacDeltaPressure = 9
            Me._WetPHAHoldTimeRetardVal = 0
        End Sub

        Public Sub New(ByVal PChannel As Channel)
            Me._VentDxDt2Threshold = -75
            Me._DerivCnt = 12
            Me._LeakMin = -1
            Me._LeakMax = 0
            Me._TubeEvacDeltaPressure = 9
            Me._WetPHAHoldTimeRetardVal = 0
            Me.PumpChannel = PChannel
        End Sub

        Private Sub DispSpecs()
            Interaction.MsgBox(String.Concat(New String() { "Pressure:  ", Conversions.ToString(Me.PressureMin), "/", Conversions.ToString(Me.PressureMax), ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Leak:      ", Conversions.ToString(Me.LeakMax), ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Vent Time: ", Conversions.ToString(Me.VentTime) }), MsgBoxStyle.Information, "Current PST Specs")
        End Sub

        Friend Sub SetMaxLeakVal(ByVal t1 As Double, ByVal t2 As Double)
            Me.LeakMax = CInt(Math.Round(CDbl(((t2 - t1) * 5))))
        End Sub

        Public Function Validate() As Boolean
            Dim flag As Boolean = True
            If Information.IsNothing(Me.HoldTime) Then
                flag = False
            ElseIf (Me.HoldTime <= 0) Then
                flag = False
            End If
            If Information.IsNothing(Me.PressureMax) Then
                flag = False
            ElseIf (Me.PressureMax <= 0) Then
                flag = False
            End If
            If Information.IsNothing(Me.PressureMin) Then
                flag = False
            ElseIf ((Me.PressureMin <= 0) Or (Me.PressureMin > Me.PressureMax)) Then
                flag = False
            End If
            If Information.IsNothing(Me.LeakMax) Then
                flag = False
            ElseIf (Me.LeakMin > Me.LeakMax) Then
                flag = False
            End If
            If Information.IsNothing(Me.VentTime) Then
                flag = False
            ElseIf Not (Me.VentTime <> 0) Then
                flag = False
            End If
            If Information.IsNothing(Me.PumpVolume) Then
                flag = False
            ElseIf (Me.PumpVolume <= 0) Then
                flag = False
            End If
            If Information.IsNothing(Me.PumpRate) Then
                flag = False
            ElseIf (Me.PumpRate <= 0) Then
                flag = False
            End If
            If (Me.PumpTime = -1) Then
                flag = False
            End If
            If Not flag Then
                Interaction.MsgBox("Specs are not valid. PST results may be comprimised.", MsgBoxStyle.Information, Nothing)
            End If
            Return flag
        End Function


        ' Properties
        Private Property _PumpChannel As Channel
            <DebuggerNonUserCode> _
            Get
                Return Me.__PumpChannel
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Channel)
                Me.__PumpChannel = AutoPropertyValue
            End Set
        End Property

        Private Property _PressureMax As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__PressureMax
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__PressureMax = AutoPropertyValue
            End Set
        End Property

        Private Property _PressureMin As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__PressureMin
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__PressureMin = AutoPropertyValue
            End Set
        End Property

        Private Property _VentTime As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__VentTime
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__VentTime = AutoPropertyValue
            End Set
        End Property

        Private Property _VentDeltaPMin As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__VentDeltaPMin
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__VentDeltaPMin = AutoPropertyValue
            End Set
        End Property

        Private Property _VentDxDt2Threshold As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__VentDxDt2Threshold
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__VentDxDt2Threshold = AutoPropertyValue
            End Set
        End Property

        Private Property _DerivCnt As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__DerivCnt
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__DerivCnt = AutoPropertyValue
            End Set
        End Property

        Private Property _HoldTime As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__HoldTime
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__HoldTime = AutoPropertyValue
            End Set
        End Property

        Private Property _LeakMin As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__LeakMin
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__LeakMin = AutoPropertyValue
            End Set
        End Property

        Private Property _LeakMax As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__LeakMax
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__LeakMax = AutoPropertyValue
            End Set
        End Property

        Private Property _AllowWetPHA As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__AllowWetPHA
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__AllowWetPHA = AutoPropertyValue
            End Set
        End Property

        Private Property _AllowDryPHA As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__AllowDryPHA
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__AllowDryPHA = AutoPropertyValue
            End Set
        End Property

        Private Property _TubeEvacDeltaPressure As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__TubeEvacDeltaPressure
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__TubeEvacDeltaPressure = AutoPropertyValue
            End Set
        End Property

        Private Property _WetPHAHoldTimeRetardVal As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__WetPHAHoldTimeRetardVal
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__WetPHAHoldTimeRetardVal = AutoPropertyValue
            End Set
        End Property

        Private Property _PumpVolume As Long
            <DebuggerNonUserCode> _
            Get
                Return Me.__PumpVolume
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Long)
                Me.__PumpVolume = AutoPropertyValue
            End Set
        End Property

        Private Property _PumpRate As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me.__PumpRate
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me.__PumpRate = AutoPropertyValue
            End Set
        End Property

        Private Property _PressureBuildDelay As Double()
            <DebuggerNonUserCode> _
            Get
                Return Me.__PressureBuildDelay
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double())
                Me.__PressureBuildDelay = AutoPropertyValue
            End Set
        End Property

        Public Property HoldTime As Integer
            Get
                Return Me._HoldTime
            End Get
            Set(ByVal value As Integer)
                Me._HoldTime = value
            End Set
        End Property

        Friend ReadOnly Property DerivCnt As Integer
            Get
                Return Me._DerivCnt
            End Get
        End Property

        Public Property PressureMax As Integer
            Get
                Return Me._PressureMax
            End Get
            Set(ByVal value As Integer)
                Me._PressureMax = value
            End Set
        End Property

        Public Property PressureMin As Integer
            Get
                Return Me._PressureMin
            End Get
            Set(ByVal value As Integer)
                Me._PressureMin = value
            End Set
        End Property

        Public Property LeakMax As Integer
            Get
                Return Me._LeakMax
            End Get
            Set(ByVal value As Integer)
                Me._LeakMax = value
            End Set
        End Property

        Public Property LeakMin As Integer
            Get
                Return Me._LeakMin
            End Get
            Set(ByVal value As Integer)
                Me._LeakMin = value
            End Set
        End Property

        Public Property VentTime As Double
            Get
                Return Me._VentTime
            End Get
            Set(ByVal value As Double)
                Me._VentTime = value
            End Set
        End Property

        Public ReadOnly Property VentDeltaPMin As Double
            Get
                Return Me._VentDeltaPMin
            End Get
        End Property

        Public ReadOnly Property VentDxDt2Threshold As Double
            Get
                Return Me._VentDxDt2Threshold
            End Get
        End Property

        Public Property AllowWetPHA As Boolean
            Get
                Return Me._AllowWetPHA
            End Get
            Set(ByVal value As Boolean)
                Me._AllowWetPHA = value
                If Not value Then
                    Me._VentDeltaPMin = 60
                Else
                    Me._WetPHAHoldTimeRetardVal = 3
                    Me._VentDeltaPMin = 10
                    Me.LeakMin = -20
                End If
                If (Me.PumpChannel = Channel.Black) Then
                    Me._PressureBuildDelay = If(Not Me.AllowWetPHA, New Double() { 0, 0 }, New Double() { -0.7898, 3.1361 })
                ElseIf (Me.PumpChannel = Channel.Color) Then
                    Me._PressureBuildDelay = If(Not Me.AllowWetPHA, New Double() { 0, 0 }, New Double() { 0, -0.9575 })
                End If
            End Set
        End Property

        Public Property TubeEvacDeltaPressure As Integer
            Get
                Return Me._TubeEvacDeltaPressure
            End Get
            Set(ByVal value As Integer)
                Me._TubeEvacDeltaPressure = value
            End Set
        End Property

        Public Property PumpVolume As Long
            Get
                Return Me._PumpVolume
            End Get
            Set(ByVal value As Long)
                Me._PumpVolume = value
            End Set
        End Property

        Public Property PumpRate As Integer
            Get
                Return Me._PumpRate
            End Get
            Set(ByVal value As Integer)
                Me._PumpRate = value
            End Set
        End Property

        Public ReadOnly Property PumpTime As Double
            Get
                Dim num As Double
                If Not (Not Information.IsNothing(Me.PumpRate) And Not Information.IsNothing(Me.PumpVolume)) Then
                    num = -1
                Else
                    Dim num2 As Double = (Me.PumpVolume * 1E-07)
                    num = (((1 / CDbl(Me.PumpRate)) * num2) * 60)
                End If
                Return num
            End Get
        End Property

        Public ReadOnly Property WetPHAHoldTimeRetardVal As Integer
            Get
                Return Me._WetPHAHoldTimeRetardVal
            End Get
        End Property

        Public ReadOnly Property PressureBuildDelay As Double()
            Get
                Return Me._PressureBuildDelay
            End Get
        End Property

        <XmlIgnore> _
        Property PumpChannel As Channel
            Public Get
                Return Me._PumpChannel
            End Get
            Protected Set(ByVal value As Channel)
                Me._PumpChannel = value
                If (Me._PumpChannel = Channel.Black) Then
                    If (Me.PumpVolume = 0) Then
                        Me.PumpVolume = &H8EAB70
                    End If
                    If (Me.PumpRate = 0) Then
                        Me.PumpRate = &H18
                    End If
                Else
                    If (Me.PumpVolume = 0) Then
                        Me.PumpVolume = &HEC82E0
                    End If
                    If (Me.PumpRate = 0) Then
                        Me.PumpRate = &H18
                    End If
                End If
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PumpChannel As Channel
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PressureMax As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PressureMin As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __VentTime As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __VentDeltaPMin As Double
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __VentDxDt2Threshold As Double
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __DerivCnt As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __HoldTime As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __LeakMin As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __LeakMax As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __AllowWetPHA As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __AllowDryPHA As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __TubeEvacDeltaPressure As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __WetPHAHoldTimeRetardVal As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PumpVolume As Long
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __PumpRate As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PressureBuildDelay As Double()
    End Class
End Namespace

