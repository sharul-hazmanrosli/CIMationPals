// Decompiled with JetBrains decompiler
// Type: FUEL.ctrlMechChecks
// Assembly: FUEL, Version=2.4.8.0, Culture=neutral, PublicKeyToken=null
// MVID: A3D630D0-0620-425D-8CFB-B67B2AC75507
// Assembly location: C:\hp\FUEL\FUEL.dll

using DevComponents.Instrumentation;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FUEL
{
  [DesignerGenerated]
  public class ctrlMechChecks : UserControl
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("gagPos1")]
    private GaugeControl _gagPos1;
    private List<PST.PrinterMechChecks> _CheckList;

    [DebuggerNonUserCode]
    static ctrlMechChecks()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (ctrlMechChecks.__ENCList)
      {
        if (ctrlMechChecks.__ENCList.Count == ctrlMechChecks.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (ctrlMechChecks.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (ctrlMechChecks.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                ctrlMechChecks.__ENCList[index1] = ctrlMechChecks.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          ctrlMechChecks.__ENCList.RemoveRange(index1, checked (ctrlMechChecks.__ENCList.Count - index1));
          ctrlMechChecks.__ENCList.Capacity = ctrlMechChecks.__ENCList.Count;
        }
        ctrlMechChecks.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      GradientFillColor gradientFillColor1 = new GradientFillColor();
      GradientFillColor gradientFillColor2 = new GradientFillColor();
      StateIndicator stateIndicator1 = new StateIndicator();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ctrlMechChecks));
      StateIndicator stateIndicator2 = new StateIndicator();
      StateIndicator stateIndicator3 = new StateIndicator();
      StateIndicator stateIndicator4 = new StateIndicator();
      StateIndicator stateIndicator5 = new StateIndicator();
      StateIndicator stateIndicator6 = new StateIndicator();
      StateIndicator stateIndicator7 = new StateIndicator();
      StateIndicator stateIndicator8 = new StateIndicator();
      StateIndicator stateIndicator9 = new StateIndicator();
      StateIndicator stateIndicator10 = new StateIndicator();
      StateIndicator stateIndicator11 = new StateIndicator();
      StateIndicator stateIndicator12 = new StateIndicator();
      GaugeLinearScale gaugeLinearScale1 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel1 = new GaugeCustomLabel();
      GaugePointer gaugePointer1 = new GaugePointer();
      GaugeSection gaugeSection1 = new GaugeSection();
      GaugeSection gaugeSection2 = new GaugeSection();
      GaugeSection gaugeSection3 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale2 = new GaugeLinearScale();
      GaugePointer gaugePointer2 = new GaugePointer();
      GaugeSection gaugeSection4 = new GaugeSection();
      GaugeSection gaugeSection5 = new GaugeSection();
      GaugeSection gaugeSection6 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale3 = new GaugeLinearScale();
      GaugePointer gaugePointer3 = new GaugePointer();
      GaugeSection gaugeSection7 = new GaugeSection();
      GaugeSection gaugeSection8 = new GaugeSection();
      GaugeSection gaugeSection9 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale4 = new GaugeLinearScale();
      GaugePointer gaugePointer4 = new GaugePointer();
      GaugeSection gaugeSection10 = new GaugeSection();
      GaugeSection gaugeSection11 = new GaugeSection();
      GaugeSection gaugeSection12 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale5 = new GaugeLinearScale();
      GaugePointer gaugePointer5 = new GaugePointer();
      GaugeSection gaugeSection13 = new GaugeSection();
      GaugeSection gaugeSection14 = new GaugeSection();
      GaugeSection gaugeSection15 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale6 = new GaugeLinearScale();
      GaugePointer gaugePointer6 = new GaugePointer();
      GaugeSection gaugeSection16 = new GaugeSection();
      GaugeSection gaugeSection17 = new GaugeSection();
      GaugeSection gaugeSection18 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale7 = new GaugeLinearScale();
      GaugePointer gaugePointer7 = new GaugePointer();
      GaugeSection gaugeSection19 = new GaugeSection();
      GaugeSection gaugeSection20 = new GaugeSection();
      GaugeSection gaugeSection21 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale8 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel2 = new GaugeCustomLabel();
      GaugePointer gaugePointer8 = new GaugePointer();
      GaugeSection gaugeSection22 = new GaugeSection();
      GaugeSection gaugeSection23 = new GaugeSection();
      GaugeSection gaugeSection24 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale9 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel3 = new GaugeCustomLabel();
      GaugePointer gaugePointer9 = new GaugePointer();
      GaugeSection gaugeSection25 = new GaugeSection();
      GaugeSection gaugeSection26 = new GaugeSection();
      GaugeSection gaugeSection27 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale10 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel4 = new GaugeCustomLabel();
      GaugePointer gaugePointer10 = new GaugePointer();
      GaugeSection gaugeSection28 = new GaugeSection();
      GaugeSection gaugeSection29 = new GaugeSection();
      GaugeSection gaugeSection30 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale11 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel5 = new GaugeCustomLabel();
      GaugePointer gaugePointer11 = new GaugePointer();
      GaugeSection gaugeSection31 = new GaugeSection();
      GaugeSection gaugeSection32 = new GaugeSection();
      GaugeSection gaugeSection33 = new GaugeSection();
      GaugeLinearScale gaugeLinearScale12 = new GaugeLinearScale();
      GaugeCustomLabel gaugeCustomLabel6 = new GaugeCustomLabel();
      GaugePointer gaugePointer12 = new GaugePointer();
      GaugeSection gaugeSection34 = new GaugeSection();
      GaugeSection gaugeSection35 = new GaugeSection();
      GaugeSection gaugeSection36 = new GaugeSection();
      this.gagPos1 = new GaugeControl();
      this.gagPos1.BeginInit();
      this.SuspendLayout();
      this.gagPos1.BackColor = Color.White;
      this.gagPos1.ForeColor = Color.Black;
      gradientFillColor1.Color1 = Color.Gainsboro;
      gradientFillColor1.Color2 = Color.DarkGray;
      this.gagPos1.Frame.BackColor = gradientFillColor1;
      gradientFillColor2.BorderColor = Color.Gainsboro;
      gradientFillColor2.BorderWidth = 1;
      gradientFillColor2.Color1 = Color.White;
      gradientFillColor2.Color2 = Color.DimGray;
      this.gagPos1.Frame.FrameColor = gradientFillColor2;
      stateIndicator1.BackColor.BorderColor = Color.Black;
      stateIndicator1.BackColor.Color1 = Color.Red;
      stateIndicator1.BackColor.Color2 = Color.Maroon;
      stateIndicator1.EmptyString = "";
      stateIndicator1.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator13 = stateIndicator1;
      object obj1 = componentResourceManager.GetObject("StateIndicator1.Location");
      PointF pointF1;
      PointF pointF2 = obj1 != null ? (PointF) obj1 : pointF1;
      stateIndicator13.Location = pointF2;
      stateIndicator1.Name = "StateIndicator1";
      StateIndicator stateIndicator14 = stateIndicator1;
      SizeF sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF2 = sizeF1;
      stateIndicator14.Size = sizeF2;
      stateIndicator1.Text = "";
      stateIndicator1.TextColor = Color.White;
      stateIndicator1.UnderScale = false;
      stateIndicator1.Visible = false;
      stateIndicator2.BackColor.BorderColor = Color.Black;
      stateIndicator2.BackColor.Color1 = Color.Red;
      stateIndicator2.BackColor.Color2 = Color.Maroon;
      stateIndicator2.EmptyString = "";
      stateIndicator2.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator15 = stateIndicator2;
      object obj2 = componentResourceManager.GetObject("StateIndicator2.Location");
      PointF pointF3 = obj2 != null ? (PointF) obj2 : pointF1;
      stateIndicator15.Location = pointF3;
      stateIndicator2.Name = "StateIndicator2";
      StateIndicator stateIndicator16 = stateIndicator2;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF3 = sizeF1;
      stateIndicator16.Size = sizeF3;
      stateIndicator2.Text = "";
      stateIndicator2.TextColor = Color.White;
      stateIndicator2.UnderScale = false;
      stateIndicator2.Visible = false;
      stateIndicator3.BackColor.BorderColor = Color.Black;
      stateIndicator3.BackColor.Color1 = Color.Red;
      stateIndicator3.BackColor.Color2 = Color.Maroon;
      stateIndicator3.EmptyString = "";
      stateIndicator3.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator17 = stateIndicator3;
      object obj3 = componentResourceManager.GetObject("StateIndicator3.Location");
      PointF pointF4 = obj3 != null ? (PointF) obj3 : pointF1;
      stateIndicator17.Location = pointF4;
      stateIndicator3.Name = "StateIndicator3";
      StateIndicator stateIndicator18 = stateIndicator3;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF4 = sizeF1;
      stateIndicator18.Size = sizeF4;
      stateIndicator3.Text = "";
      stateIndicator3.TextColor = Color.White;
      stateIndicator3.UnderScale = false;
      stateIndicator3.Visible = false;
      stateIndicator4.BackColor.BorderColor = Color.Black;
      stateIndicator4.BackColor.Color1 = Color.Red;
      stateIndicator4.BackColor.Color2 = Color.Maroon;
      stateIndicator4.EmptyString = "";
      stateIndicator4.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator19 = stateIndicator4;
      object obj4 = componentResourceManager.GetObject("StateIndicator4.Location");
      PointF pointF5 = obj4 != null ? (PointF) obj4 : pointF1;
      stateIndicator19.Location = pointF5;
      stateIndicator4.Name = "StateIndicator4";
      StateIndicator stateIndicator20 = stateIndicator4;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF5 = sizeF1;
      stateIndicator20.Size = sizeF5;
      stateIndicator4.Text = "";
      stateIndicator4.TextColor = Color.White;
      stateIndicator4.UnderScale = false;
      stateIndicator4.Visible = false;
      stateIndicator5.BackColor.BorderColor = Color.Black;
      stateIndicator5.BackColor.Color1 = Color.Red;
      stateIndicator5.BackColor.Color2 = Color.Maroon;
      stateIndicator5.EmptyString = "";
      stateIndicator5.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator21 = stateIndicator5;
      object obj5 = componentResourceManager.GetObject("StateIndicator5.Location");
      PointF pointF6 = obj5 != null ? (PointF) obj5 : pointF1;
      stateIndicator21.Location = pointF6;
      stateIndicator5.Name = "StateIndicator5";
      StateIndicator stateIndicator22 = stateIndicator5;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF6 = sizeF1;
      stateIndicator22.Size = sizeF6;
      stateIndicator5.Text = "";
      stateIndicator5.TextColor = Color.White;
      stateIndicator5.UnderScale = false;
      stateIndicator5.Visible = false;
      stateIndicator6.BackColor.BorderColor = Color.Black;
      stateIndicator6.BackColor.Color1 = Color.Red;
      stateIndicator6.BackColor.Color2 = Color.Maroon;
      stateIndicator6.EmptyString = "";
      stateIndicator6.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator23 = stateIndicator6;
      object obj6 = componentResourceManager.GetObject("StateIndicator6.Location");
      PointF pointF7 = obj6 != null ? (PointF) obj6 : pointF1;
      stateIndicator23.Location = pointF7;
      stateIndicator6.Name = "StateIndicator6";
      StateIndicator stateIndicator24 = stateIndicator6;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF7 = sizeF1;
      stateIndicator24.Size = sizeF7;
      stateIndicator6.Text = "";
      stateIndicator6.TextColor = Color.White;
      stateIndicator6.UnderScale = false;
      stateIndicator6.Visible = false;
      stateIndicator7.BackColor.BorderColor = Color.Black;
      stateIndicator7.BackColor.Color1 = Color.Red;
      stateIndicator7.BackColor.Color2 = Color.Maroon;
      stateIndicator7.EmptyString = "";
      stateIndicator7.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator25 = stateIndicator7;
      object obj7 = componentResourceManager.GetObject("StateIndicator7.Location");
      PointF pointF8 = obj7 != null ? (PointF) obj7 : pointF1;
      stateIndicator25.Location = pointF8;
      stateIndicator7.Name = "StateIndicator7";
      StateIndicator stateIndicator26 = stateIndicator7;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF8 = sizeF1;
      stateIndicator26.Size = sizeF8;
      stateIndicator7.Text = "";
      stateIndicator7.TextColor = Color.White;
      stateIndicator7.UnderScale = false;
      stateIndicator7.Visible = false;
      stateIndicator8.BackColor.BorderColor = Color.Black;
      stateIndicator8.BackColor.Color1 = Color.Red;
      stateIndicator8.BackColor.Color2 = Color.Maroon;
      stateIndicator8.EmptyString = "";
      stateIndicator8.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator27 = stateIndicator8;
      object obj8 = componentResourceManager.GetObject("StateIndicator8.Location");
      PointF pointF9 = obj8 != null ? (PointF) obj8 : pointF1;
      stateIndicator27.Location = pointF9;
      stateIndicator8.Name = "StateIndicator8";
      StateIndicator stateIndicator28 = stateIndicator8;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF9 = sizeF1;
      stateIndicator28.Size = sizeF9;
      stateIndicator8.Text = "";
      stateIndicator8.TextColor = Color.White;
      stateIndicator8.UnderScale = false;
      stateIndicator8.Visible = false;
      stateIndicator9.BackColor.BorderColor = Color.Black;
      stateIndicator9.BackColor.Color1 = Color.Red;
      stateIndicator9.BackColor.Color2 = Color.Maroon;
      stateIndicator9.EmptyString = "";
      stateIndicator9.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator29 = stateIndicator9;
      object obj9 = componentResourceManager.GetObject("StateIndicator9.Location");
      PointF pointF10 = obj9 != null ? (PointF) obj9 : pointF1;
      stateIndicator29.Location = pointF10;
      stateIndicator9.Name = "StateIndicator9";
      StateIndicator stateIndicator30 = stateIndicator9;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF10 = sizeF1;
      stateIndicator30.Size = sizeF10;
      stateIndicator9.Text = "";
      stateIndicator9.TextColor = Color.White;
      stateIndicator9.UnderScale = false;
      stateIndicator9.Visible = false;
      stateIndicator10.BackColor.BorderColor = Color.Black;
      stateIndicator10.BackColor.Color1 = Color.Red;
      stateIndicator10.BackColor.Color2 = Color.Maroon;
      stateIndicator10.EmptyString = "";
      stateIndicator10.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator31 = stateIndicator10;
      object obj10 = componentResourceManager.GetObject("StateIndicator10.Location");
      PointF pointF11 = obj10 != null ? (PointF) obj10 : pointF1;
      stateIndicator31.Location = pointF11;
      stateIndicator10.Name = "StateIndicator10";
      StateIndicator stateIndicator32 = stateIndicator10;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF11 = sizeF1;
      stateIndicator32.Size = sizeF11;
      stateIndicator10.Text = "";
      stateIndicator10.TextColor = Color.White;
      stateIndicator10.UnderScale = false;
      stateIndicator10.Visible = false;
      stateIndicator11.BackColor.BorderColor = Color.Black;
      stateIndicator11.BackColor.Color1 = Color.Red;
      stateIndicator11.BackColor.Color2 = Color.Maroon;
      stateIndicator11.EmptyString = "";
      stateIndicator11.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator33 = stateIndicator11;
      object obj11 = componentResourceManager.GetObject("StateIndicator11.Location");
      PointF pointF12 = obj11 != null ? (PointF) obj11 : pointF1;
      stateIndicator33.Location = pointF12;
      stateIndicator11.Name = "StateIndicator11";
      StateIndicator stateIndicator34 = stateIndicator11;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF12 = sizeF1;
      stateIndicator34.Size = sizeF12;
      stateIndicator11.Text = "";
      stateIndicator11.TextColor = Color.White;
      stateIndicator11.UnderScale = false;
      stateIndicator11.Visible = false;
      stateIndicator12.BackColor.BorderColor = Color.Black;
      stateIndicator12.BackColor.Color1 = Color.Red;
      stateIndicator12.BackColor.Color2 = Color.Maroon;
      stateIndicator12.EmptyString = "";
      stateIndicator12.Image = (Image) FUEL.My.Resources.Resources.Error_icon_sm;
      StateIndicator stateIndicator35 = stateIndicator12;
      object obj12 = componentResourceManager.GetObject("StateIndicator12.Location");
      PointF pointF13 = obj12 != null ? (PointF) obj12 : pointF1;
      stateIndicator35.Location = pointF13;
      stateIndicator12.Name = "StateIndicator12";
      StateIndicator stateIndicator36 = stateIndicator12;
      sizeF1 = new SizeF(0.03f, 0.05f);
      SizeF sizeF13 = sizeF1;
      stateIndicator36.Size = sizeF13;
      stateIndicator12.Text = "";
      stateIndicator12.TextColor = Color.White;
      stateIndicator12.UnderScale = false;
      stateIndicator12.Visible = false;
      this.gagPos1.GaugeItems.AddRange(new GaugeItem[12]
      {
        (GaugeItem) stateIndicator1,
        (GaugeItem) stateIndicator2,
        (GaugeItem) stateIndicator3,
        (GaugeItem) stateIndicator4,
        (GaugeItem) stateIndicator5,
        (GaugeItem) stateIndicator6,
        (GaugeItem) stateIndicator7,
        (GaugeItem) stateIndicator8,
        (GaugeItem) stateIndicator9,
        (GaugeItem) stateIndicator10,
        (GaugeItem) stateIndicator11,
        (GaugeItem) stateIndicator12
      });
      this.gagPos1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      gaugeCustomLabel1.Layout.AdaptiveLabel = true;
      gaugeCustomLabel1.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel1.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel1.Name = "Label1fgfdg";
      gaugeCustomLabel1.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel1.Value = 1000.0;
      gaugeLinearScale1.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel1
      });
      GaugeLinearScale gaugeLinearScale13 = gaugeLinearScale1;
      object obj13 = componentResourceManager.GetObject("GaugeLinearScale1.Location");
      PointF pointF14 = obj13 != null ? (PointF) obj13 : pointF1;
      gaugeLinearScale13.Location = pointF14;
      gaugeLinearScale1.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale1.MaxPin.Name = "MaxPin";
      gaugeLinearScale1.MaxPin.Visible = false;
      gaugeLinearScale1.MaxValue = 1500.0;
      gaugeLinearScale1.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale1.MinPin.Name = "MinPin";
      gaugeLinearScale1.MinPin.Visible = false;
      gaugeLinearScale1.MinValue = 1000.0;
      gaugeLinearScale1.Name = "Scale1";
      gaugePointer1.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer1.CapFillColor.BorderWidth = 1;
      gaugePointer1.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer1.CapFillColor.Color2 = Color.DimGray;
      gaugePointer1.FillColor.BorderColor = Color.DimGray;
      gaugePointer1.FillColor.BorderWidth = 1;
      gaugePointer1.FillColor.Color1 = Color.Red;
      gaugePointer1.Name = "Pointer1";
      gaugePointer1.Placement = DisplayPlacement.Far;
      gaugePointer1.ScaleOffset = 0.05f;
      gaugePointer1.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer1.ThermoBackColor.BorderWidth = 1;
      gaugePointer1.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale1.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer1
      });
      gaugeSection1.FillColor.Color1 = Color.Crimson;
      gaugeSection1.Name = "Section1";
      gaugeSection2.EndValue = 1500.0;
      gaugeSection2.FillColor.Color1 = Color.Lime;
      gaugeSection2.Name = "Section2";
      gaugeSection2.StartValue = 1200.0;
      gaugeSection3.EndValue = 0.0;
      gaugeSection3.FillColor.Color1 = Color.Crimson;
      gaugeSection3.Name = "Section3";
      gaugeSection3.StartValue = 0.0;
      gaugeLinearScale1.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection1,
        gaugeSection2,
        gaugeSection3
      });
      GaugeLinearScale gaugeLinearScale14 = gaugeLinearScale1;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF14 = sizeF1;
      gaugeLinearScale14.Size = sizeF14;
      gaugeLinearScale1.Visible = false;
      gaugeLinearScale1.Width = 0.06f;
      GaugeLinearScale gaugeLinearScale15 = gaugeLinearScale2;
      object obj14 = componentResourceManager.GetObject("GaugeLinearScale2.Location");
      PointF pointF15 = obj14 != null ? (PointF) obj14 : pointF1;
      gaugeLinearScale15.Location = pointF15;
      gaugeLinearScale2.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale2.MaxPin.Name = "MaxPin";
      gaugeLinearScale2.MaxPin.Visible = false;
      gaugeLinearScale2.MaxValue = 1500.0;
      gaugeLinearScale2.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale2.MinPin.Name = "MinPin";
      gaugeLinearScale2.MinPin.Visible = false;
      gaugeLinearScale2.MinValue = 1000.0;
      gaugeLinearScale2.Name = "Scale2";
      gaugePointer2.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer2.CapFillColor.BorderWidth = 1;
      gaugePointer2.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer2.CapFillColor.Color2 = Color.DimGray;
      gaugePointer2.FillColor.BorderColor = Color.DimGray;
      gaugePointer2.FillColor.BorderWidth = 1;
      gaugePointer2.FillColor.Color1 = Color.Red;
      gaugePointer2.Name = "Pointer1";
      gaugePointer2.Placement = DisplayPlacement.Far;
      gaugePointer2.ScaleOffset = 0.05f;
      gaugePointer2.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer2.ThermoBackColor.BorderWidth = 1;
      gaugePointer2.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale2.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer2
      });
      gaugeSection4.FillColor.Color1 = Color.Crimson;
      gaugeSection4.Name = "Section1";
      gaugeSection5.EndValue = 1500.0;
      gaugeSection5.FillColor.Color1 = Color.Lime;
      gaugeSection5.Name = "Section2";
      gaugeSection5.StartValue = 1200.0;
      gaugeSection6.EndValue = 0.0;
      gaugeSection6.FillColor.Color1 = Color.Crimson;
      gaugeSection6.Name = "Section3";
      gaugeSection6.StartValue = 0.0;
      gaugeLinearScale2.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection4,
        gaugeSection5,
        gaugeSection6
      });
      GaugeLinearScale gaugeLinearScale16 = gaugeLinearScale2;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF15 = sizeF1;
      gaugeLinearScale16.Size = sizeF15;
      gaugeLinearScale2.Visible = false;
      GaugeLinearScale gaugeLinearScale17 = gaugeLinearScale3;
      object obj15 = componentResourceManager.GetObject("GaugeLinearScale3.Location");
      PointF pointF16 = obj15 != null ? (PointF) obj15 : pointF1;
      gaugeLinearScale17.Location = pointF16;
      gaugeLinearScale3.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale3.MaxPin.Name = "MaxPin";
      gaugeLinearScale3.MaxPin.Visible = false;
      gaugeLinearScale3.MaxValue = 1500.0;
      gaugeLinearScale3.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale3.MinPin.Name = "MinPin";
      gaugeLinearScale3.MinPin.Visible = false;
      gaugeLinearScale3.MinValue = 1000.0;
      gaugeLinearScale3.Name = "Scale3";
      gaugePointer3.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer3.CapFillColor.BorderWidth = 1;
      gaugePointer3.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer3.CapFillColor.Color2 = Color.DimGray;
      gaugePointer3.FillColor.BorderColor = Color.DimGray;
      gaugePointer3.FillColor.BorderWidth = 1;
      gaugePointer3.FillColor.Color1 = Color.Red;
      gaugePointer3.Name = "Pointer1";
      gaugePointer3.Placement = DisplayPlacement.Far;
      gaugePointer3.ScaleOffset = 0.05f;
      gaugePointer3.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer3.ThermoBackColor.BorderWidth = 1;
      gaugePointer3.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale3.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer3
      });
      gaugeSection7.FillColor.Color1 = Color.Crimson;
      gaugeSection7.Name = "Section1";
      gaugeSection8.EndValue = 1500.0;
      gaugeSection8.FillColor.Color1 = Color.Lime;
      gaugeSection8.Name = "Section2";
      gaugeSection8.StartValue = 1200.0;
      gaugeSection9.EndValue = 0.0;
      gaugeSection9.FillColor.Color1 = Color.Crimson;
      gaugeSection9.Name = "Section3";
      gaugeSection9.StartValue = 0.0;
      gaugeLinearScale3.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection7,
        gaugeSection8,
        gaugeSection9
      });
      GaugeLinearScale gaugeLinearScale18 = gaugeLinearScale3;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF16 = sizeF1;
      gaugeLinearScale18.Size = sizeF16;
      gaugeLinearScale3.Visible = false;
      GaugeLinearScale gaugeLinearScale19 = gaugeLinearScale4;
      object obj16 = componentResourceManager.GetObject("GaugeLinearScale4.Location");
      PointF pointF17 = obj16 != null ? (PointF) obj16 : pointF1;
      gaugeLinearScale19.Location = pointF17;
      gaugeLinearScale4.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale4.MaxPin.Name = "MaxPin";
      gaugeLinearScale4.MaxPin.Visible = false;
      gaugeLinearScale4.MaxValue = 1500.0;
      gaugeLinearScale4.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale4.MinPin.Name = "MinPin";
      gaugeLinearScale4.MinPin.Visible = false;
      gaugeLinearScale4.MinValue = 1000.0;
      gaugeLinearScale4.Name = "Scale4";
      gaugePointer4.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer4.CapFillColor.BorderWidth = 1;
      gaugePointer4.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer4.CapFillColor.Color2 = Color.DimGray;
      gaugePointer4.FillColor.BorderColor = Color.DimGray;
      gaugePointer4.FillColor.BorderWidth = 1;
      gaugePointer4.FillColor.Color1 = Color.Red;
      gaugePointer4.Name = "Pointer1";
      gaugePointer4.Placement = DisplayPlacement.Far;
      gaugePointer4.ScaleOffset = 0.05f;
      gaugePointer4.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer4.ThermoBackColor.BorderWidth = 1;
      gaugePointer4.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale4.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer4
      });
      gaugeSection10.FillColor.Color1 = Color.Crimson;
      gaugeSection10.Name = "Section1";
      gaugeSection11.EndValue = 1500.0;
      gaugeSection11.FillColor.Color1 = Color.Lime;
      gaugeSection11.Name = "Section2";
      gaugeSection11.StartValue = 1200.0;
      gaugeSection12.EndValue = 0.0;
      gaugeSection12.FillColor.Color1 = Color.Crimson;
      gaugeSection12.Name = "Section3";
      gaugeSection12.StartValue = 0.0;
      gaugeLinearScale4.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection10,
        gaugeSection11,
        gaugeSection12
      });
      GaugeLinearScale gaugeLinearScale20 = gaugeLinearScale4;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF17 = sizeF1;
      gaugeLinearScale20.Size = sizeF17;
      gaugeLinearScale4.Visible = false;
      GaugeLinearScale gaugeLinearScale21 = gaugeLinearScale5;
      object obj17 = componentResourceManager.GetObject("GaugeLinearScale5.Location");
      PointF pointF18 = obj17 != null ? (PointF) obj17 : pointF1;
      gaugeLinearScale21.Location = pointF18;
      gaugeLinearScale5.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale5.MaxPin.Name = "MaxPin";
      gaugeLinearScale5.MaxPin.Visible = false;
      gaugeLinearScale5.MaxValue = 1500.0;
      gaugeLinearScale5.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale5.MinPin.Name = "MinPin";
      gaugeLinearScale5.MinPin.Visible = false;
      gaugeLinearScale5.MinValue = 1000.0;
      gaugeLinearScale5.Name = "Scale5";
      gaugePointer5.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer5.CapFillColor.BorderWidth = 1;
      gaugePointer5.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer5.CapFillColor.Color2 = Color.DimGray;
      gaugePointer5.FillColor.BorderColor = Color.DimGray;
      gaugePointer5.FillColor.BorderWidth = 1;
      gaugePointer5.FillColor.Color1 = Color.Red;
      gaugePointer5.Name = "Pointer1";
      gaugePointer5.Placement = DisplayPlacement.Far;
      gaugePointer5.ScaleOffset = 0.05f;
      gaugePointer5.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer5.ThermoBackColor.BorderWidth = 1;
      gaugePointer5.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale5.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer5
      });
      gaugeSection13.FillColor.Color1 = Color.Crimson;
      gaugeSection13.Name = "Section1";
      gaugeSection14.EndValue = 1500.0;
      gaugeSection14.FillColor.Color1 = Color.Lime;
      gaugeSection14.Name = "Section2";
      gaugeSection14.StartValue = 1200.0;
      gaugeSection15.EndValue = 0.0;
      gaugeSection15.FillColor.Color1 = Color.Crimson;
      gaugeSection15.Name = "Section3";
      gaugeSection15.StartValue = 0.0;
      gaugeLinearScale5.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection13,
        gaugeSection14,
        gaugeSection15
      });
      GaugeLinearScale gaugeLinearScale22 = gaugeLinearScale5;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF18 = sizeF1;
      gaugeLinearScale22.Size = sizeF18;
      gaugeLinearScale5.Visible = false;
      GaugeLinearScale gaugeLinearScale23 = gaugeLinearScale6;
      object obj18 = componentResourceManager.GetObject("GaugeLinearScale6.Location");
      PointF pointF19 = obj18 != null ? (PointF) obj18 : pointF1;
      gaugeLinearScale23.Location = pointF19;
      gaugeLinearScale6.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale6.MaxPin.Name = "MaxPin";
      gaugeLinearScale6.MaxPin.Visible = false;
      gaugeLinearScale6.MaxValue = 1500.0;
      gaugeLinearScale6.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale6.MinPin.Name = "MinPin";
      gaugeLinearScale6.MinPin.Visible = false;
      gaugeLinearScale6.MinValue = 1000.0;
      gaugeLinearScale6.Name = "Scale6";
      gaugePointer6.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer6.CapFillColor.BorderWidth = 1;
      gaugePointer6.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer6.CapFillColor.Color2 = Color.DimGray;
      gaugePointer6.FillColor.BorderColor = Color.DimGray;
      gaugePointer6.FillColor.BorderWidth = 1;
      gaugePointer6.FillColor.Color1 = Color.Red;
      gaugePointer6.Name = "Pointer1";
      gaugePointer6.Placement = DisplayPlacement.Far;
      gaugePointer6.ScaleOffset = 0.05f;
      gaugePointer6.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer6.ThermoBackColor.BorderWidth = 1;
      gaugePointer6.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale6.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer6
      });
      gaugeSection16.FillColor.Color1 = Color.Crimson;
      gaugeSection16.Name = "Section1";
      gaugeSection17.EndValue = 1500.0;
      gaugeSection17.FillColor.Color1 = Color.Lime;
      gaugeSection17.Name = "Section2";
      gaugeSection17.StartValue = 1200.0;
      gaugeSection18.EndValue = 0.0;
      gaugeSection18.FillColor.Color1 = Color.Crimson;
      gaugeSection18.Name = "Section3";
      gaugeSection18.StartValue = 0.0;
      gaugeLinearScale6.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection16,
        gaugeSection17,
        gaugeSection18
      });
      GaugeLinearScale gaugeLinearScale24 = gaugeLinearScale6;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF19 = sizeF1;
      gaugeLinearScale24.Size = sizeF19;
      gaugeLinearScale6.Visible = false;
      GaugeLinearScale gaugeLinearScale25 = gaugeLinearScale7;
      object obj19 = componentResourceManager.GetObject("GaugeLinearScale7.Location");
      PointF pointF20 = obj19 != null ? (PointF) obj19 : pointF1;
      gaugeLinearScale25.Location = pointF20;
      gaugeLinearScale7.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale7.MaxPin.Name = "MaxPin";
      gaugeLinearScale7.MaxPin.Visible = false;
      gaugeLinearScale7.MaxValue = 1500.0;
      gaugeLinearScale7.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale7.MinPin.Name = "MinPin";
      gaugeLinearScale7.MinPin.Visible = false;
      gaugeLinearScale7.MinValue = 1000.0;
      gaugeLinearScale7.Name = "Scale7";
      gaugePointer7.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer7.CapFillColor.BorderWidth = 1;
      gaugePointer7.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer7.CapFillColor.Color2 = Color.DimGray;
      gaugePointer7.FillColor.BorderColor = Color.DimGray;
      gaugePointer7.FillColor.BorderWidth = 1;
      gaugePointer7.FillColor.Color1 = Color.Red;
      gaugePointer7.Name = "Pointer1";
      gaugePointer7.Placement = DisplayPlacement.Far;
      gaugePointer7.ScaleOffset = 0.05f;
      gaugePointer7.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer7.ThermoBackColor.BorderWidth = 1;
      gaugePointer7.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale7.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer7
      });
      gaugeSection19.FillColor.Color1 = Color.Crimson;
      gaugeSection19.Name = "Section1";
      gaugeSection20.EndValue = 1500.0;
      gaugeSection20.FillColor.Color1 = Color.Lime;
      gaugeSection20.Name = "Section2";
      gaugeSection20.StartValue = 1200.0;
      gaugeSection21.EndValue = 0.0;
      gaugeSection21.FillColor.Color1 = Color.Crimson;
      gaugeSection21.Name = "Section3";
      gaugeSection21.StartValue = 0.0;
      gaugeLinearScale7.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection19,
        gaugeSection20,
        gaugeSection21
      });
      GaugeLinearScale gaugeLinearScale26 = gaugeLinearScale7;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF20 = sizeF1;
      gaugeLinearScale26.Size = sizeF20;
      gaugeLinearScale7.Visible = false;
      gaugeCustomLabel2.Layout.AdaptiveLabel = true;
      gaugeCustomLabel2.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel2.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel2.Name = "Label1fgfdg";
      gaugeCustomLabel2.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel2.Value = 1000.0;
      gaugeLinearScale8.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel2
      });
      GaugeLinearScale gaugeLinearScale27 = gaugeLinearScale8;
      object obj20 = componentResourceManager.GetObject("GaugeLinearScale8.Location");
      PointF pointF21 = obj20 != null ? (PointF) obj20 : pointF1;
      gaugeLinearScale27.Location = pointF21;
      gaugeLinearScale8.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale8.MaxPin.Name = "MaxPin";
      gaugeLinearScale8.MaxPin.Visible = false;
      gaugeLinearScale8.MaxValue = 1500.0;
      gaugeLinearScale8.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale8.MinPin.Name = "MinPin";
      gaugeLinearScale8.MinPin.Visible = false;
      gaugeLinearScale8.MinValue = 1000.0;
      gaugeLinearScale8.Name = "Scale8";
      gaugePointer8.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer8.CapFillColor.BorderWidth = 1;
      gaugePointer8.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer8.CapFillColor.Color2 = Color.DimGray;
      gaugePointer8.FillColor.BorderColor = Color.DimGray;
      gaugePointer8.FillColor.BorderWidth = 1;
      gaugePointer8.FillColor.Color1 = Color.Red;
      gaugePointer8.Name = "Pointer1";
      gaugePointer8.Placement = DisplayPlacement.Far;
      gaugePointer8.ScaleOffset = 0.05f;
      gaugePointer8.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer8.ThermoBackColor.BorderWidth = 1;
      gaugePointer8.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale8.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer8
      });
      gaugeSection22.FillColor.Color1 = Color.Crimson;
      gaugeSection22.Name = "Section1";
      gaugeSection23.EndValue = 1500.0;
      gaugeSection23.FillColor.Color1 = Color.Lime;
      gaugeSection23.Name = "Section2";
      gaugeSection23.StartValue = 1200.0;
      gaugeSection24.EndValue = 0.0;
      gaugeSection24.FillColor.Color1 = Color.Crimson;
      gaugeSection24.Name = "Section3";
      gaugeSection24.StartValue = 0.0;
      gaugeLinearScale8.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection22,
        gaugeSection23,
        gaugeSection24
      });
      GaugeLinearScale gaugeLinearScale28 = gaugeLinearScale8;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF21 = sizeF1;
      gaugeLinearScale28.Size = sizeF21;
      gaugeLinearScale8.Visible = false;
      gaugeLinearScale8.Width = 0.06f;
      gaugeCustomLabel3.Layout.AdaptiveLabel = true;
      gaugeCustomLabel3.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel3.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel3.Name = "Label1fgfdg";
      gaugeCustomLabel3.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel3.Value = 1000.0;
      gaugeLinearScale9.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel3
      });
      GaugeLinearScale gaugeLinearScale29 = gaugeLinearScale9;
      object obj21 = componentResourceManager.GetObject("GaugeLinearScale9.Location");
      PointF pointF22 = obj21 != null ? (PointF) obj21 : pointF1;
      gaugeLinearScale29.Location = pointF22;
      gaugeLinearScale9.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale9.MaxPin.Name = "MaxPin";
      gaugeLinearScale9.MaxPin.Visible = false;
      gaugeLinearScale9.MaxValue = 1500.0;
      gaugeLinearScale9.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale9.MinPin.Name = "MinPin";
      gaugeLinearScale9.MinPin.Visible = false;
      gaugeLinearScale9.MinValue = 1000.0;
      gaugeLinearScale9.Name = "Scale9";
      gaugePointer9.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer9.CapFillColor.BorderWidth = 1;
      gaugePointer9.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer9.CapFillColor.Color2 = Color.DimGray;
      gaugePointer9.FillColor.BorderColor = Color.DimGray;
      gaugePointer9.FillColor.BorderWidth = 1;
      gaugePointer9.FillColor.Color1 = Color.Red;
      gaugePointer9.Name = "Pointer1";
      gaugePointer9.Placement = DisplayPlacement.Far;
      gaugePointer9.ScaleOffset = 0.05f;
      gaugePointer9.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer9.ThermoBackColor.BorderWidth = 1;
      gaugePointer9.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale9.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer9
      });
      gaugeSection25.FillColor.Color1 = Color.Crimson;
      gaugeSection25.Name = "Section1";
      gaugeSection26.EndValue = 1500.0;
      gaugeSection26.FillColor.Color1 = Color.Lime;
      gaugeSection26.Name = "Section2";
      gaugeSection26.StartValue = 1200.0;
      gaugeSection27.EndValue = 0.0;
      gaugeSection27.FillColor.Color1 = Color.Crimson;
      gaugeSection27.Name = "Section3";
      gaugeSection27.StartValue = 0.0;
      gaugeLinearScale9.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection25,
        gaugeSection26,
        gaugeSection27
      });
      GaugeLinearScale gaugeLinearScale30 = gaugeLinearScale9;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF22 = sizeF1;
      gaugeLinearScale30.Size = sizeF22;
      gaugeLinearScale9.Visible = false;
      gaugeLinearScale9.Width = 0.06f;
      gaugeCustomLabel4.Layout.AdaptiveLabel = true;
      gaugeCustomLabel4.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel4.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel4.Name = "Label1fgfdg";
      gaugeCustomLabel4.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel4.Value = 1000.0;
      gaugeLinearScale10.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel4
      });
      GaugeLinearScale gaugeLinearScale31 = gaugeLinearScale10;
      object obj22 = componentResourceManager.GetObject("GaugeLinearScale10.Location");
      PointF pointF23 = obj22 != null ? (PointF) obj22 : pointF1;
      gaugeLinearScale31.Location = pointF23;
      gaugeLinearScale10.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale10.MaxPin.Name = "MaxPin";
      gaugeLinearScale10.MaxPin.Visible = false;
      gaugeLinearScale10.MaxValue = 1500.0;
      gaugeLinearScale10.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale10.MinPin.Name = "MinPin";
      gaugeLinearScale10.MinPin.Visible = false;
      gaugeLinearScale10.MinValue = 1000.0;
      gaugeLinearScale10.Name = "Scale10";
      gaugePointer10.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer10.CapFillColor.BorderWidth = 1;
      gaugePointer10.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer10.CapFillColor.Color2 = Color.DimGray;
      gaugePointer10.FillColor.BorderColor = Color.DimGray;
      gaugePointer10.FillColor.BorderWidth = 1;
      gaugePointer10.FillColor.Color1 = Color.Red;
      gaugePointer10.Name = "Pointer1";
      gaugePointer10.Placement = DisplayPlacement.Far;
      gaugePointer10.ScaleOffset = 0.05f;
      gaugePointer10.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer10.ThermoBackColor.BorderWidth = 1;
      gaugePointer10.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale10.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer10
      });
      gaugeSection28.FillColor.Color1 = Color.Crimson;
      gaugeSection28.Name = "Section1";
      gaugeSection29.EndValue = 1500.0;
      gaugeSection29.FillColor.Color1 = Color.Lime;
      gaugeSection29.Name = "Section2";
      gaugeSection29.StartValue = 1200.0;
      gaugeSection30.EndValue = 0.0;
      gaugeSection30.FillColor.Color1 = Color.Crimson;
      gaugeSection30.Name = "Section3";
      gaugeSection30.StartValue = 0.0;
      gaugeLinearScale10.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection28,
        gaugeSection29,
        gaugeSection30
      });
      GaugeLinearScale gaugeLinearScale32 = gaugeLinearScale10;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF23 = sizeF1;
      gaugeLinearScale32.Size = sizeF23;
      gaugeLinearScale10.Visible = false;
      gaugeLinearScale10.Width = 0.06f;
      gaugeCustomLabel5.Layout.AdaptiveLabel = true;
      gaugeCustomLabel5.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel5.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel5.Name = "Label1fgfdg";
      gaugeCustomLabel5.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel5.Value = 1000.0;
      gaugeLinearScale11.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel5
      });
      GaugeLinearScale gaugeLinearScale33 = gaugeLinearScale11;
      object obj23 = componentResourceManager.GetObject("GaugeLinearScale11.Location");
      PointF pointF24 = obj23 != null ? (PointF) obj23 : pointF1;
      gaugeLinearScale33.Location = pointF24;
      gaugeLinearScale11.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale11.MaxPin.Name = "MaxPin";
      gaugeLinearScale11.MaxPin.Visible = false;
      gaugeLinearScale11.MaxValue = 1500.0;
      gaugeLinearScale11.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale11.MinPin.Name = "MinPin";
      gaugeLinearScale11.MinPin.Visible = false;
      gaugeLinearScale11.MinValue = 1000.0;
      gaugeLinearScale11.Name = "Scale11";
      gaugePointer11.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer11.CapFillColor.BorderWidth = 1;
      gaugePointer11.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer11.CapFillColor.Color2 = Color.DimGray;
      gaugePointer11.FillColor.BorderColor = Color.DimGray;
      gaugePointer11.FillColor.BorderWidth = 1;
      gaugePointer11.FillColor.Color1 = Color.Red;
      gaugePointer11.Name = "Pointer1";
      gaugePointer11.Placement = DisplayPlacement.Far;
      gaugePointer11.ScaleOffset = 0.05f;
      gaugePointer11.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer11.ThermoBackColor.BorderWidth = 1;
      gaugePointer11.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale11.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer11
      });
      gaugeSection31.FillColor.Color1 = Color.Crimson;
      gaugeSection31.Name = "Section1";
      gaugeSection32.EndValue = 1500.0;
      gaugeSection32.FillColor.Color1 = Color.Lime;
      gaugeSection32.Name = "Section2";
      gaugeSection32.StartValue = 1200.0;
      gaugeSection33.EndValue = 0.0;
      gaugeSection33.FillColor.Color1 = Color.Crimson;
      gaugeSection33.Name = "Section3";
      gaugeSection33.StartValue = 0.0;
      gaugeLinearScale11.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection31,
        gaugeSection32,
        gaugeSection33
      });
      GaugeLinearScale gaugeLinearScale34 = gaugeLinearScale11;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF24 = sizeF1;
      gaugeLinearScale34.Size = sizeF24;
      gaugeLinearScale11.Visible = false;
      gaugeLinearScale11.Width = 0.06f;
      gaugeCustomLabel6.Layout.AdaptiveLabel = true;
      gaugeCustomLabel6.Layout.Placement = DisplayPlacement.Center;
      gaugeCustomLabel6.Layout.ScaleOffset = 0.3f;
      gaugeCustomLabel6.Name = "Label1fgfdg";
      gaugeCustomLabel6.Text = "asdf gfhdfgdfgdPWM";
      gaugeCustomLabel6.Value = 1000.0;
      gaugeLinearScale12.CustomLabels.AddRange(new GaugeCustomLabel[1]
      {
        gaugeCustomLabel6
      });
      GaugeLinearScale gaugeLinearScale35 = gaugeLinearScale12;
      object obj24 = componentResourceManager.GetObject("GaugeLinearScale12.Location");
      PointF pointF25 = obj24 != null ? (PointF) obj24 : pointF1;
      gaugeLinearScale35.Location = pointF25;
      gaugeLinearScale12.MajorTickMarks.Interval = 100.0;
      gaugeLinearScale12.MaxPin.Name = "MaxPin";
      gaugeLinearScale12.MaxPin.Visible = false;
      gaugeLinearScale12.MaxValue = 1500.0;
      gaugeLinearScale12.MinorTickMarks.Interval = 10.0;
      gaugeLinearScale12.MinPin.Name = "MinPin";
      gaugeLinearScale12.MinPin.Visible = false;
      gaugeLinearScale12.MinValue = 1000.0;
      gaugeLinearScale12.Name = "Scale12";
      gaugePointer12.CapFillColor.BorderColor = Color.DimGray;
      gaugePointer12.CapFillColor.BorderWidth = 1;
      gaugePointer12.CapFillColor.Color1 = Color.WhiteSmoke;
      gaugePointer12.CapFillColor.Color2 = Color.DimGray;
      gaugePointer12.FillColor.BorderColor = Color.DimGray;
      gaugePointer12.FillColor.BorderWidth = 1;
      gaugePointer12.FillColor.Color1 = Color.Red;
      gaugePointer12.Name = "Pointer1";
      gaugePointer12.Placement = DisplayPlacement.Far;
      gaugePointer12.ScaleOffset = 0.05f;
      gaugePointer12.ThermoBackColor.BorderColor = Color.Black;
      gaugePointer12.ThermoBackColor.BorderWidth = 1;
      gaugePointer12.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60);
      gaugeLinearScale12.Pointers.AddRange(new GaugePointer[1]
      {
        gaugePointer12
      });
      gaugeSection34.FillColor.Color1 = Color.Crimson;
      gaugeSection34.Name = "Section1";
      gaugeSection35.EndValue = 1500.0;
      gaugeSection35.FillColor.Color1 = Color.Lime;
      gaugeSection35.Name = "Section2";
      gaugeSection35.StartValue = 1200.0;
      gaugeSection36.EndValue = 0.0;
      gaugeSection36.FillColor.Color1 = Color.Crimson;
      gaugeSection36.Name = "Section3";
      gaugeSection36.StartValue = 0.0;
      gaugeLinearScale12.Sections.AddRange(new GaugeSection[3]
      {
        gaugeSection34,
        gaugeSection35,
        gaugeSection36
      });
      GaugeLinearScale gaugeLinearScale36 = gaugeLinearScale12;
      sizeF1 = new SizeF(0.4f, 0.25f);
      SizeF sizeF25 = sizeF1;
      gaugeLinearScale36.Size = sizeF25;
      gaugeLinearScale12.Visible = false;
      gaugeLinearScale12.Width = 0.06f;
      this.gagPos1.LinearScales.AddRange(new GaugeLinearScale[12]
      {
        gaugeLinearScale1,
        gaugeLinearScale2,
        gaugeLinearScale3,
        gaugeLinearScale4,
        gaugeLinearScale5,
        gaugeLinearScale6,
        gaugeLinearScale7,
        gaugeLinearScale8,
        gaugeLinearScale9,
        gaugeLinearScale10,
        gaugeLinearScale11,
        gaugeLinearScale12
      });
      this.gagPos1.Location = new Point(0, 0);
      this.gagPos1.Name = "gagPos1";
      GaugeControl gagPos1 = this.gagPos1;
      Size size1 = new Size(862, 438);
      Size size2 = size1;
      gagPos1.Size = size2;
      this.gagPos1.TabIndex = 1;
      this.gagPos1.Text = "GaugeControl1";
      sizeF1 = new SizeF(6f, 13f);
      this.AutoScaleDimensions = sizeF1;
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.gagPos1);
      this.Name = nameof (ctrlMechChecks);
      size1 = new Size(862, 438);
      this.Size = size1;
      this.gagPos1.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GaugeControl gagPos1
    {
      [DebuggerNonUserCode] get => this._gagPos1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._gagPos1 = value;
    }

    public ctrlMechChecks(List<PST.PrinterMechChecks> CheckList)
    {
      ctrlMechChecks.__ENCAddToList((object) this);
      this.InitializeComponent();
      this._CheckList = CheckList;
      this.AddMechChecks();
    }

    private void AddMechChecks()
    {
      int num1 = Math.Min(checked (this._CheckList.Count - 1), checked (this.gagPos1.LinearScales.Count - 1));
      int index = 0;
      while (index <= num1)
      {
        try
        {
          GaugeLinearScale linearScale = this.gagPos1.LinearScales[index];
          linearScale.Visible = true;
          switch (this._CheckList[index].SpecType)
          {
            case PST.SpecType.LessThan:
              linearScale.Sections[0].EndValue = Math.Round(linearScale.MinValue, 2);
              linearScale.Sections[1].EndValue = Math.Round(this._CheckList[index].SpecHigh, 2);
              break;
            case PST.SpecType.GreaterThan:
              linearScale.Sections[0].EndValue = Math.Round(this._CheckList[index].SpecLow, 2);
              linearScale.Sections[1].EndValue = Math.Round(linearScale.MaxValue, 2);
              break;
            case PST.SpecType.Between:
              double num2 = Math.Min(this._CheckList[index].SpecLow, this._CheckList[index].Value);
              double num3 = Math.Max(this._CheckList[index].SpecHigh, this._CheckList[index].Value);
              int num4 = checked ((int) Math.Round(Math.Round(unchecked (num3 - num2 + (num3 - num2) * 0.5), 2)));
              linearScale.MajorTickMarks.Interval = Math.Round((double) num4 / 5.0, 2);
              linearScale.MinorTickMarks.Interval = Math.Round((double) num4 / 30.0, 2);
              linearScale.Sections[0].EndValue = Math.Round(this._CheckList[index].SpecLow, 2);
              linearScale.Sections[1].StartValue = Math.Round(this._CheckList[index].SpecLow, 2);
              linearScale.Sections[1].EndValue = Math.Round(this._CheckList[index].SpecHigh, 2);
              linearScale.Sections[2].StartValue = Math.Round(this._CheckList[index].SpecHigh, 2);
              linearScale.Sections[2].EndValue = Math.Round(linearScale.MaxValue, 2);
              break;
          }
          linearScale.MinValue = Math.Round(Math.Min(this._CheckList[index].SpecLow, this._CheckList[index].Value) - linearScale.MajorTickMarks.Interval, 0);
          linearScale.MaxValue = Math.Round(Math.Max(this._CheckList[index].SpecHigh, this._CheckList[index].Value) + linearScale.MajorTickMarks.Interval, 0);
          linearScale.Pointers[0].Value = Math.Round(this._CheckList[index].Value, 2);
          linearScale.Pointers[0].Tooltip = Conversions.ToString(Math.Round(this._CheckList[index].Value, 2));
          GaugeCustomLabel gaugeCustomLabel = new GaugeCustomLabel();
          gaugeCustomLabel.Text = this._CheckList[index].Name;
          gaugeCustomLabel.Visible = true;
          gaugeCustomLabel.Layout.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
          gaugeCustomLabel.Layout.AdaptiveLabel = true;
          gaugeCustomLabel.Layout.AutoOrientLabel = true;
          gaugeCustomLabel.Layout.AutoSize = true;
          gaugeCustomLabel.Layout.Placement = DisplayPlacement.Near;
          gaugeCustomLabel.Layout.ScaleOffset = 0.13f;
          gaugeCustomLabel.Value = (linearScale.MaxValue - linearScale.MinValue) / 2.0 + linearScale.MinValue;
          gaugeCustomLabel.TickMark.Visible = false;
          linearScale.CustomLabels.Add(gaugeCustomLabel);
          if (!this._CheckList[index].Results & this._CheckList[index].SpecFunction == PST.SpecFunction.PassFail)
            this.gagPos1.GaugeItems[index].Visible = true;
        }
        catch (OverflowException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          OverflowException overflowException = ex;
          string str = "Error occured while adding a mech check.\r\n\r\nCheck Name: " + this._CheckList[index].Name + "\r\nCheck Value: " + Conversions.ToString(this._CheckList[index].Value) + "\r\n\r\nError Details\r\n" + overflowException.ToString();
          Logging.AddLogEntry((object) this, str, EventLogEntryType.Error, 1);
          int num5 = (int) Interaction.MsgBox((object) str);
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          throw ex;
        }
        checked { ++index; }
      }
    }
  }
}
