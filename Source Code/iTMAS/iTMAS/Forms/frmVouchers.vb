Public Class frmVouchers

    Dim objGlmast As New clsGlmast
    Dim subLedgerAccounts As List(Of String)

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

    Private Sub frmVouchers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgvParty.Visible = False
        cboType.SelectedIndex = 0
        txtDate.Text = System.DateTime.Today
        dgvParty.Visible = False
        dgvTL.Visible = False
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherDetail.CellValueChanged
        UpdateBalance()
        CheckBalance()
    End Sub

    Private Sub UpdateBalance()
        If dgvVoucherDetail IsNot Nothing Then
            If dgvVoucherDetail.CurrentRow IsNot Nothing Then
                Dim accountName As String = dgvVoucherDetail.CurrentRow.Cells("Account").Value
                dgvVoucherDetail.CurrentRow.Cells("Balance").Value = objGlmast.GetBalance(accountName.Trim(""))
            End If
        End If
    End Sub

    Private Sub dgvOthers_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvOthers.EditingControlShowing
        Dim row As DataGridViewRow = dgvVoucherDetail.CurrentRow
        If row IsNot Nothing Then
            Dim accountName As String = row.Cells("Account").Value
            If accountName IsNot Nothing Then
                subLedgerAccounts = objGlmast.GetSubLedgerDetailsByAccount(accountName.Trim(""))
                Dim column As Integer = dgvOthers.CurrentCell.ColumnIndex
                Dim headerText As String = dgvOthers.Columns(column).HeaderText
                If headerText.Equals("Sub Ledger Account") Then
                    Dim tb As TextBox = TryCast(e.Control, TextBox)
                    If tb IsNot Nothing Then
                        If subLedgerAccounts.Count > 0 Then
                            tb.ReadOnly = False
                            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                            tb.AutoCompleteCustomSource = AutoCompleteForSubLedger()
                            tb.AutoCompleteSource = AutoCompleteSource.CustomSource
                            dgvOthers.CurrentRow.Cells("ParentAccount").Value = accountName
                        Else
                            tb.ReadOnly = True
                        End If
                    End If
                End If
            Else
                MsgBox("Please select an account.", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("Please select an account.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Public Function AutoCompleteForSubLedger() As AutoCompleteStringCollection
        Dim autoCompleteCollection As New AutoCompleteStringCollection()
        For Each item As String In subLedgerAccounts
            autoCompleteCollection.Add(item)
        Next
        Return autoCompleteCollection
    End Function

    Private Sub CheckBalance()
        If dgvVoucherDetail IsNot Nothing Then
            If dgvVoucherDetail.CurrentRow IsNot Nothing Then
                Dim column As Integer = dgvVoucherDetail.CurrentCell.ColumnIndex
                Dim headerText As String = dgvVoucherDetail.Columns(column).HeaderText
                Dim drAmt As String = dgvVoucherDetail.CurrentRow.Cells("DrAmt").Value
                Dim crAmt As String = dgvVoucherDetail.CurrentRow.Cells("CrAmt").Value
                If Convert.ToDecimal(drAmt) > 0 And Convert.ToDecimal(crAmt) > 0 Then
                    MsgBox("You cannot enter amount in both debit and credit fields.", MsgBoxStyle.OkOnly)
                    dgvVoucherDetail.CurrentCell.Value = 0
                End If
                If headerText.Equals("Dr. Amount") Then
                    Dim balance As String = dgvVoucherDetail.CurrentRow.Cells("Balance").Value
                    If dgvVoucherDetail.CurrentCell.Value > balance Then
                        MsgBox("Debit amount can't be greater than balance.", MsgBoxStyle.OkOnly)
                        dgvVoucherDetail.CurrentCell.Value = 0
                    End If
                End If
                If headerText.Equals("Cr. Amount") Then
                    Dim balance As String = dgvVoucherDetail.CurrentRow.Cells("Balance").Value
                    If dgvVoucherDetail.CurrentCell.Value > balance Then
                        MsgBox("Credit amount can't be greater than balance.", MsgBoxStyle.OkOnly)
                        dgvVoucherDetail.CurrentCell.Value = 0
                    End If
                End If
                Dim accountName As String = dgvVoucherDetail.CurrentRow.Cells("Balance").Value
                dgvVoucherDetail.CurrentRow.Cells("Balance").Value = objGlmast.GetBalance(accountName.Trim(""))
            End If
        End If
    End Sub

    Private Sub dgvOthers_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOthers.CellValueChanged
        If dgvOthers IsNot Nothing Then
            If dgvOthers.CurrentRow IsNot Nothing Then
                Dim parent As String = dgvOthers.CurrentRow.Cells("parentAccount").Value
                Dim amount As Decimal = 0
                For Each row As DataGridViewRow In dgvOthers.Rows
                    If row.Cells("parentAccount").Value = parent Then
                        amount = amount + row.Cells("Amount").Value
                    End If
                Next
                Dim balance As Decimal = dgvVoucherDetail.CurrentRow.Cells("balance").Value
                If amount > balance Then
                    MsgBox("You cannot enter amount greater than balance.", MsgBoxStyle.OkOnly)
                    dgvOthers.CurrentRow.Cells("amount").Value = 0
                End If
            End If
        End If
    End Sub
End Class