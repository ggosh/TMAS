Imports System.Data.SqlClient

Public Class clsVouch

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetMaxVoNo(ByVal CoID As String, ByVal vInit As String, ByVal sDate As Date, _
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
        prm.Value = vInit
        prm.ParameterName = "@vInit"
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

        ds = objDA.ExecuteQuery("s_GetMaxVoNo", prms)
        If ds.Tables(0).Rows(0).Item("vo_No").ToString <> "" Then
            Return ds.Tables(0).Rows(0).Item("Vo_No")
        Else
            Return ""
        End If

    End Function

    Public Function GetVoList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetVoList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetVoDtlList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetVoDtlList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetVoDetails(ByVal Ac_ID As Int32) As DataSet

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Ac_ID
        prm.ParameterName = "@ac_id"
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

        ds = objDA.ExecuteQuery("s_GetVoDetails", prms)
        Return ds

    End Function

    Public Function InsertUpdateVouch(ByVal Ac_ID As Int32, ByVal VoNo As String, ByVal VoDt As Date, ByVal vTyp As String, ByVal ChqNo As String, _
            ByVal bank_dt As Nullable(Of Date), ByVal Amt As Decimal, ByVal co_cd As String, ByVal brn As String, ByVal yr_cd As String, _
            ByVal ref_id As Integer, ByVal Narr As String, ByVal Dtls As String, ByVal SDtls As String) As Object

        Dim prms(15) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = Ac_ID
        prm.ParameterName = "@ac_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = VoNo
        prm.ParameterName = "@Vo_No"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = VoDt
        prm.ParameterName = "@Vo_Dt"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = vTyp
        prm.ParameterName = "@Vo_Type"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 10
        prm.Value = ChqNo
        prm.ParameterName = "@Cheque_No"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = bank_dt
        prm.ParameterName = "@Bank_Dt"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = Amt
        prm.ParameterName = "@Amount"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(7) = prm
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = brn
        prm.ParameterName = "@branch"
        prms(8) = prm
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = yr_cd
        prm.ParameterName = "@YR_CD"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Int64
        prm.Direction = ParameterDirection.Input
        prm.Value = ref_id
        prm.ParameterName = "@Ref_ID"
        prms(10) = prm
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = Narr
        prm.ParameterName = "@Narr"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = Dtls
        prm.ParameterName = "@Dtls"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = SDtls
        prm.ParameterName = "@SubDtls"
        prms(13) = prm
        prm = Nothing
        ' parameter 15
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(14) = prm
        prm = Nothing
        ' parameter 16
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(15) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateVouch", prms)

        If prms(15).Value.ToString.Trim <> "" Then
            Return prms(15).Value
        Else
            Return prms(14).Value
        End If

    End Function

End Class
