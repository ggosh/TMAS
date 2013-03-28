Imports System.Data.SqlClient

Public Class clsChallan

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetChalList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetChalList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetChalDetails(ByVal Chal_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
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

        ds = objDA.ExecuteQuery("s_GetChalDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetChalUnldDetails(ByVal Chal_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
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

        ds = objDA.ExecuteQuery("s_GetChalUnldDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetChalDtnDetails(ByVal Chal_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
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

        ds = objDA.ExecuteQuery("s_GetChalDtnDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetChalFromNo(ByVal ChalNo As String, ByVal Co_cd As String, ByVal Yr_cd As String) As Int32

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = ChalNo
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

        ds = objDA.ExecuteQuery("s_GetChalIDbyNo", prms)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item("Chal_ID")
        End If

    End Function

    Public Function GetChalFromCN(ByVal CN_No As String, ByVal Co_cd As String, ByVal Yr_cd As String) As Int32

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = CN_No
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

        ds = objDA.ExecuteQuery("s_GetChalIDbyCN", prms)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item("Chal_ID")
        End If

    End Function

    Public Function DeleteChal(ByVal Chal_ID As Int32) As Object

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
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

        objDA.ExecuteQuery("s_DeleteChal", prms)

        If prms(1).Value.ToString.Trim <> "" Then
            Return prms(1).Value
        Else
            Return prms(0).Value
        End If

    End Function

    Public Function InsertUpdateChal(ByVal Chal_ID As Int32, ByVal branch As String, ByVal tl_id As Int32, ByVal chal_no As String, ByVal chal_dt As DateTime, ByVal cn_no As String, ByVal csgr_id As Int32, ByVal ldpt_id As Int32, _
            ByVal Gl_id As Int32, ByVal csge_id As Int32, ByVal dest_id As Int32, ByVal trip_days As Int32, ByVal driv_id As Int32, ByVal prod_id As Int32, ByVal qty As Single, ByVal unit As String, ByVal rate As Single, _
            ByVal per As String, ByVal amount As Single, ByVal hire_frgt As Single, ByVal co_cd As String, ByVal Yr_cd As String, ByVal AcEffctB4dlv As Boolean) As Object

        Dim prms(24) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 3
        prm.Value = branch
        prm.ParameterName = "@branch"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = tl_id
        prm.ParameterName = "@tl_id"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = chal_no
        prm.ParameterName = "@chal_no"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = chal_dt
        prm.ParameterName = "@chal_dt"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = cn_no
        prm.ParameterName = "@CN_no"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = csgr_id
        prm.ParameterName = "@csgr_id"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = ldpt_id
        prm.ParameterName = "@ldpt_id"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Gl_id
        prm.ParameterName = "@Gl_id"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = csge_id
        prm.ParameterName = "@csge_id"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = dest_id
        prm.ParameterName = "@dest_id"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.Int16
        prm.Direction = ParameterDirection.Input
        prm.Value = trip_days
        prm.ParameterName = "@trip_days"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = driv_id
        prm.ParameterName = "@driv_id"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = prod_id
        prm.ParameterName = "@prod_id"
        prms(13) = prm
        prm = Nothing
        ' parameter 15
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = qty
        prm.ParameterName = "@qty"
        prms(14) = prm
        prm = Nothing
        ' parameter 16
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = unit
        prm.ParameterName = "@unit"
        prms(15) = prm
        prm = Nothing
        ' parameter 17
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = rate
        prm.ParameterName = "@rate"
        prms(16) = prm
        prm = Nothing
        ' parameter 18
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = per
        prm.ParameterName = "@per"
        prms(17) = prm
        prm = Nothing
        ' parameter 19
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = amount
        prm.ParameterName = "@amount"
        prms(18) = prm
        prm = Nothing
        ' parameter 20
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = hire_frgt
        prm.ParameterName = "@hire_frgt"
        prms(19) = prm
        prm = Nothing
        ' parameter 21
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(20) = prm
        prm = Nothing
        ' parameter 22
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 2
        prm.Value = Yr_cd
        prm.ParameterName = "@Yr_cd"
        prms(21) = prm
        prm = Nothing
        ' parameter 23
        prm = New SqlParameter
        prm.DbType = DbType.Boolean
        prm.Direction = ParameterDirection.Input
        prm.Value = AcEffctB4dlv
        prm.ParameterName = "@AcEffctB4dlv"
        prms(22) = prm
        prm = Nothing
        ' parameter 24
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(23) = prm
        prm = Nothing
        ' parameter 25
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(24) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateChal", prms)

        If prms(24).Value.ToString.Trim <> "" Then
            Return prms(24).Value
        Else
            Return prms(23).Value
        End If

    End Function

    Public Function InsertUpdateChalDtn(ByVal Dtn_ID As Int32, ByVal Chal_ID As Int32, ByVal Pre_dtn As Boolean, ByVal Rep_time As DateTime, ByVal Rel_time As DateTime, ByVal dtn_days As Int32, _
            ByVal Dtn_rate As Single, ByVal Dtn_amt As Single, ByVal mkt_days As Int32, ByVal mkt_rate As Single, ByVal mkt_amt As Single) As Object

        Dim prms(12) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Dtn_ID
        prm.ParameterName = "@Dtn_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Boolean
        prm.Direction = ParameterDirection.Input
        prm.Value = Pre_dtn
        prm.ParameterName = "@Pre_dtn"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Rep_time
        prm.ParameterName = "@Rep_time"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Rel_time
        prm.ParameterName = "@Rel_time"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = dtn_days
        prm.ParameterName = "@dtn_days"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Dtn_rate
        prm.ParameterName = "@Dtn_rate"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Dtn_amt
        prm.ParameterName = "@Dtn_amt"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = mkt_days
        prm.ParameterName = "@mkt_days"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = mkt_rate
        prm.ParameterName = "@mkt_rate"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = mkt_amt
        prm.ParameterName = "@mkt_amt"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(12) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateChalDtn", prms)

        If prms(12).Value.ToString.Trim <> "" Then
            Return prms(12).Value
        Else
            Return prms(11).Value
        End If

    End Function

    Public Function InsertUpdateChalUnld(ByVal Unld_ID As Int32, ByVal Chal_ID As Int32, ByVal Chal_rcd As DateTime, ByVal Deliv_dt As DateTime, _
            ByVal Deliv_wt As Single, ByVal Deliv_unit As String, ByVal Shortage As Single, ByVal Sht_unit As String, ByVal Sht_rate As Single, ByVal Sht_amt As Single, ByVal Mkt_Sht As Single) As Object

        Dim prms(12) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Unld_ID
        prm.ParameterName = "@Unld_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Chal_ID
        prm.ParameterName = "@chal_id"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Chal_rcd
        prm.ParameterName = "@Chal_rcd"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Deliv_dt
        prm.ParameterName = "@Deliv_dt"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Deliv_wt
        prm.ParameterName = "@deliv_wt"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 2
        prm.Value = Deliv_unit
        prm.ParameterName = "@Deliv_unit"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Shortage
        prm.ParameterName = "@Shortage"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 3
        prm.Value = Sht_unit
        prm.ParameterName = "@sht_unit"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Sht_rate
        prm.ParameterName = "@Sht_rate"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Sht_amt
        prm.ParameterName = "@Sht_amt"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = Mkt_Sht
        prm.ParameterName = "@mkt_sht"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(12) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateChalUnld", prms)

        If prms(12).Value.ToString.Trim <> "" Then
            Return prms(12).Value
        Else
            Return prms(11).Value
        End If

    End Function

End Class
