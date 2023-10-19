// Decompiled with JetBrains decompiler
// Type: FUEL.frmMechChecks
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class frmMechChecks : MetroAppForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("MetroShell1")]
    private MetroShell _MetroShell1;
    [AccessedThroughProperty("MetroTabPanel1")]
    private MetroTabPanel _MetroTabPanel1;
    [AccessedThroughProperty("MetroTabItem1")]
    private MetroTabItem _MetroTabItem1;
    [AccessedThroughProperty("StyleManager1")]
    private StyleManager _StyleManager1;
    private ctrlMechChecks _ctrlMechChecks;
    private List<PST.PrinterMechChecks> _CheckList;

    [DebuggerNonUserCode]
    static frmMechChecks()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (frmMechChecks.__ENCList)
      {
        if (frmMechChecks.__ENCList.Count == frmMechChecks.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (frmMechChecks.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (frmMechChecks.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                frmMechChecks.__ENCList[index1] = frmMechChecks.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          frmMechChecks.__ENCList.RemoveRange(index1, checked (frmMechChecks.__ENCList.Count - index1));
          frmMechChecks.__ENCList.Capacity = frmMechChecks.__ENCList.Count;
        }
        frmMechChecks.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.MetroTabItem1 = new MetroTabItem();
      this.StyleManager1 = new StyleManager(this.components);
      this.MetroShell1.SuspendLayout();
      this.SuspendLayout();
      this.MetroShell1.BackColor = Color.White;
      this.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square;
      this.MetroShell1.CanCustomize = false;
      this.MetroShell1.CaptionVisible = true;
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel1);
      this.MetroShell1.Dock = DockStyle.Top;
      this.MetroShell1.ForeColor = Color.Black;
      this.MetroShell1.HelpButtonText = (string) null;
      this.MetroShell1.HelpButtonVisible = false;
      this.MetroShell1.Items.AddRange(new BaseItem[1]
      {
        (BaseItem) this.MetroTabItem1
      });
      this.MetroShell1.KeyTipsFont = new Font("Tahoma", 7f);
      MetroShell metroShell1_1 = this.MetroShell1;
      Point point1 = new Point(0, 1);
      Point point2 = point1;
      metroShell1_1.Location = point2;
      this.MetroShell1.Name = "MetroShell1";
      this.MetroShell1.SettingsButtonVisible = false;
      MetroShell metroShell1_2 = this.MetroShell1;
      Size size1 = new Size(769, 401);
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
      point1 = new Point(0, 51);
      Point point3 = point1;
      metroTabPanel1_1.Location = point3;
      this.MetroTabPanel1.Name = "MetroTabPanel1";
      this.MetroTabPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
      MetroTabPanel metroTabPanel1_2 = this.MetroTabPanel1;
      size1 = new Size(769, 350);
      Size size3 = size1;
      metroTabPanel1_2.Size = size3;
      this.MetroTabPanel1.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel1.TabIndex = 1;
      this.MetroTabItem1.Checked = true;
      this.MetroTabItem1.Name = "MetroTabItem1";
      this.MetroTabItem1.Panel = this.MetroTabPanel1;
      this.MetroTabItem1.Text = "Mech Checks";
      this.StyleManager1.ManagerStyle = eStyle.Metro;
      this.StyleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.White, Color.FromArgb((int) byte.MaxValue, 163, 26));
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(770, 406);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.MetroShell1);
      this.Name = nameof (frmMechChecks);
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

    internal virtual MetroTabItem MetroTabItem1
    {
      [DebuggerNonUserCode] get => this._MetroTabItem1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabItem1 = value;
    }

    internal virtual StyleManager StyleManager1
    {
      [DebuggerNonUserCode] get => this._StyleManager1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._StyleManager1 = value;
    }

    public frmMechChecks(List<PST.PrinterMechChecks> CheckList)
    {
      this.Load += new EventHandler(this.frmMechChecks_Load);
      frmMechChecks.__ENCAddToList((object) this);
      this.InitializeComponent();
      this._CheckList = CheckList;
    }

    private void frmMechChecks_Load(object sender, EventArgs e)
    {
      this._ctrlMechChecks = new ctrlMechChecks(this._CheckList);
      this.MetroTabPanel1.Controls.Add((Control) this._ctrlMechChecks);
      this._ctrlMechChecks.Dock = DockStyle.Fill;
    }
  }
}
