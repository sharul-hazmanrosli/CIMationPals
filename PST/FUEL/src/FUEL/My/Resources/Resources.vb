Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices

Namespace FUEL.My.Resources
    <DebuggerNonUserCode, StandardModule, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated, HideModuleName> _
    Friend NotInheritable Class Resources
        ' Properties
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend Shared ReadOnly Property ResourceManager As ResourceManager
            Get
                If Object.ReferenceEquals(Resources.resourceMan, Nothing) Then
                    Resources.resourceMan = New ResourceManager("FUEL.Resources", GetType(Resources).Assembly)
                End If
                Return Resources.resourceMan
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend Shared Property Culture As CultureInfo
            Get
                Return Resources.resourceCulture
            End Get
            Set(ByVal Value As CultureInfo)
                Resources.resourceCulture = Value
            End Set
        End Property

        Friend Shared ReadOnly Property Bad_PST_Box As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Bad_PST_Box", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Error_icon As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Error_icon", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Error_icon_sm As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Error_icon_sm", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property FluctuatingPressure As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("FluctuatingPressure", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property frown_sm As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("frown_sm", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Good_or_Tick_icon As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Good_or_Tick_icon", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Good_or_Tick_icon_sm As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Good_or_Tick_icon_sm", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property happy_sm As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("happy_sm", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property idk1 As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("idk1", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property idk2 As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("idk2", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Kinked_Tube_possible As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Kinked_Tube_possible", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property Leak As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("Leak", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property NoPressure As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("NoPressure", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property oh_noes As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("oh noes", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property PinchedVentTube As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("PinchedVentTube", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property VerySmallVentDeltaP As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("VerySmallVentDeltaP", Resources.resourceCulture), Bitmap)
            End Get
        End Property

        Friend Shared ReadOnly Property warning_sm As Bitmap
            Get
                Return DirectCast(Resources.ResourceManager.GetObject("warning_sm", Resources.resourceCulture), Bitmap)
            End Get
        End Property


        ' Fields
        Private Shared resourceMan As ResourceManager
        Private Shared resourceCulture As CultureInfo
    End Class
End Namespace

