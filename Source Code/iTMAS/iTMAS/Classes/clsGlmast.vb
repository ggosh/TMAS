Imports System.Data.SqlClient

Public Class clsGlmast

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetGrpList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetGrplist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetGLList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetGLlist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetGLFList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetGLFlist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetPartyList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetPartyList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetPartyFList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetPartyFList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetPartyRateList(ByVal CoID As String, ByVal Flt As String) As DataTable

        Dim ds As DataSet
        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
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

    Public Function GetPartyDetails(ByVal GL_ID As Int32) As DataTable
        Return GetGLDetails(GL_ID)
    End Function

    Public Function ChkDuplicateGL(ByVal GL_id As Integer, ByVal AcName As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_id
        prm.ParameterName = "@GL_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = AcName
        prm.ParameterName = "@AcName"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
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

        objDA.ExecuteQuery("s_ChkDuplicateGLname", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function ChkDuplicateCode(ByVal GL_id As Integer, ByVal AcCode As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_id
        prm.ParameterName = "@GL_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = AcCode
        prm.ParameterName = "@AcCode"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
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

        objDA.ExecuteQuery("s_ChkDuplicateGLCode", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function GetGLIDbyCode(ByVal Accode As String) As Int32

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet, dt As DataTable

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = Accode
        prm.ParameterName = "@AcCode"
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

        ds = objDA.ExecuteQuery("s_GetGLIDbyCode", prms)
        dt = ds.Tables(0)
        Return dt.Rows(0).Item(0)

    End Function

    Public Function GetGLDetails(ByVal GL_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@Gl_id"
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

        ds = objDA.ExecuteQuery("s_GetGLDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetGLSubList(ByVal GL_ID As Int32) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@Gl_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = 0       'to get all subs for gl
        prm.ParameterName = "@Sub_id"
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

        ds = objDA.ExecuteQuery("s_GetSubGLList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetGLType(ByVal GL_ID As Int32) As String

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@Gl_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 5
        prm.ParameterName = "@Return"
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

        ds = objDA.ExecuteQuery("s_GetGLType", prms)
        If prms(2).Value.ToString.Trim <> "" Then
            Return prms(2).Value
        Else
            Return prms(1).Value
        End If

    End Function

    Public Function InsertUpdateGL(ByVal GL_ID As Int32, ByVal AcName As String, ByVal Grp_id As Int32, ByVal yrOpen As String, _
        ByVal opbal As Single, ByVal lybal As Single, ByVal status As String, ByVal co_cd As String, _
        ByVal AcCode As String, ByVal IT_file As String, ByVal RC_no As String, ByVal VAT_no As String, _
        ByVal ECC_no As String, ByVal Addr As String, ByVal bill_addr As String, ByVal ref_no As String, _
        ByVal Encl As String, ByVal attn As String, ByVal kattn As String, ByVal ph_no As String, _
        ByVal HasSub As Boolean) As Object

        Dim prms(22) As SqlParameter
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
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 30
        prm.Value = kattn
        prm.ParameterName = "@ph_no"
        prms(19) = prm
        prm = Nothing
        ' parameter 21
        prm = New SqlParameter
        prm.DbType = DbType.Boolean
        prm.Direction = ParameterDirection.Input
        prm.Value = HasSub
        prm.ParameterName = "@HasSub"
        prms(20) = prm
        prm = Nothing
        ' parameter 22
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(21) = prm
        prm = Nothing
        ' parameter 23
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(22) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateGL", prms)

        If prms(22).Value.ToString.Trim <> "" Then
            Return prms(22).Value
        Else
            Return prms(21).Value
        End If

    End Function

    Public Function DeleteGL(ByVal GL_ID As Int32) As Object

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@Gl_id"
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

        objDA.ExecuteQuery("s_DeleteGL", prms)
        If prms(1).Value.ToString.Trim <> "" Then
            Return prms(1).Value
        Else
            Return prms(0).Value
        End If

    End Function

    Public Function InsertUpdateGrp(ByVal Grp_ID As Int32, ByVal GrpName As String, ByVal GrpCode As String, _
        ByVal SchNo As String, ByVal yrOpen As String, ByVal status As String, ByVal co_cd As String) As Object

        Dim prms(8) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Grp_ID
        prm.ParameterName = "@GRP_ID"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 40
        prm.Value = GrpName
        prm.ParameterName = "@GrpName"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 4
        prm.Value = GrpCode
        prm.ParameterName = "@GrpCode"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 4
        prm.Value = SchNo
        prm.ParameterName = "@SchNo"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 5
        prm.Value = yrOpen
        prm.ParameterName = "@yrOpen"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = status
        prm.ParameterName = "@status"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(7) = prm
        prm = Nothing
        ' parameter 9
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(8) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateGrp", prms)

        If prms(8).Value.ToString.Trim <> "" Then
            Return prms(8).Value
        Else
            Return prms(7).Value
        End If

    End Function

    Public Function GetPartyBillList(ByVal CoID As String, ByVal GLId As Int64, ByVal AsOn As Date, ByVal Os As Boolean) As DataTable

        Dim ds As DataSet
        Dim prms(4) As SqlParameter
        Dim prm As SqlParameter
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
        prm.DbType = DbType.Int64
        prm.Direction = ParameterDirection.Input
        prm.Value = GLId
        prm.ParameterName = "@GL_ID"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Date
        prm.Direction = ParameterDirection.Input
        prm.Value = AsOn
        prm.ParameterName = "@AsOn"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Boolean
        prm.Direction = ParameterDirection.Input
        prm.Value = Os
        prm.ParameterName = "@OnlyBal"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(4) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetPartyBillList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetAllAccounts() As List(Of String)
        Dim accounts As List(Of String) = New List(Of String)
        Dim prm As SqlParameter = New SqlParameter
        Dim con As SqlConnection = New SqlConnection(gStrConnectString)
        con.Open()
        Dim command As SqlCommand = New SqlCommand("s_GetAccountNames", con)
        command.CommandType = CommandType.StoredProcedure
        Dim reader As SqlDataReader = command.ExecuteReader()
        While reader.Read()
            accounts.Add(reader("AcName"))
        End While

        Return accounts

    End Function

    Public Function GetPartyByCode(ByVal CoID As String, ByVal GLcd As String) As Int64

        Dim ds As DataSet
        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
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
        prm.Value = GLcd
        prm.ParameterName = "@PCode"
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

        ds = objDA.ExecuteQuery("s_GetPartyByCode", prms)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        Else
            Return ds.Tables(0).Rows(0).Item(0)
        End If

    End Function

    Public Function InsertUpdteSubGL(ByVal SG_ID As Int64, ByVal GLID As Int64, ByVal SubId As Int64, ByVal CoID As String) As Object

        Dim prms(5) As SqlParameter
        Dim prm As SqlParameter

        Try

            ' parameter 1
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Input
            prm.Value = SG_ID
            prm.ParameterName = "@SG_ID"
            prms(0) = prm
            prm = Nothing
            ' parameter 2
            prm = New SqlParameter
            prm.DbType = DbType.Int64
            prm.Direction = ParameterDirection.Input
            prm.Value = GLID
            prm.ParameterName = "@GL_ID"
            prms(1) = prm
            prm = Nothing
            ' parameter 3
            prm = New SqlParameter
            prm.DbType = DbType.Int64
            prm.Direction = ParameterDirection.Input
            prm.Value = SubId
            prm.ParameterName = "@SUB_ID"
            prms(2) = prm
            prm = Nothing
            ' parameter 4
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = CoID
            prm.ParameterName = "@CO_CD"
            prms(3) = prm
            prm = Nothing
            ' parameter 5
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Output
            prm.ParameterName = "@Return"
            prms(4) = prm
            prm = Nothing
            ' parameter 6
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Output
            prm.Size = 1000
            prm.ParameterName = "@ErrMsg"
            prms(5) = prm
            prm = Nothing

            objDA.ExecuteQuery("s_InsertUpdateSubGL", prms)

            If prms(5).Value.ToString.Trim <> "" Then
                Return prms(5).Value
            Else
                Return prms(4).Value
            End If

        Catch ex As Exception
            Throw New Exception(PARAMS_FAILED, ex)
        End Try

    End Function

End Class
