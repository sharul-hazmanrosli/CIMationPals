Imports FUEL
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL.BigRed
    Public Class TestSuite
        ' Methods
        Public Sub New()
            Me.TemplateRev = 0
            Me.Variables = New TestVariables
        End Sub

        Private Function LoadInstructions(ByVal arrInstructions As Object(0 To .,0 To .)) As String(0 To .,0 To .)
            Dim num2 As Integer = 0
            Dim num7 As Integer = Information.UBound(arrInstructions, 1)
            Dim num3 As Integer = 1
            Do While True
                Dim flag As Boolean
                Dim num11 As Integer = num7
                If (num3 <= num11) Then
                    flag = Operators.ConditionalCompareObjectEqual(arrInstructions(num3, 1), Nothing, False)
                    If Not flag Then
                        num3 += 1
                        Continue Do
                    End If
                    num2 = (num3 - 1)
                End If
                Dim num As Integer = 0
                Dim num8 As Integer = Information.UBound(arrInstructions, 2)
                Dim num4 As Integer = 1
                Do While True
                    num11 = num8
                    If (num4 > num11) Then
                        Dim strArray2(,) As String(0 To .,0 To .) = New String(((num2 - 2) + 1)  - 1, ((num - 1) + 1)  - 1) {}
                        Dim num9 As Integer = num2
                        Dim num5 As Integer = 2
                        Do While (num5 <= num9)
                            Dim num10 As Integer = num
                            Dim num6 As Integer = 1
                            Do While True
                                num11 = num10
                                If (num6 > num11) Then
                                    num5 += 1
                                    Exit Do
                                End If
                                flag = Operators.ConditionalCompareObjectEqual(arrInstructions(num5, num6), Nothing, False)
                                strArray2((num5 - 2), (num6 - 1)) = If(Not flag, Conversions.ToString(arrInstructions(num5, num6)), "")
                                num6 += 1
                            Loop
                        Loop
                        Return strArray2
                    End If
                    If Operators.ConditionalCompareObjectNotEqual(arrInstructions(1, num4), Nothing, False) Then
                        num = num4
                    End If
                    num4 += 1
                Loop
            Loop
        End Function

        Public Sub LoadNativeSuite(ByVal Path As String)
            Dim wB As Workbook = ExcelHandler.LoadExcel(Path)
            Dim arguments As Object() = New Object() { "Revision Number" }
            Me.TemplateRev = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(wB.get_BuiltinDocumentProperties, arguments, Nothing), Nothing, "value", New Object(0  - 1) {}, Nothing, Nothing, Nothing))
            Dim arrVariables(,) As Object(0 To .,0 To .) = ExcelHandler.ReadSheet(wB, 1)
            Dim arrInstructions(,) As Object(0 To .,0 To .) = ExcelHandler.ReadSheet(wB, 2)
            ExcelHandler.CloseWB(wB)
            Me.Variables = Me.LoadVariables(arrVariables)
            Me.Instructions = Me.LoadInstructions(arrInstructions)
        End Sub

        Private Function LoadVariables(ByVal arrVariables As Object(0 To .,0 To .)) As TestVariables
            Return New TestVariables With { _
                .AutoDataOnSchedule = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Run AutoData on a schedule?")), _
                .PassiveAutoData = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Use Passive AutoData?")), _
                .UploadDataToGradeBook = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Upload data to GradeBook?")), _
                .TestRunningOutsideOfHPFireWall = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Test running outside of HP Firewall?")), _
                .CollectDataForEveryPrintJob = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Collect data for every print job?")), _
                .SendDataViaEmail = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Send data via email?")), _
                .EmailAddress = Me.Variables_Set(arrVariables, "To whom do you want email sent?"), _
                .MessagePriority = Conversions.ToInteger(Me.Variables_Set(arrVariables, "Messaging Priority")), _
                .ReplacePgNrWithPlotCD = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Replace Page Nr with PLOT_CD?")), _
                .PrintProtocol = Me.Variables_Set(arrVariables, "Select Print Protocols"), _
                .AutomaticeLIDILMode = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Automatic eLIDIL Mode")), _
                .PCLFileLocation = Me.Variables_Set(arrVariables, "PCL Location"), _
                .NozzlePatternLocation = Me.Variables_Set(arrVariables, "Nozzle Pattern Locations"), _
                .AddCRLFToHeaders = Conversions.ToBoolean(Me.Variables_Set(arrVariables, "Auto add Carriage Return to Header?")), _
                .FooterData = Me.Variables_DataCollections(arrVariables, "Footer Data"), _
                .GradeBookData = Me.Variables_DataCollections(arrVariables, "GradeBook Data") _
            }
        End Function

        Private Function Variables_DataCollections(ByVal arr As Object(0 To .,0 To .), ByVal LookinFor As String) As String()
            Dim flag As Boolean = False
            Dim num2 As Integer = 0
            Dim num6 As Integer = Information.UBound(arr, 1)
            Dim num3 As Integer = 1
            Do While True
                Dim strArray2 As String()
                Dim num9 As Integer = num6
                If (num3 <= num9) Then
                    Dim flag2 As Boolean = Operators.ConditionalCompareObjectNotEqual(arr(num3, 1), Nothing, False)
                    If (Not flag2 OrElse Not Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(arr(num3, 1), Nothing, "trim", New Object(0  - 1) {}, Nothing, Nothing, Nothing), Nothing, "tolower", New Object(0  - 1) {}, Nothing, Nothing, Nothing), LookinFor.Trim.ToLower, False)) Then
                        num3 += 1
                        Continue Do
                    End If
                    num2 = num3
                    flag = True
                End If
                If Not flag Then
                    strArray2 = Nothing
                Else
                    Dim num As Integer = 0
                    Dim num7 As Integer = Information.UBound(arr, 2)
                    Dim num4 As Integer = 1
                    Do While True
                        num9 = num7
                        If (num4 <= num9) Then
                            If Not Operators.ConditionalCompareObjectEqual(arr(num2, num4), Nothing, False) Then
                                num4 += 1
                                Continue Do
                            End If
                            num = (num4 - 1)
                        End If
                        Dim strArray As String() = New String(((num - 3) + 1)  - 1) {}
                        Dim num8 As Integer = num
                        Dim num5 As Integer = 3
                        Do While True
                            num9 = num8
                            If (num5 > num9) Then
                                strArray2 = strArray
                                Exit Do
                            End If
                            strArray((num5 - 3)) = Conversions.ToString(arr(num2, num5))
                            num5 += 1
                        Loop
                        Exit Do
                    Loop
                End If
                Return strArray2
            Loop
        End Function

        Private Function Variables_Set(ByVal arr As Object(0 To .,0 To .), ByVal LookinFor As String) As String
            Dim num2 As Integer = Information.UBound(arr, 1)
            Dim num As Integer = 1
            Do While True
                Dim str2 As String
                Dim num3 As Integer = num2
                If (num > num3) Then
                    Interaction.MsgBox(("Error: Unable to find '" & LookinFor & "' in test variables."), MsgBoxStyle.Critical, "Cant Find Test Variable")
                    str2 = Conversions.ToString(0)
                Else
                    Dim flag As Boolean = Operators.ConditionalCompareObjectNotEqual(arr(num, 1), Nothing, False)
                    If (Not flag OrElse Not Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(arr(num, 1), Nothing, "trim", New Object(0  - 1) {}, Nothing, Nothing, Nothing), Nothing, "tolower", New Object(0  - 1) {}, Nothing, Nothing, Nothing), LookinFor.Trim.ToLower, False)) Then
                        num += 1
                        Continue Do
                    End If
                    str2 = Conversions.ToString(arr(num, 2))
                End If
                Return str2
            Loop
        End Function


        ' Properties
        Public Property TemplateRev As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me._TemplateRev
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me._TemplateRev = AutoPropertyValue
            End Set
        End Property

        Public Property Variables As TestVariables
            <DebuggerNonUserCode> _
            Get
                Return Me._Variables
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestVariables)
                Me._Variables = AutoPropertyValue
            End Set
        End Property

        Public Property Instructions As String(0 To .,0 To .)
            <DebuggerNonUserCode> _
            Get
                Return Me._Instructions
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String(0 To .,0 To .))
                Me._Instructions = AutoPropertyValue
            End Set
        End Property


        ' Fields
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _TemplateRev As Integer
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _Variables As TestVariables
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _Instructions As String(0 To .,0 To .)
    End Class
End Namespace

