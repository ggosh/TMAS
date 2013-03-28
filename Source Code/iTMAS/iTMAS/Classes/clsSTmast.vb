Imports System.Data.SqlClient

Public Class clsSTmast

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetSTList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetSTlist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetSTDetails(ByVal GL_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@Tax_id"
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

        ds = objDA.ExecuteQuery("s_GetSTDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdateST(ByVal GL_ID As Int32, ByVal AcName As String, ByVal Grp_id As Int32, ByVal yrOpen As String, _
        ByVal opbal As Single, ByVal lybal As Single, ByVal status As String, ByVal co_cd As String, _
        ByVal AcCode As String, ByVal IT_file As String, ByVal RC_no As String, ByVal VAT_no As String, _
        ByVal ECC_no As String, ByVal Addr As String, ByVal bill_addr As String, ByVal ref_no As String, _
        ByVal Encl As String, ByVal attn As String, ByVal kattn As String) As Object

        Dim prms(20) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@GL_ID"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 40
        prm.Value = AcName
        prm.ParameterName = "@AcName"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Grp_id
        prm.ParameterName = "@Grp_id"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 5
        prm.Value = yrOpen
        prm.ParameterName = "@yrOpen"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = opbal
        prm.ParameterName = "@OpBal"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Single
        prm.Direction = ParameterDirection.Input
        prm.Value = lybal
        prm.ParameterName = "@lybal"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = status
        prm.ParameterName = "@status"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = AcCode
        prm.ParameterName = "@AcCode"
        prms(8) = prm
        prm = Nothing
        ' parameter 10
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 25
        prm.Value = IT_file
        prm.ParameterName = "@IT_file"
        prms(9) = prm
        prm = Nothing
        ' parameter 11
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 20
        prm.Value = RC_no
        prm.ParameterName = "@RC_No"
        prms(10) = prm
        prm = Nothing
        ' parameter 12
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = VAT_no
        prm.ParameterName = "@VAT_No"
        prms(11) = prm
        prm = Nothing
        ' parameter 13
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = ECC_no
        prm.ParameterName = "@ECC_No"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 500
        prm.Value = Addr
        prm.ParameterName = "@Addr"
        prms(13) = prm
        prm = Nothing
        ' parameter 15
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 500
        prm.Value = bill_addr
        prm.ParameterName = "@bill_addr"
        prms(14) = prm
        prm = Nothing
        ' parameter 16
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 10
        prm.Value = ref_no
        prm.ParameterName = "@ref_no"
        prms(15) = prm
        prm = Nothing
        ' parameter 17
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = Encl
        prm.ParameterName = "@Encl"
        prms(16) = prm
        prm = Nothing
        ' parameter 18
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = attn
        prm.ParameterName = "@attn"
        prms(17) = prm
        prm = Nothing
        ' parameter 19
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = kattn
        prm.ParameterName = "@kattn"
        prms(18) = prm
        prm = Nothing
        ' parameter 20
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(19) = prm
        prm = Nothing
        ' parameter 21
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(20) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateST", prms)

        If prms(20).Value.ToString.Trim <> "" Then
            Return prms(20).Value
        Else
            Return prms(19).Value
        End If

    End Function

End Class
