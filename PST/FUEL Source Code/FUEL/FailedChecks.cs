// Decompiled with JetBrains decompiler
// Type: FUEL.FailedChecks
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Diagnostics;
using System.Windows.Forms;

namespace FUEL
{
  public class FailedChecks : FSDialog
  {
    private string _Name { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Val { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private PST.SpecType _CheckType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Spec1 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Spec2 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Instructions { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public FailedChecks(
      string Name,
      string Val,
      PST.SpecType CheckType,
      string Spec1,
      string Instructions)
      : this(Name, Val, CheckType, Spec1, (string) null, Instructions)
    {
    }

    public FailedChecks(
      string Name,
      string Val,
      PST.SpecType CheckType,
      string Spec1,
      string Spec2,
      string Instructions)
    {
      this._Name = Name;
      this._Val = Val;
      this._CheckType = CheckType;
      this._Spec1 = Spec1;
      this._Spec2 = Spec2;
      this._Instructions = Instructions;
    }

    public void Show() => this.Show((Form) new dlgCriticalCheckFailed(this._Name, this._Val, this._CheckType, this._Spec1, this._Spec2, this._Instructions));
  }
}
