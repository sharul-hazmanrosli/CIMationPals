Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class FailedChecks
        Inherits FSDialog
        ' Methods
        Public Sub New(ByVal Name As String, ByVal Val As String, ByVal CheckType As SpecType, ByVal Spec1 As String, ByVal Instructions As String)
            Me.New(Name, Val, CheckType, Spec1, Nothing, Instructions)
        End Sub

        Public Sub New(ByVal Name As String, ByVal Val As String, ByVal CheckType As SpecType, ByVal Spec1 As String, ByVal Spec2 As String, ByVal Instructions As String)
            Me._Name = Name
            Me._Val = Val
            Me._CheckType = CheckType
            Me._Spec1 = Spec1
            Me._Spec2 = Spec2
            Me._Instructions = Instructions
        End Sub

        Public Sub Show()
            Dim dialog As New dlgCriticalCheckFailed(Me._Name, Me._Val, Me._CheckType, Me._Spec1, Me._Spec2, Me._Instructions)
            Me.Show(dialog)
        End Sub


        ' Properties
        Private Property _Name As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Name
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Name = AutoPropertyValue
            End Set
        End Property

        Private Property _Val As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Val
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Val = AutoPropertyValue
            End Set
        End Property

        Private Property _CheckType As SpecType
            <DebuggerNonUserCode> _
            Get
                Return Me.__CheckType
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As SpecType)
                Me.__CheckType = AutoPropertyValue
            End Set
        End Property

        Private Property _Spec1 As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Spec1
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Spec1 = AutoPropertyValue
            End Set
        End Property

        Private Property _Spec2 As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Spec2
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Spec2 = AutoPropertyValue
            End Set
        End Property

        Private Property _Instructions As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Instructions
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Instructions = AutoPropertyValue
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Name As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Val As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __CheckType As SpecType
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Spec1 As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Spec2 As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Instructions As String
    End Class
End Namespace

