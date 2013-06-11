Public Class frmVouchers

    Private Sub cboType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedItem = "Payment" Then
            dgvTL.Visible = True
            dgvParty.Visible = False
        ElseIf cboType.SelectedItem = "Receipt" Then
            dgvParty.Visible = True
            dgvTL.Visible = False
        ElseIf cboType.SelectedItem = "Contra" Then
            dgvParty.Visible = True
            dgvTL.Visible = False
        ElseIf cboType.SelectedItem = "Journal" Then
            dgvParty.Visible = False
            dgvTL.Visible = False
        End If
    End Sub

    Private Sub frmVouchers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgvParty.Visible = False
        cboType.SelectedIndex = 0
    End Sub
End Class