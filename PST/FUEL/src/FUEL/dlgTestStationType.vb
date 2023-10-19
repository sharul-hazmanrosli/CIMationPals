Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class dlgTestStationType
        Inherits MetroForm
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.dlgTestStationType_Load)
            dlgTestStationType.__ENCAddToList(Me)
            Me.InitializeComponent
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock dlgTestStationType.__ENCList
                If (dlgTestStationType.__ENCList.Count = dlgTestStationType.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (dlgTestStationType.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            dlgTestStationType.__ENCList.RemoveRange(index, (dlgTestStationType.__ENCList.Count - index))
                            dlgTestStationType.__ENCList.Capacity = dlgTestStationType.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = dlgTestStationType.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                dlgTestStationType.__ENCList(index) = dlgTestStationType.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                dlgTestStationType.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.Cancel
            Me._TestStationType = Not TestStationTypes.ProductionLine
            Me.Close
        End Sub

        Private Sub cboTestStations_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            MySettingsProperty.Settings.TestStationType = Me.cboTestStations.SelectedIndex
            MySettingsProperty.Settings.TestStationType_Date = DateAndTime.Now
            MySettingsProperty.Settings.Save
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

        Private Sub dlgTestStationType_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Enum.GetValues(GetType(TestStationTypes)).GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As Object = enumerator.Current
                    Me.cboTestStations.Items.Add(current.ToString)
                Loop
            Finally
                If Not Object.ReferenceEquals(TryCast(enumerator,IDisposable), Nothing) Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
            If (DateAndTime.DateDiff(DateInterval.Hour, MySettingsProperty.Settings.TestStationType_Date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 6) Then
                MySettingsProperty.Settings.TestStationType = -1
                MySettingsProperty.Settings.Save
            Else
                Me._TestStationType = DirectCast(MySettingsProperty.Settings.TestStationType, TestStationTypes)
                Me.DialogResult = DialogResult.OK
                Me.Close
            End If
            Me.cboTestStations.SelectedIndex = MySettingsProperty.Settings.TestStationType
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.OK_Button = New Button
            Me.Cancel_Button = New Button
            Me.cboTestStations = New ComboBoxEx
            Me.LabelX1 = New LabelX
            Me.TableLayoutPanel1.SuspendLayout
            Me.SuspendLayout
            Me.TableLayoutPanel1.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.TableLayoutPanel1.BackColor = Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50!))
            Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
            Me.TableLayoutPanel1.ForeColor = Color.Black
            Dim point2 As New Point(&HA5, &H4A)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50!))
            Dim size2 As New Size(&H92, &H1D)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 0
            Me.OK_Button.Anchor = AnchorStyles.None
            Me.OK_Button.BackColor = Color.White
            Me.OK_Button.ForeColor = Color.Black
            point2 = New Point(3, 3)
            Me.OK_Button.Location = point2
            Me.OK_Button.Name = "OK_Button"
            size2 = New Size(&H43, &H17)
            Me.OK_Button.Size = size2
            Me.OK_Button.TabIndex = 0
            Me.OK_Button.Text = "OK"
            Me.OK_Button.UseVisualStyleBackColor = False
            Me.Cancel_Button.Anchor = AnchorStyles.None
            Me.Cancel_Button.BackColor = Color.White
            Me.Cancel_Button.DialogResult = DialogResult.Cancel
            Me.Cancel_Button.ForeColor = Color.Black
            point2 = New Point(&H4C, 3)
            Me.Cancel_Button.Location = point2
            Me.Cancel_Button.Name = "Cancel_Button"
            size2 = New Size(&H43, &H17)
            Me.Cancel_Button.Size = size2
            Me.Cancel_Button.TabIndex = 1
            Me.Cancel_Button.Text = "Cancel"
            Me.Cancel_Button.UseVisualStyleBackColor = False
            Me.cboTestStations.DisplayMember = "Text"
            Me.cboTestStations.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboTestStations.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTestStations.ForeColor = Color.Black
            Me.cboTestStations.FormattingEnabled = True
            Me.cboTestStations.ItemHeight = 14
            point2 = New Point(13, &H2A)
            Me.cboTestStations.Location = point2
            Me.cboTestStations.Name = "cboTestStations"
            size2 = New Size(&HCB, 20)
            Me.cboTestStations.Size = size2
            Me.cboTestStations.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboTestStations.TabIndex = 1
            Me.LabelX1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.LabelX1.BackColor = Color.White
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX1.ForeColor = Color.Black
            point2 = New Point(13, 13)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&H12A, &H17)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = 2
            Me.LabelX1.Text = "Please select the type of test station that you are working at."
            Me.AcceptButton = Me.OK_Button
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.CancelButton = Me.Cancel_Button
            size2 = New Size(&H143, &H73)
            Me.ClientSize = size2
            Me.Controls.Add(Me.LabelX1)
            Me.Controls.Add(Me.cboTestStations)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgTestStationType"
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Test Station Selection"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me._TestStationType = DirectCast(Me.cboTestStations.SelectedIndex, TestStationTypes)
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

        Friend Overridable Property cboTestStations As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboTestStations
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cboTestStations_SelectedIndexChanged)
                If Not Object.ReferenceEquals(Me._cboTestStations, Nothing) Then
                    RemoveHandler Me._cboTestStations.SelectedIndexChanged, handler
                End If
                Me._cboTestStations = WithEventsValue
                If Not Object.ReferenceEquals(Me._cboTestStations, Nothing) Then
                    AddHandler Me._cboTestStations.SelectedIndexChanged, handler
                End If
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

        Private Property _TestStationType As TestStationTypes
            <DebuggerNonUserCode> _
            Get
                Return Me.__TestStationType
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As TestStationTypes)
                Me.__TestStationType = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property TestStationType As TestStationTypes
            Get
                Return Me._TestStationType
            End Get
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
        <AccessedThroughProperty("cboTestStations")> _
        Private _cboTestStations As ComboBoxEx
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __TestStationType As TestStationTypes
    End Class
End Namespace

