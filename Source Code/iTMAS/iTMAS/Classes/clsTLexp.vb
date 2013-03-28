Imports System.Data.SqlClient

Public Class clsTLexp

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetTLexplist(ByVal CoID As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetTLexplist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetTLexpDetails(ByVal te_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = te_ID
        prm.ParameterName = "@te_id"
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

        ds = objDA.ExecuteQuery("s_GetTLexpDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function ChkTLexpType(ByVal GL_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = GL_ID
        prm.ParameterName = "@GL_id"
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

        ds = objDA.ExecuteQuery("s_ChkTLexpType", prms)
        Return ds.Tables(0)

    End Function

    Public Function ChkDuplicateTLexp(ByVal TE_id As Integer, ByVal ExpName As String) As Object

        Dim prms(3) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Value = TE_id
        prm.ParameterName = "@TE_id"
        prms(0) = prm
        prm = Nothing
        ' parameter 2
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Value = ExpName
        prm.ParameterName = "@ExpName"
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

        objDA.ExecuteQuery("s_ChkDuplicateTLexp", prms)
        If prms(2).Value.ToString.Trim <> "" Then
            Return prms(2).Value
        Else
            Return prms(1).Value
        End If

    End Function

    Public Function NewTLexpCode() As Object

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter

        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Output
        prm.Size = 1
        prm.ParameterName = "@Return"
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

        objDA.ExecuteQuery("s_NewTLexpCode", prms)
        If prms(1).Value.ToString.Trim <> "" Then
            Return prms(1).Value
        Else
            Return prms(0).Value
        End If

    End Function

    Public Function InsertUpdateTLexp(ByVal Te_ID As Int32, ByVal ExpCode As String, ByVal ExpName As String, ByVal GL_id As Int32, ByVal CoID As String) As Object
        Try
            Dim prms(6) As SqlParameter
            Dim prm As SqlParameter

            ' parameter 1
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = Te_ID
            prm.ParameterName = "@Te_id"
            prms(0) = prm
            prm = Nothing
            ' parameter 2
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = ExpCode
            prm.ParameterName = "@ExpCode"
            prms(1) = prm
            prm = Nothing
            ' parameter 3
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 50
            prm.Value = ExpName
            prm.ParameterName = "@ExpName"
            prms(2) = prm
            prm = Nothing
            ' parameter 4
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Input
            prm.Value = GL_id
            prm.ParameterName = "@gl_id"
            prms(3) = prm
            prm = Nothing
            ' parameter 5
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = CoID
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

            objDA.ExecuteQuery("s_InsertUpdateTLexp", prms)

            If prms(6).Value.ToString.Trim <> "" Then
                Return prms(6).Value
            Else
                Return prms(5).Value
            End If

        Catch ex As Exception
            gError_Message("Error saving record(" + ex.Message + ").", MessageBoxButtons.OK + MessageBoxIcon.Error)
            Return -1
        End Try

    End Function

End Class
