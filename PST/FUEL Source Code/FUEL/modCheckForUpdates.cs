// Decompiled with JetBrains decompiler
// Type: FUEL.modCheckForUpdates
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RDL;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FUEL
{
  [StandardModule]
  internal sealed class modCheckForUpdates
  {
    private static Thread thdUpdateCheck;

    internal static void CheckForUpdate(FUEL.CheckForUpdates.CheckType FUELType)
    {
      try
      {
        bool flag = true;
        try
        {
          if (modCheckForUpdates.thdUpdateCheck.IsAlive)
            flag = false;
        }
        catch (NullReferenceException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          flag = true;
          ProjectData.ClearProjectError();
        }
        if (!new NetworkConnection().CheckForNetworkConnection((RichTextBox) null))
          flag = false;
        if (!flag || DateAndTime.DateDiff("h", (object) MySettingsProperty.Settings.UpdateCheck.ToString(), (object) DateAndTime.Now) <= 24L)
          return;
        modCheckForUpdates.thdUpdateCheck = new Thread((ParameterizedThreadStart) (a0 => modCheckForUpdates.CheckForUpdates((FUEL.CheckForUpdates.CheckType) Conversions.ToInteger(a0))));
        modCheckForUpdates.thdUpdateCheck.IsBackground = true;
        modCheckForUpdates.thdUpdateCheck.Start((object) FUELType);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ("Error while checking for update.\r\n\r\n" + ex.ToString()));
        ProjectData.ClearProjectError();
      }
    }

    private static void CheckForUpdates(FUEL.CheckForUpdates.CheckType FUELType)
    {
      MySettingsProperty.Settings.UpdateCheck = DateAndTime.Now;
      MySettingsProperty.Settings.Save();
      string str = "\\\\vcslab.vcd.hp.com\\root\\InkSystems\\SPHINKS\\Randal Morrison\\FUEL\\VersionInfo.txt";
      string SaveAs = Path.Combine(modCommonCode.GetDataPath(), "VersionInfo.txt");
      FUEL.CheckForUpdates checkForUpdates = new FUEL.CheckForUpdates(str, SaveAs, FUELType);
      if (!Operators.ConditionalCompareObjectNotEqual(checkForUpdates.UpdateAvailable, (object) FUEL.CheckForUpdates.UpdateType.None, false))
        return;
      string Prompt = (string) null;
      string Title = "Update Available";
      bool flag = false;
      if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(checkForUpdates.UpdateAvailable, (object) FUEL.CheckForUpdates.UpdateType.OptionalUpdate, false), (object) (FUELType != FUEL.CheckForUpdates.CheckType.PST))))
      {
        Prompt = "There is a new version of FUEL available.\r\n\r\nInstalled Version: " + checkForUpdates.CurrentVersion + "\r\nNew Version: " + checkForUpdates.ServerVersion + "\r\n\r\nGo to the location below to install the new version:\r\n" + Path.GetDirectoryName(str);
        flag = true;
      }
      else if (Operators.ConditionalCompareObjectEqual(checkForUpdates.UpdateAvailable, (object) FUEL.CheckForUpdates.UpdateType.RequiredUpdate, false))
      {
        Prompt = "There is a CRITICAL new version of FUEL available.\r\n\r\nInstalled Version: " + checkForUpdates.CurrentVersion + "\r\nNew Version: " + checkForUpdates.ServerVersion + "\r\n\r\nCritical updates are reserved for occasions where a significant bug was fixed, or a required new feature was added. Please update your version of FUEL as soon as possible.\r\n\r\nGo to the location below to install the new version:\r\n" + Path.GetDirectoryName(str);
        Title = "Critical Update Available";
        flag = true;
      }
      if (!flag)
        return;
      int num = (int) Interaction.MsgBox((object) Prompt, Title: (object) Title);
    }
  }
}
