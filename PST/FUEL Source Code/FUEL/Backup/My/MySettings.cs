// Decompiled with JetBrains decompiler
// Type: FUEL.My.MySettings
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FUEL.My
{
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  public sealed class MySettings : ApplicationSettingsBase
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

    [UserScopedSetting]
    [DefaultSettingValue("AP41M;-102.5;105;InchesWater|AP41M;7.53375;-7.7175;InchesHg|Voltage;20;0;Volts")]
    [DebuggerNonUserCode]
    public string SensorCalibrations
    {
      get => Conversions.ToString(this[nameof (SensorCalibrations)]);
      set => this[nameof (SensorCalibrations)] = (object) value;
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public DateTime UpdateCheck
    {
      get => Conversions.ToDate(this[nameof (UpdateCheck)]);
      set => this[nameof (UpdateCheck)] = (object) value;
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public DateTime LastUploadTime
    {
      get => Conversions.ToDate(this[nameof (LastUploadTime)]);
      set => this[nameof (LastUploadTime)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("HP|NKG")]
    public string SiteList
    {
      get => Conversions.ToString(this[nameof (SiteList)]);
      set => this[nameof (SiteList)] = (object) value;
    }

    [UserScopedSetting]
    [DefaultSettingValue("0")]
    [DebuggerNonUserCode]
    public int CurrentSite
    {
      get => Conversions.ToInteger(this[nameof (CurrentSite)]);
      set => this[nameof (CurrentSite)] = (object) value;
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("4")]
    [UserScopedSetting]
    public int DebugLevel
    {
      get => Conversions.ToInteger(this[nameof (DebugLevel)]);
      set => this[nameof (DebugLevel)] = (object) value;
    }

    [UserScopedSetting]
    [DefaultSettingValue("-1")]
    [DebuggerNonUserCode]
    public int TestStationType
    {
      get => Conversions.ToInteger(this[nameof (TestStationType)]);
      set => this[nameof (TestStationType)] = (object) value;
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public DateTime TestStationType_Date
    {
      get => Conversions.ToDate(this[nameof (TestStationType_Date)]);
      set => this[nameof (TestStationType_Date)] = (object) value;
    }

    [DebuggerNonUserCode]
    [ApplicationScopedSetting]
    [DefaultSettingValue("mAPCaGMj4WrKdy46+tgeYMcvf9K9OYZQ3wVOeYir4eJq0kXADVReDbydeqNveZto")]
    public string SecurePropertyKey_OverRide => Conversions.ToString(this[nameof (SecurePropertyKey_OverRide)]);

    [DefaultSettingValue("mytest")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string testing
    {
      get => Conversions.ToString(this[nameof (testing)]);
      set => this[nameof (testing)] = (object) value;
    }
  }
}
