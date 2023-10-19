Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.Reflection

Namespace FUEL
    Public Class ExcelHandler
        ' Methods
        Public Shared Sub CloseWB(ByVal wb As Workbook)
            wb.Close(Missing.Value, Missing.Value, Missing.Value)
        End Sub

        Public Shared Function LoadExcel(ByVal FName As String) As Workbook
            Return New ApplicationClass().get_Workbooks.Open(FName, Missing.Value, True, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value)
        End Function

        Public Shared Function ReadSheet(ByVal WB As Workbook, ByVal SheetNum As Integer) As Object(0 To .,0 To .)
            Return DirectCast(DirectCast(WB.get_Worksheets.get__Default(SheetNum), Worksheet).get_UsedRange.get_Value(DirectCast(10, XlRangeValueDataType)), Object(0 To .,0 To .)(,))
        End Function

    End Class
End Namespace

