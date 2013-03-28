Imports System.Data.SqlClient

Public Class clsBill

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetMaxBillNo(ByVal CoID As String, ByVal bType As String, ByVal sDate As Date, _
            ByVal eDate As Date) As String

        Dim prms(4) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_CD"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = bType
        prm.ParameterName = "@Type"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = sDate
        prm.ParameterName = "@sDate"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = eDate
        prm.ParameterName = "@eDate"
        prms(3) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(4) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetMaxBillNo", prms)
        If ds.Tables(0).Rows(0).Item("Bill_No").ToString <> "" Then
            Return ds.Tables(0).Rows(0).Item("Bill_No")
        Else
            Return ""
        End If

    End Function

    Public Function GetBillList(ByVal CoID As String, ByVal sFilt As String) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_CD"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1000
        prm.Value = sFilt
        prm.ParameterName = "@Filt"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(2) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetBillList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetBillChalList(ByVal CoID As String, ByVal sFilt As String) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_CD"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1000
        prm.Value = sFilt
        prm.ParameterName = "@Filt"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(2) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetBillChalList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetBillDetails(ByVal Bill_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Bill_ID
        prm.ParameterName = "@bill_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(1) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetBillDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetBillFromNo(ByVal BillNo As String, ByVal Co_cd As String, ByVal Yr_cd As String) As Int32

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = BillNo
        prm.ParameterName = "@Number"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Co_cd
        prm.ParameterName = "@Co_cd"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 2
        prm.Value = Yr_cd
        prm.ParameterName = "@Yr_cd"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(3) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetBillIDbyNo", prms)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item("Bill_ID")
        End If

    End Function

    Public Function InsertUpdateBill(ByVal Bill_ID As Int32, ByVal Bill_No As String, ByVal Bill_Dt As Date, ByVal bType As String, ByVal Gl_id As Int32, _
        ByVal IAC_id As Int32, ByVal NonTaxbl As Decimal, ByVal Taxbl As Decimal, ByVal LessFrt As Decimal, ByVal freight As Decimal, _
        ByVal Detn As Decimal, ByVal OthName As String, ByVal OthChgs As Decimal, ByVal Total As Decimal, _
        ByVal st_id As Int32, ByVal ServPc As Decimal, ByVal ServTax As Decimal, ByVal Postage As Decimal, _
        ByVal RoundOff As Decimal, ByVal Amount As Decimal, ByVal Ref As String, ByVal LodLoc As String, _
        ByVal Rep_id As Int32, ByVal branch As String, ByVal co_cd As String, ByVal Yr_cd As String) As Object

        Dim prms(27) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Bill_ID
        prm.ParameterName = "@Bill_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = Bill_No
        prm.ParameterName = "@Bill_No"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = Bill_Dt
        prm.ParameterName = "@Bill_Dt"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = bType
        prm.ParameterName = "@Bill_Type"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Gl_id
        prm.ParameterName = "@Gl_id"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = IAC_id
        prm.ParameterName = "@IAC_id"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = NonTaxbl
        prm.ParameterName = "@NonTaxbl"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Taxbl
        prm.ParameterName = "@Taxbl"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = LessFrt
        prm.ParameterName = "@LessFrt"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = freight
        prm.ParameterName = "@freight"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Detn
        prm.ParameterName = "@detention"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = OthName
        prm.ParameterName = "@OthName"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = OthChgs
        prm.ParameterName = "@OthChgs"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Total
        prm.ParameterName = "@Total"
        prms(13) = prm
        prm = Nothing
        ' parameter 15
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = st_id
        prm.ParameterName = "@ST_id"
        prms(14) = prm
        prm = Nothing
        ' parameter 16
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = ServPc
        prm.ParameterName = "@ServPc"
        prms(15) = prm
        prm = Nothing
        ' parameter 17
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = ServTax
        prm.ParameterName = "@ServTax"
        prms(16) = prm
        prm = Nothing
        ' parameter 18
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Postage
        prm.ParameterName = "@Postage"
        prms(17) = prm
        prm = Nothing
        ' parameter 19
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = RoundOff
        prm.ParameterName = "@RoundOff"
        prms(18) = prm
        prm = Nothing
        ' parameter 20
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Amount
        prm.ParameterName = "@Amount"
        prms(19) = prm
        prm = Nothing
        ' parameter 21
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = Ref
        prm.ParameterName = "@Ref"
        prms(20) = prm
        prm = Nothing
        ' parameter 22
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = LodLoc
        prm.ParameterName = "@LodLoc"
        prms(21) = prm
        prm = Nothing
        ' parameter 23
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Rep_id
        prm.ParameterName = "@Rep_id"
        prms(22) = prm
        prm = Nothing
        ' parameter 24
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = branch
        prm.ParameterName = "@branch"
        prms(23) = prm
        prm = Nothing
        ' parameter 25
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(24) = prm
        prm = Nothing
        ' parameter 26
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 2
        prm.Value = Yr_cd
        prm.ParameterName = "@Yr_cd"
        prms(25) = prm
        prm = Nothing
        ' parameter 27
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(26) = prm
        prm = Nothing
        ' parameter 28
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(27) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateBill", prms)

        If prms(27).Value.ToString.Trim <> "" Then
            Return prms(27).Value
        Else
            Return prms(26).Value
        End If

    End Function

End Class
