Imports System.Data.SqlClient

Public Class DataAccessor

    Private con As SqlConnection
    Private cmd As SqlCommand
    Private da As SqlDataAdapter
    Private dt As DataTable
    Private ds As DataSet
    Private Const PARAMS_FAILED As String = "Could not attach parameters."

    Public Function ExecuteNonQuery(ByVal SPName As String, ByRef param As SqlParameter()) As Int32
        con = New SqlConnection(gStrConnectString)
        cmd = New SqlCommand(SPName, con)
        AppendParameters(param, cmd)
        cmd.CommandType = CommandType.StoredProcedure
        con.Open()
        Dim retVal As Int32 = cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
        Return retVal
    End Function

    Public Function ExecuteQuery(ByVal SPName As String, ByRef param As SqlParameter()) As DataSet

        con = New SqlConnection(gStrConnectString)
        cmd = New SqlCommand(SPName, con)
        AppendParameters(param, cmd)
        cmd.CommandType = CommandType.StoredProcedure
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        Return ds

    End Function

    Private Sub SqlParam2Hashtable(ByVal params As SqlParameter(), ByRef ht As Hashtable)

        Try
            If Not (params Is Nothing) Then
                For Each parameter As SqlParameter In params
                    ht.Add(parameter.ParameterName, parameter.Value)
                Next
            End If
        Catch e As Exception
            Throw New Exception(PARAMS_FAILED, e)
        End Try

    End Sub

    Private Sub AppendParameters(ByVal params As SqlParameter(), ByVal cmd As SqlCommand)
        Try
            If Not (params Is Nothing) Then
                For Each parameter As SqlParameter In params
                    cmd.Parameters.Add(parameter)
                Next
            End If
        Catch e As Exception
            Throw New Exception(PARAMS_FAILED, e)
        End Try
    End Sub

End Class
