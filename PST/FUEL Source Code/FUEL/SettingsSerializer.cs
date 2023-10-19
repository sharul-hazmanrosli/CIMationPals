// Decompiled with JetBrains decompiler
// Type: FUEL.SettingsSerializer
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace FUEL
{
  public class SettingsSerializer
  {
    [DebuggerNonUserCode]
    public SettingsSerializer()
    {
    }

    public static void Serialize(clsUploadSettings2 Setting)
    {
      Logging.AddLogEntry((object) nameof (SettingsSerializer), "Serialize: Starting", EventLogEntryType.Information, 4);
      try
      {
        StreamWriter streamWriter = new StreamWriter(Setting.SettingsFileLocation);
        new XmlSerializer(typeof (clsUploadSettings2)).Serialize((TextWriter) streamWriter, (object) Setting);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static clsUploadSettings2 DeSerialize(string FileName)
    {
      clsUploadSettings2 clsUploadSettings2_1 = new clsUploadSettings2();
      if (!MyProject.Computer.FileSystem.FileExists(FileName))
        return (clsUploadSettings2) null;
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (clsUploadSettings2));
      FileStream fileStream = new FileStream(FileName, FileMode.Open);
      clsUploadSettings2 clsUploadSettings2_2 = (clsUploadSettings2) xmlSerializer.Deserialize((Stream) fileStream);
      fileStream.Close();
      return clsUploadSettings2_2;
    }
  }
}
