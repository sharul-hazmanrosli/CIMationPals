Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class TraceData
        ' Properties
        Private Property _X As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__X
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__X = AutoPropertyValue
            End Set
        End Property

        Private Property _Y As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__Y
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__Y = AutoPropertyValue
            End Set
        End Property

        Private Property _SlidingAVG As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__SlidingAVG
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__SlidingAVG = AutoPropertyValue
            End Set
        End Property

        Private Property _DxDt As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__DxDt
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__DxDt = AutoPropertyValue
            End Set
        End Property

        Private Property _DxDt2 As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__DxDt2
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__DxDt2 = AutoPropertyValue
            End Set
        End Property

        Public Property X As Double
            Get
                Return Me._X
            End Get
            Set(ByVal value As Double)
                Me._X = value
            End Set
        End Property

        Public Property Y As Double
            Get
                Return Me._Y
            End Get
            Set(ByVal value As Double)
                Me._Y = value
            End Set
        End Property

        Public Property SlidingAVG As Double
            Get
                Return Me._SlidingAVG
            End Get
            Set(ByVal value As Double)
                Me._SlidingAVG = value
            End Set
        End Property

        Public Property DxDt As Double
            Get
                Return Me._DxDt
            End Get
            Set(ByVal value As Double)
                Me._DxDt = value
            End Set
        End Property

        Public Property DxDt2 As Double
            Get
                Return Me._DxDt2
            End Get
            Set(ByVal value As Double)
                Me._DxDt2 = value
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __X As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Y As Double
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __SlidingAVG As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __DxDt As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __DxDt2 As Double
    End Class
End Namespace

