Public Class frmGLmast

    Dim objGl As New clsGlmast
    Dim objSub As New clsSubMast
    Dim GLid As Int32

    Private Sub frmGLmast_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 16
        If lGrp Then
            PopulateGrps()
        End If
    End Sub

    Private Sub frmGLmast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 16

        Me.Top = 20
        Me.Left = 0

        lblErr.Text = ""
        GLid = 0
        dgvSubs.Visible = False
        gbAtSub.Visible = False
        PopulateGrps()
        PopulateGLs()
    End Sub

    Private Sub frmGLmast_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim r As Size
        r.Height = Me.Height - 405
        r.Width = Me.Width - 36
        GroupBox1.Width = r.Width
        dgvGLs.Size = r
        If Not dgvGLs.DataSource Is Nothing Then
            dgvGLs.Columns(1).Width = (Me.Width - 56) / 10 * 5
            dgvGLs.Columns(3).Width = (Me.Width - 56) / 10 * 4
            dgvGLs.Columns(4).Width = (Me.Width - 56) / 10 * 1
        End If
        btnNew.Top = dgvGLs.Top + r.Height + 8
        btnEdit.Top = btnNew.Top
        btnDel.Top = btnNew.Top
        'btnSubs.Top = btnNew.Top
        Label18.Top = btnNew.Top + 2
        txtFind.Top = btnNew.Top + 1
        btnRef.Top = btnNew.Top
    End Sub

    Private Sub PopulateGrps()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objGl.GetGrpList(gCoId, Flt)
        dr = dt.NewRow
        dr("GrpName") = "--Select--"
        dr("grp_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboGrp.DataSource = dt
        cboGrp.DisplayMember = "Grpname"
        cboGrp.ValueMember = "grp_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateGLs()
        Dim dtG As DataTable
        Dim Flt As String

        Label8.Visible = True
        Flt = IIf(gStock, "", "g.status not in ('K','P')")
        dtG = objGl.GetGLList(gCoId, Flt)
        dgvGLs.DataSource = dtG
        dgvGLs.Columns(0).Visible = False
        dgvGLs.Columns(2).Visible = False
        dgvGLs.Columns(1).Width = (Me.Width - 56) / 10 * 5
        dgvGLs.Columns(3).Width = (Me.Width - 56) / 10 * 4
        dgvGLs.Columns(4).Width = (Me.Width - 56) / 10 * 1
        Label8.Visible = False

    End Sub

    Private Sub PopulateSubGrps()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objSub.GetSGrList(gCoId, Flt)
        dr = dt.NewRow
        dr("SgrName") = "--Select--"
        dr("sgr_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboSGr.DataSource = dt
        cboSGr.DisplayMember = "SGrname"
        cboSGr.ValueMember = "sgr_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateSubs()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = IIf(cboSGr.SelectedIndex > 0, "g.sgr_id=" & cboSGr.SelectedValue, "")

        dt = objSub.GetSubList(gCoId, Flt)
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("sub_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboSub.DataSource = dt
        cboSub.DisplayMember = "name"
        cboSub.ValueMember = "sub_id"

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        GLid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboGrp.SelectedValue = GLid
        txtOpb.Text = ""
        txtPh.Text = ""
        txtRef.Text = ""
        txtAddr.Text = ""
        txtBlAd.Text = ""
        txtAttn.Text = ""
        txtkatn.Text = ""
        txtEncl.Text = ""
        txtPAN.Text = ""
        txtRC.Text = ""
        txtVAT.Text = ""
        txtECC.Text = ""
        chkSub.Checked = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        GLid = dgvGLs.CurrentRow.Cells(0).Value
        dt = objGl.GetGLDetails(GLid)
        dr = dt.Rows(0)
        txtCode.Text = dr("AcCode")
        txtName.Text = dr("AcName")
        cboGrp.SelectedValue = dr("Grp_id")
        txtOpb.Text = dr("opbal")
        txtPh.Text = dr("ph_no")
        txtRef.Text = dr("ref_no")
        txtAddr.Text = dr("addr")
        txtBlAd.Text = dr("bill_addr")
        txtAttn.Text = dr("attn")
        txtkatn.Text = dr("kattn")
        txtEncl.Text = dr("encl")
        txtPAN.Text = dr("IT_file")
        txtRC.Text = dr("RC_No")
        txtVAT.Text = dr("VAT_no")
        txtECC.Text = dr("ECC_no")
        chkSub.Checked = dr("HasSub")
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim sEr As String

        GLid = dgvGLs.CurrentRow.Cells(0).Value
        sEr = objGl.DeleteGL(GLid)
        If sEr.Trim.Length > 0 Then
            MsgBox("Cannot Delete A/c!" & vbCrLf & sEr)
        End If
        PopulateGLs()
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

            GLid = objGl.InsertUpdateGL(GLid, sGlNm, GrpId, yrOpen, Opb, Lyb, St, gCoId, sGlcd, txtPAN.Text.Trim, _
                txtRC.Text.Trim, txtVAT.Text.Trim, txtECC.Text.Trim, txtAddr.Text.Trim, txtBlAd.Text.Trim, txtRef.Text.Trim, _
                txtEncl.Text.Trim, txtAttn.Text.Trim, txtkatn.Text.Trim, txtPh.Text.Trim, chkSub.Checked)
            lAcc = True
            PopulateGLs()
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
            errMsgs = errMsgs + "A/c Name can not be blank." + vbCrLf
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
        GLid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboGrp.SelectedValue = GLid
        txtOpb.Text = ""
        txtPh.Text = ""
        txtRef.Text = ""
        txtAddr.Text = ""
        txtBlAd.Text = ""
        txtAttn.Text = ""
        txtkatn.Text = ""
        txtEncl.Text = ""
        txtPAN.Text = ""
        txtRC.Text = ""
        txtVAT.Text = ""
        txtECC.Text = ""
        chkSub.Checked = False
    End Sub

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateGLs()
    End Sub

    Private Sub btnGref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGref.Click
        PopulateGrps()
    End Sub

    Private Sub txtFind_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyUp
        Dim s As String, i As Integer

        s = txtFind.Text.Trim
        i = -1
        If e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Then
            For Each dgr As DataGridViewRow In dgvGLs.Rows
                If dgr.Cells(1).Value.ToString.ToUpper.Substring(0, s.Length) = s.ToUpper Then
                    dgvGLs.CurrentCell = dgr.Cells(1)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub dgvGLs_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLs.CellEnter
        If dgvGLs.CurrentRow.Cells(4).Value.ToString = "Y" Then
            btnSubs.Enabled = True
            btnAttSub.Enabled = True
        Else
            btnSubs.Enabled = False
            btnAttSub.Enabled = False
        End If
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        Me.ErrorPro.SetError(txtName, "")
        lblErr.Text = ""
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If txtName.Text.Trim.Length > 0 Then
            If objGl.ChkDuplicateGL(GLid, txtName.Text) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtName, "Duplicate A/c Head!")
                lblErr.Text = "Duplicate A/c Head!"
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.Validated
        Me.ErrorPro.SetError(txtName, "")
        lblErr.Text = ""
    End Sub

    Private Sub txtCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCode.Validating
        If txtCode.Text.Trim.Length > 0 Then
            If objGl.ChkDuplicateCode(GLid, txtCode.Text) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtCode, "Duplicate Code!")
                lblErr.Text = "Duplicate Code!"
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnSubs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubs.Click
        Dim dt As DataTable

        If dgvGLs.CurrentRow.Cells(4).Value.ToString = "Y" Then
            If dgvSubs.Visible Then
                dgvSubs.Visible = False
                btnSubs.Text = "Show Sub A/cs"
            Else
                GLid = dgvGLs.CurrentRow.Cells(0).Value
                dgvSubs.Visible = True
                btnSubs.Text = "Hide Sub A/cs"
                dt = objGl.GetGLSubList(GLid)
                dgvSubs.DataSource = dt
                dgvSubs.Columns(0).Visible = False
                dgvSubs.Columns(1).Width = dgvSubs.Width - 56
                dgvSubs.Columns(2).Visible = False
                dgvSubs.Columns(3).Visible = False
            End If
        End If
    End Sub

    Private Sub btnAttSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttSub.Click
        'attach sub a/c
        If dgvGLs.CurrentRow.Cells(4).Value.ToString = "Y" Then
            If gbAtSub.Visible Then
                gbAtSub.Visible = False
                btnAttSub.Enabled = True
            Else
                GLid = dgvGLs.CurrentRow.Cells(0).Value
                gbAtSub.Visible = True
                PopulateSubGrps()
                cboSGr.Focus()
                btnAttSub.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnAtC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtC.Click
        'cancel sub attach
        gbAtSub.Visible = False
        btnAttSub.Enabled = True
        btnAttSub.Focus()
        lblErr.Text = ""
    End Sub

    Private Sub btnAtt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtt.Click
        'save sub attach (opening?)
        If cboSub.SelectedValue > 0 Then
            objSub.InsertUpdateSubGl(0, GLid, cboSub.SelectedValue, gCoId)
            gbAtSub.Visible = False
            btnAttSub.Enabled = True
            btnAttSub.Focus()
            lblErr.Text = ""
        Else
            lblErr.Text = "No Sub A/c!"
            Exit Sub
        End If
    End Sub

    Private Sub cboSGr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSGr.Leave

        If cboSGr.SelectedValue > -1 Then
            PopulateSubs()
        End If

    End Sub

    Private Sub cboSub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSub.Validated
        Me.ErrorPro.SetError(cboSub, "")
        lblErr.Text = ""
    End Sub

    Private Sub cboSub_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboSub.Validating

        If cboSub.SelectedIndex > 0 Then
            If objSub.ChkDuplicateGLSub(GLid, cboSub.SelectedValue) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(cboSub, "Duplicate Sub A/c!")
                lblErr.Text = "Duplicate Sub A/c!"
                Exit Sub
            End If
        End If

    End Sub

End Class