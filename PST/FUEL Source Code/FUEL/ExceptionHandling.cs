// Decompiled with JetBrains decompiler
// Type: FUEL.ExceptionHandling
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FUEL
{
  public class ExceptionHandling
  {
    [DebuggerNonUserCode]
    public ExceptionHandling()
    {
    }

    public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      string str = string.Format("FUEL has encountered an error. {0}The exception has been logged in the system events log. {0} {0}The following is a description of the error: {0}", (object) "\r\n");
      string Msg = string.Format("Sender: {1} {0}Type: {2} {0}Message: {3}", (object) "\r\n", (object) sender.ToString(), (object) nameof (UnhandledException), (object) e.Exception.Message.ToString());
      SysEventLog.WriteLog("FUEL", Msg, EventLogEntryType.Error);
      new FUELLog().WriteLog(RuntimeHelpers.GetObjectValue(sender), Msg, EventLogEntryType.Error);
      int num = (int) Interaction.MsgBox((object) (str + "\r\n" + Msg), MsgBoxStyle.Critical);
      e.ExitApplication = false;
    }
  }
}
