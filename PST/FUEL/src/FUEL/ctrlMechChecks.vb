Imports DevComponents.Instrumentation
Imports FUEL.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class ctrlMechChecks
        Inherits UserControl
        ' Methods
        Public Sub New(ByVal CheckList As List(Of PrinterMechChecks))
            ctrlMechChecks.__ENCAddToList(Me)
            Me.InitializeComponent
            Me._CheckList = CheckList
            Me.AddMechChecks
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlMechChecks.__ENCList
                If (ctrlMechChecks.__ENCList.Count = ctrlMechChecks.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlMechChecks.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlMechChecks.__ENCList.RemoveRange(index, (ctrlMechChecks.__ENCList.Count - index))
                            ctrlMechChecks.__ENCList.Capacity = ctrlMechChecks.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlMechChecks.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlMechChecks.__ENCList(index) = ctrlMechChecks.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlMechChecks.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub AddMechChecks()
            Dim num6 As Integer = Math.Min(CInt((Me._CheckList.Count - 1)), CInt((Me.gagPos1.LinearScales.Count - 1)))
            Dim num2 As Integer = 0
            Do While True
                Dim specType As Integer = num6
                If (num2 > specType) Then
                    Return
                End If
                Try 
                    Dim scale As GaugeLinearScale = Me.gagPos1.LinearScales(num2)
                    scale.Visible = True
                    specType = CInt(Me._CheckList(num2).SpecType)
                    Select Case specType
                        Case 0
                            scale.Sections(0).EndValue = Math.Round(scale.MinValue, 2)
                            scale.Sections(1).EndValue = Math.Round(Me._CheckList(num2).SpecHigh, 2)
                            Exit Select
                        Case 1
                            scale.Sections(0).EndValue = Math.Round(Me._CheckList(num2).SpecLow, 2)
                            scale.Sections(1).EndValue = Math.Round(scale.MaxValue, 2)
                            Exit Select
                        Case 2
                            Dim num4 As Double = Math.Min(Me._CheckList(num2).SpecLow, Me._CheckList(num2).Value)
                            Dim num3 As Double = Math.Max(Me._CheckList(num2).SpecHigh, Me._CheckList(num2).Value)
                            Dim num5 As Integer = CInt(Math.Round(Math.Round(CDbl(((num3 - num4) + ((num3 - num4) * 0.5))), 2)))
                            scale.MajorTickMarks.Interval = Math.Round(CDbl((CDbl(num5) / 5)), 2)
                            scale.MinorTickMarks.Interval = Math.Round(CDbl((CDbl(num5) / 30)), 2)
                            scale.Sections(0).EndValue = Math.Round(Me._CheckList(num2).SpecLow, 2)
                            scale.Sections(1).StartValue = Math.Round(Me._CheckList(num2).SpecLow, 2)
                            scale.Sections(1).EndValue = Math.Round(Me._CheckList(num2).SpecHigh, 2)
                            scale.Sections(2).StartValue = Math.Round(Me._CheckList(num2).SpecHigh, 2)
                            scale.Sections(2).EndValue = Math.Round(scale.MaxValue, 2)
                            Exit Select
                        Case Else
                            Exit Select
                    End Select
                    scale.MinValue = Math.Round(CDbl((Math.Min(Me._CheckList(num2).SpecLow, Me._CheckList(num2).Value) - scale.MajorTickMarks.Interval)), 0)
                    scale.MaxValue = Math.Round(CDbl((Math.Max(Me._CheckList(num2).SpecHigh, Me._CheckList(num2).Value) + scale.MajorTickMarks.Interval)), 0)
                    scale.Pointers(0).Value = Math.Round(Me._CheckList(num2).Value, 2)
                    scale.Pointers(0).Tooltip = Conversions.ToString(Math.Round(Me._CheckList(num2).Value, 2))
                    Dim item As New GaugeCustomLabel With { _
                        .Text = Me._CheckList(num2).Name, _
                        .Visible = True _
                    }
                    item.Layout.Font = New Font("Microsoft Sans Serif", 13!, FontStyle.Bold)
                    item.Layout.AdaptiveLabel = True
                    item.Layout.AutoOrientLabel = True
                    item.Layout.AutoSize = True
                    item.Layout.Placement = DisplayPlacement.Near
                    item.Layout.ScaleOffset = 0.13!
                    item.Value = (((scale.MaxValue - scale.MinValue) / 2) + scale.MinValue)
                    item.TickMark.Visible = False
                    scale.CustomLabels.Add(item)
                    scale = Nothing
                    If (Not Me._CheckList(num2).Results And (Me._CheckList(num2).SpecFunction = SpecFunction.PassFail)) Then
                        Me.gagPos1.GaugeItems(num2).Visible = True
                    End If
                Catch exception1 As OverflowException
                    Dim ex As OverflowException = exception1
                    ProjectData.SetProjectError(ex)
                    Dim strArray As String() = New String() { "Error occured while adding a mech check." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Check Name: ", Me._CheckList(num2).Name, ChrW(13) & ChrW(10) & "Check Value: ", Conversions.ToString(Me._CheckList(num2).Value), ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Error Details" & ChrW(13) & ChrW(10), ex.ToString }
                    Dim msg As String = String.Concat(strArray)
                    Logging.AddLogEntry(Me, msg, EventLogEntryType.Error, 1)
                    Interaction.MsgBox(msg, MsgBoxStyle.ApplicationModal, Nothing)
                    ProjectData.ClearProjectError
                Catch exception3 As Exception
                    Dim ex As Exception = exception3
                    ProjectData.SetProjectError(ex)
                    Throw ex
                End Try
                num2 += 1
            Loop
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try 
                If (If((Not disposing OrElse (Me.components Is Nothing)), 0, 1) <> 0) Then
                    Me.components.Dispose
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim tf As PointF
            Dim tf1 As PointF
            Dim tf2 As PointF
            Dim tf3 As PointF
            Dim tf4 As PointF
            Dim tf5 As PointF
            Dim tf6 As PointF
            Dim tf7 As PointF
            Dim tf8 As PointF
            Dim tf9 As PointF
            Dim tf10 As PointF
            Dim tf11 As PointF
            Dim tf12 As PointF
            Dim tf13 As PointF
            Dim tf14 As PointF
            Dim tf15 As PointF
            Dim tf16 As PointF
            Dim tf17 As PointF
            Dim tf18 As PointF
            Dim tf19 As PointF
            Dim tf20 As PointF
            Dim tf21 As PointF
            Dim tf22 As PointF
            Dim tf23 As PointF
            Dim tf24 As PointF
            Dim color As New GradientFillColor
            Dim color2 As New GradientFillColor
            Dim indicator As New StateIndicator
            Dim manager As New ComponentResourceManager(GetType(ctrlMechChecks))
            Dim indicator5 As New StateIndicator
            Dim indicator6 As New StateIndicator
            Dim indicator7 As New StateIndicator
            Dim indicator8 As New StateIndicator
            Dim indicator9 As New StateIndicator
            Dim indicator10 As New StateIndicator
            Dim indicator11 As New StateIndicator
            Dim indicator12 As New StateIndicator
            Dim indicator2 As New StateIndicator
            Dim indicator3 As New StateIndicator
            Dim indicator4 As New StateIndicator
            Dim scale As New GaugeLinearScale
            Dim label As New GaugeCustomLabel
            Dim pointer As New GaugePointer
            Dim section As New GaugeSection
            Dim section12 As New GaugeSection
            Dim section23 As New GaugeSection
            Dim scale5 As New GaugeLinearScale
            Dim pointer5 As New GaugePointer
            Dim section31 As New GaugeSection
            Dim section32 As New GaugeSection
            Dim section33 As New GaugeSection
            Dim scale6 As New GaugeLinearScale
            Dim pointer6 As New GaugePointer
            Dim section34 As New GaugeSection
            Dim section35 As New GaugeSection
            Dim section36 As New GaugeSection
            Dim scale7 As New GaugeLinearScale
            Dim pointer7 As New GaugePointer
            Dim section2 As New GaugeSection
            Dim section3 As New GaugeSection
            Dim section4 As New GaugeSection
            Dim scale8 As New GaugeLinearScale
            Dim pointer8 As New GaugePointer
            Dim section5 As New GaugeSection
            Dim section6 As New GaugeSection
            Dim section7 As New GaugeSection
            Dim scale9 As New GaugeLinearScale
            Dim pointer9 As New GaugePointer
            Dim section8 As New GaugeSection
            Dim section9 As New GaugeSection
            Dim section10 As New GaugeSection
            Dim scale10 As New GaugeLinearScale
            Dim pointer10 As New GaugePointer
            Dim section11 As New GaugeSection
            Dim section13 As New GaugeSection
            Dim section14 As New GaugeSection
            Dim scale11 As New GaugeLinearScale
            Dim label2 As New GaugeCustomLabel
            Dim pointer11 As New GaugePointer
            Dim section15 As New GaugeSection
            Dim section16 As New GaugeSection
            Dim section17 As New GaugeSection
            Dim scale12 As New GaugeLinearScale
            Dim label3 As New GaugeCustomLabel
            Dim pointer12 As New GaugePointer
            Dim section18 As New GaugeSection
            Dim section19 As New GaugeSection
            Dim section20 As New GaugeSection
            Dim scale2 As New GaugeLinearScale
            Dim label4 As New GaugeCustomLabel
            Dim pointer2 As New GaugePointer
            Dim section21 As New GaugeSection
            Dim section22 As New GaugeSection
            Dim section24 As New GaugeSection
            Dim scale3 As New GaugeLinearScale
            Dim label5 As New GaugeCustomLabel
            Dim pointer3 As New GaugePointer
            Dim section25 As New GaugeSection
            Dim section26 As New GaugeSection
            Dim section27 As New GaugeSection
            Dim scale4 As New GaugeLinearScale
            Dim label6 As New GaugeCustomLabel
            Dim pointer4 As New GaugePointer
            Dim section28 As New GaugeSection
            Dim section29 As New GaugeSection
            Dim section30 As New GaugeSection
            Me.gagPos1 = New GaugeControl
            Me.gagPos1.BeginInit
            Me.SuspendLayout
            Me.gagPos1.BackColor = Color.White
            Me.gagPos1.ForeColor = Color.Black
            color.Color1 = Color.Gainsboro
            color.Color2 = Color.DarkGray
            Me.gagPos1.Frame.BackColor = color
            color2.BorderColor = Color.Gainsboro
            color2.BorderWidth = 1
            color2.Color1 = Color.White
            color2.Color2 = Color.DimGray
            Me.gagPos1.Frame.FrameColor = color2
            indicator.BackColor.BorderColor = Color.Black
            indicator.BackColor.Color1 = Color.Red
            indicator.BackColor.Color2 = Color.Maroon
            indicator.EmptyString = ""
            indicator.Image = Resources.Error_icon_sm
            Dim obj1 As Object = manager.GetObject("StateIndicator1.Location")
            If (Not obj1 Is Nothing) Then
                tf1 = DirectCast(obj1, PointF*)
            Else
                Dim local1 As Object = obj1
                tf1 = tf
            End If
            indicator.Location = tf1
            indicator.Name = "StateIndicator1"
            Dim ef2 As New SizeF(0.03!, 0.05!)
            indicator.Size = ef2
            indicator.Text = ""
            indicator.TextColor = Color.White
            indicator.UnderScale = False
            indicator.Visible = False
            indicator5.BackColor.BorderColor = Color.Black
            indicator5.BackColor.Color1 = Color.Red
            indicator5.BackColor.Color2 = Color.Maroon
            indicator5.EmptyString = ""
            indicator5.Image = Resources.Error_icon_sm
            Dim obj2 As Object = manager.GetObject("StateIndicator2.Location")
            If (Not obj2 Is Nothing) Then
                tf2 = DirectCast(obj2, PointF*)
            Else
                Dim local2 As Object = obj2
                tf2 = tf
            End If
            indicator5.Location = tf2
            indicator5.Name = "StateIndicator2"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator5.Size = ef2
            indicator5.Text = ""
            indicator5.TextColor = Color.White
            indicator5.UnderScale = False
            indicator5.Visible = False
            indicator6.BackColor.BorderColor = Color.Black
            indicator6.BackColor.Color1 = Color.Red
            indicator6.BackColor.Color2 = Color.Maroon
            indicator6.EmptyString = ""
            indicator6.Image = Resources.Error_icon_sm
            Dim obj3 As Object = manager.GetObject("StateIndicator3.Location")
            If (Not obj3 Is Nothing) Then
                tf3 = DirectCast(obj3, PointF*)
            Else
                Dim local3 As Object = obj3
                tf3 = tf
            End If
            indicator6.Location = tf3
            indicator6.Name = "StateIndicator3"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator6.Size = ef2
            indicator6.Text = ""
            indicator6.TextColor = Color.White
            indicator6.UnderScale = False
            indicator6.Visible = False
            indicator7.BackColor.BorderColor = Color.Black
            indicator7.BackColor.Color1 = Color.Red
            indicator7.BackColor.Color2 = Color.Maroon
            indicator7.EmptyString = ""
            indicator7.Image = Resources.Error_icon_sm
            Dim obj4 As Object = manager.GetObject("StateIndicator4.Location")
            If (Not obj4 Is Nothing) Then
                tf4 = DirectCast(obj4, PointF*)
            Else
                Dim local4 As Object = obj4
                tf4 = tf
            End If
            indicator7.Location = tf4
            indicator7.Name = "StateIndicator4"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator7.Size = ef2
            indicator7.Text = ""
            indicator7.TextColor = Color.White
            indicator7.UnderScale = False
            indicator7.Visible = False
            indicator8.BackColor.BorderColor = Color.Black
            indicator8.BackColor.Color1 = Color.Red
            indicator8.BackColor.Color2 = Color.Maroon
            indicator8.EmptyString = ""
            indicator8.Image = Resources.Error_icon_sm
            Dim obj5 As Object = manager.GetObject("StateIndicator5.Location")
            If (Not obj5 Is Nothing) Then
                tf5 = DirectCast(obj5, PointF*)
            Else
                Dim local5 As Object = obj5
                tf5 = tf
            End If
            indicator8.Location = tf5
            indicator8.Name = "StateIndicator5"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator8.Size = ef2
            indicator8.Text = ""
            indicator8.TextColor = Color.White
            indicator8.UnderScale = False
            indicator8.Visible = False
            indicator9.BackColor.BorderColor = Color.Black
            indicator9.BackColor.Color1 = Color.Red
            indicator9.BackColor.Color2 = Color.Maroon
            indicator9.EmptyString = ""
            indicator9.Image = Resources.Error_icon_sm
            Dim obj6 As Object = manager.GetObject("StateIndicator6.Location")
            If (Not obj6 Is Nothing) Then
                tf6 = DirectCast(obj6, PointF*)
            Else
                Dim local6 As Object = obj6
                tf6 = tf
            End If
            indicator9.Location = tf6
            indicator9.Name = "StateIndicator6"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator9.Size = ef2
            indicator9.Text = ""
            indicator9.TextColor = Color.White
            indicator9.UnderScale = False
            indicator9.Visible = False
            indicator10.BackColor.BorderColor = Color.Black
            indicator10.BackColor.Color1 = Color.Red
            indicator10.BackColor.Color2 = Color.Maroon
            indicator10.EmptyString = ""
            indicator10.Image = Resources.Error_icon_sm
            Dim obj7 As Object = manager.GetObject("StateIndicator7.Location")
            If (Not obj7 Is Nothing) Then
                tf7 = DirectCast(obj7, PointF*)
            Else
                Dim local7 As Object = obj7
                tf7 = tf
            End If
            indicator10.Location = tf7
            indicator10.Name = "StateIndicator7"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator10.Size = ef2
            indicator10.Text = ""
            indicator10.TextColor = Color.White
            indicator10.UnderScale = False
            indicator10.Visible = False
            indicator11.BackColor.BorderColor = Color.Black
            indicator11.BackColor.Color1 = Color.Red
            indicator11.BackColor.Color2 = Color.Maroon
            indicator11.EmptyString = ""
            indicator11.Image = Resources.Error_icon_sm
            Dim obj8 As Object = manager.GetObject("StateIndicator8.Location")
            If (Not obj8 Is Nothing) Then
                tf8 = DirectCast(obj8, PointF*)
            Else
                Dim local8 As Object = obj8
                tf8 = tf
            End If
            indicator11.Location = tf8
            indicator11.Name = "StateIndicator8"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator11.Size = ef2
            indicator11.Text = ""
            indicator11.TextColor = Color.White
            indicator11.UnderScale = False
            indicator11.Visible = False
            indicator12.BackColor.BorderColor = Color.Black
            indicator12.BackColor.Color1 = Color.Red
            indicator12.BackColor.Color2 = Color.Maroon
            indicator12.EmptyString = ""
            indicator12.Image = Resources.Error_icon_sm
            Dim obj9 As Object = manager.GetObject("StateIndicator9.Location")
            If (Not obj9 Is Nothing) Then
                tf9 = DirectCast(obj9, PointF*)
            Else
                Dim local9 As Object = obj9
                tf9 = tf
            End If
            indicator12.Location = tf9
            indicator12.Name = "StateIndicator9"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator12.Size = ef2
            indicator12.Text = ""
            indicator12.TextColor = Color.White
            indicator12.UnderScale = False
            indicator12.Visible = False
            indicator2.BackColor.BorderColor = Color.Black
            indicator2.BackColor.Color1 = Color.Red
            indicator2.BackColor.Color2 = Color.Maroon
            indicator2.EmptyString = ""
            indicator2.Image = Resources.Error_icon_sm
            Dim obj10 As Object = manager.GetObject("StateIndicator10.Location")
            If (Not obj10 Is Nothing) Then
                tf10 = DirectCast(obj10, PointF*)
            Else
                Dim local10 As Object = obj10
                tf10 = tf
            End If
            indicator2.Location = tf10
            indicator2.Name = "StateIndicator10"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator2.Size = ef2
            indicator2.Text = ""
            indicator2.TextColor = Color.White
            indicator2.UnderScale = False
            indicator2.Visible = False
            indicator3.BackColor.BorderColor = Color.Black
            indicator3.BackColor.Color1 = Color.Red
            indicator3.BackColor.Color2 = Color.Maroon
            indicator3.EmptyString = ""
            indicator3.Image = Resources.Error_icon_sm
            Dim obj11 As Object = manager.GetObject("StateIndicator11.Location")
            If (Not obj11 Is Nothing) Then
                tf11 = DirectCast(obj11, PointF*)
            Else
                Dim local11 As Object = obj11
                tf11 = tf
            End If
            indicator3.Location = tf11
            indicator3.Name = "StateIndicator11"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator3.Size = ef2
            indicator3.Text = ""
            indicator3.TextColor = Color.White
            indicator3.UnderScale = False
            indicator3.Visible = False
            indicator4.BackColor.BorderColor = Color.Black
            indicator4.BackColor.Color1 = Color.Red
            indicator4.BackColor.Color2 = Color.Maroon
            indicator4.EmptyString = ""
            indicator4.Image = Resources.Error_icon_sm
            Dim obj12 As Object = manager.GetObject("StateIndicator12.Location")
            If (Not obj12 Is Nothing) Then
                tf12 = DirectCast(obj12, PointF*)
            Else
                Dim local12 As Object = obj12
                tf12 = tf
            End If
            indicator4.Location = tf12
            indicator4.Name = "StateIndicator12"
            ef2 = New SizeF(0.03!, 0.05!)
            indicator4.Size = ef2
            indicator4.Text = ""
            indicator4.TextColor = Color.White
            indicator4.UnderScale = False
            indicator4.Visible = False
            Dim items As GaugeItem() = New GaugeItem() { indicator, indicator5, indicator6, indicator7, indicator8, indicator9, indicator10, indicator11, indicator12 }
            items(9) = indicator2
            items(10) = indicator3
            items(11) = indicator4
            Me.gagPos1.GaugeItems.AddRange(items)
            Me.gagPos1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            label.Layout.AdaptiveLabel = True
            label.Layout.Placement = DisplayPlacement.Center
            label.Layout.ScaleOffset = 0.3!
            label.Name = "Label1fgfdg"
            label.Text = "asdf gfhdfgdfgdPWM"
            label.Value = 1000
            scale.CustomLabels.AddRange(New GaugeCustomLabel() { label })
            Dim obj13 As Object = manager.GetObject("GaugeLinearScale1.Location")
            If (Not obj13 Is Nothing) Then
                tf13 = DirectCast(obj13, PointF*)
            Else
                Dim local13 As Object = obj13
                tf13 = tf
            End If
            scale.Location = tf13
            scale.MajorTickMarks.Interval = 100
            scale.MaxPin.Name = "MaxPin"
            scale.MaxPin.Visible = False
            scale.MaxValue = 1500
            scale.MinorTickMarks.Interval = 10
            scale.MinPin.Name = "MinPin"
            scale.MinPin.Visible = False
            scale.MinValue = 1000
            scale.Name = "Scale1"
            pointer.CapFillColor.BorderColor = Color.DimGray
            pointer.CapFillColor.BorderWidth = 1
            pointer.CapFillColor.Color1 = Color.WhiteSmoke
            pointer.CapFillColor.Color2 = Color.DimGray
            pointer.FillColor.BorderColor = Color.DimGray
            pointer.FillColor.BorderWidth = 1
            pointer.FillColor.Color1 = Color.Red
            pointer.Name = "Pointer1"
            pointer.Placement = DisplayPlacement.Far
            pointer.ScaleOffset = 0.05!
            pointer.ThermoBackColor.BorderColor = Color.Black
            pointer.ThermoBackColor.BorderWidth = 1
            pointer.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale.Pointers.AddRange(New GaugePointer() { pointer })
            section.FillColor.Color1 = Color.Crimson
            section.Name = "Section1"
            section12.EndValue = 1500
            section12.FillColor.Color1 = Color.Lime
            section12.Name = "Section2"
            section12.StartValue = 1200
            section23.EndValue = 0
            section23.FillColor.Color1 = Color.Crimson
            section23.Name = "Section3"
            section23.StartValue = 0
            scale.Sections.AddRange(New GaugeSection() { section, section12, section23 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale.Size = ef2
            scale.Visible = False
            scale.Width = 0.06!
            Dim obj14 As Object = manager.GetObject("GaugeLinearScale2.Location")
            If (Not obj14 Is Nothing) Then
                tf14 = DirectCast(obj14, PointF*)
            Else
                Dim local14 As Object = obj14
                tf14 = tf
            End If
            scale5.Location = tf14
            scale5.MajorTickMarks.Interval = 100
            scale5.MaxPin.Name = "MaxPin"
            scale5.MaxPin.Visible = False
            scale5.MaxValue = 1500
            scale5.MinorTickMarks.Interval = 10
            scale5.MinPin.Name = "MinPin"
            scale5.MinPin.Visible = False
            scale5.MinValue = 1000
            scale5.Name = "Scale2"
            pointer5.CapFillColor.BorderColor = Color.DimGray
            pointer5.CapFillColor.BorderWidth = 1
            pointer5.CapFillColor.Color1 = Color.WhiteSmoke
            pointer5.CapFillColor.Color2 = Color.DimGray
            pointer5.FillColor.BorderColor = Color.DimGray
            pointer5.FillColor.BorderWidth = 1
            pointer5.FillColor.Color1 = Color.Red
            pointer5.Name = "Pointer1"
            pointer5.Placement = DisplayPlacement.Far
            pointer5.ScaleOffset = 0.05!
            pointer5.ThermoBackColor.BorderColor = Color.Black
            pointer5.ThermoBackColor.BorderWidth = 1
            pointer5.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale5.Pointers.AddRange(New GaugePointer() { pointer5 })
            section31.FillColor.Color1 = Color.Crimson
            section31.Name = "Section1"
            section32.EndValue = 1500
            section32.FillColor.Color1 = Color.Lime
            section32.Name = "Section2"
            section32.StartValue = 1200
            section33.EndValue = 0
            section33.FillColor.Color1 = Color.Crimson
            section33.Name = "Section3"
            section33.StartValue = 0
            scale5.Sections.AddRange(New GaugeSection() { section31, section32, section33 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale5.Size = ef2
            scale5.Visible = False
            Dim obj15 As Object = manager.GetObject("GaugeLinearScale3.Location")
            If (Not obj15 Is Nothing) Then
                tf15 = DirectCast(obj15, PointF*)
            Else
                Dim local15 As Object = obj15
                tf15 = tf
            End If
            scale6.Location = tf15
            scale6.MajorTickMarks.Interval = 100
            scale6.MaxPin.Name = "MaxPin"
            scale6.MaxPin.Visible = False
            scale6.MaxValue = 1500
            scale6.MinorTickMarks.Interval = 10
            scale6.MinPin.Name = "MinPin"
            scale6.MinPin.Visible = False
            scale6.MinValue = 1000
            scale6.Name = "Scale3"
            pointer6.CapFillColor.BorderColor = Color.DimGray
            pointer6.CapFillColor.BorderWidth = 1
            pointer6.CapFillColor.Color1 = Color.WhiteSmoke
            pointer6.CapFillColor.Color2 = Color.DimGray
            pointer6.FillColor.BorderColor = Color.DimGray
            pointer6.FillColor.BorderWidth = 1
            pointer6.FillColor.Color1 = Color.Red
            pointer6.Name = "Pointer1"
            pointer6.Placement = DisplayPlacement.Far
            pointer6.ScaleOffset = 0.05!
            pointer6.ThermoBackColor.BorderColor = Color.Black
            pointer6.ThermoBackColor.BorderWidth = 1
            pointer6.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale6.Pointers.AddRange(New GaugePointer() { pointer6 })
            section34.FillColor.Color1 = Color.Crimson
            section34.Name = "Section1"
            section35.EndValue = 1500
            section35.FillColor.Color1 = Color.Lime
            section35.Name = "Section2"
            section35.StartValue = 1200
            section36.EndValue = 0
            section36.FillColor.Color1 = Color.Crimson
            section36.Name = "Section3"
            section36.StartValue = 0
            scale6.Sections.AddRange(New GaugeSection() { section34, section35, section36 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale6.Size = ef2
            scale6.Visible = False
            Dim obj16 As Object = manager.GetObject("GaugeLinearScale4.Location")
            If (Not obj16 Is Nothing) Then
                tf16 = DirectCast(obj16, PointF*)
            Else
                Dim local16 As Object = obj16
                tf16 = tf
            End If
            scale7.Location = tf16
            scale7.MajorTickMarks.Interval = 100
            scale7.MaxPin.Name = "MaxPin"
            scale7.MaxPin.Visible = False
            scale7.MaxValue = 1500
            scale7.MinorTickMarks.Interval = 10
            scale7.MinPin.Name = "MinPin"
            scale7.MinPin.Visible = False
            scale7.MinValue = 1000
            scale7.Name = "Scale4"
            pointer7.CapFillColor.BorderColor = Color.DimGray
            pointer7.CapFillColor.BorderWidth = 1
            pointer7.CapFillColor.Color1 = Color.WhiteSmoke
            pointer7.CapFillColor.Color2 = Color.DimGray
            pointer7.FillColor.BorderColor = Color.DimGray
            pointer7.FillColor.BorderWidth = 1
            pointer7.FillColor.Color1 = Color.Red
            pointer7.Name = "Pointer1"
            pointer7.Placement = DisplayPlacement.Far
            pointer7.ScaleOffset = 0.05!
            pointer7.ThermoBackColor.BorderColor = Color.Black
            pointer7.ThermoBackColor.BorderWidth = 1
            pointer7.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale7.Pointers.AddRange(New GaugePointer() { pointer7 })
            section2.FillColor.Color1 = Color.Crimson
            section2.Name = "Section1"
            section3.EndValue = 1500
            section3.FillColor.Color1 = Color.Lime
            section3.Name = "Section2"
            section3.StartValue = 1200
            section4.EndValue = 0
            section4.FillColor.Color1 = Color.Crimson
            section4.Name = "Section3"
            section4.StartValue = 0
            scale7.Sections.AddRange(New GaugeSection() { section2, section3, section4 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale7.Size = ef2
            scale7.Visible = False
            Dim obj17 As Object = manager.GetObject("GaugeLinearScale5.Location")
            If (Not obj17 Is Nothing) Then
                tf17 = DirectCast(obj17, PointF*)
            Else
                Dim local17 As Object = obj17
                tf17 = tf
            End If
            scale8.Location = tf17
            scale8.MajorTickMarks.Interval = 100
            scale8.MaxPin.Name = "MaxPin"
            scale8.MaxPin.Visible = False
            scale8.MaxValue = 1500
            scale8.MinorTickMarks.Interval = 10
            scale8.MinPin.Name = "MinPin"
            scale8.MinPin.Visible = False
            scale8.MinValue = 1000
            scale8.Name = "Scale5"
            pointer8.CapFillColor.BorderColor = Color.DimGray
            pointer8.CapFillColor.BorderWidth = 1
            pointer8.CapFillColor.Color1 = Color.WhiteSmoke
            pointer8.CapFillColor.Color2 = Color.DimGray
            pointer8.FillColor.BorderColor = Color.DimGray
            pointer8.FillColor.BorderWidth = 1
            pointer8.FillColor.Color1 = Color.Red
            pointer8.Name = "Pointer1"
            pointer8.Placement = DisplayPlacement.Far
            pointer8.ScaleOffset = 0.05!
            pointer8.ThermoBackColor.BorderColor = Color.Black
            pointer8.ThermoBackColor.BorderWidth = 1
            pointer8.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale8.Pointers.AddRange(New GaugePointer() { pointer8 })
            section5.FillColor.Color1 = Color.Crimson
            section5.Name = "Section1"
            section6.EndValue = 1500
            section6.FillColor.Color1 = Color.Lime
            section6.Name = "Section2"
            section6.StartValue = 1200
            section7.EndValue = 0
            section7.FillColor.Color1 = Color.Crimson
            section7.Name = "Section3"
            section7.StartValue = 0
            scale8.Sections.AddRange(New GaugeSection() { section5, section6, section7 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale8.Size = ef2
            scale8.Visible = False
            Dim obj18 As Object = manager.GetObject("GaugeLinearScale6.Location")
            If (Not obj18 Is Nothing) Then
                tf18 = DirectCast(obj18, PointF*)
            Else
                Dim local18 As Object = obj18
                tf18 = tf
            End If
            scale9.Location = tf18
            scale9.MajorTickMarks.Interval = 100
            scale9.MaxPin.Name = "MaxPin"
            scale9.MaxPin.Visible = False
            scale9.MaxValue = 1500
            scale9.MinorTickMarks.Interval = 10
            scale9.MinPin.Name = "MinPin"
            scale9.MinPin.Visible = False
            scale9.MinValue = 1000
            scale9.Name = "Scale6"
            pointer9.CapFillColor.BorderColor = Color.DimGray
            pointer9.CapFillColor.BorderWidth = 1
            pointer9.CapFillColor.Color1 = Color.WhiteSmoke
            pointer9.CapFillColor.Color2 = Color.DimGray
            pointer9.FillColor.BorderColor = Color.DimGray
            pointer9.FillColor.BorderWidth = 1
            pointer9.FillColor.Color1 = Color.Red
            pointer9.Name = "Pointer1"
            pointer9.Placement = DisplayPlacement.Far
            pointer9.ScaleOffset = 0.05!
            pointer9.ThermoBackColor.BorderColor = Color.Black
            pointer9.ThermoBackColor.BorderWidth = 1
            pointer9.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale9.Pointers.AddRange(New GaugePointer() { pointer9 })
            section8.FillColor.Color1 = Color.Crimson
            section8.Name = "Section1"
            section9.EndValue = 1500
            section9.FillColor.Color1 = Color.Lime
            section9.Name = "Section2"
            section9.StartValue = 1200
            section10.EndValue = 0
            section10.FillColor.Color1 = Color.Crimson
            section10.Name = "Section3"
            section10.StartValue = 0
            scale9.Sections.AddRange(New GaugeSection() { section8, section9, section10 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale9.Size = ef2
            scale9.Visible = False
            Dim obj19 As Object = manager.GetObject("GaugeLinearScale7.Location")
            If (Not obj19 Is Nothing) Then
                tf19 = DirectCast(obj19, PointF*)
            Else
                Dim local19 As Object = obj19
                tf19 = tf
            End If
            scale10.Location = tf19
            scale10.MajorTickMarks.Interval = 100
            scale10.MaxPin.Name = "MaxPin"
            scale10.MaxPin.Visible = False
            scale10.MaxValue = 1500
            scale10.MinorTickMarks.Interval = 10
            scale10.MinPin.Name = "MinPin"
            scale10.MinPin.Visible = False
            scale10.MinValue = 1000
            scale10.Name = "Scale7"
            pointer10.CapFillColor.BorderColor = Color.DimGray
            pointer10.CapFillColor.BorderWidth = 1
            pointer10.CapFillColor.Color1 = Color.WhiteSmoke
            pointer10.CapFillColor.Color2 = Color.DimGray
            pointer10.FillColor.BorderColor = Color.DimGray
            pointer10.FillColor.BorderWidth = 1
            pointer10.FillColor.Color1 = Color.Red
            pointer10.Name = "Pointer1"
            pointer10.Placement = DisplayPlacement.Far
            pointer10.ScaleOffset = 0.05!
            pointer10.ThermoBackColor.BorderColor = Color.Black
            pointer10.ThermoBackColor.BorderWidth = 1
            pointer10.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale10.Pointers.AddRange(New GaugePointer() { pointer10 })
            section11.FillColor.Color1 = Color.Crimson
            section11.Name = "Section1"
            section13.EndValue = 1500
            section13.FillColor.Color1 = Color.Lime
            section13.Name = "Section2"
            section13.StartValue = 1200
            section14.EndValue = 0
            section14.FillColor.Color1 = Color.Crimson
            section14.Name = "Section3"
            section14.StartValue = 0
            scale10.Sections.AddRange(New GaugeSection() { section11, section13, section14 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale10.Size = ef2
            scale10.Visible = False
            label2.Layout.AdaptiveLabel = True
            label2.Layout.Placement = DisplayPlacement.Center
            label2.Layout.ScaleOffset = 0.3!
            label2.Name = "Label1fgfdg"
            label2.Text = "asdf gfhdfgdfgdPWM"
            label2.Value = 1000
            scale11.CustomLabels.AddRange(New GaugeCustomLabel() { label2 })
            Dim obj20 As Object = manager.GetObject("GaugeLinearScale8.Location")
            If (Not obj20 Is Nothing) Then
                tf20 = DirectCast(obj20, PointF*)
            Else
                Dim local20 As Object = obj20
                tf20 = tf
            End If
            scale11.Location = tf20
            scale11.MajorTickMarks.Interval = 100
            scale11.MaxPin.Name = "MaxPin"
            scale11.MaxPin.Visible = False
            scale11.MaxValue = 1500
            scale11.MinorTickMarks.Interval = 10
            scale11.MinPin.Name = "MinPin"
            scale11.MinPin.Visible = False
            scale11.MinValue = 1000
            scale11.Name = "Scale8"
            pointer11.CapFillColor.BorderColor = Color.DimGray
            pointer11.CapFillColor.BorderWidth = 1
            pointer11.CapFillColor.Color1 = Color.WhiteSmoke
            pointer11.CapFillColor.Color2 = Color.DimGray
            pointer11.FillColor.BorderColor = Color.DimGray
            pointer11.FillColor.BorderWidth = 1
            pointer11.FillColor.Color1 = Color.Red
            pointer11.Name = "Pointer1"
            pointer11.Placement = DisplayPlacement.Far
            pointer11.ScaleOffset = 0.05!
            pointer11.ThermoBackColor.BorderColor = Color.Black
            pointer11.ThermoBackColor.BorderWidth = 1
            pointer11.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale11.Pointers.AddRange(New GaugePointer() { pointer11 })
            section15.FillColor.Color1 = Color.Crimson
            section15.Name = "Section1"
            section16.EndValue = 1500
            section16.FillColor.Color1 = Color.Lime
            section16.Name = "Section2"
            section16.StartValue = 1200
            section17.EndValue = 0
            section17.FillColor.Color1 = Color.Crimson
            section17.Name = "Section3"
            section17.StartValue = 0
            scale11.Sections.AddRange(New GaugeSection() { section15, section16, section17 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale11.Size = ef2
            scale11.Visible = False
            scale11.Width = 0.06!
            label3.Layout.AdaptiveLabel = True
            label3.Layout.Placement = DisplayPlacement.Center
            label3.Layout.ScaleOffset = 0.3!
            label3.Name = "Label1fgfdg"
            label3.Text = "asdf gfhdfgdfgdPWM"
            label3.Value = 1000
            scale12.CustomLabels.AddRange(New GaugeCustomLabel() { label3 })
            Dim obj21 As Object = manager.GetObject("GaugeLinearScale9.Location")
            If (Not obj21 Is Nothing) Then
                tf21 = DirectCast(obj21, PointF*)
            Else
                Dim local21 As Object = obj21
                tf21 = tf
            End If
            scale12.Location = tf21
            scale12.MajorTickMarks.Interval = 100
            scale12.MaxPin.Name = "MaxPin"
            scale12.MaxPin.Visible = False
            scale12.MaxValue = 1500
            scale12.MinorTickMarks.Interval = 10
            scale12.MinPin.Name = "MinPin"
            scale12.MinPin.Visible = False
            scale12.MinValue = 1000
            scale12.Name = "Scale9"
            pointer12.CapFillColor.BorderColor = Color.DimGray
            pointer12.CapFillColor.BorderWidth = 1
            pointer12.CapFillColor.Color1 = Color.WhiteSmoke
            pointer12.CapFillColor.Color2 = Color.DimGray
            pointer12.FillColor.BorderColor = Color.DimGray
            pointer12.FillColor.BorderWidth = 1
            pointer12.FillColor.Color1 = Color.Red
            pointer12.Name = "Pointer1"
            pointer12.Placement = DisplayPlacement.Far
            pointer12.ScaleOffset = 0.05!
            pointer12.ThermoBackColor.BorderColor = Color.Black
            pointer12.ThermoBackColor.BorderWidth = 1
            pointer12.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale12.Pointers.AddRange(New GaugePointer() { pointer12 })
            section18.FillColor.Color1 = Color.Crimson
            section18.Name = "Section1"
            section19.EndValue = 1500
            section19.FillColor.Color1 = Color.Lime
            section19.Name = "Section2"
            section19.StartValue = 1200
            section20.EndValue = 0
            section20.FillColor.Color1 = Color.Crimson
            section20.Name = "Section3"
            section20.StartValue = 0
            scale12.Sections.AddRange(New GaugeSection() { section18, section19, section20 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale12.Size = ef2
            scale12.Visible = False
            scale12.Width = 0.06!
            label4.Layout.AdaptiveLabel = True
            label4.Layout.Placement = DisplayPlacement.Center
            label4.Layout.ScaleOffset = 0.3!
            label4.Name = "Label1fgfdg"
            label4.Text = "asdf gfhdfgdfgdPWM"
            label4.Value = 1000
            scale2.CustomLabels.AddRange(New GaugeCustomLabel() { label4 })
            Dim obj22 As Object = manager.GetObject("GaugeLinearScale10.Location")
            If (Not obj22 Is Nothing) Then
                tf22 = DirectCast(obj22, PointF*)
            Else
                Dim local22 As Object = obj22
                tf22 = tf
            End If
            scale2.Location = tf22
            scale2.MajorTickMarks.Interval = 100
            scale2.MaxPin.Name = "MaxPin"
            scale2.MaxPin.Visible = False
            scale2.MaxValue = 1500
            scale2.MinorTickMarks.Interval = 10
            scale2.MinPin.Name = "MinPin"
            scale2.MinPin.Visible = False
            scale2.MinValue = 1000
            scale2.Name = "Scale10"
            pointer2.CapFillColor.BorderColor = Color.DimGray
            pointer2.CapFillColor.BorderWidth = 1
            pointer2.CapFillColor.Color1 = Color.WhiteSmoke
            pointer2.CapFillColor.Color2 = Color.DimGray
            pointer2.FillColor.BorderColor = Color.DimGray
            pointer2.FillColor.BorderWidth = 1
            pointer2.FillColor.Color1 = Color.Red
            pointer2.Name = "Pointer1"
            pointer2.Placement = DisplayPlacement.Far
            pointer2.ScaleOffset = 0.05!
            pointer2.ThermoBackColor.BorderColor = Color.Black
            pointer2.ThermoBackColor.BorderWidth = 1
            pointer2.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale2.Pointers.AddRange(New GaugePointer() { pointer2 })
            section21.FillColor.Color1 = Color.Crimson
            section21.Name = "Section1"
            section22.EndValue = 1500
            section22.FillColor.Color1 = Color.Lime
            section22.Name = "Section2"
            section22.StartValue = 1200
            section24.EndValue = 0
            section24.FillColor.Color1 = Color.Crimson
            section24.Name = "Section3"
            section24.StartValue = 0
            scale2.Sections.AddRange(New GaugeSection() { section21, section22, section24 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale2.Size = ef2
            scale2.Visible = False
            scale2.Width = 0.06!
            label5.Layout.AdaptiveLabel = True
            label5.Layout.Placement = DisplayPlacement.Center
            label5.Layout.ScaleOffset = 0.3!
            label5.Name = "Label1fgfdg"
            label5.Text = "asdf gfhdfgdfgdPWM"
            label5.Value = 1000
            scale3.CustomLabels.AddRange(New GaugeCustomLabel() { label5 })
            Dim obj23 As Object = manager.GetObject("GaugeLinearScale11.Location")
            If (Not obj23 Is Nothing) Then
                tf23 = DirectCast(obj23, PointF*)
            Else
                Dim local23 As Object = obj23
                tf23 = tf
            End If
            scale3.Location = tf23
            scale3.MajorTickMarks.Interval = 100
            scale3.MaxPin.Name = "MaxPin"
            scale3.MaxPin.Visible = False
            scale3.MaxValue = 1500
            scale3.MinorTickMarks.Interval = 10
            scale3.MinPin.Name = "MinPin"
            scale3.MinPin.Visible = False
            scale3.MinValue = 1000
            scale3.Name = "Scale11"
            pointer3.CapFillColor.BorderColor = Color.DimGray
            pointer3.CapFillColor.BorderWidth = 1
            pointer3.CapFillColor.Color1 = Color.WhiteSmoke
            pointer3.CapFillColor.Color2 = Color.DimGray
            pointer3.FillColor.BorderColor = Color.DimGray
            pointer3.FillColor.BorderWidth = 1
            pointer3.FillColor.Color1 = Color.Red
            pointer3.Name = "Pointer1"
            pointer3.Placement = DisplayPlacement.Far
            pointer3.ScaleOffset = 0.05!
            pointer3.ThermoBackColor.BorderColor = Color.Black
            pointer3.ThermoBackColor.BorderWidth = 1
            pointer3.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale3.Pointers.AddRange(New GaugePointer() { pointer3 })
            section25.FillColor.Color1 = Color.Crimson
            section25.Name = "Section1"
            section26.EndValue = 1500
            section26.FillColor.Color1 = Color.Lime
            section26.Name = "Section2"
            section26.StartValue = 1200
            section27.EndValue = 0
            section27.FillColor.Color1 = Color.Crimson
            section27.Name = "Section3"
            section27.StartValue = 0
            scale3.Sections.AddRange(New GaugeSection() { section25, section26, section27 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale3.Size = ef2
            scale3.Visible = False
            scale3.Width = 0.06!
            label6.Layout.AdaptiveLabel = True
            label6.Layout.Placement = DisplayPlacement.Center
            label6.Layout.ScaleOffset = 0.3!
            label6.Name = "Label1fgfdg"
            label6.Text = "asdf gfhdfgdfgdPWM"
            label6.Value = 1000
            scale4.CustomLabels.AddRange(New GaugeCustomLabel() { label6 })
            Dim obj24 As Object = manager.GetObject("GaugeLinearScale12.Location")
            If (Not obj24 Is Nothing) Then
                tf24 = DirectCast(obj24, PointF*)
            Else
                Dim local24 As Object = obj24
                tf24 = tf
            End If
            scale4.Location = tf24
            scale4.MajorTickMarks.Interval = 100
            scale4.MaxPin.Name = "MaxPin"
            scale4.MaxPin.Visible = False
            scale4.MaxValue = 1500
            scale4.MinorTickMarks.Interval = 10
            scale4.MinPin.Name = "MinPin"
            scale4.MinPin.Visible = False
            scale4.MinValue = 1000
            scale4.Name = "Scale12"
            pointer4.CapFillColor.BorderColor = Color.DimGray
            pointer4.CapFillColor.BorderWidth = 1
            pointer4.CapFillColor.Color1 = Color.WhiteSmoke
            pointer4.CapFillColor.Color2 = Color.DimGray
            pointer4.FillColor.BorderColor = Color.DimGray
            pointer4.FillColor.BorderWidth = 1
            pointer4.FillColor.Color1 = Color.Red
            pointer4.Name = "Pointer1"
            pointer4.Placement = DisplayPlacement.Far
            pointer4.ScaleOffset = 0.05!
            pointer4.ThermoBackColor.BorderColor = Color.Black
            pointer4.ThermoBackColor.BorderWidth = 1
            pointer4.ThermoBackColor.Color1 = Color.FromArgb(100, 60, 60, 60)
            scale4.Pointers.AddRange(New GaugePointer() { pointer4 })
            section28.FillColor.Color1 = Color.Crimson
            section28.Name = "Section1"
            section29.EndValue = 1500
            section29.FillColor.Color1 = Color.Lime
            section29.Name = "Section2"
            section29.StartValue = 1200
            section30.EndValue = 0
            section30.FillColor.Color1 = Color.Crimson
            section30.Name = "Section3"
            section30.StartValue = 0
            scale4.Sections.AddRange(New GaugeSection() { section28, section29, section30 })
            ef2 = New SizeF(0.4!, 0.25!)
            scale4.Size = ef2
            scale4.Visible = False
            scale4.Width = 0.06!
            Dim scaleArray As GaugeLinearScale() = New GaugeLinearScale() { scale, scale5, scale6, scale7, scale8, scale9, scale10, scale11, scale12 }
            scaleArray(9) = scale2
            scaleArray(10) = scale3
            scaleArray(11) = scale4
            Me.gagPos1.LinearScales.AddRange(scaleArray)
            Dim point2 As New Point(0, 0)
            Me.gagPos1.Location = point2
            Me.gagPos1.Name = "gagPos1"
            Dim size2 As New Size(&H35E, &H1B6)
            Me.gagPos1.Size = size2
            Me.gagPos1.TabIndex = 1
            Me.gagPos1.Text = "GaugeControl1"
            ef2 = New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.gagPos1)
            Me.Name = "ctrlMechChecks"
            size2 = New Size(&H35E, &H1B6)
            Me.Size = size2
            Me.gagPos1.EndInit
            Me.ResumeLayout(False)
        End Sub


        ' Properties
        Friend Overridable Property gagPos1 As GaugeControl
            <DebuggerNonUserCode> _
            Get
                Return Me._gagPos1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As GaugeControl)
                Me._gagPos1 = WithEventsValue
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("gagPos1")> _
        Private _gagPos1 As GaugeControl
        Private _CheckList As List(Of PrinterMechChecks)
    End Class
End Namespace

