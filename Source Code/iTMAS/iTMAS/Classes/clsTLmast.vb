Imports System.Data.SqlClient

Public Class clsTLmast

    Private objDA As New DataAccessor
    Private Const PARAMS_FAILED As String = "Error executing."

    Public Function GetTLlist(ByVal CoID As String, ByVal sFilt As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetTLlist", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetOwnerlist(ByVal CoID As String) As DataTable

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

        ds = objDA.ExecuteQuery("s_GetOwnerList", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetTLbyCode(ByVal TL_code As String) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 4
        prm.Value = TL_code
        prm.ParameterName = "@TL_code"
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

        ds = objDA.ExecuteQuery("s_GetTLbyCode", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetTLbyNo(ByVal TL_No As String) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.String
        prm.Direction = ParameterDirection.Input
        prm.Size = 15
        prm.Value = TL_No
        prm.ParameterName = "@TL_No"
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

        ds = objDA.ExecuteQuery("s_GetTLbyNo", prms)
        Return ds.Tables(0)

    End Function

    Public Function GetTLDetails(ByVal TL_ID As Int32) As DataTable

        Dim prms(1) As SqlParameter
        Dim prm As SqlParameter
        Dim ds As DataSet
        ' parameter 1
        prm = New SqlParameter
        prm.DbType = DbType.Int32
        prm.Direction = ParameterDirection.Input
        prm.Size = 1
        prm.Value = TL_ID
        prm.ParameterName = "@TL_id"
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

        ds = objDA.ExecuteQuery("s_GetTLDetails", prms)
        Return ds.Tables(0)

    End Function

    Public Function InsertUpdateTL(ByVal TL_ID As Int32, ByVal TL_Code As String, ByVal TL_No As String, ByVal tOwn As Boolean, ByVal bOwn As Boolean, ByVal Owner_id As Int32, ByVal Start_date As Date, ByVal End_date As Nullable(Of Date), ByVal CoID As String) As Object
        Try
            Dim prms(10) As SqlParameter
            Dim prm As SqlParameter

            ' parameter 1
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = TL_ID
            prm.ParameterName = "@TL_id"
            prms(0) = prm
            prm = Nothing
            ' parameter 2
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 4
            prm.Value = TL_Code
            prm.ParameterName = "@TL_code"
            prms(1) = prm
            prm = Nothing
            ' parameter 3
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 15
            prm.Value = TL_No
            prm.ParameterName = "@TL_no"
            prms(2) = prm
            prm = Nothing
            ' parameter 4
            prm = New SqlParameter
            prm.DbType = DbType.Boolean
            prm.Direction = ParameterDirection.Input
            prm.Value = tOwn
            prm.ParameterName = "@Own"
            prms(3) = prm
            prm = Nothing
            ' parameter 5
            prm = New SqlParameter
            prm.DbType = DbType.Boolean
            prm.Direction = ParameterDirection.Input
            prm.Value = bOwn
            prm.ParameterName = "@Bilown"
            prms(4) = prm
            prm = Nothing
            ' parameter 6
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Input
            prm.Value = IIf(bOwn, DBNull.Value, Owner_id)
            prm.ParameterName = "@owner_id"
            prms(5) = prm
            prm = Nothing
            ' parameter 7
            prm = New SqlParameter
            prm.DbType = DbType.Date
            prm.Direction = ParameterDirection.Input
            prm.Value = Start_date
            prm.ParameterName = "@start_date"
            prms(6) = prm
            prm = Nothing
            ' parameter 8
            prm = New SqlParameter
            prm.DbType = DbType.Date
            prm.Direction = ParameterDirection.Input
            prm.Value = End_date
            prm.ParameterName = "@end_date"
            prms(7) = prm
            prm = Nothing
            ' parameter 9
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Input
            prm.Size = 1
            prm.Value = CoID
            prm.ParameterName = "@CO_CD"
            prms(8) = prm
            prm = Nothing
            ' parameter 10
            prm = New SqlParameter
            prm.DbType = DbType.Int32
            prm.Direction = ParameterDirection.Output
            prm.ParameterName = "@Return"
            prms(9) = prm
            prm = Nothing
            ' parameter 11
            prm = New SqlParameter
            prm.DbType = DbType.String
            prm.Direction = ParameterDirection.Output
            prm.Size = 1000
            prm.ParameterName = "@ErrMsg"
            prms(10) = prm
            prm = Nothing

            objDA.ExecuteQuery("s_InsertUpdateTLmast", prms)

            If prms(10).Value.ToString.Trim <> "" Then
                Return prms(10).Value
            Else
                Return prms(9).Value
            End If

        Catch ex As Exception
            gError_Message("Error saving record(" + ex.Message + ").", MessageBoxButtons.OK + MessageBoxIcon.Error)
            Return -1
        End Try

    End Function

End Class
