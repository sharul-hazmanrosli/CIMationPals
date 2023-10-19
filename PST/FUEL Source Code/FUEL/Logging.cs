// Decompiled with JetBrains decompiler
// Type: FUEL.Logging
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FUEL
{
  [StandardModule]
  public sealed class Logging
  {
    public static void AddLogEntry(
      object Sender,
      string Msg,
      EventLogEntryType EntryType,
      int Priority)
    {
      bool flag1 = false;
      bool flag2 = true;
      if (UploadSettings.DebugLevel < Priority)
        return;
      if (flag2)
        new FUELLog().WriteLog(RuntimeHelpers.GetObjectValue(Sender), Msg, EntryType);
      if (flag1)
        SysEventLog.WriteLog("FUEL", Msg, EntryType);
    }
  }
}
