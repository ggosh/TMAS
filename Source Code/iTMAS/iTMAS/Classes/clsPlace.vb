Imports System.Data.SqlClient

Public Class clsPlace

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetPlaceList(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetPlaceList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetPlaceDetails(ByVal PL_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = PL_ID
        prm.ParameterName = "@pl_id"
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

        ds = objDA.ExecuteQuery("s_GetPlaceDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdatePlace(ByVal pl_ID As Int32, ByVal pl_sht As String, ByVal pl_Name As String, ByVal pl_type As String, ByVal co_cd As String) As Object

        Dim prms(6) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = pl_ID
        prm.ParameterName = "@pl_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 4
        prm.Value = pl_sht
        prm.ParameterName = "@pl_sht"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = pl_Name
        prm.ParameterName = "@pl_name"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = pl_type
        prm.ParameterName = "@pl_type"
        prms(3) = prm
        prm = Nothing
        ' parameter 5
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
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

        objDA.ExecuteQuery("s_InsertUpdatePlace", prms)

        If prms(6).Value.ToString.Trim <> "" Then
            Return prms(6).Value
        Else
            Return prms(5).Value
        End If

    End Function

End Class
