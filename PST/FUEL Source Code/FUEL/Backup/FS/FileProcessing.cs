// Decompiled with JetBrains decompiler
// Type: FUEL.FS.FileProcessing
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace FUEL.FS
{
  public class FileProcessing
  {
    [DebuggerNonUserCode]
    public FileProcessing()
    {
    }

    public static object ReadFile(string Path) => (object) MyProject.Computer.FileSystem.ReadAllText(FileSystem.SetPath(Path, FilePurpose.ForReading));

    public static string[,] ReadDelimitedFile(string Path, string Delimiter) => FileProcessing.ReadDelimitedFile(Path, Delimiter, (string[]) null, -1, -1L);

    public static string[,] ReadDelimitedFile(
      string Path,
      string Delimiter,
      string[] CommentTokens)
    {
      return FileProcessing.ReadDelimitedFile(Path, Delimiter, CommentTokens, -1, -1L);
    }

    private static string[,] ReadDelimitedFile(
      string Path,
      string Delimiter,
      string[] CommentTokens,
      int MaxFieldCnt,
      long LineCnt)
    {
      string path;
      try
      {
        path = FileSystem.SetPath(Path, FilePurpose.ForReading);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        throw;
      }
      bool flag = false;
      string[,] strArray1 = (string[,]) null;
      if (MaxFieldCnt != -1)
      {
        flag = true;
        strArray1 = new string[checked ((int) (LineCnt - 1L) + 1), checked (MaxFieldCnt - 1 + 1)];
      }
      using (TextFieldParser textFieldParser = new TextFieldParser(path))
      {
        textFieldParser.SetDelimiters(Delimiter);
        textFieldParser.CommentTokens = CommentTokens;
        textFieldParser.TrimWhiteSpace = true;
        int index1 = 0;
        while (!textFieldParser.EndOfData)
        {
          string[] strArray2 = textFieldParser.ReadFields();
          if (flag)
          {
            int num = checked (strArray2.Length - 1);
            int index2 = 0;
            while (index2 <= num)
            {
              strArray1[index1, index2] = strArray2[index2];
              checked { ++index2; }
            }
            checked { ++index1; }
          }
          else if (strArray2.Length > MaxFieldCnt)
            MaxFieldCnt = strArray2.Length;
          if (textFieldParser.LineNumber != -1L)
            LineCnt = textFieldParser.LineNumber;
          else if (textFieldParser.LineNumber != -1L & LineCnt == -1L)
            LineCnt = 1L;
        }
      }
      return flag ? strArray1 : FileProcessing.ReadDelimitedFile(Path, Delimiter, CommentTokens, MaxFieldCnt, LineCnt);
    }

    public static void WriteDelimitedFile(
      string Path,
      string[] Header,
      string[,] Body,
      string Delimiter)
    {
      FileProcessing.WriteDelimitedFile(Path, Header, Body, Delimiter, true);
    }

    public static void WriteDelimitedFile(
      string Path,
      string[] Header,
      string[,] Body,
      string Delimiter,
      bool AppendWriteExistingFile)
    {
      string file = FileSystem.SetPath(Path, FilePurpose.ForWriting);
      StringBuilder stringBuilder = new StringBuilder();
      if (!MyProject.Computer.FileSystem.FileExists(file) & Header != null)
      {
        string str = Strings.Join(Header, Delimiter);
        stringBuilder.Append(str).AppendLine();
      }
      int num1 = Information.UBound((Array) Body);
      int index1 = 0;
      while (index1 <= num1)
      {
        string str = (string) null;
        int num2 = Information.UBound((Array) Body, 2);
        int index2 = 0;
        while (index2 <= num2)
        {
          str += Body[index1, index2];
          if (index2 < Information.UBound((Array) Body, 2))
            str += Delimiter;
          checked { ++index2; }
        }
        stringBuilder.Append(str).AppendLine();
        checked { ++index1; }
      }
      string text = stringBuilder.ToString();
      MyProject.Computer.FileSystem.WriteAllText(file, text, AppendWriteExistingFile);
    }

    public static void WriteToFile(string Filename, string TextToWrite, bool Append)
    {
      Filename = FileSystem.SetPath(Filename, FilePurpose.ForWriting);
      MyProject.Computer.FileSystem.WriteAllText(Filename, TextToWrite, Append);
    }

    public static void ZipFiles(string SourceDir, string OutputName) => FileProcessing.ZipFiles(SourceDir, OutputName, 0.0, false);

    public static void ZipFiles(string SourceDir, string OutputName, double MaxFileSize) => FileProcessing.ZipFiles(SourceDir, OutputName, MaxFileSize, false);

    public static void ZipFiles(
      string SourceDir,
      string OutputName,
      double MaxFileSize,
      bool DeleteFiles)
    {
      frmZipProgress frmZipProgress = new frmZipProgress(SourceDir, OutputName, DeleteFiles);
      frmZipProgress.MaxFileSize = checked ((long) System.Math.Round(MaxFileSize));
      IntPtr owner = PST.getOwner();
      if (owner != (IntPtr) -1)
      {
        int num1 = (int) frmZipProgress.ShowDialog((IWin32Window) new WindowWrapper(owner));
      }
      else
      {
        int num2 = (int) frmZipProgress.ShowDialog();
      }
    }
  }
}
