// Decompiled with JetBrains decompiler
// Type: FUEL.dlgPSTResults
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar.SuperGrid;
using FUEL.FS;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualBasic.MyServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FUEL
{
  [DesignerGenerated]
  public class dlgPSTResults : MetroForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("lblTitlePressure_K")]
    private LabelX _lblTitlePressure_K;
    [AccessedThroughProperty("GroupPanel1")]
    private GroupPanel _GroupPanel1;
    [AccessedThroughProperty("TableLayoutPanel2")]
    private TableLayoutPanel _TableLayoutPanel2;
    [AccessedThroughProperty("lblTitleLeak_K")]
    private LabelX _lblTitleLeak_K;
    [AccessedThroughProperty("lblTitleVent_K")]
    private LabelX _lblTitleVent_K;
    [AccessedThroughProperty("lblMeasPressure_K")]
    private LabelX _lblMeasPressure_K;
    [AccessedThroughProperty("lblTitlePressure_C")]
    private LabelX _lblTitlePressure_C;
    [AccessedThroughProperty("lblMeasLeak_K")]
    private LabelX _lblMeasLeak_K;
    [AccessedThroughProperty("lblTitleLeak_C")]
    private LabelX _lblTitleLeak_C;
    [AccessedThroughProperty("lblMeasVent_K")]
    private LabelX _lblMeasVent_K;
    [AccessedThroughProperty("lblTitleVent_C")]
    private LabelX _lblTitleVent_C;
    [AccessedThroughProperty("lblSpecPressure_K")]
    private LabelX _lblSpecPressure_K;
    [AccessedThroughProperty("lblSpecLeak_K")]
    private LabelX _lblSpecLeak_K;
    [AccessedThroughProperty("lblSpecVent_K")]
    private LabelX _lblSpecVent_K;
    [AccessedThroughProperty("LabelX10")]
    private LabelX _LabelX10;
    [AccessedThroughProperty("LabelX11")]
    private LabelX _LabelX11;
    [AccessedThroughProperty("LabelX12")]
    private LabelX _LabelX12;
    [AccessedThroughProperty("GroupPanel2")]
    private GroupPanel _GroupPanel2;
    [AccessedThroughProperty("TableLayoutPanel3")]
    private TableLayoutPanel _TableLayoutPanel3;
    [AccessedThroughProperty("lblMeasPressure_C")]
    private LabelX _lblMeasPressure_C;
    [AccessedThroughProperty("lblMeasLeak_C")]
    private LabelX _lblMeasLeak_C;
    [AccessedThroughProperty("lblMeasVent_C")]
    private LabelX _lblMeasVent_C;
    [AccessedThroughProperty("lblSpecPressure_C")]
    private LabelX _lblSpecPressure_C;
    [AccessedThroughProperty("lblSpecLeak_C")]
    private LabelX _lblSpecLeak_C;
    [AccessedThroughProperty("lblSpecVent_C")]
    private LabelX _lblSpecVent_C;
    [AccessedThroughProperty("LabelX16")]
    private LabelX _LabelX16;
    [AccessedThroughProperty("LabelX17")]
    private LabelX _LabelX17;
    [AccessedThroughProperty("LabelX18")]
    private LabelX _LabelX18;
    [AccessedThroughProperty("TableLayoutPanel4")]
    private TableLayoutPanel _TableLayoutPanel4;
    [AccessedThroughProperty("MetroShell1")]
    private MetroShell _MetroShell1;
    [AccessedThroughProperty("MetroTabPanel2")]
    private MetroTabPanel _MetroTabPanel2;
    [AccessedThroughProperty("MetroTabPanel1")]
    private MetroTabPanel _MetroTabPanel1;
    [AccessedThroughProperty("MetroAppButton1")]
    private MetroAppButton _MetroAppButton1;
    [AccessedThroughProperty("MetroTabItem1")]
    private MetroTabItem _MetroTabItem1;
    [AccessedThroughProperty("MetroTabItem2")]
    private MetroTabItem _MetroTabItem2;
    [AccessedThroughProperty("ButtonItem1")]
    private ButtonItem _ButtonItem1;
    [AccessedThroughProperty("StyleManager1")]
    private StyleManager _StyleManager1;
    [AccessedThroughProperty("MetroTabPanel4")]
    private MetroTabPanel _MetroTabPanel4;
    [AccessedThroughProperty("MetroTabItem4")]
    private MetroTabItem _MetroTabItem4;
    [AccessedThroughProperty("ReflectionLabel5")]
    private ReflectionLabel _ReflectionLabel5;
    [AccessedThroughProperty("ReflectionLabel3")]
    private ReflectionLabel _ReflectionLabel3;
    [AccessedThroughProperty("ReflectionLabel2")]
    private ReflectionLabel _ReflectionLabel2;
    [AccessedThroughProperty("ReflectionLabel1")]
    private ReflectionLabel _ReflectionLabel1;
    [AccessedThroughProperty("lblSummary_FuelRev")]
    private LabelX _lblSummary_FuelRev;
    [AccessedThroughProperty("lblSummary_TestTime")]
    private LabelX _lblSummary_TestTime;
    [AccessedThroughProperty("lblSummary_TestDate")]
    private LabelX _lblSummary_TestDate;
    [AccessedThroughProperty("lblSummary_ScriptRev")]
    private LabelX _lblSummary_ScriptRev;
    [AccessedThroughProperty("lblSummary_PSTColor")]
    private LabelX _lblSummary_PSTColor;
    [AccessedThroughProperty("lblSummary_PSTBlack")]
    private LabelX _lblSummary_PSTBlack;
    [AccessedThroughProperty("lblSummary_EngPgCnt")]
    private LabelX _lblSummary_EngPgCnt;
    [AccessedThroughProperty("lblSummary_FW")]
    private LabelX _lblSummary_FW;
    [AccessedThroughProperty("lblSummary_SerialNum")]
    private LabelX _lblSummary_SerialNum;
    [AccessedThroughProperty("Chart1")]
    private Chart _Chart1;
    [AccessedThroughProperty("Chart2")]
    private Chart _Chart2;
    [AccessedThroughProperty("MetroTabPanel3")]
    private MetroTabPanel _MetroTabPanel3;
    [AccessedThroughProperty("Chart3")]
    private Chart _Chart3;
    [AccessedThroughProperty("MetroTabItem3")]
    private MetroTabItem _MetroTabItem3;
    [AccessedThroughProperty("TableLayoutPanel5")]
    private TableLayoutPanel _TableLayoutPanel5;
    [AccessedThroughProperty("lblHistory_TotalUnits")]
    private LabelX _lblHistory_TotalUnits;
    [AccessedThroughProperty("cmdDataSelect")]
    private ButtonX _cmdDataSelect;
    [AccessedThroughProperty("cmdShowRuncharts")]
    private ButtonItem _cmdShowRuncharts;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    [AccessedThroughProperty("ReflectionLabel4")]
    private ReflectionLabel _ReflectionLabel4;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;
    [AccessedThroughProperty("lblFailModes")]
    private LabelX _lblFailModes;
    [AccessedThroughProperty("MetroTabPanel5")]
    private MetroTabPanel _MetroTabPanel5;
    [AccessedThroughProperty("SuperTabControl1")]
    private SuperTabControl _SuperTabControl1;
    [AccessedThroughProperty("SuperTabControlPanel1")]
    private SuperTabControlPanel _SuperTabControlPanel1;
    [AccessedThroughProperty("stiPSTDocs_Intro")]
    private SuperTabItem _stiPSTDocs_Intro;
    [AccessedThroughProperty("SuperTabControlPanel4")]
    private SuperTabControlPanel _SuperTabControlPanel4;
    [AccessedThroughProperty("stiPSTDocs_CyclicalPressure")]
    private SuperTabItem _stiPSTDocs_CyclicalPressure;
    [AccessedThroughProperty("SuperTabControlPanel3")]
    private SuperTabControlPanel _SuperTabControlPanel3;
    [AccessedThroughProperty("stiPSTDocs_DelayedPressure")]
    private SuperTabItem _stiPSTDocs_DelayedPressure;
    [AccessedThroughProperty("SuperTabControlPanel2")]
    private SuperTabControlPanel _SuperTabControlPanel2;
    [AccessedThroughProperty("stiPSTDocs_NoPressure")]
    private SuperTabItem _stiPSTDocs_NoPressure;
    [AccessedThroughProperty("tabTriage")]
    private MetroTabItem _tabTriage;
    [AccessedThroughProperty("rtbPSTDocs_Intro")]
    private RichTextBox _rtbPSTDocs_Intro;
    [AccessedThroughProperty("SuperTabControlPanel5")]
    private SuperTabControlPanel _SuperTabControlPanel5;
    [AccessedThroughProperty("stiPSTDocs_PressureFluctuates")]
    private SuperTabItem _stiPSTDocs_PressureFluctuates;
    [AccessedThroughProperty("SuperTabControlPanel6")]
    private SuperTabControlPanel _SuperTabControlPanel6;
    [AccessedThroughProperty("rtbPSTDocs_PSTOutputs")]
    private RichTextBox _rtbPSTDocs_PSTOutputs;
    [AccessedThroughProperty("stiPSTDocs_Outputs")]
    private SuperTabItem _stiPSTDocs_Outputs;
    [AccessedThroughProperty("rtbPSTDocs_NoPressure")]
    private RichTextBox _rtbPSTDocs_NoPressure;
    [AccessedThroughProperty("rtbPSTDocs_PressureFluctuates")]
    private RichTextBox _rtbPSTDocs_PressureFluctuates;
    [AccessedThroughProperty("rtbPSTDocs_CyclicalPressure")]
    private RichTextBox _rtbPSTDocs_CyclicalPressure;
    [AccessedThroughProperty("rtbPSTDocs_DelayedPressure")]
    private RichTextBox _rtbPSTDocs_DelayedPressure;
    [AccessedThroughProperty("MetroStatusBar1")]
    private MetroStatusBar _MetroStatusBar1;
    [AccessedThroughProperty("cmdEmail")]
    private ButtonItem _cmdEmail;
    [AccessedThroughProperty("cmdClipBoard")]
    private ButtonItem _cmdClipBoard;
    [AccessedThroughProperty("ButtonItem2")]
    private ButtonItem _ButtonItem2;
    [AccessedThroughProperty("ButtonItem3")]
    private ButtonItem _ButtonItem3;
    [AccessedThroughProperty("SuperTooltip1")]
    private SuperTooltip _SuperTooltip1;
    [AccessedThroughProperty("lstSummaryMechChecks")]
    private ListViewEx _lstSummaryMechChecks;
    [AccessedThroughProperty("ImageList1")]
    private ImageList _ImageList1;
    [AccessedThroughProperty("ColumnHeader2")]
    private ColumnHeader _ColumnHeader2;
    [AccessedThroughProperty("Chart4")]
    private Chart _Chart4;
    [AccessedThroughProperty("cmdShowRegularcharts")]
    private ButtonItem _cmdShowRegularcharts;
    [AccessedThroughProperty("cboRunCharts")]
    private ComboBoxEx _cboRunCharts;
    [AccessedThroughProperty("cmdShowDataGrid")]
    private ButtonItem _cmdShowDataGrid;
    [AccessedThroughProperty("sgcHistory")]
    private SuperGridControl _sgcHistory;
    [AccessedThroughProperty("cboHistory_XVal")]
    private ComboBoxEx _cboHistory_XVal;
    [AccessedThroughProperty("cboHistory_YVal")]
    private ComboBoxEx _cboHistory_YVal;
    [AccessedThroughProperty("cboHistory_Series")]
    private ComboBoxEx _cboHistory_Series;
    [AccessedThroughProperty("lblHistory_XVal")]
    private LabelX _lblHistory_XVal;
    [AccessedThroughProperty("lblHistory_YVal")]
    private LabelX _lblHistory_YVal;
    [AccessedThroughProperty("lblHistory_Series")]
    private LabelX _lblHistory_Series;
    [AccessedThroughProperty("cmdHistory_ChartIt")]
    private ButtonX _cmdHistory_ChartIt;
    [AccessedThroughProperty("cmdHistory_DataGrid_Edit")]
    private ButtonX _cmdHistory_DataGrid_Edit;
    [AccessedThroughProperty("MetroTabPanel6")]
    private MetroTabPanel _MetroTabPanel6;
    [AccessedThroughProperty("ButtonX2")]
    private ButtonX _ButtonX2;
    [AccessedThroughProperty("ButtonX1")]
    private ButtonX _ButtonX1;
    [AccessedThroughProperty("tabHelp")]
    private MetroTabItem _tabHelp;
    [AccessedThroughProperty("lblSummary_ScriptProduct")]
    private LabelX _lblSummary_ScriptProduct;
    [AccessedThroughProperty("lblMeasTubeEvac_K")]
    private LabelX _lblMeasTubeEvac_K;
    [AccessedThroughProperty("lblTitleTubeEvac_k")]
    private LabelX _lblTitleTubeEvac_k;
    [AccessedThroughProperty("lblSpecTubeEvac_K")]
    private LabelX _lblSpecTubeEvac_K;
    [AccessedThroughProperty("lblTitleTubeEvac_C")]
    private LabelX _lblTitleTubeEvac_C;
    [AccessedThroughProperty("lblMeasTubeEvac_C")]
    private LabelX _lblMeasTubeEvac_C;
    [AccessedThroughProperty("lblSpecTubeEvac_C")]
    private LabelX _lblSpecTubeEvac_C;
    [AccessedThroughProperty("FlowLayoutPanel1")]
    private FlowLayoutPanel _FlowLayoutPanel1;
    [AccessedThroughProperty("lblHidden_TestInfo")]
    private Label _lblHidden_TestInfo;
    [AccessedThroughProperty("lblHidden_TestID")]
    private Label _lblHidden_TestID;
    [AccessedThroughProperty("lblHidden_Date")]
    private Label _lblHidden_Date;
    [AccessedThroughProperty("lblHidden_Time")]
    private Label _lblHidden_Time;
    [AccessedThroughProperty("lblHidden_Serial")]
    private Label _lblHidden_Serial;
    [AccessedThroughProperty("lblHidden_RunNum")]
    private Label _lblHidden_RunNum;
    [AccessedThroughProperty("lblHidden_FUELRev")]
    private Label _lblHidden_FUELRev;
    [AccessedThroughProperty("lblHidden_ScriptRev")]
    private Label _lblHidden_ScriptRev;
    [AccessedThroughProperty("lblHidden_Product")]
    private Label _lblHidden_Product;
    [AccessedThroughProperty("ButtonItem4")]
    private ButtonItem _ButtonItem4;
    [AccessedThroughProperty("lblSummary_Run")]
    private LabelX _lblSummary_Run;
    [AccessedThroughProperty("lblSummary_TestID")]
    private LabelX _lblSummary_TestID;
    [AccessedThroughProperty("cmdSaveFormImage")]
    private ButtonItem _cmdSaveFormImage;
    private DataTable dtHistory;
    private PST PST;
    private bool TestStatus;

    [DebuggerNonUserCode]
    static dlgPSTResults()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (dlgPSTResults.__ENCList)
      {
        if (dlgPSTResults.__ENCList.Count == dlgPSTResults.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (dlgPSTResults.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (dlgPSTResults.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                dlgPSTResults.__ENCList[index1] = dlgPSTResults.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          dlgPSTResults.__ENCList.RemoveRange(index1, checked (dlgPSTResults.__ENCList.Count - index1));
          dlgPSTResults.__ENCList.Capacity = dlgPSTResults.__ENCList.Count;
        }
        dlgPSTResults.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      Title title1 = new Title();
      ChartArea chartArea2 = new ChartArea();
      Title title2 = new Title();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPSTResults));
      ChartArea chartArea3 = new ChartArea();
      ChartArea chartArea4 = new ChartArea();
      Legend legend1 = new Legend();
      ChartArea chartArea5 = new ChartArea();
      Legend legend2 = new Legend();
      this.lblTitlePressure_K = new LabelX();
      this.GroupPanel1 = new GroupPanel();
      this.TableLayoutPanel2 = new TableLayoutPanel();
      this.lblMeasTubeEvac_K = new LabelX();
      this.lblTitleTubeEvac_k = new LabelX();
      this.lblTitleLeak_K = new LabelX();
      this.lblTitleVent_K = new LabelX();
      this.lblMeasPressure_K = new LabelX();
      this.lblMeasLeak_K = new LabelX();
      this.lblMeasVent_K = new LabelX();
      this.lblSpecPressure_K = new LabelX();
      this.lblSpecLeak_K = new LabelX();
      this.lblSpecVent_K = new LabelX();
      this.LabelX10 = new LabelX();
      this.LabelX11 = new LabelX();
      this.LabelX12 = new LabelX();
      this.lblSpecTubeEvac_K = new LabelX();
      this.GroupPanel2 = new GroupPanel();
      this.TableLayoutPanel3 = new TableLayoutPanel();
      this.lblTitleTubeEvac_C = new LabelX();
      this.lblMeasTubeEvac_C = new LabelX();
      this.lblSpecTubeEvac_C = new LabelX();
      this.lblTitlePressure_C = new LabelX();
      this.lblTitleLeak_C = new LabelX();
      this.lblTitleVent_C = new LabelX();
      this.lblMeasPressure_C = new LabelX();
      this.lblMeasLeak_C = new LabelX();
      this.lblMeasVent_C = new LabelX();
      this.lblSpecPressure_C = new LabelX();
      this.lblSpecLeak_C = new LabelX();
      this.lblSpecVent_C = new LabelX();
      this.LabelX16 = new LabelX();
      this.LabelX17 = new LabelX();
      this.LabelX18 = new LabelX();
      this.TableLayoutPanel4 = new TableLayoutPanel();
      this.FlowLayoutPanel1 = new FlowLayoutPanel();
      this.lblHidden_TestInfo = new Label();
      this.lblHidden_TestID = new Label();
      this.lblHidden_Date = new Label();
      this.lblHidden_Time = new Label();
      this.lblHidden_Serial = new Label();
      this.lblHidden_RunNum = new Label();
      this.lblHidden_FUELRev = new Label();
      this.lblHidden_ScriptRev = new Label();
      this.lblHidden_Product = new Label();
      this.Chart1 = new Chart();
      this.Chart2 = new Chart();
      this.MetroShell1 = new MetroShell();
      this.MetroTabPanel1 = new MetroTabPanel();
      this.lblSummary_Run = new LabelX();
      this.lblSummary_TestID = new LabelX();
      this.PictureBox1 = new PictureBox();
      this.ReflectionLabel4 = new ReflectionLabel();
      this.lblSummary_ScriptProduct = new LabelX();
      this.lstSummaryMechChecks = new ListViewEx();
      this.ColumnHeader2 = new ColumnHeader();
      this.ImageList1 = new ImageList(this.components);
      this.LabelX1 = new LabelX();
      this.lblFailModes = new LabelX();
      this.ReflectionLabel5 = new ReflectionLabel();
      this.ReflectionLabel3 = new ReflectionLabel();
      this.lblSummary_PSTColor = new LabelX();
      this.lblSummary_PSTBlack = new LabelX();
      this.lblSummary_EngPgCnt = new LabelX();
      this.lblSummary_FW = new LabelX();
      this.lblSummary_SerialNum = new LabelX();
      this.ReflectionLabel1 = new ReflectionLabel();
      this.lblSummary_TestTime = new LabelX();
      this.lblSummary_TestDate = new LabelX();
      this.lblSummary_ScriptRev = new LabelX();
      this.lblSummary_FuelRev = new LabelX();
      this.ReflectionLabel2 = new ReflectionLabel();
      this.MetroTabPanel5 = new MetroTabPanel();
      this.SuperTabControl1 = new SuperTabControl();
      this.SuperTabControlPanel1 = new SuperTabControlPanel();
      this.rtbPSTDocs_Intro = new RichTextBox();
      this.stiPSTDocs_Intro = new SuperTabItem();
      this.SuperTabControlPanel6 = new SuperTabControlPanel();
      this.rtbPSTDocs_PSTOutputs = new RichTextBox();
      this.stiPSTDocs_Outputs = new SuperTabItem();
      this.SuperTabControlPanel3 = new SuperTabControlPanel();
      this.rtbPSTDocs_DelayedPressure = new RichTextBox();
      this.stiPSTDocs_DelayedPressure = new SuperTabItem();
      this.SuperTabControlPanel4 = new SuperTabControlPanel();
      this.rtbPSTDocs_CyclicalPressure = new RichTextBox();
      this.stiPSTDocs_CyclicalPressure = new SuperTabItem();
      this.SuperTabControlPanel2 = new SuperTabControlPanel();
      this.rtbPSTDocs_NoPressure = new RichTextBox();
      this.stiPSTDocs_NoPressure = new SuperTabItem();
      this.SuperTabControlPanel5 = new SuperTabControlPanel();
      this.rtbPSTDocs_PressureFluctuates = new RichTextBox();
      this.stiPSTDocs_PressureFluctuates = new SuperTabItem();
      this.MetroTabPanel6 = new MetroTabPanel();
      this.ButtonX2 = new ButtonX();
      this.ButtonX1 = new ButtonX();
      this.MetroTabPanel2 = new MetroTabPanel();
      this.MetroTabPanel4 = new MetroTabPanel();
      this.MetroTabPanel3 = new MetroTabPanel();
      this.TableLayoutPanel5 = new TableLayoutPanel();
      this.cmdDataSelect = new ButtonX();
      this.cmdShowRuncharts = new ButtonItem();
      this.cmdShowRegularcharts = new ButtonItem();
      this.cmdShowDataGrid = new ButtonItem();
      this.Chart3 = new Chart();
      this.Chart4 = new Chart();
      this.lblHistory_TotalUnits = new LabelX();
      this.cboRunCharts = new ComboBoxEx();
      this.sgcHistory = new SuperGridControl();
      this.cboHistory_XVal = new ComboBoxEx();
      this.cboHistory_YVal = new ComboBoxEx();
      this.cboHistory_Series = new ComboBoxEx();
      this.lblHistory_XVal = new LabelX();
      this.lblHistory_YVal = new LabelX();
      this.lblHistory_Series = new LabelX();
      this.cmdHistory_ChartIt = new ButtonX();
      this.cmdHistory_DataGrid_Edit = new ButtonX();
      this.MetroAppButton1 = new MetroAppButton();
      this.MetroTabItem1 = new MetroTabItem();
      this.MetroTabItem2 = new MetroTabItem();
      this.MetroTabItem4 = new MetroTabItem();
      this.MetroTabItem3 = new MetroTabItem();
      this.tabTriage = new MetroTabItem();
      this.tabHelp = new MetroTabItem();
      this.ButtonItem4 = new ButtonItem();
      this.ButtonItem1 = new ButtonItem();
      this.StyleManager1 = new StyleManager(this.components);
      this.MetroStatusBar1 = new MetroStatusBar();
      this.cmdEmail = new ButtonItem();
      this.cmdClipBoard = new ButtonItem();
      this.cmdSaveFormImage = new ButtonItem();
      this.ButtonItem2 = new ButtonItem();
      this.ButtonItem3 = new ButtonItem();
      this.SuperTooltip1 = new SuperTooltip();
      this.GroupPanel1.SuspendLayout();
      this.TableLayoutPanel2.SuspendLayout();
      this.GroupPanel2.SuspendLayout();
      this.TableLayoutPanel3.SuspendLayout();
      this.TableLayoutPanel4.SuspendLayout();
      this.FlowLayoutPanel1.SuspendLayout();
      this.Chart1.BeginInit();
      this.Chart2.BeginInit();
      this.MetroShell1.SuspendLayout();
      this.MetroTabPanel1.SuspendLayout();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.MetroTabPanel5.SuspendLayout();
      ((ISupportInitialize) this.SuperTabControl1).BeginInit();
      this.SuperTabControl1.SuspendLayout();
      this.SuperTabControlPanel1.SuspendLayout();
      this.SuperTabControlPanel6.SuspendLayout();
      this.SuperTabControlPanel3.SuspendLayout();
      this.SuperTabControlPanel4.SuspendLayout();
      this.SuperTabControlPanel2.SuspendLayout();
      this.SuperTabControlPanel5.SuspendLayout();
      this.MetroTabPanel6.SuspendLayout();
      this.MetroTabPanel2.SuspendLayout();
      this.MetroTabPanel3.SuspendLayout();
      this.TableLayoutPanel5.SuspendLayout();
      this.Chart3.BeginInit();
      this.Chart4.BeginInit();
      this.SuspendLayout();
      this.lblTitlePressure_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitlePressure_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitlePressure_K.Dock = DockStyle.Fill;
      this.lblTitlePressure_K.ForeColor = Color.Black;
      LabelX lblTitlePressureK1 = this.lblTitlePressure_K;
      Point point1 = new Point(0, 24);
      Point point2 = point1;
      lblTitlePressureK1.Location = point2;
      LabelX lblTitlePressureK2 = this.lblTitlePressure_K;
      System.Windows.Forms.Padding padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding2 = padding1;
      lblTitlePressureK2.Margin = padding2;
      this.lblTitlePressure_K.Name = "lblTitlePressure_K";
      this.lblTitlePressure_K.PaddingLeft = 3;
      this.lblTitlePressure_K.PaddingRight = 3;
      LabelX lblTitlePressureK3 = this.lblTitlePressure_K;
      Size size1 = new Size(151, 24);
      Size size2 = size1;
      lblTitlePressureK3.Size = size2;
      this.lblTitlePressure_K.TabIndex = 2;
      this.lblTitlePressure_K.Text = "Pressure";
      this.lblTitlePressure_K.TextAlignment = StringAlignment.Far;
      this.GroupPanel1.Anchor = AnchorStyles.Bottom;
      this.GroupPanel1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.GroupPanel1.CanvasColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.GroupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
      this.GroupPanel1.Controls.Add((Control) this.TableLayoutPanel2);
      this.GroupPanel1.DisabledBackColor = Color.Empty;
      GroupPanel groupPanel1_1 = this.GroupPanel1;
      point1 = new Point(18, 289);
      Point point3 = point1;
      groupPanel1_1.Location = point3;
      this.GroupPanel1.Name = "GroupPanel1";
      GroupPanel groupPanel1_2 = this.GroupPanel1;
      size1 = new Size(383, 135);
      Size size3 = size1;
      groupPanel1_2.Size = size3;
      this.GroupPanel1.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
      this.GroupPanel1.Style.BackColorGradientAngle = 90;
      this.GroupPanel1.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
      this.GroupPanel1.Style.BorderBottom = eStyleBorderType.Solid;
      this.GroupPanel1.Style.BorderBottomWidth = 1;
      this.GroupPanel1.Style.BorderColorSchemePart = eColorSchemePart.MenuBorder;
      this.GroupPanel1.Style.BorderLeft = eStyleBorderType.Solid;
      this.GroupPanel1.Style.BorderLeftWidth = 1;
      this.GroupPanel1.Style.BorderRight = eStyleBorderType.Solid;
      this.GroupPanel1.Style.BorderRightWidth = 1;
      this.GroupPanel1.Style.BorderTop = eStyleBorderType.Solid;
      this.GroupPanel1.Style.BorderTopWidth = 1;
      this.GroupPanel1.Style.CornerDiameter = 4;
      this.GroupPanel1.Style.CornerType = eCornerType.Rounded;
      this.GroupPanel1.Style.TextAlignment = eStyleTextAlignment.Center;
      this.GroupPanel1.Style.TextColor = Color.FromArgb(0, 0, 0);
      this.GroupPanel1.Style.TextLineAlignment = eStyleTextAlignment.Near;
      this.GroupPanel1.StyleMouseDown.CornerType = eCornerType.Square;
      this.GroupPanel1.StyleMouseOver.CornerType = eCornerType.Square;
      this.GroupPanel1.TabIndex = 3;
      this.GroupPanel1.Text = "<b>Black PST Details</b>";
      this.TableLayoutPanel2.BackColor = Color.Transparent;
      this.TableLayoutPanel2.ColumnCount = 3;
      this.TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151f));
      this.TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97f));
      this.TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102f));
      this.TableLayoutPanel2.Controls.Add((Control) this.lblMeasTubeEvac_K, 0, 4);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblTitleTubeEvac_k, 0, 4);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblTitlePressure_K, 0, 1);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblTitleLeak_K, 0, 2);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblTitleVent_K, 0, 3);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblMeasPressure_K, 1, 1);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblMeasLeak_K, 1, 2);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblMeasVent_K, 1, 3);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblSpecPressure_K, 2, 1);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblSpecLeak_K, 2, 2);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblSpecVent_K, 2, 3);
      this.TableLayoutPanel2.Controls.Add((Control) this.LabelX10, 0, 0);
      this.TableLayoutPanel2.Controls.Add((Control) this.LabelX11, 1, 0);
      this.TableLayoutPanel2.Controls.Add((Control) this.LabelX12, 2, 0);
      this.TableLayoutPanel2.Controls.Add((Control) this.lblSpecTubeEvac_K, 1, 4);
      this.TableLayoutPanel2.Dock = DockStyle.Fill;
      this.TableLayoutPanel2.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel2_1 = this.TableLayoutPanel2;
      point1 = new Point(0, 0);
      Point point4 = point1;
      tableLayoutPanel2_1.Location = point4;
      TableLayoutPanel tableLayoutPanel2_2 = this.TableLayoutPanel2;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding3 = padding1;
      tableLayoutPanel2_2.Margin = padding3;
      this.TableLayoutPanel2.Name = "TableLayoutPanel2";
      this.TableLayoutPanel2.RowCount = 5;
      this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      TableLayoutPanel tableLayoutPanel2_3 = this.TableLayoutPanel2;
      size1 = new Size(377, 116);
      Size size4 = size1;
      tableLayoutPanel2_3.Size = size4;
      this.TableLayoutPanel2.TabIndex = 0;
      this.lblMeasTubeEvac_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasTubeEvac_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasTubeEvac_K.Dock = DockStyle.Fill;
      this.lblMeasTubeEvac_K.ForeColor = Color.Black;
      LabelX lblMeasTubeEvacK1 = this.lblMeasTubeEvac_K;
      point1 = new Point(151, 96);
      Point point5 = point1;
      lblMeasTubeEvacK1.Location = point5;
      LabelX lblMeasTubeEvacK2 = this.lblMeasTubeEvac_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding4 = padding1;
      lblMeasTubeEvacK2.Margin = padding4;
      this.lblMeasTubeEvac_K.Name = "lblMeasTubeEvac_K";
      this.lblMeasTubeEvac_K.PaddingLeft = 3;
      this.lblMeasTubeEvac_K.PaddingRight = 3;
      LabelX lblMeasTubeEvacK3 = this.lblMeasTubeEvac_K;
      size1 = new Size(97, 20);
      Size size5 = size1;
      lblMeasTubeEvacK3.Size = size5;
      this.lblMeasTubeEvac_K.TabIndex = 16;
      this.lblMeasTubeEvac_K.Text = "LabelX9";
      this.lblMeasTubeEvac_K.TextAlignment = StringAlignment.Center;
      this.lblTitleTubeEvac_k.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleTubeEvac_k.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleTubeEvac_k.Dock = DockStyle.Fill;
      this.lblTitleTubeEvac_k.ForeColor = Color.Black;
      LabelX lblTitleTubeEvacK1 = this.lblTitleTubeEvac_k;
      point1 = new Point(0, 96);
      Point point6 = point1;
      lblTitleTubeEvacK1.Location = point6;
      LabelX lblTitleTubeEvacK2 = this.lblTitleTubeEvac_k;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding5 = padding1;
      lblTitleTubeEvacK2.Margin = padding5;
      this.lblTitleTubeEvac_k.Name = "lblTitleTubeEvac_k";
      this.lblTitleTubeEvac_k.PaddingLeft = 3;
      this.lblTitleTubeEvac_k.PaddingRight = 3;
      LabelX lblTitleTubeEvacK3 = this.lblTitleTubeEvac_k;
      size1 = new Size(151, 20);
      Size size6 = size1;
      lblTitleTubeEvacK3.Size = size6;
      this.lblTitleTubeEvac_k.TabIndex = 14;
      this.lblTitleTubeEvac_k.Text = "Tube Evac";
      this.lblTitleTubeEvac_k.TextAlignment = StringAlignment.Far;
      this.lblTitleLeak_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleLeak_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleLeak_K.Dock = DockStyle.Fill;
      this.lblTitleLeak_K.ForeColor = Color.Black;
      LabelX lblTitleLeakK1 = this.lblTitleLeak_K;
      point1 = new Point(0, 48);
      Point point7 = point1;
      lblTitleLeakK1.Location = point7;
      LabelX lblTitleLeakK2 = this.lblTitleLeak_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding6 = padding1;
      lblTitleLeakK2.Margin = padding6;
      this.lblTitleLeak_K.Name = "lblTitleLeak_K";
      this.lblTitleLeak_K.PaddingLeft = 3;
      this.lblTitleLeak_K.PaddingRight = 3;
      LabelX lblTitleLeakK3 = this.lblTitleLeak_K;
      size1 = new Size(151, 24);
      Size size7 = size1;
      lblTitleLeakK3.Size = size7;
      this.lblTitleLeak_K.TabIndex = 3;
      this.lblTitleLeak_K.Text = "Leak";
      this.lblTitleLeak_K.TextAlignment = StringAlignment.Far;
      this.lblTitleVent_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleVent_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleVent_K.Dock = DockStyle.Fill;
      this.lblTitleVent_K.ForeColor = Color.Black;
      LabelX lblTitleVentK1 = this.lblTitleVent_K;
      point1 = new Point(0, 72);
      Point point8 = point1;
      lblTitleVentK1.Location = point8;
      LabelX lblTitleVentK2 = this.lblTitleVent_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding7 = padding1;
      lblTitleVentK2.Margin = padding7;
      this.lblTitleVent_K.Name = "lblTitleVent_K";
      this.lblTitleVent_K.PaddingLeft = 3;
      this.lblTitleVent_K.PaddingRight = 3;
      LabelX lblTitleVentK3 = this.lblTitleVent_K;
      size1 = new Size(151, 24);
      Size size8 = size1;
      lblTitleVentK3.Size = size8;
      this.lblTitleVent_K.TabIndex = 4;
      this.lblTitleVent_K.Text = "Vent Delta P";
      this.lblTitleVent_K.TextAlignment = StringAlignment.Far;
      this.lblMeasPressure_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasPressure_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasPressure_K.Dock = DockStyle.Fill;
      this.lblMeasPressure_K.ForeColor = Color.Black;
      LabelX lblMeasPressureK1 = this.lblMeasPressure_K;
      point1 = new Point(151, 24);
      Point point9 = point1;
      lblMeasPressureK1.Location = point9;
      LabelX lblMeasPressureK2 = this.lblMeasPressure_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding8 = padding1;
      lblMeasPressureK2.Margin = padding8;
      this.lblMeasPressure_K.Name = "lblMeasPressure_K";
      this.lblMeasPressure_K.PaddingLeft = 3;
      this.lblMeasPressure_K.PaddingRight = 3;
      LabelX lblMeasPressureK3 = this.lblMeasPressure_K;
      size1 = new Size(97, 24);
      Size size9 = size1;
      lblMeasPressureK3.Size = size9;
      this.lblMeasPressure_K.TabIndex = 5;
      this.lblMeasPressure_K.Text = "LabelX4";
      this.lblMeasPressure_K.TextAlignment = StringAlignment.Center;
      this.lblMeasLeak_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasLeak_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasLeak_K.Dock = DockStyle.Fill;
      this.lblMeasLeak_K.ForeColor = Color.Black;
      LabelX lblMeasLeakK1 = this.lblMeasLeak_K;
      point1 = new Point(151, 48);
      Point point10 = point1;
      lblMeasLeakK1.Location = point10;
      LabelX lblMeasLeakK2 = this.lblMeasLeak_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding9 = padding1;
      lblMeasLeakK2.Margin = padding9;
      this.lblMeasLeak_K.Name = "lblMeasLeak_K";
      this.lblMeasLeak_K.PaddingLeft = 3;
      this.lblMeasLeak_K.PaddingRight = 3;
      LabelX lblMeasLeakK3 = this.lblMeasLeak_K;
      size1 = new Size(97, 24);
      Size size10 = size1;
      lblMeasLeakK3.Size = size10;
      this.lblMeasLeak_K.TabIndex = 6;
      this.lblMeasLeak_K.Text = "LabelX5";
      this.lblMeasLeak_K.TextAlignment = StringAlignment.Center;
      this.lblMeasVent_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasVent_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasVent_K.Dock = DockStyle.Fill;
      this.lblMeasVent_K.ForeColor = Color.Black;
      LabelX lblMeasVentK1 = this.lblMeasVent_K;
      point1 = new Point(151, 72);
      Point point11 = point1;
      lblMeasVentK1.Location = point11;
      LabelX lblMeasVentK2 = this.lblMeasVent_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding10 = padding1;
      lblMeasVentK2.Margin = padding10;
      this.lblMeasVent_K.Name = "lblMeasVent_K";
      this.lblMeasVent_K.PaddingLeft = 3;
      this.lblMeasVent_K.PaddingRight = 3;
      LabelX lblMeasVentK3 = this.lblMeasVent_K;
      size1 = new Size(97, 24);
      Size size11 = size1;
      lblMeasVentK3.Size = size11;
      this.lblMeasVent_K.TabIndex = 7;
      this.lblMeasVent_K.Text = "LabelX6";
      this.lblMeasVent_K.TextAlignment = StringAlignment.Center;
      this.lblSpecPressure_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecPressure_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecPressure_K.Dock = DockStyle.Fill;
      this.lblSpecPressure_K.ForeColor = Color.Black;
      LabelX lblSpecPressureK1 = this.lblSpecPressure_K;
      point1 = new Point(248, 24);
      Point point12 = point1;
      lblSpecPressureK1.Location = point12;
      LabelX lblSpecPressureK2 = this.lblSpecPressure_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding11 = padding1;
      lblSpecPressureK2.Margin = padding11;
      this.lblSpecPressure_K.Name = "lblSpecPressure_K";
      this.lblSpecPressure_K.PaddingLeft = 3;
      this.lblSpecPressure_K.PaddingRight = 3;
      LabelX lblSpecPressureK3 = this.lblSpecPressure_K;
      size1 = new Size(129, 24);
      Size size12 = size1;
      lblSpecPressureK3.Size = size12;
      this.lblSpecPressure_K.TabIndex = 8;
      this.lblSpecPressure_K.Text = "LabelX7";
      this.lblSpecPressure_K.TextAlignment = StringAlignment.Center;
      this.lblSpecLeak_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecLeak_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecLeak_K.Dock = DockStyle.Fill;
      this.lblSpecLeak_K.ForeColor = Color.Black;
      LabelX lblSpecLeakK1 = this.lblSpecLeak_K;
      point1 = new Point(248, 48);
      Point point13 = point1;
      lblSpecLeakK1.Location = point13;
      LabelX lblSpecLeakK2 = this.lblSpecLeak_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding12 = padding1;
      lblSpecLeakK2.Margin = padding12;
      this.lblSpecLeak_K.Name = "lblSpecLeak_K";
      this.lblSpecLeak_K.PaddingLeft = 3;
      this.lblSpecLeak_K.PaddingRight = 3;
      LabelX lblSpecLeakK3 = this.lblSpecLeak_K;
      size1 = new Size(129, 24);
      Size size13 = size1;
      lblSpecLeakK3.Size = size13;
      this.lblSpecLeak_K.TabIndex = 9;
      this.lblSpecLeak_K.Text = "LabelX8";
      this.lblSpecLeak_K.TextAlignment = StringAlignment.Center;
      this.lblSpecVent_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecVent_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecVent_K.Dock = DockStyle.Fill;
      this.lblSpecVent_K.ForeColor = Color.Black;
      LabelX lblSpecVentK1 = this.lblSpecVent_K;
      point1 = new Point(248, 72);
      Point point14 = point1;
      lblSpecVentK1.Location = point14;
      LabelX lblSpecVentK2 = this.lblSpecVent_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding13 = padding1;
      lblSpecVentK2.Margin = padding13;
      this.lblSpecVent_K.Name = "lblSpecVent_K";
      this.lblSpecVent_K.PaddingLeft = 3;
      this.lblSpecVent_K.PaddingRight = 3;
      LabelX lblSpecVentK3 = this.lblSpecVent_K;
      size1 = new Size(129, 24);
      Size size14 = size1;
      lblSpecVentK3.Size = size14;
      this.lblSpecVent_K.TabIndex = 10;
      this.lblSpecVent_K.Text = "LabelX9";
      this.lblSpecVent_K.TextAlignment = StringAlignment.Center;
      this.LabelX10.BackColor = Color.Transparent;
      this.LabelX10.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX10.Dock = DockStyle.Fill;
      this.LabelX10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX10.ForeColor = Color.Black;
      LabelX labelX10_1 = this.LabelX10;
      point1 = new Point(3, 3);
      Point point15 = point1;
      labelX10_1.Location = point15;
      this.LabelX10.Name = "LabelX10";
      this.LabelX10.PaddingLeft = 3;
      this.LabelX10.PaddingRight = 3;
      LabelX labelX10_2 = this.LabelX10;
      size1 = new Size(145, 18);
      Size size15 = size1;
      labelX10_2.Size = size15;
      this.LabelX10.TabIndex = 11;
      this.LabelX10.Text = "Metric";
      this.LabelX10.TextAlignment = StringAlignment.Far;
      this.LabelX11.BackColor = Color.Transparent;
      this.LabelX11.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX11.Dock = DockStyle.Fill;
      this.LabelX11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX11.ForeColor = Color.Black;
      LabelX labelX11_1 = this.LabelX11;
      point1 = new Point(154, 3);
      Point point16 = point1;
      labelX11_1.Location = point16;
      this.LabelX11.Name = "LabelX11";
      this.LabelX11.PaddingLeft = 3;
      this.LabelX11.PaddingRight = 3;
      LabelX labelX11_2 = this.LabelX11;
      size1 = new Size(91, 18);
      Size size16 = size1;
      labelX11_2.Size = size16;
      this.LabelX11.TabIndex = 12;
      this.LabelX11.Text = "Measure Value";
      this.LabelX11.TextAlignment = StringAlignment.Center;
      this.LabelX12.BackColor = Color.Transparent;
      this.LabelX12.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX12.Dock = DockStyle.Fill;
      this.LabelX12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX12.ForeColor = Color.Black;
      LabelX labelX12_1 = this.LabelX12;
      point1 = new Point(251, 3);
      Point point17 = point1;
      labelX12_1.Location = point17;
      this.LabelX12.Name = "LabelX12";
      this.LabelX12.PaddingLeft = 3;
      this.LabelX12.PaddingRight = 3;
      LabelX labelX12_2 = this.LabelX12;
      size1 = new Size(123, 18);
      Size size17 = size1;
      labelX12_2.Size = size17;
      this.LabelX12.Style = eDotNetBarStyle.StyleManagerControlled;
      this.LabelX12.TabIndex = 13;
      this.LabelX12.Text = "Specs";
      this.LabelX12.TextAlignment = StringAlignment.Center;
      this.lblSpecTubeEvac_K.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecTubeEvac_K.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecTubeEvac_K.Dock = DockStyle.Fill;
      this.lblSpecTubeEvac_K.ForeColor = Color.Black;
      LabelX lblSpecTubeEvacK1 = this.lblSpecTubeEvac_K;
      point1 = new Point(248, 96);
      Point point18 = point1;
      lblSpecTubeEvacK1.Location = point18;
      LabelX lblSpecTubeEvacK2 = this.lblSpecTubeEvac_K;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding14 = padding1;
      lblSpecTubeEvacK2.Margin = padding14;
      this.lblSpecTubeEvac_K.Name = "lblSpecTubeEvac_K";
      this.lblSpecTubeEvac_K.PaddingLeft = 3;
      this.lblSpecTubeEvac_K.PaddingRight = 3;
      LabelX lblSpecTubeEvacK3 = this.lblSpecTubeEvac_K;
      size1 = new Size(129, 20);
      Size size18 = size1;
      lblSpecTubeEvacK3.Size = size18;
      this.lblSpecTubeEvac_K.TabIndex = 15;
      this.lblSpecTubeEvac_K.Text = "LabelX6";
      this.lblSpecTubeEvac_K.TextAlignment = StringAlignment.Center;
      this.GroupPanel2.Anchor = AnchorStyles.Bottom;
      this.GroupPanel2.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.GroupPanel2.CanvasColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.GroupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
      this.GroupPanel2.Controls.Add((Control) this.TableLayoutPanel3);
      this.GroupPanel2.DisabledBackColor = Color.Empty;
      GroupPanel groupPanel2_1 = this.GroupPanel2;
      point1 = new Point(437, 289);
      Point point19 = point1;
      groupPanel2_1.Location = point19;
      this.GroupPanel2.Name = "GroupPanel2";
      GroupPanel groupPanel2_2 = this.GroupPanel2;
      size1 = new Size(383, 135);
      Size size19 = size1;
      groupPanel2_2.Size = size19;
      this.GroupPanel2.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
      this.GroupPanel2.Style.BackColorGradientAngle = 90;
      this.GroupPanel2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
      this.GroupPanel2.Style.BorderBottom = eStyleBorderType.Solid;
      this.GroupPanel2.Style.BorderBottomWidth = 1;
      this.GroupPanel2.Style.BorderColorSchemePart = eColorSchemePart.MenuBorder;
      this.GroupPanel2.Style.BorderLeft = eStyleBorderType.Solid;
      this.GroupPanel2.Style.BorderLeftWidth = 1;
      this.GroupPanel2.Style.BorderRight = eStyleBorderType.Solid;
      this.GroupPanel2.Style.BorderRightWidth = 1;
      this.GroupPanel2.Style.BorderTop = eStyleBorderType.Solid;
      this.GroupPanel2.Style.BorderTopWidth = 1;
      this.GroupPanel2.Style.CornerDiameter = 4;
      this.GroupPanel2.Style.CornerType = eCornerType.Rounded;
      this.GroupPanel2.Style.TextAlignment = eStyleTextAlignment.Center;
      this.GroupPanel2.Style.TextColor = Color.FromArgb(0, 0, 0);
      this.GroupPanel2.Style.TextLineAlignment = eStyleTextAlignment.Near;
      this.GroupPanel2.StyleMouseDown.CornerType = eCornerType.Square;
      this.GroupPanel2.StyleMouseOver.CornerType = eCornerType.Square;
      this.GroupPanel2.TabIndex = 4;
      this.GroupPanel2.Text = "<b>Color PST Details</b>";
      this.TableLayoutPanel3.BackColor = Color.Transparent;
      this.TableLayoutPanel3.ColumnCount = 3;
      this.TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151f));
      this.TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97f));
      this.TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72f));
      this.TableLayoutPanel3.Controls.Add((Control) this.lblTitleTubeEvac_C, 0, 4);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblMeasTubeEvac_C, 0, 4);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblSpecTubeEvac_C, 0, 4);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblTitlePressure_C, 0, 1);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblTitleLeak_C, 0, 2);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblTitleVent_C, 0, 3);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblMeasPressure_C, 1, 1);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblMeasLeak_C, 1, 2);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblMeasVent_C, 1, 3);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblSpecPressure_C, 2, 1);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblSpecLeak_C, 2, 2);
      this.TableLayoutPanel3.Controls.Add((Control) this.lblSpecVent_C, 2, 3);
      this.TableLayoutPanel3.Controls.Add((Control) this.LabelX16, 0, 0);
      this.TableLayoutPanel3.Controls.Add((Control) this.LabelX17, 1, 0);
      this.TableLayoutPanel3.Controls.Add((Control) this.LabelX18, 2, 0);
      this.TableLayoutPanel3.Dock = DockStyle.Fill;
      this.TableLayoutPanel3.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel3_1 = this.TableLayoutPanel3;
      point1 = new Point(0, 0);
      Point point20 = point1;
      tableLayoutPanel3_1.Location = point20;
      this.TableLayoutPanel3.Name = "TableLayoutPanel3";
      this.TableLayoutPanel3.RowCount = 5;
      this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      TableLayoutPanel tableLayoutPanel3_2 = this.TableLayoutPanel3;
      size1 = new Size(377, 116);
      Size size20 = size1;
      tableLayoutPanel3_2.Size = size20;
      this.TableLayoutPanel3.TabIndex = 0;
      this.lblTitleTubeEvac_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleTubeEvac_C.Dock = DockStyle.Fill;
      this.lblTitleTubeEvac_C.ForeColor = Color.Black;
      LabelX lblTitleTubeEvacC1 = this.lblTitleTubeEvac_C;
      point1 = new Point(0, 96);
      Point point21 = point1;
      lblTitleTubeEvacC1.Location = point21;
      LabelX lblTitleTubeEvacC2 = this.lblTitleTubeEvac_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding15 = padding1;
      lblTitleTubeEvacC2.Margin = padding15;
      this.lblTitleTubeEvac_C.Name = "lblTitleTubeEvac_C";
      this.lblTitleTubeEvac_C.PaddingLeft = 3;
      this.lblTitleTubeEvac_C.PaddingRight = 3;
      LabelX lblTitleTubeEvacC3 = this.lblTitleTubeEvac_C;
      size1 = new Size(151, 20);
      Size size21 = size1;
      lblTitleTubeEvacC3.Size = size21;
      this.lblTitleTubeEvac_C.TabIndex = 16;
      this.lblTitleTubeEvac_C.Text = "Tube Evac";
      this.lblTitleTubeEvac_C.TextAlignment = StringAlignment.Far;
      this.lblMeasTubeEvac_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasTubeEvac_C.Dock = DockStyle.Fill;
      this.lblMeasTubeEvac_C.ForeColor = Color.Black;
      LabelX lblMeasTubeEvacC1 = this.lblMeasTubeEvac_C;
      point1 = new Point(151, 96);
      Point point22 = point1;
      lblMeasTubeEvacC1.Location = point22;
      LabelX lblMeasTubeEvacC2 = this.lblMeasTubeEvac_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding16 = padding1;
      lblMeasTubeEvacC2.Margin = padding16;
      this.lblMeasTubeEvac_C.Name = "lblMeasTubeEvac_C";
      this.lblMeasTubeEvac_C.PaddingLeft = 3;
      this.lblMeasTubeEvac_C.PaddingRight = 3;
      LabelX lblMeasTubeEvacC3 = this.lblMeasTubeEvac_C;
      size1 = new Size(97, 20);
      Size size22 = size1;
      lblMeasTubeEvacC3.Size = size22;
      this.lblMeasTubeEvac_C.TabIndex = 15;
      this.lblMeasTubeEvac_C.Text = "Vent Time";
      this.lblMeasTubeEvac_C.TextAlignment = StringAlignment.Center;
      this.lblSpecTubeEvac_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecTubeEvac_C.Dock = DockStyle.Fill;
      this.lblSpecTubeEvac_C.ForeColor = Color.Black;
      LabelX lblSpecTubeEvacC1 = this.lblSpecTubeEvac_C;
      point1 = new Point(248, 96);
      Point point23 = point1;
      lblSpecTubeEvacC1.Location = point23;
      LabelX lblSpecTubeEvacC2 = this.lblSpecTubeEvac_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding17 = padding1;
      lblSpecTubeEvacC2.Margin = padding17;
      this.lblSpecTubeEvac_C.Name = "lblSpecTubeEvac_C";
      this.lblSpecTubeEvac_C.PaddingLeft = 3;
      this.lblSpecTubeEvac_C.PaddingRight = 3;
      LabelX lblSpecTubeEvacC3 = this.lblSpecTubeEvac_C;
      size1 = new Size(129, 20);
      Size size23 = size1;
      lblSpecTubeEvacC3.Size = size23;
      this.lblSpecTubeEvac_C.TabIndex = 14;
      this.lblSpecTubeEvac_C.Text = "Vent Time";
      this.lblSpecTubeEvac_C.TextAlignment = StringAlignment.Center;
      this.lblTitlePressure_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitlePressure_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitlePressure_C.Dock = DockStyle.Fill;
      this.lblTitlePressure_C.ForeColor = Color.Black;
      LabelX lblTitlePressureC1 = this.lblTitlePressure_C;
      point1 = new Point(0, 24);
      Point point24 = point1;
      lblTitlePressureC1.Location = point24;
      LabelX lblTitlePressureC2 = this.lblTitlePressure_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding18 = padding1;
      lblTitlePressureC2.Margin = padding18;
      this.lblTitlePressure_C.Name = "lblTitlePressure_C";
      this.lblTitlePressure_C.PaddingLeft = 3;
      this.lblTitlePressure_C.PaddingRight = 3;
      LabelX lblTitlePressureC3 = this.lblTitlePressure_C;
      size1 = new Size(151, 24);
      Size size24 = size1;
      lblTitlePressureC3.Size = size24;
      this.lblTitlePressure_C.TabIndex = 2;
      this.lblTitlePressure_C.Text = "Pressure";
      this.lblTitlePressure_C.TextAlignment = StringAlignment.Far;
      this.lblTitleLeak_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleLeak_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleLeak_C.Dock = DockStyle.Fill;
      this.lblTitleLeak_C.ForeColor = Color.Black;
      LabelX lblTitleLeakC1 = this.lblTitleLeak_C;
      point1 = new Point(0, 48);
      Point point25 = point1;
      lblTitleLeakC1.Location = point25;
      LabelX lblTitleLeakC2 = this.lblTitleLeak_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding19 = padding1;
      lblTitleLeakC2.Margin = padding19;
      this.lblTitleLeak_C.Name = "lblTitleLeak_C";
      this.lblTitleLeak_C.PaddingLeft = 3;
      this.lblTitleLeak_C.PaddingRight = 3;
      LabelX lblTitleLeakC3 = this.lblTitleLeak_C;
      size1 = new Size(151, 24);
      Size size25 = size1;
      lblTitleLeakC3.Size = size25;
      this.lblTitleLeak_C.TabIndex = 3;
      this.lblTitleLeak_C.Text = "Leak";
      this.lblTitleLeak_C.TextAlignment = StringAlignment.Far;
      this.lblTitleVent_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblTitleVent_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblTitleVent_C.Dock = DockStyle.Fill;
      this.lblTitleVent_C.ForeColor = Color.Black;
      LabelX lblTitleVentC1 = this.lblTitleVent_C;
      point1 = new Point(0, 72);
      Point point26 = point1;
      lblTitleVentC1.Location = point26;
      LabelX lblTitleVentC2 = this.lblTitleVent_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding20 = padding1;
      lblTitleVentC2.Margin = padding20;
      this.lblTitleVent_C.Name = "lblTitleVent_C";
      this.lblTitleVent_C.PaddingLeft = 3;
      this.lblTitleVent_C.PaddingRight = 3;
      LabelX lblTitleVentC3 = this.lblTitleVent_C;
      size1 = new Size(151, 24);
      Size size26 = size1;
      lblTitleVentC3.Size = size26;
      this.lblTitleVent_C.TabIndex = 4;
      this.lblTitleVent_C.Text = "Vent Delta P";
      this.lblTitleVent_C.TextAlignment = StringAlignment.Far;
      this.lblMeasPressure_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasPressure_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasPressure_C.Dock = DockStyle.Fill;
      this.lblMeasPressure_C.ForeColor = Color.Black;
      LabelX lblMeasPressureC1 = this.lblMeasPressure_C;
      point1 = new Point(151, 24);
      Point point27 = point1;
      lblMeasPressureC1.Location = point27;
      LabelX lblMeasPressureC2 = this.lblMeasPressure_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding21 = padding1;
      lblMeasPressureC2.Margin = padding21;
      this.lblMeasPressure_C.Name = "lblMeasPressure_C";
      this.lblMeasPressure_C.PaddingLeft = 3;
      this.lblMeasPressure_C.PaddingRight = 3;
      LabelX lblMeasPressureC3 = this.lblMeasPressure_C;
      size1 = new Size(97, 24);
      Size size27 = size1;
      lblMeasPressureC3.Size = size27;
      this.lblMeasPressure_C.TabIndex = 5;
      this.lblMeasPressure_C.Text = "LabelX4";
      this.lblMeasPressure_C.TextAlignment = StringAlignment.Center;
      this.lblMeasLeak_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasLeak_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasLeak_C.Dock = DockStyle.Fill;
      this.lblMeasLeak_C.ForeColor = Color.Black;
      LabelX lblMeasLeakC1 = this.lblMeasLeak_C;
      point1 = new Point(151, 48);
      Point point28 = point1;
      lblMeasLeakC1.Location = point28;
      LabelX lblMeasLeakC2 = this.lblMeasLeak_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding22 = padding1;
      lblMeasLeakC2.Margin = padding22;
      this.lblMeasLeak_C.Name = "lblMeasLeak_C";
      this.lblMeasLeak_C.PaddingLeft = 3;
      this.lblMeasLeak_C.PaddingRight = 3;
      LabelX lblMeasLeakC3 = this.lblMeasLeak_C;
      size1 = new Size(97, 24);
      Size size28 = size1;
      lblMeasLeakC3.Size = size28;
      this.lblMeasLeak_C.TabIndex = 6;
      this.lblMeasLeak_C.Text = "LabelX5";
      this.lblMeasLeak_C.TextAlignment = StringAlignment.Center;
      this.lblMeasVent_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblMeasVent_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblMeasVent_C.Dock = DockStyle.Fill;
      this.lblMeasVent_C.ForeColor = Color.Black;
      LabelX lblMeasVentC1 = this.lblMeasVent_C;
      point1 = new Point(151, 72);
      Point point29 = point1;
      lblMeasVentC1.Location = point29;
      LabelX lblMeasVentC2 = this.lblMeasVent_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding23 = padding1;
      lblMeasVentC2.Margin = padding23;
      this.lblMeasVent_C.Name = "lblMeasVent_C";
      this.lblMeasVent_C.PaddingLeft = 3;
      this.lblMeasVent_C.PaddingRight = 3;
      LabelX lblMeasVentC3 = this.lblMeasVent_C;
      size1 = new Size(97, 24);
      Size size29 = size1;
      lblMeasVentC3.Size = size29;
      this.lblMeasVent_C.TabIndex = 7;
      this.lblMeasVent_C.Text = "LabelX6";
      this.lblMeasVent_C.TextAlignment = StringAlignment.Center;
      this.lblSpecPressure_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecPressure_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecPressure_C.Dock = DockStyle.Fill;
      this.lblSpecPressure_C.ForeColor = Color.Black;
      LabelX lblSpecPressureC1 = this.lblSpecPressure_C;
      point1 = new Point(248, 24);
      Point point30 = point1;
      lblSpecPressureC1.Location = point30;
      LabelX lblSpecPressureC2 = this.lblSpecPressure_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding24 = padding1;
      lblSpecPressureC2.Margin = padding24;
      this.lblSpecPressure_C.Name = "lblSpecPressure_C";
      this.lblSpecPressure_C.PaddingLeft = 3;
      this.lblSpecPressure_C.PaddingRight = 3;
      LabelX lblSpecPressureC3 = this.lblSpecPressure_C;
      size1 = new Size(129, 24);
      Size size30 = size1;
      lblSpecPressureC3.Size = size30;
      this.lblSpecPressure_C.TabIndex = 8;
      this.lblSpecPressure_C.Text = "LabelX7";
      this.lblSpecPressure_C.TextAlignment = StringAlignment.Center;
      this.lblSpecLeak_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecLeak_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecLeak_C.Dock = DockStyle.Fill;
      this.lblSpecLeak_C.ForeColor = Color.Black;
      LabelX lblSpecLeakC1 = this.lblSpecLeak_C;
      point1 = new Point(248, 48);
      Point point31 = point1;
      lblSpecLeakC1.Location = point31;
      LabelX lblSpecLeakC2 = this.lblSpecLeak_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding25 = padding1;
      lblSpecLeakC2.Margin = padding25;
      this.lblSpecLeak_C.Name = "lblSpecLeak_C";
      this.lblSpecLeak_C.PaddingLeft = 3;
      this.lblSpecLeak_C.PaddingRight = 3;
      LabelX lblSpecLeakC3 = this.lblSpecLeak_C;
      size1 = new Size(129, 24);
      Size size31 = size1;
      lblSpecLeakC3.Size = size31;
      this.lblSpecLeak_C.TabIndex = 9;
      this.lblSpecLeak_C.Text = "LabelX8";
      this.lblSpecLeak_C.TextAlignment = StringAlignment.Center;
      this.lblSpecVent_C.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblSpecVent_C.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpecVent_C.Dock = DockStyle.Fill;
      this.lblSpecVent_C.ForeColor = Color.Black;
      LabelX lblSpecVentC1 = this.lblSpecVent_C;
      point1 = new Point(248, 72);
      Point point32 = point1;
      lblSpecVentC1.Location = point32;
      LabelX lblSpecVentC2 = this.lblSpecVent_C;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding26 = padding1;
      lblSpecVentC2.Margin = padding26;
      this.lblSpecVent_C.Name = "lblSpecVent_C";
      this.lblSpecVent_C.PaddingLeft = 3;
      this.lblSpecVent_C.PaddingRight = 3;
      LabelX lblSpecVentC3 = this.lblSpecVent_C;
      size1 = new Size(129, 24);
      Size size32 = size1;
      lblSpecVentC3.Size = size32;
      this.lblSpecVent_C.TabIndex = 10;
      this.lblSpecVent_C.Text = "LabelX9";
      this.lblSpecVent_C.TextAlignment = StringAlignment.Center;
      this.LabelX16.BackColor = Color.Transparent;
      this.LabelX16.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX16.Dock = DockStyle.Fill;
      this.LabelX16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX16.ForeColor = Color.Black;
      LabelX labelX16_1 = this.LabelX16;
      point1 = new Point(3, 3);
      Point point33 = point1;
      labelX16_1.Location = point33;
      this.LabelX16.Name = "LabelX16";
      this.LabelX16.PaddingLeft = 3;
      this.LabelX16.PaddingRight = 3;
      LabelX labelX16_2 = this.LabelX16;
      size1 = new Size(145, 18);
      Size size33 = size1;
      labelX16_2.Size = size33;
      this.LabelX16.TabIndex = 11;
      this.LabelX16.Text = "Metric";
      this.LabelX16.TextAlignment = StringAlignment.Far;
      this.LabelX17.BackColor = Color.Transparent;
      this.LabelX17.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX17.Dock = DockStyle.Fill;
      this.LabelX17.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX17.ForeColor = Color.Black;
      LabelX labelX17_1 = this.LabelX17;
      point1 = new Point(154, 3);
      Point point34 = point1;
      labelX17_1.Location = point34;
      this.LabelX17.Name = "LabelX17";
      this.LabelX17.PaddingLeft = 3;
      this.LabelX17.PaddingRight = 3;
      LabelX labelX17_2 = this.LabelX17;
      size1 = new Size(91, 18);
      Size size34 = size1;
      labelX17_2.Size = size34;
      this.LabelX17.TabIndex = 12;
      this.LabelX17.Text = "Measure Value";
      this.LabelX17.TextAlignment = StringAlignment.Center;
      this.LabelX18.BackColor = Color.Transparent;
      this.LabelX18.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX18.Dock = DockStyle.Fill;
      this.LabelX18.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.LabelX18.ForeColor = Color.Black;
      LabelX labelX18_1 = this.LabelX18;
      point1 = new Point(251, 3);
      Point point35 = point1;
      labelX18_1.Location = point35;
      this.LabelX18.Name = "LabelX18";
      this.LabelX18.PaddingLeft = 3;
      this.LabelX18.PaddingRight = 3;
      LabelX labelX18_2 = this.LabelX18;
      size1 = new Size(123, 18);
      Size size35 = size1;
      labelX18_2.Size = size35;
      this.LabelX18.TabIndex = 13;
      this.LabelX18.Text = "Specs";
      this.LabelX18.TextAlignment = StringAlignment.Center;
      this.TableLayoutPanel4.BackColor = Color.Transparent;
      this.TableLayoutPanel4.ColumnCount = 2;
      this.TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel4.Controls.Add((Control) this.FlowLayoutPanel1, 0, 1);
      this.TableLayoutPanel4.Controls.Add((Control) this.Chart1, 0, 0);
      this.TableLayoutPanel4.Controls.Add((Control) this.Chart2, 1, 0);
      this.TableLayoutPanel4.Controls.Add((Control) this.GroupPanel1, 0, 2);
      this.TableLayoutPanel4.Controls.Add((Control) this.GroupPanel2, 1, 2);
      this.TableLayoutPanel4.Dock = DockStyle.Fill;
      this.TableLayoutPanel4.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel4_1 = this.TableLayoutPanel4;
      point1 = new Point(3, 0);
      Point point36 = point1;
      tableLayoutPanel4_1.Location = point36;
      this.TableLayoutPanel4.Name = "TableLayoutPanel4";
      this.TableLayoutPanel4.RowCount = 3;
      this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 141f));
      this.TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      TableLayoutPanel tableLayoutPanel4_2 = this.TableLayoutPanel4;
      size1 = new Size(838, 427);
      Size size36 = size1;
      tableLayoutPanel4_2.Size = size36;
      this.TableLayoutPanel4.TabIndex = 5;
      this.FlowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.FlowLayoutPanel1.AutoSize = true;
      this.FlowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.FlowLayoutPanel1.BackColor = Color.FromArgb(211, 211, 211);
      this.TableLayoutPanel4.SetColumnSpan((Control) this.FlowLayoutPanel1, 2);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_TestInfo);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_TestID);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_Date);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_Time);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_Serial);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_RunNum);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_FUELRev);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_ScriptRev);
      this.FlowLayoutPanel1.Controls.Add((Control) this.lblHidden_Product);
      this.FlowLayoutPanel1.ForeColor = Color.Black;
      FlowLayoutPanel flowLayoutPanel1_1 = this.FlowLayoutPanel1;
      point1 = new Point(3, 270);
      Point point37 = point1;
      flowLayoutPanel1_1.Location = point37;
      this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
      FlowLayoutPanel flowLayoutPanel1_2 = this.FlowLayoutPanel1;
      size1 = new Size(832, 13);
      Size size37 = size1;
      flowLayoutPanel1_2.Size = size37;
      this.FlowLayoutPanel1.TabIndex = 8;
      this.lblHidden_TestInfo.AutoSize = true;
      this.lblHidden_TestInfo.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_TestInfo.ForeColor = Color.Black;
      Label lblHiddenTestInfo1 = this.lblHidden_TestInfo;
      point1 = new Point(3, 0);
      Point point38 = point1;
      lblHiddenTestInfo1.Location = point38;
      Label lblHiddenTestInfo2 = this.lblHidden_TestInfo;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding27 = padding1;
      lblHiddenTestInfo2.Margin = padding27;
      this.lblHidden_TestInfo.Name = "lblHidden_TestInfo";
      Label lblHiddenTestInfo3 = this.lblHidden_TestInfo;
      size1 = new Size(52, 13);
      Size size38 = size1;
      lblHiddenTestInfo3.Size = size38;
      this.lblHidden_TestInfo.TabIndex = 8;
      this.lblHidden_TestInfo.Text = "Test Info:";
      this.lblHidden_TestInfo.Visible = false;
      this.lblHidden_TestID.AutoSize = true;
      this.lblHidden_TestID.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_TestID.ForeColor = Color.Black;
      Label lblHiddenTestId1 = this.lblHidden_TestID;
      point1 = new Point(63, 0);
      Point point39 = point1;
      lblHiddenTestId1.Location = point39;
      Label lblHiddenTestId2 = this.lblHidden_TestID;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding28 = padding1;
      lblHiddenTestId2.Margin = padding28;
      this.lblHidden_TestID.Name = "lblHidden_TestID";
      Label lblHiddenTestId3 = this.lblHidden_TestID;
      size1 = new Size(39, 13);
      Size size39 = size1;
      lblHiddenTestId3.Size = size39;
      this.lblHidden_TestID.TabIndex = 0;
      this.lblHidden_TestID.Text = "TestID";
      this.lblHidden_TestID.Visible = false;
      this.lblHidden_Date.AutoSize = true;
      this.lblHidden_Date.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_Date.ForeColor = Color.Black;
      Label lblHiddenDate1 = this.lblHidden_Date;
      point1 = new Point(110, 0);
      Point point40 = point1;
      lblHiddenDate1.Location = point40;
      Label lblHiddenDate2 = this.lblHidden_Date;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding29 = padding1;
      lblHiddenDate2.Margin = padding29;
      this.lblHidden_Date.Name = "lblHidden_Date";
      Label lblHiddenDate3 = this.lblHidden_Date;
      size1 = new Size(30, 13);
      Size size40 = size1;
      lblHiddenDate3.Size = size40;
      this.lblHidden_Date.TabIndex = 1;
      this.lblHidden_Date.Text = "Date";
      this.lblHidden_Date.Visible = false;
      this.lblHidden_Time.AutoSize = true;
      this.lblHidden_Time.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_Time.ForeColor = Color.Black;
      Label lblHiddenTime1 = this.lblHidden_Time;
      point1 = new Point(148, 0);
      Point point41 = point1;
      lblHiddenTime1.Location = point41;
      Label lblHiddenTime2 = this.lblHidden_Time;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding30 = padding1;
      lblHiddenTime2.Margin = padding30;
      this.lblHidden_Time.Name = "lblHidden_Time";
      Label lblHiddenTime3 = this.lblHidden_Time;
      size1 = new Size(30, 13);
      Size size41 = size1;
      lblHiddenTime3.Size = size41;
      this.lblHidden_Time.TabIndex = 2;
      this.lblHidden_Time.Text = "Time";
      this.lblHidden_Time.Visible = false;
      this.lblHidden_Serial.AutoSize = true;
      this.lblHidden_Serial.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_Serial.ForeColor = Color.Black;
      Label lblHiddenSerial1 = this.lblHidden_Serial;
      point1 = new Point(186, 0);
      Point point42 = point1;
      lblHiddenSerial1.Location = point42;
      Label lblHiddenSerial2 = this.lblHidden_Serial;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding31 = padding1;
      lblHiddenSerial2.Margin = padding31;
      this.lblHidden_Serial.Name = "lblHidden_Serial";
      Label lblHiddenSerial3 = this.lblHidden_Serial;
      size1 = new Size(33, 13);
      Size size42 = size1;
      lblHiddenSerial3.Size = size42;
      this.lblHidden_Serial.TabIndex = 3;
      this.lblHidden_Serial.Text = "Serial";
      this.lblHidden_Serial.Visible = false;
      this.lblHidden_RunNum.AutoSize = true;
      this.lblHidden_RunNum.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_RunNum.ForeColor = Color.Black;
      Label lblHiddenRunNum1 = this.lblHidden_RunNum;
      point1 = new Point(227, 0);
      Point point43 = point1;
      lblHiddenRunNum1.Location = point43;
      Label lblHiddenRunNum2 = this.lblHidden_RunNum;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding32 = padding1;
      lblHiddenRunNum2.Margin = padding32;
      this.lblHidden_RunNum.Name = "lblHidden_RunNum";
      Label lblHiddenRunNum3 = this.lblHidden_RunNum;
      size1 = new Size(49, 13);
      Size size43 = size1;
      lblHiddenRunNum3.Size = size43;
      this.lblHidden_RunNum.TabIndex = 4;
      this.lblHidden_RunNum.Text = "RunNum";
      this.lblHidden_RunNum.Visible = false;
      this.lblHidden_FUELRev.AutoSize = true;
      this.lblHidden_FUELRev.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_FUELRev.ForeColor = Color.Black;
      Label lblHiddenFuelRev1 = this.lblHidden_FUELRev;
      point1 = new Point(284, 0);
      Point point44 = point1;
      lblHiddenFuelRev1.Location = point44;
      Label lblHiddenFuelRev2 = this.lblHidden_FUELRev;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding33 = padding1;
      lblHiddenFuelRev2.Margin = padding33;
      this.lblHidden_FUELRev.Name = "lblHidden_FUELRev";
      Label lblHiddenFuelRev3 = this.lblHidden_FUELRev;
      size1 = new Size(54, 13);
      Size size44 = size1;
      lblHiddenFuelRev3.Size = size44;
      this.lblHidden_FUELRev.TabIndex = 5;
      this.lblHidden_FUELRev.Text = "FUELRev";
      this.lblHidden_FUELRev.Visible = false;
      this.lblHidden_ScriptRev.AutoSize = true;
      this.lblHidden_ScriptRev.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_ScriptRev.ForeColor = Color.Black;
      Label lblHiddenScriptRev1 = this.lblHidden_ScriptRev;
      point1 = new Point(346, 0);
      Point point45 = point1;
      lblHiddenScriptRev1.Location = point45;
      Label lblHiddenScriptRev2 = this.lblHidden_ScriptRev;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding34 = padding1;
      lblHiddenScriptRev2.Margin = padding34;
      this.lblHidden_ScriptRev.Name = "lblHidden_ScriptRev";
      Label lblHiddenScriptRev3 = this.lblHidden_ScriptRev;
      size1 = new Size(54, 13);
      Size size45 = size1;
      lblHiddenScriptRev3.Size = size45;
      this.lblHidden_ScriptRev.TabIndex = 6;
      this.lblHidden_ScriptRev.Text = "ScriptRev";
      this.lblHidden_ScriptRev.Visible = false;
      this.lblHidden_Product.AutoSize = true;
      this.lblHidden_Product.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblHidden_Product.ForeColor = Color.Black;
      Label lblHiddenProduct1 = this.lblHidden_Product;
      point1 = new Point(408, 0);
      Point point46 = point1;
      lblHiddenProduct1.Location = point46;
      Label lblHiddenProduct2 = this.lblHidden_Product;
      padding1 = new System.Windows.Forms.Padding(3, 0, 5, 0);
      System.Windows.Forms.Padding padding35 = padding1;
      lblHiddenProduct2.Margin = padding35;
      this.lblHidden_Product.Name = "lblHidden_Product";
      Label lblHiddenProduct3 = this.lblHidden_Product;
      size1 = new Size(44, 13);
      Size size46 = size1;
      lblHiddenProduct3.Size = size46;
      this.lblHidden_Product.TabIndex = 7;
      this.lblHidden_Product.Text = "Product";
      this.lblHidden_Product.Visible = false;
      this.Chart1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      chartArea1.AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
      chartArea1.AxisX.Title = "Time";
      chartArea1.AxisY.Minimum = -20.0;
      chartArea1.AxisY.Title = "Pressure (in. of water)";
      chartArea1.BackColor = Color.Transparent;
      chartArea1.IsSameFontSizeForAllAxes = true;
      chartArea1.Name = "ChartArea1";
      this.Chart1.ChartAreas.Add(chartArea1);
      this.Chart1.Dock = DockStyle.Fill;
      Chart chart1_1 = this.Chart1;
      point1 = new Point(0, 0);
      Point point47 = point1;
      chart1_1.Location = point47;
      Chart chart1_2 = this.Chart1;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding36 = padding1;
      chart1_2.Margin = padding36;
      this.Chart1.Name = "Chart1";
      Chart chart1_3 = this.Chart1;
      size1 = new Size(419, 266);
      Size size47 = size1;
      chart1_3.Size = size47;
      this.Chart1.TabIndex = 5;
      this.Chart1.Text = "Chart1";
      title1.Alignment = ContentAlignment.TopCenter;
      title1.DockedToChartArea = "ChartArea1";
      title1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      title1.IsDockedInsideChartArea = false;
      title1.Name = "Title1";
      title1.Text = "Black Pressure";
      this.Chart1.Titles.Add(title1);
      this.Chart2.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      chartArea2.AxisX.MajorTickMark.Enabled = false;
      chartArea2.AxisX.MinorGrid.LineColor = Color.Gray;
      chartArea2.AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.NotSet;
      chartArea2.AxisX.Title = "Time";
      chartArea2.AxisY.Title = "Pressure (in. of water)";
      chartArea2.BackColor = Color.Transparent;
      chartArea2.IsSameFontSizeForAllAxes = true;
      chartArea2.Name = "ChartArea1";
      this.Chart2.ChartAreas.Add(chartArea2);
      this.Chart2.Dock = DockStyle.Fill;
      Chart chart2_1 = this.Chart2;
      point1 = new Point(419, 0);
      Point point48 = point1;
      chart2_1.Location = point48;
      Chart chart2_2 = this.Chart2;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding37 = padding1;
      chart2_2.Margin = padding37;
      this.Chart2.Name = "Chart2";
      Chart chart2_3 = this.Chart2;
      size1 = new Size(419, 266);
      Size size48 = size1;
      chart2_3.Size = size48;
      this.Chart2.TabIndex = 6;
      title2.Alignment = ContentAlignment.TopCenter;
      title2.DockedToChartArea = "ChartArea1";
      title2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      title2.IsDockedInsideChartArea = false;
      title2.Name = "Title1";
      title2.Text = "Color Pressure";
      this.Chart2.Titles.Add(title2);
      this.MetroShell1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.MetroShell1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square;
      this.MetroShell1.CanCustomize = false;
      this.MetroShell1.CaptionVisible = true;
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel4);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel2);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel1);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel6);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel5);
      this.MetroShell1.Controls.Add((Control) this.MetroTabPanel3);
      this.MetroShell1.ForeColor = Color.Black;
      this.MetroShell1.HelpButtonText = (string) null;
      this.MetroShell1.HelpButtonVisible = false;
      this.MetroShell1.Items.AddRange(new BaseItem[8]
      {
        (BaseItem) this.MetroAppButton1,
        (BaseItem) this.MetroTabItem1,
        (BaseItem) this.MetroTabItem2,
        (BaseItem) this.MetroTabItem4,
        (BaseItem) this.MetroTabItem3,
        (BaseItem) this.tabTriage,
        (BaseItem) this.tabHelp,
        (BaseItem) this.ButtonItem4
      });
      this.MetroShell1.KeyTipsFont = new Font("Tahoma", 7f);
      MetroShell metroShell1_1 = this.MetroShell1;
      point1 = new Point(0, 0);
      Point point49 = point1;
      metroShell1_1.Location = point49;
      MetroShell metroShell1_2 = this.MetroShell1;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding38 = padding1;
      metroShell1_2.Margin = padding38;
      this.MetroShell1.Name = "MetroShell1";
      this.MetroShell1.QuickToolbarItems.AddRange(new BaseItem[1]
      {
        (BaseItem) this.ButtonItem1
      });
      this.MetroShell1.SettingsButtonVisible = false;
      MetroShell metroShell1_3 = this.MetroShell1;
      size1 = new Size(844, 481);
      Size size49 = size1;
      metroShell1_3.Size = size49;
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
      this.MetroShell1.TabIndex = 6;
      this.MetroShell1.TabStripFont = new Font("Segoe UI", 10.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.MetroShell1.Text = "Priming Systems Test";
      this.MetroShell1.TitleText = "Priming Systems Test";
      this.MetroShell1.UseCustomizeDialog = false;
      this.MetroTabPanel1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_Run);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_TestID);
      this.MetroTabPanel1.Controls.Add((Control) this.PictureBox1);
      this.MetroTabPanel1.Controls.Add((Control) this.ReflectionLabel4);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_ScriptProduct);
      this.MetroTabPanel1.Controls.Add((Control) this.lstSummaryMechChecks);
      this.MetroTabPanel1.Controls.Add((Control) this.LabelX1);
      this.MetroTabPanel1.Controls.Add((Control) this.lblFailModes);
      this.MetroTabPanel1.Controls.Add((Control) this.ReflectionLabel5);
      this.MetroTabPanel1.Controls.Add((Control) this.ReflectionLabel3);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_PSTColor);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_PSTBlack);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_EngPgCnt);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_FW);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_SerialNum);
      this.MetroTabPanel1.Controls.Add((Control) this.ReflectionLabel1);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_TestTime);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_TestDate);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_ScriptRev);
      this.MetroTabPanel1.Controls.Add((Control) this.lblSummary_FuelRev);
      this.MetroTabPanel1.Controls.Add((Control) this.ReflectionLabel2);
      this.MetroTabPanel1.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel1_1 = this.MetroTabPanel1;
      point1 = new Point(0, 51);
      Point point50 = point1;
      metroTabPanel1_1.Location = point50;
      this.MetroTabPanel1.Name = "MetroTabPanel1";
      MetroTabPanel metroTabPanel1_2 = this.MetroTabPanel1;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding39 = padding1;
      metroTabPanel1_2.Padding = padding39;
      MetroTabPanel metroTabPanel1_3 = this.MetroTabPanel1;
      size1 = new Size(844, 430);
      Size size50 = size1;
      metroTabPanel1_3.Size = size50;
      this.MetroTabPanel1.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel1.TabIndex = 1;
      this.MetroTabPanel1.Visible = false;
      this.lblSummary_Run.BackColor = Color.Transparent;
      this.lblSummary_Run.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_Run.ForeColor = Color.Black;
      LabelX lblSummaryRun1 = this.lblSummary_Run;
      point1 = new Point(12, 178);
      Point point51 = point1;
      lblSummaryRun1.Location = point51;
      this.lblSummary_Run.Name = "lblSummary_Run";
      LabelX lblSummaryRun2 = this.lblSummary_Run;
      size1 = new Size(175, 23);
      Size size51 = size1;
      lblSummaryRun2.Size = size51;
      this.lblSummary_Run.TabIndex = 37;
      this.lblSummary_Run.Text = "Run";
      this.lblSummary_TestID.BackColor = Color.Transparent;
      this.lblSummary_TestID.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_TestID.ForeColor = Color.Black;
      LabelX lblSummaryTestId1 = this.lblSummary_TestID;
      point1 = new Point(12, 155);
      Point point52 = point1;
      lblSummaryTestId1.Location = point52;
      this.lblSummary_TestID.Name = "lblSummary_TestID";
      LabelX lblSummaryTestId2 = this.lblSummary_TestID;
      size1 = new Size(175, 23);
      Size size52 = size1;
      lblSummaryTestId2.Size = size52;
      this.lblSummary_TestID.TabIndex = 36;
      this.lblSummary_TestID.Text = "Test ID";
      this.PictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.PictureBox1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.PictureBox1.ForeColor = Color.Black;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      PictureBox pictureBox1_1 = this.PictureBox1;
      point1 = new Point(459, 341);
      Point point53 = point1;
      pictureBox1_1.Location = point53;
      this.PictureBox1.Name = "PictureBox1";
      PictureBox pictureBox1_2 = this.PictureBox1;
      size1 = new Size(77, 83);
      Size size53 = size1;
      pictureBox1_2.Size = size53;
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 22;
      this.PictureBox1.TabStop = false;
      this.ReflectionLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.ReflectionLabel4.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.ReflectionLabel4.BackgroundStyle.CornerType = eCornerType.Square;
      this.ReflectionLabel4.ForeColor = Color.Black;
      ReflectionLabel reflectionLabel4_1 = this.ReflectionLabel4;
      point1 = new Point(542, 341);
      Point point54 = point1;
      reflectionLabel4_1.Location = point54;
      this.ReflectionLabel4.Name = "ReflectionLabel4";
      ReflectionLabel reflectionLabel4_2 = this.ReflectionLabel4;
      size1 = new Size(299, 83);
      Size size54 = size1;
      reflectionLabel4_2.Size = size54;
      this.ReflectionLabel4.TabIndex = 21;
      this.ReflectionLabel4.Text = "<b><font size=\"+15\">Test Status: <font color=\"#009303\">Passed</font></font></b>";
      this.lblSummary_ScriptProduct.BackColor = Color.Transparent;
      this.lblSummary_ScriptProduct.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_ScriptProduct.ForeColor = Color.Black;
      LabelX summaryScriptProduct1 = this.lblSummary_ScriptProduct;
      point1 = new Point(12, 86);
      Point point55 = point1;
      summaryScriptProduct1.Location = point55;
      this.lblSummary_ScriptProduct.Name = "lblSummary_ScriptProduct";
      LabelX summaryScriptProduct2 = this.lblSummary_ScriptProduct;
      size1 = new Size(175, 23);
      Size size55 = size1;
      summaryScriptProduct2.Size = size55;
      this.lblSummary_ScriptProduct.TabIndex = 35;
      this.lblSummary_ScriptProduct.Text = "Script Product";
      this.lstSummaryMechChecks.Activation = ItemActivation.OneClick;
      this.lstSummaryMechChecks.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lstSummaryMechChecks.Border.BorderBottom = eStyleBorderType.Solid;
      this.lstSummaryMechChecks.Border.BorderColor = Color.FromArgb(180, 180, 141);
      this.lstSummaryMechChecks.Border.BorderLeft = eStyleBorderType.Solid;
      this.lstSummaryMechChecks.Border.BorderRight = eStyleBorderType.Solid;
      this.lstSummaryMechChecks.Border.BorderTop = eStyleBorderType.Solid;
      this.lstSummaryMechChecks.Border.Class = "ListViewBorder";
      this.lstSummaryMechChecks.Border.CornerDiameter = 0;
      this.lstSummaryMechChecks.Border.CornerType = eCornerType.Square;
      this.lstSummaryMechChecks.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader2
      });
      this.lstSummaryMechChecks.Cursor = Cursors.Default;
      this.lstSummaryMechChecks.DisabledBackColor = Color.Empty;
      this.lstSummaryMechChecks.ForeColor = Color.Black;
      this.lstSummaryMechChecks.HeaderStyle = ColumnHeaderStyle.None;
      this.lstSummaryMechChecks.HotTracking = true;
      this.lstSummaryMechChecks.HoverSelection = true;
      ListViewEx summaryMechChecks1 = this.lstSummaryMechChecks;
      point1 = new Point(248, 151);
      Point point56 = point1;
      summaryMechChecks1.Location = point56;
      this.lstSummaryMechChecks.MultiSelect = false;
      this.lstSummaryMechChecks.Name = "lstSummaryMechChecks";
      ListViewEx summaryMechChecks2 = this.lstSummaryMechChecks;
      size1 = new Size(211, 259);
      Size size56 = size1;
      summaryMechChecks2.Size = size56;
      this.lstSummaryMechChecks.SmallImageList = this.ImageList1;
      this.lstSummaryMechChecks.TabIndex = 34;
      this.lstSummaryMechChecks.UseCompatibleStateImageBehavior = false;
      this.lstSummaryMechChecks.View = View.Details;
      this.ColumnHeader2.Text = "col2";
      this.ColumnHeader2.Width = 20;
      this.ImageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ImageList1.ImageStream");
      this.ImageList1.TransparentColor = Color.White;
      this.ImageList1.Images.SetKeyName(0, "Good-or-Tick-icon-sm.png");
      this.ImageList1.Images.SetKeyName(1, "Error-icon-sm.png");
      this.ImageList1.Images.SetKeyName(2, "warning_sm.png");
      this.LabelX1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX1.ForeColor = Color.Black;
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(534, 36);
      Point point57 = point1;
      labelX1_1.Location = point57;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(304, 156);
      Size size57 = size1;
      labelX1_2.Size = size57;
      this.LabelX1.TabIndex = 24;
      this.LabelX1.Text = componentResourceManager.GetString("LabelX1.Text");
      this.LabelX1.TextLineAlignment = StringAlignment.Near;
      this.LabelX1.Visible = false;
      this.lblFailModes.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.lblFailModes.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblFailModes.ForeColor = Color.Black;
      LabelX lblFailModes1 = this.lblFailModes;
      point1 = new Point(534, 11);
      Point point58 = point1;
      lblFailModes1.Location = point58;
      this.lblFailModes.Name = "lblFailModes";
      LabelX lblFailModes2 = this.lblFailModes;
      size1 = new Size(304, 23);
      Size size58 = size1;
      lblFailModes2.Size = size58;
      this.lblFailModes.TabIndex = 23;
      this.lblFailModes.Visible = false;
      this.ReflectionLabel5.BackColor = Color.Transparent;
      this.ReflectionLabel5.BackgroundStyle.CornerType = eCornerType.Square;
      this.ReflectionLabel5.ForeColor = Color.Black;
      ReflectionLabel reflectionLabel5_1 = this.ReflectionLabel5;
      point1 = new Point(248, 113);
      Point point59 = point1;
      reflectionLabel5_1.Location = point59;
      this.ReflectionLabel5.Name = "ReflectionLabel5";
      ReflectionLabel reflectionLabel5_2 = this.ReflectionLabel5;
      size1 = new Size(218, 41);
      Size size59 = size1;
      reflectionLabel5_2.Size = size59;
      this.ReflectionLabel5.TabIndex = 5;
      this.ReflectionLabel5.Text = "<b><font size=\"+6\">Mech Check Summary</font></b>";
      this.ReflectionLabel3.BackColor = Color.Transparent;
      this.ReflectionLabel3.BackgroundStyle.CornerType = eCornerType.Square;
      this.ReflectionLabel3.ForeColor = Color.Black;
      ReflectionLabel reflectionLabel3_1 = this.ReflectionLabel3;
      point1 = new Point(12, 213);
      Point point60 = point1;
      reflectionLabel3_1.Location = point60;
      this.ReflectionLabel3.Name = "ReflectionLabel3";
      ReflectionLabel reflectionLabel3_2 = this.ReflectionLabel3;
      size1 = new Size(175, 41);
      Size size60 = size1;
      reflectionLabel3_2.Size = size60;
      this.ReflectionLabel3.TabIndex = 3;
      this.ReflectionLabel3.Text = "<b><font size=\"+6\">Prime Pressures</font></b>";
      this.lblSummary_PSTColor.BackColor = Color.Transparent;
      this.lblSummary_PSTColor.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_PSTColor.Cursor = Cursors.Hand;
      this.lblSummary_PSTColor.ForeColor = Color.Black;
      this.lblSummary_PSTColor.Image = (Image) componentResourceManager.GetObject("lblSummary_PSTColor.Image");
      LabelX lblSummaryPstColor1 = this.lblSummary_PSTColor;
      point1 = new Point(12, 274);
      Point point61 = point1;
      lblSummaryPstColor1.Location = point61;
      this.lblSummary_PSTColor.Name = "lblSummary_PSTColor";
      LabelX lblSummaryPstColor2 = this.lblSummary_PSTColor;
      size1 = new Size(175, 23);
      Size size61 = size1;
      lblSummaryPstColor2.Size = size61;
      this.lblSummary_PSTColor.TabIndex = 14;
      this.lblSummary_PSTColor.Text = "Color: Passed";
      this.lblSummary_PSTBlack.BackColor = Color.Transparent;
      this.lblSummary_PSTBlack.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_PSTBlack.Cursor = Cursors.Hand;
      this.lblSummary_PSTBlack.ForeColor = Color.Black;
      this.lblSummary_PSTBlack.Image = (Image) componentResourceManager.GetObject("lblSummary_PSTBlack.Image");
      LabelX lblSummaryPstBlack1 = this.lblSummary_PSTBlack;
      point1 = new Point(12, 251);
      Point point62 = point1;
      lblSummaryPstBlack1.Location = point62;
      this.lblSummary_PSTBlack.Name = "lblSummary_PSTBlack";
      LabelX lblSummaryPstBlack2 = this.lblSummary_PSTBlack;
      size1 = new Size(175, 23);
      Size size62 = size1;
      lblSummaryPstBlack2.Size = size62;
      this.lblSummary_PSTBlack.TabIndex = 13;
      this.lblSummary_PSTBlack.Text = "Black: Passed";
      this.lblSummary_EngPgCnt.BackColor = Color.Transparent;
      this.lblSummary_EngPgCnt.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_EngPgCnt.ForeColor = Color.Black;
      LabelX lblSummaryEngPgCnt1 = this.lblSummary_EngPgCnt;
      point1 = new Point(248, 86);
      Point point63 = point1;
      lblSummaryEngPgCnt1.Location = point63;
      this.lblSummary_EngPgCnt.Name = "lblSummary_EngPgCnt";
      LabelX lblSummaryEngPgCnt2 = this.lblSummary_EngPgCnt;
      size1 = new Size(175, 23);
      Size size63 = size1;
      lblSummaryEngPgCnt2.Size = size63;
      this.lblSummary_EngPgCnt.TabIndex = 12;
      this.lblSummary_EngPgCnt.Text = "Engine Page Count: ";
      this.lblSummary_FW.BackColor = Color.Transparent;
      this.lblSummary_FW.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_FW.ForeColor = Color.Black;
      LabelX lblSummaryFw1 = this.lblSummary_FW;
      point1 = new Point(248, 63);
      Point point64 = point1;
      lblSummaryFw1.Location = point64;
      this.lblSummary_FW.Name = "lblSummary_FW";
      LabelX lblSummaryFw2 = this.lblSummary_FW;
      size1 = new Size(175, 23);
      Size size64 = size1;
      lblSummaryFw2.Size = size64;
      this.lblSummary_FW.TabIndex = 11;
      this.lblSummary_FW.Text = "FW Rev:";
      this.lblSummary_SerialNum.BackColor = Color.Transparent;
      this.lblSummary_SerialNum.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_SerialNum.ForeColor = Color.Black;
      LabelX summarySerialNum1 = this.lblSummary_SerialNum;
      point1 = new Point(248, 40);
      Point point65 = point1;
      summarySerialNum1.Location = point65;
      this.lblSummary_SerialNum.Name = "lblSummary_SerialNum";
      LabelX summarySerialNum2 = this.lblSummary_SerialNum;
      size1 = new Size(175, 23);
      Size size65 = size1;
      summarySerialNum2.Size = size65;
      this.lblSummary_SerialNum.TabIndex = 10;
      this.lblSummary_SerialNum.Text = "Serial Number:";
      this.ReflectionLabel1.BackColor = Color.Transparent;
      this.ReflectionLabel1.BackgroundStyle.CornerType = eCornerType.Square;
      this.ReflectionLabel1.ForeColor = Color.Black;
      ReflectionLabel reflectionLabel1_1 = this.ReflectionLabel1;
      point1 = new Point(12, 3);
      Point point66 = point1;
      reflectionLabel1_1.Location = point66;
      this.ReflectionLabel1.Name = "ReflectionLabel1";
      ReflectionLabel reflectionLabel1_2 = this.ReflectionLabel1;
      size1 = new Size(175, 41);
      Size size66 = size1;
      reflectionLabel1_2.Size = size66;
      this.ReflectionLabel1.TabIndex = 1;
      this.ReflectionLabel1.Text = "<b><font size=\"+6\">Test Setup</font></b>";
      this.lblSummary_TestTime.BackColor = Color.Transparent;
      this.lblSummary_TestTime.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_TestTime.ForeColor = Color.Black;
      LabelX lblSummaryTestTime1 = this.lblSummary_TestTime;
      point1 = new Point(12, 132);
      Point point67 = point1;
      lblSummaryTestTime1.Location = point67;
      this.lblSummary_TestTime.Name = "lblSummary_TestTime";
      LabelX lblSummaryTestTime2 = this.lblSummary_TestTime;
      size1 = new Size(175, 23);
      Size size67 = size1;
      lblSummaryTestTime2.Size = size67;
      this.lblSummary_TestTime.TabIndex = 9;
      this.lblSummary_TestTime.Text = "Test Time";
      this.lblSummary_TestDate.BackColor = Color.Transparent;
      this.lblSummary_TestDate.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_TestDate.ForeColor = Color.Black;
      LabelX lblSummaryTestDate1 = this.lblSummary_TestDate;
      point1 = new Point(12, 109);
      Point point68 = point1;
      lblSummaryTestDate1.Location = point68;
      this.lblSummary_TestDate.Name = "lblSummary_TestDate";
      LabelX lblSummaryTestDate2 = this.lblSummary_TestDate;
      size1 = new Size(175, 23);
      Size size68 = size1;
      lblSummaryTestDate2.Size = size68;
      this.lblSummary_TestDate.TabIndex = 8;
      this.lblSummary_TestDate.Text = "Test Date";
      this.lblSummary_ScriptRev.BackColor = Color.Transparent;
      this.lblSummary_ScriptRev.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_ScriptRev.ForeColor = Color.Black;
      LabelX summaryScriptRev1 = this.lblSummary_ScriptRev;
      point1 = new Point(12, 63);
      Point point69 = point1;
      summaryScriptRev1.Location = point69;
      this.lblSummary_ScriptRev.Name = "lblSummary_ScriptRev";
      LabelX summaryScriptRev2 = this.lblSummary_ScriptRev;
      size1 = new Size(175, 23);
      Size size69 = size1;
      summaryScriptRev2.Size = size69;
      this.lblSummary_ScriptRev.TabIndex = 7;
      this.lblSummary_ScriptRev.Text = "Script Rev";
      this.lblSummary_FuelRev.BackColor = Color.Transparent;
      this.lblSummary_FuelRev.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSummary_FuelRev.ForeColor = Color.Black;
      LabelX lblSummaryFuelRev1 = this.lblSummary_FuelRev;
      point1 = new Point(12, 40);
      Point point70 = point1;
      lblSummaryFuelRev1.Location = point70;
      this.lblSummary_FuelRev.Name = "lblSummary_FuelRev";
      LabelX lblSummaryFuelRev2 = this.lblSummary_FuelRev;
      size1 = new Size(175, 23);
      Size size70 = size1;
      lblSummaryFuelRev2.Size = size70;
      this.lblSummary_FuelRev.TabIndex = 6;
      this.lblSummary_FuelRev.Text = "Fuel Rev";
      this.ReflectionLabel2.BackColor = Color.Transparent;
      this.ReflectionLabel2.BackgroundStyle.CornerType = eCornerType.Square;
      this.ReflectionLabel2.ForeColor = Color.Black;
      ReflectionLabel reflectionLabel2_1 = this.ReflectionLabel2;
      point1 = new Point(248, 3);
      Point point71 = point1;
      reflectionLabel2_1.Location = point71;
      this.ReflectionLabel2.Name = "ReflectionLabel2";
      ReflectionLabel reflectionLabel2_2 = this.ReflectionLabel2;
      size1 = new Size(218, 41);
      Size size71 = size1;
      reflectionLabel2_2.Size = size71;
      this.ReflectionLabel2.TabIndex = 2;
      this.ReflectionLabel2.Text = "<b><font size=\"+6\">Printer Information</font></b>";
      this.MetroTabPanel5.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel5.Controls.Add((Control) this.SuperTabControl1);
      this.MetroTabPanel5.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel5_1 = this.MetroTabPanel5;
      point1 = new Point(0, 51);
      Point point72 = point1;
      metroTabPanel5_1.Location = point72;
      this.MetroTabPanel5.Name = "MetroTabPanel5";
      MetroTabPanel metroTabPanel5_2 = this.MetroTabPanel5;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding40 = padding1;
      metroTabPanel5_2.Padding = padding40;
      MetroTabPanel metroTabPanel5_3 = this.MetroTabPanel5;
      size1 = new Size(844, 430);
      Size size72 = size1;
      metroTabPanel5_3.Size = size72;
      this.MetroTabPanel5.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel5.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel5.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel5.TabIndex = 6;
      this.MetroTabPanel5.Visible = false;
      this.SuperTabControl1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.SuperTabControl1.CloseButtonOnTabsAlwaysDisplayed = false;
      this.SuperTabControl1.ControlBox.CloseBox.Name = "";
      this.SuperTabControl1.ControlBox.MenuBox.Name = "";
      this.SuperTabControl1.ControlBox.Name = "";
      this.SuperTabControl1.ControlBox.SubItems.AddRange(new BaseItem[2]
      {
        (BaseItem) this.SuperTabControl1.ControlBox.MenuBox,
        (BaseItem) this.SuperTabControl1.ControlBox.CloseBox
      });
      this.SuperTabControl1.ControlBox.Visible = false;
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel1);
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel6);
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel3);
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel4);
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel2);
      this.SuperTabControl1.Controls.Add((Control) this.SuperTabControlPanel5);
      this.SuperTabControl1.Dock = DockStyle.Fill;
      this.SuperTabControl1.ForeColor = Color.Black;
      SuperTabControl superTabControl1_1 = this.SuperTabControl1;
      point1 = new Point(3, 0);
      Point point73 = point1;
      superTabControl1_1.Location = point73;
      this.SuperTabControl1.Name = "SuperTabControl1";
      this.SuperTabControl1.ReorderTabsEnabled = false;
      this.SuperTabControl1.SelectedTabFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.SuperTabControl1.SelectedTabIndex = 0;
      SuperTabControl superTabControl1_2 = this.SuperTabControl1;
      size1 = new Size(838, 427);
      Size size73 = size1;
      superTabControl1_2.Size = size73;
      this.SuperTabControl1.TabAlignment = eTabStripAlignment.Left;
      this.SuperTabControl1.TabFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.SuperTabControl1.TabIndex = 0;
      this.SuperTabControl1.Tabs.AddRange(new BaseItem[6]
      {
        (BaseItem) this.stiPSTDocs_Intro,
        (BaseItem) this.stiPSTDocs_Outputs,
        (BaseItem) this.stiPSTDocs_NoPressure,
        (BaseItem) this.stiPSTDocs_DelayedPressure,
        (BaseItem) this.stiPSTDocs_CyclicalPressure,
        (BaseItem) this.stiPSTDocs_PressureFluctuates
      });
      this.SuperTabControl1.TabStyle = eSuperTabStyle.Office2010BackstageBlue;
      this.SuperTabControl1.Text = "SuperTabControl1";
      this.SuperTabControlPanel1.Controls.Add((Control) this.rtbPSTDocs_Intro);
      this.SuperTabControlPanel1.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel1_1 = this.SuperTabControlPanel1;
      point1 = new Point(120, 0);
      Point point74 = point1;
      tabControlPanel1_1.Location = point74;
      this.SuperTabControlPanel1.Name = "SuperTabControlPanel1";
      SuperTabControlPanel tabControlPanel1_2 = this.SuperTabControlPanel1;
      size1 = new Size(718, 427);
      Size size74 = size1;
      tabControlPanel1_2.Size = size74;
      this.SuperTabControlPanel1.TabIndex = 1;
      this.SuperTabControlPanel1.TabItem = this.stiPSTDocs_Intro;
      this.rtbPSTDocs_Intro.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_Intro.BorderStyle = BorderStyle.FixedSingle;
      this.rtbPSTDocs_Intro.BulletIndent = 4;
      this.rtbPSTDocs_Intro.Dock = DockStyle.Fill;
      this.rtbPSTDocs_Intro.ForeColor = Color.Black;
      RichTextBox rtbPstDocsIntro1 = this.rtbPSTDocs_Intro;
      point1 = new Point(0, 0);
      Point point75 = point1;
      rtbPstDocsIntro1.Location = point75;
      this.rtbPSTDocs_Intro.Name = "rtbPSTDocs_Intro";
      this.rtbPSTDocs_Intro.ReadOnly = true;
      RichTextBox rtbPstDocsIntro2 = this.rtbPSTDocs_Intro;
      size1 = new Size(718, 427);
      Size size75 = size1;
      rtbPstDocsIntro2.Size = size75;
      this.rtbPSTDocs_Intro.TabIndex = 1;
      this.rtbPSTDocs_Intro.Text = "";
      this.stiPSTDocs_Intro.AttachedControl = (Control) this.SuperTabControlPanel1;
      this.stiPSTDocs_Intro.GlobalItem = false;
      this.stiPSTDocs_Intro.Name = "stiPSTDocs_Intro";
      this.stiPSTDocs_Intro.Text = "Introduction";
      this.SuperTabControlPanel6.Controls.Add((Control) this.rtbPSTDocs_PSTOutputs);
      this.SuperTabControlPanel6.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel6_1 = this.SuperTabControlPanel6;
      point1 = new Point(120, 0);
      Point point76 = point1;
      tabControlPanel6_1.Location = point76;
      this.SuperTabControlPanel6.Name = "SuperTabControlPanel6";
      SuperTabControlPanel tabControlPanel6_2 = this.SuperTabControlPanel6;
      size1 = new Size(718, 427);
      Size size76 = size1;
      tabControlPanel6_2.Size = size76;
      this.SuperTabControlPanel6.TabIndex = 0;
      this.SuperTabControlPanel6.TabItem = this.stiPSTDocs_Outputs;
      this.rtbPSTDocs_PSTOutputs.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_PSTOutputs.Dock = DockStyle.Fill;
      this.rtbPSTDocs_PSTOutputs.ForeColor = Color.Black;
      RichTextBox pstDocsPstOutputs1 = this.rtbPSTDocs_PSTOutputs;
      point1 = new Point(0, 0);
      Point point77 = point1;
      pstDocsPstOutputs1.Location = point77;
      this.rtbPSTDocs_PSTOutputs.Name = "rtbPSTDocs_PSTOutputs";
      RichTextBox pstDocsPstOutputs2 = this.rtbPSTDocs_PSTOutputs;
      size1 = new Size(718, 427);
      Size size77 = size1;
      pstDocsPstOutputs2.Size = size77;
      this.rtbPSTDocs_PSTOutputs.TabIndex = 0;
      this.rtbPSTDocs_PSTOutputs.Text = "";
      this.stiPSTDocs_Outputs.AttachedControl = (Control) this.SuperTabControlPanel6;
      this.stiPSTDocs_Outputs.GlobalItem = false;
      this.stiPSTDocs_Outputs.Name = "stiPSTDocs_Outputs";
      this.stiPSTDocs_Outputs.Text = "PST Outputs";
      this.SuperTabControlPanel3.Controls.Add((Control) this.rtbPSTDocs_DelayedPressure);
      this.SuperTabControlPanel3.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel3_1 = this.SuperTabControlPanel3;
      point1 = new Point(120, 0);
      Point point78 = point1;
      tabControlPanel3_1.Location = point78;
      this.SuperTabControlPanel3.Name = "SuperTabControlPanel3";
      SuperTabControlPanel tabControlPanel3_2 = this.SuperTabControlPanel3;
      size1 = new Size(718, 427);
      Size size78 = size1;
      tabControlPanel3_2.Size = size78;
      this.SuperTabControlPanel3.TabIndex = 0;
      this.SuperTabControlPanel3.TabItem = this.stiPSTDocs_DelayedPressure;
      this.rtbPSTDocs_DelayedPressure.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_DelayedPressure.Dock = DockStyle.Fill;
      this.rtbPSTDocs_DelayedPressure.ForeColor = Color.Black;
      RichTextBox docsDelayedPressure1 = this.rtbPSTDocs_DelayedPressure;
      point1 = new Point(0, 0);
      Point point79 = point1;
      docsDelayedPressure1.Location = point79;
      this.rtbPSTDocs_DelayedPressure.Name = "rtbPSTDocs_DelayedPressure";
      RichTextBox docsDelayedPressure2 = this.rtbPSTDocs_DelayedPressure;
      size1 = new Size(718, 427);
      Size size79 = size1;
      docsDelayedPressure2.Size = size79;
      this.rtbPSTDocs_DelayedPressure.TabIndex = 0;
      this.rtbPSTDocs_DelayedPressure.Text = "";
      this.stiPSTDocs_DelayedPressure.AttachedControl = (Control) this.SuperTabControlPanel3;
      this.stiPSTDocs_DelayedPressure.GlobalItem = false;
      this.stiPSTDocs_DelayedPressure.Name = "stiPSTDocs_DelayedPressure";
      this.stiPSTDocs_DelayedPressure.Text = "Delayed Pressure";
      this.SuperTabControlPanel4.Controls.Add((Control) this.rtbPSTDocs_CyclicalPressure);
      this.SuperTabControlPanel4.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel4_1 = this.SuperTabControlPanel4;
      point1 = new Point(120, 0);
      Point point80 = point1;
      tabControlPanel4_1.Location = point80;
      this.SuperTabControlPanel4.Name = "SuperTabControlPanel4";
      SuperTabControlPanel tabControlPanel4_2 = this.SuperTabControlPanel4;
      size1 = new Size(718, 427);
      Size size80 = size1;
      tabControlPanel4_2.Size = size80;
      this.SuperTabControlPanel4.TabIndex = 0;
      this.SuperTabControlPanel4.TabItem = this.stiPSTDocs_CyclicalPressure;
      this.rtbPSTDocs_CyclicalPressure.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_CyclicalPressure.Dock = DockStyle.Fill;
      this.rtbPSTDocs_CyclicalPressure.ForeColor = Color.Black;
      RichTextBox cyclicalPressure1 = this.rtbPSTDocs_CyclicalPressure;
      point1 = new Point(0, 0);
      Point point81 = point1;
      cyclicalPressure1.Location = point81;
      this.rtbPSTDocs_CyclicalPressure.Name = "rtbPSTDocs_CyclicalPressure";
      RichTextBox cyclicalPressure2 = this.rtbPSTDocs_CyclicalPressure;
      size1 = new Size(718, 427);
      Size size81 = size1;
      cyclicalPressure2.Size = size81;
      this.rtbPSTDocs_CyclicalPressure.TabIndex = 0;
      this.rtbPSTDocs_CyclicalPressure.Text = "";
      this.stiPSTDocs_CyclicalPressure.AttachedControl = (Control) this.SuperTabControlPanel4;
      this.stiPSTDocs_CyclicalPressure.GlobalItem = false;
      this.stiPSTDocs_CyclicalPressure.Name = "stiPSTDocs_CyclicalPressure";
      this.stiPSTDocs_CyclicalPressure.Text = "Cyclical Pressure";
      this.SuperTabControlPanel2.Controls.Add((Control) this.rtbPSTDocs_NoPressure);
      this.SuperTabControlPanel2.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel2_1 = this.SuperTabControlPanel2;
      point1 = new Point(120, 0);
      Point point82 = point1;
      tabControlPanel2_1.Location = point82;
      this.SuperTabControlPanel2.Name = "SuperTabControlPanel2";
      SuperTabControlPanel tabControlPanel2_2 = this.SuperTabControlPanel2;
      size1 = new Size(718, 427);
      Size size82 = size1;
      tabControlPanel2_2.Size = size82;
      this.SuperTabControlPanel2.TabIndex = 0;
      this.SuperTabControlPanel2.TabItem = this.stiPSTDocs_NoPressure;
      this.rtbPSTDocs_NoPressure.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_NoPressure.Dock = DockStyle.Fill;
      this.rtbPSTDocs_NoPressure.ForeColor = Color.Black;
      RichTextBox pstDocsNoPressure1 = this.rtbPSTDocs_NoPressure;
      point1 = new Point(0, 0);
      Point point83 = point1;
      pstDocsNoPressure1.Location = point83;
      this.rtbPSTDocs_NoPressure.Name = "rtbPSTDocs_NoPressure";
      RichTextBox pstDocsNoPressure2 = this.rtbPSTDocs_NoPressure;
      size1 = new Size(718, 427);
      Size size83 = size1;
      pstDocsNoPressure2.Size = size83;
      this.rtbPSTDocs_NoPressure.TabIndex = 0;
      this.rtbPSTDocs_NoPressure.Text = "";
      this.stiPSTDocs_NoPressure.AttachedControl = (Control) this.SuperTabControlPanel2;
      this.stiPSTDocs_NoPressure.GlobalItem = false;
      this.stiPSTDocs_NoPressure.Name = "stiPSTDocs_NoPressure";
      this.stiPSTDocs_NoPressure.Text = "No Pressure";
      this.SuperTabControlPanel5.Controls.Add((Control) this.rtbPSTDocs_PressureFluctuates);
      this.SuperTabControlPanel5.Dock = DockStyle.Fill;
      SuperTabControlPanel tabControlPanel5_1 = this.SuperTabControlPanel5;
      point1 = new Point(120, 0);
      Point point84 = point1;
      tabControlPanel5_1.Location = point84;
      this.SuperTabControlPanel5.Name = "SuperTabControlPanel5";
      SuperTabControlPanel tabControlPanel5_2 = this.SuperTabControlPanel5;
      size1 = new Size(718, 427);
      Size size84 = size1;
      tabControlPanel5_2.Size = size84;
      this.SuperTabControlPanel5.TabIndex = 2;
      this.SuperTabControlPanel5.TabItem = this.stiPSTDocs_PressureFluctuates;
      this.rtbPSTDocs_PressureFluctuates.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.rtbPSTDocs_PressureFluctuates.Dock = DockStyle.Fill;
      this.rtbPSTDocs_PressureFluctuates.ForeColor = Color.Black;
      RichTextBox pressureFluctuates1 = this.rtbPSTDocs_PressureFluctuates;
      point1 = new Point(0, 0);
      Point point85 = point1;
      pressureFluctuates1.Location = point85;
      this.rtbPSTDocs_PressureFluctuates.Name = "rtbPSTDocs_PressureFluctuates";
      RichTextBox pressureFluctuates2 = this.rtbPSTDocs_PressureFluctuates;
      size1 = new Size(718, 427);
      Size size85 = size1;
      pressureFluctuates2.Size = size85;
      this.rtbPSTDocs_PressureFluctuates.TabIndex = 0;
      this.rtbPSTDocs_PressureFluctuates.Text = "";
      this.stiPSTDocs_PressureFluctuates.AttachedControl = (Control) this.SuperTabControlPanel5;
      this.stiPSTDocs_PressureFluctuates.GlobalItem = false;
      this.stiPSTDocs_PressureFluctuates.Name = "stiPSTDocs_PressureFluctuates";
      this.stiPSTDocs_PressureFluctuates.Text = "Pressure Fluctuates";
      this.MetroTabPanel6.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel6.Controls.Add((Control) this.ButtonX2);
      this.MetroTabPanel6.Controls.Add((Control) this.ButtonX1);
      this.MetroTabPanel6.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel6_1 = this.MetroTabPanel6;
      point1 = new Point(0, 51);
      Point point86 = point1;
      metroTabPanel6_1.Location = point86;
      this.MetroTabPanel6.Name = "MetroTabPanel6";
      MetroTabPanel metroTabPanel6_2 = this.MetroTabPanel6;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding41 = padding1;
      metroTabPanel6_2.Padding = padding41;
      MetroTabPanel metroTabPanel6_3 = this.MetroTabPanel6;
      size1 = new Size(844, 430);
      Size size86 = size1;
      metroTabPanel6_3.Size = size86;
      this.MetroTabPanel6.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel6.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel6.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel6.TabIndex = 7;
      this.MetroTabPanel6.Visible = false;
      this.ButtonX2.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX2.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX buttonX2_1 = this.ButtonX2;
      point1 = new Point(13, 46);
      Point point87 = point1;
      buttonX2_1.Location = point87;
      this.ButtonX2.Name = "ButtonX2";
      ButtonX buttonX2_2 = this.ButtonX2;
      size1 = new Size(75, 23);
      Size size87 = size1;
      buttonX2_2.Size = size87;
      this.ButtonX2.Style = eDotNetBarStyle.StyleManagerControlled;
      this.ButtonX2.TabIndex = 1;
      this.ButtonX2.Text = "ButtonX2";
      this.ButtonX1.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX1.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX buttonX1_1 = this.ButtonX1;
      point1 = new Point(10, 11);
      Point point88 = point1;
      buttonX1_1.Location = point88;
      this.ButtonX1.Name = "ButtonX1";
      ButtonX buttonX1_2 = this.ButtonX1;
      size1 = new Size(75, 23);
      Size size88 = size1;
      buttonX1_2.Size = size88;
      this.ButtonX1.Style = eDotNetBarStyle.StyleManagerControlled;
      this.ButtonX1.TabIndex = 0;
      this.ButtonX1.Text = "ButtonX1";
      this.MetroTabPanel2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel2.Controls.Add((Control) this.TableLayoutPanel4);
      this.MetroTabPanel2.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel2_1 = this.MetroTabPanel2;
      point1 = new Point(0, 51);
      Point point89 = point1;
      metroTabPanel2_1.Location = point89;
      this.MetroTabPanel2.Name = "MetroTabPanel2";
      MetroTabPanel metroTabPanel2_2 = this.MetroTabPanel2;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding42 = padding1;
      metroTabPanel2_2.Padding = padding42;
      MetroTabPanel metroTabPanel2_3 = this.MetroTabPanel2;
      size1 = new Size(844, 430);
      Size size89 = size1;
      metroTabPanel2_3.Size = size89;
      this.MetroTabPanel2.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel2.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel2.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel2.TabIndex = 2;
      this.MetroTabPanel2.Visible = false;
      this.MetroTabPanel4.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel4.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel4_1 = this.MetroTabPanel4;
      point1 = new Point(0, 51);
      Point point90 = point1;
      metroTabPanel4_1.Location = point90;
      this.MetroTabPanel4.Name = "MetroTabPanel4";
      MetroTabPanel metroTabPanel4_2 = this.MetroTabPanel4;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding43 = padding1;
      metroTabPanel4_2.Padding = padding43;
      MetroTabPanel metroTabPanel4_3 = this.MetroTabPanel4;
      size1 = new Size(844, 430);
      Size size90 = size1;
      metroTabPanel4_3.Size = size90;
      this.MetroTabPanel4.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel4.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel4.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel4.TabIndex = 4;
      this.MetroTabPanel3.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled;
      this.MetroTabPanel3.Controls.Add((Control) this.TableLayoutPanel5);
      this.MetroTabPanel3.Dock = DockStyle.Fill;
      MetroTabPanel metroTabPanel3_1 = this.MetroTabPanel3;
      point1 = new Point(0, 51);
      Point point91 = point1;
      metroTabPanel3_1.Location = point91;
      this.MetroTabPanel3.Name = "MetroTabPanel3";
      MetroTabPanel metroTabPanel3_2 = this.MetroTabPanel3;
      padding1 = new System.Windows.Forms.Padding(3, 0, 3, 3);
      System.Windows.Forms.Padding padding44 = padding1;
      metroTabPanel3_2.Padding = padding44;
      MetroTabPanel metroTabPanel3_3 = this.MetroTabPanel3;
      size1 = new Size(844, 430);
      Size size91 = size1;
      metroTabPanel3_3.Size = size91;
      this.MetroTabPanel3.Style.CornerType = eCornerType.Square;
      this.MetroTabPanel3.StyleMouseDown.CornerType = eCornerType.Square;
      this.MetroTabPanel3.StyleMouseOver.CornerType = eCornerType.Square;
      this.MetroTabPanel3.TabIndex = 5;
      this.MetroTabPanel3.Visible = false;
      this.TableLayoutPanel5.BackColor = Color.Transparent;
      this.TableLayoutPanel5.ColumnCount = 3;
      this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145f));
      this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145f));
      this.TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
      this.TableLayoutPanel5.Controls.Add((Control) this.cmdDataSelect, 0, 0);
      this.TableLayoutPanel5.Controls.Add((Control) this.Chart3, 2, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.Chart4, 2, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.lblHistory_TotalUnits, 0, 18);
      this.TableLayoutPanel5.Controls.Add((Control) this.cboRunCharts, 0, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.sgcHistory, 0, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.cboHistory_XVal, 0, 2);
      this.TableLayoutPanel5.Controls.Add((Control) this.cboHistory_YVal, 1, 2);
      this.TableLayoutPanel5.Controls.Add((Control) this.cboHistory_Series, 0, 4);
      this.TableLayoutPanel5.Controls.Add((Control) this.lblHistory_XVal, 0, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.lblHistory_YVal, 1, 1);
      this.TableLayoutPanel5.Controls.Add((Control) this.lblHistory_Series, 0, 3);
      this.TableLayoutPanel5.Controls.Add((Control) this.cmdHistory_ChartIt, 1, 4);
      this.TableLayoutPanel5.Controls.Add((Control) this.cmdHistory_DataGrid_Edit, 0, 17);
      this.TableLayoutPanel5.Dock = DockStyle.Fill;
      this.TableLayoutPanel5.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel5_1 = this.TableLayoutPanel5;
      point1 = new Point(3, 0);
      Point point92 = point1;
      tableLayoutPanel5_1.Location = point92;
      TableLayoutPanel tableLayoutPanel5_2 = this.TableLayoutPanel5;
      padding1 = new System.Windows.Forms.Padding(0);
      System.Windows.Forms.Padding padding45 = padding1;
      tableLayoutPanel5_2.Margin = padding45;
      this.TableLayoutPanel5.Name = "TableLayoutPanel5";
      this.TableLayoutPanel5.RowCount = 5;
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 35f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      TableLayoutPanel tableLayoutPanel5_3 = this.TableLayoutPanel5;
      size1 = new Size(838, 427);
      Size size92 = size1;
      tableLayoutPanel5_3.Size = size92;
      this.TableLayoutPanel5.TabIndex = 2;
      this.cmdDataSelect.AccessibleRole = AccessibleRole.PushButton;
      this.cmdDataSelect.AutoExpandOnClick = true;
      this.cmdDataSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.cmdDataSelect.ColorTable = eButtonColor.OrangeWithBackground;
      this.TableLayoutPanel5.SetColumnSpan((Control) this.cmdDataSelect, 2);
      this.cmdDataSelect.Cursor = Cursors.Hand;
      this.cmdDataSelect.Dock = DockStyle.Fill;
      ButtonX cmdDataSelect1 = this.cmdDataSelect;
      point1 = new Point(3, 3);
      Point point93 = point1;
      cmdDataSelect1.Location = point93;
      this.cmdDataSelect.Name = "cmdDataSelect";
      this.cmdDataSelect.PopupSide = ePopupSide.Right;
      this.cmdDataSelect.Shape = (ShapeDescriptor) new RoundRectangleShapeDescriptor(6);
      ButtonX cmdDataSelect2 = this.cmdDataSelect;
      size1 = new Size(284, 29);
      Size size93 = size1;
      cmdDataSelect2.Size = size93;
      this.cmdDataSelect.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdDataSelect.SubItems.AddRange(new BaseItem[3]
      {
        (BaseItem) this.cmdShowRuncharts,
        (BaseItem) this.cmdShowRegularcharts,
        (BaseItem) this.cmdShowDataGrid
      });
      this.cmdDataSelect.SubItemsExpandWidth = 20;
      this.cmdDataSelect.TabIndex = 2;
      this.cmdDataSelect.Text = "<b>Now Showing Run Charts</b>";
      this.cmdShowRuncharts.AutoExpandOnClick = true;
      this.cmdShowRuncharts.BeginGroup = true;
      this.cmdShowRuncharts.GlobalItem = false;
      this.cmdShowRuncharts.Name = "cmdShowRuncharts";
      this.cmdShowRuncharts.OptionGroup = "1";
      this.cmdShowRuncharts.PopupWidth = 4000;
      this.cmdShowRuncharts.ShowSubItems = false;
      this.cmdShowRuncharts.Stretch = true;
      this.cmdShowRuncharts.Text = "Run Charts";
      this.cmdShowRegularcharts.GlobalItem = false;
      this.cmdShowRegularcharts.Name = "cmdShowRegularcharts";
      this.cmdShowRegularcharts.Text = "Regular Charts";
      this.cmdShowDataGrid.GlobalItem = false;
      this.cmdShowDataGrid.Name = "cmdShowDataGrid";
      this.cmdShowDataGrid.Text = "Data Grid";
      this.Chart3.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      chartArea3.AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Yes;
      chartArea3.Name = "ChartArea1";
      chartArea4.Name = "ChartArea2";
      this.Chart3.ChartAreas.Add(chartArea3);
      this.Chart3.ChartAreas.Add(chartArea4);
      this.Chart3.Dock = DockStyle.Fill;
      legend1.Name = "Legend1";
      this.Chart3.Legends.Add(legend1);
      Chart chart3_1 = this.Chart3;
      point1 = new Point(3, 70);
      Point point94 = point1;
      chart3_1.Location = point94;
      this.Chart3.Name = "Chart3";
      this.TableLayoutPanel5.SetRowSpan((Control) this.Chart3, 18);
      Chart chart3_2 = this.Chart3;
      size1 = new Size(139, 354);
      Size size94 = size1;
      chart3_2.Size = size94;
      this.Chart3.TabIndex = 0;
      this.Chart3.Text = "Chart3";
      this.Chart4.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      chartArea5.AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Yes;
      chartArea5.Name = "ChartArea1";
      this.Chart4.ChartAreas.Add(chartArea5);
      this.Chart4.Dock = DockStyle.Fill;
      legend2.Name = "Legend1";
      this.Chart4.Legends.Add(legend2);
      Chart chart4_1 = this.Chart4;
      point1 = new Point(293, 50);
      Point point95 = point1;
      chart4_1.Location = point95;
      this.Chart4.Name = "Chart4";
      this.TableLayoutPanel5.SetRowSpan((Control) this.Chart4, 18);
      Chart chart4_2 = this.Chart4;
      size1 = new Size(548, 354);
      Size size95 = size1;
      chart4_2.Size = size95;
      this.Chart4.TabIndex = 4;
      this.Chart4.Text = "Chart4";
      this.Chart4.Visible = false;
      this.lblHistory_TotalUnits.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblHistory_TotalUnits.ForeColor = Color.Black;
      LabelX historyTotalUnits1 = this.lblHistory_TotalUnits;
      point1 = new Point(148, 190);
      Point point96 = point1;
      historyTotalUnits1.Location = point96;
      this.lblHistory_TotalUnits.Name = "lblHistory_TotalUnits";
      LabelX historyTotalUnits2 = this.lblHistory_TotalUnits;
      size1 = new Size(137, 14);
      Size size96 = size1;
      historyTotalUnits2.Size = size96;
      this.lblHistory_TotalUnits.TabIndex = 1;
      this.lblHistory_TotalUnits.Text = "LabelX1";
      this.cboRunCharts.DisplayMember = "Text";
      this.cboRunCharts.Dock = DockStyle.Fill;
      this.cboRunCharts.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboRunCharts.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRunCharts.ForeColor = Color.Black;
      this.cboRunCharts.FormattingEnabled = true;
      this.cboRunCharts.ItemHeight = 14;
      ComboBoxEx cboRunCharts1 = this.cboRunCharts;
      point1 = new Point(3, 38);
      Point point97 = point1;
      cboRunCharts1.Location = point97;
      this.cboRunCharts.Name = "cboRunCharts";
      ComboBoxEx cboRunCharts2 = this.cboRunCharts;
      size1 = new Size(139, 20);
      Size size97 = size1;
      cboRunCharts2.Size = size97;
      this.cboRunCharts.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboRunCharts.TabIndex = 9;
      this.sgcHistory.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.TableLayoutPanel5.SetColumnSpan((Control) this.sgcHistory, 3);
      this.sgcHistory.Dock = DockStyle.Fill;
      this.sgcHistory.ForeColor = Color.Black;
      this.sgcHistory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      SuperGridControl sgcHistory1 = this.sgcHistory;
      point1 = new Point(3, -370);
      Point point98 = point1;
      sgcHistory1.Location = point98;
      this.sgcHistory.Name = "sgcHistory";
      this.sgcHistory.PrimaryGrid.AllowSelection = false;
      this.sgcHistory.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.TextColor = Color.Black;
      this.sgcHistory.PrimaryGrid.ReadOnly = true;
      this.sgcHistory.PrimaryGrid.Title.RowHeaderVisibility = RowHeaderVisibility.PanelControlled;
      this.TableLayoutPanel5.SetRowSpan((Control) this.sgcHistory, 21);
      SuperGridControl sgcHistory2 = this.sgcHistory;
      size1 = new Size(838, 414);
      Size size98 = size1;
      sgcHistory2.Size = size98;
      this.sgcHistory.TabIndex = 10;
      this.sgcHistory.Text = "SuperGridControl1";
      this.sgcHistory.Visible = false;
      this.cboHistory_XVal.DisplayMember = "Text";
      this.cboHistory_XVal.Dock = DockStyle.Fill;
      this.cboHistory_XVal.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_XVal.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboHistory_XVal.ForeColor = Color.Black;
      this.cboHistory_XVal.FormattingEnabled = true;
      this.cboHistory_XVal.ItemHeight = 14;
      ComboBoxEx cboHistoryXval1 = this.cboHistory_XVal;
      point1 = new Point(148, 70);
      Point point99 = point1;
      cboHistoryXval1.Location = point99;
      this.cboHistory_XVal.Name = "cboHistory_XVal";
      ComboBoxEx cboHistoryXval2 = this.cboHistory_XVal;
      size1 = new Size(139, 20);
      Size size99 = size1;
      cboHistoryXval2.Size = size99;
      this.cboHistory_XVal.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_XVal.TabIndex = 11;
      this.cboHistory_XVal.Visible = false;
      this.cboHistory_YVal.DisplayMember = "Text";
      this.cboHistory_YVal.Dock = DockStyle.Fill;
      this.cboHistory_YVal.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_YVal.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboHistory_YVal.ForeColor = Color.Black;
      this.cboHistory_YVal.FormattingEnabled = true;
      this.cboHistory_YVal.ItemHeight = 14;
      ComboBoxEx cboHistoryYval1 = this.cboHistory_YVal;
      point1 = new Point(148, 90);
      Point point100 = point1;
      cboHistoryYval1.Location = point100;
      this.cboHistory_YVal.Name = "cboHistory_YVal";
      ComboBoxEx cboHistoryYval2 = this.cboHistory_YVal;
      size1 = new Size(139, 20);
      Size size100 = size1;
      cboHistoryYval2.Size = size100;
      this.cboHistory_YVal.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_YVal.TabIndex = 12;
      this.cboHistory_YVal.Visible = false;
      this.cboHistory_Series.DisplayMember = "Text";
      this.cboHistory_Series.Dock = DockStyle.Fill;
      this.cboHistory_Series.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboHistory_Series.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboHistory_Series.ForeColor = Color.Black;
      this.cboHistory_Series.FormattingEnabled = true;
      this.cboHistory_Series.ItemHeight = 14;
      ComboBoxEx cboHistorySeries1 = this.cboHistory_Series;
      point1 = new Point(148, 130);
      Point point101 = point1;
      cboHistorySeries1.Location = point101;
      this.cboHistory_Series.Name = "cboHistory_Series";
      ComboBoxEx cboHistorySeries2 = this.cboHistory_Series;
      size1 = new Size(139, 20);
      Size size101 = size1;
      cboHistorySeries2.Size = size101;
      this.cboHistory_Series.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboHistory_Series.TabIndex = 13;
      this.cboHistory_Series.Visible = false;
      this.lblHistory_XVal.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblHistory_XVal.Dock = DockStyle.Fill;
      this.lblHistory_XVal.ForeColor = Color.Black;
      LabelX lblHistoryXval1 = this.lblHistory_XVal;
      point1 = new Point(3, 50);
      Point point102 = point1;
      lblHistoryXval1.Location = point102;
      this.lblHistory_XVal.Name = "lblHistory_XVal";
      LabelX lblHistoryXval2 = this.lblHistory_XVal;
      size1 = new Size(139, 14);
      Size size102 = size1;
      lblHistoryXval2.Size = size102;
      this.lblHistory_XVal.TabIndex = 14;
      this.lblHistory_XVal.Text = "X Values";
      this.lblHistory_XVal.TextLineAlignment = StringAlignment.Far;
      this.lblHistory_XVal.Visible = false;
      this.lblHistory_YVal.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblHistory_YVal.Dock = DockStyle.Fill;
      this.lblHistory_YVal.ForeColor = Color.Black;
      LabelX lblHistoryYval1 = this.lblHistory_YVal;
      point1 = new Point(148, 50);
      Point point103 = point1;
      lblHistoryYval1.Location = point103;
      this.lblHistory_YVal.Name = "lblHistory_YVal";
      LabelX lblHistoryYval2 = this.lblHistory_YVal;
      size1 = new Size(139, 14);
      Size size103 = size1;
      lblHistoryYval2.Size = size103;
      this.lblHistory_YVal.TabIndex = 15;
      this.lblHistory_YVal.Text = "Y Values";
      this.lblHistory_YVal.TextLineAlignment = StringAlignment.Far;
      this.lblHistory_YVal.Visible = false;
      this.lblHistory_Series.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblHistory_Series.Dock = DockStyle.Fill;
      this.lblHistory_Series.ForeColor = Color.Black;
      LabelX lblHistorySeries1 = this.lblHistory_Series;
      point1 = new Point(148, 110);
      Point point104 = point1;
      lblHistorySeries1.Location = point104;
      this.lblHistory_Series.Name = "lblHistory_Series";
      LabelX lblHistorySeries2 = this.lblHistory_Series;
      size1 = new Size(139, 14);
      Size size104 = size1;
      lblHistorySeries2.Size = size104;
      this.lblHistory_Series.TabIndex = 16;
      this.lblHistory_Series.Text = "Series";
      this.lblHistory_Series.TextLineAlignment = StringAlignment.Far;
      this.lblHistory_Series.Visible = false;
      this.cmdHistory_ChartIt.AccessibleRole = AccessibleRole.PushButton;
      this.cmdHistory_ChartIt.ColorTable = eButtonColor.OrangeWithBackground;
      this.cmdHistory_ChartIt.Dock = DockStyle.Fill;
      ButtonX cmdHistoryChartIt1 = this.cmdHistory_ChartIt;
      point1 = new Point(148, 150);
      Point point105 = point1;
      cmdHistoryChartIt1.Location = point105;
      ButtonX cmdHistoryChartIt2 = this.cmdHistory_ChartIt;
      padding1 = new System.Windows.Forms.Padding(3, 3, 3, 0);
      System.Windows.Forms.Padding padding46 = padding1;
      cmdHistoryChartIt2.Margin = padding46;
      this.cmdHistory_ChartIt.Name = "cmdHistory_ChartIt";
      ButtonX cmdHistoryChartIt3 = this.cmdHistory_ChartIt;
      size1 = new Size(139, 17);
      Size size105 = size1;
      cmdHistoryChartIt3.Size = size105;
      this.cmdHistory_ChartIt.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdHistory_ChartIt.TabIndex = 17;
      this.cmdHistory_ChartIt.Text = "Chart It";
      this.cmdHistory_ChartIt.Visible = false;
      this.cmdHistory_DataGrid_Edit.AccessibleRole = AccessibleRole.PushButton;
      this.cmdHistory_DataGrid_Edit.AutoCheckOnClick = true;
      this.cmdHistory_DataGrid_Edit.ColorTable = eButtonColor.OrangeWithBackground;
      this.cmdHistory_DataGrid_Edit.Dock = DockStyle.Left;
      ButtonX historyDataGridEdit1 = this.cmdHistory_DataGrid_Edit;
      point1 = new Point(146, 168);
      Point point106 = point1;
      historyDataGridEdit1.Location = point106;
      ButtonX historyDataGridEdit2 = this.cmdHistory_DataGrid_Edit;
      padding1 = new System.Windows.Forms.Padding(1);
      System.Windows.Forms.Padding padding47 = padding1;
      historyDataGridEdit2.Margin = padding47;
      this.cmdHistory_DataGrid_Edit.Name = "cmdHistory_DataGrid_Edit";
      ButtonX historyDataGridEdit3 = this.cmdHistory_DataGrid_Edit;
      size1 = new Size(103, 18);
      Size size106 = size1;
      historyDataGridEdit3.Size = size106;
      this.cmdHistory_DataGrid_Edit.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdHistory_DataGrid_Edit.TabIndex = 18;
      this.cmdHistory_DataGrid_Edit.Text = "Edit Grid Contents";
      this.cmdHistory_DataGrid_Edit.Visible = false;
      this.MetroAppButton1.AutoExpandOnClick = true;
      this.MetroAppButton1.BackstageTabEnabled = false;
      this.MetroAppButton1.CanCustomize = false;
      this.MetroAppButton1.Enabled = false;
      MetroAppButton metroAppButton1 = this.MetroAppButton1;
      size1 = new Size(16, 16);
      Size size107 = size1;
      metroAppButton1.ImageFixedSize = size107;
      this.MetroAppButton1.ImagePaddingHorizontal = 0;
      this.MetroAppButton1.ImagePaddingVertical = 0;
      this.MetroAppButton1.Name = "MetroAppButton1";
      this.MetroAppButton1.ShowSubItems = false;
      this.MetroAppButton1.Text = "&File";
      this.MetroAppButton1.Visible = false;
      this.MetroTabItem1.Cursor = Cursors.Hand;
      this.MetroTabItem1.ImagePaddingHorizontal = 1;
      this.MetroTabItem1.Name = "MetroTabItem1";
      this.MetroTabItem1.Panel = this.MetroTabPanel1;
      this.MetroTabItem1.Tag = (object) "99";
      this.MetroTabItem1.Text = "&Summary";
      this.MetroTabItem2.Cursor = Cursors.Hand;
      this.MetroTabItem2.ImagePaddingHorizontal = 1;
      this.MetroTabItem2.Name = "MetroTabItem2";
      this.MetroTabItem2.Panel = this.MetroTabPanel2;
      this.MetroTabItem2.Tag = (object) "99";
      this.MetroTabItem2.Text = "&Prime Pressures";
      this.MetroTabItem4.Checked = true;
      this.MetroTabItem4.Cursor = Cursors.Hand;
      this.MetroTabItem4.ImagePaddingHorizontal = 1;
      this.MetroTabItem4.Name = "MetroTabItem4";
      this.MetroTabItem4.Panel = this.MetroTabPanel4;
      this.MetroTabItem4.Tag = (object) "99";
      this.MetroTabItem4.Text = "Mech Checks";
      this.MetroTabItem3.Cursor = Cursors.Hand;
      this.MetroTabItem3.ImagePaddingHorizontal = 1;
      this.MetroTabItem3.Name = "MetroTabItem3";
      this.MetroTabItem3.Panel = this.MetroTabPanel3;
      this.MetroTabItem3.Tag = (object) "99";
      this.MetroTabItem3.Text = "History";
      this.tabTriage.Name = "tabTriage";
      this.tabTriage.Panel = this.MetroTabPanel5;
      this.tabTriage.Tag = (object) "99";
      this.tabTriage.Text = "Printer Triage";
      this.tabHelp.Name = "tabHelp";
      this.tabHelp.Panel = this.MetroTabPanel6;
      this.tabHelp.Tag = (object) "99";
      this.tabHelp.Text = "Help";
      this.tabHelp.Visible = false;
      this.ButtonItem4.Name = "ButtonItem4";
      this.ButtonItem4.Text = "CopyToClipBoard";
      this.ButtonItem4.Visible = false;
      this.ButtonItem1.Enabled = false;
      this.ButtonItem1.Name = "ButtonItem1";
      this.ButtonItem1.Text = "ButtonItem1";
      this.ButtonItem1.Visible = false;
      this.StyleManager1.ManagerStyle = eStyle.Metro;
      this.StyleManager1.MetroColorParameters = new MetroColorGeneratorParameters(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Color.FromArgb(237, 142, 0));
      this.MetroStatusBar1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.MetroStatusBar1.BackgroundStyle.CornerType = eCornerType.Square;
      this.MetroStatusBar1.ContainerControlProcessDialogKey = true;
      this.MetroStatusBar1.Dock = DockStyle.Bottom;
      this.MetroStatusBar1.DragDropSupport = true;
      this.MetroStatusBar1.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.MetroStatusBar1.ForeColor = Color.Black;
      this.MetroStatusBar1.Items.AddRange(new BaseItem[5]
      {
        (BaseItem) this.cmdEmail,
        (BaseItem) this.cmdClipBoard,
        (BaseItem) this.cmdSaveFormImage,
        (BaseItem) this.ButtonItem2,
        (BaseItem) this.ButtonItem3
      });
      this.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      MetroStatusBar metroStatusBar1_1 = this.MetroStatusBar1;
      point1 = new Point(0, 484);
      Point point107 = point1;
      metroStatusBar1_1.Location = point107;
      this.MetroStatusBar1.Name = "MetroStatusBar1";
      MetroStatusBar metroStatusBar1_2 = this.MetroStatusBar1;
      size1 = new Size(844, 22);
      Size size108 = size1;
      metroStatusBar1_2.Size = size108;
      this.MetroStatusBar1.TabIndex = 9;
      this.MetroStatusBar1.Text = "MetroStatusBar1";
      this.cmdEmail.Image = (Image) componentResourceManager.GetObject("cmdEmail.Image");
      this.cmdEmail.Name = "cmdEmail";
      this.SuperTooltip1.SetSuperTooltip((IComponent) this.cmdEmail, new SuperTooltipInfo("Email PST Screenshot", "", "Click to open a new email message. An image of the PST results will be placed on the clipboard. To insert the image in your message, you can either type CTRL+V or click on the paste button.", (Image) null, (Image) null, eTooltipColor.Gray));
      this.cmdEmail.Text = "Email";
      this.cmdClipBoard.Image = (Image) componentResourceManager.GetObject("cmdClipBoard.Image");
      this.cmdClipBoard.Name = "cmdClipBoard";
      this.SuperTooltip1.SetSuperTooltip((IComponent) this.cmdClipBoard, new SuperTooltipInfo("Copy Clip", "", "Copies an image of the PST results to the clipboard that can be pastedinto other applications.", (Image) null, (Image) null, eTooltipColor.Gray));
      this.cmdClipBoard.Text = "Copy Clip";
      this.cmdSaveFormImage.Icon = (Icon) componentResourceManager.GetObject("cmdSaveFormImage.Icon");
      this.cmdSaveFormImage.Name = "cmdSaveFormImage";
      this.cmdSaveFormImage.Text = "ButtonItem5";
      this.ButtonItem2.Name = "ButtonItem2";
      this.ButtonItem2.Text = "ButtonItem2";
      this.ButtonItem2.Visible = false;
      this.ButtonItem3.Name = "ButtonItem3";
      this.ButtonItem3.Text = "ButtonItem3";
      this.ButtonItem3.Visible = false;
      this.SuperTooltip1.DefaultTooltipSettings = new SuperTooltipInfo("", "", "", (Image) null, (Image) null, eTooltipColor.Gray);
      this.SuperTooltip1.HoverDelayMultiplier = 1;
      this.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.AutoScaleMode = AutoScaleMode.Inherit;
      size1 = new Size(844, 506);
      this.ClientSize = size1;
      this.ControlBox = false;
      this.Controls.Add((Control) this.MetroStatusBar1);
      this.Controls.Add((Control) this.MetroShell1);
      this.DoubleBuffered = true;
      this.ForeColor = Color.Black;
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (dlgPSTResults);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.TitleText = "Priming Systems Test";
      this.TopLeftCornerSize = 25;
      this.GroupPanel1.ResumeLayout(false);
      this.TableLayoutPanel2.ResumeLayout(false);
      this.GroupPanel2.ResumeLayout(false);
      this.TableLayoutPanel3.ResumeLayout(false);
      this.TableLayoutPanel4.ResumeLayout(false);
      this.TableLayoutPanel4.PerformLayout();
      this.FlowLayoutPanel1.ResumeLayout(false);
      this.FlowLayoutPanel1.PerformLayout();
      this.Chart1.EndInit();
      this.Chart2.EndInit();
      this.MetroShell1.ResumeLayout(false);
      this.MetroShell1.PerformLayout();
      this.MetroTabPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.MetroTabPanel5.ResumeLayout(false);
      ((ISupportInitialize) this.SuperTabControl1).EndInit();
      this.SuperTabControl1.ResumeLayout(false);
      this.SuperTabControlPanel1.ResumeLayout(false);
      this.SuperTabControlPanel6.ResumeLayout(false);
      this.SuperTabControlPanel3.ResumeLayout(false);
      this.SuperTabControlPanel4.ResumeLayout(false);
      this.SuperTabControlPanel2.ResumeLayout(false);
      this.SuperTabControlPanel5.ResumeLayout(false);
      this.MetroTabPanel6.ResumeLayout(false);
      this.MetroTabPanel2.ResumeLayout(false);
      this.MetroTabPanel3.ResumeLayout(false);
      this.TableLayoutPanel5.ResumeLayout(false);
      this.Chart3.EndInit();
      this.Chart4.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual LabelX lblTitlePressure_K
    {
      [DebuggerNonUserCode] get => this._lblTitlePressure_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitlePressure_K = value;
    }

    internal virtual GroupPanel GroupPanel1
    {
      [DebuggerNonUserCode] get => this._GroupPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._GroupPanel1 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel2
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel2 = value;
    }

    internal virtual LabelX lblTitleLeak_K
    {
      [DebuggerNonUserCode] get => this._lblTitleLeak_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleLeak_K = value;
    }

    internal virtual LabelX lblTitleVent_K
    {
      [DebuggerNonUserCode] get => this._lblTitleVent_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleVent_K = value;
    }

    internal virtual LabelX lblMeasPressure_K
    {
      [DebuggerNonUserCode] get => this._lblMeasPressure_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasPressure_K = value;
    }

    internal virtual LabelX lblTitlePressure_C
    {
      [DebuggerNonUserCode] get => this._lblTitlePressure_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitlePressure_C = value;
    }

    internal virtual LabelX lblMeasLeak_K
    {
      [DebuggerNonUserCode] get => this._lblMeasLeak_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasLeak_K = value;
    }

    internal virtual LabelX lblTitleLeak_C
    {
      [DebuggerNonUserCode] get => this._lblTitleLeak_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleLeak_C = value;
    }

    internal virtual LabelX lblMeasVent_K
    {
      [DebuggerNonUserCode] get => this._lblMeasVent_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasVent_K = value;
    }

    internal virtual LabelX lblTitleVent_C
    {
      [DebuggerNonUserCode] get => this._lblTitleVent_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleVent_C = value;
    }

    internal virtual LabelX lblSpecPressure_K
    {
      [DebuggerNonUserCode] get => this._lblSpecPressure_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecPressure_K = value;
    }

    internal virtual LabelX lblSpecLeak_K
    {
      [DebuggerNonUserCode] get => this._lblSpecLeak_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecLeak_K = value;
    }

    internal virtual LabelX lblSpecVent_K
    {
      [DebuggerNonUserCode] get => this._lblSpecVent_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecVent_K = value;
    }

    internal virtual LabelX LabelX10
    {
      [DebuggerNonUserCode] get => this._LabelX10;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX10 = value;
    }

    internal virtual LabelX LabelX11
    {
      [DebuggerNonUserCode] get => this._LabelX11;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX11 = value;
    }

    internal virtual LabelX LabelX12
    {
      [DebuggerNonUserCode] get => this._LabelX12;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX12 = value;
    }

    internal virtual GroupPanel GroupPanel2
    {
      [DebuggerNonUserCode] get => this._GroupPanel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._GroupPanel2 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel3
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel3 = value;
    }

    internal virtual LabelX lblMeasPressure_C
    {
      [DebuggerNonUserCode] get => this._lblMeasPressure_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasPressure_C = value;
    }

    internal virtual LabelX lblMeasLeak_C
    {
      [DebuggerNonUserCode] get => this._lblMeasLeak_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasLeak_C = value;
    }

    internal virtual LabelX lblMeasVent_C
    {
      [DebuggerNonUserCode] get => this._lblMeasVent_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasVent_C = value;
    }

    internal virtual LabelX lblSpecPressure_C
    {
      [DebuggerNonUserCode] get => this._lblSpecPressure_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecPressure_C = value;
    }

    internal virtual LabelX lblSpecLeak_C
    {
      [DebuggerNonUserCode] get => this._lblSpecLeak_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecLeak_C = value;
    }

    internal virtual LabelX lblSpecVent_C
    {
      [DebuggerNonUserCode] get => this._lblSpecVent_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecVent_C = value;
    }

    internal virtual LabelX LabelX16
    {
      [DebuggerNonUserCode] get => this._LabelX16;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX16 = value;
    }

    internal virtual LabelX LabelX17
    {
      [DebuggerNonUserCode] get => this._LabelX17;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX17 = value;
    }

    internal virtual LabelX LabelX18
    {
      [DebuggerNonUserCode] get => this._LabelX18;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX18 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel4
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel4 = value;
    }

    internal virtual MetroShell MetroShell1
    {
      [DebuggerNonUserCode] get => this._MetroShell1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroShell1 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel2
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel2 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel1
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel1 = value;
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

    internal virtual StyleManager StyleManager1
    {
      [DebuggerNonUserCode] get => this._StyleManager1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._StyleManager1 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel4
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel4 = value;
    }

    internal virtual MetroTabItem MetroTabItem4
    {
      [DebuggerNonUserCode] get => this._MetroTabItem4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabItem4 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel5
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel5 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel3
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel3 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel2
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel2 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel1
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel1 = value;
    }

    internal virtual LabelX lblSummary_FuelRev
    {
      [DebuggerNonUserCode] get => this._lblSummary_FuelRev;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_FuelRev = value;
    }

    internal virtual LabelX lblSummary_TestTime
    {
      [DebuggerNonUserCode] get => this._lblSummary_TestTime;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_TestTime = value;
    }

    internal virtual LabelX lblSummary_TestDate
    {
      [DebuggerNonUserCode] get => this._lblSummary_TestDate;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_TestDate = value;
    }

    internal virtual LabelX lblSummary_ScriptRev
    {
      [DebuggerNonUserCode] get => this._lblSummary_ScriptRev;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_ScriptRev = value;
    }

    internal virtual LabelX lblSummary_PSTColor
    {
      [DebuggerNonUserCode] get => this._lblSummary_PSTColor;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblSummary_PST_MouseClick);
        if (this._lblSummary_PSTColor != null)
          this._lblSummary_PSTColor.MouseClick -= mouseEventHandler;
        this._lblSummary_PSTColor = value;
        if (this._lblSummary_PSTColor == null)
          return;
        this._lblSummary_PSTColor.MouseClick += mouseEventHandler;
      }
    }

    internal virtual LabelX lblSummary_PSTBlack
    {
      [DebuggerNonUserCode] get => this._lblSummary_PSTBlack;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblSummary_PST_MouseClick);
        if (this._lblSummary_PSTBlack != null)
          this._lblSummary_PSTBlack.MouseClick -= mouseEventHandler;
        this._lblSummary_PSTBlack = value;
        if (this._lblSummary_PSTBlack == null)
          return;
        this._lblSummary_PSTBlack.MouseClick += mouseEventHandler;
      }
    }

    internal virtual LabelX lblSummary_EngPgCnt
    {
      [DebuggerNonUserCode] get => this._lblSummary_EngPgCnt;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_EngPgCnt = value;
    }

    internal virtual LabelX lblSummary_FW
    {
      [DebuggerNonUserCode] get => this._lblSummary_FW;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_FW = value;
    }

    internal virtual LabelX lblSummary_SerialNum
    {
      [DebuggerNonUserCode] get => this._lblSummary_SerialNum;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_SerialNum = value;
    }

    internal virtual Chart Chart1
    {
      [DebuggerNonUserCode] get => this._Chart1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart1 = value;
    }

    internal virtual Chart Chart2
    {
      [DebuggerNonUserCode] get => this._Chart2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart2 = value;
    }

    internal virtual MetroTabPanel MetroTabPanel3
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel3 = value;
    }

    internal virtual Chart Chart3
    {
      [DebuggerNonUserCode] get => this._Chart3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart3 = value;
    }

    internal virtual MetroTabItem MetroTabItem3
    {
      [DebuggerNonUserCode] get => this._MetroTabItem3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabItem3 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel5
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel5 = value;
    }

    internal virtual LabelX lblHistory_TotalUnits
    {
      [DebuggerNonUserCode] get => this._lblHistory_TotalUnits;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHistory_TotalUnits = value;
    }

    internal virtual ButtonX cmdDataSelect
    {
      [DebuggerNonUserCode] get => this._cmdDataSelect;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cmdDataSelect = value;
    }

    internal virtual ButtonItem cmdShowRuncharts
    {
      [DebuggerNonUserCode] get => this._cmdShowRuncharts;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HistoryChartTypeChanged);
        if (this._cmdShowRuncharts != null)
          this._cmdShowRuncharts.Click -= eventHandler;
        this._cmdShowRuncharts = value;
        if (this._cmdShowRuncharts == null)
          return;
        this._cmdShowRuncharts.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox1
    {
      [DebuggerNonUserCode] get => this._PictureBox1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._PictureBox1 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel4
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel4 = value;
    }

    internal virtual LabelX LabelX1
    {
      [DebuggerNonUserCode] get => this._LabelX1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX1 = value;
    }

    internal virtual LabelX lblFailModes
    {
      [DebuggerNonUserCode] get => this._lblFailModes;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblFailModes = value;
    }

    internal virtual MetroTabPanel MetroTabPanel5
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel5 = value;
    }

    internal virtual SuperTabControl SuperTabControl1
    {
      [DebuggerNonUserCode] get => this._SuperTabControl1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControl1 = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel1
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel1 = value;
    }

    internal virtual SuperTabItem stiPSTDocs_Intro
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_Intro;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_Intro = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel4
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel4 = value;
    }

    internal virtual SuperTabItem stiPSTDocs_CyclicalPressure
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_CyclicalPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_CyclicalPressure = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel3
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel3 = value;
    }

    internal virtual SuperTabItem stiPSTDocs_DelayedPressure
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_DelayedPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_DelayedPressure = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel2
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel2 = value;
    }

    internal virtual SuperTabItem stiPSTDocs_NoPressure
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_NoPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_NoPressure = value;
    }

    internal virtual MetroTabItem tabTriage
    {
      [DebuggerNonUserCode] get => this._tabTriage;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._tabTriage = value;
    }

    internal virtual RichTextBox rtbPSTDocs_Intro
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_Intro;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_Intro = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel5
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel5 = value;
    }

    internal virtual SuperTabItem stiPSTDocs_PressureFluctuates
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_PressureFluctuates;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_PressureFluctuates = value;
    }

    internal virtual SuperTabControlPanel SuperTabControlPanel6
    {
      [DebuggerNonUserCode] get => this._SuperTabControlPanel6;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTabControlPanel6 = value;
    }

    internal virtual RichTextBox rtbPSTDocs_PSTOutputs
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_PSTOutputs;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_PSTOutputs = value;
    }

    internal virtual SuperTabItem stiPSTDocs_Outputs
    {
      [DebuggerNonUserCode] get => this._stiPSTDocs_Outputs;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._stiPSTDocs_Outputs = value;
    }

    internal virtual RichTextBox rtbPSTDocs_NoPressure
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_NoPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_NoPressure = value;
    }

    internal virtual RichTextBox rtbPSTDocs_PressureFluctuates
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_PressureFluctuates;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_PressureFluctuates = value;
    }

    internal virtual RichTextBox rtbPSTDocs_CyclicalPressure
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_CyclicalPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_CyclicalPressure = value;
    }

    internal virtual RichTextBox rtbPSTDocs_DelayedPressure
    {
      [DebuggerNonUserCode] get => this._rtbPSTDocs_DelayedPressure;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbPSTDocs_DelayedPressure = value;
    }

    internal virtual MetroStatusBar MetroStatusBar1
    {
      [DebuggerNonUserCode] get => this._MetroStatusBar1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dlgPSTResults_MouseClick);
        if (this._MetroStatusBar1 != null)
          this._MetroStatusBar1.MouseClick -= mouseEventHandler;
        this._MetroStatusBar1 = value;
        if (this._MetroStatusBar1 == null)
          return;
        this._MetroStatusBar1.MouseClick += mouseEventHandler;
      }
    }

    internal virtual ButtonItem cmdEmail
    {
      [DebuggerNonUserCode] get => this._cmdEmail;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdEmail_Click);
        if (this._cmdEmail != null)
          this._cmdEmail.Click -= eventHandler;
        this._cmdEmail = value;
        if (this._cmdEmail == null)
          return;
        this._cmdEmail.Click += eventHandler;
      }
    }

    internal virtual ButtonItem cmdClipBoard
    {
      [DebuggerNonUserCode] get => this._cmdClipBoard;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdClipBoard_Click);
        if (this._cmdClipBoard != null)
          this._cmdClipBoard.Click -= eventHandler;
        this._cmdClipBoard = value;
        if (this._cmdClipBoard == null)
          return;
        this._cmdClipBoard.Click += eventHandler;
      }
    }

    internal virtual ButtonItem ButtonItem2
    {
      [DebuggerNonUserCode] get => this._ButtonItem2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonItem2_Click);
        if (this._ButtonItem2 != null)
          this._ButtonItem2.Click -= eventHandler;
        this._ButtonItem2 = value;
        if (this._ButtonItem2 == null)
          return;
        this._ButtonItem2.Click += eventHandler;
      }
    }

    internal virtual ButtonItem ButtonItem3
    {
      [DebuggerNonUserCode] get => this._ButtonItem3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonItem3_Click);
        if (this._ButtonItem3 != null)
          this._ButtonItem3.Click -= eventHandler;
        this._ButtonItem3 = value;
        if (this._ButtonItem3 == null)
          return;
        this._ButtonItem3.Click += eventHandler;
      }
    }

    internal virtual SuperTooltip SuperTooltip1
    {
      [DebuggerNonUserCode] get => this._SuperTooltip1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._SuperTooltip1 = value;
    }

    internal virtual ListViewEx lstSummaryMechChecks
    {
      [DebuggerNonUserCode] get => this._lstSummaryMechChecks;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstSummaryMechChecks_MouseLeave);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lstSUmmaryMechChecks_MouseClick);
        if (this._lstSummaryMechChecks != null)
        {
          this._lstSummaryMechChecks.MouseLeave -= eventHandler;
          this._lstSummaryMechChecks.MouseClick -= mouseEventHandler;
        }
        this._lstSummaryMechChecks = value;
        if (this._lstSummaryMechChecks == null)
          return;
        this._lstSummaryMechChecks.MouseLeave += eventHandler;
        this._lstSummaryMechChecks.MouseClick += mouseEventHandler;
      }
    }

    internal virtual ImageList ImageList1
    {
      [DebuggerNonUserCode] get => this._ImageList1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ImageList1 = value;
    }

    internal virtual ColumnHeader ColumnHeader2
    {
      [DebuggerNonUserCode] get => this._ColumnHeader2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ColumnHeader2 = value;
    }

    internal virtual Chart Chart4
    {
      [DebuggerNonUserCode] get => this._Chart4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._Chart4 = value;
    }

    internal virtual ButtonItem cmdShowRegularcharts
    {
      [DebuggerNonUserCode] get => this._cmdShowRegularcharts;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HistoryChartTypeChanged);
        if (this._cmdShowRegularcharts != null)
          this._cmdShowRegularcharts.Click -= eventHandler;
        this._cmdShowRegularcharts = value;
        if (this._cmdShowRegularcharts == null)
          return;
        this._cmdShowRegularcharts.Click += eventHandler;
      }
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

    internal virtual ButtonItem cmdShowDataGrid
    {
      [DebuggerNonUserCode] get => this._cmdShowDataGrid;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HistoryChartTypeChanged);
        if (this._cmdShowDataGrid != null)
          this._cmdShowDataGrid.Click -= eventHandler;
        this._cmdShowDataGrid = value;
        if (this._cmdShowDataGrid == null)
          return;
        this._cmdShowDataGrid.Click += eventHandler;
      }
    }

    internal virtual SuperGridControl sgcHistory
    {
      [DebuggerNonUserCode] get => this._sgcHistory;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._sgcHistory = value;
    }

    internal virtual ComboBoxEx cboHistory_XVal
    {
      [DebuggerNonUserCode] get => this._cboHistory_XVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_XVal = value;
    }

    internal virtual ComboBoxEx cboHistory_YVal
    {
      [DebuggerNonUserCode] get => this._cboHistory_YVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_YVal = value;
    }

    internal virtual ComboBoxEx cboHistory_Series
    {
      [DebuggerNonUserCode] get => this._cboHistory_Series;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboHistory_Series = value;
    }

    internal virtual LabelX lblHistory_XVal
    {
      [DebuggerNonUserCode] get => this._lblHistory_XVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHistory_XVal = value;
    }

    internal virtual LabelX lblHistory_YVal
    {
      [DebuggerNonUserCode] get => this._lblHistory_YVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHistory_YVal = value;
    }

    internal virtual LabelX lblHistory_Series
    {
      [DebuggerNonUserCode] get => this._lblHistory_Series;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHistory_Series = value;
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

    internal virtual ButtonX cmdHistory_DataGrid_Edit
    {
      [DebuggerNonUserCode] get => this._cmdHistory_DataGrid_Edit;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdHistory_DataGrid_Edit_Click);
        if (this._cmdHistory_DataGrid_Edit != null)
          this._cmdHistory_DataGrid_Edit.Click -= eventHandler;
        this._cmdHistory_DataGrid_Edit = value;
        if (this._cmdHistory_DataGrid_Edit == null)
          return;
        this._cmdHistory_DataGrid_Edit.Click += eventHandler;
      }
    }

    internal virtual MetroTabPanel MetroTabPanel6
    {
      [DebuggerNonUserCode] get => this._MetroTabPanel6;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._MetroTabPanel6 = value;
    }

    internal virtual ButtonX ButtonX2
    {
      [DebuggerNonUserCode] get => this._ButtonX2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonX2_Click);
        if (this._ButtonX2 != null)
          this._ButtonX2.Click -= eventHandler;
        this._ButtonX2 = value;
        if (this._ButtonX2 == null)
          return;
        this._ButtonX2.Click += eventHandler;
      }
    }

    internal virtual ButtonX ButtonX1
    {
      [DebuggerNonUserCode] get => this._ButtonX1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ButtonX1 = value;
    }

    internal virtual MetroTabItem tabHelp
    {
      [DebuggerNonUserCode] get => this._tabHelp;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._tabHelp = value;
    }

    internal virtual LabelX lblSummary_ScriptProduct
    {
      [DebuggerNonUserCode] get => this._lblSummary_ScriptProduct;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_ScriptProduct = value;
    }

    internal virtual LabelX lblMeasTubeEvac_K
    {
      [DebuggerNonUserCode] get => this._lblMeasTubeEvac_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasTubeEvac_K = value;
    }

    internal virtual LabelX lblTitleTubeEvac_k
    {
      [DebuggerNonUserCode] get => this._lblTitleTubeEvac_k;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleTubeEvac_k = value;
    }

    internal virtual LabelX lblSpecTubeEvac_K
    {
      [DebuggerNonUserCode] get => this._lblSpecTubeEvac_K;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecTubeEvac_K = value;
    }

    internal virtual LabelX lblTitleTubeEvac_C
    {
      [DebuggerNonUserCode] get => this._lblTitleTubeEvac_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblTitleTubeEvac_C = value;
    }

    internal virtual LabelX lblMeasTubeEvac_C
    {
      [DebuggerNonUserCode] get => this._lblMeasTubeEvac_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasTubeEvac_C = value;
    }

    internal virtual LabelX lblSpecTubeEvac_C
    {
      [DebuggerNonUserCode] get => this._lblSpecTubeEvac_C;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecTubeEvac_C = value;
    }

    internal virtual FlowLayoutPanel FlowLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._FlowLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._FlowLayoutPanel1 = value;
    }

    internal virtual Label lblHidden_TestInfo
    {
      [DebuggerNonUserCode] get => this._lblHidden_TestInfo;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_TestInfo = value;
    }

    internal virtual Label lblHidden_TestID
    {
      [DebuggerNonUserCode] get => this._lblHidden_TestID;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_TestID = value;
    }

    internal virtual Label lblHidden_Date
    {
      [DebuggerNonUserCode] get => this._lblHidden_Date;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_Date = value;
    }

    internal virtual Label lblHidden_Time
    {
      [DebuggerNonUserCode] get => this._lblHidden_Time;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_Time = value;
    }

    internal virtual Label lblHidden_Serial
    {
      [DebuggerNonUserCode] get => this._lblHidden_Serial;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_Serial = value;
    }

    internal virtual Label lblHidden_RunNum
    {
      [DebuggerNonUserCode] get => this._lblHidden_RunNum;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_RunNum = value;
    }

    internal virtual Label lblHidden_FUELRev
    {
      [DebuggerNonUserCode] get => this._lblHidden_FUELRev;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_FUELRev = value;
    }

    internal virtual Label lblHidden_ScriptRev
    {
      [DebuggerNonUserCode] get => this._lblHidden_ScriptRev;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_ScriptRev = value;
    }

    internal virtual Label lblHidden_Product
    {
      [DebuggerNonUserCode] get => this._lblHidden_Product;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblHidden_Product = value;
    }

    internal virtual ButtonItem ButtonItem4
    {
      [DebuggerNonUserCode] get => this._ButtonItem4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonItem4_Click);
        if (this._ButtonItem4 != null)
          this._ButtonItem4.Click -= eventHandler;
        this._ButtonItem4 = value;
        if (this._ButtonItem4 == null)
          return;
        this._ButtonItem4.Click += eventHandler;
      }
    }

    internal virtual LabelX lblSummary_Run
    {
      [DebuggerNonUserCode] get => this._lblSummary_Run;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_Run = value;
    }

    internal virtual LabelX lblSummary_TestID
    {
      [DebuggerNonUserCode] get => this._lblSummary_TestID;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSummary_TestID = value;
    }

    internal virtual ButtonItem cmdSaveFormImage
    {
      [DebuggerNonUserCode] get => this._cmdSaveFormImage;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdSaveFormImage_Click);
        if (this._cmdSaveFormImage != null)
          this._cmdSaveFormImage.Click -= eventHandler;
        this._cmdSaveFormImage = value;
        if (this._cmdSaveFormImage == null)
          return;
        this._cmdSaveFormImage.Click += eventHandler;
      }
    }

    public dlgPSTResults(PST myPST, bool ShowHistory)
    {
      this.Load += new EventHandler(this.dlgPSTResults_Load);
      this.MouseClick += new MouseEventHandler(this.dlgPSTResults_MouseClick);
      dlgPSTResults.__ENCAddToList((object) this);
      this.dtHistory = new DataTable();
      this.TestStatus = true;
      this.InitializeComponent();
      this.MetroShell1.CaptionVisible = false;
      this.MetroStatusBar1.Visible = false;
      this.MetroTabItem3.Visible = ShowHistory;
      this.PST = myPST;
    }

    public dlgPSTResults(PST myPST)
    {
      this.Load += new EventHandler(this.dlgPSTResults_Load);
      this.MouseClick += new MouseEventHandler(this.dlgPSTResults_MouseClick);
      dlgPSTResults.__ENCAddToList((object) this);
      this.dtHistory = new DataTable();
      this.TestStatus = true;
      this.InitializeComponent();
      this.PST = myPST;
    }

    private void dlgPSTResults_Load(object sender, EventArgs e)
    {
      this.MetroTabItem1.Select();
      this.TableLayoutPanel4.BackColor = Color.Transparent;
      if (this.MetroTabItem3.Visible)
      {
        this.LoadHistoryTable();
        this.sgcHistory.PrimaryGrid.DataSource = (object) this.dtHistory;
      }
      this.AddSummaryData();
      this.AddPSTData();
      this.cboRunCharts.Text = "K_MAX_PRESSURE";
      this.AddMechChecks();
      this.AddPSTDocumention();
      if (!this.TestStatus)
      {
        this.PictureBox1.Image = (Image) FUEL.My.Resources.Resources.Error_icon;
        this.ReflectionLabel4.Text = this.ReflectionLabel4.Text.Replace("Passed", "Failed");
        this.ReflectionLabel4.Text = this.ReflectionLabel4.Text.Replace("#009303", "#B02B2C");
      }
      this.Refresh();
    }

    private void lblSummary_PST_MouseClick(object sender, MouseEventArgs e) => this.MetroTabItem2.Select();

    private void cmdClipBoard_Click(object sender, EventArgs e) => this.CopyToClipBoard();

    private void ButtonItem2_Click(object sender, EventArgs e)
    {
      this.MetroTabItem2.Refresh();
      this.Redraw();
    }

    private void ButtonItem3_Click(object sender, EventArgs e)
    {
      if (this.Chart2.ChartAreas["ChartArea1"].AxisX.Minimum != this.PST.PTraceColor[0].X)
      {
        this.Chart2.ChartAreas["ChartArea1"].AxisX.Maximum = this.PST.PTraceColor[checked (this.PST.PTraceColor.Count - 1)].X;
        this.Chart2.ChartAreas["ChartArea1"].AxisX.Minimum = this.PST.PTraceColor[0].X;
      }
      else
      {
        this.Chart2.ChartAreas["ChartArea1"].AxisX.Maximum = this.PST.CDataPoints.PT4X + 1.0;
        this.Chart2.ChartAreas["ChartArea1"].AxisX.Minimum = this.PST.CDataPoints.PT1X - 1.0;
      }
    }

    private void cmdEmail_Click(object sender, EventArgs e)
    {
      this.CopyToClipBoard();
      Process.Start(string.Format("mailto:{0}?subject={1}&body={2}", (object) (string) null, (object) "PST Email", (object) "Type 'Ctrl+V' to insert screen shot of PST results"));
    }

    private void dlgPSTResults_MouseClick(object sender, MouseEventArgs e)
    {
      if (Control.ModifierKeys != (System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control))
        return;
      this.ButtonItem2.Visible = !this.ButtonItem2.Visible;
      this.ButtonItem3.Visible = !this.ButtonItem3.Visible;
      this.ButtonItem4.Visible = !this.ButtonItem4.Visible;
      this.Redraw();
    }

    private void lstSUmmaryMechChecks_MouseClick(object sender, MouseEventArgs e) => this.MetroTabItem4.Select();

    private void lstSummaryMechChecks_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        foreach (ListViewItem selectedItem in this.lstSummaryMechChecks.SelectedItems)
          selectedItem.Selected = false;
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void AddPSTData()
    {
      try
      {
        this.Chart1.Series.Add("Black");
        Series series1 = this.Chart1.Series["Black"];
        series1.ChartArea = "ChartArea1";
        series1.ChartType = SeriesChartType.Area;
        series1.Color = Color.FromArgb(215, 14, 5, 199);
        this.Chart2.Series.Add("Color");
        Series series2 = this.Chart2.Series["Color"];
        series2.ChartArea = "ChartArea1";
        series2.ChartType = SeriesChartType.Area;
        series2.Color = Color.FromArgb(240, 0, 153, 0);
        this.Chart1.Series[0].Points.DataBind((IEnumerable) this.PST.PTraceBlack, "X", "Y", (string) null);
        this.Chart2.Series[0].Points.DataBind((IEnumerable) this.PST.PTraceColor, "X", "Y", (string) null);
        this.FormatPSTChartArea(this.Chart1, "ChartArea1");
        this.FormatPSTChartArea(this.Chart2, "ChartArea1");
        this.SetChartAxisValues(this.Chart1, "ChartArea1", 0, this.PST.KDataPoints);
        this.SetChartAxisValues(this.Chart2, "ChartArea1", 0, this.PST.CDataPoints);
        this.SetPSTSpecLabelText(dlgPSTResults.Channels.Black, this.PST.SpecsBlack);
        this.SetPSTSpecLabelText(dlgPSTResults.Channels.Color, this.PST.SpecsColor);
        this.lblMeasPressure_K.Text = Conversions.ToString(System.Math.Round(this.PST.KResults.Val.MaxPressure, 1));
        this.lblMeasLeak_K.Text = Conversions.ToString(System.Math.Round(this.PST.KResults.Val.Leak, 1));
        if (this.PST.KResults.PF.VentDeltaPMin < 1)
          this.lblMeasVent_K.Text = Conversions.ToString(System.Math.Round(this.PST.KResults.Val.VentDeltaP, 3));
        else if (this.PST.KResults.PF.VentDeltaPMin == 1)
          this.lblMeasVent_K.Text = Conversions.ToString(System.Math.Round(this.PST.KResults.Val.VentDeltaP, 0)) + ", " + Conversions.ToString(System.Math.Round(this.PST.KDataPoints.PT3Y - this.PST.KDataPoints.PT4Y, 3));
        this.lblMeasTubeEvac_K.Text = Conversions.ToString(System.Math.Round(this.PST.KResults.Val.TubeEvacDeltaPressure, 3));
        this.lblMeasPressure_C.Text = Conversions.ToString(System.Math.Round(this.PST.CResults.Val.MaxPressure, 1));
        this.lblMeasLeak_C.Text = Conversions.ToString(System.Math.Round(this.PST.CResults.Val.Leak, 1));
        if (this.PST.CResults.PF.VentDeltaPMin < 1)
          this.lblMeasVent_C.Text = Conversions.ToString(System.Math.Round(this.PST.CResults.Val.VentDeltaP, 3));
        else if (this.PST.CResults.PF.VentDeltaPMin == 1)
          this.lblMeasVent_C.Text = Conversions.ToString(System.Math.Round(this.PST.CResults.Val.VentDeltaP, 0)) + ", " + Conversions.ToString(System.Math.Round(this.PST.CDataPoints.PT3Y - this.PST.CDataPoints.PT4Y, 3));
        this.lblMeasTubeEvac_C.Text = Conversions.ToString(System.Math.Round(this.PST.CResults.Val.TubeEvacDeltaPressure, 3));
        if (!this.PST.KResults.PF.MaxPressure)
        {
          this.lblTitlePressure_K.BackColor = Color.Red;
          this.lblMeasPressure_K.BackColor = Color.Red;
          this.lblSpecPressure_K.BackColor = Color.Red;
          this.lblSummary_PSTBlack.Text = "Black: Failed";
          this.lblSummary_PSTBlack.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart1, "ChartArea1", AxisName.Y, (double) checked (this.PST.SpecsBlack.PressureMax - this.PST.SpecsBlack.PressureMin), (double) this.PST.SpecsBlack.PressureMin, "Max Pressure Range");
        }
        else
        {
          this.lblTitlePressure_K.BackColor = Color.Lime;
          this.lblMeasPressure_K.BackColor = Color.Lime;
          this.lblSpecPressure_K.BackColor = Color.Lime;
        }
        if (!this.PST.KResults.PF.Leak)
        {
          this.lblTitleLeak_K.BackColor = Color.Red;
          this.lblMeasLeak_K.BackColor = Color.Red;
          this.lblSpecLeak_K.BackColor = Color.Red;
          this.lblSummary_PSTBlack.Text = "Black: Failed";
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.lblSummary_PSTBlack.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          double num = this.PST.KDataPoints.PT2Y;
          if (this.PST.SpecsBlack.AllowWetPHA)
            num = this.PST.KDataPoints.PT6Y - (double) this.PST.SpecsBlack.LeakMin;
          this.AddStripLine(this.Chart1, "ChartArea1", AxisName.Y, (double) checked (this.PST.SpecsBlack.LeakMax - this.PST.SpecsBlack.LeakMin), num - (double) checked (this.PST.SpecsBlack.LeakMax + System.Math.Abs(this.PST.SpecsBlack.LeakMin)), "Leak Range");
        }
        else
        {
          this.lblTitleLeak_K.BackColor = Color.Lime;
          this.lblMeasLeak_K.BackColor = Color.Lime;
          this.lblSpecLeak_K.BackColor = Color.Lime;
        }
        if (this.PST.KResults.PF.VentDeltaPMin == -1)
        {
          this.lblTitleVent_K.BackColor = Color.Red;
          this.lblMeasVent_K.BackColor = Color.Red;
          this.lblSpecVent_K.BackColor = Color.Red;
          this.lblSummary_PSTBlack.Text = "Black: Failed";
          this.lblSummary_PSTBlack.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart1, "ChartArea1", AxisName.X, this.PST.SpecsBlack.VentTime, this.PST.KDataPoints.PT3X, "Vent Range");
        }
        else
        {
          this.lblTitleVent_K.BackColor = Color.Lime;
          this.lblMeasVent_K.BackColor = Color.Lime;
          this.lblSpecVent_K.BackColor = Color.Lime;
        }
        if (!this.PST.KResults.PF.TubeEvacDeltaPressure)
        {
          this.lblTitleTubeEvac_k.BackColor = Color.Red;
          this.lblMeasTubeEvac_K.BackColor = Color.Red;
          this.lblSpecTubeEvac_K.BackColor = Color.Red;
          this.lblSummary_PSTBlack.Text = "Black: Failed";
          this.lblSummary_PSTBlack.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart1, "ChartArea1", AxisName.Y, (double) System.Math.Abs(this.PST.SpecsBlack.TubeEvacDeltaPressure), this.PST.KDataPoints.PT8Y + (double) System.Math.Abs(this.PST.SpecsBlack.TubeEvacDeltaPressure), "Tube Evac");
        }
        else
        {
          this.lblTitleTubeEvac_k.BackColor = Color.Lime;
          this.lblMeasTubeEvac_K.BackColor = Color.Lime;
          this.lblSpecTubeEvac_K.BackColor = Color.Lime;
        }
        if (!this.PST.CResults.PF.MaxPressure)
        {
          this.lblTitlePressure_C.BackColor = Color.Red;
          this.lblMeasPressure_C.BackColor = Color.Red;
          this.lblSpecPressure_C.BackColor = Color.Red;
          this.lblSummary_PSTColor.Text = "Color: Failed";
          this.lblSummary_PSTColor.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart2, "ChartArea1", AxisName.Y, (double) checked (this.PST.SpecsColor.PressureMax - this.PST.SpecsColor.PressureMin), (double) this.PST.SpecsColor.PressureMin, "Max Pressure Range");
        }
        else
        {
          this.lblTitlePressure_C.BackColor = Color.Lime;
          this.lblMeasPressure_C.BackColor = Color.Lime;
          this.lblSpecPressure_C.BackColor = Color.Lime;
        }
        if (!this.PST.CResults.PF.Leak)
        {
          this.lblTitleLeak_C.BackColor = Color.Red;
          this.lblMeasLeak_C.BackColor = Color.Red;
          this.lblSpecLeak_C.BackColor = Color.Red;
          this.lblSummary_PSTColor.Text = "Color: Failed";
          this.lblSummary_PSTColor.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          double num = this.PST.CDataPoints.PT2Y;
          if (this.PST.SpecsColor.AllowWetPHA)
            num = this.PST.CDataPoints.PT6Y - (double) this.PST.SpecsColor.LeakMin;
          this.AddStripLine(this.Chart2, "ChartArea1", AxisName.Y, (double) checked (this.PST.SpecsColor.LeakMax - this.PST.SpecsColor.LeakMin), num - (double) checked (this.PST.SpecsColor.LeakMax + System.Math.Abs(this.PST.SpecsColor.LeakMin)), "Leak Range");
        }
        else
        {
          this.lblTitleLeak_C.BackColor = Color.Lime;
          this.lblMeasLeak_C.BackColor = Color.Lime;
          this.lblSpecLeak_C.BackColor = Color.Lime;
        }
        if (this.PST.CResults.PF.VentDeltaPMin == -1)
        {
          this.lblTitleVent_C.BackColor = Color.Red;
          this.lblMeasVent_C.BackColor = Color.Red;
          this.lblSpecVent_C.BackColor = Color.Red;
          this.lblSummary_PSTColor.Text = "Color: Failed";
          this.lblSummary_PSTColor.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart2, "ChartArea1", AxisName.X, this.PST.SpecsColor.VentTime, this.PST.CDataPoints.PT3X, "Vent Range");
        }
        else
        {
          this.lblTitleVent_C.BackColor = Color.Lime;
          this.lblMeasVent_C.BackColor = Color.Lime;
          this.lblSpecVent_C.BackColor = Color.Lime;
        }
        if (!this.PST.CResults.PF.TubeEvacDeltaPressure)
        {
          this.lblTitleTubeEvac_C.BackColor = Color.Red;
          this.lblMeasTubeEvac_C.BackColor = Color.Red;
          this.lblSpecTubeEvac_C.BackColor = Color.Red;
          this.lblSummary_PSTColor.Text = "Color: Failed";
          this.lblSummary_PSTColor.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
          this.TestStatus = false;
          this.AddStripLine(this.Chart2, "ChartArea1", AxisName.Y, (double) System.Math.Abs(this.PST.SpecsColor.TubeEvacDeltaPressure), this.PST.CDataPoints.PT8Y + (double) System.Math.Abs(this.PST.SpecsColor.TubeEvacDeltaPressure), "Tube Evac");
        }
        else
        {
          this.lblTitleTubeEvac_C.BackColor = Color.Lime;
          this.lblMeasTubeEvac_C.BackColor = Color.Lime;
          this.lblSpecTubeEvac_C.BackColor = Color.Lime;
        }
        if (!this.PST.KResults.PF.DerivCnt)
        {
          RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
          rectangleAnnotation.AnchorX = 40.0;
          rectangleAnnotation.AnchorY = 23.0;
          rectangleAnnotation.AllowMoving = true;
          rectangleAnnotation.AllowAnchorMoving = true;
          rectangleAnnotation.AllowResizing = true;
          rectangleAnnotation.AllowSelecting = true;
          rectangleAnnotation.Text = "Too many derivatives.\r\nShape of curve is not recognized.\r\nConsider this a warning and not a failure.";
          rectangleAnnotation.ForeColor = Color.Black;
          rectangleAnnotation.Font = new Font("Arial", 8f);
          rectangleAnnotation.LineWidth = 2;
          rectangleAnnotation.BackColor = Color.Yellow;
          rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
          this.Chart1.Annotations.Add((Annotation) rectangleAnnotation);
        }
        if (!this.PST.CResults.PF.DerivCnt)
        {
          RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
          rectangleAnnotation.AnchorX = 40.0;
          rectangleAnnotation.AnchorY = 23.0;
          rectangleAnnotation.AllowMoving = true;
          rectangleAnnotation.AllowAnchorMoving = true;
          rectangleAnnotation.AllowResizing = true;
          rectangleAnnotation.AllowSelecting = true;
          rectangleAnnotation.Text = "Too many derivatives.\r\nShape of curve is not recognized.\r\nConsider this a warning and not a failure.";
          rectangleAnnotation.ForeColor = Color.Black;
          rectangleAnnotation.Font = new Font("Arial", 8f);
          rectangleAnnotation.LineWidth = 2;
          rectangleAnnotation.BackColor = Color.Yellow;
          rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
          this.Chart2.Annotations.Add((Annotation) rectangleAnnotation);
        }
        if (!this.PST.KResults.PF.DryPHA)
        {
          Color yellow = Color.Yellow;
          if (!this.PST.SpecsBlack.AllowWetPHA)
          {
            string str = "Wet PHA detected. Wet PHAs are not allowed.\r\n\r\nTest fails";
            Color red = Color.Red;
            this.lblSummary_PSTBlack.Text = "Black: Failed";
            this.lblSummary_PSTBlack.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
            this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
            this.TestStatus = false;
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            int num = !this.PST.KResults.PF.DerivCnt ? 45 : 23;
            rectangleAnnotation.AnchorX = 40.0;
            rectangleAnnotation.AnchorY = (double) num;
            rectangleAnnotation.AllowMoving = true;
            rectangleAnnotation.AllowAnchorMoving = true;
            rectangleAnnotation.AllowResizing = true;
            rectangleAnnotation.AllowSelecting = true;
            rectangleAnnotation.Text = str;
            rectangleAnnotation.ForeColor = Color.Black;
            rectangleAnnotation.Font = new Font("Arial", 8f);
            rectangleAnnotation.LineWidth = 2;
            rectangleAnnotation.BackColor = red;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
            this.Chart1.Annotations.Add((Annotation) rectangleAnnotation);
          }
        }
        if (!this.PST.CResults.PF.DryPHA)
        {
          Color yellow = Color.Yellow;
          if (!this.PST.SpecsColor.AllowWetPHA)
          {
            string str = "Wet PHA detected. Wet PHAs are not allowed.\r\n\r\nTest fails";
            Color red = Color.Red;
            this.lblSummary_PSTColor.Text = "Color: Failed";
            this.lblSummary_PSTColor.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
            this.MetroTabItem2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
            this.TestStatus = false;
            int num = !this.PST.CResults.PF.DerivCnt ? 45 : 23;
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            rectangleAnnotation.AnchorX = 40.0;
            rectangleAnnotation.AnchorY = (double) num;
            rectangleAnnotation.AllowMoving = true;
            rectangleAnnotation.AllowAnchorMoving = true;
            rectangleAnnotation.AllowResizing = true;
            rectangleAnnotation.AllowSelecting = true;
            rectangleAnnotation.Text = str;
            rectangleAnnotation.ForeColor = Color.Black;
            rectangleAnnotation.Font = new Font("Arial", 8f);
            rectangleAnnotation.LineWidth = 2;
            rectangleAnnotation.BackColor = red;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
            this.Chart2.Annotations.Add((Annotation) rectangleAnnotation);
          }
        }
        ChartUtilities.AddAnnotations("PT1: " + Conversions.ToString(this.PST.KDataPoints.PT1X) + "," + Conversions.ToString(this.PST.KDataPoints.PT1Y), this.Chart1, Conversions.ToInteger(this.PST.KDataPoints.PT1Index));
        ChartUtilities.AddAnnotations("PT2: " + Conversions.ToString(this.PST.KDataPoints.PT2X) + "," + Conversions.ToString(this.PST.KDataPoints.PT2Y), this.Chart1, Conversions.ToInteger(this.PST.KDataPoints.PT2Index));
        ChartUtilities.AddAnnotations("PT3: " + Conversions.ToString(this.PST.KDataPoints.PT3X) + "," + Conversions.ToString(this.PST.KDataPoints.PT3Y), this.Chart1, this.PST.KDataPoints.PT3Index);
        ChartUtilities.AddAnnotations("PT4: " + Conversions.ToString(this.PST.KDataPoints.PT4X) + "," + Conversions.ToString(this.PST.KDataPoints.PT4Y), this.Chart1, this.PST.KDataPoints.PT4Index);
        ChartUtilities.AddAnnotations("PT5: " + Conversions.ToString(this.PST.KDataPoints.PT5X) + "," + Conversions.ToString(this.PST.KDataPoints.PT5Y), this.Chart1, this.PST.KDataPoints.PT5Index);
        if (this.PST.SpecsBlack.AllowWetPHA)
          ChartUtilities.AddAnnotations("PT6: " + Conversions.ToString(this.PST.KDataPoints.PT6X) + "," + Conversions.ToString(this.PST.KDataPoints.PT6Y), this.Chart1, this.PST.KDataPoints.PT6Index);
        if (this.PST.SpecsBlack.AllowWetPHA && this.PST.KDataPoints.PT7Index != this.PST.KDataPoints.PT3Index)
          ChartUtilities.AddAnnotations("PT7: " + Conversions.ToString(this.PST.KDataPoints.PT7X) + ", " + Conversions.ToString(this.PST.KDataPoints.PT7Y), this.Chart1, this.PST.KDataPoints.PT7Index);
        ChartUtilities.AddAnnotations("PT1: " + Conversions.ToString(this.PST.CDataPoints.PT1X) + "," + Conversions.ToString(this.PST.CDataPoints.PT1Y), this.Chart2, Conversions.ToInteger(this.PST.CDataPoints.PT1Index));
        ChartUtilities.AddAnnotations("PT2: " + Conversions.ToString(this.PST.CDataPoints.PT2X) + "," + Conversions.ToString(this.PST.CDataPoints.PT2Y), this.Chart2, Conversions.ToInteger(this.PST.CDataPoints.PT2Index));
        ChartUtilities.AddAnnotations("PT3: " + Conversions.ToString(this.PST.CDataPoints.PT3X) + "," + Conversions.ToString(this.PST.CDataPoints.PT3Y), this.Chart2, this.PST.CDataPoints.PT3Index);
        ChartUtilities.AddAnnotations("PT4: " + Conversions.ToString(this.PST.CDataPoints.PT4X) + "," + Conversions.ToString(this.PST.CDataPoints.PT4Y), this.Chart2, this.PST.CDataPoints.PT4Index);
        ChartUtilities.AddAnnotations("PT5: " + Conversions.ToString(this.PST.CDataPoints.PT5X) + "," + Conversions.ToString(this.PST.CDataPoints.PT5Y), this.Chart2, this.PST.CDataPoints.PT5Index);
        if (this.PST.SpecsColor.AllowWetPHA)
          ChartUtilities.AddAnnotations("PT6: " + Conversions.ToString(this.PST.CDataPoints.PT6X) + "," + Conversions.ToString(this.PST.CDataPoints.PT6Y), this.Chart2, this.PST.CDataPoints.PT6Index);
        if (!this.PST.SpecsColor.AllowWetPHA || this.PST.CDataPoints.PT7Index == this.PST.CDataPoints.PT3Index)
          return;
        ChartUtilities.AddAnnotations("PT7: " + Conversions.ToString(this.PST.CDataPoints.PT7X) + ", " + Conversions.ToString(this.PST.CDataPoints.PT7Y), this.Chart2, this.PST.CDataPoints.PT7Index);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void SetPSTSpecLabelText(dlgPSTResults.Channels Channel, Specifications Specs)
    {
      if (Channel == dlgPSTResults.Channels.Black)
      {
        this.lblSpecPressure_K.Text = Conversions.ToString(Specs.PressureMin) + " / " + Conversions.ToString(Specs.PressureMax);
        this.lblSpecLeak_K.Text = Conversions.ToString(Specs.LeakMin) + " / " + Conversions.ToString(Specs.LeakMax);
        this.lblSpecTubeEvac_K.Text = "< " + Conversions.ToString(System.Math.Round(new Decimal(Specs.TubeEvacDeltaPressure), 1));
        if (this.PST.KResults.PF.VentDeltaPMin < 1)
        {
          this.lblSpecVent_K.Text = "> " + Conversions.ToString(System.Math.Round(Specs.VentDeltaPMin, 3));
        }
        else
        {
          if (this.PST.KResults.PF.VentDeltaPMin != 1)
            return;
          this.lblSpecVent_K.Text = "<" + Conversions.ToString(Specs.VentDxDt2Threshold) + ", > " + Conversions.ToString(System.Math.Round(Specs.VentDeltaPMin, 3) * 0.5);
          this.lblTitleVent_K.Text = "Vent D2x/Dt2, Vent Delta P";
        }
      }
      else
      {
        this.lblSpecPressure_C.Text = Conversions.ToString(Specs.PressureMin) + " / " + Conversions.ToString(Specs.PressureMax);
        this.lblSpecLeak_C.Text = Conversions.ToString(Specs.LeakMin) + " / " + Conversions.ToString(Specs.LeakMax);
        this.lblSpecTubeEvac_C.Text = "< " + Conversions.ToString(System.Math.Round(new Decimal(Specs.TubeEvacDeltaPressure), 1));
        if (this.PST.CResults.PF.VentDeltaPMin < 1)
          this.lblSpecVent_C.Text = "> " + Conversions.ToString(System.Math.Round(Specs.VentDeltaPMin, 3));
        else if (this.PST.CResults.PF.VentDeltaPMin == 1)
        {
          this.lblSpecVent_C.Text = "<" + Conversions.ToString(Specs.VentDxDt2Threshold) + ", > " + Conversions.ToString(System.Math.Round(Specs.VentDeltaPMin, 3) * 0.5);
          this.lblTitleVent_C.Text = "Vent D2x/Dt2, Vent Delta P";
        }
      }
    }

    private void AddStripLine(
      Chart myChart,
      string myArea,
      AxisName myAxis,
      double stpWidth,
      double stpIntervalOffset,
      string stpText)
    {
      try
      {
        StripLine stripLine = new StripLine();
        stripLine.BackColor = Color.FromArgb((int) byte.MaxValue, Color.Red);
        stripLine.StripWidth = stpWidth;
        stripLine.IntervalOffset = stpIntervalOffset;
        stripLine.Text = stpText;
        stripLine.ForeColor = Color.Yellow;
        stripLine.TextOrientation = TextOrientation.Horizontal;
        stripLine.Font = new Font("Arial", 8f);
        if (myAxis == AxisName.X)
        {
          stripLine.TextAlignment = StringAlignment.Center;
          stripLine.TextLineAlignment = StringAlignment.Near;
          myChart.ChartAreas[myArea].AxisX.StripLines.Add(stripLine);
        }
        else
        {
          stripLine.TextAlignment = StringAlignment.Near;
          stripLine.TextLineAlignment = StringAlignment.Center;
          myChart.ChartAreas[myArea].AxisY.StripLines.Add(stripLine);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void FormatPSTChartArea(Chart myChart, string myArea)
    {
      Chart chart = myChart;
      Axis axisX = chart.ChartAreas[myArea].AxisX;
      axisX.LineColor = Color.DarkBlue;
      axisX.LineWidth = 4;
      axisX.Interval = 1.0;
      axisX.MajorTickMark.Interval = 1.0;
      axisX.MajorGrid.LineWidth = 1;
      axisX.MinorGrid.Enabled = true;
      axisX.MinorGrid.Interval = 0.25;
      axisX.MinorGrid.LineColor = Color.FromArgb(200, 142, 141, 93);
      axisX.MinorGrid.LineWidth = 1;
      axisX.MinorTickMark.Enabled = false;
      axisX.IsMarginVisible = false;
      Axis axisY = chart.ChartAreas[myArea].AxisY;
      axisY.LineColor = Color.DarkBlue;
      axisY.LineWidth = 4;
      axisY.Interval = 30.0;
      axisY.MajorTickMark.Interval = 30.0;
      axisY.MinorGrid.Enabled = true;
      axisY.MinorGrid.Interval = 10.0;
      axisY.MinorGrid.LineColor = Color.FromArgb(200, 142, 141, 93);
      axisY.MinorTickMark.Enabled = false;
      axisY.IsMarginVisible = false;
    }

    private void SetChartAxisValues(
      Chart myChart,
      string myArea,
      int ChartSeries,
      PST.Points DataPoints)
    {
      try
      {
        myChart.ChartAreas[myArea].AxisY.Maximum = System.Math.Max(200.0, myChart.Series[ChartSeries].Points.FindMaxByValue().YValues[0] + 20.0);
        myChart.ChartAreas[myArea].AxisY.Minimum = System.Math.Min(0.0, myChart.Series[ChartSeries].Points.FindMinByValue().YValues[0]);
        myChart.ChartAreas[myArea].AxisX.Maximum = System.Math.Max(DataPoints.PT5X + 1.0, 0.0);
        if (DataPoints.PT3X <= 0.0)
          return;
        myChart.ChartAreas[myArea].AxisX.Minimum = DataPoints.PT1X - 1.0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) "Using non-default axis scales");
        ProjectData.ClearProjectError();
      }
    }

    private void LoadHistoryTable()
    {
      string[,] strArray = FileProcessing.ReadDelimitedFile(this.PST.SummaryFileName, ",");
      this.dtHistory.Columns.Add("Indexer");
      int num1 = Information.UBound((Array) strArray, 2);
      int index1 = 0;
      while (index1 <= num1)
      {
        string columnName = strArray[0, index1] == null ? "Unknown" + Conversions.ToString(index1) : strArray[0, index1];
        this.dtHistory.Columns.Add(columnName);
        this.cboHistory_XVal.Items.Add((object) columnName);
        this.cboHistory_YVal.Items.Add((object) columnName);
        this.cboHistory_Series.Items.Add((object) columnName);
        this.cboRunCharts.Items.Add((object) columnName);
        checked { ++index1; }
      }
      int num2 = Information.UBound((Array) strArray);
      int index2 = 1;
      while (index2 <= num2)
      {
        Debug.Print(Conversions.ToString(index2));
        DataRow row = this.dtHistory.NewRow();
        row[0] = (object) index2;
        int num3 = checked (this.dtHistory.Columns.Count - 2);
        int index3 = 0;
        while (index3 <= num3)
        {
          if (strArray[index2, index3] != null)
            row[checked (index3 + 1)] = (object) strArray[index2, index3];
          checked { ++index3; }
        }
        this.dtHistory.Rows.Add(row);
        checked { ++index2; }
      }
    }

    private void AddHistoryData(string MetricName)
    {
      try
      {
        ChartUtilities.ClearChart(this.Chart3);
        List<dlgPSTResults.HistoryData> dataSource1 = new List<dlgPSTResults.HistoryData>();
        string summaryFileName = this.PST.SummaryFileName;
        string str = ",";
        if (!MyProject.Computer.FileSystem.FileExists(summaryFileName))
          return;
        int num1 = 0;
        using (TextFieldParser textFieldParser = new TextFieldParser(summaryFileName))
        {
          textFieldParser.SetDelimiters(str);
          int index1 = 0;
          while (!textFieldParser.EndOfData)
          {
            string[] source = textFieldParser.ReadFields();
            if (textFieldParser.LineNumber == 2L)
            {
              string[] array = new string[checked (((IEnumerable<string>) source).Count<string>() - 1 + 1)];
              int num2 = checked (((IEnumerable<string>) source).Count<string>() - 1);
              int index2 = 0;
              while (index2 <= num2)
              {
                array[index2] = source[index2];
                checked { ++index2; }
              }
              index1 = Array.IndexOf<string>(array, MetricName);
            }
            else
            {
              dataSource1.Add(new dlgPSTResults.HistoryData()
              {
                Indexer = num1,
                RunChartYVal = (object) source[index1]
              });
              checked { ++num1; }
            }
          }
        }
        if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataSource1[0].RunChartYVal)))
        {
          this.Chart3.Series.Add("KMax");
          this.Chart3.Series["KMax"].Points.DataBind((IEnumerable) dataSource1, "Indexer", "RunChartYVal", (string) null);
          this.Chart3.Series["KMax"].Enabled = false;
          this.Chart3.DataManipulator.Group("AVE", 4.0, IntervalType.Number, "KMax", "Ẋ");
          int num3 = 0;
          int num4 = checked (this.Chart3.Series["Ẋ"].Points.Count - 1);
          int index3 = 0;
          while (index3 <= num4)
          {
            this.Chart3.Series["Ẋ"].Points[index3].XValue = (double) num3;
            checked { ++num3; }
            checked { ++index3; }
          }
          this.Chart3.DataManipulator.Group("HiLo", 4.0, IntervalType.Number, "KMax", "HiLo");
          this.Chart3.Series["HiLo"].Enabled = false;
          List<dlgPSTResults.ChartData> dataSource2 = new List<dlgPSTResults.ChartData>();
          long index4 = 0;
          try
          {
            foreach (DataPoint point in (Collection<DataPoint>) this.Chart3.Series["HiLo"].Points)
            {
              dataSource2.Add(new dlgPSTResults.ChartData()
              {
                YVal = this.Chart3.Series["HiLo"].Points[checked ((int) index4)].YValues[0] - this.Chart3.Series["HiLo"].Points[checked ((int) index4)].YValues[1],
                Indexer = index4
              });
              checked { ++index4; }
            }
          }
          finally
          {
            IEnumerator<DataPoint> enumerator;
            enumerator?.Dispose();
          }
          this.Chart3.Series.Add("r");
          Series series1 = this.Chart3.Series["r"];
          series1.Points.DataBind((IEnumerable) dataSource2, "Indexer", "YVal", (string) null);
          series1.ChartArea = "ChartArea2";
          double IntervalOffset1 = this.Chart3.DataManipulator.Statistics.Mean("Ẋ");
          double IntervalOffset2 = this.Chart3.DataManipulator.Statistics.Mean("r");
          double num5 = IntervalOffset1 + 0.729 * IntervalOffset2;
          double IntervalOffset3 = IntervalOffset1 - 0.729 * IntervalOffset2;
          double num6 = IntervalOffset2 * 2.282;
          double IntervalOffset4 = IntervalOffset2 * 0.0;
          this.Chart3.ChartAreas["ChartArea1"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, IntervalOffset3, num5 - IntervalOffset3, Color.Orange));
          this.Chart3.ChartAreas["ChartArea1"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Ẍ", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, IntervalOffset1, Color.Red, 2));
          this.Chart3.ChartAreas["ChartArea2"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, IntervalOffset4, num6 - IntervalOffset4, Color.Orange));
          this.Chart3.ChartAreas["ChartArea2"].AxisY.StripLines.Add(ChartUtilities.GetStripLine("Ṙ", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, IntervalOffset2, Color.Red, 2));
          ChartUtilities.AddChartTitle("Ẋ", this.Chart3, "ChartArea1", Docking.Top);
          ChartUtilities.AddChartTitle("Ṙ", this.Chart3, "ChartArea2", Docking.Top);
          this.Chart3.Legends[0].Enabled = false;
          this.Chart3.ChartAreas["ChartArea1"].AxisY.Title = "Max Pressure";
          this.Chart3.ChartAreas["ChartArea2"].AxisY.Title = "Max Pressure";
          this.Chart3.ChartAreas["ChartArea1"].AxisX.Title = "Sample Group";
          this.Chart3.ChartAreas["ChartArea2"].AxisX.Title = "Sample Group";
          this.Chart3.ChartAreas["ChartArea1"].AxisY.Minimum = System.Math.Min(System.Math.Round(IntervalOffset3 - IntervalOffset3 * 0.1, 0), System.Math.Round(this.Chart3.Series["Ẋ"].Points.FindMinByValue().YValues[0] - this.Chart3.Series["Ẋ"].Points.FindMinByValue().YValues[0] * 0.1, 0));
          this.Chart3.ChartAreas["ChartArea1"].AxisY.Maximum = System.Math.Max(System.Math.Round(num5 + num5 * 0.1, 0), System.Math.Round(this.Chart3.Series["Ẋ"].Points.FindMaxByValue().YValues[0] + this.Chart3.Series["Ẋ"].Points.FindMaxByValue().YValues[0] * 0.1, 0));
          this.Chart3.ChartAreas["ChartArea2"].AxisY.Maximum = System.Math.Max(System.Math.Round(num6 + num6 * 0.1, 0), System.Math.Round(this.Chart3.Series["r"].Points.FindMaxByValue().YValues[0] + this.Chart3.Series["r"].Points.FindMaxByValue().YValues[0] * 0.1, 0));
          this.Chart3.ChartAreas["ChartArea1"].AxisX.Minimum = 0.0;
          this.Chart3.ChartAreas["ChartArea2"].AxisX.Minimum = 0.0;
          Axis axisX1 = this.Chart3.ChartAreas["ChartArea1"].AxisX;
          axisX1.MajorGrid.Interval = (double) checked ((int) System.Math.Round(unchecked (0.2 * (double) this.Chart3.Series["Ẋ"].Points.Count)));
          axisX1.MajorTickMark.Interval = this.Chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval;
          axisX1.Interval = this.Chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval;
          axisX1.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4.0, checked ((int) System.Math.Round(this.Chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval)));
          axisX1.MinorGrid.LineColor = Color.LightGray;
          axisX1.MinorGrid.Enabled = true;
          Axis axisX2 = this.Chart3.ChartAreas["ChartArea2"].AxisX;
          axisX2.MajorGrid.Interval = (double) checked ((int) System.Math.Round(unchecked (0.2 * (double) this.Chart3.Series["r"].Points.Count)));
          axisX2.MajorTickMark.Interval = this.Chart3.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval;
          axisX2.Interval = this.Chart3.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval;
          axisX2.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4.0, checked ((int) System.Math.Round(this.Chart3.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval)));
          axisX2.MinorGrid.LineColor = Color.LightGray;
          axisX2.MinorGrid.Enabled = true;
          int num7 = checked (this.Chart3.Series.Count - 1);
          int index5 = 0;
          while (index5 <= num7)
          {
            Series series2 = this.Chart3.Series[index5];
            series2.ChartType = SeriesChartType.Line;
            series2.BorderWidth = 1;
            series2.Color = Color.Blue;
            series2.MarkerStyle = MarkerStyle.Circle;
            series2.MarkerSize = 6;
            series2.MarkerColor = Color.Blue;
            checked { ++index5; }
          }
          this.lblHistory_TotalUnits.Text = "Total Units in History: " + Conversions.ToString(this.Chart3.Series["KMax"].Points.Count);
        }
        else
        {
          int num8 = (int) Interaction.MsgBox((object) "Invalid non-numeric value selected.", MsgBoxStyle.Critical);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void AddHistoryData2(string MetricName)
    {
      try
      {
        this.Chart4.Series.Clear();
        this.Chart4.Series.Add("0");
        this.Chart4.DataSource = (object) this.dtHistory;
        this.Chart4.Series[0].XValueMember = "Test_Date";
        this.Chart4.Series[0].YValueMembers = "K_MAX_PRESSURE";
        try
        {
          foreach (Series series in (Collection<Series>) this.Chart4.Series)
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

    private void AddHistoryData3(string xVal, string yVal, string groupVal)
    {
      try
      {
        this.Chart4.Series.Clear();
        this.Chart4.DataBindCrossTable((IEnumerable) this.dtHistory.AsEnumerable(), groupVal, xVal, yVal, (string) null);
        try
        {
          foreach (Series series in (Collection<Series>) this.Chart4.Series)
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

    private void AddMechChecks()
    {
      try
      {
        ctrlMechChecks ctrlMechChecks = new ctrlMechChecks(this.PST.MechChecks);
        ctrlMechChecks.Visible = true;
        ctrlMechChecks.Dock = DockStyle.Fill;
        this.MetroTabPanel4.Controls.Add((Control) ctrlMechChecks);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Logging.AddLogEntry((object) this, "Error adding mech checks. \r\n\r\n" + ex.ToString(), EventLogEntryType.Error, 1);
        int num = (int) Interaction.MsgBox((object) "Error loading Mech checks. This may invalidate results display.\r\n\r\nError details have been added to the log.");
        ProjectData.ClearProjectError();
      }
    }

    private void AddSummaryData()
    {
      try
      {
        this.lstSummaryMechChecks.Columns[0].Width = this.lstSummaryMechChecks.Width;
        int num = checked (this.PST.MechChecks.Count - 1);
        int index = 0;
        while (index <= num)
        {
          int imageIndex = 0;
          if (!this.PST.MechChecks[index].Results & this.PST.MechChecks[index].SpecFunction == PST.SpecFunction.PassFail)
          {
            imageIndex = 1;
            this.MetroTabItem4.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
            this.MetroTabItem4.Tag = (object) "Error";
            this.TestStatus = false;
          }
          else if (!this.PST.MechChecks[index].Results & this.PST.MechChecks[index].SpecFunction == PST.SpecFunction.Monitor)
          {
            imageIndex = 2;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.MetroTabItem4.Tag.ToString().ToLower(), "error", false) != 0)
            {
              this.MetroTabItem4.Image = (Image) FUEL.My.Resources.Resources.warning_sm;
              this.MetroTabItem4.Tag = (object) "Warning";
            }
          }
          this.lstSummaryMechChecks.Items.Add(this.PST.MechChecks[index].Name + ": " + this.PST.MechChecks[index].Value.ToString(), imageIndex);
          checked { ++index; }
        }
        this.lblSummary_FuelRev.Text = "FUEL Rev: " + PST.TestInformation.FuelRev.ToString();
        this.lblSummary_ScriptRev.Text = "Script Rev: " + this.PST.TestInfo.ScriptRev.ToString();
        this.lblSummary_ScriptProduct.Text = "Script Product: " + this.PST.TestInfo.ScriptProduct;
        this.lblSummary_TestDate.Text = "Test Date: " + this.PST.TestInfo.TestDate.ToString();
        this.lblSummary_TestTime.Text = "Test Time: " + this.PST.TestInfo.TestTime.ToString();
        this.lblSummary_TestID.Text = "Test ID: " + this.PST.TestID;
        this.lblSummary_Run.Text = "Run: " + Conversions.ToString(this.PST.TestInfo.RunNumber);
        this.lblSummary_SerialNum.Text = "Serial Number: " + this.PST.PrinterInfo.SerialNum;
        this.lblSummary_FW.Text = "FW Rev: " + this.PST.PrinterInfo.FWRev;
        this.lblSummary_EngPgCnt.Text = "Engine Pg Cnt: " + this.PST.PrinterInfo.EnginePgCnt.ToString();
        this.lblHidden_TestID.Text = this.PST.TestID;
        this.lblHidden_Date.Text = this.PST.TestInfo.TestDate;
        this.lblHidden_Time.Text = this.PST.TestInfo.TestTime;
        this.lblHidden_Serial.Text = this.PST.PrinterInfo.SerialNum;
        this.lblHidden_RunNum.Text = Conversions.ToString(this.PST.TestInfo.RunNumber);
        this.lblHidden_FUELRev.Text = "FUELRev: " + PST.TestInformation.FuelRev.ToString();
        this.lblHidden_ScriptRev.Text = "ScriptRev: " + this.PST.TestInfo.ScriptRev.ToString();
        this.lblHidden_Product.Text = this.PST.TestInfo.ScriptProduct;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public string GetEnglishResult(bool Val)
    {
      if (Val)
        return "Passed";
      return !Val ? "Failed" : "err";
    }

    private void AddPSTDocumention()
    {
      string dataPath = modCommonCode.GetDataPath();
      this.rtbPSTDocs_Intro.LoadFile(dataPath + "\\PSTDocs\\PSTIntro.rtf");
      this.rtbPSTDocs_PSTOutputs.LoadFile(dataPath + "\\PSTDocs\\PSTOutput.rtf");
      this.rtbPSTDocs_NoPressure.LoadFile(dataPath + "\\PSTDocs\\PSTNoPressure.rtf");
      this.rtbPSTDocs_DelayedPressure.LoadFile(dataPath + "\\PSTDocs\\PSTDelayedVacuum.rtf");
      this.rtbPSTDocs_CyclicalPressure.LoadFile(dataPath + "\\PSTDocs\\PSTCyclicalPressureDrop.rtf");
      this.rtbPSTDocs_PressureFluctuates.LoadFile(dataPath + "\\PSTDocs\\PSTPressureFluctuates.rtf");
    }

    private Image ToBitmap(ref Control c)
    {
      Bitmap bitmap = new Bitmap(c.Width, c.Height);
      c.DrawToBitmap(bitmap, new Rectangle(0, 0, c.Width, c.Height));
      return (Image) bitmap;
    }

    private void cmdSaveFormImage_Click(object sender, EventArgs e)
    {
      this.PrepFormForBitMap(true);
      Control c = (Control) this;
      Image bitmap = this.ToBitmap(ref c);
      Debug.Print(this.PST.SaveFileLocation);
      bitmap.Save(Path.Combine(this.PST.SaveFileLocation, this.PST.TestID + "-" + this.PST.PrinterInfo.SerialNum + "-" + Conversions.ToString(this.PST.TestInfo.RunNumber) + ".bmp"));
      this.PrepFormForBitMap(false);
    }

    private void PrepFormForBitMap(bool Start)
    {
      this.lblHidden_TestID.Visible = Start;
      this.lblHidden_Date.Visible = Start;
      this.lblHidden_Time.Visible = Start;
      this.lblHidden_Serial.Visible = Start;
      this.lblHidden_RunNum.Visible = Start;
      this.lblHidden_FUELRev.Visible = Start;
      this.lblHidden_ScriptRev.Visible = Start;
      this.lblHidden_Product.Visible = Start;
      this.lblHidden_TestInfo.Visible = Start;
    }

    private void CopyToClipBoard()
    {
      this.PrepFormForBitMap(true);
      ClipboardProxy clipboard = MyProject.Computer.Clipboard;
      Control c = (Control) this;
      Image bitmap = this.ToBitmap(ref c);
      clipboard.SetImage(bitmap);
      this.PrepFormForBitMap(false);
    }

    private void cboRunCharts_SelectedIndexChanged(object sender, EventArgs e) => this.AddHistoryData(this.cboRunCharts.SelectedItem.ToString());

    private void HistoryChartTypeChanged(object sender, EventArgs e)
    {
      this.Chart3.Visible = false;
      this.Chart4.Visible = false;
      this.cboRunCharts.Visible = false;
      this.cboHistory_XVal.Visible = false;
      this.cboHistory_YVal.Visible = false;
      this.cboHistory_Series.Visible = false;
      this.lblHistory_XVal.Visible = false;
      this.lblHistory_YVal.Visible = false;
      this.lblHistory_Series.Visible = false;
      this.cmdHistory_ChartIt.Visible = false;
      this.cmdHistory_DataGrid_Edit.Visible = false;
      this.sgcHistory.Visible = false;
      object Left = NewLateBinding.LateGet(sender, (System.Type) null, "Name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "cmdShowRuncharts", false))
      {
        this.cmdDataSelect.Text = "Now Showing Run Charts";
        this.AddHistoryData(this.cboRunCharts.SelectedItem.ToString());
        this.cboRunCharts.Visible = true;
        this.Chart3.Visible = true;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "cmdShowRegularcharts", false))
      {
        this.cmdDataSelect.Text = "Now Showing Mech Check Data";
        this.Chart4.Visible = true;
        this.cboHistory_XVal.Visible = true;
        this.cboHistory_YVal.Visible = true;
        this.cboHistory_Series.Visible = true;
        this.lblHistory_XVal.Visible = true;
        this.lblHistory_YVal.Visible = true;
        this.lblHistory_Series.Visible = true;
        this.cmdHistory_ChartIt.Visible = true;
      }
      else
      {
        if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "cmdShowDataGrid", false))
          return;
        this.cmdDataSelect.Text = "Now Showing Full History Data";
        this.sgcHistory.Visible = true;
        this.cmdHistory_DataGrid_Edit.Visible = true;
      }
    }

    private void cmdHistory_ChartIt_Click(object sender, EventArgs e) => this.AddHistoryData3(this.cboHistory_XVal.SelectedItem.ToString(), this.cboHistory_YVal.SelectedItem.ToString(), this.cboHistory_Series.SelectedItem.ToString());

    private void cmdHistory_DataGrid_Edit_Click(object sender, EventArgs e)
    {
      this.sgcHistory.PrimaryGrid.AllowSelection = this.cmdHistory_DataGrid_Edit.Checked;
      this.sgcHistory.PrimaryGrid.AllowRowDelete = this.cmdHistory_DataGrid_Edit.Checked;
      this.sgcHistory.PrimaryGrid.ReadOnly = !this.cmdHistory_DataGrid_Edit.Checked;
    }

    private void ButtonX2_Click(object sender, EventArgs e)
    {
      string str = modCommonCode.GetDataPath() + "Help\\PST.exe";
      new Process() { StartInfo = { FileName = str } }.Start();
    }

    private void ButtonItem4_Click(object sender, EventArgs e)
    {
      this.PrepFormForBitMap(true);
      Control c = (Control) this;
      this.ToBitmap(ref c).Save(Path.Combine(this.PST.SaveFileLocation, this.PST.TestID + "-" + this.PST.PrinterInfo.SerialNum + "-" + Conversions.ToString(this.PST.TestInfo.RunNumber) + ".bmp"));
      this.PrepFormForBitMap(false);
    }

    private enum Channels
    {
      Black,
      Color,
    }

    private class ChartData
    {
      [DebuggerNonUserCode]
      public ChartData()
      {
      }

      public long Indexer { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double XVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double YVal { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }
    }

    private class HistoryData
    {
      [DebuggerNonUserCode]
      public HistoryData()
      {
      }

      public int Indexer { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public object RunChartYVal
      {
        [DebuggerNonUserCode] get => this._RunChartYVal;
        [DebuggerNonUserCode] set => this._RunChartYVal = RuntimeHelpers.GetObjectValue(value);
      }
    }
  }
}
