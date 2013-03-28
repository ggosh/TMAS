Imports System.Data.SqlClient

Public Class clsRates

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetRateList(ByVal CoID As String, ByVal Flt As String) As DataTable

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
        prm.Size = 1
        prm.Value = Flt
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

        ds = objDA.ExecuteQuery("s_GetRateList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetRateDetails(ByVal rate_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = rate_ID
        prm.ParameterName = "@tar_id"
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

        ds = objDA.ExecuteQuery("s_GetTarDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdateRate(ByVal tar_ID As Int32, ByVal Gl_ID As Int32, ByVal csge_ID As Int32, _
            ByVal prod_ID As Int32, ByVal ldpt_ID As Int32, ByVal dest_ID As Int32, ByVal bill_rate As Single, _
            ByVal hire_rate As Single, ByVal shrt_rate As Single, ByVal shrt_unit As String, _
            ByVal othr_rate As Single, ByVal othr_name As String, ByVal othr_unit As String, _
            ByVal Wef As Date, ByVal Efto As Date, ByVal stat As String, ByVal co_cd As String, _
            ByVal RouteKM As Int32) As Object

        Dim prms(19) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = tar_ID
        prm.ParameterName = "@tar_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Gl_ID
        prm.ParameterName = "@Gl_id"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = csge_ID
        prm.ParameterName = "@csge_id"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = prod_ID
        prm.ParameterName = "@prod_id"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = ldpt_ID
        prm.ParameterName = "@ldpt_id"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = dest_ID
        prm.ParameterName = "@dest_id"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = bill_rate
        prm.ParameterName = "@bill_rate"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = hire_rate
        prm.ParameterName = "@hire_rate"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = shrt_rate
        prm.ParameterName = "@shrt_rate"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = shrt_unit
        prm.ParameterName = "@shrt_unit"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = othr_rate
        prm.ParameterName = "@othr_rate"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = othr_name
        prm.ParameterName = "@othr_name"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = othr_unit
        prm.ParameterName = "@othr_unit"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Wef
        prm.ParameterName = "@WEF"
        prms(13) = prm
        prm = Nothing
        ' parameter 15
        prm = New SqlParameter
        prm.DbType = DbType.DateTime
        prm.Direction = ParameterDirection.Input
        prm.Value = Efto
        prm.ParameterName = "@Efto"
        prms(14) = prm
        prm = Nothing
        ' parameter 16
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = stat
        prm.ParameterName = "@Status"
        prms(15) = prm
        prm = Nothing
        ' parameter 17
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(16) = prm
        prm = Nothing
        ' parameter 18
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = RouteKM
        prm.ParameterName = "@RouteKM"
        prms(17) = prm
        prm = Nothing
        ' parameter 19
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(18) = prm
        prm = Nothing
        ' parameter 20
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(19) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateTar", prms)

        If prms(19).Value.ToString.Trim <> "" Then
            Return prms(19).Value
        Else
            Return prms(18).Value
        End If

    End Function

End Class
