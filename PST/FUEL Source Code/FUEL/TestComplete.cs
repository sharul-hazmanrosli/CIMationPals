// Decompiled with JetBrains decompiler
// Type: FUEL.TestComplete
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  public class TestComplete : FSDialog
  {
    private object _Passed
    {
      [DebuggerNonUserCode] get => this.__Passed;
      [DebuggerNonUserCode] set => this.__Passed = RuntimeHelpers.GetObjectValue(value);
    }

    public TestComplete(bool Passed) => this._Passed = (object) Passed;

    public void Show() => this.Show((Form) new dlgTestComplete(Conversions.ToBoolean(this._Passed)));
  }
}
