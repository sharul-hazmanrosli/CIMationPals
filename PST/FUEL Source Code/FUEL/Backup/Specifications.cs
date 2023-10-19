// Decompiled with JetBrains decompiler
// Type: FUEL.Specifications
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace FUEL
{
  public class Specifications
  {
    private PST.Channel _PumpChannel { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _PressureMax { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _PressureMin { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _VentTime { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _VentDeltaPMin { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _VentDxDt2Threshold { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _DerivCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _HoldTime { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _LeakMin { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _LeakMax { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _AllowWetPHA { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _AllowDryPHA { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _TubeEvacDeltaPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _WetPHAHoldTimeRetardVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private long _PumpVolume { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _PumpRate { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double[] _PressureBuildDelay { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public int HoldTime
    {
      get => this._HoldTime;
      set => this._HoldTime = value;
    }

    internal int DerivCnt => this._DerivCnt;

    public int PressureMax
    {
      get => this._PressureMax;
      set => this._PressureMax = value;
    }

    public int PressureMin
    {
      get => this._PressureMin;
      set => this._PressureMin = value;
    }

    public int LeakMax
    {
      get => this._LeakMax;
      set => this._LeakMax = value;
    }

    public int LeakMin
    {
      get => this._LeakMin;
      set => this._LeakMin = value;
    }

    public double VentTime
    {
      get => this._VentTime;
      set => this._VentTime = value;
    }

    public double VentDeltaPMin => this._VentDeltaPMin;

    public double VentDxDt2Threshold => this._VentDxDt2Threshold;

    public bool AllowWetPHA
    {
      get => this._AllowWetPHA;
      set
      {
        this._AllowWetPHA = value;
        if (value)
        {
          this._WetPHAHoldTimeRetardVal = 3;
          this._VentDeltaPMin = 10.0;
          this.LeakMin = -20;
        }
        else
          this._VentDeltaPMin = 60.0;
        if (this.PumpChannel == PST.Channel.Black)
        {
          if (this.AllowWetPHA)
            this._PressureBuildDelay = new double[2]
            {
              -0.7898,
              3.1361
            };
          else
            this._PressureBuildDelay = new double[2]
            {
              0.0,
              0.0
            };
        }
        else
        {
          if (this.PumpChannel != PST.Channel.Color)
            return;
          if (this.AllowWetPHA)
            this._PressureBuildDelay = new double[2]
            {
              0.0,
              -383.0 / 400.0
            };
          else
            this._PressureBuildDelay = new double[2]
            {
              0.0,
              0.0
            };
        }
      }
    }

    public int TubeEvacDeltaPressure
    {
      get => this._TubeEvacDeltaPressure;
      set => this._TubeEvacDeltaPressure = value;
    }

    public long PumpVolume
    {
      get => this._PumpVolume;
      set => this._PumpVolume = value;
    }

    public int PumpRate
    {
      get => this._PumpRate;
      set => this._PumpRate = value;
    }

    public double PumpTime => !Information.IsNothing((object) this.PumpRate) & !Information.IsNothing((object) this.PumpVolume) ? 1.0 / (double) this.PumpRate * ((double) this.PumpVolume * 1E-07) * 60.0 : -1.0;

    public int WetPHAHoldTimeRetardVal => this._WetPHAHoldTimeRetardVal;

    public double[] PressureBuildDelay => this._PressureBuildDelay;

    [XmlIgnore]
    public PST.Channel PumpChannel
    {
      get => this._PumpChannel;
      protected set
      {
        this._PumpChannel = value;
        if (this._PumpChannel == PST.Channel.Black)
        {
          if (this.PumpVolume == 0L)
            this.PumpVolume = 9350000L;
          if (this.PumpRate != 0)
            return;
          this.PumpRate = 24;
        }
        else
        {
          if (this.PumpVolume == 0L)
            this.PumpVolume = 15500000L;
          if (this.PumpRate == 0)
            this.PumpRate = 24;
        }
      }
    }

    protected Specifications()
    {
      this._VentDxDt2Threshold = -75.0;
      this._DerivCnt = 12;
      this._LeakMin = -1;
      this._LeakMax = 0;
      this._TubeEvacDeltaPressure = 9;
      this._WetPHAHoldTimeRetardVal = 0;
    }

    public Specifications(PST.Channel PChannel)
    {
      this._VentDxDt2Threshold = -75.0;
      this._DerivCnt = 12;
      this._LeakMin = -1;
      this._LeakMax = 0;
      this._TubeEvacDeltaPressure = 9;
      this._WetPHAHoldTimeRetardVal = 0;
      this.PumpChannel = PChannel;
    }

    internal void SetMaxLeakVal(double t1, double t2) => this.LeakMax = checked ((int) Math.Round(unchecked (t2 - t1 * 5.0)));

    private void DispSpecs()
    {
      int num = (int) Interaction.MsgBox((object) ("Pressure:  " + Conversions.ToString(this.PressureMin) + "/" + Conversions.ToString(this.PressureMax) + "\r\n\r\nLeak:      " + Conversions.ToString(this.LeakMax) + "\r\n\r\nVent Time: " + Conversions.ToString(this.VentTime)), MsgBoxStyle.Information, (object) "Current PST Specs");
    }

    public bool Validate()
    {
      bool flag = true;
      if (Information.IsNothing((object) this.HoldTime))
        flag = false;
      else if (this.HoldTime <= 0)
        flag = false;
      if (Information.IsNothing((object) this.PressureMax))
        flag = false;
      else if (this.PressureMax <= 0)
        flag = false;
      if (Information.IsNothing((object) this.PressureMin))
        flag = false;
      else if (this.PressureMin <= 0 | this.PressureMin > this.PressureMax)
        flag = false;
      if (Information.IsNothing((object) this.LeakMax))
        flag = false;
      else if (this.LeakMin > this.LeakMax)
        flag = false;
      if (Information.IsNothing((object) this.VentTime))
        flag = false;
      else if (this.VentTime <= 0.0)
        flag = false;
      if (Information.IsNothing((object) this.PumpVolume))
        flag = false;
      else if (this.PumpVolume <= 0L)
        flag = false;
      if (Information.IsNothing((object) this.PumpRate))
        flag = false;
      else if (this.PumpRate <= 0)
        flag = false;
      if (this.PumpTime == -1.0)
        flag = false;
      if (!flag)
      {
        int num = (int) Interaction.MsgBox((object) "Specs are not valid. PST results may be comprimised.", MsgBoxStyle.Information);
      }
      return flag;
    }
  }
}
