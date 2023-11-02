'#Language "WWB.NET"
Option Explicit
Imports System
Imports System.Diagnostics

Sub Main()
	Dim sFailInfo As String        ' String for failure information.
	Dim bTestResult As Boolean     ' Overall pass or fail of the test.

	Try
        Dim sourceDirectory As String = RunTime.ProjectPath & "\Marconi Result Sample"
        Dim destinationDirectory As String = RunTime.ProjectPath & "\Marconi Result Sample"

        Dim process As New Process()
        process.StartInfo.FileName = RunTime.ProjectPath & "\Utilities\PVTPostProcess\PVTPostProcess_Rev2.exe"     '"\Utilities\PVTPostProcess\PVTPostProcess_Rev2.exe"
        process.StartInfo.Arguments = $"""{sourceDirectory}"" ""{destinationDirectory}"""                       'Pass the variable as a command-line argument
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True
        process.StartInfo.RedirectStandardOutput = True


        Display.Text = "Graph Generator is starting. Once done, close the Generator before continuing with CIMation"

        process.Start()

        Wait 5
        'process.WaitForExit()

        Dim sGraphResult As Integer
        sGraphResult = GUIUtil.DisplayFailRetryContinue("Graph",DisplayPanelType.Default,False)

        If sGraphResult = 2 Then
            Display.Text = "Pass"
            bTestResult = True
        ElseIf sGraphResult = 1 Then
            Display.Text = "Retry"
        Else
            Display.Text = "Fail"
            bTestResult = False
        End If

        'Dim reader As System.IO.StreamReader = process.StandardOutput
        'Dim result As String = reader.ReadToEnd()

		If bTestResult Then
			DataLog.TestResult = "PASS"
			Test.Pass()
		Else
			Throw New TestFailException(sFailInfo)
		End If

	Catch ex As Exception
		If ex.GetType().ToString() = "TestFailException" Then
			DataLog.TestResult = "FAIL"
			DataLog.ResultInfo = ex.Message
			Test.Fail (DataLog.ResultInfo)
		Else
			DataLog.TestResult = "EXCEPTION"
			DataLog.ResultInfo = ex.Message
			Test.Exception (DataLog.ResultInfo)
			CIMation.Logger.LogException(ex)
		End If

    Finally
        Display.Style = DisplayStyle.Default
        Display.Clear
        Display.ShowStatus ""
	End Try
End Sub

Public Function GenerateGraph As Boolean
    
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
'		<Name Value="Proc2GenerateGraphV2_Marconi" Description=""/>
'		<Test_Author Value="" Description=""/>
'		<Test_Owner Value="" Description=""/>
'		<Last_Changed_By Value="" Description=""/>
'		<Test_Type Value="" Description=""/>
'		<CreatedDate Value="10/13/2023 11:16:38" Description=""/>
'		<ModifiedOn Value="11/2/2023 17:10:37" Description=""/>
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
