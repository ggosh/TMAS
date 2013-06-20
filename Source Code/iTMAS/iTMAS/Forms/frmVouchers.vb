Public Class frmVouchers

    Dim objGlmast As New clsGlmast

    Private Sub cboType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
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

    Private Sub frmVouchers_Load(sender As System.Object, e As System.EventArgs)
        dgvParty.Visible = False
        cboType.SelectedIndex = 0

    End Sub

    Public Function AutoCompleteLoad() As AutoCompleteStringCollection
        Dim accounts As List(Of String) = objGlmast.GetAllAccounts()
        Dim autoCompleteCollection As New AutoCompleteStringCollection()

        For Each item As String In accounts
            autoCompleteCollection.Add(item)
        Next

        Return autoCompleteCollection
    End Function

    Private Sub dgvVoucherDetail_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvVoucherDetail.EditingControlShowing
        Dim column As Integer = dgvVoucherDetail.CurrentCell.ColumnIndex
        Dim headerText As String = dgvVoucherDetail.Columns(column).HeaderText

        If headerText.Equals("Account") Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)

            If tb IsNot Nothing Then
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                tb.AutoCompleteCustomSource = AutoCompleteLoad()
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
        End If
    End Sub
End Class