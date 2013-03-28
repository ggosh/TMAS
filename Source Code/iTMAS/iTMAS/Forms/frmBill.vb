Public Class frmBill

    Dim objBill As New clsBill
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
        If lAcc Then
            PopulatePtys()
        End If
    End Sub

    Private Sub frmBill_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 3

        lblErr.Text = ""
        PopulatePtys()
        txtServPc.Text = gSrvPc
        txtServPc.Enabled = False
        If BlId <> 0 Then
            PopulateBill()
        Else
            cboType.SelectedIndex = 0
            dtpBlDt.Value = Today
            chkSTax.Checked = True
        End If
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

    Private Sub PopulateBill()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objBill.GetBillDetails(BlId)
        dr = dt.Rows(0)

        PtyId = dr("Gl_id")
        cboPtys.SelectedValue = PtyId
        lblRef.Text = dr("ref")
        lblLodLoc.Text = dr("lodloc")

        cboType.SelectedValue = dr("bill_type")
        txtBillNo.Text = dr("bill_no")
        dtpBlDt.Value = dr("bill_dt")
        txtAmount.Text = dr("amount")

        txtFreight.Text = dr("freight")
        txtServPc.Text = dr("ServPc")
        txtServTax.Text = dr("ServTax")
        txtDeten.Text = dr("detention")
        txtOthNam.Text = dr("OthName")
        txtOther.Text = dr("OthChgs")
        dt = Nothing

        dt = objBill.GetBillChalList(gCoId, "bill_id=" & BlId)
        dgvChals.DataSource = dt

        dgvChals.Columns(0).Visible = False
        dgvChals.Columns(5).Visible = False
        dgvChals.Columns(7).Visible = False

        Label8.Visible = False
    End Sub

    Private Sub frmBills_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Function Validation() As Boolean
        'If dtpBlDt.Value > Today Then
        '    MsgBox("Cannot allow entry in Furture Date!", MsgBoxStyle.OkOnly)
        '    Return False
        'End If
        Return True

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not Validation() Then
                Exit Sub
            End If


        Catch ex As Exception
            gError_Message("Could not save Bill! " + ex.Message, 0)
        End Try

    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If btnChange.Text = "Change" Then
            txtServPc.Enabled = True
            txtServPc.Focus()
            btnChange.Text = "Accept"
        Else
            txtServPc.Enabled = False
            btnChange.Text = "Change"
        End If
    End Sub

    Private Sub cboPtys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPtys.SelectedIndexChanged
        Dim dt As DataTable
        Dim chkCol As New DataGridViewCheckBoxColumn
        Dim Amt, Frt, Dtn, Oth, ROf, STx As Single

        ShowError(cboPtys, "")
        If cboPtys.SelectedIndex > 0 Then
            PtyId = cboPtys.SelectedValue
            dt = objBill.GetBillChalList(gCoId, "(c.gl_id=" & PtyId & " and (isnull(c.bill_id,0)=" & BlId & " or isnull(c.bill_id,0)=0))")
            chkCol.HeaderText = "Sel"
            chkCol.Width = 30
            dgvChals.Columns.Add(chkCol)
            dgvChals.DataSource = dt
            dgvChals.Columns(1).Visible = False
            dgvChals.Columns(2).Width = 100
            dgvChals.Columns(6).Visible = False
            dgvChals.Columns(8).Visible = False
            If dt.Rows.Count = 0 Then
                ShowError(cboPtys, "No Challans for this party!")
                Exit Sub
            Else
                Amt = 0 : Frt = 0 : STx = 0 : Dtn = 0 : Oth = 0 : ROf = 0
                For Each Rw As DataGridViewRow In dgvChals.Rows
                    Rw.Cells(0).Value = 1
                    Frt = Frt + Rw.Cells(14).Value
                Next
                lblTot.Text = Frt.ToString("##,##,###.00")
                txtFreight.Text = lblTot.Text
                Amt = Amt + Frt
                txtServTax.Text = "0.00"
                If chkSTax.Checked Then
                    STx = Math.Round(Amt / 4 * txtServPc.Text / 100, 2)
                    txtServTax.Text = STx.ToString("##,##,###.00")
                    Amt = Amt + STx
                End If
                Dtn = IIf(txtDeten.Text = "", 0, txtDeten.Text)
                Oth = IIf(txtOther.Text = "", 0, txtOther.Text)
                ROf = IIf(txtROff.Text = "", 0, txtROff.Text)
                Amt = Amt + Dtn + Oth + ROf
                txtAmount.Text = Amt.ToString("##,##,###.00")
            End If
        End If
    End Sub

    Private Sub dtpBlDt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBlDt.Validated
        ShowError(dtpBlDt, "")
    End Sub

    Private Sub dtpBlDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpBlDt.Validating
        If dtpBlDt.Value > Today Then
            e.Cancel = True
            ShowError(dtpBlDt, "No future Date!")
            Exit Sub
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSTax.CheckedChanged
        btnChange.Enabled = chkSTax.Checked
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        Select Case cboType.SelectedIndex
            Case 0  'Freight
                Me.BackColor = Color.Linen
            Case 1  'Supplementary
                Me.BackColor = Color.PowderBlue
            Case 2  'Detention
                Me.BackColor = Color.Wheat
            Case 3  'Others
                Me.BackColor = Color.YellowGreen
        End Select
    End Sub

    Private Sub txtBillNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBillNo.Validated
        ShowError(txtBillNo, "")
    End Sub

    Private Sub txtBillNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBillNo.Validating
        If txtBillNo.Text.Trim.Length > 0 Then
            If objBill.GetBillFromNo(txtBillNo.Text, gCoId, gYrCd) > 0 Then
                e.Cancel = True
                ShowError(txtBillNo, "Duplicate Bill Number!")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

    Private Sub dgvChals_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChals.CellClick
        Dim Amt, Frt, Dtn, Oth, ROf, STx As Single

        If e.ColumnIndex = 0 Then
            dgvChals.CurrentCell.Value = 1 - dgvChals.CurrentCell.Value
            Amt = 0 : Frt = 0 : STx = 0 : Dtn = 0 : Oth = 0 : ROf = 0
            For Each Rw As DataGridViewRow In dgvChals.Rows
                If Rw.Cells(0).Value = 1 Then
                    Frt = Frt + Rw.Cells(14).Value
                End If
            Next
            lblTot.Text = Frt.ToString("##,##,###.00")
            txtFreight.Text = lblTot.Text
            Amt = Amt + Frt
            txtServTax.Text = "0.00"
            If chkSTax.Checked Then
                STx = Math.Round(Amt / 4 * txtServPc.Text / 100, 2)
                txtServTax.Text = STx.ToString("##,##,###.00")
                Amt = Amt + STx
            End If
            Dtn = IIf(txtDeten.Text = "", 0, txtDeten.Text)
            Oth = IIf(txtOther.Text = "", 0, txtOther.Text)
            ROf = IIf(txtROff.Text = "", 0, txtROff.Text)
            Amt = Amt + Dtn + Oth + ROf
            txtAmount.Text = Amt.ToString("##,##,###.00")
        End If
    End Sub
End Class
