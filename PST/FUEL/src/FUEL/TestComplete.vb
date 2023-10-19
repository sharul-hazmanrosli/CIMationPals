Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class TestComplete
        Inherits FSDialog
        ' Methods
        Public Sub New(ByVal Passed As Boolean)
            Me._Passed = Passed
        End Sub

        Public Sub Show()
            Dim dialog As New dlgTestComplete(Conversions.ToBoolean(Me._Passed))
            Me.Show(dialog)
        End Sub


        ' Properties
        Private Property _Passed As Object
            <DebuggerNonUserCode> _
            Get
                Return Me.__Passed
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Object)
                Me.__Passed = AutoPropertyValue
            End Set
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Passed As Object
    End Class
End Namespace

