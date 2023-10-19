// Decompiled with JetBrains decompiler
// Type: FUEL.clsUploadSettings2
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using System.Diagnostics;
using System.IO;

namespace FUEL
{
  public class clsUploadSettings2
  {
    private PST.TestSites _InstallLocation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _VCDServerAddress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _LocalCopyToAddress { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _SettingsVerified { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private int _DebugLevel { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    internal string SettingsFileLocation => modCommonCode.GetDataPath().ToLower().Contains("\\bin\\") ? "C:\\Users\\morrisor\\Documents\\Visual Studio 2010\\Projects\\FUEL\\AutoSendFiles\\FUEL\\Uploadsettings2.xml" : Path.Combine(modCommonCode.GetDataPath(), "Uploadsettings2.xml");

    public PST.TestSites InstallLocation
    {
      get => this._InstallLocation;
      set => this._InstallLocation = value;
    }

    public string VCDServerAddress
    {
      get => this._VCDServerAddress;
      set => this._VCDServerAddress = value;
    }

    public string LocalCopyToAddress
    {
      get => this._LocalCopyToAddress;
      set => this._LocalCopyToAddress = value;
    }

    public bool SettingsVerified
    {
      get => this._SettingsVerified;
      set => this._SettingsVerified = value;
    }

    public int DebugLevel
    {
      get => this._DebugLevel;
      set => this._DebugLevel = value;
    }

    public void Reset()
    {
      this._InstallLocation = PST.TestSites.HP;
      this._LocalCopyToAddress = "M:\\";
      this._VCDServerAddress = "http://pst1.vcd.hp.com/PST/upload.php";
      this._SettingsVerified = false;
      this._DebugLevel = 4;
    }
  }
}
