Public Class frmCsgr

    Dim objCs As New clsCsgr
    Dim objPl As New clsPlace
    Dim Csid As Int32

    Private Sub frmCsgr_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 13
        If lPlac Then
            PopulateLoads()
        End If
    End Sub

    Private Sub frmCsgr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 13

        lblErr.Text = ""
        PopulateLoads()
        PopulateCsgrs()
    End Sub

    Private Sub PopulateLoads()
        Dim dt As DataTable
        Dim Flt As String

        Label8.Visible = True
        Flt = "pl_type='L'"

        dt = objPl.GetPlaceList(gCoId, Flt)
        cboLocs.DataSource = dt
        cboLocs.DisplayMember = "Place"
        cboLocs.ValueMember = "pl_id"

        Label8.Visible = False

    End Sub

    Private Sub PopulateCsgrs()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objCs.GetCsgrList(gCoId)
        dgvCsgrs.DataSource = dt
        dgvCsgrs.Columns(0).Visible = False
        dgvCsgrs.Columns(1).Width = 150
        dgvCsgrs.Columns(2).Width = 75
        dgvCsgrs.Columns(3).Visible = False
        dgvCsgrs.Columns(4).Visible = False
        dgvCsgrs.Columns(5).Width = 100

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Csid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboLocs.SelectedValue = 0
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        Csid = dgvCsgrs.CurrentRow.Cells(0).Value
        dt = objCs.GetCsgrDetails(Csid)
        dr = dt.Rows(0)
        txtCode.Text = dr("cs_code")
        txtName.Text = dr("cs_name")
        cboLocs.SelectedValue = dr("ldpt_id")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sPlSht As String, sPlNam As String, yrOpen As String
            Dim sPlTy As Int32

            If Validation() = False Then
                Exit Sub
            End If

            sPlSht = Me.txtCode.Text.Trim
            sPlNam = Me.txtName.Text.Trim
            sPlTy = Me.cboLocs.SelectedValue
            yrOpen = gAcYr.Substring(0, 3)

            Csid = objCs.InsertUpdateCsgr(Csid, sPlSht, sPlNam, sPlTy, yrOpen, gCoId)
            lCsgr = True
            PopulateCsgrs()
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
            errMsgs = errMsgs + "Consignor code can not be blank." + vbCrLf
            passed = False
        End If

        If Me.txtName.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Consignor name can not be blank." + vbCrLf
            passed = False
        End If
        If Me.txtName.Text.Trim.Length > 30 Then
            errMsgs = errMsgs + "Consignor name too long(>30)." + vbCrLf
            passed = False
        End If

        If Me.cboLocs.SelectedValue = 0 Then
            errMsgs = errMsgs + "Loading Point can not be blank." + vbCrLf
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
        PopulateCsgrs()
    End Sub

    Private Sub btnDref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDref.Click
        PopulateLoads()
    End Sub

    Private Sub frmCsgr_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvCsgrs.Width = Me.Width - 36
        GroupBox1.Width = Me.Width - 36
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        Me.ErrorPro.SetError(txtName, "")
        lblErr.Text = ""
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If txtName.Text.Trim.Length > 0 Then
            If objCs.ChkDuplicateCsgr(Csid, txtName.Text) > 0 Then
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
            If objCs.ChkDuplicateCsgrCode(Csid, txtCode.Text) > 0 Then
                e.Cancel = True
                Me.ErrorPro.SetError(txtCode, "Duplicate Code!")
                lblErr.Text = "Duplicate Code!"
                Exit Sub
            End If
        End If
    End Sub
End Class