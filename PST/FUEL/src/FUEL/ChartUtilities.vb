Imports System
Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting

Namespace FUEL
    Public Class ChartUtilities
        ' Methods
        Public Shared Sub AddAnnotations(ByVal msg As String, ByVal myChart As Chart, ByVal Index As Integer)
            Dim item As New CalloutAnnotation With { _
                .AnchorDataPoint = myChart.Series(0).Points(Index), _
                .Text = msg, _
                .BackColor = Color.LightGoldenrodYellow, _
                .ClipToChartArea = "Default", _
                .AllowMoving = True, _
                .AllowAnchorMoving = False, _
                .AllowSelecting = True _
            }
            item.SmartLabelStyle.Enabled = True
            item.Name = msg
            item.Visible = True
            item.CalloutStyle = CalloutStyle.RoundedRectangle
            myChart.Annotations.Add(item)
        End Sub

        Public Shared Sub AddChartTitle(ByVal TitleText As String, ByVal myChart As Chart, ByVal ChartArea As String, ByVal DockingLoc As Docking)
            Dim item As New Title With { _
                .Name = TitleText, _
                .Text = TitleText, _
                .Docking = DockingLoc, _
                .IsDockedInsideChartArea = False, _
                .Font = New Font("Ariel", 10!, FontStyle.Bold) _
            }
            myChart.Titles.Add(item)
            myChart.Titles(TitleText).DockedToChartArea = ChartArea
        End Sub

        Public Shared Sub AddSeriesDataLabels(ByVal Chart As Chart, ByVal Series As Series)
            Chart.Series(Series.Name).IsValueShownAsLabel = True
            Chart.Series(Series.Name).Font = New Font("ariel", 8!)
            Chart.Series(Series.Name).LabelAngle = &H2D
            Chart.Series(Series.Name).LabelForeColor = Color.Black
            Chart.Series(Series.Name).LabelFormat = ".##"
            Chart.Series(Series.Name).LabelBackColor = Color.LightGray
            Chart.Series(Series.Name).SmartLabelStyle.Enabled = True
            Chart.Series(Series.Name).SmartLabelStyle.IsMarkerOverlappingAllowed = False
            Chart.Series(Series.Name).SmartLabelStyle.IsOverlappedHidden = False
        End Sub

        Public Shared Sub ClearChart(ByVal Chart As Chart)
            Dim chart As Chart = Chart
            chart.Series.Clear
            chart.Titles.Clear
            Dim num2 As Integer = (Chart.ChartAreas.Count - 1)
            Dim num As Integer = 0
            Do While True
                Dim num3 As Integer = num2
                If (num > num3) Then
                    chart = Nothing
                    Return
                End If
                chart.ChartAreas(num).AxisX.Title = Nothing
                chart.ChartAreas(num).AxisY.Title = Nothing
                chart.ChartAreas(num).AxisY.StripLines.Clear
                chart.ChartAreas(num).AxisX.StripLines.Clear
                num += 1
            Loop
        End Sub

        Public Shared Function GetMinorGridInterval(ByVal Divisor As Double, ByVal MajorVal As Integer) As Double
            If (MajorVal <= Divisor) Then
                Divisor = (MajorVal - 1)
            End If
            Dim num3 As Integer = CInt(Math.Round(Divisor))
            Dim num2 As Integer = 0
            Do While True
                Dim num As Double
                Dim num4 As Integer = num3
                If (num2 > num4) Then
                    num = Math.Max(Divisor, 0)
                Else
                    If Not (((CDbl(MajorVal) Mod (Divisor - num2)) = 0) And (MajorVal <> (Divisor - num2))) Then
                        num2 += 1
                        Continue Do
                    End If
                    num = Math.Max(CDbl((Divisor - num2)), CDbl(0))
                End If
                Return num
            Loop
        End Function

        Public Shared Function GetStripLine(ByVal [Text] As String, ByVal TextOrientation As TextOrientation, ByVal TextAlignment As StringAlignment, ByVal TextLineAlignment As StringAlignment, ByVal FontColor As Color, ByVal IntervalOffset As Double, ByVal StripWidth As Double, ByVal BackColor As Color) As StripLine
            Dim color As Color
            Return DirectCast(ChartUtilities.GetStripLine([Text], TextOrientation, TextAlignment, TextLineAlignment, FontColor, IntervalOffset, color, 0, StripWidth, BackColor), StripLine)
        End Function

        Public Shared Function GetStripLine(ByVal [Text] As String, ByVal TextOrientation As TextOrientation, ByVal TextAlignment As StringAlignment, ByVal TextLineAlignment As StringAlignment, ByVal FontColor As Color, ByVal IntervalOffset As Double, ByVal LineColor As Color, ByVal LineWeight As Integer) As StripLine
            Dim color As Color
            Return DirectCast(ChartUtilities.GetStripLine([Text], TextOrientation, TextAlignment, TextLineAlignment, FontColor, IntervalOffset, LineColor, LineWeight, 0, color), StripLine)
        End Function

        Public Shared Function GetStripLine(ByVal [Text] As String, ByVal TextOrientation As TextOrientation, ByVal TextAlignment As StringAlignment, ByVal TextLineAlignment As StringAlignment, ByVal FontColor As Color, ByVal IntervalOffset As Double, ByVal LineColor As Color, ByVal LineWeight As Integer, ByVal StripWidth As Double, ByVal BackColor As Color) As Object
            Dim line As New StripLine
            Dim line2 As StripLine = line
            If ([Text] <> Nothing) Then
                line2.Text = [Text]
                line2.TextOrientation = TextOrientation
                line2.TextAlignment = TextAlignment
                line2.TextLineAlignment = TextLineAlignment
                line2.ForeColor = FontColor
                line2.Font = New Font("ariel", 8!)
            End If
            line.IntervalOffset = IntervalOffset
            line.StripWidth = StripWidth
            line.BackColor = BackColor
            line.BorderColor = LineColor
            line.BorderWidth = LineWeight
            line2 = Nothing
            Return line
        End Function

        Public Shared Sub LinkChartAreas(ByVal Area1 As ChartArea, ByVal Area2 As ChartArea)
            Area1.InnerPlotPosition.Auto = True
            Area2.InnerPlotPosition.Auto = True
            Area2.AlignmentOrientation = AreaAlignmentOrientations.Vertical
            Area2.AlignmentStyle = AreaAlignmentStyles.All
            Area2.AlignWithChartArea = Area1.Name
        End Sub

        Public Shared Sub RemoveSeriesDataLabels(ByVal Chart As Chart, ByVal Series As Series)
            Chart.Series(Series.Name).IsValueShownAsLabel = False
            Chart.Series(Series.Name).SmartLabelStyle.Enabled = False
        End Sub

        Public Shared Sub SetXAxisZoom(ByVal Area As ChartArea, ByVal Enabled As Boolean)
            ChartUtilities.SetZoom(Area, Enabled, True)
        End Sub

        Public Shared Sub SetYAxisZoom(ByVal Area As ChartArea, ByVal Enabled As Boolean)
            ChartUtilities.SetZoom(Area, Enabled, False)
        End Sub

        Private Shared Sub SetZoom(ByVal Area As ChartArea, ByVal Enabled As Boolean, ByVal XAxis As Boolean)
            If XAxis Then
                Area.CursorX.IsUserEnabled = Enabled
                Area.CursorX.IsUserSelectionEnabled = Enabled
                Area.AxisX.ScaleView.Zoomable = Enabled
                Area.AxisX.ScrollBar.IsPositionedInside = Enabled
            Else
                Area.CursorY.IsUserEnabled = Enabled
                Area.CursorY.IsUserSelectionEnabled = Enabled
                Area.AxisY.ScaleView.Zoomable = Enabled
                Area.AxisY.ScrollBar.IsPositionedInside = Enabled
            End If
        End Sub

    End Class
End Namespace

