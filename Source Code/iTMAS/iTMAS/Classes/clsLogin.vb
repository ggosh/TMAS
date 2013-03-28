Imports System.Data.SqlClient

Public Class clsLogin

    Private objDA As New DataAccessor

    Public Function GetUserDetails(ByVal UID As String, ByVal pwd As String) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 20
        prm.Value = UID
        prm.ParameterName = "@UserName"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 20
        prm.Value = pwd
        prm.ParameterName = "@Password"
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

        ds = objDA.ExecuteQuery("s_GetUser", prms)
        Return ds.Tables(0)

    End Function

    Public Function SetUserDetails(ByVal UID As String, ByVal pwd As String, ByVal uty As String) As DataTable
        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = UID
        prm.ParameterName = "@UserName"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 50
        prm.Value = pwd
        prm.ParameterName = "@Password"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 2
        prm.Value = uty
        prm.ParameterName = "@UserType"
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

        ds = objDA.ExecuteQuery("s_InsertUpdateUser", prms)
        Return ds.Tables(0)
    End Function
End Class
