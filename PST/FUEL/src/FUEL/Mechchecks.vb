Imports FUEL.FS
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO

Namespace FUEL
    Public Class Mechchecks
        Inherits FSDialog
        ' Methods
        Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal Spec As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
            Dim item As New PrinterMechChecks
            item.AddMechCheck(Name, SpecType, Spec, Value, SpecFunction)
            Me._MechChecks.Add(item)
        End Sub

        Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal SpecLow As Double, ByVal SpecHigh As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
            Dim item As New PrinterMechChecks
            item.AddMechCheck(Name, SpecType, SpecLow, SpecHigh, Value, SpecFunction)
            Me._MechChecks.Add(item)
        End Sub

        Public Sub Save(ByVal FileName As String, ByVal Append As Boolean)
            Dim directoryName As String = Path.GetDirectoryName(FileName)
            Dim fileName As String = Path.GetFileName(FileName)
            If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                MyProject.Computer.FileSystem.CreateDirectory(directoryName)
            End If
            Dim body(,) As String(0 To .,0 To .) = New String(((Me.Count - 1) + 1)  - 1, 6  - 1) {}
            Dim num2 As Integer = (Me.Count - 1)
            Dim num As Integer = 0
            Do While True
                Dim num4 As Integer = num2
                If (num > num4) Then
                    Dim header As String() = New String() { "Name", "SpecType", "Spec1", "Spec2", "Value", "Results" }
                    FileProcessing.WriteDelimitedFile(FileName, header, body, ",", Append)
                    Return
                End If
                body(num, 0) = Me._MechChecks(num).Name
                body(num, 1) = Me._MechChecks(num).SpecType.ToString
                body(num, 2) = Me._MechChecks(num).SpecLow.ToString
                body(num, 3) = Me._MechChecks(num).SpecHigh.ToString
                body(num, 4) = Me._MechChecks(num).Value.ToString
                body(num, 5) = Me._MechChecks(num).Results.ToString
                num += 1
            Loop
        End Sub

        Public Sub Show()
            Dim dialog As New frmMechChecks(Me._MechChecks)
            Me.Show(dialog)
        End Sub


        ' Properties
        Public ReadOnly Property Result(ByVal CheckName As String) As Boolean
            Get
                Dim flag As Boolean = False
                Dim num As Integer = 0
                Do While True
                    Dim results As Boolean
                    If (Not flag And (num < Me._MechChecks.Count)) Then
                        If (Me._MechChecks(num).Name.ToLower <> CheckName.ToLower) Then
                            num += 1
                            Continue Do
                        End If
                        flag = True
                        results = Me._MechChecks(num).Results
                    ElseIf flag Then
                        results = False
                    Else
                        Interaction.MsgBox(("The MechCheck name that you specified does not exist" & ChrW(13) & ChrW(10) & "MechCheck Name: " & CheckName), MsgBoxStyle.Critical, Nothing)
                        results = False
                    End If
                    Return results
                Loop
            End Get
        End Property

        Public ReadOnly Property Result(ByVal Index As Integer) As Boolean
            Get
                Dim results As Boolean
                If (Index < Me._MechChecks.Count) Then
                    results = Me._MechChecks(Index).Results
                Else
                    Interaction.MsgBox(("The MechCheck index that you specified does not exist" & ChrW(13) & ChrW(10) & "MechCheck Index: " & Index.ToString), MsgBoxStyle.Critical, Nothing)
                    results = False
                End If
                Return results
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return Me._MechChecks.Count
            End Get
        End Property


        ' Fields
        Private _MechChecks As List(Of PrinterMechChecks) = New List(Of PrinterMechChecks)
    End Class
End Namespace

