Imports DataMatrix.net
Imports FUEL
Imports FUEL.My
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Text

Namespace FUEL.FS
    <StandardModule> _
    Public NotInheritable Class Misc
        ' Methods
        Private Shared Function AddTextToBarcode(ByVal bcdText As String, ByVal OriginalImage As Bitmap, ByVal TransParentBackground As Boolean) As Bitmap
            Dim brush As Brush = Nothing
            brush = If(TransParentBackground, Brushes.White, Brushes.Snow)
            Dim font As New Font("Courier New", 24!)
            Dim text As String = bcdText
            Dim ef As SizeF = Graphics.FromImage(OriginalImage).MeasureString([text], font)
            Dim image As New Bitmap(CInt(Math.Round(CDbl(((OriginalImage.Width + ef.Width) + 12!)))), (OriginalImage.Height + 12), PixelFormat.Format24bppRgb)
            Dim graphics2 As Graphics = Graphics.FromImage(image)
            Dim objA As Graphics = graphics2
            Try 
                graphics2.SmoothingMode = SmoothingMode.AntiAlias
                Dim rect As New RectangleF(-1!, -1!, CSng((image.Width + 2)), CSng((image.Height + 2)))
                graphics2.FillRectangle(brush, rect)
                Dim rectangle As New Rectangle(6, 6, image.Width, image.Height)
                graphics2.DrawImageUnscaled(OriginalImage, rectangle)
                rect = New RectangleF(CSng((OriginalImage.Width + 10)), 0!, CSng(image.Width), CSng(image.Height))
                graphics2.DrawString([text], font, Brushes.Red, rect)
            Finally
                If Not Object.ReferenceEquals(objA, Nothing) Then
                    objA.Dispose
                End If
            End Try
            Return image
        End Function

        Public Shared Sub CheckForDAQDrivers()
            Dim str As String = Path.Combine(New FileInfo(Assembly.GetExecutingAssembly.Location).DirectoryName, "LaunchNIDaqInstall.exe")
            Dim process As New Process
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.StartInfo.FileName = str
            process.Start
            process.WaitForExit
        End Sub

        Public Shared Sub CheckForUpdate(ByVal UpdateType As CheckType)
            modCheckForUpdates.CheckForUpdate(CheckType.FS)
        End Sub

        Private Shared Function ConvertByteArrayToString(ByVal byteArray As Byte()) As String
            Return Encoding.UTF8.GetString(byteArray)
        End Function

        Public Shared Sub Create2dBarcode(ByVal PSID As String, ByVal PrinterSerialNum As String, ByVal OutputPath As String, ByVal TransParentBackground As Boolean)
            FileSystem.SetPath(Path.GetDirectoryName(OutputPath))
            Dim color As New Color
            color = If(TransParentBackground, Color.White, Color.Snow)
            Dim options As New DmtxImageEncoderOptions With { _
                .ModuleSize = 9, _
                .BackColor = color, _
                .MarginSize = 0, _
                .ForeColor = Color.Black _
            }
            Dim strArray As String() = New String() { PSID, ChrW(13) & ChrW(10), PrinterSerialNum, ChrW(13) & ChrW(10), Conversions.ToString(DateAndTime.Now), ChrW(13) & ChrW(10) & "FUEL: ", TestInformation.FuelRev }
            Misc.AddTextToBarcode(String.Concat(strArray), New DmtxImageEncoder().EncodeImage(PSID, options), TransParentBackground).Save(OutputPath, ImageFormat.Bmp)
        End Sub

        Public Shared Sub CreateBMPFromString(ByVal [Text] As String, ByVal OutputPath As String, ByVal TransParentBackground As Boolean)
            Dim brush As Brush = Nothing
            brush = If(TransParentBackground, Brushes.White, Brushes.Snow)
            Dim font As New Font("Arial", 20!)
            Dim ef As SizeF = Graphics.FromImage(New Bitmap(1, 1, PixelFormat.Format24bppRgb)).MeasureString([Text], font)
            Dim image As New Bitmap(CInt(Math.Round(CDbl(ef.Width))), CInt(Math.Round(CDbl(ef.Height))), PixelFormat.Format24bppRgb)
            Dim graphics As Graphics = Graphics.FromImage(image)
            Dim objA As Graphics = graphics
            Try 
                Dim rect As New Rectangle(-1, -1, CInt(Math.Round(CDbl((ef.Width + 2!)))), CInt(Math.Round(CDbl((ef.Height + 2!)))))
                graphics.FillRectangle(brush, rect)
                rect = New Rectangle(1, 1, CInt(Math.Round(CDbl((ef.Width + 2!)))), CInt(Math.Round(CDbl((ef.Height + 2!)))))
                graphics.DrawString([Text], font, Brushes.Red, rect)
            Finally
                If Not Object.ReferenceEquals(objA, Nothing) Then
                    objA.Dispose
                End If
            End Try
            image.Save(OutputPath)
        End Sub

        Public Shared Sub CreateQRCode(ByVal PSID As String, ByVal PrinterSerialNum As String, ByVal OutputPath As String)
            Misc.CreateQRCode(PSID, PrinterSerialNum, OutputPath, 4, 2, False)
        End Sub

        Public Shared Sub CreateQRCode(ByVal PSID As String, ByVal PrinterSerialNum As String, ByVal OutputPath As String, ByVal Scale As Integer, ByVal ErrorCorrection As Integer, ByVal TransParentBackground As Boolean)
            FileSystem.SetPath(Path.GetDirectoryName(OutputPath))
            Dim color As New Color
            color = If(TransParentBackground, Color.White, Color.Snow)
            Dim originalImage As Bitmap = New QRCodeEncoder() With { _
                .QRCodeErrorCorrect = DirectCast(ErrorCorrection, ERROR_CORRECTION), _
                .QRCodeScale = Scale, _
                .QRCodeEncodeMode = ENCODE_MODE.ALPHA_NUMERIC, _
                .QRCodeBackgroundColor = color _
            }.Encode(PSID)
            originalImage.SetPixel(1, 1, Color.Red)
            Dim strArray As String() = New String() { PSID, ChrW(13) & ChrW(10), PrinterSerialNum, ChrW(13) & ChrW(10), Conversions.ToString(DateAndTime.Now), ChrW(13) & ChrW(10) & "FUEL: ", TestInformation.FuelRev }
            Misc.AddTextToBarcode(String.Concat(strArray), originalImage, TransParentBackground).Save(OutputPath, ImageFormat.Bmp)
        End Sub

        Public Shared Function GenerateFUELCompatibleFileName(ByVal Product As String, ByVal DataType As String, ByVal ValidDuration As FileType, ByVal FileExtension As String) As Object
            Return Misc.GenerateFUELCompatibleFileName(Product, DataType, ValidDuration, FileExtension, Nothing)
        End Function

        Public Shared Function GenerateFUELCompatibleFileName(ByVal Product As String, ByVal DataType As String, ByVal ValidDuration As FileType, ByVal FileExtension As String, ByVal ExtraInfo As String) As Object
            Dim right As String = Strings.Replace(Conversions.ToString(DateAndTime.Now.Date), "/", "-", 1, -1, CompareMethod.Binary)
            If (ValidDuration = FileType.Monthly) Then
                right = Strings.Replace((Conversions.ToString(DateAndTime.Now.Month) & "-" & Conversions.ToString(DateAndTime.Now.Year)), "/", "-", 1, -1, CompareMethod.Binary)
            End If
            If Not FileExtension.StartsWith(".") Then
                FileExtension = ("." & FileExtension)
            End If
            Dim str As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataType & "_") & Product & "_"), Misc.GetComputerName(True)), "_"), right))
            If (ExtraInfo <> Nothing) Then
                str = (str & "_" & ExtraInfo)
            End If
            Return (str & FileExtension)
        End Function

        Public Shared Function GetComputerName() As Object
            Return Misc.GetComputerName(False)
        End Function

        Friend Shared Function GetComputerName(ByVal ForFUELCompatFileName As Boolean) As Object
            Return If(ForFUELCompatFileName, MyProject.Computer.Name.Replace("_", "-"), MyProject.Computer.Name)
        End Function

        Public Shared Function GetMediaSize(ByVal File As String) As Integer
            FileSystem.SetPath(File, FilePurpose.ForReading)
            Dim array As Byte() = MyProject.Computer.FileSystem.ReadAllBytes(File)
            Dim flag As Boolean = False
            Dim strArray As String() = New String(1  - 1) {}
            Dim num6 As Long = Information.UBound(array, 1)
            Dim num3 As Long = 0
            Do While True
                Dim num8 As Long = num6
                If (num3 > num8) Then
                    Exit Do
                End If
                Dim flag3 As Boolean = (array(CInt(num3)) = &H26)
                If (flag3 AndAlso (array(CInt((num3 + 1))) = &H6C)) Then
                    Dim flag2 As Boolean = False
                    Dim num4 As Long = num3
                    Do While True
                        Dim buffer2 As Byte()
                        If Not (Not flag2 And (num4 < Information.UBound(array, 1))) Then
                            Exit Do
                        End If
                        If (strArray(0) = Nothing) Then
                            buffer2 = New Byte() { array(CInt(num4)) }
                            strArray(0) = Misc.ConvertByteArrayToString(buffer2)
                        Else
                            strArray = DirectCast(Utils.CopyArray(DirectCast(strArray, Array), New String(((Information.UBound(strArray, 1) + 1) + 1)  - 1) {}), String())
                            buffer2 = New Byte() { array(CInt(num4)) }
                            strArray(Information.UBound(strArray, 1)) = Misc.ConvertByteArrayToString(buffer2)
                        End If
                        buffer2 = New Byte() { array(CInt(num4)) }
                        If (Misc.ConvertByteArrayToString(buffer2).ToLower <> "a") Then
                            buffer2 = New Byte() { array(CInt(num4)) }
                            If (Misc.ConvertByteArrayToString(buffer2) = ChrW(27)) Then
                                flag2 = True
                                flag = False
                                strArray = New String(1  - 1) {}
                            End If
                            num4 = (num4 + 1)
                        Else
                            flag = True
                            flag2 = True
                            Exit Do
                        End If
                    Loop
                End If
                num3 = (num3 + 1)
            Loop
            Dim num2 As Integer = -100
            If flag Then
                Dim expression As String = Nothing
                Dim num7 As Integer = (Information.UBound(strArray, 1) - 1)
                Dim index As Integer = 2
                Do While True
                    Dim num9 As Integer = num7
                    If (index > num9) Then
                        If Versioned.IsNumeric(expression) Then
                            num2 = Conversions.ToInteger(expression)
                        End If
                        Exit Do
                    End If
                    expression = (expression & strArray(index))
                    index += 1
                Loop
            End If
            Return num2
        End Function

        Public Shared Function ValidateSecurePropertyKey(ByVal Key As String) As Boolean
            Return Misc.ValidateSecurePropertyKey(Key, False, False)
        End Function

        Public Shared Function ValidateSecurePropertyKey(ByVal Key As String, ByVal MsgExpired As Boolean, ByVal ThrowOnExpired As Boolean) As Boolean
            Dim keyIsValid As Boolean
            If (Key = Nothing) Then
                If (MsgExpired Or ThrowOnExpired) Then
                    Interaction.MsgBox("Key not provided, and thus is not valid.", MsgBoxStyle.Critical, Nothing)
                End If
                keyIsValid = False
            Else
                Dim key As New clsSecurePropertyKey(Key)
                If ((MsgExpired Or ThrowOnExpired) AndAlso Not key.KeyIsValid) Then
                    Dim message As String = ("The security key provided expired on " & Conversions.ToString(key.KeyExpirationDate.Date) & " and is no longer valid")
                    If ThrowOnExpired Then
                        Throw New Exception(message)
                    End If
                    If MsgExpired Then
                        Interaction.MsgBox(message, MsgBoxStyle.Critical, Nothing)
                    End If
                End If
                keyIsValid = key.KeyIsValid
            End If
            Return keyIsValid
        End Function

    End Class
End Namespace

