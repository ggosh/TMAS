Imports System.Data.SqlClient

Public Class clsCsgr

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetCsgrList(ByVal CoID As String) As DataTable

        Dim prms(1) As SqlParameter
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
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(1) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetCsgrList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetCsgrDetails(ByVal CS_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CS_ID
        prm.ParameterName = "@csgr_id"
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

        ds = objDA.ExecuteQuery("s_GetCsgrDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function ChkDuplicateCsgr(ByVal Csgr_id As Integer, ByVal CName As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Csgr_id
        prm.ParameterName = "@Csgr_id"
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

        objDA.ExecuteQuery("s_ChkDuplicateCsgrName", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function ChkDuplicateCsgrCode(ByVal Csgr_id As Integer, ByVal CCode As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = Csgr_id
        prm.ParameterName = "@Csgr_id"
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

        objDA.ExecuteQuery("s_ChkDuplicateCsgrCode", prms)
        If prms(3).Value.ToString.Trim <> "" Then
            Return prms(3).Value
        Else
            Return prms(2).Value
        End If

    End Function

    Public Function InsertUpdateCsgr(ByVal cs_ID As Int32, ByVal cs_code As String, ByVal cs_Name As String, ByVal ldpt_id As Int32, ByVal yrOpen As String, ByVal co_cd As String) As Object

        Dim prms(7) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = cs_ID
        prm.ParameterName = "@csgr_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 10
        prm.Value = cs_code
        prm.ParameterName = "@cs_code"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 30
        prm.Value = cs_Name
        prm.ParameterName = "@cs_name"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = ldpt_id
        prm.ParameterName = "@ldpt_id"
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
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(5) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(6) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(7) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateCsgr", prms)

        If prms(7).Value.ToString.Trim <> "" Then
            Return prms(7).Value
        Else
            Return prms(6).Value
        End If

    End Function

End Class
