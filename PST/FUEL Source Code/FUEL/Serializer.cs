// Decompiled with JetBrains decompiler
// Type: FUEL.Serializer
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
  public class Serializer
  {
    [DebuggerNonUserCode]
    public Serializer()
    {
    }

    public static void SerializeMe(PST PST, string SpecFileName)
    {
      Logging.AddLogEntry((object) nameof (Serializer), "SerializeMe: Starting", EventLogEntryType.Information, 4);
      TestSpecs testSpecs = new TestSpecs();
      testSpecs.PST = PST;
      SpecFile specFile = new SpecFile();
      SpecFile o = Serializer.DeserializeMe(SpecFileName);
      o.Tests.Add(testSpecs);
      try
      {
        StreamWriter streamWriter = new StreamWriter(SpecFileName);
        new XmlSerializer(typeof (SpecFile)).Serialize((TextWriter) streamWriter, (object) o);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Logging.AddLogEntry((object) nameof (Serializer), "SerializeMe: Error writing spec file..." + ex.ToString(), EventLogEntryType.Error, 0);
        ProjectData.ClearProjectError();
      }
      Logging.AddLogEntry((object) nameof (Serializer), "SerializeMe: Complete", EventLogEntryType.Information, 4);
    }

    public static SpecFile DeserializeMe(string SpecFileName)
    {
      SpecFile specFile = new SpecFile();
      Logging.AddLogEntry((object) nameof (Serializer), "DeserializeMe: Starting", EventLogEntryType.Information, 4);
      if (MyProject.Computer.FileSystem.FileExists(SpecFileName))
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (SpecFile));
        FileStream fileStream = new FileStream(SpecFileName, FileMode.Open);
        specFile = (SpecFile) xmlSerializer.Deserialize((Stream) fileStream);
        fileStream.Close();
      }
      else
        Logging.AddLogEntry((object) nameof (Serializer), "DeserializeMe: SpecFile doesnt exist: " + SpecFileName, EventLogEntryType.Error, 0);
      Logging.AddLogEntry((object) nameof (Serializer), "DeserializeMe: Complete", EventLogEntryType.Information, 4);
      return specFile;
    }

    public static TestSpecs GetTestSpecs(string TestID, SpecFile TestSpecs)
    {
      int index1 = -1;
      int num = checked (TestSpecs.Tests.Count - 1);
      int index2 = 0;
      while (index2 <= num)
      {
        if (Operators.CompareString(TestSpecs.Tests[index2].TestID.ToLower(), TestID.ToLower(), false) == 0)
          index1 = index2;
        checked { ++index2; }
      }
      if (index1 == -1)
        throw new ArgumentException("Test ID " + TestID + " not found in the SpecFile");
      return new TestSpecs()
      {
        TestID = TestID,
        PST = TestSpecs.Tests[index1].PST
      };
    }
  }
}
