// Decompiled with JetBrains decompiler
// Type: FUEL.dlgTestStationType
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class dlgTestStationType : MetroForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("OK_Button")]
    private Button _OK_Button;
    [AccessedThroughProperty("Cancel_Button")]
    private Button _Cancel_Button;
    [AccessedThroughProperty("cboTestStations")]
    private ComboBoxEx _cboTestStations;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;

    [DebuggerNonUserCode]
    static dlgTestStationType()
    {
    }

    [DebuggerNonUserCode]
    public dlgTestStationType()
    {
      this.Load += new EventHandler(this.dlgTestStationType_Load);
      dlgTestStationType.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (dlgTestStationType.__ENCList)
      {
        if (dlgTestStationType.__ENCList.Count == dlgTestStationType.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (dlgTestStationType.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (dlgTestStationType.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                dlgTestStationType.__ENCList[index1] = dlgTestStationType.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          dlgTestStationType.__ENCList.RemoveRange(index1, checked (dlgTestStationType.__ENCList.Count - index1));
          dlgTestStationType.__ENCList.Capacity = dlgTestStationType.__ENCList.Count;
        }
        dlgTestStationType.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.OK_Button = new Button();
      this.Cancel_Button = new Button();
      this.cboTestStations = new ComboBoxEx();
      this.LabelX1 = new LabelX();
      this.TableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TableLayoutPanel1.BackColor = Color.Transparent;
      this.TableLayoutPanel1.ColumnCount = 2;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.Controls.Add((Control) this.OK_Button, 0, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.Cancel_Button, 1, 0);
      this.TableLayoutPanel1.ForeColor = Color.Black;
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      Point point1 = new Point(165, 74);
      Point point2 = point1;
      tableLayoutPanel1_1.Location = point2;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 1;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      Size size1 = new Size(146, 29);
      Size size2 = size1;
      tableLayoutPanel1_2.Size = size2;
      this.TableLayoutPanel1.TabIndex = 0;
      this.OK_Button.Anchor = AnchorStyles.None;
      this.OK_Button.BackColor = Color.White;
      this.OK_Button.ForeColor = Color.Black;
      Button okButton1 = this.OK_Button;
      point1 = new Point(3, 3);
      Point point3 = point1;
      okButton1.Location = point3;
      this.OK_Button.Name = "OK_Button";
      Button okButton2 = this.OK_Button;
      size1 = new Size(67, 23);
      Size size3 = size1;
      okButton2.Size = size3;
      this.OK_Button.TabIndex = 0;
      this.OK_Button.Text = "OK";
      this.OK_Button.UseVisualStyleBackColor = false;
      this.Cancel_Button.Anchor = AnchorStyles.None;
      this.Cancel_Button.BackColor = Color.White;
      this.Cancel_Button.DialogResult = DialogResult.Cancel;
      this.Cancel_Button.ForeColor = Color.Black;
      Button cancelButton1 = this.Cancel_Button;
      point1 = new Point(76, 3);
      Point point4 = point1;
      cancelButton1.Location = point4;
      this.Cancel_Button.Name = "Cancel_Button";
      Button cancelButton2 = this.Cancel_Button;
      size1 = new Size(67, 23);
      Size size4 = size1;
      cancelButton2.Size = size4;
      this.Cancel_Button.TabIndex = 1;
      this.Cancel_Button.Text = "Cancel";
      this.Cancel_Button.UseVisualStyleBackColor = false;
      this.cboTestStations.DisplayMember = "Text";
      this.cboTestStations.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboTestStations.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTestStations.ForeColor = Color.Black;
      this.cboTestStations.FormattingEnabled = true;
      this.cboTestStations.ItemHeight = 14;
      ComboBoxEx cboTestStations1 = this.cboTestStations;
      point1 = new Point(13, 42);
      Point point5 = point1;
      cboTestStations1.Location = point5;
      this.cboTestStations.Name = "cboTestStations";
      ComboBoxEx cboTestStations2 = this.cboTestStations;
      size1 = new Size(203, 20);
      Size size5 = size1;
      cboTestStations2.Size = size5;
      this.cboTestStations.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboTestStations.TabIndex = 1;
      this.LabelX1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelX1.BackColor = Color.White;
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      this.LabelX1.ForeColor = Color.Black;
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(13, 13);
      Point point6 = point1;
      labelX1_1.Location = point6;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(298, 23);
      Size size6 = size1;
      labelX1_2.Size = size6;
      this.LabelX1.TabIndex = 2;
      this.LabelX1.Text = "Please select the type of test station that you are working at.";
      this.AcceptButton = (IButtonControl) this.OK_Button;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.Cancel_Button;
      size1 = new Size(323, 115);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.LabelX1);
      this.Controls.Add((Control) this.cboTestStations);
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (dlgTestStationType);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Test Station Selection";
      this.TableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get => this._TableLayoutPanel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._TableLayoutPanel1 = value;
    }

    internal virtual Button OK_Button
    {
      [DebuggerNonUserCode] get => this._OK_Button;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OK_Button_Click);
        if (this._OK_Button != null)
          this._OK_Button.Click -= eventHandler;
        this._OK_Button = value;
        if (this._OK_Button == null)
          return;
        this._OK_Button.Click += eventHandler;
      }
    }

    internal virtual Button Cancel_Button
    {
      [DebuggerNonUserCode] get => this._Cancel_Button;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Cancel_Button_Click);
        if (this._Cancel_Button != null)
          this._Cancel_Button.Click -= eventHandler;
        this._Cancel_Button = value;
        if (this._Cancel_Button == null)
          return;
        this._Cancel_Button.Click += eventHandler;
      }
    }

    internal virtual ComboBoxEx cboTestStations
    {
      [DebuggerNonUserCode] get => this._cboTestStations;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTestStations_SelectedIndexChanged);
        if (this._cboTestStations != null)
          this._cboTestStations.SelectedIndexChanged -= eventHandler;
        this._cboTestStations = value;
        if (this._cboTestStations == null)
          return;
        this._cboTestStations.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual LabelX LabelX1
    {
      [DebuggerNonUserCode] get => this._LabelX1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._LabelX1 = value;
    }

    private PST.TestStationTypes _TestStationType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public PST.TestStationTypes TestStationType => this._TestStationType;

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this._TestStationType = (PST.TestStationTypes) this.cboTestStations.SelectedIndex;
      this.Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this._TestStationType = ~PST.TestStationTypes.ProductionLine;
      this.Close();
    }

    private void dlgTestStationType_Load(object sender, EventArgs e)
    {
      try
      {
        foreach (object obj in Enum.GetValues(typeof (PST.TestStationTypes)))
          this.cboTestStations.Items.Add((object) RuntimeHelpers.GetObjectValue(obj).ToString());
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (DateAndTime.DateDiff(DateInterval.Hour, MySettingsProperty.Settings.TestStationType_Date, DateAndTime.Now) >= 6L)
      {
        MySettingsProperty.Settings.TestStationType = -1;
        MySettingsProperty.Settings.Save();
      }
      else
      {
        this._TestStationType = (PST.TestStationTypes) MySettingsProperty.Settings.TestStationType;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      this.cboTestStations.SelectedIndex = MySettingsProperty.Settings.TestStationType;
    }

    private void cboTestStations_SelectedIndexChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.TestStationType = this.cboTestStations.SelectedIndex;
      MySettingsProperty.Settings.TestStationType_Date = DateAndTime.Now;
      MySettingsProperty.Settings.Save();
    }
  }
}
