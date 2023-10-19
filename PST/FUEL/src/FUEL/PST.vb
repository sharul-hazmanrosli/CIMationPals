Imports FUEL.FS
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization

Namespace FUEL
    <Serializable> _
    Public Class PST
        ' Methods
        Protected Sub New()
            Me._BlackPressureOverRide = 1
            Me._ColorPressureOverRide = 1
            Me._MechChecks = New List(Of PrinterMechChecks)
            Me._TestStatus = True
            Me._OverallTestStatus = True
            Me._RetestForVentDP = False
            Me.PrinterInfo = New PrinterInformation
            Me.TestInfo = New TestInformation
            Me.SpecsBlack = New Specifications(Channel.Black)
            Me.SpecsColor = New Specifications(Channel.Color)
            Me.KDataPoints = New Points
            Me.CDataPoints = New Points
            Me.KResults = New Results
            Me.CResults = New Results
        End Sub

        Public Sub New(ByVal TestStationType As TestStationTypes, ByVal Serial As String, ByVal FW As String, ByVal PgCnt As Long, ByVal ScriptRev As String, ByVal ScriptProduct As String, ByVal SaveFileLocation As String, ByVal BlackArrayX As Double(), ByVal BlackArrayY As Double(), ByVal ColorArrayX As Double(), ByVal ColorArrayY As Double())
            Me.New(TestStationType, Serial, FW, PgCnt, ScriptRev, ScriptProduct, Strings.FormatDateTime(DateAndTime.Now, DateFormat.ShortDate), Strings.FormatDateTime(DateAndTime.Now, DateFormat.LongTime), SaveFileLocation, BlackArrayX, BlackArrayY, ColorArrayX, ColorArrayY, Nothing)
        End Sub

        Public Sub New(ByVal TestStationType As TestStationTypes, ByVal Serial As String, ByVal FW As String, ByVal PgCnt As Long, ByVal ScriptRev As String, ByVal ScriptProduct As String, ByVal TestDate As String, ByVal TestTime As String, ByVal SaveFileLocation As String, ByVal BlackArrayX As Double(), ByVal BlackArrayY As Double(), ByVal ColorArrayX As Double(), ByVal ColorArrayY As Double(), ByVal TestID As String)
            Me._BlackPressureOverRide = 1
            Me._ColorPressureOverRide = 1
            Me._MechChecks = New List(Of PrinterMechChecks)
            Me._TestStatus = True
            Me._OverallTestStatus = True
            Me._RetestForVentDP = False
            Me.PrinterInfo = New PrinterInformation
            Me.TestInfo = New TestInformation
            Me.SpecsBlack = New Specifications(Channel.Black)
            Me.SpecsColor = New Specifications(Channel.Color)
            Me.KDataPoints = New Points
            Me.CDataPoints = New Points
            Me.KResults = New Results
            Me.CResults = New Results
            Logging.AddLogEntry(Me, "New PST: PST Instantiated", EventLogEntryType.Information, 3)
            Try 
                Me._TestID = If((TestID <> Nothing), TestID, Me.GetTestID)
                Me.PrinterInfo.SerialNum = Serial
                Me.PrinterInfo.FWRev = FW
                Me.PrinterInfo.EnginePgCnt = PgCnt
                Logging.AddLogEntry(Me, "New PST: PrinterInfo Set", EventLogEntryType.Information, 4)
                Me.TestInfo.ScriptRev = ScriptRev
                Me.TestInfo.ScriptProduct = ScriptProduct
                Me.TestInfo.TestDate = TestDate
                Me.TestInfo.TestTime = TestTime
                Me.TestInfo.UploadsEnabled = False
                Me.TestInfo.TestStationType = TestStationType
                Logging.AddLogEntry(Me, "New PST: TestInfo Set", EventLogEntryType.Information, 4)
                Me.SaveFileLocation = SaveFileLocation
                Me.OutputFileName = SaveFileLocation
                Me.SummaryFileName = SaveFileLocation
                Me.SpecFileName = SaveFileLocation
                Logging.AddLogEntry(Me, "New PST: Output Files Set", EventLogEntryType.Information, 4)
                Me.PTraceBlack = Me.ProcessTraceData(BlackArrayX, BlackArrayY)
                Logging.AddLogEntry(Me, "New PST: ProcessTraceData Black Complete", EventLogEntryType.Information, 4)
                Me.PTraceColor = Me.ProcessTraceData(ColorArrayX, ColorArrayY)
                Logging.AddLogEntry(Me, "New PST: ProcessTraceData Color Complete", EventLogEntryType.Information, 4)
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Logging.AddLogEntry(Me, ("New: Error instantiating PST class: " & exception.ToString), EventLogEntryType.Error, 0)
                Interaction.MsgBox(("Error instantiating PST class." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & exception.ToString), MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal Spec As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
            If Not Me.VerifyUniqueMechCheck(Name) Then
                Interaction.MsgBox(("Duplicate Mech Check name, ignoring and moving on" & ChrW(13) & ChrW(10) & "Check Name: " & Name), MsgBoxStyle.ApplicationModal, Nothing)
            Else
                Dim item As New PrinterMechChecks
                item.AddMechCheck(Name, SpecType, Spec, Value, SpecFunction)
                Me._MechChecks.Add(item)
            End If
        End Sub

        Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal SpecLow As Double, ByVal SpecHigh As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
            If Not Me.VerifyUniqueMechCheck(Name) Then
                Interaction.MsgBox(("Duplicate Mech Check name, ignoring and moving on" & ChrW(13) & ChrW(10) & "Check Name: " & Name), MsgBoxStyle.ApplicationModal, Nothing)
            Else
                Dim item As New PrinterMechChecks
                item.AddMechCheck(Name, SpecType, SpecLow, SpecHigh, Value, SpecFunction)
                Me._MechChecks.Add(item)
            End If
        End Sub

        Public Sub AnalyzeResults(ByVal BlackInstallPressure As Double, ByVal ColorInstallPressure As Double)
            Me.AnalyzeResults(BlackInstallPressure, ColorInstallPressure, True)
        End Sub

        Public Sub AnalyzeResults(ByVal BlackInstallPressure As Double, ByVal ColorInstallPressure As Double, ByVal LogResults As Boolean)
            Try 
                Dim flag3 As Boolean
                Me._BlackInstallPressure = BlackInstallPressure
                Me._ColorInstallPressure = ColorInstallPressure
                Me.KDataPoints.SetCriticalPoints(Me.PTraceBlack, Me.SpecsBlack)
                Me.CDataPoints.SetCriticalPoints(Me.PTraceColor, Me.SpecsColor)
                Dim specsBlack As Specifications = Me.SpecsBlack
                Me.KResults.AnalyzeResults(Me.KDataPoints, specsBlack, Me._BlackInstallPressure)
                Me.SpecsBlack = specsBlack
                specsBlack = Me.SpecsColor
                Me.CResults.AnalyzeResults(Me.CDataPoints, specsBlack, Me._ColorInstallPressure)
                Me.SpecsColor = specsBlack
                Dim flag As Boolean = True
                Using enumerator As Enumerator(Of PrinterMechChecks) = Me.MechChecks.GetEnumerator
                    Do While True
                        flag3 = enumerator.MoveNext
                        If flag3 Then
                            Dim current As PrinterMechChecks = enumerator.Current
                            flag3 = (Not current.Results And (current.SpecFunction = SpecFunction.PassFail))
                            If Not flag3 Then
                                Continue Do
                            End If
                            flag = False
                        End If
                        Exit Do
                    Loop
                End Using
                If Not flag Then
                    Me.KResults.VentDP_RetestRequired = False
                    Me.CResults.VentDP_RetestRequired = False
                    Me.KResults.TubeEvacDP_RetestRequired = False
                    Me.CResults.TubeEvacDP_RetestRequired = False
                End If
                If ((Not flag Or Not Me.KResults.PF.OverallPSTResults) Or Not Me.CResults.PF.OverallPSTResults) Then
                    Me._OverallTestStatus = False
                End If
                flag3 = LogResults
                If flag3 Then
                    Dim addFailuretoFailSummary As Boolean = False
                    flag3 = (Not Me.KResults.PF.OverallPSTResults Or Not Me.CResults.PF.OverallPSTResults)
                    If flag3 Then
                        addFailuretoFailSummary = True
                    End If
                    Dim log As New PSTLog(Me, Me.OutputFileName, Me.SummaryFileName, Me.SpecFileName, addFailuretoFailSummary)
                    Me.TestInfo.RunNumber = log.RunNumber
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Logging.AddLogEntry(Me, ("AnalyzeResults: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                Interaction.MsgBox(("Error Analyzing Results." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & exception.ToString), MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
            If Me.TestInfo.UploadsEnabled Then
                Dim upload As New FileUpload(Path.GetDirectoryName(Me.OutputFileName), Me.TestInfo.UploadInterval)
            Else
                Logging.AddLogEntry(Me, "AnalyzeResults: uploads are disabled", EventLogEntryType.Information, 3)
            End If
        End Sub

        Public Shared Function getOwner() As IntPtr
            Dim ptr As IntPtr
            Try 
                Dim processesByName As Process() = Process.GetProcessesByName("FlexScript")
                ptr = If((processesByName.Length = 0), DirectCast(-1, IntPtr), processesByName(0).MainWindowHandle)
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                ptr = DirectCast(-1, IntPtr)
                ProjectData.ClearProjectError
            End Try
            Return ptr
        End Function

        Private Function GetTestID() As String
            Return (Conversions.ToString(DateAndTime.Now.Ticks) & "a")
        End Function

        Public Function ProcessTraceData(ByVal arrX As Double(), ByVal arrY As Double()) As List(Of TraceData)
            Dim list As List(Of TraceData)
            If ((arrX.Length < 2) Or (arrY.Length < 2)) Then
                Throw New ApplicationException("Data set is empty, cannot continue.")
            End If
            Try 
                Dim array As Double() = New Double(((Information.UBound(arrX, 1) - 2) + 1)  - 1) {}
                Dim num5 As Integer = (Information.UBound(arrX, 1) - 1)
                Dim index As Integer = 1
                Do While True
                    Dim num9 As Integer = num5
                    If (index > num9) Then
                        Dim numArray As Double() = New Double(((Information.UBound(array, 1) - 2) + 1)  - 1) {}
                        Dim num6 As Integer = (Information.UBound(array, 1) - 1)
                        Dim num2 As Integer = 1
                        Do While True
                            num9 = num6
                            If (num2 > num9) Then
                                Dim numArray2 As Double() = New Double(((Information.UBound(numArray, 1) - 2) + 1)  - 1) {}
                                Dim num7 As Integer = (Information.UBound(numArray, 1) - 1)
                                Dim num3 As Integer = 1
                                Do While True
                                    num9 = num7
                                    If (num3 > num9) Then
                                        Dim list2 As New List(Of TraceData)
                                        Dim num8 As Integer = Information.UBound(arrX, 1)
                                        Dim num4 As Integer = 0
                                        Do While True
                                            num9 = num8
                                            If (num4 > num9) Then
                                                Dim numArray4(,) As Double(0 To .,0 To .) = New Double((arrY.Length + 1)  - 1, 5  - 1) {}
                                                list = list2
                                                Exit Do
                                            End If
                                            Dim item As New TraceData With { _
                                                .X = arrX(num4), _
                                                .Y = arrY(num4) _
                                            }
                                            If ((num4 >= 1) And (num4 <= Information.UBound(array, 1))) Then
                                                item.SlidingAVG = array((num4 - 1))
                                            End If
                                            If ((num4 >= 2) And (num4 <= Information.UBound(numArray, 1))) Then
                                                item.DxDt = numArray((num4 - 2))
                                            End If
                                            If ((num4 >= 3) And (num4 <= Information.UBound(numArray2, 1))) Then
                                                item.DxDt2 = numArray2((num4 - 3))
                                            End If
                                            list2.Add(item)
                                            num4 += 1
                                        Loop
                                        Exit Do
                                    End If
                                    numArray2((num3 - 1)) = ((numArray((num3 + 1)) - numArray((num3 - 1))) / (2 * (arrX((num3 + 1)) - arrX(num3))))
                                    num3 += 1
                                Loop
                                Exit Do
                            End If
                            numArray((num2 - 1)) = ((array((num2 + 1)) - array((num2 - 1))) / (2 * (arrX((num2 + 1)) - arrX(num2))))
                            num2 += 1
                        Loop
                        Exit Do
                    End If
                    Dim numArray5 As Double() = New Double() { arrY((index - 1)), arrY(index), arrY((index + 1)) }
                    array((index - 1)) = (((numArray5(0) + numArray5(1)) + numArray5(2)) / 3)
                    index += 1
                Loop
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                Logging.AddLogEntry(Me, ("ProcessTraceData: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                Throw New Exception(exception.Message, exception.InnerException)
            End Try
            Return list
        End Function

        Friend Sub SavePointData(ByVal Channel As Channel)
            Dim textToWrite As String = "TestID,PrinterSerialNum,Date,Time,OverAllTestStatus,PT1X,PT1Y,PT2X,PT2Y,PT3X,PT3Y,PT4X,PT4Y,PT5X,PT5Y,PT6X,PT6Y,PT7X,PT7Y,PT8X,PT8Y,DERIVCNT,HoldTime,PumpTime,PressureBuildDelay" & ChrW(13) & ChrW(10)
            Dim strArray As String() = New String() { Me.TestID.ToString, ",", Me.PrinterInfo.SerialNum, ",", Me.TestInfo.TestDate, ",", Me.TestInfo.TestTime, ",", Conversions.ToString(Me.OverallTestStatus) }
            strArray(9) = ","
            Dim str2 As String = String.Concat(strArray)
            Dim str As String = Nothing
            If (Channel = Channel.Black) Then
                strArray = New String() { str2, Me.KDataPoints.PT1X.ToString, ",", Me.KDataPoints.PT1Y.ToString, ",", Me.KDataPoints.PT2X.ToString, ",", Me.KDataPoints.PT2Y.ToString, "," }
                strArray(9) = Me.KDataPoints.PT3X.ToString
                strArray(10) = ","
                strArray(11) = Me.KDataPoints.PT3Y.ToString
                strArray(12) = ","
                strArray(13) = Me.KDataPoints.PT4X.ToString
                strArray(14) = ","
                strArray(15) = Me.KDataPoints.PT4Y.ToString
                strArray(&H10) = ","
                strArray(&H11) = Me.KDataPoints.PT5X.ToString
                strArray(&H12) = ","
                strArray(&H13) = Me.KDataPoints.PT5Y.ToString
                strArray(20) = ","
                strArray(&H15) = Me.KDataPoints.PT6X.ToString
                strArray(&H16) = ","
                strArray(&H17) = Me.KDataPoints.PT6Y.ToString
                strArray(&H18) = ","
                strArray(&H19) = Me.KDataPoints.PT7X.ToString
                strArray(&H1A) = ","
                strArray(&H1B) = Me.KDataPoints.PT7Y.ToString
                strArray(&H1C) = ","
                strArray(&H1D) = Me.KDataPoints.PT8X.ToString
                strArray(30) = ","
                strArray(&H1F) = Me.KDataPoints.PT8Y.ToString
                strArray(&H20) = ","
                strArray(&H21) = Conversions.ToString(Me.KDataPoints.DerivCnt)
                strArray(&H22) = ","
                strArray(&H23) = Me.SpecsBlack.HoldTime.ToString
                strArray(&H24) = ","
                strArray(&H25) = Me.SpecsBlack.PumpTime.ToString
                strArray(&H26) = ","
                strArray(&H27) = Conversions.ToString(CDbl((((Me.KDataPoints.PT3X - Me.KDataPoints.PT1X) - Me.SpecsBlack.HoldTime) - Me.SpecsBlack.PumpTime)))
                strArray(40) = ChrW(13) & ChrW(10)
                str2 = String.Concat(strArray)
                str = "KDataPoints.csv"
            ElseIf (Channel = Channel.Color) Then
                strArray = New String() { str2, Me.CDataPoints.PT1X.ToString, ",", Me.CDataPoints.PT1Y.ToString, ",", Me.CDataPoints.PT2X.ToString, ",", Me.CDataPoints.PT2Y.ToString, "," }
                strArray(9) = Me.CDataPoints.PT3X.ToString
                strArray(10) = ","
                strArray(11) = Me.CDataPoints.PT3Y.ToString
                strArray(12) = ","
                strArray(13) = Me.CDataPoints.PT4X.ToString
                strArray(14) = ","
                strArray(15) = Me.CDataPoints.PT4Y.ToString
                strArray(&H10) = ","
                strArray(&H11) = Me.CDataPoints.PT5X.ToString
                strArray(&H12) = ","
                strArray(&H13) = Me.CDataPoints.PT5Y.ToString
                strArray(20) = ","
                strArray(&H15) = Me.CDataPoints.PT6X.ToString
                strArray(&H16) = ","
                strArray(&H17) = Me.CDataPoints.PT6Y.ToString
                strArray(&H18) = ","
                strArray(&H19) = Me.CDataPoints.PT7X.ToString
                strArray(&H1A) = ","
                strArray(&H1B) = Me.CDataPoints.PT7Y.ToString
                strArray(&H1C) = ","
                strArray(&H1D) = Me.CDataPoints.PT8X.ToString
                strArray(30) = ","
                strArray(&H1F) = Me.CDataPoints.PT8Y.ToString
                strArray(&H20) = ","
                strArray(&H21) = Conversions.ToString(Me.CDataPoints.DerivCnt)
                strArray(&H22) = ","
                strArray(&H23) = Me.SpecsColor.HoldTime.ToString
                strArray(&H24) = ","
                strArray(&H25) = Me.SpecsColor.PumpTime.ToString
                strArray(&H26) = ","
                strArray(&H27) = Conversions.ToString(CDbl((((Me.CDataPoints.PT3X - Me.CDataPoints.PT1X) - Me.SpecsColor.HoldTime) - Me.SpecsColor.PumpTime)))
                strArray(40) = ChrW(13) & ChrW(10)
                str2 = String.Concat(strArray)
                str = "CDataPoints.csv"
            End If
            str = Path.Combine(Me.SaveFileLocation, str)
            If Not MyProject.Computer.FileSystem.FileExists(str) Then
                FileProcessing.WriteToFile(str, textToWrite, True)
            End If
            FileProcessing.WriteToFile(str, str2, True)
        End Sub

        Public Sub ShowResults()
            Logging.AddLogEntry(Me, "ShowResults: Starting", EventLogEntryType.Information, 3)
            Dim results As New dlgPSTResults(Me)
            Dim aHandle As IntPtr = PST.getOwner
            If (aHandle <> DirectCast(-1, IntPtr)) Then
                results.ShowDialog(New WindowWrapper(aHandle))
            Else
                results.ShowDialog
            End If
            Logging.AddLogEntry(Me, "ShowResults: Complete", EventLogEntryType.Information, 3)
        End Sub

        Private Function VerifyUniqueMechCheck(ByVal Name As String) As Boolean
            Using enumerator As Enumerator(Of PrinterMechChecks) = Me._MechChecks.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As PrinterMechChecks = enumerator.Current
                    If (current.Name.ToLower = Name) Then
                        Return False
                    End If
                Loop
            End Using
            Return True
        End Function


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

        Private Property _PTraceBlack As List(Of TraceData)
            <DebuggerNonUserCode> _
            Get
                Return Me.__PTraceBlack
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of TraceData))
                Me.__PTraceBlack = AutoPropertyValue
            End Set
        End Property

        Private Property _PTraceColor As List(Of TraceData)
            <DebuggerNonUserCode> _
            Get
                Return Me.__PTraceColor
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As List(Of TraceData))
                Me.__PTraceColor = AutoPropertyValue
            End Set
        End Property

        Private Property _SaveFileLocation As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SaveFileLocation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SaveFileLocation = AutoPropertyValue
            End Set
        End Property

        Private Property _OutputFileName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__OutputFileName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__OutputFileName = AutoPropertyValue
            End Set
        End Property

        Private Property _SummaryFileName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SummaryFileName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SummaryFileName = AutoPropertyValue
            End Set
        End Property

        Private Property _SpecFileName As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__SpecFileName
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__SpecFileName = AutoPropertyValue
            End Set
        End Property

        Private Property _BlackPressureOverRide As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__BlackPressureOverRide
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__BlackPressureOverRide = AutoPropertyValue
            End Set
        End Property

        Private Property _ColorPressureOverRide As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__ColorPressureOverRide
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__ColorPressureOverRide = AutoPropertyValue
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

        Private Property _BlackInstallPressure As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__BlackInstallPressure
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__BlackInstallPressure = AutoPropertyValue
            End Set
        End Property

        Private Property _ColorInstallPressure As Double
            <DebuggerNonUserCode> _
            Get
                Return Me.__ColorInstallPressure
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Double)
                Me.__ColorInstallPressure = AutoPropertyValue
            End Set
        End Property

        Private Property _TestStatus As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__TestStatus
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__TestStatus = AutoPropertyValue
            End Set
        End Property

        Private Property _OverallTestStatus As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__OverallTestStatus
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__OverallTestStatus = AutoPropertyValue
            End Set
        End Property

        Private Property _RetestForVentDP As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__RetestForVentDP
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__RetestForVentDP = AutoPropertyValue
            End Set
        End Property

        Public Property RetestForVentDP As Boolean
            Get
                Return Me._RetestForVentDP
            End Get
            Set(ByVal value As Boolean)
                Me._RetestForVentDP = value
            End Set
        End Property

        Private Property _PreviousTestID As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__PreviousTestID
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__PreviousTestID = AutoPropertyValue
            End Set
        End Property

        Public Property PreviousTestID As String
            Get
                Return Me._PreviousTestID
            End Get
            Set(ByVal value As String)
                Me._PreviousTestID = value
            End Set
        End Property

        <XmlIgnore> _
        Public Property PrinterInfo As PrinterInformation
            <DebuggerNonUserCode> _
            Get
                Return Me._PrinterInfo
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As PrinterInformation)
                Me._PrinterInfo = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public Property TestInfo As TestInformation
            <DebuggerNonUserCode> _
            Get
                Return Me._TestInfo
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestInformation)
                Me._TestInfo = AutoPropertyValue
            End Set
        End Property

        Public Property SpecsBlack As Specifications
            <DebuggerNonUserCode> _
            Get
                Return Me._SpecsBlack
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Specifications)
                Me._SpecsBlack = AutoPropertyValue
            End Set
        End Property

        Public Property SpecsColor As Specifications
            <DebuggerNonUserCode> _
            Get
                Return Me._SpecsColor
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Specifications)
                Me._SpecsColor = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public Property KDataPoints As Points
            <DebuggerNonUserCode> _
            Get
                Return Me._KDataPoints
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Points)
                Me._KDataPoints = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public Property CDataPoints As Points
            <DebuggerNonUserCode> _
            Get
                Return Me._CDataPoints
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Points)
                Me._CDataPoints = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public Property KResults As Results
            <DebuggerNonUserCode> _
            Get
                Return Me._KResults
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Results)
                Me._KResults = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public Property CResults As Results
            <DebuggerNonUserCode> _
            Get
                Return Me._CResults
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Results)
                Me._CResults = AutoPropertyValue
            End Set
        End Property

        <XmlIgnore> _
        Public ReadOnly Property BlackInstallPressure As Object
            Get
                Return Me._BlackInstallPressure
            End Get
        End Property

        <XmlIgnore> _
        Public ReadOnly Property ColorInstallPressure As Object
            Get
                Return Me._ColorInstallPressure
            End Get
        End Property

        <XmlIgnore> _
        Public ReadOnly Property OverallTestStatus As Boolean
            Get
                Return Me._OverallTestStatus
            End Get
        End Property

        Public ReadOnly Property MechChecks As List(Of PrinterMechChecks)
            Get
                Return Me._MechChecks
            End Get
        End Property

        Public Property SaveFileLocation As String
            Get
                Return Me._SaveFileLocation
            End Get
            Set(ByVal value As String)
                If (value = Nothing) Then
                    Throw New ArgumentException("You must specify a path. You gave me nothing to work with", value)
                End If
                Me._SaveFileLocation = value
            End Set
        End Property

        Public ReadOnly Property TestID As String
            Get
                Return Me._TestID
            End Get
        End Property

        <XmlIgnore> _
        Public Property PTraceBlack As List(Of TraceData)
            Get
                Return Me._PTraceBlack
            End Get
            Set(ByVal value As List(Of TraceData))
                Me._PTraceBlack = value
            End Set
        End Property

        <XmlIgnore> _
        Public Property PTraceColor As List(Of TraceData)
            Get
                Return Me._PTraceColor
            End Get
            Set(ByVal value As List(Of TraceData))
                Me._PTraceColor = value
            End Set
        End Property

        Public Property TestStatus As Boolean
            Get
                Return Me._TestStatus
            End Get
            Set(ByVal value As Boolean)
                If (Me._TestStatus And Not value) Then
                    Me._TestStatus = value
                End If
            End Set
        End Property

        Friend Property OutputFileName As String
            Get
                Return Me._OutputFileName
            End Get
            Set(ByVal value As String)
                If (value = Nothing) Then
                    Logging.AddLogEntry(Me, "OutputFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0)
                    Throw New ArgumentException("You must specify a path. You gave me nothing to work with", value)
                End If
                If Not value.EndsWith("\") Then
                    value = (value & "\")
                End If
                Dim directoryName As String = Path.GetDirectoryName(value)
                Try 
                    If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                        MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                    End If
                    Dim str3 As String = Path.Combine(directoryName, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(("PST_" & Me.TestInfo.ScriptProduct & "_"), Misc.GetComputerName(True)), "_"), DateAndTime.Now.Month), "-"), DateAndTime.Now.Day), "-"), DateAndTime.Now.Year), "_"), Me.TestInfo.TestStationType.ToString), ".csv")))
                    Me._OutputFileName = str3
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Dim message As String = ("Unable to create folder for output file." & ChrW(13) & ChrW(10) & "Path: " & directoryName)
                    Logging.AddLogEntry(Me, ("OutputFileName: Error: " & message), EventLogEntryType.Error, 0)
                    Throw New ApplicationException(message)
                End Try
            End Set
        End Property

        Friend Property SummaryFileName As String
            Get
                Return Me._SummaryFileName
            End Get
            Set(ByVal value As String)
                If (value = Nothing) Then
                    Logging.AddLogEntry(Me, "SummaryFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0)
                    Throw New ArgumentException("You must specify a path. You gave me nothing to work with", value)
                End If
                If Not value.EndsWith("\") Then
                    value = (value & "\")
                End If
                Dim directoryName As String = Path.GetDirectoryName(value)
                Try 
                    If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                        MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                    End If
                    Dim str3 As String = Path.Combine(directoryName, ("PSTSummary_" & Me._MonthlyFileName_Suffix & ".csv"))
                    Me._SummaryFileName = str3
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Logging.AddLogEntry(Me, ("SummaryFileName: Error: " & ("Unable to create folder for output file." & ChrW(13) & ChrW(10) & "Path: " & directoryName)), EventLogEntryType.Error, 0)
                    Throw New ApplicationException
                End Try
            End Set
        End Property

        Friend Property SpecFileName As String
            Get
                Return Me._SpecFileName
            End Get
            Set(ByVal value As String)
                If (value = Nothing) Then
                    Logging.AddLogEntry(Me, "SpecFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0)
                    Throw New ArgumentException("You must specify a path. You gave me nothing to work with", value)
                End If
                If Not value.EndsWith("\") Then
                    value = (value & "\")
                End If
                Dim directoryName As String = Path.GetDirectoryName(value)
                Try 
                    If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                        MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                    End If
                    Dim str3 As String = Path.Combine(directoryName, ("PSTSpecs_" & Me._MonthlyFileName_Suffix & ".xml"))
                    Me._SpecFileName = str3
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Logging.AddLogEntry(Me, ("SpecFileName: Error: " & ("Unable to create folder for output file." & ChrW(13) & ChrW(10) & "Path: " & directoryName)), EventLogEntryType.Error, 0)
                    Throw New ApplicationException
                End Try
            End Set
        End Property

        Private ReadOnly Property _MonthlyFileName_Suffix As String
            Get
                Return Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((Me.TestInfo.ScriptProduct & "_"), Misc.GetComputerName(True)), "_"), DateAndTime.Now.Month), "-"), DateAndTime.Now.Year), "_"), Me.TestInfo.TestStationType.ToString))
            End Get
        End Property


        ' Fields
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __TestID As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __PTraceBlack As List(Of TraceData)
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __PTraceColor As List(Of TraceData)
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __SaveFileLocation As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __OutputFileName As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __SummaryFileName As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __SpecFileName As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __BlackPressureOverRide As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __ColorPressureOverRide As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __MechChecks As List(Of PrinterMechChecks)
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __BlackInstallPressure As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __ColorInstallPressure As Double
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __TestStatus As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __OverallTestStatus As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __RetestForVentDP As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __PreviousTestID As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _PrinterInfo As PrinterInformation
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _TestInfo As TestInformation
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _SpecsBlack As Specifications
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _SpecsColor As Specifications
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _KDataPoints As Points
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _CDataPoints As Points
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _KResults As Results
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _CResults As Results

        ' Nested Types
        Public Enum Channel
            ' Fields
            Unknown = 0
            Black = 1
            Color = 2
        End Enum

        Public Class Points
            ' Methods
            Public Sub New()
                Me._PT2_DxDt_Sensitivity = &H59
                Me._PT3_DxDt_Sensitivity = 300
            End Sub

            Public Sub SetCriticalPoints(ByVal myList As List(Of TraceData), ByVal Spec As Specifications)
                If Spec.AllowWetPHA Then
                    Me._PT3_DxDt_Sensitivity = 40
                End If
                Me.SetPT1(myList, 10)
                Me.SetPT2(myList, Spec)
                Me.SetPT3(myList, Spec)
                Me.SetPT4(myList, 10, Spec.VentTime)
                Me.SetPT5(myList, Spec.VentTime)
                If Spec.AllowWetPHA Then
                    Me.SetPT6(myList, Spec)
                End If
                If Spec.AllowWetPHA Then
                    Me.SetPT7(myList, Spec)
                End If
                Me.SetPT8(myList)
                Me.SetDerivCnt(myList)
                Me.SetFlatness(myList)
                If (Me._PT1X > Me._PT2X) Then
                    Me._PT1Index = Me._PT2Index
                    Me._PT1X = Me._PT2X
                    Me._PT1Y = Me._PT2Y
                End If
            End Sub

            Private Sub SetDerivCnt(ByVal mylist As List(Of TraceData))
                Dim num As Integer = 0
                Dim list As New List(Of Double)
                Dim num2 As Integer = 0
                Do While True
                    If (num >= mylist.Count) Then
                        Me._DerivCnt = list.Count
                        Return
                    End If
                    If (Math.Abs(mylist(num).Y) >= 5) Then
                        If (list.Count = 0) Then
                            list.Add(mylist(num).DxDt)
                        Else
                            Dim num4 As Integer = (list.Count - 1)
                            Dim num3 As Integer = 0
                            Do While True
                                Dim num5 As Integer = num4
                                If (num3 > num5) Then
                                    If (num2 = list.Count) Then
                                        list.Add(mylist(num).DxDt)
                                    End If
                                    num2 = 0
                                    Exit Do
                                End If
                                If ((mylist(num).DxDt > (list(num3) + (CDbl(Me._PT2_DxDt_Sensitivity) / 1.3))) Or (mylist(num).DxDt < (list(num3) - (CDbl(Me._PT2_DxDt_Sensitivity) / 1.3)))) Then
                                    num2 += 1
                                End If
                                num3 += 1
                            Loop
                        End If
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetFlatness(ByVal myList As List(Of TraceData))
                Dim num As Integer = Me._PT2Index
                Dim y As Double = 1000
                Dim y As Double = 0
                Do While True
                    If (num > Me._PT3Index) Then
                        Me._Flatness = Math.Abs(CDbl((y - y)))
                        Return
                    End If
                    If (myList(num).Y < y) Then
                        y = myList(num).Y
                    End If
                    If (myList(num).Y > y) Then
                        y = myList(num).Y
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT1(ByVal mylist As List(Of TraceData), ByVal MinDxDt As Integer)
                Dim num As Integer = 0
                Dim flag As Boolean = False
                Do While True
                    If Not ((num < mylist.Count) And Not flag) Then
                        If (Not flag AndAlso (MinDxDt > 30)) Then
                            Me.SetPT1(mylist, (MinDxDt - 2))
                        End If
                        Return
                    End If
                    If ((mylist(num).DxDt >= MinDxDt) And (mylist(num).X > 3)) Then
                        Me._PT1Y = mylist(num).Y
                        Me._PT1X = mylist(num).X
                        Me._PT1Index = num
                        flag = True
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT2(ByVal myList As List(Of TraceData), ByVal Specs As Specifications)
                Dim a As Double = 0
                Dim y As Double = 0
                Dim x As Double = 0
                Dim num7 As Integer = (myList.Count - 1)
                Dim num5 As Integer = Me._PT1Index
                Do While True
                    Dim flag As Boolean
                    Dim num9 As Integer = num7
                    If (num5 <= num9) Then
                        flag = (myList(num5).X >= ((Me._PT1X + Specs.PumpTime) + ((Specs.PressureBuildDelay(0) * Me._PT1X) + Specs.PressureBuildDelay(1))))
                        If Not flag Then
                            num5 += 1
                            Continue Do
                        End If
                        y = myList(num5).Y
                        x = myList(num5).X
                        a = num5
                    End If
                    Me._PT2X = x
                    Me._PT2Y = y
                    Me._PT2Index = CInt(Math.Round(a))
                    Dim strArray As String() = New String() { "SetPT2: Based on time, Found it at: (", Conversions.ToString(Me._PT2X), ", ", Conversions.ToString(Me._PT2Y), ")" }
                    Logging.AddLogEntry(Me, String.Concat(strArray), EventLogEntryType.Information, 4)
                    Dim num As Double = 1
                    Dim num8 As Integer = (myList.Count - 1)
                    Dim num6 As Integer = Conversions.ToInteger(Me.PT1Index)
                    Do While True
                        num9 = num8
                        If (num6 <= num9) Then
                            flag = ((myList(num6).X >= x) And (myList(num6).X <= (x + num)))
                            If (Not flag OrElse (myList(num6).DxDt2 >= -250)) Then
                                num6 += 1
                                Continue Do
                            End If
                            Me._PT2Y = myList(num6).Y
                            Me._PT2Index = num6
                            Me._PT2X = myList(num6).X
                            Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT2: ReSet based on DxDt2 to: (", Conversions.ToString(Me._PT2X), ", ", Conversions.ToString(Me._PT2Y), ")" }), EventLogEntryType.Information, 4)
                        End If
                        Return
                    Loop
                Loop
            End Sub

            Private Sub SetPT3(ByVal myList As List(Of TraceData), ByVal Specs As Specifications)
                Dim num10 As Double = 0
                Dim y As Double = 0
                Dim x As Double = 0
                Dim dxDt As Double = 0
                Dim num8 As Double = 0
                Dim num17 As Integer = (myList.Count - 1)
                Dim num12 As Integer = Me._PT2Index
                Do While True
                    Dim flag3 As Boolean
                    Dim num20 As Integer = num17
                    If (num12 <= num20) Then
                        flag3 = (myList(num12).X >= (Me._PT2X + Specs.HoldTime))
                        If Not flag3 Then
                            num12 += 1
                            Continue Do
                        End If
                        y = myList(num12).Y
                        x = myList(num12).X
                        dxDt = myList(num12).DxDt
                        num8 = myList(num12).DxDt2
                        num10 = num12
                    End If
                    Me._PT3X = x
                    Me._PT3Y = y
                    Me._PT3DxDt = dxDt
                    Me._PT3DxDt2 = num8
                    Me._PT3Index = num10
                    Dim strArray As String() = New String() { "SetPT3: Based on time, set to: (", Conversions.ToString(Me._PT3X), ", ", Conversions.ToString(Me._PT3Y), ")" }
                    Logging.AddLogEntry(Me, String.Concat(strArray), EventLogEntryType.Information, 4)
                    Dim num3 As Double = 0.5
                    Dim num5 As Double = 1.5
                    Dim num As Double = 0
                    Dim num2 As Integer = 0
                    Dim num18 As Integer = (myList.Count - 1)
                    Dim num13 As Integer = Conversions.ToInteger(Me.PT2Index)
                    Do While True
                        num20 = num18
                        If (num13 > num20) Then
                            Dim num6 As Integer = -50
                            If (num < num6) Then
                                Me._PT3Y = myList(num2).Y
                                Me._PT3Index = num2
                                Me._PT3X = myList(num2).X
                                Me._PT3DxDt = myList(num2).DxDt
                                Me._PT3DxDt2 = myList(num2).DxDt2
                                strArray = New String() { "SetPT3: Reset based on DxDt2<", num6.ToString, ": (", Conversions.ToString(Me._PT3X), ", ", Conversions.ToString(Me._PT3Y), "), DxDt2=", Conversions.ToString(Me._PT3DxDt2) }
                                Logging.AddLogEntry(Me, String.Concat(strArray), EventLogEntryType.Information, 4)
                            End If
                            Dim num4 As Double = (Specs.VentTime - 0.5)
                            num = 0
                            num2 = 0
                            Dim flag As Boolean = False
                            Dim num19 As Integer = (myList.Count - 1)
                            Dim num14 As Integer = Conversions.ToInteger(Me.PT2Index)
                            Do While True
                                Dim flag4 As Boolean
                                num20 = num19
                                If (num14 <= num20) Then
                                    flag4 = ((myList(num14).X >= (x - num4)) And (myList(num14).X <= (x + num4)))
                                    If (Not flag4 OrElse Not ((myList(num14).DxDt2 < -5000) And (myList(num14).DxDt2 < Me._PT3DxDt2))) Then
                                        num14 += 1
                                        Continue Do
                                    End If
                                    num = myList(num14).DxDt2
                                    num2 = num14
                                    flag = True
                                End If
                                If flag Then
                                    Me._PT3Y = myList(num2).Y
                                    Me._PT3Index = num2
                                    Me._PT3X = myList(num2).X
                                    Me._PT3DxDt = myList(num2).DxDt
                                    Me._PT3DxDt2 = myList(num2).DxDt2
                                    strArray = New String() { "SetPT3: Reseting Pt based on Extreme DxDt2 value: (", Conversions.ToString(Me._PT3X), ", ", Conversions.ToString(Me._PT3Y), ", ", Conversions.ToString(num), ")" }
                                    Logging.AddLogEntry(Me, String.Concat(strArray), EventLogEntryType.Information, 4)
                                    Dim num16 As Double = (Me._PT3X - Specs.HoldTime)
                                    Dim flag2 As Boolean = False
                                    Dim num15 As Integer = CInt(Math.Round(Me._PT3Index))
                                    Do While True
                                        flag4 = ((num15 > Me._PT1Index) And Not flag2)
                                        If Not flag4 Then
                                            Exit Do
                                        End If
                                        If (myList(num15).X > num16) Then
                                            num15 -= 1
                                            Continue Do
                                        End If
                                        flag2 = True
                                        Me._PT2X = myList(num15).X
                                        Me._PT2Y = myList(num15).Y
                                        Me._PT2Index = num15
                                        Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT3: Reseting PT2 based on PT3 Extreme DxDt2 val: (", Conversions.ToString(Me._PT2X), ", ", Conversions.ToString(Me._PT2Y), ")" }), EventLogEntryType.Information, 4)
                                        Interaction.Beep
                                    Loop
                                End If
                                Return
                            Loop
                        End If
                        flag3 = ((myList(num13).X >= (x - num5)) And (myList(num13).X <= (x + num3)))
                        If (flag3 AndAlso (myList(num13).DxDt2 < num)) Then
                            num = myList(num13).DxDt2
                            num2 = num13
                        End If
                        num13 += 1
                    Loop
                Loop
            End Sub

            Private Sub SetPT4(ByVal mylist As List(Of TraceData), ByVal ExpectedMin As Integer, ByVal VentTime As Double)
                Dim num As Integer = Me.PT3Index
                Dim flag As Boolean = False
                Dim num2 As Double = 0.5
                If (VentTime <= num2) Then
                    num2 = (VentTime * 0.5)
                End If
                Logging.AddLogEntry(Me, ("SetPT4: looking for PT past PT3 with Y val < " & Conversions.ToString(ExpectedMin)), EventLogEntryType.Information, 4)
                Do While True
                    If Not ((num < mylist.Count) And Not flag) Then
                        If Not flag Then
                            Logging.AddLogEntry(Me, ("SetPT4: Never found it. Repeating with ExpectedMin = " & Conversions.ToString(CInt((ExpectedMin + 5)))), EventLogEntryType.Information, 4)
                            Me.SetPT4(mylist, (ExpectedMin + 5), VentTime)
                        End If
                        Return
                    End If
                    If ((Math.Abs(mylist(num).Y) <= ExpectedMin) Or ((mylist(num).X - Me._PT3X) >= (VentTime - num2))) Then
                        Logging.AddLogEntry(Me, "SetPT4: foundit", EventLogEntryType.Information, 4)
                        Me._PT4Y = mylist(num).Y
                        Me._PT4X = mylist(num).X
                        Me._PT4Index = num
                        flag = True
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT5(ByVal mylist As List(Of TraceData), ByVal VentTime As Double)
                Dim num As Integer = Me.PT4Index
                Dim flag As Boolean = False
                Dim num2 As Integer = 8
                Logging.AddLogEntry(Me, "SetPT5: looking for PT past PT4 + 2 seconds", EventLogEntryType.Information, 4)
                Do While True
                    If Not ((num < mylist.Count) And Not flag) Then
                        If Not flag Then
                            Me._PT5Y = Me._PT4Y
                            Me._PT5X = Me._PT4X
                            Me._PT5Index = Me._PT4Index
                            Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT5: Coulding find it, setting to = PT4: (", Conversions.ToString(Me._PT5X), ", ", Conversions.ToString(Me._PT5Y), ")" }), EventLogEntryType.Information, 4)
                        End If
                        Return
                    End If
                    If (mylist(num).X >= ((Me.PT3X + VentTime) + num2)) Then
                        Logging.AddLogEntry(Me, ("SetPT5: Found it at: " & Conversions.ToString(mylist(num).X)), EventLogEntryType.Information, 4)
                        flag = True
                        Me._PT5Y = mylist(num).Y
                        Me._PT5X = mylist(num).X
                        Me._PT5Index = num
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT6(ByVal mylist As List(Of TraceData), ByVal Specs As Specifications)
                Logging.AddLogEntry(Me, "SetPT6: Looking for pt btween PT2 and PT3-HoldTime-Retard with a max val", EventLogEntryType.Information, 4)
                Dim num3 As Double = (Specs.HoldTime - Specs.WetPHAHoldTimeRetardVal)
                Dim y As Double = 0
                Dim num As Integer = Conversions.ToInteger(Me.PT2Index)
                Dim num2 As Integer = 0
                Do While True
                    If (mylist(num).X > (Me.PT3X - num3)) Then
                        Me._PT6Y = mylist(num2).Y
                        Me._PT6X = mylist(num2).X
                        Me._PT6Index = num2
                        Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT8: Found it at (", Conversions.ToString(Me._PT6X), ", ", Conversions.ToString(Me._PT6Y), ")" }), EventLogEntryType.Information, 4)
                        Return
                    End If
                    If (mylist(num).Y > y) Then
                        y = mylist(num).Y
                        num2 = num
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT7(ByVal mylist As List(Of TraceData), ByVal Specs As Specifications)
                Logging.AddLogEntry(Me, "SetPT7: Looking for pt btween PT6 and PT3 with a min value", EventLogEntryType.Information, 4)
                Dim y As Double = Me.PT6Y
                Dim num As Integer = Me.PT6Index
                Dim num2 As Integer = 0
                Do While True
                    If (mylist(num).X > Me.PT3X) Then
                        If ((mylist(num2).X - Me._PT6X) < 1) Then
                            num2 = CInt(Math.Round(Me._PT3Index))
                        End If
                        Me._PT7Y = mylist(num2).Y
                        Me._PT7X = mylist(num2).X
                        Me._PT7Index = num2
                        Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT8: Found it at (", Conversions.ToString(Me._PT7X), ", ", Conversions.ToString(Me._PT7Y), ")" }), EventLogEntryType.Information, 4)
                        Return
                    End If
                    If (mylist(num).Y < y) Then
                        y = mylist(num).Y
                        num2 = num
                    End If
                    num += 1
                Loop
            End Sub

            Private Sub SetPT8(ByVal myList As List(Of TraceData))
                Logging.AddLogEntry(Me, "SetPT8: Looking for Min between PT4 and PT5", EventLogEntryType.Information, 4)
                Dim y As Double = Me.PT4Y
                Dim num As Integer = Me.PT4Index
                Dim num3 As Integer = Me.PT4Index
                Do While True
                    If (myList(num).X > Me.PT5X) Then
                        Me._PT8Index = num3
                        Me._PT8X = myList(num3).X
                        Me._PT8Y = myList(num3).Y
                        Logging.AddLogEntry(Me, String.Concat(New String() { "SetPT8: Found it at (", Conversions.ToString(Me._PT8X), ", ", Conversions.ToString(Me._PT8Y), ")" }), EventLogEntryType.Information, 4)
                        Return
                    End If
                    If (myList(num).Y < y) Then
                        y = myList(num).Y
                        num3 = num
                    End If
                    num += 1
                Loop
            End Sub


            ' Properties
            Private Property _PT1X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT1X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT1X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT1Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT1Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT1Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT1Index As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT1Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__PT1Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT2X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT2X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT2X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT2Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT2Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT2Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT2Index As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT2Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__PT2Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT2_DxDt_Sensitivity As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT2_DxDt_Sensitivity
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__PT2_DxDt_Sensitivity = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT3X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT3Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3DxDt As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3DxDt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT3DxDt = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3DxDt2 As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3DxDt2
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT3DxDt2 = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT3Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT3_DxDt_Sensitivity As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT3_DxDt_Sensitivity
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__PT3_DxDt_Sensitivity = AutoPropertyValue
                End Set
            End Property

            Private Property _PT4X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT4X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT4X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT4Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT4Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT4Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT4Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT4Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT4Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT5X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT5X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT5X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT5Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT5Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT5Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT5Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT5Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT5Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT6X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT6X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT6X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT6Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT6Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT6Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT6Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT6Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT6Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT7X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT7X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT7X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT7Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT7Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT7Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT7Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT7Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT7Index = AutoPropertyValue
                End Set
            End Property

            Private Property _PT8X As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT8X
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT8X = AutoPropertyValue
                End Set
            End Property

            Private Property _PT8Y As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT8Y
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT8Y = AutoPropertyValue
                End Set
            End Property

            Private Property _PT8Index As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PT8Index
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__PT8Index = AutoPropertyValue
                End Set
            End Property

            Private Property _DerivCnt As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__DerivCnt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__DerivCnt = AutoPropertyValue
                End Set
            End Property

            Private Property _Flatness As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__Flatness
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__Flatness = AutoPropertyValue
                End Set
            End Property

            Public ReadOnly Property DerivCnt As Integer
                Get
                    Return Me._DerivCnt
                End Get
            End Property

            Public ReadOnly Property PT1X As Double
                Get
                    Return Me._PT1X
                End Get
            End Property

            Public ReadOnly Property PT1Y As Double
                Get
                    Return Me._PT1Y
                End Get
            End Property

            Public ReadOnly Property PT1Index As Object
                Get
                    Return Me._PT1Index
                End Get
            End Property

            Public ReadOnly Property PT2X As Double
                Get
                    Return Me._PT2X
                End Get
            End Property

            Public ReadOnly Property PT2Y As Double
                Get
                    Return Me._PT2Y
                End Get
            End Property

            Public ReadOnly Property PT2Index As Object
                Get
                    Return Me._PT2Index
                End Get
            End Property

            Public ReadOnly Property PT3X As Double
                Get
                    Return Me._PT3X
                End Get
            End Property

            Public ReadOnly Property PT3Y As Double
                Get
                    Return Me._PT3Y
                End Get
            End Property

            Public ReadOnly Property PT3DxDt As Double
                Get
                    Return Me._PT3DxDt
                End Get
            End Property

            Public ReadOnly Property PT3DxDt2 As Double
                Get
                    Return Me._PT3DxDt2
                End Get
            End Property

            Public ReadOnly Property PT3Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT3Index))
                End Get
            End Property

            Public ReadOnly Property PT4X As Double
                Get
                    Return Me._PT4X
                End Get
            End Property

            Public ReadOnly Property PT4Y As Double
                Get
                    Return Me._PT4Y
                End Get
            End Property

            Public ReadOnly Property PT4Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT4Index))
                End Get
            End Property

            Public ReadOnly Property PT5X As Double
                Get
                    Return Me._PT5X
                End Get
            End Property

            Public ReadOnly Property PT5Y As Double
                Get
                    Return Me._PT5Y
                End Get
            End Property

            Public ReadOnly Property PT5Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT5Index))
                End Get
            End Property

            Public ReadOnly Property PT6X As Double
                Get
                    Return Me._PT6X
                End Get
            End Property

            Public ReadOnly Property PT6Y As Double
                Get
                    Return Me._PT6Y
                End Get
            End Property

            Public ReadOnly Property PT6Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT6Index))
                End Get
            End Property

            Public ReadOnly Property PT7X As Double
                Get
                    Return Me._PT7X
                End Get
            End Property

            Public ReadOnly Property PT7Y As Double
                Get
                    Return Me._PT7Y
                End Get
            End Property

            Public ReadOnly Property PT7Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT7Index))
                End Get
            End Property

            Public ReadOnly Property PT8X As Double
                Get
                    Return Me._PT8X
                End Get
            End Property

            Public ReadOnly Property PT8Y As Double
                Get
                    Return Me._PT8Y
                End Get
            End Property

            Public ReadOnly Property PT8Index As Integer
                Get
                    Return CInt(Math.Round(Me._PT8Index))
                End Get
            End Property

            Public ReadOnly Property Flatness As Double
                Get
                    Return Me._Flatness
                End Get
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT1X As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT1Y As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT1Index As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT2X As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT2Y As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT2Index As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT2_DxDt_Sensitivity As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT3X As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT3Y As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT3DxDt As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT3DxDt2 As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT3Index As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT3_DxDt_Sensitivity As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT4X As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT4Y As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT4Index As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT5X As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT5Y As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT5Index As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT6X As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT6Y As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT6Index As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT7X As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT7Y As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT7Index As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT8X As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __PT8Y As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PT8Index As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __DerivCnt As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __Flatness As Double
        End Class

        Public Class PrinterInformation
            ' Properties
            Private Property _SerialNum As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SerialNum
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__SerialNum = AutoPropertyValue
                End Set
            End Property

            Private Property _FWRev As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__FWRev
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__FWRev = AutoPropertyValue
                End Set
            End Property

            Private Property _EnginePgCnt As Long
                <DebuggerNonUserCode> _
                Get
                    Return Me.__EnginePgCnt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Long)
                    Me.__EnginePgCnt = AutoPropertyValue
                End Set
            End Property

            Public Property SerialNum As String
                Get
                    Return Me._SerialNum
                End Get
                Set(ByVal value As String)
                    Me._SerialNum = value
                End Set
            End Property

            Public Property FWRev As String
                Get
                    Return Me._FWRev
                End Get
                Set(ByVal value As String)
                    Me._FWRev = value
                End Set
            End Property

            Public Property EnginePgCnt As Long
                Get
                    Return Me._EnginePgCnt
                End Get
                Set(ByVal value As Long)
                    Me._EnginePgCnt = value
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SerialNum As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __FWRev As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __EnginePgCnt As Long
        End Class

        Public Class PrinterMechChecks
            ' Methods
            Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal Spec As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
                Try 
                    Me._Name = Name
                    Me._SpecType = SpecType
                    Me._SpecLow = Spec
                    Me._Value = Value
                    Me._SpecFunction = SpecFunction
                    If (SpecType = SpecType.GreaterThan) Then
                        Me._Results = (Value >= Spec)
                    Else
                        If (SpecType <> SpecType.LessThan) Then
                            Throw New ApplicationException("SpecType not supported. Try the overloaded method.")
                        End If
                        Me._Results = (Value <= Spec)
                    End If
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Logging.AddLogEntry(Me, ("AddMechCheck: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                    Interaction.MsgBox(exception.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                End Try
            End Sub

            Public Sub AddMechCheck(ByVal Name As String, ByVal SpecType As SpecType, ByVal SpecLow As Double, ByVal SpecHigh As Double, ByVal Value As Double, ByVal SpecFunction As SpecFunction)
                Try 
                    Me._Name = Name
                    Me._SpecType = SpecType
                    Me._SpecLow = SpecLow
                    Me._SpecHigh = SpecHigh
                    Me._Value = Value
                    Me._SpecFunction = SpecFunction
                    If (SpecType <> SpecType.Between) Then
                        Throw New ApplicationException("SpecType not supported. Try the overloaded method.")
                    End If
                    Me._Results = ((Value >= SpecLow) And (Value <= SpecHigh))
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Logging.AddLogEntry(Me, ("AddMechCheck: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                    Interaction.MsgBox(exception.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                End Try
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

            Private Property _SpecType As SpecType
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SpecType
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As SpecType)
                    Me.__SpecType = AutoPropertyValue
                End Set
            End Property

            Private Property _SpecLow As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SpecLow
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__SpecLow = AutoPropertyValue
                End Set
            End Property

            Private Property _SpecHigh As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SpecHigh
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__SpecHigh = AutoPropertyValue
                End Set
            End Property

            Private Property _Value As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__Value
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__Value = AutoPropertyValue
                End Set
            End Property

            Private Property _Results As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__Results
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__Results = AutoPropertyValue
                End Set
            End Property

            Private Property _SpecFunction As SpecFunction
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SpecFunction
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As SpecFunction)
                    Me.__SpecFunction = AutoPropertyValue
                End Set
            End Property

            Public Property Name As String
                Get
                    Return Me._Name
                End Get
                Set(ByVal value As String)
                    Me._Name = value
                End Set
            End Property

            Public Property SpecType As SpecType
                Get
                    Return Me._SpecType
                End Get
                Set(ByVal value As SpecType)
                    Me._SpecType = value
                End Set
            End Property

            Public Property SpecLow As Double
                Get
                    Return Me._SpecLow
                End Get
                Set(ByVal value As Double)
                    Me._SpecLow = value
                End Set
            End Property

            Public Property SpecHigh As Double
                Get
                    Return Me._SpecHigh
                End Get
                Set(ByVal value As Double)
                    Me._SpecHigh = value
                End Set
            End Property

            Public ReadOnly Property Value As Double
                Get
                    Return Me._Value
                End Get
            End Property

            Public Property Results As Boolean
                Get
                    Return Me._Results
                End Get
                Set(ByVal value As Boolean)
                    Me._Results = value
                End Set
            End Property

            Public Property SpecFunction As SpecFunction
                Get
                    Return Me._SpecFunction
                End Get
                Set(ByVal value As SpecFunction)
                    Me._SpecFunction = value
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __Name As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __SpecType As SpecType
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SpecLow As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SpecHigh As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __Value As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __Results As Boolean
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __SpecFunction As SpecFunction
        End Class

        Public Class Results
            ' Methods
            Public Sub New()
                Me._InstallPressureThreshold = -5
                Me.PF = New Results_PF
                Me.Val = New Results_Val
            End Sub

            Friend Sub AnalyzeResults(ByVal myPoints As Points, ByRef specs As Specifications, ByVal InstallPressure As Double)
                Me.PF.DryPHA = Me.DetermineDryPHA(InstallPressure, myPoints, specs)
                Dim num3 As Double = Me.DetermineSpecOverRide(InstallPressure, specs)
                If Not (num3 = 1) Then
                    specs.PressureMin = CInt(Math.Round(CDbl((specs.PressureMin * num3))))
                    specs.VentTime = (specs.VentTime / num3)
                    specs.LeakMin = -20
                End If
                Dim num4 As Double = myPoints.PT2Y
                If (specs.AllowWetPHA And (myPoints.PT2Y <= myPoints.PT6Y)) Then
                    num4 = myPoints.PT6Y
                End If
                Me.Val.MaxPressure = num4
                If ((num4 >= specs.PressureMin) And (num4 <= specs.PressureMax)) Then
                    Me.PF.MaxPressure = True
                Else
                    Me.PF.MaxPressure = False
                    Me.PF.OverallPSTResults = False
                End If
                Dim num As Double = myPoints.PT2Y
                Dim num2 As Double = myPoints.PT3Y
                specs.SetMaxLeakVal(myPoints.PT2X, myPoints.PT3X)
                If specs.AllowWetPHA Then
                    num = myPoints.PT6Y
                    num2 = myPoints.PT7Y
                    specs.SetMaxLeakVal(myPoints.PT6X, myPoints.PT7X)
                End If
                If Not (Not (num = 0) And Not (num2 = 0)) Then
                    Me.PF.Leak = False
                    Me.PF.OverallPSTResults = False
                Else
                    Dim num5 As Double = (num - num2)
                    Me.Val.Leak = num5
                    If ((num5 <= specs.LeakMax) And (num5 >= specs.LeakMin)) Then
                        Me.PF.Leak = True
                    Else
                        Me.PF.Leak = False
                        Me.PF.OverallPSTResults = False
                    End If
                End If
                Me.Val.TubeEvacDeltaPressure = (myPoints.PT5Y - myPoints.PT8Y)
                If (Me.Val.TubeEvacDeltaPressure <= specs.TubeEvacDeltaPressure) Then
                    Me.PF.TubeEvacDeltaPressure = True
                Else
                    Me.PF.TubeEvacDeltaPressure = False
                    If Me.PF.OverallPSTResults Then
                        Me._TubeEvacDP_RetestRequired = True
                    End If
                    Me.PF.OverallPSTResults = False
                End If
                Me.Val.DerivCnt = myPoints.DerivCnt
                If (myPoints.DerivCnt <= specs.DerivCnt) Then
                    Me.PF.DerivCnt = True
                Else
                    Me.PF.DerivCnt = False
                    Me.PF.OverallPSTResults = False
                End If
                If Not ((Not (myPoints.PT4Y = 0) And Not (myPoints.PT3Y = 0)) And Not (myPoints.PT4Y = myPoints.PT3Y)) Then
                    Me.PF.VentDeltaPMin = -1
                    If Me.PF.OverallPSTResults Then
                        Me._VentDP_RetestRequired = True
                    End If
                    Me.PF.OverallPSTResults = False
                Else
                    Dim num6 As Double = (myPoints.PT3Y - myPoints.PT4Y)
                    Me.Val.VentDeltaP = num6
                    If (num6 >= specs.VentDeltaPMin) Then
                        Me.PF.VentDeltaPMin = 0
                    ElseIf (((myPoints.PT3DxDt2 < specs.VentDxDt2Threshold) And (num6 >= (specs.VentDeltaPMin * 0.5))) And specs.AllowWetPHA) Then
                        Me.Val.VentDeltaP = myPoints.PT3DxDt2
                        Me.PF.VentDeltaPMin = 1
                    Else
                        Me.PF.VentDeltaPMin = -1
                        If Me.PF.OverallPSTResults Then
                            Me._VentDP_RetestRequired = True
                        End If
                        Me.PF.OverallPSTResults = False
                    End If
                End If
            End Sub

            Private Function DetermineDryPHA(ByVal InstallPressure As Double, ByVal myPoints As Points, ByVal Specs As Specifications) As Boolean
                Return If((InstallPressure > Me._InstallPressureThreshold), If(((myPoints.PT2Y - myPoints.PT3Y) >= (Specs.LeakMin - 2)), Not ((myPoints.PT4Y > 5) And Math.IsCloseTo(myPoints.PT4Y, myPoints.PT5Y, (myPoints.PT4Y * 0.2))), False), False)
            End Function

            Private Function DetermineSpecOverRide(ByVal InstallPressure As Double, ByVal specs As Specifications) As Double
                Return If(Not specs.AllowWetPHA, 1, If(Me.PF.DryPHA, 1, 1))
            End Function


            ' Properties
            Private Property _InstallPressureThreshold As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__InstallPressureThreshold
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__InstallPressureThreshold = AutoPropertyValue
                End Set
            End Property

            Private Property _VentDP_RetestRequired As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__VentDP_RetestRequired
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__VentDP_RetestRequired = AutoPropertyValue
                End Set
            End Property

            Property VentDP_RetestRequired As Boolean
                Public Get
                    Return Me._VentDP_RetestRequired
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._VentDP_RetestRequired = value
                End Set
            End Property

            Private Property _TubeEvacDP_RetestRequired As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__TubeEvacDP_RetestRequired
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__TubeEvacDP_RetestRequired = AutoPropertyValue
                End Set
            End Property

            Property TubeEvacDP_RetestRequired As Boolean
                Public Get
                    Return Me._TubeEvacDP_RetestRequired
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._TubeEvacDP_RetestRequired = value
                End Set
            End Property

            Public Property PF As Results_PF
                <DebuggerNonUserCode> _
                Get
                    Return Me._PF
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Results_PF)
                    Me._PF = AutoPropertyValue
                End Set
            End Property

            Public Property Val As Results_Val
                <DebuggerNonUserCode> _
                Get
                    Return Me._Val
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Results_Val)
                    Me._Val = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __InstallPressureThreshold As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __VentDP_RetestRequired As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __TubeEvacDP_RetestRequired As Boolean
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _PF As Results_PF
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _Val As Results_Val
        End Class

        Public Class Results_PF
            ' Methods
            Public Sub New()
                Me._OverallPSTResults = True
            End Sub


            ' Properties
            Private Property _MaxPressure As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__MaxPressure
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__MaxPressure = AutoPropertyValue
                End Set
            End Property

            Private Property _Leak As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__Leak
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__Leak = AutoPropertyValue
                End Set
            End Property

            Private Property _VentDeltaPMin As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__VentDeltaPMin
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__VentDeltaPMin = AutoPropertyValue
                End Set
            End Property

            Private Property _DerivCnt As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__DerivCnt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__DerivCnt = AutoPropertyValue
                End Set
            End Property

            Private Property _DryPHA As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__DryPHA
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__DryPHA = AutoPropertyValue
                End Set
            End Property

            Private Property _OverallPSTResults As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__OverallPSTResults
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__OverallPSTResults = AutoPropertyValue
                End Set
            End Property

            Private Property _TubeEvacDeltaPressure As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__TubeEvacDeltaPressure
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__TubeEvacDeltaPressure = AutoPropertyValue
                End Set
            End Property

            Property MaxPressure As Boolean
                Public Get
                    Return Me._MaxPressure
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._MaxPressure = value
                End Set
            End Property

            Property Leak As Boolean
                Public Get
                    Return Me._Leak
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._Leak = value
                End Set
            End Property

            Property DerivCnt As Boolean
                Public Get
                    Return Me._DerivCnt
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._DerivCnt = value
                End Set
            End Property

            Property DryPHA As Boolean
                Public Get
                    Return Me._DryPHA
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._DryPHA = value
                End Set
            End Property

            Property OverallPSTResults As Boolean
                Public Get
                    Return Me._OverallPSTResults
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._OverallPSTResults = value
                End Set
            End Property

            Property TubeEvacDeltaPressure As Boolean
                Public Get
                    Return Me._TubeEvacDeltaPressure
                End Get
                Friend Set(ByVal value As Boolean)
                    Me._TubeEvacDeltaPressure = value
                End Set
            End Property

            Property VentDeltaPMin As Integer
                Public Get
                    Return Me._VentDeltaPMin
                End Get
                Friend Set(ByVal value As Integer)
                    Me._VentDeltaPMin = value
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __MaxPressure As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __Leak As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __VentDeltaPMin As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __DerivCnt As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __DryPHA As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __OverallPSTResults As Boolean
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __TubeEvacDeltaPressure As Boolean
        End Class

        Public Class Results_Val
            ' Properties
            Private Property _MaxPressure As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__MaxPressure
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__MaxPressure = AutoPropertyValue
                End Set
            End Property

            Private Property _Leak As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__Leak
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__Leak = AutoPropertyValue
                End Set
            End Property

            Private Property _VentDeltaP As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__VentDeltaP
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__VentDeltaP = AutoPropertyValue
                End Set
            End Property

            Private Property _DerivCnt As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__DerivCnt
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__DerivCnt = AutoPropertyValue
                End Set
            End Property

            Private Property _TubeEvacDeltaPressure As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__TubeEvacDeltaPressure
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__TubeEvacDeltaPressure = AutoPropertyValue
                End Set
            End Property

            Property MaxPressure As Double
                Public Get
                    Return Me._MaxPressure
                End Get
                Friend Set(ByVal value As Double)
                    Me._MaxPressure = value
                End Set
            End Property

            Property Leak As Double
                Public Get
                    Return Me._Leak
                End Get
                Friend Set(ByVal value As Double)
                    Me._Leak = value
                End Set
            End Property

            Property VentDeltaP As Double
                Public Get
                    Return Me._VentDeltaP
                End Get
                Friend Set(ByVal value As Double)
                    Me._VentDeltaP = value
                End Set
            End Property

            Property DerivCnt As Integer
                Public Get
                    Return Me._DerivCnt
                End Get
                Friend Set(ByVal value As Integer)
                    Me._DerivCnt = value
                End Set
            End Property

            Property TubeEvacDeltaPressure As Double
                Public Get
                    Return Me._TubeEvacDeltaPressure
                End Get
                Friend Set(ByVal value As Double)
                    Me._TubeEvacDeltaPressure = value
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __MaxPressure As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __Leak As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __VentDeltaP As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __DerivCnt As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __TubeEvacDeltaPressure As Double
        End Class

        Public Enum SpecFunction
            ' Fields
            PassFail = 0
            Monitor = 1
        End Enum

        Public Enum SpecType
            ' Fields
            LessThan = 0
            GreaterThan = 1
            Between = 2
        End Enum

        Public Class TestInformation
            ' Properties
            Public Property ScriptRev As String
                Get
                    Return Me._ScriptRev
                End Get
                Set(ByVal value As String)
                    Me._ScriptRev = value
                End Set
            End Property

            Public Property ScriptProduct As String
                Get
                    Return Me._ScriptProduct
                End Get
                Set(ByVal value As String)
                    Me._ScriptProduct = value
                End Set
            End Property

            Public Shared ReadOnly Property FuelRev As String
                Get
                    Return Assembly.GetExecutingAssembly.GetName.Version.ToString
                End Get
            End Property

            Public Property TestDate As String
                Get
                    Return Me._TestDate
                End Get
                Set(ByVal value As String)
                    Me._TestDate = value
                End Set
            End Property

            Public Property TestTime As String
                Get
                    Return Me._TestTime
                End Get
                Set(ByVal value As String)
                    Me._TestTime = value
                End Set
            End Property

            Public Property TestSite As TestSites
                Get
                    Return Me._TestSite
                End Get
                Set(ByVal value As TestSites)
                    Me._TestSite = value
                End Set
            End Property

            Public Property UploadInterval As Integer
                Get
                    Return Me._UploadInterval
                End Get
                Set(ByVal value As Integer)
                    Me._UploadInterval = value
                End Set
            End Property

            Public Property UploadsEnabled As Boolean
                Get
                    Return Me._UploadsEnabled
                End Get
                Set(ByVal value As Boolean)
                    Me._UploadsEnabled = value
                End Set
            End Property

            Public Property RunNumber As Integer
                Get
                    Return Me._RunNumber
                End Get
                Set(ByVal value As Integer)
                    Me._RunNumber = value
                End Set
            End Property

            Public Property TestStationType As TestStationTypes
                Get
                    Return Me._TestStationType
                End Get
                Set(ByVal value As TestStationTypes)
                    Me._TestStationType = value
                End Set
            End Property


            ' Fields
            Private _ScriptRev As String
            Private _ScriptProduct As String
            Private _TestDate As String
            Private _TestTime As String
            Private _TestSite As TestSites
            Private _UploadInterval As Integer = 2
            Private _UploadsEnabled As Boolean = True
            Private _RunNumber As Integer
            Private _TestStationType As TestStationTypes
        End Class

        Public Enum TestSites
            ' Fields
            HP = 0
            NKG_China = 1
            NKG_Thailand = 2
            DEBUG = 3
        End Enum

        Public Enum TestStationTypes
            ' Fields
            ProductionLine = 0
            Rework = 1
            CSA = 2
            PPP = 3
            RnD = 4
        End Enum
    End Class
End Namespace

