// Decompiled with JetBrains decompiler
// Type: FUEL.ChartUtilities
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace FUEL
{
  public class ChartUtilities
  {
    [DebuggerNonUserCode]
    public ChartUtilities()
    {
    }

    public static void AddChartTitle(
      string TitleText,
      Chart myChart,
      string ChartArea,
      Docking DockingLoc)
    {
      Title title = new Title();
      title.Name = TitleText;
      title.Text = TitleText;
      title.Docking = DockingLoc;
      title.IsDockedInsideChartArea = false;
      title.Font = new Font("Ariel", 10f, FontStyle.Bold);
      myChart.Titles.Add(title);
      myChart.Titles[TitleText].DockedToChartArea = ChartArea;
    }

    public static double GetMinorGridInterval(double Divisor, int MajorVal)
    {
      if ((double) MajorVal <= Divisor)
        Divisor = (double) checked (MajorVal - 1);
      int num1 = checked ((int) Math.Round(Divisor));
      int num2 = 0;
      while (num2 <= num1)
      {
        if ((double) MajorVal % (Divisor - (double) num2) == 0.0 & (double) MajorVal != Divisor - (double) num2)
          return Math.Max(Divisor - (double) num2, 0.0);
        checked { ++num2; }
      }
      return Math.Max(Divisor, 0.0);
    }

    public static void AddAnnotations(string msg, Chart myChart, int Index)
    {
      CalloutAnnotation calloutAnnotation = new CalloutAnnotation();
      calloutAnnotation.AnchorDataPoint = myChart.Series[0].Points[Index];
      calloutAnnotation.Text = msg;
      calloutAnnotation.BackColor = Color.LightGoldenrodYellow;
      calloutAnnotation.ClipToChartArea = "Default";
      calloutAnnotation.AllowMoving = true;
      calloutAnnotation.AllowAnchorMoving = false;
      calloutAnnotation.AllowSelecting = true;
      calloutAnnotation.SmartLabelStyle.Enabled = true;
      calloutAnnotation.Name = msg;
      calloutAnnotation.Visible = true;
      calloutAnnotation.CalloutStyle = CalloutStyle.RoundedRectangle;
      myChart.Annotations.Add((Annotation) calloutAnnotation);
    }

    public static StripLine GetStripLine(
      string Text,
      TextOrientation TextOrientation,
      StringAlignment TextAlignment,
      StringAlignment TextLineAlignment,
      Color FontColor,
      double IntervalOffset,
      double StripWidth,
      Color BackColor)
    {
      Color LineColor;
      return (StripLine) ChartUtilities.GetStripLine(Text, TextOrientation, TextAlignment, TextLineAlignment, FontColor, IntervalOffset, LineColor, 0, StripWidth, BackColor);
    }

    public static StripLine GetStripLine(
      string Text,
      TextOrientation TextOrientation,
      StringAlignment TextAlignment,
      StringAlignment TextLineAlignment,
      Color FontColor,
      double IntervalOffset,
      Color LineColor,
      int LineWeight)
    {
      Color BackColor;
      return (StripLine) ChartUtilities.GetStripLine(Text, TextOrientation, TextAlignment, TextLineAlignment, FontColor, IntervalOffset, LineColor, LineWeight, 0.0, BackColor);
    }

    public static object GetStripLine(
      string Text,
      TextOrientation TextOrientation,
      StringAlignment TextAlignment,
      StringAlignment TextLineAlignment,
      Color FontColor,
      double IntervalOffset,
      Color LineColor,
      int LineWeight,
      double StripWidth,
      Color BackColor)
    {
      StripLine stripLine1 = new StripLine();
      StripLine stripLine2 = stripLine1;
      if (Operators.CompareString(Text, (string) null, false) != 0)
      {
        stripLine2.Text = Text;
        stripLine2.TextOrientation = TextOrientation;
        stripLine2.TextAlignment = TextAlignment;
        stripLine2.TextLineAlignment = TextLineAlignment;
        stripLine2.ForeColor = FontColor;
        stripLine2.Font = new Font("ariel", 8f);
      }
      stripLine1.IntervalOffset = IntervalOffset;
      stripLine1.StripWidth = StripWidth;
      stripLine1.BackColor = BackColor;
      stripLine1.BorderColor = LineColor;
      stripLine1.BorderWidth = LineWeight;
      return (object) stripLine1;
    }

    public static void ClearChart(Chart Chart)
    {
      Chart chart = Chart;
      chart.Series.Clear();
      chart.Titles.Clear();
      int num = checked (Chart.ChartAreas.Count - 1);
      int index = 0;
      while (index <= num)
      {
        chart.ChartAreas[index].AxisX.Title = (string) null;
        chart.ChartAreas[index].AxisY.Title = (string) null;
        chart.ChartAreas[index].AxisY.StripLines.Clear();
        chart.ChartAreas[index].AxisX.StripLines.Clear();
        checked { ++index; }
      }
    }

    public static void AddSeriesDataLabels(Chart Chart, Series Series)
    {
      Chart.Series[Series.Name].IsValueShownAsLabel = true;
      Chart.Series[Series.Name].Font = new Font("ariel", 8f);
      Chart.Series[Series.Name].LabelAngle = 45;
      Chart.Series[Series.Name].LabelForeColor = Color.Black;
      Chart.Series[Series.Name].LabelFormat = ".##";
      Chart.Series[Series.Name].LabelBackColor = Color.LightGray;
      Chart.Series[Series.Name].SmartLabelStyle.Enabled = true;
      Chart.Series[Series.Name].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
      Chart.Series[Series.Name].SmartLabelStyle.IsOverlappedHidden = false;
    }

    public static void RemoveSeriesDataLabels(Chart Chart, Series Series)
    {
      Chart.Series[Series.Name].IsValueShownAsLabel = false;
      Chart.Series[Series.Name].SmartLabelStyle.Enabled = false;
    }

    public static void SetXAxisZoom(ChartArea Area, bool Enabled) => ChartUtilities.SetZoom(Area, Enabled, true);

    public static void SetYAxisZoom(ChartArea Area, bool Enabled) => ChartUtilities.SetZoom(Area, Enabled, false);

    private static void SetZoom(ChartArea Area, bool Enabled, bool XAxis)
    {
      if (XAxis)
      {
        Area.CursorX.IsUserEnabled = Enabled;
        Area.CursorX.IsUserSelectionEnabled = Enabled;
        Area.AxisX.ScaleView.Zoomable = Enabled;
        Area.AxisX.ScrollBar.IsPositionedInside = Enabled;
      }
      else
      {
        Area.CursorY.IsUserEnabled = Enabled;
        Area.CursorY.IsUserSelectionEnabled = Enabled;
        Area.AxisY.ScaleView.Zoomable = Enabled;
        Area.AxisY.ScrollBar.IsPositionedInside = Enabled;
      }
    }

    public static void LinkChartAreas(ChartArea Area1, ChartArea Area2)
    {
      Area1.InnerPlotPosition.Auto = true;
      Area2.InnerPlotPosition.Auto = true;
      Area2.AlignmentOrientation = AreaAlignmentOrientations.Vertical;
      Area2.AlignmentStyle = AreaAlignmentStyles.All;
      Area2.AlignWithChartArea = Area1.Name;
    }
  }
}
