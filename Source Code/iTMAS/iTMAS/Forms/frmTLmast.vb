Public Class frmTLmast

    Dim objTL As New clsTLmast
    Dim TLid As Int32
    Dim Flt As String
    Private nonNumberEntered As Boolean = False

    Private Sub frmTLmast_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 11
        If lAcc Then
            PopulateOwners()
        End If
    End Sub

    Private Sub frmTLmast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 11

        lblErr.Text = ""
        dtpStart.Value = Date.Today
        Flt = ""
        PopulateTLs()
        PopulateOwners()
        'tl_no like 'M%' / 'TL_No like ''%2569%'
    End Sub

    Private Sub PopulateTLs()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objTL.GetTLlist(gCoId, Flt)
        dgvTLs.DataSource = dt
        dgvTLs.Columns(0).Visible = False
        dgvTLs.Columns(1).Width = 100
        dgvTLs.Columns(2).Width = 50
        dgvTLs.Columns(3).Width = 50
        dgvTLs.Columns(4).Visible = False
        dgvTLs.Columns(5).Width = 150
        dgvTLs.Columns(6).Width = 80
        dgvTLs.Columns(7).Width = 80

        Label8.Visible = False

    End Sub

    Private Sub PopulateOwners()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objTL.GetOwnerlist(gCoId)
        cboOwners.DataSource = dt
        cboOwners.DisplayMember = "AcName"
        cboOwners.ValueMember = "Gl_Id"

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        TLid = 0
        lblCode.Text = "0000"
        txtTL_NO.Text = ""
        chkOwn.Checked = False
        cboOwners.SelectedValue = 0
        dtpStart.Value = Today
        txtEnd.Text = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        TLid = dgvTLs.CurrentRow.Cells(0).Value
        dt = objTL.GetTLDetails(TLid)
        dr = dt.Rows(0)
        lblCode.Text = dr("TL_code")
        txtTL_NO.Text = dr("TL_no")
        chkOwn.Checked = dr("Own")
        cboOwners.SelectedValue = dr("owner_id")
        dtpStart.Value = dr("start_date")
        txtEnd.Text = ""
        If dr("end_date").ToString <> "" Then
            dtpEnd.Value = dr("end_date")
            txtEnd.Text = dtpEnd.Value.ToShortDateString
        End If
        txtTL_NO.Focus()

    End Sub

    Private Sub btnDupli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDupli.Click

        TLid = 0
        lblCode.Text = "0000"
        txtTL_NO.Text = dgvTLs.CurrentRow.Cells(1).Value
        chkOwn.Checked = False
        cboOwners.SelectedValue = 0
        dtpStart.Value = Today
        txtEnd.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sTLno As String, sTLcd As String
            Dim bOwn As Boolean, bBown As Boolean
            Dim Owid As Int32
            Dim dStdt As Nullable(Of Date)
            Dim dEndt As Nullable(Of Date)

            If Validation() = False Then
                Exit Sub
            End If

            sTLcd = Me.lblCode.Text
            sTLno = Me.txtTL_NO.Text.Trim
            bOwn = Me.chkOwn.Checked
            bBown = True
            If bOwn Then
                Owid = 0
            Else
                Owid = Me.cboOwners.SelectedValue
            End If
            dStdt = dtpStart.Value
            If txtEnd.Text.Trim.Length > 0 Then
                dEndt = dtpEnd.Value
            End If

            TLid = objTL.InsertUpdateTL(TLid, sTLcd, sTLno, bOwn, bBown, Owid, dStdt, dEndt, gCoId)
            lTL = True
            PopulateTLs()
            btnNew_Click(sender, e)

            Dim Rw, rw2 As DataGridViewRow
            Dim i As Integer = 0

            i = dgvTLs.SelectedRows.Count
            For Each Rw In dgvTLs.Rows
                If Rw.Cells(0).Value.ToString.Equals(TLid.ToString.Trim) Then
                    For Each rw2 In dgvTLs.SelectedRows
                        rw2.Selected = False
                    Next
                    dgvTLs.Rows(Rw.Index).Selected = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            gError_Message("Error ! (" + ex.Message + ").", MessageBoxButtons.OK + MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Validation() As Boolean
        Dim passed As Boolean
        Dim errMsgs As String
        passed = True
        errMsgs = ""
        If Me.txtTL_NO.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "T/L No. can not be blank." + vbCrLf
            passed = False
        End If

        If chkOwn.Checked = False And cboOwners.SelectedValue < 1 Then
            errMsgs = errMsgs + "Select an owner." + vbCrLf
            passed = False
        End If

        If txtStart.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Select start date." + vbCrLf
            passed = False
        End If

        Dim dt As DataTable

        dt = objTL.GetTLbyNo(txtTL_NO.Text.Trim)
        For Each rw As DataRow In dt.Rows
            If rw("start_date") > dtpStart.Value Then
                errMsgs = errMsgs + "Invalid start date (existing " & rw("start_date").ToString & ")." + vbCrLf
                passed = False
            End If
        Next

        If passed = False Then
            gError_Message(errMsgs, MessageBoxButtons.OK + MessageBoxIcon.Error)
        End If
        Return passed
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Me.Close()
    End Sub

    Private Sub txtEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            txtEnd.Text = ""
        End If
    End Sub

    Private Sub dtpStart_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStart.ValueChanged
        txtStart.Text = dtpStart.Text
    End Sub

    Private Sub dtpEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEnd.ValueChanged
        txtEnd.Text = dtpEnd.Text
    End Sub

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateTLs()
    End Sub

    Private Sub txtFindNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindNo.KeyUp
        If e.KeyCode = Keys.Enter Then
            dgvTLs.Focus()
        End If
    End Sub

    Private Sub txtFindNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindNo.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0

        i = dgvTLs.SelectedRows.Count
        For Each Rw In dgvTLs.Rows
            If Rw.Cells(1).Value.ToString.StartsWith(txtFindNo.Text.ToUpper.Trim) Then
                For Each rw2 In dgvTLs.SelectedRows
                    rw2.Selected = False
                Next
                dgvTLs.Rows(Rw.Index).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub txtFindOnlyNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindOnlyNo.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtFindOnlyNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindOnlyNo.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        End If

    End Sub

    Private Sub txtFindOnlyNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindOnlyNo.KeyUp
        If e.KeyCode = Keys.Enter Then
            dgvTLs.Focus()
        End If
    End Sub

    Private Sub txtFindOnlyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindOnlyNo.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0

        i = dgvTLs.SelectedRows.Count
        For Each Rw In dgvTLs.Rows
            If Rw.Cells(1).Value.ToString.Contains(txtFindOnlyNo.Text.ToUpper.Trim) Then
                For Each rw2 In dgvTLs.SelectedRows
                    rw2.Selected = False
                Next
                dgvTLs.Rows(Rw.Index).Selected = True
                Exit For
            End If
        Next

    End Sub

    Private Sub frmTLmast_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        gbEdit.Width = Me.Width - 41
        gbTLs.Width = Me.Width - 41
        dgvTLs.Width = gbTLs.Width - 14
    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

    Private Sub txtTL_NO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTL_NO.Validated
        ShowError(txtTL_NO, "")
    End Sub

    Private Sub txtTL_NO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTL_NO.Validating
        If txtTL_NO.Text.Trim.Length > 15 Then
            e.Cancel = True
            ShowError(txtTL_NO, "Number too long!(Max 15)")
            Exit Sub
        End If
    End Sub
End Class
