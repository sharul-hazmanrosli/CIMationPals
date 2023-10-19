Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
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
    Public Class dlgTestComplete
        Inherits MetroForm
        ' Methods
        Public Sub New(ByVal Passed As Boolean)
            AddHandler MyBase.Shown, New EventHandler(AddressOf Me.dlgTestComplete_Shown)
            dlgTestComplete.__ENCAddToList(Me)
            Me.InitializeComponent
            Me._Passed = Passed
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock dlgTestComplete.__ENCList
                If (dlgTestComplete.__ENCList.Count = dlgTestComplete.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (dlgTestComplete.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            dlgTestComplete.__ENCList.RemoveRange(index, (dlgTestComplete.__ENCList.Count - index))
                            dlgTestComplete.__ENCList.Capacity = dlgTestComplete.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = dlgTestComplete.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                dlgTestComplete.__ENCList(index) = dlgTestComplete.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                dlgTestComplete.__ENCList.Add(New WeakReference(value))
            End SyncLock
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

        Private Sub dlgTestComplete_Shown(ByVal sender As Object, ByVal e As EventArgs)
            If Me._Passed Then
                Me.PictureBox1.Image = Resources.happy_sm
            Else
                Me.PictureBox1.Image = Resources.frown_sm
                Me.ReflectionLabel2.Text = Strings.Replace(Me.ReflectionLabel2.Text, "#20C500", "#B02B2C", 1, -1, CompareMethod.Binary)
                Me.ReflectionLabel2.Text = Strings.Replace(Me.ReflectionLabel2.Text, "Passed", "Failed", 1, -1, CompareMethod.Binary)
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(dlgTestComplete))
            Me.PictureBox1 = New PictureBox
            Me.ReflectionLabel1 = New ReflectionLabel
            Me.ReflectionLabel2 = New ReflectionLabel
            Me.cmdOkay = New ButtonX
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.PictureBox1.BackColor = Color.Transparent
            Me.PictureBox1.ForeColor = Color.Black
            Me.PictureBox1.Image = DirectCast(manager.GetObject("PictureBox1.Image"), Image)
            Dim point2 As New Point(9, 9)
            Me.PictureBox1.Location = point2
            Dim padding2 As New Padding(0)
            Me.PictureBox1.Margin = padding2
            Me.PictureBox1.Name = "PictureBox1"
            Dim size2 As New Size(&H80, &H7D)
            Me.PictureBox1.Size = size2
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 2
            Me.PictureBox1.TabStop = False
            Me.ReflectionLabel1.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(140, 0)
            Me.ReflectionLabel1.Location = point2
            Me.ReflectionLabel1.Name = "ReflectionLabel1"
            size2 = New Size(290, 70)
            Me.ReflectionLabel1.Size = size2
            Me.ReflectionLabel1.TabIndex = 3
            Me.ReflectionLabel1.Text = "<b><font size=""+10""><i>Test Complete</i></font></b>"
            Me.ReflectionLabel2.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(140, &H40)
            Me.ReflectionLabel2.Location = point2
            Me.ReflectionLabel2.Name = "ReflectionLabel2"
            size2 = New Size(290, 70)
            Me.ReflectionLabel2.Size = size2
            Me.ReflectionLabel2.TabIndex = 4
            Me.ReflectionLabel2.Text = "<b><font size=""+12""><i>Status:  </i><font color=""#B02B2C""><font color=""#20C500"">Passed</font></font></font></b>"
            Me.cmdOkay.AccessibleRole = AccessibleRole.PushButton
            Me.cmdOkay.ColorTable = eButtonColor.OrangeWithBackground
            point2 = New Point(&HB1, 140)
            Me.cmdOkay.Location = point2
            Me.cmdOkay.Name = "cmdOkay"
            size2 = New Size(&H4B, &H17)
            Me.cmdOkay.Size = size2
            Me.cmdOkay.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cmdOkay.TabIndex = 5
            Me.cmdOkay.Text = "Okay"
            Me.AcceptButton = Me.cmdOkay
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            size2 = New Size(&H1B3, &HA9)
            Me.ClientSize = size2
            Me.Controls.Add(Me.cmdOkay)
            Me.Controls.Add(Me.ReflectionLabel2)
            Me.Controls.Add(Me.ReflectionLabel1)
            Me.Controls.Add(Me.PictureBox1)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgTestComplete"
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Test Complete"
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
        End Sub

        Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.Close
        End Sub


        ' Properties
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

        Friend Overridable Property cmdOkay As ButtonX
            <DebuggerNonUserCode> _
            Get
                Return Me._cmdOkay
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonX)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OK_Button_Click)
                If Not Object.ReferenceEquals(Me._cmdOkay, Nothing) Then
                    RemoveHandler Me._cmdOkay.Click, handler
                End If
                Me._cmdOkay = WithEventsValue
                If Not Object.ReferenceEquals(Me._cmdOkay, Nothing) Then
                    AddHandler Me._cmdOkay.Click, handler
                End If
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("ReflectionLabel1")> _
        Private _ReflectionLabel1 As ReflectionLabel
        <AccessedThroughProperty("ReflectionLabel2")> _
        Private _ReflectionLabel2 As ReflectionLabel
        <AccessedThroughProperty("cmdOkay")> _
        Private _cmdOkay As ButtonX
        Private _Passed As Boolean
    End Class
End Namespace

