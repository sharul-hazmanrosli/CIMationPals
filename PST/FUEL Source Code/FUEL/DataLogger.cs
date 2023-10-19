// Decompiled with JetBrains decompiler
// Type: FUEL.DataLogger
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FUEL
{
  public class DataLogger
  {
    [DebuggerNonUserCode]
    public DataLogger()
    {
    }

    public class PSTLog
    {
      private PST _PSTData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _OutputFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _SummaryFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _SpecFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _RunNumber { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      internal int RunNumber => this._RunNumber;

      public PSTLog(
        PST PSTData,
        string OutputFileName,
        string SummaryFileName,
        string SpecFileName)
      {
        this._PSTData = PSTData;
        this._OutputFileName = OutputFileName;
        this._SummaryFileName = SummaryFileName;
        this._SpecFileName = SpecFileName;
        this._RunNumber = this.DetermineRunNumber(this._PSTData.PrinterInfo.SerialNum);
        this.WriteLog();
        this.WriteSummary();
        this.WriteSpecFile();
      }

      public PSTLog(
        PST PSTData,
        string OutputFileName,
        string SummaryFileName,
        string SpecFileName,
        bool AddFailuretoFailSummary)
      {
        this._PSTData = PSTData;
        this._OutputFileName = OutputFileName;
        this._SummaryFileName = SummaryFileName;
        this._SpecFileName = SpecFileName;
        this._RunNumber = this.DetermineRunNumber(this._PSTData.PrinterInfo.SerialNum);
        this.WriteLog();
        this.WriteSummary();
        this.WriteSpecFile();
        if (!AddFailuretoFailSummary)
          return;
        this._SummaryFileName = this._SummaryFileName.Replace(".csv", "-FAILED.csv");
        this.WriteSummary();
      }

      private int DetermineRunNumber(string cuSerialNum)
      {
        int runNumber;
        if (MyProject.Computer.FileSystem.FileExists(this._SummaryFileName))
        {
          string[] strArray1;
          try
          {
            strArray1 = Microsoft.VisualBasic.Strings.Split(MyProject.Computer.FileSystem.ReadAllText(this._SummaryFileName), "\r\n");
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) Interaction.MsgBox((object) ("Unable to open the Summary file" + "\r\n\r\n" + ex.ToString()), (MsgBoxStyle) Conversions.ToInteger("\r"));
            runNumber = -1;
            ProjectData.ClearProjectError();
            goto label_14;
          }
          string[] strArray2 = (string[]) null;
          int num1 = Information.UBound((Array) strArray1);
          int index = 0;
          while (index <= num1)
          {
            string[] strArray3 = Microsoft.VisualBasic.Strings.Split(strArray1[index], ",");
            if (Operators.CompareString(strArray3[0], cuSerialNum, false) == 0)
            {
              if (strArray2 == null)
              {
                strArray2 = (string[]) Utils.CopyArray((Array) strArray2, (Array) new string[1]);
                strArray2[0] = strArray3[1];
              }
              if (Array.IndexOf<string>(strArray2, strArray3[1]) == -1 & Operators.CompareString(strArray3[0], "", false) != 0)
              {
                strArray2 = (string[]) Utils.CopyArray((Array) strArray2, (Array) new string[checked (Information.UBound((Array) strArray2) + 1 + 1)]);
                strArray2[Information.UBound((Array) strArray2)] = strArray3[1];
              }
            }
            checked { ++index; }
          }
          runNumber = strArray2 != null ? (Array.IndexOf<string>(strArray2, cuSerialNum) != -1 ? ((IEnumerable<string>) strArray2).Count<string>() : checked (((IEnumerable<string>) strArray2).Count<string>() + 1)) : 1;
        }
        else
          runNumber = 1;
label_14:
        return runNumber;
      }

      private void WriteLog()
      {
        Logging.AddLogEntry((object) this, "WriteLog: Starting", EventLogEntryType.Information, 4);
        StringBuilder stringBuilder = new StringBuilder();
        if (!MyProject.Computer.FileSystem.FileExists(this._OutputFileName))
        {
          string str = "Serial Number,Test ID,Run Number,Date,Time,Channel,Sample Time,Sample Pressure";
          stringBuilder.Append(str).AppendLine();
        }
        int num1 = checked (this._PSTData.PTraceBlack.Count - 1);
        int index1 = 0;
        while (index1 <= num1)
        {
          string str = this._PSTData.PrinterInfo.SerialNum + "," + this._PSTData.TestID + "," + Conversions.ToString(this._RunNumber) + "," + this._PSTData.TestInfo.TestDate + "," + this._PSTData.TestInfo.TestTime + ",Black," + Conversions.ToString(this._PSTData.PTraceBlack[index1].X) + "," + Conversions.ToString(this._PSTData.PTraceBlack[index1].Y);
          stringBuilder.Append(str).AppendLine();
          checked { ++index1; }
        }
        int num2 = checked (this._PSTData.PTraceColor.Count - 1);
        int index2 = 0;
        while (index2 <= num2)
        {
          string str = this._PSTData.PrinterInfo.SerialNum + "," + this._PSTData.TestID + "," + Conversions.ToString(this._RunNumber) + "," + this._PSTData.TestInfo.TestDate + "," + this._PSTData.TestInfo.TestTime + ",Color," + Conversions.ToString(this._PSTData.PTraceColor[index2].X) + "," + Conversions.ToString(this._PSTData.PTraceColor[index2].Y);
          stringBuilder.Append(str).AppendLine();
          checked { ++index2; }
        }
        MyProject.Computer.FileSystem.WriteAllText(this._OutputFileName, stringBuilder.ToString(), true);
        Logging.AddLogEntry((object) this, "WriteLog: Complete", EventLogEntryType.Information, 4);
      }

      private void WriteSummary()
      {
        Logging.AddLogEntry((object) this, "WriteSummary: Starting", EventLogEntryType.Information, 4);
        string str1 = (string) null;
        if (!MyProject.Computer.FileSystem.FileExists(this._SummaryFileName))
        {
          string str2 = "SERIAL_NUM,Test ID, Test_Station_Type,RunNumber,Script_Rev,Script_Product,FUEL_Rev,FW_REV,TEST_DATE,TEST_TIME,Pg_Cnt,Overall_Test_Results,AutoRetestForVentDP, PreviousTestID,K_MAX_PRESSURE_Results,K_MAX_PRESSURE_Val,C_MAX_PRESSURE_Results,C_MAX_PRESSURE_Val,K_LEAK_Results,K_LEAK_Val,K_VENT_Results,K_VENTDeltaP_Val,K_DERIVCNT_Results,K_DERIVCNT_Val,K_TubeEvacPressure_Results,K_TubeEvacPressure_Val,C_LEAK_Results,C_LEAK_Val,C_VENT_Results,C_VENTDeltaP_Val,C_DERIVCNT_Results,C_DERIVCNT_Val,C_TubeEvacPressure_Results,C_TubeEvacPressure_Val,KDryPHA_Results,K_INSTALL_PRESSURE_Val,CDryPHA_Results,C_INSTALL_PRESSURE_Val,Data_File,Spec_File";
          if (this._PSTData.MechChecks.Count > 0)
          {
            str2 += ",";
            int num = checked (this._PSTData.MechChecks.Count - 1);
            int index = 0;
            while (index <= num)
            {
              str2 = str2 + this._PSTData.MechChecks[index].Name + "_Results," + this._PSTData.MechChecks[index].Name + "_Val";
              if (index < checked (this._PSTData.MechChecks.Count - 1))
                str2 += ",";
              checked { ++index; }
            }
          }
          str1 = str2 + "\r\n";
        }
        string str3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) (str1 + this._PSTData.PrinterInfo.SerialNum + "," + this._PSTData.TestID + "," + this._PSTData.TestInfo.TestStationType.ToString() + "," + Conversions.ToString(this._RunNumber) + "," + this._PSTData.TestInfo.ScriptRev + "," + this._PSTData.TestInfo.ScriptProduct + "," + PST.TestInformation.FuelRev + "," + this._PSTData.PrinterInfo.FWRev + "," + this._PSTData.TestInfo.TestDate + "," + this._PSTData.TestInfo.TestTime + "," + Conversions.ToString(this._PSTData.PrinterInfo.EnginePgCnt) + "," + Conversions.ToString(this._PSTData.OverallTestStatus) + "," + this._PSTData.RetestForVentDP.ToString() + "," + this._PSTData.PreviousTestID + "," + Conversions.ToString(this._PSTData.KResults.PF.MaxPressure) + "," + Conversions.ToString(this._PSTData.KResults.Val.MaxPressure) + "," + Conversions.ToString(this._PSTData.CResults.PF.MaxPressure) + "," + Conversions.ToString(this._PSTData.CResults.Val.MaxPressure) + "," + Conversions.ToString(this._PSTData.KResults.PF.Leak) + "," + Conversions.ToString(this._PSTData.KResults.Val.Leak) + "," + Conversions.ToString(this._PSTData.KResults.PF.VentDeltaPMin) + "," + Conversions.ToString(this._PSTData.KResults.Val.VentDeltaP) + "," + Conversions.ToString(this._PSTData.KResults.PF.DerivCnt) + "," + Conversions.ToString(this._PSTData.KResults.Val.DerivCnt) + "," + Conversions.ToString(this._PSTData.KResults.PF.TubeEvacDeltaPressure) + "," + Conversions.ToString(this._PSTData.KResults.Val.TubeEvacDeltaPressure) + "," + Conversions.ToString(this._PSTData.CResults.PF.Leak) + "," + Conversions.ToString(this._PSTData.CResults.Val.Leak) + "," + Conversions.ToString(this._PSTData.CResults.PF.VentDeltaPMin) + "," + Conversions.ToString(this._PSTData.CResults.Val.VentDeltaP) + "," + Conversions.ToString(this._PSTData.CResults.PF.DerivCnt) + "," + Conversions.ToString(this._PSTData.CResults.Val.DerivCnt) + "," + Conversions.ToString(this._PSTData.CResults.PF.TubeEvacDeltaPressure) + "," + Conversions.ToString(this._PSTData.CResults.Val.TubeEvacDeltaPressure) + "," + Conversions.ToString(this._PSTData.KResults.PF.DryPHA) + ","), this._PSTData.BlackInstallPressure), (object) ","), (object) this._PSTData.CResults.PF.DryPHA), (object) ","), this._PSTData.ColorInstallPressure), (object) ","), (object) Path.GetFileName(this._OutputFileName)), (object) ","), (object) Path.GetFileName(this._SpecFileName)));
        if (this._PSTData.MechChecks.Count > 0)
        {
          str3 += ",";
          int num = checked (this._PSTData.MechChecks.Count - 1);
          int index = 0;
          while (index <= num)
          {
            str3 = str3 + this._PSTData.MechChecks[index].Results.ToString() + "," + this._PSTData.MechChecks[index].Value.ToString();
            if (index < checked (this._PSTData.MechChecks.Count - 1))
              str3 += ",";
            checked { ++index; }
          }
        }
        MyProject.Computer.FileSystem.WriteAllText(this._SummaryFileName, str3 + "\r\n", true);
        Logging.AddLogEntry((object) this, "WriteSummary: Starting", EventLogEntryType.Information, 4);
      }

      private void WriteSpecFile()
      {
        Logging.AddLogEntry((object) this, "WriteSpecFile: Starting", EventLogEntryType.Information, 4);
        Serializer.SerializeMe(this._PSTData, this._SpecFileName);
        Logging.AddLogEntry((object) this, "WriteSpecFile: Complete", EventLogEntryType.Information, 4);
      }
    }

    public class PSTDebugLog
    {
      private PST _PSTData { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _OutputFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _RunNumber { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private DataLogger.PSTDebugLog.LogType _LogType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string OutputFileName
      {
        get => this._OutputFileName;
        set
        {
          string directoryName = Path.GetDirectoryName(value);
          try
          {
            if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
              MyProject.Computer.FileSystem.CreateDirectory(directoryName);
            string Expression = this._LogType != DataLogger.PSTDebugLog.LogType.Black ? "PST-C-*.txt" : "PST-K-*.txt";
            ReadOnlyCollection<string> files = MyProject.Computer.FileSystem.GetFiles(directoryName, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, Expression);
            string path2 = Microsoft.VisualBasic.Strings.Replace(Expression, "*", Conversions.ToString(files.Count));
            this._OutputFileName = Path.Combine(directoryName, path2);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            throw new ApplicationException("Unable to create folder for output file.\r\nPath: " + directoryName);
          }
        }
      }

      public PSTDebugLog(
        PST PSTData,
        string OutputDirectory,
        DataLogger.PSTDebugLog.LogType FileType)
      {
        this._PSTData = PSTData;
        this._LogType = FileType;
        this.OutputFileName = OutputDirectory;
        this.WriteLog();
      }

      private int DetermineRunNumber(long cuID) => 0;

      private void WriteLog()
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this._LogType == DataLogger.PSTDebugLog.LogType.Black)
        {
          int num = checked (this._PSTData.PTraceBlack.Count - 1);
          int index = 0;
          while (index <= num)
          {
            string str = Conversions.ToString(this._PSTData.PTraceBlack[index].X) + "\t" + Conversions.ToString(this._PSTData.PTraceBlack[index].Y);
            stringBuilder.Append(str).AppendLine();
            checked { ++index; }
          }
        }
        else
        {
          int num = checked (this._PSTData.PTraceColor.Count - 1);
          int index = 0;
          while (index <= num)
          {
            string str = Conversions.ToString(this._PSTData.PTraceColor[index].X) + "\t" + Conversions.ToString(this._PSTData.PTraceColor[index].Y);
            stringBuilder.Append(str).AppendLine();
            checked { ++index; }
          }
        }
        MyProject.Computer.FileSystem.WriteAllText(this.OutputFileName, stringBuilder.ToString(), true);
      }

      public enum LogType
      {
        Black,
        Color,
      }
    }
  }
}
