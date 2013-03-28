Public Class frmChallan

    Dim objChal As New clsChallan
    Dim objTL As New clsTLmast
    Dim objGL As New clsGlmast
    Dim objRt As New clsRates
    Dim objSub As New clsSubMast
    Dim ChId As Int64 = 0
    Dim chUid As Int64 = 0
    Dim chDtid1 As Int64 = 0
    Dim chDtid2 As Int64 = 0
    Dim OwnTL As Boolean

    Public Property iChal_id()
        Get
            iChal_id = ChId
        End Get
        Set(ByVal value)
            ChId = value
        End Set
    End Property

    Private Sub frmChallan_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 2
        If lBrn Then
            PopulateBrns()
        End If
        If lTL Then
            PopulateTLs()
        End If
        If lCsgr Then
            PopulateCsgrs()
        End If
        If lCsge Then
            PopulateCsges()
        End If
        If lAcc Then
            PopulatePtys()
        End If
        If lPlac Then
            PopulateLoads()
            PopulateDests()
        End If
        If lDrv Then
            PopulateDrivers()
        End If
        If lProd Then
            PopulateProds()
        End If
    End Sub

    Private Sub frmChallan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 2
        PopulateBrns()
        PopulateTLs()
        PopulateCsgrs()
        PopulateCsges()
        PopulatePtys()
        PopulateLoads()
        PopulateDests()
        PopulateDrivers()
        PopulateProds()
        cboUnits.SelectedIndex = 0
        cboPers.SelectedIndex = 0
        txtDays.Text = 0
        lblErr.Text = ""
        If Not gDtnB4Ldg Then
            GroupBox2.Visible = False
            gbDtn1.Visible = False
            GroupBox3.Top = GroupBox2.Top
            gbUnld.Top = gbDtn1.Top
            GroupBox5.Top = GroupBox3.Top + 149
            gbDtn2.Top = gbUnld.Top + 149
            btnSave.Top = btnSave.Top - 119
            btnCancel.Top = btnCancel.Top - 119
            btnSave2.Top = btnSave2.Top - 119
            btnCancel2.Top = btnCancel2.Top - 119
            Me.Height = Me.Height - 119
        End If
        If ChId <> 0 Then
            PopulateChallan()
        Else
            dtpChDt.Value = Today
        End If
    End Sub

    Private Sub PopulateBrns()
        Dim dt As DataTable ', dr As DataRow
        Dim objDashB As New clsDashboard

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

    Private Sub PopulatePtys()
        Dim dt As DataTable, dr As DataRow
        Dim objGL As New clsGlmast

        Label8.Visible = True
        dt = objGL.GetPartyList(gCoId, "")
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("gl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboPtys.DisplayMember = "Name"
        cboPtys.ValueMember = "gl_id"
        cboPtys.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateCsges()
        Dim dt As DataTable, dr As DataRow
        Dim objCsge As New clsCsge

        Label8.Visible = True
        dt = objCsge.GetCsgeList(gCoId, "")
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("csge_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboCsges.DisplayMember = "Name"
        cboCsges.ValueMember = "csge_id"
        cboCsges.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateCsgrs()
        Dim dt As DataTable, dr As DataRow
        Dim objCsgr As New clsCsgr

        Label8.Visible = True
        dt = objCsgr.GetCsgrList(gCoId)
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("csgr_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboCsgrs.DisplayMember = "Name"
        cboCsgrs.ValueMember = "csgr_id"
        cboCsgrs.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateLoads()
        Dim dt As DataTable, dr As DataRow
        Dim objPl As New clsPlace
        Dim Flt As String

        Label8.Visible = True
        Flt = "pl_type='L'"

        dt = objPl.GetPlaceList(gCoId, Flt)
        dr = dt.NewRow
        dr("Place") = "--Select--"
        dr("pl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboLoads.DataSource = dt
        cboLoads.DisplayMember = "Place"
        cboLoads.ValueMember = "pl_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateDests()
        Dim dt As DataTable, dr As DataRow
        Dim objPl As New clsPlace
        Dim Flt As String

        Label8.Visible = True
        Flt = "pl_type='D'"

        dt = objPl.GetPlaceList(gCoId, Flt)
        dr = dt.NewRow
        dr("Place") = "--Select--"
        dr("pl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboDests.DataSource = dt
        cboDests.DisplayMember = "Place"
        cboDests.ValueMember = "pl_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateDrivers()
        Dim dt As New DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objSub.GetDriverList(gCoId, Flt)
        dr = dt.NewRow
        dr("Name") = "--Select--"
        dr("sub_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboDrivers.DataSource = dt
        cboDrivers.DisplayMember = "Name"
        cboDrivers.ValueMember = "sub_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateProds()
        Dim dt As New DataTable, dr As DataRow
        Dim objPr As New clsProduct
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objPr.GetProductList(gCoId)
        dr = dt.NewRow
        dr("Product") = "--Select--"
        dr("prod_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboProds.DataSource = dt
        cboProds.DisplayMember = "Product"
        cboProds.ValueMember = "prod_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateTLs()
        Dim dt As DataTable, dr As DataRow
        Dim objTL As New clsTLmast

        Label8.Visible = True
        dt = objTL.GetTLlist(gCoId, "")
        dr = dt.NewRow
        dr("TL No") = "--Select--"
        dr("tl_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboTLs.DisplayMember = "TL No"
        cboTLs.ValueMember = "tl_id"
        cboTLs.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateRates(ByVal Gl_id As Int64)
        Dim dt As DataTable

        Label8.Visible = True
        Try
            dt = objGL.GetPartyRateList(gCoId, "g.Gl_id=" & Gl_id)
            If dt.Rows.Count = 0 Then
                Dim objR As New frmRates
                objR.MdiParent = Me.MdiParent
                objR.Show()
            Else
                cboRates.DisplayMember = "Rates"
                cboRates.ValueMember = "tar_id"
                cboRates.DataSource = dt
            End If
        Catch ex As Exception
            gError_Message("Error getting Rates! " + ex.Message, 0)
        End Try
        Label8.Visible = False

    End Sub

    Private Sub PopulateChallan()
        Dim dt1, dt2, dt3, dt4 As DataTable, dr1, dr2, dr3 As DataRow

        Label8.Visible = True

        dt1 = objChal.GetChalDetails(ChId)
        dr1 = dt1.Rows(0)
        cboBrns.Text = dr1("branch")
        dtpChDt.Value = dr1("chal_dt")
        cboTLs.SelectedValue = dr1("tl_id")
        dt4 = objTL.GetTLDetails(dr1("tl_id"))
        OwnTL = dt4.Rows(0).Item("Own")
        txtTLcode.Text = dt4.Rows(0).Item("TL_Code")
        txtChNo.Text = dr1("chal_no")
        txtCNNo.Text = dr1("cn_no")
        cboCsgrs.SelectedValue = dr1("csgr_id")
        cboLoads.SelectedValue = dr1("ldpt_id")
        cboCsges.SelectedValue = dr1("csge_id")
        cboPtys.SelectedValue = dr1("Gl_id")
        cboDests.SelectedValue = dr1("dest_id")
        txtDays.Text = dr1("trip_days")
        cboDrivers.SelectedValue = dr1("driv_id")

        cboProds.SelectedValue = dr1("prod_id")
        txtQty.Text = dr1("qty")
        cboUnits.Text = dr1("unit")
        txtRate.Text = dr1("Rate")
        cboPers.Text = dr1("per")
        txtAmt.Text = dr1("Amount")
        chkRound.CheckState = IIf(txtAmt.Text.Substring(txtAmt.Text.Length - 2, 2) = "00", CheckState.Checked, CheckState.Unchecked)
        txtHFrgt.Text = dr1("hire_frgt")
        txtHFrgt.Enabled = Not OwnTL

        dt2 = objChal.GetChalDtnDetails(ChId)
        If dt2.Rows.Count > 0 Then
            dr2 = dt2.Rows(0)
            If dr2("pre_dtn") = True Then
                gbDtn1.BackColor = Color.Wheat
                chDtid1 = dr2("dtn_id")
                dtpReport1.Value = dr2("rep_time")
                dtpRel1.Value = dr2("rel_time")
                txtDtnD1.Text = dr2("dtn_days")
                txtDtnR1.Text = dr2("dtn_rate")
                lblDtnA1.Text = "/ day = Rs." + dr2("dtn_amt")
                txtMktD1.Text = dr2("mkt_days")
                txtMktR1.Text = dr2("mkt_rate")
                lblMktA1.Text = "/ day = Rs." + dr2("mkt_amt")
            Else
                gbDtn2.BackColor = Color.Wheat
                chDtid2 = dr2("dtn_id")
                dtpReport2.Value = dr2("rep_time")
                dtpRel2.Value = dr2("rel_time")
                txtDtnD2.Text = dr2("dtn_days")
                txtDtnR2.Text = dr2("dtn_rate")
                lblDtnA2.Text = "/ day = Rs." + dr2("dtn_amt")
                txtMktD2.Text = dr2("mkt_days")
                txtMktR2.Text = dr2("mkt_rate")
                lblMktA2.Text = "/ day = Rs." + dr2("mkt_amt")
            End If
            If dt2.Rows.Count > 1 Then
                dr2 = dt2.Rows(1)
                If dr2("pre_dtn") = True Then
                    chDtid1 = dr2("dtn_id")
                    dtpReport1.Value = dr2("rep_time")
                    dtpRel1.Value = dr2("rel_time")
                    txtDtnD1.Text = dr2("dtn_days")
                    txtDtnR1.Text = dr2("dtn_rate")
                    lblDtnA1.Text = "/ day = Rs." + dr2("dtn_amt")
                    txtMktD1.Text = dr2("mkt_days")
                    txtMktR1.Text = dr2("mkt_rate")
                    lblMktA1.Text = "/ day = Rs." + dr2("mkt_amt")
                Else
                    chDtid2 = dr2("dtn_id")
                    dtpReport2.Value = dr2("rep_time")
                    dtpRel2.Value = dr2("rel_time")
                    txtDtnD2.Text = dr2("dtn_days")
                    txtDtnR2.Text = dr2("dtn_rate")
                    lblDtnA2.Text = "/ day = Rs." + dr2("dtn_amt")
                    txtMktD2.Text = dr2("mkt_days")
                    txtMktR2.Text = dr2("mkt_rate")
                    lblMktA2.Text = "/ day = Rs." + dr2("mkt_amt")
                End If
            End If
        Else
            chDtid1 = 0
            chDtid2 = 0
            dtpReport1.Text = ""
            dtpRel1.Text = ""
            txtDtnD1.Text = 0
            txtDtnR1.Text = 0
            txtMktD1.Text = 0
            txtMktR1.Text = 0
            lblDtnA1.Text = "/ day = Rs. 0.00"
            dtpReport2.Text = ""
            dtpRel2.Text = ""
            txtDtnD2.Text = 0
            txtDtnR2.Text = 0
            txtMktD2.Text = 0
            txtMktR2.Text = 0
            lblDtnA2.Text = "/ day = Rs. 0.00"
        End If

        dt3 = objChal.GetChalUnldDetails(ChId)
        If dt3.Rows.Count > 0 Then
            Me.BackColor = Color.BlanchedAlmond
            dr3 = dt3.Rows(0)
            chUid = dr3("unld_id")
            dtpChRcvDt.Value = dr3("chal_rcd")
            dtpDelivDt.Value = dr3("deliv_dt")
            txtDelivWt.Text = dr3("deliv_wt")
            txtShtQty.Text = dr3("shortage")
            cboDelivUnit.Text = dr3("deliv_unit")
            cboShtUnit.Text = dr3("sht_unit")
            txtShtRt.Text = dr3("sht_rate")
            txtShtAmt.Text = dr3("sht_amt")
            txtMktSht.Text = dr3("mkt_sht")
        Else
            dtpChRcvDt.Value = Date.Today
            dtpDelivDt.Value = Date.Today
            txtDelivWt.Text = txtQty.Text
            cboDelivUnit.Text = cboUnits.Text
            txtShtQty.Text = 0
            cboShtUnit.Text = cboUnits.Text
            txtShtRt.Text = 0
            txtShtAmt.Text = 0
            chkRoun2.Checked = True
            txtMktSht.Text = 0
        End If

        Label8.Visible = False
    End Sub

    Private Sub frmChallan_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 30
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not Validation1() Then
                Exit Sub
            End If

            ChId = objChal.InsertUpdateChal(ChId, cboBrns.Text, cboTLs.SelectedValue, txtChNo.Text, _
                dtpChDt.Value.ToShortDateString, txtCNNo.Text, cboCsgrs.SelectedValue, cboLoads.SelectedValue, _
                cboPtys.SelectedValue, cboCsges.SelectedValue, cboDests.SelectedValue, txtDays.Text, cboDrivers.SelectedValue, _
                cboProds.SelectedValue, txtQty.Text, cboUnits.Text, txtRate.Text, cboPers.Text, _
                txtAmt.Text, txtHFrgt.Text, gCoId, gYrCd, gAcEffctB4Dlv)

            If Val(txtDtnD1.Text) > 0 Then
                chDtid1 = objChal.InsertUpdateChalDtn(chDtid1, ChId, True, dtpReport1.Value, dtpRel1.Value, txtDtnD1.Text, _
                    txtDtnR1.Text, 0, txtMktD1.Text, txtMktR1.Text, 0)
            End If

            Me.Close()

        Catch ex As Exception
            gError_Message("Could not save Challan! " + ex.Message, 0)
        End Try
    End Sub

    Private Sub btnSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try
            If Not Validation2() Then
                Exit Sub
            End If

            chUid = objChal.InsertUpdateChalUnld(chUid, ChId, dtpChRcvDt.Value.ToShortDateString, dtpDelivDt.Value.ToShortDateString, _
                txtDelivWt.Text, cboDelivUnit.Text, txtShtQty.Text, cboShtUnit.Text, txtShtRt.Text, txtShtAmt.Text, txtMktSht.Text)

            If Val(txtDtnD2.Text) > 0 Then
                chDtid2 = objChal.InsertUpdateChalDtn(chDtid2, ChId, False, dtpReport2.Value, dtpRel2.Value, txtDtnD2.Text, _
                    txtDtnR2.Text, 0, txtMktD2.Text, txtMktR2.Text, 0)
            End If

            Me.Close()

        Catch ex As Exception
            gError_Message("Could not save Unloading! " + ex.Message, 0)
        End Try

    End Sub

    Private Function Validation1() As Boolean
        If dtpChDt.Value > Today Then
            MsgBox("Cannot allow Challan Date in Future !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboTLs.SelectedValue <= 0 Then
            MsgBox("There must be a T/L !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If txtChNo.Text.Trim.Length = 0 Then
            MsgBox("Challan No. must be there!", MsgBoxStyle.OkOnly)
            txtChNo.Focus()
            Return False
        End If
        If txtCNNo.Text.Trim.Length = 0 Then
            MsgBox("C/N No. must be there!", MsgBoxStyle.OkOnly)
            txtCNNo.Focus()
            Return False
        End If
        If cboCsgrs.SelectedValue <= 0 Then
            MsgBox("There must be a Consignor !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboCsges.SelectedValue <= 0 Then
            MsgBox("There must be a Consignee !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboLoads.SelectedValue <= 0 Then
            MsgBox("There must be a Loading Point !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboDests.SelectedValue <= 0 Then
            MsgBox("There must be a Destination !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboDrivers.SelectedValue <= 0 Then
            MsgBox("There must be a Driver !", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboProds.SelectedValue <= 0 Then
            MsgBox("There must be a Product !", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True

    End Function

    Private Function Validation2() As Boolean
        If dtpChRcvDt.Value > Today Then
            'chked in dtpchrcvdt
            MsgBox("Cannot allow Receive Date in Future !", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True

    End Function

    Private Sub txtTLcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTLcode.Validated
        ShowError(txtTLcode, "")
    End Sub

    Private Sub txtTLcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTLcode.Validating
        Dim dt As DataTable

        If txtTLcode.Text.Trim <> "" Then
            If txtTLcode.Text.Trim.Length <> 4 Then
                e.Cancel = True
                ShowError(txtTLcode, "Code must be 4 digits.")
                Exit Sub
            End If
            dt = objTL.GetTLbyCode(txtTLcode.Text.Trim)
            If dt.Rows.Count = 0 Then
                e.Cancel = True
                ShowError(txtTLcode, "T/L Code not found!")
                Exit Sub
            End If
            cboTLs.SelectedValue = dt.Rows(0).Item("TL_id")
            OwnTL = dt.Rows(0).Item("Own")
            txtHFrgt.Enabled = Not OwnTL
        End If

    End Sub

    Private Sub dtpChDt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpChDt.Validated
        ShowError(dtpChDt, "")
    End Sub

    Private Sub dtpChDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpChDt.Validating
        If dtpChDt.Value > Date.Today Then
            dtpChDt.Value = Date.Today
            e.Cancel = True
            ShowError(dtpChDt, "Challan Date in Future!")
            Exit Sub
        End If
    End Sub

    Private Sub dtpChRcvDt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpChRcvDt.Validated
        ShowError(dtpChRcvDt, "")
    End Sub

    Private Sub dtpChRcvDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpChRcvDt.Validating
        If dtpChRcvDt.Value > Date.Today Then
            e.Cancel = True
            ShowError(dtpChRcvDt, "Receive Date in Future!")
            Exit Sub
        End If
    End Sub

    Private Sub cboCsges_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCsges.Validated
        ShowError(cboCsges, "")
    End Sub

    Private Sub cboCsges_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCsges.Validating
        Dim dt As DataTable
        Dim objCsge As New clsCsge

        If cboCsges.SelectedIndex > 0 Then
            Label8.Visible = True
            dt = objCsge.GetCsgeDetails(cboCsges.SelectedValue)
            If dt.Rows.Count > 0 Then
                cboDests.SelectedValue = dt.Rows(0)("dest_Id")
                cboPtys.SelectedValue = dt.Rows(0)("GL_Id")
                PopulateRates(cboPtys.SelectedValue)
                If cboRates.Items.Count > 0 Then
                    gbRates.Visible = True
                    gbRates.BringToFront()
                    cboRates.Focus()
                Else
                    gbRates.Visible = False
                End If
            Else
                e.Cancel = True
                ShowError(cboCsges, "Error Finding Rate!")
            End If
            Label8.Visible = False
        End If

    End Sub

    Private Sub cboCsgrs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCsgrs.Validated
        ShowError(cboCsgrs, "")
    End Sub

    Private Sub cboCsgrs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCsgrs.Validating
        Dim dt As DataTable
        Dim objCsgr As New clsCsgr

        If cboCsgrs.SelectedIndex > 0 Then
            Label8.Visible = True
            dt = objCsgr.GetCsgrDetails(cboCsgrs.SelectedValue)
            If dt.Rows.Count > 0 Then
                cboLoads.SelectedValue = dt.Rows(0)("ldpt_Id")
            End If
            Label8.Visible = False
        End If

    End Sub

    Private Sub cboPtys_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPtys.Leave
        If cboPtys.SelectedIndex > 0 Then
            gbRates.Visible = True
            PopulateRates(cboPtys.SelectedValue)
            cboRates.Focus()
        End If
    End Sub

    Private Sub cboRates_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRates.Leave
        cboDests.Focus()
        gbRates.Visible = False
    End Sub

    Private Sub cboRates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRates.SelectedIndexChanged
        Dim rTi As Int64
        Dim dt As DataTable, dr As DataRow

        If cboRates.SelectedValue <> 0 Then
            rTi = cboRates.SelectedValue
            dt = objRt.GetRateDetails(rTi)
            dr = dt.Rows(0)
            cboCsges.SelectedValue = dr("csge_id")
            cboPtys.SelectedValue = dr("gl_id")
            cboProds.SelectedValue = dr("prod_id")
            cboLoads.SelectedValue = dr("ldpt_id")
            cboDests.SelectedValue = dr("dest_id")
            txtRate.Text = dr("bill_rate")
            If Not OwnTL Then
                txtHFRt.Text = dr("hire_rate")
                txtShtRt.Text = dr("shrt_rate")
                cboShtUnit.Text = dr("shrt_unit")
                lblRtKm.Text = "Route-KM=" & dr("RouteKM")
            Else
                txtHFrgt.Text = 0
                txtShtRt.Text = 0
                cboShtUnit.Text = dr("shrt_unit")
                lblRtKm.Text = "Route-KM=" & dr("RouteKM")
            End If
        End If
    End Sub

    Private Sub cboTLs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTLs.Validated
        ShowError(cboCsges, "")
    End Sub

    Private Sub cboTLs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTLs.Validating
        Dim dt As DataTable
        Dim objCsge As New clsCsge

        If cboTLs.SelectedIndex > 0 Then
            Label8.Visible = True
            dt = objTL.GetTLbyNo(cboTLs.Text)
            If dt.Rows.Count > 0 Then
                txtTLcode.Text = dt.Rows(0)("TL_Code")
            Else
                e.Cancel = True
                ShowError(cboTLs, "No T/L Code!")
                'Exit Sub
            End If
            Label8.Visible = False
        End If

    End Sub

    Private Sub cboUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnits.SelectedIndexChanged
        cboPers.SelectedValue = cboUnits.SelectedValue
        cboDelivUnit.SelectedValue = cboUnits.SelectedValue
        cboShtUnit.SelectedValue = cboUnits.SelectedValue
    End Sub

    Private Sub txtChNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChNo.Validated
        ShowError(txtChNo, "")
    End Sub

    Private Sub txtChNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtChNo.Validating
        If txtChNo.Text.Trim.Length > 0 Then
            If objChal.GetChalFromNo(txtChNo.Text, gCoId, gYrCd) > 0 Then
                e.Cancel = True
                ShowError(txtChNo, "Duplicate Challan Number!")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtCNNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNNo.Validated
        ShowError(txtCNNo, "")
    End Sub

    Private Sub txtCNNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCNNo.Validating
        If txtCNNo.Text.Trim.Length > 0 And txtCNNo.Text.Trim.ToUpper <> "NIL" Then
            If objChal.GetChalFromCN(txtCNNo.Text, gCoId, gYrCd) > 0 Then
                e.Cancel = True
                ShowError(txtCNNo, "Duplicate C/N Number! ('NIL' allowed)")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtDays_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDays.Validated
        ShowError(txtDays, "")
    End Sub

    Private Sub txtDays_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDays.Validating
        If Val(txtDays.Text) < 0 Then
            e.Cancel = True
            ShowError(txtChNo, "Invalid days!")
            Exit Sub
        End If

    End Sub

    Private Sub txtQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Validated
        ShowError(txtQty, "")
    End Sub

    Private Sub txtQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQty.Validating
        Dim AMT As Single

        If Val(txtQty.Text) <= 0 Then
            e.Cancel = True
            ShowError(txtQty, "Invalid Quantity!")
            Exit Sub
        Else
            If chkRound.Checked Then
                AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 0)
            Else
                AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 2)
            End If
            txtAmt.Text = Format(AMT, "##,##,###.00")

            If chkRound.Checked Then
                AMT = Math.Round(Val(txtQty.Text) * Val(txtHFRt.Text), 0)
            Else
                AMT = Math.Round(Val(txtQty.Text) * Val(txtHFRt.Text), 2)
            End If
            txtHFrgt.Text = AMT
        End If

    End Sub

    Private Sub txtRate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.Validated
        ShowError(txtRate, "")
    End Sub

    Private Sub txtRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRate.Validating
        Dim AMT As Single

        If Val(txtRate.Text) <= 0 Then
            e.Cancel = True
            ShowError(txtRate, "Invalid Rate!")
            Exit Sub
        Else
            If chkRound.Checked Then
                AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 0)
            Else
                AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 2)
            End If
            txtAmt.Text = Format(AMT, "##,##,###.00")
        End If

    End Sub

    Private Sub chkRound_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRound.CheckStateChanged
        Dim AMT As Single

        If chkRound.Checked Then
            AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 0)
        Else
            AMT = Math.Round(Val(txtQty.Text) * Val(txtRate.Text), 2)
        End If
        txtAmt.Text = Format(AMT, "##,##,###.00")

    End Sub

    Private Sub txtShtQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShtQty.Validated
        ShowError(txtShtQty, "")
    End Sub

    Private Sub txtShtQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtShtQty.Validating
        Dim AMT As Single

        If Val(txtShtQty.Text) < 0 Then
            e.Cancel = True
            ShowError(txtShtQty, "Invalid quantity!")
            Exit Sub
        Else
            If chkRoun2.Checked Then
                AMT = Math.Round(Val(txtShtQty.Text) * Val(txtShtRt.Text), 0)
            Else
                AMT = Math.Round(Val(txtShtQty.Text) * Val(txtShtRt.Text), 2)
            End If
            txtShtAmt.Text = Format(AMT, "##,##,###.00")
        End If
    End Sub

    Private Sub txtShtRt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShtRt.Validated
        ShowError(txtShtRt, "")
    End Sub

    Private Sub txtShtRt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtShtRt.Validating
        Dim AMT As Single

        If Val(txtShtRt.Text) <= 0 Then
            e.Cancel = True
            ShowError(txtShtRt, "Invalid rate!")
            Exit Sub
        Else
            If chkRoun2.Checked Then
                AMT = Math.Round(Val(txtShtQty.Text) * Val(txtShtRt.Text), 0)
            Else
                AMT = Math.Round(Val(txtShtQty.Text) * Val(txtShtRt.Text), 2)
            End If
            txtShtAmt.Text = Format(AMT, "##,##,###.00")
        End If

    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

End Class