// Decompiled with JetBrains decompiler
// Type: FUEL.dlgCriticalCheckFailed
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
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
  public class dlgCriticalCheckFailed : MetroForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("cmdOkay")]
    private ButtonX _cmdOkay;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;
    [AccessedThroughProperty("LabelX2")]
    private LabelX _LabelX2;
    [AccessedThroughProperty("LabelX3")]
    private LabelX _LabelX3;
    [AccessedThroughProperty("LabelX4")]
    private LabelX _LabelX4;
    [AccessedThroughProperty("lblSpec2Title")]
    private LabelX _lblSpec2Title;
    [AccessedThroughProperty("lblInstructions")]
    private LabelX _lblInstructions;
    [AccessedThroughProperty("txtInstructions")]
    private TextBoxX _txtInstructions;
    [AccessedThroughProperty("lblCheckName")]
    private LabelX _lblCheckName;
    [AccessedThroughProperty("lblMeasVal")]
    private LabelX _lblMeasVal;
    [AccessedThroughProperty("lblSpecType")]
    private LabelX _lblSpecType;
    [AccessedThroughProperty("lblSpec1")]
    private LabelX _lblSpec1;
    [AccessedThroughProperty("lblSpec2")]
    private LabelX _lblSpec2;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;

    [DebuggerNonUserCode]
    static dlgCriticalCheckFailed()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (dlgCriticalCheckFailed.__ENCList)
      {
        if (dlgCriticalCheckFailed.__ENCList.Count == dlgCriticalCheckFailed.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (dlgCriticalCheckFailed.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (dlgCriticalCheckFailed.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                dlgCriticalCheckFailed.__ENCList[index1] = dlgCriticalCheckFailed.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          dlgCriticalCheckFailed.__ENCList.RemoveRange(index1, checked (dlgCriticalCheckFailed.__ENCList.Count - index1));
          dlgCriticalCheckFailed.__ENCList.Capacity = dlgCriticalCheckFailed.__ENCList.Count;
        }
        dlgCriticalCheckFailed.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgCriticalCheckFailed));
      this.cmdOkay = new ButtonX();
      this.LabelX1 = new LabelX();
      this.LabelX2 = new LabelX();
      this.LabelX3 = new LabelX();
      this.LabelX4 = new LabelX();
      this.lblSpec2Title = new LabelX();
      this.lblInstructions = new LabelX();
      this.txtInstructions = new TextBoxX();
      this.lblCheckName = new LabelX();
      this.lblMeasVal = new LabelX();
      this.lblSpecType = new LabelX();
      this.lblSpec1 = new LabelX();
      this.lblSpec2 = new LabelX();
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.PictureBox1 = new PictureBox();
      this.TableLayoutPanel1.SuspendLayout();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.cmdOkay.AccessibleRole = AccessibleRole.PushButton;
      this.cmdOkay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cmdOkay.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX cmdOkay1 = this.cmdOkay;
      Point point1 = new Point(179, 194);
      Point point2 = point1;
      cmdOkay1.Location = point2;
      this.cmdOkay.Name = "cmdOkay";
      ButtonX cmdOkay2 = this.cmdOkay;
      Size size1 = new Size(75, 23);
      Size size2 = size1;
      cmdOkay2.Size = size2;
      this.cmdOkay.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdOkay.TabIndex = 0;
      this.cmdOkay.Text = "Okay";
      this.LabelX1.BackColor = Color.Transparent;
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX1.Dock = DockStyle.Fill;
      this.LabelX1.ForeColor = Color.Black;
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(3, 3);
      Point point3 = point1;
      labelX1_1.Location = point3;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(94, 23);
      Size size3 = size1;
      labelX1_2.Size = size3;
      this.LabelX1.TabIndex = 2;
      this.LabelX1.Text = "Check Name:";
      this.LabelX1.TextAlignment = StringAlignment.Far;
      this.LabelX2.BackColor = Color.Transparent;
      this.LabelX2.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX2.Dock = DockStyle.Fill;
      this.LabelX2.ForeColor = Color.Black;
      LabelX labelX2_1 = this.LabelX2;
      point1 = new Point(3, 32);
      Point point4 = point1;
      labelX2_1.Location = point4;
      this.LabelX2.Name = "LabelX2";
      LabelX labelX2_2 = this.LabelX2;
      size1 = new Size(94, 23);
      Size size4 = size1;
      labelX2_2.Size = size4;
      this.LabelX2.TabIndex = 3;
      this.LabelX2.Text = "Measured Value:";
      this.LabelX2.TextAlignment = StringAlignment.Far;
      this.LabelX3.BackColor = Color.Transparent;
      this.LabelX3.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX3.Dock = DockStyle.Fill;
      this.LabelX3.ForeColor = Color.Black;
      LabelX labelX3_1 = this.LabelX3;
      point1 = new Point(3, 61);
      Point point5 = point1;
      labelX3_1.Location = point5;
      this.LabelX3.Name = "LabelX3";
      LabelX labelX3_2 = this.LabelX3;
      size1 = new Size(94, 23);
      Size size5 = size1;
      labelX3_2.Size = size5;
      this.LabelX3.TabIndex = 4;
      this.LabelX3.Text = "Spec Type";
      this.LabelX3.TextAlignment = StringAlignment.Far;
      this.LabelX4.BackColor = Color.Transparent;
      this.LabelX4.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX4.Dock = DockStyle.Fill;
      this.LabelX4.ForeColor = Color.Black;
      LabelX labelX4_1 = this.LabelX4;
      point1 = new Point(3, 90);
      Point point6 = point1;
      labelX4_1.Location = point6;
      this.LabelX4.Name = "LabelX4";
      LabelX labelX4_2 = this.LabelX4;
      size1 = new Size(94, 23);
      Size size6 = size1;
      labelX4_2.Size = size6;
      this.LabelX4.TabIndex = 5;
      this.LabelX4.Text = "Spec Value 1:";
      this.LabelX4.TextAlignment = StringAlignment.Far;
      this.lblSpec2Title.BackColor = Color.Transparent;
      this.lblSpec2Title.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpec2Title.Dock = DockStyle.Fill;
      this.lblSpec2Title.ForeColor = Color.Black;
      LabelX lblSpec2Title1 = this.lblSpec2Title;
      point1 = new Point(173, 90);
      Point point7 = point1;
      lblSpec2Title1.Location = point7;
      this.lblSpec2Title.Name = "lblSpec2Title";
      LabelX lblSpec2Title2 = this.lblSpec2Title;
      size1 = new Size(80, 23);
      Size size7 = size1;
      lblSpec2Title2.Size = size7;
      this.lblSpec2Title.TabIndex = 6;
      this.lblSpec2Title.Text = "Spec Value 2:";
      this.lblSpec2Title.TextAlignment = StringAlignment.Far;
      this.lblInstructions.BackColor = Color.White;
      this.lblInstructions.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblInstructions.ForeColor = Color.Black;
      LabelX lblInstructions1 = this.lblInstructions;
      point1 = new Point(19, 125);
      Point point8 = point1;
      lblInstructions1.Location = point8;
      this.lblInstructions.Name = "lblInstructions";
      LabelX lblInstructions2 = this.lblInstructions;
      size1 = new Size(80, 23);
      Size size8 = size1;
      lblInstructions2.Size = size8;
      this.lblInstructions.TabIndex = 7;
      this.lblInstructions.Text = "Instructions:";
      this.txtInstructions.BackColor = Color.White;
      this.txtInstructions.Border.Class = "TextBoxBorder";
      this.txtInstructions.Border.CornerType = eCornerType.Square;
      this.txtInstructions.ForeColor = Color.Black;
      TextBoxX txtInstructions1 = this.txtInstructions;
      point1 = new Point(19, 143);
      Point point9 = point1;
      txtInstructions1.Location = point9;
      this.txtInstructions.Multiline = true;
      this.txtInstructions.Name = "txtInstructions";
      this.txtInstructions.ReadOnly = true;
      TextBoxX txtInstructions2 = this.txtInstructions;
      size1 = new Size(422, 45);
      Size size9 = size1;
      txtInstructions2.Size = size9;
      this.txtInstructions.TabIndex = 8;
      this.lblCheckName.BackColor = Color.Transparent;
      this.lblCheckName.BackgroundStyle.CornerType = eCornerType.Square;
      this.TableLayoutPanel1.SetColumnSpan((Control) this.lblCheckName, 3);
      this.lblCheckName.Dock = DockStyle.Fill;
      this.lblCheckName.ForeColor = Color.Black;
      LabelX lblCheckName1 = this.lblCheckName;
      point1 = new Point(103, 3);
      Point point10 = point1;
      lblCheckName1.Location = point10;
      this.lblCheckName.Name = "lblCheckName";
      LabelX lblCheckName2 = this.lblCheckName;
      size1 = new Size(220, 23);
      Size size10 = size1;
      lblCheckName2.Size = size10;
      this.lblCheckName.TabIndex = 9;
      this.lblCheckName.Text = "LabelX7";
      this.lblMeasVal.BackColor = Color.Transparent;
      this.lblMeasVal.BackgroundStyle.CornerType = eCornerType.Square;
      this.TableLayoutPanel1.SetColumnSpan((Control) this.lblMeasVal, 3);
      this.lblMeasVal.Dock = DockStyle.Fill;
      this.lblMeasVal.ForeColor = Color.Black;
      LabelX lblMeasVal1 = this.lblMeasVal;
      point1 = new Point(103, 32);
      Point point11 = point1;
      lblMeasVal1.Location = point11;
      this.lblMeasVal.Name = "lblMeasVal";
      LabelX lblMeasVal2 = this.lblMeasVal;
      size1 = new Size(220, 23);
      Size size11 = size1;
      lblMeasVal2.Size = size11;
      this.lblMeasVal.TabIndex = 10;
      this.lblMeasVal.Text = "LabelX7";
      this.lblSpecType.BackColor = Color.Transparent;
      this.lblSpecType.BackgroundStyle.CornerType = eCornerType.Square;
      this.TableLayoutPanel1.SetColumnSpan((Control) this.lblSpecType, 3);
      this.lblSpecType.Dock = DockStyle.Fill;
      this.lblSpecType.ForeColor = Color.Black;
      LabelX lblSpecType1 = this.lblSpecType;
      point1 = new Point(103, 61);
      Point point12 = point1;
      lblSpecType1.Location = point12;
      this.lblSpecType.Name = "lblSpecType";
      LabelX lblSpecType2 = this.lblSpecType;
      size1 = new Size(220, 23);
      Size size12 = size1;
      lblSpecType2.Size = size12;
      this.lblSpecType.TabIndex = 11;
      this.lblSpecType.Text = "LabelX7";
      this.lblSpec1.BackColor = Color.Transparent;
      this.lblSpec1.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpec1.Dock = DockStyle.Fill;
      this.lblSpec1.ForeColor = Color.Black;
      LabelX lblSpec1_1 = this.lblSpec1;
      point1 = new Point(103, 90);
      Point point13 = point1;
      lblSpec1_1.Location = point13;
      this.lblSpec1.Name = "lblSpec1";
      LabelX lblSpec1_2 = this.lblSpec1;
      size1 = new Size(64, 23);
      Size size13 = size1;
      lblSpec1_2.Size = size13;
      this.lblSpec1.TabIndex = 12;
      this.lblSpec1.Text = "LabelX7";
      this.lblSpec2.BackColor = Color.Transparent;
      this.lblSpec2.BackgroundStyle.CornerType = eCornerType.Square;
      this.lblSpec2.Dock = DockStyle.Fill;
      this.lblSpec2.ForeColor = Color.Black;
      LabelX lblSpec2_1 = this.lblSpec2;
      point1 = new Point(259, 90);
      Point point14 = point1;
      lblSpec2_1.Location = point14;
      this.lblSpec2.Name = "lblSpec2";
      LabelX lblSpec2_2 = this.lblSpec2;
      size1 = new Size(64, 23);
      Size size14 = size1;
      lblSpec2_2.Size = size14;
      this.lblSpec2.TabIndex = 13;
      this.lblSpec2.Text = "LabelX7";
      this.TableLayoutPanel1.BackColor = Color.FromArgb(216, 216, 216);
      this.TableLayoutPanel1.ColumnCount = 4;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70f));
      this.TableLayoutPanel1.Controls.Add((Control) this.LabelX1, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblSpec2, 3, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.LabelX2, 0, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblSpec1, 1, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.LabelX3, 0, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblSpec2Title, 2, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblSpecType, 1, 2);
      this.TableLayoutPanel1.Controls.Add((Control) this.LabelX4, 0, 3);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblMeasVal, 1, 1);
      this.TableLayoutPanel1.Controls.Add((Control) this.lblCheckName, 1, 0);
      this.TableLayoutPanel1.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      point1 = new Point(115, -6);
      Point point15 = point1;
      tableLayoutPanel1_1.Location = point15;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 4;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      size1 = new Size(326, 116);
      Size size15 = size1;
      tableLayoutPanel1_2.Size = size15;
      this.TableLayoutPanel1.TabIndex = 14;
      this.PictureBox1.BackColor = Color.Transparent;
      this.PictureBox1.ForeColor = Color.Black;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      PictureBox pictureBox1_1 = this.PictureBox1;
      point1 = new Point(0, 1);
      Point point16 = point1;
      pictureBox1_1.Location = point16;
      this.PictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.PictureBox1.Name = "PictureBox1";
      PictureBox pictureBox1_2 = this.PictureBox1;
      size1 = new Size(128, 125);
      Size size16 = size1;
      pictureBox1_2.Size = size16;
      this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.PictureBox1.TabIndex = 1;
      this.PictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      size1 = new Size(455, 226);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.PictureBox1);
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.Controls.Add((Control) this.txtInstructions);
      this.Controls.Add((Control) this.lblInstructions);
      this.Controls.Add((Control) this.cmdOkay);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (dlgCriticalCheckFailed);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Failed Check";
      this.TableLayoutPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
    }

    internal virtual ButtonX cmdOkay
    {
      [DebuggerNonUserCode] get => this._cmdOkay;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmdOkay_Click);
        if (this._cmdOkay != null)
          this._cmdOkay.Click -= eventHandler;
        this._cmdOkay = value;
        if (this._cmdOkay == null)
          return;
        this._cmdOkay.Click += eventHandler;
      }
    }

    internal virtual PictureBox PictureBox1
    {
      [DebuggerNonUserCode] get => this._PictureBox1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._PictureBox1 = value;
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

    internal virtual LabelX LabelX3
    {
      [DebuggerNonUserCode] get => this._LabelX3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX3 = value;
    }

    internal virtual LabelX LabelX4
    {
      [DebuggerNonUserCode] get => this._LabelX4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX4 = value;
    }

    internal virtual LabelX lblSpec2Title
    {
      [DebuggerNonUserCode] get => this._lblSpec2Title;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpec2Title = value;
    }

    internal virtual LabelX lblInstructions
    {
      [DebuggerNonUserCode] get => this._lblInstructions;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblInstructions = value;
    }

    internal virtual TextBoxX txtInstructions
    {
      [DebuggerNonUserCode] get => this._txtInstructions;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._txtInstructions = value;
    }

    internal virtual LabelX lblCheckName
    {
      [DebuggerNonUserCode] get => this._lblCheckName;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblCheckName = value;
    }

    internal virtual LabelX lblMeasVal
    {
      [DebuggerNonUserCode] get => this._lblMeasVal;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblMeasVal = value;
    }

    internal virtual LabelX lblSpecType
    {
      [DebuggerNonUserCode] get => this._lblSpecType;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpecType = value;
    }

    internal virtual LabelX lblSpec1
    {
      [DebuggerNonUserCode] get => this._lblSpec1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpec1 = value;
    }

    internal virtual LabelX lblSpec2
    {
      [DebuggerNonUserCode] get => this._lblSpec2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._lblSpec2 = value;
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    private string _Name { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Val { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private PST.SpecType _CheckType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Spec1 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Spec2 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _Instructions { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public dlgCriticalCheckFailed(
      string Name,
      string Val,
      PST.SpecType CheckType,
      string Spec1,
      string Spec2,
      string Instructions)
    {
      this.Shown += new EventHandler(this.dlgCriticalCheckFailed_Shown);
      this.Load += new EventHandler(this.Dialog1_Load);
      dlgCriticalCheckFailed.__ENCAddToList((object) this);
      this.InitializeComponent();
      this._Name = Name;
      this._Val = Val;
      this._CheckType = CheckType;
      this._Spec1 = Spec1;
      this._Spec2 = Spec2;
      this._Instructions = Instructions;
      this.BackColor = Color.Aquamarine;
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void Dialog1_Load(object sender, EventArgs e)
    {
      if (Operators.CompareString(this._Instructions, (string) null, false) == 0)
      {
        this.txtInstructions.Visible = false;
        this.lblInstructions.Visible = false;
        this.Height = checked (this.Height - this.txtInstructions.Height - this.lblInstructions.Height);
      }
      if (this._CheckType != PST.SpecType.Between)
      {
        this.lblSpec2.Visible = false;
        this.lblSpec2Title.Visible = false;
      }
      this.lblCheckName.Text = this._Name;
      this.lblMeasVal.Text = this._Val;
      this.lblSpecType.Text = this._CheckType.ToString();
      this.lblSpec1.Text = this._Spec1;
      this.lblSpec2.Text = this._Spec2;
      this.txtInstructions.Text = this._Instructions;
    }

    private void dlgCriticalCheckFailed_Shown(object sender, EventArgs e) => this.TableLayoutPanel1.BackColor = Color.Transparent;

    private void cmdOkay_Click(object sender, EventArgs e)
    {
      this.Hide();
      this.Dispose();
    }
  }
}
