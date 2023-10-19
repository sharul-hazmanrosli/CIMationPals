// Decompiled with JetBrains decompiler
// Type: FUEL.FS.FileUpload
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace FUEL.FS
{
  public class FileUpload
  {
    private Thread _thdUpload;

    private string _SrcDir { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string SrcDir
    {
      get => this._SrcDir;
      set => this._SrcDir = value;
    }

    private int _UploadFrequency { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public int UploadFrequency
    {
      get => this._UploadFrequency;
      set => this._UploadFrequency = value;
    }

    private bool _UploadRequired { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool UploadRequired
    {
      get
      {
        int num = checked ((int) DateAndTime.DateDiff(DateInterval.Minute, MySettingsProperty.Settings.LastUploadTime, DateAndTime.Now));
        Logging.AddLogEntry((object) "FileUpload: UploadRequired", "Date Delta from last upload (minutes) = " + num.ToString(), EventLogEntryType.Information, 2);
        return num >= checked (this._UploadFrequency * 60);
      }
    }

    public bool NewThread { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool ZipFiles { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string ZipFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool DeleteFilesAfterZip { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public double MaxZipFileSize { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool HideForms { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public FileUpload()
    {
      this._UploadFrequency = 2;
      this._UploadRequired = false;
      this.NewThread = false;
      this.ZipFiles = false;
      this.ZipFileName = (string) null;
      this.DeleteFilesAfterZip = false;
      this.MaxZipFileSize = 0.0;
      this.HideForms = false;
    }

    public FileUpload(string SrcDir)
    {
      this._UploadFrequency = 2;
      this._UploadRequired = false;
      this.NewThread = false;
      this.ZipFiles = false;
      this.ZipFileName = (string) null;
      this.DeleteFilesAfterZip = false;
      this.MaxZipFileSize = 0.0;
      this.HideForms = false;
      this._SrcDir = SrcDir;
      this.UploadFiles(0);
    }

    public FileUpload(string SrcDir, int UploadInterval)
    {
      this._UploadFrequency = 2;
      this._UploadRequired = false;
      this.NewThread = false;
      this.ZipFiles = false;
      this.ZipFileName = (string) null;
      this.DeleteFilesAfterZip = false;
      this.MaxZipFileSize = 0.0;
      this.HideForms = false;
      this._UploadFrequency = UploadInterval;
      this._SrcDir = SrcDir;
      this.UploadFiles(0);
    }

    public void UploadFiles() => this.UploadFiles(0);

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void UploadFiles(int Recursion)
    {
      if (this.UploadRequired)
      {
        try
        {
          if (UploadSettings.SettingsVerified)
          {
            Logging.AddLogEntry((object) "clsFileUpload", "Starting Upload", EventLogEntryType.Information, 2);
            if (!this.NewThread)
            {
              frmAutoUpload frmAutoUpload = new frmAutoUpload(this.SrcDir);
              IntPtr owner = PST.getOwner();
              if (owner != (IntPtr) -1)
              {
                int num1 = (int) frmAutoUpload.ShowDialog((IWin32Window) new WindowWrapper(owner));
              }
              else
              {
                int num2 = (int) frmAutoUpload.ShowDialog();
              }
            }
            else
            {
              this._thdUpload = new Thread(new ThreadStart(this.UploadInNewThread));
              this._thdUpload.IsBackground = false;
              this._thdUpload.Start();
            }
          }
          else if (Recursion == 0)
          {
            Logging.AddLogEntry((object) this, "Cant upload files till FUEL Settings have been verified", EventLogEntryType.Information, 0);
            int num = (int) Interaction.MsgBox((object) "You must verify FUEL Settings before trying to upload data");
            Process process = new Process();
            process.StartInfo.FileName = !MyProject.Application.Info.DirectoryPath.Contains("\\bin\\") ? Path.Combine(modCommonCode.GetDataPath(), "FuelSettings.exe") : "C:\\Users\\morrisor\\Documents\\Visual Studio 2010\\Projects\\FUEL\\AutoSendFiles\\FUELSettings\\bin\\Debug\\FUELSettings.exe";
            process.Start();
            process.WaitForExit();
            this.UploadFiles(checked (Recursion + 1));
          }
          else
          {
            Logging.AddLogEntry((object) this, "User did not verify settings, skipping request to upload files.", EventLogEntryType.Information, 0);
            int num = (int) Interaction.MsgBox((object) "Can not upload files until the FUEL Settings have been verified.\r\n\r\nPlease access FUEL Settings via the Windows Start Menu\r\n\r\nSkipping request to upload files.");
          }
          MySettingsProperty.Settings.LastUploadTime = DateAndTime.Now;
          MySettingsProperty.Settings.Save();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) Interaction.MsgBox((object) ("There was a problem uploading your data to the network" + "\r\n\r\n" + ex.ToString()), MsgBoxStyle.Critical);
          ProjectData.ClearProjectError();
        }
      }
      else
        Logging.AddLogEntry((object) this, "Upload not currently required.", EventLogEntryType.Information, 2);
    }

    private void UploadInNewThread()
    {
      Logging.AddLogEntry((object) "FS.UploadInNewThread", "Starting Zip process", EventLogEntryType.Information, 2);
      int num1 = (int) new frmZipProgress(this.SrcDir, this.ZipFileName, this.DeleteFilesAfterZip)
      {
        MaxFileSize = (checked ((long) System.Math.Round(this.MaxZipFileSize))),
        HideForm = this.HideForms
      }.ShowDialog();
      Logging.AddLogEntry((object) "FS.UploadInNewThread", "Done with Zip process", EventLogEntryType.Information, 2);
      Logging.AddLogEntry((object) "FS.UploadInNewThread", "Starting Upload process", EventLogEntryType.Information, 2);
      frmAutoUpload frmAutoUpload = new frmAutoUpload(this.SrcDir);
      frmAutoUpload.HideForm = this.HideForms;
      int num2 = (int) frmAutoUpload.ShowDialog();
      Logging.AddLogEntry((object) "FS.UploadInNewThread", "Done with Upload process", EventLogEntryType.Information, 2);
      frmAutoUpload.HideForm = this.HideForms;
    }

    public string Status => this._thdUpload.IsAlive ? "Busy" : "Idle";

    public void AbortUpload()
    {
      if (!this._thdUpload.IsAlive)
        return;
      this._thdUpload.Abort();
    }
  }
}
