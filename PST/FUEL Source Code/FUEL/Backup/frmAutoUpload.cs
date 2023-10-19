// Decompiled with JetBrains decompiler
// Type: FUEL.frmAutoUpload
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class frmAutoUpload : MetroAppForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("MetroShell1")]
    private MetroShell _MetroShell1;
    [AccessedThroughProperty("MetroTabPanel1")]
    private MetroTabPanel _MetroTabPanel1;
    [AccessedThroughProperty("MetroTabPanel2")]
    private MetroTabPanel _MetroTabPanel2;
    [AccessedThroughProperty("MetroAppButton1")]
    private MetroAppButton _MetroAppButton1;
    [AccessedThroughProperty("MetroTabItem1")]
    private MetroTabItem _MetroTabItem1;
    [AccessedThroughProperty("MetroTabItem2")]
    private MetroTabItem _MetroTabItem2;
    [AccessedThroughProperty("ButtonItem1")]
    private ButtonItem _ButtonItem1;
    [AccessedThroughProperty("QatCustomizeItem1")]
    private QatCustomizeItem _QatCustomizeItem1;
    [AccessedThroughProperty("StyleManager1")]
    private StyleManager _StyleManager1;
    private ctrlUploadFiles _ctrlUpload;
    private string _FileDir;
    private PST.TestSites _DestinationSite;
    private bool _HideForm;

    [DebuggerNonUserCode]
    static frmAutoUpload()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (frmAutoUpload.__ENCList)
      {
        if (frmAutoUpload.__ENCList.Count == frmAutoUpload.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (frmAutoUpload.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (frmAutoUpload.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                frmAutoUpload.__ENCList[index1] = frmAutoUpload.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          frmAutoUpload.__ENCList.RemoveRange(index1, checked (frmAutoUpload.__ENCList.Count - index1));
          frmAutoUpload.__ENCList.Capacity = frmAutoUpload.__ENCList.Count;
        }
        frmAutoUpload.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.MetroShell1 = new MetroShell();
      this.MetroTabPanel1 = new MetroTabPanel();
      this.MetroTabPanel2 = new MetroTabPanel();
      this.MetroAppButton1 = new MetroAppButton();
      this.MetroTabItem1 = new MetroTabItem();
      this.MetroTabItem2 = new MetroTabItem();
      this.ButtonItem1 = new ButtonItem();
      this.QatCustomizeItem1 = new QatCustomizeItem();
      this.StyleManager1 = new StyleManager(this.components);
      this.MetroShell1.SuspendLayout();
      this.SuspendLayout();
      this.MetroShell1.BackColor = Color.White;
      this.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square;
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel1);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel2);
      this.MetroShell1.Dock = DockStyle.Top;
      this.MetroShell1.ForeColor = Color.Black;
      this.MetroShell1.HelpButtonText = (string) null;
      this.MetroShell1.Items.AddRange(new BaseItem[3]
      {
        (BaseItem) this.MetroAppButton1,
        (BaseItem) this.MetroTabItem1,
        (BaseItem) this.MetroTabItem2
      });
      this.MetroShell1.KeyTipsFont = new Font("Tahoma", 7f);
      MetroShell metroShell1_1 = this.MetroShell1;
      Point point1 = new Point(0, 1);
      Point point2 = point1;
      metroShell1_1.Location = point2;
      this.MetroShell1.Name = "MetroShell1";
      this.MetroShell1.QuickToolbarItems.AddRange(new BaseItem[2]
      {
        (BaseItem) this.ButtonItem1,
        (BaseItem) this.QatCustomizeItem1
      });
      MetroShell metroShell1_2 = this.MetroShell1;
      Size size1 = new Size(496, 319);
      Size size2 = size1;
      metroShell1_2.Size = size2;
      this.MetroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
      this.MetroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
      this.MetroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
      this.MetroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
      this.MetroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
      this.MetroShell1.SystemText.QatDialogAddButton = "&Add >>";
      this.MetroShell1.SystemText.QatDialogCancelButton = "Cancel";
      this.MetroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
      this.MetroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
      this.MetroShell1.SystemText.QatDialogOkButton = "OK";
      this.MetroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
      this.MetroShell1.SystemText.QatDialogRemoveButton = "&Remove";
      this.MetroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
      this.MetroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
      this.MetroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
      this.MetroShell1.TabIndex = 0;
      this.MetroShell1.TabStripFont = new Font("Segoe UI", 10.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.MetroShell1.Text = "MetroShell1";
      this.MetroTabPanel1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel1.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel1_1 = this.MetroTabPanel1;
      point1 = new Point(0, 26);
      Point point3 = point1;
      metroTabPanel1_1.Location = point3;
      this.MetroTabPanel1.Name = "MetroTabPanel1";
      MetroTabPanel metroTabPanel1_2 = this.MetroTabPanel1;
      System.Windows.Forms.Padding padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding2 = padding1;
      metroTabPanel1_2.Padding = padding2;
      MetroTabPanel metroTabPanel1_3 = this.MetroTabPanel1;
      size1 = new Size(496, 293);
      Size size3 = size1;
      metroTabPanel1_3.Size = size3;
      this.MetroTabPanel1.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel1.TabIndex = 1;
      this.MetroTabPanel2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel2.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel2_1 = this.MetroTabPanel2;
      point1 = new Point(0, 26);
      Point point4 = point1;
      metroTabPanel2_1.Location = point4;
      this.MetroTabPanel2.Name = "MetroTabPanel2";
      MetroTabPanel metroTabPanel2_2 = this.MetroTabPanel2;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding3 = padding1;
      metroTabPanel2_2.Padding = padding3;
      MetroTabPanel metroTabPanel2_3 = this.MetroTabPanel2;
      size1 = new Size(496, 293);
      Size size4 = size1;
      metroTabPanel2_3.Size = size4;
      this.MetroTabPanel2.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel2.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel2.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel2.TabIndex = 2;
      this.MetroTabPanel2.Visible = false;
      this.MetroAppButton1.AutoExpandOnClick = true;
      this.MetroAppButton1.CanCustomize = false;
      MetroAppButton metroAppButton1 = this.MetroAppButton1;
      size1 = new Size(16, 16);
      Size size5 = size1;
      metroAppButton1.ImageFixedSize = size5;
      this.MetroAppButton1.ImagePaddingHorizontal = 0;
      this.MetroAppButton1.ImagePaddingVertical = 0;
      this.MetroAppButton1.Name = "MetroAppButton1";
      this.MetroAppButton1.ShowSubItems = false;
      this.MetroAppButton1.Text = "&File";
      this.MetroAppButton1.Visible = false;
      this.MetroTabItem1.Checked = true;
      this.MetroTabItem1.Name = "MetroTabItem1";
      this.MetroTabItem1.Panel = this.MetroTabPanel1;
      this.MetroTabItem1.Text = "File Uploads";
      this.MetroTabItem2.Name = "MetroTabItem2";
      this.MetroTabItem2.Panel = this.MetroTabPanel2;
      this.MetroTabItem2.Text = "&VIEW";
      this.MetroTabItem2.Visible = false;
      this.ButtonItem1.Name = "ButtonItem1";
      this.ButtonItem1.Text = "ButtonItem1";
      this.QatCustomizeItem1.BeginGroup = true;
      this.QatCustomizeItem1.Name = "QatCustomizeItem1";
      this.StyleManager1.ManagerStyle = eStyle.Metro;
      this.StyleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.White, Color.FromArgb((int) byte.MaxValue, 163, 26));
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(497, 324);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.MetroShell1);
      this.Name = nameof (frmAutoUpload);
      this.Text = nameof (frmAutoUpload);
      this.MetroShell1.ResumeLayout(false);
      this.MetroShell1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual MetroShell MetroShell1
    {
      [DebuggerNonUserCode] get => this._MetroShell1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroShell1 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel1
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel1 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel2
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel2 = value;
    }

    internal virtual MetroAppButton MetroAppButton1
    {
      [DebuggerNonUserCode] get => this._MetroAppButton1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroAppButton1 = value;
    }

    internal virtual MetroTabItem MetroTabItem1
    {
      [DebuggerNonUserCode] get => this._MetroTabItem1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabItem1 = value;
    }

    internal virtual MetroTabItem MetroTabItem2
    {
      [DebuggerNonUserCode] get => this._MetroTabItem2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabItem2 = value;
    }

    internal virtual ButtonItem ButtonItem1
    {
      [DebuggerNonUserCode] get => this._ButtonItem1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ButtonItem1 = value;
    }

    internal virtual QatCustomizeItem QatCustomizeItem1
    {
      [DebuggerNonUserCode] get => this._QatCustomizeItem1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._QatCustomizeItem1 = value;
    }

    internal virtual StyleManager StyleManager1
    {
      [DebuggerNonUserCode] get => this._StyleManager1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._StyleManager1 = value;
    }

    public bool HideForm
    {
      get => this._HideForm;
      set => this._HideForm = value;
    }

    public frmAutoUpload(string FileDir)
    {
      this.Load += new EventHandler(this.frmAutoUpload_Load);
      this.Shown += new EventHandler(this.frmAutoUpload_Shown);
      frmAutoUpload.__ENCAddToList((object) this);
      this._HideForm = false;
      this.InitializeComponent();
      Logging.AddLogEntry((object) this, "Instantiating frmAutoUpload", EventLogEntryType.Information, 2);
      Logging.AddLogEntry((object) this, "File Dir: " + FileDir, EventLogEntryType.Information, 2);
      this._FileDir = FileDir;
      this._DestinationSite = UploadSettings.InstallLocation;
    }

    private void frmAutoUpload_Load(object sender, EventArgs e)
    {
      ReadOnlyCollection<string> files = MyProject.Computer.FileSystem.GetFiles(this._FileDir, SearchOption.SearchTopLevelOnly, ctrlUploadFiles.AllowedFileTypes);
      Logging.AddLogEntry((object) this, "File Count: " + Conversions.ToString(files.Count), EventLogEntryType.Information, 3);
      Collection<string> FileList = new Collection<string>();
      try
      {
        foreach (string str in files)
          FileList.Add(str);
      }
      finally
      {
        IEnumerator<string> enumerator;
        enumerator?.Dispose();
      }
      this._ctrlUpload = new ctrlUploadFiles(FileList, UploadSettings.InstallLocation, this._DestinationSite);
      this._ctrlUpload.JobComplete += new ctrlUploadFiles.JobCompleteEventHandler(this.JobComplete);
      this.MetroTabPanel1.Controls.Add((Control) this._ctrlUpload);
      this._ctrlUpload.Dock = DockStyle.Fill;
    }

    private void frmAutoUpload_Shown(object sender, EventArgs e)
    {
      if (this._HideForm)
        this.Hide();
      Logging.AddLogEntry((object) this, "frmAutoUpload_Shown: Starting Upload", EventLogEntryType.Information, 2);
      this._ctrlUpload.StartUpload();
    }

    private void JobComplete(bool Status)
    {
      string str = (string) null;
      if (Status)
      {
        str = "Job completed without error";
        Logging.AddLogEntry((object) this, str, EventLogEntryType.Information, 2);
      }
      else if (!Status)
      {
        str = "Job completed with errors";
        Logging.AddLogEntry((object) this, str, EventLogEntryType.Error, 0);
      }
      if (!Status)
      {
        int num = (int) Interaction.MsgBox((object) str);
      }
      this.CloseForm();
    }

    private void CloseForm()
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new frmAutoUpload.FRMClose(this.CloseForm));
      else
        this.Close();
    }

    private delegate void FRMClose();
  }
}
