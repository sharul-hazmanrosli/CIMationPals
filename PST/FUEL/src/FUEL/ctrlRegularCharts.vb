Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
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
    Public Class ctrlRegularCharts
        Inherits UserControl
        ' Methods
        Public Sub New(ByVal dtHistory As DataTable)
            ctrlRegularCharts.__ENCAddToList(Me)
            Me.InitializeComponent
            Me._dtHistory = dtHistory
            Me.GetHeaders
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlRegularCharts.__ENCList
                If (ctrlRegularCharts.__ENCList.Count = ctrlRegularCharts.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlRegularCharts.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlRegularCharts.__ENCList.RemoveRange(index, (ctrlRegularCharts.__ENCList.Count - index))
                            ctrlRegularCharts.__ENCList.Capacity = ctrlRegularCharts.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlRegularCharts.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlRegularCharts.__ENCList(index) = ctrlRegularCharts.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlRegularCharts.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub AddHistoryData(ByVal xVal As String, ByVal yVal As String, ByVal groupVal As String)
            Try 
                Dim enumerator As IEnumerator(Of Series)
                Me.Chart1.Series.Clear
                Me.Chart1.DataBindCrossTable(Me._dtHistory.AsEnumerable(), groupVal, xVal, yVal, Nothing)
                Try 
                    enumerator = Me.Chart1.Series.GetEnumerator
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

        Private Sub cmdHistory_ChartIt_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.AddHistoryData(Me.cboHistory_XVal.Text, Me.cboHistory_YVal.Text, Me.cboHistory_Series.Text)
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

        Private Sub GetHeaders()
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me._dtHistory.Columns.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As DataColumn = DirectCast(enumerator.Current, DataColumn)
                    Me.cboHistory_XVal.Items.Add(current.ColumnName)
                    Me.cboHistory_YVal.Items.Add(current.ColumnName)
                    Me.cboHistory_Series.Items.Add(current.ColumnName)
                Loop
            Finally
                If Not Object.ReferenceEquals(TryCast(enumerator,IDisposable), Nothing) Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim item As New ChartArea
            Dim legend As New Legend
            Dim series As New Series
            Me.Chart1 = New Chart
            Me.cboHistory_XVal = New ComboBoxEx
            Me.LabelX1 = New LabelX
            Me.LabelX2 = New LabelX
            Me.cboHistory_YVal = New ComboBoxEx
            Me.LabelX3 = New LabelX
            Me.cboHistory_Series = New ComboBoxEx
            Me.cmdHistory_ChartIt = New ButtonX
            Me.Chart1.BeginInit
            Me.SuspendLayout
            Me.Chart1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.Chart1.BorderlineColor = Color.Maroon
            Me.Chart1.BorderlineDashStyle = ChartDashStyle.Solid
            Me.Chart1.BorderlineWidth = 2
            item.Name = "ChartArea1"
            Me.Chart1.ChartAreas.Add(item)
            legend.Name = "Legend1"
            Me.Chart1.Legends.Add(legend)
            Dim point2 As New Point(3, &H31)
            Me.Chart1.Location = point2
            Me.Chart1.Name = "Chart1"
            series.ChartArea = "ChartArea1"
            series.Legend = "Legend1"
            series.Name = "Series1"
            Me.Chart1.Series.Add(series)
            Dim size2 As New Size(&H1DA, &H133)
            Me.Chart1.Size = size2
            Me.Chart1.TabIndex = &H19
            Me.Chart1.Text = "Chart1"
            Me.cboHistory_XVal.DisplayMember = "Text"
            Me.cboHistory_XVal.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_XVal.FormattingEnabled = True
            Me.cboHistory_XVal.ItemHeight = 14
            point2 = New Point(3, &H17)
            Me.cboHistory_XVal.Location = point2
            Me.cboHistory_XVal.Name = "cboHistory_XVal"
            size2 = New Size(&H79, 20)
            Me.cboHistory_XVal.Size = size2
            Me.cboHistory_XVal.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_XVal.TabIndex = &H1A
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(4, 7)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&H4B, 13)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = &H1B
            Me.LabelX1.Text = "X Value"
            Me.LabelX2.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(&H83, 7)
            Me.LabelX2.Location = point2
            Me.LabelX2.Name = "LabelX2"
            size2 = New Size(&H4B, 13)
            Me.LabelX2.Size = size2
            Me.LabelX2.TabIndex = &H1D
            Me.LabelX2.Text = "Y Value"
            Me.cboHistory_YVal.DisplayMember = "Text"
            Me.cboHistory_YVal.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_YVal.FormattingEnabled = True
            Me.cboHistory_YVal.ItemHeight = 14
            point2 = New Point(130, &H17)
            Me.cboHistory_YVal.Location = point2
            Me.cboHistory_YVal.Name = "cboHistory_YVal"
            size2 = New Size(&H79, 20)
            Me.cboHistory_YVal.Size = size2
            Me.cboHistory_YVal.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_YVal.TabIndex = &H1C
            Me.LabelX3.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(&H102, 7)
            Me.LabelX3.Location = point2
            Me.LabelX3.Name = "LabelX3"
            size2 = New Size(&H4B, 13)
            Me.LabelX3.Size = size2
            Me.LabelX3.TabIndex = &H1F
            Me.LabelX3.Text = "Series"
            Me.cboHistory_Series.DisplayMember = "Text"
            Me.cboHistory_Series.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboHistory_Series.FormattingEnabled = True
            Me.cboHistory_Series.ItemHeight = 14
            point2 = New Point(&H101, &H17)
            Me.cboHistory_Series.Location = point2
            Me.cboHistory_Series.Name = "cboHistory_Series"
            size2 = New Size(&H79, 20)
            Me.cboHistory_Series.Size = size2
            Me.cboHistory_Series.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboHistory_Series.TabIndex = 30
            Me.cmdHistory_ChartIt.AccessibleRole = AccessibleRole.PushButton
            Me.cmdHistory_ChartIt.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(&H181, &H12)
            Me.cmdHistory_ChartIt.Location = point2
            Me.cmdHistory_ChartIt.Name = "cmdHistory_ChartIt"
            size2 = New Size(&H4B, &H17)
            Me.cmdHistory_ChartIt.Size = size2
            Me.cmdHistory_ChartIt.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdHistory_ChartIt.TabIndex = &H20
            Me.cmdHistory_ChartIt.Text = "Chart It"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.cmdHistory_ChartIt)
            Me.Controls.Add(Me.LabelX3)
            Me.Controls.Add(Me.cboHistory_Series)
            Me.Controls.Add(Me.LabelX2)
            Me.Controls.Add(Me.cboHistory_YVal)
            Me.Controls.Add(Me.LabelX1)
            Me.Controls.Add(Me.cboHistory_XVal)
            Me.Controls.Add(Me.Chart1)
            Me.Name = "ctrlRegularCharts"
            size2 = New Size(480, &H167)
            Me.Size = size2
            Me.Chart1.EndInit
            Me.ResumeLayout(False)
        End Sub


        ' Properties
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

        Friend Overridable Property LabelX2 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX2 = WithEventsValue
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

        Friend Overridable Property LabelX3 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX3 = WithEventsValue
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


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("Chart1")> _
        Private _Chart1 As Chart
        <AccessedThroughProperty("cboHistory_XVal")> _
        Private _cboHistory_XVal As ComboBoxEx
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
        <AccessedThroughProperty("LabelX2")> _
        Private _LabelX2 As LabelX
        <AccessedThroughProperty("cboHistory_YVal")> _
        Private _cboHistory_YVal As ComboBoxEx
        <AccessedThroughProperty("LabelX3")> _
        Private _LabelX3 As LabelX
        <AccessedThroughProperty("cboHistory_Series")> _
        Private _cboHistory_Series As ComboBoxEx
        <AccessedThroughProperty("cmdHistory_ChartIt")> _
        Private _cmdHistory_ChartIt As ButtonX
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __dtHistory As DataTable
    End Class
End Namespace

