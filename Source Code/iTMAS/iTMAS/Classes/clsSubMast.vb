Imports System.Data.SqlClient

Public Class clsSubMast

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetSGrList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetSGrlist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetSubList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetSubList", prms)
        Return ds.Tables(0)

    End Function

    Public Function ChkDuplicateSub(ByVal Sub_id As Integer, ByVal SubName As String) As Object
        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_id
        prm.ParameterName = "@Sub_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = SubName
        prm.ParameterName = "@SubName"
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

        objDA.ExecuteQuery("s_ChkDuplicateSubName", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function ChkDuplicateSubCode(ByVal Sub_id As Integer, ByVal SubCode As String) As Object
        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_id
        prm.ParameterName = "@Sub_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = SubCode
        prm.ParameterName = "@SubCode"
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

        objDA.ExecuteQuery("s_ChkDuplicateSubCode", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function ChkDuplicateGLSub(ByVal GL_id As Integer, ByVal Sub_id As Integer) As Object
        '
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
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_id
        prm.ParameterName = "@Sub_id"
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

        objDA.ExecuteQuery("s_ChkDuplicateGLSub", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function GetSubIDbyCode(ByVal Accode As String) As Int32

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

        ds = objDA.ExecuteQuery("s_GetSubIDbyCode", prms)
        dt = ds.Tables(0)
        Return dt.Rows(0).Item(0)

    End Function

    Public Function GetSubGLList(ByVal Sub_ID As Int32) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = 0
        prm.ParameterName = "@Gl_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
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

    Public Function GetSubDetails(ByVal Sub_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
        prm.ParameterName = "@Sub_id"
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

        ds = objDA.ExecuteQuery("s_GetSubDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetDriverList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetDriverList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetDriverDetails(ByVal Sub_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
        prm.ParameterName = "@Sub_id"
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

        ds = objDA.ExecuteQuery("s_GetDriverDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdateSub(ByVal Sub_ID As Int32, ByVal SubName As String, ByVal SGr_id As Int32, _
        ByVal yrOpen As String, ByVal opbal As Single, ByVal lybal As Single, _
        ByVal status As String, ByVal co_cd As String, _
        ByVal AcCode As String, ByVal IT_file As String, ByVal RC_no As String, ByVal VAT_no As String, _
        ByVal Addr As String, ByVal ph_no As String) As Object

        Dim prms(15) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
        prm.ParameterName = "@Sub_ID"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 40
        prm.Value = SubName
        prm.ParameterName = "@SubName"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = SGr_id
        prm.ParameterName = "@SGr_id"
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
        prm.Size = 4
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
        prm.Size = 500
        prm.Value = Addr
        prm.ParameterName = "@Addr"
        prms(12) = prm
        prm = Nothing
        ' parameter 14
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 30
        prm.Value = ph_no
        prm.ParameterName = "@ph_no"
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

        objDA.ExecuteQuery("s_InsertUpdateSub", prms)

        If prms(15).Value.ToString.Trim <> "" Then
            Return prms(15).Value
        Else
            Return prms(14).Value
        End If

    End Function

    Public Function InsertUpdateSGr(ByVal SGr_ID As Int32, ByVal SGrName As String, ByVal yrOpen As String, _
                ByVal status As String, ByVal co_cd As String) As Object

        Dim prms(6) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = SGr_ID
        prm.ParameterName = "@SGR_ID"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 40
        prm.Value = SGrName
        prm.ParameterName = "@SGrName"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 5
        prm.Value = yrOpen
        prm.ParameterName = "@yrOpen"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = status
        prm.ParameterName = "@status"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(6) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateSGr", prms)

        If prms(6).Value.ToString.Trim <> "" Then
            Return prms(6).Value
        Else
            Return prms(5).Value
        End If

    End Function

    Public Function InsertUpdateSubGl(ByVal SG_ID As Int32, ByVal GL_ID As Int32, ByVal Sub_ID As Int32, ByVal co_cd As String) As Object

        Dim prms(5) As SqlParameter
        Dim prm As SqlParameter

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
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = GL_ID
        prm.ParameterName = "@GL_ID"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
        prm.ParameterName = "@SUB_ID"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = co_cd
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

    End Function

    Public Function DeleteSub(ByVal Sub_ID As Int32) As Object

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Sub_ID
        prm.ParameterName = "@Sub_id"
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

        objDA.ExecuteQuery("s_DeleteSub", prms)
        If prms(1).Value.ToString.Trim <> "" Then
            Return prms(1).Value
        Else
            Return prms(0).Value
        End If

    End Function

End Class
