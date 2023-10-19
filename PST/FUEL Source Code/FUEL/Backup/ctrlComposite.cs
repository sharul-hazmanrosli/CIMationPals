// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlComposite
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class ctrlComposite : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("cmdShowRuncharts")]
    private ButtonItem _cmdShowRuncharts;
    [AccessedThroughProperty("cmdShowRegularcharts")]
    private ButtonItem _cmdShowRegularcharts;
    [AccessedThroughProperty("cmdShowDataGrid")]
    private ButtonItem _cmdShowDataGrid;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("cmdDataSelect")]
    private ButtonX _cmdDataSelect;
    private DataTable dtHistory;
    public ctrlRunCharts RunCharts;
    public ctrlDataGrid DataGrid;
    public ctrlRegularCharts RegularCharts;

    [DebuggerNonUserCode]
    static ctrlComposite()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlComposite.__ENCList)
      {
        if (ctrlComposite.__ENCList.Count == ctrlComposite.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlComposite.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlComposite.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlComposite.__ENCList[index1] = ctrlComposite.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlComposite.__ENCList.RemoveRange(index1, checked (ctrlComposite.__ENCList.Count - index1));
          ctrlComposite.__ENCList.Capacity = ctrlComposite.__ENCList.Count;
        }
        ctrlComposite.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.cmdDataSelect = new ButtonX();
      this.cmdShowRuncharts = new ButtonItem();
      this.cmdShowRegularcharts = new ButtonItem();
      this.cmdShowDataGrid = new ButtonItem();
      this.TableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.TableLayoutPanel1.BackColor = Color.Transparent;
      this.TableLayoutPanel1.ColumnCount = 2;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.TableLayoutPanel1.Controls.Add((Control) this.cmdDataSelect, 0, 0);
      this.TableLayoutPanel1.Dock = DockStyle.Fill;
      this.TableLayoutPanel1.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      Point point1 = new Point(0, 0);
      Point point2 = point1;
      tableLayoutPanel1_1.Location = point2;
      this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 2;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      Size size1 = new Size(586, 375);
      Size size2 = size1;
      tableLayoutPanel1_2.Size = size2;
      this.TableLayoutPanel1.TabIndex = 17;
      this.cmdDataSelect.AccessibleRole = AccessibleRole.PushButton;
      this.cmdDataSelect.AutoExpandOnClick = true;
      this.cmdDataSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.cmdDataSelect.ColorTable = eButtonColor.OrangeWithBackground;
      this.cmdDataSelect.Cursor = Cursors.Hand;
      ButtonX cmdDataSelect1 = this.cmdDataSelect;
      point1 = new Point(3, 3);
      Point point3 = point1;
      cmdDataSelect1.Location = point3;
      this.cmdDataSelect.Name = "cmdDataSelect";
      this.cmdDataSelect.PopupSide = ePopupSide.Right;
      this.cmdDataSelect.Shape = (ShapeDescriptor) new RoundRectangleShapeDescriptor(6);
      ButtonX cmdDataSelect2 = this.cmdDataSelect;
      size1 = new Size(201, 24);
      Size size3 = size1;
      cmdDataSelect2.Size = size3;
      this.cmdDataSelect.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdDataSelect.SubItems.AddRange(new BaseItem[3]
      {
        (BaseItem) this.cmdShowRuncharts,
        (BaseItem) this.cmdShowRegularcharts,
        (BaseItem) this.cmdShowDataGrid
      });
      this.cmdDataSelect.SubItemsExpandWidth = 20;
      this.cmdDataSelect.TabIndex = 14;
      this.cmdDataSelect.Text = "<b>Now Showing Run Charts</b>";
      this.cmdShowRuncharts.Cursor = Cursors.Hand;
      this.cmdShowRuncharts.GlobalItem = false;
      this.cmdShowRuncharts.Name = "cmdShowRuncharts";
      this.cmdShowRuncharts.OptionGroup = "1";
      this.cmdShowRuncharts.PopupWidth = 4000;
      this.cmdShowRuncharts.ShowSubItems = false;
      this.cmdShowRuncharts.Stretch = true;
      this.cmdShowRuncharts.Text = "Run Charts";
      this.cmdShowRegularcharts.Cursor = Cursors.Hand;
      this.cmdShowRegularcharts.GlobalItem = false;
      this.cmdShowRegularcharts.Name = "cmdShowRegularcharts";
      this.cmdShowRegularcharts.OptionGroup = "1";
      this.cmdShowRegularcharts.Text = "Regular Charts";
      this.cmdShowDataGrid.Cursor = Cursors.Hand;
      this.cmdShowDataGrid.GlobalItem = false;
      this.cmdShowDataGrid.Name = "cmdShowDataGrid";
      this.cmdShowDataGrid.OptionGroup = "1";
      this.cmdShowDataGrid.Text = "Data Grid";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.Name = nameof (ctrlComposite);
      size1 = new Size(586, 375);
      this.Size = size1;
      this.TableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual ButtonItem cmdShowRuncharts
    {
      [DebuggerNonUserCode] get => this._cmdShowRuncharts;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdShowRuncharts_Click);
        if (this._cmdShowRuncharts != null)
          this._cmdShowRuncharts.Click -= eventHandler;
        this._cmdShowRuncharts = value;
        if (this._cmdShowRuncharts == null)
          return;
        this._cmdShowRuncharts.Click += eventHandler;
      }
    }

    internal virtual ButtonItem cmdShowRegularcharts
    {
      [DebuggerNonUserCode] get => this._cmdShowRegularcharts;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdShowRegularcharts_Click);
        if (this._cmdShowRegularcharts != null)
          this._cmdShowRegularcharts.Click -= eventHandler;
        this._cmdShowRegularcharts = value;
        if (this._cmdShowRegularcharts == null)
          return;
        this._cmdShowRegularcharts.Click += eventHandler;
      }
    }

    internal virtual ButtonItem cmdShowDataGrid
    {
      [DebuggerNonUserCode] get => this._cmdShowDataGrid;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdShowDataGrid_Click);
        if (this._cmdShowDataGrid != null)
          this._cmdShowDataGrid.Click -= eventHandler;
        this._cmdShowDataGrid = value;
        if (this._cmdShowDataGrid == null)
          return;
        this._cmdShowDataGrid.Click += eventHandler;
      }
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    internal virtual ButtonX cmdDataSelect
    {
      [DebuggerNonUserCode] get => this._cmdDataSelect;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cmdDataSelect = value;
    }

    private bool _EnableRunCharts { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _EnableDataGrid { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _EnableRegularChart { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public ctrlComposite(
      DataTable History,
      bool EnableRunCharts,
      bool EnableDataGrid,
      bool EnableRegularChart)
    {
      this.Load += new EventHandler(this.ctrlComposit_Load);
      ctrlComposite.__ENCAddToList((object) this);
      this.dtHistory = new DataTable();
      this.InitializeComponent();
      this._EnableRunCharts = EnableRunCharts;
      this._EnableDataGrid = EnableDataGrid;
      this._EnableRegularChart = EnableRegularChart;
      this.dtHistory = History;
      this.cmdShowRuncharts.Visible = EnableRunCharts;
      this.cmdShowDataGrid.Visible = EnableDataGrid;
      this.cmdShowRegularcharts.Visible = EnableRegularChart;
    }

    private void ctrlComposit_Load(object sender, EventArgs e)
    {
      this.RunCharts = new ctrlRunCharts(this.dtHistory);
      this.DataGrid = new ctrlDataGrid(this.dtHistory);
      this.RegularCharts = new ctrlRegularCharts(this.dtHistory);
      this.SetVisibility(ctrlComposite.ControlNames.RunCharts);
    }

    private void cmdShowRuncharts_Click(object sender, EventArgs e) => this.SetVisibility(ctrlComposite.ControlNames.RunCharts);

    private void cmdShowDataGrid_Click(object sender, EventArgs e) => this.SetVisibility(ctrlComposite.ControlNames.DataGrid);

    private void cmdShowRegularcharts_Click(object sender, EventArgs e) => this.SetVisibility(ctrlComposite.ControlNames.RegularChart);

    private void SetVisibility(ctrlComposite.ControlNames ControlName)
    {
      this.TableLayoutPanel1.Controls.Remove((Control) this.DataGrid);
      this.TableLayoutPanel1.Controls.Remove((Control) this.RunCharts);
      this.TableLayoutPanel1.Controls.Remove((Control) this.RegularCharts);
      string str = (string) null;
      object Instance = (object) null;
      switch (ControlName)
      {
        case ctrlComposite.ControlNames.RunCharts:
          str = "Now Showing Run Charts";
          Instance = (object) this.RunCharts;
          break;
        case ctrlComposite.ControlNames.DataGrid:
          str = "Now Showing Data Grid";
          Instance = (object) this.DataGrid;
          break;
        case ctrlComposite.ControlNames.RegularChart:
          str = "Now Showing Regular Charts";
          Instance = (object) this.RegularCharts;
          break;
      }
      this.TableLayoutPanel1.Controls.Add((Control) Instance, 0, 1);
      this.TableLayoutPanel1.SetColumnSpan((Control) Instance, 2);
      NewLateBinding.LateSet(Instance, (System.Type) null, "Dock", new object[1]
      {
        (object) DockStyle.Fill
      }, (string[]) null, (System.Type[]) null);
      this.cmdDataSelect.Text = str;
    }

    private enum ControlNames
    {
      RunCharts,
      DataGrid,
      RegularChart,
    }

    internal class ChartData
    {
      [DebuggerNonUserCode]
      public ChartData()
      {
      }

      public long Indexer { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double XVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double YVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }
  }
}
