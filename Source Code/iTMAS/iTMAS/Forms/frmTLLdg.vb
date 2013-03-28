Public Class frmTLLdg

    Dim objTL As New clsTLmast
    Dim TLid As Int32
    Dim Flt As String
    Private nonNumberEntered As Boolean = False

    Private Sub frmTLLdg_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 19
        If lTL Then
            PopulateTLs()
        End If
    End Sub

    Private Sub frmTLLdg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 19

        lblErr.Text = ""
        dtpStart.Value = gYrStart
        dtpEnd.Value = IIf(Date.Today > gYrEnd, gYrEnd, Date.Today)
        Flt = ""
        PopulateTLs()
        'tl_no like 'M%' / 'TL_No like ''%2569%'
    End Sub

    Private Sub PopulateTLs()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objTL.GetTLlist(gCoId, Flt)
        cboOwners.DataSource = dt
        cboOwners.DisplayMember = "[TL No]"
        cboOwners.ValueMember = "TL_Id"

        Label8.Visible = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sTLcd As String
            Dim bOwn As Boolean, bBown As Boolean
            Dim Owid As Int32
            Dim dStdt As Nullable(Of Date)
            Dim dEndt As Nullable(Of Date)

            If Validation() = False Then
                Exit Sub
            End If

            sTLcd = Me.txtTLCode.Text
            bBown = True
            If bOwn Then
                Owid = 0
            Else
                Owid = Me.cboOwners.SelectedValue
            End If
            dStdt = dtpStart.Value
            dEndt = dtpEnd.Value

            'TLid = objTL.InsertUpdateTL(TLid, sTLcd, sTLno, bOwn, bBown, Owid, dStdt, dEndt, gCoId)
            'lTL = True
            PopulateTLs()

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



        If passed = False Then
            gError_Message(errMsgs, MessageBoxButtons.OK + MessageBoxIcon.Error)
        End If
        Return passed
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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

    Private Sub frmTLLdg_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        gbEdit.Width = Me.Width - 41
        gbTLs.Width = Me.Width - 41
        dgvTLs.Width = gbTLs.Width - 14
    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

End Class
