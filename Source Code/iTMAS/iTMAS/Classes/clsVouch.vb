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

    Public Function InsertUpdateVouch(voucherDetails As VoucherDTO) As Object

        Dim prms(15) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.AcId
        prm.ParameterName = "@Ac_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = voucherDetails.VoucherNo
        prm.ParameterName = "@Vo_No"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.VoucherDate
        prm.ParameterName = "@Vo_Dt"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = voucherDetails.VType
        prm.ParameterName = "@Vo_Type"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 10
        prm.Value = voucherDetails.ChqNo
        prm.ParameterName = "@Cheque_No"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.BankDate
        prm.ParameterName = "@Bank_Dt"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Decimal
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.Amt
        prm.ParameterName = "@Amount"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.CoCd
        prm.ParameterName = "@CO_CD"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.Brn
        prm.ParameterName = "@branch"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.YrCd
        prm.ParameterName = "@Yr_CD"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.Int64
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.RefId
        prm.ParameterName = "@Ref_id"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.Narr
        prm.ParameterName = "@Narr"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.Dtls
        prm.ParameterName = "@Dtls"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = voucherDetails.SDtls
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