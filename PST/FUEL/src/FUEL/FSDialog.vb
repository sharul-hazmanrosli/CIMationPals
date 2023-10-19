Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace FUEL
    Public Class FSDialog
        ' Methods
        Private Function getOwner() As IntPtr
            Dim ptr As IntPtr
            Try 
                Dim processesByName As Process() = Process.GetProcessesByName("FlexScript")
                ptr = If((processesByName.Length = 0), DirectCast(-1, IntPtr), processesByName(0).MainWindowHandle)
            Catch exception1 As Exception
                Dim ex As Exception = exception1
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                ptr = DirectCast(-1, IntPtr)
                ProjectData.ClearProjectError
            End Try
            Return ptr
        End Function

        Friend Sub Show(ByVal Dialog As Form)
            Dim aHandle As IntPtr = Me.getOwner
            If (aHandle <> DirectCast(-1, IntPtr)) Then
                Dialog.ShowDialog(New WindowWrapper(aHandle))
            Else
                Dialog.ShowDialog
            End If
        End Sub

    End Class
End Namespace

