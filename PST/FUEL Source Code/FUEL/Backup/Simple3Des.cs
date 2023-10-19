// Decompiled with JetBrains decompiler
// Type: FUEL.Simple3Des
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FUEL
{
  internal sealed class Simple3Des
  {
    private TripleDESCryptoServiceProvider TripleDes;

    public Simple3Des(string key)
    {
      this.TripleDes = new TripleDESCryptoServiceProvider();
      this.TripleDes.Key = this.TruncateHash(key, this.TripleDes.KeySize / 8);
      this.TripleDes.IV = this.TruncateHash("", this.TripleDes.BlockSize / 8);
    }

    private byte[] TruncateHash(string Key, int Length) => (byte[]) Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array) new SHA256CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(Key)), (Array) new byte[checked (Length - 1 + 1)]);

    public string EncryptData(string PlainText)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(PlainText);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, this.TripleDes.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(bytes, 0, bytes.Length);
      cryptoStream.FlushFinalBlock();
      return Convert.ToBase64String(memoryStream.ToArray());
    }

    public string DecryptData(string encryptedtext)
    {
      byte[] buffer = Convert.FromBase64String(encryptedtext);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, this.TripleDes.CreateDecryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(buffer, 0, buffer.Length);
      cryptoStream.FlushFinalBlock();
      return Encoding.Unicode.GetString(memoryStream.ToArray());
    }
  }
}
