Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class SpecFile
        ' Methods
        Public Sub New()
            Me._Tests = New List(Of TestSpecs)
        End Sub


        ' Properties
        Private Property _Tests As List(Of TestSpecs)
            <DebuggerNonUserCode> _
            Get
                Return Me.__Tests
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of TestSpecs))
                Me.__Tests = AutoPropertyValue
            End Set
        End Property

        Public Property Tests As List(Of TestSpecs)
            Get
                Return Me._Tests
            End Get
            Set(ByVal value As List(Of TestSpecs))
                Me._Tests = value
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Tests As List(Of TestSpecs)
    End Class
End Namespace

