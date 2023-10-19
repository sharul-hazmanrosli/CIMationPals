// Decompiled with JetBrains decompiler
// Type: FUEL.FUELLog
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.FS;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;

namespace FUEL
{
  public class FUELLog
  {
    private string _LogFileName;
    private System.IO.FileInfo _LogFileInfo;

    public string LogFileName => this._LogFileName;

    public DateTime LastWriteTime => this._LogFileInfo.LastWriteTime;

    public FUELLog()
    {
      this._LogFileName = Path.Combine(modCommonCode.GetDataPath(), "FUEL.Log");
      this._LogFileInfo = MyProject.Computer.FileSystem.GetFileInfo(this.LogFileName);
      if (!MyProject.Computer.FileSystem.FileExists(this.LogFileName) || (double) this._LogFileInfo.Length / 1048576.0 <= 2.0)
        return;
      MyProject.Computer.FileSystem.RenameFile(this.LogFileName, Path.GetFileNameWithoutExtension(this.LogFileName) + " - Log Archive - " + DateAndTime.Now.Ticks.ToString() + ".log");
    }

    public void WriteLog(object Sender, string Msg, EventLogEntryType EntryType)
    {
      DateTime now = DateAndTime.Now;
      string directoryName = Path.GetDirectoryName(this.LogFileName);
      if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
        MyProject.Computer.FileSystem.CreateDirectory(directoryName);
      string TextToWrite = now.ToString() + "\t" + Sender.ToString() + "\t" + EntryType.ToString() + "\t" + Msg + "\r\n";
      try
      {
        FileProcessing.WriteToFile(this.LogFileName, TextToWrite, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public string ReadLog() => MyProject.Computer.FileSystem.FileExists(this.LogFileName) ? Conversions.ToString(FileProcessing.ReadFile(this.LogFileName)) : "No log file found";

    public string ReadLastLine()
    {
      if (!MyProject.Computer.FileSystem.FileExists(this.LogFileName))
        return "No log file found";
      string str = Conversions.ToString(FileProcessing.ReadFile(this.LogFileName));
      string[] strArray = (string[]) null;
      if (Operators.CompareString(str, (string) null, false) != 0)
        strArray = Strings.Split(str, "\r\n");
      return strArray[Information.UBound((Array) strArray)];
    }
  }
}
