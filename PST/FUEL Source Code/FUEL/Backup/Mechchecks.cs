// Decompiled with JetBrains decompiler
// Type: FUEL.Mechchecks
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.FS;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FUEL
{
  public class Mechchecks : FSDialog
  {
    private List<PST.PrinterMechChecks> _MechChecks;

    public Mechchecks() => this._MechChecks = new List<PST.PrinterMechChecks>();

    public void Show() => this.Show((Form) new frmMechChecks(this._MechChecks));

    public void AddMechCheck(
      string Name,
      PST.SpecType SpecType,
      double Spec,
      double Value,
      PST.SpecFunction SpecFunction)
    {
      PST.PrinterMechChecks printerMechChecks = new PST.PrinterMechChecks();
      printerMechChecks.AddMechCheck(Name, SpecType, Spec, Value, SpecFunction);
      this._MechChecks.Add(printerMechChecks);
    }

    public void AddMechCheck(
      string Name,
      PST.SpecType SpecType,
      double SpecLow,
      double SpecHigh,
      double Value,
      PST.SpecFunction SpecFunction)
    {
      PST.PrinterMechChecks printerMechChecks = new PST.PrinterMechChecks();
      printerMechChecks.AddMechCheck(Name, SpecType, SpecLow, SpecHigh, Value, SpecFunction);
      this._MechChecks.Add(printerMechChecks);
    }

    public bool get_Result(string CheckName)
    {
      bool flag = false;
      int index = 0;
      while (!flag & index < this._MechChecks.Count)
      {
        if (Operators.CompareString(this._MechChecks[index].Name.ToLower(), CheckName.ToLower(), false) == 0)
          return this._MechChecks[index].Results;
        checked { ++index; }
      }
      if (flag)
        return false;
      int num = (int) Interaction.MsgBox((object) ("The MechCheck name that you specified does not exist\r\nMechCheck Name: " + CheckName), MsgBoxStyle.Critical);
      return false;
    }

    public bool get_Result(int Index)
    {
      if (Index < this._MechChecks.Count)
        return this._MechChecks[Index].Results;
      int num = (int) Interaction.MsgBox((object) ("The MechCheck index that you specified does not exist\r\nMechCheck Index: " + Index.ToString()), MsgBoxStyle.Critical);
      return false;
    }

    public int Count => this._MechChecks.Count;

    public void Save(string FileName, bool Append)
    {
      string directoryName = Path.GetDirectoryName(FileName);
      Path.GetFileName(FileName);
      if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
        MyProject.Computer.FileSystem.CreateDirectory(directoryName);
      string[,] Body = new string[checked (this.Count - 1 + 1), 6];
      int num = checked (this.Count - 1);
      int index = 0;
      while (index <= num)
      {
        Body[index, 0] = this._MechChecks[index].Name;
        Body[index, 1] = this._MechChecks[index].SpecType.ToString();
        Body[index, 2] = this._MechChecks[index].SpecLow.ToString();
        Body[index, 3] = this._MechChecks[index].SpecHigh.ToString();
        Body[index, 4] = this._MechChecks[index].Value.ToString();
        Body[index, 5] = this._MechChecks[index].Results.ToString();
        checked { ++index; }
      }
      string[] Header = new string[6]
      {
        "Name",
        "SpecType",
        "Spec1",
        "Spec2",
        "Value",
        "Results"
      };
      FileProcessing.WriteDelimitedFile(FileName, Header, Body, ",", Append);
    }
  }
}
