// Decompiled with JetBrains decompiler
// Type: FUEL.DAQ
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NationalInstruments.DAQmx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace FUEL
{
  public class DAQ
  {
    [DebuggerNonUserCode]
    public DAQ()
    {
    }

    public class DAQChannelInfo
    {
      public DAQChannelInfo()
      {
        this._InvertSignal = false;
        this.ReadyToGo = false;
      }

      private string _PhysicalChannelName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _ChannelPosition { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _SeriesName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private DAQ.DAQChannelInfo.Sensors _SensorName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _SensorSlope { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _SensorIntercept { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private DAQ.DAQChannelInfo.Units _SensorUnits { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _InvertSignal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      internal bool ReadyToGo { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string PhysicalChannelName => this._PhysicalChannelName;

      public int ChannelPosition => this._ChannelPosition;

      public string SeriesName => this._SeriesName;

      public DAQ.DAQChannelInfo.Sensors SensorName => this._SensorName;

      public double SensorSlope => this._SensorSlope;

      public double SensorIntercept => this._SensorIntercept;

      public DAQ.DAQChannelInfo.Units SensorUnits => this._SensorUnits;

      public bool InvertSignal
      {
        get => this._InvertSignal;
        set => this._InvertSignal = value;
      }

      private void SetStdCalValues()
      {
        string[] source = Microsoft.VisualBasic.Strings.Split(MySettingsProperty.Settings.SensorCalibrations, "|");
        bool flag = false;
        int index = 0;
        while (!flag & index < ((IEnumerable<string>) source).Count<string>())
        {
          string[] strArray = Microsoft.VisualBasic.Strings.Split(source[index], ";");
          if (Operators.CompareString(strArray[0].ToUpper(), this.SensorName.ToString().ToUpper(), false) == 0 & Operators.CompareString(strArray[3].ToUpper(), this.SensorUnits.ToString().ToUpper(), false) == 0)
          {
            flag = true;
            this._SensorIntercept = Conversions.ToDouble(strArray[2]);
            this._SensorSlope = Conversions.ToDouble(strArray[1]);
          }
        }
      }

      public void SetChannelProperties(
        int ChannelPosition,
        string SeriesName,
        DAQ.DAQChannelInfo.Sensors SensorName,
        DAQ.DAQChannelInfo.Units SensorUnits)
      {
        this._PhysicalChannelName = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[ChannelPosition];
        this._ChannelPosition = ChannelPosition;
        this._SeriesName = SeriesName;
        this._SensorName = SensorName;
        this._SensorUnits = SensorUnits;
        this.SetStdCalValues();
        this.ReadyToGo = true;
      }

      public void SetChannelProperties(
        int ChannelPosition,
        string SeriesName,
        double CalSlope,
        double CalIntercept,
        DAQ.DAQChannelInfo.Units SensorUnits)
      {
        this._PhysicalChannelName = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External)[ChannelPosition];
        this._ChannelPosition = ChannelPosition;
        this._SeriesName = SeriesName;
        this._SensorName = DAQ.DAQChannelInfo.Sensors.Custom;
        this._SensorSlope = CalSlope;
        this._SensorIntercept = CalIntercept;
        this._SensorUnits = SensorUnits;
        this.ReadyToGo = true;
      }

      public enum Sensors
      {
        AP41M,
        Custom,
      }

      public enum Units
      {
        InchesWater,
        InchesHg,
        Voltage,
        Custom,
      }
    }

    public class ReturnedData
    {
      public ReturnedData() => this.List = new List<DAQ.ReturnedData.lstReturnedData>();

      internal List<DAQ.ReturnedData.lstReturnedData> List { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double[] XVal
      {
        get
        {
          double[] xval = new double[checked (this.List.Count - 1 + 1)];
          int num = Information.UBound((Array) xval);
          int index = 0;
          while (index <= num)
          {
            xval[index] = this.List[index].XVal;
            checked { ++index; }
          }
          return xval;
        }
      }

      public double[] YVal
      {
        get
        {
          double[] yval = new double[checked (this.List.Count - 1 + 1)];
          int num = Information.UBound((Array) yval);
          int index = 0;
          while (index <= num)
          {
            yval[index] = this.List[index].YVal;
            checked { ++index; }
          }
          return yval;
        }
      }

      internal class lstReturnedData : DAQ.DAQChannelInfo
      {
        [DebuggerNonUserCode]
        public lstReturnedData()
        {
        }

        public double XVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

        public double YVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
      }
    }

    public class PST
    {
      private Task runningTask;
      private Task myTask;
      private AnalogMultiChannelReader analogInReader;
      private AsyncCallback analogCallback;
      private Thread thdAcquire;
      private bool CollectionStarted;
      private const double SamplesPerChannel = 10.0;

      private double _TareVoltage { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _SampleRate { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double SampleRate
      {
        get => this._SampleRate;
        set => this._SampleRate = value;
      }

      public DAQ.DAQChannelInfo DaqInfo { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public DAQ.ReturnedData ReturnData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool ScanForDAQ()
      {
        bool flag;
        try
        {
          Logging.AddLogEntry((object) this, "Starting ScanForDAQ", EventLogEntryType.Information, 4);
          if (((IEnumerable<string>) DaqSystem.Local.Devices).Count<string>() > 0)
          {
            Logging.AddLogEntry((object) this, "clsDAQ.PST.ScanForDAQ: DAQ Found.", EventLogEntryType.Information, 2);
            flag = true;
          }
          else
          {
            string Prompt = "No DAQ found. Likely that the DAQ is not connected.";
            Logging.AddLogEntry((object) this, "clsDAQ.PST.ScanForDAQ: " + Prompt, EventLogEntryType.Error, 0);
            int num = (int) Interaction.MsgBox((object) Prompt, MsgBoxStyle.Critical);
            flag = false;
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          string str = "clsDAQ.PST.ScanForDAQ: Error: Likely that the DAQ drivers are not installed or not properly installed." + "   \r\n" + ex.Message.ToString();
          Logging.AddLogEntry((object) this, str, EventLogEntryType.Error, 0);
          int num = (int) Interaction.MsgBox((object) str, MsgBoxStyle.Critical);
          flag = false;
          ProjectData.ClearProjectError();
        }
        return flag;
      }

      public void SetTareVoltage()
      {
        Logging.AddLogEntry((object) this, "SetTareVoltage: Starting", EventLogEntryType.Information, 3);
        double[,] smallDaqSample = this.GetSmallDAQSample();
        double num1 = 0.0;
        int num2 = Information.UBound((Array) smallDaqSample, 2);
        int index = 0;
        while (index <= num2)
        {
          num1 += smallDaqSample[0, index];
          checked { ++index; }
        }
        double num3 = num1 / (double) checked (Information.UBound((Array) smallDaqSample, 2) + 1);
        int num4 = 1;
        if (this.DaqInfo.InvertSignal)
          num4 = -1;
        double num5 = num3 - this.DaqInfo.SensorIntercept / this.DaqInfo.SensorSlope * (double) num4;
        this._TareVoltage = num5;
        Logging.AddLogEntry((object) this, "SetTareVoltage: Tare = " + Conversions.ToString(num5), EventLogEntryType.Information, 4);
        Logging.AddLogEntry((object) this, "SetTareVoltage: Complete", EventLogEntryType.Information, 3);
      }

      public double GetInitialPressure()
      {
        Logging.AddLogEntry((object) this, "GetInitialPressure: Complete", EventLogEntryType.Information, 3);
        double[,] smallDaqSample = this.GetSmallDAQSample();
        double num1 = 0.0;
        int num2 = Information.UBound((Array) smallDaqSample, 2);
        int index = 0;
        while (index <= num2)
        {
          num1 += smallDaqSample[0, index];
          checked { ++index; }
        }
        double num3 = num1 / (double) checked (Information.UBound((Array) smallDaqSample, 2) + 1);
        int num4 = 1;
        if (this.DaqInfo.InvertSignal)
          num4 = -1;
        double initialPressure = Math.Round(((num3 - this._TareVoltage) * this.DaqInfo.SensorSlope + this.DaqInfo.SensorIntercept) * (double) num4, 2);
        Logging.AddLogEntry((object) this, "GetInitialPressure: Initial Pressure = " + Conversions.ToString(initialPressure), EventLogEntryType.Information, 4);
        Logging.AddLogEntry((object) this, "GetInitialPressure: Complete", EventLogEntryType.Information, 3);
        return initialPressure;
      }

      public void acquiredata()
      {
        if (this.DaqInfo.ReadyToGo)
        {
          Logging.AddLogEntry((object) this, "Starting thread acquiredata", EventLogEntryType.Information, 3);
          this.thdAcquire = new Thread(new ThreadStart(this.thd_AcquireData));
          this.thdAcquire.Start();
          while (!this.CollectionStarted)
          {
            Logging.AddLogEntry((object) this, "acquiredata: thread sleep waiting for acquisition to start.", EventLogEntryType.Information, 4);
            Thread.Sleep(30);
          }
          Logging.AddLogEntry((object) this, "acquiredata: Returning control to FlexScript", EventLogEntryType.Information, 4);
        }
        else
        {
          string message = "DAQ Info not yet set, you must setup the DAQ using the DAQChannelInfo class first.";
          Logging.AddLogEntry((object) this, "acquiredata: Error: " + message, EventLogEntryType.Error, 0);
          throw new ApplicationException(message);
        }
      }

      private void thd_AcquireData()
      {
        if (this.runningTask == null & this.ScanForDAQ())
        {
          try
          {
            this.myTask = new Task();
            this.myTask.AIChannels.CreateVoltageChannel(this.DaqInfo.PhysicalChannelName, this.DaqInfo.SeriesName, (AITerminalConfiguration) -1, -5.0, 5.0, AIVoltageUnits.Volts);
            this.myTask.Timing.ConfigureSampleClock((string) null, this.SampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 1000);
            this.myTask.Control(TaskAction.Verify);
            int samplesPerChannel = 10;
            this.runningTask = this.myTask;
            this.analogInReader = new AnalogMultiChannelReader(this.myTask.Stream);
            this.analogInReader.SynchronizeCallbacks = true;
            this.analogCallback = new AsyncCallback(this.AnalogInCallback);
            this.analogInReader.BeginReadMultiSample(samplesPerChannel, this.analogCallback, (object) this.myTask);
            this.CollectionStarted = true;
          }
          catch (DaqException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            DaqException daqException = ex;
            Logging.AddLogEntry((object) this, "thd_AcquireData: Error: " + daqException.ToString(), EventLogEntryType.Error, 0);
            int num = (int) Interaction.MsgBox((object) daqException.Message);
            this.runningTask = (Task) null;
            this.myTask.Dispose();
            ProjectData.ClearProjectError();
          }
        }
        else if (this.runningTask != null)
          Logging.AddLogEntry((object) this, "thd_AcquireData: Task is already running.", EventLogEntryType.Error, 0);
      }

      public void StopAcquisition()
      {
        if (this.runningTask == null)
          return;
        Logging.AddLogEntry((object) this, "Stopping data acquisition", EventLogEntryType.Information, 3);
        this.runningTask = (Task) null;
        this.myTask.Control(TaskAction.Stop);
        this.myTask.Control(TaskAction.Unreserve);
        this.myTask.Stop();
        this.myTask.Dispose();
      }

      public void RecoverFromError()
      {
        Logging.AddLogEntry((object) this, "Recovering from error", EventLogEntryType.Error, 0);
        this.StopAcquisition();
      }

      private void AnalogInCallback(IAsyncResult ar)
      {
        try
        {
          if (this.runningTask != ar.AsyncState)
            return;
          this.AddDataToList(this.analogInReader.EndReadMultiSample(ar));
          this.analogInReader.BeginReadMultiSample(10, this.analogCallback, (object) this.myTask);
        }
        catch (DaqException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          DaqException daqException = ex;
          Logging.AddLogEntry((object) this, "AnalogInCallback: DAQException " + daqException.ToString(), EventLogEntryType.Error, 0);
          int num = (int) Interaction.MsgBox((object) daqException.Message);
          this.StopAcquisition();
          ProjectData.ClearProjectError();
        }
      }

      private void AddDataToList(double[,] sourceArray)
      {
        try
        {
          int num1 = checked (sourceArray.GetLength(1) - 1);
          int index = 0;
          while (index <= num1)
          {
            DAQ.ReturnedData.lstReturnedData lstReturnedData = new DAQ.ReturnedData.lstReturnedData();
            if (this.DaqInfo.SensorName != DAQ.DAQChannelInfo.Sensors.Custom)
              lstReturnedData.SetChannelProperties(this.DaqInfo.ChannelPosition, this.DaqInfo.SeriesName, this.DaqInfo.SensorName, this.DaqInfo.SensorUnits);
            else
              lstReturnedData.SetChannelProperties(this.DaqInfo.ChannelPosition, this.DaqInfo.SeriesName, this.DaqInfo.SensorSlope, this.DaqInfo.SensorIntercept, this.DaqInfo.SensorUnits);
            int num2 = 1;
            if (this.DaqInfo.InvertSignal)
              num2 = -1;
            lstReturnedData.XVal = Math.Round((double) this.ReturnData.List.Count / this.SampleRate, 4);
            lstReturnedData.YVal = Math.Round(((sourceArray[0, index] - this._TareVoltage) * this.DaqInfo.SensorSlope + this.DaqInfo.SensorIntercept) * (double) num2, 2);
            this.ReturnData.List.Add(lstReturnedData);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Logging.AddLogEntry((object) this, "AddDataToList: Error " + exception.ToString(), EventLogEntryType.Error, 0);
          int num = (int) Interaction.MsgBox((object) exception.ToString());
          this.StopAcquisition();
          ProjectData.ClearProjectError();
        }
      }

      private double[,] GetSmallDAQSample()
      {
        double[,] smallDaqSample;
        if (this.runningTask == null & this.ScanForDAQ())
        {
          try
          {
            this.myTask = new Task();
            this.myTask.AIChannels.CreateVoltageChannel(this.DaqInfo.PhysicalChannelName, this.DaqInfo.SeriesName, (AITerminalConfiguration) -1, -5.0, 5.0, AIVoltageUnits.Volts);
            this.myTask.Control(TaskAction.Verify);
            this.runningTask = this.myTask;
            smallDaqSample = new AnalogMultiChannelReader(this.myTask.Stream).ReadMultiSample(10);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            Logging.AddLogEntry((object) this, "GetSmallDAQSample: Error: " + exception.ToString(), EventLogEntryType.Error, 0);
            int num = (int) Interaction.MsgBox((object) ("GetSmallDAQSample: Error: \r\n" + exception.ToString()), MsgBoxStyle.Critical);
            smallDaqSample = (double[,]) null;
            ProjectData.ClearProjectError();
          }
          finally
          {
            this.StopAcquisition();
            this.runningTask = (Task) null;
          }
        }
        else
        {
          if (this.runningTask != null)
            Logging.AddLogEntry((object) this, "GetSmallDAQSample: Task is already running.", EventLogEntryType.Error, 0);
          smallDaqSample = (double[,]) null;
        }
        return smallDaqSample;
      }

      public PST()
      {
        this.CollectionStarted = false;
        this._SampleRate = 40.0;
        this.DaqInfo = new DAQ.DAQChannelInfo();
        this.ReturnData = new DAQ.ReturnedData();
        Logging.AddLogEntry((object) this, "***Starting DAQ***", EventLogEntryType.Information, 3);
      }

      public void ResetDAQ()
      {
        if (this.ScanForDAQ())
        {
          Device device = DaqSystem.Local.LoadDevice(DaqSystem.Local.Devices[0]);
          device.Reset();
          device.Dispose();
        }
        else
        {
          int num = (int) Interaction.MsgBox((object) "No DAQ Found, nothing to reset");
        }
      }
    }
  }
}
