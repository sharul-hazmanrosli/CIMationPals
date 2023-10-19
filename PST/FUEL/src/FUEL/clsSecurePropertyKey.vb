Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace FUEL
    Public Class clsSecurePropertyKey
        ' Methods
        Protected Friend Sub New()
        End Sub

        Public Sub New(ByVal Key As String)
            Me._DecryptedKey = New Simple3Des("Overlanding123").DecryptData(Key)
            Me._KeyExpirationDate = Me.GetDateFromDecryptedKey(Me._DecryptedKey)
        End Sub

        Private Function GetDateFromDecryptedKey(ByVal strKey As Object) As DateTime
            If Not Versioned.IsNumeric(strKey) Then
                Throw New ArgumentException("Malformed Key")
            End If
            Return New DateTime(Conversions.ToLong(Operators.DivideObject(strKey, 3.1415926535897931)))
        End Function


        ' Properties
        Private Property _DecryptedKey As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__DecryptedKey
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__DecryptedKey = AutoPropertyValue
            End Set
        End Property

        Private Property _KeyExpirationDate As DateTime
            <DebuggerNonUserCode> _
            Get
                Return Me.__KeyExpirationDate
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As DateTime)
                Me.__KeyExpirationDate = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property KeyExpirationDate As DateTime
            Get
                Return Me._KeyExpirationDate
            End Get
        End Property

        Private Property _Key As String
            <DebuggerNonUserCode> _
            Get
                Return Me.__Key
            End Get
            <DebuggerNonUserCode> _
            Set(ByVal AutoPropertyValue As String)
                Me.__Key = AutoPropertyValue
            End Set
        End Property

        Public ReadOnly Property Key As String
            Get
                Return Me._Key
            End Get
        End Property

        Public ReadOnly Property KeyIsValid As Boolean
            Get
                Dim flag As Boolean
                If Not ((DateTime.Compare(Me._KeyExpirationDate.Date, DateAndTime.Now.Date) >= 0) Or (DateTime.Compare(Me._KeyExpirationDate.Date, Conversions.ToDate("06/06/2006").Date) = 0)) Then
                    flag = False
                Else
                    If (DateTime.Compare(Me._KeyExpirationDate, Conversions.ToDate("06/06/2006")) = 0) Then
                        Interaction.MsgBox("666", MsgBoxStyle.ApplicationModal, Nothing)
                    End If
                    flag = True
                End If
                Return flag
            End Get
        End Property


        ' Fields
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __DecryptedKey As String
        <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private __KeyExpirationDate As DateTime
        <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
        Private __Key As String
    End Class
End Namespace

