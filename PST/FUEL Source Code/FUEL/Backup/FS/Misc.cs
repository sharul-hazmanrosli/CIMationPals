// Decompiled with JetBrains decompiler
// Type: FUEL.FS.Misc
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DataMatrix.net;
using FUEL.My;
using MessagingToolkit.QRCode.Codec;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;

namespace FUEL.FS
{
  [StandardModule]
  public sealed class Misc
  {
    public static void CheckForDAQDrivers()
    {
      string str = Path.Combine(new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "LaunchNIDaqInstall.exe");
      Process process = new Process();
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.FileName = str;
      process.Start();
      process.WaitForExit();
    }

    public static void CheckForUpdate(CheckForUpdates.CheckType UpdateType) => modCheckForUpdates.CheckForUpdate(CheckForUpdates.CheckType.FS);

    public static object GetComputerName() => Misc.GetComputerName(false);

    internal static object GetComputerName(bool ForFUELCompatFileName) => !ForFUELCompatFileName ? (object) MyProject.Computer.Name : (object) MyProject.Computer.Name.Replace("_", "-");

    public static object GenerateFUELCompatibleFileName(
      string Product,
      string DataType,
      ctrlUploadFiles.FileType ValidDuration,
      string FileExtension)
    {
      return Misc.GenerateFUELCompatibleFileName(Product, DataType, ValidDuration, FileExtension, (string) null);
    }

    public static object GenerateFUELCompatibleFileName(
      string Product,
      string DataType,
      ctrlUploadFiles.FileType ValidDuration,
      string FileExtension,
      string ExtraInfo)
    {
      string Right = Strings.Replace(Conversions.ToString(DateAndTime.Now.Date), "/", "-");
      if (ValidDuration == ctrlUploadFiles.FileType.Monthly)
        Right = Strings.Replace(Conversions.ToString(DateAndTime.Now.Month) + "-" + Conversions.ToString(DateAndTime.Now.Year), "/", "-");
      if (!FileExtension.StartsWith("."))
        FileExtension = "." + FileExtension;
      string str = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) (DataType + "_" + Product + "_"), Misc.GetComputerName(true)), (object) "_"), (object) Right));
      if (Operators.CompareString(ExtraInfo, (string) null, false) != 0)
        str = str + "_" + ExtraInfo;
      return (object) (str + FileExtension);
    }

    public static bool ValidateSecurePropertyKey(string Key) => Misc.ValidateSecurePropertyKey(Key, false, false);

    public static bool ValidateSecurePropertyKey(string Key, bool MsgExpired, bool ThrowOnExpired)
    {
      if (Operators.CompareString(Key, (string) null, false) != 0)
      {
        clsSecurePropertyKey securePropertyKey = new clsSecurePropertyKey(Key);
        if (MsgExpired | ThrowOnExpired && !securePropertyKey.KeyIsValid)
        {
          string str = "The security key provided expired on " + Conversions.ToString(securePropertyKey.KeyExpirationDate.Date) + " and is no longer valid";
          if (ThrowOnExpired)
            throw new Exception(str);
          if (MsgExpired)
          {
            int num = (int) Interaction.MsgBox((object) str, MsgBoxStyle.Critical);
          }
        }
        return securePropertyKey.KeyIsValid;
      }
      if (MsgExpired | ThrowOnExpired)
      {
        int num1 = (int) Interaction.MsgBox((object) "Key not provided, and thus is not valid.", MsgBoxStyle.Critical);
      }
      return false;
    }

    public static void CreateQRCode(string PSID, string PrinterSerialNum, string OutputPath) => Misc.CreateQRCode(PSID, PrinterSerialNum, OutputPath, 4, 2, false);

    public static void CreateQRCode(
      string PSID,
      string PrinterSerialNum,
      string OutputPath,
      int Scale,
      int ErrorCorrection,
      bool TransParentBackground)
    {
      FileSystem.SetPath(Path.GetDirectoryName(OutputPath));
      Color color1 = new Color();
      Color color2 = TransParentBackground ? Color.White : Color.Snow;
      Bitmap OriginalImage = new QRCodeEncoder()
      {
        QRCodeErrorCorrect = ((QRCodeEncoder.ERROR_CORRECTION) ErrorCorrection),
        QRCodeScale = Scale,
        QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC,
        QRCodeBackgroundColor = color2
      }.Encode(PSID);
      OriginalImage.SetPixel(1, 1, Color.Red);
      Misc.AddTextToBarcode(PSID + "\r\n" + PrinterSerialNum + "\r\n" + Conversions.ToString(DateAndTime.Now) + "\r\nFUEL: " + PST.TestInformation.FuelRev, OriginalImage, TransParentBackground).Save(OutputPath, ImageFormat.Bmp);
    }

    public static void Create2dBarcode(
      string PSID,
      string PrinterSerialNum,
      string OutputPath,
      bool TransParentBackground)
    {
      FileSystem.SetPath(Path.GetDirectoryName(OutputPath));
      Color color1 = new Color();
      Color color2 = TransParentBackground ? Color.White : Color.Snow;
      DmtxImageEncoder dmtxImageEncoder = new DmtxImageEncoder();
      Misc.AddTextToBarcode(PSID + "\r\n" + PrinterSerialNum + "\r\n" + Conversions.ToString(DateAndTime.Now) + "\r\nFUEL: " + PST.TestInformation.FuelRev, dmtxImageEncoder.EncodeImage(PSID, new DmtxImageEncoderOptions()
      {
        ModuleSize = 9,
        BackColor = color2,
        MarginSize = 0,
        ForeColor = Color.Black
      }), TransParentBackground).Save(OutputPath, ImageFormat.Bmp);
    }

    public static void CreateBMPFromString(
      string Text,
      string OutputPath,
      bool TransParentBackground)
    {
      Brush brush1 = TransParentBackground ? Brushes.White : Brushes.Snow;
      Font font1 = new Font("Arial", 20f);
      SizeF sizeF = Graphics.FromImage((Image) new Bitmap(1, 1, PixelFormat.Format24bppRgb)).MeasureString(Text, font1);
      Bitmap bitmap = new Bitmap(checked ((int) System.Math.Round((double) sizeF.Width)), checked ((int) System.Math.Round((double) sizeF.Height)), PixelFormat.Format24bppRgb);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap);
      using (graphics1)
      {
        Graphics graphics2 = graphics1;
        Brush brush2 = brush1;
        Rectangle rectangle = new Rectangle(-1, -1, checked ((int) System.Math.Round((double) unchecked (sizeF.Width + 2f))), checked ((int) System.Math.Round((double) unchecked (sizeF.Height + 2f))));
        Rectangle rect = rectangle;
        graphics2.FillRectangle(brush2, rect);
        Graphics graphics3 = graphics1;
        string s = Text;
        Font font2 = font1;
        Brush red = Brushes.Red;
        rectangle = new Rectangle(1, 1, checked ((int) System.Math.Round((double) unchecked (sizeF.Width + 2f))), checked ((int) System.Math.Round((double) unchecked (sizeF.Height + 2f))));
        RectangleF layoutRectangle = (RectangleF) rectangle;
        graphics3.DrawString(s, font2, red, layoutRectangle);
      }
      bitmap.Save(OutputPath);
    }

    private static Bitmap AddTextToBarcode(
      string bcdText,
      Bitmap OriginalImage,
      bool TransParentBackground)
    {
      Brush brush1 = TransParentBackground ? Brushes.White : Brushes.Snow;
      Font font1 = new Font("Courier New", 24f);
      string text = bcdText;
      SizeF sizeF = Graphics.FromImage((Image) OriginalImage).MeasureString(text, font1);
      Bitmap barcode = new Bitmap(checked ((int) System.Math.Round(unchecked ((double) OriginalImage.Width + (double) sizeF.Width + 12.0))), checked (OriginalImage.Height + 12), PixelFormat.Format24bppRgb);
      Graphics graphics1 = Graphics.FromImage((Image) barcode);
      using (graphics1)
      {
        graphics1.SmoothingMode = SmoothingMode.AntiAlias;
        Graphics graphics2 = graphics1;
        Brush brush2 = brush1;
        RectangleF rectangleF = new RectangleF(-1f, -1f, (float) checked (barcode.Width + 2), (float) checked (barcode.Height + 2));
        RectangleF rect = rectangleF;
        graphics2.FillRectangle(brush2, rect);
        graphics1.DrawImageUnscaled((Image) OriginalImage, new Rectangle(6, 6, barcode.Width, barcode.Height));
        Graphics graphics3 = graphics1;
        string s = text;
        Font font2 = font1;
        Brush red = Brushes.Red;
        rectangleF = new RectangleF((float) checked (OriginalImage.Width + 10), 0.0f, (float) barcode.Width, (float) barcode.Height);
        RectangleF layoutRectangle = rectangleF;
        graphics3.DrawString(s, font2, red, layoutRectangle);
      }
      return barcode;
    }

    public static int GetMediaSize(string File)
    {
      FileSystem.SetPath(File, FilePurpose.ForReading);
      byte[] numArray = MyProject.Computer.FileSystem.ReadAllBytes(File);
      bool flag1 = false;
      string[] arySrc = new string[1];
      long num1 = (long) Information.UBound((Array) numArray);
      long index1 = 0;
      while (index1 <= num1)
      {
        if (numArray[checked ((int) index1)] == (byte) 38 && numArray[checked ((int) (index1 + 1L))] == (byte) 108)
        {
          bool flag2 = false;
          long index2 = index1;
          while (!flag2 & index2 < (long) Information.UBound((Array) numArray))
          {
            if (Operators.CompareString(arySrc[0], (string) null, false) == 0)
            {
              arySrc[0] = Misc.ConvertByteArrayToString(new byte[1]
              {
                numArray[checked ((int) index2)]
              });
            }
            else
            {
              arySrc = (string[]) Utils.CopyArray((Array) arySrc, (Array) new string[checked (Information.UBound((Array) arySrc) + 1 + 1)]);
              arySrc[Information.UBound((Array) arySrc)] = Misc.ConvertByteArrayToString(new byte[1]
              {
                numArray[checked ((int) index2)]
              });
            }
            if (Operators.CompareString(Misc.ConvertByteArrayToString(new byte[1]
            {
              numArray[checked ((int) index2)]
            }).ToLower(), "a", false) == 0)
            {
              flag1 = true;
              goto label_14;
            }
            else
            {
              if (Operators.CompareString(Misc.ConvertByteArrayToString(new byte[1]
              {
                numArray[checked ((int) index2)]
              }), "\u001B", false) == 0)
              {
                flag2 = true;
                flag1 = false;
                arySrc = new string[1];
              }
              checked { ++index2; }
            }
          }
        }
        checked { ++index1; }
      }
label_14:
      int mediaSize = -100;
      if (flag1)
      {
        string Expression = (string) null;
        int num2 = checked (Information.UBound((Array) arySrc) - 1);
        int index3 = 2;
        while (index3 <= num2)
        {
          Expression += arySrc[index3];
          checked { ++index3; }
        }
        if (Versioned.IsNumeric((object) Expression))
          mediaSize = Conversions.ToInteger(Expression);
      }
      return mediaSize;
    }

    private static string ConvertByteArrayToString(byte[] byteArray) => Encoding.UTF8.GetString(byteArray);
  }
}
