// Decompiled with JetBrains decompiler
// Type: NIDAQ.My.Resources.Resources
// Assembly: NIDAQ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8E0A2D9-BC78-4088-A605-9E0C1595E02F
// Assembly location: C:\Program Files (x86)\CIMProjects.Net\Marconi\NIDAQ\amd64\NIDAQ.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NIDAQ.My.Resources
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [HideModuleName]
  [StandardModule]
  [DebuggerNonUserCode]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) NIDAQ.My.Resources.Resources.resourceMan, (object) null))
          NIDAQ.My.Resources.Resources.resourceMan = new ResourceManager("NIDAQ.Resources", typeof (NIDAQ.My.Resources.Resources).Assembly);
        return NIDAQ.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => NIDAQ.My.Resources.Resources.resourceCulture;
      set => NIDAQ.My.Resources.Resources.resourceCulture = value;
    }
  }
}
