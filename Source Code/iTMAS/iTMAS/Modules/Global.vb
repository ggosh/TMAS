Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Module mdlGlobal

    Public objConn As New SqlConnection
    Public gStrProvider As String = "MSSQL"
    Public gStrConnectString As String = AppSettings("TMConnectionString")

    Public gUObj As Int16 = 1
    Public gUser_ID As Int64
    Public gUserName As String
    Public gUserType As String
    Public gUserDescription As String

    Public gCoId As String = "1"
    Public gCoType As String        'Prop/paRtner/pVt/Ltd/Indiv
    Public gCoSht As String
    Public gCoName As String
    Public gCoAddr As String
    Public gCoBuTy As String        'Tran
    Public gProduct As Boolean
    Public gStock As Boolean
    Public gPurch As Boolean
    Public gAcc As Boolean
    Public gCashPty As Boolean
    Public gDtnB4Ldg As Boolean
    Public gAcEffctB4Dlv As Boolean 'effct b4 deliv
    Public gDrShrtge2Drv As Boolean
    Public gDtn2ShrMktTL As Boolean
    Public gShrtgeIncldBill As Boolean
    Public gMaxChlinBill As Short
    Public gVoNoGen As Boolean
    Public gPrintVouch As Boolean

    Public gAcYr As String
    Public gAcBrn As String
    Public gAcBrId As Integer
    Public gYrStart As Date
    Public gYrEnd As Date
    Public gYrCd As String

    Public lPlac As Boolean = False
    Public lCsgr As Boolean = False
    Public lCsge As Boolean = False
    Public lBrn As Boolean = False
    Public lTL As Boolean = False
    Public lAcc As Boolean = False
    Public lGrp As Boolean = False
    Public lSub As Boolean = False
    Public lSGr As Boolean = False
    Public lDrv As Boolean = False
    Public lProd As Boolean = False
    Public lRat As Boolean = False

    Public gSrvPc As Single = 12.36

    Public Sub Main()

    End Sub

    Public Function gError_Message(ByVal erroMsg As String, ByVal buttonStyle As Short) As Short
        Dim lresponse As Short
        erroMsg = "                                                                         " + vbCrLf + erroMsg
        lresponse = MsgBox(erroMsg, buttonStyle, "Recon")
        If lresponse = MsgBoxResult.Ok Then
            lresponse = 0
        End If
    End Function

    Public Function NoDbNull(ByVal dbFld As Object, ByVal Deflt As Object) As Object
        If IsDBNull(dbFld) Then
            Return Deflt
        Else
            Return dbFld
        End If
    End Function

    'Public Sub ExportToExcel(ByRef Dataset As DataSet, ByVal OutputFileName As String)
    '    Using SourceDataset As System.Data.DataSet = Dataset
    '        Dim Application As New Excel.Application
    '        Application.SheetsInNewWorkbook = SourceDataset.Tables.Count
    '        Dim wb As Excel.Workbook = Application.Workbooks.Add()
    '        For i As Integer = 0 To SourceDataset.Tables.Count - 1
    '            Dim table As System.Data.DataTable = SourceDataset.Tables(i)
    '            Dim y As Excel.Worksheet = wb.Sheets(i + 1)
    '            y.Name = table.TableName.ToString
    '            Dim rowIndex As Integer
    '            Dim colIndex As Integer
    '            Try
    '                ' Create the headers on the sheet.
    '                For colIndex = 1 To table.Columns.Count
    '                    TryCast(y.Cells(1, colIndex), Excel.Range).Value2 = table.Columns(colIndex - 1).ColumnName
    '                Next
    '                ' Add each row of data to the sheet.
    '                ' The sheet cell row is incremented by one because the first row was used for the header.
    '                Console.WriteLine("Columns Added Starting Data Transfer (" & table.TableName.ToString & ") - " & OutputFileName & ".xls")
    '                For rowIndex = 1 To table.Rows.Count
    '                    For colIndex = 1 To table.Columns.Count
    '                        TryCast(y.Cells(rowIndex + 1, colIndex), Excel.Range).Value2 = table.Rows(rowIndex - 1)(colIndex - 1).ToString()
    '                    Next
    '                Next
    '            Catch ex As System.Runtime.InteropServices.COMException
    '            End Try
    '        Next
    '        wb.SaveAs(OutputFileName & ".xls")
    '        wb.Close()
    '        Application.Quit()
    '        Application = Nothing
    '    End Using
    'End Sub

End Module
