Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports DevComponents.DotNetBar.SuperGrid
Imports FUEL.FS
Imports FUEL.My
Imports FUEL.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Namespace FUEL
    <DesignerGenerated> _
    Public Class dlgPSTResults
        Inherits MetroForm
        ' Methods
        Public Sub New(ByVal myPST As PST)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.dlgPSTResults_Load)
            AddHandler MyBase.MouseClick, New MouseEventHandler(AddressOf Me.dlgPSTResults_MouseClick)
            dlgPSTResults.__ENCAddToList(Me)
            Me.dtHistory = New DataTable
            Me.TestStatus = True
            Me.InitializeComponent
            Me.PST = myPST
        End Sub

        Public Sub New(ByVal myPST As PST, ByVal ShowHistory As Boolean)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.dlgPSTResults_Load)
            AddHandler MyBase.MouseClick, New MouseEventHandler(AddressOf Me.dlgPSTResults_MouseClick)
            dlgPSTResults.__ENCAddToList(Me)
            Me.dtHistory = New DataTable
            Me.TestStatus = True
            Me.InitializeComponent
            Me.MetroShell1.CaptionVisible = False
            Me.MetroStatusBar1.Visible = False
            Me.MetroTabItem3.Visible = ShowHistory
            Me.PST = myPST
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock dlgPSTResults.__ENCList
                If (dlgPSTResults.__ENCList.Count = dlgPSTResults.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (dlgPSTResults.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            dlgPSTResults.__ENCList.RemoveRange(index, (dlgPSTResults.__ENCList.Count - index))
                            dlgPSTResults.__ENCList.Capacity = dlgPSTResults.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = dlgPSTResults.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                dlgPSTResults.__ENCList(index) = dlgPSTResults.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                dlgPSTResults.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub AddHistoryData(ByVal MetricName As String)
            Try 
                ChartUtilities.ClearChart(Me.Chart3)
                Dim dataSource As New List(Of HistoryData)
                Dim summaryFileName As String = Me.PST.SummaryFileName
                Dim str As String = ","
                Dim flag As Boolean = MyProject.Computer.FileSystem.FileExists(summaryFileName)
                If flag Then
                    Dim num18 As Integer
                    Dim num As Integer = 0
                    Dim objA As New TextFieldParser(summaryFileName)
                    Try 
                        objA.SetDelimiters(New String() { str })
                        Dim index As Integer = 0
                        Do While True
                            flag = Not objA.EndOfData
                            If Not flag Then
                                Exit Do
                            End If
                            Dim source As String() = objA.ReadFields
                            If (objA.LineNumber <> 2) Then
                                Dim item As New HistoryData With { _
                                    .Indexer = num, _
                                    .RunChartYVal = source(index) _
                                }
                                dataSource.Add(item)
                                num += 1
                                Continue Do
                            End If
                            Dim array As String() = New String(((Enumerable.Count(Of String)(source) - 1) + 1)  - 1) {}
                            Dim num15 As Integer = (Enumerable.Count(Of String)(source) - 1)
                            Dim num3 As Integer = 0
                            Do While True
                                num18 = num15
                                If (num3 > num18) Then
                                    index = Array.IndexOf(Of String)(array, MetricName)
                                    Exit Do
                                End If
                                array(num3) = source(num3)
                                num3 += 1
                            Loop
                        Loop
                    Finally
                        If Not Object.ReferenceEquals(objA, Nothing) Then
                            DirectCast(objA, IDisposable).Dispose
                        End If
                    End Try
                    flag = Versioned.IsNumeric(dataSource(0).RunChartYVal)
                    If Not flag Then
                        Interaction.MsgBox("Invalid non-numeric value selected.", MsgBoxStyle.Critical, Nothing)
                    Else
                        Me.Chart3.Series.Add("KMax")
                        Me.Chart3.Series("KMax").Points.DataBind(dataSource, "Indexer", "RunChartYVal", Nothing)
                        Me.Chart3.Series("KMax").Enabled = False
                        Me.Chart3.DataManipulator.Group("AVE", 4, IntervalType.Number, "KMax", "Ẋ")
                        Dim num5 As Integer = 0
                        Dim num16 As Integer = (Me.Chart3.Series("Ẋ").Points.Count - 1)
                        Dim num13 As Integer = 0
                        Do While True
                            num18 = num16
                            If (num13 > num18) Then
                                Dim enumerator As IEnumerator(Of DataPoint)
                                Me.Chart3.DataManipulator.Group("HiLo", 4, IntervalType.Number, "KMax", "HiLo")
                                Me.Chart3.Series("HiLo").Enabled = False
                                Dim list2 As New List(Of ChartData)
                                Dim num4 As Long = 0
                                Try 
                                    enumerator = Me.Chart3.Series("HiLo").Points.GetEnumerator
                                    Do While True
                                        flag = enumerator.MoveNext
                                        If Not flag Then
                                            Exit Do
                                        End If
                                        Dim current As DataPoint = enumerator.Current
                                        Dim data2 As New ChartData With { _
                                            .YVal = (Me.Chart3.Series("HiLo").Points(CInt(num4)).YValues(0) - Me.Chart3.Series("HiLo").Points(CInt(num4)).YValues(1)), _
                                            .Indexer = num4 _
                                        }
                                        list2.Add(data2)
                                        num4 = (num4 + 1)
                                    Loop
                                Finally
                                    If Not Object.ReferenceEquals(enumerator, Nothing) Then
                                        enumerator.Dispose
                                    End If
                                End Try
                                Me.Chart3.Series.Add("r")
                                Dim series2 As Series = Me.Chart3.Series("r")
                                series2.Points.DataBind(list2, "Indexer", "YVal", Nothing)
                                series2.ChartArea = "ChartArea2"
                                series2 = Nothing
                                Dim intervalOffset As Double = Me.Chart3.DataManipulator.Statistics.Mean("Ẋ")
                                Dim num7 As Double = Me.Chart3.DataManipulator.Statistics.Mean("r")
                                Dim num12 As Double = (intervalOffset + (0.729 * num7))
                                Dim num11 As Double = (intervalOffset - (0.729 * num7))
                                Dim num9 As Double = (num7 * 2.282)
                                Dim num8 As Double = (num7 * 0)
                                Dim item As StripLine = ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, num11, (num12 - num11), Color.Orange)
                                Me.Chart3.ChartAreas("ChartArea1").AxisY.StripLines.Add(item)
                                Dim line3 As StripLine = ChartUtilities.GetStripLine("Ẍ", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, intervalOffset, Color.Red, 2)
                                Me.Chart3.ChartAreas("ChartArea1").AxisY.StripLines.Add(line3)
                                Dim line2 As StripLine = ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, num8, (num9 - num8), Color.Orange)
                                Me.Chart3.ChartAreas("ChartArea2").AxisY.StripLines.Add(line2)
                                Dim line4 As StripLine = ChartUtilities.GetStripLine("Ṙ", TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.White, num7, Color.Red, 2)
                                Me.Chart3.ChartAreas("ChartArea2").AxisY.StripLines.Add(line4)
                                ChartUtilities.AddChartTitle("Ẋ", Me.Chart3, "ChartArea1", Docking.Top)
                                ChartUtilities.AddChartTitle("Ṙ", Me.Chart3, "ChartArea2", Docking.Top)
                                Me.Chart3.Legends(0).Enabled = False
                                Me.Chart3.ChartAreas("ChartArea1").AxisY.Title = "Max Pressure"
                                Me.Chart3.ChartAreas("ChartArea2").AxisY.Title = "Max Pressure"
                                Me.Chart3.ChartAreas("ChartArea1").AxisX.Title = "Sample Group"
                                Me.Chart3.ChartAreas("ChartArea2").AxisX.Title = "Sample Group"
                                Me.Chart3.ChartAreas("ChartArea1").AxisY.Minimum = Math.Min(Math.Round(CDbl((num11 - (num11 * 0.1))), 0), Math.Round(CDbl((Me.Chart3.Series("Ẋ").Points.FindMinByValue.YValues(0) - (Me.Chart3.Series("Ẋ").Points.FindMinByValue.YValues(0) * 0.1))), 0))
                                Me.Chart3.ChartAreas("ChartArea1").AxisY.Maximum = Math.Max(Math.Round(CDbl((num12 + (num12 * 0.1))), 0), Math.Round(CDbl((Me.Chart3.Series("Ẋ").Points.FindMaxByValue.YValues(0) + (Me.Chart3.Series("Ẋ").Points.FindMaxByValue.YValues(0) * 0.1))), 0))
                                Me.Chart3.ChartAreas("ChartArea2").AxisY.Maximum = Math.Max(Math.Round(CDbl((num9 + (num9 * 0.1))), 0), Math.Round(CDbl((Me.Chart3.Series("r").Points.FindMaxByValue.YValues(0) + (Me.Chart3.Series("r").Points.FindMaxByValue.YValues(0) * 0.1))), 0))
                                Me.Chart3.ChartAreas("ChartArea1").AxisX.Minimum = 0
                                Me.Chart3.ChartAreas("ChartArea2").AxisX.Minimum = 0
                                Dim axisX As Axis = Me.Chart3.ChartAreas("ChartArea1").AxisX
                                axisX.MajorGrid.Interval = CInt(Math.Round(CDbl((0.2 * Me.Chart3.Series("Ẋ").Points.Count))))
                                axisX.MajorTickMark.Interval = Me.Chart3.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval
                                axisX.Interval = Me.Chart3.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval
                                axisX.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4, CInt(Math.Round(Me.Chart3.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval)))
                                axisX.MinorGrid.LineColor = Color.LightGray
                                axisX.MinorGrid.Enabled = True
                                axisX = Nothing
                                Dim axis2 As Axis = Me.Chart3.ChartAreas("ChartArea2").AxisX
                                axis2.MajorGrid.Interval = CInt(Math.Round(CDbl((0.2 * Me.Chart3.Series("r").Points.Count))))
                                axis2.MajorTickMark.Interval = Me.Chart3.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval
                                axis2.Interval = Me.Chart3.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval
                                axis2.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4, CInt(Math.Round(Me.Chart3.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval)))
                                axis2.MinorGrid.LineColor = Color.LightGray
                                axis2.MinorGrid.Enabled = True
                                axis2 = Nothing
                                Dim num17 As Integer = (Me.Chart3.Series.Count - 1)
                                Dim num14 As Integer = 0
                                Do While True
                                    num18 = num17
                                    If (num14 > num18) Then
                                        Dim count As Integer = Me.Chart3.Series("KMax").Points.Count
                                        Me.lblHistory_TotalUnits.Text = ("Total Units in History: " & Conversions.ToString(count))
                                        Exit Do
                                    End If
                                    Dim series3 As Series = Me.Chart3.Series(num14)
                                    series3.ChartType = SeriesChartType.Line
                                    series3.BorderWidth = 1
                                    series3.Color = Color.Blue
                                    series3.MarkerStyle = MarkerStyle.Circle
                                    series3.MarkerSize = 6
                                    series3.MarkerColor = Color.Blue
                                    series3 = Nothing
                                    num14 += 1
                                Loop
                                Exit Do
                            End If
                            Me.Chart3.Series("Ẋ").Points(num13).XValue = num5
                            num5 += 1
                            num13 += 1
                        Loop
                    End If
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddHistoryData2(ByVal MetricName As String)
            Try 
                Dim enumerator As IEnumerator(Of Series)
                Me.Chart4.Series.Clear
                Me.Chart4.Series.Add("0")
                Me.Chart4.DataSource = Me.dtHistory
                Me.Chart4.Series(0).XValueMember = "Test_Date"
                Me.Chart4.Series(0).YValueMembers = "K_MAX_PRESSURE"
                Try 
                    enumerator = Me.Chart4.Series.GetEnumerator
                    Do While True
                        If Not enumerator.MoveNext Then
                            Exit Do
                        End If
                        Dim current As Series = enumerator.Current
                        current.ChartType = SeriesChartType.Line
                        current.BorderWidth = 4
                    Loop
                Finally
                    If Not Object.ReferenceEquals(enumerator, Nothing) Then
                        enumerator.Dispose
                    End If
                End Try
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddHistoryData3(ByVal xVal As String, ByVal yVal As String, ByVal groupVal As String)
            Try 
                Dim enumerator As IEnumerator(Of Series)
                Me.Chart4.Series.Clear
                Me.Chart4.DataBindCrossTable(Me.dtHistory.AsEnumerable(), groupVal, xVal, yVal, Nothing)
                Try 
                    enumerator = Me.Chart4.Series.GetEnumerator
                    Do While True
                        If Not enumerator.MoveNext Then
                            Exit Do
                        End If
                        Dim current As Series = enumerator.Current
                        current.ChartType = SeriesChartType.Line
                        current.BorderWidth = 4
                    Loop
                Finally
                    If Not Object.ReferenceEquals(enumerator, Nothing) Then
                        enumerator.Dispose
                    End If
                End Try
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddMechChecks()
            Try 
                Dim checks As New ctrlMechChecks(Me.PST.MechChecks) With { _
                    .Visible = True, _
                    .Dock = DockStyle.Fill _
                }
                Me.MetroTabPanel4.Controls.Add(checks)
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Logging.AddLogEntry(Me, ("Error adding mech checks. " & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & ex.ToString), EventLogEntryType.Error, 1)
                Interaction.MsgBox("Error loading Mech checks. This may invalidate results display." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Error details have been added to the log.", MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddPSTData()
            Try 
                Me.Chart1.Series.Add("Black")
                Dim series As Series = Me.Chart1.Series("Black")
                series.ChartArea = "ChartArea1"
                series.ChartType = SeriesChartType.Area
                series.Color = Color.FromArgb(&HD7, 14, 5, &HC7)
                series = Nothing
                Me.Chart2.Series.Add("Color")
                Dim series2 As Series = Me.Chart2.Series("Color")
                series2.ChartArea = "ChartArea1"
                series2.ChartType = SeriesChartType.Area
                series2.Color = Color.FromArgb(240, 0, &H99, 0)
                series2 = Nothing
                Me.Chart1.Series(0).Points.DataBind(Me.PST.PTraceBlack, "X", "Y", Nothing)
                Me.Chart2.Series(0).Points.DataBind(Me.PST.PTraceColor, "X", "Y", Nothing)
                Me.FormatPSTChartArea(Me.Chart1, "ChartArea1")
                Me.FormatPSTChartArea(Me.Chart2, "ChartArea1")
                Me.SetChartAxisValues(Me.Chart1, "ChartArea1", 0, Me.PST.KDataPoints)
                Me.SetChartAxisValues(Me.Chart2, "ChartArea1", 0, Me.PST.CDataPoints)
                Me.SetPSTSpecLabelText(Channels.Black, Me.PST.SpecsBlack)
                Me.SetPSTSpecLabelText(Channels.Color, Me.PST.SpecsColor)
                Dim maxPressure As Double = Me.PST.KResults.Val.MaxPressure
                Me.lblMeasPressure_K.Text = Conversions.ToString(Math.Round(maxPressure, 1))
                Dim leak As Double = Me.PST.KResults.Val.Leak
                Me.lblMeasLeak_K.Text = Conversions.ToString(Math.Round(leak, 1))
                If (Me.PST.KResults.PF.VentDeltaPMin < 1) Then
                    Me.lblMeasVent_K.Text = Conversions.ToString(Math.Round(Me.PST.KResults.Val.VentDeltaP, 3))
                ElseIf (Me.PST.KResults.PF.VentDeltaPMin = 1) Then
                    Me.lblMeasVent_K.Text = (Conversions.ToString(Math.Round(Me.PST.KResults.Val.VentDeltaP, 0)) & ", " & Conversions.ToString(Math.Round(CDbl((Me.PST.KDataPoints.PT3Y - Me.PST.KDataPoints.PT4Y)), 3)))
                End If
                Me.lblMeasTubeEvac_K.Text = Conversions.ToString(Math.Round(Me.PST.KResults.Val.TubeEvacDeltaPressure, 3))
                Dim num2 As Double = Me.PST.CResults.Val.MaxPressure
                Me.lblMeasPressure_C.Text = Conversions.ToString(Math.Round(num2, 1))
                Dim num As Double = Me.PST.CResults.Val.Leak
                Me.lblMeasLeak_C.Text = Conversions.ToString(Math.Round(num, 1))
                If (Me.PST.CResults.PF.VentDeltaPMin < 1) Then
                    Me.lblMeasVent_C.Text = Conversions.ToString(Math.Round(Me.PST.CResults.Val.VentDeltaP, 3))
                ElseIf (Me.PST.CResults.PF.VentDeltaPMin = 1) Then
                    Me.lblMeasVent_C.Text = (Conversions.ToString(Math.Round(Me.PST.CResults.Val.VentDeltaP, 0)) & ", " & Conversions.ToString(Math.Round(CDbl((Me.PST.CDataPoints.PT3Y - Me.PST.CDataPoints.PT4Y)), 3)))
                End If
                Me.lblMeasTubeEvac_C.Text = Conversions.ToString(Math.Round(Me.PST.CResults.Val.TubeEvacDeltaPressure, 3))
                If Me.PST.KResults.PF.MaxPressure Then
                    Me.lblTitlePressure_K.BackColor = Color.Lime
                    Me.lblMeasPressure_K.BackColor = Color.Lime
                    Me.lblSpecPressure_K.BackColor = Color.Lime
                Else
                    Me.lblTitlePressure_K.BackColor = Color.Red
                    Me.lblMeasPressure_K.BackColor = Color.Red
                    Me.lblSpecPressure_K.BackColor = Color.Red
                    Me.lblSummary_PSTBlack.Text = "Black: Failed"
                    Me.lblSummary_PSTBlack.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart1, "ChartArea1", AxisName.Y, CDbl((Me.PST.SpecsBlack.PressureMax - Me.PST.SpecsBlack.PressureMin)), CDbl(Me.PST.SpecsBlack.PressureMin), "Max Pressure Range")
                End If
                If Me.PST.KResults.PF.Leak Then
                    Me.lblTitleLeak_K.BackColor = Color.Lime
                    Me.lblMeasLeak_K.BackColor = Color.Lime
                    Me.lblSpecLeak_K.BackColor = Color.Lime
                Else
                    Me.lblTitleLeak_K.BackColor = Color.Red
                    Me.lblMeasLeak_K.BackColor = Color.Red
                    Me.lblSpecLeak_K.BackColor = Color.Red
                    Me.lblSummary_PSTBlack.Text = "Black: Failed"
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.lblSummary_PSTBlack.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Dim num5 As Double = Me.PST.KDataPoints.PT2Y
                    If Me.PST.SpecsBlack.AllowWetPHA Then
                        num5 = (Me.PST.KDataPoints.PT6Y - Me.PST.SpecsBlack.LeakMin)
                    End If
                    Me.AddStripLine(Me.Chart1, "ChartArea1", AxisName.Y, CDbl((Me.PST.SpecsBlack.LeakMax - Me.PST.SpecsBlack.LeakMin)), (num5 - (Me.PST.SpecsBlack.LeakMax + Math.Abs(Me.PST.SpecsBlack.LeakMin))), "Leak Range")
                End If
                If (Me.PST.KResults.PF.VentDeltaPMin <> -1) Then
                    Me.lblTitleVent_K.BackColor = Color.Lime
                    Me.lblMeasVent_K.BackColor = Color.Lime
                    Me.lblSpecVent_K.BackColor = Color.Lime
                Else
                    Me.lblTitleVent_K.BackColor = Color.Red
                    Me.lblMeasVent_K.BackColor = Color.Red
                    Me.lblSpecVent_K.BackColor = Color.Red
                    Me.lblSummary_PSTBlack.Text = "Black: Failed"
                    Me.lblSummary_PSTBlack.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart1, "ChartArea1", AxisName.X, Me.PST.SpecsBlack.VentTime, Me.PST.KDataPoints.PT3X, "Vent Range")
                End If
                If Me.PST.KResults.PF.TubeEvacDeltaPressure Then
                    Me.lblTitleTubeEvac_k.BackColor = Color.Lime
                    Me.lblMeasTubeEvac_K.BackColor = Color.Lime
                    Me.lblSpecTubeEvac_K.BackColor = Color.Lime
                Else
                    Me.lblTitleTubeEvac_k.BackColor = Color.Red
                    Me.lblMeasTubeEvac_K.BackColor = Color.Red
                    Me.lblSpecTubeEvac_K.BackColor = Color.Red
                    Me.lblSummary_PSTBlack.Text = "Black: Failed"
                    Me.lblSummary_PSTBlack.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart1, "ChartArea1", AxisName.Y, CDbl(Math.Abs(Me.PST.SpecsBlack.TubeEvacDeltaPressure)), (Me.PST.KDataPoints.PT8Y + Math.Abs(Me.PST.SpecsBlack.TubeEvacDeltaPressure)), "Tube Evac")
                End If
                If Me.PST.CResults.PF.MaxPressure Then
                    Me.lblTitlePressure_C.BackColor = Color.Lime
                    Me.lblMeasPressure_C.BackColor = Color.Lime
                    Me.lblSpecPressure_C.BackColor = Color.Lime
                Else
                    Me.lblTitlePressure_C.BackColor = Color.Red
                    Me.lblMeasPressure_C.BackColor = Color.Red
                    Me.lblSpecPressure_C.BackColor = Color.Red
                    Me.lblSummary_PSTColor.Text = "Color: Failed"
                    Me.lblSummary_PSTColor.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart2, "ChartArea1", AxisName.Y, CDbl((Me.PST.SpecsColor.PressureMax - Me.PST.SpecsColor.PressureMin)), CDbl(Me.PST.SpecsColor.PressureMin), "Max Pressure Range")
                End If
                If Me.PST.CResults.PF.Leak Then
                    Me.lblTitleLeak_C.BackColor = Color.Lime
                    Me.lblMeasLeak_C.BackColor = Color.Lime
                    Me.lblSpecLeak_C.BackColor = Color.Lime
                Else
                    Me.lblTitleLeak_C.BackColor = Color.Red
                    Me.lblMeasLeak_C.BackColor = Color.Red
                    Me.lblSpecLeak_C.BackColor = Color.Red
                    Me.lblSummary_PSTColor.Text = "Color: Failed"
                    Me.lblSummary_PSTColor.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Dim num6 As Double = Me.PST.CDataPoints.PT2Y
                    If Me.PST.SpecsColor.AllowWetPHA Then
                        num6 = (Me.PST.CDataPoints.PT6Y - Me.PST.SpecsColor.LeakMin)
                    End If
                    Me.AddStripLine(Me.Chart2, "ChartArea1", AxisName.Y, CDbl((Me.PST.SpecsColor.LeakMax - Me.PST.SpecsColor.LeakMin)), (num6 - (Me.PST.SpecsColor.LeakMax + Math.Abs(Me.PST.SpecsColor.LeakMin))), "Leak Range")
                End If
                If (Me.PST.CResults.PF.VentDeltaPMin <> -1) Then
                    Me.lblTitleVent_C.BackColor = Color.Lime
                    Me.lblMeasVent_C.BackColor = Color.Lime
                    Me.lblSpecVent_C.BackColor = Color.Lime
                Else
                    Me.lblTitleVent_C.BackColor = Color.Red
                    Me.lblMeasVent_C.BackColor = Color.Red
                    Me.lblSpecVent_C.BackColor = Color.Red
                    Me.lblSummary_PSTColor.Text = "Color: Failed"
                    Me.lblSummary_PSTColor.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart2, "ChartArea1", AxisName.X, Me.PST.SpecsColor.VentTime, Me.PST.CDataPoints.PT3X, "Vent Range")
                End If
                If Me.PST.CResults.PF.TubeEvacDeltaPressure Then
                    Me.lblTitleTubeEvac_C.BackColor = Color.Lime
                    Me.lblMeasTubeEvac_C.BackColor = Color.Lime
                    Me.lblSpecTubeEvac_C.BackColor = Color.Lime
                Else
                    Me.lblTitleTubeEvac_C.BackColor = Color.Red
                    Me.lblMeasTubeEvac_C.BackColor = Color.Red
                    Me.lblSpecTubeEvac_C.BackColor = Color.Red
                    Me.lblSummary_PSTColor.Text = "Color: Failed"
                    Me.lblSummary_PSTColor.Image = Resources.Error_icon_sm
                    Me.MetroTabItem2.Image = Resources.Error_icon_sm
                    Me.TestStatus = False
                    Me.AddStripLine(Me.Chart2, "ChartArea1", AxisName.Y, CDbl(Math.Abs(Me.PST.SpecsColor.TubeEvacDeltaPressure)), (Me.PST.CDataPoints.PT8Y + Math.Abs(Me.PST.SpecsColor.TubeEvacDeltaPressure)), "Tube Evac")
                End If
                If Not Me.PST.KResults.PF.DerivCnt Then
                    Dim item As New RectangleAnnotation With { _
                        .AnchorX = 40, _
                        .AnchorY = 23, _
                        .AllowMoving = True, _
                        .AllowAnchorMoving = True, _
                        .AllowResizing = True, _
                        .AllowSelecting = True, _
                        .Text = "Too many derivatives." & ChrW(13) & ChrW(10) & "Shape of curve is not recognized." & ChrW(13) & ChrW(10) & "Consider this a warning and not a failure.", _
                        .ForeColor = Color.Black, _
                        .Font = New Font("Arial", 8!), _
                        .LineWidth = 2, _
                        .BackColor = Color.Yellow, _
                        .LineDashStyle = ChartDashStyle.Solid _
                    }
                    Me.Chart1.Annotations.Add(item)
                End If
                If Not Me.PST.CResults.PF.DerivCnt Then
                    Dim item As New RectangleAnnotation With { _
                        .AnchorX = 40, _
                        .AnchorY = 23, _
                        .AllowMoving = True, _
                        .AllowAnchorMoving = True, _
                        .AllowResizing = True, _
                        .AllowSelecting = True, _
                        .Text = "Too many derivatives." & ChrW(13) & ChrW(10) & "Shape of curve is not recognized." & ChrW(13) & ChrW(10) & "Consider this a warning and not a failure.", _
                        .ForeColor = Color.Black, _
                        .Font = New Font("Arial", 8!), _
                        .LineWidth = 2, _
                        .BackColor = Color.Yellow, _
                        .LineDashStyle = ChartDashStyle.Solid _
                    }
                    Me.Chart2.Annotations.Add(item)
                End If
                If Not Me.PST.KResults.PF.DryPHA Then
                    Dim str As String = Nothing
                    Dim yellow As Color = Color.Yellow
                    If Not Me.PST.SpecsBlack.AllowWetPHA Then
                        str = "Wet PHA detected. Wet PHAs are not allowed." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Test fails"
                        yellow = Color.Red
                        Me.lblSummary_PSTBlack.Text = "Black: Failed"
                        Me.lblSummary_PSTBlack.Image = Resources.Error_icon_sm
                        Me.MetroTabItem2.Image = Resources.Error_icon_sm
                        Me.TestStatus = False
                        Dim item As New RectangleAnnotation
                        Dim num7 As Integer = If(Not Me.PST.KResults.PF.DerivCnt, &H2D, &H17)
                        item.AnchorX = 40
                        item.AnchorY = num7
                        item.AllowMoving = True
                        item.AllowAnchorMoving = True
                        item.AllowResizing = True
                        item.AllowSelecting = True
                        item.Text = str
                        item.ForeColor = Color.Black
                        item.Font = New Font("Arial", 8!)
                        item.LineWidth = 2
                        item.BackColor = yellow
                        item.LineDashStyle = ChartDashStyle.Solid
                        Me.Chart1.Annotations.Add(item)
                    End If
                End If
                If Not Me.PST.CResults.PF.DryPHA Then
                    Dim str2 As String = Nothing
                    Dim yellow As Color = Color.Yellow
                    If Not Me.PST.SpecsColor.AllowWetPHA Then
                        str2 = "Wet PHA detected. Wet PHAs are not allowed." & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "Test fails"
                        yellow = Color.Red
                        Me.lblSummary_PSTColor.Text = "Color: Failed"
                        Me.lblSummary_PSTColor.Image = Resources.Error_icon_sm
                        Me.MetroTabItem2.Image = Resources.Error_icon_sm
                        Me.TestStatus = False
                        Dim num8 As Integer = If(Not Me.PST.CResults.PF.DerivCnt, &H2D, &H17)
                        Dim item As New RectangleAnnotation With { _
                            .AnchorX = 40, _
                            .AnchorY = num8, _
                            .AllowMoving = True, _
                            .AllowAnchorMoving = True, _
                            .AllowResizing = True, _
                            .AllowSelecting = True, _
                            .Text = str2, _
                            .ForeColor = Color.Black, _
                            .Font = New Font("Arial", 8!), _
                            .LineWidth = 2, _
                            .BackColor = yellow, _
                            .LineDashStyle = ChartDashStyle.Solid _
                        }
                        Me.Chart2.Annotations.Add(item)
                    End If
                End If
                ChartUtilities.AddAnnotations(("PT1: " & Conversions.ToString(Me.PST.KDataPoints.PT1X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT1Y)), Me.Chart1, Conversions.ToInteger(Me.PST.KDataPoints.PT1Index))
                ChartUtilities.AddAnnotations(("PT2: " & Conversions.ToString(Me.PST.KDataPoints.PT2X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT2Y)), Me.Chart1, Conversions.ToInteger(Me.PST.KDataPoints.PT2Index))
                ChartUtilities.AddAnnotations(("PT3: " & Conversions.ToString(Me.PST.KDataPoints.PT3X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT3Y)), Me.Chart1, Me.PST.KDataPoints.PT3Index)
                ChartUtilities.AddAnnotations(("PT4: " & Conversions.ToString(Me.PST.KDataPoints.PT4X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT4Y)), Me.Chart1, Me.PST.KDataPoints.PT4Index)
                ChartUtilities.AddAnnotations(("PT5: " & Conversions.ToString(Me.PST.KDataPoints.PT5X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT5Y)), Me.Chart1, Me.PST.KDataPoints.PT5Index)
                If Me.PST.SpecsBlack.AllowWetPHA Then
                    ChartUtilities.AddAnnotations(("PT6: " & Conversions.ToString(Me.PST.KDataPoints.PT6X) & "," & Conversions.ToString(Me.PST.KDataPoints.PT6Y)), Me.Chart1, Me.PST.KDataPoints.PT6Index)
                End If
                If (Me.PST.SpecsBlack.AllowWetPHA AndAlso (Me.PST.KDataPoints.PT7Index <> Me.PST.KDataPoints.PT3Index)) Then
                    ChartUtilities.AddAnnotations(("PT7: " & Conversions.ToString(Me.PST.KDataPoints.PT7X) & ", " & Conversions.ToString(Me.PST.KDataPoints.PT7Y)), Me.Chart1, Me.PST.KDataPoints.PT7Index)
                End If
                ChartUtilities.AddAnnotations(("PT1: " & Conversions.ToString(Me.PST.CDataPoints.PT1X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT1Y)), Me.Chart2, Conversions.ToInteger(Me.PST.CDataPoints.PT1Index))
                ChartUtilities.AddAnnotations(("PT2: " & Conversions.ToString(Me.PST.CDataPoints.PT2X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT2Y)), Me.Chart2, Conversions.ToInteger(Me.PST.CDataPoints.PT2Index))
                ChartUtilities.AddAnnotations(("PT3: " & Conversions.ToString(Me.PST.CDataPoints.PT3X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT3Y)), Me.Chart2, Me.PST.CDataPoints.PT3Index)
                ChartUtilities.AddAnnotations(("PT4: " & Conversions.ToString(Me.PST.CDataPoints.PT4X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT4Y)), Me.Chart2, Me.PST.CDataPoints.PT4Index)
                ChartUtilities.AddAnnotations(("PT5: " & Conversions.ToString(Me.PST.CDataPoints.PT5X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT5Y)), Me.Chart2, Me.PST.CDataPoints.PT5Index)
                If Me.PST.SpecsColor.AllowWetPHA Then
                    ChartUtilities.AddAnnotations(("PT6: " & Conversions.ToString(Me.PST.CDataPoints.PT6X) & "," & Conversions.ToString(Me.PST.CDataPoints.PT6Y)), Me.Chart2, Me.PST.CDataPoints.PT6Index)
                End If
                If (Me.PST.SpecsColor.AllowWetPHA AndAlso (Me.PST.CDataPoints.PT7Index <> Me.PST.CDataPoints.PT3Index)) Then
                    ChartUtilities.AddAnnotations(("PT7: " & Conversions.ToString(Me.PST.CDataPoints.PT7X) & ", " & Conversions.ToString(Me.PST.CDataPoints.PT7Y)), Me.Chart2, Me.PST.CDataPoints.PT7Index)
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddPSTDocumention()
            Dim dataPath As String = modCommonCode.GetDataPath
            Me.rtbPSTDocs_Intro.LoadFile((dataPath & "\PSTDocs\PSTIntro.rtf"))
            Me.rtbPSTDocs_PSTOutputs.LoadFile((dataPath & "\PSTDocs\PSTOutput.rtf"))
            Me.rtbPSTDocs_NoPressure.LoadFile((dataPath & "\PSTDocs\PSTNoPressure.rtf"))
            Me.rtbPSTDocs_DelayedPressure.LoadFile((dataPath & "\PSTDocs\PSTDelayedVacuum.rtf"))
            Me.rtbPSTDocs_CyclicalPressure.LoadFile((dataPath & "\PSTDocs\PSTCyclicalPressureDrop.rtf"))
            Me.rtbPSTDocs_PressureFluctuates.LoadFile((dataPath & "\PSTDocs\PSTPressureFluctuates.rtf"))
        End Sub

        Private Sub AddStripLine(ByVal myChart As Chart, ByVal myArea As String, ByVal myAxis As AxisName, ByVal stpWidth As Double, ByVal stpIntervalOffset As Double, ByVal stpText As String)
            Try 
                Dim item As New StripLine With { _
                    .BackColor = Color.FromArgb(&HFF, Color.Red), _
                    .StripWidth = stpWidth, _
                    .IntervalOffset = stpIntervalOffset, _
                    .Text = stpText, _
                    .ForeColor = Color.Yellow, _
                    .TextOrientation = TextOrientation.Horizontal, _
                    .Font = New Font("Arial", 8!) _
                }
                If (myAxis = AxisName.X) Then
                    item.TextAlignment = StringAlignment.Center
                    item.TextLineAlignment = StringAlignment.Near
                    myChart.ChartAreas(myArea).AxisX.StripLines.Add(item)
                Else
                    item.TextAlignment = StringAlignment.Near
                    item.TextLineAlignment = StringAlignment.Center
                    myChart.ChartAreas(myArea).AxisY.StripLines.Add(item)
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub AddSummaryData()
            Try 
                Me.lstSummaryMechChecks.Columns(0).Width = Me.lstSummaryMechChecks.Width
                Dim num3 As Integer = (Me.PST.MechChecks.Count - 1)
                Dim num As Integer = 0
                Do While True
                    Dim num6 As Integer = num3
                    If (num > num6) Then
                        Me.lblSummary_FuelRev.Text = ("FUEL Rev: " & TestInformation.FuelRev.ToString)
                        Me.lblSummary_ScriptRev.Text = ("Script Rev: " & Me.PST.TestInfo.ScriptRev.ToString)
                        Me.lblSummary_ScriptProduct.Text = ("Script Product: " & Me.PST.TestInfo.ScriptProduct)
                        Me.lblSummary_TestDate.Text = ("Test Date: " & Me.PST.TestInfo.TestDate.ToString)
                        Me.lblSummary_TestTime.Text = ("Test Time: " & Me.PST.TestInfo.TestTime.ToString)
                        Me.lblSummary_TestID.Text = ("Test ID: " & Me.PST.TestID)
                        Me.lblSummary_Run.Text = ("Run: " & Conversions.ToString(Me.PST.TestInfo.RunNumber))
                        Me.lblSummary_SerialNum.Text = ("Serial Number: " & Me.PST.PrinterInfo.SerialNum)
                        Me.lblSummary_FW.Text = ("FW Rev: " & Me.PST.PrinterInfo.FWRev)
                        Me.lblSummary_EngPgCnt.Text = ("Engine Pg Cnt: " & Me.PST.PrinterInfo.EnginePgCnt.ToString)
                        Me.lblHidden_TestID.Text = Me.PST.TestID
                        Me.lblHidden_Date.Text = Me.PST.TestInfo.TestDate
                        Me.lblHidden_Time.Text = Me.PST.TestInfo.TestTime
                        Me.lblHidden_Serial.Text = Me.PST.PrinterInfo.SerialNum
                        Me.lblHidden_RunNum.Text = Conversions.ToString(Me.PST.TestInfo.RunNumber)
                        Me.lblHidden_FUELRev.Text = ("FUELRev: " & TestInformation.FuelRev.ToString)
                        Me.lblHidden_ScriptRev.Text = ("ScriptRev: " & Me.PST.TestInfo.ScriptRev.ToString)
                        Me.lblHidden_Product.Text = Me.PST.TestInfo.ScriptProduct
                        Exit Do
                    End If
                    Dim imageIndex As Integer = 0
                    If (Not Me.PST.MechChecks(num).Results And (Me.PST.MechChecks(num).SpecFunction = SpecFunction.PassFail)) Then
                        imageIndex = 1
                        Me.MetroTabItem4.Image = Resources.Error_icon_sm
                        Me.MetroTabItem4.Tag = "Error"
                        Me.TestStatus = False
                    ElseIf (Not Me.PST.MechChecks(num).Results And (Me.PST.MechChecks(num).SpecFunction = SpecFunction.Monitor)) Then
                        imageIndex = 2
                        If (Me.MetroTabItem4.Tag.ToString.ToLower <> "error") Then
                            Me.MetroTabItem4.Image = Resources.warning_sm
                            Me.MetroTabItem4.Tag = "Warning"
                        End If
                    End If
                    Me.lstSummaryMechChecks.Items.Add((Me.PST.MechChecks(num).Name & ": " & Me.PST.MechChecks(num).Value.ToString), imageIndex)
                    num += 1
                Loop
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub ButtonItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MetroTabItem2.Refresh
            Me.Redraw
        End Sub

        Private Sub ButtonItem3_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not (Me.Chart2.ChartAreas("ChartArea1").AxisX.Minimum = Me.PST.PTraceColor(0).X) Then
                Me.Chart2.ChartAreas("ChartArea1").AxisX.Maximum = Me.PST.PTraceColor((Me.PST.PTraceColor.Count - 1)).X
                Me.Chart2.ChartAreas("ChartArea1").AxisX.Minimum = Me.PST.PTraceColor(0).X
            Else
                Me.Chart2.ChartAreas("ChartArea1").AxisX.Maximum = (Me.PST.CDataPoints.PT4X + 1)
                Me.Chart2.ChartAreas("ChartArea1").AxisX.Minimum = (Me.PST.CDataPoints.PT1X - 1)
            End If
        End Sub

        Private Sub ButtonItem4_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.PrepFormForBitMap(True)
            Dim strArray As String() = New String() { Me.PST.TestID, "-", Me.PST.PrinterInfo.SerialNum, "-", Conversions.ToString(Me.PST.TestInfo.RunNumber), ".bmp" }
            Me.ToBitmap(Me).Save(Path.Combine(Me.PST.SaveFileLocation, String.Concat(strArray)))
            Me.PrepFormForBitMap(False)
        End Sub

        Private Sub ButtonX2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim str As String = (modCommonCode.GetDataPath & "Help\PST.exe")
            Dim process As New Process
            process.StartInfo.FileName = str
            process.Start
        End Sub

        Private Sub cboRunCharts_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.AddHistoryData(Me.cboRunCharts.SelectedItem.ToString)
        End Sub

        Private Sub cmdClipBoard_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.CopyToClipBoard
        End Sub

        Private Sub cmdEmail_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.CopyToClipBoard
            Dim str As String = Nothing
            Process.Start($"mailto:{str}?subject={"PST Email"}&body={"Type 'Ctrl+V' to insert screen shot of PST results"}")
        End Sub

        Private Sub cmdHistory_ChartIt_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.AddHistoryData3(Me.cboHistory_XVal.SelectedItem.ToString, Me.cboHistory_YVal.SelectedItem.ToString, Me.cboHistory_Series.SelectedItem.ToString)
        End Sub

        Private Sub cmdHistory_DataGrid_Edit_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.sgcHistory.PrimaryGrid.AllowSelection = Me.cmdHistory_DataGrid_Edit.Checked
            Me.sgcHistory.PrimaryGrid.AllowRowDelete = Me.cmdHistory_DataGrid_Edit.Checked
            Me.sgcHistory.PrimaryGrid.ReadOnly = Not Me.cmdHistory_DataGrid_Edit.Checked
        End Sub

        Private Sub cmdSaveFormImage_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.PrepFormForBitMap(True)
            Dim image As Image = Me.ToBitmap(Me)
            Debug.Print(Me.PST.SaveFileLocation)
            Dim strArray As String() = New String() { Me.PST.TestID, "-", Me.PST.PrinterInfo.SerialNum, "-", Conversions.ToString(Me.PST.TestInfo.RunNumber), ".bmp" }
            image.Save(Path.Combine(Me.PST.SaveFileLocation, String.Concat(strArray)))
            Me.PrepFormForBitMap(False)
        End Sub

        Private Sub CopyToClipBoard()
            Me.PrepFormForBitMap(True)
            MyProject.Computer.Clipboard.SetImage(Me.ToBitmap(Me))
            Me.PrepFormForBitMap(False)
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

        Private Sub dlgPSTResults_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.MetroTabItem1.Select
            Me.TableLayoutPanel4.BackColor = Color.Transparent
            If Me.MetroTabItem3.Visible Then
                Me.LoadHistoryTable
                Me.sgcHistory.PrimaryGrid.DataSource = Me.dtHistory
            End If
            Me.AddSummaryData
            Me.AddPSTData
            Me.cboRunCharts.Text = "K_MAX_PRESSURE"
            Me.AddMechChecks
            Me.AddPSTDocumention
            If Not Me.TestStatus Then
                Me.PictureBox1.Image = Resources.Error_icon
                Me.ReflectionLabel4.Text = Me.ReflectionLabel4.Text.Replace("Passed", "Failed")
                Me.ReflectionLabel4.Text = Me.ReflectionLabel4.Text.Replace("#009303", "#B02B2C")
            End If
            Me.Refresh
        End Sub

        Private Sub dlgPSTResults_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (Control.ModifierKeys = (Keys.Control Or Keys.Shift)) Then
                Me.ButtonItem2.Visible = Not Me.ButtonItem2.Visible
                Me.ButtonItem3.Visible = Not Me.ButtonItem3.Visible
                Me.ButtonItem4.Visible = Not Me.ButtonItem4.Visible
                Me.Redraw
            End If
        End Sub

        Private Sub FormatPSTChartArea(ByVal myChart As Chart, ByVal myArea As String)
            Dim chart As Chart = myChart
            Dim axisX As Axis = chart.ChartAreas(myArea).AxisX
            axisX.LineColor = Color.DarkBlue
            axisX.LineWidth = 4
            axisX.Interval = 1
            axisX.MajorTickMark.Interval = 1
            axisX.MajorGrid.LineWidth = 1
            axisX.MinorGrid.Enabled = True
            axisX.MinorGrid.Interval = 0.25
            axisX.MinorGrid.LineColor = Color.FromArgb(200, &H8E, &H8D, &H5D)
            axisX.MinorGrid.LineWidth = 1
            axisX.MinorTickMark.Enabled = False
            axisX.IsMarginVisible = False
            axisX = Nothing
            Dim axisY As Axis = chart.ChartAreas(myArea).AxisY
            axisY.LineColor = Color.DarkBlue
            axisY.LineWidth = 4
            axisY.Interval = 30
            axisY.MajorTickMark.Interval = 30
            axisY.MinorGrid.Enabled = True
            axisY.MinorGrid.Interval = 10
            axisY.MinorGrid.LineColor = Color.FromArgb(200, &H8E, &H8D, &H5D)
            axisY.MinorTickMark.Enabled = False
            axisY.IsMarginVisible = False
            axisY = Nothing
            chart = Nothing
        End Sub

        Public Function GetEnglishResult(ByVal Val As Boolean) As String
            Dim str As String
            If Val Then
                str = "Passed"
            ElseIf Not Val Then
                str = "Failed"
            Else
                str = "err"
            End If
            Return str
        End Function

        Private Sub HistoryChartTypeChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.Chart3.Visible = False
            Me.Chart4.Visible = False
            Me.cboRunCharts.Visible = False
            Me.cboHistory_XVal.Visible = False
            Me.cboHistory_YVal.Visible = False
            Me.cboHistory_Series.Visible = False
            Me.lblHistory_XVal.Visible = False
            Me.lblHistory_YVal.Visible = False
            Me.lblHistory_Series.Visible = False
            Me.cmdHistory_ChartIt.Visible = False
            Me.cmdHistory_DataGrid_Edit.Visible = False
            Me.sgcHistory.Visible = False
            Dim left As Object = NewLateBinding.LateGet(sender, Nothing, "Name", New Object(0  - 1) {}, Nothing, Nothing, Nothing)
            If Operators.ConditionalCompareObjectEqual(left, "cmdShowRuncharts", False) Then
                Me.cmdDataSelect.Text = "Now Showing Run Charts"
                Me.AddHistoryData(Me.cboRunCharts.SelectedItem.ToString)
                Me.cboRunCharts.Visible = True
                Me.Chart3.Visible = True
            ElseIf Not Operators.ConditionalCompareObjectEqual(left, "cmdShowRegularcharts", False) Then
                If Operators.ConditionalCompareObjectEqual(left, "cmdShowDataGrid", False) Then
                    Me.cmdDataSelect.Text = "Now Showing Full History Data"
                    Me.sgcHistory.Visible = True
                    Me.cmdHistory_DataGrid_Edit.Visible = True
                End If
            Else
                Me.cmdDataSelect.Text = "Now Showing Mech Check Data"
                Me.Chart4.Visible = True
                Me.cboHistory_XVal.Visible = True
                Me.cboHistory_YVal.Visible = True
                Me.cboHistory_Series.Visible = True
                Me.lblHistory_XVal.Visible = True
                Me.lblHistory_YVal.Visible = True
                Me.lblHistory_Series.Visible = True
                Me.cmdHistory_ChartIt.Visible = True
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Dim item As New ChartArea
            Dim title As New Title
            Dim area2 As New ChartArea
            Dim title2 As New Title
            Dim manager As New ComponentResourceManager(GetType(dlgPSTResults))
            Dim area3 As New ChartArea
            Dim area4 As New ChartArea
            Dim legend As New Legend
            Dim area5 As New ChartArea
            Dim legend2 As New Legend
            Me.lblTitlePressure_K = New LabelX
            Me.GroupPanel1 = New GroupPanel
            Me.TableLayoutPanel2 = New TableLayoutPanel
            Me.lblMeasTubeEvac_K = New LabelX
            Me.lblTitleTubeEvac_k = New LabelX
            Me.lblTitleLeak_K = New LabelX
            Me.lblTitleVent_K = New LabelX
            Me.lblMeasPressure_K = New LabelX
            Me.lblMeasLeak_K = New LabelX
            Me.lblMeasVent_K = New LabelX
            Me.lblSpecPressure_K = New LabelX
            Me.lblSpecLeak_K = New LabelX
            Me.lblSpecVent_K = New LabelX
            Me.LabelX10 = New LabelX
            Me.LabelX11 = New LabelX
            Me.LabelX12 = New LabelX
            Me.lblSpecTubeEvac_K = New LabelX
            Me.GroupPanel2 = New GroupPanel
            Me.TableLayoutPanel3 = New TableLayoutPanel
            Me.lblTitleTubeEvac_C = New LabelX
            Me.lblMeasTubeEvac_C = New LabelX
            Me.lblSpecTubeEvac_C = New LabelX
            Me.lblTitlePressure_C = New LabelX
            Me.lblTitleLeak_C = New LabelX
            Me.lblTitleVent_C = New LabelX
            Me.lblMeasPressure_C = New LabelX
            Me.lblMeasLeak_C = New LabelX
            Me.lblMeasVent_C = New LabelX
            Me.lblSpecPressure_C = New LabelX
            Me.lblSpecLeak_C = New LabelX
            Me.lblSpecVent_C = New LabelX
            Me.LabelX16 = New LabelX
            Me.LabelX17 = New LabelX
            Me.LabelX18 = New LabelX
            Me.TableLayoutPanel4 = New TableLayoutPanel
            Me.FlowLayoutPanel1 = New FlowLayoutPanel
            Me.lblHidden_TestInfo = New Label
            Me.lblHidden_TestID = New Label
            Me.lblHidden_Date = New Label
            Me.lblHidden_Time = New Label
            Me.lblHidden_Serial = New Label
            Me.lblHidden_RunNum = New Label
            Me.lblHidden_FUELRev = New Label
            Me.lblHidden_ScriptRev = New Label
            Me.lblHidden_Product = New Label
            Me.Chart1 = New Chart
            Me.Chart2 = New Chart
            Me.MetroShell1 = New MetroShell
            Me.MetroTabPanel1 = New MetroTabPanel
            Me.lblSummary_Run = New LabelX
            Me.lblSummary_TestID = New LabelX
            Me.PictureBox1 = New PictureBox
            Me.ReflectionLabel4 = New ReflectionLabel
            Me.lblSummary_ScriptProduct = New LabelX
            Me.lstSummaryMechChecks = New ListViewEx
            Me.ColumnHeader2 = New ColumnHeader
            Me.ImageList1 = New ImageList(Me.components)
            Me.LabelX1 = New LabelX
            Me.lblFailModes = New LabelX
            Me.ReflectionLabel5 = New ReflectionLabel
            Me.ReflectionLabel3 = New ReflectionLabel
            Me.lblSummary_PSTColor = New LabelX
            Me.lblSummary_PSTBlack = New LabelX
            Me.lblSummary_EngPgCnt = New LabelX
            Me.lblSummary_FW = New LabelX
            Me.lblSummary_SerialNum = New LabelX
            Me.ReflectionLabel1 = New ReflectionLabel
            Me.lblSummary_TestTime = New LabelX
            Me.lblSummary_TestDate = New LabelX
            Me.lblSummary_ScriptRev = New LabelX
            Me.lblSummary_FuelRev = New LabelX
            Me.ReflectionLabel2 = New ReflectionLabel
            Me.MetroTabPanel5 = New MetroTabPanel
            Me.SuperTabControl1 = New SuperTabControl
            Me.SuperTabControlPanel1 = New SuperTabControlPanel
            Me.rtbPSTDocs_Intro = New RichTextBox
            Me.stiPSTDocs_Intro = New SuperTabItem
            Me.SuperTabControlPanel6 = New SuperTabControlPanel
            Me.rtbPSTDocs_PSTOutputs = New RichTextBox
            Me.stiPSTDocs_Outputs = New SuperTabItem
            Me.SuperTabControlPanel3 = New SuperTabControlPanel
            Me.rtbPSTDocs_DelayedPressure = New RichTextBox
            Me.stiPSTDocs_DelayedPressure = New SuperTabItem
            Me.SuperTabControlPanel4 = New SuperTabControlPanel
            Me.rtbPSTDocs_CyclicalPressure = New RichTextBox
            Me.stiPSTDocs_CyclicalPressure = New SuperTabItem
            Me.SuperTabControlPanel2 = New SuperTabControlPanel
            Me.rtbPSTDocs_NoPressure = New RichTextBox
            Me.stiPSTDocs_NoPressure = New SuperTabItem
            Me.SuperTabControlPanel5 = New SuperTabControlPanel
            Me.rtbPSTDocs_PressureFluctuates = New RichTextBox
            Me.stiPSTDocs_PressureFluctuates = New SuperTabItem
            Me.MetroTabPanel6 = New MetroTabPanel
            Me.ButtonX2 = New ButtonX
            Me.ButtonX1 = New ButtonX
            Me.MetroTabPanel2 = New MetroTabPanel
            Me.MetroTabPanel4 = New MetroTabPanel
            Me.MetroTabPanel3 = New MetroTabPanel
            Me.TableLayoutPanel5 = New TableLayoutPanel
            Me.cmdDataSelect = New ButtonX
            Me.cmdShowRuncharts = New ButtonItem
            Me.cmdShowRegularcharts = New ButtonItem
            Me.cmdShowDataGrid = New ButtonItem
            Me.Chart3 = New Chart
            Me.Chart4 = New Chart
            Me.lblHistory_TotalUnits = New LabelX
            Me.cboRunCharts = New ComboBoxEx
            Me.sgcHistory = New SuperGridControl
            Me.cboHistory_XVal = New ComboBoxEx
            Me.cboHistory_YVal = New ComboBoxEx
            Me.cboHistory_Series = New ComboBoxEx
            Me.lblHistory_XVal = New LabelX
            Me.lblHistory_YVal = New LabelX
            Me.lblHistory_Series = New LabelX
            Me.cmdHistory_ChartIt = New ButtonX
            Me.cmdHistory_DataGrid_Edit = New ButtonX
            Me.MetroAppButton1 = New MetroAppButton
            Me.MetroTabItem1 = New MetroTabItem
            Me.MetroTabItem2 = New MetroTabItem
            Me.MetroTabItem4 = New MetroTabItem
            Me.MetroTabItem3 = New MetroTabItem
            Me.tabTriage = New MetroTabItem
            Me.tabHelp = New MetroTabItem
            Me.ButtonItem4 = New ButtonItem
            Me.ButtonItem1 = New ButtonItem
            Me.StyleManager1 = New StyleManager(Me.components)
            Me.MetroStatusBar1 = New MetroStatusBar
            Me.cmdEmail = New ButtonItem
            Me.cmdClipBoard = New ButtonItem
            Me.cmdSaveFormImage = New ButtonItem
            Me.ButtonItem2 = New ButtonItem
            Me.ButtonItem3 = New ButtonItem
            Me.SuperTooltip1 = New SuperTooltip
            Me.GroupPanel1.SuspendLayout
            Me.TableLayoutPanel2.SuspendLayout
            Me.GroupPanel2.SuspendLayout
            Me.TableLayoutPanel3.SuspendLayout
            Me.TableLayoutPanel4.SuspendLayout
            Me.FlowLayoutPanel1.SuspendLayout
            Me.Chart1.BeginInit
            Me.Chart2.BeginInit
            Me.MetroShell1.SuspendLayout
            Me.MetroTabPanel1.SuspendLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.MetroTabPanel5.SuspendLayout
            DirectCast(Me.SuperTabControl1, ISupportInitialize).BeginInit
            Me.SuperTabControl1.SuspendLayout
            Me.SuperTabControlPanel1.SuspendLayout
            Me.SuperTabControlPanel6.SuspendLayout
            Me.SuperTabControlPanel3.SuspendLayout
            Me.SuperTabControlPanel4.SuspendLayout
            Me.SuperTabControlPanel2.SuspendLayout
            Me.SuperTabControlPanel5.SuspendLayout
            Me.MetroTabPanel6.SuspendLayout
            Me.MetroTabPanel2.SuspendLayout
            Me.MetroTabPanel3.SuspendLayout
            Me.TableLayoutPanel5.SuspendLayout
            Me.Chart3.BeginInit
            Me.Chart4.BeginInit
            Me.SuspendLayout
            Me.lblTitlePressure_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitlePressure_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitlePressure_K.Dock = DockStyle.Fill
            Me.lblTitlePressure_K.ForeColor = Color.Black
            Dim point2 As New Point(0, &H18)
            Me.lblTitlePressure_K.Location = point2
            Dim padding2 As New Padding(0)
            Me.lblTitlePressure_K.Margin = padding2
            Me.lblTitlePressure_K.Name = "lblTitlePressure_K"
            Me.lblTitlePressure_K.PaddingLeft = 3
            Me.lblTitlePressure_K.PaddingRight = 3
            Dim size2 As New Size(&H97, &H18)
            Me.lblTitlePressure_K.Size = size2
            Me.lblTitlePressure_K.TabIndex = 2
            Me.lblTitlePressure_K.Text = "Pressure"
            Me.lblTitlePressure_K.TextAlignment = StringAlignment.Far
            Me.GroupPanel1.Anchor = AnchorStyles.Bottom
            Me.GroupPanel1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.GroupPanel1.CanvasColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.GroupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007
            Me.GroupPanel1.Controls.Add(Me.TableLayoutPanel2)
            Me.GroupPanel1.DisabledBackColor = Color.Empty
            point2 = New Point(&H12, &H121)
            Me.GroupPanel1.Location = point2
            Me.GroupPanel1.Name = "GroupPanel1"
            size2 = New Size(&H17F, &H87)
            Me.GroupPanel1.Size = size2
            Me.GroupPanel1.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2
            Me.GroupPanel1.Style.BackColorGradientAngle = 90
            Me.GroupPanel1.Style.BackColorSchemePart = eColorSchemePart.PanelBackground
            Me.GroupPanel1.Style.BorderBottom = eStyleBorderType.Solid
            Me.GroupPanel1.Style.BorderBottomWidth = 1
            Me.GroupPanel1.Style.BorderColorSchemePart = eColorSchemePart.MenuBorder
            Me.GroupPanel1.Style.BorderLeft = eStyleBorderType.Solid
            Me.GroupPanel1.Style.BorderLeftWidth = 1
            Me.GroupPanel1.Style.BorderRight = eStyleBorderType.Solid
            Me.GroupPanel1.Style.BorderRightWidth = 1
            Me.GroupPanel1.Style.BorderTop = eStyleBorderType.Solid
            Me.GroupPanel1.Style.BorderTopWidth = 1
            Me.GroupPanel1.Style.CornerDiameter = 4
            Me.GroupPanel1.Style.CornerType = eCornerType.Rounded
            Me.GroupPanel1.Style.TextAlignment = eStyleTextAlignment.Center
            Me.GroupPanel1.Style.TextColor = Color.FromArgb(0, 0, 0)
            Me.GroupPanel1.Style.TextLineAlignment = eStyleTextAlignment.Near
            Me.GroupPanel1.StyleMouseDown.CornerType = eCornerType.Square
            Me.GroupPanel1.StyleMouseOver.CornerType = eCornerType.Square
            Me.GroupPanel1.TabIndex = 3
            Me.GroupPanel1.Text = "<b>Black PST Details</b>"
            Me.TableLayoutPanel2.BackColor = Color.Transparent
            Me.TableLayoutPanel2.ColumnCount = 3
            Me.TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 151!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 97!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 102!))
            Me.TableLayoutPanel2.Controls.Add(Me.lblMeasTubeEvac_K, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.lblTitleTubeEvac_k, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.lblTitlePressure_K, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblTitleLeak_K, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblTitleVent_K, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblMeasPressure_K, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblMeasLeak_K, 1, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblMeasVent_K, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblSpecPressure_K, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblSpecLeak_K, 2, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblSpecVent_K, 2, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.LabelX10, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.LabelX11, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.LabelX12, 2, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblSpecTubeEvac_K, 1, 4)
            Me.TableLayoutPanel2.Dock = DockStyle.Fill
            Me.TableLayoutPanel2.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.TableLayoutPanel2.Location = point2
            padding2 = New Padding(0)
            Me.TableLayoutPanel2.Margin = padding2
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 5
            Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            size2 = New Size(&H179, &H74)
            Me.TableLayoutPanel2.Size = size2
            Me.TableLayoutPanel2.TabIndex = 0
            Me.lblMeasTubeEvac_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasTubeEvac_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasTubeEvac_K.Dock = DockStyle.Fill
            Me.lblMeasTubeEvac_K.ForeColor = Color.Black
            point2 = New Point(&H97, &H60)
            Me.lblMeasTubeEvac_K.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasTubeEvac_K.Margin = padding2
            Me.lblMeasTubeEvac_K.Name = "lblMeasTubeEvac_K"
            Me.lblMeasTubeEvac_K.PaddingLeft = 3
            Me.lblMeasTubeEvac_K.PaddingRight = 3
            size2 = New Size(&H61, 20)
            Me.lblMeasTubeEvac_K.Size = size2
            Me.lblMeasTubeEvac_K.TabIndex = &H10
            Me.lblMeasTubeEvac_K.Text = "LabelX9"
            Me.lblMeasTubeEvac_K.TextAlignment = StringAlignment.Center
            Me.lblTitleTubeEvac_k.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleTubeEvac_k.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleTubeEvac_k.Dock = DockStyle.Fill
            Me.lblTitleTubeEvac_k.ForeColor = Color.Black
            point2 = New Point(0, &H60)
            Me.lblTitleTubeEvac_k.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleTubeEvac_k.Margin = padding2
            Me.lblTitleTubeEvac_k.Name = "lblTitleTubeEvac_k"
            Me.lblTitleTubeEvac_k.PaddingLeft = 3
            Me.lblTitleTubeEvac_k.PaddingRight = 3
            size2 = New Size(&H97, 20)
            Me.lblTitleTubeEvac_k.Size = size2
            Me.lblTitleTubeEvac_k.TabIndex = 14
            Me.lblTitleTubeEvac_k.Text = "Tube Evac"
            Me.lblTitleTubeEvac_k.TextAlignment = StringAlignment.Far
            Me.lblTitleLeak_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleLeak_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleLeak_K.Dock = DockStyle.Fill
            Me.lblTitleLeak_K.ForeColor = Color.Black
            point2 = New Point(0, &H30)
            Me.lblTitleLeak_K.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleLeak_K.Margin = padding2
            Me.lblTitleLeak_K.Name = "lblTitleLeak_K"
            Me.lblTitleLeak_K.PaddingLeft = 3
            Me.lblTitleLeak_K.PaddingRight = 3
            size2 = New Size(&H97, &H18)
            Me.lblTitleLeak_K.Size = size2
            Me.lblTitleLeak_K.TabIndex = 3
            Me.lblTitleLeak_K.Text = "Leak"
            Me.lblTitleLeak_K.TextAlignment = StringAlignment.Far
            Me.lblTitleVent_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleVent_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleVent_K.Dock = DockStyle.Fill
            Me.lblTitleVent_K.ForeColor = Color.Black
            point2 = New Point(0, &H48)
            Me.lblTitleVent_K.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleVent_K.Margin = padding2
            Me.lblTitleVent_K.Name = "lblTitleVent_K"
            Me.lblTitleVent_K.PaddingLeft = 3
            Me.lblTitleVent_K.PaddingRight = 3
            size2 = New Size(&H97, &H18)
            Me.lblTitleVent_K.Size = size2
            Me.lblTitleVent_K.TabIndex = 4
            Me.lblTitleVent_K.Text = "Vent Delta P"
            Me.lblTitleVent_K.TextAlignment = StringAlignment.Far
            Me.lblMeasPressure_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasPressure_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasPressure_K.Dock = DockStyle.Fill
            Me.lblMeasPressure_K.ForeColor = Color.Black
            point2 = New Point(&H97, &H18)
            Me.lblMeasPressure_K.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasPressure_K.Margin = padding2
            Me.lblMeasPressure_K.Name = "lblMeasPressure_K"
            Me.lblMeasPressure_K.PaddingLeft = 3
            Me.lblMeasPressure_K.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasPressure_K.Size = size2
            Me.lblMeasPressure_K.TabIndex = 5
            Me.lblMeasPressure_K.Text = "LabelX4"
            Me.lblMeasPressure_K.TextAlignment = StringAlignment.Center
            Me.lblMeasLeak_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasLeak_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasLeak_K.Dock = DockStyle.Fill
            Me.lblMeasLeak_K.ForeColor = Color.Black
            point2 = New Point(&H97, &H30)
            Me.lblMeasLeak_K.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasLeak_K.Margin = padding2
            Me.lblMeasLeak_K.Name = "lblMeasLeak_K"
            Me.lblMeasLeak_K.PaddingLeft = 3
            Me.lblMeasLeak_K.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasLeak_K.Size = size2
            Me.lblMeasLeak_K.TabIndex = 6
            Me.lblMeasLeak_K.Text = "LabelX5"
            Me.lblMeasLeak_K.TextAlignment = StringAlignment.Center
            Me.lblMeasVent_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasVent_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasVent_K.Dock = DockStyle.Fill
            Me.lblMeasVent_K.ForeColor = Color.Black
            point2 = New Point(&H97, &H48)
            Me.lblMeasVent_K.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasVent_K.Margin = padding2
            Me.lblMeasVent_K.Name = "lblMeasVent_K"
            Me.lblMeasVent_K.PaddingLeft = 3
            Me.lblMeasVent_K.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasVent_K.Size = size2
            Me.lblMeasVent_K.TabIndex = 7
            Me.lblMeasVent_K.Text = "LabelX6"
            Me.lblMeasVent_K.TextAlignment = StringAlignment.Center
            Me.lblSpecPressure_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecPressure_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecPressure_K.Dock = DockStyle.Fill
            Me.lblSpecPressure_K.ForeColor = Color.Black
            point2 = New Point(&HF8, &H18)
            Me.lblSpecPressure_K.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecPressure_K.Margin = padding2
            Me.lblSpecPressure_K.Name = "lblSpecPressure_K"
            Me.lblSpecPressure_K.PaddingLeft = 3
            Me.lblSpecPressure_K.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecPressure_K.Size = size2
            Me.lblSpecPressure_K.TabIndex = 8
            Me.lblSpecPressure_K.Text = "LabelX7"
            Me.lblSpecPressure_K.TextAlignment = StringAlignment.Center
            Me.lblSpecLeak_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecLeak_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecLeak_K.Dock = DockStyle.Fill
            Me.lblSpecLeak_K.ForeColor = Color.Black
            point2 = New Point(&HF8, &H30)
            Me.lblSpecLeak_K.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecLeak_K.Margin = padding2
            Me.lblSpecLeak_K.Name = "lblSpecLeak_K"
            Me.lblSpecLeak_K.PaddingLeft = 3
            Me.lblSpecLeak_K.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecLeak_K.Size = size2
            Me.lblSpecLeak_K.TabIndex = 9
            Me.lblSpecLeak_K.Text = "LabelX8"
            Me.lblSpecLeak_K.TextAlignment = StringAlignment.Center
            Me.lblSpecVent_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecVent_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecVent_K.Dock = DockStyle.Fill
            Me.lblSpecVent_K.ForeColor = Color.Black
            point2 = New Point(&HF8, &H48)
            Me.lblSpecVent_K.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecVent_K.Margin = padding2
            Me.lblSpecVent_K.Name = "lblSpecVent_K"
            Me.lblSpecVent_K.PaddingLeft = 3
            Me.lblSpecVent_K.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecVent_K.Size = size2
            Me.lblSpecVent_K.TabIndex = 10
            Me.lblSpecVent_K.Text = "LabelX9"
            Me.lblSpecVent_K.TextAlignment = StringAlignment.Center
            Me.LabelX10.BackColor = Color.Transparent
            Me.LabelX10.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX10.Dock = DockStyle.Fill
            Me.LabelX10.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX10.ForeColor = Color.Black
            point2 = New Point(3, 3)
            Me.LabelX10.Location = point2
            Me.LabelX10.Name = "LabelX10"
            Me.LabelX10.PaddingLeft = 3
            Me.LabelX10.PaddingRight = 3
            size2 = New Size(&H91, &H12)
            Me.LabelX10.Size = size2
            Me.LabelX10.TabIndex = 11
            Me.LabelX10.Text = "Metric"
            Me.LabelX10.TextAlignment = StringAlignment.Far
            Me.LabelX11.BackColor = Color.Transparent
            Me.LabelX11.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX11.Dock = DockStyle.Fill
            Me.LabelX11.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX11.ForeColor = Color.Black
            point2 = New Point(&H9A, 3)
            Me.LabelX11.Location = point2
            Me.LabelX11.Name = "LabelX11"
            Me.LabelX11.PaddingLeft = 3
            Me.LabelX11.PaddingRight = 3
            size2 = New Size(&H5B, &H12)
            Me.LabelX11.Size = size2
            Me.LabelX11.TabIndex = 12
            Me.LabelX11.Text = "Measure Value"
            Me.LabelX11.TextAlignment = StringAlignment.Center
            Me.LabelX12.BackColor = Color.Transparent
            Me.LabelX12.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX12.Dock = DockStyle.Fill
            Me.LabelX12.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX12.ForeColor = Color.Black
            point2 = New Point(&HFB, 3)
            Me.LabelX12.Location = point2
            Me.LabelX12.Name = "LabelX12"
            Me.LabelX12.PaddingLeft = 3
            Me.LabelX12.PaddingRight = 3
            size2 = New Size(&H7B, &H12)
            Me.LabelX12.Size = size2
            Me.LabelX12.Style = eDotNetBarStyle.StyleManagerControlled
            Me.LabelX12.TabIndex = 13
            Me.LabelX12.Text = "Specs"
            Me.LabelX12.TextAlignment = StringAlignment.Center
            Me.lblSpecTubeEvac_K.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecTubeEvac_K.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecTubeEvac_K.Dock = DockStyle.Fill
            Me.lblSpecTubeEvac_K.ForeColor = Color.Black
            point2 = New Point(&HF8, &H60)
            Me.lblSpecTubeEvac_K.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecTubeEvac_K.Margin = padding2
            Me.lblSpecTubeEvac_K.Name = "lblSpecTubeEvac_K"
            Me.lblSpecTubeEvac_K.PaddingLeft = 3
            Me.lblSpecTubeEvac_K.PaddingRight = 3
            size2 = New Size(&H81, 20)
            Me.lblSpecTubeEvac_K.Size = size2
            Me.lblSpecTubeEvac_K.TabIndex = 15
            Me.lblSpecTubeEvac_K.Text = "LabelX6"
            Me.lblSpecTubeEvac_K.TextAlignment = StringAlignment.Center
            Me.GroupPanel2.Anchor = AnchorStyles.Bottom
            Me.GroupPanel2.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.GroupPanel2.CanvasColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.GroupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007
            Me.GroupPanel2.Controls.Add(Me.TableLayoutPanel3)
            Me.GroupPanel2.DisabledBackColor = Color.Empty
            point2 = New Point(&H1B5, &H121)
            Me.GroupPanel2.Location = point2
            Me.GroupPanel2.Name = "GroupPanel2"
            size2 = New Size(&H17F, &H87)
            Me.GroupPanel2.Size = size2
            Me.GroupPanel2.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2
            Me.GroupPanel2.Style.BackColorGradientAngle = 90
            Me.GroupPanel2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground
            Me.GroupPanel2.Style.BorderBottom = eStyleBorderType.Solid
            Me.GroupPanel2.Style.BorderBottomWidth = 1
            Me.GroupPanel2.Style.BorderColorSchemePart = eColorSchemePart.MenuBorder
            Me.GroupPanel2.Style.BorderLeft = eStyleBorderType.Solid
            Me.GroupPanel2.Style.BorderLeftWidth = 1
            Me.GroupPanel2.Style.BorderRight = eStyleBorderType.Solid
            Me.GroupPanel2.Style.BorderRightWidth = 1
            Me.GroupPanel2.Style.BorderTop = eStyleBorderType.Solid
            Me.GroupPanel2.Style.BorderTopWidth = 1
            Me.GroupPanel2.Style.CornerDiameter = 4
            Me.GroupPanel2.Style.CornerType = eCornerType.Rounded
            Me.GroupPanel2.Style.TextAlignment = eStyleTextAlignment.Center
            Me.GroupPanel2.Style.TextColor = Color.FromArgb(0, 0, 0)
            Me.GroupPanel2.Style.TextLineAlignment = eStyleTextAlignment.Near
            Me.GroupPanel2.StyleMouseDown.CornerType = eCornerType.Square
            Me.GroupPanel2.StyleMouseOver.CornerType = eCornerType.Square
            Me.GroupPanel2.TabIndex = 4
            Me.GroupPanel2.Text = "<b>Color PST Details</b>"
            Me.TableLayoutPanel3.BackColor = Color.Transparent
            Me.TableLayoutPanel3.ColumnCount = 3
            Me.TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 151!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 97!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 72!))
            Me.TableLayoutPanel3.Controls.Add(Me.lblTitleTubeEvac_C, 0, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.lblMeasTubeEvac_C, 0, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.lblSpecTubeEvac_C, 0, 4)
            Me.TableLayoutPanel3.Controls.Add(Me.lblTitlePressure_C, 0, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.lblTitleLeak_C, 0, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.lblTitleVent_C, 0, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.lblMeasPressure_C, 1, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.lblMeasLeak_C, 1, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.lblMeasVent_C, 1, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.lblSpecPressure_C, 2, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.lblSpecLeak_C, 2, 2)
            Me.TableLayoutPanel3.Controls.Add(Me.lblSpecVent_C, 2, 3)
            Me.TableLayoutPanel3.Controls.Add(Me.LabelX16, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.LabelX17, 1, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.LabelX18, 2, 0)
            Me.TableLayoutPanel3.Dock = DockStyle.Fill
            Me.TableLayoutPanel3.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.TableLayoutPanel3.Location = point2
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 5
            Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            size2 = New Size(&H179, &H74)
            Me.TableLayoutPanel3.Size = size2
            Me.TableLayoutPanel3.TabIndex = 0
            Me.lblTitleTubeEvac_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleTubeEvac_C.Dock = DockStyle.Fill
            Me.lblTitleTubeEvac_C.ForeColor = Color.Black
            point2 = New Point(0, &H60)
            Me.lblTitleTubeEvac_C.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleTubeEvac_C.Margin = padding2
            Me.lblTitleTubeEvac_C.Name = "lblTitleTubeEvac_C"
            Me.lblTitleTubeEvac_C.PaddingLeft = 3
            Me.lblTitleTubeEvac_C.PaddingRight = 3
            size2 = New Size(&H97, 20)
            Me.lblTitleTubeEvac_C.Size = size2
            Me.lblTitleTubeEvac_C.TabIndex = &H10
            Me.lblTitleTubeEvac_C.Text = "Tube Evac"
            Me.lblTitleTubeEvac_C.TextAlignment = StringAlignment.Far
            Me.lblMeasTubeEvac_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasTubeEvac_C.Dock = DockStyle.Fill
            Me.lblMeasTubeEvac_C.ForeColor = Color.Black
            point2 = New Point(&H97, &H60)
            Me.lblMeasTubeEvac_C.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasTubeEvac_C.Margin = padding2
            Me.lblMeasTubeEvac_C.Name = "lblMeasTubeEvac_C"
            Me.lblMeasTubeEvac_C.PaddingLeft = 3
            Me.lblMeasTubeEvac_C.PaddingRight = 3
            size2 = New Size(&H61, 20)
            Me.lblMeasTubeEvac_C.Size = size2
            Me.lblMeasTubeEvac_C.TabIndex = 15
            Me.lblMeasTubeEvac_C.Text = "Vent Time"
            Me.lblMeasTubeEvac_C.TextAlignment = StringAlignment.Center
            Me.lblSpecTubeEvac_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecTubeEvac_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecTubeEvac_C.Dock = DockStyle.Fill
            Me.lblSpecTubeEvac_C.ForeColor = Color.Black
            point2 = New Point(&HF8, &H60)
            Me.lblSpecTubeEvac_C.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecTubeEvac_C.Margin = padding2
            Me.lblSpecTubeEvac_C.Name = "lblSpecTubeEvac_C"
            Me.lblSpecTubeEvac_C.PaddingLeft = 3
            Me.lblSpecTubeEvac_C.PaddingRight = 3
            size2 = New Size(&H81, 20)
            Me.lblSpecTubeEvac_C.Size = size2
            Me.lblSpecTubeEvac_C.TabIndex = 14
            Me.lblSpecTubeEvac_C.Text = "Vent Time"
            Me.lblSpecTubeEvac_C.TextAlignment = StringAlignment.Center
            Me.lblTitlePressure_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitlePressure_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitlePressure_C.Dock = DockStyle.Fill
            Me.lblTitlePressure_C.ForeColor = Color.Black
            point2 = New Point(0, &H18)
            Me.lblTitlePressure_C.Location = point2
            padding2 = New Padding(0)
            Me.lblTitlePressure_C.Margin = padding2
            Me.lblTitlePressure_C.Name = "lblTitlePressure_C"
            Me.lblTitlePressure_C.PaddingLeft = 3
            Me.lblTitlePressure_C.PaddingRight = 3
            size2 = New Size(&H97, &H18)
            Me.lblTitlePressure_C.Size = size2
            Me.lblTitlePressure_C.TabIndex = 2
            Me.lblTitlePressure_C.Text = "Pressure"
            Me.lblTitlePressure_C.TextAlignment = StringAlignment.Far
            Me.lblTitleLeak_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleLeak_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleLeak_C.Dock = DockStyle.Fill
            Me.lblTitleLeak_C.ForeColor = Color.Black
            point2 = New Point(0, &H30)
            Me.lblTitleLeak_C.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleLeak_C.Margin = padding2
            Me.lblTitleLeak_C.Name = "lblTitleLeak_C"
            Me.lblTitleLeak_C.PaddingLeft = 3
            Me.lblTitleLeak_C.PaddingRight = 3
            size2 = New Size(&H97, &H18)
            Me.lblTitleLeak_C.Size = size2
            Me.lblTitleLeak_C.TabIndex = 3
            Me.lblTitleLeak_C.Text = "Leak"
            Me.lblTitleLeak_C.TextAlignment = StringAlignment.Far
            Me.lblTitleVent_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblTitleVent_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblTitleVent_C.Dock = DockStyle.Fill
            Me.lblTitleVent_C.ForeColor = Color.Black
            point2 = New Point(0, &H48)
            Me.lblTitleVent_C.Location = point2
            padding2 = New Padding(0)
            Me.lblTitleVent_C.Margin = padding2
            Me.lblTitleVent_C.Name = "lblTitleVent_C"
            Me.lblTitleVent_C.PaddingLeft = 3
            Me.lblTitleVent_C.PaddingRight = 3
            size2 = New Size(&H97, &H18)
            Me.lblTitleVent_C.Size = size2
            Me.lblTitleVent_C.TabIndex = 4
            Me.lblTitleVent_C.Text = "Vent Delta P"
            Me.lblTitleVent_C.TextAlignment = StringAlignment.Far
            Me.lblMeasPressure_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasPressure_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasPressure_C.Dock = DockStyle.Fill
            Me.lblMeasPressure_C.ForeColor = Color.Black
            point2 = New Point(&H97, &H18)
            Me.lblMeasPressure_C.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasPressure_C.Margin = padding2
            Me.lblMeasPressure_C.Name = "lblMeasPressure_C"
            Me.lblMeasPressure_C.PaddingLeft = 3
            Me.lblMeasPressure_C.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasPressure_C.Size = size2
            Me.lblMeasPressure_C.TabIndex = 5
            Me.lblMeasPressure_C.Text = "LabelX4"
            Me.lblMeasPressure_C.TextAlignment = StringAlignment.Center
            Me.lblMeasLeak_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasLeak_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasLeak_C.Dock = DockStyle.Fill
            Me.lblMeasLeak_C.ForeColor = Color.Black
            point2 = New Point(&H97, &H30)
            Me.lblMeasLeak_C.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasLeak_C.Margin = padding2
            Me.lblMeasLeak_C.Name = "lblMeasLeak_C"
            Me.lblMeasLeak_C.PaddingLeft = 3
            Me.lblMeasLeak_C.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasLeak_C.Size = size2
            Me.lblMeasLeak_C.TabIndex = 6
            Me.lblMeasLeak_C.Text = "LabelX5"
            Me.lblMeasLeak_C.TextAlignment = StringAlignment.Center
            Me.lblMeasVent_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblMeasVent_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblMeasVent_C.Dock = DockStyle.Fill
            Me.lblMeasVent_C.ForeColor = Color.Black
            point2 = New Point(&H97, &H48)
            Me.lblMeasVent_C.Location = point2
            padding2 = New Padding(0)
            Me.lblMeasVent_C.Margin = padding2
            Me.lblMeasVent_C.Name = "lblMeasVent_C"
            Me.lblMeasVent_C.PaddingLeft = 3
            Me.lblMeasVent_C.PaddingRight = 3
            size2 = New Size(&H61, &H18)
            Me.lblMeasVent_C.Size = size2
            Me.lblMeasVent_C.TabIndex = 7
            Me.lblMeasVent_C.Text = "LabelX6"
            Me.lblMeasVent_C.TextAlignment = StringAlignment.Center
            Me.lblSpecPressure_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecPressure_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecPressure_C.Dock = DockStyle.Fill
            Me.lblSpecPressure_C.ForeColor = Color.Black
            point2 = New Point(&HF8, &H18)
            Me.lblSpecPressure_C.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecPressure_C.Margin = padding2
            Me.lblSpecPressure_C.Name = "lblSpecPressure_C"
            Me.lblSpecPressure_C.PaddingLeft = 3
            Me.lblSpecPressure_C.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecPressure_C.Size = size2
            Me.lblSpecPressure_C.TabIndex = 8
            Me.lblSpecPressure_C.Text = "LabelX7"
            Me.lblSpecPressure_C.TextAlignment = StringAlignment.Center
            Me.lblSpecLeak_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecLeak_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecLeak_C.Dock = DockStyle.Fill
            Me.lblSpecLeak_C.ForeColor = Color.Black
            point2 = New Point(&HF8, &H30)
            Me.lblSpecLeak_C.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecLeak_C.Margin = padding2
            Me.lblSpecLeak_C.Name = "lblSpecLeak_C"
            Me.lblSpecLeak_C.PaddingLeft = 3
            Me.lblSpecLeak_C.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecLeak_C.Size = size2
            Me.lblSpecLeak_C.TabIndex = 9
            Me.lblSpecLeak_C.Text = "LabelX8"
            Me.lblSpecLeak_C.TextAlignment = StringAlignment.Center
            Me.lblSpecVent_C.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblSpecVent_C.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpecVent_C.Dock = DockStyle.Fill
            Me.lblSpecVent_C.ForeColor = Color.Black
            point2 = New Point(&HF8, &H48)
            Me.lblSpecVent_C.Location = point2
            padding2 = New Padding(0)
            Me.lblSpecVent_C.Margin = padding2
            Me.lblSpecVent_C.Name = "lblSpecVent_C"
            Me.lblSpecVent_C.PaddingLeft = 3
            Me.lblSpecVent_C.PaddingRight = 3
            size2 = New Size(&H81, &H18)
            Me.lblSpecVent_C.Size = size2
            Me.lblSpecVent_C.TabIndex = 10
            Me.lblSpecVent_C.Text = "LabelX9"
            Me.lblSpecVent_C.TextAlignment = StringAlignment.Center
            Me.LabelX16.BackColor = Color.Transparent
            Me.LabelX16.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX16.Dock = DockStyle.Fill
            Me.LabelX16.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX16.ForeColor = Color.Black
            point2 = New Point(3, 3)
            Me.LabelX16.Location = point2
            Me.LabelX16.Name = "LabelX16"
            Me.LabelX16.PaddingLeft = 3
            Me.LabelX16.PaddingRight = 3
            size2 = New Size(&H91, &H12)
            Me.LabelX16.Size = size2
            Me.LabelX16.TabIndex = 11
            Me.LabelX16.Text = "Metric"
            Me.LabelX16.TextAlignment = StringAlignment.Far
            Me.LabelX17.BackColor = Color.Transparent
            Me.LabelX17.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX17.Dock = DockStyle.Fill
            Me.LabelX17.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX17.ForeColor = Color.Black
            point2 = New Point(&H9A, 3)
            Me.LabelX17.Location = point2
            Me.LabelX17.Name = "LabelX17"
            Me.LabelX17.PaddingLeft = 3
            Me.LabelX17.PaddingRight = 3
            size2 = New Size(&H5B, &H12)
            Me.LabelX17.Size = size2
            Me.LabelX17.TabIndex = 12
            Me.LabelX17.Text = "Measure Value"
            Me.LabelX17.TextAlignment = StringAlignment.Center
            Me.LabelX18.BackColor = Color.Transparent
            Me.LabelX18.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX18.Dock = DockStyle.Fill
            Me.LabelX18.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.LabelX18.ForeColor = Color.Black
            point2 = New Point(&HFB, 3)
            Me.LabelX18.Location = point2
            Me.LabelX18.Name = "LabelX18"
            Me.LabelX18.PaddingLeft = 3
            Me.LabelX18.PaddingRight = 3
            size2 = New Size(&H7B, &H12)
            Me.LabelX18.Size = size2
            Me.LabelX18.TabIndex = 13
            Me.LabelX18.Text = "Specs"
            Me.LabelX18.TextAlignment = StringAlignment.Center
            Me.TableLayoutPanel4.BackColor = Color.Transparent
            Me.TableLayoutPanel4.ColumnCount = 2
            Me.TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.Chart1, 0, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Chart2, 1, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.GroupPanel1, 0, 2)
            Me.TableLayoutPanel4.Controls.Add(Me.GroupPanel2, 1, 2)
            Me.TableLayoutPanel4.Dock = DockStyle.Fill
            Me.TableLayoutPanel4.ForeColor = Color.Black
            point2 = New Point(3, 0)
            Me.TableLayoutPanel4.Location = point2
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 3
            Me.TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100!))
            Me.TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 141!))
            Me.TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            size2 = New Size(&H346, &H1AB)
            Me.TableLayoutPanel4.Size = size2
            Me.TableLayoutPanel4.TabIndex = 5
            Me.FlowLayoutPanel1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Bottom))
            Me.FlowLayoutPanel1.AutoSize = True
            Me.FlowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
            Me.FlowLayoutPanel1.BackColor = Color.FromArgb(&HD3, &HD3, &HD3)
            Me.TableLayoutPanel4.SetColumnSpan(Me.FlowLayoutPanel1, 2)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_TestInfo)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_TestID)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_Date)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_Time)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_Serial)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_RunNum)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_FUELRev)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_ScriptRev)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblHidden_Product)
            Me.FlowLayoutPanel1.ForeColor = Color.Black
            point2 = New Point(3, 270)
            Me.FlowLayoutPanel1.Location = point2
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            size2 = New Size(&H340, 13)
            Me.FlowLayoutPanel1.Size = size2
            Me.FlowLayoutPanel1.TabIndex = 8
            Me.lblHidden_TestInfo.AutoSize = True
            Me.lblHidden_TestInfo.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_TestInfo.ForeColor = Color.Black
            point2 = New Point(3, 0)
            Me.lblHidden_TestInfo.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_TestInfo.Margin = padding2
            Me.lblHidden_TestInfo.Name = "lblHidden_TestInfo"
            size2 = New Size(&H34, 13)
            Me.lblHidden_TestInfo.Size = size2
            Me.lblHidden_TestInfo.TabIndex = 8
            Me.lblHidden_TestInfo.Text = "Test Info:"
            Me.lblHidden_TestInfo.Visible = False
            Me.lblHidden_TestID.AutoSize = True
            Me.lblHidden_TestID.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_TestID.ForeColor = Color.Black
            point2 = New Point(&H3F, 0)
            Me.lblHidden_TestID.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_TestID.Margin = padding2
            Me.lblHidden_TestID.Name = "lblHidden_TestID"
            size2 = New Size(&H27, 13)
            Me.lblHidden_TestID.Size = size2
            Me.lblHidden_TestID.TabIndex = 0
            Me.lblHidden_TestID.Text = "TestID"
            Me.lblHidden_TestID.Visible = False
            Me.lblHidden_Date.AutoSize = True
            Me.lblHidden_Date.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_Date.ForeColor = Color.Black
            point2 = New Point(110, 0)
            Me.lblHidden_Date.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_Date.Margin = padding2
            Me.lblHidden_Date.Name = "lblHidden_Date"
            size2 = New Size(30, 13)
            Me.lblHidden_Date.Size = size2
            Me.lblHidden_Date.TabIndex = 1
            Me.lblHidden_Date.Text = "Date"
            Me.lblHidden_Date.Visible = False
            Me.lblHidden_Time.AutoSize = True
            Me.lblHidden_Time.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_Time.ForeColor = Color.Black
            point2 = New Point(&H94, 0)
            Me.lblHidden_Time.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_Time.Margin = padding2
            Me.lblHidden_Time.Name = "lblHidden_Time"
            size2 = New Size(30, 13)
            Me.lblHidden_Time.Size = size2
            Me.lblHidden_Time.TabIndex = 2
            Me.lblHidden_Time.Text = "Time"
            Me.lblHidden_Time.Visible = False
            Me.lblHidden_Serial.AutoSize = True
            Me.lblHidden_Serial.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_Serial.ForeColor = Color.Black
            point2 = New Point(&HBA, 0)
            Me.lblHidden_Serial.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_Serial.Margin = padding2
            Me.lblHidden_Serial.Name = "lblHidden_Serial"
            size2 = New Size(&H21, 13)
            Me.lblHidden_Serial.Size = size2
            Me.lblHidden_Serial.TabIndex = 3
            Me.lblHidden_Serial.Text = "Serial"
            Me.lblHidden_Serial.Visible = False
            Me.lblHidden_RunNum.AutoSize = True
            Me.lblHidden_RunNum.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_RunNum.ForeColor = Color.Black
            point2 = New Point(&HE3, 0)
            Me.lblHidden_RunNum.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_RunNum.Margin = padding2
            Me.lblHidden_RunNum.Name = "lblHidden_RunNum"
            size2 = New Size(&H31, 13)
            Me.lblHidden_RunNum.Size = size2
            Me.lblHidden_RunNum.TabIndex = 4
            Me.lblHidden_RunNum.Text = "RunNum"
            Me.lblHidden_RunNum.Visible = False
            Me.lblHidden_FUELRev.AutoSize = True
            Me.lblHidden_FUELRev.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_FUELRev.ForeColor = Color.Black
            point2 = New Point(&H11C, 0)
            Me.lblHidden_FUELRev.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_FUELRev.Margin = padding2
            Me.lblHidden_FUELRev.Name = "lblHidden_FUELRev"
            size2 = New Size(&H36, 13)
            Me.lblHidden_FUELRev.Size = size2
            Me.lblHidden_FUELRev.TabIndex = 5
            Me.lblHidden_FUELRev.Text = "FUELRev"
            Me.lblHidden_FUELRev.Visible = False
            Me.lblHidden_ScriptRev.AutoSize = True
            Me.lblHidden_ScriptRev.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_ScriptRev.ForeColor = Color.Black
            point2 = New Point(&H15A, 0)
            Me.lblHidden_ScriptRev.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_ScriptRev.Margin = padding2
            Me.lblHidden_ScriptRev.Name = "lblHidden_ScriptRev"
            size2 = New Size(&H36, 13)
            Me.lblHidden_ScriptRev.Size = size2
            Me.lblHidden_ScriptRev.TabIndex = 6
            Me.lblHidden_ScriptRev.Text = "ScriptRev"
            Me.lblHidden_ScriptRev.Visible = False
            Me.lblHidden_Product.AutoSize = True
            Me.lblHidden_Product.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblHidden_Product.ForeColor = Color.Black
            point2 = New Point(&H198, 0)
            Me.lblHidden_Product.Location = point2
            padding2 = New Padding(3, 0, 5, 0)
            Me.lblHidden_Product.Margin = padding2
            Me.lblHidden_Product.Name = "lblHidden_Product"
            size2 = New Size(&H2C, 13)
            Me.lblHidden_Product.Size = size2
            Me.lblHidden_Product.TabIndex = 7
            Me.lblHidden_Product.Text = "Product"
            Me.lblHidden_Product.Visible = False
            Me.Chart1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            item.AlignmentOrientation = AreaAlignmentOrientations.Horizontal
            item.AxisX.Title = "Time"
            item.AxisY.Minimum = -20
            item.AxisY.Title = "Pressure (in. of water)"
            item.BackColor = Color.Transparent
            item.IsSameFontSizeForAllAxes = True
            item.Name = "ChartArea1"
            Me.Chart1.ChartAreas.Add(item)
            Me.Chart1.Dock = DockStyle.Fill
            point2 = New Point(0, 0)
            Me.Chart1.Location = point2
            padding2 = New Padding(0)
            Me.Chart1.Margin = padding2
            Me.Chart1.Name = "Chart1"
            size2 = New Size(&H1A3, &H10A)
            Me.Chart1.Size = size2
            Me.Chart1.TabIndex = 5
            Me.Chart1.Text = "Chart1"
            title.Alignment = ContentAlignment.TopCenter
            title.DockedToChartArea = "ChartArea1"
            title.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            title.IsDockedInsideChartArea = False
            title.Name = "Title1"
            title.Text = "Black Pressure"
            Me.Chart1.Titles.Add(title)
            Me.Chart2.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            area2.AxisX.MajorTickMark.Enabled = False
            area2.AxisX.MinorGrid.LineColor = Color.Gray
            area2.AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.NotSet
            area2.AxisX.Title = "Time"
            area2.AxisY.Title = "Pressure (in. of water)"
            area2.BackColor = Color.Transparent
            area2.IsSameFontSizeForAllAxes = True
            area2.Name = "ChartArea1"
            Me.Chart2.ChartAreas.Add(area2)
            Me.Chart2.Dock = DockStyle.Fill
            point2 = New Point(&H1A3, 0)
            Me.Chart2.Location = point2
            padding2 = New Padding(0)
            Me.Chart2.Margin = padding2
            Me.Chart2.Name = "Chart2"
            size2 = New Size(&H1A3, &H10A)
            Me.Chart2.Size = size2
            Me.Chart2.TabIndex = 6
            title2.Alignment = ContentAlignment.TopCenter
            title2.DockedToChartArea = "ChartArea1"
            title2.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            title2.IsDockedInsideChartArea = False
            title2.Name = "Title1"
            title2.Text = "Color Pressure"
            Me.Chart2.Titles.Add(title2)
            Me.MetroShell1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.MetroShell1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square
            Me.MetroShell1.CanCustomize = False
            Me.MetroShell1.CaptionVisible = True
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel4)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel2)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel1)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel6)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel5)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel3)
            Me.MetroShell1.ForeColor = Color.Black
            Me.MetroShell1.HelpButtonText = Nothing
            Me.MetroShell1.HelpButtonVisible = False
            Dim items As BaseItem() = New BaseItem() { Me.MetroAppButton1, Me.MetroTabItem1, Me.MetroTabItem2, Me.MetroTabItem4, Me.MetroTabItem3, Me.tabTriage, Me.tabHelp, Me.ButtonItem4 }
            Me.MetroShell1.Items.AddRange(items)
            Me.MetroShell1.KeyTipsFont = New Font("Tahoma", 7!)
            point2 = New Point(0, 0)
            Me.MetroShell1.Location = point2
            padding2 = New Padding(0)
            Me.MetroShell1.Margin = padding2
            Me.MetroShell1.Name = "MetroShell1"
            items = New BaseItem() { Me.ButtonItem1 }
            Me.MetroShell1.QuickToolbarItems.AddRange(items)
            Me.MetroShell1.SettingsButtonVisible = False
            size2 = New Size(&H34C, &H1E1)
            Me.MetroShell1.Size = size2
            Me.MetroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.MetroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.MetroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.MetroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.MetroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.MetroShell1.SystemText.QatDialogAddButton = "&Add >>"
            Me.MetroShell1.SystemText.QatDialogCancelButton = "Cancel"
            Me.MetroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.MetroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.MetroShell1.SystemText.QatDialogOkButton = "OK"
            Me.MetroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.MetroShell1.SystemText.QatDialogRemoveButton = "&Remove"
            Me.MetroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.MetroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.MetroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.MetroShell1.TabIndex = 6
            Me.MetroShell1.TabStripFont = New Font("Segoe UI", 10.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.MetroShell1.Text = "Priming Systems Test"
            Me.MetroShell1.TitleText = "Priming Systems Test"
            Me.MetroShell1.UseCustomizeDialog = False
            Me.MetroTabPanel1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_Run)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_TestID)
            Me.MetroTabPanel1.Controls.Add(Me.PictureBox1)
            Me.MetroTabPanel1.Controls.Add(Me.ReflectionLabel4)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_ScriptProduct)
            Me.MetroTabPanel1.Controls.Add(Me.lstSummaryMechChecks)
            Me.MetroTabPanel1.Controls.Add(Me.LabelX1)
            Me.MetroTabPanel1.Controls.Add(Me.lblFailModes)
            Me.MetroTabPanel1.Controls.Add(Me.ReflectionLabel5)
            Me.MetroTabPanel1.Controls.Add(Me.ReflectionLabel3)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_PSTColor)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_PSTBlack)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_EngPgCnt)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_FW)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_SerialNum)
            Me.MetroTabPanel1.Controls.Add(Me.ReflectionLabel1)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_TestTime)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_TestDate)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_ScriptRev)
            Me.MetroTabPanel1.Controls.Add(Me.lblSummary_FuelRev)
            Me.MetroTabPanel1.Controls.Add(Me.ReflectionLabel2)
            Me.MetroTabPanel1.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel1.Location = point2
            Me.MetroTabPanel1.Name = "MetroTabPanel1"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel1.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel1.Size = size2
            Me.MetroTabPanel1.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel1.TabIndex = 1
            Me.MetroTabPanel1.Visible = False
            Me.lblSummary_Run.BackColor = Color.Transparent
            Me.lblSummary_Run.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_Run.ForeColor = Color.Black
            point2 = New Point(12, &HB2)
            Me.lblSummary_Run.Location = point2
            Me.lblSummary_Run.Name = "lblSummary_Run"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_Run.Size = size2
            Me.lblSummary_Run.TabIndex = &H25
            Me.lblSummary_Run.Text = "Run"
            Me.lblSummary_TestID.BackColor = Color.Transparent
            Me.lblSummary_TestID.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_TestID.ForeColor = Color.Black
            point2 = New Point(12, &H9B)
            Me.lblSummary_TestID.Location = point2
            Me.lblSummary_TestID.Name = "lblSummary_TestID"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_TestID.Size = size2
            Me.lblSummary_TestID.TabIndex = &H24
            Me.lblSummary_TestID.Text = "Test ID"
            Me.PictureBox1.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.PictureBox1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.PictureBox1.ForeColor = Color.Black
            Me.PictureBox1.Image = DirectCast(manager.GetObject("PictureBox1.Image"), Image)
            point2 = New Point(&H1CB, &H155)
            Me.PictureBox1.Location = point2
            Me.PictureBox1.Name = "PictureBox1"
            size2 = New Size(&H4D, &H53)
            Me.PictureBox1.Size = size2
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox1.TabIndex = &H16
            Me.PictureBox1.TabStop = False
            Me.ReflectionLabel4.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.ReflectionLabel4.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.ReflectionLabel4.BackgroundStyle.CornerType = eCornerType.Square
            Me.ReflectionLabel4.ForeColor = Color.Black
            point2 = New Point(&H21E, &H155)
            Me.ReflectionLabel4.Location = point2
            Me.ReflectionLabel4.Name = "ReflectionLabel4"
            size2 = New Size(&H12B, &H53)
            Me.ReflectionLabel4.Size = size2
            Me.ReflectionLabel4.TabIndex = &H15
            Me.ReflectionLabel4.Text = "<b><font size=""+15"">Test Status: <font color=""#009303"">Passed</font></font></b>"
            Me.lblSummary_ScriptProduct.BackColor = Color.Transparent
            Me.lblSummary_ScriptProduct.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_ScriptProduct.ForeColor = Color.Black
            point2 = New Point(12, &H56)
            Me.lblSummary_ScriptProduct.Location = point2
            Me.lblSummary_ScriptProduct.Name = "lblSummary_ScriptProduct"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_ScriptProduct.Size = size2
            Me.lblSummary_ScriptProduct.TabIndex = &H23
            Me.lblSummary_ScriptProduct.Text = "Script Product"
            Me.lstSummaryMechChecks.Activation = ItemActivation.OneClick
            Me.lstSummaryMechChecks.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lstSummaryMechChecks.Border.BorderBottom = eStyleBorderType.Solid
            Me.lstSummaryMechChecks.Border.BorderColor = Color.FromArgb(180, 180, &H8D)
            Me.lstSummaryMechChecks.Border.BorderLeft = eStyleBorderType.Solid
            Me.lstSummaryMechChecks.Border.BorderRight = eStyleBorderType.Solid
            Me.lstSummaryMechChecks.Border.BorderTop = eStyleBorderType.Solid
            Me.lstSummaryMechChecks.Border.Class = "ListViewBorder"
            Me.lstSummaryMechChecks.Border.CornerDiameter = 0
            Me.lstSummaryMechChecks.Border.CornerType = eCornerType.Square
            Dim values As ColumnHeader() = New ColumnHeader() { Me.ColumnHeader2 }
            Me.lstSummaryMechChecks.Columns.AddRange(values)
            Me.lstSummaryMechChecks.Cursor = Cursors.Default
            Me.lstSummaryMechChecks.DisabledBackColor = Color.Empty
            Me.lstSummaryMechChecks.ForeColor = Color.Black
            Me.lstSummaryMechChecks.HeaderStyle = ColumnHeaderStyle.None
            Me.lstSummaryMechChecks.HotTracking = True
            Me.lstSummaryMechChecks.HoverSelection = True
            point2 = New Point(&HF8, &H97)
            Me.lstSummaryMechChecks.Location = point2
            Me.lstSummaryMechChecks.MultiSelect = False
            Me.lstSummaryMechChecks.Name = "lstSummaryMechChecks"
            size2 = New Size(&HD3, &H103)
            Me.lstSummaryMechChecks.Size = size2
            Me.lstSummaryMechChecks.SmallImageList = Me.ImageList1
            Me.lstSummaryMechChecks.TabIndex = &H22
            Me.lstSummaryMechChecks.UseCompatibleStateImageBehavior = False
            Me.lstSummaryMechChecks.View = View.Details
            Me.ColumnHeader2.Text = "col2"
            Me.ColumnHeader2.Width = 20
            Me.ImageList1.ImageStream = DirectCast(manager.GetObject("ImageList1.ImageStream"), ImageListStreamer)
            Me.ImageList1.TransparentColor = Color.White
            Me.ImageList1.Images.SetKeyName(0, "Good-or-Tick-icon-sm.png")
            Me.ImageList1.Images.SetKeyName(1, "Error-icon-sm.png")
            Me.ImageList1.Images.SetKeyName(2, "warning_sm.png")
            Me.LabelX1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX1.ForeColor = Color.Black
            point2 = New Point(&H216, &H24)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&H130, &H9C)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = &H18
            Me.LabelX1.Text = manager.GetString("LabelX1.Text")
            Me.LabelX1.TextLineAlignment = StringAlignment.Near
            Me.LabelX1.Visible = False
            Me.lblFailModes.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.lblFailModes.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblFailModes.ForeColor = Color.Black
            point2 = New Point(&H216, 11)
            Me.lblFailModes.Location = point2
            Me.lblFailModes.Name = "lblFailModes"
            size2 = New Size(&H130, &H17)
            Me.lblFailModes.Size = size2
            Me.lblFailModes.TabIndex = &H17
            Me.lblFailModes.Visible = False
            Me.ReflectionLabel5.BackColor = Color.Transparent
            Me.ReflectionLabel5.BackgroundStyle.CornerType = eCornerType.Square
            Me.ReflectionLabel5.ForeColor = Color.Black
            point2 = New Point(&HF8, &H71)
            Me.ReflectionLabel5.Location = point2
            Me.ReflectionLabel5.Name = "ReflectionLabel5"
            size2 = New Size(&HDA, &H29)
            Me.ReflectionLabel5.Size = size2
            Me.ReflectionLabel5.TabIndex = 5
            Me.ReflectionLabel5.Text = "<b><font size=""+6"">Mech Check Summary</font></b>"
            Me.ReflectionLabel3.BackColor = Color.Transparent
            Me.ReflectionLabel3.BackgroundStyle.CornerType = eCornerType.Square
            Me.ReflectionLabel3.ForeColor = Color.Black
            point2 = New Point(12, &HD5)
            Me.ReflectionLabel3.Location = point2
            Me.ReflectionLabel3.Name = "ReflectionLabel3"
            size2 = New Size(&HAF, &H29)
            Me.ReflectionLabel3.Size = size2
            Me.ReflectionLabel3.TabIndex = 3
            Me.ReflectionLabel3.Text = "<b><font size=""+6"">Prime Pressures</font></b>"
            Me.lblSummary_PSTColor.BackColor = Color.Transparent
            Me.lblSummary_PSTColor.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_PSTColor.Cursor = Cursors.Hand
            Me.lblSummary_PSTColor.ForeColor = Color.Black
            Me.lblSummary_PSTColor.Image = DirectCast(manager.GetObject("lblSummary_PSTColor.Image"), Image)
            point2 = New Point(12, &H112)
            Me.lblSummary_PSTColor.Location = point2
            Me.lblSummary_PSTColor.Name = "lblSummary_PSTColor"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_PSTColor.Size = size2
            Me.lblSummary_PSTColor.TabIndex = 14
            Me.lblSummary_PSTColor.Text = "Color: Passed"
            Me.lblSummary_PSTBlack.BackColor = Color.Transparent
            Me.lblSummary_PSTBlack.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_PSTBlack.Cursor = Cursors.Hand
            Me.lblSummary_PSTBlack.ForeColor = Color.Black
            Me.lblSummary_PSTBlack.Image = DirectCast(manager.GetObject("lblSummary_PSTBlack.Image"), Image)
            point2 = New Point(12, &HFB)
            Me.lblSummary_PSTBlack.Location = point2
            Me.lblSummary_PSTBlack.Name = "lblSummary_PSTBlack"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_PSTBlack.Size = size2
            Me.lblSummary_PSTBlack.TabIndex = 13
            Me.lblSummary_PSTBlack.Text = "Black: Passed"
            Me.lblSummary_EngPgCnt.BackColor = Color.Transparent
            Me.lblSummary_EngPgCnt.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_EngPgCnt.ForeColor = Color.Black
            point2 = New Point(&HF8, &H56)
            Me.lblSummary_EngPgCnt.Location = point2
            Me.lblSummary_EngPgCnt.Name = "lblSummary_EngPgCnt"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_EngPgCnt.Size = size2
            Me.lblSummary_EngPgCnt.TabIndex = 12
            Me.lblSummary_EngPgCnt.Text = "Engine Page Count: "
            Me.lblSummary_FW.BackColor = Color.Transparent
            Me.lblSummary_FW.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_FW.ForeColor = Color.Black
            point2 = New Point(&HF8, &H3F)
            Me.lblSummary_FW.Location = point2
            Me.lblSummary_FW.Name = "lblSummary_FW"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_FW.Size = size2
            Me.lblSummary_FW.TabIndex = 11
            Me.lblSummary_FW.Text = "FW Rev:"
            Me.lblSummary_SerialNum.BackColor = Color.Transparent
            Me.lblSummary_SerialNum.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_SerialNum.ForeColor = Color.Black
            point2 = New Point(&HF8, 40)
            Me.lblSummary_SerialNum.Location = point2
            Me.lblSummary_SerialNum.Name = "lblSummary_SerialNum"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_SerialNum.Size = size2
            Me.lblSummary_SerialNum.TabIndex = 10
            Me.lblSummary_SerialNum.Text = "Serial Number:"
            Me.ReflectionLabel1.BackColor = Color.Transparent
            Me.ReflectionLabel1.BackgroundStyle.CornerType = eCornerType.Square
            Me.ReflectionLabel1.ForeColor = Color.Black
            point2 = New Point(12, 3)
            Me.ReflectionLabel1.Location = point2
            Me.ReflectionLabel1.Name = "ReflectionLabel1"
            size2 = New Size(&HAF, &H29)
            Me.ReflectionLabel1.Size = size2
            Me.ReflectionLabel1.TabIndex = 1
            Me.ReflectionLabel1.Text = "<b><font size=""+6"">Test Setup</font></b>"
            Me.lblSummary_TestTime.BackColor = Color.Transparent
            Me.lblSummary_TestTime.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_TestTime.ForeColor = Color.Black
            point2 = New Point(12, &H84)
            Me.lblSummary_TestTime.Location = point2
            Me.lblSummary_TestTime.Name = "lblSummary_TestTime"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_TestTime.Size = size2
            Me.lblSummary_TestTime.TabIndex = 9
            Me.lblSummary_TestTime.Text = "Test Time"
            Me.lblSummary_TestDate.BackColor = Color.Transparent
            Me.lblSummary_TestDate.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_TestDate.ForeColor = Color.Black
            point2 = New Point(12, &H6D)
            Me.lblSummary_TestDate.Location = point2
            Me.lblSummary_TestDate.Name = "lblSummary_TestDate"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_TestDate.Size = size2
            Me.lblSummary_TestDate.TabIndex = 8
            Me.lblSummary_TestDate.Text = "Test Date"
            Me.lblSummary_ScriptRev.BackColor = Color.Transparent
            Me.lblSummary_ScriptRev.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_ScriptRev.ForeColor = Color.Black
            point2 = New Point(12, &H3F)
            Me.lblSummary_ScriptRev.Location = point2
            Me.lblSummary_ScriptRev.Name = "lblSummary_ScriptRev"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_ScriptRev.Size = size2
            Me.lblSummary_ScriptRev.TabIndex = 7
            Me.lblSummary_ScriptRev.Text = "Script Rev"
            Me.lblSummary_FuelRev.BackColor = Color.Transparent
            Me.lblSummary_FuelRev.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSummary_FuelRev.ForeColor = Color.Black
            point2 = New Point(12, 40)
            Me.lblSummary_FuelRev.Location = point2
            Me.lblSummary_FuelRev.Name = "lblSummary_FuelRev"
            size2 = New Size(&HAF, &H17)
            Me.lblSummary_FuelRev.Size = size2
            Me.lblSummary_FuelRev.TabIndex = 6
            Me.lblSummary_FuelRev.Text = "Fuel Rev"
            Me.ReflectionLabel2.BackColor = Color.Transparent
            Me.ReflectionLabel2.BackgroundStyle.CornerType = eCornerType.Square
            Me.ReflectionLabel2.ForeColor = Color.Black
            point2 = New Point(&HF8, 3)
            Me.ReflectionLabel2.Location = point2
            Me.ReflectionLabel2.Name = "ReflectionLabel2"
            size2 = New Size(&HDA, &H29)
            Me.ReflectionLabel2.Size = size2
            Me.ReflectionLabel2.TabIndex = 2
            Me.ReflectionLabel2.Text = "<b><font size=""+6"">Printer Information</font></b>"
            Me.MetroTabPanel5.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel5.Controls.Add(Me.SuperTabControl1)
            Me.MetroTabPanel5.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel5.Location = point2
            Me.MetroTabPanel5.Name = "MetroTabPanel5"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel5.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel5.Size = size2
            Me.MetroTabPanel5.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel5.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel5.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel5.TabIndex = 6
            Me.MetroTabPanel5.Visible = False
            Me.SuperTabControl1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.SuperTabControl1.CloseButtonOnTabsAlwaysDisplayed = False
            Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
            Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
            Me.SuperTabControl1.ControlBox.Name = ""
            items = New BaseItem() { Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox }
            Me.SuperTabControl1.ControlBox.SubItems.AddRange(items)
            Me.SuperTabControl1.ControlBox.Visible = False
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel6)
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
            Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
            Me.SuperTabControl1.Dock = DockStyle.Fill
            Me.SuperTabControl1.ForeColor = Color.Black
            point2 = New Point(3, 0)
            Me.SuperTabControl1.Location = point2
            Me.SuperTabControl1.Name = "SuperTabControl1"
            Me.SuperTabControl1.ReorderTabsEnabled = False
            Me.SuperTabControl1.SelectedTabFont = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)
            Me.SuperTabControl1.SelectedTabIndex = 0
            size2 = New Size(&H346, &H1AB)
            Me.SuperTabControl1.Size = size2
            Me.SuperTabControl1.TabAlignment = eTabStripAlignment.Left
            Me.SuperTabControl1.TabFont = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.SuperTabControl1.TabIndex = 0
            items = New BaseItem() { Me.stiPSTDocs_Intro, Me.stiPSTDocs_Outputs, Me.stiPSTDocs_NoPressure, Me.stiPSTDocs_DelayedPressure, Me.stiPSTDocs_CyclicalPressure, Me.stiPSTDocs_PressureFluctuates }
            Me.SuperTabControl1.Tabs.AddRange(items)
            Me.SuperTabControl1.TabStyle = eSuperTabStyle.Office2010BackstageBlue
            Me.SuperTabControl1.Text = "SuperTabControl1"
            Me.SuperTabControlPanel1.Controls.Add(Me.rtbPSTDocs_Intro)
            Me.SuperTabControlPanel1.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel1.Location = point2
            Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel1.Size = size2
            Me.SuperTabControlPanel1.TabIndex = 1
            Me.SuperTabControlPanel1.TabItem = Me.stiPSTDocs_Intro
            Me.rtbPSTDocs_Intro.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_Intro.BorderStyle = BorderStyle.FixedSingle
            Me.rtbPSTDocs_Intro.BulletIndent = 4
            Me.rtbPSTDocs_Intro.Dock = DockStyle.Fill
            Me.rtbPSTDocs_Intro.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_Intro.Location = point2
            Me.rtbPSTDocs_Intro.Name = "rtbPSTDocs_Intro"
            Me.rtbPSTDocs_Intro.ReadOnly = True
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_Intro.Size = size2
            Me.rtbPSTDocs_Intro.TabIndex = 1
            Me.rtbPSTDocs_Intro.Text = ""
            Me.stiPSTDocs_Intro.AttachedControl = Me.SuperTabControlPanel1
            Me.stiPSTDocs_Intro.GlobalItem = False
            Me.stiPSTDocs_Intro.Name = "stiPSTDocs_Intro"
            Me.stiPSTDocs_Intro.Text = "Introduction"
            Me.SuperTabControlPanel6.Controls.Add(Me.rtbPSTDocs_PSTOutputs)
            Me.SuperTabControlPanel6.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel6.Location = point2
            Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel6.Size = size2
            Me.SuperTabControlPanel6.TabIndex = 0
            Me.SuperTabControlPanel6.TabItem = Me.stiPSTDocs_Outputs
            Me.rtbPSTDocs_PSTOutputs.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_PSTOutputs.Dock = DockStyle.Fill
            Me.rtbPSTDocs_PSTOutputs.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_PSTOutputs.Location = point2
            Me.rtbPSTDocs_PSTOutputs.Name = "rtbPSTDocs_PSTOutputs"
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_PSTOutputs.Size = size2
            Me.rtbPSTDocs_PSTOutputs.TabIndex = 0
            Me.rtbPSTDocs_PSTOutputs.Text = ""
            Me.stiPSTDocs_Outputs.AttachedControl = Me.SuperTabControlPanel6
            Me.stiPSTDocs_Outputs.GlobalItem = False
            Me.stiPSTDocs_Outputs.Name = "stiPSTDocs_Outputs"
            Me.stiPSTDocs_Outputs.Text = "PST Outputs"
            Me.SuperTabControlPanel3.Controls.Add(Me.rtbPSTDocs_DelayedPressure)
            Me.SuperTabControlPanel3.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel3.Location = point2
            Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel3.Size = size2
            Me.SuperTabControlPanel3.TabIndex = 0
            Me.SuperTabControlPanel3.TabItem = Me.stiPSTDocs_DelayedPressure
            Me.rtbPSTDocs_DelayedPressure.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_DelayedPressure.Dock = DockStyle.Fill
            Me.rtbPSTDocs_DelayedPressure.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_DelayedPressure.Location = point2
            Me.rtbPSTDocs_DelayedPressure.Name = "rtbPSTDocs_DelayedPressure"
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_DelayedPressure.Size = size2
            Me.rtbPSTDocs_DelayedPressure.TabIndex = 0
            Me.rtbPSTDocs_DelayedPressure.Text = ""
            Me.stiPSTDocs_DelayedPressure.AttachedControl = Me.SuperTabControlPanel3
            Me.stiPSTDocs_DelayedPressure.GlobalItem = False
            Me.stiPSTDocs_DelayedPressure.Name = "stiPSTDocs_DelayedPressure"
            Me.stiPSTDocs_DelayedPressure.Text = "Delayed Pressure"
            Me.SuperTabControlPanel4.Controls.Add(Me.rtbPSTDocs_CyclicalPressure)
            Me.SuperTabControlPanel4.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel4.Location = point2
            Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel4.Size = size2
            Me.SuperTabControlPanel4.TabIndex = 0
            Me.SuperTabControlPanel4.TabItem = Me.stiPSTDocs_CyclicalPressure
            Me.rtbPSTDocs_CyclicalPressure.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_CyclicalPressure.Dock = DockStyle.Fill
            Me.rtbPSTDocs_CyclicalPressure.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_CyclicalPressure.Location = point2
            Me.rtbPSTDocs_CyclicalPressure.Name = "rtbPSTDocs_CyclicalPressure"
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_CyclicalPressure.Size = size2
            Me.rtbPSTDocs_CyclicalPressure.TabIndex = 0
            Me.rtbPSTDocs_CyclicalPressure.Text = ""
            Me.stiPSTDocs_CyclicalPressure.AttachedControl = Me.SuperTabControlPanel4
            Me.stiPSTDocs_CyclicalPressure.GlobalItem = False
            Me.stiPSTDocs_CyclicalPressure.Name = "stiPSTDocs_CyclicalPressure"
            Me.stiPSTDocs_CyclicalPressure.Text = "Cyclical Pressure"
            Me.SuperTabControlPanel2.Controls.Add(Me.rtbPSTDocs_NoPressure)
            Me.SuperTabControlPanel2.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel2.Location = point2
            Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel2.Size = size2
            Me.SuperTabControlPanel2.TabIndex = 0
            Me.SuperTabControlPanel2.TabItem = Me.stiPSTDocs_NoPressure
            Me.rtbPSTDocs_NoPressure.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_NoPressure.Dock = DockStyle.Fill
            Me.rtbPSTDocs_NoPressure.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_NoPressure.Location = point2
            Me.rtbPSTDocs_NoPressure.Name = "rtbPSTDocs_NoPressure"
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_NoPressure.Size = size2
            Me.rtbPSTDocs_NoPressure.TabIndex = 0
            Me.rtbPSTDocs_NoPressure.Text = ""
            Me.stiPSTDocs_NoPressure.AttachedControl = Me.SuperTabControlPanel2
            Me.stiPSTDocs_NoPressure.GlobalItem = False
            Me.stiPSTDocs_NoPressure.Name = "stiPSTDocs_NoPressure"
            Me.stiPSTDocs_NoPressure.Text = "No Pressure"
            Me.SuperTabControlPanel5.Controls.Add(Me.rtbPSTDocs_PressureFluctuates)
            Me.SuperTabControlPanel5.Dock = DockStyle.Fill
            point2 = New Point(120, 0)
            Me.SuperTabControlPanel5.Location = point2
            Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
            size2 = New Size(&H2CE, &H1AB)
            Me.SuperTabControlPanel5.Size = size2
            Me.SuperTabControlPanel5.TabIndex = 2
            Me.SuperTabControlPanel5.TabItem = Me.stiPSTDocs_PressureFluctuates
            Me.rtbPSTDocs_PressureFluctuates.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.rtbPSTDocs_PressureFluctuates.Dock = DockStyle.Fill
            Me.rtbPSTDocs_PressureFluctuates.ForeColor = Color.Black
            point2 = New Point(0, 0)
            Me.rtbPSTDocs_PressureFluctuates.Location = point2
            Me.rtbPSTDocs_PressureFluctuates.Name = "rtbPSTDocs_PressureFluctuates"
            size2 = New Size(&H2CE, &H1AB)
            Me.rtbPSTDocs_PressureFluctuates.Size = size2
            Me.rtbPSTDocs_PressureFluctuates.TabIndex = 0
            Me.rtbPSTDocs_PressureFluctuates.Text = ""
            Me.stiPSTDocs_PressureFluctuates.AttachedControl = Me.SuperTabControlPanel5
            Me.stiPSTDocs_PressureFluctuates.GlobalItem = False
            Me.stiPSTDocs_PressureFluctuates.Name = "stiPSTDocs_PressureFluctuates"
            Me.stiPSTDocs_PressureFluctuates.Text = "Pressure Fluctuates"
            Me.MetroTabPanel6.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel6.Controls.Add(Me.ButtonX2)
            Me.MetroTabPanel6.Controls.Add(Me.ButtonX1)
            Me.MetroTabPanel6.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel6.Location = point2
            Me.MetroTabPanel6.Name = "MetroTabPanel6"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel6.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel6.Size = size2
            Me.MetroTabPanel6.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel6.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel6.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel6.TabIndex = 7
            Me.MetroTabPanel6.Visible = False
            Me.ButtonX2.AccessibleRole = AccessibleRole.PushButton
            Me.ButtonX2.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(13, &H2E)
            Me.ButtonX2.Location = point2
            Me.ButtonX2.Name = "ButtonX2"
            size2 = New Size(&H4B, &H17)
            Me.ButtonX2.Size = size2
            Me.ButtonX2.Style = eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX2.TabIndex = 1
            Me.ButtonX2.Text = "ButtonX2"
            Me.ButtonX1.AccessibleRole = AccessibleRole.PushButton
            Me.ButtonX1.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(10, 11)
            Me.ButtonX1.Location = point2
            Me.ButtonX1.Name = "ButtonX1"
            size2 = New Size(&H4B, &H17)
            Me.ButtonX1.Size = size2
            Me.ButtonX1.Style = eDotNetBarStyle.StyleManagerControlled
            Me.ButtonX1.TabIndex = 0
            Me.ButtonX1.Text = "ButtonX1"
            Me.MetroTabPanel2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel2.Controls.Add(Me.TableLayoutPanel4)
            Me.MetroTabPanel2.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel2.Location = point2
            Me.MetroTabPanel2.Name = "MetroTabPanel2"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel2.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel2.Size = size2
            Me.MetroTabPanel2.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel2.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel2.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel2.TabIndex = 2
            Me.MetroTabPanel2.Visible = False
            Me.MetroTabPanel4.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel4.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel4.Location = point2
            Me.MetroTabPanel4.Name = "MetroTabPanel4"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel4.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel4.Size = size2
            Me.MetroTabPanel4.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel4.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel4.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel4.TabIndex = 4
            Me.MetroTabPanel3.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel3.Controls.Add(Me.TableLayoutPanel5)
            Me.MetroTabPanel3.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel3.Location = point2
            Me.MetroTabPanel3.Name = "MetroTabPanel3"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel3.Padding = padding2
            size2 = New Size(&H34C, 430)
            Me.MetroTabPanel3.Size = size2
            Me.MetroTabPanel3.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel3.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel3.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel3.TabIndex = 5
            Me.MetroTabPanel3.Visible = False
            Me.TableLayoutPanel5.BackColor = Color.Transparent
            Me.TableLayoutPanel5.ColumnCount = 3
            Me.TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 145!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 145!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle)
            Me.TableLayoutPanel5.Controls.Add(Me.cmdDataSelect, 0, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.Chart3, 2, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.Chart4, 2, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.lblHistory_TotalUnits, 0, &H12)
            Me.TableLayoutPanel5.Controls.Add(Me.cboRunCharts, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.sgcHistory, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.cboHistory_XVal, 0, 2)
            Me.TableLayoutPanel5.Controls.Add(Me.cboHistory_YVal, 1, 2)
            Me.TableLayoutPanel5.Controls.Add(Me.cboHistory_Series, 0, 4)
            Me.TableLayoutPanel5.Controls.Add(Me.lblHistory_XVal, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.lblHistory_YVal, 1, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.lblHistory_Series, 0, 3)
            Me.TableLayoutPanel5.Controls.Add(Me.cmdHistory_ChartIt, 1, 4)
            Me.TableLayoutPanel5.Controls.Add(Me.cmdHistory_DataGrid_Edit, 0, &H11)
            Me.TableLayoutPanel5.Dock = DockStyle.Fill
            Me.TableLayoutPanel5.ForeColor = Color.Black
            point2 = New Point(3, 0)
            Me.TableLayoutPanel5.Location = point2
            padding2 = New Padding(0)
            Me.TableLayoutPanel5.Margin = padding2
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 5
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 35!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 100!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            Me.TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            size2 = New Size(&H346, &H1AB)
            Me.TableLayoutPanel5.Size = size2
            Me.TableLayoutPanel5.TabIndex = 2
            Me.cmdDataSelect.AccessibleRole = AccessibleRole.PushButton
            Me.cmdDataSelect.AutoExpandOnClick = True
            Me.cmdDataSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink
            Me.cmdDataSelect.ColorTable = eButtonColor.OrangeWithBackground
            Me.TableLayoutPanel5.SetColumnSpan(Me.cmdDataSelect, 2)
            Me.cmdDataSelect.Cursor = Cursors.Hand
            Me.cmdDataSelect.Dock = DockStyle.Fill
            point2 = New Point(3, 3)
            Me.cmdDataSelect.Location = point2
            Me.cmdDataSelect.Name = "cmdDataSelect"
            Me.cmdDataSelect.PopupSide = ePopupSide.Right
            Me.cmdDataSelect.Shape = New RoundRectangleShapeDescriptor(6)
            size2 = New Size(&H11C, &H1D)
            Me.cmdDataSelect.Size = size2
            Me.cmdDataSelect.Style = eDotNetBarStyle.StyleManagerControlled
            items = New BaseItem() { Me.cmdShowRuncharts, Me.cmdShowRegularcharts, Me.cmdShowDataGrid }
            Me.cmdDataSelect.SubItems.AddRange(items)
            Me.cmdDataSelect.SubItemsExpandWidth = 20
            Me.cmdDataSelect.TabIndex = 2
            Me.cmdDataSelect.Text = "<b>Now Showing Run Charts</b>"
            Me.cmdShowRuncharts.AutoExpandOnClick = True
            Me.cmdShowRuncharts.BeginGroup = True
            Me.cmdShowRuncharts.GlobalItem = False
            Me.cmdShowRuncharts.Name = "cmdShowRuncharts"
            Me.cmdShowRuncharts.OptionGroup = "1"
            Me.cmdShowRuncharts.PopupWidth = &HFA0
            Me.cmdShowRuncharts.ShowSubItems = False
            Me.cmdShowRuncharts.Stretch = True
            Me.cmdShowRuncharts.Text = "Run Charts"
            Me.cmdShowRegularcharts.GlobalItem = False
            Me.cmdShowRegularcharts.Name = "cmdShowRegularcharts"
            Me.cmdShowRegularcharts.Text = "Regular Charts"
            Me.cmdShowDataGrid.GlobalItem = False
            Me.cmdShowDataGrid.Name = "cmdShowDataGrid"
            Me.cmdShowDataGrid.Text = "Data Grid"
            Me.Chart3.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            area3.AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Yes
            area3.Name = "ChartArea1"
            area4.Name = "ChartArea2"
            Me.Chart3.ChartAreas.Add(area3)
            Me.Chart3.ChartAreas.Add(area4)
            Me.Chart3.Dock = DockStyle.Fill
            legend.Name = "Legend1"
            Me.Chart3.Legends.Add(legend)
            point2 = New Point(3, 70)
            Me.Chart3.Location = point2
            Me.Chart3.Name = "Chart3"
            Me.TableLayoutPanel5.SetRowSpan(Me.Chart3, &H12)
            size2 = New Size(&H8B, &H162)
            Me.Chart3.Size = size2
            Me.Chart3.TabIndex = 0
            Me.Chart3.Text = "Chart3"
            Me.Chart4.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            area5.AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Yes
            area5.Name = "ChartArea1"
            Me.Chart4.ChartAreas.Add(area5)
            Me.Chart4.Dock = DockStyle.Fill
            legend2.Name = "Legend1"
            Me.Chart4.Legends.Add(legend2)
            point2 = New Point(&H125, 50)
            Me.Chart4.Location = point2
            Me.Chart4.Name = "Chart4"
            Me.TableLayoutPanel5.SetRowSpan(Me.Chart4, &H12)
            size2 = New Size(&H224, &H162)
            Me.Chart4.Size = size2
            Me.Chart4.TabIndex = 4
            Me.Chart4.Text = "Chart4"
            Me.Chart4.Visible = False
            Me.lblHistory_TotalUnits.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblHistory_TotalUnits.ForeColor = Color.Black
            point2 = New Point(&H94, 190)
            Me.lblHistory_TotalUnits.Location = point2
            Me.lblHistory_TotalUnits.Name = "lblHistory_TotalUnits"
            size2 = New Size(&H89, 14)
            Me.lblHistory_TotalUnits.Size = size2
            Me.lblHistory_TotalUnits.TabIndex = 1
            Me.lblHistory_TotalUnits.Text = "LabelX1"
            Me.cboRunCharts.DisplayMember = "Text"
            Me.cboRunCharts.Dock = DockStyle.Fill
            Me.cboRunCharts.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboRunCharts.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboRunCharts.ForeColor = Color.Black
            Me.cboRunCharts.FormattingEnabled = True
            Me.cboRunCharts.ItemHeight = 14
            point2 = New Point(3, &H26)
            Me.cboRunCharts.Location = point2
            Me.cboRunCharts.Name = "cboRunCharts"
            size2 = New Size(&H8B, 20)
            Me.cboRunCharts.Size = size2
            Me.cboRunCharts.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboRunCharts.TabIndex = 9
            Me.sgcHistory.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.TableLayoutPanel5.SetColumnSpan(Me.sgcHistory, 3)
            Me.sgcHistory.Dock = DockStyle.Fill
            Me.sgcHistory.ForeColor = Color.Black
            Me.sgcHistory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            point2 = New Point(3, -370)
            Me.sgcHistory.Location = point2
            Me.sgcHistory.Name = "sgcHistory"
            Me.sgcHistory.PrimaryGrid.AllowSelection = False
            Me.sgcHistory.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.TextColor = Color.Black
            Me.sgcHistory.PrimaryGrid.ReadOnly = True
            Me.sgcHistory.PrimaryGrid.Title.RowHeaderVisibility = RowHeaderVisibility.PanelControlled
            Me.TableLayoutPanel5.SetRowSpan(Me.sgcHistory, &H15)
            size2 = New Size(&H346, &H19E)
            Me.sgcHistory.Size = size2
            Me.sgcHistory.TabIndex = 10
            Me.sgcHistory.Text = "SuperGridControl1"
            Me.sgcHistory.Visible = False
            Me.cboHistory_XVal.DisplayMember = "Text"
            Me.cboHistory_XVal.Dock = DockStyle.Fill
            Me.cboHistory_XVal.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_XVal.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboHistory_XVal.ForeColor = Color.Black
            Me.cboHistory_XVal.FormattingEnabled = True
            Me.cboHistory_XVal.ItemHeight = 14
            point2 = New Point(&H94, 70)
            Me.cboHistory_XVal.Location = point2
            Me.cboHistory_XVal.Name = "cboHistory_XVal"
            size2 = New Size(&H8B, 20)
            Me.cboHistory_XVal.Size = size2
            Me.cboHistory_XVal.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_XVal.TabIndex = 11
            Me.cboHistory_XVal.Visible = False
            Me.cboHistory_YVal.DisplayMember = "Text"
            Me.cboHistory_YVal.Dock = DockStyle.Fill
            Me.cboHistory_YVal.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_YVal.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboHistory_YVal.ForeColor = Color.Black
            Me.cboHistory_YVal.FormattingEnabled = True
            Me.cboHistory_YVal.ItemHeight = 14
            point2 = New Point(&H94, 90)
            Me.cboHistory_YVal.Location = point2
            Me.cboHistory_YVal.Name = "cboHistory_YVal"
            size2 = New Size(&H8B, 20)
            Me.cboHistory_YVal.Size = size2
            Me.cboHistory_YVal.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_YVal.TabIndex = 12
            Me.cboHistory_YVal.Visible = False
            Me.cboHistory_Series.DisplayMember = "Text"
            Me.cboHistory_Series.Dock = DockStyle.Fill
            Me.cboHistory_Series.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_Series.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboHistory_Series.ForeColor = Color.Black
            Me.cboHistory_Series.FormattingEnabled = True
            Me.cboHistory_Series.ItemHeight = 14
            point2 = New Point(&H94, 130)
            Me.cboHistory_Series.Location = point2
            Me.cboHistory_Series.Name = "cboHistory_Series"
            size2 = New Size(&H8B, 20)
            Me.cboHistory_Series.Size = size2
            Me.cboHistory_Series.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_Series.TabIndex = 13
            Me.cboHistory_Series.Visible = False
            Me.lblHistory_XVal.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblHistory_XVal.Dock = DockStyle.Fill
            Me.lblHistory_XVal.ForeColor = Color.Black
            point2 = New Point(3, 50)
            Me.lblHistory_XVal.Location = point2
            Me.lblHistory_XVal.Name = "lblHistory_XVal"
            size2 = New Size(&H8B, 14)
            Me.lblHistory_XVal.Size = size2
            Me.lblHistory_XVal.TabIndex = 14
            Me.lblHistory_XVal.Text = "X Values"
            Me.lblHistory_XVal.TextLineAlignment = StringAlignment.Far
            Me.lblHistory_XVal.Visible = False
            Me.lblHistory_YVal.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblHistory_YVal.Dock = DockStyle.Fill
            Me.lblHistory_YVal.ForeColor = Color.Black
            point2 = New Point(&H94, 50)
            Me.lblHistory_YVal.Location = point2
            Me.lblHistory_YVal.Name = "lblHistory_YVal"
            size2 = New Size(&H8B, 14)
            Me.lblHistory_YVal.Size = size2
            Me.lblHistory_YVal.TabIndex = 15
            Me.lblHistory_YVal.Text = "Y Values"
            Me.lblHistory_YVal.TextLineAlignment = StringAlignment.Far
            Me.lblHistory_YVal.Visible = False
            Me.lblHistory_Series.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblHistory_Series.Dock = DockStyle.Fill
            Me.lblHistory_Series.ForeColor = Color.Black
            point2 = New Point(&H94, 110)
            Me.lblHistory_Series.Location = point2
            Me.lblHistory_Series.Name = "lblHistory_Series"
            size2 = New Size(&H8B, 14)
            Me.lblHistory_Series.Size = size2
            Me.lblHistory_Series.TabIndex = &H10
            Me.lblHistory_Series.Text = "Series"
            Me.lblHistory_Series.TextLineAlignment = StringAlignment.Far
            Me.lblHistory_Series.Visible = False
            Me.cmdHistory_ChartIt.AccessibleRole = AccessibleRole.PushButton
            Me.cmdHistory_ChartIt.ColorTable = eButtonColor.OrangeWithBackground
            Me.cmdHistory_ChartIt.Dock = DockStyle.Fill
            point2 = New Point(&H94, 150)
            Me.cmdHistory_ChartIt.Location = point2
            padding2 = New Padding(3, 3, 3, 0)
            Me.cmdHistory_ChartIt.Margin = padding2
            Me.cmdHistory_ChartIt.Name = "cmdHistory_ChartIt"
            size2 = New Size(&H8B, &H11)
            Me.cmdHistory_ChartIt.Size = size2
            Me.cmdHistory_ChartIt.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdHistory_ChartIt.TabIndex = &H11
            Me.cmdHistory_ChartIt.Text = "Chart It"
            Me.cmdHistory_ChartIt.Visible = False
            Me.cmdHistory_DataGrid_Edit.AccessibleRole = AccessibleRole.PushButton
            Me.cmdHistory_DataGrid_Edit.AutoCheckOnClick = True
            Me.cmdHistory_DataGrid_Edit.ColorTable = eButtonColor.OrangeWithBackground
            Me.cmdHistory_DataGrid_Edit.Dock = DockStyle.Left
            point2 = New Point(&H92, &HA8)
            Me.cmdHistory_DataGrid_Edit.Location = point2
            padding2 = New Padding(1)
            Me.cmdHistory_DataGrid_Edit.Margin = padding2
            Me.cmdHistory_DataGrid_Edit.Name = "cmdHistory_DataGrid_Edit"
            size2 = New Size(&H67, &H12)
            Me.cmdHistory_DataGrid_Edit.Size = size2
            Me.cmdHistory_DataGrid_Edit.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdHistory_DataGrid_Edit.TabIndex = &H12
            Me.cmdHistory_DataGrid_Edit.Text = "Edit Grid Contents"
            Me.cmdHistory_DataGrid_Edit.Visible = False
            Me.MetroAppButton1.AutoExpandOnClick = True
            Me.MetroAppButton1.BackstageTabEnabled = False
            Me.MetroAppButton1.CanCustomize = False
            Me.MetroAppButton1.Enabled = False
            size2 = New Size(&H10, &H10)
            Me.MetroAppButton1.ImageFixedSize = size2
            Me.MetroAppButton1.ImagePaddingHorizontal = 0
            Me.MetroAppButton1.ImagePaddingVertical = 0
            Me.MetroAppButton1.Name = "MetroAppButton1"
            Me.MetroAppButton1.ShowSubItems = False
            Me.MetroAppButton1.Text = "&File"
            Me.MetroAppButton1.Visible = False
            Me.MetroTabItem1.Cursor = Cursors.Hand
            Me.MetroTabItem1.ImagePaddingHorizontal = 1
            Me.MetroTabItem1.Name = "MetroTabItem1"
            Me.MetroTabItem1.Panel = Me.MetroTabPanel1
            Me.MetroTabItem1.Tag = "99"
            Me.MetroTabItem1.Text = "&Summary"
            Me.MetroTabItem2.Cursor = Cursors.Hand
            Me.MetroTabItem2.ImagePaddingHorizontal = 1
            Me.MetroTabItem2.Name = "MetroTabItem2"
            Me.MetroTabItem2.Panel = Me.MetroTabPanel2
            Me.MetroTabItem2.Tag = "99"
            Me.MetroTabItem2.Text = "&Prime Pressures"
            Me.MetroTabItem4.Checked = True
            Me.MetroTabItem4.Cursor = Cursors.Hand
            Me.MetroTabItem4.ImagePaddingHorizontal = 1
            Me.MetroTabItem4.Name = "MetroTabItem4"
            Me.MetroTabItem4.Panel = Me.MetroTabPanel4
            Me.MetroTabItem4.Tag = "99"
            Me.MetroTabItem4.Text = "Mech Checks"
            Me.MetroTabItem3.Cursor = Cursors.Hand
            Me.MetroTabItem3.ImagePaddingHorizontal = 1
            Me.MetroTabItem3.Name = "MetroTabItem3"
            Me.MetroTabItem3.Panel = Me.MetroTabPanel3
            Me.MetroTabItem3.Tag = "99"
            Me.MetroTabItem3.Text = "History"
            Me.tabTriage.Name = "tabTriage"
            Me.tabTriage.Panel = Me.MetroTabPanel5
            Me.tabTriage.Tag = "99"
            Me.tabTriage.Text = "Printer Triage"
            Me.tabHelp.Name = "tabHelp"
            Me.tabHelp.Panel = Me.MetroTabPanel6
            Me.tabHelp.Tag = "99"
            Me.tabHelp.Text = "Help"
            Me.tabHelp.Visible = False
            Me.ButtonItem4.Name = "ButtonItem4"
            Me.ButtonItem4.Text = "CopyToClipBoard"
            Me.ButtonItem4.Visible = False
            Me.ButtonItem1.Enabled = False
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.Text = "ButtonItem1"
            Me.ButtonItem1.Visible = False
            Me.StyleManager1.ManagerStyle = eStyle.Metro
            Dim parameters2 As New MetroColorGeneratorParameters(Color.FromArgb(&HFF, &HFF, &HFF), Color.FromArgb(&HED, &H8E, 0))
            Me.StyleManager1.MetroColorParameters = parameters2
            Me.MetroStatusBar1.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.MetroStatusBar1.BackgroundStyle.CornerType = eCornerType.Square
            Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
            Me.MetroStatusBar1.Dock = DockStyle.Bottom
            Me.MetroStatusBar1.DragDropSupport = True
            Me.MetroStatusBar1.Font = New Font("Segoe UI", 10.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.MetroStatusBar1.ForeColor = Color.Black
            items = New BaseItem() { Me.cmdEmail, Me.cmdClipBoard, Me.cmdSaveFormImage, Me.ButtonItem2, Me.ButtonItem3 }
            Me.MetroStatusBar1.Items.AddRange(items)
            Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            point2 = New Point(0, &H1E4)
            Me.MetroStatusBar1.Location = point2
            Me.MetroStatusBar1.Name = "MetroStatusBar1"
            size2 = New Size(&H34C, &H16)
            Me.MetroStatusBar1.Size = size2
            Me.MetroStatusBar1.TabIndex = 9
            Me.MetroStatusBar1.Text = "MetroStatusBar1"
            Me.cmdEmail.Image = DirectCast(manager.GetObject("cmdEmail.Image"), Image)
            Me.cmdEmail.Name = "cmdEmail"
            Me.SuperTooltip1.SetSuperTooltip(Me.cmdEmail, New SuperTooltipInfo("Email PST Screenshot", "", "Click to open a new email message. An image of the PST results will be placed on the clipboard. To insert the image in your message, you can either type CTRL+V or click on the paste button.", Nothing, Nothing, eTooltipColor.Gray))
            Me.cmdEmail.Text = "Email"
            Me.cmdClipBoard.Image = DirectCast(manager.GetObject("cmdClipBoard.Image"), Image)
            Me.cmdClipBoard.Name = "cmdClipBoard"
            Me.SuperTooltip1.SetSuperTooltip(Me.cmdClipBoard, New SuperTooltipInfo("Copy Clip", "", "Copies an image of the PST results to the clipboard that can be pastedinto other applications.", Nothing, Nothing, eTooltipColor.Gray))
            Me.cmdClipBoard.Text = "Copy Clip"
            Me.cmdSaveFormImage.Icon = DirectCast(manager.GetObject("cmdSaveFormImage.Icon"), Icon)
            Me.cmdSaveFormImage.Name = "cmdSaveFormImage"
            Me.cmdSaveFormImage.Text = "ButtonItem5"
            Me.ButtonItem2.Name = "ButtonItem2"
            Me.ButtonItem2.Text = "ButtonItem2"
            Me.ButtonItem2.Visible = False
            Me.ButtonItem3.Name = "ButtonItem3"
            Me.ButtonItem3.Text = "ButtonItem3"
            Me.ButtonItem3.Visible = False
            Me.SuperTooltip1.DefaultTooltipSettings = New SuperTooltipInfo("", "", "", Nothing, Nothing, eTooltipColor.Gray)
            Me.SuperTooltip1.HoverDelayMultiplier = 1
            Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AutoScaleMode = AutoScaleMode.Inherit
            size2 = New Size(&H34C, &H1FA)
            Me.ClientSize = size2
            Me.ControlBox = False
            Me.Controls.Add(Me.MetroStatusBar1)
            Me.Controls.Add(Me.MetroShell1)
            Me.DoubleBuffered = True
            Me.ForeColor = Color.Black
            Me.FormBorderStyle = FormBorderStyle.SizableToolWindow
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgPSTResults"
            Me.ShowIcon = False
            Me.StartPosition = FormStartPosition.CenterParent
            Me.TitleText = "Priming Systems Test"
            Me.TopLeftCornerSize = &H19
            Me.GroupPanel1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.GroupPanel2.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel4.ResumeLayout(False)
            Me.TableLayoutPanel4.PerformLayout
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout
            Me.Chart1.EndInit
            Me.Chart2.EndInit
            Me.MetroShell1.ResumeLayout(False)
            Me.MetroShell1.PerformLayout
            Me.MetroTabPanel1.ResumeLayout(False)
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.MetroTabPanel5.ResumeLayout(False)
            DirectCast(Me.SuperTabControl1, ISupportInitialize).EndInit
            Me.SuperTabControl1.ResumeLayout(False)
            Me.SuperTabControlPanel1.ResumeLayout(False)
            Me.SuperTabControlPanel6.ResumeLayout(False)
            Me.SuperTabControlPanel3.ResumeLayout(False)
            Me.SuperTabControlPanel4.ResumeLayout(False)
            Me.SuperTabControlPanel2.ResumeLayout(False)
            Me.SuperTabControlPanel5.ResumeLayout(False)
            Me.MetroTabPanel6.ResumeLayout(False)
            Me.MetroTabPanel2.ResumeLayout(False)
            Me.MetroTabPanel3.ResumeLayout(False)
            Me.TableLayoutPanel5.ResumeLayout(False)
            Me.Chart3.EndInit
            Me.Chart4.EndInit
            Me.ResumeLayout(False)
        End Sub

        Private Sub lblSummary_PST_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.MetroTabItem2.Select
        End Sub

        Private Sub LoadHistoryTable()
            Dim array(,) As String(0 To .,0 To .) = FileProcessing.ReadDelimitedFile(Me.PST.SummaryFileName, ",")
            Me.dtHistory.Columns.Add("Indexer")
            Dim num4 As Integer = Information.UBound(array, 2)
            Dim num As Integer = 0
            Do While True
                Dim flag As Boolean
                Dim num7 As Integer = num4
                If (num > num7) Then
                    Dim num5 As Integer = Information.UBound(array, 1)
                    Dim num2 As Integer = 1
                    Do While (num2 <= num5)
                        Debug.Print(Conversions.ToString(num2))
                        Dim row As DataRow = Me.dtHistory.NewRow
                        row(0) = num2
                        Dim num6 As Integer = (Me.dtHistory.Columns.Count - 2)
                        Dim num3 As Integer = 0
                        Do While True
                            num7 = num6
                            If (num3 > num7) Then
                                Me.dtHistory.Rows.Add(row)
                                num2 += 1
                                Exit Do
                            End If
                            flag = Not Object.ReferenceEquals(array(num2, num3), Nothing)
                            If flag Then
                                row((num3 + 1)) = array(num2, num3)
                            End If
                            num3 += 1
                        Loop
                    Loop
                    Return
                End If
                Dim columnName As String = Nothing
                flag = Not Object.ReferenceEquals(array(0, num), Nothing)
                columnName = If(Not flag, ("Unknown" & Conversions.ToString(num)), array(0, num))
                Me.dtHistory.Columns.Add(columnName)
                Me.cboHistory_XVal.Items.Add(columnName)
                Me.cboHistory_YVal.Items.Add(columnName)
                Me.cboHistory_Series.Items.Add(columnName)
                Me.cboRunCharts.Items.Add(columnName)
                num += 1
            Loop
        End Sub

        Private Sub lstSUmmaryMechChecks_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            Me.MetroTabItem4.Select
        End Sub

        Private Sub lstSummaryMechChecks_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me.lstSummaryMechChecks.SelectedItems.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    current.Selected = False
                Loop
            Finally
                If Not Object.ReferenceEquals(TryCast(enumerator,IDisposable), Nothing) Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        Private Sub PrepFormForBitMap(ByVal Start As Boolean)
            Me.lblHidden_TestID.Visible = Start
            Me.lblHidden_Date.Visible = Start
            Me.lblHidden_Time.Visible = Start
            Me.lblHidden_Serial.Visible = Start
            Me.lblHidden_RunNum.Visible = Start
            Me.lblHidden_FUELRev.Visible = Start
            Me.lblHidden_ScriptRev.Visible = Start
            Me.lblHidden_Product.Visible = Start
            Me.lblHidden_TestInfo.Visible = Start
        End Sub

        Private Sub SetChartAxisValues(ByVal myChart As Chart, ByVal myArea As String, ByVal ChartSeries As Integer, ByVal DataPoints As Points)
            Try 
                myChart.ChartAreas(myArea).AxisY.Maximum = Math.Max(CDbl(200), CDbl((myChart.Series(ChartSeries).Points.FindMaxByValue.YValues(0) + 20)))
                myChart.ChartAreas(myArea).AxisY.Minimum = Math.Min(0, myChart.Series(ChartSeries).Points.FindMinByValue.YValues(0))
                myChart.ChartAreas(myArea).AxisX.Maximum = Math.Max(CDbl((DataPoints.PT5X + 1)), CDbl(0))
                If (DataPoints.PT3X > 0) Then
                    myChart.ChartAreas(myArea).AxisX.Minimum = (DataPoints.PT1X - 1)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Interaction.MsgBox("Using non-default axis scales", MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub SetPSTSpecLabelText(ByVal Channel As Channels, ByVal Specs As Specifications)
            If (Channel = Channels.Black) Then
                Me.lblSpecPressure_K.Text = (Conversions.ToString(Specs.PressureMin) & " / " & Conversions.ToString(Specs.PressureMax))
                Me.lblSpecLeak_K.Text = (Conversions.ToString(Specs.LeakMin) & " / " & Conversions.ToString(Specs.LeakMax))
                Me.lblSpecTubeEvac_K.Text = ("< " & Conversions.ToString(Math.Round(New Decimal(Specs.TubeEvacDeltaPressure), 1)))
                If (Me.PST.KResults.PF.VentDeltaPMin < 1) Then
                    Me.lblSpecVent_K.Text = ("> " & Conversions.ToString(Math.Round(Specs.VentDeltaPMin, 3)))
                ElseIf (Me.PST.KResults.PF.VentDeltaPMin = 1) Then
                    Me.lblSpecVent_K.Text = ("<" & Conversions.ToString(Specs.VentDxDt2Threshold) & ", > " & Conversions.ToString(CDbl((Math.Round(Specs.VentDeltaPMin, 3) * 0.5))))
                    Me.lblTitleVent_K.Text = "Vent D2x/Dt2, Vent Delta P"
                End If
            Else
                Me.lblSpecPressure_C.Text = (Conversions.ToString(Specs.PressureMin) & " / " & Conversions.ToString(Specs.PressureMax))
                Me.lblSpecLeak_C.Text = (Conversions.ToString(Specs.LeakMin) & " / " & Conversions.ToString(Specs.LeakMax))
                Me.lblSpecTubeEvac_C.Text = ("< " & Conversions.ToString(Math.Round(New Decimal(Specs.TubeEvacDeltaPressure), 1)))
                If (Me.PST.CResults.PF.VentDeltaPMin < 1) Then
                    Me.lblSpecVent_C.Text = ("> " & Conversions.ToString(Math.Round(Specs.VentDeltaPMin, 3)))
                ElseIf (Me.PST.CResults.PF.VentDeltaPMin = 1) Then
                    Me.lblSpecVent_C.Text = ("<" & Conversions.ToString(Specs.VentDxDt2Threshold) & ", > " & Conversions.ToString(CDbl((Math.Round(Specs.VentDeltaPMin, 3) * 0.5))))
                    Me.lblTitleVent_C.Text = "Vent D2x/Dt2, Vent Delta P"
                End If
            End If
        End Sub

        Private Function ToBitmap(ByRef c As Control) As Image
            Dim bitmap As New Bitmap(c.Width, c.Height)
            Dim targetBounds As New Rectangle(0, 0, c.Width, c.Height)
            c.DrawToBitmap(bitmap, targetBounds)
            Return bitmap
        End Function


        ' Properties
        Friend Overridable Property lblTitlePressure_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitlePressure_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitlePressure_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property GroupPanel1 As GroupPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._GroupPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As GroupPanel)
                Me._GroupPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel2 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleLeak_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleLeak_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleLeak_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleVent_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleVent_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleVent_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasPressure_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasPressure_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasPressure_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitlePressure_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitlePressure_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitlePressure_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasLeak_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasLeak_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasLeak_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleLeak_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleLeak_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleLeak_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasVent_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasVent_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasVent_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleVent_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleVent_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleVent_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecPressure_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecPressure_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecPressure_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecLeak_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecLeak_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecLeak_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecVent_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecVent_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecVent_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX10 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX10 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX11 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX11
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX11 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX12 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX12 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property GroupPanel2 As GroupPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._GroupPanel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As GroupPanel)
                Me._GroupPanel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel3 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasPressure_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasPressure_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasPressure_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasLeak_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasLeak_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasLeak_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasVent_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasVent_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasVent_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecPressure_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecPressure_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecPressure_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecLeak_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecLeak_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecLeak_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecVent_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecVent_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecVent_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX16 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX16
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX16 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX17 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX17
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX17 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX18 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX18
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX18 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel4 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroShell1 As MetroShell
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroShell1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroShell)
                Me._MetroShell1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel2 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel1 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroAppButton1 As MetroAppButton
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroAppButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroAppButton)
                Me._MetroAppButton1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabItem1 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabItem2 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ButtonItem1 As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Me._ButtonItem1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property StyleManager1 As StyleManager
            <DebuggerNonUserCode> _
            Get
                Return Me._StyleManager1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As StyleManager)
                Me._StyleManager1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel4 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabItem4 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ReflectionLabel5 As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._ReflectionLabel5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Me._ReflectionLabel5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ReflectionLabel3 As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._ReflectionLabel3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Me._ReflectionLabel3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ReflectionLabel2 As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._ReflectionLabel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Me._ReflectionLabel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ReflectionLabel1 As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._ReflectionLabel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Me._ReflectionLabel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_FuelRev As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_FuelRev
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_FuelRev = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_TestTime As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_TestTime
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_TestTime = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_TestDate As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_TestDate
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_TestDate = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_ScriptRev As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_ScriptRev
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_ScriptRev = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_PSTColor As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_PSTColor
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Dim handler As MouseEventHandler = New MouseEventHandler(AddressOf Me.lblSummary_PST_MouseClick)
                If Not Object.ReferenceEquals(Me._lblSummary_PSTColor, Nothing) Then
                    RemoveHandler Me._lblSummary_PSTColor.MouseClick, handler
                End If
                Me._lblSummary_PSTColor = WithEventsValue
                If Not Object.ReferenceEquals(Me._lblSummary_PSTColor, Nothing) Then
                    AddHandler Me._lblSummary_PSTColor.MouseClick, handler
                End If
            End Set
        End Property

        Friend Overridable Property lblSummary_PSTBlack As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_PSTBlack
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Dim handler As MouseEventHandler = New MouseEventHandler(AddressOf Me.lblSummary_PST_MouseClick)
                If Not Object.ReferenceEquals(Me._lblSummary_PSTBlack, Nothing) Then
                    RemoveHandler Me._lblSummary_PSTBlack.MouseClick, handler
                End If
                Me._lblSummary_PSTBlack = WithEventsValue
                If Not Object.ReferenceEquals(Me._lblSummary_PSTBlack, Nothing) Then
                    AddHandler Me._lblSummary_PSTBlack.MouseClick, handler
                End If
            End Set
        End Property

        Friend Overridable Property lblSummary_EngPgCnt As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_EngPgCnt
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_EngPgCnt = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_FW As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_FW
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_FW = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_SerialNum As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_SerialNum
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_SerialNum = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Chart1 As Chart
            <DebuggerNonUserCode> _
            Get
                Return Me._Chart1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Chart)
                Me._Chart1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Chart2 As Chart
            <DebuggerNonUserCode> _
            Get
                Return Me._Chart2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Chart)
                Me._Chart2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel3 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Chart3 As Chart
            <DebuggerNonUserCode> _
            Get
                Return Me._Chart3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Chart)
                Me._Chart3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabItem3 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel5 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHistory_TotalUnits As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHistory_TotalUnits
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblHistory_TotalUnits = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdDataSelect As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdDataSelect
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Me._cmdDataSelect = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdShowRuncharts As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdShowRuncharts
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.HistoryChartTypeChanged)
                If Not Object.ReferenceEquals(Me._cmdShowRuncharts, Nothing) Then
                    RemoveHandler Me._cmdShowRuncharts.Click, handler
                End If
                Me._cmdShowRuncharts = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowRuncharts, Nothing) Then
                    AddHandler Me._cmdShowRuncharts.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox1 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Me._PictureBox1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ReflectionLabel4 As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._ReflectionLabel4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Me._ReflectionLabel4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property LabelX1 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFailModes As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblFailModes
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblFailModes = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel5 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControl1 As SuperTabControl
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControl1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControl)
                Me._SuperTabControl1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel1 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_Intro As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_Intro
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_Intro = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel4 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_CyclicalPressure As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_CyclicalPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_CyclicalPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel3 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_DelayedPressure As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_DelayedPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_DelayedPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel2 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_NoPressure As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_NoPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_NoPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tabTriage As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._tabTriage
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._tabTriage = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_Intro As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_Intro
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_Intro = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel5 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_PressureFluctuates As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_PressureFluctuates
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_PressureFluctuates = WithEventsValue
            End Set
        End Property

        Friend Overridable Property SuperTabControlPanel6 As SuperTabControlPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTabControlPanel6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabControlPanel)
                Me._SuperTabControlPanel6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_PSTOutputs As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_PSTOutputs
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_PSTOutputs = WithEventsValue
            End Set
        End Property

        Friend Overridable Property stiPSTDocs_Outputs As SuperTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._stiPSTDocs_Outputs
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTabItem)
                Me._stiPSTDocs_Outputs = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_NoPressure As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_NoPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_NoPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_PressureFluctuates As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_PressureFluctuates
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_PressureFluctuates = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_CyclicalPressure As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_CyclicalPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_CyclicalPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtbPSTDocs_DelayedPressure As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbPSTDocs_DelayedPressure
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbPSTDocs_DelayedPressure = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroStatusBar1 As MetroStatusBar
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroStatusBar1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroStatusBar)
                Dim handler As MouseEventHandler = New MouseEventHandler(AddressOf Me.dlgPSTResults_MouseClick)
                If Not Object.ReferenceEquals(Me._MetroStatusBar1, Nothing) Then
                    RemoveHandler Me._MetroStatusBar1.MouseClick, handler
                End If
                Me._MetroStatusBar1 = WithEventsValue
                If Not Object.ReferenceEquals(Me._MetroStatusBar1, Nothing) Then
                    AddHandler Me._MetroStatusBar1.MouseClick, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdEmail As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdEmail
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdEmail_Click)
                If Not Object.ReferenceEquals(Me._cmdEmail, Nothing) Then
                    RemoveHandler Me._cmdEmail.Click, handler
                End If
                Me._cmdEmail = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdEmail, Nothing) Then
                    AddHandler Me._cmdEmail.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdClipBoard As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdClipBoard
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdClipBoard_Click)
                If Not Object.ReferenceEquals(Me._cmdClipBoard, Nothing) Then
                    RemoveHandler Me._cmdClipBoard.Click, handler
                End If
                Me._cmdClipBoard = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdClipBoard, Nothing) Then
                    AddHandler Me._cmdClipBoard.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ButtonItem2 As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ButtonItem2_Click)
                If Not Object.ReferenceEquals(Me._ButtonItem2, Nothing) Then
                    RemoveHandler Me._ButtonItem2.Click, handler
                End If
                Me._ButtonItem2 = WithEventsValue
                If Not Object.ReferenceEquals(Me._ButtonItem2, Nothing) Then
                    AddHandler Me._ButtonItem2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ButtonItem3 As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonItem3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ButtonItem3_Click)
                If Not Object.ReferenceEquals(Me._ButtonItem3, Nothing) Then
                    RemoveHandler Me._ButtonItem3.Click, handler
                End If
                Me._ButtonItem3 = WithEventsValue
                If Not Object.ReferenceEquals(Me._ButtonItem3, Nothing) Then
                    AddHandler Me._ButtonItem3.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property SuperTooltip1 As SuperTooltip
            <DebuggerNonUserCode> _
            Get
                Return Me._SuperTooltip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperTooltip)
                Me._SuperTooltip1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lstSummaryMechChecks As ListViewEx
            <DebuggerNonUserCode> _
            Get
                Return Me._lstSummaryMechChecks
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ListViewEx)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.lstSummaryMechChecks_MouseLeave)
                Dim handler2 As MouseEventHandler = New MouseEventHandler(AddressOf Me.lstSUmmaryMechChecks_MouseClick)
                If Not Object.ReferenceEquals(Me._lstSummaryMechChecks, Nothing) Then
                    RemoveHandler Me._lstSummaryMechChecks.MouseLeave, handler
                    RemoveHandler Me._lstSummaryMechChecks.MouseClick, handler2
                End If
                Me._lstSummaryMechChecks = WithEventsValue
                If Not Object.ReferenceEquals(Me._lstSummaryMechChecks, Nothing) Then
                    AddHandler Me._lstSummaryMechChecks.MouseLeave, handler
                    AddHandler Me._lstSummaryMechChecks.MouseClick, handler2
                End If
            End Set
        End Property

        Friend Overridable Property ImageList1 As ImageList
            <DebuggerNonUserCode> _
            Get
                Return Me._ImageList1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ImageList)
                Me._ImageList1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ColumnHeader2 As ColumnHeader
            <DebuggerNonUserCode> _
            Get
                Return Me._ColumnHeader2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ColumnHeader)
                Me._ColumnHeader2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Chart4 As Chart
            <DebuggerNonUserCode> _
            Get
                Return Me._Chart4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Chart)
                Me._Chart4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdShowRegularcharts As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdShowRegularcharts
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.HistoryChartTypeChanged)
                If Not Object.ReferenceEquals(Me._cmdShowRegularcharts, Nothing) Then
                    RemoveHandler Me._cmdShowRegularcharts.Click, handler
                End If
                Me._cmdShowRegularcharts = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowRegularcharts, Nothing) Then
                    AddHandler Me._cmdShowRegularcharts.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cboRunCharts As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboRunCharts
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cboRunCharts_SelectedIndexChanged)
                If Not Object.ReferenceEquals(Me._cboRunCharts, Nothing) Then
                    RemoveHandler Me._cboRunCharts.SelectedIndexChanged, handler
                End If
                Me._cboRunCharts = WithEventsValue
                If Not Object.ReferenceEquals(Me._cboRunCharts, Nothing) Then
                    AddHandler Me._cboRunCharts.SelectedIndexChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdShowDataGrid As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdShowDataGrid
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.HistoryChartTypeChanged)
                If Not Object.ReferenceEquals(Me._cmdShowDataGrid, Nothing) Then
                    RemoveHandler Me._cmdShowDataGrid.Click, handler
                End If
                Me._cmdShowDataGrid = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowDataGrid, Nothing) Then
                    AddHandler Me._cmdShowDataGrid.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property sgcHistory As SuperGridControl
            <DebuggerNonUserCode> _
            Get
                Return Me._sgcHistory
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperGridControl)
                Me._sgcHistory = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboHistory_XVal As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboHistory_XVal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboHistory_XVal = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboHistory_YVal As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboHistory_YVal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboHistory_YVal = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboHistory_Series As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboHistory_Series
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboHistory_Series = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHistory_XVal As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHistory_XVal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblHistory_XVal = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHistory_YVal As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHistory_YVal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblHistory_YVal = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHistory_Series As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHistory_Series
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblHistory_Series = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdHistory_ChartIt As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdHistory_ChartIt
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdHistory_ChartIt_Click)
                If Not Object.ReferenceEquals(Me._cmdHistory_ChartIt, Nothing) Then
                    RemoveHandler Me._cmdHistory_ChartIt.Click, handler
                End If
                Me._cmdHistory_ChartIt = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdHistory_ChartIt, Nothing) Then
                    AddHandler Me._cmdHistory_ChartIt.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdHistory_DataGrid_Edit As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdHistory_DataGrid_Edit
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdHistory_DataGrid_Edit_Click)
                If Not Object.ReferenceEquals(Me._cmdHistory_DataGrid_Edit, Nothing) Then
                    RemoveHandler Me._cmdHistory_DataGrid_Edit.Click, handler
                End If
                Me._cmdHistory_DataGrid_Edit = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdHistory_DataGrid_Edit, Nothing) Then
                    AddHandler Me._cmdHistory_DataGrid_Edit.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property MetroTabPanel6 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ButtonX2 As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonX2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ButtonX2_Click)
                If Not Object.ReferenceEquals(Me._ButtonX2, Nothing) Then
                    RemoveHandler Me._ButtonX2.Click, handler
                End If
                Me._ButtonX2 = WithEventsValue
                If Not Object.ReferenceEquals(Me._ButtonX2, Nothing) Then
                    AddHandler Me._ButtonX2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ButtonX1 As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonX1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Me._ButtonX1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tabHelp As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._tabHelp
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._tabHelp = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_ScriptProduct As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_ScriptProduct
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_ScriptProduct = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasTubeEvac_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasTubeEvac_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasTubeEvac_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleTubeEvac_k As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleTubeEvac_k
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleTubeEvac_k = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecTubeEvac_K As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecTubeEvac_K
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecTubeEvac_K = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblTitleTubeEvac_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblTitleTubeEvac_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblTitleTubeEvac_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasTubeEvac_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasTubeEvac_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasTubeEvac_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecTubeEvac_C As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecTubeEvac_C
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecTubeEvac_C = WithEventsValue
            End Set
        End Property

        Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._FlowLayoutPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As FlowLayoutPanel)
                Me._FlowLayoutPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_TestInfo As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_TestInfo
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_TestInfo = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_TestID As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_TestID
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_TestID = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_Date As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_Date
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_Date = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_Time As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_Time
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_Time = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_Serial As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_Serial
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_Serial = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_RunNum As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_RunNum
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_RunNum = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_FUELRev As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_FUELRev
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_FUELRev = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_ScriptRev As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_ScriptRev
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_ScriptRev = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHidden_Product As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._lblHidden_Product
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHidden_Product = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ButtonItem4 As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ButtonItem4_Click)
                If Not Object.ReferenceEquals(Me._ButtonItem4, Nothing) Then
                    RemoveHandler Me._ButtonItem4.Click, handler
                End If
                Me._ButtonItem4 = WithEventsValue
                If Not Object.ReferenceEquals(Me._ButtonItem4, Nothing) Then
                    AddHandler Me._ButtonItem4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property lblSummary_Run As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_Run
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_Run = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSummary_TestID As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSummary_TestID
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSummary_TestID = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdSaveFormImage As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdSaveFormImage
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdSaveFormImage_Click)
                If Not Object.ReferenceEquals(Me._cmdSaveFormImage, Nothing) Then
                    RemoveHandler Me._cmdSaveFormImage.Click, handler
                End If
                Me._cmdSaveFormImage = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdSaveFormImage, Nothing) Then
                    AddHandler Me._cmdSaveFormImage.Click, handler
                End If
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("lblTitlePressure_K")> _
        Private _lblTitlePressure_K As LabelX
        <AccessedThroughProperty("GroupPanel1")> _
        Private _GroupPanel1 As GroupPanel
        <AccessedThroughProperty("TableLayoutPanel2")> _
        Private _TableLayoutPanel2 As TableLayoutPanel
        <AccessedThroughProperty("lblTitleLeak_K")> _
        Private _lblTitleLeak_K As LabelX
        <AccessedThroughProperty("lblTitleVent_K")> _
        Private _lblTitleVent_K As LabelX
        <AccessedThroughProperty("lblMeasPressure_K")> _
        Private _lblMeasPressure_K As LabelX
        <AccessedThroughProperty("lblTitlePressure_C")> _
        Private _lblTitlePressure_C As LabelX
        <AccessedThroughProperty("lblMeasLeak_K")> _
        Private _lblMeasLeak_K As LabelX
        <AccessedThroughProperty("lblTitleLeak_C")> _
        Private _lblTitleLeak_C As LabelX
        <AccessedThroughProperty("lblMeasVent_K")> _
        Private _lblMeasVent_K As LabelX
        <AccessedThroughProperty("lblTitleVent_C")> _
        Private _lblTitleVent_C As LabelX
        <AccessedThroughProperty("lblSpecPressure_K")> _
        Private _lblSpecPressure_K As LabelX
        <AccessedThroughProperty("lblSpecLeak_K")> _
        Private _lblSpecLeak_K As LabelX
        <AccessedThroughProperty("lblSpecVent_K")> _
        Private _lblSpecVent_K As LabelX
        <AccessedThroughProperty("LabelX10")> _
        Private _LabelX10 As LabelX
        <AccessedThroughProperty("LabelX11")> _
        Private _LabelX11 As LabelX
        <AccessedThroughProperty("LabelX12")> _
        Private _LabelX12 As LabelX
        <AccessedThroughProperty("GroupPanel2")> _
        Private _GroupPanel2 As GroupPanel
        <AccessedThroughProperty("TableLayoutPanel3")> _
        Private _TableLayoutPanel3 As TableLayoutPanel
        <AccessedThroughProperty("lblMeasPressure_C")> _
        Private _lblMeasPressure_C As LabelX
        <AccessedThroughProperty("lblMeasLeak_C")> _
        Private _lblMeasLeak_C As LabelX
        <AccessedThroughProperty("lblMeasVent_C")> _
        Private _lblMeasVent_C As LabelX
        <AccessedThroughProperty("lblSpecPressure_C")> _
        Private _lblSpecPressure_C As LabelX
        <AccessedThroughProperty("lblSpecLeak_C")> _
        Private _lblSpecLeak_C As LabelX
        <AccessedThroughProperty("lblSpecVent_C")> _
        Private _lblSpecVent_C As LabelX
        <AccessedThroughProperty("LabelX16")> _
        Private _LabelX16 As LabelX
        <AccessedThroughProperty("LabelX17")> _
        Private _LabelX17 As LabelX
        <AccessedThroughProperty("LabelX18")> _
        Private _LabelX18 As LabelX
        <AccessedThroughProperty("TableLayoutPanel4")> _
        Private _TableLayoutPanel4 As TableLayoutPanel
        <AccessedThroughProperty("MetroShell1")> _
        Private _MetroShell1 As MetroShell
        <AccessedThroughProperty("MetroTabPanel2")> _
        Private _MetroTabPanel2 As MetroTabPanel
        <AccessedThroughProperty("MetroTabPanel1")> _
        Private _MetroTabPanel1 As MetroTabPanel
        <AccessedThroughProperty("MetroAppButton1")> _
        Private _MetroAppButton1 As MetroAppButton
        <AccessedThroughProperty("MetroTabItem1")> _
        Private _MetroTabItem1 As MetroTabItem
        <AccessedThroughProperty("MetroTabItem2")> _
        Private _MetroTabItem2 As MetroTabItem
        <AccessedThroughProperty("ButtonItem1")> _
        Private _ButtonItem1 As ButtonItem
        <AccessedThroughProperty("StyleManager1")> _
        Private _StyleManager1 As StyleManager
        <AccessedThroughProperty("MetroTabPanel4")> _
        Private _MetroTabPanel4 As MetroTabPanel
        <AccessedThroughProperty("MetroTabItem4")> _
        Private _MetroTabItem4 As MetroTabItem
        <AccessedThroughProperty("ReflectionLabel5")> _
        Private _ReflectionLabel5 As ReflectionLabel
        <AccessedThroughProperty("ReflectionLabel3")> _
        Private _ReflectionLabel3 As ReflectionLabel
        <AccessedThroughProperty("ReflectionLabel2")> _
        Private _ReflectionLabel2 As ReflectionLabel
        <AccessedThroughProperty("ReflectionLabel1")> _
        Private _ReflectionLabel1 As ReflectionLabel
        <AccessedThroughProperty("lblSummary_FuelRev")> _
        Private _lblSummary_FuelRev As LabelX
        <AccessedThroughProperty("lblSummary_TestTime")> _
        Private _lblSummary_TestTime As LabelX
        <AccessedThroughProperty("lblSummary_TestDate")> _
        Private _lblSummary_TestDate As LabelX
        <AccessedThroughProperty("lblSummary_ScriptRev")> _
        Private _lblSummary_ScriptRev As LabelX
        <AccessedThroughProperty("lblSummary_PSTColor")> _
        Private _lblSummary_PSTColor As LabelX
        <AccessedThroughProperty("lblSummary_PSTBlack")> _
        Private _lblSummary_PSTBlack As LabelX
        <AccessedThroughProperty("lblSummary_EngPgCnt")> _
        Private _lblSummary_EngPgCnt As LabelX
        <AccessedThroughProperty("lblSummary_FW")> _
        Private _lblSummary_FW As LabelX
        <AccessedThroughProperty("lblSummary_SerialNum")> _
        Private _lblSummary_SerialNum As LabelX
        <AccessedThroughProperty("Chart1")> _
        Private _Chart1 As Chart
        <AccessedThroughProperty("Chart2")> _
        Private _Chart2 As Chart
        <AccessedThroughProperty("MetroTabPanel3")> _
        Private _MetroTabPanel3 As MetroTabPanel
        <AccessedThroughProperty("Chart3")> _
        Private _Chart3 As Chart
        <AccessedThroughProperty("MetroTabItem3")> _
        Private _MetroTabItem3 As MetroTabItem
        <AccessedThroughProperty("TableLayoutPanel5")> _
        Private _TableLayoutPanel5 As TableLayoutPanel
        <AccessedThroughProperty("lblHistory_TotalUnits")> _
        Private _lblHistory_TotalUnits As LabelX
        <AccessedThroughProperty("cmdDataSelect")> _
        Private _cmdDataSelect As ButtonX
        <AccessedThroughProperty("cmdShowRuncharts")> _
        Private _cmdShowRuncharts As ButtonItem
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("ReflectionLabel4")> _
        Private _ReflectionLabel4 As ReflectionLabel
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
        <AccessedThroughProperty("lblFailModes")> _
        Private _lblFailModes As LabelX
        <AccessedThroughProperty("MetroTabPanel5")> _
        Private _MetroTabPanel5 As MetroTabPanel
        <AccessedThroughProperty("SuperTabControl1")> _
        Private _SuperTabControl1 As SuperTabControl
        <AccessedThroughProperty("SuperTabControlPanel1")> _
        Private _SuperTabControlPanel1 As SuperTabControlPanel
        <AccessedThroughProperty("stiPSTDocs_Intro")> _
        Private _stiPSTDocs_Intro As SuperTabItem
        <AccessedThroughProperty("SuperTabControlPanel4")> _
        Private _SuperTabControlPanel4 As SuperTabControlPanel
        <AccessedThroughProperty("stiPSTDocs_CyclicalPressure")> _
        Private _stiPSTDocs_CyclicalPressure As SuperTabItem
        <AccessedThroughProperty("SuperTabControlPanel3")> _
        Private _SuperTabControlPanel3 As SuperTabControlPanel
        <AccessedThroughProperty("stiPSTDocs_DelayedPressure")> _
        Private _stiPSTDocs_DelayedPressure As SuperTabItem
        <AccessedThroughProperty("SuperTabControlPanel2")> _
        Private _SuperTabControlPanel2 As SuperTabControlPanel
        <AccessedThroughProperty("stiPSTDocs_NoPressure")> _
        Private _stiPSTDocs_NoPressure As SuperTabItem
        <AccessedThroughProperty("tabTriage")> _
        Private _tabTriage As MetroTabItem
        <AccessedThroughProperty("rtbPSTDocs_Intro")> _
        Private _rtbPSTDocs_Intro As RichTextBox
        <AccessedThroughProperty("SuperTabControlPanel5")> _
        Private _SuperTabControlPanel5 As SuperTabControlPanel
        <AccessedThroughProperty("stiPSTDocs_PressureFluctuates")> _
        Private _stiPSTDocs_PressureFluctuates As SuperTabItem
        <AccessedThroughProperty("SuperTabControlPanel6")> _
        Private _SuperTabControlPanel6 As SuperTabControlPanel
        <AccessedThroughProperty("rtbPSTDocs_PSTOutputs")> _
        Private _rtbPSTDocs_PSTOutputs As RichTextBox
        <AccessedThroughProperty("stiPSTDocs_Outputs")> _
        Private _stiPSTDocs_Outputs As SuperTabItem
        <AccessedThroughProperty("rtbPSTDocs_NoPressure")> _
        Private _rtbPSTDocs_NoPressure As RichTextBox
        <AccessedThroughProperty("rtbPSTDocs_PressureFluctuates")> _
        Private _rtbPSTDocs_PressureFluctuates As RichTextBox
        <AccessedThroughProperty("rtbPSTDocs_CyclicalPressure")> _
        Private _rtbPSTDocs_CyclicalPressure As RichTextBox
        <AccessedThroughProperty("rtbPSTDocs_DelayedPressure")> _
        Private _rtbPSTDocs_DelayedPressure As RichTextBox
        <AccessedThroughProperty("MetroStatusBar1")> _
        Private _MetroStatusBar1 As MetroStatusBar
        <AccessedThroughProperty("cmdEmail")> _
        Private _cmdEmail As ButtonItem
        <AccessedThroughProperty("cmdClipBoard")> _
        Private _cmdClipBoard As ButtonItem
        <AccessedThroughProperty("ButtonItem2")> _
        Private _ButtonItem2 As ButtonItem
        <AccessedThroughProperty("ButtonItem3")> _
        Private _ButtonItem3 As ButtonItem
        <AccessedThroughProperty("SuperTooltip1")> _
        Private _SuperTooltip1 As SuperTooltip
        <AccessedThroughProperty("lstSummaryMechChecks")> _
        Private _lstSummaryMechChecks As ListViewEx
        <AccessedThroughProperty("ImageList1")> _
        Private _ImageList1 As ImageList
        <AccessedThroughProperty("ColumnHeader2")> _
        Private _ColumnHeader2 As ColumnHeader
        <AccessedThroughProperty("Chart4")> _
        Private _Chart4 As Chart
        <AccessedThroughProperty("cmdShowRegularcharts")> _
        Private _cmdShowRegularcharts As ButtonItem
        <AccessedThroughProperty("cboRunCharts")> _
        Private _cboRunCharts As ComboBoxEx
        <AccessedThroughProperty("cmdShowDataGrid")> _
        Private _cmdShowDataGrid As ButtonItem
        <AccessedThroughProperty("sgcHistory")> _
        Private _sgcHistory As SuperGridControl
        <AccessedThroughProperty("cboHistory_XVal")> _
        Private _cboHistory_XVal As ComboBoxEx
        <AccessedThroughProperty("cboHistory_YVal")> _
        Private _cboHistory_YVal As ComboBoxEx
        <AccessedThroughProperty("cboHistory_Series")> _
        Private _cboHistory_Series As ComboBoxEx
        <AccessedThroughProperty("lblHistory_XVal")> _
        Private _lblHistory_XVal As LabelX
        <AccessedThroughProperty("lblHistory_YVal")> _
        Private _lblHistory_YVal As LabelX
        <AccessedThroughProperty("lblHistory_Series")> _
        Private _lblHistory_Series As LabelX
        <AccessedThroughProperty("cmdHistory_ChartIt")> _
        Private _cmdHistory_ChartIt As ButtonX
        <AccessedThroughProperty("cmdHistory_DataGrid_Edit")> _
        Private _cmdHistory_DataGrid_Edit As ButtonX
        <AccessedThroughProperty("MetroTabPanel6")> _
        Private _MetroTabPanel6 As MetroTabPanel
        <AccessedThroughProperty("ButtonX2")> _
        Private _ButtonX2 As ButtonX
        <AccessedThroughProperty("ButtonX1")> _
        Private _ButtonX1 As ButtonX
        <AccessedThroughProperty("tabHelp")> _
        Private _tabHelp As MetroTabItem
        <AccessedThroughProperty("lblSummary_ScriptProduct")> _
        Private _lblSummary_ScriptProduct As LabelX
        <AccessedThroughProperty("lblMeasTubeEvac_K")> _
        Private _lblMeasTubeEvac_K As LabelX
        <AccessedThroughProperty("lblTitleTubeEvac_k")> _
        Private _lblTitleTubeEvac_k As LabelX
        <AccessedThroughProperty("lblSpecTubeEvac_K")> _
        Private _lblSpecTubeEvac_K As LabelX
        <AccessedThroughProperty("lblTitleTubeEvac_C")> _
        Private _lblTitleTubeEvac_C As LabelX
        <AccessedThroughProperty("lblMeasTubeEvac_C")> _
        Private _lblMeasTubeEvac_C As LabelX
        <AccessedThroughProperty("lblSpecTubeEvac_C")> _
        Private _lblSpecTubeEvac_C As LabelX
        <AccessedThroughProperty("FlowLayoutPanel1")> _
        Private _FlowLayoutPanel1 As FlowLayoutPanel
        <AccessedThroughProperty("lblHidden_TestInfo")> _
        Private _lblHidden_TestInfo As Label
        <AccessedThroughProperty("lblHidden_TestID")> _
        Private _lblHidden_TestID As Label
        <AccessedThroughProperty("lblHidden_Date")> _
        Private _lblHidden_Date As Label
        <AccessedThroughProperty("lblHidden_Time")> _
        Private _lblHidden_Time As Label
        <AccessedThroughProperty("lblHidden_Serial")> _
        Private _lblHidden_Serial As Label
        <AccessedThroughProperty("lblHidden_RunNum")> _
        Private _lblHidden_RunNum As Label
        <AccessedThroughProperty("lblHidden_FUELRev")> _
        Private _lblHidden_FUELRev As Label
        <AccessedThroughProperty("lblHidden_ScriptRev")> _
        Private _lblHidden_ScriptRev As Label
        <AccessedThroughProperty("lblHidden_Product")> _
        Private _lblHidden_Product As Label
        <AccessedThroughProperty("ButtonItem4")> _
        Private _ButtonItem4 As ButtonItem
        <AccessedThroughProperty("lblSummary_Run")> _
        Private _lblSummary_Run As LabelX
        <AccessedThroughProperty("lblSummary_TestID")> _
        Private _lblSummary_TestID As LabelX
        <AccessedThroughProperty("cmdSaveFormImage")> _
        Private _cmdSaveFormImage As ButtonItem
        Private dtHistory As DataTable
        Private PST As PST
        Private TestStatus As Boolean

        ' Nested Types
        Private Enum Channels
            ' Fields
            Black = 0
            Color = 1
        End Enum

        Private Class ChartData
            ' Properties
            Public Property Indexer As Long
                <DebuggerNonUserCode> _
                Get
                    Return Me._Indexer
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Long)
                    Me._Indexer = AutoPropertyValue
                End Set
            End Property

            Public Property XVal As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me._XVal
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me._XVal = AutoPropertyValue
                End Set
            End Property

            Public Property YVal As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me._YVal
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me._YVal = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Indexer As Long
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _XVal As Double
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _YVal As Double
        End Class

        Private Class HistoryData
            ' Properties
            Public Property Indexer As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me._Indexer
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me._Indexer = AutoPropertyValue
                End Set
            End Property

            Public Property RunChartYVal As Object
                <DebuggerNonUserCode> _
                Get
                    Return Me._RunChartYVal
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Object)
                    Me._RunChartYVal = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Indexer As Integer
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _RunChartYVal As Object
        End Class
    End Class
End Namespace

