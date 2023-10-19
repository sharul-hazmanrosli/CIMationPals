// Decompiled with JetBrains decompiler
// Type: FUEL.CheckForUpdates
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.FS;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RDL;
using System;
using System.Diagnostics;
using System.Reflection;

namespace FUEL
{
  public class CheckForUpdates
  {
    private string _DLLoc { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _SaveAs { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private CheckForUpdates.CheckType _FUELType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private Version _ServerVersion { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private Version _CurrentVersion { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private Version _RequiredPSTVersion { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private Version _RequiredFSVersion { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private CheckForUpdates.UpdateType _UpdateRequired { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _FileList { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public object UpdateAvailable => (object) this._UpdateRequired;

    public string ServerVersion => this._ServerVersion.ToString();

    public string CurrentVersion => this._CurrentVersion.ToString();

    public CheckForUpdates(string DLLocation, string SaveAs, CheckForUpdates.CheckType FUELType)
    {
      this._DLLoc = DLLocation;
      this._SaveAs = SaveAs;
      this._FUELType = FUELType;
      if (this.DownloadVersionFile())
      {
        this.ReadVersionFile();
        this.DetermineIfUpdateNeeded();
      }
      else
        this._UpdateRequired = CheckForUpdates.UpdateType.None;
    }

    private bool DownloadVersionFile()
    {
      HTTPDownloadSync httpDownloadSync = new HTTPDownloadSync(this._DLLoc, this._SaveAs);
      httpDownloadSync.StartDownload();
      return Conversions.ToBoolean(httpDownloadSync.Success);
    }

    private void DetermineIfUpdateNeeded()
    {
      this._CurrentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
      if (this._CurrentVersion < this._RequiredPSTVersion & this._FUELType == CheckForUpdates.CheckType.PST)
        this._UpdateRequired = CheckForUpdates.UpdateType.RequiredUpdate;
      else if (this._CurrentVersion < this._RequiredFSVersion & this._FUELType == CheckForUpdates.CheckType.FS)
        this._UpdateRequired = CheckForUpdates.UpdateType.RequiredUpdate;
      else if (this._CurrentVersion < this._ServerVersion)
        this._UpdateRequired = CheckForUpdates.UpdateType.OptionalUpdate;
      else
        this._UpdateRequired = CheckForUpdates.UpdateType.None;
    }

    private void ReadVersionFile()
    {
      string[,] strArray = FileProcessing.ReadDelimitedFile(this._SaveAs, ":");
      int num = Information.UBound((Array) strArray);
      int index = 0;
      while (index <= num)
      {
        string upper = strArray[index, 0].ToUpper();
        if (Operators.CompareString(upper, "CurrentVersion".ToUpper(), false) == 0)
          this._ServerVersion = new Version(strArray[index, 1]);
        else if (Operators.CompareString(upper, "RequiredPSTVersion".ToUpper(), false) == 0)
          this._RequiredPSTVersion = new Version(strArray[index, 1]);
        else if (Operators.CompareString(upper, "RequiredFSVersion".ToUpper(), false) == 0)
          this._RequiredFSVersion = new Version(strArray[index, 1]);
        else if (Operators.CompareString(upper, "FileList".ToUpper(), false) == 0)
          this._FileList = strArray[index, 1];
        checked { ++index; }
      }
    }

    public enum UpdateType
    {
      None,
      OptionalUpdate,
      RequiredUpdate,
    }

    public enum CheckType
    {
      PST,
      FS,
    }
  }
}
