Imports DevComponents.DotNetBar.SuperGrid
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
    Public Class ctrlDataGrid
        Inherits UserControl
        ' Methods
        Public Sub New(ByVal dtHistory As DataTable)
            ctrlDataGrid.__ENCAddToList(Me)
            Me.InitializeComponent
            Me.sgcHistory.PrimaryGrid.DataSource = dtHistory
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            SyncLock ctrlDataGrid.__ENCList
                If (ctrlDataGrid.__ENCList.Count = ctrlDataGrid.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (ctrlDataGrid.__ENCList.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        Dim num4 As Integer = num3
                        If (num2 > num4) Then
                            ctrlDataGrid.__ENCList.RemoveRange(index, (ctrlDataGrid.__ENCList.Count - index))
                            ctrlDataGrid.__ENCList.Capacity = ctrlDataGrid.__ENCList.Count
                            Exit Do
                        End If
                        Dim reference As WeakReference = ctrlDataGrid.__ENCList(num2)
                        If reference.IsAlive Then
                            If (num2 <> index) Then
                                ctrlDataGrid.__ENCList(index) = ctrlDataGrid.__ENCList(num2)
                            End If
                            index += 1
                        End If
                        num2 += 1
                    Loop
                End If
                ctrlDataGrid.__ENCList.Add(New WeakReference(value))
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

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.sgcHistory = New SuperGridControl
            Me.SuspendLayout
            Me.sgcHistory.BackColor = Color.White
            Me.sgcHistory.Dock = DockStyle.Fill
            Me.sgcHistory.ForeColor = Color.Black
            Me.sgcHistory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Dim point2 As New Point(0, 0)
            Me.sgcHistory.Location = point2
            Me.sgcHistory.Name = "sgcHistory"
            Me.sgcHistory.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row
            Me.sgcHistory.PrimaryGrid.Title.RowHeaderVisibility = RowHeaderVisibility.PanelControlled
            Dim size2 As New Size(&H204, &H17B)
            Me.sgcHistory.Size = size2
            Me.sgcHistory.TabIndex = 0
            Me.sgcHistory.Text = "SuperGridControl1"
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.Controls.Add(Me.sgcHistory)
            Me.Name = "ctrlDataGrid"
            size2 = New Size(&H204, &H17B)
            Me.Size = size2
            Me.ResumeLayout(False)
        End Sub


        ' Properties
        Friend Overridable Property sgcHistory As SuperGridControl
            <DebuggerNonUserCode> _
            Get
                Return Me._sgcHistory
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As SuperGridControl)
                Me._sgcHistory = WithEventsValue
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private components As IContainer
        <AccessedThroughProperty("sgcHistory")> _
        Private _sgcHistory As SuperGridControl
    End Class
End Namespace

