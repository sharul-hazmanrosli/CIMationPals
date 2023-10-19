Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Deployment.Application
Imports System.Reflection

Namespace FUEL
    <StandardModule> _
    Friend NotInheritable Class modCommonCode
        ' Methods
        Friend Shared Function GetDataPath() As String
            Dim codeBase As String
            If ApplicationDeployment.IsNetworkDeployed Then
                codeBase = ApplicationDeployment.CurrentDeployment.DataDirectory.ToString
            Else
                codeBase = Assembly.GetExecutingAssembly.CodeBase
                codeBase = Strings.Left(codeBase, Strings.InStrRev(codeBase, "/", -1, CompareMethod.Binary))
                codeBase = Strings.Right(codeBase, ((Strings.Len(codeBase) - Strings.InStr(codeBase, "///", CompareMethod.Binary)) - 2)).Replace("/", "\")
            End If
            Return If(Not codeBase.EndsWith("\"), (codeBase & "\"), codeBase)
        End Function

    End Class
End Namespace

