Public Class frmVouchers

    Private Sub cboType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedItem = "T/L" Then
            dgvTL.Visible = True
            dgvParty.Visible = False
            lblGridHeader.Visible = True
            lblMessage.Text = "(Payment to market tankers)"
        ElseIf cboType.SelectedItem = "Party" Then
            dgvParty.Visible = True
            dgvTL.Visible = False
            lblGridHeader.Visible = True
            lblMessage.Text = "(Receipt from Party)"
        ElseIf cboType.SelectedItem = "Drivers" Then
            dgvParty.Visible = True
            dgvTL.Visible = False
            lblGridHeader.Visible = True
            lblMessage.Text = "(Payment to drivers)"
        ElseIf cboType.SelectedItem = "Others" Then
            dgvParty.Visible = False
            dgvTL.Visible = False
            lblGridHeader.Visible = False
            lblMessage.Text = "(Payment to others)"
        End If
    End Sub

    Private Sub frmVouchers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgvParty.Visible = False
        cboType.SelectedIndex = 0
    End Sub
End Class