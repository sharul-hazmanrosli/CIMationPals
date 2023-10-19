Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class TestSpecs
        ' Methods
        Public Sub New()
            Me._MechChecks = New List(Of PrinterMechChecks)
        End Sub


        ' Properties
        Private Property _TestID As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__TestID
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__TestID = AutoPropertyValue
            End Set
        End Property

        Private Property _MechChecks As List(Of PrinterMechChecks)
            <DebuggerNonUserCode> _
            Get
                Return Me.__MechChecks
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of PrinterMechChecks))
                Me.__MechChecks = AutoPropertyValue
            End Set
        End Property

        Private Property _PST As PST
            <DebuggerNonUserCode> _
            Get
                Return Me.__PST
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As PST)
                Me.__PST = AutoPropertyValue
            End Set
        End Property

        Public Property TestID As String
            Get
                Return If((Me.PST.TestID = Nothing), Me._TestID, Me.PST.TestID)
            End Get
            Set(ByVal value As String)
                Me._TestID = value
            End Set
        End Property

        Public Property PST As PST
            Get
                Return Me._PST
            End Get
            Set(ByVal value As PST)
                Me._PST = value
            End Set
        End Property


        ' Fields
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __TestID As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __MechChecks As List(Of PrinterMechChecks)
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __PST As PST
    End Class
End Namespace

