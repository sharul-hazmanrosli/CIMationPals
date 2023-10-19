// Decompiled with JetBrains decompiler
// Type: FUEL.TraceData
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Diagnostics;

namespace FUEL
{
  public class TraceData
  {
    [DebuggerNonUserCode]
    public TraceData()
    {
    }

    private double _X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _SlidingAVG { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _DxDt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _DxDt2 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public double X
    {
      get => this._X;
      set => this._X = value;
    }

    public double Y
    {
      get => this._Y;
      set => this._Y = value;
    }

    public double SlidingAVG
    {
      get => this._SlidingAVG;
      set => this._SlidingAVG = value;
    }

    public double DxDt
    {
      get => this._DxDt;
      set => this._DxDt = value;
    }

    public double DxDt2
    {
      get => this._DxDt2;
      set => this._DxDt2 = value;
    }
  }
}
