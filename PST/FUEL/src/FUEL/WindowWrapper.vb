Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace FUEL
    Friend Class WindowWrapper
        Implements IWin32Window
        ' Methods
        Friend Sub New(ByVal aHandle As IntPtr)
            Me._hwnd = aHandle
        End Sub


        ' Properties
        Private Property _hwnd As IntPtr
            <DebuggerNonUserCode> _
            Get
                Return Me.__hwnd
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As IntPtr)
                Me.__hwnd = AutoPropertyValue
            End Set
        End Property

        Friend ReadOnly Property Handle As IntPtr
            Get
                Return Me._hwnd
            End Get
        End Property

        Friend WriteOnly Property WindowWrapper As IntPtr
            Set(ByVal value As IntPtr)
                Me._hwnd = value
            End Set
        End Property

        Friend ReadOnly Property System.Windows.Forms.IWin32Window.Handle As IntPtr
            Get
                Return Me._hwnd
            End Get
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __hwnd As IntPtr
    End Class
End Namespace

