// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlUploadFiles
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using FUEL.FS;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RDL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class ctrlUploadFiles : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("prgFile")]
    private ProgressBarX _prgFile;
    [AccessedThroughProperty("prgOverall")]
    private ProgressBarX _prgOverall;
    [AccessedThroughProperty("lblCuFile")]
    private LabelX _lblCuFile;
    [AccessedThroughProperty("lblOverall")]
    private LabelX _lblOverall;
    [AccessedThroughProperty("lblComplete")]
    private LabelX _lblComplete;
    [AccessedThroughProperty("prgDLInitialize")]
    private ProgressBarX _prgDLInitialize;
    [AccessedThroughProperty("rtbResponseWindow")]
    private RichTextBox _rtbResponseWindow;
    private AutoResetEvent[] WaitAllEvents;
    private Thread thdUpload;

    [DebuggerNonUserCode]
    static ctrlUploadFiles()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlUploadFiles.__ENCList)
      {
        if (ctrlUploadFiles.__ENCList.Count == ctrlUploadFiles.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlUploadFiles.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlUploadFiles.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlUploadFiles.__ENCList[index1] = ctrlUploadFiles.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlUploadFiles.__ENCList.RemoveRange(index1, checked (ctrlUploadFiles.__ENCList.Count - index1));
          ctrlUploadFiles.__ENCList.Capacity = ctrlUploadFiles.__ENCList.Count;
        }
        ctrlUploadFiles.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.prgFile = new ProgressBarX();
      this.prgOverall = new ProgressBarX();
      this.lblCuFile = new LabelX();
      this.lblOverall = new LabelX();
      this.lblComplete = new LabelX();
      this.prgDLInitialize = new ProgressBarX();
      this.rtbResponseWindow = new RichTextBox();
      this.SuspendLayout();
      this.prgFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.prgFile.BackgroundStyle.CornerType = eCornerType.Square;
      ProgressBarX prgFile1 = this.prgFile;
      Point point1 = new Point(30, 47);
      Point point2 = point1;
      prgFile1.Location = point2;
      this.prgFile.Name = "prgFile";
      ProgressBarX prgFile2 = this.prgFile;
      Size size1 = new Size(285, 23);
      Size size2 = size1;
      prgFile2.Size = size2;
      this.prgFile.Style = eDotNetBarStyle.StyleManagerControlled;
      this.prgFile.TabIndex = 0;
      this.prgFile.Text = "ProgressBarX1";
      this.prgFile.Visible = false;
      this.prgOverall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.prgOverall.BackgroundStyle.CornerType = eCornerType.Square;
      ProgressBarX prgOverall1 = this.prgOverall;
      point1 = new Point(30, 98);
      Point point3 = point1;
      prgOverall1.Location = point3;
      this.prgOverall.Name = "prgOverall";
      ProgressBarX prgOverall2 = this.prgOverall;
      size1 = new Size(285, 23);
      Size size3 = size1;
      prgOverall2.Size = size3;
      this.prgOverall.Style = eDotNetBarStyle.StyleManagerControlled;
      this.prgOverall.TabIndex = 1;
      this.prgOverall.Text = "ProgressBarX2";
      this.prgOverall.Visible = false;
      this.lblCuFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblCuFile.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX lblCuFile1 = this.lblCuFile;
      point1 = new Point(30, 25);
      Point point4 = point1;
      lblCuFile1.Location = point4;
      this.lblCuFile.Name = "lblCuFile";
      LabelX lblCuFile2 = this.lblCuFile;
      size1 = new Size(285, 23);
      Size size4 = size1;
      lblCuFile2.Size = size4;
      this.lblCuFile.TabIndex = 2;
      this.lblCuFile.Text = "LabelX1";
      this.lblCuFile.Visible = false;
      this.lblOverall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblOverall.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX lblOverall1 = this.lblOverall;
      point1 = new Point(30, 76);
      Point point5 = point1;
      lblOverall1.Location = point5;
      this.lblOverall.Name = "lblOverall";
      LabelX lblOverall2 = this.lblOverall;
      size1 = new Size(285, 23);
      Size size5 = size1;
      lblOverall2.Size = size5;
      this.lblOverall.TabIndex = 3;
      this.lblOverall.Text = "Overall Progress";
      this.lblOverall.Visible = false;
      this.lblComplete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblComplete.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblComplete.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      LabelX lblComplete1 = this.lblComplete;
      point1 = new Point(30, (int) sbyte.MaxValue);
      Point point6 = point1;
      lblComplete1.Location = point6;
      this.lblComplete.Name = "lblComplete";
      LabelX lblComplete2 = this.lblComplete;
      size1 = new Size(285, 23);
      Size size6 = size1;
      lblComplete2.Size = size6;
      this.lblComplete.TabIndex = 5;
      this.lblComplete.Text = "Upload Complete";
      this.lblComplete.TextAlignment = StringAlignment.Center;
      this.lblComplete.Visible = false;
      this.prgDLInitialize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.prgDLInitialize.BackgroundStyle.CornerType = eCornerType.Square;
      this.prgDLInitialize.ColorTable = eProgressBarItemColor.Error;
      ProgressBarX prgDlInitialize1 = this.prgDLInitialize;
      point1 = new Point(30, 72);
      Point point7 = point1;
      prgDlInitialize1.Location = point7;
      this.prgDLInitialize.MarqueeAnimationSpeed = 75;
      this.prgDLInitialize.Name = "prgDLInitialize";
      this.prgDLInitialize.ProgressType = eProgressItemType.Marquee;
      ProgressBarX prgDlInitialize2 = this.prgDLInitialize;
      size1 = new Size(285, 23);
      Size size7 = size1;
      prgDlInitialize2.Size = size7;
      this.prgDLInitialize.Style = eDotNetBarStyle.StyleManagerControlled;
      this.prgDLInitialize.TabIndex = 6;
      this.prgDLInitialize.Text = "Initializing Upload";
      this.prgDLInitialize.TextVisible = true;
      this.rtbResponseWindow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      RichTextBox rtbResponseWindow1 = this.rtbResponseWindow;
      point1 = new Point(30, 157);
      Point point8 = point1;
      rtbResponseWindow1.Location = point8;
      this.rtbResponseWindow.Name = "rtbResponseWindow";
      RichTextBox rtbResponseWindow2 = this.rtbResponseWindow;
      size1 = new Size(285, 87);
      Size size8 = size1;
      rtbResponseWindow2.Size = size8;
      this.rtbResponseWindow.TabIndex = 7;
      this.rtbResponseWindow.Text = "=====================================\n                Server Response Window\nThis will likely be removed before final release.\n=====================================\n";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.rtbResponseWindow);
      this.Controls.Add((Control) this.prgDLInitialize);
      this.Controls.Add((Control) this.lblComplete);
      this.Controls.Add((Control) this.prgOverall);
      this.Controls.Add((Control) this.prgFile);
      this.Controls.Add((Control) this.lblOverall);
      this.Controls.Add((Control) this.lblCuFile);
      this.Name = nameof (ctrlUploadFiles);
      size1 = new Size(352, 247);
      this.Size = size1;
      this.ResumeLayout(false);
    }

    internal virtual ProgressBarX prgFile
    {
      [DebuggerNonUserCode] get => this._prgFile;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._prgFile = value;
    }

    internal virtual ProgressBarX prgOverall
    {
      [DebuggerNonUserCode] get => this._prgOverall;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._prgOverall = value;
    }

    internal virtual LabelX lblCuFile
    {
      [DebuggerNonUserCode] get => this._lblCuFile;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblCuFile = value;
    }

    internal virtual LabelX lblOverall
    {
      [DebuggerNonUserCode] get => this._lblOverall;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblOverall = value;
    }

    internal virtual LabelX lblComplete
    {
      [DebuggerNonUserCode] get => this._lblComplete;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblComplete = value;
    }

    internal virtual ProgressBarX prgDLInitialize
    {
      [DebuggerNonUserCode] get => this._prgDLInitialize;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._prgDLInitialize = value;
    }

    internal virtual RichTextBox rtbResponseWindow
    {
      [DebuggerNonUserCode] get => this._rtbResponseWindow;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbResponseWindow = value;
    }

    private Collection<string> _SrcFileList { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _FileDir { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _FileCount { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _CuFileNum { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _CuFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _CuFileName_FullName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _UploadInProgress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<ctrlUploadFiles.FileError> _ErrorList { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<ctrlUploadFiles.FileUploads> _FileUploadList { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _FinalDesitnation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _TemporaryDestination { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private PST.TestSites _DestinationSite { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private PST.TestSites _TestSite { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private WebProxy _Proxy { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static string FileUploadListName => "Uploads";

    public static string[] AllowedFileTypes => new string[7]
    {
      "*.csv",
      "*.txt",
      "*.xls",
      "*.xlsx",
      "*.xml",
      "*.zip",
      "*.z*"
    };

    public event ctrlUploadFiles.JobCompleteEventHandler JobComplete;

    public ctrlUploadFiles(
      Collection<string> FileList,
      PST.TestSites TestSite,
      PST.TestSites Destination)
    {
      this.Disposed += new EventHandler(this.ctrlUploadFiles_Disposed);
      ctrlUploadFiles.__ENCAddToList((object) this);
      this._UploadInProgress = false;
      this._ErrorList = (List<ctrlUploadFiles.FileError>) null;
      this.WaitAllEvents = new AutoResetEvent[1];
      try
      {
        Logging.AddLogEntry((object) this, "ctrlUploadFiles Instantiated", EventLogEntryType.Information, 4);
        this.InitializeComponent();
        this._SrcFileList = FileList;
        this._FileDir = Path.GetDirectoryName(FileList[0]);
        this._DestinationSite = Destination;
        this._TestSite = TestSite;
        this.rtbResponseWindow.Visible = false;
      }
      catch (ArgumentOutOfRangeException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        Logging.AddLogEntry((object) this, "ctrlUploadFiles: can't instantiate, the FileList is empty.", EventLogEntryType.Error, 0);
        int num = (int) Interaction.MsgBox((object) "The list of files to upload is empty.", MsgBoxStyle.Critical);
        this.Dispose();
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        throw;
      }
    }

    public void StartUpload()
    {
      this.thdUpload = new Thread(new ThreadStart(this.Upload));
      this.thdUpload.IsBackground = true;
      this.thdUpload.Start();
    }

    private void Upload()
    {
      this._FileUploadList = ctrlUploadFiles.ReadFileUploadList(this._FileDir, ctrlUploadFiles.FileUploadListName);
      this._ErrorList = new List<ctrlUploadFiles.FileError>();
      this._FileCount = this._SrcFileList.Count;
      Logging.AddLogEntry((object) this, "Files to upload: " + Conversions.ToString(this._FileCount), EventLogEntryType.Information, 2);
      this.prgOverall.Maximum = checked (this._FileCount * 100);
      int num1 = 0;
      this.WaitAllEvents[0] = new AutoResetEvent(false);
      try
      {
        foreach (string srcFile in this._SrcFileList)
        {
          if (MyProject.Computer.FileSystem.FileExists(srcFile))
          {
            Logging.AddLogEntry((object) this, "****************Starting Upload process for file: " + srcFile, EventLogEntryType.Information, 1);
            switch (this._TestSite)
            {
              case PST.TestSites.HP:
                this._TemporaryDestination = UploadSettings.VCDServerAddress;
                break;
              case PST.TestSites.DEBUG:
                this._TemporaryDestination = "\\\\vcslab\\root\\InkSystems\\SPHINKS\\Randal Morrison\\FUEL\\testing\\howdy\\";
                break;
              default:
                if (this._DestinationSite == PST.TestSites.HP)
                  this._TemporaryDestination = UploadSettings.VCDServerAddress;
                else if (this._DestinationSite == PST.TestSites.NKG_China | this._DestinationSite == PST.TestSites.NKG_Thailand)
                  this._TemporaryDestination = UploadSettings.LocalCopyToAddress;
                break;
            }
            this._CuFileName = Path.GetFileName(srcFile);
            this._CuFileName_FullName = srcFile;
            if (ctrlUploadFiles.DetermineIfFileShouldBeUploaded(this._CuFileName_FullName, this._FileUploadList))
            {
              if (Path.IsPathRooted(this._TemporaryDestination))
              {
                this.SetResponseWindowVisibility(false);
                string str = Path.GetDirectoryName(this._TemporaryDestination);
                if (Operators.CompareString(str, (string) null, false) == 0)
                  str = Path.GetPathRoot(this._TemporaryDestination);
                if (MyProject.Computer.FileSystem.DirectoryExists(Path.GetPathRoot(this._TemporaryDestination)))
                {
                  this._TemporaryDestination = Path.Combine(str, this._CuFileName);
                  if (!MyProject.Computer.FileSystem.DirectoryExists(str))
                    MyProject.Computer.FileSystem.CreateDirectory(str);
                }
                else
                {
                  int num2 = (int) Interaction.MsgBox((object) "The specified drive to upload files to does not exist. Are you sure that you set your location properly?", MsgBoxStyle.Critical, (object) "Can't Find Specified Drive.");
                  MySettingsProperty.Settings.CurrentSite = 0;
                  MySettingsProperty.Settings.Save();
                  ctrlUploadFiles.JobCompleteEventHandler jobCompleteEvent = this.JobCompleteEvent;
                  if (jobCompleteEvent == null)
                    return;
                  jobCompleteEvent(false);
                  return;
                }
              }
              else
                this.SetResponseWindowVisibility(false);
              this._CuFileNum = num1;
              ctrlUploadFiles.FileInfo fileName = ctrlUploadFiles.ParseFileName(this._CuFileName);
              this._FinalDesitnation = fileName.DataType + "|" + fileName.Product;
              Uri uri = new Uri(this._TemporaryDestination);
              if (uri.HostNameType == UriHostNameType.Dns)
              {
                IPAddress[] hostAddresses;
                try
                {
                  hostAddresses = Dns.GetHostAddresses(uri.Authority.ToString());
                }
                catch (SocketException ex)
                {
                  ProjectData.SetProjectError((Exception) ex);
                  SocketException socketException = ex;
                  string Prompt = "Unable to resolve the UploadAddress: " + uri.ToString();
                  Logging.AddLogEntry((object) this, "Upload: GetHostName:" + socketException.ToString(), EventLogEntryType.Error, 0);
                  int num3 = (int) Interaction.MsgBox((object) Prompt);
                  ctrlUploadFiles.JobCompleteEventHandler jobCompleteEvent = this.JobCompleteEvent;
                  if (jobCompleteEvent != null)
                    jobCompleteEvent(false);
                  ProjectData.ClearProjectError();
                  return;
                }
                uri = new Uri(uri.Scheme.ToString() + Uri.SchemeDelimiter.ToString() + hostAddresses[0].ToString() + uri.AbsolutePath);
              }
              Logging.AddLogEntry((object) this, "Upload: Upload in Async Mode", EventLogEntryType.Information, 2);
              HTTPUploadAsync httpUploadAsync = !Path.IsPathRooted(this._TemporaryDestination) ? new HTTPUploadAsync(this._CuFileName_FullName, uri.AbsoluteUri) : new HTTPUploadAsync(this._CuFileName_FullName, uri.AbsolutePath);
              httpUploadAsync.UploadProgressChange += new HTTPUploadAsync.UploadProgressChangeEventHandler(this.UpdateProgress);
              httpUploadAsync.UploadComplete += new HTTPUploadAsync.UploadCompleteEventHandler(this.UploadComplete);
              httpUploadAsync.AuthAddress = uri.Authority.ToString();
              httpUploadAsync.UserName = "randalm";
              httpUploadAsync.Password = "foobie2";
              Logging.AddLogEntry((object) this, "Destination Site: " + this._DestinationSite.ToString(), EventLogEntryType.Information, 2);
              Logging.AddLogEntry((object) this, "Destination: " + this._TemporaryDestination.ToString(), EventLogEntryType.Information, 2);
              Logging.AddLogEntry((object) this, "Translated Destination: " + uri.AbsoluteUri.ToString(), EventLogEntryType.Information, 2);
              Logging.AddLogEntry((object) this, "Current File: " + this._CuFileName_FullName.ToString(), EventLogEntryType.Information, 2);
              Logging.AddLogEntry((object) this, "AuthAddress: " + httpUploadAsync.AuthAddress.ToString(), EventLogEntryType.Information, 2);
              if (this._Proxy != null)
              {
                httpUploadAsync.Proxy = (IWebProxy) this._Proxy;
                Logging.AddLogEntry((object) this, "Proxy: " + this._Proxy.Address.ToString(), EventLogEntryType.Information, 2);
              }
              httpUploadAsync.FinalDestination = this._FinalDesitnation;
              Logging.AddLogEntry((object) this, "Starting Upload", EventLogEntryType.Information, 1);
              httpUploadAsync.StartUpload();
              this.UpdateFileLabel(this._CuFileName);
              WaitHandle.WaitAll((WaitHandle[]) this.WaitAllEvents);
              Thread.Sleep(30);
            }
          }
          checked { ++num1; }
        }
      }
      finally
      {
        IEnumerator<string> enumerator;
        enumerator?.Dispose();
      }
      if (this._ErrorList.Count > 0)
      {
        this.prgFile.ColorTable = eProgressBarItemColor.Error;
        this.prgOverall.ColorTable = eProgressBarItemColor.Error;
        this.UpdateProgress(100.0);
        Thread.Sleep(30);
        this.UpdateCompleteLabel(false);
        this.UpdateResponseWindow("\r\n********Error List Summary********\r\n");
        try
        {
          foreach (ctrlUploadFiles.FileError error in this._ErrorList)
            this.UpdateResponseWindow("Error on file: " + error.FileName + "\r\nError: " + error.Err + "\r\n\r\n");
        }
        finally
        {
          List<ctrlUploadFiles.FileError>.Enumerator enumerator;
          enumerator.Dispose();
        }
        ctrlUploadFiles.JobCompleteEventHandler jobCompleteEvent = this.JobCompleteEvent;
        if (jobCompleteEvent != null)
          jobCompleteEvent(false);
      }
      else
      {
        this.WriteFilesToUploadList();
        this.UpdateProgress(100.0);
        Thread.Sleep(30);
        this.UpdateCompleteLabel(true);
        ctrlUploadFiles.JobCompleteEventHandler jobCompleteEvent = this.JobCompleteEvent;
        if (jobCompleteEvent != null)
          jobCompleteEvent(true);
      }
    }

    private void UpdateProgress(double Percentage)
    {
      if (this.prgFile.InvokeRequired)
        this.prgFile.Invoke((Delegate) new ctrlUploadFiles.PrgFile_UpdateDisplay(this.UpdateFileprg), (object) Percentage);
      if (!this.prgOverall.InvokeRequired)
        return;
      this.prgOverall.Invoke((Delegate) new ctrlUploadFiles.PrgFile_UpdateDisplay(this.UpdateOverallprg), (object) Percentage);
    }

    private void UpdateFileprg(double Percentage)
    {
      if (!this.prgFile.Visible)
      {
        this.prgFile.Visible = true;
        this.prgOverall.Visible = true;
        this.lblCuFile.Visible = true;
        this.lblOverall.Visible = true;
        this.prgDLInitialize.Visible = false;
      }
      this.prgFile.Value = checked ((int) System.Math.Round(Percentage));
    }

    private void UpdateOverallprg(double percentage) => this.prgOverall.Value = checked ((int) System.Math.Round(unchecked (percentage + (double) checked (this._CuFileNum * 100))));

    private void UploadComplete(UploadFileCompletedEventArgs e)
    {
      if (e.Cancelled)
      {
        this._ErrorList.Add(new ctrlUploadFiles.FileError()
        {
          FileName = this._CuFileName_FullName,
          Err = e.Cancelled.ToString()
        });
        Logging.AddLogEntry((object) this, "UploadComplete: upload cancelled:" + this._CuFileName_FullName.ToString(), EventLogEntryType.Error, 0);
        this.AddFileToList(this._CuFileName_FullName, false);
      }
      else if (e.Error != null)
      {
        this._ErrorList.Add(new ctrlUploadFiles.FileError()
        {
          FileName = this._CuFileName_FullName,
          Err = e.Error.ToString()
        });
        this.AddFileToList(this._CuFileName_FullName, false);
        string myMSG = "*****Error******\r\n\t" + e.Error.ToString() + "\r\n\r\n";
        this.UpdateResponseWindow(myMSG);
        Logging.AddLogEntry((object) this, "UploadComplete: eror:" + myMSG, EventLogEntryType.Error, 0);
      }
      else
      {
        bool flag = false;
        ctrlUploadFiles.ServerResponse serverResponse = (ctrlUploadFiles.ServerResponse) null;
        if (!Path.IsPathRooted(this._TemporaryDestination))
        {
          serverResponse = this.DecodeJSON(Encoding.UTF8.GetString(e.Result));
          if (Operators.CompareString(serverResponse.Status.ToLower(), "success".ToLower(), false) == 0)
            flag = true;
          string myMSG = serverResponse.FileName + "\r\n\t" + serverResponse.FinalDestination + "\r\n\t" + serverResponse.Status;
          this.UpdateResponseWindow(myMSG);
          if (flag)
            Logging.AddLogEntry((object) this, "UploadComplete: Success:" + myMSG, EventLogEntryType.Information, 1);
          else
            Logging.AddLogEntry((object) this, "UploadComplete: Server Error:" + myMSG, EventLogEntryType.Error, 0);
        }
        else if (MyProject.Computer.FileSystem.FileExists(this._TemporaryDestination))
        {
          Logging.AddLogEntry((object) this, "UploadCompleted successfully", EventLogEntryType.Information, 1);
          flag = true;
        }
        if (flag)
          this.AddFileToList(this._CuFileName_FullName, true);
        else
          this._ErrorList.Add(new ctrlUploadFiles.FileError()
          {
            FileName = this._CuFileName_FullName,
            Err = serverResponse.Status
          });
      }
      this.WaitAllEvents[0].Set();
    }

    private void UpdateFileLabel(string strLabel)
    {
      if (this.lblCuFile.InvokeRequired)
        this.lblCuFile.Invoke((Delegate) new ctrlUploadFiles.lblCuFile_UpdateDisplay(this.UpdateFileLabel), (object) strLabel);
      else
        this.lblCuFile.Text = strLabel;
    }

    private void UpdateCompleteLabel(bool Success)
    {
      if (this.lblCuFile.InvokeRequired)
        this.lblCuFile.Invoke((Delegate) new ctrlUploadFiles.lblComplete_UpdateDisplay(this.UpdateCompleteLabel), (object) Success);
      else if (Success)
      {
        if (this._CuFileNum > 0)
        {
          this.lblComplete.Visible = true;
        }
        else
        {
          this.lblComplete.Text = "No files waiting to be uploaded";
          this.lblComplete.Visible = true;
          this.lblCuFile.Visible = false;
          this.lblOverall.Visible = false;
          this.prgDLInitialize.Visible = false;
          this.prgFile.Visible = false;
          this.prgOverall.Visible = false;
        }
      }
      else
      {
        this.lblComplete.Text = Conversions.ToString(this._ErrorList.Count) + " files had errors wile uploading.";
        this.lblComplete.Visible = true;
      }
    }

    private ctrlUploadFiles.ServerResponse DecodeJSON(string strJSON)
    {
      if (Operators.CompareString(strJSON, (string) null, false) == 0)
        return (ctrlUploadFiles.ServerResponse) null;
      Dictionary<string, object> dictionary = (Dictionary<string, object>) new JavaScriptSerializer().DeserializeObject(strJSON);
      return new ctrlUploadFiles.ServerResponse()
      {
        FileName = Conversions.ToString(dictionary["filename"]),
        FinalDestination = Conversions.ToString(dictionary["finaldestination"]),
        Status = Conversions.ToString(dictionary["status"])
      };
    }

    public static List<ctrlUploadFiles.FileUploads> ReadFileUploadList(
      string FileDir,
      string FileUploadListName)
    {
      List<ctrlUploadFiles.FileUploads> fileUploadsList = new List<ctrlUploadFiles.FileUploads>();
      if (MyProject.Computer.FileSystem.FileExists(Path.Combine(FileDir, FileUploadListName)))
      {
        string[,] strArray = FileProcessing.ReadDelimitedFile(Path.Combine(FileDir, FileUploadListName), ",");
        int num = Information.UBound((Array) strArray);
        int index = 0;
        while (index <= num)
        {
          if (Operators.CompareString(strArray[index, 0], (string) null, false) != 0)
            fileUploadsList.Add(new ctrlUploadFiles.FileUploads()
            {
              FileName = strArray[index, 0],
              FileFinalized = Conversions.ToBoolean(strArray[index, 1]),
              UploadDate = Conversions.ToDate(strArray[index, 2]),
              Success = Conversions.ToBoolean(strArray[index, 3])
            });
          checked { ++index; }
        }
      }
      return fileUploadsList;
    }

    public static bool DetermineIfFileShouldBeUploaded(
      string FileName,
      List<ctrlUploadFiles.FileUploads> FileUploadList)
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      int num = checked (FileUploadList.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (Operators.CompareString(FileUploadList[index].FileName, FileName, false) == 0)
        {
          flag1 = true;
          Logging.AddLogEntry((object) "ctrlUploadFiles: DetermineIfFileShouldBeUploaded", "FileNameFound: " + FileName, EventLogEntryType.Information, 3);
          Logging.AddLogEntry((object) "ctrlUploadFiles: DetermineIfFileShouldBeUploaded", "File Upload Success: " + Conversions.ToString(FileUploadList[index].Success), EventLogEntryType.Information, 3);
          Logging.AddLogEntry((object) "ctrlUploadFiles: DetermineIfFileShouldBeUploaded", "File Finalized: " + Conversions.ToString(FileUploadList[index].FileFinalized), EventLogEntryType.Information, 3);
          if (FileUploadList[index].Success)
            flag3 = true;
          if (FileUploadList[index].FileFinalized)
          {
            flag2 = true;
            break;
          }
          break;
        }
        checked { ++index; }
      }
      return !flag1 || !flag3 || !flag2 || !flag2;
    }

    public static bool CheckForFileInList(
      string FileName,
      List<ctrlUploadFiles.FileUploads> FileUploadList)
    {
      int num = checked (FileUploadList.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (Operators.CompareString(FileUploadList[index].FileName, FileName, false) == 0)
          return true;
        checked { ++index; }
      }
      return false;
    }

    private void AddFileToList(string FileName, bool Success)
    {
      ctrlUploadFiles.FileUploads fileUploads = new ctrlUploadFiles.FileUploads();
      fileUploads.FileName = FileName.ToString();
      fileUploads.FileFinalized = Conversions.ToBoolean(ctrlUploadFiles.DetermineIfFileIsFinalized(ctrlUploadFiles.ParseFileName(FileName)).ToString());
      fileUploads.UploadDate = Conversions.ToDate(DateAndTime.Now.ToString());
      fileUploads.Success = Conversions.ToBoolean(Success.ToString());
      this.RemoveEntryFromFileList(fileUploads.FileName);
      this._FileUploadList.Add(fileUploads);
    }

    private void WriteFilesToUploadList()
    {
      int num1 = 4;
      ctrlUploadFiles.FileUploads fileUploads = new ctrlUploadFiles.FileUploads();
      if (num1 != fileUploads._ItemCnt)
        throw new ApplicationException();
      int num2 = checked (this._FileUploadList.Count - 1);
      string[,] Body = new string[checked (num2 + 1), checked (num1 - 1 + 1)];
      int num3 = num2;
      int index = 0;
      while (index <= num3)
      {
        Body[index, 0] = this._FileUploadList[index].FileName;
        Body[index, 1] = Conversions.ToString(this._FileUploadList[index].FileFinalized);
        Body[index, 2] = Conversions.ToString(this._FileUploadList[index].UploadDate);
        Body[index, 3] = Conversions.ToString(this._FileUploadList[index].Success);
        checked { ++index; }
      }
      this.ChangeFileHiddenAttribute(Path.Combine(this._FileDir, ctrlUploadFiles.FileUploadListName), false);
      FileProcessing.WriteDelimitedFile(Path.Combine(this._FileDir, ctrlUploadFiles.FileUploadListName), (string[]) null, Body, ",", false);
      this.ChangeFileHiddenAttribute(Path.Combine(this._FileDir, ctrlUploadFiles.FileUploadListName), true);
    }

    private void RemoveEntryFromFileList(string FileName)
    {
      int num = checked (this._FileUploadList.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (Operators.CompareString(this._FileUploadList[index].FileName.ToUpper(), FileName.ToUpper(), false) == 0)
        {
          this._FileUploadList.RemoveAt(index);
          break;
        }
        checked { ++index; }
      }
    }

    public static bool DetermineIfFileIsFinalized(ctrlUploadFiles.FileInfo File)
    {
      Logging.AddLogEntry((object) "ctrlUploadFiles:DetermineIfFileIsFinalized: ", "FileName: " + File.FileName, EventLogEntryType.Information, 2);
      if (File.ValidName)
      {
        if (File.FileType == ctrlUploadFiles.FileType.Daily)
        {
          int num = checked ((int) DateAndTime.DateDiff(DateInterval.Day, File.FileDate, DateAndTime.Now));
          Logging.AddLogEntry((object) "ctrlUploadFiles:DetermineIfFileIsFinalized: ", "Daily FileType DeltaDate (days) = " + Conversions.ToString(num), EventLogEntryType.Information, 3);
          return num > 0;
        }
        if (File.FileType != ctrlUploadFiles.FileType.Monthly)
          return false;
        int num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, File.FileDate, DateAndTime.Now));
        Logging.AddLogEntry((object) "ctrlUploadFiles:DetermineIfFileIsFinalized: ", "Monthly FileType DeltaDate (months) = " + Conversions.ToString(num1), EventLogEntryType.Information, 3);
        return num1 > 0;
      }
      Logging.AddLogEntry((object) "ctrlUploadFiles:DetermineIfFileIsFinalized: ", "filename not valid", EventLogEntryType.Information, 3);
      return true;
    }

    public static ctrlUploadFiles.FileInfo ParseFileName(string FileName)
    {
      string[] strArray1 = Strings.Split(Path.GetFileNameWithoutExtension(FileName), "_");
      ctrlUploadFiles.FileInfo fileInfo1 = new ctrlUploadFiles.FileInfo();
      ctrlUploadFiles.FileInfo fileName;
      try
      {
        if (strArray1.Length >= 4)
        {
          fileInfo1.DataType = !strArray1[0].ToUpper().StartsWith("PST") ? strArray1[0] : "PST";
          fileInfo1.Product = strArray1[1];
          fileInfo1.ComputerName = strArray1[2];
          string[] strArray2 = Strings.Split(strArray1[3], "-");
          fileInfo1.FileType = strArray2.Length != 2 ? (strArray2.Length != 3 ? ctrlUploadFiles.FileType.NA : ctrlUploadFiles.FileType.Daily) : ctrlUploadFiles.FileType.Monthly;
          CultureInfo cultureInfo = new CultureInfo("en-us");
          string s = strArray1[3];
          CultureInfo provider = cultureInfo;
          ctrlUploadFiles.FileInfo fileInfo2 = fileInfo1;
          DateTime fileDate = fileInfo2.FileDate;
          ref DateTime local = ref fileDate;
          DateTime.TryParse(s, (IFormatProvider) provider, DateTimeStyles.AssumeLocal, out local);
          fileInfo2.FileDate = fileDate;
          Logging.AddLogEntry((object) "ctrlUploadFiles:ParseFileName: ", "FileType = " + fileInfo1.FileType.ToString(), EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "ctrlUploadFiles:ParseFileName: ", "FileDate = " + fileInfo1.FileDate.ToString(), EventLogEntryType.Information, 4);
          fileInfo1.FileName = FileName;
          fileInfo1.ValidName = true;
        }
        else
        {
          fileInfo1.FileName = strArray1[0];
          fileInfo1.Product = "Unknown";
          fileInfo1.DataType = "Unknown";
          fileInfo1.ValidName = false;
        }
        fileName = fileInfo1;
      }
      catch (ArgumentException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        fileName = new ctrlUploadFiles.FileInfo()
        {
          ValidName = false,
          FileName = FileName
        };
        ProjectData.ClearProjectError();
      }
      return fileName;
    }

    private void ChangeFileHiddenAttribute(string Path, bool Hide)
    {
      if (!System.IO.File.Exists(Path))
        return;
      FileAttributes attributes = System.IO.File.GetAttributes(Path);
      if (!Hide)
      {
        FileAttributes fileAttributes = this.RemoveAttribute(attributes, FileAttributes.Hidden);
        System.IO.File.SetAttributes(Path, fileAttributes);
        Console.WriteLine("The {0} file is no longer hidden.", (object) Path);
      }
      else if (Hide)
      {
        System.IO.File.SetAttributes(Path, System.IO.File.GetAttributes(Path) | FileAttributes.Hidden);
        Console.WriteLine("The {0} file is now hidden.", (object) Path);
      }
    }

    private FileAttributes RemoveAttribute(
      FileAttributes attributes,
      FileAttributes attributesToRemove)
    {
      return attributes & ~attributesToRemove;
    }

    private void UpdateResponseWindow(string myMSG)
    {
      if (!this.rtbResponseWindow.Visible)
        return;
      if (this.rtbResponseWindow.InvokeRequired)
      {
        this.rtbResponseWindow.Invoke((Delegate) new ctrlUploadFiles.delResponseWindow_Update(this.UpdateResponseWindow), (object) myMSG);
      }
      else
      {
        this.rtbResponseWindow.AppendText(myMSG + "\r\n");
        this.rtbResponseWindow.ScrollToCaret();
      }
    }

    private void SetResponseWindowVisibility(bool p1)
    {
      if (this.rtbResponseWindow.InvokeRequired)
        this.rtbResponseWindow.Invoke((Delegate) new ctrlUploadFiles.delResponseWindow_SetVisiblity(this.SetResponseWindowVisibility), (object) p1);
      else
        this.rtbResponseWindow.Visible = p1;
    }

    private void ctrlUploadFiles_Disposed(object sender, EventArgs e)
    {
      if (this.thdUpload == null || !this.thdUpload.IsAlive)
        return;
      this.thdUpload.Abort();
    }

    public enum FileType
    {
      Monthly,
      Daily,
      NA,
    }

    public delegate void JobCompleteEventHandler(bool Status);

    private delegate void PrgFile_UpdateDisplay(double Percentage);

    private delegate void prgOverall_UpdateDisplay(double Percentage);

    private delegate void lblCuFile_UpdateDisplay(string strLabel);

    private delegate void lblComplete_UpdateDisplay(bool Sucess);

    private delegate void delResponseWindow_Update(string myMSG);

    private delegate void delResponseWindow_SetVisiblity(bool Visible);

    private class FileError
    {
      [DebuggerNonUserCode]
      public FileError()
      {
      }

      public string FileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string Err { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }

    public class FileUploads
    {
      public FileUploads() => this._ItemCnt = 4;

      protected internal int _ItemCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string FileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool FileFinalized { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public DateTime UploadDate { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool Success { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }

    public class FileInfo
    {
      public FileInfo() => this.ValidName = true;

      public string DataType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public ctrlUploadFiles.FileType FileType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string Product { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string ComputerName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public DateTime FileDate { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool ValidName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string FileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }

    private class ServerResponse
    {
      [DebuggerNonUserCode]
      public ServerResponse()
      {
      }

      public string FinalDestination { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string FileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string Status { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }
  }
}
