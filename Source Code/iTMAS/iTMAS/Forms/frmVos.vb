Public Class frmVos

    Dim objVo As New clsVouch

    Private Sub frmVos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpVoDt.Value = Today
        btnCBV_Click(sender, e)
    End Sub

    Private Sub PopulateVos()
        Dim dt As DataTable
        Dim d As Date
        Dim Flt As String

        d = dtpVoDt.Value
        Label8.Visible = True
        Flt = "a.vo_dt='" & d.ToLongDateString.Substring(InStr(d.ToLongDateString, ",") + 1) & "'" & _
                IIf(gUObj = 5, " and a.type in ('P','R','C')", " and a.type='J'")

        dt = objVo.GetVoList(gCoId, Flt)
        dgvVos.DataSource = dt
        dgvVos.Columns(0).Visible = False
        dgvVos.Columns(1).Width = 70      'vo no
        dgvVos.Columns(2).Width = 70      'vo dt
        dgvVos.Columns(3).Width = 70      'type
        dgvVos.Columns(4).Width = 70      'cheque
        dgvVos.Columns(5).Width = 150     'account
        dgvVos.Columns(6).Width = 90      'amount
        dgvVos.Columns(7).Width = 50      'dr/cr

        Label8.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If gUObj = 5 Then
            Dim objV As New frmCBV
            objV.MdiParent = Me.MdiParent
            objV.Show()
            objV.BringToFront()
        Else
            'Dim objV As New frmJV
            'objv.MdiParent = Me.MdiParent
            'objv.Show()
            'objv.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If gUObj = 5 Then
            Dim objV As New frmCBV
            objV.MdiParent = Me.MdiParent
            objV.iV_id = dgvVos.CurrentRow.Cells(0).Value
            objV.Show()
            objV.BringToFront()
        Else
            'Dim objV As New frmJV
            'objv.MdiParent = Me.MdiParent
            'objv.Show()
            'objv.BringToFront()
        End If
    End Sub

    Private Sub frmVos_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Sub txtFindVoNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindVoNo.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0

        If txtFindVoNo.Text.ToUpper.Trim.Length > 0 Then
            i = dgvVos.SelectedRows.Count
            For Each rw2 In dgvVos.SelectedRows
                rw2.Selected = False
            Next
            For Each Rw In dgvVos.Rows
                If Rw.Cells(1).Value.ToString.StartsWith(txtFindVoNo.Text.ToUpper.Trim) Then
                    dgvVos.Rows(Rw.Index).Selected = True
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub btnCBV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCBV.Click
        gUObj = 5
        PopulateVos()
        btnCBV.Image = WinAc.My.Resources.ti_led_green
        btnJV.Image = WinAc.My.Resources.blank1
    End Sub

    Private Sub btnJV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJV.Click
        gUObj = 6
        PopulateVos()
        btnCBV.Image = WinAc.My.Resources.blank1
        btnJV.Image = WinAc.My.Resources.ti_led_green
    End Sub

End Class