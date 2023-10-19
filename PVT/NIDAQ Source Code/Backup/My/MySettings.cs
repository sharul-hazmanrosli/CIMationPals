// Decompiled with JetBrains decompiler
// Type: NIDAQ.My.MySettings
// Assembly: NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E0A2D9-BC78-4088-A605-9E0C1595E02F
// Assembly location: C:\Program Files (x86)\CIMProjects.Net\Marconi\NIDAQ\amd64\NIDAQ.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NIDAQ.My
{
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());

    [DebuggerNonUserCode]
    public MySettings()
    {
    }

    public static MySettings Default
    {
      get
      {
        MySettings defaultInstance = MySettings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
