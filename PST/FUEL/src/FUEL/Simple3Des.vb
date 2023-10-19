Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace FUEL
    Friend NotInheritable Class Simple3Des
        ' Methods
        Public Sub New(ByVal key As String)
            Me.TripleDes.Key = Me.TruncateHash(key, (Me.TripleDes.KeySize / 8))
            Me.TripleDes.IV = Me.TruncateHash("", (Me.TripleDes.BlockSize / 8))
        End Sub

        Public Function DecryptData(ByVal encryptedtext As String) As String
            Dim buffer As Byte() = Convert.FromBase64String(encryptedtext)
            Dim stream2 As New MemoryStream
            Dim stream As New CryptoStream(stream2, Me.TripleDes.CreateDecryptor, CryptoStreamMode.Write)
            stream.Write(buffer, 0, buffer.Length)
            stream.FlushFinalBlock
            Return Encoding.Unicode.GetString(stream2.ToArray)
        End Function

        Public Function EncryptData(ByVal PlainText As String) As String
            Dim bytes As Byte() = Encoding.Unicode.GetBytes(PlainText)
            Dim stream2 As New MemoryStream
            Dim stream As New CryptoStream(stream2, Me.TripleDes.CreateEncryptor, CryptoStreamMode.Write)
            stream.Write(bytes, 0, bytes.Length)
            stream.FlushFinalBlock
            Return Convert.ToBase64String(stream2.ToArray)
        End Function

        Private Function TruncateHash(ByVal Key As String, ByVal Length As Integer) As Byte()
            Return DirectCast(Utils.CopyArray(DirectCast(New SHA256CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(Key)), Array), New Byte(((Length - 1) + 1)  - 1) {}), Byte())
        End Function


        ' Fields
        Private TripleDes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
    End Class
End Namespace

