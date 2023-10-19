Imports FUEL.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text

Namespace FUEL
    Public Class DataLogger
        ' Nested Types
        Public Class PSTDebugLog
            ' Methods
            Public Sub New(ByVal PSTData As PST, ByVal OutputDirectory As String, ByVal FileType As LogType)
                Me._PSTData = PSTData
                Me._LogType = FileType
                Me.OutputFileName = OutputDirectory
                Me.WriteLog
            End Sub

            Private Function DetermineRunNumber(ByVal cuID As Long) As Integer
                Return 0
            End Function

            Private Sub WriteLog()
                Dim num5 As Integer
                Dim builder As New StringBuilder
                If (Me._LogType = LogType.Black) Then
                    Dim num3 As Integer = (Me._PSTData.PTraceBlack.Count - 1)
                    Dim num As Integer = 0
                    Do While True
                        num5 = num3
                        If (num > num5) Then
                            Exit Do
                        End If
                        Dim str2 As String = (Conversions.ToString(Me._PSTData.PTraceBlack(num).X) & ChrW(9) & Conversions.ToString(Me._PSTData.PTraceBlack(num).Y))
                        builder.Append(str2).AppendLine
                        num += 1
                    Loop
                Else
                    Dim num4 As Integer = (Me._PSTData.PTraceColor.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        num5 = num4
                        If (num2 > num5) Then
                            Exit Do
                        End If
                        Dim str3 As String = (Conversions.ToString(Me._PSTData.PTraceColor(num2).X) & ChrW(9) & Conversions.ToString(Me._PSTData.PTraceColor(num2).Y))
                        builder.Append(str3).AppendLine
                        num2 += 1
                    Loop
                End If
                Dim text As String = builder.ToString
                MyProject.Computer.FileSystem.WriteAllText(Me.OutputFileName, [text], True)
            End Sub


            ' Properties
            Private Property _PSTData As PST
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PSTData
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As PST)
                    Me.__PSTData = AutoPropertyValue
                End Set
            End Property

            Private Property _OutputFileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__OutputFileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__OutputFileName = AutoPropertyValue
                End Set
            End Property

            Private Property _RunNumber As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__RunNumber
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__RunNumber = AutoPropertyValue
                End Set
            End Property

            Private Property _LogType As LogType
                <DebuggerNonUserCode> _
                Get
                    Return Me.__LogType
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As LogType)
                    Me.__LogType = AutoPropertyValue
                End Set
            End Property

            Public Property OutputFileName As String
                Get
                    Return Me._OutputFileName
                End Get
                Set(ByVal value As String)
                    Dim directoryName As String = Path.GetDirectoryName(value)
                    Try 
                        If Not MyProject.Computer.FileSystem.DirectoryExists(directoryName) Then
                            MyProject.Computer.FileSystem.CreateDirectory(directoryName)
                        End If
                        Dim expression As String = Nothing
                        expression = If((Me._LogType <> LogType.Black), "PST-C-*.txt", "PST-K-*.txt")
                        Dim onlys As ReadOnlyCollection(Of String) = MyProject.Computer.FileSystem.GetFiles(directoryName, SearchOption.SearchTopLevelOnly, New String() { expression })
                        Dim str3 As String = Path.Combine(directoryName, Strings.Replace(expression, "*", Conversions.ToString(onlys.Count), 1, -1, CompareMethod.Binary))
                        Me._OutputFileName = str3
                    Catch exception1 As Exception
                        Dim ex As Exception = exception1
                        ProjectData.SetProjectError(ex)
                        Dim exception As Exception = ex
                        Throw New ApplicationException(("Unable to create folder for output file." & ChrW(13) & ChrW(10) & "Path: " & directoryName))
                    End Try
                End Set
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PSTData As PST
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __OutputFileName As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __RunNumber As Integer
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __LogType As LogType

            ' Nested Types
            Public Enum LogType
                ' Fields
                Black = 0
                Color = 1
            End Enum
        End Class

        Public Class PSTLog
            ' Methods
            Public Sub New(ByVal PSTData As PST, ByVal OutputFileName As String, ByVal SummaryFileName As String, ByVal SpecFileName As String)
                Me._PSTData = PSTData
                Me._OutputFileName = OutputFileName
                Me._SummaryFileName = SummaryFileName
                Me._SpecFileName = SpecFileName
                Me._RunNumber = Me.DetermineRunNumber(Me._PSTData.PrinterInfo.SerialNum)
                Me.WriteLog
                Me.WriteSummary
                Me.WriteSpecFile
            End Sub

            Public Sub New(ByVal PSTData As PST, ByVal OutputFileName As String, ByVal SummaryFileName As String, ByVal SpecFileName As String, ByVal AddFailuretoFailSummary As Boolean)
                Me._PSTData = PSTData
                Me._OutputFileName = OutputFileName
                Me._SummaryFileName = SummaryFileName
                Me._SpecFileName = SpecFileName
                Me._RunNumber = Me.DetermineRunNumber(Me._PSTData.PrinterInfo.SerialNum)
                Me.WriteLog
                Me.WriteSummary
                Me.WriteSpecFile
                If AddFailuretoFailSummary Then
                    Me._SummaryFileName = Me._SummaryFileName.Replace(".csv", "-FAILED.csv")
                    Me.WriteSummary
                End If
            End Sub

            Private Function DetermineRunNumber(ByVal cuSerialNum As String) As Integer
                Dim num As Integer
                If Not MyProject.Computer.FileSystem.FileExists(Me._SummaryFileName) Then
                    num = 1
                Else
                    Dim strArray2 As String()
                    Try 
                        strArray2 = Strings.Split(MyProject.Computer.FileSystem.ReadAllText(Me._SummaryFileName), ChrW(13) & ChrW(10), -1, CompareMethod.Binary)
                    Catch exception1 As Exception
                        Dim ex As Exception = exception1
                        ProjectData.SetProjectError(ex)
                        Interaction.MsgBox(("Unable to open the Summary file" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & ex.ToString), DirectCast(Conversions.ToInteger(ChrW(13)), MsgBoxStyle), Nothing)
                        num = -1
                        ProjectData.ClearProjectError
                        Return num
                    End Try
                    Dim array As String() = Nothing
                    Dim num4 As Integer = Information.UBound(strArray2, 1)
                    Dim index As Integer = 0
                    Do While True
                        Dim num5 As Integer = num4
                        If (index > num5) Then
                            Dim num2 As Integer = 0
                            num2 = If((Not array Is Nothing), If((Array.IndexOf(Of String)(array, cuSerialNum) <> -1), Enumerable.Count(Of String)(array), (Enumerable.Count(Of String)(array) + 1)), 1)
                            num = num2
                            Exit Do
                        End If
                        Dim strArray3 As String() = Strings.Split(strArray2(index), ",", -1, CompareMethod.Binary)
                        If (strArray3(0) = cuSerialNum) Then
                            If (array Is Nothing) Then
                                array = DirectCast(Utils.CopyArray(DirectCast(array, Array), New String(1  - 1) {}), String())
                                array(0) = strArray3(1)
                            End If
                            If ((Array.IndexOf(Of String)(array, strArray3(1)) = -1) And (strArray3(0) <> "")) Then
                                array = DirectCast(Utils.CopyArray(DirectCast(array, Array), New String(((Information.UBound(array, 1) + 1) + 1)  - 1) {}), String())
                                array(Information.UBound(array, 1)) = strArray3(1)
                            End If
                        End If
                        index += 1
                    Loop
                End If
                Return num
            End Function

            Private Sub WriteLog()
                Logging.AddLogEntry(Me, "WriteLog: Starting", EventLogEntryType.Information, 4)
                Dim builder As New StringBuilder
                If Not MyProject.Computer.FileSystem.FileExists(Me._OutputFileName) Then
                    builder.Append("Serial Number,Test ID,Run Number,Date,Time,Channel,Sample Time,Sample Pressure").AppendLine
                End If
                Dim num3 As Integer = (Me._PSTData.PTraceBlack.Count - 1)
                Dim num As Integer = 0
                Do While True
                    Dim strArray As String()
                    Dim num5 As Integer = num3
                    If (num > num5) Then
                        Dim num4 As Integer = (Me._PSTData.PTraceColor.Count - 1)
                        Dim num2 As Integer = 0
                        Do While True
                            num5 = num4
                            If (num2 > num5) Then
                                Dim text As String = builder.ToString
                                MyProject.Computer.FileSystem.WriteAllText(Me._OutputFileName, [text], True)
                                Logging.AddLogEntry(Me, "WriteLog: Complete", EventLogEntryType.Information, 4)
                                Return
                            End If
                            strArray = New String() { Me._PSTData.PrinterInfo.SerialNum, ",", Me._PSTData.TestID, ",", Conversions.ToString(Me._RunNumber), ",", Me._PSTData.TestInfo.TestDate, ",", Me._PSTData.TestInfo.TestTime }
                            strArray(9) = ",Color,"
                            strArray(10) = Conversions.ToString(Me._PSTData.PTraceColor(num2).X)
                            strArray(11) = ","
                            strArray(12) = Conversions.ToString(Me._PSTData.PTraceColor(num2).Y)
                            Dim str4 As String = String.Concat(strArray)
                            builder.Append(str4).AppendLine
                            num2 += 1
                        Loop
                    End If
                    strArray = New String() { Me._PSTData.PrinterInfo.SerialNum, ",", Me._PSTData.TestID, ",", Conversions.ToString(Me._RunNumber), ",", Me._PSTData.TestInfo.TestDate, ",", Me._PSTData.TestInfo.TestTime }
                    strArray(9) = ",Black,"
                    strArray(10) = Conversions.ToString(Me._PSTData.PTraceBlack(num).X)
                    strArray(11) = ","
                    strArray(12) = Conversions.ToString(Me._PSTData.PTraceBlack(num).Y)
                    Dim str3 As String = String.Concat(strArray)
                    builder.Append(str3).AppendLine
                    num += 1
                Loop
            End Sub

            Private Sub WriteSpecFile()
                Logging.AddLogEntry(Me, "WriteSpecFile: Starting", EventLogEntryType.Information, 4)
                Serializer.SerializeMe(Me._PSTData, Me._SpecFileName)
                Logging.AddLogEntry(Me, "WriteSpecFile: Complete", EventLogEntryType.Information, 4)
            End Sub

            Private Sub WriteSummary()
                Dim num6 As Integer
                Logging.AddLogEntry(Me, "WriteSummary: Starting", EventLogEntryType.Information, 4)
                Dim text As String = Nothing
                If Not MyProject.Computer.FileSystem.FileExists(Me._SummaryFileName) Then
                    [text] = "SERIAL_NUM,Test ID, Test_Station_Type,RunNumber,Script_Rev,Script_Product,FUEL_Rev,FW_REV,TEST_DATE,TEST_TIME,Pg_Cnt,Overall_Test_Results,AutoRetestForVentDP, PreviousTestID,K_MAX_PRESSURE_Results,K_MAX_PRESSURE_Val,C_MAX_PRESSURE_Results,C_MAX_PRESSURE_Val,K_LEAK_Results,K_LEAK_Val,K_VENT_Results,K_VENTDeltaP_Val,K_DERIVCNT_Results,K_DERIVCNT_Val,K_TubeEvacPressure_Results,K_TubeEvacPressure_Val,C_LEAK_Results,C_LEAK_Val,C_VENT_Results,C_VENTDeltaP_Val,C_DERIVCNT_Results,C_DERIVCNT_Val,C_TubeEvacPressure_Results,C_TubeEvacPressure_Val,KDryPHA_Results,K_INSTALL_PRESSURE_Val,CDryPHA_Results,C_INSTALL_PRESSURE_Val,Data_File,Spec_File"
                    If (Me._PSTData.MechChecks.Count > 0) Then
                        [text] = ([text] & ",")
                        Dim num3 As Integer = (Me._PSTData.MechChecks.Count - 1)
                        Dim num As Integer = 0
                        Do While True
                            num6 = num3
                            If (num > num6) Then
                                Exit Do
                            End If
                            [text] = (([text] & Me._PSTData.MechChecks(num).Name & "_Results,") & Me._PSTData.MechChecks(num).Name & "_Val")
                            If (num < (Me._PSTData.MechChecks.Count - 1)) Then
                                [text] = ([text] & ",")
                            End If
                            num += 1
                        Loop
                    End If
                    [text] = ([text] & ChrW(13) & ChrW(10))
                End If
                [text] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(((((((((((((((((((((((((((((((((((([text] & Me._PSTData.PrinterInfo.SerialNum & ",") & Me._PSTData.TestID & ",") & Me._PSTData.TestInfo.TestStationType.ToString & ",") & Conversions.ToString(Me._RunNumber) & ",") & Me._PSTData.TestInfo.ScriptRev & ",") & Me._PSTData.TestInfo.ScriptProduct & ",") & TestInformation.FuelRev & ",") & Me._PSTData.PrinterInfo.FWRev & ",") & Me._PSTData.TestInfo.TestDate & ",") & Me._PSTData.TestInfo.TestTime & ",") & Conversions.ToString(Me._PSTData.PrinterInfo.EnginePgCnt) & ",") & Conversions.ToString(Me._PSTData.OverallTestStatus) & ",") & Me._PSTData.RetestForVentDP.ToString & ",") & Me._PSTData.PreviousTestID & ",") & Conversions.ToString(Me._PSTData.KResults.PF.MaxPressure) & ",") & Conversions.ToString(Me._PSTData.KResults.Val.MaxPressure) & ",") & Conversions.ToString(Me._PSTData.CResults.PF.MaxPressure) & ",") & Conversions.ToString(Me._PSTData.CResults.Val.MaxPressure) & ",") & Conversions.ToString(Me._PSTData.KResults.PF.Leak) & ",") & Conversions.ToString(Me._PSTData.KResults.Val.Leak) & ",") & Conversions.ToString(Me._PSTData.KResults.PF.VentDeltaPMin) & ",") & Conversions.ToString(Me._PSTData.KResults.Val.VentDeltaP) & ",") & Conversions.ToString(Me._PSTData.KResults.PF.DerivCnt) & ",") & Conversions.ToString(Me._PSTData.KResults.Val.DerivCnt) & ",") & Conversions.ToString(Me._PSTData.KResults.PF.TubeEvacDeltaPressure) & ",") & Conversions.ToString(Me._PSTData.KResults.Val.TubeEvacDeltaPressure) & ",") & Conversions.ToString(Me._PSTData.CResults.PF.Leak) & ",") & Conversions.ToString(Me._PSTData.CResults.Val.Leak) & ",") & Conversions.ToString(Me._PSTData.CResults.PF.VentDeltaPMin) & ",") & Conversions.ToString(Me._PSTData.CResults.Val.VentDeltaP) & ",") & Conversions.ToString(Me._PSTData.CResults.PF.DerivCnt) & ",") & Conversions.ToString(Me._PSTData.CResults.Val.DerivCnt) & ",") & Conversions.ToString(Me._PSTData.CResults.PF.TubeEvacDeltaPressure) & ",") & Conversions.ToString(Me._PSTData.CResults.Val.TubeEvacDeltaPressure) & ",") & Conversions.ToString(Me._PSTData.KResults.PF.DryPHA) & ","), Me._PSTData.BlackInstallPressure), ","), Me._PSTData.CResults.PF.DryPHA), ","), Me._PSTData.ColorInstallPressure), ","), Path.GetFileName(Me._OutputFileName)), ","), Path.GetFileName(Me._SpecFileName)))
                If (Me._PSTData.MechChecks.Count > 0) Then
                    [text] = ([text] & ",")
                    Dim num4 As Integer = (Me._PSTData.MechChecks.Count - 1)
                    Dim num2 As Integer = 0
                    Do While True
                        num6 = num4
                        If (num2 > num6) Then
                            Exit Do
                        End If
                        [text] = (([text] & Me._PSTData.MechChecks(num2).Results.ToString & ",") & Me._PSTData.MechChecks(num2).Value.ToString)
                        If (num2 < (Me._PSTData.MechChecks.Count - 1)) Then
                            [text] = ([text] & ",")
                        End If
                        num2 += 1
                    Loop
                End If
                [text] = ([text] & ChrW(13) & ChrW(10))
                MyProject.Computer.FileSystem.WriteAllText(Me._SummaryFileName, [text], True)
                Logging.AddLogEntry(Me, "WriteSummary: Starting", EventLogEntryType.Information, 4)
            End Sub


            ' Properties
            Private Property _PSTData As PST
                <DebuggerNonUserCode> _
                Get
                    Return Me.__PSTData
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As PST)
                    Me.__PSTData = AutoPropertyValue
                End Set
            End Property

            Private Property _OutputFileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__OutputFileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__OutputFileName = AutoPropertyValue
                End Set
            End Property

            Private Property _SummaryFileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SummaryFileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__SummaryFileName = AutoPropertyValue
                End Set
            End Property

            Private Property _SpecFileName As String
                <DebuggerNonUserCode> _
                Get
                    Return Me.__SpecFileName
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As String)
                    Me.__SpecFileName = AutoPropertyValue
                End Set
            End Property

            Private Property _RunNumber As Integer
                <DebuggerNonUserCode> _
                Get
                    Return Me.__RunNumber
                End Get
                <DebuggerNonUserCode> _
                Set(ByVal AutoPropertyValue As Integer)
                    Me.__RunNumber = AutoPropertyValue
                End Set
            End Property

            Friend ReadOnly Property RunNumber As Integer
                Get
                    Return Me._RunNumber
                End Get
            End Property


            ' Fields
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __PSTData As PST
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __OutputFileName As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SummaryFileName As String
            <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
            Private __SpecFileName As String
            <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private __RunNumber As Integer
        End Class
    End Class
End Namespace

