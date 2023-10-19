// Decompiled with JetBrains decompiler
// Type: FUEL.frmZipProgress
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using FUEL.My;
using Ionic.Zip;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class frmZipProgress : MetroForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("prgMain")]
    private ProgressBarX _prgMain;
    [AccessedThroughProperty("prgAlternate")]
    private ProgressBarX _prgAlternate;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("lblFile")]
    private LabelX _lblFile;
    [AccessedThroughProperty("lblJob")]
    private LabelX _lblJob;

    [DebuggerNonUserCode]
    static frmZipProgress()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (frmZipProgress.__ENCList)
      {
        if (frmZipProgress.__ENCList.Count == frmZipProgress.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (frmZipProgress.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (frmZipProgress.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                frmZipProgress.__ENCList[index1] = frmZipProgress.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          frmZipProgress.__ENCList.RemoveRange(index1, checked (frmZipProgress.__ENCList.Count - index1));
          frmZipProgress.__ENCList.Capacity = frmZipProgress.__ENCList.Count;
        }
        frmZipProgress.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.prgMain = new ProgressBarX();
      this.prgAlternate = new ProgressBarX();
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.lblFile = new LabelX();
      this.lblJob = new LabelX();
      this.TableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.prgMain.BackColor = Color.White;
      this.prgMain.BackgroundStyle.CornerType = eCornerType.Square;
      this.prgMain.Dock = DockStyle.Fill;
      this.prgMain.ForeColor = Color.Black;
      ProgressBarX prgMain1 = this.prgMain;
      Point point1 = new Point(3, 95);
      Point point2 = point1;
      prgMain1.Location = point2;
      this.prgMain.Name = "prgMain";
      ProgressBarX prgMain2 = this.prgMain;
      Size size1 = new Size(363, 26);
      Size size2 = size1;
      prgMain2.Size = size2;
      this.prgMain.Step = 0;
      this.prgMain.TabIndex = 0;
      this.prgMain.Text = "ProgressBarX1";
      this.prgAlternate.BackColor = Color.White;
      this.prgAlternate.BackgroundStyle.CornerType = eCornerType.Square;
      this.prgAlternate.Dock = DockStyle.Fill;
      this.prgAlternate.ForeColor = Color.Black;
      ProgressBarX prgAlternate1 = this.prgAlternate;
      point1 = new Point(3, 33);
      Point point3 = point1;
      prgAlternate1.Location = point3;
      this.prgAlternate.Name = "prgAlternate";
      ProgressBarX prgAlternate2 = this.prgAlternate;
      size1 = new Size(363, 26);
      Size size3 = size1;
      prgAlternate2.Size = size3;
      this.prgAlternate.TabIndex = 1;
      this.prgAlternate.Text = "ProgressBarX1";
      this.TableLayoutPanel1.BackColor = Color.FromArgb(211, 211, 211);
      this.TableLayoutPanel1.ColumnCount = 1;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.TableLayoutPanel1.Controls.Add((Control) this.prgMain, 0, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.prgAlternate, 0, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblFile, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblJob, 0, 2);
      this.TableLayoutPanel1.Dock = DockStyle.Fill;
      this.TableLayoutPanel1.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      point1 = new Point(0, 0);
      Point point4 = point1;
      tableLayoutPanel1_1.Location = point4;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 4;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      size1 = new Size(369, 124);
      Size size4 = size1;
      tableLayoutPanel1_2.Size = size4;
      this.TableLayoutPanel1.TabIndex = 2;
      this.lblFile.BackColor = Color.Transparent;
      this.lblFile.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblFile.ForeColor = Color.Black;
      LabelX lblFile1 = this.lblFile;
      point1 = new Point(3, 3);
      Point point5 = point1;
      lblFile1.Location = point5;
      this.lblFile.Name = "lblFile";
      LabelX lblFile2 = this.lblFile;
      size1 = new Size(75, 23);
      Size size5 = size1;
      lblFile2.Size = size5;
      this.lblFile.TabIndex = 2;
      this.lblFile.Text = "File Progress";
      this.lblJob.BackColor = Color.Transparent;
      this.lblJob.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblJob.ForeColor = Color.Black;
      LabelX lblJob1 = this.lblJob;
      point1 = new Point(3, 65);
      Point point6 = point1;
      lblJob1.Location = point6;
      this.lblJob.Name = "lblJob";
      LabelX lblJob2 = this.lblJob;
      size1 = new Size(75, 23);
      Size size6 = size1;
      lblJob2.Size = size6;
      this.lblJob.TabIndex = 3;
      this.lblJob.Text = "Job Progress";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(369, 124);
      this.ClientSize = size1;
      this.ControlBox = false;
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.DoubleBuffered = true;
      this.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (frmZipProgress);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.TableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual ProgressBarX prgMain
    {
      [DebuggerNonUserCode] get => this._prgMain;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._prgMain = value;
    }

    internal virtual ProgressBarX prgAlternate
    {
      [DebuggerNonUserCode] get => this._prgAlternate;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._prgAlternate = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    internal virtual LabelX lblFile
    {
      [DebuggerNonUserCode] get => this._lblFile;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblFile = value;
    }

    internal virtual LabelX lblJob
    {
      [DebuggerNonUserCode] get => this._lblJob;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblJob = value;
    }

    private string _SourceDir { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _OutputName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private long _BytesTransfered { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private long _JobSize { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private long _MaxFileSize { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _DeleteFilesAfterZip { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _HideForm { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public long MaxFileSize
    {
      get => this._MaxFileSize;
      set => this._MaxFileSize = checked (value * 1024L * 1024L);
    }

    public bool DeleteFilesAfterZip
    {
      get => this._DeleteFilesAfterZip;
      set => this._DeleteFilesAfterZip = value;
    }

    public bool HideForm
    {
      get => this._HideForm;
      set => this._HideForm = value;
    }

    public frmZipProgress(string SourceDir, string OutputName, bool DeleteSourceFiles)
    {
      this.Shown += new EventHandler(this.frmSimpleProgress_Shown);
      frmZipProgress.__ENCAddToList((object) this);
      this._BytesTransfered = 0L;
      this._JobSize = 0L;
      this._MaxFileSize = 0L;
      this._DeleteFilesAfterZip = false;
      this._HideForm = false;
      this.InitializeComponent();
      this._SourceDir = SourceDir;
      this._OutputName = OutputName;
      this._DeleteFilesAfterZip = DeleteSourceFiles;
      ReadOnlyCollection<string> files = MyProject.Computer.FileSystem.GetFiles(this._SourceDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, (string[]) null);
      long num;
      try
      {
        foreach (string file in files)
          checked { num += MyProject.Computer.FileSystem.GetFileInfo(file).Length; }
      }
      finally
      {
        IEnumerator<string> enumerator;
        enumerator?.Dispose();
      }
      this._JobSize = num;
    }

    private void frmSimpleProgress_Shown(object sender, EventArgs e)
    {
      if (this._HideForm)
        this.Hide();
      this.Zip();
      if (!this.DeleteFilesAfterZip)
        return;
      this.DeleteSourceFiles();
    }

    private void DeleteSourceFiles()
    {
      ReadOnlyCollection<string> files = MyProject.Computer.FileSystem.GetFiles(this._SourceDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, (string[]) null);
      try
      {
        foreach (string str in files)
        {
          Path.GetExtension(str);
          if (Operators.CompareString(Path.GetFileNameWithoutExtension(str), Path.GetFileNameWithoutExtension(this._OutputName), false) != 0)
            MyProject.Computer.FileSystem.DeleteFile(str, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
        }
      }
      finally
      {
        IEnumerator<string> enumerator;
        enumerator?.Dispose();
      }
      ReadOnlyCollection<string> directories = MyProject.Computer.FileSystem.GetDirectories(this._SourceDir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories);
      try
      {
        foreach (string directory in directories)
          MyProject.Computer.FileSystem.DeleteDirectory(directory, DeleteDirectoryOption.DeleteAllContents);
      }
      finally
      {
        IEnumerator<string> enumerator;
        enumerator?.Dispose();
      }
    }

    private void Zip()
    {
      try
      {
        using (ZipFile zipFile = new ZipFile())
        {
          zipFile.AddDirectory(this._SourceDir);
          if (this.MaxFileSize != 0L)
            zipFile.MaxOutputSegmentSize = checked ((int) this.MaxFileSize);
          zipFile.SaveProgress += new EventHandler<SaveProgressEventArgs>(this.Zip_SaveProgress);
          zipFile.Save(this._OutputName);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Show();
        ProjectData.ClearProjectError();
      }
    }

    private void Zip_SaveProgress(object sender, SaveProgressEventArgs e)
    {
      switch (e.EventType)
      {
        case ZipProgressEventType.Saving_AfterWriteEntry:
          this.StepArchiveProgress(e);
          break;
        case ZipProgressEventType.Saving_Completed:
          this.SaveCompleted();
          break;
        case ZipProgressEventType.Saving_EntryBytesRead:
          this.StepEntryProgress(e);
          break;
      }
    }

    private void StepArchiveProgress(SaveProgressEventArgs e)
    {
      if (this.prgMain.InvokeRequired)
      {
        this.prgMain.Invoke((Delegate) new frmZipProgress.SaveEntryProgress(this.StepArchiveProgress), (object) e);
      }
      else
      {
        checked { this._BytesTransfered += e.CurrentEntry.UncompressedSize; }
        this.prgMain.Value = checked ((int) Math.Round(Math.Round(unchecked ((double) this._BytesTransfered / (double) this._JobSize * 100.0), 0)));
        this.Update();
      }
    }

    private void SaveCompleted() => this.Close();

    private void StepEntryProgress(SaveProgressEventArgs e)
    {
      if (this.prgAlternate.InvokeRequired)
      {
        this.prgAlternate.Invoke((Delegate) new frmZipProgress.SaveEntryProgress(this.StepEntryProgress), (object) e);
      }
      else
      {
        this.prgAlternate.Value = checked ((int) Math.Round(Math.Round(unchecked ((double) e.BytesTransferred / (double) e.TotalBytesToTransfer * 100.0), 0)));
        this.prgMain.Value = checked ((int) Math.Round(Math.Round(unchecked ((double) checked (this._BytesTransfered + e.BytesTransferred) / (double) this._JobSize * 100.0), 0)));
        this.Update();
      }
    }

    private delegate void SaveEntryProgress(SaveProgressEventArgs e);
  }
}
