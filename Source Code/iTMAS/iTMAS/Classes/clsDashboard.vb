Imports System.Data.SqlClient

Public Class clsDashboard

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetCurrUsers(ByVal CoID As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetCurrUsers", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetCompanies(ByVal CoID As String) As DataTable

        Dim prms(0) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1000
        prm.ParameterName = "@ErrMsg"
        prms(1) = prm
        prm = Nothing

        ds = objDA.ExecuteQuery("s_GetCos", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetCoDetails(ByVal CoID As String) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_ID"
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

        ds = objDA.ExecuteQuery("s_GetCoDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetBranches(ByVal CoID As String) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_ID"
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

        ds = objDA.ExecuteQuery("s_GetBrns", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetYears(ByVal CoID As String) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_ID"
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

        ds = objDA.ExecuteQuery("s_GetYears", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetHiBals(ByVal CoID As String, ByVal UsrID As Int64) As DataTable

        Dim prms(2) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = CoID
        prm.ParameterName = "@CO_ID"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.Int64
        prm.Direction = ParameterDirection.Input
        prm.Value = UsrID
        prm.ParameterName = "@USR_ID"
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

        ds = objDA.ExecuteQuery("s_GetHiBals", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetFavs(ByVal CoID As String, ByVal UsrID As Int64, ByVal Catg As String, ByVal isAll As Boolean) As DataTable

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
        prm.DbType = DbType.Int64
        prm.Direction = ParameterDirection.Input
        prm.Value = UsrID
        prm.ParameterName = "@USR_ID"
        prms(1) = prm
        prm = Nothing
        ' parameter 3
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = Catg
        prm.ParameterName = "@Categ"
        prms(2) = prm
        prm = Nothing
        ' parameter 4
        prm = New SqlParameter
        prm.DbType = DbType.Boolean
        prm.Direction = ParameterDirection.Input
        prm.Value = isAll
        prm.ParameterName = "@IsAll"
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

        ds = objDA.ExecuteQuery("s_GetFavs", prms)
        Return ds.Tables(0)

    End Function

    Public Sub InsertUpdteULog(ByVal CoID As String, ByVal UsrID As Int64, ByVal UobjId As Int64, ByVal uState As Boolean)

        Dim prms(4) As SqlParameter
        Dim prm As SqlParameter

        Try

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
            prm.Value = UsrID
            prm.ParameterName = "@USR_ID"
            prms(1) = prm
            prm = Nothing
            ' parameter 3
            prm = New SqlParameter
            prm.DbType = DbType.Int64
            prm.Direction = ParameterDirection.Input
            prm.Value = UobjId
            prm.ParameterName = "@UOBJ_ID"
            prms(2) = prm
            prm = Nothing
            ' parameter 4
            prm = New SqlParameter
            prm.DbType = DbType.Boolean
            prm.Direction = ParameterDirection.Input
            prm.Value = uState
            prm.ParameterName = "@Stt"
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

            Dim obj As Object = objDA.ExecuteQuery("s_InsertUpdateULog", prms)

        Catch ex As Exception
            Throw New Exception(PARAMS_FAILED, ex)
        End Try

    End Sub

End Class
