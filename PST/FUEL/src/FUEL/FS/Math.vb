Imports System

Namespace FUEL.FS
    Public Class Math
        ' Methods
        Public Shared Function IsCloseTo(ByVal PrimaryVal As Double, ByVal SecondaryVal As Double) As Boolean
            Dim threshold As Double = (PrimaryVal * 0.1)
            Return Math.IsCloseTo(PrimaryVal, SecondaryVal, threshold)
        End Function

        Public Shared Function IsCloseTo(ByVal PrimaryVal As Double, ByVal SecondaryVal As Double, ByVal Threshold As Double) As Boolean
            Return ((Math.Max(PrimaryVal, SecondaryVal) - Math.Min(PrimaryVal, SecondaryVal)) <= Threshold)
        End Function

    End Class
End Namespace

