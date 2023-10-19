Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class ctrlComposite
        Inherits UserControl
        ' Methods
        Public Sub New(ByVal History As DataTable, ByVal EnableRunCharts As Boolean, ByVal EnableDataGrid As Boolean, ByVal EnableRegularChart As Boolean)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.ctrlComposit_Load)
            ctrlComposite.__ENCAddToList(Me)
            Me.dtHistory = New DataTable
            Me.InitializeComponent
            Me._EnableRunCharts = EnableRunCharts
            Me._EnableDataGrid = EnableDataGrid
            Me._EnableRegularChart = EnableRegularChart
            Me.dtHistory = History
            Me.cmdShowRuncharts.Visible = EnableRunCharts
            Me.cmdShowDataGrid.Visible = EnableDataGrid
            Me.cmdShowRegularcharts.Visible = EnableRegularChart
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlComposite.__ENCList
                If (ctrlComposite.__ENCList.Count = ctrlComposite.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlComposite.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlComposite.__ENCList.RemoveRange(index, (ctrlComposite.__ENCList.Count - index))
                            ctrlComposite.__ENCList.Capacity = ctrlComposite.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlComposite.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlComposite.__ENCList(index) = ctrlComposite.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlComposite.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub cmdShowDataGrid_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetVisibility(ControlNames.DataGrid)
        End Sub

        Private Sub cmdShowRegularcharts_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetVisibility(ControlNames.RegularChart)
        End Sub

        Private Sub cmdShowRuncharts_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetVisibility(ControlNames.RunCharts)
        End Sub

        Private Sub ctrlComposit_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.RunCharts = New ctrlRunCharts(Me.dtHistory)
            Me.DataGrid = New ctrlDataGrid(Me.dtHistory)
            Me.RegularCharts = New ctrlRegularCharts(Me.dtHistory)
            Me.SetVisibility(ControlNames.RunCharts)
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
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.cmdDataSelect = New ButtonX
            Me.cmdShowRuncharts = New ButtonItem
            Me.cmdShowRegularcharts = New ButtonItem
            Me.cmdShowDataGrid = New ButtonItem
            Me.TableLayoutPanel1.SuspendLayout
            Me.SuspendLayout
            Me.TableLayoutPanel1.BackColor = Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100!))
            Me.TableLayoutPanel1.Controls.Add(Me.cmdDataSelect, 0, 0)
            Me.TableLayoutPanel1.Dock = DockStyle.Fill
            Me.TableLayoutPanel1.ForeColor = Color.Black
            Dim point2 As New Point(0, 0)
            Me.TableLayoutPanel1.Location = point2
            Dim padding2 As New Padding(0)
            Me.TableLayoutPanel1.Margin = padding2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 2
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle)
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100!))
            Dim size2 As New Size(&H24A, &H177)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = &H11
            Me.cmdDataSelect.AccessibleRole = AccessibleRole.PushButton
            Me.cmdDataSelect.AutoExpandOnClick = True
            Me.cmdDataSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink
            Me.cmdDataSelect.ColorTable = eButtonColor.OrangeWithBackground
            Me.cmdDataSelect.Cursor = Cursors.Hand
            point2 = New Point(3, 3)
            Me.cmdDataSelect.Location = point2
            Me.cmdDataSelect.Name = "cmdDataSelect"
            Me.cmdDataSelect.PopupSide = ePopupSide.Right
            Me.cmdDataSelect.Shape = New RoundRectangleShapeDescriptor(6)
            size2 = New Size(&HC9, &H18)
            Me.cmdDataSelect.Size = size2
            Me.cmdDataSelect.Style = eDotNetBarStyle.StyleManagerControlled
            Dim items As BaseItem() = New BaseItem() { Me.cmdShowRuncharts, Me.cmdShowRegularcharts, Me.cmdShowDataGrid }
            Me.cmdDataSelect.SubItems.AddRange(items)
            Me.cmdDataSelect.SubItemsExpandWidth = 20
            Me.cmdDataSelect.TabIndex = 14
            Me.cmdDataSelect.Text = "<b>Now Showing Run Charts</b>"
            Me.cmdShowRuncharts.Cursor = Cursors.Hand
            Me.cmdShowRuncharts.GlobalItem = False
            Me.cmdShowRuncharts.Name = "cmdShowRuncharts"
            Me.cmdShowRuncharts.OptionGroup = "1"
            Me.cmdShowRuncharts.PopupWidth = &HFA0
            Me.cmdShowRuncharts.ShowSubItems = False
            Me.cmdShowRuncharts.Stretch = True
            Me.cmdShowRuncharts.Text = "Run Charts"
            Me.cmdShowRegularcharts.Cursor = Cursors.Hand
            Me.cmdShowRegularcharts.GlobalItem = False
            Me.cmdShowRegularcharts.Name = "cmdShowRegularcharts"
            Me.cmdShowRegularcharts.OptionGroup = "1"
            Me.cmdShowRegularcharts.Text = "Regular Charts"
            Me.cmdShowDataGrid.Cursor = Cursors.Hand
            Me.cmdShowDataGrid.GlobalItem = False
            Me.cmdShowDataGrid.Name = "cmdShowDataGrid"
            Me.cmdShowDataGrid.OptionGroup = "1"
            Me.cmdShowDataGrid.Text = "Data Grid"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "ctrlComposite"
            size2 = New Size(&H24A, &H177)
            Me.Size = size2
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub SetVisibility(ByVal ControlName As ControlNames)
            Me.TableLayoutPanel1.Controls.Remove(Me.DataGrid)
            Me.TableLayoutPanel1.Controls.Remove(Me.RunCharts)
            Me.TableLayoutPanel1.Controls.Remove(Me.RegularCharts)
            Dim str As String = Nothing
            Dim instance As Object = Nothing
            Select Case ControlName
                Case ControlNames.RunCharts
                    str = "Now Showing Run Charts"
                    instance = Me.RunCharts
                    Exit Select
                Case ControlNames.DataGrid
                    str = "Now Showing Data Grid"
                    instance = Me.DataGrid
                    Exit Select
                Case ControlNames.RegularChart
                    str = "Now Showing Regular Charts"
                    instance = Me.RegularCharts
                    Exit Select
                Case Else
                    Exit Select
            End Select
            Me.TableLayoutPanel1.Controls.Add(DirectCast(instance, Control), 0, 1)
            Me.TableLayoutPanel1.SetColumnSpan(DirectCast(instance, Control), 2)
            Dim arguments As Object() = New Object() { DockStyle.Fill }
            NewLateBinding.LateSet(instance, Nothing, "Dock", arguments, Nothing, Nothing)
            Me.cmdDataSelect.Text = str
        End Sub


        ' Properties
        Friend Overridable Property cmdShowRuncharts As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdShowRuncharts
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdShowRuncharts_Click)
                If Not Object.ReferenceEquals(Me._cmdShowRuncharts, Nothing) Then
                    RemoveHandler Me._cmdShowRuncharts.Click, handler
                End If
                Me._cmdShowRuncharts = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowRuncharts, Nothing) Then
                    AddHandler Me._cmdShowRuncharts.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cmdShowRegularcharts As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdShowRegularcharts
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdShowRegularcharts_Click)
                If Not Object.ReferenceEquals(Me._cmdShowRegularcharts, Nothing) Then
                    RemoveHandler Me._cmdShowRegularcharts.Click, handler
                End If
                Me._cmdShowRegularcharts = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowRegularcharts, Nothing) Then
                    AddHandler Me._cmdShowRegularcharts.Click, handler
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
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdShowDataGrid_Click)
                If Not Object.ReferenceEquals(Me._cmdShowDataGrid, Nothing) Then
                    RemoveHandler Me._cmdShowDataGrid.Click, handler
                End If
                Me._cmdShowDataGrid = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdShowDataGrid, Nothing) Then
                    AddHandler Me._cmdShowDataGrid.Click, handler
                End If
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

        Private Property _EnableRunCharts As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__EnableRunCharts
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__EnableRunCharts = AutoPropertyValue
            End Set
        End Property

        Private Property _EnableDataGrid As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__EnableDataGrid
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__EnableDataGrid = AutoPropertyValue
            End Set
        End Property

        Private Property _EnableRegularChart As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me.__EnableRegularChart
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me.__EnableRegularChart = AutoPropertyValue
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("cmdShowRuncharts")> _
        Private _cmdShowRuncharts As ButtonItem
        <AccessedThroughProperty("cmdShowRegularcharts")> _
        Private _cmdShowRegularcharts As ButtonItem
        <AccessedThroughProperty("cmdShowDataGrid")> _
        Private _cmdShowDataGrid As ButtonItem
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <AccessedThroughProperty("cmdDataSelect")> _
        Private _cmdDataSelect As ButtonX
        Private dtHistory As DataTable
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __EnableRunCharts As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __EnableDataGrid As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __EnableRegularChart As Boolean
        Public RunCharts As ctrlRunCharts
        Public DataGrid As ctrlDataGrid
        Public RegularCharts As ctrlRegularCharts

        ' Nested Types
        Friend Class ChartData
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
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _Indexer As Long
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _XVal As Double
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _YVal As Double
        End Class

        Private Enum ControlNames
            ' Fields
            RunCharts = 0
            DataGrid = 1
            RegularChart = 2
        End Enum
    End Class
End Namespace

