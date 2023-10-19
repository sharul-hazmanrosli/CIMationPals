Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
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
    Public Class dlgCriticalCheckFailed
        Inherits MetroForm
        ' Methods
        Public Sub New(ByVal Name As String, ByVal Val As String, ByVal CheckType As SpecType, ByVal Spec1 As String, ByVal Spec2 As String, ByVal Instructions As String)
            AddHandler MyBase.Shown, New EventHandler(AddressOf Me.dlgCriticalCheckFailed_Shown)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Dialog1_Load)
            dlgCriticalCheckFailed.__ENCAddToList(Me)
            Me.InitializeComponent
            Me._Name = Name
            Me._Val = Val
            Me._CheckType = CheckType
            Me._Spec1 = Spec1
            Me._Spec2 = Spec2
            Me._Instructions = Instructions
            Me.BackColor = Color.Aquamarine
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock dlgCriticalCheckFailed.__ENCList
                If (dlgCriticalCheckFailed.__ENCList.Count = dlgCriticalCheckFailed.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (dlgCriticalCheckFailed.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            dlgCriticalCheckFailed.__ENCList.RemoveRange(index, (dlgCriticalCheckFailed.__ENCList.Count - index))
                            dlgCriticalCheckFailed.__ENCList.Capacity = dlgCriticalCheckFailed.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = dlgCriticalCheckFailed.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                dlgCriticalCheckFailed.__ENCList(index) = dlgCriticalCheckFailed.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                dlgCriticalCheckFailed.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.Cancel
            Me.Close
        End Sub

        Private Sub cmdOkay_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Hide
            Me.Dispose
        End Sub

        Private Sub Dialog1_Load(ByVal sender As Object, ByVal e As EventArgs)
            If (Me._Instructions = Nothing) Then
                Me.txtInstructions.Visible = False
                Me.lblInstructions.Visible = False
                Me.Height = ((Me.Height - Me.txtInstructions.Height) - Me.lblInstructions.Height)
            End If
            If (Me._CheckType <> SpecType.Between) Then
                Me.lblSpec2.Visible = False
                Me.lblSpec2Title.Visible = False
            End If
            Me.lblCheckName.Text = Me._Name
            Me.lblMeasVal.Text = Me._Val
            Me.lblSpecType.Text = Me._CheckType.ToString
            Me.lblSpec1.Text = Me._Spec1
            Me.lblSpec2.Text = Me._Spec2
            Me.txtInstructions.Text = Me._Instructions
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

        Private Sub dlgCriticalCheckFailed_Shown(ByVal sender As Object, ByVal e As EventArgs)
            Me.TableLayoutPanel1.BackColor = Color.Transparent
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(dlgCriticalCheckFailed))
            Me.cmdOkay = New ButtonX
            Me.LabelX1 = New LabelX
            Me.LabelX2 = New LabelX
            Me.LabelX3 = New LabelX
            Me.LabelX4 = New LabelX
            Me.lblSpec2Title = New LabelX
            Me.lblInstructions = New LabelX
            Me.txtInstructions = New TextBoxX
            Me.lblCheckName = New LabelX
            Me.lblMeasVal = New LabelX
            Me.lblSpecType = New LabelX
            Me.lblSpec1 = New LabelX
            Me.lblSpec2 = New LabelX
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.PictureBox1 = New PictureBox
            Me.TableLayoutPanel1.SuspendLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.cmdOkay.AccessibleRole = AccessibleRole.PushButton
            Me.cmdOkay.Anchor = (AnchorStyles.Left Or AnchorStyles.Bottom)
            Me.cmdOkay.ColorTable = eButtonColor.OrangeWithBackground
            Dim point2 As New Point(&HB3, &HC2)
            Me.cmdOkay.Location = point2
            Me.cmdOkay.Name = "cmdOkay"
            Dim size2 As New Size(&H4B, &H17)
            Me.cmdOkay.Size = size2
            Me.cmdOkay.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdOkay.TabIndex = 0
            Me.cmdOkay.Text = "Okay"
            Me.LabelX1.BackColor = Color.Transparent
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX1.Dock = DockStyle.Fill
            Me.LabelX1.ForeColor = Color.Black
            point2 = New Point(3, 3)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&H5E, &H17)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = 2
            Me.LabelX1.Text = "Check Name:"
            Me.LabelX1.TextAlignment = StringAlignment.Far
            Me.LabelX2.BackColor = Color.Transparent
            Me.LabelX2.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX2.Dock = DockStyle.Fill
            Me.LabelX2.ForeColor = Color.Black
            point2 = New Point(3, &H20)
            Me.LabelX2.Location = point2
            Me.LabelX2.Name = "LabelX2"
            size2 = New Size(&H5E, &H17)
            Me.LabelX2.Size = size2
            Me.LabelX2.TabIndex = 3
            Me.LabelX2.Text = "Measured Value:"
            Me.LabelX2.TextAlignment = StringAlignment.Far
            Me.LabelX3.BackColor = Color.Transparent
            Me.LabelX3.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX3.Dock = DockStyle.Fill
            Me.LabelX3.ForeColor = Color.Black
            point2 = New Point(3, &H3D)
            Me.LabelX3.Location = point2
            Me.LabelX3.Name = "LabelX3"
            size2 = New Size(&H5E, &H17)
            Me.LabelX3.Size = size2
            Me.LabelX3.TabIndex = 4
            Me.LabelX3.Text = "Spec Type"
            Me.LabelX3.TextAlignment = StringAlignment.Far
            Me.LabelX4.BackColor = Color.Transparent
            Me.LabelX4.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX4.Dock = DockStyle.Fill
            Me.LabelX4.ForeColor = Color.Black
            point2 = New Point(3, 90)
            Me.LabelX4.Location = point2
            Me.LabelX4.Name = "LabelX4"
            size2 = New Size(&H5E, &H17)
            Me.LabelX4.Size = size2
            Me.LabelX4.TabIndex = 5
            Me.LabelX4.Text = "Spec Value 1:"
            Me.LabelX4.TextAlignment = StringAlignment.Far
            Me.lblSpec2Title.BackColor = Color.Transparent
            Me.lblSpec2Title.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpec2Title.Dock = DockStyle.Fill
            Me.lblSpec2Title.ForeColor = Color.Black
            point2 = New Point(&HAD, 90)
            Me.lblSpec2Title.Location = point2
            Me.lblSpec2Title.Name = "lblSpec2Title"
            size2 = New Size(80, &H17)
            Me.lblSpec2Title.Size = size2
            Me.lblSpec2Title.TabIndex = 6
            Me.lblSpec2Title.Text = "Spec Value 2:"
            Me.lblSpec2Title.TextAlignment = StringAlignment.Far
            Me.lblInstructions.BackColor = Color.White
            Me.lblInstructions.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblInstructions.ForeColor = Color.Black
            point2 = New Point(&H13, &H7D)
            Me.lblInstructions.Location = point2
            Me.lblInstructions.Name = "lblInstructions"
            size2 = New Size(80, &H17)
            Me.lblInstructions.Size = size2
            Me.lblInstructions.TabIndex = 7
            Me.lblInstructions.Text = "Instructions:"
            Me.txtInstructions.BackColor = Color.White
            Me.txtInstructions.Border.Class = "TextBoxBorder"
            Me.txtInstructions.Border.CornerType = eCornerType.Square
            Me.txtInstructions.ForeColor = Color.Black
            point2 = New Point(&H13, &H8F)
            Me.txtInstructions.Location = point2
            Me.txtInstructions.Multiline = True
            Me.txtInstructions.Name = "txtInstructions"
            Me.txtInstructions.ReadOnly = True
            size2 = New Size(&H1A6, &H2D)
            Me.txtInstructions.Size = size2
            Me.txtInstructions.TabIndex = 8
            Me.lblCheckName.BackColor = Color.Transparent
            Me.lblCheckName.BackgroundStyle.CornerType = eCornerType.Square
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblCheckName, 3)
            Me.lblCheckName.Dock = DockStyle.Fill
            Me.lblCheckName.ForeColor = Color.Black
            point2 = New Point(&H67, 3)
            Me.lblCheckName.Location = point2
            Me.lblCheckName.Name = "lblCheckName"
            size2 = New Size(220, &H17)
            Me.lblCheckName.Size = size2
            Me.lblCheckName.TabIndex = 9
            Me.lblCheckName.Text = "LabelX7"
            Me.lblMeasVal.BackColor = Color.Transparent
            Me.lblMeasVal.BackgroundStyle.CornerType = eCornerType.Square
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblMeasVal, 3)
            Me.lblMeasVal.Dock = DockStyle.Fill
            Me.lblMeasVal.ForeColor = Color.Black
            point2 = New Point(&H67, &H20)
            Me.lblMeasVal.Location = point2
            Me.lblMeasVal.Name = "lblMeasVal"
            size2 = New Size(220, &H17)
            Me.lblMeasVal.Size = size2
            Me.lblMeasVal.TabIndex = 10
            Me.lblMeasVal.Text = "LabelX7"
            Me.lblSpecType.BackColor = Color.Transparent
            Me.lblSpecType.BackgroundStyle.CornerType = eCornerType.Square
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblSpecType, 3)
            Me.lblSpecType.Dock = DockStyle.Fill
            Me.lblSpecType.ForeColor = Color.Black
            point2 = New Point(&H67, &H3D)
            Me.lblSpecType.Location = point2
            Me.lblSpecType.Name = "lblSpecType"
            size2 = New Size(220, &H17)
            Me.lblSpecType.Size = size2
            Me.lblSpecType.TabIndex = 11
            Me.lblSpecType.Text = "LabelX7"
            Me.lblSpec1.BackColor = Color.Transparent
            Me.lblSpec1.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpec1.Dock = DockStyle.Fill
            Me.lblSpec1.ForeColor = Color.Black
            point2 = New Point(&H67, 90)
            Me.lblSpec1.Location = point2
            Me.lblSpec1.Name = "lblSpec1"
            size2 = New Size(&H40, &H17)
            Me.lblSpec1.Size = size2
            Me.lblSpec1.TabIndex = 12
            Me.lblSpec1.Text = "LabelX7"
            Me.lblSpec2.BackColor = Color.Transparent
            Me.lblSpec2.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblSpec2.Dock = DockStyle.Fill
            Me.lblSpec2.ForeColor = Color.Black
            point2 = New Point(&H103, 90)
            Me.lblSpec2.Location = point2
            Me.lblSpec2.Name = "lblSpec2"
            size2 = New Size(&H40, &H17)
            Me.lblSpec2.Size = size2
            Me.lblSpec2.TabIndex = 13
            Me.lblSpec2.Text = "LabelX7"
            Me.TableLayoutPanel1.BackColor = Color.FromArgb(&HD8, &HD8, &HD8)
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70!))
            Me.TableLayoutPanel1.Controls.Add(Me.LabelX1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSpec2, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelX2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSpec1, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelX3, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSpec2Title, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSpecType, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.LabelX4, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMeasVal, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCheckName, 1, 0)
            Me.TableLayoutPanel1.ForeColor = Color.Black
            point2 = New Point(&H73, -6)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25!))
            size2 = New Size(&H146, &H74)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 14
            Me.PictureBox1.BackColor = Color.Transparent
            Me.PictureBox1.ForeColor = Color.Black
            Me.PictureBox1.Image = DirectCast(manager.GetObject("PictureBox1.Image"), Image)
            point2 = New Point(0, 1)
            Me.PictureBox1.Location = point2
            Dim padding2 As New Padding(0)
            Me.PictureBox1.Margin = padding2
            Me.PictureBox1.Name = "PictureBox1"
            size2 = New Size(&H80, &H7D)
            Me.PictureBox1.Size = size2
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 1
            Me.PictureBox1.TabStop = False
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.White
            size2 = New Size(&H1C7, &HE2)
            Me.ClientSize = size2
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.txtInstructions)
            Me.Controls.Add(Me.lblInstructions)
            Me.Controls.Add(Me.cmdOkay)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgCriticalCheckFailed"
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Failed Check"
            Me.TableLayoutPanel1.ResumeLayout(False)
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
        End Sub

        Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.Close
        End Sub


        ' Properties
        Friend Overridable Property cmdOkay As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdOkay
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cmdOkay_Click)
                If Not Object.ReferenceEquals(Me._cmdOkay, Nothing) Then
                    RemoveHandler Me._cmdOkay.Click, handler
                End If
                Me._cmdOkay = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdOkay, Nothing) Then
                    AddHandler Me._cmdOkay.Click, handler
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

        Friend Overridable Property LabelX4 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._LabelX4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._LabelX4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpec2Title As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpec2Title
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpec2Title = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblInstructions As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblInstructions
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblInstructions = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtInstructions As TextBoxX
            <DebuggerNonUserCode> _
            Get
                Return Me._txtInstructions
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As TextBoxX)
                Me._txtInstructions = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblCheckName As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblCheckName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblCheckName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblMeasVal As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblMeasVal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblMeasVal = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpecType As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpecType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpecType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpec1 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpec1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpec1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblSpec2 As LabelX
            <DebuggerNonUserCode> _
            Get
                Return Me._lblSpec2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As LabelX)
                Me._lblSpec2 = WithEventsValue
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

        Private Property _Name As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Name
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Name = AutoPropertyValue
            End Set
        End Property

        Private Property _Val As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Val
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Val = AutoPropertyValue
            End Set
        End Property

        Private Property _CheckType As SpecType
            <DebuggerNonUserCode> _
            Get
                Return Me.__CheckType
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As SpecType)
                Me.__CheckType = AutoPropertyValue
            End Set
        End Property

        Private Property _Spec1 As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Spec1
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Spec1 = AutoPropertyValue
            End Set
        End Property

        Private Property _Spec2 As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Spec2
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Spec2 = AutoPropertyValue
            End Set
        End Property

        Private Property _Instructions As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Instructions
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Instructions = AutoPropertyValue
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("cmdOkay")> _
        Private _cmdOkay As ButtonX
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
        <AccessedThroughProperty("LabelX2")> _
        Private _LabelX2 As LabelX
        <AccessedThroughProperty("LabelX3")> _
        Private _LabelX3 As LabelX
        <AccessedThroughProperty("LabelX4")> _
        Private _LabelX4 As LabelX
        <AccessedThroughProperty("lblSpec2Title")> _
        Private _lblSpec2Title As LabelX
        <AccessedThroughProperty("lblInstructions")> _
        Private _lblInstructions As LabelX
        <AccessedThroughProperty("txtInstructions")> _
        Private _txtInstructions As TextBoxX
        <AccessedThroughProperty("lblCheckName")> _
        Private _lblCheckName As LabelX
        <AccessedThroughProperty("lblMeasVal")> _
        Private _lblMeasVal As LabelX
        <AccessedThroughProperty("lblSpecType")> _
        Private _lblSpecType As LabelX
        <AccessedThroughProperty("lblSpec1")> _
        Private _lblSpec1 As LabelX
        <AccessedThroughProperty("lblSpec2")> _
        Private _lblSpec2 As LabelX
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Name As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Val As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __CheckType As SpecType
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Spec1 As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Spec2 As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __Instructions As String
    End Class
End Namespace

