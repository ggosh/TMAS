Public Class frmVouchers

    Dim objGlmast As New clsGlmast
    Dim subLedgerAccounts As List(Of String)

    Public Function AutoCompleteLoad() As AutoCompleteStringCollection
        Dim accounts As List(Of String) = objGlmast.GetAllAccounts()
        Dim autoCompleteCollection As New AutoCompleteStringCollection()
        For Each item As String In accounts
            autoCompleteCollection.Add(item)
        Next
        Return autoCompleteCollection
    End Function

    Private Sub dgvVoucherDetail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvVoucherDetail.EditingControlShowing
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

    Private Sub frmVouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvParty.Visible = False
        cboType.SelectedIndex = 0
        txtDate.Text = System.DateTime.Today
        dgvParty.Visible = False
        dgvTL.Visible = False
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherDetail.CellValueChanged
        If dgvVoucherDetail IsNot Nothing Then
            If dgvVoucherDetail.CurrentCell IsNot Nothing Then
                Dim column As Integer = dgvVoucherDetail.CurrentCell.ColumnIndex
                Dim headerText As String = dgvVoucherDetail.Columns(column).HeaderText
                If headerText.Equals("Account") Then
                    UpdateBalance()
                    CheckBalance()
                End If
            End If
        End If
    End Sub

    Private Sub UpdateBalance()
        If dgvVoucherDetail IsNot Nothing Then
            If dgvVoucherDetail.CurrentRow IsNot Nothing Then
                Dim accountName As String = dgvVoucherDetail.CurrentRow.Cells("Account").Value
                dgvVoucherDetail.CurrentRow.Cells("Balance").Value = objGlmast.GetBalance(accountName.Trim(""))
            End If
        End If
    End Sub

    Private Sub dgvOthers_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvOthers.EditingControlShowing
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

    Private Sub dgvOthers_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOthers.CellValueChanged
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim voucherDetails As VoucherDTO = New VoucherDTO()
        voucherDetails.AcId = 0
        voucherDetails.VoucherNo = txtVoucherNo.Text.Trim()
        voucherDetails.VoucherDate = txtDate.Text.Trim()
        voucherDetails.VType = GetVoucherType()
        voucherDetails.ChqNo = txtChqNo.Text.Trim()
        voucherDetails.BankDate = DateTime.Now
        voucherDetails.Amt = 0
        voucherDetails.CoCd = String.Empty
        voucherDetails.Brn = String.Empty
        voucherDetails.YrCd = String.Empty
        voucherDetails.RefId = 0
        voucherDetails.Narr = String.Empty
        voucherDetails.Dtls = String.Empty
        voucherDetails.SDtls = String.Empty

        Dim clsVoucher As clsVouch = New clsVouch()
        clsVoucher.InsertUpdateVouch(voucherDetails)

        'For Each row As DataGridViewRow In dgvVoucherDetail.Rows

        'Next
    End Sub

    Private Function GetVoucherType() As String
        Dim voucherType As String = String.Empty
        Select Case cboType.SelectedItem
            Case "Payment"
                voucherType = "P"
            Case "Receipt"
                voucherType = "R"
            Case "Contra"
                voucherType = "C"
            Case "Journal"
                voucherType = "J"
        End Select

        Return voucherType
    End Function
End Class