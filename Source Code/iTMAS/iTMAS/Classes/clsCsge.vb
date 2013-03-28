Imports System.Data.SqlClient

Public Class clsCsge

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetCsgeList(ByVal CoID As String, ByVal Flt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetCsgeList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetCsgeDetails(ByVal Csge_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CSge_ID
        prm.ParameterName = "@csge_id"
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

        ds = objDA.ExecuteQuery("s_GetCsgeDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function ChkDuplicateCsge(ByVal Csge_id As Integer, ByVal CName As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Csge_id
        prm.ParameterName = "@Csge_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = CName
        prm.ParameterName = "@CName"
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

        objDA.ExecuteQuery("s_ChkDuplicateCsgeName", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function ChkDuplicateCsgeCode(ByVal Csge_id As Integer, ByVal CCode As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Csge_id
        prm.ParameterName = "@Csge_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = CCode
        prm.ParameterName = "@CCode"
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

        objDA.ExecuteQuery("s_ChkDuplicateCsgeCode", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function InsertUpdateCsge(ByVal csge_ID As Int32, ByVal csge_code As String, ByVal csge_Name As String, ByVal Gl_id As Int32, ByVal dest_id As Int32, ByVal yrOpen As String, ByVal co_cd As String) As Object

        Dim prms(8) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = csge_ID
        prm.ParameterName = "@csge_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = csge_code
        prm.ParameterName = "@csge_code"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 30
        prm.Value = csge_Name
        prm.ParameterName = "@csge_name"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Gl_id
        prm.ParameterName = "@Gl_id"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = dest_id
        prm.ParameterName = "@dest_id"
        prms(4) = prm
        prm = Nothing
        ' parameter 6
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = yrOpen
        prm.ParameterName = "@yrOpen"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
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

        objDA.ExecuteQuery("s_InsertUpdateCsge", prms)

        If prms(8).Value.ToString.Trim <> "" Then
            Return prms(8).Value
        Else
            Return prms(7).Value
        End If

    End Function

End Class
