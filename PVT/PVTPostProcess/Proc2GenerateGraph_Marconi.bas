'#Language "WWB.NET"
Option Explicit
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Collections.Generic

'#Uses "modPen.bas"
'#Uses "modMech.bas"

'Replica of Mech2TestPrimingPressure script structure

'Declaration of Const variables for Blockage Test, Pump Initialization and Shutdown, Pressure Test, R&D, Decay Test

Const PRESSURE_TEST_SAMPLINGHZ = 1000
Const PRESSURE_TEST_STOP_COMPENSATION_PRESSURE = 80
Const PRESSURE_TEST_MAX_VENT_DELAY = 50
Const PRESSURE_TEST_MIN_VENT_DELAY = -75
Const PRESSURE_TEST_MAX_VENTRATE = 1434
Const PRESSURE_TEST_MIN_VENTRATE = 784

Const DECAY_TEST_MIN_DECAY = 0
Const DECAY_TEST_MAX_DECAY = -5.75
Const DECAY_TEST_MAX_VENTRATE = 1000
Const DECAY_TEST_MIN_VENTRATE = 200

Const Colorstr = "Magenta,Cyan,Yellow,K (Black)"

Sub Main()
    Dim bTestResult As Boolean      = True,
    sFailInfo As String             = String.Empty,
    sErrLine As String              = String.Empty,
    sResp As String
    
    Try
        'Assign the script version to be saved to the DataLog and the Error.log

        'Additional setting required for CIMation 2.10.2.0 onward

        'Initializing NIDAQ

        'Read PVT Transducer Values from File

        'Set NIDAQ Gain Offsets

Retest:
        ' Run Blockage Test
    
        ' Run Pressure Test
    
        ' Check difference between 4 pressures
    
        ' Save Data
    
        ' Run Decay Test
    
        ' Save Data
    
        ' Run Pressure Test with Pump Time = 750

        Dim Test As String
        Dim Pressures(2, 3) As Double
    
        Test = "PVTPostProcess"
    
        Pressures(0, 0) = 0.0869
        Pressures(0, 1) = 0.0457
        Pressures(0, 2) = 0.0332
        Pressures(0, 3) = 0.0998

        Pressures(1, 0) = 0.0869
        Pressures(1, 1) = 0.0457
        Pressures(1, 2) = 0.0332
        Pressures(1, 3) = 0.0419

        LogPressures Test, Pressures

        ' Running PVT Post Process to generate graph for results
        If TestParms.blnRunPVTPostProcess Then
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
            Display.Text = "Skipping PVTPostProcess.exe to generate result graphs"
        End If

EndTry:
        ' Prevent BEA GPE error, set carr motor to available if stall
    
        ' Screen Max Pressure for Writing System Test [Marconi PP Only]
    
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
        ErrUtil.AddData "sFailInfo, bTestResult", sFailInfo, bTestResult
        ErrUtil.ReRaiseError(ex)

    Finally
        Display.Style = DisplayStyle.Default
        Display.Clear
        Display.ShowStatus ""
	End Try
End Sub

Function GenerateGraph() As String
   	Dim sErrLine As String
    Dim sError As String

    Try
        sErrLine = CallersLine(-1)
        Dim sourceDirectory As String = RunTime.ProjectPath & "\Marconi Result Sample"
        Dim destinationDirectory As String = RunTime.ProjectPath & "\Marconi Result Sample"

        Display.ShowStatus "Executing PVTPostProcess.exe"
        sErrLine = CallersLine(-1)
        Dim process As New process()
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True
        'process.StartInfo.RedirectStandardError = True
        'process.StartInfo.RedirectStandardOutput = True

        process.StartInfo.FileName = RunTime.ProjectPath & "\Utilities\PVTPostProcess_Rev4\PVTPostProcess_Rev4.exe"
        process.StartInfo.Arguments = $"""{sourceDirectory}"" ""{destinationDirectory}"""   'Pass the variable as a command-line argument
        Display.Text = "Graph is now being generated."
        sErrLine = CallersLine(-1)
        process.Start()
        Wait 3

        'sError = process.StandardError.ReadToEnd
        'Display.Text = sError
        'process.WaitForExit        'currently not robust, cimation hangs once process starts and wait
        'process.Close

        Dim sGraphResult As Integer
        sGraphResult = GUIUtil.DisplayPassFailRetry("Is the graph acceptable?",DisplayPanelType.Default,False)
        ' 0 - Pass; 1 = Retry; 2 = Fail

        'Retry to show failure msg
        'TEST PARMS TO RUN GUI OR NOT

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

Sub LogPressures(Test$, Pressures(,) As Double)
    Dim Writer As System.IO.StreamWriter
    Dim S As String, i As Long
    Dim SavePath As String
    Dim Dt As String
    Dim sFileName As String
    Dim sErrLine As String = String.Empty

    sErrLine = CallersLine(-1)
    Dim TestLimits As New Dictionary(Of String, Object)
    'Test Info
    TestLimits.Add("test_results", 0)
    TestLimits.Add("sampling_rate", PRESSURE_TEST_SAMPLINGHZ)
    TestLimits.Add("serial_number", "TH36936123085Z")
    TestLimits.Add("run_number", "RunNumber")   'RunTime.RunNumber
    'Max Pressures
    TestLimits.Add("maxP_magenta", 98.51)
    TestLimits.Add("maxP_cyan", 98.26)
    TestLimits.Add("maxP_yellow", 98.54)
    TestLimits.Add("maxP_black", 98.33)
    TestLimits.Add("maxP_within_range", 1)      'MaxP(COLOR)
    'Pressure Test Result
    TestLimits.Add("Vent Delay", PRESSURE_TEST_STOP_COMPENSATION_PRESSURE)
    TestLimits.Add("Vent Rate", 1500)           'Decay(COLOR)
    TestLimits.Add("Vent Delay Result", 1)
    TestLimits.Add("Vent Rate Result", 0)
    'Pressure Test Limits
    TestLimits.Add("Vent Delay UL", PRESSURE_TEST_MAX_VENT_DELAY)
    TestLimits.Add("Vent Delay LL", PRESSURE_TEST_MIN_VENT_DELAY)
    TestLimits.Add("Vent Rate UL", PRESSURE_TEST_MAX_VENTRATE)
    TestLimits.Add("Vent Rate LL", PRESSURE_TEST_MIN_VENTRATE)
    'Decay Test Result
    TestLimits.Add("Decay Min", DECAY_TEST_MIN_DECAY)   'Decay(COLOR)
    TestLimits.Add("Decay Vent Rate", 500)              'VentRate(COLOR)
    TestLimits.Add("Decay Result", 1)
    TestLimits.Add("Decay Vent Rate Result", 1)
    'Decay Test Result
    TestLimits.Add("Decay UL", DECAY_TEST_MIN_DECAY)
    TestLimits.Add("Decay LL", DECAY_TEST_MAX_DECAY)
    TestLimits.Add("Decay Vent Rate UL", DECAY_TEST_MAX_VENTRATE)
    TestLimits.Add("Decay Vent Rate LL", DECAY_TEST_MIN_VENTRATE)

    Try
        sErrLine = CallersLine(-1)
        Dt = Format(Now,"yyyy_MM_dd_HH_mm_ss")
        sFileName = "TH36936123085Z" + "_" + "RunNumber" + "_" + Dt + "_" + Test + "_Proc2GenerateGraph" + ".log" 'RunTime.SerialNumber

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
        Writer.WriteLine "SamplingHz: " + "100" 'Str(NIDAQ.AISamplingRateHz)
        sErrLine = CallersLine(-1)
        Writer.WriteLine "Number Samples: " + Str(PRESSURE_TEST_SAMPLINGHZ) 'Str(NIDAQ.NumberSamples)

        sErrLine = CallersLine(-1)
        For Each kvp As KeyValuePair(Of String, Object) In TestLimits
            sErrLine = CallersLine(-1)
            S = kvp.Key.ToString + ": " + kvp.Value.ToString
            Writer.WriteLine S
        Next
        Writer.WriteLine ""

        sErrLine = CallersLine(-1)
        Writer.Writeline "Colors: " + Colorstr

        For i = 0 To 1
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
                    'CreateFolder dataLoggingFolder
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





















'__Start MetaData__
'
'<ScriptMetadata>
'
'	<Modules>
'
'	</Modules>
'
'	<Documentation>
'		<Name Value="Proc2GenerateGraphV4_Marconi" Description=""/>
'		<Test_Author Value="" Description=""/>
'		<Test_Owner Value="" Description=""/>
'		<Last_Changed_By Value="" Description=""/>
'		<Test_Type Value="" Description=""/>
'		<CreatedDate Value="10/13/2023 11:16:38" Description=""/>
'		<ModifiedOn Value="11/17/2023 11:22:25" Description=""/>
'		<Asset_Classification Value="" Description=""/>
'		<Purpose Value="" Description=""/>
'		<Theory_Of_Operation Value="" Description=""/>
'		<Link_To_External Value="" Description=""/>
'		<Customer_want_Addressed Value="" Description=""/>
'		<Mfg_Risk_Addressed Value="" Description=""/>
'		<Eng._Parameter_Monitored Value="" Description=""/>
'		<Materials_Supp._Required Value="" Description=""/>
'		<Test_SCM_Header Value="$Header$" Description=""/>
'
'	</Documentation>
'
'	<Metadata>
'		<TestParms>
'			<blnSaveRawToSharedDrive Value="0" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'			<blnRunPVTPostProcess Value="" Description="" Optional="0" Default_Set="Embedded" Default_Key="_Current"/>
'
'		</TestParms>
'
'		<DataLog Name="Default">
'			<TestResult Value="" Type="Text" Description="Contains the PASS/FAIL result of the test"/>
'			<ResultInfo Value="" Type="Text" Description="Contains the description for the result"/>
'
'		</DataLog>
'
'		<FailureMsgs>
'
'		</FailureMsgs>
'
'		<OutputParms>
'
'		</OutputParms>
'
'		<TestMsgs>
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
'			<blnRunPVTPostProcess Value="1" Description="" ResultDefID=""/>
'			<blnSaveRawToSharedDrive Value="0" Description="" ResultDefID=""/>
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
