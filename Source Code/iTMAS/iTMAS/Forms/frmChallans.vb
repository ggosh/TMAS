Public Class frmChallans

    Dim objChal As New clsChallan

    Private Sub frmChallans_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 2
        PopulateChallans()
    End Sub

    Private Sub frmChallans_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 2
        dtpChDt.Value = Today
        PopulateChallans()
    End Sub

    Private Sub PopulateChallans()
        Dim dt As DataTable
        Dim Flt As String, dy As Date

        Label8.Visible = True
        dy = dtpChDt.Value
        Flt = "c.chal_dt='" & dy.ToString("dd MMM yyyy") & "'"

        dt = objChal.GetChalList(gCoId, Flt)
        dgvChallans.DataSource = dt
        dgvChallans.Columns(0).Visible = False
        dgvChallans.Columns(1).Width = 70
        dgvChallans.Columns(2).Width = 100
        dgvChallans.Columns(3).Width = 100
        dgvChallans.Columns(4).Width = 100
        dgvChallans.Columns(5).Visible = False
        dgvChallans.Columns(6).Width = 150
        dgvChallans.Columns(7).Visible = False
        dgvChallans.Columns(8).Width = 80
        dgvChallans.Columns(9).Visible = False
        dgvChallans.Columns(10).Width = 70
        dgvChallans.Columns(11).Visible = False
        dgvChallans.Columns(12).Width = 100
        dgvChallans.Columns(13).Visible = False
        dgvChallans.Columns(14).Width = 80
        dgvChallans.Columns(15).Width = 70
        dgvChallans.Columns(16).Width = 70
        dgvChallans.Columns(17).Width = 70
        dgvChallans.Columns(18).Visible = False
        If dgvChallans.Rows(0).Cells(18).Value = 0 Then
            btnUnld.Enabled = True
        Else
            btnUnld.Enabled = False
        End If
        Label8.Visible = False
    End Sub

    Private Sub frmChallans_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim objChallan As New frmChallan
        objChallan.MdiParent = Me.MdiParent
        objChallan.Show()
        objChallan.BringToFront()
        objChallan.gbUnld.Enabled = False
        objChallan.gbDtn2.Enabled = False
        objChallan.btnSave2.Enabled = False
        objChallan.btnCancel2.Enabled = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim objChallan As New frmChallan
        objChallan.MdiParent = Me.MdiParent
        objChallan.iChal_id = dgvChallans.CurrentRow.Cells(0).Value
        objChallan.Show()
        objChallan.BringToFront()
    End Sub

    Private Sub btnUnld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnld.Click
        Dim objChallan As New frmChallan
        objChallan.MdiParent = Me.MdiParent
        objChallan.iChal_id = dgvChallans.CurrentRow.Cells(0).Value
        objChallan.Show()
        objChallan.BringToFront()
        objChallan.gbLoad.Enabled = False
        objChallan.gbProd.Enabled = False
        objChallan.gbDtn1.Enabled = False
        objChallan.btnSave.Enabled = False
        objChallan.btnCancel.Enabled = False
    End Sub

    Private Sub txtFindChNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindChNo.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0

        If txtFindChNo.Text.ToUpper.Trim.Length > 0 Then
            i = dgvChallans.SelectedRows.Count
            For Each Rw In dgvChallans.Rows
                If Rw.Cells(3).Value.ToString.StartsWith(txtFindChNo.Text.ToUpper.Trim) Then
                    For Each rw2 In dgvChallans.SelectedRows
                        rw2.Selected = False
                    Next
                    dgvChallans.Rows(Rw.Index).Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnFilt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilt.Click
        PopulateChallans()
    End Sub

    Private Sub dgvChallans_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChallans.CellClick
        If dgvChallans.CurrentRow.Cells(18).Value = 0 Then
            btnUnld.Enabled = True
        Else
            btnUnld.Enabled = False
        End If
    End Sub
End Class
