// Decompiled with JetBrains decompiler
// Type: FUEL.My.Resources.Resources
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FUEL.My.Resources
{
  [DebuggerNonUserCode]
  [StandardModule]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  [HideModuleName]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) FUEL.My.Resources.Resources.resourceMan, (object) null))
          FUEL.My.Resources.Resources.resourceMan = new ResourceManager("FUEL.Resources", typeof (FUEL.My.Resources.Resources).Assembly);
        return FUEL.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => FUEL.My.Resources.Resources.resourceCulture;
      set => FUEL.My.Resources.Resources.resourceCulture = value;
    }

    internal static Bitmap Bad_PST_Box => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Bad_PST_Box), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Error_icon => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Error_icon), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Error_icon_sm => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Error_icon_sm), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap FluctuatingPressure => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (FluctuatingPressure), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap frown_sm => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (frown_sm), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Good_or_Tick_icon => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Good_or_Tick_icon), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Good_or_Tick_icon_sm => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Good_or_Tick_icon_sm), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap happy_sm => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (happy_sm), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap idk1 => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (idk1), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap idk2 => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (idk2), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Kinked_Tube_possible => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Kinked_Tube_possible), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap Leak => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (Leak), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap NoPressure => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (NoPressure), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap oh_noes => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject("oh noes", FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap PinchedVentTube => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (PinchedVentTube), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap VerySmallVentDeltaP => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (VerySmallVentDeltaP), FUEL.My.Resources.Resources.resourceCulture));

    internal static Bitmap warning_sm => (Bitmap) RuntimeHelpers.GetObjectValue(FUEL.My.Resources.Resources.ResourceManager.GetObject(nameof (warning_sm), FUEL.My.Resources.Resources.resourceCulture));
  }
}
