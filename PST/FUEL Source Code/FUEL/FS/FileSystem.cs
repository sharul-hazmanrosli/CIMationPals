// Decompiled with JetBrains decompiler
// Type: FUEL.FS.FileSystem
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;

namespace FUEL.FS
{
  public class FileSystem
  {
    [DebuggerNonUserCode]
    public FileSystem()
    {
    }

    public static object SetPath(string Path) => (object) FileSystem.SetPath(Path, FilePurpose.ForWriting);

    public static string SetPath(string Path, FilePurpose Purpose)
    {
      string str;
      try
      {
        string directoryName = Path.GetDirectoryName(Path);
        string fileName = Path.GetFileName(Path);
        switch (Purpose)
        {
          case FilePurpose.ForReading:
            if (Operators.CompareString(fileName, (string) null, false) == 0)
              throw new ArgumentException("No file name specified", Path);
            if (!MyProject.Computer.FileSystem.FileExists(Path.Combine(directoryName, fileName)))
              throw new ArgumentException("The file '" + fileName + "' does not exist", Path);
            break;
          case FilePurpose.ForWriting:
            if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
            {
              if (Interaction.MsgBox((object) ("The directory '" + directoryName.ToString() + "' does not exist. Would you like me to create it?"), MsgBoxStyle.YesNo) != MsgBoxResult.Yes)
                throw new ApplicationException("The directory '" + directoryName + "' does not exist");
              try
              {
                MyProject.Computer.FileSystem.CreateDirectory(directoryName);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                throw;
              }
            }
            break;
        }
        str = Path;
      }
      catch (ApplicationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) Interaction.MsgBox((object) ex.Message.ToString());
        str = (string) null;
        ProjectData.ClearProjectError();
      }
      return str;
    }

    public static bool CheckFileExists(string FileName) => MyProject.Computer.FileSystem.FileExists(FileName);

    public static bool CheckDirectoryExists(string DirName) => MyProject.Computer.FileSystem.DirectoryExists(DirName);

    public static void DeleteFile(string FileName) => FileSystem.DeleteFile(FileName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

    public static void DeleteFile(string FileName, UIOption Dialogs, RecycleOption Reycle) => MyProject.Computer.FileSystem.DeleteFile(FileName, Dialogs, RecycleOption.SendToRecycleBin);

    public static void CreateDir(string DirectoryName) => MyProject.Computer.FileSystem.CreateDirectory(DirectoryName);

    public static void CopyFile(string SourceFile, string DestFile)
    {
      SourceFile = FileSystem.SetPath(SourceFile, FilePurpose.ForReading);
      MyProject.Computer.FileSystem.CopyFile(SourceFile, DestFile);
    }
  }
}
