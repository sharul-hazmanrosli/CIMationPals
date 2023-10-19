// Decompiled with JetBrains decompiler
// Type: NIDAQ.NIDAQForm
// Assembly: NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E0A2D9-BC78-4088-A605-9E0C1595E02F
// Assembly location: C:\Program Files (x86)\CIMProjects.Net\Marconi\NIDAQ\amd64\NIDAQ.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NIDAQ
{
  [DesignerGenerated]
  public class NIDAQForm : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("Timer1")]
    private Timer _Timer1;
    private object Caller;

    [DebuggerNonUserCode]
    static NIDAQForm()
    {
    }

    [DebuggerNonUserCode]
    public NIDAQForm()
    {
      this.Load += new EventHandler(this.Timer_Load);
      NIDAQForm.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (NIDAQForm.__ENCList)
      {
        if (NIDAQForm.__ENCList.Count == NIDAQForm.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (NIDAQForm.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (NIDAQForm.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                NIDAQForm.__ENCList[index1] = NIDAQForm.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          NIDAQForm.__ENCList.RemoveRange(index1, checked (NIDAQForm.__ENCList.Count - index1));
          NIDAQForm.__ENCList.Capacity = NIDAQForm.__ENCList.Count;
        }
        NIDAQForm.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.Timer1 = new Timer(this.components);
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(116, 57);
      this.Name = nameof (NIDAQForm);
      this.Text = "Form1";
      this.ResumeLayout(false);
    }

    internal virtual Timer Timer1
    {
      [DebuggerNonUserCode] get => this._Timer1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
        if (this._Timer1 != null)
          this._Timer1.Tick -= eventHandler;
        this._Timer1 = value;
        if (this._Timer1 == null)
          return;
        this._Timer1.Tick += eventHandler;
      }
    }

    public void Setup(object CallMe)
    {
      this.Caller = RuntimeHelpers.GetObjectValue(CallMe);
      this.Timer1.Interval = 100;
      this.Timer1.Enabled = true;
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Enabled = false;
      NewLateBinding.LateCall(this.Caller, (System.Type) null, "StartReadAnalogAsync", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null, true);
      this.Caller = (object) null;
    }

    private void Timer_Load(object sender, EventArgs e) => this.Timer1.Enabled = false;
  }
}
