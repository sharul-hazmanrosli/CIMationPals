// Decompiled with JetBrains decompiler
// Type: FUEL.ExcelHandler
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;

namespace FUEL
{
  public class ExcelHandler
  {
    [DebuggerNonUserCode]
    public ExcelHandler()
    {
    }

    public static Workbook LoadExcel(string FName) => ((_Application) new ApplicationClass()).Workbooks.Open(FName, (object) Missing.Value, (object) true, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value, (object) Missing.Value);

    public static object[,] ReadSheet(Workbook WB, int SheetNum) => (object[,]) ((_Worksheet) WB.Worksheets[(object) SheetNum]).UsedRange.get_Value((object) XlRangeValueDataType.xlRangeValueDefault);

    public static void CloseWB(Workbook wb) => wb.Close((object) Missing.Value, (object) Missing.Value, (object) Missing.Value);
  }
}
