// Decompiled with JetBrains decompiler
// Type: FUEL.FSDialog
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FUEL
{
  public class FSDialog
  {
    [DebuggerNonUserCode]
    public FSDialog()
    {
    }

    internal void Show(Form Dialog)
    {
      IntPtr owner = this.getOwner();
      if (owner != (IntPtr) -1)
      {
        int num1 = (int) Dialog.ShowDialog((IWin32Window) new WindowWrapper(owner));
      }
      else
      {
        int num2 = (int) Dialog.ShowDialog();
      }
    }

    private IntPtr getOwner()
    {
      IntPtr owner;
      try
      {
        Process[] processesByName = Process.GetProcessesByName("FlexScript");
        owner = processesByName.Length == 0 ? (IntPtr) -1 : processesByName[0].MainWindowHandle;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        owner = (IntPtr) -1;
        ProjectData.ClearProjectError();
      }
      return owner;
    }
  }
}
