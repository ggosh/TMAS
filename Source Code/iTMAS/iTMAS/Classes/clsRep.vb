Imports System.Data.SqlClient

Public Class clsRep

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetRepList(ByVal CoID As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetRepList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetRepDetails(ByVal CS_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CS_ID
        prm.ParameterName = "@Rep_id"
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

        ds = objDA.ExecuteQuery("s_GetRepDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdateRep(ByVal cs_ID As Int32, ByVal cs_Name As String, ByVal co_cd As String) As Object

        Dim prms(4) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = cs_ID
        prm.ParameterName = "@Rep_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 30
        prm.Value = cs_Name
        prm.ParameterName = "@Repname"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = co_cd
        prm.ParameterName = "@CO_CD"
        prms(2) = prm
        prm = Nothing
        ' parameter 7
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Output
        prm.ParameterName = "@Return"
        prms(3) = prm
        prm = Nothing
        ' parameter 8
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(4) = prm
        prm = Nothing

        objDA.ExecuteQuery("s_InsertUpdateRep", prms)

        If prms(4).Value.ToString.Trim <> "" Then
            Return prms(4).Value
        Else
            Return prms(3).Value
        End If

    End Function

End Class
