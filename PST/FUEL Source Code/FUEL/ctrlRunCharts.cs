// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlRunCharts
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.Editors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FUEL
{
  [DesignerGenerated]
  public class ctrlRunCharts : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("ToolTip1")]
    private System.Windows.Forms.ToolTip _ToolTip1;
    [AccessedThroughProperty("cboRunCharts")]
    private ComboBoxEx _cboRunCharts;
    [AccessedThroughProperty("lblHistory_TotalUnits")]
    private LabelX _lblHistory_TotalUnits;
    [AccessedThroughProperty("Chart1")]
    private Chart _Chart1;
    [AccessedThroughProperty("txtFilter1_val")]
    private TextBoxX _txtFilter1_val;
    [AccessedThroughProperty("cboFilter1")]
    private ComboBoxEx _cboFilter1;
    [AccessedThroughProperty("ItemPanel1")]
    private ItemPanel _ItemPanel1;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("txtFilters")]
    private TextBoxDropDown _txtFilters;
    [AccessedThroughProperty("cboFilter4")]
    private ComboBoxEx _cboFilter4;
    [AccessedThroughProperty("cboFilter2")]
    private ComboBoxEx _cboFilter2;
    [AccessedThroughProperty("cboFilter3")]
    private ComboBoxEx _cboFilter3;
    [AccessedThroughProperty("txtFilter2_val")]
    private TextBoxX _txtFilter2_val;
    [AccessedThroughProperty("txtFilter3_val")]
    private TextBoxX _txtFilter3_val;
    [AccessedThroughProperty("txtFilter4_val")]
    private TextBoxX _txtFilter4_val;
    [AccessedThroughProperty("cmdFilter_Apply")]
    private ButtonX _cmdFilter_Apply;
    [AccessedThroughProperty("cmdFilter_Cancel")]
    private ButtonX _cmdFilter_Cancel;
    [AccessedThroughProperty("intUnitsPerGroup")]
    private IntegerInput _intUnitsPerGroup;
    [AccessedThroughProperty("lblUnitesPerGroup")]
    private LabelX _lblUnitesPerGroup;
    [AccessedThroughProperty("chkGrpBySerial")]
    private CheckBoxX _chkGrpBySerial;
    [AccessedThroughProperty("chkDisplayDataLabels")]
    private CheckBoxX _chkDisplayDataLabels;
    [AccessedThroughProperty("expOptions")]
    private ExpandablePanel _expOptions;
    [AccessedThroughProperty("StyleManager1")]
    private StyleManager _StyleManager1;
    [AccessedThroughProperty("cboOper1")]
    private ComboBoxEx _cboOper1;
    [AccessedThroughProperty("ComboItem1")]
    private ComboItem _ComboItem1;
    [AccessedThroughProperty("ComboItem2")]
    private ComboItem _ComboItem2;
    [AccessedThroughProperty("ComboItem3")]
    private ComboItem _ComboItem3;
    [AccessedThroughProperty("ComboItem4")]
    private ComboItem _ComboItem4;
    [AccessedThroughProperty("ComboItem5")]
    private ComboItem _ComboItem5;
    [AccessedThroughProperty("ComboItem6")]
    private ComboItem _ComboItem6;
    [AccessedThroughProperty("cboOper4")]
    private ComboBoxEx _cboOper4;
    [AccessedThroughProperty("ComboItem19")]
    private ComboItem _ComboItem19;
    [AccessedThroughProperty("ComboItem20")]
    private ComboItem _ComboItem20;
    [AccessedThroughProperty("ComboItem21")]
    private ComboItem _ComboItem21;
    [AccessedThroughProperty("ComboItem22")]
    private ComboItem _ComboItem22;
    [AccessedThroughProperty("ComboItem23")]
    private ComboItem _ComboItem23;
    [AccessedThroughProperty("ComboItem24")]
    private ComboItem _ComboItem24;
    [AccessedThroughProperty("cboOper3")]
    private ComboBoxEx _cboOper3;
    [AccessedThroughProperty("ComboItem13")]
    private ComboItem _ComboItem13;
    [AccessedThroughProperty("ComboItem14")]
    private ComboItem _ComboItem14;
    [AccessedThroughProperty("ComboItem15")]
    private ComboItem _ComboItem15;
    [AccessedThroughProperty("ComboItem16")]
    private ComboItem _ComboItem16;
    [AccessedThroughProperty("ComboItem17")]
    private ComboItem _ComboItem17;
    [AccessedThroughProperty("ComboItem18")]
    private ComboItem _ComboItem18;
    [AccessedThroughProperty("cboOper2")]
    private ComboBoxEx _cboOper2;
    [AccessedThroughProperty("ComboItem7")]
    private ComboItem _ComboItem7;
    [AccessedThroughProperty("ComboItem8")]
    private ComboItem _ComboItem8;
    [AccessedThroughProperty("ComboItem9")]
    private ComboItem _ComboItem9;
    [AccessedThroughProperty("ComboItem10")]
    private ComboItem _ComboItem10;
    [AccessedThroughProperty("ComboItem11")]
    private ComboItem _ComboItem11;
    [AccessedThroughProperty("ComboItem12")]
    private ComboItem _ComboItem12;
    private bool InitializeComplete;

    [DebuggerNonUserCode]
    static ctrlRunCharts()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlRunCharts.__ENCList)
      {
        if (ctrlRunCharts.__ENCList.Count == ctrlRunCharts.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlRunCharts.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlRunCharts.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlRunCharts.__ENCList[index1] = ctrlRunCharts.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlRunCharts.__ENCList.RemoveRange(index1, checked (ctrlRunCharts.__ENCList.Count - index1));
          ctrlRunCharts.__ENCList.Capacity = ctrlRunCharts.__ENCList.Count;
        }
        ctrlRunCharts.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      ChartArea chartArea1 = new ChartArea();
      ChartArea chartArea2 = new ChartArea();
      Legend legend = new Legend();
      Series series = new Series();
      this.Chart1 = new Chart();
      this.cboRunCharts = new ComboBoxEx();
      this.lblHistory_TotalUnits = new LabelX();
      this.txtFilter1_val = new TextBoxX();
      this.cboFilter1 = new ComboBoxEx();
      this.ItemPanel1 = new ItemPanel();
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.cboFilter4 = new ComboBoxEx();
      this.cboFilter2 = new ComboBoxEx();
      this.cboFilter3 = new ComboBoxEx();
      this.txtFilter2_val = new TextBoxX();
      this.txtFilter3_val = new TextBoxX();
      this.txtFilter4_val = new TextBoxX();
      this.cmdFilter_Apply = new ButtonX();
      this.cmdFilter_Cancel = new ButtonX();
      this.txtFilters = new TextBoxDropDown();
      this.intUnitsPerGroup = new IntegerInput();
      this.lblUnitesPerGroup = new LabelX();
      this.chkGrpBySerial = new CheckBoxX();
      this.chkDisplayDataLabels = new CheckBoxX();
      this.expOptions = new ExpandablePanel();
      this.StyleManager1 = new StyleManager(this.components);
      this.cboOper1 = new ComboBoxEx();
      this.ComboItem1 = new ComboItem();
      this.ComboItem2 = new ComboItem();
      this.ComboItem3 = new ComboItem();
      this.ComboItem4 = new ComboItem();
      this.ComboItem5 = new ComboItem();
      this.ComboItem6 = new ComboItem();
      this.cboOper2 = new ComboBoxEx();
      this.ComboItem7 = new ComboItem();
      this.ComboItem8 = new ComboItem();
      this.ComboItem9 = new ComboItem();
      this.ComboItem10 = new ComboItem();
      this.ComboItem11 = new ComboItem();
      this.ComboItem12 = new ComboItem();
      this.cboOper3 = new ComboBoxEx();
      this.ComboItem13 = new ComboItem();
      this.ComboItem14 = new ComboItem();
      this.ComboItem15 = new ComboItem();
      this.ComboItem16 = new ComboItem();
      this.ComboItem17 = new ComboItem();
      this.ComboItem18 = new ComboItem();
      this.cboOper4 = new ComboBoxEx();
      this.ComboItem19 = new ComboItem();
      this.ComboItem20 = new ComboItem();
      this.ComboItem21 = new ComboItem();
      this.ComboItem22 = new ComboItem();
      this.ComboItem23 = new ComboItem();
      this.ComboItem24 = new ComboItem();
      this.Chart1.BeginInit();
      this.ItemPanel1.SuspendLayout();
      this.TableLayoutPanel1.SuspendLayout();
      this.intUnitsPerGroup.BeginInit();
      this.expOptions.SuspendLayout();
      this.SuspendLayout();
      this.Chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Chart1.BorderlineColor = Color.DarkRed;
      this.Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
      this.Chart1.BorderlineWidth = 2;
      chartArea1.Name = "ChartArea1";
      chartArea2.Name = "ChartArea2";
      this.Chart1.ChartAreas.Add(chartArea1);
      this.Chart1.ChartAreas.Add(chartArea2);
      legend.Name = "Legend1";
      this.Chart1.Legends.Add(legend);
      Chart chart1_1 = this.Chart1;
      Point point1 = new Point(3, 31);
      Point point2 = point1;
      chart1_1.Location = point2;
      this.Chart1.Name = "Chart1";
      series.ChartArea = "ChartArea1";
      series.Legend = "Legend1";
      series.Name = "Series1";
      this.Chart1.Series.Add(series);
      Chart chart1_2 = this.Chart1;
      Size size1 = new Size(932, 325);
      Size size2 = size1;
      chart1_2.Size = size2;
      this.Chart1.TabIndex = 9;
      this.Chart1.Text = "Chart1";
      this.cboRunCharts.DisplayMember = "Text";
      this.cboRunCharts.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboRunCharts.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRunCharts.ForeColor = Color.Black;
      this.cboRunCharts.FormattingEnabled = true;
      this.cboRunCharts.ItemHeight = 16;
      ComboBoxEx cboRunCharts1 = this.cboRunCharts;
      point1 = new Point(3, 3);
      Point point3 = point1;
      cboRunCharts1.Location = point3;
      this.cboRunCharts.Name = "cboRunCharts";
      ComboBoxEx cboRunCharts2 = this.cboRunCharts;
      size1 = new Size(201, 22);
      Size size3 = size1;
      cboRunCharts2.Size = size3;
      this.cboRunCharts.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboRunCharts.TabIndex = 16;
      this.cboRunCharts.WatermarkText = "Select a Metric";
      this.lblHistory_TotalUnits.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX historyTotalUnits1 = this.lblHistory_TotalUnits;
      point1 = new Point(210, 3);
      Point point4 = point1;
      historyTotalUnits1.Location = point4;
      this.lblHistory_TotalUnits.Name = "lblHistory_TotalUnits";
      LabelX historyTotalUnits2 = this.lblHistory_TotalUnits;
      size1 = new Size(159, 23);
      Size size4 = size1;
      historyTotalUnits2.Size = size4;
      this.lblHistory_TotalUnits.TabIndex = 17;
      this.txtFilter1_val.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.txtFilter1_val.Border.Class = "TextBoxBorder";
      this.txtFilter1_val.Border.CornerType = eCornerType.Square;
      this.txtFilter1_val.ForeColor = Color.Black;
      TextBoxX txtFilter1Val1 = this.txtFilter1_val;
      point1 = new Point(190, 3);
      Point point5 = point1;
      txtFilter1Val1.Location = point5;
      this.txtFilter1_val.Name = "txtFilter1_val";
      TextBoxX txtFilter1Val2 = this.txtFilter1_val;
      size1 = new Size(90, 20);
      Size size5 = size1;
      txtFilter1Val2.Size = size5;
      this.txtFilter1_val.TabIndex = 19;
      this.cboFilter1.DisplayMember = "Text";
      this.cboFilter1.Dock = DockStyle.Top;
      this.cboFilter1.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboFilter1.FormattingEnabled = true;
      this.cboFilter1.ItemHeight = 14;
      ComboBoxEx cboFilter1_1 = this.cboFilter1;
      point1 = new Point(3, 3);
      Point point6 = point1;
      cboFilter1_1.Location = point6;
      this.cboFilter1.Name = "cboFilter1";
      ComboBoxEx cboFilter1_2 = this.cboFilter1;
      size1 = new Size(136, 20);
      Size size6 = size1;
      cboFilter1_2.Size = size6;
      this.cboFilter1.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboFilter1.TabIndex = 18;
      this.ItemPanel1.BackgroundStyle.Class = "ItemPanel";
      this.ItemPanel1.BackgroundStyle.CornerType = eCornerType.Square;
      this.ItemPanel1.ContainerControlProcessDialogKey = true;
      this.ItemPanel1.Controls.Add((Control) this.TableLayoutPanel1);
      this.ItemPanel1.LayoutOrientation = eOrientation.Vertical;
      this.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      ItemPanel itemPanel1_1 = this.ItemPanel1;
      point1 = new Point(375, 31);
      Point point7 = point1;
      itemPanel1_1.Location = point7;
      this.ItemPanel1.Name = "ItemPanel1";
      ItemPanel itemPanel1_2 = this.ItemPanel1;
      size1 = new Size(283, 145);
      Size size7 = size1;
      itemPanel1_2.Size = size7;
      this.ItemPanel1.TabIndex = 21;
      this.ItemPanel1.Text = "ItemPanel1";
      this.TableLayoutPanel1.ColumnCount = 3;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
      this.TableLayoutPanel1.Controls.Add((Control) this.cboOper4, 1, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboOper3, 1, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboOper2, 1, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboFilter4, 0, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboFilter1, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboFilter2, 0, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboFilter3, 0, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.cmdFilter_Apply, 0, 4);
      this.TableLayoutPanel1.Controls.Add((Control) this.txtFilter1_val, 2, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.txtFilter2_val, 2, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.txtFilter3_val, 2, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.txtFilter4_val, 2, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.cboOper1, 1, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.cmdFilter_Cancel, 2, 4);
      this.TableLayoutPanel1.Dock = DockStyle.Fill;
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      point1 = new Point(0, 0);
      Point point8 = point1;
      tableLayoutPanel1_1.Location = point8;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 5;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      size1 = new Size(283, 145);
      Size size8 = size1;
      tableLayoutPanel1_2.Size = size8;
      this.TableLayoutPanel1.TabIndex = 0;
      this.cboFilter4.DisplayMember = "Text";
      this.cboFilter4.Dock = DockStyle.Top;
      this.cboFilter4.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboFilter4.FormattingEnabled = true;
      this.cboFilter4.ItemHeight = 14;
      ComboBoxEx cboFilter4_1 = this.cboFilter4;
      point1 = new Point(3, 82);
      Point point9 = point1;
      cboFilter4_1.Location = point9;
      this.cboFilter4.Name = "cboFilter4";
      ComboBoxEx cboFilter4_2 = this.cboFilter4;
      size1 = new Size(136, 20);
      Size size9 = size1;
      cboFilter4_2.Size = size9;
      this.cboFilter4.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboFilter4.TabIndex = 22;
      this.cboFilter2.DisplayMember = "Text";
      this.cboFilter2.Dock = DockStyle.Top;
      this.cboFilter2.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboFilter2.FormattingEnabled = true;
      this.cboFilter2.ItemHeight = 14;
      ComboBoxEx cboFilter2_1 = this.cboFilter2;
      point1 = new Point(3, 30);
      Point point10 = point1;
      cboFilter2_1.Location = point10;
      this.cboFilter2.Name = "cboFilter2";
      ComboBoxEx cboFilter2_2 = this.cboFilter2;
      size1 = new Size(136, 20);
      Size size10 = size1;
      cboFilter2_2.Size = size10;
      this.cboFilter2.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboFilter2.TabIndex = 20;
      this.cboFilter3.DisplayMember = "Text";
      this.cboFilter3.Dock = DockStyle.Top;
      this.cboFilter3.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboFilter3.FormattingEnabled = true;
      this.cboFilter3.ItemHeight = 14;
      ComboBoxEx cboFilter3_1 = this.cboFilter3;
      point1 = new Point(3, 56);
      Point point11 = point1;
      cboFilter3_1.Location = point11;
      this.cboFilter3.Name = "cboFilter3";
      ComboBoxEx cboFilter3_2 = this.cboFilter3;
      size1 = new Size(136, 20);
      Size size11 = size1;
      cboFilter3_2.Size = size11;
      this.cboFilter3.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboFilter3.TabIndex = 21;
      this.txtFilter2_val.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.txtFilter2_val.Border.Class = "TextBoxBorder";
      this.txtFilter2_val.Border.CornerType = eCornerType.Square;
      this.txtFilter2_val.ForeColor = Color.Black;
      TextBoxX txtFilter2Val1 = this.txtFilter2_val;
      point1 = new Point(190, 30);
      Point point12 = point1;
      txtFilter2Val1.Location = point12;
      this.txtFilter2_val.Name = "txtFilter2_val";
      TextBoxX txtFilter2Val2 = this.txtFilter2_val;
      size1 = new Size(90, 20);
      Size size12 = size1;
      txtFilter2Val2.Size = size12;
      this.txtFilter2_val.TabIndex = 23;
      this.txtFilter3_val.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.txtFilter3_val.Border.Class = "TextBoxBorder";
      this.txtFilter3_val.Border.CornerType = eCornerType.Square;
      this.txtFilter3_val.ForeColor = Color.Black;
      TextBoxX txtFilter3Val1 = this.txtFilter3_val;
      point1 = new Point(190, 56);
      Point point13 = point1;
      txtFilter3Val1.Location = point13;
      this.txtFilter3_val.Name = "txtFilter3_val";
      TextBoxX txtFilter3Val2 = this.txtFilter3_val;
      size1 = new Size(90, 20);
      Size size13 = size1;
      txtFilter3Val2.Size = size13;
      this.txtFilter3_val.TabIndex = 24;
      this.txtFilter4_val.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.txtFilter4_val.Border.Class = "TextBoxBorder";
      this.txtFilter4_val.Border.CornerType = eCornerType.Square;
      this.txtFilter4_val.ForeColor = Color.Black;
      TextBoxX txtFilter4Val1 = this.txtFilter4_val;
      point1 = new Point(190, 82);
      Point point14 = point1;
      txtFilter4Val1.Location = point14;
      this.txtFilter4_val.Name = "txtFilter4_val";
      TextBoxX txtFilter4Val2 = this.txtFilter4_val;
      size1 = new Size(90, 20);
      Size size14 = size1;
      txtFilter4Val2.Size = size14;
      this.txtFilter4_val.TabIndex = 25;
      this.cmdFilter_Apply.AccessibleRole = AccessibleRole.PushButton;
      this.cmdFilter_Apply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cmdFilter_Apply.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX cmdFilterApply1 = this.cmdFilter_Apply;
      point1 = new Point(3, 119);
      Point point15 = point1;
      cmdFilterApply1.Location = point15;
      this.cmdFilter_Apply.Name = "cmdFilter_Apply";
      ButtonX cmdFilterApply2 = this.cmdFilter_Apply;
      size1 = new Size(88, 23);
      Size size15 = size1;
      cmdFilterApply2.Size = size15;
      this.cmdFilter_Apply.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdFilter_Apply.TabIndex = 26;
      this.cmdFilter_Apply.Text = "Apply";
      this.cmdFilter_Cancel.AccessibleRole = AccessibleRole.PushButton;
      this.cmdFilter_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdFilter_Cancel.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX cmdFilterCancel1 = this.cmdFilter_Cancel;
      point1 = new Point(192, 119);
      Point point16 = point1;
      cmdFilterCancel1.Location = point16;
      this.cmdFilter_Cancel.Name = "cmdFilter_Cancel";
      ButtonX cmdFilterCancel2 = this.cmdFilter_Cancel;
      size1 = new Size(88, 23);
      Size size16 = size1;
      cmdFilterCancel2.Size = size16;
      this.cmdFilter_Cancel.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdFilter_Cancel.TabIndex = 27;
      this.cmdFilter_Cancel.Text = "Cancel";
      this.txtFilters.BackgroundStyle.Class = "TextBoxBorder";
      this.txtFilters.BackgroundStyle.CornerType = eCornerType.Square;
      this.txtFilters.ButtonClear.Visible = true;
      this.txtFilters.ButtonDropDown.Visible = true;
      this.txtFilters.DropDownControl = (Control) this.ItemPanel1;
      TextBoxDropDown txtFilters1 = this.txtFilters;
      point1 = new Point(375, 3);
      Point point17 = point1;
      txtFilters1.Location = point17;
      this.txtFilters.Name = "txtFilters";
      this.txtFilters.ReadOnly = true;
      TextBoxDropDown txtFilters2 = this.txtFilters;
      size1 = new Size(283, 22);
      Size size17 = size1;
      txtFilters2.Size = size17;
      this.txtFilters.Style = eDotNetBarStyle.StyleManagerControlled;
      this.txtFilters.TabIndex = 22;
      this.txtFilters.Text = "";
      this.txtFilters.WatermarkText = "Filter Values";
      this.intUnitsPerGroup.BackgroundStyle.Class = "DateTimeInputBackground";
      this.intUnitsPerGroup.BackgroundStyle.CornerType = eCornerType.Square;
      this.intUnitsPerGroup.ButtonFreeText.Shortcut = eShortcut.F2;
      IntegerInput intUnitsPerGroup1 = this.intUnitsPerGroup;
      point1 = new Point(666, 4);
      Point point18 = point1;
      intUnitsPerGroup1.Location = point18;
      this.intUnitsPerGroup.MinValue = 1;
      this.intUnitsPerGroup.Name = "intUnitsPerGroup";
      this.intUnitsPerGroup.ShowUpDown = true;
      IntegerInput intUnitsPerGroup2 = this.intUnitsPerGroup;
      size1 = new Size(45, 20);
      Size size18 = size1;
      intUnitsPerGroup2.Size = size18;
      this.intUnitsPerGroup.TabIndex = 23;
      this.intUnitsPerGroup.Value = 4;
      this.lblUnitesPerGroup.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX lblUnitesPerGroup1 = this.lblUnitesPerGroup;
      point1 = new Point(717, 3);
      Point point19 = point1;
      lblUnitesPerGroup1.Location = point19;
      this.lblUnitesPerGroup.Name = "lblUnitesPerGroup";
      LabelX lblUnitesPerGroup2 = this.lblUnitesPerGroup;
      size1 = new Size(88, 23);
      Size size19 = size1;
      lblUnitesPerGroup2.Size = size19;
      this.lblUnitesPerGroup.TabIndex = 24;
      this.lblUnitesPerGroup.Text = "Units Per Group";
      this.chkGrpBySerial.BackColor = Color.Transparent;
      this.chkGrpBySerial.BackgroundStyle.CornerType = eCornerType.Square;
      CheckBoxX chkGrpBySerial1 = this.chkGrpBySerial;
      point1 = new Point(3, 58);
      Point point20 = point1;
      chkGrpBySerial1.Location = point20;
      this.chkGrpBySerial.Name = "chkGrpBySerial";
      CheckBoxX chkGrpBySerial2 = this.chkGrpBySerial;
      size1 = new Size(110, 23);
      Size size20 = size1;
      chkGrpBySerial2.Size = size20;
      this.chkGrpBySerial.Style = eDotNetBarStyle.StyleManagerControlled;
      this.chkGrpBySerial.TabIndex = 25;
      this.chkGrpBySerial.Text = "Group By Printer";
      this.chkDisplayDataLabels.BackColor = Color.Transparent;
      this.chkDisplayDataLabels.BackgroundStyle.CornerType = eCornerType.Square;
      this.chkDisplayDataLabels.Checked = true;
      this.chkDisplayDataLabels.CheckState = CheckState.Checked;
      this.chkDisplayDataLabels.CheckValue = (object) "Y";
      CheckBoxX displayDataLabels1 = this.chkDisplayDataLabels;
      point1 = new Point(3, 29);
      Point point21 = point1;
      displayDataLabels1.Location = point21;
      this.chkDisplayDataLabels.Name = "chkDisplayDataLabels";
      CheckBoxX displayDataLabels2 = this.chkDisplayDataLabels;
      size1 = new Size(132, 23);
      Size size21 = size1;
      displayDataLabels2.Size = size21;
      this.chkDisplayDataLabels.Style = eDotNetBarStyle.StyleManagerControlled;
      this.chkDisplayDataLabels.TabIndex = 26;
      this.chkDisplayDataLabels.Text = "Display Data Labels";
      this.expOptions.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.expOptions.Controls.Add((Control) this.chkDisplayDataLabels);
      this.expOptions.Controls.Add((Control) this.chkGrpBySerial);
      this.expOptions.ExpandButtonAlignment = eTitleButtonAlignment.Left;
      this.expOptions.ExpandOnTitleClick = true;
      ExpandablePanel expOptions1 = this.expOptions;
      point1 = new Point(811, 3);
      Point point22 = point1;
      expOptions1.Location = point22;
      this.expOptions.Name = "expOptions";
      ExpandablePanel expOptions2 = this.expOptions;
      size1 = new Size((int) sbyte.MaxValue, 90);
      Size size22 = size1;
      expOptions2.Size = size22;
      this.expOptions.Style.Alignment = StringAlignment.Center;
      this.expOptions.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
      this.expOptions.Style.Border = eBorderType.SingleLine;
      this.expOptions.Style.BorderColor.Color = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.expOptions.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText;
      this.expOptions.Style.GradientAngle = 90;
      this.expOptions.StyleMouseDown.Alignment = StringAlignment.Center;
      this.expOptions.StyleMouseDown.BorderColor.ColorSchemePart = eColorSchemePart.ItemPressedBorder;
      this.expOptions.StyleMouseDown.ForeColor.ColorSchemePart = eColorSchemePart.ItemPressedText;
      this.expOptions.StyleMouseOver.Alignment = StringAlignment.Center;
      this.expOptions.StyleMouseOver.BorderColor.ColorSchemePart = eColorSchemePart.ItemHotBorder;
      this.expOptions.StyleMouseOver.ForeColor.ColorSchemePart = eColorSchemePart.ItemHotText;
      this.expOptions.TabIndex = 28;
      this.expOptions.TitleStyle.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground;
      this.expOptions.TitleStyle.Border = eBorderType.RaisedInner;
      this.expOptions.TitleStyle.ForeColor.ColorSchemePart = eColorSchemePart.PanelText;
      this.expOptions.TitleStyle.GradientAngle = 90;
      this.expOptions.TitleStyleMouseDown.Border = eBorderType.SingleLine;
      this.expOptions.TitleStyleMouseDown.BorderColor.Color = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.expOptions.TitleStyleMouseOver.BackColor1.Color = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.expOptions.TitleText = "Options";
      this.StyleManager1.ManagerStyle = eStyle.Metro;
      this.StyleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Color.FromArgb(237, 142, 0));
      this.cboOper1.DisplayMember = "Text";
      this.cboOper1.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboOper1.FormattingEnabled = true;
      this.cboOper1.ItemHeight = 14;
      this.cboOper1.Items.AddRange(new object[6]
      {
        (object) this.ComboItem1,
        (object) this.ComboItem2,
        (object) this.ComboItem3,
        (object) this.ComboItem4,
        (object) this.ComboItem5,
        (object) this.ComboItem6
      });
      ComboBoxEx cboOper1_1 = this.cboOper1;
      point1 = new Point(145, 3);
      Point point23 = point1;
      cboOper1_1.Location = point23;
      this.cboOper1.Name = "cboOper1";
      ComboBoxEx cboOper1_2 = this.cboOper1;
      size1 = new Size(39, 20);
      Size size23 = size1;
      cboOper1_2.Size = size23;
      this.cboOper1.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboOper1.TabIndex = 28;
      this.cboOper1.Text = "=";
      this.ComboItem1.Text = "=";
      this.ComboItem2.Text = "<";
      this.ComboItem3.Text = "<=";
      this.ComboItem4.Text = ">";
      this.ComboItem5.Text = ">=";
      this.ComboItem6.Text = "<>";
      this.cboOper2.DisplayMember = "Text";
      this.cboOper2.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboOper2.FormattingEnabled = true;
      this.cboOper2.ItemHeight = 14;
      this.cboOper2.Items.AddRange(new object[6]
      {
        (object) this.ComboItem7,
        (object) this.ComboItem8,
        (object) this.ComboItem9,
        (object) this.ComboItem10,
        (object) this.ComboItem11,
        (object) this.ComboItem12
      });
      ComboBoxEx cboOper2_1 = this.cboOper2;
      point1 = new Point(145, 30);
      Point point24 = point1;
      cboOper2_1.Location = point24;
      this.cboOper2.Name = "cboOper2";
      ComboBoxEx cboOper2_2 = this.cboOper2;
      size1 = new Size(39, 20);
      Size size24 = size1;
      cboOper2_2.Size = size24;
      this.cboOper2.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboOper2.TabIndex = 29;
      this.cboOper2.Text = "=";
      this.ComboItem7.Text = "=";
      this.ComboItem8.Text = "<";
      this.ComboItem9.Text = "<=";
      this.ComboItem10.Text = ">";
      this.ComboItem11.Text = ">=";
      this.ComboItem12.Text = "<>";
      this.cboOper3.DisplayMember = "Text";
      this.cboOper3.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboOper3.FormattingEnabled = true;
      this.cboOper3.ItemHeight = 14;
      this.cboOper3.Items.AddRange(new object[6]
      {
        (object) this.ComboItem13,
        (object) this.ComboItem14,
        (object) this.ComboItem15,
        (object) this.ComboItem16,
        (object) this.ComboItem17,
        (object) this.ComboItem18
      });
      ComboBoxEx cboOper3_1 = this.cboOper3;
      point1 = new Point(145, 56);
      Point point25 = point1;
      cboOper3_1.Location = point25;
      this.cboOper3.Name = "cboOper3";
      ComboBoxEx cboOper3_2 = this.cboOper3;
      size1 = new Size(39, 20);
      Size size25 = size1;
      cboOper3_2.Size = size25;
      this.cboOper3.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboOper3.TabIndex = 30;
      this.cboOper3.Text = "=";
      this.ComboItem13.Text = "=";
      this.ComboItem14.Text = "<";
      this.ComboItem15.Text = "<=";
      this.ComboItem16.Text = ">";
      this.ComboItem17.Text = ">=";
      this.ComboItem18.Text = "<>";
      this.cboOper4.DisplayMember = "Text";
      this.cboOper4.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboOper4.FormattingEnabled = true;
      this.cboOper4.ItemHeight = 14;
      this.cboOper4.Items.AddRange(new object[6]
      {
        (object) this.ComboItem19,
        (object) this.ComboItem20,
        (object) this.ComboItem21,
        (object) this.ComboItem22,
        (object) this.ComboItem23,
        (object) this.ComboItem24
      });
      ComboBoxEx cboOper4_1 = this.cboOper4;
      point1 = new Point(145, 82);
      Point point26 = point1;
      cboOper4_1.Location = point26;
      this.cboOper4.Name = "cboOper4";
      ComboBoxEx cboOper4_2 = this.cboOper4;
      size1 = new Size(39, 20);
      Size size26 = size1;
      cboOper4_2.Size = size26;
      this.cboOper4.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboOper4.TabIndex = 31;
      this.cboOper4.Text = "=";
      this.ComboItem19.Text = "=";
      this.ComboItem20.Text = "<";
      this.ComboItem21.Text = "<=";
      this.ComboItem22.Text = ">";
      this.ComboItem23.Text = ">=";
      this.ComboItem24.Text = "<>";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.expOptions);
      this.Controls.Add((Control) this.lblUnitesPerGroup);
      this.Controls.Add((Control) this.intUnitsPerGroup);
      this.Controls.Add((Control) this.txtFilters);
      this.Controls.Add((Control) this.ItemPanel1);
      this.Controls.Add((Control) this.lblHistory_TotalUnits);
      this.Controls.Add((Control) this.cboRunCharts);
      this.Controls.Add((Control) this.Chart1);
      this.Name = nameof (ctrlRunCharts);
      size1 = new Size(938, 356);
      this.Size = size1;
      this.Chart1.EndInit();
      this.ItemPanel1.ResumeLayout(false);
      this.TableLayoutPanel1.ResumeLayout(false);
      this.intUnitsPerGroup.EndInit();
      this.expOptions.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual System.Windows.Forms.ToolTip ToolTip1
    {
      [DebuggerNonUserCode] get => this._ToolTip1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ToolTip1 = value;
    }

    internal virtual ComboBoxEx cboRunCharts
    {
      [DebuggerNonUserCode] get => this._cboRunCharts;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboRunCharts_SelectedIndexChanged);
        if (this._cboRunCharts != null)
          this._cboRunCharts.SelectedIndexChanged -= eventHandler;
        this._cboRunCharts = value;
        if (this._cboRunCharts == null)
          return;
        this._cboRunCharts.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual LabelX lblHistory_TotalUnits
    {
      [DebuggerNonUserCode] get => this._lblHistory_TotalUnits;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHistory_TotalUnits = value;
    }

    private virtual Chart Chart1
    {
      [DebuggerNonUserCode] get => this._Chart1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart1 = value;
    }

    internal virtual TextBoxX txtFilter1_val
    {
      [DebuggerNonUserCode] get => this._txtFilter1_val;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._txtFilter1_val = value;
    }

    internal virtual ComboBoxEx cboFilter1
    {
      [DebuggerNonUserCode] get => this._cboFilter1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboFilter1 = value;
    }

    internal virtual ItemPanel ItemPanel1
    {
      [DebuggerNonUserCode] get => this._ItemPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ItemPanel1 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    internal virtual TextBoxDropDown txtFilters
    {
      [DebuggerNonUserCode] get => this._txtFilters;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.txtFilters_ButtonClearClick);
        EventHandler eventHandler = new EventHandler(this.txtFilters_TextChanged);
        if (this._txtFilters != null)
        {
          this._txtFilters.ButtonClearClick -= cancelEventHandler;
          this._txtFilters.TextChanged -= eventHandler;
        }
        this._txtFilters = value;
        if (this._txtFilters == null)
          return;
        this._txtFilters.ButtonClearClick += cancelEventHandler;
        this._txtFilters.TextChanged += eventHandler;
      }
    }

    internal virtual ComboBoxEx cboFilter4
    {
      [DebuggerNonUserCode] get => this._cboFilter4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboFilter4 = value;
    }

    internal virtual ComboBoxEx cboFilter2
    {
      [DebuggerNonUserCode] get => this._cboFilter2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboFilter2 = value;
    }

    internal virtual ComboBoxEx cboFilter3
    {
      [DebuggerNonUserCode] get => this._cboFilter3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboFilter3 = value;
    }

    internal virtual TextBoxX txtFilter2_val
    {
      [DebuggerNonUserCode] get => this._txtFilter2_val;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._txtFilter2_val = value;
    }

    internal virtual TextBoxX txtFilter3_val
    {
      [DebuggerNonUserCode] get => this._txtFilter3_val;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._txtFilter3_val = value;
    }

    internal virtual TextBoxX txtFilter4_val
    {
      [DebuggerNonUserCode] get => this._txtFilter4_val;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._txtFilter4_val = value;
    }

    internal virtual ButtonX cmdFilter_Apply
    {
      [DebuggerNonUserCode] get => this._cmdFilter_Apply;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdFilter_Apply_Click);
        if (this._cmdFilter_Apply != null)
          this._cmdFilter_Apply.Click -= eventHandler;
        this._cmdFilter_Apply = value;
        if (this._cmdFilter_Apply == null)
          return;
        this._cmdFilter_Apply.Click += eventHandler;
      }
    }

    internal virtual ButtonX cmdFilter_Cancel
    {
      [DebuggerNonUserCode] get => this._cmdFilter_Cancel;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdFilter_Cancel_Click);
        if (this._cmdFilter_Cancel != null)
          this._cmdFilter_Cancel.Click -= eventHandler;
        this._cmdFilter_Cancel = value;
        if (this._cmdFilter_Cancel == null)
          return;
        this._cmdFilter_Cancel.Click += eventHandler;
      }
    }

    internal virtual IntegerInput intUnitsPerGroup
    {
      [DebuggerNonUserCode] get => this._intUnitsPerGroup;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.intUnitsPerGroup_ValueChanged);
        if (this._intUnitsPerGroup != null)
          this._intUnitsPerGroup.ValueChanged -= eventHandler;
        this._intUnitsPerGroup = value;
        if (this._intUnitsPerGroup == null)
          return;
        this._intUnitsPerGroup.ValueChanged += eventHandler;
      }
    }

    internal virtual LabelX lblUnitesPerGroup
    {
      [DebuggerNonUserCode] get => this._lblUnitesPerGroup;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblUnitesPerGroup = value;
    }

    internal virtual CheckBoxX chkGrpBySerial
    {
      [DebuggerNonUserCode] get => this._chkGrpBySerial;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkGrpBySerial_CheckedChanged);
        if (this._chkGrpBySerial != null)
          this._chkGrpBySerial.CheckedChanged -= eventHandler;
        this._chkGrpBySerial = value;
        if (this._chkGrpBySerial == null)
          return;
        this._chkGrpBySerial.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBoxX chkDisplayDataLabels
    {
      [DebuggerNonUserCode] get => this._chkDisplayDataLabels;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDisplayDataLabels_CheckedChanged);
        if (this._chkDisplayDataLabels != null)
          this._chkDisplayDataLabels.CheckedChanged -= eventHandler;
        this._chkDisplayDataLabels = value;
        if (this._chkDisplayDataLabels == null)
          return;
        this._chkDisplayDataLabels.CheckedChanged += eventHandler;
      }
    }

    internal virtual ExpandablePanel expOptions
    {
      [DebuggerNonUserCode] get => this._expOptions;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._expOptions = value;
    }

    internal virtual StyleManager StyleManager1
    {
      [DebuggerNonUserCode] get => this._StyleManager1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._StyleManager1 = value;
    }

    internal virtual ComboBoxEx cboOper1
    {
      [DebuggerNonUserCode] get => this._cboOper1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboOper1 = value;
    }

    internal virtual ComboItem ComboItem1
    {
      [DebuggerNonUserCode] get => this._ComboItem1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem1 = value;
    }

    internal virtual ComboItem ComboItem2
    {
      [DebuggerNonUserCode] get => this._ComboItem2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem2 = value;
    }

    internal virtual ComboItem ComboItem3
    {
      [DebuggerNonUserCode] get => this._ComboItem3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem3 = value;
    }

    internal virtual ComboItem ComboItem4
    {
      [DebuggerNonUserCode] get => this._ComboItem4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem4 = value;
    }

    internal virtual ComboItem ComboItem5
    {
      [DebuggerNonUserCode] get => this._ComboItem5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem5 = value;
    }

    internal virtual ComboItem ComboItem6
    {
      [DebuggerNonUserCode] get => this._ComboItem6;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem6 = value;
    }

    internal virtual ComboBoxEx cboOper4
    {
      [DebuggerNonUserCode] get => this._cboOper4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboOper4 = value;
    }

    internal virtual ComboItem ComboItem19
    {
      [DebuggerNonUserCode] get => this._ComboItem19;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem19 = value;
    }

    internal virtual ComboItem ComboItem20
    {
      [DebuggerNonUserCode] get => this._ComboItem20;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem20 = value;
    }

    internal virtual ComboItem ComboItem21
    {
      [DebuggerNonUserCode] get => this._ComboItem21;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem21 = value;
    }

    internal virtual ComboItem ComboItem22
    {
      [DebuggerNonUserCode] get => this._ComboItem22;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem22 = value;
    }

    internal virtual ComboItem ComboItem23
    {
      [DebuggerNonUserCode] get => this._ComboItem23;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem23 = value;
    }

    internal virtual ComboItem ComboItem24
    {
      [DebuggerNonUserCode] get => this._ComboItem24;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem24 = value;
    }

    internal virtual ComboBoxEx cboOper3
    {
      [DebuggerNonUserCode] get => this._cboOper3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboOper3 = value;
    }

    internal virtual ComboItem ComboItem13
    {
      [DebuggerNonUserCode] get => this._ComboItem13;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem13 = value;
    }

    internal virtual ComboItem ComboItem14
    {
      [DebuggerNonUserCode] get => this._ComboItem14;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem14 = value;
    }

    internal virtual ComboItem ComboItem15
    {
      [DebuggerNonUserCode] get => this._ComboItem15;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem15 = value;
    }

    internal virtual ComboItem ComboItem16
    {
      [DebuggerNonUserCode] get => this._ComboItem16;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem16 = value;
    }

    internal virtual ComboItem ComboItem17
    {
      [DebuggerNonUserCode] get => this._ComboItem17;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem17 = value;
    }

    internal virtual ComboItem ComboItem18
    {
      [DebuggerNonUserCode] get => this._ComboItem18;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem18 = value;
    }

    internal virtual ComboBoxEx cboOper2
    {
      [DebuggerNonUserCode] get => this._cboOper2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboOper2 = value;
    }

    internal virtual ComboItem ComboItem7
    {
      [DebuggerNonUserCode] get => this._ComboItem7;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem7 = value;
    }

    internal virtual ComboItem ComboItem8
    {
      [DebuggerNonUserCode] get => this._ComboItem8;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem8 = value;
    }

    internal virtual ComboItem ComboItem9
    {
      [DebuggerNonUserCode] get => this._ComboItem9;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem9 = value;
    }

    internal virtual ComboItem ComboItem10
    {
      [DebuggerNonUserCode] get => this._ComboItem10;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem10 = value;
    }

    internal virtual ComboItem ComboItem11
    {
      [DebuggerNonUserCode] get => this._ComboItem11;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem11 = value;
    }

    internal virtual ComboItem ComboItem12
    {
      [DebuggerNonUserCode] get => this._ComboItem12;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ComboItem12 = value;
    }

    private string _CurrentMetric { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private DataTable _dtHistory { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private DataView _dvHistory { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    internal string CurrentMetric => this._CurrentMetric;

    public ctrlRunCharts(DataTable dtHistory)
    {
      ctrlRunCharts.__ENCAddToList((object) this);
      this.InitializeComplete = false;
      this.InitializeComponent();
      this.InitializeComplete = true;
      this.expOptions.Expanded = false;
      this._dtHistory = dtHistory;
      this._dvHistory = new DataView(dtHistory);
      this.GetHeaders();
      this._CurrentMetric = !this._dtHistory.Columns.Contains("K_MAX_PRESSURE") ? (!this._dtHistory.Columns.Contains("K_MAX_PRESSURE_Val") ? (string) null : "K_MAX_PRESSURE_Val") : "K_MAX_PRESSURE";
      this.cboRunCharts.Text = this._CurrentMetric;
      this.AddHistoryData();
    }

    private void cboRunCharts_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._CurrentMetric = this.cboRunCharts.Text;
      this.AddHistoryData();
    }

    private void cmdFilter_Apply_Click(object sender, EventArgs e)
    {
      this.txtFilters.CloseDropDown();
      this.GetFilters();
    }

    private void cmdFilter_Cancel_Click(object sender, EventArgs e) => this.txtFilters.CloseDropDown();

    private void txtFilters_TextChanged(object sender, EventArgs e) => this.AddHistoryData();

    private void txtFilters_ButtonClearClick(object sender, CancelEventArgs e)
    {
      this.txtFilters.Text = (string) null;
      this.txtFilters.CloseDropDown();
      this.ClearFilters();
      this.AddHistoryData();
    }

    internal void AddHistoryData()
    {
      try
      {
        ChartUtilities.ClearChart(this.Chart1);
        List<ctrlRunCharts.HistoryData> dataSource1 = this.BuildHistoryDataList();
        if (dataSource1 != null)
        {
          if (Versioned.IsNumeric((object) dataSource1[0].RunChartYVal))
          {
            this.Chart1.Series.Add("KMax");
            Series series1 = this.Chart1.Series["KMax"];
            if (!this.chkGrpBySerial.Checked)
              series1.Points.DataBind((IEnumerable) dataSource1, "Indexer", "RunChartYVal", (string) null);
            else
              series1.Points.DataBind((IEnumerable) dataSource1, "Name", "RunChartYVal", (string) null);
            this.Chart1.Series["KMax"].Enabled = false;
            if (!this.chkGrpBySerial.Checked)
              this.Chart1.DataManipulator.Group("AVE", (double) this.intUnitsPerGroup.Value, IntervalType.Number, "KMax", "Ẋ");
            else
              this.Chart1.DataManipulator.GroupByAxisLabel("AVE", "KMax", "Ẋ");
            int num1 = 0;
            int num2 = checked (this.Chart1.Series["Ẋ"].Points.Count - 1);
            int index1 = 0;
            while (index1 <= num2)
            {
              this.Chart1.Series["Ẋ"].Points[index1].XValue = (double) num1;
              checked { ++num1; }
              checked { ++index1; }
            }
            if (!this.chkGrpBySerial.Checked)
              this.Chart1.DataManipulator.Group("HiLo", (double) this.intUnitsPerGroup.Value, IntervalType.Number, "KMax", "HiLo");
            else
              this.Chart1.DataManipulator.GroupByAxisLabel("HiLo", "KMax", "HiLo");
            this.Chart1.Series["HiLo"].Enabled = false;
            List<ctrlComposite.ChartData> dataSource2 = new List<ctrlComposite.ChartData>();
            long index2 = 0;
            try
            {
              foreach (DataPoint point in (Collection<DataPoint>) this.Chart1.Series["HiLo"].Points)
              {
                dataSource2.Add(new ctrlComposite.ChartData()
                {
                  YVal = this.Chart1.Series["HiLo"].Points[checked ((int) index2)].YValues[0] - this.Chart1.Series["HiLo"].Points[checked ((int) index2)].YValues[1],
                  Indexer = index2
                });
                checked { ++index2; }
              }
            }
            finally
            {
              IEnumerator<DataPoint> enumerator;
              enumerator?.Dispose();
            }
            this.Chart1.Series.Add("r");
            Series series2 = this.Chart1.Series["r"];
            series2.Points.DataBind((IEnumerable) dataSource2, "Indexer", "YVal", (string) null);
            series2.ChartArea = "ChartArea2";
            double IntervalOffset1 = this.Chart1.DataManipulator.Statistics.Mean("Ẋ");
            double IntervalOffset2 = this.Chart1.DataManipulator.Statistics.Mean("r");
            double num3 = IntervalOffset1 + 0.729 * IntervalOffset2;
            double IntervalOffset3 = IntervalOffset1 - 0.729 * IntervalOffset2;
            double num4 = IntervalOffset2 * 2.282;
            double IntervalOffset4 = IntervalOffset2 * 0.0;
            this.Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Control Limits: " + Math.Round(IntervalOffset1, 1).ToString() + " ±" + Math.Round(0.729 * IntervalOffset2, 1).ToString(), TextOrientation.Horizontal, StringAlignment.Far, StringAlignment.Far, Color.Black, IntervalOffset3, num3 - IntervalOffset3, Color.Orange));
            this.Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Ẍ = " + Conversions.ToString(Math.Round(IntervalOffset1, 2)), TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.Black, IntervalOffset1, Color.Red, 2));
            this.Chart1.ChartAreas["ChartArea2"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Far, StringAlignment.Far, Color.Black, IntervalOffset4, num4 - IntervalOffset4, Color.Orange));
            this.Chart1.ChartAreas["ChartArea2"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Ṙ = " + Conversions.ToString(Math.Round(IntervalOffset2, 2)), TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.Black, IntervalOffset2, Color.Red, 2));
            ChartUtilities.AddChartTitle("Ẋ", this.Chart1, "ChartArea1", Docking.Top);
            ChartUtilities.AddChartTitle("Ṙ", this.Chart1, "ChartArea2", Docking.Top);
            this.Chart1.Legends[0].Enabled = false;
            this.Chart1.ChartAreas["ChartArea1"].AxisY.Title = this._CurrentMetric;
            this.Chart1.ChartAreas["ChartArea2"].AxisY.Title = this._CurrentMetric;
            this.Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Sample Group";
            this.Chart1.ChartAreas["ChartArea2"].AxisX.Title = "Sample Group";
            this.Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Math.Min(Math.Round(IntervalOffset3 - IntervalOffset3 * 0.1, 0), Math.Round(this.Chart1.Series["Ẋ"].Points.FindMinByValue().YValues[0] - this.Chart1.Series["Ẋ"].Points.FindMinByValue().YValues[0] * 0.1, 0));
            this.Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Math.Max(Math.Round(num3 + num3 * 0.1, 0), Math.Round(this.Chart1.Series["Ẋ"].Points.FindMaxByValue().YValues[0] + this.Chart1.Series["Ẋ"].Points.FindMaxByValue().YValues[0] * 0.1, 0));
            this.Chart1.ChartAreas["ChartArea2"].AxisY.Maximum = Math.Max(Math.Round(num4 + num4 * 0.1, 0), Math.Round(this.Chart1.Series["r"].Points.FindMaxByValue().YValues[0] + this.Chart1.Series["r"].Points.FindMaxByValue().YValues[0] * 0.1, 0));
            this.Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0.0;
            this.Chart1.ChartAreas["ChartArea2"].AxisX.Minimum = 0.0;
            Axis axisX1 = this.Chart1.ChartAreas["ChartArea1"].AxisX;
            axisX1.MajorGrid.Interval = (double) checked ((int) Math.Round(unchecked (0.2 * (double) this.Chart1.Series["Ẋ"].Points.Count)));
            axisX1.MajorTickMark.Interval = this.Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval;
            axisX1.Interval = this.Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval;
            axisX1.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4.0, checked ((int) Math.Round(this.Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval)));
            axisX1.MinorGrid.LineColor = Color.LightGray;
            axisX1.MinorGrid.Enabled = true;
            Axis axisX2 = this.Chart1.ChartAreas["ChartArea2"].AxisX;
            axisX2.MajorGrid.Interval = (double) checked ((int) Math.Round(unchecked (0.2 * (double) this.Chart1.Series["r"].Points.Count)));
            axisX2.MajorTickMark.Interval = this.Chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval;
            axisX2.Interval = this.Chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval;
            axisX2.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4.0, checked ((int) Math.Round(this.Chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval)));
            axisX2.MinorGrid.LineColor = Color.LightGray;
            axisX2.MinorGrid.Enabled = true;
            ChartUtilities.SetXAxisZoom(this.Chart1.ChartAreas[0], true);
            ChartUtilities.LinkChartAreas(this.Chart1.ChartAreas[0], this.Chart1.ChartAreas[1]);
            if (this.chkDisplayDataLabels.Checked)
            {
              ChartUtilities.AddSeriesDataLabels(this.Chart1, this.Chart1.Series["Ẋ"]);
              ChartUtilities.AddSeriesDataLabels(this.Chart1, this.Chart1.Series["r"]);
            }
            int num5 = checked (this.Chart1.Series.Count - 1);
            int index3 = 0;
            while (index3 <= num5)
            {
              Series series3 = this.Chart1.Series[index3];
              series3.ChartType = SeriesChartType.Line;
              series3.BorderWidth = 1;
              series3.Color = Color.Blue;
              series3.MarkerStyle = MarkerStyle.Circle;
              series3.MarkerSize = 6;
              series3.MarkerColor = Color.Blue;
              checked { ++index3; }
            }
            this.lblHistory_TotalUnits.Text = "Total Units in History: " + Conversions.ToString(this.Chart1.Series["KMax"].Points.Count);
          }
          else
          {
            int num6 = (int) MessageBox.Show("Invalid non-numeric value selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._CurrentMetric, (string) null, false) == 0)
            return;
          int num7 = (int) MessageBox.Show("No data to display", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private List<ctrlRunCharts.HistoryData> BuildHistoryDataList()
    {
      List<ctrlRunCharts.HistoryData> historyDataList1;
      try
      {
        this._dvHistory.RowFilter = this.txtFilters.Text;
        if (this._dvHistory.Count > 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._CurrentMetric, (string) null, false) != 0)
        {
          List<ctrlRunCharts.HistoryData> historyDataList2 = new List<ctrlRunCharts.HistoryData>();
          int num1 = 0;
          int num2 = checked (this._dvHistory.Count - 1);
          int recordIndex = 0;
          while (recordIndex <= num2)
          {
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this._dvHistory[recordIndex][this.CurrentMetric])))
            {
              if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(this._dvHistory[recordIndex][this.CurrentMetric])))
              {
                historyDataList2.Add(new ctrlRunCharts.HistoryData()
                {
                  Indexer = num1,
                  Name = Conversions.ToString(this._dvHistory[recordIndex]["SERIAL_NUM"]),
                  RunChartYVal = Conversions.ToDouble(this._dvHistory[recordIndex][this.CurrentMetric])
                });
                checked { ++num1; }
              }
              else if (this._CurrentMetric.Contains("_Result"))
              {
                int num3 = (int) Interaction.MsgBox((object) "Metric names that end with '_Result' contain Boolean information that indicates if the units passed the specific test. This data is not numerical and thus cannot be added to a run chart\r\n\r\nI suggest that you select a metric whose name ends with '_Val'.");
                historyDataList1 = (List<ctrlRunCharts.HistoryData>) null;
                goto label_14;
              }
              else
              {
                int num4 = (int) Interaction.MsgBox((object) "Non-Numeric data detected, Please select a metric that contains numerical data.");
                historyDataList1 = (List<ctrlRunCharts.HistoryData>) null;
                goto label_14;
              }
            }
            checked { ++recordIndex; }
          }
          historyDataList1 = historyDataList2;
        }
        else
          historyDataList1 = (List<ctrlRunCharts.HistoryData>) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        historyDataList1 = (List<ctrlRunCharts.HistoryData>) null;
        ProjectData.ClearProjectError();
      }
label_14:
      return historyDataList1;
    }

    private void GetHeaders()
    {
      try
      {
        foreach (DataColumn column in (InternalDataCollectionBase) this._dtHistory.Columns)
        {
          this.cboRunCharts.Items.Add((object) column.ColumnName);
          this.cboFilter1.Items.Add((object) column.ColumnName);
          this.cboFilter2.Items.Add((object) column.ColumnName);
          this.cboFilter3.Items.Add((object) column.ColumnName);
          this.cboFilter4.Items.Add((object) column.ColumnName);
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void GetFilters()
    {
      string str1 = (string) null;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboFilter1.Text, (string) null, false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFilter1_val.Text, (string) null, false) != 0)
      {
        string str2 = this.cboFilter1.Text;
        if (str2.Contains(" "))
          str2 = "[" + str2 + "]";
        str1 = str2 + " " + this.cboOper1.Text + " '" + this.txtFilter1_val.Text + "'";
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboFilter2.Text, (string) null, false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFilter2_val.Text, (string) null, false) != 0)
      {
        string Left = this.cboFilter2.Text;
        if (Left.Contains(" "))
          Left = "[" + Left + "]";
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, (string) null, false) == 0)
          str1 = Left + " = '" + this.txtFilter2_val.Text + "'";
        else
          str1 = str1 + " " + this.cboOper2.Text + " " + Left + " = '" + this.txtFilter2_val.Text + "'";
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboFilter3.Text, (string) null, false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFilter3_val.Text, (string) null, false) != 0)
      {
        string Left = this.cboFilter3.Text;
        if (Left.Contains(" "))
          Left = "[" + Left + "]";
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, (string) null, false) == 0)
          str1 = Left + " = '" + this.txtFilter3_val.Text + "'";
        else
          str1 = str1 + " " + this.cboOper3.Text + " " + Left + " = '" + this.txtFilter3_val.Text + "'";
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboFilter4.Text, (string) null, false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtFilter4_val.Text, (string) null, false) != 0)
      {
        string Left = this.cboFilter4.Text;
        if (Left.Contains(" "))
          Left = "[" + Left + "]";
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, (string) null, false) == 0)
          str1 = Left + " = '" + this.txtFilter4_val.Text + "'";
        else
          str1 = str1 + " " + this.cboOper4.Text + " " + Left + " = '" + this.txtFilter4_val.Text + "'";
      }
      this.txtFilters.Text = str1;
    }

    private void ClearFilters()
    {
      this.cboFilter1.Text = (string) null;
      this.cboFilter2.Text = (string) null;
      this.cboFilter3.Text = (string) null;
      this.cboFilter4.Text = (string) null;
      this.txtFilter1_val.Text = (string) null;
      this.txtFilter2_val.Text = (string) null;
      this.txtFilter3_val.Text = (string) null;
      this.txtFilter4_val.Text = (string) null;
    }

    private void intUnitsPerGroup_ValueChanged(object sender, EventArgs e) => this.AddHistoryData();

    private void chkGrpBySerial_CheckedChanged(object sender, EventArgs e)
    {
      if (this.InitializeComplete)
        this.expOptions.Expanded = false;
      this.intUnitsPerGroup.Enabled = !this.chkGrpBySerial.Checked;
      this.lblUnitesPerGroup.Enabled = !this.chkGrpBySerial.Checked;
      this.AddHistoryData();
    }

    private void chkDisplayDataLabels_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.InitializeComplete)
        return;
      this.expOptions.Expanded = false;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, (System.Type) null, "checked", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) true, false))
      {
        ChartUtilities.AddSeriesDataLabels(this.Chart1, this.Chart1.Series["Ẋ"]);
        ChartUtilities.AddSeriesDataLabels(this.Chart1, this.Chart1.Series["r"]);
      }
      else
      {
        ChartUtilities.RemoveSeriesDataLabels(this.Chart1, this.Chart1.Series["Ẋ"]);
        ChartUtilities.RemoveSeriesDataLabels(this.Chart1, this.Chart1.Series["r"]);
      }
    }

    private class HistoryData
    {
      [DebuggerNonUserCode]
      public HistoryData()
      {
      }

      public int Indexer { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string Name { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double RunChartYVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }
  }
}
