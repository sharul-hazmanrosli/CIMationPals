// Decompiled with JetBrains decompiler
// Type: FUEL.modCommonCode
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Deployment.Application;
using System.Reflection;

namespace FUEL
{
  [StandardModule]
  internal sealed class modCommonCode
  {
    internal static string GetDataPath()
    {
      string str1;
      if (ApplicationDeployment.IsNetworkDeployed)
      {
        str1 = ApplicationDeployment.CurrentDeployment.DataDirectory.ToString();
      }
      else
      {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        string str2 = Strings.Left(codeBase, Strings.InStrRev(codeBase, "/"));
        str1 = Strings.Right(str2, checked (Strings.Len(str2) - Strings.InStr(str2, "///") - 2)).Replace("/", "\\");
      }
      return str1.EndsWith("\\") ? str1 : str1 + "\\";
    }
  }
}
