// Decompiled with JetBrains decompiler
// Type: FUEL.TestSpecs
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace FUEL
{
  public class TestSpecs
  {
    private string _TestID { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<PST.PrinterMechChecks> _MechChecks { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private PST _PST { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string TestID
    {
      get => Operators.CompareString(this.PST.TestID, (string) null, false) != 0 ? this.PST.TestID : this._TestID;
      set => this._TestID = value;
    }

    public PST PST
    {
      get => this._PST;
      set => this._PST = value;
    }

    public TestSpecs() => this._MechChecks = new List<PST.PrinterMechChecks>();
  }
}
