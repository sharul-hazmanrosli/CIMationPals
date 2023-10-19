// Decompiled with JetBrains decompiler
// Type: FUEL.SysEventLog
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Diagnostics;

namespace FUEL
{
  public class SysEventLog
  {
    [DebuggerNonUserCode]
    public SysEventLog()
    {
    }

    public static void WriteLog(string LogName, string Msg, EventLogEntryType EntryType)
    {
      if (!EventLog.SourceExists(LogName))
        EventLog.CreateEventSource(LogName, LogName);
      EventLog.WriteEntry(LogName, Msg, EntryType);
    }
  }
}
