Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    <DesignerGenerated> _
    Public Class frmAutoUpload
        Inherits MetroAppForm
        ' Methods
        Public Sub New(ByVal FileDir As String)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmAutoUpload_Load)
            AddHandler MyBase.Shown, New EventHandler(AddressOf Me.frmAutoUpload_Shown)
            frmAutoUpload.__ENCAddToList(Me)
            Me._HideForm = False
            Me.InitializeComponent
            Logging.AddLogEntry(Me, "Instantiating frmAutoUpload", EventLogEntryType.Information, 2)
            Logging.AddLogEntry(Me, ("File Dir: " & FileDir), EventLogEntryType.Information, 2)
            Me._FileDir = FileDir
            Me._DestinationSite = UploadSettings.InstallLocation
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock frmAutoUpload.__ENCList
                If (frmAutoUpload.__ENCList.Count = frmAutoUpload.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (frmAutoUpload.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            frmAutoUpload.__ENCList.RemoveRange(index, (frmAutoUpload.__ENCList.Count - index))
                            frmAutoUpload.__ENCList.Capacity = frmAutoUpload.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = frmAutoUpload.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                frmAutoUpload.__ENCList(index) = frmAutoUpload.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                frmAutoUpload.__ENCList.Add(New WeakReference(value))
            End SyncLock
        End Sub

        Private Sub CloseForm()
            If Me.InvokeRequired Then
                Me.Invoke(New FRMClose(AddressOf Me.CloseForm))
            Else
                Me.Close
            End If
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

        Private Sub frmAutoUpload_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim enumerator As IEnumerator(Of String)
            Dim onlys As ReadOnlyCollection(Of String) = MyProject.Computer.FileSystem.GetFiles(Me._FileDir, SearchOption.SearchTopLevelOnly, ctrlUploadFiles.AllowedFileTypes)
            Logging.AddLogEntry(Me, ("File Count: " & Conversions.ToString(onlys.Count)), EventLogEntryType.Information, 3)
            Dim fileList As New Collection(Of String)
            Try 
                enumerator = onlys.GetEnumerator
                Do While True
                    If Not enumerator.MoveNext Then
                        Exit Do
                    End If
                    Dim current As String = enumerator.Current
                    fileList.Add(current)
                Loop
            Finally
                If Not Object.ReferenceEquals(enumerator, Nothing) Then
                    enumerator.Dispose
                End If
            End Try
            Me._ctrlUpload = New ctrlUploadFiles(fileList, UploadSettings.InstallLocation, Me._DestinationSite)
            AddHandler Me._ctrlUpload.JobComplete, New JobCompleteEventHandler(AddressOf Me.JobComplete)
            Me.MetroTabPanel1.Controls.Add(Me._ctrlUpload)
            Me._ctrlUpload.Dock = DockStyle.Fill
        End Sub

        Private Sub frmAutoUpload_Shown(ByVal sender As Object, ByVal e As EventArgs)
            If Me._HideForm Then
                Me.Hide
            End If
            Logging.AddLogEntry(Me, "frmAutoUpload_Shown: Starting Upload", EventLogEntryType.Information, 2)
            Me._ctrlUpload.StartUpload
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.MetroShell1 = New MetroShell
            Me.MetroTabPanel1 = New MetroTabPanel
            Me.MetroTabPanel2 = New MetroTabPanel
            Me.MetroAppButton1 = New MetroAppButton
            Me.MetroTabItem1 = New MetroTabItem
            Me.MetroTabItem2 = New MetroTabItem
            Me.ButtonItem1 = New ButtonItem
            Me.QatCustomizeItem1 = New QatCustomizeItem
            Me.StyleManager1 = New StyleManager(Me.components)
            Me.MetroShell1.SuspendLayout
            Me.SuspendLayout
            Me.MetroShell1.BackColor = Color.White
            Me.MetroShell1.BackgroundStyle.CornerType = eCornerType.Square
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel1)
            Me.MetroShell1.Controls.Add(Me.MetroTabPanel2)
            Me.MetroShell1.Dock = DockStyle.Top
            Me.MetroShell1.ForeColor = Color.Black
            Me.MetroShell1.HelpButtonText = Nothing
            Dim items As BaseItem() = New BaseItem() { Me.MetroAppButton1, Me.MetroTabItem1, Me.MetroTabItem2 }
            Me.MetroShell1.Items.AddRange(items)
            Me.MetroShell1.KeyTipsFont = New Font("Tahoma", 7!)
            Dim point2 As New Point(0, 1)
            Me.MetroShell1.Location = point2
            Me.MetroShell1.Name = "MetroShell1"
            items = New BaseItem() { Me.ButtonItem1, Me.QatCustomizeItem1 }
            Me.MetroShell1.QuickToolbarItems.AddRange(items)
            Dim size2 As New Size(&H1F0, &H13F)
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
            point2 = New Point(0, &H1A)
            Me.MetroTabPanel1.Location = point2
            Me.MetroTabPanel1.Name = "MetroTabPanel1"
            Dim padding2 As New Padding(3, 0, 3, 3)
            Me.MetroTabPanel1.Padding = padding2
            size2 = New Size(&H1F0, &H125)
            Me.MetroTabPanel1.Size = size2
            Me.MetroTabPanel1.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel1.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel1.TabIndex = 1
            Me.MetroTabPanel2.ColorSchemeStyle = eDotNetBarStyle.StyleManagerControlled
            Me.MetroTabPanel2.Dock = DockStyle.Fill
            point2 = New Point(0, &H1A)
            Me.MetroTabPanel2.Location = point2
            Me.MetroTabPanel2.Name = "MetroTabPanel2"
            padding2 = New Padding(3, 0, 3, 3)
            Me.MetroTabPanel2.Padding = padding2
            size2 = New Size(&H1F0, &H125)
            Me.MetroTabPanel2.Size = size2
            Me.MetroTabPanel2.Style.CornerType = eCornerType.Square
            Me.MetroTabPanel2.StyleMouseDown.CornerType = eCornerType.Square
            Me.MetroTabPanel2.StyleMouseOver.CornerType = eCornerType.Square
            Me.MetroTabPanel2.TabIndex = 2
            Me.MetroTabPanel2.Visible = False
            Me.MetroAppButton1.AutoExpandOnClick = True
            Me.MetroAppButton1.CanCustomize = False
            size2 = New Size(&H10, &H10)
            Me.MetroAppButton1.ImageFixedSize = size2
            Me.MetroAppButton1.ImagePaddingHorizontal = 0
            Me.MetroAppButton1.ImagePaddingVertical = 0
            Me.MetroAppButton1.Name = "MetroAppButton1"
            Me.MetroAppButton1.ShowSubItems = False
            Me.MetroAppButton1.Text = "&File"
            Me.MetroAppButton1.Visible = False
            Me.MetroTabItem1.Checked = True
            Me.MetroTabItem1.Name = "MetroTabItem1"
            Me.MetroTabItem1.Panel = Me.MetroTabPanel1
            Me.MetroTabItem1.Text = "File Uploads"
            Me.MetroTabItem2.Name = "MetroTabItem2"
            Me.MetroTabItem2.Panel = Me.MetroTabPanel2
            Me.MetroTabItem2.Text = "&VIEW"
            Me.MetroTabItem2.Visible = False
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.Text = "ButtonItem1"
            Me.QatCustomizeItem1.BeginGroup = True
            Me.QatCustomizeItem1.Name = "QatCustomizeItem1"
            Me.StyleManager1.ManagerStyle = eStyle.Metro
            Dim parameters2 As New MetroColorGeneratorParameters(Color.White, Color.FromArgb(&HFF, &HA3, &H1A))
            Me.StyleManager1.MetroColorParameters = parameters2
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            size2 = New Size(&H1F1, &H144)
            Me.ClientSize = size2
            Me.Controls.Add(Me.MetroShell1)
            Me.Name = "frmAutoUpload"
            Me.Text = "frmAutoUpload"
            Me.MetroShell1.ResumeLayout(False)
            Me.MetroShell1.PerformLayout
            Me.ResumeLayout(False)
        End Sub

        Private Sub JobComplete(ByVal Status As Boolean)
            Dim msg As String = Nothing
            If Status Then
                msg = "Job completed without error"
                Logging.AddLogEntry(Me, msg, EventLogEntryType.Information, 2)
            ElseIf Not Status Then
                msg = "Job completed with errors"
                Logging.AddLogEntry(Me, msg, EventLogEntryType.Error, 0)
            End If
            If Not Status Then
                Interaction.MsgBox(msg, MsgBoxStyle.ApplicationModal, Nothing)
            End If
            Me.CloseForm
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

        Friend Overridable Property MetroTabPanel2 As MetroTabPanel
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabPanel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabPanel)
                Me._MetroTabPanel2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MetroAppButton1 As MetroAppButton
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroAppButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroAppButton)
                Me._MetroAppButton1 = WithEventsValue
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

        Friend Overridable Property MetroTabItem2 As MetroTabItem
            <DebuggerNonUserCode> _
            Get
                Return Me._MetroTabItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As MetroTabItem)
                Me._MetroTabItem2 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property ButtonItem1 As ButtonItem
            <DebuggerNonUserCode> _
            Get
                Return Me._ButtonItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As ButtonItem)
                Me._ButtonItem1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property QatCustomizeItem1 As QatCustomizeItem
            <DebuggerNonUserCode> _
            Get
                Return Me._QatCustomizeItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As QatCustomizeItem)
                Me._QatCustomizeItem1 = WithEventsValue
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

        Public Property HideForm As Boolean
            Get
                Return Me._HideForm
            End Get
            Set(ByVal value As Boolean)
                Me._HideForm = value
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("MetroShell1")> _
        Private _MetroShell1 As MetroShell
        <AccessedThroughProperty("MetroTabPanel1")> _
        Private _MetroTabPanel1 As MetroTabPanel
        <AccessedThroughProperty("MetroTabPanel2")> _
        Private _MetroTabPanel2 As MetroTabPanel
        <AccessedThroughProperty("MetroAppButton1")> _
        Private _MetroAppButton1 As MetroAppButton
        <AccessedThroughProperty("MetroTabItem1")> _
        Private _MetroTabItem1 As MetroTabItem
        <AccessedThroughProperty("MetroTabItem2")> _
        Private _MetroTabItem2 As MetroTabItem
        <AccessedThroughProperty("ButtonItem1")> _
        Private _ButtonItem1 As ButtonItem
        <AccessedThroughProperty("QatCustomizeItem1")> _
        Private _QatCustomizeItem1 As QatCustomizeItem
        <AccessedThroughProperty("StyleManager1")> _
        Private _StyleManager1 As StyleManager
        Private _ctrlUpload As ctrlUploadFiles
        Private _FileDir As String
        Private _DestinationSite As TestSites
        Private _HideForm As Boolean

        ' Nested Types
        Private Delegate Sub FRMClose()
    End Class
End Namespace

