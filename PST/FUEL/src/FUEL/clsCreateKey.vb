Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace FUEL
    Friend Class clsCreateKey
        ' Methods
        Public Shared Function GeneratePropertyKey(ByVal DateToExpire As DateTime) As String
            Return New Simple3Des("Overlanding123").EncryptData(Conversions.ToString(CDbl((Conversions.ToDouble(Conversions.ToString(DateToExpire.Ticks)) * 3.1415926535897931))))
        End Function

        Public Shared Function GenerateScriptKey(ByVal DateToExpire As DateTime) As String
            Return clsCreateKey.GeneratePropertyKey(DateToExpire)
        End Function

    End Class
End Namespace

