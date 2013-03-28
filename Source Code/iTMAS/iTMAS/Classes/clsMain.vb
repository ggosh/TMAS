Imports System.Data.SqlClient

Public Class clsMain
    Public Function CheckDBConnection() As Boolean
        Dim con As SqlConnection
        con = New SqlConnection(gStrConnectString)

        Try
            con.Open()
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
