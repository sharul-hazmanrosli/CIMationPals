Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports DevComponents.Editors
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Namespace FUEL
    <DesignerGenerated> _
    Public Class ctrlRunCharts
        Inherits UserControl
        ' Methods
        Public Sub New(ByVal dtHistory As DataTable)
            ctrlRunCharts.__ENCAddToList(Me)
            Me.InitializeComplete = False
            Me.InitializeComponent
            Me.InitializeComplete = True
            Me.expOptions.Expanded = False
            Me._dtHistory = dtHistory
            Me._dvHistory = New DataView(dtHistory)
            Me.GetHeaders
            Me._CurrentMetric = If(Not Me._dtHistory.Columns.Contains("K_MAX_PRESSURE"), If(Not Me._dtHistory.Columns.Contains("K_MAX_PRESSURE_Val"), Nothing, "K_MAX_PRESSURE_Val"), "K_MAX_PRESSURE")
            Me.cboRunCharts.Text = Me._CurrentMetric
            Me.AddHistoryData
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlRunCharts.__ENCList
                If (ctrlRunCharts.__ENCList.Count = ctrlRunCharts.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlRunCharts.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlRunCharts.__ENCList.RemoveRange(index, (ctrlRunCharts.__ENCList.Count - index))
                            ctrlRunCharts.__ENCList.Capacity = ctrlRunCharts.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlRunCharts.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlRunCharts.__ENCList(index) = ctrlRunCharts.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlRunCharts.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Friend Sub AddHistoryData()
            Try 
                ChartUtilities.ClearChart(Me.Chart1)
                Dim objA As List(Of HistoryData) = Me.BuildHistoryDataList
                If Object.ReferenceEquals(objA, Nothing) Then
                    If (Me._CurrentMetric <> Nothing) Then
                        MessageBox.Show("No data to display", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                ElseIf Not Versioned.IsNumeric(objA(0).RunChartYVal) Then
                    MessageBox.Show("Invalid non-numeric value selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Me.Chart1.Series.Add("KMax")
                    Dim series As Series = Me.Chart1.Series("KMax")
                    If Not Me.chkGrpBySerial.Checked Then
                        series.Points.DataBind(objA, "Indexer", "RunChartYVal", Nothing)
                    Else
                        series.Points.DataBind(objA, "Name", "RunChartYVal", Nothing)
                    End If
                    series = Nothing
                    Me.Chart1.Series("KMax").Enabled = False
                    If Not Me.chkGrpBySerial.Checked Then
                        Me.Chart1.DataManipulator.Group("AVE", CDbl(Me.intUnitsPerGroup.Value), IntervalType.Number, "KMax", "Ẋ")
                    Else
                        Me.Chart1.DataManipulator.GroupByAxisLabel("AVE", "KMax", "Ẋ")
                    End If
                    Dim num2 As Integer = 0
                    Dim num12 As Integer = (Me.Chart1.Series("Ẋ").Points.Count - 1)
                    Dim num10 As Integer = 0
                    Do While True
                        Dim num16 As Integer = num12
                        If (num10 > num16) Then
                            Dim enumerator As IEnumerator(Of DataPoint)
                            If Not Me.chkGrpBySerial.Checked Then
                                Me.Chart1.DataManipulator.Group("HiLo", CDbl(Me.intUnitsPerGroup.Value), IntervalType.Number, "KMax", "HiLo")
                            Else
                                Me.Chart1.DataManipulator.GroupByAxisLabel("HiLo", "KMax", "HiLo")
                            End If
                            Me.Chart1.Series("HiLo").Enabled = False
                            Dim dataSource As New List(Of ChartData)
                            Dim num As Long = 0
                            Try 
                                enumerator = Me.Chart1.Series("HiLo").Points.GetEnumerator
                                Do While True
                                    If Not enumerator.MoveNext Then
                                        Exit Do
                                    End If
                                    Dim current As DataPoint = enumerator.Current
                                    Dim data As New ChartData With { _
                                        .YVal = (Me.Chart1.Series("HiLo").Points(CInt(num)).YValues(0) - Me.Chart1.Series("HiLo").Points(CInt(num)).YValues(1)), _
                                        .Indexer = num _
                                    }
                                    dataSource.Add(data)
                                    num = (num + 1)
                                Loop
                            Finally
                                If Not Object.ReferenceEquals(enumerator, Nothing) Then
                                    enumerator.Dispose
                                End If
                            End Try
                            Me.Chart1.Series.Add("r")
                            Dim series2 As Series = Me.Chart1.Series("r")
                            series2.Points.DataBind(dataSource, "Indexer", "YVal", Nothing)
                            series2.ChartArea = "ChartArea2"
                            series2 = Nothing
                            Dim num7 As Double = Me.Chart1.DataManipulator.Statistics.Mean("Ẋ")
                            Dim intervalOffset As Double = Me.Chart1.DataManipulator.Statistics.Mean("r")
                            Dim num9 As Double = (num7 + (0.729 * intervalOffset))
                            Dim num8 As Double = (num7 - (0.729 * intervalOffset))
                            Dim num6 As Double = (intervalOffset * 2.282)
                            Dim num5 As Double = (intervalOffset * 0)
                            Dim item As StripLine = ChartUtilities.GetStripLine(("Control Limits: " & Math.Round(num7, 1).ToString & " ±" & Math.Round(CDbl((0.729 * intervalOffset)), 1).ToString), TextOrientation.Horizontal, StringAlignment.Far, StringAlignment.Far, Color.Black, num8, (num9 - num8), Color.Orange)
                            Me.Chart1.ChartAreas("ChartArea1").AxisY.StripLines.Add(item)
                            Dim line3 As StripLine = ChartUtilities.GetStripLine(("Ẍ = " & Conversions.ToString(Math.Round(num7, 2))), TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.Black, num7, Color.Red, 2)
                            Me.Chart1.ChartAreas("ChartArea1").AxisY.StripLines.Add(line3)
                            Dim line2 As StripLine = ChartUtilities.GetStripLine("Control Limits", TextOrientation.Horizontal, StringAlignment.Far, StringAlignment.Far, Color.Black, num5, (num6 - num5), Color.Orange)
                            Me.Chart1.ChartAreas("ChartArea2").AxisY.StripLines.Add(line2)
                            Dim line4 As StripLine = ChartUtilities.GetStripLine(("Ṙ = " & Conversions.ToString(Math.Round(intervalOffset, 2))), TextOrientation.Horizontal, StringAlignment.Near, StringAlignment.Far, Color.Black, intervalOffset, Color.Red, 2)
                            Me.Chart1.ChartAreas("ChartArea2").AxisY.StripLines.Add(line4)
                            ChartUtilities.AddChartTitle("Ẋ", Me.Chart1, "ChartArea1", Docking.Top)
                            ChartUtilities.AddChartTitle("Ṙ", Me.Chart1, "ChartArea2", Docking.Top)
                            Me.Chart1.Legends(0).Enabled = False
                            Me.Chart1.ChartAreas("ChartArea1").AxisY.Title = Me._CurrentMetric
                            Me.Chart1.ChartAreas("ChartArea2").AxisY.Title = Me._CurrentMetric
                            Me.Chart1.ChartAreas("ChartArea1").AxisX.Title = "Sample Group"
                            Me.Chart1.ChartAreas("ChartArea2").AxisX.Title = "Sample Group"
                            Me.Chart1.ChartAreas("ChartArea1").AxisY.Minimum = Math.Min(Math.Round(CDbl((num8 - (num8 * 0.1))), 0), Math.Round(CDbl((Me.Chart1.Series("Ẋ").Points.FindMinByValue.YValues(0) - (Me.Chart1.Series("Ẋ").Points.FindMinByValue.YValues(0) * 0.1))), 0))
                            Me.Chart1.ChartAreas("ChartArea1").AxisY.Maximum = Math.Max(Math.Round(CDbl((num9 + (num9 * 0.1))), 0), Math.Round(CDbl((Me.Chart1.Series("Ẋ").Points.FindMaxByValue.YValues(0) + (Me.Chart1.Series("Ẋ").Points.FindMaxByValue.YValues(0) * 0.1))), 0))
                            Me.Chart1.ChartAreas("ChartArea2").AxisY.Maximum = Math.Max(Math.Round(CDbl((num6 + (num6 * 0.1))), 0), Math.Round(CDbl((Me.Chart1.Series("r").Points.FindMaxByValue.YValues(0) + (Me.Chart1.Series("r").Points.FindMaxByValue.YValues(0) * 0.1))), 0))
                            Me.Chart1.ChartAreas("ChartArea1").AxisX.Minimum = 0
                            Me.Chart1.ChartAreas("ChartArea2").AxisX.Minimum = 0
                            Dim axisX As Axis = Me.Chart1.ChartAreas("ChartArea1").AxisX
                            axisX.MajorGrid.Interval = CInt(Math.Round(CDbl((0.2 * Me.Chart1.Series("Ẋ").Points.Count))))
                            axisX.MajorTickMark.Interval = Me.Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval
                            axisX.Interval = Me.Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval
                            axisX.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4, CInt(Math.Round(Me.Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Interval)))
                            axisX.MinorGrid.LineColor = Color.LightGray
                            axisX.MinorGrid.Enabled = True
                            axisX = Nothing
                            Dim axis2 As Axis = Me.Chart1.ChartAreas("ChartArea2").AxisX
                            axis2.MajorGrid.Interval = CInt(Math.Round(CDbl((0.2 * Me.Chart1.Series("r").Points.Count))))
                            axis2.MajorTickMark.Interval = Me.Chart1.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval
                            axis2.Interval = Me.Chart1.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval
                            axis2.MinorGrid.Interval = ChartUtilities.GetMinorGridInterval(4, CInt(Math.Round(Me.Chart1.ChartAreas("ChartArea2").AxisX.MajorGrid.Interval)))
                            axis2.MinorGrid.LineColor = Color.LightGray
                            axis2.MinorGrid.Enabled = True
                            axis2 = Nothing
                            ChartUtilities.SetXAxisZoom(Me.Chart1.ChartAreas(0), True)
                            ChartUtilities.LinkChartAreas(Me.Chart1.ChartAreas(0), Me.Chart1.ChartAreas(1))
                            If Me.chkDisplayDataLabels.Checked Then
                                ChartUtilities.AddSeriesDataLabels(Me.Chart1, Me.Chart1.Series("Ẋ"))
                                ChartUtilities.AddSeriesDataLabels(Me.Chart1, Me.Chart1.Series("r"))
                            End If
                            Dim num15 As Integer = (Me.Chart1.Series.Count - 1)
                            Dim num11 As Integer = 0
                            Do While True
                                num16 = num15
                                If (num11 > num16) Then
                                    Dim count As Integer = Me.Chart1.Series("KMax").Points.Count
                                    Me.lblHistory_TotalUnits.Text = ("Total Units in History: " & Conversions.ToString(count))
                                    Exit Do
                                End If
                                Dim series3 As Series = Me.Chart1.Series(num11)
                                series3.ChartType = SeriesChartType.Line
                                series3.BorderWidth = 1
                                series3.Color = Color.Blue
                                series3.MarkerStyle = MarkerStyle.Circle
                                series3.MarkerSize = 6
                                series3.MarkerColor = Color.Blue
                                series3 = Nothing
                                num11 += 1
                            Loop
                            Exit Do
                        End If
                        Me.Chart1.Series("Ẋ").Points(num10).XValue = num2
                        num2 += 1
                        num10 += 1
                    Loop
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Function BuildHistoryDataList() As List(Of HistoryData)
            Dim list As List(Of HistoryData)
            Try 
                Me._dvHistory.RowFilter = Me.txtFilters.Text
                If Not ((Me._dvHistory.Count > 0) And (Me._CurrentMetric <> Nothing)) Then
                    list = Nothing
                Else
                    Dim list2 As New List(Of HistoryData)
                    Dim num As Integer = 0
                    Dim num3 As Integer = (Me._dvHistory.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            list = list2
                            Exit Do
                        End If
                        If Not Information.IsDBNull(Me._dvHistory(num2)(Me.CurrentMetric)) Then
                            If Not Versioned.IsNumeric(Me._dvHistory(num2)(Me.CurrentMetric)) Then
                                If Me._CurrentMetric.Contains("_Result") Then
                                    Interaction.MsgBox("Metric names that end with '_Result' contain Boolean information that indicates if the units passed the specific test. This data is not numerical and thus cannot be added to a run chart" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "I suggest that you select a metric whose name ends with '_Val'.", MsgBoxStyle.ApplicationModal, Nothing)
                                    list = Nothing
                                Else
                                    Interaction.MsgBox("Non-Numeric data detected, Please select a metric that contains numerical data.", MsgBoxStyle.ApplicationModal, Nothing)
                                    list = Nothing
                                End If
                                Exit Do
                            End If
                            Dim item As New HistoryData With { _
                                .Indexer = num, _
                                .Name = Conversions.ToString(Me._dvHistory(num2)("SERIAL_NUM")), _
                                .RunChartYVal = Conversions.ToDouble(Me._dvHistory(num2)(Me.CurrentMetric)) _
                            }
                            list2.Add(item)
                            num += 1
                        End If
                        num2 += 1
                    Loop
                End If
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Interaction.MsgBox(ex.ToString, MsgBoxStyle.ApplicationModal, Nothing)
                list = Nothing
                ProjectData.ClearProjectError
            End Try
            Return list
        End Function

        Private Sub cboRunCharts_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me._CurrentMetric = Me.cboRunCharts.Text
            Me.AddHistoryData
        End Sub

        Private Sub chkDisplayDataLabels_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.InitializeComplete Then
                Me.expOptions.Expanded = False
                If Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, Nothing, "checked", New Object(0  - 1) {}, Nothing, Nothing, Nothing), True, False) Then
                    ChartUtilities.AddSeriesDataLabels(Me.Chart1, Me.Chart1.Series("Ẋ"))
                    ChartUtilities.AddSeriesDataLabels(Me.Chart1, Me.Chart1.Series("r"))
                Else
                    ChartUtilities.RemoveSeriesDataLabels(Me.Chart1, Me.Chart1.Series("Ẋ"))
                    ChartUtilities.RemoveSeriesDataLabels(Me.Chart1, Me.Chart1.Series("r"))
                End If
            End If
        End Sub

        Private Sub chkGrpBySerial_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.InitializeComplete Then
                Me.expOptions.Expanded = False
            End If
            Me.intUnitsPerGroup.Enabled = Not Me.chkGrpBySerial.Checked
            Me.lblUnitesPerGroup.Enabled = Not Me.chkGrpBySerial.Checked
            Me.AddHistoryData
        End Sub

        Private Sub ClearFilters()
            Me.cboFilter1.Text = Nothing
            Me.cboFilter2.Text = Nothing
            Me.cboFilter3.Text = Nothing
            Me.cboFilter4.Text = Nothing
            Me.txtFilter1_val.Text = Nothing
            Me.txtFilter2_val.Text = Nothing
            Me.txtFilter3_val.Text = Nothing
            Me.txtFilter4_val.Text = Nothing
        End Sub

        Private Sub cmdFilter_Apply_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.txtFilters.CloseDropDown
            Me.GetFilters
        End Sub

        Private Sub cmdFilter_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.txtFilters.CloseDropDown
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

        Private Sub GetFilters()
            Dim str As String = Nothing
            Dim strArray As String()
            If ((Me.cboFilter1.Text <> Nothing) And (Me.txtFilter1_val.Text <> Nothing)) Then
                Dim text As String = Me.cboFilter1.Text
                If [text].Contains(" ") Then
                    [text] = ("[" & [text] & "]")
                End If
                strArray = New String() { [text], " ", Me.cboOper1.Text, " '", Me.txtFilter1_val.Text, "'" }
                str = String.Concat(strArray)
            End If
            If ((Me.cboFilter2.Text <> Nothing) And (Me.txtFilter2_val.Text <> Nothing)) Then
                Dim text As String = Me.cboFilter2.Text
                If [text].Contains(" ") Then
                    [text] = ("[" & [text] & "]")
                End If
                If ([text] = Nothing) Then
                    str = ([text] & " = '" & Me.txtFilter2_val.Text & "'")
                Else
                    strArray = New String() { str, " ", Me.cboOper2.Text, " ", [text], " = '", Me.txtFilter2_val.Text, "'" }
                    str = String.Concat(strArray)
                End If
            End If
            If ((Me.cboFilter3.Text <> Nothing) And (Me.txtFilter3_val.Text <> Nothing)) Then
                Dim text As String = Me.cboFilter3.Text
                If [text].Contains(" ") Then
                    [text] = ("[" & [text] & "]")
                End If
                If ([text] = Nothing) Then
                    str = ([text] & " = '" & Me.txtFilter3_val.Text & "'")
                Else
                    strArray = New String() { str, " ", Me.cboOper3.Text, " ", [text], " = '", Me.txtFilter3_val.Text, "'" }
                    str = String.Concat(strArray)
                End If
            End If
            If ((Me.cboFilter4.Text <> Nothing) And (Me.txtFilter4_val.Text <> Nothing)) Then
                Dim text As String = Me.cboFilter4.Text
                If [text].Contains(" ") Then
                    [text] = ("[" & [text] & "]")
                End If
                If ([text] = Nothing) Then
                    str = ([text] & " = '" & Me.txtFilter4_val.Text & "'")
                Else
                    strArray = New String() { str, " ", Me.cboOper4.Text, " ", [text], " = '", Me.txtFilter4_val.Text, "'" }
                    str = String.Concat(strArray)
                End If
            End If
            Me.txtFilters.Text = str
        End Sub

        Private Sub GetHeaders()
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me._dtHistory.Columns.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As DataColumn = DirectCast(enumerator.Current, DataColumn)
                    Me.cboRunCharts.Items.Add(current.ColumnName)
                    Me.cboFilter1.Items.Add(current.ColumnName)
                    Me.cboFilter2.Items.Add(current.ColumnName)
                    Me.cboFilter3.Items.Add(current.ColumnName)
                    Me.cboFilter4.Items.Add(current.ColumnName)
                Loop
            Finally
                If Not Object.ReferenceEquals(TryCast(enumerator,IDisposable), Nothing) Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Dim item As New ChartArea
            Dim area2 As New ChartArea
            Dim legend As New Legend
            Dim series As New Series
            Me.Chart1 = New Chart
            Me.cboRunCharts = New ComboBoxEx
            Me.lblHistory_TotalUnits = New LabelX
            Me.txtFilter1_val = New TextBoxX
            Me.cboFilter1 = New ComboBoxEx
            Me.ItemPanel1 = New ItemPanel
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.cboFilter4 = New ComboBoxEx
            Me.cboFilter2 = New ComboBoxEx
            Me.cboFilter3 = New ComboBoxEx
            Me.txtFilter2_val = New TextBoxX
            Me.txtFilter3_val = New TextBoxX
            Me.txtFilter4_val = New TextBoxX
            Me.cmdFilter_Apply = New ButtonX
            Me.cmdFilter_Cancel = New ButtonX
            Me.txtFilters = New TextBoxDropDown
            Me.intUnitsPerGroup = New IntegerInput
            Me.lblUnitesPerGroup = New LabelX
            Me.chkGrpBySerial = New CheckBoxX
            Me.chkDisplayDataLabels = New CheckBoxX
            Me.expOptions = New ExpandablePanel
            Me.StyleManager1 = New StyleManager(Me.components)
            Me.cboOper1 = New ComboBoxEx
            Me.ComboItem1 = New ComboItem
            Me.ComboItem2 = New ComboItem
            Me.ComboItem3 = New ComboItem
            Me.ComboItem4 = New ComboItem
            Me.ComboItem5 = New ComboItem
            Me.ComboItem6 = New ComboItem
            Me.cboOper2 = New ComboBoxEx
            Me.ComboItem7 = New ComboItem
            Me.ComboItem8 = New ComboItem
            Me.ComboItem9 = New ComboItem
            Me.ComboItem10 = New ComboItem
            Me.ComboItem11 = New ComboItem
            Me.ComboItem12 = New ComboItem
            Me.cboOper3 = New ComboBoxEx
            Me.ComboItem13 = New ComboItem
            Me.ComboItem14 = New ComboItem
            Me.ComboItem15 = New ComboItem
            Me.ComboItem16 = New ComboItem
            Me.ComboItem17 = New ComboItem
            Me.ComboItem18 = New ComboItem
            Me.cboOper4 = New ComboBoxEx
            Me.ComboItem19 = New ComboItem
            Me.ComboItem20 = New ComboItem
            Me.ComboItem21 = New ComboItem
            Me.ComboItem22 = New ComboItem
            Me.ComboItem23 = New ComboItem
            Me.ComboItem24 = New ComboItem
            Me.Chart1.BeginInit
            Me.ItemPanel1.SuspendLayout
            Me.TableLayoutPanel1.SuspendLayout
            Me.intUnitsPerGroup.BeginInit
            Me.expOptions.SuspendLayout
            Me.SuspendLayout
            Me.Chart1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.Chart1.BorderlineColor = Color.DarkRed
            Me.Chart1.BorderlineDashStyle = ChartDashStyle.Solid
            Me.Chart1.BorderlineWidth = 2
            item.Name = "ChartArea1"
            area2.Name = "ChartArea2"
            Me.Chart1.ChartAreas.Add(item)
            Me.Chart1.ChartAreas.Add(area2)
            legend.Name = "Legend1"
            Me.Chart1.Legends.Add(legend)
            Dim point2 As New Point(3, &H1F)
            Me.Chart1.Location = point2
            Me.Chart1.Name = "Chart1"
            series.ChartArea = "ChartArea1"
            series.Legend = "Legend1"
            series.Name = "Series1"
            Me.Chart1.Series.Add(series)
            Dim size2 As New Size(&H3A4, &H145)
            Me.Chart1.Size = size2
            Me.Chart1.TabIndex = 9
            Me.Chart1.Text = "Chart1"
            Me.cboRunCharts.DisplayMember = "Text"
            Me.cboRunCharts.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboRunCharts.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboRunCharts.ForeColor = Color.Black
            Me.cboRunCharts.FormattingEnabled = True
            Me.cboRunCharts.ItemHeight = &H10
            point2 = New Point(3, 3)
            Me.cboRunCharts.Location = point2
            Me.cboRunCharts.Name = "cboRunCharts"
            size2 = New Size(&HC9, &H16)
            Me.cboRunCharts.Size = size2
            Me.cboRunCharts.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboRunCharts.TabIndex = &H10
            Me.cboRunCharts.WatermarkText = "Select a Metric"
            Me.lblHistory_TotalUnits.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(210, 3)
            Me.lblHistory_TotalUnits.Location = point2
            Me.lblHistory_TotalUnits.Name = "lblHistory_TotalUnits"
            size2 = New Size(&H9F, &H17)
            Me.lblHistory_TotalUnits.Size = size2
            Me.lblHistory_TotalUnits.TabIndex = &H11
            Me.txtFilter1_val.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.txtFilter1_val.Border.Class = "TextBoxBorder"
            Me.txtFilter1_val.Border.CornerType = eCornerType.Square
            Me.txtFilter1_val.ForeColor = Color.Black
            point2 = New Point(190, 3)
            Me.txtFilter1_val.Location = point2
            Me.txtFilter1_val.Name = "txtFilter1_val"
            size2 = New Size(90, 20)
            Me.txtFilter1_val.Size = size2
            Me.txtFilter1_val.TabIndex = &H13
            Me.cboFilter1.DisplayMember = "Text"
            Me.cboFilter1.Dock = DockStyle.Top
            Me.cboFilter1.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboFilter1.FormattingEnabled = True
            Me.cboFilter1.ItemHeight = 14
            point2 = New Point(3, 3)
            Me.cboFilter1.Location = point2
            Me.cboFilter1.Name = "cboFilter1"
            size2 = New Size(&H88, 20)
            Me.cboFilter1.Size = size2
            Me.cboFilter1.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboFilter1.TabIndex = &H12
            Me.ItemPanel1.BackgroundStyle.Class = "ItemPanel"
            Me.ItemPanel1.BackgroundStyle.CornerType = eCornerType.Square
            Me.ItemPanel1.ContainerControlProcessDialogKey = True
            Me.ItemPanel1.Controls.Add(Me.TableLayoutPanel1)
            Me.ItemPanel1.LayoutOrientation = eOrientation.Vertical
            Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            point2 = New Point(&H177, &H1F)
            Me.ItemPanel1.Location = point2
            Me.ItemPanel1.Name = "ItemPanel1"
            size2 = New Size(&H11B, &H91)
            Me.ItemPanel1.Size = size2
            Me.ItemPanel1.TabIndex = &H15
            Me.ItemPanel1.Text = "ItemPanel1"
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 45!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40!))
            Me.TableLayoutPanel1.Controls.Add(Me.cboOper4, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboOper3, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.cboOper2, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFilter4, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFilter1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFilter2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFilter3, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.cmdFilter_Apply, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFilter1_val, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFilter2_val, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFilter3_val, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFilter4_val, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboOper1, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cmdFilter_Cancel, 2, 4)
            Me.TableLayoutPanel1.Dock = DockStyle.Fill
            point2 = New Point(0, 0)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle)
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle)
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle)
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle)
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
            size2 = New Size(&H11B, &H91)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 0
            Me.cboFilter4.DisplayMember = "Text"
            Me.cboFilter4.Dock = DockStyle.Top
            Me.cboFilter4.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboFilter4.FormattingEnabled = True
            Me.cboFilter4.ItemHeight = 14
            point2 = New Point(3, &H52)
            Me.cboFilter4.Location = point2
            Me.cboFilter4.Name = "cboFilter4"
            size2 = New Size(&H88, 20)
            Me.cboFilter4.Size = size2
            Me.cboFilter4.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboFilter4.TabIndex = &H16
            Me.cboFilter2.DisplayMember = "Text"
            Me.cboFilter2.Dock = DockStyle.Top
            Me.cboFilter2.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboFilter2.FormattingEnabled = True
            Me.cboFilter2.ItemHeight = 14
            point2 = New Point(3, 30)
            Me.cboFilter2.Location = point2
            Me.cboFilter2.Name = "cboFilter2"
            size2 = New Size(&H88, 20)
            Me.cboFilter2.Size = size2
            Me.cboFilter2.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboFilter2.TabIndex = 20
            Me.cboFilter3.DisplayMember = "Text"
            Me.cboFilter3.Dock = DockStyle.Top
            Me.cboFilter3.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboFilter3.FormattingEnabled = True
            Me.cboFilter3.ItemHeight = 14
            point2 = New Point(3, &H38)
            Me.cboFilter3.Location = point2
            Me.cboFilter3.Name = "cboFilter3"
            size2 = New Size(&H88, 20)
            Me.cboFilter3.Size = size2
            Me.cboFilter3.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboFilter3.TabIndex = &H15
            Me.txtFilter2_val.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.txtFilter2_val.Border.Class = "TextBoxBorder"
            Me.txtFilter2_val.Border.CornerType = eCornerType.Square
            Me.txtFilter2_val.ForeColor = Color.Black
            point2 = New Point(190, 30)
            Me.txtFilter2_val.Location = point2
            Me.txtFilter2_val.Name = "txtFilter2_val"
            size2 = New Size(90, 20)
            Me.txtFilter2_val.Size = size2
            Me.txtFilter2_val.TabIndex = &H17
            Me.txtFilter3_val.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.txtFilter3_val.Border.Class = "TextBoxBorder"
            Me.txtFilter3_val.Border.CornerType = eCornerType.Square
            Me.txtFilter3_val.ForeColor = Color.Black
            point2 = New Point(190, &H38)
            Me.txtFilter3_val.Location = point2
            Me.txtFilter3_val.Name = "txtFilter3_val"
            size2 = New Size(90, 20)
            Me.txtFilter3_val.Size = size2
            Me.txtFilter3_val.TabIndex = &H18
            Me.txtFilter4_val.BackColor = Color.FromArgb(&HFF, &HFF, &HFF)
            Me.txtFilter4_val.Border.Class = "TextBoxBorder"
            Me.txtFilter4_val.Border.CornerType = eCornerType.Square
            Me.txtFilter4_val.ForeColor = Color.Black
            point2 = New Point(190, &H52)
            Me.txtFilter4_val.Location = point2
            Me.txtFilter4_val.Name = "txtFilter4_val"
            size2 = New Size(90, 20)
            Me.txtFilter4_val.Size = size2
            Me.txtFilter4_val.TabIndex = &H19
            Me.cmdFilter_Apply.AccessibleRole = AccessibleRole.PushButton
            Me.cmdFilter_Apply.Anchor = (AnchorStyles.Left Or AnchorStyles.Bottom)
            Me.cmdFilter_Apply.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(3, &H77)
            Me.cmdFilter_Apply.Location = point2
            Me.cmdFilter_Apply.Name = "cmdFilter_Apply"
            size2 = New Size(&H58, &H17)
            Me.cmdFilter_Apply.Size = size2
            Me.cmdFilter_Apply.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdFilter_Apply.TabIndex = &H1A
            Me.cmdFilter_Apply.Text = "Apply"
            Me.cmdFilter_Cancel.AccessibleRole = AccessibleRole.PushButton
            Me.cmdFilter_Cancel.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.cmdFilter_Cancel.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(&HC0, &H77)
            Me.cmdFilter_Cancel.Location = point2
            Me.cmdFilter_Cancel.Name = "cmdFilter_Cancel"
            size2 = New Size(&H58, &H17)
            Me.cmdFilter_Cancel.Size = size2
            Me.cmdFilter_Cancel.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdFilter_Cancel.TabIndex = &H1B
            Me.cmdFilter_Cancel.Text = "Cancel"
            Me.txtFilters.BackgroundStyle.Class = "TextBoxBorder"
            Me.txtFilters.BackgroundStyle.CornerType = eCornerType.Square
            Me.txtFilters.ButtonClear.Visible = True
            Me.txtFilters.ButtonDropDown.Visible = True
            Me.txtFilters.DropDownControl = Me.ItemPanel1
            point2 = New Point(&H177, 3)
            Me.txtFilters.Location = point2
            Me.txtFilters.Name = "txtFilters"
            Me.txtFilters.ReadOnly = True
            size2 = New Size(&H11B, &H16)
            Me.txtFilters.Size = size2
            Me.txtFilters.Style = eDotNetBarStyle.StyleManagerControlled
            Me.txtFilters.TabIndex = &H16
            Me.txtFilters.Text = ""
            Me.txtFilters.WatermarkText = "Filter Values"
            Me.intUnitsPerGroup.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.intUnitsPerGroup.BackgroundStyle.CornerType = eCornerType.Square
            Me.intUnitsPerGroup.ButtonFreeText.Shortcut = eShortcut.F2
            point2 = New Point(&H29A, 4)
            Me.intUnitsPerGroup.Location = point2
            Me.intUnitsPerGroup.MinValue = 1
            Me.intUnitsPerGroup.Name = "intUnitsPerGroup"
            Me.intUnitsPerGroup.ShowUpDown = True
            size2 = New Size(&H2D, 20)
            Me.intUnitsPerGroup.Size = size2
            Me.intUnitsPerGroup.TabIndex = &H17
            Me.intUnitsPerGroup.Value = 4
            Me.lblUnitesPerGroup.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(&H2CD, 3)
            Me.lblUnitesPerGroup.Location = point2
            Me.lblUnitesPerGroup.Name = "lblUnitesPerGroup"
            size2 = New Size(&H58, &H17)
            Me.lblUnitesPerGroup.Size = size2
            Me.lblUnitesPerGroup.TabIndex = &H18
            Me.lblUnitesPerGroup.Text = "Units Per Group"
            Me.chkGrpBySerial.BackColor = Color.Transparent
            Me.chkGrpBySerial.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(3, &H3A)
            Me.chkGrpBySerial.Location = point2
            Me.chkGrpBySerial.Name = "chkGrpBySerial"
            size2 = New Size(110, &H17)
            Me.chkGrpBySerial.Size = size2
            Me.chkGrpBySerial.Style = eDotNetBarStyle.StyleManagerControlled
            Me.chkGrpBySerial.TabIndex = &H19
            Me.chkGrpBySerial.Text = "Group By Printer"
            Me.chkDisplayDataLabels.BackColor = Color.Transparent
            Me.chkDisplayDataLabels.BackgroundStyle.CornerType = eCornerType.Square
            Me.chkDisplayDataLabels.Checked = True
            Me.chkDisplayDataLabels.CheckState = CheckState.Checked
            Me.chkDisplayDataLabels.CheckValue = "Y"
            point2 = New Point(3, &H1D)
            Me.chkDisplayDataLabels.Location = point2
            Me.chkDisplayDataLabels.Name = "chkDisplayDataLabels"
            size2 = New Size(&H84, &H17)
            Me.chkDisplayDataLabels.Size = size2
            Me.chkDisplayDataLabels.Style = eDotNetBarStyle.StyleManagerControlled
            Me.chkDisplayDataLabels.TabIndex = &H1A
            Me.chkDisplayDataLabels.Text = "Display Data Labels"
            Me.expOptions.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.expOptions.Controls.Add(Me.chkDisplayDataLabels)
            Me.expOptions.Controls.Add(Me.chkGrpBySerial)
            Me.expOptions.ExpandButtonAlignment = eTitleButtonAlignment.Left
            Me.expOptions.ExpandOnTitleClick = True
            point2 = New Point(&H32B, 3)
            Me.expOptions.Location = point2
            Me.expOptions.Name = "expOptions"
            size2 = New Size(&H7F, 90)
            Me.expOptions.Size = size2
            Me.expOptions.Style.Alignment = StringAlignment.Center
            Me.expOptions.Style.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground
            Me.expOptions.Style.Border = eBorderType.SingleLine
            Me.expOptions.Style.BorderColor.Color = Color.FromArgb(&HFF, &H80, 0)
            Me.expOptions.Style.ForeColor.ColorSchemePart = eColorSchemePart.ItemText
            Me.expOptions.Style.GradientAngle = 90
            Me.expOptions.StyleMouseDown.Alignment = StringAlignment.Center
            Me.expOptions.StyleMouseDown.BorderColor.ColorSchemePart = eColorSchemePart.ItemPressedBorder
            Me.expOptions.StyleMouseDown.ForeColor.ColorSchemePart = eColorSchemePart.ItemPressedText
            Me.expOptions.StyleMouseOver.Alignment = StringAlignment.Center
            Me.expOptions.StyleMouseOver.BorderColor.ColorSchemePart = eColorSchemePart.ItemHotBorder
            Me.expOptions.StyleMouseOver.ForeColor.ColorSchemePart = eColorSchemePart.ItemHotText
            Me.expOptions.TabIndex = &H1C
            Me.expOptions.TitleStyle.BackColor1.ColorSchemePart = eColorSchemePart.BarBackground
            Me.expOptions.TitleStyle.Border = eBorderType.RaisedInner
            Me.expOptions.TitleStyle.ForeColor.ColorSchemePart = eColorSchemePart.PanelText
            Me.expOptions.TitleStyle.GradientAngle = 90
            Me.expOptions.TitleStyleMouseDown.Border = eBorderType.SingleLine
            Me.expOptions.TitleStyleMouseDown.BorderColor.Color = Color.FromArgb(&HFF, &H80, 0)
            Me.expOptions.TitleStyleMouseOver.BackColor1.Color = Color.FromArgb(&HFF, &H80, 0)
            Me.expOptions.TitleText = "Options"
            Me.StyleManager1.ManagerStyle = eStyle.Metro
            Dim parameters2 As New MetroColorGeneratorParameters(Color.FromArgb(&HFF, &HFF, &HFF), Color.FromArgb(&HED, &H8E, 0))
            Me.StyleManager1.MetroColorParameters = parameters2
            Me.cboOper1.DisplayMember = "Text"
            Me.cboOper1.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboOper1.FormattingEnabled = True
            Me.cboOper1.ItemHeight = 14
            Dim items As Object() = New Object() { Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6 }
            Me.cboOper1.Items.AddRange(items)
            point2 = New Point(&H91, 3)
            Me.cboOper1.Location = point2
            Me.cboOper1.Name = "cboOper1"
            size2 = New Size(&H27, 20)
            Me.cboOper1.Size = size2
            Me.cboOper1.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboOper1.TabIndex = &H1C
            Me.cboOper1.Text = "="
            Me.ComboItem1.Text = "="
            Me.ComboItem2.Text = "<"
            Me.ComboItem3.Text = "<="
            Me.ComboItem4.Text = ">"
            Me.ComboItem5.Text = ">="
            Me.ComboItem6.Text = "<>"
            Me.cboOper2.DisplayMember = "Text"
            Me.cboOper2.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboOper2.FormattingEnabled = True
            Me.cboOper2.ItemHeight = 14
            items = New Object() { Me.ComboItem7, Me.ComboItem8, Me.ComboItem9, Me.ComboItem10, Me.ComboItem11, Me.ComboItem12 }
            Me.cboOper2.Items.AddRange(items)
            point2 = New Point(&H91, 30)
            Me.cboOper2.Location = point2
            Me.cboOper2.Name = "cboOper2"
            size2 = New Size(&H27, 20)
            Me.cboOper2.Size = size2
            Me.cboOper2.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboOper2.TabIndex = &H1D
            Me.cboOper2.Text = "="
            Me.ComboItem7.Text = "="
            Me.ComboItem8.Text = "<"
            Me.ComboItem9.Text = "<="
            Me.ComboItem10.Text = ">"
            Me.ComboItem11.Text = ">="
            Me.ComboItem12.Text = "<>"
            Me.cboOper3.DisplayMember = "Text"
            Me.cboOper3.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboOper3.FormattingEnabled = True
            Me.cboOper3.ItemHeight = 14
            items = New Object() { Me.ComboItem13, Me.ComboItem14, Me.ComboItem15, Me.ComboItem16, Me.ComboItem17, Me.ComboItem18 }
            Me.cboOper3.Items.AddRange(items)
            point2 = New Point(&H91, &H38)
            Me.cboOper3.Location = point2
            Me.cboOper3.Name = "cboOper3"
            size2 = New Size(&H27, 20)
            Me.cboOper3.Size = size2
            Me.cboOper3.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboOper3.TabIndex = 30
            Me.cboOper3.Text = "="
            Me.ComboItem13.Text = "="
            Me.ComboItem14.Text = "<"
            Me.ComboItem15.Text = "<="
            Me.ComboItem16.Text = ">"
            Me.ComboItem17.Text = ">="
            Me.ComboItem18.Text = "<>"
            Me.cboOper4.DisplayMember = "Text"
            Me.cboOper4.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboOper4.FormattingEnabled = True
            Me.cboOper4.ItemHeight = 14
            items = New Object() { Me.ComboItem19, Me.ComboItem20, Me.ComboItem21, Me.ComboItem22, Me.ComboItem23, Me.ComboItem24 }
            Me.cboOper4.Items.AddRange(items)
            point2 = New Point(&H91, &H52)
            Me.cboOper4.Location = point2
            Me.cboOper4.Name = "cboOper4"
            size2 = New Size(&H27, 20)
            Me.cboOper4.Size = size2
            Me.cboOper4.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboOper4.TabIndex = &H1F
            Me.cboOper4.Text = "="
            Me.ComboItem19.Text = "="
            Me.ComboItem20.Text = "<"
            Me.ComboItem21.Text = "<="
            Me.ComboItem22.Text = ">"
            Me.ComboItem23.Text = ">="
            Me.ComboItem24.Text = "<>"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.expOptions)
            Me.Controls.Add(Me.lblUnitesPerGroup)
            Me.Controls.Add(Me.intUnitsPerGroup)
            Me.Controls.Add(Me.txtFilters)
            Me.Controls.Add(Me.ItemPanel1)
            Me.Controls.Add(Me.lblHistory_TotalUnits)
            Me.Controls.Add(Me.cboRunCharts)
            Me.Controls.Add(Me.Chart1)
            Me.Name = "ctrlRunCharts"
            size2 = New Size(&H3AA, &H164)
            Me.Size = size2
            Me.Chart1.EndInit
            Me.ItemPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.intUnitsPerGroup.EndInit
            Me.expOptions.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub intUnitsPerGroup_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.AddHistoryData
        End Sub

        Private Sub txtFilters_ButtonClearClick(ByVal sender As Object, ByVal e As CancelEventArgs)
            Me.txtFilters.Text = Nothing
            Me.txtFilters.CloseDropDown
            Me.ClearFilters
            Me.AddHistoryData
        End Sub

        Private Sub txtFilters_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.AddHistoryData
        End Sub


        ' Properties
        Friend Overridable Property ToolTip1 As ToolTip
            <DebuggerNonUserCode> _
            Get
                Return Me._ToolTip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ToolTip)
                Me._ToolTip1 = WithEventsValue
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

        Private Overridable Property Chart1 As Chart
            <DebuggerNonUserCode> _
            Get
                Return Me._Chart1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Chart)
                Me._Chart1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFilter1_val As TextBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._txtFilter1_val
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxX)
                Me._txtFilter1_val = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboFilter1 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboFilter1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboFilter1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ItemPanel1 As ItemPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._ItemPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ItemPanel)
                Me._ItemPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._TableLayoutPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TableLayoutPanel)
                Me._TableLayoutPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFilters As TextBoxDropDown
            <DebuggerNonUserCode> _
            Get
                Return Me._txtFilters
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxDropDown)
                Dim handler As CancelEventHandler = New CancelEventHandler(AddressOf Me.txtFilters_ButtonClearClick)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.txtFilters_TextChanged)
                If Not Object.ReferenceEquals(Me._txtFilters, Nothing) Then
                    RemoveHandler Me._txtFilters.ButtonClearClick, handler
                    RemoveHandler Me._txtFilters.TextChanged, handler2
                End If
                Me._txtFilters = WithEventsValue
                If Not Object.ReferenceEquals(Me._txtFilters, Nothing) Then
                    AddHandler Me._txtFilters.ButtonClearClick, handler
                    AddHandler Me._txtFilters.TextChanged, handler2
                End If
            End Set
        End Property

        Friend Overridable Property cboFilter4 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboFilter4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboFilter4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboFilter2 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboFilter2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboFilter2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboFilter3 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboFilter3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboFilter3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFilter2_val As TextBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._txtFilter2_val
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxX)
                Me._txtFilter2_val = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFilter3_val As TextBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._txtFilter3_val
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxX)
                Me._txtFilter3_val = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFilter4_val As TextBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._txtFilter4_val
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxX)
                Me._txtFilter4_val = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cmdFilter_Apply As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdFilter_Apply
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdFilter_Apply_Click)
                If Not Object.ReferenceEquals(Me._cmdFilter_Apply, Nothing) Then
                    RemoveHandler Me._cmdFilter_Apply.Click, handler
                End If
                Me._cmdFilter_Apply = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdFilter_Apply, Nothing) Then
                    AddHandler Me._cmdFilter_Apply.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdFilter_Cancel As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdFilter_Cancel
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdFilter_Cancel_Click)
                If Not Object.ReferenceEquals(Me._cmdFilter_Cancel, Nothing) Then
                    RemoveHandler Me._cmdFilter_Cancel.Click, handler
                End If
                Me._cmdFilter_Cancel = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdFilter_Cancel, Nothing) Then
                    AddHandler Me._cmdFilter_Cancel.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property intUnitsPerGroup As IntegerInput
            <DebuggerNonUserCode> _
            Get
                Return Me._intUnitsPerGroup
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As IntegerInput)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.intUnitsPerGroup_ValueChanged)
                If Not Object.ReferenceEquals(Me._intUnitsPerGroup, Nothing) Then
                    RemoveHandler Me._intUnitsPerGroup.ValueChanged, handler
                End If
                Me._intUnitsPerGroup = WithEventsValue
                If Not Object.ReferenceEquals(Me._intUnitsPerGroup, Nothing) Then
                    AddHandler Me._intUnitsPerGroup.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property lblUnitesPerGroup As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblUnitesPerGroup
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblUnitesPerGroup = WithEventsValue
            End Set
        End Property

        Friend Overridable Property chkGrpBySerial As CheckBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._chkGrpBySerial
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As CheckBoxX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.chkGrpBySerial_CheckedChanged)
                If Not Object.ReferenceEquals(Me._chkGrpBySerial, Nothing) Then
                    RemoveHandler Me._chkGrpBySerial.CheckedChanged, handler
                End If
                Me._chkGrpBySerial = WithEventsValue
                If Not Object.ReferenceEquals(Me._chkGrpBySerial, Nothing) Then
                    AddHandler Me._chkGrpBySerial.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property chkDisplayDataLabels As CheckBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._chkDisplayDataLabels
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As CheckBoxX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.chkDisplayDataLabels_CheckedChanged)
                If Not Object.ReferenceEquals(Me._chkDisplayDataLabels, Nothing) Then
                    RemoveHandler Me._chkDisplayDataLabels.CheckedChanged, handler
                End If
                Me._chkDisplayDataLabels = WithEventsValue
                If Not Object.ReferenceEquals(Me._chkDisplayDataLabels, Nothing) Then
                    AddHandler Me._chkDisplayDataLabels.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property expOptions As ExpandablePanel
            <DebuggerNonUserCode> _
            Get
                Return Me._expOptions
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ExpandablePanel)
                Me._expOptions = WithEventsValue
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

        Friend Overridable Property cboOper1 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboOper1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboOper1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem1 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem2 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem3 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem4 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem5 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem6 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboOper4 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboOper4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboOper4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem19 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem19
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem19 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem20 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem20
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem20 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem21 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem21
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem21 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem22 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem22
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem22 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem23 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem23
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem23 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem24 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem24
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem24 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboOper3 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboOper3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboOper3 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem13 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem13
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem13 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem14 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem14
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem14 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem15 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem15
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem15 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem16 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem16
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem16 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem17 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem17
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem17 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem18 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem18
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem18 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property cboOper2 As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboOper2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboOper2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem7 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem8 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem8 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem9 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem9 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem10 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem10 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem11 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem11
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem11 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ComboItem12 As ComboItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ComboItem12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboItem)
                Me._ComboItem12 = WithEventsValue
            End Set
        End Property

        Private Property _CurrentMetric As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__CurrentMetric
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__CurrentMetric = AutoPropertyValue
            End Set
        End Property

        Private Property _dtHistory As DataTable
            <DebuggerNonUserCode> _
            Get
                Return Me.__dtHistory
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As DataTable)
                Me.__dtHistory = AutoPropertyValue
            End Set
        End Property

        Private Property _dvHistory As DataView
            <DebuggerNonUserCode> _
            Get
                Return Me.__dvHistory
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As DataView)
                Me.__dvHistory = AutoPropertyValue
            End Set
        End Property

        Friend ReadOnly Property CurrentMetric As String
            Get
                Return Me._CurrentMetric
            End Get
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("ToolTip1")> _
        Private _ToolTip1 As ToolTip
        <AccessedThroughProperty("cboRunCharts")> _
        Private _cboRunCharts As ComboBoxEx
        <AccessedThroughProperty("lblHistory_TotalUnits")> _
        Private _lblHistory_TotalUnits As LabelX
        <AccessedThroughProperty("Chart1")> _
        Private _Chart1 As Chart
        <AccessedThroughProperty("txtFilter1_val")> _
        Private _txtFilter1_val As TextBoxX
        <AccessedThroughProperty("cboFilter1")> _
        Private _cboFilter1 As ComboBoxEx
        <AccessedThroughProperty("ItemPanel1")> _
        Private _ItemPanel1 As ItemPanel
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <AccessedThroughProperty("txtFilters")> _
        Private _txtFilters As TextBoxDropDown
        <AccessedThroughProperty("cboFilter4")> _
        Private _cboFilter4 As ComboBoxEx
        <AccessedThroughProperty("cboFilter2")> _
        Private _cboFilter2 As ComboBoxEx
        <AccessedThroughProperty("cboFilter3")> _
        Private _cboFilter3 As ComboBoxEx
        <AccessedThroughProperty("txtFilter2_val")> _
        Private _txtFilter2_val As TextBoxX
        <AccessedThroughProperty("txtFilter3_val")> _
        Private _txtFilter3_val As TextBoxX
        <AccessedThroughProperty("txtFilter4_val")> _
        Private _txtFilter4_val As TextBoxX
        <AccessedThroughProperty("cmdFilter_Apply")> _
        Private _cmdFilter_Apply As ButtonX
        <AccessedThroughProperty("cmdFilter_Cancel")> _
        Private _cmdFilter_Cancel As ButtonX
        <AccessedThroughProperty("intUnitsPerGroup")> _
        Private _intUnitsPerGroup As IntegerInput
        <AccessedThroughProperty("lblUnitesPerGroup")> _
        Private _lblUnitesPerGroup As LabelX
        <AccessedThroughProperty("chkGrpBySerial")> _
        Private _chkGrpBySerial As CheckBoxX
        <AccessedThroughProperty("chkDisplayDataLabels")> _
        Private _chkDisplayDataLabels As CheckBoxX
        <AccessedThroughProperty("expOptions")> _
        Private _expOptions As ExpandablePanel
        <AccessedThroughProperty("StyleManager1")> _
        Private _StyleManager1 As StyleManager
        <AccessedThroughProperty("cboOper1")> _
        Private _cboOper1 As ComboBoxEx
        <AccessedThroughProperty("ComboItem1")> _
        Private _ComboItem1 As ComboItem
        <AccessedThroughProperty("ComboItem2")> _
        Private _ComboItem2 As ComboItem
        <AccessedThroughProperty("ComboItem3")> _
        Private _ComboItem3 As ComboItem
        <AccessedThroughProperty("ComboItem4")> _
        Private _ComboItem4 As ComboItem
        <AccessedThroughProperty("ComboItem5")> _
        Private _ComboItem5 As ComboItem
        <AccessedThroughProperty("ComboItem6")> _
        Private _ComboItem6 As ComboItem
        <AccessedThroughProperty("cboOper4")> _
        Private _cboOper4 As ComboBoxEx
        <AccessedThroughProperty("ComboItem19")> _
        Private _ComboItem19 As ComboItem
        <AccessedThroughProperty("ComboItem20")> _
        Private _ComboItem20 As ComboItem
        <AccessedThroughProperty("ComboItem21")> _
        Private _ComboItem21 As ComboItem
        <AccessedThroughProperty("ComboItem22")> _
        Private _ComboItem22 As ComboItem
        <AccessedThroughProperty("ComboItem23")> _
        Private _ComboItem23 As ComboItem
        <AccessedThroughProperty("ComboItem24")> _
        Private _ComboItem24 As ComboItem
        <AccessedThroughProperty("cboOper3")> _
        Private _cboOper3 As ComboBoxEx
        <AccessedThroughProperty("ComboItem13")> _
        Private _ComboItem13 As ComboItem
        <AccessedThroughProperty("ComboItem14")> _
        Private _ComboItem14 As ComboItem
        <AccessedThroughProperty("ComboItem15")> _
        Private _ComboItem15 As ComboItem
        <AccessedThroughProperty("ComboItem16")> _
        Private _ComboItem16 As ComboItem
        <AccessedThroughProperty("ComboItem17")> _
        Private _ComboItem17 As ComboItem
        <AccessedThroughProperty("ComboItem18")> _
        Private _ComboItem18 As ComboItem
        <AccessedThroughProperty("cboOper2")> _
        Private _cboOper2 As ComboBoxEx
        <AccessedThroughProperty("ComboItem7")> _
        Private _ComboItem7 As ComboItem
        <AccessedThroughProperty("ComboItem8")> _
        Private _ComboItem8 As ComboItem
        <AccessedThroughProperty("ComboItem9")> _
        Private _ComboItem9 As ComboItem
        <AccessedThroughProperty("ComboItem10")> _
        Private _ComboItem10 As ComboItem
        <AccessedThroughProperty("ComboItem11")> _
        Private _ComboItem11 As ComboItem
        <AccessedThroughProperty("ComboItem12")> _
        Private _ComboItem12 As ComboItem
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __CurrentMetric As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __dtHistory As DataTable
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __dvHistory As DataView
        Private InitializeComplete As Boolean

        ' Nested Types
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

            Public Property Name As String
                <DebuggerNonUserCode> _
                Get
                    Return Me._Name
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me._Name = AutoPropertyValue
                End Set
            End Property

            Public Property RunChartYVal As Double
                <DebuggerNonUserCode> _
                Get
                    Return Me._RunChartYVal
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Double)
                    Me._RunChartYVal = AutoPropertyValue
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _Indexer As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private _Name As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _RunChartYVal As Double
        End Class
    End Class
End Namespace

