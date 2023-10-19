Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NationalInstruments.DAQmx
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading

Namespace FUEL
    Public Class DAQ
        ' Nested Types
        Public Class DAQChannelInfo
            ' Methods
            Public Sub New()
                Me._InvertSignal = False
                Me.ReadyToGo = False
            End Sub

            Public Sub SetChannelProperties(ByVal ChannelPosition As Integer, ByVal SeriesName As String, ByVal SensorName As Sensors, ByVal SensorUnits As Units)
                Dim physicalChannels As String() = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)
                Me._PhysicalChannelName = physicalChannels(ChannelPosition)
                Me._ChannelPosition = ChannelPosition
                Me._SeriesName = SeriesName
                Me._SensorName = SensorName
                Me._SensorUnits = SensorUnits
                Me.SetStdCalValues
                Me.ReadyToGo = True
            End Sub

            Public Sub SetChannelProperties(ByVal ChannelPosition As Integer, ByVal SeriesName As String, ByVal CalSlope As Double, ByVal CalIntercept As Double, ByVal SensorUnits As Units)
                Dim physicalChannels As String() = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)
                Me._PhysicalChannelName = physicalChannels(ChannelPosition)
                Me._ChannelPosition = ChannelPosition
                Me._SeriesName = SeriesName
                Me._SensorName = Sensors.Custom
                Me._SensorSlope = CalSlope
                Me._SensorIntercept = CalIntercept
                Me._SensorUnits = SensorUnits
                Me.ReadyToGo = True
            End Sub

            Private Sub SetStdCalValues()
                Dim source As String() = Strings.Split(MySettingsProperty.Settings.SensorCalibrations, "|", -1, CompareMethod.Binary)
                Dim flag As Boolean = False
                Dim index As Integer = 0
                Do While (Not flag And (index < Enumerable.Count(Of String)(source)))
                    Dim strArray2 As String() = Strings.Split(source(index), ";", -1, CompareMethod.Binary)
                    If ((strArray2(0).ToUpper = Me.SensorName.ToString.ToUpper) And (strArray2(3).ToUpper = Me.SensorUnits.ToString.ToUpper)) Then
                        flag = True
                        Me._SensorIntercept = Conversions.ToDouble(strArray2(2))
                        Me._SensorSlope = Conversions.ToDouble(strArray2(1))
                    End If
                Loop
            End Sub


            ' Properties
            Private Property _PhysicalChannelName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PhysicalChannelName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__PhysicalChannelName = AutoPropertyValue
                End Set
            End Property

            Private Property _ChannelPosition As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__ChannelPosition
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__ChannelPosition = AutoPropertyValue
                End Set
            End Property

            Private Property _SeriesName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SeriesName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__SeriesName = AutoPropertyValue
                End Set
            End Property

            Private Property _SensorName As Sensors
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SensorName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Sensors)
                    Me.__SensorName = AutoPropertyValue
                End Set
            End Property

            Private Property _SensorSlope As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SensorSlope
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__SensorSlope = AutoPropertyValue
                End Set
            End Property

            Private Property _SensorIntercept As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SensorIntercept
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__SensorIntercept = AutoPropertyValue
                End Set
            End Property

            Private Property _SensorUnits As Units
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SensorUnits
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Units)
                    Me.__SensorUnits = AutoPropertyValue
                End Set
            End Property

            Private Property _InvertSignal As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me.__InvertSignal
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me.__InvertSignal = AutoPropertyValue
                End Set
            End Property

            Friend Property ReadyToGo As Boolean
                <DebuggerNonUserCode> _
                Get
                    Return Me._ReadyToGo
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Boolean)
                    Me._ReadyToGo = AutoPropertyValue
                End Set
            End Property

            Public ReadOnly Property PhysicalChannelName As String
                Get
                    Return Me._PhysicalChannelName
                End Get
            End Property

            Public ReadOnly Property ChannelPosition As Integer
                Get
                    Return Me._ChannelPosition
                End Get
            End Property

            Public ReadOnly Property SeriesName As String
                Get
                    Return Me._SeriesName
                End Get
            End Property

            Public ReadOnly Property SensorName As Sensors
                Get
                    Return Me._SensorName
                End Get
            End Property

            Public ReadOnly Property SensorSlope As Double
                Get
                    Return Me._SensorSlope
                End Get
            End Property

            Public ReadOnly Property SensorIntercept As Double
                Get
                    Return Me._SensorIntercept
                End Get
            End Property

            Public ReadOnly Property SensorUnits As Units
                Get
                    Return Me._SensorUnits
                End Get
            End Property

            Public Property InvertSignal As Boolean
                Get
                    Return Me._InvertSignal
                End Get
                Set(ByVal value As Boolean)
                    Me._InvertSignal = value
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PhysicalChannelName As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __ChannelPosition As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SeriesName As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SensorName As Sensors
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __SensorSlope As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SensorIntercept As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SensorUnits As Units
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __InvertSignal As Boolean
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _ReadyToGo As Boolean

            ' Nested Types
            Public Enum Sensors
                ' Fields
                AP41M = 0
                Custom = 1
            End Enum

            Public Enum Units
                ' Fields
                InchesWater = 0
                InchesHg = 1
                Voltage = 2
                Custom = 3
            End Enum
        End Class

        Public Class PST
            ' Methods
            Public Sub New()
                Me._SampleRate = 40
                Me.DaqInfo = New DAQChannelInfo
                Me.ReturnData = New ReturnedData
                Logging.AddLogEntry(Me, "***Starting DAQ***", EventLogEntryType.Information, 3)
            End Sub

            Public Sub acquiredata()
                If Not Me.DaqInfo.ReadyToGo Then
                    Dim message As String = "DAQ Info not yet set, you must setup the DAQ using the DAQChannelInfo class first."
                    Logging.AddLogEntry(Me, ("acquiredata: Error: " & message), EventLogEntryType.Error, 0)
                    Throw New ApplicationException(message)
                End If
                Logging.AddLogEntry(Me, "Starting thread acquiredata", EventLogEntryType.Information, 3)
                Me.thdAcquire = New Thread(New ThreadStart(AddressOf Me.thd_AcquireData))
                Me.thdAcquire.Start
                Do While True
                    If Me.CollectionStarted Then
                        Logging.AddLogEntry(Me, "acquiredata: Returning control to FlexScript", EventLogEntryType.Information, 4)
                        Return
                    End If
                    Logging.AddLogEntry(Me, "acquiredata: thread sleep waiting for acquisition to start.", EventLogEntryType.Information, 4)
                    Thread.Sleep(30)
                Loop
            End Sub

            Private Sub AddDataToList(ByVal sourceArray As Double(0 To .,0 To .))
                Try 
                    Dim num4 As Integer = (sourceArray.GetLength(1) - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num5 As Integer = num4
                        If (num2 > num5) Then
                            Exit Do
                        End If
                        Dim item As New lstReturnedData
                        If (Me.DaqInfo.SensorName <> Sensors.Custom) Then
                            item.SetChannelProperties(Me.DaqInfo.ChannelPosition, Me.DaqInfo.SeriesName, Me.DaqInfo.SensorName, Me.DaqInfo.SensorUnits)
                        Else
                            item.SetChannelProperties(Me.DaqInfo.ChannelPosition, Me.DaqInfo.SeriesName, Me.DaqInfo.SensorSlope, Me.DaqInfo.SensorIntercept, Me.DaqInfo.SensorUnits)
                        End If
                        Dim num3 As Integer = 1
                        If Me.DaqInfo.InvertSignal Then
                            num3 = -1
                        End If
                        item.XVal = Math.Round(CDbl((CDbl(Me.ReturnData.List.Count) / Me.SampleRate)), 4)
                        item.YVal = Math.Round(CDbl(((((sourceArray(0, num2) - Me._TareVoltage) * Me.DaqInfo.SensorSlope) + Me.DaqInfo.SensorIntercept) * num3)), 2)
                        Me.ReturnData.List.Add(item)
                        num2 += 1
                    Loop
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Logging.AddLogEntry(Me, ("AddDataToList: Error " & exception.ToString), EventLogEntryType.Error, 0)
                    Interaction.MsgBox(exception.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                    Me.StopAcquisition
                    ProjectData.ClearProjectError
                End Try
            End Sub

            Private Sub AnalogInCallback(ByVal ar As IAsyncResult)
                Try 
                    If Object.ReferenceEquals(Me.runningTask, ar.AsyncState) Then
                        Dim sourceArray(,) As Double(0 To .,0 To .) = Me.analogInReader.EndReadMultiSample(ar)
                        Me.AddDataToList(sourceArray)
                        Me.analogInReader.BeginReadMultiSample(10, Me.analogCallback, Me.myTask)
                    End If
                Catch exception1 As DaqException
                    Dim ex As DaqException = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As DaqException = ex
                    Logging.AddLogEntry(Me, ("AnalogInCallback: DAQException " & exception.ToString), EventLogEntryType.Error, 0)
                    Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, Nothing)
                    Me.StopAcquisition
                    ProjectData.ClearProjectError
                End Try
            End Sub

            Public Function GetInitialPressure() As Double
                Logging.AddLogEntry(Me, "GetInitialPressure: Complete", EventLogEntryType.Information, 3)
                Dim smallDAQSample(,) As Double(0 To .,0 To .) = Me.GetSmallDAQSample
                Dim num As Double = 0
                Dim num6 As Integer = Information.UBound(smallDAQSample, 2)
                Dim num5 As Integer = 0
                Do While True
                    Dim num7 As Integer = num6
                    If (num5 > num7) Then
                        num = (num / CDbl((Information.UBound(smallDAQSample, 2) + 1)))
                        Dim num4 As Integer = 1
                        If Me.DaqInfo.InvertSignal Then
                            num4 = -1
                        End If
                        Dim num3 As Double = Math.Round(CDbl(((((num - Me._TareVoltage) * Me.DaqInfo.SensorSlope) + Me.DaqInfo.SensorIntercept) * num4)), 2)
                        Logging.AddLogEntry(Me, ("GetInitialPressure: Initial Pressure = " & Conversions.ToString(num3)), EventLogEntryType.Information, 4)
                        Logging.AddLogEntry(Me, "GetInitialPressure: Complete", EventLogEntryType.Information, 3)
                        Return num3
                    End If
                    num = (num + smallDAQSample(0, num5))
                    num5 += 1
                Loop
            End Function

            Private Function GetSmallDAQSample() As Double(0 To .,0 To .)
                Dim numArray(,) As Double(0 To .,0 To .)
                If Not (Object.ReferenceEquals(Me.runningTask, Nothing) And Me.ScanForDAQ) Then
                    If Not Object.ReferenceEquals(Me.runningTask, Nothing) Then
                        Logging.AddLogEntry(Me, "GetSmallDAQSample: Task is already running.", EventLogEntryType.Error, 0)
                    End If
                    numArray = Nothing
                Else
                    Try 
                        Me.myTask = New Task
                        Me.myTask.AIChannels.CreateVoltageChannel(Me.DaqInfo.PhysicalChannelName, Me.DaqInfo.SeriesName, DirectCast(-1, AITerminalConfiguration), -5, 5, AIVoltageUnits.Volts)
                        Me.myTask.Control(TaskAction.Verify)
                        Me.runningTask = Me.myTask
                        numArray = New AnalogMultiChannelReader(Me.myTask.Stream).ReadMultiSample(10)
                    Catch exception1 As Exception
                        Dim ex As Exception = exception1
                        ProjectData.SetProjectError(ex)
                        Dim exception As Exception = ex
                        Logging.AddLogEntry(Me, ("GetSmallDAQSample: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                        Interaction.MsgBox(("GetSmallDAQSample: Error: " & ChrW(13) & ChrW(10) & exception.ToString), MsgBoxStyle.Critical, Nothing)
                        numArray = Nothing
                        ProjectData.ClearProjectError
                    Finally
                        Me.StopAcquisition
                        Me.runningTask = Nothing
                    End Try
                End If
                Return numArray
            End Function

            Public Sub RecoverFromError()
                Logging.AddLogEntry(Me, "Recovering from error", EventLogEntryType.Error, 0)
                Me.StopAcquisition
            End Sub

            Public Sub ResetDAQ()
                If Not Me.ScanForDAQ Then
                    Interaction.MsgBox("No DAQ Found, nothing to reset", MsgBoxStyle.ApplicationModal, Nothing)
                Else
                    Dim devices As String() = DaqSystem.Local.Devices
                    Dim device As Device = DaqSystem.Local.LoadDevice(devices(0))
                    device.Reset
                    device.Dispose
                End If
            End Sub

            Public Function ScanForDAQ() As Boolean
                Dim flag As Boolean
                Try 
                    Logging.AddLogEntry(Me, "Starting ScanForDAQ", EventLogEntryType.Information, 4)
                    If (Enumerable.Count(Of String)(DaqSystem.Local.Devices) > 0) Then
                        Logging.AddLogEntry(Me, "clsDAQ.PST.ScanForDAQ: DAQ Found.", EventLogEntryType.Information, 2)
                        flag = True
                    Else
                        Dim prompt As String = "No DAQ found. Likely that the DAQ is not connected."
                        Logging.AddLogEntry(Me, ("clsDAQ.PST.ScanForDAQ: " & prompt), EventLogEntryType.Error, 0)
                        Interaction.MsgBox(prompt, MsgBoxStyle.Critical, Nothing)
                        flag = False
                    End If
                Catch exception1 As Exception
                    Dim ex As Exception = exception1
                    ProjectData.SetProjectError(ex)
                    Dim exception As Exception = ex
                    Dim msg As String = ("clsDAQ.PST.ScanForDAQ: Error: Likely that the DAQ drivers are not installed or not properly installed." & "   " & ChrW(13) & ChrW(10) & exception.Message.ToString)
                    Logging.AddLogEntry(Me, msg, EventLogEntryType.Error, 0)
                    Interaction.MsgBox(msg, MsgBoxStyle.Critical, Nothing)
                    flag = False
                    ProjectData.ClearProjectError
                End Try
                Return flag
            End Function

            Public Sub SetTareVoltage()
                Logging.AddLogEntry(Me, "SetTareVoltage: Starting", EventLogEntryType.Information, 3)
                Dim smallDAQSample(,) As Double(0 To .,0 To .) = Me.GetSmallDAQSample
                Dim num As Double = 0
                Dim num5 As Integer = Information.UBound(smallDAQSample, 2)
                Dim num4 As Integer = 0
                Do While True
                    Dim num6 As Integer = num5
                    If (num4 > num6) Then
                        num = (num / CDbl((Information.UBound(smallDAQSample, 2) + 1)))
                        Dim num2 As Integer = 1
                        If Me.DaqInfo.InvertSignal Then
                            num2 = -1
                        End If
                        Dim num3 As Double = (num - ((Me.DaqInfo.SensorIntercept / Me.DaqInfo.SensorSlope) * num2))
                        Me._TareVoltage = num3
                        Logging.AddLogEntry(Me, ("SetTareVoltage: Tare = " & Conversions.ToString(num3)), EventLogEntryType.Information, 4)
                        Logging.AddLogEntry(Me, "SetTareVoltage: Complete", EventLogEntryType.Information, 3)
                        Return
                    End If
                    num = (num + smallDAQSample(0, num4))
                    num4 += 1
                Loop
            End Sub

            Public Sub StopAcquisition()
                If Not Object.ReferenceEquals(Me.runningTask, Nothing) Then
                    Logging.AddLogEntry(Me, "Stopping data acquisition", EventLogEntryType.Information, 3)
                    Me.runningTask = Nothing
                    Me.myTask.Control(TaskAction.Stop)
                    Me.myTask.Control(TaskAction.Unreserve)
                    Me.myTask.Stop
                    Me.myTask.Dispose
                End If
            End Sub

            Private Sub thd_AcquireData()
                If Not (Object.ReferenceEquals(Me.runningTask, Nothing) And Me.ScanForDAQ) Then
                    If Not Object.ReferenceEquals(Me.runningTask, Nothing) Then
                        Logging.AddLogEntry(Me, "thd_AcquireData: Task is already running.", EventLogEntryType.Error, 0)
                    End If
                Else
                    Try 
                        Me.myTask = New Task
                        Me.myTask.AIChannels.CreateVoltageChannel(Me.DaqInfo.PhysicalChannelName, Me.DaqInfo.SeriesName, DirectCast(-1, AITerminalConfiguration), -5, 5, AIVoltageUnits.Volts)
                        Me.myTask.Timing.ConfigureSampleClock(Nothing, Me.SampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, &H3E8)
                        Me.myTask.Control(TaskAction.Verify)
                        Dim samplesPerChannel As Integer = 10
                        Me.runningTask = Me.myTask
                        Me.analogInReader = New AnalogMultiChannelReader(Me.myTask.Stream)
                        Me.analogInReader.SynchronizeCallbacks = True
                        Me.analogCallback = New AsyncCallback(AddressOf Me.AnalogInCallback)
                        Me.analogInReader.BeginReadMultiSample(samplesPerChannel, Me.analogCallback, Me.myTask)
                        Me.CollectionStarted = True
                    Catch exception1 As DaqException
                        Dim ex As DaqException = exception1
                        ProjectData.SetProjectError(ex)
                        Dim exception As DaqException = ex
                        Logging.AddLogEntry(Me, ("thd_AcquireData: Error: " & exception.ToString), EventLogEntryType.Error, 0)
                        Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, Nothing)
                        Me.runningTask = Nothing
                        Me.myTask.Dispose
                        ProjectData.ClearProjectError
                    End Try
                End If
            End Sub


            ' Properties
            Private Property _TareVoltage As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__TareVoltage
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__TareVoltage = AutoPropertyValue
                End Set
            End Property

            Private Property _SampleRate As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SampleRate
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me.__SampleRate = AutoPropertyValue
                End Set
            End Property

            Public Property SampleRate As Double
                Get
                    Return Me._SampleRate
                End Get
                Set(ByVal value As Double)
                    Me._SampleRate = value
                End Set
            End Property

            Public Property DaqInfo As DAQChannelInfo
                <DebuggerNonUserCode> _
                Get
                    Return Me._DaqInfo
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As DAQChannelInfo)
                    Me._DaqInfo = AutoPropertyValue
                End Set
            End Property

            Public Property ReturnData As ReturnedData
                <DebuggerNonUserCode> _
                Get
                    Return Me._ReturnData
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As ReturnedData)
                    Me._ReturnData = AutoPropertyValue
                End Set
            End Property


            ' Fields
            Private runningTask As Task
            Private myTask As Task
            Private analogInReader As AnalogMultiChannelReader
            Private analogCallback As AsyncCallback
            Private thdAcquire As Thread
            Private CollectionStarted As Boolean = False
            Private Const SamplesPerChannel As Double = 10
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __TareVoltage As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SampleRate As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _DaqInfo As DAQChannelInfo
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _ReturnData As ReturnedData
        End Class

        Public Class ReturnedData
            ' Methods
            Public Sub New()
                Me.List = New List(Of lstReturnedData)
            End Sub


            ' Properties
            Friend Property List As List(Of lstReturnedData)
                <DebuggerNonUserCode> _
                Get
                    Return Me._List
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As List(Of lstReturnedData))
                    Me._List = AutoPropertyValue
                End Set
            End Property

            Public ReadOnly Property XVal As Double()
                Get
                    Dim array As Double() = New Double(((Me.List.Count - 1) + 1)  - 1) {}
                    Dim num2 As Integer = Information.UBound(array, 1)
                    Dim index As Integer = 0
                    Do While True
                        Dim num3 As Integer = num2
                        If (index > num3) Then
                            Return array
                        End If
                        array(index) = Me.List(index).XVal
                        index += 1
                    Loop
                End Get
            End Property

            Public ReadOnly Property YVal As Double()
                Get
                    Dim array As Double() = New Double(((Me.List.Count - 1) + 1)  - 1) {}
                    Dim num2 As Integer = Information.UBound(array, 1)
                    Dim index As Integer = 0
                    Do While True
                        Dim num3 As Integer = num2
                        If (index > num3) Then
                            Return array
                        End If
                        array(index) = Me.List(index).YVal
                        index += 1
                    Loop
                End Get
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _List As List(Of lstReturnedData)

            ' Nested Types
            Friend Class lstReturnedData
                Inherits DAQChannelInfo
                ' Properties
                Public Property XVal As Double
                    <DebuggerNonUserCode> _
                    Get
                        Return Me._XVal
                    End Get
                    <DebuggerNonUserCode> _
                    Set(ByVal AutoPropertyValue As Double)
                        Me._XVal = AutoPropertyValue
                    End Set
                End Property

                Public Property YVal As Double
                    <DebuggerNonUserCode> _
                    Get
                        Return Me._YVal
                    End Get
                    <DebuggerNonUserCode> _
                    Set(ByVal AutoPropertyValue As Double)
                        Me._YVal = AutoPropertyValue
                    End Set
                End Property


                ' Fields
                <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
                Private _XVal As Double
                <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
                Private _YVal As Double
            End Class
        End Class
    End Class
End Namespace

