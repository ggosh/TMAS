Public Class frmTLexp

    Dim objTE As New clsTLexp
    Dim objGL As New clsGlmast
    Dim Teid As Int32
    Dim Tlc As String

    Private Sub frmTLexp_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 18
        If lAcc Then
            PopulateGLs()
            PopulateTEs()
        End If
    End Sub

    Private Sub frmTLexp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 18

        Me.Top = 20
        Me.Left = 0

        lblErr.Text = ""
        Teid = 0
        PopulateGLs()
        PopulateTEs()
    End Sub

    Private Sub frmTLexp_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim r As Size
        r.Height = Me.Height - 226
        r.Width = Me.Width - 36
        GroupBox1.Width = r.Width
        dgvTEs.Size = r
        If Not dgvTEs.DataSource Is Nothing Then
            dgvTEs.Columns(2).Width = (Me.Width - 56) / 10 * 4
            dgvTEs.Columns(3).Width = (Me.Width - 56) / 10 * 5
        End If
        btnNew.Top = dgvTEs.Top + r.Height + 8
        btnEdit.Top = btnNew.Top
        btnDel.Top = btnNew.Top
        Label18.Top = btnNew.Top + 2
        txtFind.Top = btnNew.Top + 1
        btnRef.Top = btnNew.Top
    End Sub

    Private Sub PopulateGLs()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True

        Flt = IIf(gStock, "", "g.status not in ('K','P')")
        dt = objGL.GetGLList(gCoId, Flt)
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("gl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboGL.DataSource = dt
        cboGL.DisplayMember = "Name"
        cboGL.ValueMember = "gl_id"
        cboGL.AutoCompleteSource = AutoCompleteSource.ListItems
        cboGL.AutoCompleteMode = AutoCompleteMode.Suggest

        Label8.Visible = False

    End Sub

    Private Sub PopulateTEs()
        Dim dtG As DataTable

        Label8.Visible = True

        dtG = objTE.GetTLexplist(gCoId)
        dgvTEs.DataSource = dtG
        dgvTEs.Columns(0).Visible = False
        dgvTEs.Columns(1).Visible = False
        dgvTEs.Columns(2).Width = (Me.Width - 56) / 10 * 4
        dgvTEs.Columns(3).Width = (Me.Width - 56) / 10 * 5

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Teid = 0
        Tlc = objTE.NewTLexpCode.ToString
        If Tlc.Trim.Length = 1 Then
            txtCode.Text = Tlc
        Else
            txtCode.Text = ""
            ShowError(txtCode, Tlc)
        End If
        txtName.Text = ""
        cboGL.SelectedValue = -1
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        Teid = dgvTEs.CurrentRow.Cells(0).Value
        dt = objTE.GetTLexpDetails(Teid)
        dr = dt.Rows(0)
        txtCode.Text = dr("ExpCode")
        txtName.Text = dr("ExpName")
        cboGL.SelectedValue = dr("GL_id")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sGlcd As String, sGlNm As String
            Dim GLId As Int32

            If Validation() = False Then
                Exit Sub
            End If

            sGlcd = Me.txtCode.Text.Trim
            sGlNm = Me.txtName.Text.Trim
            GLId = Me.cboGL.SelectedValue

            Teid = objTE.InsertUpdateTLexp(Teid, sGlcd, sGlNm, GLId, gCoId)
            lAcc = True
            PopulateTEs()
            btnNew_Click(sender, e)

        Catch ex As Exception
            gError_Message("Error saving record.", MessageBoxButtons.OK + MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function Validation() As Boolean
        Dim passed As Boolean
        Dim errMsgs As String

        passed = True
        errMsgs = ""

        If Me.txtName.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Exp Name can not be blank." + vbCrLf
            passed = False
        End If

        If Me.cboGL.SelectedValue = 0 Then
            errMsgs = errMsgs + "A/c can not be blank." + vbCrLf
            passed = False
        End If

        If passed = False Then
            gError_Message(errMsgs, MessageBoxButtons.OK + MessageBoxIcon.Error)
        End If
        Return passed
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Teid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboGL.SelectedValue = 0
    End Sub

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateTEs()
    End Sub

    Private Sub txtFind_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyUp
        Dim s As String, i As Integer

        s = txtFind.Text.Trim
        i = -1
        If e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Then
            For Each dgr As DataGridViewRow In dgvTEs.Rows
                If dgr.Cells(1).Value.ToString.ToUpper.Substring(0, s.Length) = s.ToUpper Then
                    dgvTEs.CurrentCell = dgr.Cells(1)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        ShowError(txtName, "")
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If txtName.Text.Trim.Length > 0 Then
            If objTE.ChkDuplicateTLexp(Teid, txtName.Text) > 0 Then
                e.Cancel = True
                ShowError(txtName, "Duplicate Expense!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

End Class