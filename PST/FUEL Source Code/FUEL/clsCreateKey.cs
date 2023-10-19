// Decompiled with JetBrains decompiler
// Type: FUEL.clsCreateKey
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace FUEL
{
  internal class clsCreateKey
  {
    [DebuggerNonUserCode]
    public clsCreateKey()
    {
    }

    public static string GeneratePropertyKey(DateTime DateToExpire) => new Simple3Des("Overlanding123").EncryptData(Conversions.ToString(Conversions.ToDouble(Conversions.ToString(DateToExpire.Ticks)) * Math.PI));

    public static string GenerateScriptKey(DateTime DateToExpire) => clsCreateKey.GeneratePropertyKey(DateToExpire);
  }
}
