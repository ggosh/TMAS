Imports System.Data.OleDb

Public Class DbfImp
    Dim odcn As OleDb.OleDbConnection
    Dim oda As OleDb.OleDbDataAdapter
    Dim ds1, ds2 As DataSet, dt1 As DataTable
    Dim tsql As String
    Dim oGL As New clsGlmast
    Dim oRp As New clsRep

    Private Sub DbfImp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtLoc.Text = "C:\IHR\DATA"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtLoc.Text = "" Then Exit Sub
        If cboItems.SelectedIndex = -1 Then Exit Sub

        odcn = New OleDbConnection
        odcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtLoc.Text.Trim + ";Extended Properties=dBASE IV;User ID=Admin;Password="
        odcn.Open()
        Select Case cboItems.SelectedIndex
            Case 0
                tsql = "select g.GrpCode, g.descripton as GrpName, g.year as yropen, g.opbal2 as opbal, " & _
                "g.schedule as SchNo, g.status " & _
                "from grpmast g order by g.grpcode"
                oda = New OleDb.OleDbDataAdapter(tsql, odcn)
                ds1 = New DataSet
                oda.Fill(ds1)
                dgv1.DataSource = ds1.Tables(0)
            Case 1
                'Sundry Debtors
                tsql = "select g.descripton as AcName,g.year as yropen,g.opbal2 as opbal, " & _
                "p.shortname as accode, p.address1+p.address2+p.address3 as addr,p.rc_no,g.status,g.grpcode " & _
                "from glmast g,parties p where g.grpcode LIKE 'DA%' AND g.accode=p.code order by p.shortname,g.descripton"
                oda = New OleDb.OleDbDataAdapter(tsql, odcn)
                ds1 = New DataSet
                oda.Fill(ds1)
                dgv1.DataSource = ds1.Tables(0)
                Label3.Text = "Count:" & ds1.Tables(0).Rows.Count
            Case 2
                'Sundry Creditors
                tsql = "select g.descripton as AcName,g.year as yropen,g.opbal2 as opbal, " & _
                "p.shortname as accode, p.address1+p.address2+p.address3 as addr,p.rc_no,g.status,g.grpcode " & _
                "from glmast g,parties p where g.grpcode LIKE 'IA%' AND g.accode=p.code order by p.shortname,g.descripton"
                oda = New OleDb.OleDbDataAdapter(tsql, odcn)
                ds1 = New DataSet
                oda.Fill(ds1)
                dgv1.DataSource = ds1.Tables(0)
                Label3.Text = "Count:" & ds1.Tables(0).Rows.Count
            Case 3
                'Others
                tsql = "select g.descripton as AcName,g.year as yropen,g.opbal2 as opbal, " & _
                "g.status,g.grpcode " & _
                "from glmast g where g.accode NOT IN (select code from parties) order by g.descripton"
                oda = New OleDb.OleDbDataAdapter(tsql, odcn)
                ds1 = New DataSet
                oda.Fill(ds1)
                dgv1.DataSource = ds1.Tables(0)
                Label3.Text = "Count:" & ds1.Tables(0).Rows.Count
            Case 4
                'Reps
                tsql = "select g.Name " & _
                "from repmast g order by g.name"
                oda = New OleDb.OleDbDataAdapter(tsql, odcn)
                ds1 = New DataSet
                oda.Fill(ds1)
                dgv1.DataSource = ds1.Tables(0)
                Label3.Text = "Count:" & ds1.Tables(0).Rows.Count
        End Select
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim grid As Int32 = 0, grcd As String = "00"

        Select Case cboItems.SelectedIndex
            Case 0
                For Each dr As DataRow In ds1.Tables(0).Rows
                    Try
                        oGL.InsertUpdateGrp(0, dr("GrpName"), dr("grpcode"), _
                        IIf(IsDBNull(dr("SchNo")), "    ", dr("SchNo")), dr("YrOpen"), _
                        IIf(IsDBNull(dr("Status")), "G", dr("Status")), gCoId)
                    Catch ex As Exception
                        gError_Message("Could not import group " & dr("grpname"), MsgBoxStyle.OkOnly)
                    End Try
                Next
            Case 1
                For Each dr As DataRow In ds1.Tables(0).Rows
                    If grcd <> dr("grpcode") Then
                        grcd = dr("grpcode")
                        dt1 = oGL.GetGrpList(gCoId, "grpcode='" & grcd & "'")
                        If dt1.Rows.Count > 0 Then
                            grid = dt1.Rows(0).Item("Grp_Id")
                        Else
                            grid = 0
                        End If
                    End If
                    Try
                        oGL.InsertUpdateGL(0, NoDbNull(dr("AcName"), ""), grid, NoDbNull(dr("YrOpen"), "  "), _
                            dr("opbal"), 0, NoDbNull(dr("Status"), "G"), gCoId, NoDbNull(dr("AcCode"), " "), _
                            "", NoDbNull(dr("RC_no"), " "), "", "", NoDbNull(dr("Addr"), ""), _
                            NoDbNull(dr("Addr"), ""), "", "", "", "", "", False)
                    Catch ex As Exception
                        gError_Message("Could not import a/c " & dr("Acname"), MsgBoxStyle.OkOnly)
                    End Try
                Next
            Case 2
                For Each dr As DataRow In ds1.Tables(0).Rows
                    If grcd <> dr("grpcode") Then
                        grcd = dr("grpcode")
                        dt1 = oGL.GetGrpList(gCoId, "grpcode='" & grcd & "'")
                        If dt1.Rows.Count > 0 Then
                            grid = dt1.Rows(0).Item("Grp_Id")
                        Else
                            grid = 0
                        End If
                    End If
                    Try
                        oGL.InsertUpdateGL(0, NoDbNull(dr("AcName"), ""), grid, NoDbNull(dr("YrOpen"), "  "), _
                            dr("opbal"), 0, NoDbNull(dr("Status"), "G"), gCoId, NoDbNull(dr("AcCode"), " "), _
                            "", NoDbNull(dr("RC_no"), " "), "", "", NoDbNull(dr("Addr"), ""), _
                            NoDbNull(dr("Addr"), ""), "", "", "", "", "", False)
                    Catch ex As Exception
                        gError_Message("Could not import a/c " & dr("Acname"), MsgBoxStyle.OkOnly)
                    End Try
                Next
            Case 3
                'Others
                For Each dr As DataRow In ds1.Tables(0).Rows
                    If grcd <> dr("grpcode") Then
                        grcd = dr("grpcode")
                        dt1 = oGL.GetGrpList(gCoId, "grpcode='" & grcd & "'")
                        If dt1.Rows.Count > 0 Then
                            grid = dt1.Rows(0).Item("Grp_Id")
                        Else
                            grid = 0
                        End If
                    End If
                    Try
                        oGL.InsertUpdateGL(0, NoDbNull(dr("AcName"), ""), grid, NoDbNull(dr("YrOpen"), "  "), _
                            dr("opbal"), 0, NoDbNull(dr("Status"), "G"), gCoId, " ", _
                            "", " ", "", "", "", _
                            "", "", "", "", "", "", False)
                    Catch ex As Exception
                        gError_Message("Could not import a/c " & dr("Acname"), MsgBoxStyle.OkOnly)
                    End Try
                Next
            Case 4
                'Reps
                For Each dr As DataRow In ds1.Tables(0).Rows
                    Try
                        oRp.InsertUpdateRep(0, NoDbNull(dr("Name"), ""), gCoId)
                    Catch ex As Exception
                        gError_Message("Could not import rep " & dr("name"), MsgBoxStyle.OkOnly)
                    End Try
                Next
        End Select
    End Sub
End Class