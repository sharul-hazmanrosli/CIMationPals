// Decompiled with JetBrains decompiler
// Type: FUEL.dlgTestComplete
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using Microsoft.VisualBasic;
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
  public class dlgTestComplete : MetroForm
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("PictureBox1")]
    private PictureBox _PictureBox1;
    [AccessedThroughProperty("ReflectionLabel1")]
    private ReflectionLabel _ReflectionLabel1;
    [AccessedThroughProperty("ReflectionLabel2")]
    private ReflectionLabel _ReflectionLabel2;
    [AccessedThroughProperty("cmdOkay")]
    private ButtonX _cmdOkay;
    private bool _Passed;

    [DebuggerNonUserCode]
    static dlgTestComplete()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (dlgTestComplete.__ENCList)
      {
        if (dlgTestComplete.__ENCList.Count == dlgTestComplete.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (dlgTestComplete.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (dlgTestComplete.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                dlgTestComplete.__ENCList[index1] = dlgTestComplete.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          dlgTestComplete.__ENCList.RemoveRange(index1, checked (dlgTestComplete.__ENCList.Count - index1));
          dlgTestComplete.__ENCList.Capacity = dlgTestComplete.__ENCList.Count;
        }
        dlgTestComplete.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgTestComplete));
      this.PictureBox1 = new PictureBox();
      this.ReflectionLabel1 = new ReflectionLabel();
      this.ReflectionLabel2 = new ReflectionLabel();
      this.cmdOkay = new ButtonX();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.PictureBox1.BackColor = Color.Transparent;
      this.PictureBox1.ForeColor = Color.Black;
      this.PictureBox1.Image = (Image) componentResourceManager.GetObject("PictureBox1.Image");
      PictureBox pictureBox1_1 = this.PictureBox1;
      Point point1 = new Point(9, 9);
      Point point2 = point1;
      pictureBox1_1.Location = point2;
      this.PictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.PictureBox1.Name = "PictureBox1";
      PictureBox pictureBox1_2 = this.PictureBox1;
      Size size1 = new Size(128, 125);
      Size size2 = size1;
      pictureBox1_2.Size = size2;
      this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.PictureBox1.TabIndex = 2;
      this.PictureBox1.TabStop = false;
      this.ReflectionLabel1.BackgroundStyle.CornerType = eCornerType.Square;
      ReflectionLabel reflectionLabel1_1 = this.ReflectionLabel1;
      point1 = new Point(140, 0);
      Point point3 = point1;
      reflectionLabel1_1.Location = point3;
      this.ReflectionLabel1.Name = "ReflectionLabel1";
      ReflectionLabel reflectionLabel1_2 = this.ReflectionLabel1;
      size1 = new Size(290, 70);
      Size size3 = size1;
      reflectionLabel1_2.Size = size3;
      this.ReflectionLabel1.TabIndex = 3;
      this.ReflectionLabel1.Text = "<b><font size=\"+10\"><i>Test Complete</i></font></b>";
      this.ReflectionLabel2.BackgroundStyle.CornerType = eCornerType.Square;
      ReflectionLabel reflectionLabel2_1 = this.ReflectionLabel2;
      point1 = new Point(140, 64);
      Point point4 = point1;
      reflectionLabel2_1.Location = point4;
      this.ReflectionLabel2.Name = "ReflectionLabel2";
      ReflectionLabel reflectionLabel2_2 = this.ReflectionLabel2;
      size1 = new Size(290, 70);
      Size size4 = size1;
      reflectionLabel2_2.Size = size4;
      this.ReflectionLabel2.TabIndex = 4;
      this.ReflectionLabel2.Text = "<b><font size=\"+12\"><i>Status:  </i><font color=\"#B02B2C\"><font color=\"#20C500\">Passed</font></font></font></b>";
      this.cmdOkay.AccessibleRole = AccessibleRole.PushButton;
      this.cmdOkay.ColorTable = eButtonColor.OrangeWithBackground;
      ButtonX cmdOkay1 = this.cmdOkay;
      point1 = new Point(177, 140);
      Point point5 = point1;
      cmdOkay1.Location = point5;
      this.cmdOkay.Name = "cmdOkay";
      ButtonX cmdOkay2 = this.cmdOkay;
      size1 = new Size(75, 23);
      Size size5 = size1;
      cmdOkay2.Size = size5;
      this.cmdOkay.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cmdOkay.TabIndex = 5;
      this.cmdOkay.Text = "Okay";
      this.AcceptButton = (IButtonControl) this.cmdOkay;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(435, 169);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.cmdOkay);
      this.Controls.Add((Control) this.ReflectionLabel2);
      this.Controls.Add((Control) this.ReflectionLabel1);
      this.Controls.Add((Control) this.PictureBox1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (dlgTestComplete);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Test Complete";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
    }

    internal virtual PictureBox PictureBox1
    {
      [DebuggerNonUserCode] get => this._PictureBox1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._PictureBox1 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel1
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel1 = value;
    }

    internal virtual ReflectionLabel ReflectionLabel2
    {
      [DebuggerNonUserCode] get => this._ReflectionLabel2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._ReflectionLabel2 = value;
    }

    internal virtual ButtonX cmdOkay
    {
      [DebuggerNonUserCode] get => this._cmdOkay;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OK_Button_Click);
        if (this._cmdOkay != null)
          this._cmdOkay.Click -= eventHandler;
        this._cmdOkay = value;
        if (this._cmdOkay == null)
          return;
        this._cmdOkay.Click += eventHandler;
      }
    }

    public dlgTestComplete(bool Passed)
    {
      this.Shown += new EventHandler(this.dlgTestComplete_Shown);
      dlgTestComplete.__ENCAddToList((object) this);
      this.InitializeComponent();
      this._Passed = Passed;
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void dlgTestComplete_Shown(object sender, EventArgs e)
    {
      if (!this._Passed)
      {
        this.PictureBox1.Image = (Image) FUEL.My.Resources.Resources.frown_sm;
        this.ReflectionLabel2.Text = Strings.Replace(this.ReflectionLabel2.Text, "#20C500", "#B02B2C");
        this.ReflectionLabel2.Text = Strings.Replace(this.ReflectionLabel2.Text, "Passed", "Failed");
      }
      else
        this.PictureBox1.Image = (Image) FUEL.My.Resources.Resources.happy_sm;
    }
  }
}
