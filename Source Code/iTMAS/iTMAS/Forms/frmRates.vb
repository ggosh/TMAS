Public Class frmRates

    Dim objRt As New clsRates
    Dim objGl As New clsGlmast
    Dim objCsge As New clsCsge
    Dim objPl As New clsPlace
    Dim objPr As New clsProduct
    Dim RTid As Int32
    Dim Flt As String

    Private Sub frmRates_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 15
        If lAcc Then
            PopulatePtys()
        End If
        If lCsge Then
            PopulateCsges()
        End If
        If lPlac Then
            PopulateLoads()
        End If
        If lProd Then
            PopulateProducts()
        End If
    End Sub

    Private Sub frmRates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 15

        lblErr.Text = ""
        Flt = ""
        PopulatePtys()
        PopulateRates()
        PopulateCsges()
        PopulateLoads()
        PopulateProducts()
        'tl_no like 'M%' / 'TL_No like ''%2569%'
    End Sub

    Private Sub PopulateRates()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objRt.GetRateList(gCoId, Flt)
        dgvRates.DataSource = dt
        dgvRates.Columns(0).Visible = False
        dgvRates.Columns(1).Width = 100
        dgvRates.Columns(2).Width = 50
        dgvRates.Columns(3).Width = 100
        dgvRates.Columns(4).Width = 100
        dgvRates.Columns(5).Width = 100
        dgvRates.Columns(6).Width = 100
        dgvRates.Columns(7).Width = 80
        dgvRates.Columns(8).Width = 80
        dgvRates.Columns(9).Visible = False

        Label8.Visible = False

    End Sub

    Private Sub PopulatePtys()
        Dim dt As DataTable, dr As DataRow

        Label8.Visible = True

        dt = objGl.GetPartyList(gCoId, "")
        dr = dt.NewRow
        dr("gl_id") = 0
        dr("Name") = "--Select--"
        dt.Rows.InsertAt(dr, 0)
        cboPty.DataSource = dt
        cboPty.DisplayMember = "Name"
        cboPty.ValueMember = "Gl_Id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateCsges()
        Dim dt As DataTable, dr As DataRow

        Label8.Visible = True
        If cboPty.SelectedIndex > -1 Then
            dt = objCsge.GetCsgeList(gCoId, "c.gl_id=" & cboPty.SelectedValue)
            dr = dt.NewRow
            dr("csge_id") = 0
            dr("Name") = "--Select--"
            dt.Rows.InsertAt(dr, 0)
            cboCsge.DataSource = dt
            cboCsge.DisplayMember = "Name"
            cboCsge.ValueMember = "csge_Id"
        End If
        Label8.Visible = False

    End Sub

    Private Sub PopulateLoads()
        Dim dt As DataTable, dr As DataRow
        Dim Flt As String

        Label8.Visible = True

        Flt = "pl_type='L'"
        dt = objPl.GetPlaceList(gCoId, Flt)
        dr = dt.NewRow
        dr("pl_id") = 0
        dr("Place") = "--Select--"
        dt.Rows.InsertAt(dr, 0)
        cboLoad.DataSource = dt
        cboLoad.DisplayMember = "Place"
        cboLoad.ValueMember = "pl_id"

        Flt = "pl_type='D'"
        dt = objPl.GetPlaceList(gCoId, Flt)
        dr = dt.NewRow
        dr("pl_id") = 0
        dr("Place") = "--Select--"
        dt.Rows.InsertAt(dr, 0)
        cboDest.DataSource = dt
        cboDest.DisplayMember = "Place"
        cboDest.ValueMember = "pl_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateProducts()
        Dim dt As DataTable, dr As DataRow

        Label8.Visible = True

        dt = objPr.GetProductList(gCoId)
        dr = dt.NewRow
        dr("prod_id") = 0
        dr("Product") = "--Select--"
        dt.Rows.InsertAt(dr, 0)
        cboProd.DataSource = dt
        cboProd.DisplayMember = "Product"
        cboProd.ValueMember = "prod_id"

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        RTid = 0
        cboPty.SelectedValue = -1
        cboCsge.SelectedValue = -1
        cboProd.SelectedValue = -1
        cboLoad.SelectedValue = -1
        cboDest.SelectedValue = -1
        txtBRat.Text = ""
        txtHRat.Text = ""
        txtSRat.Text = ""
        txtSRPer.Text = "KG"
        txtORName.Text = ""
        txtORat.Text = "0"
        txtORPer.Text = "MT"
        dtpStart.Value = Today
        txtEnd.Text = ""
        txtRtKM.Text = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        RTid = dgvRates.CurrentRow.Cells(0).Value
        dt = objRt.GetRateDetails(RTid)
        dr = dt.Rows(0)
        cboPty.SelectedValue = dr("Gl_id")
        cboCsge.SelectedValue = dr("csge_id")
        cboProd.SelectedValue = dr("prod_id")
        cboLoad.SelectedValue = dr("ldpt_id")
        cboDest.SelectedValue = dr("dest_id")
        txtBRat.Text = dr("Bill_rate")
        txtHRat.Text = dr("hire_rate")
        txtSRat.Text = dr("shrt_rate")
        txtSRPer.Text = dr("shrt_unit")
        txtORName.Text = dr("othr_name")
        txtORat.Text = dr("othr_rate")
        txtORPer.Text = dr("othr_unit")
        dtpStart.Value = dr("start_date")
        txtEnd.Text = ""
        If dr("end_date").ToString <> "" Then
            dtpEnd.Value = dr("end_date")
            txtEnd.Text = dtpEnd.Value.ToShortDateString
        End If
        txtRtKM = dr("RouteKM")
        cboPty.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sBR, sHR, sSR, sSU, sON, sOR, sOU, sRtKM As String
            Dim Ptid, CsId, Prid, LPid, DsId As Int32
            Dim dStdt As Nullable(Of Date)
            Dim dEndt As Nullable(Of Date)

            If Validation() = False Then
                Exit Sub
            End If

            'sTLcd = Me.lblCode.Text
            Ptid = Me.cboPty.SelectedValue
            CsId = Me.cboCsge.SelectedValue
            Prid = Me.cboProd.SelectedValue
            LPid = Me.cboLoad.SelectedValue
            DsId = Me.cboDest.SelectedValue
            sBR = Me.txtBRat.Text.Trim
            sHR = Me.txtHRat.Text.Trim
            sSR = Me.txtSRat.Text.Trim
            sSU = Me.txtSRPer.Text.Trim
            sON = Me.txtORName.Text.Trim
            sOR = Me.txtORat.Text.Trim
            sOU = Me.txtORPer.Text.Trim
            sRTKM = Me.txtRtKM.Text.Trim

            dStdt = dtpStart.Value
            If txtEnd.Text.Trim.Length > 0 Then
                dEndt = dtpEnd.Value
            End If

            RTid = objRt.InsertUpdateRate(RTid, Ptid, CsId, Prid, LPid, DsId, sBR, sHR, sSR, sSU, sOR, sON, sOU, dStdt, dEndt, "", gCoId, sRtKM)
            lRat = True
            PopulateRates()
            btnNew_Click(sender, e)

            Dim Rw, rw2 As DataGridViewRow
            Dim i As Integer = 0

            i = dgvRates.SelectedRows.Count
            For Each Rw In dgvRates.Rows
                If Rw.Cells(0).Value.ToString.Equals(RTid.ToString.Trim) Then
                    For Each rw2 In dgvRates.SelectedRows
                        rw2.Selected = False
                    Next
                    dgvRates.Rows(Rw.Index).Selected = True
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
        If Me.txtBRat.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Bill Rate can not be blank." + vbCrLf
            passed = False
        End If

        If cboPty.SelectedValue < 1 Then
            errMsgs = errMsgs + "Select a Party." + vbCrLf
            passed = False
        End If

        If txtStart.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Select start date." + vbCrLf
            passed = False
        End If

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

    Private Sub dtpStart_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStart.Leave
        txtStart.Text = dtpStart.Text
    End Sub

    Private Sub dtpEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEnd.Leave
        txtEnd.Text = dtpEnd.Text
    End Sub

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateRates()
    End Sub

    Private Sub txtFindNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindNo.KeyUp
        If e.KeyCode = Keys.Enter Then
            dgvRates.Focus()
        End If
    End Sub

    Private Sub txtFindNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindNo.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0
        Dim s As String

        s = txtFindNo.Text.Trim
        i = dgvRates.SelectedRows.Count
        For Each Rw In dgvRates.Rows
            If Rw.Cells(1).Value.ToString.StartsWith(s.ToUpper) Then
                For Each rw2 In dgvRates.SelectedRows
                    rw2.Selected = False
                Next
                dgvRates.Rows(Rw.Index).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub frmRates_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        gbEdit.Width = Me.Width - 41
        gbTLs.Width = Me.Width - 41
        dgvRates.Width = gbTLs.Width - 14
    End Sub

    Private Sub cboPty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPty.SelectedIndexChanged
        If cboPty.SelectedIndex > 0 Then
            PopulateCsges()
        End If
    End Sub

    Private Sub ShowError(ByVal control As System.Windows.Forms.Control, ByVal Msg As String)
        Me.ErrorPro.SetError(control, Msg)
        lblErr.Text = Msg
    End Sub

End Class
