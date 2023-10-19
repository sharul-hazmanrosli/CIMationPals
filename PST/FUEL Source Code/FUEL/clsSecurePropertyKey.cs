// Decompiled with JetBrains decompiler
// Type: FUEL.clsSecurePropertyKey
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FUEL
{
  public class clsSecurePropertyKey
  {
    private string _DecryptedKey { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private DateTime _KeyExpirationDate { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public DateTime KeyExpirationDate => this._KeyExpirationDate;

    private string _Key { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string Key => this._Key;

    public bool KeyIsValid
    {
      get
      {
        if (!(DateTime.Compare(this._KeyExpirationDate.Date, DateAndTime.Now.Date) >= 0 | DateTime.Compare(this._KeyExpirationDate.Date, Conversions.ToDate("06/06/2006").Date) == 0))
          return false;
        if (DateTime.Compare(this._KeyExpirationDate, Conversions.ToDate("06/06/2006")) == 0)
        {
          int num = (int) Interaction.MsgBox((object) "666");
        }
        return true;
      }
    }

    private DateTime GetDateFromDecryptedKey(object strKey) => Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(strKey)) ? new DateTime(Conversions.ToLong(Operators.DivideObject(strKey, (object) Math.PI))) : throw new ArgumentException("Malformed Key");

    protected internal clsSecurePropertyKey()
    {
    }

    public clsSecurePropertyKey(string Key)
    {
      this._DecryptedKey = new Simple3Des("Overlanding123").DecryptData(Key);
      this._KeyExpirationDate = this.GetDateFromDecryptedKey((object) this._DecryptedKey);
    }
  }
}
