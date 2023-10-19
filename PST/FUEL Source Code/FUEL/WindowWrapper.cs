// Decompiled with JetBrains decompiler
// Type: FUEL.WindowWrapper
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FUEL
{
  internal class WindowWrapper : IWin32Window
  {
    private IntPtr _hwnd { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    internal WindowWrapper(IntPtr aHandle) => this._hwnd = aHandle;

    IntPtr IWin32Window.Handle => this._hwnd;

    internal IntPtr WindowWrapper
    {
      set => this._hwnd = value;
    }
  }
}
