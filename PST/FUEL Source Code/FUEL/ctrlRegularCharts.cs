// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlRegularCharts
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
  public class ctrlRegularCharts : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("Chart1")]
    private Chart _Chart1;
    [AccessedThroughProperty("cboHistory_XVal")]
    private ComboBoxEx _cboHistory_XVal;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;
    [AccessedThroughProperty("LabelX2")]
    private LabelX _LabelX2;
    [AccessedThroughProperty("cboHistory_YVal")]
    private ComboBoxEx _cboHistory_YVal;
    [AccessedThroughProperty("LabelX3")]
    private LabelX _LabelX3;
    [AccessedThroughProperty("cboHistory_Series")]
    private ComboBoxEx _cboHistory_Series;
    [AccessedThroughProperty("cmdHistory_ChartIt")]
    private ButtonX _cmdHistory_ChartIt;

    [DebuggerNonUserCode]
    static ctrlRegularCharts()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlRegularCharts.__ENCList)
      {
        if (ctrlRegularCharts.__ENCList.Count == ctrlRegularCharts.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlRegularCharts.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlRegularCharts.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlRegularCharts.__ENCList[index1] = ctrlRegularCharts.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlRegularCharts.__ENCList.RemoveRange(index1, checked (ctrlRegularCharts.__ENCList.Count - index1));
          ctrlRegularCharts.__ENCList.Capacity = ctrlRegularCharts.__ENCList.Count;
        }
        ctrlRegularCharts.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      ChartArea chartArea = new ChartArea();
      Legend legend = new Legend();
      Series series = new Series();
      this.Chart1 = new Chart();
      this.cboHistory_XVal = new ComboBoxEx();
      this.LabelX1 = new LabelX();
      this.LabelX2 = new LabelX();
      this.cboHistory_YVal = new ComboBoxEx();
      this.LabelX3 = new LabelX();
      this.cboHistory_Series = new ComboBoxEx();
      this.cmdHistory_ChartIt = new ButtonX();
      this.Chart1.BeginInit();
      this.SuspendLayout();
      this.Chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Chart1.BorderlineColor = Color.Maroon;
      this.Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
      this.Chart1.BorderlineWidth = 2;
      chartArea.Name = "ChartArea1";
      this.Chart1.ChartAreas.Add(chartArea);
      legend.Name = "Legend1";
      this.Chart1.Legends.Add(legend);
      Chart chart1_1 = this.Chart1;
      Point point1 = new Point(3, 49);
      Point point2 = point1;
      chart1_1.Location = point2;
      this.Chart1.Name = "Chart1";
      series.ChartArea = "ChartArea1";
      series.Legend = "Legend1";
      series.Name = "Series1";
      this.Chart1.Series.Add(series);
      Chart chart1_2 = this.Chart1;
      Size size1 = new Size(474, 307);
      Size size2 = size1;
      chart1_2.Size = size2;
      this.Chart1.TabIndex = 25;
      this.Chart1.Text = "Chart1";
      this.cboHistory_XVal.DisplayMember = "Text";
      this.cboHistory_XVal.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_XVal.FormattingEnabled = true;
      this.cboHistory_XVal.ItemHeight = 14;
      ComboBoxEx cboHistoryXval1 = this.cboHistory_XVal;
      point1 = new Point(3, 23);
      Point point3 = point1;
      cboHistoryXval1.Location = point3;
      this.cboHistory_XVal.Name = "cboHistory_XVal";
      ComboBoxEx cboHistoryXval2 = this.cboHistory_XVal;
      size1 = new Size(121, 20);
      Size size3 = size1;
      cboHistoryXval2.Size = size3;
      this.cboHistory_XVal.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_XVal.TabIndex = 26;
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(4, 7);
      Point point4 = point1;
      labelX1_1.Location = point4;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(75, 13);
      Size size4 = size1;
      labelX1_2.Size = size4;
      this.LabelX1.TabIndex = 27;
      this.LabelX1.Text = "X Value";
      this.LabelX2.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX labelX2_1 = this.LabelX2;
      point1 = new Point(131, 7);
      Point point5 = point1;
      labelX2_1.Location = point5;
      this.LabelX2.Name = "LabelX2";
      LabelX labelX2_2 = this.LabelX2;
      size1 = new Size(75, 13);
      Size size5 = size1;
      labelX2_2.Size = size5;
      this.LabelX2.TabIndex = 29;
      this.LabelX2.Text = "Y Value";
      this.cboHistory_YVal.DisplayMember = "Text";
      this.cboHistory_YVal.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_YVal.FormattingEnabled = true;
      this.cboHistory_YVal.ItemHeight = 14;
      ComboBoxEx cboHistoryYval1 = this.cboHistory_YVal;
      point1 = new Point(130, 23);
      Point point6 = point1;
      cboHistoryYval1.Location = point6;
      this.cboHistory_YVal.Name = "cboHistory_YVal";
      ComboBoxEx cboHistoryYval2 = this.cboHistory_YVal;
      size1 = new Size(121, 20);
      Size size6 = size1;
      cboHistoryYval2.Size = size6;
      this.cboHistory_YVal.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_YVal.TabIndex = 28;
      this.LabelX3.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX labelX3_1 = this.LabelX3;
      point1 = new Point(258, 7);
      Point point7 = point1;
      labelX3_1.Location = point7;
      this.LabelX3.Name = "LabelX3";
      LabelX labelX3_2 = this.LabelX3;
      size1 = new Size(75, 13);
      Size size7 = size1;
      labelX3_2.Size = size7;
      this.LabelX3.TabIndex = 31;
      this.LabelX3.Text = "Series";
      this.cboHistory_Series.DisplayMember = "Text";
      this.cboHistory_Series.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_Series.FormattingEnabled = true;
      this.cboHistory_Series.ItemHeight = 14;
      ComboBoxEx cboHistorySeries1 = this.cboHistory_Series;
      point1 = new Point(257, 23);
      Point point8 = point1;
      cboHistorySeries1.Location = point8;
      this.cboHistory_Series.Name = "cboHistory_Series";
      ComboBoxEx cboHistorySeries2 = this.cboHistory_Series;
      size1 = new Size(121, 20);
      Size size8 = size1;
      cboHistorySeries2.Size = size8;
      this.cboHistory_Series.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_Series.TabIndex = 30;
      this.cmdHistory_ChartIt.AccessibleRole = AccessibleRole.PushButton;
      this.cmdHistory_ChartIt.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX cmdHistoryChartIt1 = this.cmdHistory_ChartIt;
      point1 = new Point(385, 18);
      Point point9 = point1;
      cmdHistoryChartIt1.Location = point9;
      this.cmdHistory_ChartIt.Name = "cmdHistory_ChartIt";
      ButtonX cmdHistoryChartIt2 = this.cmdHistory_ChartIt;
      size1 = new Size(75, 23);
      Size size9 = size1;
      cmdHistoryChartIt2.Size = size9;
      this.cmdHistory_ChartIt.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdHistory_ChartIt.TabIndex = 32;
      this.cmdHistory_ChartIt.Text = "Chart It";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.cmdHistory_ChartIt);
      this.Controls.Add((Control) this.LabelX3);
      this.Controls.Add((Control) this.cboHistory_Series);
      this.Controls.Add((Control) this.LabelX2);
      this.Controls.Add((Control) this.cboHistory_YVal);
      this.Controls.Add((Control) this.LabelX1);
      this.Controls.Add((Control) this.cboHistory_XVal);
      this.Controls.Add((Control) this.Chart1);
      this.Name = nameof (ctrlRegularCharts);
      size1 = new Size(480, 359);
      this.Size = size1;
      this.Chart1.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual Chart Chart1
    {
      [DebuggerNonUserCode] get => this._Chart1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart1 = value;
    }

    internal virtual ComboBoxEx cboHistory_XVal
    {
      [DebuggerNonUserCode] get => this._cboHistory_XVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_XVal = value;
    }

    internal virtual LabelX LabelX1
    {
      [DebuggerNonUserCode] get => this._LabelX1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX1 = value;
    }

    internal virtual LabelX LabelX2
    {
      [DebuggerNonUserCode] get => this._LabelX2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX2 = value;
    }

    internal virtual ComboBoxEx cboHistory_YVal
    {
      [DebuggerNonUserCode] get => this._cboHistory_YVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_YVal = value;
    }

    internal virtual LabelX LabelX3
    {
      [DebuggerNonUserCode] get => this._LabelX3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX3 = value;
    }

    internal virtual ComboBoxEx cboHistory_Series
    {
      [DebuggerNonUserCode] get => this._cboHistory_Series;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_Series = value;
    }

    internal virtual ButtonX cmdHistory_ChartIt
    {
      [DebuggerNonUserCode] get => this._cmdHistory_ChartIt;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdHistory_ChartIt_Click);
        if (this._cmdHistory_ChartIt != null)
          this._cmdHistory_ChartIt.Click -= eventHandler;
        this._cmdHistory_ChartIt = value;
        if (this._cmdHistory_ChartIt == null)
          return;
        this._cmdHistory_ChartIt.Click += eventHandler;
      }
    }

    private DataTable _dtHistory { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public ctrlRegularCharts(DataTable dtHistory)
    {
      ctrlRegularCharts.__ENCAddToList((object) this);
      this.InitializeComponent();
      this._dtHistory = dtHistory;
      this.GetHeaders();
    }

    private void cmdHistory_ChartIt_Click(object sender, EventArgs e) => this.AddHistoryData(this.cboHistory_XVal.Text, this.cboHistory_YVal.Text, this.cboHistory_Series.Text);

    private void AddHistoryData(string xVal, string yVal, string groupVal)
    {
      try
      {
        this.Chart1.Series.Clear();
        this.Chart1.DataBindCrossTable((IEnumerable) this._dtHistory.AsEnumerable(), groupVal, xVal, yVal, (string) null);
        try
        {
          foreach (Series series in (Collection<Series>) this.Chart1.Series)
          {
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 4;
          }
        }
        finally
        {
          IEnumerator<Series> enumerator;
          enumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void GetHeaders()
    {
      try
      {
        foreach (DataColumn column in (InternalDataCollectionBase) this._dtHistory.Columns)
        {
          this.cboHistory_XVal.Items.Add((object) column.ColumnName);
          this.cboHistory_YVal.Items.Add((object) column.ColumnName);
          this.cboHistory_Series.Items.Add((object) column.ColumnName);
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }
  }
}
