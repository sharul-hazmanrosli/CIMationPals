// Decompiled with JetBrains decompiler
// Type: FUEL.BigRed.TestSuite
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace FUEL.BigRed
{
  public class TestSuite
  {
    public TestSuite()
    {
      this.TemplateRev = 0;
      this.Variables = new TestVariables();
    }

    public int TemplateRev { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public TestVariables Variables { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string[,] Instructions { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public void LoadNativeSuite(string Path)
    {
      Workbook workbook = ExcelHandler.LoadExcel(Path);
      this.TemplateRev = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(workbook.BuiltinDocumentProperties, new object[1]
      {
        (object) "Revision Number"
      }, (string[]) null), (Type) null, "value", new object[0], (string[]) null, (Type[]) null, (bool[]) null));
      object[,] arrVariables = ExcelHandler.ReadSheet(workbook, 1);
      object[,] arrInstructions = ExcelHandler.ReadSheet(workbook, 2);
      ExcelHandler.CloseWB(workbook);
      this.Variables = this.LoadVariables(arrVariables);
      this.Instructions = this.LoadInstructions(arrInstructions);
    }

    private TestVariables LoadVariables(object[,] arrVariables) => new TestVariables()
    {
      AutoDataOnSchedule = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Run AutoData on a schedule?")),
      PassiveAutoData = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Use Passive AutoData?")),
      UploadDataToGradeBook = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Upload data to GradeBook?")),
      TestRunningOutsideOfHPFireWall = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Test running outside of HP Firewall?")),
      CollectDataForEveryPrintJob = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Collect data for every print job?")),
      SendDataViaEmail = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Send data via email?")),
      EmailAddress = this.Variables_Set(arrVariables, "To whom do you want email sent?"),
      MessagePriority = Conversions.ToInteger(this.Variables_Set(arrVariables, "Messaging Priority")),
      ReplacePgNrWithPlotCD = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Replace Page Nr with PLOT_CD?")),
      PrintProtocol = this.Variables_Set(arrVariables, "Select Print Protocols"),
      AutomaticeLIDILMode = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Automatic eLIDIL Mode")),
      PCLFileLocation = this.Variables_Set(arrVariables, "PCL Location"),
      NozzlePatternLocation = this.Variables_Set(arrVariables, "Nozzle Pattern Locations"),
      AddCRLFToHeaders = Conversions.ToBoolean(this.Variables_Set(arrVariables, "Auto add Carriage Return to Header?")),
      FooterData = this.Variables_DataCollections(arrVariables, "Footer Data"),
      GradeBookData = this.Variables_DataCollections(arrVariables, "GradeBook Data")
    };

    private string Variables_Set(object[,] arr, string LookinFor)
    {
      int num1 = Information.UBound((Array) arr);
      int index = 1;
      while (index <= num1)
      {
        if (Operators.ConditionalCompareObjectNotEqual(arr[index, 1], (object) null, false) && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(arr[index, 1], (Type) null, "trim", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (Type) null, "tolower", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (object) LookinFor.Trim().ToLower(), false))
          return Conversions.ToString(arr[index, 2]);
        checked { ++index; }
      }
      int num2 = (int) Interaction.MsgBox((object) ("Error: Unable to find '" + LookinFor + "' in test variables."), MsgBoxStyle.Critical, (object) "Cant Find Test Variable");
      return Conversions.ToString(0);
    }

    private string[] Variables_DataCollections(object[,] arr, string LookinFor)
    {
      bool flag = false;
      int index1 = 0;
      int num1 = Information.UBound((Array) arr);
      int index2 = 1;
      while (index2 <= num1)
      {
        if (Operators.ConditionalCompareObjectNotEqual(arr[index2, 1], (object) null, false) && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(arr[index2, 1], (Type) null, "trim", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (Type) null, "tolower", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (object) LookinFor.Trim().ToLower(), false))
        {
          index1 = index2;
          flag = true;
          break;
        }
        checked { ++index2; }
      }
      if (!flag)
        return (string[]) null;
      int num2 = 0;
      int num3 = Information.UBound((Array) arr, 2);
      int index3 = 1;
      while (index3 <= num3)
      {
        if (Operators.ConditionalCompareObjectEqual(arr[index1, index3], (object) null, false))
        {
          num2 = checked (index3 - 1);
          break;
        }
        checked { ++index3; }
      }
      string[] strArray = new string[checked (num2 - 3 + 1)];
      int num4 = num2;
      int index4 = 3;
      while (index4 <= num4)
      {
        strArray[checked (index4 - 3)] = Conversions.ToString(arr[index1, index4]);
        checked { ++index4; }
      }
      return strArray;
    }

    private string[,] LoadInstructions(object[,] arrInstructions)
    {
      int num1 = 0;
      int num2 = Information.UBound((Array) arrInstructions);
      int index1 = 1;
      while (index1 <= num2)
      {
        if (Operators.ConditionalCompareObjectEqual(arrInstructions[index1, 1], (object) null, false))
        {
          num1 = checked (index1 - 1);
          break;
        }
        checked { ++index1; }
      }
      int num3 = 0;
      int num4 = Information.UBound((Array) arrInstructions, 2);
      int index2 = 1;
      while (index2 <= num4)
      {
        if (Operators.ConditionalCompareObjectNotEqual(arrInstructions[1, index2], (object) null, false))
          num3 = index2;
        checked { ++index2; }
      }
      string[,] strArray = new string[checked (num1 - 2 + 1), checked (num3 - 1 + 1)];
      int num5 = num1;
      int index3 = 2;
      while (index3 <= num5)
      {
        int num6 = num3;
        int index4 = 1;
        while (index4 <= num6)
        {
          strArray[checked (index3 - 2), checked (index4 - 1)] = !Operators.ConditionalCompareObjectEqual(arrInstructions[index3, index4], (object) null, false) ? Conversions.ToString(arrInstructions[index3, index4]) : "";
          checked { ++index4; }
        }
        checked { ++index3; }
      }
      return strArray;
    }
  }
}
