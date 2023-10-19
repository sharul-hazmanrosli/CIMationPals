Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
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
    Public Class ctrlUserLocation
        Inherits UserControl
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.ctrlUserLocation_Load)
            ctrlUserLocation.__ENCAddToList(Me)
            Me.InitializeComponent
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlUserLocation.__ENCList
                If (ctrlUserLocation.__ENCList.Count = ctrlUserLocation.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlUserLocation.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlUserLocation.__ENCList.RemoveRange(index, (ctrlUserLocation.__ENCList.Count - index))
                            ctrlUserLocation.__ENCList.Capacity = ctrlUserLocation.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlUserLocation.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlUserLocation.__ENCList(index) = ctrlUserLocation.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlUserLocation.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub ctrlUserLocation_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Enum.GetValues(GetType(TestSites)).GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As Object = enumerator.Current
                    Me.cboSiteList.Items.Add(current.ToString)
                Loop
            Finally
                If Not Object.ReferenceEquals(TryCast(enumerator,IDisposable), Nothing) Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
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
            Me.cboSiteList = New ComboBoxEx
            Me.LabelX1 = New LabelX
            Me.LabelX2 = New LabelX
            Me.SuspendLayout
            Me.cboSiteList.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.cboSiteList.DisplayMember = "Text"
            Me.cboSiteList.DrawMode = DrawMode.OwnerDrawFixed
            Me.cboSiteList.FormattingEnabled = True
            Me.cboSiteList.ItemHeight = 14
            Dim point2 As New Point(&H10, &H3E)
            Me.cboSiteList.Location = point2
            Me.cboSiteList.Name = "cboSiteList"
            Dim size2 As New Size(&HF5, 20)
            Me.cboSiteList.Size = size2
            Me.cboSiteList.Style = eDotNetBarStyle.StyleManagerControlled
            Me.cboSiteList.TabIndex = 0
            Me.LabelX1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.LabelX1.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(&H10, &H26)
            Me.LabelX1.Location = point2
            Me.LabelX1.Name = "LabelX1"
            size2 = New Size(&HF5, &H17)
            Me.LabelX1.Size = size2
            Me.LabelX1.TabIndex = 1
            Me.LabelX1.Text = "Please Select Your Location from the List Below"
            Me.LabelX2.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.LabelX2.BackgroundStyle.CornerType = eCornerType.Square
            point2 = New Point(&H10, 3)
            Me.LabelX2.Location = point2
            Me.LabelX2.Name = "LabelX2"
            size2 = New Size(&HF5, &H17)
            Me.LabelX2.Size = size2
            Me.LabelX2.TabIndex = 2
            Me.LabelX2.Text = "Before proceeding, I must know your location."
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.LabelX2)
            Me.Controls.Add(Me.LabelX1)
            Me.Controls.Add(Me.cboSiteList)
            Me.Name = "ctrlUserLocation"
            size2 = New Size(280, &H63)
            Me.Size = size2
            Me.ResumeLayout(False)
        End Sub


        ' Properties
        Friend Overridable Property cboSiteList As ComboBoxEx
            <DebuggerNonUserCode> _
            Get
                Return Me._cboSiteList
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ComboBoxEx)
                Me._cboSiteList = WithEventsValue
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


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("cboSiteList")> _
        Private _cboSiteList As ComboBoxEx
        <AccessedThroughProperty("LabelX1")> _
        Private _LabelX1 As LabelX
        <AccessedThroughProperty("LabelX2")> _
        Private _LabelX2 As LabelX
    End Class
End Namespace

