// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlUserLocation
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
  public class ctrlUserLocation : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("cboSiteList")]
    private ComboBoxEx _cboSiteList;
    [AccessedThroughProperty("LabelX1")]
    private LabelX _LabelX1;
    [AccessedThroughProperty("LabelX2")]
    private LabelX _LabelX2;

    [DebuggerNonUserCode]
    static ctrlUserLocation()
    {
    }

    [DebuggerNonUserCode]
    public ctrlUserLocation()
    {
      this.Load += new EventHandler(this.ctrlUserLocation_Load);
      ctrlUserLocation.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlUserLocation.__ENCList)
      {
        if (ctrlUserLocation.__ENCList.Count == ctrlUserLocation.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlUserLocation.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlUserLocation.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlUserLocation.__ENCList[index1] = ctrlUserLocation.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlUserLocation.__ENCList.RemoveRange(index1, checked (ctrlUserLocation.__ENCList.Count - index1));
          ctrlUserLocation.__ENCList.Capacity = ctrlUserLocation.__ENCList.Count;
        }
        ctrlUserLocation.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.cboSiteList = new ComboBoxEx();
      this.LabelX1 = new LabelX();
      this.LabelX2 = new LabelX();
      this.SuspendLayout();
      this.cboSiteList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSiteList.DisplayMember = "Text";
      this.cboSiteList.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboSiteList.FormattingEnabled = true;
      this.cboSiteList.ItemHeight = 14;
      ComboBoxEx cboSiteList1 = this.cboSiteList;
      Point point1 = new Point(16, 62);
      Point point2 = point1;
      cboSiteList1.Location = point2;
      this.cboSiteList.Name = "cboSiteList";
      ComboBoxEx cboSiteList2 = this.cboSiteList;
      Size size1 = new Size(245, 20);
      Size size2 = size1;
      cboSiteList2.Size = size2;
      this.cboSiteList.Style = eDotNetBarStyle.StyleManagerControlled;
      this.cboSiteList.TabIndex = 0;
      this.LabelX1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelX1.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX labelX1_1 = this.LabelX1;
      point1 = new Point(16, 38);
      Point point3 = point1;
      labelX1_1.Location = point3;
      this.LabelX1.Name = "LabelX1";
      LabelX labelX1_2 = this.LabelX1;
      size1 = new Size(245, 23);
      Size size3 = size1;
      labelX1_2.Size = size3;
      this.LabelX1.TabIndex = 1;
      this.LabelX1.Text = "Please Select Your Location from the List Below";
      this.LabelX2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.LabelX2.BackgroundStyle.CornerType = eCornerType.Square;
      LabelX labelX2_1 = this.LabelX2;
      point1 = new Point(16, 3);
      Point point4 = point1;
      labelX2_1.Location = point4;
      this.LabelX2.Name = "LabelX2";
      LabelX labelX2_2 = this.LabelX2;
      size1 = new Size(245, 23);
      Size size4 = size1;
      labelX2_2.Size = size4;
      this.LabelX2.TabIndex = 2;
      this.LabelX2.Text = "Before proceeding, I must know your location.";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.LabelX2);
      this.Controls.Add((Control) this.LabelX1);
      this.Controls.Add((Control) this.cboSiteList);
      this.Name = nameof (ctrlUserLocation);
      size1 = new Size(280, 99);
      this.Size = size1;
      this.ResumeLayout(false);
    }

    internal virtual ComboBoxEx cboSiteList
    {
      [DebuggerNonUserCode] get => this._cboSiteList;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._cboSiteList = value;
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

    private void ctrlUserLocation_Load(object sender, EventArgs e)
    {
      try
      {
        foreach (object obj in Enum.GetValues(typeof (PST.TestSites)))
          this.cboSiteList.Items.Add((object) RuntimeHelpers.GetObjectValue(obj).ToString());
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
