Public Class frmCBV

    Dim objVO As New clsVouch
    Dim objGL As New clsGlmast
    Dim objBl As New clsBill
    Dim objDashB As New clsDashboard
    Dim dtEVDtl, dtEBDtl As DataTable
    Dim dtETDtl, dtESDtl As DataTable
    Dim VoId As Int64 = 0
    Dim CBId As Int64 = 0
    Dim PtyId As Int64 = 0
    Dim CBstat As String = "     "
    Dim GLstat As String = "     "

    Public Property iV_id()
        Get
            iV_id = VoId
        End Get
        Set(ByVal value)
            VoId = value
        End Set
    End Property

    Private Sub frmCBV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 5
    End Sub

    Private Sub frmCBV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 5

        lblErr.Text = ""
        PopulateBrns()
        PopulateTypes()
        PopulateDr()
        PopulateCBs()
        PopulateGLs()
        If VoId <> 0 Then
            PopulateVo()
            cboType.Enabled = False
        Else
            EmptyVO()
            'dtpVoDt.Value = Today
            'cboType.SelectedValue = "P"
            'Label30.Text = "Cr."
            'cboDr.SelectedValue = "D"
            cboType.Enabled = True
        End If
    End Sub

    Private Sub frmCBV_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Sub PopulateTypes()
        Dim dt As New DataTable, dr As DataRow

        Label8.Visible = True

        dt.Columns.Add("vTy", Type.GetType("System.String"))
        dt.Columns.Add("VType", Type.GetType("System.String"))
        dr = dt.Rows.Add()
        dr.Item("vTY") = "P"
        dr.Item("VType") = "Payment"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "R"
        dr.Item("VType") = "Receipt"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "C"
        dr.Item("VType") = "Contra"

        cboType.DisplayMember = "VType"
        cboType.ValueMember = "vTy"
        cboType.DataSource = dt

        Label8.Visible = False

    End Sub

    Private Sub PopulateDr()
        Dim dt As New DataTable, dr As DataRow

        Label8.Visible = True

        dt.Columns.Add("vTy", Type.GetType("System.String"))
        dt.Columns.Add("VType", Type.GetType("System.String"))
        dr = dt.Rows.Add()
        dr.Item("vTY") = "D"
        dr.Item("VType") = "Dr"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "C"
        dr.Item("VType") = "Cr"

        cboDr.DisplayMember = "VType"
        cboDr.ValueMember = "vTy"
        cboDr.DataSource = dt

        Label8.Visible = False

    End Sub

    Private Sub PopulateCBs()
        Dim dt As DataTable, dr As DataRow
        Dim objGL As New clsGlmast

        Label8.Visible = True
        dt = objGL.GetGLList(gCoId, "g.status in ('C','B')")
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("gl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboCBs.DisplayMember = "Name"
        cboCBs.ValueMember = "gl_id"
        cboCBs.DataSource = dt
        'cboCBs.AutoCompleteSource = AutoCompleteSource.ListItems
        'cboCBs.AutoCompleteMode = AutoCompleteMode.Suggest
        Label8.Visible = False

    End Sub

    Private Sub PopulateGLs()
        Dim dt As DataTable, dr As DataRow
        Dim objGL As New clsGlmast

        Label8.Visible = True
        dt = objGL.GetGLList(gCoId, "g.status<>'P'")
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("gl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboGLs.DisplayMember = "Name"
        cboGLs.ValueMember = "gl_id"
        cboGLs.DataSource = dt
        cboGLs.AutoCompleteSource = AutoCompleteSource.ListItems
        cboGLs.AutoCompleteMode = AutoCompleteMode.Suggest
        Label8.Visible = False

    End Sub

    Private Sub PopulateBrns()
        Dim dt As DataTable

        Label8.Visible = True
        dt = objDashB.GetBranches(gCoId)
        cboBrns.DisplayMember = "br_code"
        cboBrns.ValueMember = "br_id"
        cboBrns.DataSource = dt
        If dt.Rows.Count = 1 Then
            cboBrns.Visible = False
            Label46.Visible = False
        End If
        Label8.Visible = False

    End Sub

    Private Sub PopulateVo()
        Dim DS As DataSet
        Dim dt1, dt2, dt3 As DataTable  ', dt4, dt5
        Dim dr1 As DataRow

        Label8.Visible = True

        DS = objVO.GetVoDetails(VoId)
        dt1 = DS.Tables(0)
        dr1 = dt1.Rows(0)
        cboBrns.SelectedValue = dr1("branch")
        dtpVoDt.Value = dr1("vo_dt")
        cboType.SelectedValue = dr1("type")
        txtVoNo.Text = dr1("vo_no")
        txtChqNo.Text = dr1("chq_no")
        '=bank_dt

        dt2 = DS.Tables(1)
        cboCBs.SelectedValue = dt2.Rows(0).Item("Gl_id")
        cboGLs.SelectedValue = dt2.Rows(1).Item("Gl_id")

        txtAmt.Text = dt2.Rows(1).Item("amount")
        txtNarr.Text = dr1("Narr")
        dgvVoDtl.DataSource = dt2
        dgvVoDtl.Rows(1).Selected = True
        dt3 = DS.Tables(2)
        dgvAdjBill.DataSource = dt3
        'dt4 = DS.Tables(3)
        'dt5 = DS.Tables(4)
        Label8.Visible = False
    End Sub

    Private Sub EmptyVO()
        'create empty records
        Dim DS As DataSet
        Dim dt2, dt3, dt4, dt5 As DataTable  '

        Label8.Visible = True

        DS = objVO.GetVoDetails(0)
        cboBrns.SelectedValue = gAcBrId
        dtpVoDt.Value = Date.Today
        cboType.SelectedValue = "P"
        Label30.Text = "Cr."
        cboDr.SelectedValue = "D"
        txtVoNo.Text = ""
        txtChqNo.Text = ""
        '=bank_dt

        cboCBs.SelectedValue = -1
        cboGLs.SelectedValue = -1
        dt2 = DS.Tables(1)

        'dgvVoDtl.DataSource = dt2
        'dgvVoDtl.Columns(0).Visible = False
        'dgvVoDtl.Columns(1).Visible = False
        'dgvVoDtl.Columns(2).Width = 40
        'dgvVoDtl.Columns(3).Width = 140
        'dgvVoDtl.Columns(7).Visible = False
        'dgvVoDtl.Columns(8).Visible = False
        'dt2.Rows.Add()
        dgvVoDtl.Rows.Clear()
        dgvVoDtl.Rows.AddCopy(0)
        dgvVoDtl.Rows(0).Cells(2).Value = Label30.Text
        dgvVoDtl.Rows(1).Cells(2).Value = cboDr.Text

        dt3 = DS.Tables(2)
        dgvAdjBill.DataSource = dt3
        dt4 = DS.Tables(3)
        dgvTdtl.DataSource = dt4
        dt5 = DS.Tables(4)
        dgvSdtl.DataSource = dt5

        txtAmt.Text = ""
        txtNarr.Text = ""
        'dgvVoDtl.DataSource = Nothing

        Label8.Visible = False

    End Sub

    Private Sub NewVoNo()
        If VoId > 0 Then Exit Sub
        If Not gVoNoGen Then txtVoNo.Text = "" : Exit Sub

        Dim Bn, Bs As String, N As Int16

        Select Case cboType.SelectedValue
            Case "P"
                If cboCBs.SelectedValue = 1 Then
                    Bs = Format(dtpVoDt.Value, "MMM") + "/0"
                Else
                    Bs = Format(dtpVoDt.Value, "MMM") + "/B"
                End If
                Bs = Bs.ToUpper
                Bn = objVO.GetMaxVoNo(gCoId, Bs, CDate("01/" + dtpVoDt.Text.Substring(3)), _
                    CDate(Date.DaysInMonth(Year(dtpVoDt.Value), Month(dtpVoDt.Value)) & dtpVoDt.Text.Substring(2)))
                If Bn = "" Then N = 0 Else N = Bn.Substring(6, 4)
                N = N + 1
                txtVoNo.Text = Bs + N.ToString("0000")
            Case "R"
                Bs = Format(dtpVoDt.Value, "MMM") + "/R"
                Bs = Bs.ToUpper
                Bn = objVO.GetMaxVoNo(gCoId, Bs, CDate("01/" + dtpVoDt.Text.Substring(3)), _
                    CDate(Date.DaysInMonth(Year(dtpVoDt.Value), Month(dtpVoDt.Value)) & dtpVoDt.Text.Substring(2)))
                If Bn = "" Then N = 0 Else N = Bn.Substring(6, 4)
                N = N + 1
                txtVoNo.Text = Bs + N.ToString("0000")
            Case "C"
                If cboCBs.SelectedValue = 1 Then
                    Bs = Format(dtpVoDt.Value, "MMM") + "/0"
                Else
                    Bs = Format(dtpVoDt.Value, "MMM") + "/B"
                End If
                Bs = Bs.ToUpper
                Bn = objVO.GetMaxVoNo(gCoId, Bs, CDate("01/" + dtpVoDt.Text.Substring(3)), _
                    CDate(Date.DaysInMonth(Year(dtpVoDt.Value), Month(dtpVoDt.Value)) & dtpVoDt.Text.Substring(2)))
                If Bn = "" Then N = 0 Else N = Bn.Substring(6, 4)
                N = N + 1
                txtVoNo.Text = Bs + N.ToString("0000")
        End Select

    End Sub

    Private Sub PopulateBills(ByVal Gl_id As Int64)
        Dim dt As DataTable

        Label8.Visible = True
        dt = objGL.GetPartyBillList(gCoId, Gl_id, dtpVoDt.Value, True)
        lbAdjB.DisplayMember = "Bill"
        lbAdjB.ValueMember = "bill_id"
        lbAdjB.DataSource = dt
        If dt.Rows.Count = 0 Then
            chkAdhoc.Checked = True
        Else
            lbAdjB.Focus()
        End If
        Label8.Visible = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not Validation1() Then
                Exit Sub
            End If

            Dim voucherDetails As VoucherDTO = New VoucherDTO()
            voucherDetails.AcId = VoId
            voucherDetails.VoucherNo = txtVoNo.Text
            voucherDetails.VoucherDate = dtpVoDt.Value.ToShortDateString
            voucherDetails.VType = cboType.SelectedValue
            voucherDetails.ChqNo = txtChqNo.Text
            voucherDetails.Amt = txtAmt.Text
            voucherDetails.CoCd = gCoId
            voucherDetails.Brn = gAcBrn
            voucherDetails.YrCd = gYrCd
            voucherDetails.RefId = 0
            voucherDetails.Narr = txtNarr.Text

            VoId = objVO.InsertUpdateVouch(voucherDetails)

        Catch ex As Exception
            gError_Message("Could not save Voucher! " + ex.Message, 0)
        End Try
    End Sub

    Private Function Validation1() As Boolean
        If dtpVoDt.Value > Today Then
            MsgBox("Cannot allow Voucher Date in Future !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboCBs.SelectedValue = 0 Then
            MsgBox("There must be a Cash or Bank !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If dgvVoDtl.Rows.Count < 2 Then
            MsgBox("There must be a 2nd Account !", MsgBoxStyle.OkOnly)
            Return False
        ElseIf dgvVoDtl.Rows(1).Cells(3).ToString.Trim.Length = 0 Then
            MsgBox("There must be a 2nd Account !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If gVoNoGen And txtVoNo.Text.Trim.Length = 0 Then
            MsgBox("Vo. No. must be there!", MsgBoxStyle.OkOnly)
            txtVoNo.Focus()
            Return False
        End If

    End Function

    Private Sub txtPCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPCode.Validating

        If txtPCode.Text.Trim.Length > 0 Then
            PtyId = objGL.GetPartyByCode(gCoId, txtPCode.Text)
            If PtyId = 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtPCode, "Invalid Party Code!")
                lblErr.Text = "Invalid Party Code!"
                Exit Sub
            End If
            cboGLs.SelectedValue = PtyId
            gb2.Enabled = True
            gbBills.Enabled = True
        End If

    End Sub

    Private Sub txtPCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPCode.Validated
        Me.ErrorPro.SetError(txtPCode, "")
        lblErr.Text = ""
    End Sub

    Private Sub dtpVoDt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpVoDt.Validated
        Me.ErrorPro.SetError(dtpVoDt, "")
        lblErr.Text = ""
    End Sub

    Private Sub dtpVoDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpVoDt.Validating
        If dtpVoDt.Value > Date.Today Then
            'MsgBox("Cannot allow Challan Date in Future !", MsgBoxStyle.OkOnly)
            e.Cancel = True
            Me.ErrorPro.SetError(dtpVoDt, "Voucher Date in Future!")
            lblErr.Text = "Voucher Date in Future!"
            Exit Sub
        End If
    End Sub

    Private Sub cboCBs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBs.Leave
        If cboCBs.SelectedValue <> 0 Then
            NewVoNo()       'in case cash/bank change
            CBstat = objGL.GetGLType(cboCBs.SelectedValue)
            dgvVoDtl.Rows(0).Cells(3).Value = cboCBs.Text
            dgvVoDtl.Rows(0).Cells(1).Value = cboCBs.SelectedValue
            dgvVoDtl.Rows(0).Cells(4).Selected = True
            If dgvVoDtl.Rows.Count > 1 Then
                dgvVoDtl.Focus()
            ElseIf CBstat.StartsWith("B") Then
                txtChqNo.Focus()
            Else
                If txtPCode.Enabled Then
                    txtPCode.Focus()
                ElseIf cboGLs.Enabled Then
                    cboGLs.Focus()
                End If
            End If
        Else
        End If
    End Sub

    Private Sub cboGLs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGLs.Leave
        If cboGLs.SelectedValue > 0 Then
            'dgvVoDtl.CurrentRow.Cells(3).Value = cboGLs.Text
            'dgvVoDtl.CurrentRow.Cells(1).Value = cboGLs.SelectedValue
            GLstat = objGL.GetGLType(cboGLs.SelectedValue)
            If (GLstat.Substring(1, 2) = "DA" And cboType.SelectedValue = "R") Or _
                (GLstat.Substring(1, 2) = "IA" And cboType.SelectedValue = "P") Then
                gb2.Enabled = True
                PopulateBills(cboGLs.SelectedValue)
            Else
                gb2.Enabled = False
                'dgvVoDtl.Focus()
            End If
        End If
    End Sub

    Private Sub cboType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.Leave
        NewVoNo()
        Select Case cboType.SelectedValue
            Case "P"
                Label30.Text = "Cr."
                cboDr.SelectedValue = "D"
            Case "R"
                Label30.Text = "Dr."
                cboDr.SelectedValue = "C"
            Case "C"
                If cboDr.SelectedValue = "D" Then
                    Label30.Text = "Cr."
                Else
                    Label30.Text = "Dr."
                End If
        End Select
        gb2.Enabled = False
        gbBills.Enabled = False
        If cboGLs.SelectedValue > 0 Then
            If (GLstat.Substring(1, 2) = "DA" And cboType.SelectedValue = "R") Or _
                (GLstat.Substring(1, 2) = "IA" And cboType.SelectedValue = "P") Then
                gb2.Enabled = True
                gbBills.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpd.Click
        dgvVoDtl.CurrentRow.Cells(2).Value = cboDr.Text
        dgvVoDtl.CurrentRow.Cells(3).Value = cboGLs.Text
        dgvVoDtl.CurrentRow.Cells(1).Value = cboGLs.SelectedValue
        If cboDr.SelectedValue = "D" Then
            dgvVoDtl.CurrentRow.Cells(4).Value = txtAmt.Text
            dgvVoDtl.CurrentRow.Cells(5).Value = ""
        Else
            dgvVoDtl.CurrentRow.Cells(5).Value = txtAmt.Text
            dgvVoDtl.CurrentRow.Cells(4).Value = ""
        End If
    End Sub

    Private Sub Label30_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label30.TextChanged
        If dgvVoDtl.Rows.Count > 0 Then
            dgvVoDtl.Rows(0).Cells(2).Value = Label30.Text
        End If
    End Sub

    Private Sub txtChqNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChqNo.Leave
        If txtPCode.Enabled Then
            txtPCode.Focus()
        End If
        'If cboGLs.Enabled Then
        '    cboGLs.Focus()
        'End If
    End Sub

    Private Sub dgvVoDtl_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvVoDtl.DefaultValuesNeeded
        With e.Row
            If .Index > 0 Then
                .Cells(0).Value = 0
                .Cells(1).Value = 0
                .Cells(2).Value = cboDr.SelectedValue
                .Cells(3).Value = ""
                .Cells(4).Value = ""
                .Cells(5).Value = ""
                .Cells(6).Value = ""
                .Cells(7).Value = ""
                .Cells(8).Value = ""
            End If
        End With
    End Sub

    Private Sub dgvVoDtl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVoDtl.KeyDown
        If e.KeyCode = Keys.Space Then
            With dgvVoDtl
                If .CurrentCellAddress.X = 4 Then       '5th col
                    cboCBs.Focus()
                Else
                    cboGLs.Focus()
                End If
            End With
        End If
    End Sub

    
End Class