// Decompiled with JetBrains decompiler
// Type: NIDAQ.NIDAQ
// Assembly: NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E0A2D9-BC78-4088-A605-9E0C1595E02F
// Assembly location: C:\Program Files (x86)\CIMProjects.Net\Marconi\NIDAQ\amd64\NIDAQ.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NationalInstruments;
using NationalInstruments.DAQmx;
using System;
using System.IO;

namespace NIDAQ
{
  public class NIDAQ
  {
    private bool Init_;
    private Device ThisDevice_;
    private Task myTask_;
    private AnalogMultiChannelReader reader_;
    private DigitalSingleChannelReader myDigitalReader_;
    private string NIDAQDevice_;
    private double[,] Readings_;
    private NIDAQForm Timer1_;
    private TimerTriggerInfo TimerInfo_;
    private bool ReadAnalogAsyncComplete_;
    private string ReadAnalogError_;
    private int AISamplingRateHz_;
    private int NumberSamples_;
    private double[] Gains_;
    private double[] Offsets_;
    private bool GainsOffsetsSet_;
    private bool Convert_;

    public NIDAQ()
    {
      this.Init_ = false;
      this.GainsOffsetsSet_ = false;
    }

    public bool InitNIDAQ(ref string DevSerialNumber, ref string sFailInfo)
    {
      string[] devices = DaqSystem.Local.Devices;
      if (devices.Length != 1)
      {
        sFailInfo = "Need one NIDAQ";
        return false;
      }
      this.ThisDevice_ = DaqSystem.Local.LoadDevice(devices[0]);
      DevSerialNumber = Conversions.ToString(this.ThisDevice_.SerialNumber);
      this.NIDAQDevice_ = devices[0];
      this.Init_ = true;
      return true;
    }

    public bool GetNIDAQChannels(
      ref string[] AIs,
      ref string[] DIs,
      ref string[] DOs,
      ref string sFailInfo)
    {
      sFailInfo = "";
      if (!this.Init_)
      {
        sFailInfo = "NIDAQ is not initialized";
        return false;
      }
      AIs = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External);
      DIs = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DILine, PhysicalChannelAccess.External);
      DOs = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOLine, PhysicalChannelAccess.External);
      return true;
    }

    public void SetGainsOffsets(double[] Gains, double[] Offsets)
    {
      this.Gains_ = Gains;
      this.Offsets_ = Offsets;
      this.GainsOffsetsSet_ = true;
    }

    public object AISamplingRateHz
    {
      get => (object) this.AISamplingRateHz_;
      set => this.AISamplingRateHz_ = Conversions.ToInteger(value);
    }

    public object NumberSamples
    {
      get => (object) this.NumberSamples_;
      set => this.NumberSamples_ = Conversions.ToInteger(value);
    }

    public void ClearReadAnalogAsync()
    {
      this.ReadAnalogError_ = "";
      this.Readings_ = (double[,]) null;
      this.ReadAnalogAsyncComplete_ = false;
      this.Convert_ = false;
    }

    public bool IsReadAnalogAsyncComplete() => this.ReadAnalogAsyncComplete_;

    public bool ReadAnalogAsync(string Channels, bool Convert, ref string sFailInfo) => this.ReadAnalogAsync(Channels, this.AISamplingRateHz_, this.NumberSamples_, Convert, ref sFailInfo);

    public bool ReadAnalogAsync(
      string Channels,
      int AISamplingRateHz,
      int NumberSamples,
      bool Convert,
      ref string sFailInfo)
    {
      if (Convert & !this.GainsOffsetsSet_)
      {
        sFailInfo = "No Gains or Offsets have been set";
        return false;
      }
      this.TimerInfo_.Channels = Channels;
      this.TimerInfo_.NumberSamples = NumberSamples;
      this.TimerInfo_.AISamplingRateHz = AISamplingRateHz;
      this.ReadAnalogAsyncComplete_ = false;
      this.Convert_ = Convert;
      this.Timer1_ = new NIDAQForm();
      this.Timer1_.Setup((object) this);
      return true;
    }

    public void StartReadAnalogAsync()
    {
      string sFailInfo = "";
      this.ReadAnalog(this.TimerInfo_.Channels, this.TimerInfo_.AISamplingRateHz, this.TimerInfo_.NumberSamples, this.Convert_, ref this.Readings_, ref sFailInfo);
      this.ReadAnalogAsyncComplete_ = true;
      this.Timer1_ = (NIDAQForm) null;
    }

    public bool RetrieveReadings(ref double[,] V, ref string sFailInfo)
    {
      V = this.Readings_;
      sFailInfo = this.ReadAnalogError_;
      this.Readings_ = (double[,]) null;
      this.ReadAnalogError_ = "";
      return Operators.CompareString(sFailInfo, "", false) == 0;
    }

    public bool ReadSingleAnalog(
      string Channels,
      bool Convert,
      ref double[] V,
      ref string sFailInfo)
    {
      bool flag = false;
      sFailInfo = "";
      if (!this.Init_)
      {
        sFailInfo = "NIDAQ is not initialized";
        return false;
      }
      if (Convert & !this.GainsOffsetsSet_)
      {
        sFailInfo = "No Gains or Offsets have been set";
        return false;
      }
      try
      {
        this.myTask_ = new Task();
        this.myTask_.AIChannels.CreateVoltageChannel(Channels, "AIChannel", AITerminalConfiguration.Rse, -10.0, 10.0, AIVoltageUnits.Volts);
        this.myTask_.Control(TaskAction.Verify);
        this.reader_ = new AnalogMultiChannelReader(this.myTask_.Stream);
        V = this.reader_.ReadSingleSample();
        if (Convert)
        {
          if (Information.LBound((Array) V) != Information.LBound((Array) this.Gains_) | Information.UBound((Array) V) != Information.UBound((Array) this.Gains_) | Information.LBound((Array) V) != Information.LBound((Array) this.Offsets_) | Information.UBound((Array) V) != Information.UBound((Array) this.Offsets_))
          {
            sFailInfo = "Mismatch in the number of channels read and the gains or offsets";
            return false;
          }
          int num1 = Information.LBound((Array) V);
          int num2 = Information.UBound((Array) V);
          int index = num1;
          while (index <= num2)
          {
            V[index] = this.Gains_[index] * V[index] + this.Offsets_[index];
            checked { ++index; }
          }
        }
        flag = true;
      }
      catch (DaqException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        DaqException daqException = ex;
        sFailInfo = daqException.Message;
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (this.myTask_ != null)
          this.myTask_.Dispose();
      }
      return flag;
    }

    public bool ReadAnalog(string Channels, bool Convert, ref double[,] Vs, ref string sFailInfo) => this.ReadAnalog(Channels, this.AISamplingRateHz_, this.NumberSamples_, Convert, ref Vs, ref sFailInfo);

    public bool ReadAnalog(
      string Channels,
      int AISamplingRateHz,
      int NumberSamples,
      bool Convert,
      ref double[,] Vs,
      ref string sFailInfo)
    {
      bool flag = false;
      sFailInfo = "";
      if (!this.Init_)
      {
        sFailInfo = "NIDAQ is not initialized";
        return false;
      }
      if (Convert & !this.GainsOffsetsSet_)
      {
        sFailInfo = "No Gains or Offsets have been set";
        return false;
      }
      try
      {
        this.myTask_ = new Task();
        this.myTask_.AIChannels.CreateVoltageChannel(Channels, "Read Analog", AITerminalConfiguration.Rse, -10.0, 10.0, AIVoltageUnits.Volts);
        this.myTask_.Timing.ConfigureSampleClock("", (double) AISamplingRateHz, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, NumberSamples);
        this.myTask_.Control(TaskAction.Verify);
        this.reader_ = new AnalogMultiChannelReader(this.myTask_.Stream);
        this.DataToReadings(this.reader_.ReadWaveform(NumberSamples), NumberSamples, Convert, ref sFailInfo);
        if (Vs != this.Readings_)
          Vs = this.Readings_;
        flag = true;
      }
      catch (DaqException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        DaqException daqException = ex;
        sFailInfo = daqException.Message;
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (this.myTask_ != null)
          this.myTask_.Dispose();
      }
      return flag;
    }

    private bool DataToReadings(
      AnalogWaveform<double>[] sourceArray,
      int NumberSamples,
      bool Convert,
      ref string sFailInfo)
    {
      int index1 = 0;
      this.Readings_ = new double[checked (NumberSamples - 1 + 1), checked (sourceArray.Length - 1 + 1)];
      if (Convert && Information.LBound((Array) this.Readings_, 2) != Information.LBound((Array) this.Gains_) | Information.UBound((Array) this.Readings_, 2) != Information.UBound((Array) this.Gains_) | Information.LBound((Array) this.Readings_, 2) != Information.LBound((Array) this.Offsets_) | Information.UBound((Array) this.Readings_, 2) != Information.UBound((Array) this.Offsets_))
      {
        sFailInfo = "Mismatch in the number of channels read and the gains or offsets";
        return false;
      }
      AnalogWaveform<double>[] analogWaveformArray = sourceArray;
      int index2 = 0;
      while (index2 < analogWaveformArray.Length)
      {
        AnalogWaveform<double> analogWaveform = analogWaveformArray[index2];
        int num = checked (NumberSamples - 1);
        int sampleIndex = 0;
        while (sampleIndex <= num)
        {
          this.Readings_[sampleIndex, index1] = !Convert ? analogWaveform.Samples[sampleIndex].Value : this.Gains_[index1] * analogWaveform.Samples[sampleIndex].Value + this.Offsets_[index1];
          checked { ++sampleIndex; }
        }
        checked { ++index1; }
        checked { ++index2; }
      }
      return true;
    }

    public bool ReadDigital(string Channels, ref bool[] DOs, ref string sFailInfo)
    {
      bool flag = false;
      sFailInfo = "";
      if (!this.Init_)
      {
        sFailInfo = "NIDAQ is not initialized";
        return false;
      }
      try
      {
        this.myTask_ = new Task();
        this.myTask_.DIChannels.CreateChannel(Channels, "DigitalRead", ChannelLineGrouping.OneChannelForAllLines);
        this.myTask_.Control(TaskAction.Verify);
        this.myDigitalReader_ = new DigitalSingleChannelReader(this.myTask_.Stream);
        DOs = this.myDigitalReader_.ReadSingleSampleMultiLine();
        flag = true;
      }
      catch (DaqException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        DaqException daqException = ex;
        sFailInfo = daqException.Message;
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (this.myTask_ != null)
          this.myTask_.Dispose();
      }
      return flag;
    }

    public bool WriteDigital(string Channels, bool[] Dig, ref string sFailInfo)
    {
      bool flag = false;
      sFailInfo = "";
      if (!this.Init_)
      {
        sFailInfo = "NIDAQ is not initialized";
        return false;
      }
      try
      {
        this.myTask_ = new Task();
        this.myTask_.DOChannels.CreateChannel(Channels, "DigitalWrite", ChannelLineGrouping.OneChannelForAllLines);
        this.myTask_.Control(TaskAction.Verify);
        new DigitalSingleChannelWriter(this.myTask_.Stream).WriteSingleSampleMultiLine(true, Dig);
        flag = true;
      }
      catch (DaqException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        DaqException daqException = ex;
        sFailInfo = daqException.Message;
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (this.myTask_ != null)
          this.myTask_.Dispose();
      }
      return flag;
    }

    public void LogDebug(string M)
    {
      StreamWriter streamWriter = new StreamWriter("C:\\temp\\gss.log", true);
      streamWriter.WriteLine(M);
      streamWriter.Close();
    }
  }
}
