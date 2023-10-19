// Decompiled with JetBrains decompiler
// Type: FUEL.BigRed.TestVariables
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System;
using System.Diagnostics;

namespace FUEL.BigRed
{
  public class TestVariables
  {
    public TestVariables()
    {
      this.AutoDataOnSchedule = false;
      this.PassiveAutoData = false;
      this.UploadDataToGradeBook = false;
      this.TestRunningOutsideOfHPFireWall = false;
      this.CollectDataForEveryPrintJob = true;
      this.SendDataViaEmail = false;
      this.MessagePriority = 3;
      this.ReplacePgNrWithPlotCD = false;
      this.PrintProtocol = "eLIDIL";
      this.AutomaticeLIDILMode = true;
      this.PCLFileLocation = (string) null;
      this.NozzlePatternLocation = (string) null;
      this.AddCRLFToHeaders = false;
    }

    public bool AutoDataOnSchedule { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool PassiveAutoData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool UploadDataToGradeBook { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool TestRunningOutsideOfHPFireWall { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool CollectDataForEveryPrintJob { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool SendDataViaEmail { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public int MessagePriority { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool ReplacePgNrWithPlotCD { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string PrintProtocol { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool AutomaticeLIDILMode { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string PCLFileLocation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string NozzlePatternLocation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool AddCRLFToHeaders { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _EmailAddress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string EmailAddress
    {
      get => this._EmailAddress;
      set => this._EmailAddress = value.Trim().ToLower().EndsWith("@hp.com") ? value : throw new ArgumentException("Email address must end with '@hp.com'");
    }

    public string[] GradeBookData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string[] FooterData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
  }
}
