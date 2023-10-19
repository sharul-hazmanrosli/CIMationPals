Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports FUEL.My
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
    Public Class ctrlTriage
        Inherits UserControl
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Resize, New EventHandler(AddressOf Me.ctrlTriage_Resize)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.ctrlTriage_Load)
            ctrlTriage.__ENCAddToList(Me)
            Me.InitializeComponent
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlTriage.__ENCList
                If (ctrlTriage.__ENCList.Count = ctrlTriage.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlTriage.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlTriage.__ENCList.RemoveRange(index, (ctrlTriage.__ENCList.Count - index))
                            ctrlTriage.__ENCList.Capacity = ctrlTriage.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlTriage.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlTriage.__ENCList(index) = ctrlTriage.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlTriage.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Public Sub CloseTriage()
            Me.sldpTriage.IsOpen = False
            Me.rtbTriage.Clear
        End Sub

        Private Sub ctrlTriage_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.sldpTriage.IsOpen = False
            Me.sldpTriage.SetBounds((Me.Width - 10), 10, (Me.Width - 20), (Me.Height - 50))
            Dim rectangle2 As New Rectangle(0, 0, Me.Width, Me.Height)
            Me.sldpTriage.OpenBounds = rectangle2
        End Sub

        Private Sub ctrlTriage_Resize(ByVal sender As Object, ByVal e As EventArgs)
            Me.sldpTriage.SetBounds((Me.Width - 10), 10, (Me.Width - 20), (Me.Height - 50))
            Dim rectangle2 As New Rectangle(0, 0, Me.Width, Me.Height)
            Me.sldpTriage.OpenBounds = rectangle2
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
            Dim manager As New ComponentResourceManager(GetType(ctrlTriage))
            Me.TableLayoutPanel1 = New TableLayoutPanel
            Me.PictureBox6 = New PictureBox
            Me.PictureBox5 = New PictureBox
            Me.PictureBox4 = New PictureBox
            Me.PictureBox3 = New PictureBox
            Me.PictureBox2 = New PictureBox
            Me.PictureBox1 = New PictureBox
            Me.PictureBox7 = New PictureBox
            Me.PictureBox8 = New PictureBox
            Me.PictureBox9 = New PictureBox
            Me.sldpTriage = New SlidePanel
            Me.rtbTriage = New RichTextBox
            Me.lblBack = New ReflectionLabel
            Me.LabelX1 = New LabelX
            Me.TableLayoutPanel1.SuspendLayout
            DirectCast(Me.PictureBox6, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox5, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox4, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox3, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox2, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox7, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox8, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox9, ISupportInitialize).BeginInit
            Me.sldpTriage.SuspendLayout
            Me.SuspendLayout
            Me.TableLayoutPanel1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.TableLayoutPanel1.BackColor = Color.Gold
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33332!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33334!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33334!))
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox6, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox4, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox3, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox7, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox8, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox9, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.PictureBox5, 1, 1)
            Dim point2 As New Point(3, &H25)
            Me.TableLayoutPanel1.Location = point2
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
            Dim size2 As New Size(&H32B, &H292)
            Me.TableLayoutPanel1.Size = size2
            Me.TableLayoutPanel1.TabIndex = 0
            Me.PictureBox6.Image = DirectCast(manager.GetObject("PictureBox6.Image"), Image)
            point2 = New Point(&H21F, &HDE)
            Me.PictureBox6.Location = point2
            Me.PictureBox6.Name = "PictureBox6"
            size2 = New Size(&H108, &HD5)
            Me.PictureBox6.Size = size2
            Me.PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox6.TabIndex = 5
            Me.PictureBox6.TabStop = False
            Me.PictureBox5.Image = DirectCast(manager.GetObject("PictureBox5.Image"), Image)
            point2 = New Point(&H111, &HDE)
            Me.PictureBox5.Location = point2
            Me.PictureBox5.Name = "PictureBox5"
            size2 = New Size(&H108, &HD5)
            Me.PictureBox5.Size = size2
            Me.PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox5.TabIndex = 4
            Me.PictureBox5.TabStop = False
            Me.PictureBox4.Image = DirectCast(manager.GetObject("PictureBox4.Image"), Image)
            point2 = New Point(3, &HDE)
            Me.PictureBox4.Location = point2
            Me.PictureBox4.Name = "PictureBox4"
            size2 = New Size(&H108, &HD5)
            Me.PictureBox4.Size = size2
            Me.PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox4.TabIndex = 3
            Me.PictureBox4.TabStop = False
            Me.PictureBox3.Image = DirectCast(manager.GetObject("PictureBox3.Image"), Image)
            point2 = New Point(&H21F, 3)
            Me.PictureBox3.Location = point2
            Me.PictureBox3.Name = "PictureBox3"
            size2 = New Size(&H109, &HD5)
            Me.PictureBox3.Size = size2
            Me.PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox3.TabIndex = 2
            Me.PictureBox3.TabStop = False
            Me.PictureBox2.Image = DirectCast(manager.GetObject("PictureBox2.Image"), Image)
            point2 = New Point(&H111, 3)
            Me.PictureBox2.Location = point2
            Me.PictureBox2.Name = "PictureBox2"
            size2 = New Size(&H108, &HD5)
            Me.PictureBox2.Size = size2
            Me.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox2.TabIndex = 1
            Me.PictureBox2.TabStop = False
            Me.PictureBox1.Cursor = Cursors.Hand
            Me.PictureBox1.Image = DirectCast(manager.GetObject("PictureBox1.Image"), Image)
            point2 = New Point(3, 3)
            Me.PictureBox1.Location = point2
            Me.PictureBox1.Name = "PictureBox1"
            size2 = New Size(&H108, &HD5)
            Me.PictureBox1.Size = size2
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            Me.PictureBox7.Dock = DockStyle.Fill
            Me.PictureBox7.Image = DirectCast(manager.GetObject("PictureBox7.Image"), Image)
            point2 = New Point(3, &H1B9)
            Me.PictureBox7.Location = point2
            Me.PictureBox7.Name = "PictureBox7"
            size2 = New Size(&H108, &HD6)
            Me.PictureBox7.Size = size2
            Me.PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox7.TabIndex = 6
            Me.PictureBox7.TabStop = False
            Me.PictureBox8.Dock = DockStyle.Fill
            Me.PictureBox8.Image = DirectCast(manager.GetObject("PictureBox8.Image"), Image)
            point2 = New Point(&H111, &H1B9)
            Me.PictureBox8.Location = point2
            Me.PictureBox8.Name = "PictureBox8"
            size2 = New Size(&H108, &HD6)
            Me.PictureBox8.Size = size2
            Me.PictureBox8.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox8.TabIndex = 7
            Me.PictureBox8.TabStop = False
            point2 = New Point(&H21F, &H1B9)
            Me.PictureBox9.Location = point2
            Me.PictureBox9.Name = "PictureBox9"
            size2 = New Size(100, 50)
            Me.PictureBox9.Size = size2
            Me.PictureBox9.TabIndex = 8
            Me.PictureBox9.TabStop = False
            Me.sldpTriage.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            Me.sldpTriage.AnimationTime = 350
            Me.sldpTriage.AutoScroll = True
            Me.sldpTriage.BackColor = Color.DarkRed
            Me.sldpTriage.Controls.Add(Me.rtbTriage)
            Me.sldpTriage.Controls.Add(Me.lblBack)
            Me.sldpTriage.Cursor = Cursors.Hand
            point2 = New Point(&H26F, &H1F2)
            Me.sldpTriage.Location = point2
            Me.sldpTriage.Name = "sldpTriage"
            size2 = New Size(&H9F, &HE4)
            Me.sldpTriage.Size = size2
            Me.sldpTriage.SlideOutButtonVisible = False
            Me.sldpTriage.SlideSide = eSlideSide.Right
            Me.sldpTriage.TabIndex = 1
            Me.sldpTriage.Text = "SlidePanel1"
            Me.sldpTriage.UsesBlockingAnimation = False
            Me.rtbTriage.BackColor = SystemColors.Control
            Me.rtbTriage.Cursor = Cursors.Default
            Me.rtbTriage.Dock = DockStyle.Bottom
            point2 = New Point(0, &H29)
            Me.rtbTriage.Location = point2
            Me.rtbTriage.Name = "rtbTriage"
            Me.rtbTriage.ReadOnly = True
            size2 = New Size(&H8E, &H2A4)
            Me.rtbTriage.Size = size2
            Me.rtbTriage.TabIndex = 0
            Me.rtbTriage.Text = ""
            Me.lblBack.BackgroundStyle.CornerType = eCornerType.Square
            Me.lblBack.Cursor = Cursors.Hand
            point2 = New Point(7, -12)
            Me.lblBack.Location = point2
            Me.lblBack.Name = "lblBack"
            size2 = New Size(&H39, &H35)
            Me.lblBack.Size = size2
            Me.lblBack.TabIndex = 1
            Me.lblBack.Text = "<b><font size=""+6"" color=""#B02B2C"">Back</font></b>"
            Me.LabelX1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            Me.LabelX1.Font = New Font("Microsoft Sans Serif", 14.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(3, 3)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&H32B, &H1C)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = 2
            Me.LabelX1.Text = "Click on the chart the most close resembles the failure that you want to triage"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.sldpTriage)
            Me.Controls.Add(Me.LabelX1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "ctrlTriage"
            size2 = New Size(&H331, &H2BA)
            Me.Size = size2
            Me.TableLayoutPanel1.ResumeLayout(False)
            DirectCast(Me.PictureBox6, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox5, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox4, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox3, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox2, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox7, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox8, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox9, ISupportInitialize).EndInit
            Me.sldpTriage.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub OpenTriage(ByVal FileName As String)
            Dim dataPath As String = modCommonCode.GetDataPath
            Dim file As String = (dataPath & "\PSTDocs\" & FileName)
            If MyProject.Computer.FileSystem.FileExists(file) Then
                Me.rtbTriage.LoadFile(file)
            ElseIf MyProject.Computer.FileSystem.FileExists((dataPath & "\PSTDocs\PSTNoHelp.rtf")) Then
                Me.rtbTriage.LoadFile((dataPath & "\PSTDocs\PSTNoHelp.rtf"))
            End If
            Me.sldpTriage.IsOpen = True
        End Sub

        Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTLeak.rtf")
        End Sub

        Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTFalseFailLeak.rtf")
        End Sub

        Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTCyclicalPressureDrop.rtf")
        End Sub

        Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("idk.rtf")
        End Sub

        Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTPinchedVentTube.rtf")
        End Sub

        Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTBadPSTBox.rtf")
        End Sub

        Private Sub PictureBox7_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTPressureFluctuates.rtf")
        End Sub

        Private Sub PictureBox8_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("PSTNoPressure.rtf")
        End Sub

        Private Sub PictureBox9_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.OpenTriage("none.rtf")
        End Sub

        Private Sub sldpTriage_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.CloseTriage
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

        Friend Overridable Property PictureBox1 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox1_Click)
                If Not Object.ReferenceEquals(Me._PictureBox1, Nothing) Then
                    RemoveHandler Me._PictureBox1.Click, handler
                End If
                Me._PictureBox1 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox1, Nothing) Then
                    AddHandler Me._PictureBox1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox6 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox6_Click)
                If Not Object.ReferenceEquals(Me._PictureBox6, Nothing) Then
                    RemoveHandler Me._PictureBox6.Click, handler
                End If
                Me._PictureBox6 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox6, Nothing) Then
                    AddHandler Me._PictureBox6.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox5 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox5_Click)
                If Not Object.ReferenceEquals(Me._PictureBox5, Nothing) Then
                    RemoveHandler Me._PictureBox5.Click, handler
                End If
                Me._PictureBox5 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox5, Nothing) Then
                    AddHandler Me._PictureBox5.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox4 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox4_Click)
                If Not Object.ReferenceEquals(Me._PictureBox4, Nothing) Then
                    RemoveHandler Me._PictureBox4.Click, handler
                End If
                Me._PictureBox4 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox4, Nothing) Then
                    AddHandler Me._PictureBox4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox3 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox3_Click)
                If Not Object.ReferenceEquals(Me._PictureBox3, Nothing) Then
                    RemoveHandler Me._PictureBox3.Click, handler
                End If
                Me._PictureBox3 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox3, Nothing) Then
                    AddHandler Me._PictureBox3.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox2 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox2_Click)
                If Not Object.ReferenceEquals(Me._PictureBox2, Nothing) Then
                    RemoveHandler Me._PictureBox2.Click, handler
                End If
                Me._PictureBox2 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox2, Nothing) Then
                    AddHandler Me._PictureBox2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property sldpTriage As SlidePanel
            <DebuggerNonUserCode> _
            Get
                Return Me._sldpTriage
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SlidePanel)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.sldpTriage_Click)
                If Not Object.ReferenceEquals(Me._sldpTriage, Nothing) Then
                    RemoveHandler Me._sldpTriage.Click, handler
                End If
                Me._sldpTriage = WithEventsValue
                If Not Object.ReferenceEquals(Me._sldpTriage, Nothing) Then
                    AddHandler Me._sldpTriage.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property rtbTriage As RichTextBox
            <DebuggerNonUserCode> _
            Get
                Return Me._rtbTriage
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtbTriage = WithEventsValue
            End Set
        End Property

        Friend Overridable Property PictureBox7 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox7_Click)
                If Not Object.ReferenceEquals(Me._PictureBox7, Nothing) Then
                    RemoveHandler Me._PictureBox7.Click, handler
                End If
                Me._PictureBox7 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox7, Nothing) Then
                    AddHandler Me._PictureBox7.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox8 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox8_Click)
                If Not Object.ReferenceEquals(Me._PictureBox8, Nothing) Then
                    RemoveHandler Me._PictureBox8.Click, handler
                End If
                Me._PictureBox8 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox8, Nothing) Then
                    AddHandler Me._PictureBox8.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox9 As PictureBox
            <DebuggerNonUserCode> _
            Get
                Return Me._PictureBox9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox9_Click)
                If Not Object.ReferenceEquals(Me._PictureBox9, Nothing) Then
                    RemoveHandler Me._PictureBox9.Click, handler
                End If
                Me._PictureBox9 = WithEventsValue
                If Not Object.ReferenceEquals(Me._PictureBox9, Nothing) Then
                    AddHandler Me._PictureBox9.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property lblBack As ReflectionLabel
            <DebuggerNonUserCode> _
            Get
                Return Me._lblBack
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ReflectionLabel)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.sldpTriage_Click)
                If Not Object.ReferenceEquals(Me._lblBack, Nothing) Then
                    RemoveHandler Me._lblBack.Click, handler
                End If
                Me._lblBack = WithEventsValue
                If Not Object.ReferenceEquals(Me._lblBack, Nothing) Then
                    AddHandler Me._lblBack.Click, handler
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


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("TableLayoutPanel1")> _
        Private _TableLayoutPanel1 As TableLayoutPanel
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PictureBox6")> _
        Private _PictureBox6 As PictureBox
        <AccessedThroughProperty("PictureBox5")> _
        Private _PictureBox5 As PictureBox
        <AccessedThroughProperty("PictureBox4")> _
        Private _PictureBox4 As PictureBox
        <AccessedThroughProperty("PictureBox3")> _
        Private _PictureBox3 As PictureBox
        <AccessedThroughProperty("PictureBox2")> _
        Private _PictureBox2 As PictureBox
        <AccessedThroughProperty("sldpTriage")> _
        Private _sldpTriage As SlidePanel
        <AccessedThroughProperty("rtbTriage")> _
        Private _rtbTriage As RichTextBox
        <AccessedThroughProperty("PictureBox7")> _
        Private _PictureBox7 As PictureBox
        <AccessedThroughProperty("PictureBox8")> _
        Private _PictureBox8 As PictureBox
        <AccessedThroughProperty("PictureBox9")> _
        Private _PictureBox9 As PictureBox
        <AccessedThroughProperty("lblBack")> _
        Private _lblBack As ReflectionLabel
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
    End Class
End Namespace

