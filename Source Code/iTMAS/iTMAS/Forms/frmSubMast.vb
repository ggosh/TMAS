Public Class frmSubMast

    Dim objSub As New clsSubMast
    Dim objGL As New clsGlmast
    Dim SubId As Int32
    Dim dtG As DataTable

    Private Sub frmSubMast_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 17
        If lAcc Then
            PopulateGLs()
        End If
        If lSGr Then
            PopulateGrps()
        End If
    End Sub

    Private Sub frmSubMast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 17
        SubId = 0

        PopulateSubs()
        PopulateGrps()
        Me.Left = frmMain.Width - Me.Width
    End Sub

    Private Sub frmSubMast_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim r As Size

        GroupBox1.Width = (Me.Width - 36)

        r.Height = Me.Height - 293
        r.Width = ((Me.Width - 36) / 9 * 5) - 2
        dgvSubs.Size = r
        If Not dgvSubs.DataSource Is Nothing Then
            dgvSubs.Columns(1).Width = (r.Width - 20) / 9 * 5
            dgvSubs.Columns(3).Width = (r.Width - 20) / 9 * 4
        End If

        r.Width = (Me.Width - 36) / 9 * 4
        dgvGLs.Size = r
        dgvGLs.Left = dgvSubs.Right + 2

        btnNew.Top = dgvSubs.Top + r.Height + 8
        btnEdit.Top = btnNew.Top
        btnDel.Top = btnNew.Top
        Label18.Top = btnNew.Top + 2
        txtFind.Top = btnNew.Top + 1
        btnSRef.Top = btnNew.Top
        'Me.Left = frmMain.Width - Me.Width
    End Sub

    Private Sub PopulateGrps()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objSub.GetSGrList(gCoId, Flt)
        dr = dt.NewRow
        dr("SgrName") = "--Select--"
        dr("sgr_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboGrp.DataSource = dt
        cboGrp.DisplayMember = "SGrname"
        cboGrp.ValueMember = "Sgr_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateSubs()
        Dim Flt As String

        Label8.Visible = True
        Flt = IIf(gStock, "", "")
        dtG = objSub.GetSubList(gCoId, Flt)
        dgvSubs.DataSource = dtG
        dgvSubs.Columns(0).Visible = False
        dgvSubs.Columns(2).Visible = False
        dgvSubs.Columns(1).Width = (dgvSubs.Width - 56) / 9 * 5
        dgvSubs.Columns(3).Width = (dgvSubs.Width - 56) / 9 * 4
        Label8.Visible = False

    End Sub

    Private Sub PopulateGLs()
        Dim dt As DataTable

        Label8.Visible = True
        dt = objSub.GetSubGLList(SubId)
        dgvGLs.DataSource = dt
        dgvGLs.Columns(0).Visible = False
        dgvGLs.Columns(1).Visible = False
        dgvGLs.Columns(2).Visible = False
        dgvGLs.Columns(3).Width = (dgvGLs.Width - 56)
        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Subid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboGrp.SelectedValue = -1
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        Subid = dgvSubs.CurrentRow.Cells(0).Value
        dt = objSub.GetSubDetails(Subid)
        dr = dt.Rows(0)
        txtCode.Text = dr("AcCode")
        txtName.Text = dr("SubName")
        cboGrp.SelectedValue = dr("SGr_id")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sGlcd As String, sGlNm As String, yrOpen As String, St As String
            Dim GrpId As Int32, Opb As Single, Lyb As Single


            If Validation() = False Then
                Exit Sub
            End If

            sGlcd = Me.txtCode.Text.Trim
            sGlNm = Me.txtName.Text.Trim
            GrpId = Me.cboGrp.SelectedValue
            St = "G"
            Opb = Val(txtOpb.Text) : Lyb = 0
            yrOpen = gAcYr.Substring(0, 3)

            SubId = objSub.InsertUpdateSub(SubId, sGlNm, GrpId, yrOpen, Opb, Lyb, St, gCoId, sGlcd, txtPAN.Text.Trim, _
                txtRC.Text.Trim, txtVAT.Text.Trim, txtAddr.Text.Trim, txtPh.Text.Trim)
            lSub = True
            lDrv = (GrpId = 1)
            PopulateSubs()
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
            errMsgs = errMsgs + "Sub A/c Name can not be blank." + vbCrLf
            passed = False
        End If

        If Me.cboGrp.SelectedValue = 0 Then
            errMsgs = errMsgs + "Group can not be blank." + vbCrLf
            passed = False
        End If

        If passed = False Then
            gError_Message(errMsgs, MessageBoxButtons.OK + MessageBoxIcon.Error)
        End If
        Return passed
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Subid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboGrp.SelectedValue = 0
    End Sub

    Private Sub btnSRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSRef.Click
        PopulateSubs()
    End Sub

    Private Sub txtFind_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyUp
        Dim s As String, i As Integer

        s = txtFind.Text.Trim
        i = -1
        If e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Then
            For Each dgr As DataGridViewRow In dgvSubs.Rows
                If dgr.Cells(1).Value.ToString.ToUpper.Substring(0, s.Length) = s.ToUpper Then
                    dgvSubs.CurrentCell = dgr.Cells(1)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub dgvSubs_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubs.CellClick
        SubId = dgvSubs.CurrentRow.Cells(0).Value
        PopulateGLs()
    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        ShowError(txtName, "")
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If txtName.Text.Trim.Length > 0 Then
            If objSub.ChkDuplicateSub(SubId, txtName.Text.Trim) > 0 Then
                e.Cancel = True
                ShowError(txtName, "Duplicate Sub A/c Name")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.Validated
        ShowError(txtCode, "")
    End Sub

    Private Sub txtCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCode.Validating
        If txtCode.Text.Trim.Length > 0 Then
            If objSub.ChkDuplicateSubCode(SubId, txtCode.Text.Trim) > 0 Then
                e.Cancel = True
                ShowError(txtCode, "Duplicate Code!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim sEr As String

        SubId = dgvSubs.CurrentRow.Cells(0).Value
        sEr = objSub.DeleteSub(SubId)
        If sEr.Trim.Length > 0 Then
            MsgBox("Cannot Delete SubHead!" & vbCrLf & sEr)
        End If
        PopulateSubs()
    End Sub
End Class