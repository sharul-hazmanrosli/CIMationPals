Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Namespace FUEL
    <DesignerGenerated> _
    Public Class dlgSetUserLocation
        Inherits Form
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.dlgSetUserLocation_Load)
            dlgSetUserLocation.__ENCAddToList(Me)
            Me.InitializeComponent
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock dlgSetUserLocation.__ENCList
                If (dlgSetUserLocation.__ENCList.Count = dlgSetUserLocation.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (dlgSetUserLocation.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            dlgSetUserLocation.__ENCList.RemoveRange(index, (dlgSetUserLocation.__ENCList.Count - index))
                            dlgSetUserLocation.__ENCList.Capacity = dlgSetUserLocation.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = dlgSetUserLocation.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                dlgSetUserLocation.__ENCList(index) = dlgSetUserLocation.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                dlgSetUserLocation.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.Cancel
            Me.UserLoc = Conversions.ToString(Me._ctrlUserLoc.cboSiteList.SelectedIndex)
            Me.Close
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

        Private Sub dlgSetUserLocation_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me._ctrlUserLoc = New ctrlUserLocation
            Me.Controls.Add(Me._ctrlUserLoc)
            Me._ctrlUserLoc.Dock = DockStyle.Fill
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim item As New ChartArea
            Dim legend As New Legend
            Dim series As New Series
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.OK_Button = New Button
            Me.Cancel_Button = New Button
            Me.Chart1 = New Chart
            Me.TableLayoutPanel1.SuspendLayout
            Me.Chart1.BeginInit
            Me.SuspendLayout
            Me.TableLayoutPanel1.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
            Dim point2 As New Point(&H115, &H112)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50!))
            Dim size2 As New Size(&H92, &H1D)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 0
            Me.OK_Button.Anchor = AnchorStyles.None
            point2 = New Point(3, 3)
            Me.OK_Button.Location = point2
            Me.OK_Button.Name = "OK_Button"
            size2 = New Size(&H43, &H17)
            Me.OK_Button.Size = size2
            Me.OK_Button.TabIndex = 0
            Me.OK_Button.Text = "OK"
            Me.Cancel_Button.Anchor = AnchorStyles.None
            Me.Cancel_Button.DialogResult = DialogResult.Cancel
            point2 = New Point(&H4C, 3)
            Me.Cancel_Button.Location = point2
            Me.Cancel_Button.Name = "Cancel_Button"
            size2 = New Size(&H43, &H17)
            Me.Cancel_Button.Size = size2
            Me.Cancel_Button.TabIndex = 1
            Me.Cancel_Button.Text = "Cancel"
            item.Name = "ChartArea1"
            Me.Chart1.ChartAreas.Add(item)
            legend.Name = "Legend1"
            Me.Chart1.Legends.Add(legend)
            point2 = New Point(&H56, &H5C)
            Me.Chart1.Location = point2
            Me.Chart1.Name = "Chart1"
            series.ChartArea = "ChartArea1"
            series.Legend = "Legend1"
            series.Name = "Series1"
            Me.Chart1.Series.Add(series)
            size2 = New Size(300, 300)
            Me.Chart1.Size = size2
            Me.Chart1.TabIndex = 1
            Me.Chart1.Text = "Chart1"
            Me.AcceptButton = Me.OK_Button
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.CancelButton = Me.Cancel_Button
            size2 = New Size(&H1B3, &H13B)
            Me.ClientSize = size2
            Me.Controls.Add(Me.Chart1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgSetUserLocation"
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "dlgSetUserLocation"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.Chart1.EndInit
            Me.ResumeLayout(False)
        End Sub

        Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.UserLoc = Conversions.ToString(Me._ctrlUserLoc.cboSiteList.SelectedIndex)
            Me.Close
        End Sub


        ' Properties
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

        Friend Overridable Property OK_Button As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._OK_Button
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OK_Button_Click)
                If Not Object.ReferenceEquals(Me._OK_Button, Nothing) Then
                    RemoveHandler Me._OK_Button.Click, handler
                End If
                Me._OK_Button = WithEventsValue
                If Not Object.ReferenceEquals(Me._OK_Button, Nothing) Then
                    AddHandler Me._OK_Button.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Cancel_Button As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._Cancel_Button
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Cancel_Button_Click)
                If Not Object.ReferenceEquals(Me._Cancel_Button, Nothing) Then
                    RemoveHandler Me._Cancel_Button.Click, handler
                End If
                Me._Cancel_Button = WithEventsValue
                If Not Object.ReferenceEquals(Me._Cancel_Button, Nothing) Then
                    AddHandler Me._Cancel_Button.Click, handler
                End If
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

        Public Property UserLoc As String
            <DebuggerNonUserCode> _
            Get
                Return Me._UserLoc
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me._UserLoc = AutoPropertyValue
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <AccessedThroughProperty("OK_Button")> _
        Private _OK_Button As Button
        <AccessedThroughProperty("Cancel_Button")> _
        Private _Cancel_Button As Button
        <AccessedThroughProperty("Chart1")> _
        Private _Chart1 As Chart
        Private _ctrlUserLoc As ctrlUserLocation
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _UserLoc As String
    End Class
End Namespace

