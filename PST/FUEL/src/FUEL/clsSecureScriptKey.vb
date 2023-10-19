Imports System

Namespace FUEL
    Public Class clsSecureScriptKey
        Inherits clsSecurePropertyKey
        ' Methods
        Protected Friend Sub New()
        End Sub

        Public Sub New(ByVal Key As String)
            MyBase.New(Key)
        End Sub

    End Class
End Namespace

