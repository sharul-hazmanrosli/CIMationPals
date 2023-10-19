// Decompiled with JetBrains decompiler
// Type: FUEL.FS.Math
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Diagnostics;

namespace FUEL.FS
{
  public class Math
  {
    [DebuggerNonUserCode]
    public Math()
    {
    }

    public static bool IsCloseTo(double PrimaryVal, double SecondaryVal)
    {
      double Threshold = PrimaryVal * 0.1;
      return Math.IsCloseTo(PrimaryVal, SecondaryVal, Threshold);
    }

    public static bool IsCloseTo(double PrimaryVal, double SecondaryVal, double Threshold) => System.Math.Max(PrimaryVal, SecondaryVal) - System.Math.Min(PrimaryVal, SecondaryVal) <= Threshold;
  }
}
