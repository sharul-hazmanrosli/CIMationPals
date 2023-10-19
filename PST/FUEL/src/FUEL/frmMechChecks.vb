Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar.Metro.ColorTables
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
    Public Class frmMechChecks
        Inherits MetroAppForm
        ' Methods
        Public Sub New(ByVal CheckList As List(Of PrinterMechChecks))
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmMechChecks_Load)
            frmMechChecks.__ENCAddToList(Me)
            Me.InitializeComponent
            Me._CheckList = CheckList
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock frmMechChecks.__ENCList
                If (frmMechChecks.__ENCList.Count = frmMechChecks.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (frmMechChecks.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            frmMechChecks.__ENCList.RemoveRange(index, (frmMechChecks.__ENCList.Count - index))
                            frmMechChecks.__ENCList.Capacity = frmMechChecks.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = frmMechChecks.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                frmMechChecks.__ENCList(index) = frmMechChecks.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                frmMechChecks.__ENCList.Add(New WeakReference(value))
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

        Private Sub frmMechChecks_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me._ctrlMechChecks = New ctrlMechChecks(Me._CheckList)
            Me.MetroTabPanel1.Controls.Add(Me._ctrlMechChecks)
            Me._ctrlMechChecks.Dock = DockStyle.Fill
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.MetroShell1 = New MetroShell
            Me.MetroTabPanel1 = New MetroTabPanel
            Me.MetroTabItem1 = New MetroTabItem
            Me.StyleManager1 = New StyleManager(Me.components)
            Me.MetroShell1.SuspendLayout
            Me.SuspendLayout
            Me.MetroShell1.BackColor = Color.White
            Me.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square
            Me.MetroShell1.CanCustomize = False
            Me.MetroShell1.CaptionVisible = True
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel1)
            Me.MetroShell1.Dock = DockStyle.Top
            Me.MetroShell1.ForeColor = Color.Black
            Me.MetroShell1.HelpButtonText = Nothing
            Me.MetroShell1.HelpButtonVisible = False
            Dim items As BaseItem() = New BaseItem() { Me.MetroTabItem1 }
            Me.MetroShell1.Items.AddRange(items)
            Me.MetroShell1.KeyTipsFont = New Font("Tahoma", 7!)
            Dim point2 As New Point(0, 1)
            Me.MetroShell1.Location = point2
            Me.MetroShell1.Name = "MetroShell1"
            Me.MetroShell1.SettingsButtonVisible = False
            Dim size2 As New Size(&H301, &H191)
            Me.MetroShell1.Size = size2
            Me.MetroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.MetroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.MetroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.MetroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.MetroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.MetroShell1.SystemText.QatDialogAddButton = "&Add >>"
            Me.MetroShell1.SystemText.QatDialogCancelButton = "Cancel"
            Me.MetroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.MetroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.MetroShell1.SystemText.QatDialogOkButton = "OK"
            Me.MetroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.MetroShell1.SystemText.QatDialogRemoveButton = "&Remove"
            Me.MetroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.MetroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.MetroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.MetroShell1.TabIndex = 0
            Me.MetroShell1.TabStripFont = New Font("Segoe UI", 10.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.MetroShell1.Text = "MetroShell1"
            Me.MetroTabPanel1.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel1.Dock = DockStyle.Fill
            point2 = New Point(0, &H33)
            Me.MetroTabPanel1.Location = point2
            Me.MetroTabPanel1.Name = "MetroTabPanel1"
            Dim padding2 As New Padding(3, 0, 3, 3)
            Me.MetroTabPanel1.Padding = padding2
            size2 = New Size(&H301, 350)
            Me.MetroTabPanel1.Size = size2
            Me.MetroTabPanel1.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel1.TabIndex = 1
            Me.MetroTabItem1.Checked = True
            Me.MetroTabItem1.Name = "MetroTabItem1"
            Me.MetroTabItem1.Panel = Me.MetroTabPanel1
            Me.MetroTabItem1.Text = "Mech Checks"
            Me.StyleManager1.ManagerStyle = eStyle.Metro
            Dim parameters2 As New MetroColorGeneratorParameters(Color.White, Color.FromArgb(&HFF, &HA3, &H1A))
            Me.StyleManager1.MetroColorParameters = parameters2
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            size2 = New Size(770, &H196)
            Me.ClientSize = size2
            Me.Controls.Add(Me.MetroShell1)
            Me.Name = "frmMechChecks"
            Me.MetroShell1.ResumeLayout(False)
            Me.MetroShell1.PerformLayout
            Me.ResumeLayout(False)
        End Sub


        ' Properties
        Friend Overridable Property MetroShell1 As MetroShell
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroShell1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroShell)
                Me._MetroShell1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabPanel1 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroTabItem1 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem1 = WithEventsValue
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


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("MetroShell1")> _
        Private _MetroShell1 As MetroShell
        <AccessedThroughProperty("MetroTabPanel1")> _
        Private _MetroTabPanel1 As MetroTabPanel
        <AccessedThroughProperty("MetroTabItem1")> _
        Private _MetroTabItem1 As MetroTabItem
        <AccessedThroughProperty("StyleManager1")> _
        Private _StyleManager1 As StyleManager
        Private _ctrlMechChecks As ctrlMechChecks
        Private _CheckList As List(Of PrinterMechChecks)
    End Class
End Namespace

