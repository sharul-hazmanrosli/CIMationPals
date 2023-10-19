// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlTriage
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using FUEL.My;
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
  public class ctrlTriage : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    [AccessedThroughProperty("PictureBox6")]
    private PictureBox _PictureBox6;
    [AccessedThroughProperty("PictureBox5")]
    private PictureBox _PictureBox5;
    [AccessedThroughProperty("PictureBox4")]
    private PictureBox _PictureBox4;
    [AccessedThroughProperty("PictureBox3")]
    private PictureBox _PictureBox3;
    [AccessedThroughProperty("PictureBox2")]
    private PictureBox _PictureBox2;
    [AccessedThroughProperty("sldpTriage")]
    private SlidePanel _sldpTriage;
    [AccessedThroughProperty("rtbTriage")]
    private RichTextBox _rtbTriage;
    [AccessedThroughProperty("PictureBox7")]
    private PictureBox _PictureBox7;
    [AccessedThroughProperty("PictureBox8")]
    private PictureBox _PictureBox8;
    [AccessedThroughProperty("PictureBox9")]
    private PictureBox _PictureBox9;
    [AccessedThroughProperty("lblBack")]
    private ReflectionLabel _lblBack;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;

    [DebuggerNonUserCode]
    static ctrlTriage()
    {
    }

    [DebuggerNonUserCode]
    public ctrlTriage()
    {
      this.Resize += new EventHandler(this.ctrlTriage_Resize);
      this.Load += new EventHandler(this.ctrlTriage_Load);
      ctrlTriage.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlTriage.__ENCList)
      {
        if (ctrlTriage.__ENCList.Count == ctrlTriage.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlTriage.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlTriage.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlTriage.__ENCList[index1] = ctrlTriage.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlTriage.__ENCList.RemoveRange(index1, checked (ctrlTriage.__ENCList.Count - index1));
          ctrlTriage.__ENCList.Capacity = ctrlTriage.__ENCList.Count;
        }
        ctrlTriage.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ctrlTriage));
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.PictureBox6 = new PictureBox();
      this.PictureBox5 = new PictureBox();
      this.PictureBox4 = new PictureBox();
      this.PictureBox3 = new PictureBox();
      this.PictureBox2 = new PictureBox();
      this.PictureBox1 = new PictureBox();
      this.PictureBox7 = new PictureBox();
      this.PictureBox8 = new PictureBox();
      this.PictureBox9 = new PictureBox();
      this.sldpTriage = new SlidePanel();
      this.rtbTriage = new RichTextBox();
      this.lblBack = new ReflectionLabel();
      this.LabelX1 = new LabelX();
      this.TableLayoutPanel1.SuspendLayout();
      ((ISupportInitialize) this.PictureBox6).BeginInit();
      ((ISupportInitialize) this.PictureBox5).BeginInit();
      ((ISupportInitialize) this.PictureBox4).BeginInit();
      ((ISupportInitialize) this.PictureBox3).BeginInit();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      ((ISupportInitialize) this.PictureBox7).BeginInit();
      ((ISupportInitialize) this.PictureBox8).BeginInit();
      ((ISupportInitialize) this.PictureBox9).BeginInit();
      this.sldpTriage.SuspendLayout();
      this.SuspendLayout();
      this.TableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TableLayoutPanel1.BackColor = Color.Gold;
      this.TableLayoutPanel1.ColumnCount = 3;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33332f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox6, 2, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox4, 0, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox3, 2, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox2, 1, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox1, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox7, 0, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox8, 1, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox9, 2, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.PictureBox5, 1, 1);
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      Point point1 = new Point(3, 37);
      Point point2 = point1;
      tableLayoutPanel1_1.Location = point2;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 3;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      Size size1 = new Size(811, 658);
      Size size2 = size1;
      tableLayoutPanel1_2.Size = size2;
      this.TableLayoutPanel1.TabIndex = 0;
      this.PictureBox6.Image = (Image) componentResourceManager.GetObject("PictureBox6.Image");
      PictureBox pictureBox6_1 = this.PictureBox6;
      point1 = new Point(543, 222);
      Point point3 = point1;
      pictureBox6_1.Location = point3;
      this.PictureBox6.Name = "PictureBox6";
      PictureBox pictureBox6_2 = this.PictureBox6;
      size1 = new Size(264, 213);
      Size size3 = size1;
      pictureBox6_2.Size = size3;
      this.PictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox6.TabIndex = 5;
      this.PictureBox6.TabStop = false;
      this.PictureBox5.Image = (Image) componentResourceManager.GetObject("PictureBox5.Image");
      PictureBox pictureBox5_1 = this.PictureBox5;
      point1 = new Point(273, 222);
      Point point4 = point1;
      pictureBox5_1.Location = point4;
      this.PictureBox5.Name = "PictureBox5";
      PictureBox pictureBox5_2 = this.PictureBox5;
      size1 = new Size(264, 213);
      Size size4 = size1;
      pictureBox5_2.Size = size4;
      this.PictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox5.TabIndex = 4;
      this.PictureBox5.TabStop = false;
      this.PictureBox4.Image = (Image) componentResourceManager.GetObject("PictureBox4.Image");
      PictureBox pictureBox4_1 = this.PictureBox4;
      point1 = new Point(3, 222);
      Point point5 = point1;
      pictureBox4_1.Location = point5;
      this.PictureBox4.Name = "PictureBox4";
      PictureBox pictureBox4_2 = this.PictureBox4;
      size1 = new Size(264, 213);
      Size size5 = size1;
      pictureBox4_2.Size = size5;
      this.PictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox4.TabIndex = 3;
      this.PictureBox4.TabStop = false;
      this.PictureBox3.Image = (Image) componentResourceManager.GetObject("PictureBox3.Image");
      PictureBox pictureBox3_1 = this.PictureBox3;
      point1 = new Point(543, 3);
      Point point6 = point1;
      pictureBox3_1.Location = point6;
      this.PictureBox3.Name = "PictureBox3";
      PictureBox pictureBox3_2 = this.PictureBox3;
      size1 = new Size(265, 213);
      Size size6 = size1;
      pictureBox3_2.Size = size6;
      this.PictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox3.TabIndex = 2;
      this.PictureBox3.TabStop = false;
      this.PictureBox2.Image = (Image) componentResourceManager.GetObject("PictureBox2.Image");
      PictureBox pictureBox2_1 = this.PictureBox2;
      point1 = new Point(273, 3);
      Point point7 = point1;
      pictureBox2_1.Location = point7;
      this.PictureBox2.Name = "PictureBox2";
      PictureBox pictureBox2_2 = this.PictureBox2;
      size1 = new Size(264, 213);
      Size size7 = size1;
      pictureBox2_2.Size = size7;
      this.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox2.TabIndex = 1;
      this.PictureBox2.TabStop = false;
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      PictureBox pictureBox1_1 = this.PictureBox1;
      point1 = new Point(3, 3);
      Point point8 = point1;
      pictureBox1_1.Location = point8;
      this.PictureBox1.Name = "PictureBox1";
      PictureBox pictureBox1_2 = this.PictureBox1;
      size1 = new Size(264, 213);
      Size size8 = size1;
      pictureBox1_2.Size = size8;
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 0;
      this.PictureBox1.TabStop = false;
      this.PictureBox7.Dock = DockStyle.Fill;
      this.PictureBox7.Image = (Image) componentResourceManager.GetObject("PictureBox7.Image");
      PictureBox pictureBox7_1 = this.PictureBox7;
      point1 = new Point(3, 441);
      Point point9 = point1;
      pictureBox7_1.Location = point9;
      this.PictureBox7.Name = "PictureBox7";
      PictureBox pictureBox7_2 = this.PictureBox7;
      size1 = new Size(264, 214);
      Size size9 = size1;
      pictureBox7_2.Size = size9;
      this.PictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox7.TabIndex = 6;
      this.PictureBox7.TabStop = false;
      this.PictureBox8.Dock = DockStyle.Fill;
      this.PictureBox8.Image = (Image) componentResourceManager.GetObject("PictureBox8.Image");
      PictureBox pictureBox8_1 = this.PictureBox8;
      point1 = new Point(273, 441);
      Point point10 = point1;
      pictureBox8_1.Location = point10;
      this.PictureBox8.Name = "PictureBox8";
      PictureBox pictureBox8_2 = this.PictureBox8;
      size1 = new Size(264, 214);
      Size size10 = size1;
      pictureBox8_2.Size = size10;
      this.PictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox8.TabIndex = 7;
      this.PictureBox8.TabStop = false;
      PictureBox pictureBox9_1 = this.PictureBox9;
      point1 = new Point(543, 441);
      Point point11 = point1;
      pictureBox9_1.Location = point11;
      this.PictureBox9.Name = "PictureBox9";
      PictureBox pictureBox9_2 = this.PictureBox9;
      size1 = new Size(100, 50);
      Size size11 = size1;
      pictureBox9_2.Size = size11;
      this.PictureBox9.TabIndex = 8;
      this.PictureBox9.TabStop = false;
      this.sldpTriage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.sldpTriage.AnimationTime = 350;
      this.sldpTriage.AutoScroll = true;
      this.sldpTriage.BackColor = Color.DarkRed;
      this.sldpTriage.Controls.Add((Control) this.rtbTriage);
      this.sldpTriage.Controls.Add((Control) this.lblBack);
      this.sldpTriage.Cursor = Cursors.Hand;
      SlidePanel sldpTriage1 = this.sldpTriage;
      point1 = new Point(623, 498);
      Point point12 = point1;
      sldpTriage1.Location = point12;
      this.sldpTriage.Name = "sldpTriage";
      SlidePanel sldpTriage2 = this.sldpTriage;
      size1 = new Size(159, 228);
      Size size12 = size1;
      sldpTriage2.Size = size12;
      this.sldpTriage.SlideOutButtonVisible = false;
      this.sldpTriage.SlideSide = eSlideSide.Right;
      this.sldpTriage.TabIndex = 1;
      this.sldpTriage.Text = "SlidePanel1";
      this.sldpTriage.UsesBlockingAnimation = false;
      this.rtbTriage.BackColor = SystemColors.Control;
      this.rtbTriage.Cursor = Cursors.Default;
      this.rtbTriage.Dock = DockStyle.Bottom;
      RichTextBox rtbTriage1 = this.rtbTriage;
      point1 = new Point(0, 41);
      Point point13 = point1;
      rtbTriage1.Location = point13;
      this.rtbTriage.Name = "rtbTriage";
      this.rtbTriage.ReadOnly = true;
      RichTextBox rtbTriage2 = this.rtbTriage;
      size1 = new Size(142, 676);
      Size size13 = size1;
      rtbTriage2.Size = size13;
      this.rtbTriage.TabIndex = 0;
      this.rtbTriage.Text = "";
      this.lblBack.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblBack.Cursor = Cursors.Hand;
      ReflectionLabel lblBack1 = this.lblBack;
      point1 = new Point(7, -12);
      Point point14 = point1;
      lblBack1.Location = point14;
      this.lblBack.Name = "lblBack";
      ReflectionLabel lblBack2 = this.lblBack;
      size1 = new Size(57, 53);
      Size size14 = size1;
      lblBack2.Size = size14;
      this.lblBack.TabIndex = 1;
      this.lblBack.Text = "<b><font size=\"+6\" color=\"#B02B2C\">Back</font></b>";
      this.LabelX1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(3, 3);
      Point point15 = point1;
      labelX1_1.Location = point15;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(811, 28);
      Size size15 = size1;
      labelX1_2.Size = size15;
      this.LabelX1.TabIndex = 2;
      this.LabelX1.Text = "Click on the chart the most close resembles the failure that you want to triage";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.sldpTriage);
      this.Controls.Add((Control) this.LabelX1);
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.Name = nameof (ctrlTriage);
      size1 = new Size(817, 698);
      this.Size = size1;
      this.TableLayoutPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.PictureBox6).EndInit();
      ((ISupportInitialize) this.PictureBox5).EndInit();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      ((ISupportInitialize) this.PictureBox1).EndInit();
      ((ISupportInitialize) this.PictureBox7).EndInit();
      ((ISupportInitialize) this.PictureBox8).EndInit();
      ((ISupportInitialize) this.PictureBox9).EndInit();
      this.sldpTriage.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    internal virtual PictureBox PictureBox1
    {
      [DebuggerNonUserCode] get => this._PictureBox1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
        if (this._PictureBox1 != null)
          this._PictureBox1.Click -= eventHandler;
        this._PictureBox1 = value;
        if (this._PictureBox1 == null)
          return;
        this._PictureBox1.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox6
    {
      [DebuggerNonUserCode] get => this._PictureBox6;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox6_Click);
        if (this._PictureBox6 != null)
          this._PictureBox6.Click -= eventHandler;
        this._PictureBox6 = value;
        if (this._PictureBox6 == null)
          return;
        this._PictureBox6.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox5
    {
      [DebuggerNonUserCode] get => this._PictureBox5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox5_Click);
        if (this._PictureBox5 != null)
          this._PictureBox5.Click -= eventHandler;
        this._PictureBox5 = value;
        if (this._PictureBox5 == null)
          return;
        this._PictureBox5.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox4
    {
      [DebuggerNonUserCode] get => this._PictureBox4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox4_Click);
        if (this._PictureBox4 != null)
          this._PictureBox4.Click -= eventHandler;
        this._PictureBox4 = value;
        if (this._PictureBox4 == null)
          return;
        this._PictureBox4.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox3
    {
      [DebuggerNonUserCode] get => this._PictureBox3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox3_Click);
        if (this._PictureBox3 != null)
          this._PictureBox3.Click -= eventHandler;
        this._PictureBox3 = value;
        if (this._PictureBox3 == null)
          return;
        this._PictureBox3.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox2
    {
      [DebuggerNonUserCode] get => this._PictureBox2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox2_Click);
        if (this._PictureBox2 != null)
          this._PictureBox2.Click -= eventHandler;
        this._PictureBox2 = value;
        if (this._PictureBox2 == null)
          return;
        this._PictureBox2.Click += eventHandler;
      }
    }

    internal virtual SlidePanel sldpTriage
    {
      [DebuggerNonUserCode] get => this._sldpTriage;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.sldpTriage_Click);
        if (this._sldpTriage != null)
          this._sldpTriage.Click -= eventHandler;
        this._sldpTriage = value;
        if (this._sldpTriage == null)
          return;
        this._sldpTriage.Click += eventHandler;
      }
    }

    internal virtual RichTextBox rtbTriage
    {
      [DebuggerNonUserCode] get => this._rtbTriage;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._rtbTriage = value;
    }

    internal virtual PictureBox PictureBox7
    {
      [DebuggerNonUserCode] get => this._PictureBox7;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox7_Click);
        if (this._PictureBox7 != null)
          this._PictureBox7.Click -= eventHandler;
        this._PictureBox7 = value;
        if (this._PictureBox7 == null)
          return;
        this._PictureBox7.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox8
    {
      [DebuggerNonUserCode] get => this._PictureBox8;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox8_Click);
        if (this._PictureBox8 != null)
          this._PictureBox8.Click -= eventHandler;
        this._PictureBox8 = value;
        if (this._PictureBox8 == null)
          return;
        this._PictureBox8.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox9
    {
      [DebuggerNonUserCode] get => this._PictureBox9;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox9_Click);
        if (this._PictureBox9 != null)
          this._PictureBox9.Click -= eventHandler;
        this._PictureBox9 = value;
        if (this._PictureBox9 == null)
          return;
        this._PictureBox9.Click += eventHandler;
      }
    }

    internal virtual ReflectionLabel lblBack
    {
      [DebuggerNonUserCode] get => this._lblBack;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.sldpTriage_Click);
        if (this._lblBack != null)
          this._lblBack.Click -= eventHandler;
        this._lblBack = value;
        if (this._lblBack == null)
          return;
        this._lblBack.Click += eventHandler;
      }
    }

    internal virtual LabelX LabelX1
    {
      [DebuggerNonUserCode] get => this._LabelX1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX1 = value;
    }

    private void ctrlTriage_Load(object sender, EventArgs e)
    {
      this.sldpTriage.IsOpen = false;
      this.sldpTriage.SetBounds(checked (this.Width - 10), 10, checked (this.Width - 20), checked (this.Height - 50));
      this.sldpTriage.OpenBounds = new Rectangle(0, 0, this.Width, this.Height);
    }

    private void sldpTriage_Click(object sender, EventArgs e) => this.CloseTriage();

    private void PictureBox1_Click(object sender, EventArgs e) => this.OpenTriage("PSTLeak.rtf");

    private void PictureBox2_Click(object sender, EventArgs e) => this.OpenTriage("PSTFalseFailLeak.rtf");

    private void PictureBox3_Click(object sender, EventArgs e) => this.OpenTriage("PSTCyclicalPressureDrop.rtf");

    private void PictureBox4_Click(object sender, EventArgs e) => this.OpenTriage("idk.rtf");

    private void PictureBox5_Click(object sender, EventArgs e) => this.OpenTriage("PSTPinchedVentTube.rtf");

    private void PictureBox6_Click(object sender, EventArgs e) => this.OpenTriage("PSTBadPSTBox.rtf");

    private void PictureBox7_Click(object sender, EventArgs e) => this.OpenTriage("PSTPressureFluctuates.rtf");

    private void PictureBox8_Click(object sender, EventArgs e) => this.OpenTriage("PSTNoPressure.rtf");

    private void PictureBox9_Click(object sender, EventArgs e) => this.OpenTriage("none.rtf");

    private void OpenTriage(string FileName)
    {
      string dataPath = modCommonCode.GetDataPath();
      string str = dataPath + "\\PSTDocs\\" + FileName;
      if (MyProject.Computer.FileSystem.FileExists(str))
        this.rtbTriage.LoadFile(str);
      else if (MyProject.Computer.FileSystem.FileExists(dataPath + "\\PSTDocs\\PSTNoHelp.rtf"))
        this.rtbTriage.LoadFile(dataPath + "\\PSTDocs\\PSTNoHelp.rtf");
      this.sldpTriage.IsOpen = true;
    }

    public void CloseTriage()
    {
      this.sldpTriage.IsOpen = false;
      this.rtbTriage.Clear();
    }

    private void ctrlTriage_Resize(object sender, EventArgs e)
    {
      this.sldpTriage.SetBounds(checked (this.Width - 10), 10, checked (this.Width - 20), checked (this.Height - 50));
      this.sldpTriage.OpenBounds = new Rectangle(0, 0, this.Width, this.Height);
    }
  }
}
