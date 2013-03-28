Public Class frmCsge

    Dim objCs As New clsCsge
    Dim objGl As New clsGlmast
    Dim objPl As New clsPlace
    Dim Csid As Int32

    Private Sub frmCsge_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 14
        If lPlac Then
            PopulateLoads()
        End If
        If lAcc Then
            PopulatePtys()
        End If

    End Sub

    Private Sub frmCsge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 14

        lblErr.Text = ""
        PopulateLoads()
        PopulatePtys()
        PopulateCsges()
    End Sub

    Private Sub PopulateLoads()
        Dim dt As DataTable
        Dim Flt As String

        Label8.Visible = True
        Flt = "pl_type='D'"

        dt = objPl.GetPlaceList(gCoId, Flt)
        cboLocs.DataSource = dt
        cboLocs.DisplayMember = "Place"
        cboLocs.ValueMember = "pl_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulatePtys()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objGl.GetPartyList(gCoId, "")
        cboParty.DataSource = dt
        cboParty.DisplayMember = "Name"
        cboParty.ValueMember = "Gl_Id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateCsges()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objCs.GetCsgeList(gCoId, "")
        dgvCsges.DataSource = dt
        dgvCsges.Columns(0).Visible = False
        dgvCsges.Columns(1).Width = 80
        dgvCsges.Columns(2).Width = 100
        dgvCsges.Columns(3).Visible = False
        dgvCsges.Columns(4).Visible = False
        dgvCsges.Columns(5).Visible = False
        dgvCsges.Columns(6).Width = 200
        dgvCsges.Columns(7).Width = 150

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Csid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboLocs.SelectedValue = 0
        cboParty.SelectedValue = 0
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        Csid = dgvCsges.CurrentRow.Cells(0).Value
        dt = objCs.GetCsgeDetails(Csid)
        dr = dt.Rows(0)
        txtCode.Text = dr("csge_code")
        txtName.Text = dr("csge_name")
        cboParty.SelectedValue = dr("Gl_id")
        cboLocs.SelectedValue = dr("dest_id")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sPlSht As String, sPlNam As String, yrOpen As String
            Dim sPlTy As Int32, Glid As Int32

            If Validation() = False Then
                Exit Sub
            End If

            sPlSht = Me.txtCode.Text.Trim
            sPlNam = Me.txtName.Text.Trim
            glid = Me.cboParty.SelectedValue
            sPlTy = Me.cboLocs.SelectedValue
            yrOpen = gAcYr.Substring(1, 3)

            Csid = objCs.InsertUpdateCsge(Csid, sPlSht, sPlNam, Glid, sPlTy, yrOpen, gCoId)
            lCsge = True
            PopulateCsges()
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
        If Me.txtCode.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Consignee code can not be blank." + vbCrLf
            passed = False
        End If

        If Me.txtName.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Consignee name can not be blank." + vbCrLf
            passed = False
        End If
        If Me.txtName.Text.Trim.Length > 30 Then
            errMsgs = errMsgs + "Consignee name too long(>30)." + vbCrLf
            passed = False
        End If

        If Me.cboParty.SelectedValue = 0 Then
            errMsgs = errMsgs + "Party can not be blank." + vbCrLf
            passed = False
        End If

        If Me.cboLocs.SelectedValue = 0 Then
            errMsgs = errMsgs + "Destination can not be blank." + vbCrLf
            passed = False
        End If


        If passed = False Then
            gError_Message(errMsgs, MessageBoxButtons.OK + MessageBoxIcon.Error)
        End If
        Return passed
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateCsges()
    End Sub

    Private Sub btnDref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDref.Click
        PopulateLoads()
    End Sub

    Private Sub frmCsge_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvCsges.Width = Me.Width - 36
        GroupBox1.Width = Me.Width - 36
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        Me.ErrorPro.SetError(txtName, "")
        lblErr.Text = ""
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If txtName.Text.Trim.Length > 0 Then
            If objCs.ChkDuplicateCsge(Csid, txtName.Text) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtName, "Duplicate Name!")
                lblErr.Text = "Duplicate Name!"
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
            If objCs.ChkDuplicateCsgeCode(Csid, txtCode.Text) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtCode, "Duplicate Code!")
                lblErr.Text = "Duplicate Code!"
                Exit Sub
            End If
        End If
    End Sub
End Class