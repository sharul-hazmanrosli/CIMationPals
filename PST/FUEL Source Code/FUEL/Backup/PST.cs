// Decompiled with JetBrains decompiler
// Type: FUEL.PST
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using FUEL.FS;
using FUEL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FUEL
{
  [Serializable]
  public class PST
  {
    private string _TestID { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<TraceData> _PTraceBlack { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<TraceData> _PTraceColor { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _SaveFileLocation { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _OutputFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _SummaryFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private string _SpecFileName { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _BlackPressureOverRide { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _ColorPressureOverRide { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private List<PST.PrinterMechChecks> _MechChecks { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _BlackInstallPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private double _ColorInstallPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _TestStatus { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _OverallTestStatus { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    private bool _RetestForVentDP { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public bool RetestForVentDP
    {
      get => this._RetestForVentDP;
      set => this._RetestForVentDP = value;
    }

    private string _PreviousTestID { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public string PreviousTestID
    {
      get => this._PreviousTestID;
      set => this._PreviousTestID = value;
    }

    [XmlIgnore]
    public PST.PrinterInformation PrinterInfo { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public PST.TestInformation TestInfo { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public Specifications SpecsBlack { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    public Specifications SpecsColor { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public PST.Points KDataPoints { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public PST.Points CDataPoints { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public PST.Results KResults { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public PST.Results CResults { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

    [XmlIgnore]
    public object BlackInstallPressure => (object) this._BlackInstallPressure;

    [XmlIgnore]
    public object ColorInstallPressure => (object) this._ColorInstallPressure;

    [XmlIgnore]
    public bool OverallTestStatus => this._OverallTestStatus;

    public List<PST.PrinterMechChecks> MechChecks => this._MechChecks;

    public void AddMechCheck(
      string Name,
      PST.SpecType SpecType,
      double Spec,
      double Value,
      PST.SpecFunction SpecFunction)
    {
      if (this.VerifyUniqueMechCheck(Name))
      {
        PST.PrinterMechChecks printerMechChecks = new PST.PrinterMechChecks();
        printerMechChecks.AddMechCheck(Name, SpecType, Spec, Value, SpecFunction);
        this._MechChecks.Add(printerMechChecks);
      }
      else
      {
        int num = (int) Interaction.MsgBox((object) ("Duplicate Mech Check name, ignoring and moving on\r\nCheck Name: " + Name));
      }
    }

    public void AddMechCheck(
      string Name,
      PST.SpecType SpecType,
      double SpecLow,
      double SpecHigh,
      double Value,
      PST.SpecFunction SpecFunction)
    {
      if (this.VerifyUniqueMechCheck(Name))
      {
        PST.PrinterMechChecks printerMechChecks = new PST.PrinterMechChecks();
        printerMechChecks.AddMechCheck(Name, SpecType, SpecLow, SpecHigh, Value, SpecFunction);
        this._MechChecks.Add(printerMechChecks);
      }
      else
      {
        int num = (int) Interaction.MsgBox((object) ("Duplicate Mech Check name, ignoring and moving on\r\nCheck Name: " + Name));
      }
    }

    private bool VerifyUniqueMechCheck(string Name)
    {
      try
      {
        foreach (PST.PrinterMechChecks mechCheck in this._MechChecks)
        {
          if (Operators.CompareString(mechCheck.Name.ToLower(), Name, false) == 0)
            return false;
        }
      }
      finally
      {
        List<PST.PrinterMechChecks>.Enumerator enumerator;
        enumerator.Dispose();
      }
      return true;
    }

    public string SaveFileLocation
    {
      get => this._SaveFileLocation;
      set => this._SaveFileLocation = Operators.CompareString(value, (string) null, false) != 0 ? value : throw new ArgumentException("You must specify a path. You gave me nothing to work with", value);
    }

    public string TestID => this._TestID;

    [XmlIgnore]
    public List<TraceData> PTraceBlack
    {
      get => this._PTraceBlack;
      set => this._PTraceBlack = value;
    }

    [XmlIgnore]
    public List<TraceData> PTraceColor
    {
      get => this._PTraceColor;
      set => this._PTraceColor = value;
    }

    public bool TestStatus
    {
      get => this._TestStatus;
      set
      {
        if (!(this._TestStatus & !value))
          return;
        this._TestStatus = value;
      }
    }

    internal string OutputFileName
    {
      get => this._OutputFileName;
      set
      {
        if (Operators.CompareString(value, (string) null, false) != 0)
        {
          if (!value.EndsWith("\\"))
            value += "\\";
          string directoryName = Path.GetDirectoryName(value);
          try
          {
            if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
              MyProject.Computer.FileSystem.CreateDirectory(directoryName);
            string path2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) ("PST_" + this.TestInfo.ScriptProduct + "_"), Misc.GetComputerName(true)), (object) "_"), (object) DateAndTime.Now.Month), (object) "-"), (object) DateAndTime.Now.Day), (object) "-"), (object) DateAndTime.Now.Year), (object) "_"), (object) this.TestInfo.TestStationType.ToString()), (object) ".csv"));
            this._OutputFileName = Path.Combine(directoryName, path2);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            string message = "Unable to create folder for output file.\r\nPath: " + directoryName;
            Logging.AddLogEntry((object) this, "OutputFileName: Error: " + message, EventLogEntryType.Error, 0);
            throw new ApplicationException(message);
          }
        }
        else
        {
          Logging.AddLogEntry((object) this, "OutputFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0);
          throw new ArgumentException("You must specify a path. You gave me nothing to work with", value);
        }
      }
    }

    internal string SummaryFileName
    {
      get => this._SummaryFileName;
      set
      {
        if (Operators.CompareString(value, (string) null, false) != 0)
        {
          if (!value.EndsWith("\\"))
            value += "\\";
          string directoryName = Path.GetDirectoryName(value);
          try
          {
            if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
              MyProject.Computer.FileSystem.CreateDirectory(directoryName);
            string path2 = "PSTSummary_" + this._MonthlyFileName_Suffix + ".csv";
            this._SummaryFileName = Path.Combine(directoryName, path2);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Logging.AddLogEntry((object) this, "SummaryFileName: Error: " + ("Unable to create folder for output file.\r\nPath: " + directoryName), EventLogEntryType.Error, 0);
            throw new ApplicationException();
          }
        }
        else
        {
          Logging.AddLogEntry((object) this, "SummaryFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0);
          throw new ArgumentException("You must specify a path. You gave me nothing to work with", value);
        }
      }
    }

    internal string SpecFileName
    {
      get => this._SpecFileName;
      set
      {
        if (Operators.CompareString(value, (string) null, false) != 0)
        {
          if (!value.EndsWith("\\"))
            value += "\\";
          string directoryName = Path.GetDirectoryName(value);
          try
          {
            if (!MyProject.Computer.FileSystem.DirectoryExists(directoryName))
              MyProject.Computer.FileSystem.CreateDirectory(directoryName);
            string path2 = "PSTSpecs_" + this._MonthlyFileName_Suffix + ".xml";
            this._SpecFileName = Path.Combine(directoryName, path2);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Logging.AddLogEntry((object) this, "SpecFileName: Error: " + ("Unable to create folder for output file.\r\nPath: " + directoryName), EventLogEntryType.Error, 0);
            throw new ApplicationException();
          }
        }
        else
        {
          Logging.AddLogEntry((object) this, "SpecFileName: Error: You must specify a path. You gave me nothing to work with", EventLogEntryType.Error, 0);
          throw new ArgumentException("You must specify a path. You gave me nothing to work with", value);
        }
      }
    }

    private string _MonthlyFileName_Suffix => Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) (this.TestInfo.ScriptProduct + "_"), Misc.GetComputerName(true)), (object) "_"), (object) DateAndTime.Now.Month), (object) "-"), (object) DateAndTime.Now.Year), (object) "_"), (object) this.TestInfo.TestStationType.ToString()));

    protected PST()
    {
      this._BlackPressureOverRide = 1.0;
      this._ColorPressureOverRide = 1.0;
      this._MechChecks = new List<PST.PrinterMechChecks>();
      this._TestStatus = true;
      this._OverallTestStatus = true;
      this._RetestForVentDP = false;
      this.PrinterInfo = new PST.PrinterInformation();
      this.TestInfo = new PST.TestInformation();
      this.SpecsBlack = new Specifications(PST.Channel.Black);
      this.SpecsColor = new Specifications(PST.Channel.Color);
      this.KDataPoints = new PST.Points();
      this.CDataPoints = new PST.Points();
      this.KResults = new PST.Results();
      this.CResults = new PST.Results();
    }

    public PST(
      PST.TestStationTypes TestStationType,
      string Serial,
      string FW,
      long PgCnt,
      string ScriptRev,
      string ScriptProduct,
      string SaveFileLocation,
      double[] BlackArrayX,
      double[] BlackArrayY,
      double[] ColorArrayX,
      double[] ColorArrayY)
      : this(TestStationType, Serial, FW, PgCnt, ScriptRev, ScriptProduct, Strings.FormatDateTime(DateAndTime.Now, DateFormat.ShortDate), Strings.FormatDateTime(DateAndTime.Now, DateFormat.LongTime), SaveFileLocation, BlackArrayX, BlackArrayY, ColorArrayX, ColorArrayY, (string) null)
    {
    }

    public PST(
      PST.TestStationTypes TestStationType,
      string Serial,
      string FW,
      long PgCnt,
      string ScriptRev,
      string ScriptProduct,
      string TestDate,
      string TestTime,
      string SaveFileLocation,
      double[] BlackArrayX,
      double[] BlackArrayY,
      double[] ColorArrayX,
      double[] ColorArrayY,
      string TestID)
    {
      this._BlackPressureOverRide = 1.0;
      this._ColorPressureOverRide = 1.0;
      this._MechChecks = new List<PST.PrinterMechChecks>();
      this._TestStatus = true;
      this._OverallTestStatus = true;
      this._RetestForVentDP = false;
      this.PrinterInfo = new PST.PrinterInformation();
      this.TestInfo = new PST.TestInformation();
      this.SpecsBlack = new Specifications(PST.Channel.Black);
      this.SpecsColor = new Specifications(PST.Channel.Color);
      this.KDataPoints = new PST.Points();
      this.CDataPoints = new PST.Points();
      this.KResults = new PST.Results();
      this.CResults = new PST.Results();
      Logging.AddLogEntry((object) this, "New PST: PST Instantiated", EventLogEntryType.Information, 3);
      try
      {
        this._TestID = Operators.CompareString(TestID, (string) null, false) != 0 ? TestID : this.GetTestID();
        this.PrinterInfo.SerialNum = Serial;
        this.PrinterInfo.FWRev = FW;
        this.PrinterInfo.EnginePgCnt = PgCnt;
        Logging.AddLogEntry((object) this, "New PST: PrinterInfo Set", EventLogEntryType.Information, 4);
        this.TestInfo.ScriptRev = ScriptRev;
        this.TestInfo.ScriptProduct = ScriptProduct;
        this.TestInfo.TestDate = TestDate;
        this.TestInfo.TestTime = TestTime;
        this.TestInfo.UploadsEnabled = false;
        this.TestInfo.TestStationType = TestStationType;
        Logging.AddLogEntry((object) this, "New PST: TestInfo Set", EventLogEntryType.Information, 4);
        this.SaveFileLocation = SaveFileLocation;
        this.OutputFileName = SaveFileLocation;
        this.SummaryFileName = SaveFileLocation;
        this.SpecFileName = SaveFileLocation;
        Logging.AddLogEntry((object) this, "New PST: Output Files Set", EventLogEntryType.Information, 4);
        this.PTraceBlack = this.ProcessTraceData(BlackArrayX, BlackArrayY);
        Logging.AddLogEntry((object) this, "New PST: ProcessTraceData Black Complete", EventLogEntryType.Information, 4);
        this.PTraceColor = this.ProcessTraceData(ColorArrayX, ColorArrayY);
        Logging.AddLogEntry((object) this, "New PST: ProcessTraceData Color Complete", EventLogEntryType.Information, 4);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Logging.AddLogEntry((object) this, "New: Error instantiating PST class: " + exception.ToString(), EventLogEntryType.Error, 0);
        int num = (int) Interaction.MsgBox((object) ("Error instantiating PST class.\r\n\r\n" + exception.ToString()));
        ProjectData.ClearProjectError();
      }
    }

    public void ShowResults()
    {
      Logging.AddLogEntry((object) this, "ShowResults: Starting", EventLogEntryType.Information, 3);
      dlgPSTResults dlgPstResults = new dlgPSTResults(this);
      IntPtr owner = PST.getOwner();
      if (owner != (IntPtr) -1)
      {
        int num1 = (int) dlgPstResults.ShowDialog((IWin32Window) new WindowWrapper(owner));
      }
      else
      {
        int num2 = (int) dlgPstResults.ShowDialog();
      }
      Logging.AddLogEntry((object) this, "ShowResults: Complete", EventLogEntryType.Information, 3);
    }

    public static IntPtr getOwner()
    {
      IntPtr owner;
      try
      {
        Process[] processesByName = Process.GetProcessesByName("FlexScript");
        owner = processesByName.Length == 0 ? (IntPtr) -1 : processesByName[0].MainWindowHandle;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        owner = (IntPtr) -1;
        ProjectData.ClearProjectError();
      }
      return owner;
    }

    private string GetTestID() => Conversions.ToString(DateAndTime.Now.Ticks) + "a";

    public List<TraceData> ProcessTraceData(double[] arrX, double[] arrY)
    {
      if (arrX.Length < 2 | arrY.Length < 2)
        throw new ApplicationException("Data set is empty, cannot continue.");
      try
      {
        double[] numArray1 = new double[checked (Information.UBound((Array) arrX) - 2 + 1)];
        int num1 = checked (Information.UBound((Array) arrX) - 1);
        int index1 = 1;
        while (index1 <= num1)
        {
          double[] numArray2 = new double[3]
          {
            arrY[checked (index1 - 1)],
            arrY[index1],
            arrY[checked (index1 + 1)]
          };
          numArray1[checked (index1 - 1)] = (numArray2[0] + numArray2[1] + numArray2[2]) / 3.0;
          checked { ++index1; }
        }
        double[] numArray3 = new double[checked (Information.UBound((Array) numArray1) - 2 + 1)];
        int num2 = checked (Information.UBound((Array) numArray1) - 1);
        int index2 = 1;
        while (index2 <= num2)
        {
          numArray3[checked (index2 - 1)] = (numArray1[checked (index2 + 1)] - numArray1[checked (index2 - 1)]) / (2.0 * (arrX[checked (index2 + 1)] - arrX[index2]));
          checked { ++index2; }
        }
        double[] numArray4 = new double[checked (Information.UBound((Array) numArray3) - 2 + 1)];
        int num3 = checked (Information.UBound((Array) numArray3) - 1);
        int index3 = 1;
        while (index3 <= num3)
        {
          numArray4[checked (index3 - 1)] = (numArray3[checked (index3 + 1)] - numArray3[checked (index3 - 1)]) / (2.0 * (arrX[checked (index3 + 1)] - arrX[index3]));
          checked { ++index3; }
        }
        List<TraceData> traceDataList = new List<TraceData>();
        int num4 = Information.UBound((Array) arrX);
        int index4 = 0;
        while (index4 <= num4)
        {
          TraceData traceData = new TraceData();
          traceData.X = arrX[index4];
          traceData.Y = arrY[index4];
          if (index4 >= 1 & index4 <= Information.UBound((Array) numArray1))
            traceData.SlidingAVG = numArray1[checked (index4 - 1)];
          if (index4 >= 2 & index4 <= Information.UBound((Array) numArray3))
            traceData.DxDt = numArray3[checked (index4 - 2)];
          if (index4 >= 3 & index4 <= Information.UBound((Array) numArray4))
            traceData.DxDt2 = numArray4[checked (index4 - 3)];
          traceDataList.Add(traceData);
          checked { ++index4; }
        }
        double[,] numArray5 = new double[checked (arrY.Length + 1), 5];
        return traceDataList;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Logging.AddLogEntry((object) this, "ProcessTraceData: Error: " + exception.ToString(), EventLogEntryType.Error, 0);
        throw new Exception(exception.Message, exception.InnerException);
      }
    }

    public void AnalyzeResults(double BlackInstallPressure, double ColorInstallPressure) => this.AnalyzeResults(BlackInstallPressure, ColorInstallPressure, true);

    public void AnalyzeResults(
      double BlackInstallPressure,
      double ColorInstallPressure,
      bool LogResults)
    {
      try
      {
        this._BlackInstallPressure = BlackInstallPressure;
        this._ColorInstallPressure = ColorInstallPressure;
        this.KDataPoints.SetCriticalPoints(this.PTraceBlack, this.SpecsBlack);
        this.CDataPoints.SetCriticalPoints(this.PTraceColor, this.SpecsColor);
        PST.Results kresults = this.KResults;
        PST.Points kdataPoints = this.KDataPoints;
        Specifications specsBlack = this.SpecsBlack;
        ref Specifications local1 = ref specsBlack;
        double blackInstallPressure = this._BlackInstallPressure;
        kresults.AnalyzeResults(kdataPoints, ref local1, blackInstallPressure);
        this.SpecsBlack = specsBlack;
        PST.Results cresults = this.CResults;
        PST.Points cdataPoints = this.CDataPoints;
        Specifications specsColor = this.SpecsColor;
        ref Specifications local2 = ref specsColor;
        double colorInstallPressure = this._ColorInstallPressure;
        cresults.AnalyzeResults(cdataPoints, ref local2, colorInstallPressure);
        this.SpecsColor = specsColor;
        bool flag = true;
        try
        {
          foreach (PST.PrinterMechChecks mechCheck in this.MechChecks)
          {
            if (!mechCheck.Results & mechCheck.SpecFunction == PST.SpecFunction.PassFail)
            {
              flag = false;
              break;
            }
          }
        }
        finally
        {
          List<PST.PrinterMechChecks>.Enumerator enumerator;
          enumerator.Dispose();
        }
        if (!flag)
        {
          this.KResults.VentDP_RetestRequired = false;
          this.CResults.VentDP_RetestRequired = false;
          this.KResults.TubeEvacDP_RetestRequired = false;
          this.CResults.TubeEvacDP_RetestRequired = false;
        }
        if (!flag | !this.KResults.PF.OverallPSTResults | !this.CResults.PF.OverallPSTResults)
          this._OverallTestStatus = false;
        if (LogResults)
        {
          bool AddFailuretoFailSummary = false;
          if (!this.KResults.PF.OverallPSTResults | !this.CResults.PF.OverallPSTResults)
            AddFailuretoFailSummary = true;
          this.TestInfo.RunNumber = new DataLogger.PSTLog(this, this.OutputFileName, this.SummaryFileName, this.SpecFileName, AddFailuretoFailSummary).RunNumber;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Logging.AddLogEntry((object) this, "AnalyzeResults: Error: " + exception.ToString(), EventLogEntryType.Error, 0);
        int num = (int) Interaction.MsgBox((object) ("Error Analyzing Results.\r\n\r\n" + exception.ToString()));
        ProjectData.ClearProjectError();
      }
      if (this.TestInfo.UploadsEnabled)
      {
        FileUpload fileUpload = new FileUpload(Path.GetDirectoryName(this.OutputFileName), this.TestInfo.UploadInterval);
      }
      else
        Logging.AddLogEntry((object) this, "AnalyzeResults: uploads are disabled", EventLogEntryType.Information, 3);
    }

    internal void SavePointData(PST.Channel Channel)
    {
      string TextToWrite1 = "TestID,PrinterSerialNum,Date,Time,OverAllTestStatus,PT1X,PT1Y,PT2X,PT2Y,PT3X,PT3Y,PT4X,PT4Y,PT5X,PT5Y,PT6X,PT6Y,PT7X,PT7Y,PT8X,PT8Y,DERIVCNT,HoldTime,PumpTime,PressureBuildDelay\r\n";
      string TextToWrite2 = this.TestID.ToString() + "," + this.PrinterInfo.SerialNum + "," + this.TestInfo.TestDate + "," + this.TestInfo.TestTime + "," + Conversions.ToString(this.OverallTestStatus) + ",";
      string path2 = (string) null;
      switch (Channel)
      {
        case PST.Channel.Black:
          TextToWrite2 = TextToWrite2 + this.KDataPoints.PT1X.ToString() + "," + this.KDataPoints.PT1Y.ToString() + "," + this.KDataPoints.PT2X.ToString() + "," + this.KDataPoints.PT2Y.ToString() + "," + this.KDataPoints.PT3X.ToString() + "," + this.KDataPoints.PT3Y.ToString() + "," + this.KDataPoints.PT4X.ToString() + "," + this.KDataPoints.PT4Y.ToString() + "," + this.KDataPoints.PT5X.ToString() + "," + this.KDataPoints.PT5Y.ToString() + "," + this.KDataPoints.PT6X.ToString() + "," + this.KDataPoints.PT6Y.ToString() + "," + this.KDataPoints.PT7X.ToString() + "," + this.KDataPoints.PT7Y.ToString() + "," + this.KDataPoints.PT8X.ToString() + "," + this.KDataPoints.PT8Y.ToString() + "," + Conversions.ToString(this.KDataPoints.DerivCnt) + "," + this.SpecsBlack.HoldTime.ToString() + "," + this.SpecsBlack.PumpTime.ToString() + "," + Conversions.ToString(this.KDataPoints.PT3X - this.KDataPoints.PT1X - (double) this.SpecsBlack.HoldTime - this.SpecsBlack.PumpTime) + "\r\n";
          path2 = "KDataPoints.csv";
          break;
        case PST.Channel.Color:
          TextToWrite2 = TextToWrite2 + this.CDataPoints.PT1X.ToString() + "," + this.CDataPoints.PT1Y.ToString() + "," + this.CDataPoints.PT2X.ToString() + "," + this.CDataPoints.PT2Y.ToString() + "," + this.CDataPoints.PT3X.ToString() + "," + this.CDataPoints.PT3Y.ToString() + "," + this.CDataPoints.PT4X.ToString() + "," + this.CDataPoints.PT4Y.ToString() + "," + this.CDataPoints.PT5X.ToString() + "," + this.CDataPoints.PT5Y.ToString() + "," + this.CDataPoints.PT6X.ToString() + "," + this.CDataPoints.PT6Y.ToString() + "," + this.CDataPoints.PT7X.ToString() + "," + this.CDataPoints.PT7Y.ToString() + "," + this.CDataPoints.PT8X.ToString() + "," + this.CDataPoints.PT8Y.ToString() + "," + Conversions.ToString(this.CDataPoints.DerivCnt) + "," + this.SpecsColor.HoldTime.ToString() + "," + this.SpecsColor.PumpTime.ToString() + "," + Conversions.ToString(this.CDataPoints.PT3X - this.CDataPoints.PT1X - (double) this.SpecsColor.HoldTime - this.SpecsColor.PumpTime) + "\r\n";
          path2 = "CDataPoints.csv";
          break;
      }
      string str = Path.Combine(this.SaveFileLocation, path2);
      if (!MyProject.Computer.FileSystem.FileExists(str))
        FileProcessing.WriteToFile(str, TextToWrite1, true);
      FileProcessing.WriteToFile(str, TextToWrite2, true);
    }

    public enum SpecType
    {
      LessThan,
      GreaterThan,
      Between,
    }

    public enum SpecFunction
    {
      PassFail,
      Monitor,
    }

    public enum Channel
    {
      Unknown,
      Black,
      Color,
    }

    public enum TestSites
    {
      HP,
      NKG_China,
      NKG_Thailand,
      DEBUG,
    }

    public enum TestStationTypes
    {
      ProductionLine,
      Rework,
      CSA,
      PPP,
      RnD,
    }

    public class PrinterInformation
    {
      [DebuggerNonUserCode]
      public PrinterInformation()
      {
      }

      private string _SerialNum { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private string _FWRev { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private long _EnginePgCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string SerialNum
      {
        get => this._SerialNum;
        set => this._SerialNum = value;
      }

      public string FWRev
      {
        get => this._FWRev;
        set => this._FWRev = value;
      }

      public long EnginePgCnt
      {
        get => this._EnginePgCnt;
        set => this._EnginePgCnt = value;
      }
    }

    public class TestInformation
    {
      private string _ScriptRev;
      private string _ScriptProduct;
      private string _TestDate;
      private string _TestTime;
      private PST.TestSites _TestSite;
      private int _UploadInterval;
      private bool _UploadsEnabled;
      private int _RunNumber;
      private PST.TestStationTypes _TestStationType;

      public TestInformation()
      {
        this._UploadInterval = 2;
        this._UploadsEnabled = true;
      }

      public string ScriptRev
      {
        get => this._ScriptRev;
        set => this._ScriptRev = value;
      }

      public string ScriptProduct
      {
        get => this._ScriptProduct;
        set => this._ScriptProduct = value;
      }

      public static string FuelRev => Assembly.GetExecutingAssembly().GetName().Version.ToString();

      public string TestDate
      {
        get => this._TestDate;
        set => this._TestDate = value;
      }

      public string TestTime
      {
        get => this._TestTime;
        set => this._TestTime = value;
      }

      public PST.TestSites TestSite
      {
        get => this._TestSite;
        set => this._TestSite = value;
      }

      public int UploadInterval
      {
        get => this._UploadInterval;
        set => this._UploadInterval = value;
      }

      public bool UploadsEnabled
      {
        get => this._UploadsEnabled;
        set => this._UploadsEnabled = value;
      }

      public int RunNumber
      {
        get => this._RunNumber;
        set => this._RunNumber = value;
      }

      public PST.TestStationTypes TestStationType
      {
        get => this._TestStationType;
        set => this._TestStationType = value;
      }
    }

    public class Results_PF
    {
      public Results_PF() => this._OverallPSTResults = true;

      private bool _MaxPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _Leak { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _VentDeltaPMin { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _DerivCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _DryPHA { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _OverallPSTResults { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _TubeEvacDeltaPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool MaxPressure
      {
        get => this._MaxPressure;
        internal set => this._MaxPressure = value;
      }

      public bool Leak
      {
        get => this._Leak;
        internal set => this._Leak = value;
      }

      public bool DerivCnt
      {
        get => this._DerivCnt;
        internal set => this._DerivCnt = value;
      }

      public bool DryPHA
      {
        get => this._DryPHA;
        internal set => this._DryPHA = value;
      }

      public bool OverallPSTResults
      {
        get => this._OverallPSTResults;
        internal set => this._OverallPSTResults = value;
      }

      public bool TubeEvacDeltaPressure
      {
        get => this._TubeEvacDeltaPressure;
        internal set => this._TubeEvacDeltaPressure = value;
      }

      public int VentDeltaPMin
      {
        get => this._VentDeltaPMin;
        internal set => this._VentDeltaPMin = value;
      }
    }

    public class Results_Val
    {
      [DebuggerNonUserCode]
      public Results_Val()
      {
      }

      private double _MaxPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _Leak { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _VentDeltaP { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _DerivCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _TubeEvacDeltaPressure { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public double MaxPressure
      {
        get => this._MaxPressure;
        internal set => this._MaxPressure = value;
      }

      public double Leak
      {
        get => this._Leak;
        internal set => this._Leak = value;
      }

      public double VentDeltaP
      {
        get => this._VentDeltaP;
        internal set => this._VentDeltaP = value;
      }

      public int DerivCnt
      {
        get => this._DerivCnt;
        internal set => this._DerivCnt = value;
      }

      public double TubeEvacDeltaPressure
      {
        get => this._TubeEvacDeltaPressure;
        internal set => this._TubeEvacDeltaPressure = value;
      }
    }

    public class Results
    {
      private int _InstallPressureThreshold { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _VentDP_RetestRequired { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool VentDP_RetestRequired
      {
        get => this._VentDP_RetestRequired;
        internal set => this._VentDP_RetestRequired = value;
      }

      private bool _TubeEvacDP_RetestRequired { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public bool TubeEvacDP_RetestRequired
      {
        get => this._TubeEvacDP_RetestRequired;
        internal set => this._TubeEvacDP_RetestRequired = value;
      }

      public PST.Results_PF PF { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public PST.Results_Val Val { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public Results()
      {
        this._InstallPressureThreshold = -5;
        this.PF = new PST.Results_PF();
        this.Val = new PST.Results_Val();
      }

      private double DetermineSpecOverRide(double InstallPressure, Specifications specs) => specs.AllowWetPHA && !this.PF.DryPHA ? 1.0 : 1.0;

      private bool DetermineDryPHA(
        double InstallPressure,
        PST.Points myPoints,
        Specifications Specs)
      {
        return InstallPressure > (double) this._InstallPressureThreshold && myPoints.PT2Y - myPoints.PT3Y >= (double) checked (Specs.LeakMin - 2) && !(myPoints.PT4Y > 5.0 & FUEL.FS.Math.IsCloseTo(myPoints.PT4Y, myPoints.PT5Y, myPoints.PT4Y * 0.2));
      }

      internal void AnalyzeResults(
        PST.Points myPoints,
        ref Specifications specs,
        double InstallPressure)
      {
        this.PF.DryPHA = this.DetermineDryPHA(InstallPressure, myPoints, specs);
        double specOverRide = this.DetermineSpecOverRide(InstallPressure, specs);
        if (specOverRide != 1.0)
        {
          specs.PressureMin = checked ((int) System.Math.Round(unchecked ((double) specs.PressureMin * specOverRide)));
          specs.VentTime /= specOverRide;
          specs.LeakMin = -20;
        }
        double num1 = myPoints.PT2Y;
        if (specs.AllowWetPHA & myPoints.PT2Y <= myPoints.PT6Y)
          num1 = myPoints.PT6Y;
        this.Val.MaxPressure = num1;
        if (num1 >= (double) specs.PressureMin & num1 <= (double) specs.PressureMax)
        {
          this.PF.MaxPressure = true;
        }
        else
        {
          this.PF.MaxPressure = false;
          this.PF.OverallPSTResults = false;
        }
        double num2 = myPoints.PT2Y;
        double num3 = myPoints.PT3Y;
        specs.SetMaxLeakVal(myPoints.PT2X, myPoints.PT3X);
        if (specs.AllowWetPHA)
        {
          num2 = myPoints.PT6Y;
          num3 = myPoints.PT7Y;
          specs.SetMaxLeakVal(myPoints.PT6X, myPoints.PT7X);
        }
        if (num2 != 0.0 & num3 != 0.0)
        {
          double num4 = num2 - num3;
          this.Val.Leak = num4;
          if (num4 <= (double) specs.LeakMax & num4 >= (double) specs.LeakMin)
          {
            this.PF.Leak = true;
          }
          else
          {
            this.PF.Leak = false;
            this.PF.OverallPSTResults = false;
          }
        }
        else
        {
          this.PF.Leak = false;
          this.PF.OverallPSTResults = false;
        }
        this.Val.TubeEvacDeltaPressure = myPoints.PT5Y - myPoints.PT8Y;
        if (this.Val.TubeEvacDeltaPressure > (double) specs.TubeEvacDeltaPressure)
        {
          this.PF.TubeEvacDeltaPressure = false;
          if (this.PF.OverallPSTResults)
            this._TubeEvacDP_RetestRequired = true;
          this.PF.OverallPSTResults = false;
        }
        else
          this.PF.TubeEvacDeltaPressure = true;
        this.Val.DerivCnt = myPoints.DerivCnt;
        if (myPoints.DerivCnt <= specs.DerivCnt)
        {
          this.PF.DerivCnt = true;
        }
        else
        {
          this.PF.DerivCnt = false;
          this.PF.OverallPSTResults = false;
        }
        if (myPoints.PT4Y != 0.0 & myPoints.PT3Y != 0.0 & myPoints.PT4Y != myPoints.PT3Y)
        {
          double num5 = myPoints.PT3Y - myPoints.PT4Y;
          this.Val.VentDeltaP = num5;
          if (num5 >= specs.VentDeltaPMin)
            this.PF.VentDeltaPMin = 0;
          else if (myPoints.PT3DxDt2 < specs.VentDxDt2Threshold & num5 >= specs.VentDeltaPMin * 0.5 & specs.AllowWetPHA)
          {
            this.Val.VentDeltaP = myPoints.PT3DxDt2;
            this.PF.VentDeltaPMin = 1;
          }
          else
          {
            this.PF.VentDeltaPMin = -1;
            if (this.PF.OverallPSTResults)
              this._VentDP_RetestRequired = true;
            this.PF.OverallPSTResults = false;
          }
        }
        else
        {
          this.PF.VentDeltaPMin = -1;
          if (this.PF.OverallPSTResults)
            this._VentDP_RetestRequired = true;
          this.PF.OverallPSTResults = false;
        }
      }
    }

    public class Points
    {
      public Points()
      {
        this._PT2_DxDt_Sensitivity = 89;
        this._PT3_DxDt_Sensitivity = 300;
      }

      private double _PT1X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT1Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _PT1Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT2X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT2Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _PT2Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _PT2_DxDt_Sensitivity { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT3X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT3Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT3DxDt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT3DxDt2 { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT3Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _PT3_DxDt_Sensitivity { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT4X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT4Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT4Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT5X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT5Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT5Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT6X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT6Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT6Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT7X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT7Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT7Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT8X { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT8Y { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _PT8Index { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private int _DerivCnt { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _Flatness { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public int DerivCnt => this._DerivCnt;

      public double PT1X => this._PT1X;

      public double PT1Y => this._PT1Y;

      public object PT1Index => (object) this._PT1Index;

      public double PT2X => this._PT2X;

      public double PT2Y => this._PT2Y;

      public object PT2Index => (object) this._PT2Index;

      public double PT3X => this._PT3X;

      public double PT3Y => this._PT3Y;

      public double PT3DxDt => this._PT3DxDt;

      public double PT3DxDt2 => this._PT3DxDt2;

      public int PT3Index => checked ((int) System.Math.Round(this._PT3Index));

      public double PT4X => this._PT4X;

      public double PT4Y => this._PT4Y;

      public int PT4Index => checked ((int) System.Math.Round(this._PT4Index));

      public double PT5X => this._PT5X;

      public double PT5Y => this._PT5Y;

      public int PT5Index => checked ((int) System.Math.Round(this._PT5Index));

      public double PT6X => this._PT6X;

      public double PT6Y => this._PT6Y;

      public int PT6Index => checked ((int) System.Math.Round(this._PT6Index));

      public double PT7X => this._PT7X;

      public double PT7Y => this._PT7Y;

      public int PT7Index => checked ((int) System.Math.Round(this._PT7Index));

      public double PT8X => this._PT8X;

      public double PT8Y => this._PT8Y;

      public int PT8Index => checked ((int) System.Math.Round(this._PT8Index));

      public double Flatness => this._Flatness;

      public void SetCriticalPoints(List<TraceData> myList, Specifications Spec)
      {
        if (Spec.AllowWetPHA)
          this._PT3_DxDt_Sensitivity = 40;
        this.SetPT1(myList, 10);
        this.SetPT2(myList, Spec);
        this.SetPT3(myList, Spec);
        this.SetPT4(myList, 10, Spec.VentTime);
        this.SetPT5(myList, Spec.VentTime);
        if (Spec.AllowWetPHA)
          this.SetPT6(myList, Spec);
        if (Spec.AllowWetPHA)
          this.SetPT7(myList, Spec);
        this.SetPT8(myList);
        this.SetDerivCnt(myList);
        this.SetFlatness(myList);
        if (this._PT1X <= this._PT2X)
          return;
        this._PT1Index = this._PT2Index;
        this._PT1X = this._PT2X;
        this._PT1Y = this._PT2Y;
      }

      private void SetPT1(List<TraceData> mylist, int MinDxDt)
      {
        int index = 0;
        bool flag = false;
        while (index < mylist.Count & !flag)
        {
          if (mylist[index].DxDt >= (double) MinDxDt & mylist[index].X > 3.0)
          {
            this._PT1Y = mylist[index].Y;
            this._PT1X = mylist[index].X;
            this._PT1Index = index;
            flag = true;
          }
          checked { ++index; }
        }
        if (flag || MinDxDt <= 30)
          return;
        this.SetPT1(mylist, checked (MinDxDt - 2));
      }

      private void SetPT2(List<TraceData> myList, Specifications Specs)
      {
        double a = 0.0;
        double num1 = 0.0;
        double num2 = 0.0;
        int pt1Index = this._PT1Index;
        int num3 = checked (myList.Count - 1);
        int index1 = pt1Index;
        while (index1 <= num3)
        {
          if (myList[index1].X >= this._PT1X + Specs.PumpTime + (Specs.PressureBuildDelay[0] * this._PT1X + Specs.PressureBuildDelay[1]))
          {
            num1 = myList[index1].Y;
            num2 = myList[index1].X;
            a = (double) index1;
            break;
          }
          checked { ++index1; }
        }
        this._PT2X = num2;
        this._PT2Y = num1;
        this._PT2Index = checked ((int) System.Math.Round(a));
        Logging.AddLogEntry((object) this, "SetPT2: Based on time, Found it at: (" + Conversions.ToString(this._PT2X) + ", " + Conversions.ToString(this._PT2Y) + ")", EventLogEntryType.Information, 4);
        double num4 = 1.0;
        int integer = Conversions.ToInteger(this.PT1Index);
        int num5 = checked (myList.Count - 1);
        int index2 = integer;
        while (index2 <= num5)
        {
          if (myList[index2].X >= num2 & myList[index2].X <= num2 + num4 && myList[index2].DxDt2 < -250.0)
          {
            this._PT2Y = myList[index2].Y;
            this._PT2Index = index2;
            this._PT2X = myList[index2].X;
            Logging.AddLogEntry((object) this, "SetPT2: ReSet based on DxDt2 to: (" + Conversions.ToString(this._PT2X) + ", " + Conversions.ToString(this._PT2Y) + ")", EventLogEntryType.Information, 4);
            break;
          }
          checked { ++index2; }
        }
      }

      private void SetPT3(List<TraceData> myList, Specifications Specs)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = 0.0;
        double num5 = 0.0;
        int pt2Index = this._PT2Index;
        int num6 = checked (myList.Count - 1);
        int index1 = pt2Index;
        while (index1 <= num6)
        {
          if (myList[index1].X >= this._PT2X + (double) Specs.HoldTime)
          {
            num2 = myList[index1].Y;
            num3 = myList[index1].X;
            num4 = myList[index1].DxDt;
            num5 = myList[index1].DxDt2;
            num1 = (double) index1;
            break;
          }
          checked { ++index1; }
        }
        this._PT3X = num3;
        this._PT3Y = num2;
        this._PT3DxDt = num4;
        this._PT3DxDt2 = num5;
        this._PT3Index = num1;
        Logging.AddLogEntry((object) this, "SetPT3: Based on time, set to: (" + Conversions.ToString(this._PT3X) + ", " + Conversions.ToString(this._PT3Y) + ")", EventLogEntryType.Information, 4);
        double num7 = 0.5;
        double num8 = 1.5;
        double num9 = 0.0;
        int index2 = 0;
        int integer1 = Conversions.ToInteger(this.PT2Index);
        int num10 = checked (myList.Count - 1);
        int index3 = integer1;
        while (index3 <= num10)
        {
          if (myList[index3].X >= num3 - num8 & myList[index3].X <= num3 + num7 && myList[index3].DxDt2 < num9)
          {
            num9 = myList[index3].DxDt2;
            index2 = index3;
          }
          checked { ++index3; }
        }
        int num11 = -50;
        if (num9 < (double) num11)
        {
          this._PT3Y = myList[index2].Y;
          this._PT3Index = (double) index2;
          this._PT3X = myList[index2].X;
          this._PT3DxDt = myList[index2].DxDt;
          this._PT3DxDt2 = myList[index2].DxDt2;
          Logging.AddLogEntry((object) this, "SetPT3: Reset based on DxDt2<" + num11.ToString() + ": (" + Conversions.ToString(this._PT3X) + ", " + Conversions.ToString(this._PT3Y) + "), DxDt2=" + Conversions.ToString(this._PT3DxDt2), EventLogEntryType.Information, 4);
        }
        double num12 = Specs.VentTime - 0.5;
        double num13 = 0.0;
        int index4 = 0;
        bool flag1 = false;
        int integer2 = Conversions.ToInteger(this.PT2Index);
        int num14 = checked (myList.Count - 1);
        int index5 = integer2;
        while (index5 <= num14)
        {
          if (myList[index5].X >= num3 - num12 & myList[index5].X <= num3 + num12 && myList[index5].DxDt2 < -5000.0 & myList[index5].DxDt2 < this._PT3DxDt2)
          {
            num13 = myList[index5].DxDt2;
            index4 = index5;
            flag1 = true;
            break;
          }
          checked { ++index5; }
        }
        if (!flag1)
          return;
        this._PT3Y = myList[index4].Y;
        this._PT3Index = (double) index4;
        this._PT3X = myList[index4].X;
        this._PT3DxDt = myList[index4].DxDt;
        this._PT3DxDt2 = myList[index4].DxDt2;
        Logging.AddLogEntry((object) this, "SetPT3: Reseting Pt based on Extreme DxDt2 value: (" + Conversions.ToString(this._PT3X) + ", " + Conversions.ToString(this._PT3Y) + ", " + Conversions.ToString(num13) + ")", EventLogEntryType.Information, 4);
        double num15 = this._PT3X - (double) Specs.HoldTime;
        bool flag2 = false;
        int index6 = checked ((int) System.Math.Round(this._PT3Index));
        while (index6 > this._PT1Index & !flag2)
        {
          if (myList[index6].X <= num15)
          {
            flag2 = true;
            this._PT2X = myList[index6].X;
            this._PT2Y = myList[index6].Y;
            this._PT2Index = index6;
            Logging.AddLogEntry((object) this, "SetPT3: Reseting PT2 based on PT3 Extreme DxDt2 val: (" + Conversions.ToString(this._PT2X) + ", " + Conversions.ToString(this._PT2Y) + ")", EventLogEntryType.Information, 4);
            Interaction.Beep();
          }
          else
            checked { --index6; }
        }
      }

      private void SetPT4(List<TraceData> mylist, int ExpectedMin, double VentTime)
      {
        int pt3Index = this.PT3Index;
        bool flag = false;
        double num = 0.5;
        if (VentTime <= num)
          num = VentTime * 0.5;
        Logging.AddLogEntry((object) this, "SetPT4: looking for PT past PT3 with Y val < " + Conversions.ToString(ExpectedMin), EventLogEntryType.Information, 4);
        while (pt3Index < mylist.Count & !flag)
        {
          if (System.Math.Abs(mylist[pt3Index].Y) <= (double) ExpectedMin | mylist[pt3Index].X - this._PT3X >= VentTime - num)
          {
            Logging.AddLogEntry((object) this, "SetPT4: foundit", EventLogEntryType.Information, 4);
            this._PT4Y = mylist[pt3Index].Y;
            this._PT4X = mylist[pt3Index].X;
            this._PT4Index = (double) pt3Index;
            flag = true;
          }
          checked { ++pt3Index; }
        }
        if (flag)
          return;
        Logging.AddLogEntry((object) this, "SetPT4: Never found it. Repeating with ExpectedMin = " + Conversions.ToString(checked (ExpectedMin + 5)), EventLogEntryType.Information, 4);
        this.SetPT4(mylist, checked (ExpectedMin + 5), VentTime);
      }

      private void SetPT5(List<TraceData> mylist, double VentTime)
      {
        int pt4Index = this.PT4Index;
        bool flag = false;
        int num = 8;
        Logging.AddLogEntry((object) this, "SetPT5: looking for PT past PT4 + 2 seconds", EventLogEntryType.Information, 4);
        while (pt4Index < mylist.Count & !flag)
        {
          if (mylist[pt4Index].X >= this.PT3X + VentTime + (double) num)
          {
            Logging.AddLogEntry((object) this, "SetPT5: Found it at: " + Conversions.ToString(mylist[pt4Index].X), EventLogEntryType.Information, 4);
            flag = true;
            this._PT5Y = mylist[pt4Index].Y;
            this._PT5X = mylist[pt4Index].X;
            this._PT5Index = (double) pt4Index;
          }
          checked { ++pt4Index; }
        }
        if (flag)
          return;
        this._PT5Y = this._PT4Y;
        this._PT5X = this._PT4X;
        this._PT5Index = this._PT4Index;
        Logging.AddLogEntry((object) this, "SetPT5: Coulding find it, setting to = PT4: (" + Conversions.ToString(this._PT5X) + ", " + Conversions.ToString(this._PT5Y) + ")", EventLogEntryType.Information, 4);
      }

      private void SetPT6(List<TraceData> mylist, Specifications Specs)
      {
        Logging.AddLogEntry((object) this, "SetPT6: Looking for pt btween PT2 and PT3-HoldTime-Retard with a max val", EventLogEntryType.Information, 4);
        double num1 = (double) checked (Specs.HoldTime - Specs.WetPHAHoldTimeRetardVal);
        double num2 = 0.0;
        int integer = Conversions.ToInteger(this.PT2Index);
        int index = 0;
        while (mylist[integer].X <= this.PT3X - num1)
        {
          if (mylist[integer].Y > num2)
          {
            num2 = mylist[integer].Y;
            index = integer;
          }
          checked { ++integer; }
        }
        this._PT6Y = mylist[index].Y;
        this._PT6X = mylist[index].X;
        this._PT6Index = (double) index;
        Logging.AddLogEntry((object) this, "SetPT8: Found it at (" + Conversions.ToString(this._PT6X) + ", " + Conversions.ToString(this._PT6Y) + ")", EventLogEntryType.Information, 4);
      }

      private void SetPT7(List<TraceData> mylist, Specifications Specs)
      {
        Logging.AddLogEntry((object) this, "SetPT7: Looking for pt btween PT6 and PT3 with a min value", EventLogEntryType.Information, 4);
        double num = this.PT6Y;
        int pt6Index = this.PT6Index;
        int index = 0;
        while (mylist[pt6Index].X <= this.PT3X)
        {
          if (mylist[pt6Index].Y < num)
          {
            num = mylist[pt6Index].Y;
            index = pt6Index;
          }
          checked { ++pt6Index; }
        }
        if (mylist[index].X - this._PT6X < 1.0)
          index = checked ((int) System.Math.Round(this._PT3Index));
        this._PT7Y = mylist[index].Y;
        this._PT7X = mylist[index].X;
        this._PT7Index = (double) index;
        Logging.AddLogEntry((object) this, "SetPT8: Found it at (" + Conversions.ToString(this._PT7X) + ", " + Conversions.ToString(this._PT7Y) + ")", EventLogEntryType.Information, 4);
      }

      private void SetPT8(List<TraceData> myList)
      {
        Logging.AddLogEntry((object) this, "SetPT8: Looking for Min between PT4 and PT5", EventLogEntryType.Information, 4);
        double num = this.PT4Y;
        int pt4Index = this.PT4Index;
        int index = this.PT4Index;
        while (myList[pt4Index].X <= this.PT5X)
        {
          if (myList[pt4Index].Y < num)
          {
            num = myList[pt4Index].Y;
            index = pt4Index;
          }
          checked { ++pt4Index; }
        }
        this._PT8Index = (double) index;
        this._PT8X = myList[index].X;
        this._PT8Y = myList[index].Y;
        Logging.AddLogEntry((object) this, "SetPT8: Found it at (" + Conversions.ToString(this._PT8X) + ", " + Conversions.ToString(this._PT8Y) + ")", EventLogEntryType.Information, 4);
      }

      private void SetDerivCnt(List<TraceData> mylist)
      {
        int index1 = 0;
        List<double> doubleList = new List<double>();
        int num1 = 0;
        while (index1 < mylist.Count)
        {
          if (System.Math.Abs(mylist[index1].Y) >= 5.0)
          {
            if (doubleList.Count == 0)
            {
              doubleList.Add(mylist[index1].DxDt);
            }
            else
            {
              int num2 = checked (doubleList.Count - 1);
              int index2 = 0;
              while (index2 <= num2)
              {
                if (mylist[index1].DxDt > doubleList[index2] + (double) this._PT2_DxDt_Sensitivity / 1.3 | mylist[index1].DxDt < doubleList[index2] - (double) this._PT2_DxDt_Sensitivity / 1.3)
                  checked { ++num1; }
                checked { ++index2; }
              }
              if (num1 == doubleList.Count)
                doubleList.Add(mylist[index1].DxDt);
              num1 = 0;
            }
          }
          checked { ++index1; }
        }
        this._DerivCnt = doubleList.Count;
      }

      private void SetFlatness(List<TraceData> myList)
      {
        int pt2Index = this._PT2Index;
        double num1 = 1000.0;
        double num2 = 0.0;
        while ((double) pt2Index <= this._PT3Index)
        {
          if (myList[pt2Index].Y < num1)
            num1 = myList[pt2Index].Y;
          if (myList[pt2Index].Y > num2)
            num2 = myList[pt2Index].Y;
          checked { ++pt2Index; }
        }
        this._Flatness = System.Math.Abs(num2 - num1);
      }
    }

    public class PrinterMechChecks
    {
      [DebuggerNonUserCode]
      public PrinterMechChecks()
      {
      }

      private string _Name { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private PST.SpecType _SpecType { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _SpecLow { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _SpecHigh { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private double _Value { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private bool _Results { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      private PST.SpecFunction _SpecFunction { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

      public string Name
      {
        get => this._Name;
        set => this._Name = value;
      }

      public PST.SpecType SpecType
      {
        get => this._SpecType;
        set => this._SpecType = value;
      }

      public double SpecLow
      {
        get => this._SpecLow;
        set => this._SpecLow = value;
      }

      public double SpecHigh
      {
        get => this._SpecHigh;
        set => this._SpecHigh = value;
      }

      public double Value => this._Value;

      public bool Results
      {
        get => this._Results;
        set => this._Results = value;
      }

      public PST.SpecFunction SpecFunction
      {
        get => this._SpecFunction;
        set => this._SpecFunction = value;
      }

      public void AddMechCheck(
        string Name,
        PST.SpecType SpecType,
        double Spec,
        double Value,
        PST.SpecFunction SpecFunction)
      {
        try
        {
          this._Name = Name;
          this._SpecType = SpecType;
          this._SpecLow = Spec;
          this._Value = Value;
          this._SpecFunction = SpecFunction;
          if (SpecType == PST.SpecType.GreaterThan)
          {
            if (Value >= Spec)
              this._Results = true;
            else
              this._Results = false;
          }
          else
          {
            if (SpecType != PST.SpecType.LessThan)
              throw new ApplicationException("SpecType not supported. Try the overloaded method.");
            if (Value <= Spec)
              this._Results = true;
            else
              this._Results = false;
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Logging.AddLogEntry((object) this, "AddMechCheck: Error: " + exception.ToString(), EventLogEntryType.Error, 0);
          int num = (int) Interaction.MsgBox((object) exception.ToString());
          ProjectData.ClearProjectError();
        }
      }

      public void AddMechCheck(
        string Name,
        PST.SpecType SpecType,
        double SpecLow,
        double SpecHigh,
        double Value,
        PST.SpecFunction SpecFunction)
      {
        try
        {
          this._Name = Name;
          this._SpecType = SpecType;
          this._SpecLow = SpecLow;
          this._SpecHigh = SpecHigh;
          this._Value = Value;
          this._SpecFunction = SpecFunction;
          if (SpecType != PST.SpecType.Between)
            throw new ApplicationException("SpecType not supported. Try the overloaded method.");
          if (Value >= SpecLow & Value <= SpecHigh)
            this._Results = true;
          else
            this._Results = false;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Logging.AddLogEntry((object) this, "AddMechCheck: Error: " + exception.ToString(), EventLogEntryType.Error, 0);
          int num = (int) Interaction.MsgBox((object) exception.ToString());
          ProjectData.ClearProjectError();
        }
      }
    }
  }
}
