Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL.BigRed
    Public Class TestVariables
        ' Methods
        Public Sub New()
            Me.AutoDataOnSchedule = False
            Me.PassiveAutoData = False
            Me.UploadDataToGradeBook = False
            Me.TestRunningOutsideOfHPFireWall = False
            Me.CollectDataForEveryPrintJob = True
            Me.SendDataViaEmail = False
            Me.MessagePriority = 3
            Me.ReplacePgNrWithPlotCD = False
            Me.PrintProtocol = "eLIDIL"
            Me.AutomaticeLIDILMode = True
            Me.PCLFileLocation = Nothing
            Me.NozzlePatternLocation = Nothing
            Me.AddCRLFToHeaders = False
        End Sub


        ' Properties
        Public Property AutoDataOnSchedule As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._AutoDataOnSchedule
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._AutoDataOnSchedule = AutoPropertyValue
            End Set
        End Property

        Public Property PassiveAutoData As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._PassiveAutoData
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._PassiveAutoData = AutoPropertyValue
            End Set
        End Property

        Public Property UploadDataToGradeBook As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._UploadDataToGradeBook
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._UploadDataToGradeBook = AutoPropertyValue
            End Set
        End Property

        Public Property TestRunningOutsideOfHPFireWall As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._TestRunningOutsideOfHPFireWall
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._TestRunningOutsideOfHPFireWall = AutoPropertyValue
            End Set
        End Property

        Public Property CollectDataForEveryPrintJob As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._CollectDataForEveryPrintJob
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._CollectDataForEveryPrintJob = AutoPropertyValue
            End Set
        End Property

        Public Property SendDataViaEmail As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._SendDataViaEmail
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._SendDataViaEmail = AutoPropertyValue
            End Set
        End Property

        Public Property MessagePriority As Integer
            <DebuggerNonUserCode> _
            Get
                Return Me._MessagePriority
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Integer)
                Me._MessagePriority = AutoPropertyValue
            End Set
        End Property

        Public Property ReplacePgNrWithPlotCD As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._ReplacePgNrWithPlotCD
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._ReplacePgNrWithPlotCD = AutoPropertyValue
            End Set
        End Property

        Public Property PrintProtocol As String
            <DebuggerNonUserCode> _
            Get
                Return Me._PrintProtocol
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me._PrintProtocol = AutoPropertyValue
            End Set
        End Property

        Public Property AutomaticeLIDILMode As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._AutomaticeLIDILMode
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._AutomaticeLIDILMode = AutoPropertyValue
            End Set
        End Property

        Public Property PCLFileLocation As String
            <DebuggerNonUserCode> _
            Get
                Return Me._PCLFileLocation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me._PCLFileLocation = AutoPropertyValue
            End Set
        End Property

        Public Property NozzlePatternLocation As String
            <DebuggerNonUserCode> _
            Get
                Return Me._NozzlePatternLocation
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me._NozzlePatternLocation = AutoPropertyValue
            End Set
        End Property

        Public Property AddCRLFToHeaders As Boolean
            <DebuggerNonUserCode> _
            Get
                Return Me._AddCRLFToHeaders
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As Boolean)
                Me._AddCRLFToHeaders = AutoPropertyValue
            End Set
        End Property

        Private Property _EmailAddress As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__EmailAddress
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__EmailAddress = AutoPropertyValue
            End Set
        End Property

        Public Property EmailAddress As String
            Get
                Return Me._EmailAddress
            End Get
            Set(ByVal value As String)
                If Not value.Trim.ToLower.EndsWith("@hp.com") Then
                    Throw New ArgumentException("Email address must end with '@hp.com'")
                End If
                Me._EmailAddress = value
            End Set
        End Property

        Public Property GradeBookData As String()
            <DebuggerNonUserCode> _
            Get
                Return Me._GradeBookData
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String())
                Me._GradeBookData = AutoPropertyValue
            End Set
        End Property

        Public Property FooterData As String()
            <DebuggerNonUserCode> _
            Get
                Return Me._FooterData
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String())
                Me._FooterData = AutoPropertyValue
            End Set
        End Property


        ' Fields
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _AutoDataOnSchedule As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _PassiveAutoData As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _UploadDataToGradeBook As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _TestRunningOutsideOfHPFireWall As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _CollectDataForEveryPrintJob As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _SendDataViaEmail As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _MessagePriority As Integer
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _ReplacePgNrWithPlotCD As Boolean
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _PrintProtocol As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _AutomaticeLIDILMode As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _PCLFileLocation As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _NozzlePatternLocation As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _AddCRLFToHeaders As Boolean
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __EmailAddress As String
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private _GradeBookData As String()
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _FooterData As String()
    End Class
End Namespace

