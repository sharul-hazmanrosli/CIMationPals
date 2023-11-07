'#Language "WWB.NET"
Option Explicit
Imports System
Imports System.Diagnostics

'#################################### Replica of Mech2TestPrimingPressure script structure ####################################

'Declaration of Const variables for Blockage Test, Pump Initialization and Shutdown, Pressure Test, R&D, Decay Test

Const RUN_PVT_POST_PROCESS = True

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

        ' Running PVT Post Process to generate graph for results
        If RUN_PVT_POST_PROCESS Then
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
        End If

EndTry:
        ' Prevent BEA GPE error, set carr motor to available if stall
        ' Screen Max Pressure for Writing System Test [Marconi PP Only]
    
        ' Process result
        If bTestResult Then
            EndTest(CIMTestResult.Pass)
        Else
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

        process.StartInfo.FileName = RunTime.ProjectPath & "\Utilities\PVTPostProcess_Rev4\PVTPostProcess_Rev4.exe"
        process.StartInfo.Arguments = $"""{sourceDirectory}"" ""{destinationDirectory}"""   'Pass the variable as a command-line argument
        Display.Text = "Graph is now being generated."
        sErrLine = CallersLine(-1)
        process.Start()
        Wait 3

        Dim sGraphResult As Integer
        sGraphResult = GUIUtil.DisplayPassFailRetry("Is the graph acceptable?",DisplayPanelType.DEFAULT,False)
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
'		<Name Value="Proc2GenerateGraphV3_Marconi" Description=""/>
'		<Test_Author Value="" Description=""/>
'		<Test_Owner Value="" Description=""/>
'		<Last_Changed_By Value="" Description=""/>
'		<Test_Type Value="" Description=""/>
'		<CreatedDate Value="10/13/2023 11:16:38" Description=""/>
'		<ModifiedOn Value="11/7/2023 17:08:50" Description=""/>
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
'</ScriptMetadata>
'
'
'
'
'__End MetaData__
