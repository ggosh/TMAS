Public Class frmBill2i

    Dim objBill As New clsBill
    Dim objGL As New clsGlmast
    Dim objRep As New clsRep
    Dim objST As New clsSTmast
    Dim BlId As Int64 = 0
    Dim PtyId As Int32 = 0

    Public Property iBill_id()
        Get
            iBill_id = BlId
        End Get
        Set(ByVal value)
            BlId = value
        End Set
    End Property

    Private Sub frmBill_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 3
    End Sub

    Private Sub frmBill_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 3

        lblErr.Text = ""
        PopulateTypes()
        PopulatePtys()
        PopulateReps()
        PopulateTax()
        txtStPc.Text = gSrvPc
        txtStPc.Enabled = False
        If BlId <> 0 Then
            PopulateBill()
        Else
            dtpBlDt.Value = Today
            cboType.SelectedValue = "C"
        End If
    End Sub

    Private Sub PopulateTypes()
        Dim dt As New DataTable, dr As DataRow

        Label8.Visible = True

        dt.Columns.Add("vTy", Type.GetType("System.String"))
        dt.Columns.Add("VType", Type.GetType("System.String"))
        dr = dt.Rows.Add()
        dr.Item("vTY") = "C"
        dr.Item("VType") = "Cash Memo"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "S"
        dr.Item("VType") = "Spirit"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "D"
        dr.Item("VType") = "Direct"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "B"
        dr.Item("VType") = "B/Test"
        dr = dt.Rows.Add()
        dr.Item("vTY") = "M"
        dr.Item("VType") = "C/Cr.Memo"

        cboType.DisplayMember = "VType"
        cboType.ValueMember = "vTy"
        cboType.DataSource = dt

        Label8.Visible = False

    End Sub

    Private Sub PopulatePtys()
        Dim dt As DataTable, dr As DataRow

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

    Private Sub PopulateReps()
        Dim dt As DataTable, dr As DataRow

        Label8.Visible = True
        dt = objRep.GetRepList(gCoId)
        dr = dt.NewRow
        dr("RepName") = "--Select--"
        dr("Rep_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboRep.DisplayMember = "RepName"
        cboRep.ValueMember = "Rep_id"
        cboRep.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateTax()
        Dim dt As DataTable, dr As DataRow

        Label8.Visible = True
        dt = objST.GetSTList(gCoId, "taxtype='S'")
        dr = dt.NewRow
        dr("STName") = "--Select--"
        dr("Tax_id") = 0
        dt.Rows.InsertAt(dr, 0)
        cboST.DisplayMember = "STName"
        cboST.ValueMember = "Tax_id"
        cboST.DataSource = dt
        Label8.Visible = False

    End Sub

    Private Sub PopulateBill()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objBill.GetBillDetails(BlId)
        dr = dt.Rows(0)

        PtyId = dr("Gl_id")
        cboPtys.SelectedValue = PtyId

        cboRep.SelectedValue = dr("rep_id")
        cboType.SelectedValue = dr("bill_type")
        txtBillNo.Text = dr("bill_no")
        dtpBlDt.Value = dr("bill_dt")
        txtAmount.Text = dr("amount")

        txtNTax.Text = dr("NonTaxbl")
        txtTaxbl.Text = dr("Taxbl")
        txtLessFrt.Text = dr("LessFrt")
        cboST.SelectedValue = dr("st_id")
        txtStPc.Text = dr("ServPc")
        txtSTax.Text = dr("ServTax")
        txtPost.Text = dr("postage")
        txtRnd.Text = dr("roundoff")

        dt = Nothing

        Label8.Visible = False
    End Sub

    Private Sub frmBills_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Function Validation() As Boolean
        If dtpBlDt.Value > Today Then
            MsgBox("Cannot allow entry in Furture Date!", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboType.SelectedIndex = -1 Then
            MsgBox("Type must be selected!", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboPtys.SelectedIndex <= 0 Then
            MsgBox("Party must be there!", MsgBoxStyle.OkOnly)
            Return False
        End If
        If cboRep.SelectedIndex <= 0 Then
            MsgBox("Rep must be there!", MsgBoxStyle.OkOnly)
            Return False
        End If

        Return True

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not Validation() Then
                Exit Sub
            End If

            objBill.InsertUpdateBill(BlId, txtBillNo.Text, dtpBlDt.Value, cboType.SelectedValue, cboPtys.SelectedValue, 2848, txtNTax.Text, _
                txtTaxbl.Text, txtLessFrt.Text, 0, 0, "", 0, txtTaxbl.Text, cboST.SelectedValue, _
                txtStPc.Text, txtSTax.Text, txtPost.Text, txtRnd.Text, txtAmount.Text, "", "", _
                cboRep.SelectedValue, gAcBrn, gCoId, gYrCd)

            Me.Close()

        Catch ex As Exception
            gError_Message("Could not save Bill! " + ex.Message, 0)
        End Try

    End Sub

    Private Sub txtPCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPCode.Validating

        If txtPCode.Text.Trim.Length > 0 Then
            PtyId = objGL.GetPartyByCode(gCoId, txtPCode.Text)
            If PtyId = 0 Then
                MsgBox("Invalid Party Code!", MsgBoxStyle.Critical, "WinAc")
                Exit Sub
            End If
            cboPtys.SelectedValue = PtyId
            cboRep.Focus()
        End If

    End Sub

    Private Sub cboPtys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPtys.SelectedIndexChanged
        Dim dt As DataTable

        PtyId = cboPtys.SelectedValue
        If PtyId > 0 Then
            dt = objGL.GetPartyDetails(PtyId)
            Label5.Text = NoDbNull(dt.Rows(0).Item("Addr"), "")
            Label2.Text = NoDbNull(dt.Rows(0).Item("GrpName"), "")
        End If

    End Sub

    Private Sub cboType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.Leave
        'for edit opt.?
        Dim Bn As String, N As Int16

        Bn = objBill.GetMaxBillNo(gCoId, cboType.SelectedValue, gYrStart, gYrEnd)
        Select Case cboType.SelectedValue
            Case "C"
                'nothing to do
            Case "S"
                If Bn = "" Then N = 0 Else N = Bn.Substring(3, 4)
                N = N + 1
                txtBillNo.Text = "S/" + N.ToString("0000") + "/" + gAcYr
            Case "D"
                If Bn = "" Then N = 0 Else N = Bn.Substring(1, 4)
                N = N + 1
                txtBillNo.Text = N.ToString("0000") + "/D" + dtpBlDt.Text.Substring(3, 2) + "/" + gAcYr
            Case "B"
                If Bn = "" Then N = 0 Else N = Bn.Substring(3, 3)
                N = N + 1
                txtBillNo.Text = "BT" + N.ToString("000") + "/" + gAcYr
            Case "M"
                If Bn = "" Then N = 0 Else N = Bn.Substring(3, 3)
                N = N + 1
                txtBillNo.Text = "C/" + N.ToString("000") + " /" + gAcYr
        End Select
        If cboType.SelectedValue = "C" Then
            txtPCode.Enabled = False
            cboPtys.Enabled = False
            cboPtys.SelectedValue = 1
            cboRep.SelectedValue = 4
            'cboST.SelectedIndex = 0
        Else
            txtPCode.Enabled = True
            cboPtys.Enabled = True
        End If

    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If BlId = 0 Then
            Select Case cboType.SelectedValue
                Case "C"
                    txtBillNo.Text = "CM/0000-00"
                Case "S"
                    txtBillNo.Text = "S/0000/" + gAcYr
                Case "D"
                    txtBillNo.Text = "0000/D" + dtpBlDt.Text.Substring(3, 2) + "/" + gAcYr
                Case "B"
                    txtBillNo.Text = "BT000/" + gAcYr
                Case "M"
                    txtBillNo.Text = "C/000 /" + gAcYr
            End Select
        End If
    End Sub

    Private Sub TotUpdate()
        Dim sTx, Amt As Decimal

        If txtNTax.Text = "" Then txtNTax.Text = "0"
        If txtTaxbl.Text = "" Then txtTaxbl.Text = "0"
        If txtLessFrt.Text = "" Then txtLessFrt.Text = "0"
        If txtStPc.Text = "" Then txtStPc.Text = "0"
        If txtSTax.Text = "" Then txtSTax.Text = "0"
        If txtPost.Text = "" Then txtPost.Text = "0"
        If txtRnd.Text = "" Then txtRnd.Text = "0"

        Try
            sTx = (CDec(txtTaxbl.Text) - CDec(txtLessFrt.Text)) * CDec(txtStPc.Text) / 100
            txtSTax.Text = sTx.ToString("#####.00")
            Amt = CDec(txtNTax.Text) + CDec(txtTaxbl.Text) - CDec(txtLessFrt.Text) _
                + CDec(txtSTax.Text) + CDec(txtPost.Text) + CDec(txtRnd.Text)
            txtAmount.Text = Amt.ToString("########.00")

        Catch ex As Exception
            gError_Message("Error in entry!", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub txtNTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNTax.TextChanged
        TotUpdate()
    End Sub

    Private Sub txtLessFrt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLessFrt.TextChanged
        TotUpdate()
    End Sub

    Private Sub txtPost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPost.TextChanged
        TotUpdate()
    End Sub

    Private Sub txtRnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRnd.Leave
        TotUpdate()
    End Sub

    Private Sub txtSTax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSTax.TextChanged
        TotUpdate()
    End Sub

    Private Sub txtTaxbl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxbl.TextChanged
        TotUpdate()
    End Sub

    Private Sub cboST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboST.SelectedIndexChanged
        Dim dt As DataTable, sti As Int32

        sti = cboST.SelectedValue
        If sti > 0 Then
            dt = objST.GetSTDetails(sti)
            txtStPc.Text = dt.Rows(0).Item("perc")

            TotUpdate()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtBillNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBillNo.Leave
        If txtPCode.CanFocus Then txtPCode.Focus() Else txtNTax.Focus()
    End Sub

End Class
