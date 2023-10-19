// Decompiled with JetBrains decompiler
// Type: FUEL.UploadSettings
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace FUEL
{
  public class UploadSettings
  {
    static UploadSettings()
    {
      UploadSettings._InstallLocation = PST.TestSites.HP;
      UploadSettings._LocalCopyToAddress = "M:\\";
      UploadSettings._VCDServerAddress = "https://pst1.vcd.hp.com/PST/upload.php";
      UploadSettings._SettingsVerified = false;
      UploadSettings._DebugLevel = MySettingsProperty.Settings.DebugLevel;
    }

    [DebuggerNonUserCode]
    public UploadSettings()
    {
    }

    private static string SettingsFileLocation => modCommonCode.GetDataPath().ToLower().Contains("\\bin\\") ? "C:\\Users\\morrisor\\Documents\\Visual Studio 2010\\Projects\\FUEL\\AutoSendFiles\\FUEL\\Uploadsettings.xml" : Path.Combine(modCommonCode.GetDataPath(), "Uploadsettings.xml");

    private static PST.TestSites _InstallLocation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static PST.TestSites InstallLocation
    {
      get => (PST.TestSites) Conversions.ToInteger(UploadSettings.GetVal(nameof (InstallLocation)));
      set => UploadSettings._InstallLocation = value;
    }

    private static string _LocalCopyToAddress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static string LocalCopyToAddress
    {
      get => UploadSettings.GetVal(nameof (LocalCopyToAddress));
      set => UploadSettings._LocalCopyToAddress = value;
    }

    private static string _VCDServerAddress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static string VCDServerAddress
    {
      get => UploadSettings.GetVal(nameof (VCDServerAddress));
      set => UploadSettings._VCDServerAddress = value;
    }

    private static bool _SettingsVerified { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static bool SettingsVerified
    {
      get => Conversions.ToBoolean(UploadSettings.GetVal(nameof (SettingsVerified)));
      set => UploadSettings._SettingsVerified = value;
    }

    private static int _DebugLevel { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public static int DebugLevel
    {
      get => MySettingsProperty.Settings.DebugLevel;
      set
      {
        UploadSettings._DebugLevel = value;
        MySettingsProperty.Settings.DebugLevel = value;
      }
    }

    public static void Save()
    {
      MySettingsProperty.Settings.Save();
      UploadSettings.Create();
    }

    public static void Reset()
    {
      UploadSettings._InstallLocation = PST.TestSites.HP;
      UploadSettings._LocalCopyToAddress = "M:\\";
      UploadSettings._VCDServerAddress = "https://pst1.vcd.hp.com/PST/upload.php";
      UploadSettings._SettingsVerified = false;
      MySettingsProperty.Settings.DebugLevel = 4;
      UploadSettings.Save();
    }

    private static void Create()
    {
      try
      {
        using (XmlWriter xmlWriter = XmlWriter.Create(UploadSettings.SettingsFileLocation, new XmlWriterSettings()
        {
          Indent = true
        }))
        {
          xmlWriter.WriteStartDocument();
          xmlWriter.WriteStartElement("Settings");
          xmlWriter.WriteStartElement("Setting");
          xmlWriter.WriteAttributeString("Name", "InstallLocation");
          xmlWriter.WriteAttributeString("Value", Conversions.ToString((int) UploadSettings._InstallLocation));
          xmlWriter.WriteEndElement();
          xmlWriter.WriteStartElement("Setting");
          xmlWriter.WriteAttributeString("Name", "VCDServerAddress");
          xmlWriter.WriteAttributeString("Value", UploadSettings._VCDServerAddress);
          xmlWriter.WriteEndElement();
          xmlWriter.WriteStartElement("Setting");
          xmlWriter.WriteAttributeString("Name", "LocalCopyToAddress");
          xmlWriter.WriteAttributeString("Value", UploadSettings._LocalCopyToAddress);
          xmlWriter.WriteEndElement();
          xmlWriter.WriteStartElement("Setting");
          xmlWriter.WriteAttributeString("Name", "SettingsVerified");
          xmlWriter.WriteAttributeString("Value", Conversions.ToString(UploadSettings._SettingsVerified));
          xmlWriter.WriteEndElement();
          xmlWriter.WriteEndElement();
          xmlWriter.WriteEndDocument();
          xmlWriter.Flush();
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: Settings file location = " + UploadSettings.SettingsFileLocation, EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: SettingsVerified = " + Conversions.ToString(UploadSettings._SettingsVerified), EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: InstallLocation = " + Conversions.ToString((int) UploadSettings._InstallLocation), EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: VCDServerAddress = " + UploadSettings._VCDServerAddress, EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: LocalCopyToAddress = " + UploadSettings._LocalCopyToAddress, EventLogEntryType.Information, 4);
          Logging.AddLogEntry((object) "UploadSettings.Create", "UploadSettings: DebugLevel = " + Conversions.ToString(UploadSettings.DebugLevel), EventLogEntryType.Information, 4);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Logging.AddLogEntry((object) "UploadSettings.Create", "Error: " + exception.ToString(), EventLogEntryType.Error, 0);
        int num = (int) Interaction.MsgBox((object) "UploadSettings.Create", (MsgBoxStyle) Conversions.ToInteger("Error: \r\n" + exception.ToString()), (object) MsgBoxStyle.Critical);
        ProjectData.ClearProjectError();
      }
    }

    private static bool VerifySettings() => UploadSettings.VerifySettings(0);

    private static bool VerifySettings(int Recursion)
    {
      if (!MyProject.Computer.FileSystem.FileExists(UploadSettings.SettingsFileLocation) & Recursion <= 1)
      {
        UploadSettings.Create();
        return UploadSettings.VerifySettings(checked (Recursion + 1));
      }
      return !(!MyProject.Computer.FileSystem.FileExists(UploadSettings.SettingsFileLocation) & Recursion >= 1);
    }

    private static string GetVal(string Name)
    {
      if (UploadSettings.VerifySettings())
      {
        using (XmlReader xmlReader = XmlReader.Create(UploadSettings.SettingsFileLocation))
        {
          bool flag = false;
          while (xmlReader.Read())
          {
            if (xmlReader.NodeType == XmlNodeType.Element & xmlReader.HasAttributes && Operators.CompareString(xmlReader[nameof (Name)].ToUpper(), Name.ToString().ToUpper(), false) == 0)
              return xmlReader["Value"];
          }
          if (!flag)
          {
            Logging.AddLogEntry((object) "clsUploadSettings: GetVal", "Couldn't find requested setting\r\nSetting: " + Name, EventLogEntryType.Error, 0);
            UploadSettings.Create();
          }
        }
        return (string) null;
      }
      Logging.AddLogEntry((object) "clsUploadSettings: GetVal", "Couldn't create settings file", EventLogEntryType.Error, 0);
      throw new ArgumentException("Couldn't create settings file");
    }
  }
}
