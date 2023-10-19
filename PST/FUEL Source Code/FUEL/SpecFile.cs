// Decompiled with JetBrains decompiler
// Type: FUEL.SpecFile
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Collections.Generic;
using System.Diagnostics;

namespace FUEL
{
  public class SpecFile
  {
    private List<TestSpecs> _Tests { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public List<TestSpecs> Tests
    {
      get => this._Tests;
      set => this._Tests = value;
    }

    public SpecFile() => this._Tests = new List<TestSpecs>();
  }
}
