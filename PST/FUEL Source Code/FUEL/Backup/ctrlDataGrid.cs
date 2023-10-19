// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlDataGrid
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.DotNetBar.SuperGrid;
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
  public class ctrlDataGrid : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("sgcHistory")]
    private SuperGridControl _sgcHistory;

    [DebuggerNonUserCode]
    static ctrlDataGrid()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlDataGrid.__ENCList)
      {
        if (ctrlDataGrid.__ENCList.Count == ctrlDataGrid.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlDataGrid.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlDataGrid.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlDataGrid.__ENCList[index1] = ctrlDataGrid.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlDataGrid.__ENCList.RemoveRange(index1, checked (ctrlDataGrid.__ENCList.Count - index1));
          ctrlDataGrid.__ENCList.Capacity = ctrlDataGrid.__ENCList.Count;
        }
        ctrlDataGrid.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.sgcHistory = new SuperGridControl();
      this.SuspendLayout();
      this.sgcHistory.BackColor = Color.White;
      this.sgcHistory.Dock = DockStyle.Fill;
      this.sgcHistory.ForeColor = Color.Black;
      this.sgcHistory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.sgcHistory.Location = new Point(0, 0);
      this.sgcHistory.Name = "sgcHistory";
      this.sgcHistory.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
      this.sgcHistory.PrimaryGrid.Title.RowHeaderVisibility = RowHeaderVisibility.PanelControlled;
      SuperGridControl sgcHistory = this.sgcHistory;
      Size size1 = new Size(516, 379);
      Size size2 = size1;
      sgcHistory.Size = size2;
      this.sgcHistory.TabIndex = 0;
      this.sgcHistory.Text = "SuperGridControl1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.sgcHistory);
      this.Name = nameof (ctrlDataGrid);
      size1 = new Size(516, 379);
      this.Size = size1;
      this.ResumeLayout(false);
    }

    internal virtual SuperGridControl sgcHistory
    {
      [DebuggerNonUserCode] get => this._sgcHistory;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._sgcHistory = value;
    }

    public ctrlDataGrid(DataTable dtHistory)
    {
      ctrlDataGrid.__ENCAddToList((object) this);
      this.InitializeComponent();
      this.sgcHistory.PrimaryGrid.DataSource = (object) dtHistory;
    }
  }
}
