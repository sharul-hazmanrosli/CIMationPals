'#Reference #NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null, processorArchitecture=$Proc$, Path=$CIMProjectPath$\NIDAQ\$Proc$\NIDAQ.dll

'#Language "WWB.NET"
'SVN $Revision$
'Recommended Description: Test Priming Pressure

Option Explicit
Imports System
Imports System.Threading
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Math
Imports System.String
Imports System.Diagnostics
Imports System.Collections.Generic

'#Uses "modPen.bas"
'#Uses "modMech.bas"

Const ResultTable As String = "ccProcMechPVTTransducerGainsRes" 'This table need to be created in SQL for now

Const DEBUG_MODE = False
Const LOG_RAW_DATA = True
Const RUN_PUMP_COMPENSATION_TEST = False
Const RUN_BLOCKAGE_TEST = False
Const LIMIT_CARRIAGE_SPEED = True   '20160121_HK: Added as requested by May Lee

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Blockage Test
'
Const BLOCKAGE_PRESSURE = 20   'Pressure to consider it blocked
Const BLOCKAGE_TEST_MIN_PRESSURE = 4
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Pump Initialization and Shutdown
'
Const WARM_UP_PRIMES_START = 2
Const WARM_UP_PRIMES_END = 0
Const WARMUP_PRIME_PUMP_TIME = 800
Const WARMUP_PRIME_PUMP_TIME_DecayTest = 790
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Pressure Test
'
Const PRESSURE_TEST_PUMP_TIME = 450
Const PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS = 2000
Const PRESSURE_TEST_SAMPLINGHZ = 1000

Const PRESSURE_TEST_NUMBERSAMPLES = 3800    'change from 2500 to 3800 to address low pressure seen in sealed unit

Const PRESSURE_TEST_MIN_MAX = 95                             'PP1 change old value was 93
Const PRESSURE_TEST_MAX_MAX = 134                               'PP1 change old value was 125
Const PRESSURE_TEST_START_VENTRATE_PRESSURE = 80
Const PRESSURE_TEST_STOP_VENTRATE_PRESSURE = 20
Const PRESSURE_TEST_MIN_VENTRATE = 784                               'PP change MP2 value was 250
Const PRESSURE_TEST_MAX_VENTRATE = 1434                                'PP change MP2 value was 500
Const PRESSURE_TEST_START_RISE_PRESSURE = 2
Const PRESSURE_TEST_MIN_VENT_DELAY = -75 '-25 'Changed to -75 for LP1
Const PRESSURE_TEST_MAX_VENT_DELAY = 50

Const RISETIME_OFFSET = 25
Const PRESSURE_TEST_START_COMPENSATION_PRESSURE = 35
Const PRESSURE_TEST_STOP_COMPENSATION_PRESSURE = 80
Const PRESSURE_TEST_NOMINAL_PUMP_SLOPE = 241.319

Const SCREEN_MAX_PRESSURE = False   'Set to True for Marconi PP1 Only
'
'
'Used for R&D only.
'Const COMPENSATION_TEST_PUMP_TIME = 900
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Decay Test
'
Const DECAY_TEST_PUMP_TIME = 440
Const DECAY_TEST_SAMPLINGHZ = 100
Const DECAY_TEST_PEN_PUMP_POST_PUMP_DELAY_MS =  4750
Const DECAY_TEST_PEN_PUMP_POST_CARRIAGE_VENT_DELAY_MS = 2000
Const DECAY_TEST_CARRIAGE_OFF_PRIME_POS = 4800

Const DECAY_TEST_NUMBERSAMPLES = 1000

Const DECAY_TEST_MIN_MAX = 93									'MP2 change old value was 95
Const DECAY_TEST_MAX_MAX = 134                                   'MP2 change old value was 123
Const DECAY_TEST_MIN_START_DECAY_PRESSURE = 78                          'MP2 change old value was 90
Const DECAY_TEST_START_DECAY = 2
Const DECAY_TEST_STOP_DECAY = 3
Const DECAY_TEST_AVERAGING = 5
Const DECAY_TEST_MIN_DECAY = 0
Const DECAY_TEST_MAX_DECAY = -5.75								'MP2 change old value was -2.5
Const DECAY_TEST_START_VENTRATE_PRESSURE = 70   'SSP, 5Oct2018 - change in Hi MP2 from 80
Const DECAY_TEST_STOP_VENTRATE_PRESSURE = 30    'SSP, 5Oct2018 - change in Hi MP2 from 20
Const DECAY_TEST_MIN_VENTRATE = 200 'SSP, 5Oct2018 - change in Hi MP2 from 230								'Leave this for now, this value could be lowered for SS vent.
Const DECAY_TEST_MAX_VENTRATE = 1000								'PP change old value was 1000.
'
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public TransducerGains(0 To 3) As Double 'Convert Voltage to Pressure
Public TransducerOffsets(0 To 3) As Double

Const Colorstr = "Magenta,Cyan,Yellow,K (Black)"
Dim Colors() As String
Dim NIDAQ As NIDAQ.NIDAQ
Dim AIChannels As String
Dim DIChannels As String
Dim DOChannels As String
Dim counter As Integer
Dim sDatalogName As String

'Parameters for GenerateGraph() using PVTPostProcess.exe
Dim PTGraphLogInfo As New Dictionary(Of String, Object)
Dim DTGraphLogInfo As New Dictionary(Of String, Object)
Dim MaxPwithinRange As Integer = 1
Dim bTestResult As Boolean = True

Sub main()
    Dim sFailInfo As String             = String.Empty,
        sErrLine As String              = String.Empty,
        sScriptVersion As String        = String.Empty,
        strErrMsg As String             = String.Empty,
        DevSerialNumber As String       = String.Empty,
        sSavePath As String             = String.Empty,
        ExceptionCount As Integer       = 0,
        PressCount As Integer           = 0,
        DecayCount As Integer           = 0,
        BlockCount As Integer           = 0,
        CheckVentDelayCount As Integer  = 0,
        strRes As String                = String.empty,
        intRes As Integer               = 0,
        InitTries As Integer            = 3,
        MaxMinVal As Double,
        AIs() As String,
        DIs() As String,
        DOs() As String,
        Header() As String,
        Data() As String

    Try
        'Assign the script version to be saved to the DataLog and the Error.log
        sScriptVersion = Test.SCM.Revision
        DataLog.PackageVersion = RunTime.ProjectVersionWithCheckpoint
        DataLog.StationNumber = RunTime.StationNumber

        Display.text =  "Testing Priming Pressure"
        Display.StatusBar = RunTime.TestName

        sDatalogName = "Mech2TestPrimingPressureServo_Marconi"

        'Additional setting required for CIMation 2.10.2.0 onward
        REST.WriteReadDelay = 100

        GUIUtil.DisplayStatusLine "Initializing NIDAQ"
        Do
            Colors = Split(Colorstr,",")
            sErrLine = CallersLine(-1)
            NIDAQ = New NIDAQ.NIDAQ
            sErrLine = CallersLine(-1)
            If Not NIDAQ.InitNIDAQ(DevSerialNumber, sFailInfo) Then
                InitTries = InitTries - 1
                If InitTries > 0 Then
                    'GUIUtil.DisplayPicture "PVT Connection.jpg"
                    TestUtil.DisplayPicturehtmlAR TestParms.picPVTConnection
                    GUIUtil.DisplayUserPrompt TestMsgs.CheckPVTConnection & vbCrLf & TestMsgs.AlertEngineer
                Else
                    bTestResult = False
                    sFailInfo = "Fail to initialize NIDAQ"
                    EndTest(CIMTestResult.Fail, sFailInfo)
                    Exit Try
                End If
            Else
                Exit Do
            End If
        Loop Until InitTries <= 0

        sErrLine = CallersLine(-1)
        If Not NIDAQ.GetNIDAQChannels(AIs, DIs, DOs, sFailInfo) Then
            bTestResult = False
            sFailInfo = "Fail to get NIDAQ Channels; " & sFailInfo
            EndTest(CIMTestResult.Fail, sFailInfo)
            Exit Try
        End If

        sErrLine = CallersLine(-1)
        AIChannels = AIs(0) + ":" + AIs(3)
        DIChannels = DIs(0) + ":" + DIs(7)
        DOChannels = DOs(0) + ":" + DOs(7)
        DataLog.DevSerialNumber = DevSerialNumber

        GuiUtil.DisplayStatusLine "Loading Transducer Offsets"
        sFailInfo = ""
        'ReadPVTTransducerValuesFromFile
        'SSP, 16May2019: add catch exception to do retry
        Try
            sErrLine = CallersLine(-1)
            ReadPVTTransducerValuesFromDatabase(DevSerialNumber)
        Catch
            sErrLine = CallersLine(-1)
            ReadPVTTransducerValuesFromDatabase(DevSerialNumber)
        End Try

        Try
            sErrLine = CallersLine(-1)
            CalculateTransducerOffsets
        Catch
            sErrLine = CallersLine(-1)
            CalculateTransducerOffsets
        End Try

        sErrLine = CallersLine(-1)
        NIDAQ.SetGainsOffsets(TransducerGains, TransducerOffsets)
        If DEBUG_MODE Then TestTransducerOffsets

        sErrLine = CallersLine(-1)
        If Not ResetCarriageHome(sFailInfo) Then
            bTestResult = False
            sFailInfo = "Fail to Reset Carriage to Home; " & sFailInfo
            EndTest(CIMTestResult.Fail, sFailInfo)
            Exit Try
            'GoTo EndTry
        End If

Retest:
        ' Run Blockage Test
        If RUN_BLOCKAGE_TEST Then
            Display.Text = "Running Blockage Test"
            sErrLine = CallersLine(-1)
            If Not BlockageTest(strErrMsg) Then
                BlockCount = BlockCount + 1
                If BlockCount = 1 Then
                    GoTo Retest
                Else
                    sFailInfo=strErrMsg
                    bTestResult = False
                    GoTo EndTry
                End If
            End If
            Wait .5
        End If

        If LIMIT_CARRIAGE_SPEED Then
            sErrLine = CallersLine(-1)
            printer.cmd_servo_data_set servo_carriage,servo_speed_limit,500
        End If

        Display.Text = "Running Pressure Test"
        sErrLine = CallersLine(-1)
        If Not PressureTest(strErrMsg) Then
            PressCount = PressCount + 1
            If PressCount = 1 Then
                sFailInfo = strErrMsg
                strErrMsg = String.Empty
                If sFailInfo.Contains(FailureMsgs.MaxPressureOutOfRange) Then
                    If Val(DataLog.PressureTestMaxPressureC) < 5 Or Val(DataLog.PressureTestMaxPressureK) < 5 Or _
                       Val(DataLog.PressureTestMaxPressureM) < 5 Or Val(DataLog.PressureTestMaxPressureY) < 5 Then
                        sErrLine = CallersLine(-1)
                        If Not ReinsertPVT(strErrMsg) Then
                            sFailInfo = sFailInfo + strErrMsg
                            bTestResult = False
                            GoTo EndTry
                        End If
                    Else
                        'SSP, 2Nov2018 - trigger Engineer to replace tool if the pressure > 200
                        If Val(DataLog.PressureTestMaxPressureC) > 200 Or Val(DataLog.PressureTestMaxPressureK) > 200 Or _
                        Val(DataLog.PressureTestMaxPressureM) > 200 Or Val(DataLog.PressureTestMaxPressureY) > 200 Then
                            GUIUtil.DisplayUserPrompt "Pressure Test Failed: " & vbCrLf & sFailInfo & _
                                                            vbCrLf & TestMsgs.ReplaceTool
                        End If
                        sFailInfo = sFailInfo + strErrMsg
                        bTestResult = False
                        GoTo EndTry
                    End If
                End If
                'If Not ResetCarriageHome(strErrMsg) Then
                '    sFailInfo=sFailInfo+strErrMsg
                '    GoTo FailureHandler
                'End If
                GoTo Retest
            Else
                sFailInfo = sFailInfo + strErrMsg
                bTestResult = False
                GoTo EndTry
            End If
        End If

        'SSP, 16May2019: Check the difference between the 4 pressure max values are not greater than 5
        'AS, 2DEC2020: Always check difference of pressure between CMYK. Requested by BH
        sErrLine = CallersLine(-1)
        MaxMinVal = FindMaxMinDiff(DataLog.PressureTestMaxPressureC, DataLog.PressureTestMaxPressureK, _
                                   DataLog.PressureTestMaxPressureM, DataLog.PressureTestMaxPressureY)
        If MaxMinVal > 5 Then
            'Alert Engineer to attend to the PVT Tool or PC
            GuiUtil.DisplayUserPrompt "Test failed the check for difference between the 4 PressureTestMax values. Expected < 5. Computed: " & _
                                        MaxMinVal + vbCrLf + "PLEASE ALERT QC ENGINEER TO CHECK THE PVT TOOL or PC"
            sFailInfo= "Test failed the check for difference between the 4 PressureTestMax values. Expected < 5. Computed: " & MaxMinVal & _
                       " PLEASE ALERT QC ENGINEER TO CHECK THE PVT TOOL or PC"
            MaxPwithinRange = 0
            bTestResult = False
            GoTo EndTry
        End If

        sErrLine = CallersLine(-1)
        If CBool(TestParms.CollectServoMetric) Then CollectPumpServoMetric("PressureTest")

        Display.ShowStatus "Saving data to text file"
        If CBool(TestParms.SaveDataToFile) Then
            sErrLine = CallersLine(-1)
            sSavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\PressureTest.csv"
            'Create any folder required to save data to file
            sErrLine = CallersLine(-1)
            If Dir(sSavePath) = "" Then
                sErrLine = CallersLine(-1)
                CreateFolder sSavePath
            End If

            sErrLine = CallersLine(-1)
            ReDim Header(17)
            ReDim Data(17)
            Header = {"printer_id","PressureTestVentRateM","PressureTestVentRateC","PressureTestVentRateY","PressureTestVentRateK", _
                        "PressureTestMaxPressureM","PressureTestMaxPressureC","PressureTestMaxPressureY","PressureTestMaxPressureK", _
                        "PressureTestVentDelayM","PressureTestVentDelayC","PressureTestVentDelayY","PressureTestVentDelayK", _
                        "PressureTestCompSlope","PressureTestVentDelayAvg","PressureTestMaxPressureAvg","PressureTestVentRateAvg"}
            Data = {CStr(RunTime.SerialNumber),DataLog.PressureTestVentRateM,DataLog.PressureTestVentRateC,DataLog.PressureTestVentRateY,DataLog.PressureTestVentRateK, _
                        DataLog.PressureTestMaxPressureM,DataLog.PressureTestMaxPressureC,DataLog.PressureTestMaxPressureY,DataLog.PressureTestMaxPressureK, _
                        DataLog.PressureTestVentDelayM,DataLog.PressureTestVentDelayC,DataLog.PressureTestVentDelayY,DataLog.PressureTestVentDelayK, _
                        DataLog.PressureTestCompSlope,DataLog.PressureTestVentDelayAvg,DataLog.PressureTestMaxPressureAvg,DataLog.PressureTestVentRateAvg}

            sErrLine = CallersLine(-1)
            SaveData sSavePath,Header,Data
        End If

        Display.Text = "Running Decay Test"
        'SSP, 16May2019: add catch exception for "Array Index Out Of Range" to append message
        Try
            sErrLine = CallersLine(-1)
            If Not DecayTest(strErrMsg) Then
                DecayCount = DecayCount + 1
                If DecayCount = 1 Then
                    GoTo Retest
                Else
                    sFailInfo = sFailInfo & strErrMsg
                    bTestResult = False
                    GoTo EndTry
                End If
            End If

        Catch
        'Catch ex1 As Exception
            'If ex1.Message.ToUpper.Contains("ARRAY INDEX OUT OF RANGE") Then
            If Err.Description.ToUpper.Contains("ARRAY INDEX OUT OF RANGE") Then
                'Alert Engineer to attend to the PVT Tool or PC
                'GUIUtil.DisplayUserPrompt "Exception encountered: " & ex1.Message & vbCrLf & "PLEASE ALERT QC ENGINEER TO CHECK THE PVT TOOL or PC"
                GUIUtil.DisplayUserPrompt "Exception encountered: " & Err.Description & vbCrLf & vbCrLf & "PLEASE ALERT QC ENGINEER TO CHECK THE PVT TOOL or PC"
            End If
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, "Exception encountered in DecayTest. " & Err.Description
            'EndTest(CIMTestResult.Exception, ex1.Message + ";" + "Please alert QC Engineer to attend to the PVT Tool or PC." + ReturnErrLineNumber(sErrLine) + ";" + DataLog.ResultInfo)
            'Exit Sub
        End Try

        sErrLine = CallersLine(-1)
        CollectPumpServoMetric("DecayTest")

        Display.ShowStatus "Saving data to text file"
        If CBool(TestParms.SaveDataToFile) Then
            ReDim Header(16)
            ReDim Data(16)
            sErrLine = CallersLine(-1)
            sSavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\DecayTest.csv"
            'Create any folder required to save data to file
            sErrLine = CallersLine(-1)
            If Dir(sSavePath) = "" Then
                sErrLine = CallersLine(-1)
                CreateFolder sSavePath
            End If

            sErrLine = CallersLine(-1)
            Header = {"printer_id","DecayTestStartDecayPressureM","DecayTestStartDecayPressureC","DecayTestStartDecayPressureY","DecayTestStartDecayPressureK", _
                        "DecayTestDecayM","DecayTestDecayC","DecayTestDecayY","DecayTestDecayK", _
                        "DecayTestVentRateM","DecayTestVentRateC","DecayTestVentRateY","DecayTestVentRateK", _
                        "DecayTestStartDecayPressureAvg","DecayTestDecayAvg","DecayTestVentRateAvg"}
            Data = {CStr(RunTime.SerialNumber),DataLog.DecayTestStartDecayPressureM,DataLog.DecayTestStartDecayPressureC,DataLog.DecayTestStartDecayPressureY,DataLog.DecayTestStartDecayPressureK, _
                        DataLog.DecayTestDecayM,DataLog.DecayTestDecayC,DataLog.DecayTestDecayY,DataLog.DecayTestDecayK, _
                        DataLog.DecayTestVentRateM,DataLog.DecayTestVentRateC,DataLog.DecayTestVentRateY,DataLog.DecayTestVentRateK, _
                        DataLog.DecayTestStartDecayPressureAvg,DataLog.DecayTestDecayAvg,DataLog.DecayTestVentRateAvg}

            sErrLine = CallersLine(-1)
            SaveData sSavePath,Header,Data
        End If


        ' Running Pressure Test with Pump Time = 750
        sErrLine = CallersLine(-1)
        If Not PressureTestDC(750,strErrMsg) Then
            sFailInfo = sFailInfo + strErrMsg
            bTestResult = False
            GoTo EndTry
        End If

        If LIMIT_CARRIAGE_SPEED Then '20160121_HK: Updated based on May Lee request
            sErrLine = CallersLine(-1)
            printer.cmd_servo_data_set servo_carriage,servo_speed_limit,0
        End If

        If TestParms.RunGraphGenerator Then
            Dim sResp As String
            Display.Text = "Running PVTPostProcess.exe to generate result graphs"

            sErrLine = CallersLine(-1)
            sResp = GenerateGraph()
    
            If sResp = "True" Then
                bTestResult = True
    			GoTo EndTry
    		ElseIf sResp = "Retry" Then
                bTestResult = False
                GoTo Retest
            Else
                bTestResult = False
                GoTo EndTry
    		End If
        Else
            Display.StatusBar = "Skipping PVTPostProcess.exe to generate result graphs"
        End If

EndTry:
        '20171016_HK: Add this to prevent BEA GPE error during capping
        sErrLine = CallersLine(-1)
        Printer.flow_carriage_engage_pump()
        sErrLine = CallersLine(-1)
        Printer.flow_service_move_abs(service_station_disengage_speed_0,
                              service_station_pre_disengage_pos, False, False,,60)
        If UCase(GlobalObjects.Item("UdwSealed")) = "TRUE" Then
            Wait 3     'needed for timing issue on sealed unit
        End If
        sErrLine = CallersLine(-1)
        Printer.flow_service_station_disengage()

        '20171016_HK: Seem that Carriage motor always in stall state after priming test.
        Display.ShowStatus "Setting Carriage Motor to available if it has stalled"
        sErrLine = CallersLine(-1)
        If Printer.cmd_servo_state_get(servo_carriage) = 2 Then
            sErrLine = CallersLine(-1)
            Printer.cmd_servo_state_set servo_carriage, servo_available
        End If

        sErrLine = CallersLine(-1)
        Display.ShowStatus "Switch servo to pick"
        Printer.flow_util_motor_switch_active servo_pick

        ' Screen Max Pressure for Writing System Testing [Marconi PP Only]
        If SCREEN_MAX_PRESSURE Then
            Dim bMeetSpec As Boolean = True
            If Val(DataLog.PressureTestMaxPressureK) < 101.1 Or Val(DataLog.PressureTestMaxPressureK) > 103.7 Then
                bMeetSpec = False
            End If
            If Val(DataLog.PressureTestMaxPressureC) < 101.1 Or Val(DataLog.PressureTestMaxPressureC) > 103.7 Then
                bMeetSpec = False
            End If
            If Val(DataLog.PressureTestMaxPressureM) < 101.1 Or Val(DataLog.PressureTestMaxPressureM) > 103.7 Then
                bMeetSpec = False
            End If
            If Val(DataLog.PressureTestMaxPressureY) < 101.1 Or Val(DataLog.PressureTestMaxPressureY) > 103.7 Then
                bMeetSpec = False
            End If

            If bMeetSpec Then
                Dim sMsg As String = "Max Pressures:"
                sMsg = sMsg & vbCrLf & "Black: " & DataLog.PressureTestMaxPressureK
                sMsg = sMsg & vbCrLf & "Cyan: " & DataLog.PressureTestMaxPressureC
                sMsg = sMsg & vbCrLf & "Magenta: " & DataLog.PressureTestMaxPressureM
                sMsg = sMsg & vbCrLf & "Yellow: " & DataLog.PressureTestMaxPressureY
                sMsg = sMsg & "Please TAG unit as Writing System Selection"

                GUIUtil.DisplayUserPrompt sMsg
            End If
        End If

        ' Process result
        If bTestResult Then
            EndTest(CIMTestResult.Pass)
        Else
'            If LIMIT_CARRIAGE_SPEED Then '20160121_HK: Updated based on May Lee request
'                sErrLine = CallersLine(-1)
'                printer.cmd_servo_data_set servo_carriage,servo_speed_limit,0
'            End If
            EndTest(CIMTestResult.Fail, sFailInfo)
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine, sErrLine)
        ErrUtil.AddData "sScriptVersion,sFailInfo,bTestResult", sScriptVersion, sFailInfo, bTestResult
        ErrUtil.AddData "strErrMsg,DevSerialNumber,ExceptionCount,PressCount,DecayCount,BlockCount,CheckVentDelayCount", 
                         strErrMsg,DevSerialNumber,ExceptionCount,PressCount,DecayCount,BlockCount,CheckVentDelayCount
        ErrUtil.AddData "strRes,intRes,AIs,DIs,DOs,sSavePath,Header,Data,MaxMinVal,InitTries", 
                         strRes,intRes,AIs,DIs,DOs,sSavePath,Header,Data,MaxMinVal,InitTries
        GUIUtil.HandleError(ex)

        'Call the CIMation exception handler
        EndTest(CIMTestResult.Exception, ex.Message)

    Finally
        'Additional setting required for CIMation 2.10.2.0 onward
        REST.WriteReadDelay = 10
        If LIMIT_CARRIAGE_SPEED Then '20160121_HK: Updated based on May Lee request
            Try
                Printer.cmd_servo_data_set servo_carriage,servo_speed_limit,0
            Catch
            End Try
        End If
        Display.StatusBar = ""
        Display.Clear
    End Try

End Sub

Sub ReadPVTTransducerValuesFromFile()
    Dim COLOR As Integer
    Dim TransducerGainsStr As String
    Dim Reader As System.IO.StreamReader
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Reader = New System.IO.StreamReader(RunTime.DataPath + "\PVTTransducerValues.txt")
        sErrLine = CallersLine(-1)
        TransducerGainsStr = Reader.ReadLine
        sErrLine = CallersLine(-1)
        If InStr(TransducerGainsStr, "'") > 0 Then TransducerGainsStr = Trim(Left(TransducerGainsStr, InStr(TransducerGainsStr, "'") - 1))
        sErrLine = CallersLine(-1)
        Reader.Close
        sErrLine = CallersLine(-1)
        For COLOR = 0 To 3
            TransducerGains(COLOR) = Val(Split(TransducerGainsStr, ",")(COLOR))
        Next COLOR
        Exit Sub

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "COLOR,TransducerGainsStr,Reader,sErrLine", 
                             COLOR,TransducerGainsStr,Reader,sErrLine)
        ErrUtil.ReRaiseError(ex)
    End Try
'ErrHandler:
'    Err.Raise -1,, FailureMsgs.BadPVTTransducerValuesFile
End Sub

Sub ReadPVTTransducerValuesFromDatabase(DevSerialNumber As String)

    Dim SerialNumber As String
    Dim Number As Integer
    Dim sSQL As String
    Dim COLOR As Integer
    Dim TransducerGainsStr As String = String.Empty
    Dim Found As Boolean
    Dim sErrLine As String = String.Empty

    Try
        ' 20220524_HK: Old method to trap error, may not be required anymore
        Err.Clear
        Try
            sErrLine = CallersLine(-1)
            Using cn As New OleDbConnection(GetConnectionString())
                sErrLine = CallersLine(-1)
                cn.Open
                sErrLine = CallersLine(-1)
                sSQL = "select * from " & ResultTable & " where DevSerialNumber = '"  + DevSerialNumber + "'"
                Using cmd As New oledbcommand(sSQL, cn)
                    Dim dr As oledbdatareader
                    sErrLine = CallersLine(-1)
                    dr = cmd.ExecuteReader()
                    sErrLine = CallersLine(-1)
                    If dr.Hasrows() Then
                        sErrLine = CallersLine(-1)
                        dr.Read
                        TransducerGains(0) = dr.GetValue(2)  'Rec!m0
                        TransducerGains(1) = dr.GetValue(3)  'Rec!m1
                        TransducerGains(2) = dr.GetValue(4)  'Rec!m2
                        TransducerGains(3) = dr.GetValue(5)  'Rec!m3
                        Found = True
                    End If
                End Using
                sErrLine = CallersLine(-1)
                dr.Close
                sErrLine = CallersLine(-1)
                cn.Close
            End Using
        Catch
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,"Error retrieving Gain from Database; " & Err.Description
        End Try
        ' 20220524_HK: Old method to trap error, may not be required anymore
        If Err.Number <> 0 Then
            GUIUtil.DisplayUserPrompt "Error retrieving Gain from Database"
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,"Error retrieving Gain from Database; " & Err.Description
        End If

        sErrLine = CallersLine(-1)
        If Not Found Then
            sErrLine = CallersLine(-1)
            Using cn1 As New OleDbConnection(GetConnectionString())
                sErrLine = CallersLine(-1)
                cn1.Open
                'TransducerGainsStr = DisplayInputBox("", "Enter the 4 gain values")
                Do
                    'Display.Default.InputBox "Enter the 4 gain values",TransducerGainsStr
                    TransducerGainsStr = InputBox("Enter the 4 Gain Values",vbOkCancel)
                Loop Until TransducerGainsStr <> String.Empty
                For COLOR = 0 To 3
                    TransducerGains(COLOR) = Val(Split(TransducerGainsStr, ",")(COLOR))
                Next COLOR

                sErrLine = CallersLine(-1)
                sSQL = "insert into " & ResultTable & " (DevSerialNumber,Magenta,Cyan,Yellow,Black) values (" + DevSerialNumber + ","+ Str(TransducerGains(0)) + "," + Str(TransducerGains(1))+ "," + Str(TransducerGains(2)) + "," + Str(TransducerGains(3)) + ")"
                sErrLine = CallersLine(-1)
                Dim cmd1 As New oledbcommand(sSQL, cn1)
                sErrLine = CallersLine(-1)
                cmd1.Executenonquery
                sErrLine = CallersLine(-1)
                cn1.close
                If Err.Number <> 0 Then
                    'Err.Raise -1,, Err.Description
                    ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,Err.Description
                End If
            End Using
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "DevSerialNumber,SerialNumber,Number,sSQL,COLOR,sErrLine", _
                            DevSerialNumber,SerialNumber,Number,sSQL,COLOR,sErrLine)
        ErrUtil.AddData(ex, "TransducerGainsStr,Found", _
                            TransducerGainsStr,Found)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub
Sub CalculateTransducerOffsets
    Dim COLOR As Integer
    Dim OffDataV(,) As Double
    Dim Ave() As Double
    Dim sErrMsg As String
    Dim PVTToolDeviceReset As Integer
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        PVTToolDeviceReset = 0

        sErrMsg = ""
        sErrLine = CallersLine(-1)
        NIDAQ.AISamplingRateHz = 1000
        sErrLine = CallersLine(-1)
        NIDAQ.NumberSamples = 1000

ResetPVTTool:
        sErrLine = CallersLine(-1)
        If Not NIDAQ.ReadAnalog(AIChannels, False, OffDataV, sErrMsg) Then
            If counter < 2 Then
                If sErrMsg <> "" Then
                    sErrLine = CallersLine(-1)
                    PVTToolDeviceReset = PVTToolDeviceReset + 1
                    DataLog.PVTToolDeviceReset = PVTToolDeviceReset
                     counter = counter +1
                     GuiUtil.DisplayUserPrompt TestMsgs.ResetPVT
                     GoTo ResetPVTTool
                End If
            End If
            ErrUtil.Check False, ErrorType.ERR_SAVE_ONLY,"NIDAQ.ReadAnalog:" & sErrMsg
            Exit Sub
        End If

        sErrLine = CallersLine(-1)
        If DEBUG_MODE Then LogPressures "OffDataV",OffDataV

        sErrLine = CallersLine(-1)
        FindAveInRange(OffDataV, 0, NIDAQ.NumberSamples - 1, Ave)

        For COLOR = 0 To 3
            sErrLine = CallersLine(-1)
            TransducerOffsets(COLOR) = (TransducerGains(COLOR) * Ave(COLOR))
            sErrLine = CallersLine(-1)
            TransducerOffsets(COLOR) =- TransducerOffsets(COLOR)
        Next

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,OffDataV,Ave,PVTToolDeviceReset,sErrLine", 
                             sErrMsg,COLOR,OffDataV,Ave,PVTToolDeviceReset,sErrLine)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub TestTransducerOffsets
    Dim COLOR As Integer
    Dim OffDataV(,) As Double
    Dim Ave() As Double
    Dim sErrMsg As String
    Dim sErrLine As String = String.Empty

    Try
        sErrMsg = ""
        sErrLine = CallersLine(-1)
        NIDAQ.AISamplingRateHz = 1000
        sErrLine = CallersLine(-1)
        NIDAQ.NumberSamples = 1000
        sErrLine = CallersLine(-1)
        If Not NIDAQ.ReadAnalog(AIChannels, True, OffDataV, sErrMsg) Then
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, "NIDAQ.ReadAnalog:" & sErrMsg
        End If
        sErrLine = CallersLine(-1)
        LogPressures "OffDataP",OffDataV
        sErrLine = CallersLine(-1)
        FindAveInRange(OffDataV, 0, NIDAQ.NumberSamples - 1, Ave)
        sErrLine = CallersLine(-1)
        For COLOR = 0 To 3
            If Abs(Ave(COLOR)) > 0.5 Then
                GuiUtil.DisplayMessage "Offsets is not calculated correctly"
            End If
        Next

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,OffDataV,Ave,sErrLine", _
                            sErrMsg,COLOR,OffDataV,Ave,sErrLine)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Function BlockageTest(ByRef sErrMsg As String) As Boolean
    Dim COLOR As Integer
    Dim Pressures() As Double
    Dim MaxPressures(0 To 3) As Double
    Dim Tmr As Double
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        For COLOR = 0 To 3
            MaxPressures(COLOR) = -999
        Next
        BlockageTest = True
        sErrMsg = ""

        sErrLine = CallersLine(-1)
        Display.ShowStatus "Switch servo to pump"
        printer.flow_util_motor_switch_active servo_pump

        'Move carriage
        'printer.flow_carriage_move_for_present_pens ids_pha_ink_
    	'printer.cmd_motor_wait carriage_motor_, wait_done_

        Display.ShowStatus "Turn on external pump"
        sErrLine = CallersLine(-1)
        ExternalPump (True, True, True, True, sErrMsg)
        'Get Readings for 1 sec.  Must be less than X
        Tmr = Timer
        While Timer - Tmr < 1
            sErrLine = CallersLine(-1)
            If Not NIDAQ.ReadSingleAnalog(AIChannels,True,Pressures,sErrMsg) Then
                ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,"NIDAQ.ReadSingleAnalog:" & sErrMsg
            End If

            For COLOR = 0 To 3
                sErrLine = CallersLine(-1)
                If MaxPressures(COLOR) < Pressures(COLOR) Then
                    MaxPressures(COLOR) = Pressures(COLOR)
                End If
            Next
        End While

        For COLOR = 0 To 3
            sErrLine = CallersLine(-1)
            If MaxPressures(COLOR) < BLOCKAGE_TEST_MIN_PRESSURE Then
                sErrMsg = sErrMsg + vbCrLf + FailureMsgs.BlockageTestFailed & " Color: " + Colors(COLOR)+ FailureMsgs.MinPressureTooLow + Str(Round4(MaxPressures(COLOR)))
                BlockageTest = False
            End If
            sErrLine = CallersLine(-1)
            If MaxPressures(COLOR) > BLOCKAGE_PRESSURE Then
                If InStr(sErrMsg, Colors(COLOR)) = 0 Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.BlockageTestFailed & " Color: " + Colors(COLOR)+ FailureMsgs.MaxPressureTooHigh + Str(Round4(MaxPressures(COLOR)))
                    BlockageTest = False
                End If
            End If
        Next
        Display.ShowStatus "Turn off external pump"
        sErrLine = CallersLine(-1)
        ExternalPump (False, False, False, False, sErrMsg)

        'datalog.BlockageTestPressureM = Round4(MaxPressures(0))
        'datalog.BlockageTestPressureC = Round4(MaxPressures(1))
        'datalog.BlockageTestPressureY = Round4(MaxPressures(2))
        'datalog.BlockageTestPressureK = Round4(MaxPressures(3))

        '******************************************************************************************
        'Wait(40)

    Catch ex As Exception
        BlockageTest = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,Pressures,MaxPressures,Tmr", 
                             sErrMsg,COLOR,Pressures,MaxPressures,Tmr)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Function PressureTest(ByRef sErrMsg As String) As Boolean
    Dim COLOR As Integer
    Dim MaxP() As Double
    Dim TMax() As Long
    Dim TStartRise() As Long
    Dim Pressures(,) As Double
    Dim TStartDecay() As Long
    Dim TStopDecay() As Long
    Dim Decay(0 To 3) As Double
    Dim RiseTimes(0 To 3) As Double
    Dim i As Long
    Dim j As Long
    Dim Index As Long
    Dim prime_reps As Integer
    Dim pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore As Long
    Dim AvePressure(,) As Double
    Dim TCompStartRise() As Long
    Dim TCompStopRise() As Long
    Dim CompPumpSlope As Double
    Dim CompPressures(,) As Double
    Dim MaxCP() As Double
    Dim TCMax() As Long
    Dim Temp As Integer
    Dim PressureTestVentDelay(0 To 3) As Double
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        PressureTest = True
        sErrMsg = ""
        prime_reps = 1

        sErrLine = CallersLine(-1)
        Display.ShowStatus "Switch servo to pump"
        Printer.flow_util_motor_switch_active servo_pump

        Wait .5

        sErrLine = CallersLine(-1)
        If PRESSURE_TEST_START_VENTRATE_PRESSURE > PRESSURE_TEST_MIN_MAX Then
            sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + FailureMsgs.PressureLessStartDecayPressure
            PressureTest = False
            Exit Function
        End If

        Display.ShowStatus "Move carriage to Vent position (around +6mm)"
        sErrLine = CallersLine(-1)
        Printer.flow_carriage_move_to_service_position (carriage_decap_spit_position)
        sErrLine = CallersLine(-1)
        Printer.flow_carriage_wait_until_isnt_moving
        
        ' Start Sampling for 2 sec
        sErrLine = CallersLine(-1)
        NIDAQ.AISamplingRateHz = PRESSURE_TEST_SAMPLINGHZ
        NIDAQ.NumberSamples = PRESSURE_TEST_NUMBERSAMPLES

        sErrLine = CallersLine(-1)
        NIDAQ.ClearReadAnalogAsync

        sErrLine = CallersLine(-1)
        If Not NIDAQ.ReadAnalogAsync(AIChannels, True, sErrMsg) Then
            'Err.Raise -1,, sErrMsg
            ErrUtil.Check False, ErrorType.ERR_SAVE_ONLY,"NIDAQ.ReadAnalogASync:" & sErrMsg
        End If

        ' Turn on unit pump
        i = 0
        While (i < prime_reps)
            i = i + 1
            sErrLine = CallersLine(-1)
            Printer.flow_pen_pump(PRESSURE_TEST_PUMP_TIME,pen_pump_vent_type_carriage, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)
            sErrLine = CallersLine(-1)
            Printer.flow_servo_wait_for_all
        End While
        ' Turn off unit pump

        sErrLine = CallersLine(-1)
        While Not NIDAQ.IsReadAnalogAsyncComplete
            thread.Sleep 50
        End While

        sErrLine = CallersLine(-1)
        If Not NIDAQ.RetrieveReadings(Pressures, sErrMsg) Then
            ErrUtil.Check False, ErrorType.ERR_SAVE_ONLY,"NIDAQ.RetrieveReadings:" & sErrMsg
        End If

        sErrLine = CallersLine(-1)
        If LOG_RAW_DATA Then LogPressures("PressureTest", Pressures())

        Display.ShowStatus "Get and check Max"
        sErrLine = CallersLine(-1)
        FindMaxInRange(Pressures, 0, NIDAQ.NumberSamples - 1, MaxP(), TMax())
        sErrLine = CallersLine(-1)
        FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_VENTRATE_PRESSURE, TStartDecay)
        sErrLine = CallersLine(-1)
        FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, PRESSURE_TEST_STOP_VENTRATE_PRESSURE, TStopDecay)

        For COLOR = 0 To 3
            sErrLine = CallersLine(-1)
            If MaxP(COLOR) < PRESSURE_TEST_MIN_MAX Or MaxP(COLOR) > PRESSURE_TEST_MAX_MAX Then
                sErrMsg = sErrMsg + vbCrLf +FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR)+ FailureMsgs.MaxPressureOutOfRange + Str(Round2(MaxP(COLOR)))
                PressureTest = False
            Else
                sErrLine = CallersLine(-1)
                If TStopDecay(COLOR) = NIDAQ.NumberSamples - 1 Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentRateDroppedTooLate
                    PressureTest = False
                Else
                    sErrLine = CallersLine(-1)
                    Decay(COLOR) = (Pressures(TStopDecay(COLOR), COLOR) - Pressures(TStartDecay(COLOR), COLOR)) / (TStopDecay(COLOR) - TStartDecay(COLOR)) * NIDAQ.AISamplingRateHz
                    If Abs(Decay(COLOR)) < Abs(PRESSURE_TEST_MIN_VENTRATE) Or Abs(Decay(COLOR)) > Abs(PRESSURE_TEST_MAX_VENTRATE) Then
                        sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentRateOutOfRange + Round4(Decay(COLOR))
                        PressureTest = False
                    End If
                End If
            End If
        Next COLOR

        If PressureTest Then           
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(Pressures, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_RISE_PRESSURE, TStartRise)
            For COLOR = 0 To 3
                sErrLine = CallersLine(-1)
                RiseTimes(COLOR) = (TMax(COLOR) - TStartRise(COLOR)) / NIDAQ.AISamplingRateHz
                'Test.AddDatalog "RiseTime_" & COLOR.ToString , CStr(RiseTimes(COLOR))
                PressureTestVentDelay(COLOR) = RiseTimes(COLOR)*1000 - PRESSURE_TEST_PUMP_TIME + RISETIME_OFFSET
                If PressureTestVentDelay(COLOR) < PRESSURE_TEST_MIN_VENT_DELAY Or PressureTestVentDelay(COLOR) > PRESSURE_TEST_MAX_VENT_DELAY Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentdelayOutOfRange + Round4(PressureTestVentDelay(COLOR))
                    PressureTest = False
                End If
            Next COLOR
        End If

        If PressureTest Then
            sErrLine = CallersLine(-1)
            CalcAvePressure(Pressures, 0, NIDAQ.NumberSamples -1, AvePressure)
            ' LinearRegress
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(AvePressure, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_COMPENSATION_PRESSURE, TCompStartRise)
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(AvePressure, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_STOP_COMPENSATION_PRESSURE, TCompStopRise)
            sErrLine = CallersLine(-1)
            CompPumpSlope = FindSlope(AvePressure, TCompStartRise(0), TCompStopRise(0)) * NIDAQ.AISamplingRateHz

            If RUN_PUMP_COMPENSATION_TEST Then
                sErrLine = CallersLine(-1)
                NIDAQ.ClearReadAnalogAsync
                If Not NIDAQ.ReadAnalogAsync(AIChannels, True, sErrMsg) Then
                    ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, "NIDAQ.ReadAnalogAsync: " & sErrMsg
                End If

                ' Turn on unit pump
                i = 0
                While (i < prime_reps)
                    i = i + 1
                    sErrLine = CallersLine(-1)
                    printer.flow_pen_pump((PRESSURE_TEST_NOMINAL_PUMP_SLOPE / CompPumpSlope) * PRESSURE_TEST_PUMP_TIME, pen_pump_vent_type_ss, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)
    
                    'Used For R&D only
                    'printer.flow_pen_pump(COMPENSATION_TEST_PUMP_TIME, pen_pump_vent_type_ss_, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)
    
                    sErrLine = CallersLine(-1)
                    Printer.flow_servo_wait_for_all
                End While

                sErrLine = CallersLine(-1)
                While Not NIDAQ.IsReadAnalogAsyncComplete
                    thread.Sleep 50
                End While
    
                sErrLine = CallersLine(-1)
                If Not NIDAQ.RetrieveReadings(CompPressures, sErrMsg) Then
                    ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, "NIDAQ.RetrieveReadings: " &sErrMsg
                End If

                sErrLine = CallersLine(-1)
                FindMaxInRange(CompPressures, 0, NIDAQ.NumberSamples - 1, MaxCP(), TCMax())

                sErrLine = CallersLine(-1)
                If LOG_RAW_DATA Then LogPressures("CompPressureTest", CompPressures())
            End If
        End If

        'Parameters for GenerateGraph() using PVTPostProcess.exe
        PTGraphLogInfo.Add("Mech2TestPrimingPressure", bTestResult)
        PTGraphLogInfo.Add("maxP_magenta", Round2(MaxP(0)))         'Round2(MaxP(0)
        PTGraphLogInfo.Add("maxP_cyan", Round2(MaxP(1)))            'Round2(MaxP(1))
        PTGraphLogInfo.Add("maxP_yellow", Round2(MaxP(2)))          'Round2(MaxP(2))
        PTGraphLogInfo.Add("maxP_black", Round2(MaxP(3)))           'Round2(MaxP(3))
        PTGraphLogInfo.Add("maxP_within_range", MaxPwithinRange)    'Pass = 1, Fail = 0
        'Pressure Test Results
        PTGraphLogInfo.Add("pressure_vent_delay", Round4(Avg(PressureTestVentDelay)))
        PTGraphLogInfo.Add("pressure_vent_rate", DataLog.PressureTestVentRateAvg)     'Round2(Avg(Decay))
        'Pressure Test Limits
        PTGraphLogInfo.Add("pressure_vent_delay_UL", PRESSURE_TEST_MAX_VENT_DELAY)
        PTGraphLogInfo.Add("pressure_vent_delay_LL", PRESSURE_TEST_MIN_VENT_DELAY)
        PTGraphLogInfo.Add("pressure_vent_rate_UL", PRESSURE_TEST_MAX_VENTRATE)
        PTGraphLogInfo.Add("pressure_vent_rate_LL", PRESSURE_TEST_MIN_VENTRATE)
        'Parameters for Graph Labeling
        PTGraphLogInfo.Add("start_rise_time_magenta", TStartRise(0))
        PTGraphLogInfo.Add("start_rise_time_cyan", TStartRise(1))
        PTGraphLogInfo.Add("start_rise_time_yellow", TStartRise(2))
        PTGraphLogInfo.Add("start_rise_time_black", TStartRise(3))
        PTGraphLogInfo.Add("start_vent_pressure_magenta", Round4(Pressures(TStartDecay(0), 0)))
        PTGraphLogInfo.Add("start_vent_pressure_cyan", Round4(Pressures(TStartDecay(1), 1)))
        PTGraphLogInfo.Add("start_vent_pressure_yellow", Round4(Pressures(TStartDecay(2), 2)))
        PTGraphLogInfo.Add("start_vent_pressure_black", Round4(Pressures(TStartDecay(3), 3)))
        PTGraphLogInfo.Add("stop_vent_pressure_magenta", Round4(Pressures(TStopDecay(0), 0)))
        PTGraphLogInfo.Add("stop_vent_pressure_cyan", Round4(Pressures(TStopDecay(1), 1)))
        PTGraphLogInfo.Add("stop_vent_pressure_yellow", Round4(Pressures(TStopDecay(2), 2)))
        PTGraphLogInfo.Add("stop_vent_pressure_black", Round4(Pressures(TStopDecay(3), 3)))

        sErrLine = CallersLine(-1)
        If LOG_RAW_DATA Then LogPressures("PressureTest", Pressures())

        DataLog.PressureTestVentRateM = Round2(Decay(0))
        DataLog.PressureTestVentRateC = Round2(Decay(1))
        DataLog.PressureTestVentRateY = Round2(Decay(2))
        DataLog.PressureTestVentRateK = Round2(Decay(3))
        DataLog.PressureTestMaxPressureM = Round2(MaxP(0))
        DataLog.PressureTestMaxPressureC = Round2(MaxP(1))
        DataLog.PressureTestMaxPressureY = Round2(MaxP(2))
        DataLog.PressureTestMaxPressureK = Round2(MaxP(3))
        DataLog.PressureTestVentDelayM = Round4(PressureTestVentDelay(0))
        DataLog.PressureTestVentDelayC = Round4(PressureTestVentDelay(1))
        DataLog.PressureTestVentDelayY = Round4(PressureTestVentDelay(2))
        DataLog.PressureTestVentDelayK = Round4(PressureTestVentDelay(3))
        DataLog.PressureTestCompSlope = Round2(CompPumpSlope)

        If RUN_PUMP_COMPENSATION_TEST Then
            'On Error Resume Next
            Temp = UBound(MaxCP)

            sErrLine = CallersLine(-1)
            If Temp = 3 Then
                DataLog.PressureTestMaxCompPressureM = Round2(MaxCP(0))
                DataLog.PressureTestMaxCompPressureC = Round2(MaxCP(1))
                DataLog.PressureTestMaxCompPressureY = Round2(MaxCP(2))
                DataLog.PressureTestMaxCompPressureK = Round2(MaxCP(3))
            End If
        End If

        DataLog.PressureTestVentDelayAvg = Round4(Avg(PressureTestVentDelay))
        DataLog.PressureTestMaxPressureAvg = Round2(Avg(MaxP))
        DataLog.PressureTestVentRateAvg = Round2(Avg(Decay))

        If RUN_PUMP_COMPENSATION_TEST Then
            sErrLine = CallersLine(-1)
            DataLog.PressureTestMaxCompPressureAvg = Round2(Avg(MaxCP))
        End If

        '20171109_HK: Temporary added for data collection in same table
        sErrLine = CallersLine(-1)
        Test.AddDatalog sDatalogName, "_450VentRateM",CStr(Round2(Decay(0)))
        Test.AddDatalog sDatalogName, "_450VentRateC",CStr(Round2(Decay(1)))
        Test.AddDatalog sDatalogName, "_450VentRateY",CStr(Round2(Decay(2)))
        Test.AddDatalog sDatalogName, "_450VentRateK",CStr(Round2(Decay(3)))
        Test.AddDatalog sDatalogName, "_450MaxPressureM",CStr(Round2(MaxP(0)))
        Test.AddDatalog sDatalogName, "_450MaxPressureC",CStr(Round2(MaxP(1)))
        Test.AddDatalog sDatalogName, "_450MaxPressureY",CStr(Round2(MaxP(2)))
        Test.AddDatalog sDatalogName, "_450MaxPressureK",CStr(Round2(MaxP(3)))
        Test.AddDatalog sDatalogName, "_450VentDelayM",CStr(Round4(PressureTestVentDelay(0)))
        Test.AddDatalog sDatalogName, "_450VentDelayC",CStr(Round4(PressureTestVentDelay(1)))
        Test.AddDatalog sDatalogName, "_450VentDelayY",CStr(Round4(PressureTestVentDelay(2)))
        Test.AddDatalog sDatalogName, "_450VentDelayK",CStr(Round4(PressureTestVentDelay(3)))
        Test.AddDatalog sDatalogName, "_450CompSlope",CStr(Round2(CompPumpSlope))
        Test.AddDatalog sDatalogName, "_450VentDelayAvg",CStr(Round4(Avg(PressureTestVentDelay)))
        Test.AddDatalog sDatalogName, "_450MaxPressureAvg",CStr(Round2(Avg(MaxP)))
        Test.AddDatalog sDatalogName, "_450VentRateAvg",CStr(Round2(Avg(Decay)))

    Catch ex As Exception
        PressureTest = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,MaxP,TMax,TStartRise,Pressures,sErrLine", _
                            sErrMsg,COLOR,MaxP,TMax,TStartRise,Pressures,sErrLine)
        ErrUtil.AddData(ex, "TStartDecay,TStopDecay,Decay,RiseTimes,i,j", _
                            TStartDecay,TStopDecay,Decay,RiseTimes,i,j)
        ErrUtil.AddData(ex, "Index,prime_reps,pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore", _
                            Index,prime_reps,pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore)
        ErrUtil.AddData(ex, "AvePressure,TCompStartRise,TCompStopRise,CompPumpSlope", _
                            AvePressure,TCompStartRise,TCompStopRise,CompPumpSlope)
        ErrUtil.AddData(ex, "CompPressures,MaxCP,TCMax,Temp,PressureTestVentDelay", _
                            CompPressures,MaxCP,TCMax,Temp,PressureTestVentDelay)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Function DecayTest(ByRef sErrMsg As String) As Boolean
    Dim COLOR As Integer
    Dim MaxP() As Double
    Dim TMax() As Long
    Dim Pressures(,) As Double
    Dim Pressures2(0 To 3) As Double
    Dim Pressures3(0 To 3) As Double
    Dim Decay(0 To 3) As Double
    Dim TStartSearch As Long
    Dim TStartVentRate() As Long
    Dim TStopVentRate() As Long
    Dim VentRate(0 To 3) As Double
    Dim StartDecayPressureM As Double
    Dim StartDecayPressureC As Double
    Dim StartDecayPressureY As Double
    Dim StartDecayPressureK As Double
    Dim i As Integer
    Dim Index As Long
    Dim prime_reps As Integer
    Dim carriage_off_prime_pos_restore As Long
    Dim pen_pump_post_ss_vent_delay_ms_restore As Long
    Dim pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore As Long
    Dim sErrLine As String = String.Empty

    Try
        DecayTest = True
        sErrMsg = ""
        prime_reps = 1

        sErrLine = CallersLine(-1)
        Display.ShowStatus "Switch servo to pump"
        Printer.flow_util_motor_switch_active servo_pump

        Wait 0.5

        sErrLine = CallersLine(-1)
        If DECAY_TEST_START_VENTRATE_PRESSURE > PRESSURE_TEST_MIN_MAX Then
            sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + FailureMsgs.PressureLessStartDecayPressure
            DecayTest = False
            Exit Function
        End If

        Display.ShowStatus "Move carriage to Vent position (around +6mm)"
        sErrLine = CallersLine(-1)
        carriage_off_prime_pos_restore = printer.cmd_constant_get carriage_off_prime_pos_index
        sErrLine = CallersLine(-1)
        Printer.cmd_constant_set carriage_off_prime_pos_index, DECAY_TEST_CARRIAGE_OFF_PRIME_POS
        sErrLine = CallersLine(-1)
        Printer.flow_carriage_move_to_service_position (carriage_decap_spit_position)
        sErrLine = CallersLine(-1)
        printer.flow_carriage_wait_until_isnt_moving

        'start Sampling for 2 sec
        sErrLine = CallersLine(-1)
        NIDAQ.AISamplingRateHz = DECAY_TEST_SAMPLINGHZ
        sErrLine = CallersLine(-1)
        NIDAQ.NumberSamples = DECAY_TEST_NUMBERSAMPLES

        sErrLine = CallersLine(-1)
        NIDAQ.ClearReadAnalogAsync

        sErrLine = CallersLine(-1)
        If Not NIDAQ.ReadAnalogAsync(AIChannels, True, sErrMsg) Then
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,sErrMsg
        End If

        ' Turn on unit pump
        i = 0
        'On Error GoTo Recover
        Try
            While (i < prime_reps)
                i = i + 1
                sErrLine = CallersLine(-1)
                Printer.flow_pen_pump DECAY_TEST_PUMP_TIME,pen_pump_vent_type_ss, 
                                        DECAY_TEST_PEN_PUMP_POST_PUMP_DELAY_MS, 
                                        DECAY_TEST_PEN_PUMP_POST_CARRIAGE_VENT_DELAY_MS
                sErrLine = CallersLine(-1)
                Printer.flow_servo_wait_for_all
            End While
        Catch
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, "Exception: Decay Test; flow_pen_pump"
        Finally
            sErrLine = CallersLine(-1)
            Printer.cmd_constant_set carriage_off_prime_pos_index, carriage_off_prime_pos_restore
        End Try

        ' Turn off unit pump

        sErrLine = CallersLine(-1)
        While Not NIDAQ.IsReadAnalogAsyncComplete
            thread.Sleep 50
        End While

        sErrLine = CallersLine(-1)
        If Not NIDAQ.RetrieveReadings(Pressures, sErrMsg) Then
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,sErrMsg
        End If

        Try
            sErrLine = CallersLine(-1)
            If LOG_RAW_DATA Then LogPressures("DecayTest", Pressures())

            Display.ShowStatus "Get and check Max"
            sErrLine = CallersLine(-1)
            FindMaxInRange(Pressures, 0, NIDAQ.NumberSamples - 1, MaxP(), TMax())
        Catch
            DecayTest = False
            Exit Function
        End Try

        DataLog.DecayTestMaxPressureM = CStr(Round2(MaxP(0)))
        DataLog.DecayTestMaxPressureC = CStr(Round2(MaxP(1)))
        DataLog.DecayTestMaxPressureY = CStr(Round2(MaxP(2)))
        DataLog.DecayTestMaxPressureK = CStr(Round2(MaxP(3)))

        For COLOR = 0 To 3
            'If MaxP(COLOR) < DECAY_TEST_MIN_MAX Or MaxP(COLOR) > DECAY_TEST_MAX_MAX Then
            '    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + " Color: " + Colors(COLOR)+ FailureMsgs.MaxPressureOutOfRange + Str(MaxP(COLOR))
            '    DecayTest = False
            'Else
                sErrLine = CallersLine(-1)
                If (TMax(COLOR) + DECAY_TEST_STOP_DECAY * NIDAQ.AISamplingRateHz + DECAY_TEST_AVERAGING) >= NIDAQ.NumberSamples Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.HitMaxTooLate
                    DecayTest = False
                Else
                    sErrLine = CallersLine(-1)
                    Index = TMax(COLOR) + DECAY_TEST_START_DECAY * NIDAQ.AISamplingRateHz
                    sErrLine = CallersLine(-1)
                    Pressures2(COLOR) = ComputeAverage(Pressures, COLOR, Index, DECAY_TEST_AVERAGING)
                    sErrLine = CallersLine(-1)
                    Index = TMax(COLOR) + DECAY_TEST_STOP_DECAY * NIDAQ.AISamplingRateHz
                    sErrLine = CallersLine(-1)
                    Pressures3(COLOR) = ComputeAverage(Pressures, COLOR, Index, DECAY_TEST_AVERAGING)
                    sErrLine = CallersLine(-1)
                    Decay(COLOR) = (Pressures3(COLOR) - Pressures2(COLOR)) / (DECAY_TEST_STOP_DECAY - DECAY_TEST_START_DECAY)
                    If Decay(COLOR) > DECAY_TEST_MIN_DECAY Or Decay(COLOR) < DECAY_TEST_MAX_DECAY Then
                        sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentRateOutOfRange + Round4(Decay(COLOR))
                        DecayTest = False
                    End If
                End If
            'End If
        Next COLOR

        If DecayTest Then
            sErrLine = CallersLine(-1)
            FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, DECAY_TEST_START_VENTRATE_PRESSURE, TStartVentRate)
            sErrLine = CallersLine(-1)
            FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, DECAY_TEST_STOP_VENTRATE_PRESSURE, TStopVentRate)
    
            sErrLine = CallersLine(-1)
            For COLOR = 0 To 3
                If TStopVentRate(COLOR) = NIDAQ.NumberSamples - 1 Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + " Color: " + Colors(COLOR) + " Decay dropped to late."
                    DecayTest = False
                Else
                    sErrLine = CallersLine(-1)
                    VentRate(COLOR) = (Pressures(TStopVentRate(COLOR), COLOR) - Pressures(TStartVentRate(COLOR), COLOR)) / (TStopVentRate(COLOR) - TStartVentRate(COLOR)) * NIDAQ.AISamplingRateHz
                    If Abs(VentRate(COLOR)) < Abs(DECAY_TEST_MIN_VENTRATE) Or Abs(VentRate(COLOR)) > Abs(DECAY_TEST_MAX_VENTRATE) Then
                        sErrMsg = sErrMsg + vbCrLf + FailureMsgs.DecayTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentrateOfOfRange + Round4(VentRate(COLOR))
                        DecayTest = False
                    End If
                End If
            Next COLOR
            sErrLine = CallersLine(-1)
            StartDecayPressureM = Pressures2(0)
            StartDecayPressureC = Pressures2(1)
            StartDecayPressureY = Pressures2(2)
            StartDecayPressureK = Pressures2(3)
            sErrLine = CallersLine(-1)
            If StartDecayPressureM < DECAY_TEST_MIN_START_DECAY_PRESSURE Then
                sErrMsg = sErrMsg + vbCrLf + FailureMsgs.StartDecayPressureTooLow + " Magenta"
                DecayTest = False
            End If
            sErrLine = CallersLine(-1)
            If StartDecayPressureC < DECAY_TEST_MIN_START_DECAY_PRESSURE Then
                sErrMsg = sErrMsg + vbCrLf + FailureMsgs.StartDecayPressureTooLow + " Cyan"
                DecayTest = False
            End If
            sErrLine = CallersLine(-1)
            If StartDecayPressureY < DECAY_TEST_MIN_START_DECAY_PRESSURE Then
                sErrMsg = sErrMsg + vbCrLf + FailureMsgs.StartDecayPressureTooLow + " Yellow"
                DecayTest = False
            End If
            sErrLine = CallersLine(-1)
            If StartDecayPressureK < DECAY_TEST_MIN_START_DECAY_PRESSURE Then
                sErrMsg = sErrMsg + vbCrLf + FailureMsgs.StartDecayPressureTooLow + " Black"
                DecayTest = False
            End If
        End If

        'Parameters for GenerateGraph() using PVTPostProcess.exe
        DTGraphLogInfo.Add("Mech2TestPrimingPressure", bTestResult)
        'Decay Test Result
        DTGraphLogInfo.Add("decay_rate", DECAY_TEST_MIN_DECAY)  'Decay(COLOR)
        DTGraphLogInfo.Add("decay_vent_rate", DataLog.DecayTestVentRateAvg)
        'Decay Test Result
        DTGraphLogInfo.Add("decay_rate_UL", DECAY_TEST_MIN_DECAY)
        DTGraphLogInfo.Add("decay_rate_LL", DECAY_TEST_MAX_DECAY)
        DTGraphLogInfo.Add("decay_vent_rate_UL", DECAY_TEST_MAX_VENTRATE)
        DTGraphLogInfo.Add("decay_vent_rate_LL", DECAY_TEST_MIN_VENTRATE)
        'Parameters for Graph Labeling
        DTGraphLogInfo.Add("start_decay_magenta", Round4(Pressures2(0)))
        DTGraphLogInfo.Add("start_decay_cyan", Round4(Pressures2(1)))
        DTGraphLogInfo.Add("start_decay_yellow", Round4(Pressures2(2)))
        DTGraphLogInfo.Add("start_decay_black", Round4(Pressures2(3)))
        DTGraphLogInfo.Add("stop_decay_magenta", Round4(Pressures3(0)))
        DTGraphLogInfo.Add("stop_decay_cyan", Round4(Pressures3(1)))
        DTGraphLogInfo.Add("stop_decay_yellow", Round4(Pressures3(2)))
        DTGraphLogInfo.Add("stop_decay_black", Round4(Pressures3(3)))
        DTGraphLogInfo.Add("start_vent_magenta", Round4(Pressures(TStartVentRate(0), 0)))
        DTGraphLogInfo.Add("start_vent_cyan", Round4(Pressures(TStartVentRate(1), 1)))
        DTGraphLogInfo.Add("start_vent_yellow", Round4(Pressures(TStartVentRate(2), 2)))
        DTGraphLogInfo.Add("start_vent_black", Round4(Pressures(TStartVentRate(3), 3)))
        DTGraphLogInfo.Add("stop_vent_magenta", Round4(Pressures(TStopVentRate(0), 0)))
        DTGraphLogInfo.Add("stop_vent_cyan", Round4(Pressures(TStopVentRate(1), 1)))
        DTGraphLogInfo.Add("stop_vent_yellow", Round4(Pressures(TStopVentRate(2), 2)))
        DTGraphLogInfo.Add("stop_vent_black", Round4(Pressures(TStopVentRate(3), 3)))

        sErrLine = CallersLine(-1)
        If LOG_RAW_DATA Then LogPressures("DecayTest", Pressures())

        sErrLine = CallersLine(-1)
        DataLog.DecayTestStartDecayPressureM = Round2(StartDecayPressureM)
        DataLog.DecayTestStartDecayPressureC = Round2(StartDecayPressureC)
        DataLog.DecayTestStartDecayPressureY = Round2(StartDecayPressureY)
        DataLog.DecayTestStartDecayPressureK = Round2(StartDecayPressureK)
        DataLog.DecayTestDecayM = Round4(Decay(0))
        DataLog.DecayTestDecayC = Round4(Decay(1))
        DataLog.DecayTestDecayY = Round4(Decay(2))
        DataLog.DecayTestDecayK = Round4(Decay(3))
        DataLog.DecayTestVentRateM = Round2(VentRate(0))
        DataLog.DecayTestVentRateC = Round2(VentRate(1))
        DataLog.DecayTestVentRateY = Round2(VentRate(2))
        DataLog.DecayTestVentRateK = Round2(VentRate(3))
        DataLog.DecayTestStartDecayPressureAvg = Round2((StartDecayPressureM + StartDecayPressureC + StartDecayPressureY + StartDecayPressureK) /4)
        DataLog.DecayTestDecayAvg = Round4(Avg(Decay))
        DataLog.DecayTestVentRateAvg = Round2(Avg(VentRate))

        '20171109_HK: Temporary added for data collection in same table
        sErrLine = CallersLine(-1)
        Test.AddDatalog sDatalogName, "_440StartDecayPressureM",CStr(Round2(StartDecayPressureM))
        Test.AddDatalog sDatalogName, "_440StartDecayPressureC",CStr(Round2(StartDecayPressureC))
        Test.AddDatalog sDatalogName, "_440StartDecayPressureY",CStr(Round2(StartDecayPressureY))
        Test.AddDatalog sDatalogName, "_440StartDecayPressureK",CStr(Round2(StartDecayPressureK))
        Test.AddDatalog sDatalogName, "_440DecayM",CStr(Round4(Decay(0)))
        Test.AddDatalog sDatalogName, "_440DecayC",CStr(Round4(Decay(1)))
        Test.AddDatalog sDatalogName, "_440DecayY",CStr(Round4(Decay(2)))
        Test.AddDatalog sDatalogName, "_440DecayK",CStr(Round4(Decay(3)))
        Test.AddDatalog sDatalogName, "_440VentRateM",CStr(Round2(VentRate(0)))
        Test.AddDatalog sDatalogName, "_440VentRateC",CStr(Round2(VentRate(1)))
        Test.AddDatalog sDatalogName, "_440VentRateY",CStr(Round2(VentRate(2)))
        Test.AddDatalog sDatalogName, "_440VentRateK",CStr(Round2(VentRate(3)))
        Test.AddDatalog sDatalogName, "_440StartDecayPressureAvg",CStr(Round2((StartDecayPressureM + StartDecayPressureC + StartDecayPressureY + StartDecayPressureK) /4))
        Test.AddDatalog sDatalogName, "_440DecayAvg",CStr(Round4(Avg(Decay)))
        Test.AddDatalog sDatalogName, "_440VentRateAvg",CStr(Round2(Avg(VentRate)))

        Exit Function
'Recover:
'        sErrMsg = Err.Description
        'printer.cmd_constant_set pen_pump_post_pump_delay_ms_index, pen_post_pump_delay_ms_restore
'        printer.cmd_constant_set carriage_off_prime_pos_index, carriage_off_prime_pos_restore
        'printer.cmd_constant_set pen_pump_post_ss_vent_delay_ms_index, pen_pump_post_ss_vent_delay_ms_restore
        'GSS printer.cmd_constant_set(pen_pump_post_ss_vent_post_crg_disengage_delay_ms_index, pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore)
'        Err.Raise -1,, sErrMsg

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
'        Try
'            Printer.cmd_constant_set carriage_off_prime_pos_index, carriage_off_prime_pos_restore
'        Catch
'        End Try
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,MaxP,TMax,Pressures,Pressures2,Pressures3", 
                             sErrMsg,COLOR,MaxP,TMax,Pressures,Pressures2,Pressures3)
        ErrUtil.AddData(ex, "Decay,TStartSearch,TStartVentRate,TStopVentRate,VentRate", 
                             Decay,TStartSearch,TStartVentRate,TStopVentRate,VentRate)
        ErrUtil.AddData(ex, "StartDecayPressureM,StartDecayPressureC,StartDecayPressureY,StartDecayPressureK", 
                             StartDecayPressureM,StartDecayPressureC,StartDecayPressureY,StartDecayPressureK)
        ErrUtil.AddData(ex, "i,index,prime_reps,carriage_off_prime_pos_restore,pen_pump_post_ss_vent_delay_ms_restore", 
                             i,Index,prime_reps,carriage_off_prime_pos_restore,pen_pump_post_ss_vent_delay_ms_restore)
        ErrUtil.AddData(ex, "pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore", 
                             pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Sub ConvertToPressure(DataIn() As Double,ByRef DataOut()As Double)
    Dim COLOR As Integer
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        For COLOR = 0 To 3
            sErrLine = CallersLine(-1)
            DataOut(COLOR) = -TransducerOffsets(COLOR) + TransducerGains(COLOR) * DataIn(COLOR)
        Next COLOR

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "DataIn,DataOut,Color", 
                             DataIn,DataOut,COLOR)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub ExternalPump(State0 As Boolean, State1 As Boolean, State2 As Boolean, State3 As Boolean, sErrMsg As String)
    Dim PumpOnOff(0 To 7) As Boolean
    Dim Index As Integer
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        PumpOnOff(0) = State0
        PumpOnOff(1) = State1
        PumpOnOff(2) = State2
        PumpOnOff(3) = State3
        sErrLine = CallersLine(-1)
        For Index = 4 To 7
            PumpOnOff(Index) = False
        Next Index

        sErrLine = CallersLine(-1)
        If Not NIDAQ.WriteDigital(AIChannels, PumpOnOff, sErrMsg) Then
            'Err.Raise -1,, sErrMsg
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,sErrMsg
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "State0,State1,State2,State3,PumpOnOff,Index", 
                             State0,State1,State2,State3,PumpOnOff,Index)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub FindMaxInRange(ChannelData(,) As Double, First As Integer, Last As Integer, ByRef Max() As Double, ByRef TMax() As Long)
    Dim i As Long, Color As Integer
    Dim Upper As Integer
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Upper = UBound(ChannelData, 2)
        sErrLine = CallersLine(-1)
        ReDim Max(0 To Upper)
        sErrLine = CallersLine(-1)
        ReDim TMax(0 To Upper)

        For COLOR = 0 To Upper
            sErrLine = CallersLine(-1)
            Max(COLOR) = -1e10
        Next COLOR
        For i = First To Last
            For COLOR = 0 To Upper
                If Max(COLOR) < ChannelData(i, COLOR) Then
                    sErrLine = CallersLine(-1)
                    Max(COLOR) = ChannelData(i, COLOR)
                    sErrLine = CallersLine(-1)
                    TMax(COLOR) = i
                End If
            Next COLOR
        Next i

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        AddInfoToGlobalObject("Upper",Upper.ToString)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "ChannelData,First,Last,Max,TMax,Color,i,Upper", 
                             ChannelData,First,Last,Max,TMax,Color,i,Upper)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub FindFirstExceedValueInRange(ChannelData(,) As Double, First As Long, Last As Long, Value As Double, ByRef T() As Long)
    Dim i As Long, Color As Integer
    Dim Upper As Integer
    Dim Found As Boolean
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Upper = UBound(ChannelData, 2)
        ReDim T(0 To Upper)

        sErrLine = CallersLine(-1)
        For COLOR = 0 To Upper
            Found = False
            T(COLOR) = Last
            i = First
            sErrLine = CallersLine(-1)
            While Not Found And i < Last
                If ChannelData(i, COLOR) > Value Then
                    Found = True
                    T(COLOR) = i
                End If
                i = i + 1
            End While
        Next COLOR

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "ChannelData,First,Last,Value,T,Color,i,Upper,Found", 
                             ChannelData,First,Last,Value,T,Color,i,Upper,Found)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub FindFirstBelowValueInRange(ChannelData(,) As Double, First() As Long, Last As Long, Value As Double, ByRef T() As Long)
    Dim i As Long, Color As Integer
    Dim Upper As Integer
    Dim Found As Boolean
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Upper = UBound(ChannelData, 2)
        ReDim T(0 To Upper)

        sErrLine = CallersLine(-1)
        For COLOR = 0 To Upper
            Found = False
            T(COLOR) = Last
            i = First(COLOR)
            While Not Found And i < Last
                sErrLine = CallersLine(-1)
                If ChannelData(i, COLOR) < Value Then
                    Found = True
                    T(COLOR) = i
                End If
                i = i + 1
            End While
        Next COLOR

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "ChannelData,First,Last,Value,T,Color,i,Upper,Found", 
                             ChannelData,First,Last,Value,T,COLOR,i,Upper,Found)
        ErrUtil.ReRaiseError(ex)
    End Try

End Sub

Sub FindAveInRange(ChannelData(,) As Double, First As Integer, Last As Integer, ByRef Ave() As Double)
    Dim i As Long, Color As Integer
    Dim Upper As Integer
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Upper = UBound(ChannelData, 2)
        ReDim Ave(0 To Upper)

        sErrLine = CallersLine(-1)
        For i = First To Last
            For COLOR = 0 To Upper
                sErrLine = CallersLine(-1)
                Ave(COLOR) = Ave(COLOR) + ChannelData(i, COLOR)
            Next COLOR
        Next i

        sErrLine = CallersLine(-1)
        For COLOR = 0 To Upper
            sErrLine = CallersLine(-1)
            Ave(COLOR) = Ave(COLOR) / (Last - First + 1)
        Next COLOR

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "ChannelData,First,Last,Ave,Color,i,Upper", 
                             ChannelData,First,Last,Ave,COLOR,i,Upper)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub CalcAvePressure(Pressures(,) As Double, First As Long, Last As Long, ByRef AvePressure(,) As Double)
    Dim Color As Integer
    Dim i As Long
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        ReDim AvePressure(First To Last, 0 To 0)
        For i = First To Last - 1
            sErrLine = CallersLine(-1)
            AvePressure(i, 0) = (Pressures(i, 0) + Pressures(i, 1) + Pressures(i, 2) + Pressures(i, 3)) / 4
        Next i

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "Pressures,First,Last,AvePressure,Color,i", 
                             Pressures,First,Last,AvePressure,Color,i)
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Function FindSlope(AvePressure(,) As Double, First As Long, Last As Long)
    Dim SumX As Double
    Dim SumY As Double
    Dim SumXY As Double
    Dim SumX2 As Double
    Dim i As Long
    Dim N As Long
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        N = Last - First + 1
        For i = First To Last
            sErrLine = CallersLine(-1)
            SumX = SumX + i
            SumY = SumY + AvePressure(i, 0)
            SumXY  = SumXY + i * AvePressure(i, 0)
            SumX2 = SumX2 + i * i
        Next i
        sErrLine = CallersLine(-1)
        FindSlope = (N * SumXY - SumX * SumY) / (N * SumX2 - SumX * SumX)

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "AvePressure,First,Last,SumX,SumY,SumXY,SumX2,i,N", 
                             AvePressure,First,Last,SumX,SumY,SumXY,SumX2,i,N)
        ErrUtil.ReRaiseError(ex)
    End Try

End Function

Function Round4(D As Double) As String
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Round4 = Trim(Str(Format(D, ".0000")))

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "D", D)
        ErrUtil.ReRaiseError(ex)
    End Try

End Function

Function Round2(D As Double) As String
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Round2 = Trim(Str(Format(D, ".00")))

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "D", D)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Sub LogPressures(Test$, Pressures(,) As Double)
    Dim Writer As System.IO.StreamWriter
    Dim S As String, i As Long
    Dim SavePath As String
    Dim Dt As String
    Dim sFileName As String
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        Dt = Format(Now,"yyyy_MM_dd_HH_mm_ss")
        sFileName = RunTime.ProjectName + "_" + RunTime.StationNumber + "_" + RunTime.SerialNumber + Trim(RunTime.RunNumber) + "_"  + Dt + "_" + Test + ".log"

        sErrLine = CallersLine(-1)
        SavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\" & sFileName
        'Create any folder required to save data to file
        If Dir(SavePath) = "" Then
            sErrLine = CallersLine(-1)
            CreateFolder SavePath
        End If

        sErrLine = CallersLine(-1)
        Writer = New System.IO.StreamWriter(SavePath)
        sErrLine = CallersLine(-1)
        Writer.writeline "SamplingHz: " + Str(NIDAQ.AISamplingRateHz)
        sErrLine = CallersLine(-1)
        Writer.WriteLine "Number Samples: " + Str(NIDAQ.NumberSamples)

        If Test = "PressureTest" Then
            sErrLine = CallersLine(-1)
            For Each PTkvp As KeyValuePair(Of String, Object) In PTGraphLogInfo
                sErrLine = CallersLine(-1)
                S = PTkvp.Key.ToString + ": " + PTkvp.Value.ToString
                Writer.WriteLine S
            Next
        ElseIf Test = "DecayTest" Then
            sErrLine = CallersLine(-1)
            For Each DTkvp As KeyValuePair(Of String, Object) In DTGraphLogInfo
                sErrLine = CallersLine(-1)
                S = DTkvp.Key.ToString + ": " + DTkvp.Value.ToString
                Writer.WriteLine S
            Next
        End If
        Writer.WriteLine ""

        sErrLine = CallersLine(-1)
        Writer.Writeline "Colors: " + Colorstr

        For i = 0 To NIDAQ.NumberSamples - 1
            sErrLine = CallersLine(-1)
            S = Str(i) + "," + Round4(Pressures(i, 0)) + "," + Round4(Pressures(i, 1)) + _
                        "," + Round4(Pressures(i, 2)) + "," + Round4(Pressures(i, 3))
            Writer.writeline S
        Next
        sErrLine = CallersLine(-1)
        Writer.Close

        If CBool(TestParms.blnSaveRawToSharedDrive) Then
            Dim dataLoggingFolder As String
            Dim FactoryParms As ParamSet = RunTime.GetParamSet("FactoryParms")

            sErrLine = CallersLine(-1)
            dataLoggingFolder = FactoryParms.GetParmValue("DataLoggingFolder")
            dataLoggingFolder = dataLoggingFolder & "\" & RunTime.TestName & "\"

            sErrLine = CallersLine(-1)
            If Not Directory.Exists(dataLoggingFolder) Then
                If dataLoggingFolder.ToUpper.Contains("C:\" )Then
                    'Create any folder required to save data to file
                    sErrLine = CallersLine(-1)
                    CreateFolder dataLoggingFolder
                Else
                    GUIUtil.DisplayUserPrompt "Please create folder " & dataLoggingFolder
                End If
            End If

            sErrLine = CallersLine(-1)
            If Directory.Exists(dataLoggingFolder) Then
                FileCopy(SavePath,dataLoggingFolder + "\" + sFileName)
                Wait 1
            Else
                GUIUtil.DisplayUserPrompt dataLoggingFolder & " NOT FOUND. Unable to copy Raw file"
            End If
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "Test,Pressures,Writer,S,SavePath,Dt,sErrLine,sFileName", _
                             Test,Pressures,Writer,S,SavePath,Dt,sErrLine,sFileName)
        ErrUtil.AddData(ex, "dataLoggingFolder,FactoryParms", _
                             dataLoggingFolder,FactoryParms)
        ErrUtil.ReRaiseError(ex)
    End Try

End Sub

Function ComputeAverage(Pressures(,) As Double, 
                        Color As Integer, 
                        Index As Long, 
                        TEST_AVERAGING As Integer) As Double
    Dim i As Integer
    Dim sErrLine As String = String.Empty

    Try
        ComputeAverage = 0
        sErrLine = CallersLine(-1)
        For i = Index - TEST_AVERAGING To Index + TEST_AVERAGING
            sErrLine = CallersLine(-1)
            ComputeAverage = ComputeAverage + Pressures(i, COLOR)
        Next i
        sErrLine = CallersLine(-1)
        ComputeAverage = ComputeAverage / (2 * TEST_AVERAGING + 1)

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "Pressures,Color,Index,TEST_AVERAGING,i", 
                             Pressures,COLOR,Index,TEST_AVERAGING,i)
        ErrUtil.ReRaiseError(ex)
    End Try

End Function

Function Avg(Arr() As Double) As Double
    Dim Color As Integer
    Dim Sum As Double
    Dim sErrLine As String = String.Empty

    Try
        Sum = 0
        sErrLine = CallersLine(-1)
        For COLOR = 0 To 3
            sErrLine = CallersLine(-1)
            Sum = Sum + Arr(COLOR)
        Next COLOR
        sErrLine = CallersLine(-1)
        Avg = Sum / 4

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "Arr,Color,Sum", Arr,COLOR,Sum)
        ErrUtil.ReRaiseError(ex)
    End Try

End Function

Function GetConnectionString() As String
    Dim FactoryParms As ParamSet
    Dim strConnection As String
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        FactoryParms = ParamSets.GetParameterSet("FactoryParms")

        If Win32 Then
            sErrLine = CallersLine(-1)
            strConnection = FactoryParms.GetParmValue("DBConnection")
        Else
            sErrLine = CallersLine(-1)
            strConnection = FactoryParms.GetParmValue("DBConnection64")
        End If

        sErrLine = CallersLine(-1)
        If strConnection.ToUpper().Contains("$PROJECTPATH$") Then
            sErrLine = CallersLine(-1)
            strConnection = strConnection.ToUpper().Replace("$PROJECTPATH$", RunTime.ProjectPath)
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "FactoryParms, strConnection,sErrLine", FactoryParms, strConnection,sErrLine)
        ErrUtil.ReRaiseError(ex)
    End Try

    Return strConnection
End Function

Sub CreateFolder(SavePath As String)
    Dim iIndex As Long
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        iIndex = 1
        Do
            sErrLine = CallersLine(-1)
            iIndex = InStr(iIndex,SavePath,"\")
            If iIndex = 0 Then Exit Do
            sErrLine = CallersLine(-1)
            If Dir(Left(SavePath,iIndex-1),vbDirectory) = "" Then
                display.StatusBar = "Creating Folder: "  & Left(SavePath,iIndex-1)
                sErrLine = CallersLine(-1)
                MkDir Left(SavePath,iIndex-1)
            End If
            iIndex = iIndex + 1
        Loop Until iIndex = 1

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "SavePath,iIndex,sErrLine", SavePath,iIndex,sErrLine)
        ErrUtil.ReRaiseError(ex)

    End Try
End Sub

Function ResetCarriageHome(ByRef sFailInfo As String) As Boolean
    Dim ReflowIndicatingStn As String
    Dim bIsReflow As Boolean, IsTopex As Boolean
    Dim sErrLine As String = String.Empty

    Try
        Display.Text = "Resetting Carriage Home"
        Display.ShowStatus "Uncapping Carriage"
        sErrLine = CallersLine(-1)
        Printer.flow_service_uncap
        sErrLine = CallersLine(-1)
        Printer.flow_servo_wait_for_all

        Display.ShowStatus "Capping Carriage for Reflow Units"
        sErrLine = CallersLine(-1)
        ReflowIndicatingStn = Trim(TestParms.ReflowIndicatingStn)
        If ReflowIndicatingStn = "" Then
            sFailInfo = "Missing definition for Reflow Indicating Station"
            ResetCarriageHome = False
            Exit Function
        End If

        sErrLine = CallersLine(-1)
        bIsReflow = CheckStationTested(RunTime.SerialNumber,ReflowIndicatingStn, _
                                        "Pass",sFailInfo)
        If bIsReflow Then
            sErrLine = CallersLine(-1)
            Printer.flow_service_cap
            sErrLine = CallersLine(-1)
            Printer.flow_servo_wait_for_all
        Else
            Display.StatusBar = "Homing Carriage"
            sErrLine = CallersLine(-1)
            Printer.flow_carriage_home
            sErrLine = CallersLine(-1)
            Printer.flow_carriage_wait_until_isnt_moving
        End If

        Display.ShowStatus "Uncapping Carriage"
        sErrLine = CallersLine(-1)
        Printer.flow_service_uncap
        sErrLine = CallersLine(-1)
        Printer.flow_servo_wait_for_all

        ResetCarriageHome = True

    Catch ex As Exception
        ResetCarriageHome = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sFailInfo,sErrLine,ReflowIndicatingStn,bIsReflow", _
                             sFailInfo,sErrLine,ReflowIndicatingStn,bIsReflow)
        ErrUtil.ReRaiseError(ex)

    End Try
End Function
Private Function CheckStationTested(ByRef sSN As String, 
                                    ByVal sStn As String, 
                                    Optional sStatus As String = "Pass", 
                                    ByRef sFailInfo As String ) As Boolean
    Dim dcnConnection As OleDbConnection
    Dim dcmCommand As OleDbCommand
    Dim drdDataReader As OleDbDataReader
    Dim strSQL As String = String.Empty
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        dcnConnection = New OleDbConnection(Me.GetConnectionString())
        sErrLine = CallersLine(-1)
        dcnConnection.Open()
        strSQL = "SELECT SerialNumber"
        strSQL = strSQL & " FROM inforun(nolock)"
        strSQL = strSQL & " WHERE SerialNumber like '" & sSN & "%'" & " and stationname like '" & _
                            sStn & "%' and Status like '" & sStatus & "'"
        sErrLine = CallersLine(-1)
        dcmCommand = New OleDbCommand(strSQL, dcnConnection)
        sErrLine = CallersLine(-1)
        drdDataReader = dcmCommand.ExecuteReader()
        sErrLine = CallersLine(-1)
        Dim blnRead As Boolean = drdDataReader.Read()
        If blnRead Then
            CheckStationTested = True   'found
        End If                                      'returns true if there were no errors, doesn't matter if it was found

    Catch expCaught As System.Exception
        sFailInfo = Err.Description

    Catch ex As Exception
        CheckStationTested = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sSN,sStn,sStatus,sFailInfo",sSN,sStn,sStatus,sFailInfo)
        ErrUtil.AddData(ex, "dcnConnection,dcmCommand,drdDataReader,strSQL,sErrLine", 
                             dcnConnection,dcmCommand,drdDataReader,strSQL,sErrLine)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Function ReinsertPVT(ByRef sFailInfo As String) As Boolean
    Dim sErrLine As String = String.Empty

    Try
        Display.ShowStatus "Checking Pens lines are turned Off"
        sErrLine = CallersLine(-1)
        If Not(CheckPenVoltagesOff(sFailInfo)) Then
            Display.Text = "Initial check of Pen Line voltage failed" & vbCrLf & sFailInfo
            Display.ShowStatus "Turning off Pen lines"
            sErrLine = CallersLine(-1)
            TurnOffPenLines(False)

            Display.ShowStatus "Checking Again Pen Lines are turned off"
            sFailInfo = ""
            sErrLine = CallersLine(-1)
            If Not(CheckPenVoltagesOff(sFailInfo)) Then
                ReinsertPVT = False
                Return False
            End If
        End If

        Display.ShowStatus "Move carriage to Pen change position"
        sErrLine = CallersLine(-1)
        MoveCarriagePenChangePosition(False)

        Display.ShowStatus "Turn off CARRIAGE_SERVO and other mech related servos"
        sErrLine = CallersLine(-1)
        Printer.flow_servo_wait_for_all
        sErrLine = CallersLine(-1)
        printer.flow_power_turn_motors_off

        Display.ShowStatus "Prompting Operator to insert or remove PVT"
        GUIUtil.DisplayPicture TestParms.picInsertPVTTool
        GuiUtil.DisplayUserPrompt TestMsgs.InsertPVTSupplies

        Display.ShowStatus "Homing Carriage"
        sErrLine = CallersLine(-1)
        printer.flow_carriage_home_helper (carriage_home_state_away_from_ss)

        sErrLine = CallersLine(-1)
        Printer.flow_carriage_wait_until_isnt_moving

        Display.ShowStatus "Uncapping Carriage"
        sErrLine = CallersLine(-1)
        Printer.flow_service_uncap
        sErrLine = CallersLine(-1)
        Printer.flow_servo_wait_for_all

        Return True

    Catch ex As Exception
        ReinsertPVT = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sFailInfo,sErrLine",sFailInfo,sErrLine)
        ErrUtil.ReRaiseError(ex)

    End Try
End Function

Sub SaveData(SavePath As String, Header() As String, Data() As String, Optional delimiter As String = ",")
    Dim i As Integer
    Dim sHeader As String
    Dim sData As String
    Dim fstPath As System.IO.FileStream = Nothing
    Dim swdPathWriter As System.IO.StreamWriter = Nothing
    Dim sErrLine As String = String.Empty

    Try
        sErrLine = CallersLine(-1)
        If Trim(delimiter) = "" Then
            delimiter = ","
        End If

        sErrLine = CallersLine(-1)
        fstPath = New System.IO.FileStream(SavePath, System.IO.FileMode.Append, System.IO.FileAccess.Write)
        sErrLine = CallersLine(-1)
        swdPathWriter = New System.IO.StreamWriter(fstPath)

    '    Open (SavePath) For Append As #1

        sErrLine = CallersLine(-1)
        If(FileLen(SavePath)<= 0) Then
            'Generate Header for new file
            sHeader = Header(0)
            For i = 1 To UBound(Header)
                sHeader = sHeader + delimiter +Header(i)
            Next
            swdPathWriter.WriteLine sHeader
        End If

        'Generate Data
        sErrLine = CallersLine(-1)
        sData = Data(0)
        For i = 1 To UBound(Header)
            sData = sData + delimiter + Data(i)
        Next

        sErrLine = CallersLine(-1)
        swdPathWriter.WriteLine sData
        swdPathWriter.Close()
        fstPath.Close()

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "header,data,SavePath",Header,Data,SavePath)
        ErrUtil.AddData "i,sHeader,sData,fstPath,swdPathWriter", _
                         i,sHeader,sData,fstPath,swdPathWriter
        ErrUtil.ReRaiseError(ex)
    End Try
End Sub

Sub CollectPumpServoMetric(ByVal sPumpMotionName As String )
    Dim sErrLine As String = String.Empty
    Dim TorqueSlewMax As Long
    Dim PWMSlewMax As Long
    Dim TorqueMarginMin As Long
    Dim TimeOfMove As Long
    Dim sSavePath As String
    Dim Header() As String
    Dim Data() As String
    Dim AvgSlewTorque As String

    Try
        ' always switch first to pump servo, before collecting the data, to avoid asserts
        sErrLine = CallersLine(-1)
        printer.flow_util_motor_switch_active(servo_pump)

        sErrLine = CallersLine(-1)
        printer.cmd_servo_move_wait_until_done(servo_pump)

        sErrLine = CallersLine(-1)
        TorqueSlewMax = printer.cmd_servo_metrics_get(servo_pump,torque_slew_max)
        Test.AddDatalog sPumpMotionName + "_TorqueSlewMax",CStr(TorqueSlewMax)

        sErrLine = CallersLine(-1)
        PWMSlewMax = printer.cmd_servo_metrics_get(servo_pump, pwm_slew_max)
        Test.AddDatalog sPumpMotionName + "_PWMSlewMax",CStr(PWMSlewMax)

        sErrLine = CallersLine(-1)
        TorqueMarginMin = printer.cmd_servo_metrics_get(servo_pump, torque_margin_min)
        Test.AddDatalog sPumpMotionName + "_TorqueMarginMin",CStr(TorqueMarginMin)

        sErrLine = CallersLine(-1)
        TimeOfMove = printer.cmd_servo_metrics_get(servo_pump,distance)
        Test.AddDatalog sPumpMotionName + "_TimeOfMove",CStr(TimeOfMove)

        sErrLine = CallersLine(-1)
        AvgSlewTorque = printer.cmd_servo_metrics_get servo_name_t.servo_pump_, servo_metric_enum_t.torque_slew_avg_
        Test.AddDatalog sPumpMotionName + "_AvgSlewTorque",CStr(AvgSlewTorque)

        ' always switch back to pick servo, after collecting the data
        sErrLine = CallersLine(-1)
        printer.flow_util_motor_switch_active (servo_pick)

        'OutputText (" SlewMaxTorque = " & TorqueSlewMax & " milli ounce.inches, Torque_Margin_Min = " & TorqueMarginMin & " milli ounce.inches, SlewMaxPWM = " & PWMSlewMax & " / 511, TimeOfMove = " & TimeOfMove & " counts. ")
        Display.Text = "TorqueSlewMax = " & TorqueSlewMax & " milli ounce.inches "
        Display.Text = "TorqueMarginMin = " & TorqueMarginMin & " milli ounce.inches"
        Display.Text = "PWMSlewMax = " & PWMSlewMax & " / 511"
        Display.Text = "TimeOfMove = " & TimeOfMove & " counts. "
        Display.Text = "AvgSlewTorque = " & AvgSlewTorque

        Display.StatusBar = "Saving data to text file"
        If CBool(TestParms.SaveDataToFile) Then
            ReDim Header(6)
            ReDim Data(6)
            sErrLine = CallersLine(-1)
            sSavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\" & sPumpMotionName & "_Servo.csv"
            'Create any folder required to save data to file
            sErrLine = CallersLine(-1)
            If Dir(sSavePath) = "" Then
                sErrLine = CallersLine(-1)
                CreateFolder sSavePath
            End If

            sErrLine = CallersLine(-1)
            Header = {"printer_id","sPumpMotionName","TorqueSlewMax","TorqueMarginMin","PWMSlewMax","TimeOfMove","AvgSlewTorque"}
            Data = {CStr(RunTime.SerialNumber),sPumpMotionName,TorqueSlewMax.ToString,TorqueMarginMin.ToString, _
                        PWMSlewMax.ToString,TimeOfMove.ToString,AvgSlewTorque.ToString}

            sErrLine = CallersLine(-1)
            SaveData sSavePath,Header,Data
        End If

        If CBool(TestParms.SaveDataToFile) And sPumpMotionName.trim = "PressureTest" Then
            sErrLine = CallersLine(-1)
            sSavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\Pressure_Servo.csv"
            'Create any folder required to save data to file
            sErrLine = CallersLine(-1)
            If Dir(sSavePath) = "" Then
                sErrLine = CallersLine(-1)
                CreateFolder sSavePath
            End If

            sErrLine = CallersLine(-1)
            '2+16+4
            ReDim Header(22)
            ReDim Data(22)

            sErrLine = CallersLine(-1)
            Header = {"printer_id","PumpTime", _
                    "VentRateM","VentRateC","VentRateY","VentRateK", _
                    "MaxPressureM","MaxPressureC","MaxPressureY","MaxPressureK", _
                    "VentDelayM","VentDelayC","VentDelayY","VentDelayK", _
                    "CompSlope","VentDelayAvg","MaxPressureAvg","VentRateAvg", _
                    "TorqueSlewMax","TorqueMarginMin","PWMSlewMax","TimeOfMove","AvgSlewTorque"}
            Data = {CStr(RunTime.SerialNumber),"450", _
                    DataLog.PressureTestVentRateM,DataLog.PressureTestVentRateC,DataLog.PressureTestVentRateY,DataLog.PressureTestVentRateK, _
                    DataLog.PressureTestMaxPressureM,DataLog.PressureTestMaxPressureC,DataLog.PressureTestMaxPressureY,DataLog.PressureTestMaxPressureK, _
                    DataLog.PressureTestVentDelayM,DataLog.PressureTestVentDelayC,DataLog.PressureTestVentDelayY,DataLog.PressureTestVentDelayK, _
                    DataLog.PressureTestCompSlope,DataLog.PressureTestVentDelayAvg,DataLog.PressureTestMaxPressureAvg,DataLog.PressureTestVentRateAvg, _
                    TorqueSlewMax.ToString,TorqueMarginMin.ToString,PWMSlewMax.ToString,TimeOfMove.ToString,AvgSlewTorque.ToString}
            sErrLine = CallersLine(-1)
            SaveData sSavePath,Header,Data
        End If

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrLine,TorqueSlewMax,PWMSlewMax,TorqueMarginMin,TimeOfMove,sPumpMotionName", _
                        sErrLine,TorqueSlewMax,PWMSlewMax,TorqueMarginMin,TimeOfMove,sPumpMotionName)
        ErrUtil.AddData(ex, "sSaveData,Header,Data,AvgSlewTorque",sSavePath,Header,Data,AvgSlewTorque)
        ErrUtil.ReRaiseError(ex)
    End Try

End Sub

'Create new function to perform pressure test at various pump time
Function PressureTestDC(ByVal PumpTime As Long, ByRef sErrMsg As String) As Boolean
    Dim COLOR As Integer
    Dim MaxP() As Double
    Dim TMax() As Long
    Dim TStartRise() As Long
    Dim Pressures(,) As Double
    Dim TStartDecay() As Long
    Dim TStopDecay() As Long
    Dim Decay(0 To 3) As Double
    Dim RiseTimes(0 To 3) As Double
    Dim i As Long
    Dim j As Long
    Dim Index As Long
    Dim prime_reps As Integer
    Dim pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore As Long
    Dim AvePressure(,) As Double
    Dim TCompStartRise() As Long
    Dim TCompStopRise() As Long
    Dim CompPumpSlope As Double
    Dim CompPressures(,) As Double
    Dim MaxCP() As Double
    Dim TCMax() As Long
    Dim Temp As Integer
    Dim PressureTestVentDelay(0 To 3) As Double
    Dim sErrLine As String = String.Empty

    Dim TorqueSlewMax As Long = 0
    Dim PWMSlewMax As Long = 0
    Dim TorqueMarginMin As Long = 0
    Dim TimeOfMove As Long = 0
    Dim sSavePath As String
    Dim Header() As String
    Dim Data() As String
    Dim AvgSlewTorque As String

    Try
        Display.Text = "Running Pressure Test - " + PumpTime.ToString
        sErrLine = CallersLine(-1)
        PressureTestDC = True
        sErrMsg = ""
        prime_reps = 1

        sErrLine = CallersLine(-1)
        Display.ShowStatus "Switch servo to pump"
        Printer.flow_util_motor_switch_active servo_pump

        Wait 0.5

        sErrLine = CallersLine(-1)
        If PRESSURE_TEST_START_VENTRATE_PRESSURE > PRESSURE_TEST_MIN_MAX Then
            sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + FailureMsgs.PressureLessStartDecayPressure
            PressureTestDC = False
            Exit Function
        End If

        ' Move carriage to Vent position (around +6mm)
        Display.StatusBar = "Moving Carriage to Vent Position"
        sErrLine = CallersLine(-1)
        printer.flow_carriage_move_to_service_position (carriage_decap_spit_position)
        sErrLine = CallersLine(-1)
        printer.flow_carriage_wait_until_isnt_moving

        ' Start Sampling for 2 sec
        Display.StatusBar = "Sampling for 2 seconds"
        sErrLine = CallersLine(-1)
        NIDAQ.AISamplingRateHz = PRESSURE_TEST_SAMPLINGHZ
        NIDAQ.NumberSamples = PRESSURE_TEST_NUMBERSAMPLES

        sErrLine = CallersLine(-1)
        NIDAQ.ClearReadAnalogAsync

        sErrLine = CallersLine(-1)
        If Not NIDAQ.ReadAnalogAsync(AIChannels, True, sErrMsg) Then
            'Err.Raise -1,, sErrMsg
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,sErrMsg
        End If

        ' Turn on unit pump
        Display.StatusBar = "Turning on pump"
        i = 0
        While (i < prime_reps)
            i = i + 1

            sErrLine = CallersLine(-1)
            printer.flow_pen_pump(PumpTime,pen_pump_vent_type_carriage, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)

            sErrLine = CallersLine(-1)
            Printer.flow_servo_wait_for_all
'            sErrLine = CallersLine(-1)
'            If Not(CheckMotors(sErrMsg)) Then
'                PressureTest = False
'                GoTo EndRun
'            End If
        End While

        'turn off unit pump

        sErrLine = CallersLine(-1)
        While Not NIDAQ.IsReadAnalogAsyncComplete
            thread.Sleep 50
        End While

        sErrLine = CallersLine(-1)
        If Not NIDAQ.RetrieveReadings(Pressures, sErrMsg) Then
            'Err.Raise -1,, sErrMsg
            ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY,sErrMsg
        End If

        sErrLine = CallersLine(-1)
        'If LOG_RAW_DATA Then LogPressures("PressureTest", Pressures())

        'get and check Max
        Display.StatusBar = "Checking Maximum"
        sErrLine = CallersLine(-1)
        FindMaxInRange(Pressures, 0, NIDAQ.NumberSamples - 1, MaxP(), TMax())
        sErrLine = CallersLine(-1)
        FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_VENTRATE_PRESSURE, TStartDecay)
        sErrLine = CallersLine(-1)
        FindFirstBelowValueInRange(Pressures, TMax(), NIDAQ.NumberSamples - 1, PRESSURE_TEST_STOP_VENTRATE_PRESSURE, TStopDecay)

        For COLOR = 0 To 3
            'If MaxP(COLOR) < PRESSURE_TEST_MIN_MAX Or MaxP(COLOR) > PRESSURE_TEST_MAX_MAX Then
                'sErrMsg = sErrMsg + vbCrLf +FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR)+ FailureMsgs.MaxPressureOutOfRange + Str(MaxP(COLOR))
                'PressureTestDC = False
            'Else
                sErrLine = CallersLine(-1)
                If TStopDecay(COLOR) = NIDAQ.NumberSamples - 1 Then
                    sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentRateDroppedTooLate
                    PressureTestDC = False
                Else
                    sErrLine = CallersLine(-1)
                    Decay(COLOR) = (Pressures(TStopDecay(COLOR), COLOR) - Pressures(TStartDecay(COLOR), COLOR)) / (TStopDecay(COLOR) - TStartDecay(COLOR)) * NIDAQ.AISamplingRateHz
                    'If Abs(Decay(COLOR)) < Abs(PRESSURE_TEST_MIN_VENTRATE) Or Abs(Decay(COLOR)) > Abs(PRESSURE_TEST_MAX_VENTRATE) Then
                        'sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(COLOR) + FailureMsgs.VentRateOutOfRange + Round4(Decay(COLOR))
                        'PressureTestDC = False
                    'End If
                End If
            'End If
        Next COLOR

        sErrLine = CallersLine(-1)
        If PressureTestDC Then      
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(Pressures, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_RISE_PRESSURE, TStartRise)
    
            For COLOR = 0 To 3
                sErrLine = CallersLine(-1)
                RiseTimes(COLOR) = (TMax(COLOR) - TStartRise(COLOR)) / NIDAQ.AISamplingRateHz
                'Test.AddDatalog "RiseTime_" & COLOR.ToString , CStr(RiseTimes(COLOR))
                PressureTestVentDelay(COLOR) = RiseTimes(COLOR)*1000 - PRESSURE_TEST_PUMP_TIME + RISETIME_OFFSET
                'If PressureTestVentDelay(Color) < PRESSURE_TEST_MIN_VENT_DELAY Or PressureTestVentDelay(Color) > PRESSURE_TEST_MAX_VENT_DELAY Then
                    'sErrMsg = sErrMsg + vbCrLf + FailureMsgs.PressureTestFailed + " Color: " + Colors(Color) + FailureMsgs.VentdelayOutOfRange + Round4(PressureTestVentDelay(Color))
                    'PressureTestDC = False
                'End If
            Next COLOR
        End If

        sErrLine = CallersLine(-1)
        If PressureTestDC Then
            Display.StatusBar = "Calculating Average"
            sErrLine = CallersLine(-1)
            CalcAvePressure(Pressures, 0, NIDAQ.NumberSamples -1, AvePressure)
            'LinearRegress
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(AvePressure, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_START_COMPENSATION_PRESSURE, TCompStartRise)
            sErrLine = CallersLine(-1)
            FindFirstExceedValueInRange(AvePressure, 0, NIDAQ.NumberSamples - 1, PRESSURE_TEST_STOP_COMPENSATION_PRESSURE, TCompStopRise)
            sErrLine = CallersLine(-1)
            CompPumpSlope = FindSlope(AvePressure, TCompStartRise(0), TCompStopRise(0)) * NIDAQ.AISamplingRateHz
    
            Display.StatusBar = "Running pump compensation test"
            If RUN_PUMP_COMPENSATION_TEST Then
                sErrLine = CallersLine(-1)
                NIDAQ.ClearReadAnalogAsync
                If Not NIDAQ.ReadAnalogAsync(AIChannels, True, sErrMsg) Then
                    'Err.Raise -1,, sErrMsg
                    ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, sErrMsg
                End If
    
                'turn on unit pump
                Display.StatusBar = "Turning on pump"
                i = 0
                While (i < prime_reps)
                    i = i + 1
                    sErrLine = CallersLine(-1)
                    printer.flow_pen_pump((PRESSURE_TEST_NOMINAL_PUMP_SLOPE / CompPumpSlope) * PRESSURE_TEST_PUMP_TIME, pen_pump_vent_type_ss, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)
    
                    'Used For R&D only
                    'printer.flow_pen_pump(COMPENSATION_TEST_PUMP_TIME, pen_pump_vent_type_ss_, 0, PRESSURE_TEST_PEN_PUMP_POST_SS_VENT_DELAY_MS)
    
                    sErrLine = CallersLine(-1)
                    Printer.flow_servo_wait_for_all
                End While
                sErrLine = CallersLine(-1)
                While Not Not NIDAQ.IsReadAnalogAsyncComplete
                    thread.Sleep 50
                End While
    
                sErrLine = CallersLine(-1)
                If Not NIDAQ.RetrieveReadings(CompPressures, sErrMsg) Then
                    'Err.Raise -1,, sErrMsg
                    ErrUtil.Check False,ErrorType.ERR_SAVE_ONLY, sErrMsg
                End If
    
                sErrLine = CallersLine(-1)
                FindMaxInRange(CompPressures, 0, NIDAQ.NumberSamples - 1, MaxCP(), TCMax())
                sErrLine = CallersLine(-1)
                If LOG_RAW_DATA Then LogPressures("CompPressureTest", CompPressures())
            End If
        End If
        
        sErrLine = CallersLine(-1)
        If LOG_RAW_DATA Then LogPressures("PressureTestDC", Pressures())

        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentRateM",CStr(Round2(Decay(0)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentRateC",CStr(Round2(Decay(1)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentRateY",CStr(Round2(Decay(2)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentRateK",CStr(Round2(Decay(3)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "MaxPressureM",CStr(Round2(MaxP(0)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "MaxPressureC",CStr(Round2(MaxP(1)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "MaxPressureY",CStr(Round2(MaxP(2)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "MaxPressureK",CStr(Round2(MaxP(3)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentDelayM",CStr(Round4(PressureTestVentDelay(0)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentDelayC",CStr(Round4(PressureTestVentDelay(1)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentDelayY",CStr(Round4(PressureTestVentDelay(2)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentDelayK",CStr(Round4(PressureTestVentDelay(3)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "CompSlope",CStr(Round2(CompPumpSlope))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentDelayAvg",CStr(Round4(Avg(PressureTestVentDelay)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "MaxPressureAvg",CStr(Round2(Avg(MaxP)))
        Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "VentRateAvg",CStr(Round2(Avg(Decay)))

        If RUN_PUMP_COMPENSATION_TEST Then
            Temp = UBound(MaxCP)
            If Temp = 3 Then
                Test.AddDatalog "_" + PumpTime.ToString + "MaxCompPressureM",CStr(Round2(MaxCP(0)))
                Test.AddDatalog "_" + PumpTime.ToString + "MaxCompPressureC",CStr(Round2(MaxCP(1)))
                Test.AddDatalog "_" + PumpTime.ToString + "MaxCompPressureY",CStr(Round2(MaxCP(2)))
                Test.AddDatalog "_" + PumpTime.ToString + "MaxCompPressureK",CStr(Round2(MaxCP(3)))
            End If
            Test.AddDatalog "_" + PumpTime.ToString + "MaxCompPressureAvg",CStr(Round2(Avg(MaxCP)))
        End If

        'AS, 10Oct2018 - from PostMP2, removed 750ms checking becasue we run test only 750ms
        'SSP, 4Sep2018 - from MP2, keep only 750ms servo metric data collection, remove 200, 300 & 600
        If CBool(TestParms.CollectServoMetric) Then
            ' always switch first to pump servo, before collecting the data, to avoid asserts
            Display.Text = "Collecting servo metrics - " + PumpTime.ToString
            sErrLine = CallersLine(-1)
            printer.flow_util_motor_switch_active(servo_pump)

            sErrLine = CallersLine(-1)
            printer.cmd_servo_move_wait_until_done(servo_pump)

            sErrLine = CallersLine(-1)
            TorqueSlewMax = printer.cmd_servo_metrics_get(servo_pump,torque_slew_max)
            Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "TorqueSlewMax",CStr(TorqueSlewMax)

            sErrLine = CallersLine(-1)
            PWMSlewMax = printer.cmd_servo_metrics_get(servo_pump, pwm_slew_max)
            Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "PWMSlewMax",CStr(PWMSlewMax)

            sErrLine = CallersLine(-1)
            TorqueMarginMin = printer.cmd_servo_metrics_get(servo_pump, torque_margin_min)
            Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "TorqueMarginMin",CStr(TorqueMarginMin)

            sErrLine = CallersLine(-1)
            TimeOfMove = printer.cmd_servo_metrics_get(servo_pump,distance)
            Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "TimeOfMove",CStr(TimeOfMove)

            sErrLine = CallersLine(-1)
            AvgSlewTorque = printer.cmd_servo_metrics_get servo_name_t.servo_pump_, servo_metric_enum_t.torque_slew_avg_
            Test.AddDatalog sDatalogName, "_" + PumpTime.ToString + "AvgSlewTorque",CStr(AvgSlewTorque)

            ' always switch back to pick servo, after collecting the data
            sErrLine = CallersLine(-1)
            printer.flow_util_motor_switch_active (servo_pick)

            'OutputText (" SlewMaxTorque = " & TorqueSlewMax & " milli ounce.inches, Torque_Margin_Min = " & TorqueMarginMin & " milli ounce.inches, SlewMaxPWM = " & PWMSlewMax & " / 511, TimeOfMove = " & TimeOfMove & " counts. ")
            Display.Text = "TorqueSlewMax = " & TorqueSlewMax & " milli ounce.inches "
            Display.Text = "TorqueMarginMin = " & TorqueMarginMin & " milli ounce.inches"
            Display.Text = "PWMSlewMax = " & PWMSlewMax & " / 511"
            Display.Text = "TimeOfMove = " & TimeOfMove & " counts. "
            Display.Text = "AvgSlewTorque = " & AvgSlewTorque
        End If

        Display.StatusBar = "Saving data to text file"
        If CBool(TestParms.SaveDataToFile) Then
            sErrLine = CallersLine(-1)
            sSavePath = RunTime.ProjectPath & "\Results\" & RunTime.TestName & "\Pressure_Servo.csv"
            'Create any folder required to save data to file
            sErrLine = CallersLine(-1)
            If Dir(sSavePath) = "" Then
                sErrLine = CallersLine(-1)
                CreateFolder sSavePath
            End If

            sErrLine = CallersLine(-1)
            '2+16+4
            ReDim Header(22)
            ReDim Data(22)

            sErrLine = CallersLine(-1)
            Header = {"printer_id","PumpTime", _
                    "VentRateM","VentRateC","VentRateY","VentRateK", _
                    "MaxPressureM","MaxPressureC","MaxPressureY","MaxPressureK", _
                    "VentDelayM","VentDelayC","VentDelayY","VentDelayK", _
                    "CompSlope","VentDelayAvg","MaxPressureAvg","VentRateAvg", _
                    "TorqueSlewMax","TorqueMarginMin","PWMSlewMax","TimeOfMove","AvgSlewTorque"}
            Data = {CStr(RunTime.SerialNumber),PumpTime.ToString, _
                    CStr(Round2(Decay(0))),CStr(Round2(Decay(1))),CStr(Round2(Decay(2))),CStr(Round2(Decay(3))), _
                    CStr(Round2(MaxP(0))),CStr(Round2(MaxP(1))),CStr(Round2(MaxP(2))),CStr(Round2(MaxP(3))), _
                    CStr(Round4(PressureTestVentDelay(0))),CStr(Round4(PressureTestVentDelay(1))),CStr(Round4(PressureTestVentDelay(2))),CStr(Round4(PressureTestVentDelay(3))), _
                    CStr(Round2(CompPumpSlope)),CStr(Round4(Avg(PressureTestVentDelay))),CStr(Round2(Avg(MaxP))),CStr(Round2(Avg(Decay))), _
                    TorqueSlewMax.ToString,TorqueMarginMin.ToString, PWMSlewMax.ToString,TimeOfMove.ToString,AvgSlewTorque.ToString}

            sErrLine = CallersLine(-1)
            SaveData sSavePath,Header,Data
        End If

    Catch ex As Exception
        PressureTestDC = False
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine)
        ErrUtil.AddData(ex, "sErrMsg,Color,MaxP,TMax,TStartRise,Pressures,sErrLine", _
                            sErrMsg,COLOR,MaxP,TMax,TStartRise,Pressures,sErrLine)
        ErrUtil.AddData(ex, "TStartDecay,TStopDecay,Decay,RiseTimes,i,j", _
                            TStartDecay,TStopDecay,Decay,RiseTimes,i,j)
        ErrUtil.AddData(ex, "Index,prime_reps,pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore", _
                            Index,prime_reps,pen_pump_post_ss_vent_post_crg_disengage_delay_ms_restore)
        ErrUtil.AddData(ex, "AvePressure,TCompStartRise,TCompStopRise,CompPumpSlope", _
                            AvePressure,TCompStartRise,TCompStopRise,CompPumpSlope)
        ErrUtil.AddData(ex, "CompPressures,MaxCP,TCMax,Temp,PressureTestVentDelay", _
                            CompPressures,MaxCP,TCMax,Temp,PressureTestVentDelay)
        ErrUtil.AddData(ex, "TorqueSlewMax,PWMSlewMax,TorqueMarginMin,TimeOfMove,sSavePath,Header,Data,AvgSlewTorque", _
                            TorqueSlewMax,PWMSlewMax,TorqueMarginMin,TimeOfMove,sSavePath,Header,Data,AvgSlewTorque)
        ErrUtil.ReRaiseError(ex)
    End Try
End Function

Function FindMaxMinDiff(ByRef Data1 As String, ByRef Data2 As String, ByRef Data3 As String, ByRef Data4 As String) As Double
    Dim MaxVal As Double = Val(Data1)
    Dim MinVal As Double = Val(Data1)
    Dim DiffMaxMin As Double = 0
    Dim sErrLine As String = String.Empty
    Dim i As Integer
    Dim iMax As Integer = 4
    Dim Pressure() As Double = {Val(Data1), Val(Data2), Val(Data3), Val(Data4)}

    Try
        sErrLine = CallersLine(-1)
        For i=1 To iMax-1
            MaxVal = Math.Max(MaxVal, Pressure(i))
            MinVal = Math.Min(MinVal, Pressure(i))
        Next

        sErrLine = CallersLine(-1)
        DiffMaxMin = Abs(MaxVal - MinVal)
        FindMaxMinDiff = DiffMaxMin

        DataLog.MaxPressureCMYK = MaxVal
        DataLog.MinPressureCMYK = MinVal
        DataLog.DiffPressureMaxMin = DiffMaxMin

    Catch ex As Exception
        SaveErrToGlobalObject(sErrLine)
        ErrUtil.LogError(ex, RunTime.TestName & CallersLine(-1), CallersLine, sErrLine)
        ErrUtil.AddData(ex, "Data1,Data2, Data3, Data4, MaxVal, MinVal, DiffMaxMin",
                             Data1,Data2, Data3, Data4, MaxVal, MinVal, DiffMaxMin)
        ErrUtil.AddData(ex, "i, iMax, Pressure",
                             i, iMax, Pressure)
        ErrUtil.ReRaiseError(ex)
        Return False
    End Try

End Function

Function GenerateGraph() As String
   	Dim sErrLine As String
    Dim sError As String

    Try
        sErrLine = CallersLine(-1)
        Dim sourceDirectory As String = RunTime.ProjectPath & "\Results\Mech2TestPrimingPressure_Marconi"
        Dim destinationDirectory As String = RunTime.ProjectPath & "\Results\Mech2TestPrimingPressure_Marconi"

        Display.ShowStatus "Executing PVTPostProcess.exe"
        sErrLine = CallersLine(-1)
        Dim p As Process
        p = New Process()
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.StartInfo.FileName = RunTime.ProjectPath + "\\Utilities\\PVTPostProcess\\dist\\PVTPostProcess_Rev5\\PVTPostProcess_Rev5.exe"
        p.StartInfo.Arguments = $"""{sourceDirectory}"" ""{destinationDirectory}"""

        Display.Text = "Graph is now being generated."
        sErrLine = CallersLine(-1)
        p.Start()
        sErrLine = CallersLine(-1)
        p.WaitForExit()
        p.Close

        Dim sGraphResult As Integer
        sGraphResult = GUIUtil.DisplayPassFailRetry("Is the graph acceptable?",DisplayPanelType.Default,False)
        ' 0 - Pass; 1 = Retry; 2 = Fail

        sErrLine = CallersLine(-1)
        If sGraphResult = 0 Then
            GenerateGraph = "True"
        ElseIf sGraphResult = 1 Then
            GenerateGraph = "Retry"
        Else
            GenerateGraph = "False"
        End If
    End Try
End Function






















'__Start MetaData__
'
'<ScriptMetadata>
'
'	<Modules>
'
'	</Modules>
'
'	<Documentation>
'		<Name Value="Mech2TestPrimingPressure_Marconi" Description=""/>
'		<Test_Author Value="Chua Hong Keong" Description=""/>
'		<Test_Owner Value="Chua Hong Keong" Description=""/>
'		<Last_Changed_By Value="Chua Hong Keong" Description=""/>
'		<Test_Type Value="Functional Test" Description=""/>
'		<CreatedDate Value="5/19/2014 11:58:40 AM" Description=""/>
'		<ModifiedOn Value="11/24/2023 14:47:07" Description=""/>
'		<Asset_Classification Value="MECH" Description=""/>
'		<Purpose Value="Ensure that there are no leaks and the valves work." Description=""/>
'		<Theory_Of_Operation Value="Take readings over time of the pressures.  Turning on the pump and looking at the decay." Description=""/>
'		<Link_To_External Value="NA" Description=""/>
'		<Customer_want_Addressed Value="NA" Description=""/>
'		<Mfg_Risk_Addressed Value="NA" Description=""/>
'		<Eng._Parameter_Monitored Value="NA" Description=""/>
'		<Materials_Supp._Required Value="NA" Description=""/>
'		<Test_SCM_Header Value="$Header: https://svn-pro.corp.hpicloud.net:20181/svn/cim2_2-projects/Projects/Marconi/Scripts/Mech2TestPrimingPressure_Marconi.bas 30902 2021-02-02 02:23:45Z anant.suparavong $" Description=""/>
'
'	</Documentation>
'
'	<Metadata>
'		<TestParms>
'			<ReflowIndicatingStn Value="" Description="" Optional="1" Default_Set="Embedded" Default_Key="_Current"/>
'			<SaveDataToFile Value="" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'			<CollectServoMetric Value="" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'			<blnSaveRawToSharedDrive Value="" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'			<picInsertPVTTool Value="" Description="" Optional="0" Default_Set="PicParms" Default_Key="_Current"/>
'			<picPVTConnection Value="" Description="" Optional="0" Default_Set="PicParms" Default_Key="_Current"/>
'			<RunGraphGenerator Value="" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'
'		</TestParms>
'
'		<DataLog Name="Default">
'			<TestResult Value="" Type="Text" Description="Contains the PASS/FAIL result of the test"/>
'			<ResultInfo Value="" Type="Text" Description="Contains the description for the result"/>
'			<DevSerialNumber Value="" Type="Text" Description=""/>
'			<StationNumber Value="" Type="Text" Description=""/>
'			<PressureTestVentDelayAvg Value="" Type="Text" Description=""/>
'			<PressureTestVentRateM Value="" Type="Text" Description=""/>
'			<PressureTestVentRateC Value="" Type="Text" Description=""/>
'			<PressureTestVentRateY Value="" Type="Text" Description=""/>
'			<PressureTestVentRateK Value="" Type="Text" Description=""/>
'			<PressureTestMaxPressureM Value="" Type="Text" Description=""/>
'			<PressureTestMaxPressureC Value="" Type="Text" Description=""/>
'			<PressureTestMaxPressureY Value="" Type="Text" Description=""/>
'			<PressureTestMaxPressureK Value="" Type="Text" Description=""/>
'			<PressureTestVentDelayM Value="" Type="Text" Description=""/>
'			<PressureTestVentDelayC Value="" Type="Text" Description=""/>
'			<PressureTestVentDelayY Value="" Type="Text" Description=""/>
'			<PressureTestVentDelayK Value="" Type="Text" Description=""/>
'			<PressureTestCompSlope Value="" Type="Text" Description=""/>
'			<PressureTestMaxCompPressureM Value="" Type="Text" Description=""/>
'			<PressureTestMaxCompPressureC Value="" Type="Text" Description=""/>
'			<PressureTestMaxCompPressureY Value="" Type="Text" Description=""/>
'			<PressureTestMaxCompPressureK Value="" Type="Text" Description=""/>
'			<PressureTestVentRateAvg Value="" Type="Text" Description=""/>
'			<PressureTestMaxPressureAvg Value="" Type="Text" Description=""/>
'			<PressureTestMaxCompPressureAvg Value="" Type="Text" Description=""/>
'			<DecayTestStartDecayPressureM Value="" Type="Text" Description=""/>
'			<DecayTestStartDecayPressureC Value="" Type="Text" Description=""/>
'			<DecayTestStartDecayPressureY Value="" Type="Text" Description=""/>
'			<DecayTestStartDecayPressureK Value="" Type="Text" Description=""/>
'			<DecayTestDecayM Value="" Type="Text" Description=""/>
'			<DecayTestDecayC Value="" Type="Text" Description=""/>
'			<DecayTestDecayY Value="" Type="Text" Description=""/>
'			<DecayTestDecayK Value="" Type="Text" Description=""/>
'			<DecayTestVentRateM Value="" Type="Text" Description=""/>
'			<DecayTestVentRateC Value="" Type="Text" Description=""/>
'			<DecayTestVentRateY Value="" Type="Text" Description=""/>
'			<DecayTestVentRateK Value="" Type="Text" Description=""/>
'			<DecayTestStartDecayPressureAvg Value="" Type="Text" Description=""/>
'			<DecayTestDecayAvg Value="" Type="Text" Description=""/>
'			<DecayTestVentRateAvg Value="" Type="Text" Description=""/>
'			<WarmupPrimeMaxPressureM Value="" Type="Text" Description=""/>
'			<WarmupPrimeMaxPressureC Value="" Type="Text" Description=""/>
'			<WarmupPrimeMaxPressureY Value="" Type="Text" Description=""/>
'			<WarmupPrimeMaxPressureK Value="" Type="Text" Description=""/>
'			<WarmupPrime_DecayTestDecayM Value="" Type="Text" Description=""/>
'			<WarmupPrime_DecayTestDecayC Value="" Type="Text" Description=""/>
'			<WarmupPrime_DecayTestDecayY Value="" Type="Text" Description=""/>
'			<WarmupPrime_DecayTestDecayK Value="" Type="Text" Description=""/>
'			<DecayTestMaxPressureM Value="" Type="Text" Description=""/>
'			<DecayTestMaxPressureC Value="" Type="Text" Description=""/>
'			<DecayTestMaxPressureY Value="" Type="Text" Description=""/>
'			<DecayTestMaxPressureK Value="" Type="Text" Description=""/>
'			<PVTToolDeviceReset Value="" Type="Number" Description=""/>
'			<PackageVersion Value="" Type="Text" Description=""/>
'			<MaxPressureCMYK Value="" Type="Text" Description=""/>
'			<MinPressureCMYK Value="" Type="Text" Description=""/>
'			<DiffPressureMaxMin Value="" Type="Text" Description=""/>
'
'		</DataLog>
'
'		<FailureMsgs>
'			<NoNIDAQmx Category="EXCP" English="No NIDAQ was connected" />
'			<BadPVTTransducerValuesFile Category="EXCP" English="The PVT Transducer values file is bad" />
'			<BlockageTestFailed Category="SS" English="Blockage Test failed." />
'			<MinPressureTooLow Category="SS" English=" Min Pressure too low: " />
'			<MaxPressureTooHigh Category="SS" English=" Max Pressure too high: " />
'			<PressureTestFailed Category="SS" English="Pressure Test failed" />
'			<PressureLessStartDecayPressure Category="SS" English="Start Vent Rate is lower than Max Pressure" />
'			<VentRateDroppedTooLate Category="SS" English="Vent Rate dropped too late" />
'			<VentRateOutOfRange Category="SS" English="Vent Rate out of range;" />
'			<VentdelayOutOfRange Category="SS" English="Vent delay out of range." />
'			<VentrateOfOfRange Category="SS" English=" Vent Rate of of range: " />
'			<StartDecayPressureTooLow Category="SS" English="StartDecayPressure too low, check for any leak." />
'			<MaxPressureOutOfRange Category="SS" English="Max Pressure is too high/low" />
'			<DecayTestFailed Category="SS" English="Decay Test failed" />
'			<HitMaxTooLate Category="SS" English=" hit maximum too late" />
'
'		</FailureMsgs>
'
'		<OutputParms>
'
'		</OutputParms>
'
'		<TestMsgs>
'			<OpenDoor English="Open the Door" Chinese="开门" Thai="เปิดประตู" Burmese="တံခါးဖွင့်" Cambodia="បើកទ្វារ" />
'			<ResetPVT English="Unplug and reinsert PVT USB Connector" Chinese="取出再插入PVT的USB连接器" Thai="ถอดและใส่ขั้วต่อ PVT USB" Burmese="PVT USB connector Remove နှင့် reinstall" Cambodia="យកនិងតំឡើងឧបករណ៍ភ្ជាប់ USB PVT ឡើងវិញ" />
'			<InsertPVTSupplies English="Insert the PVT Tool. Press [Done] to continue." Chinese="插入PVT 治. " Thai="แทรกเครื่องมือ PVT. กด [Done] เพื่อดำเนินการต่อ" Burmese="PVT Tool ကိုချထားပါ။ စာနယ်ဇင်းဆက်လက် [Done] ။" Cambodia="បញ្ចូលឧបករណ៍ PVT ។ ចុច [Done] ដើម្បីបន្ត។" />
'			<CheckPVTConnection English="Check PVT  Tool LED is lit.  Reinsert USB if LED is off." Chinese="" Thai="ตรวจสอบ LED PVT Tool สว่างขึ้น ถอดและเสียบ USB ถ้าไฟ LED ดับ" Burmese="Check PVT Tool ကို LED ကတက် lit ဖြစ်ပါတယ်. LED ကို lit မဟုတ်ပါလျှင်ကို USB connector ကို reinstall" Cambodia="ពិនិត្យមើលឧបករណ៍ PVT LED ត្រូវបានបំភ្លឺ។ បញ្ចូល USB ឡើងវិញប្រសិនបើ LED បិទ។" />
'			<AlertEngineer English="If still fail, alert engineer" Chinese="" Thai="หากยังคงล้มเหลววิศวกรแจ้งเตือน" Burmese="နေဆဲကျရှုံးခဲ့လျှင်, တပ်လှန့်အင်ဂျင်နီယာ" Cambodia="ប្រសិនបើនៅតែបរាជ័យ, ជូនដំណឹង (វិស្វករ)" />
'			<ReplaceTool English="Please Alert Engineer to debug/replace the PVT tool" Chinese="" Thai="" Burmese="" Cambodia="" />
'
'		</TestMsgs>
'
'	</Metadata>
'
'	<Components>
'
'	</Components>
'
'
'	<ParameterSets>
'		<EMBEDDED>
'			<blnSaveRawToSharedDrive Value="0" Description="" ResultDefID=""/>
'			<CollectServoMetric Value="1" Description="" ResultDefID=""/>
'			<DoorClosedResponse Value="0" Description="" ResultDefID=""/>
'			<DoorOpenResponse Value="1" Description="" ResultDefID=""/>
'			<ReflowIndicatingStn Value="TL_LFC" Description="" ResultDefID=""/>
'			<SaveDataToFile Value="1" Description="" ResultDefID=""/>
'			<RunGraphGenerator Value="1" Description="" ResultDefID=""/>
'
'		</EMBEDDED>
'
'	</ParameterSets>
'</ScriptMetadata>
'
'
'
'
'__End MetaData__
