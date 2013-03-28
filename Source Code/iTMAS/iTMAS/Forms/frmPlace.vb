Public Class frmPlace

    Dim objPlc As New clsPlace
    Dim Plid As Int32
    Dim Flt As String

    Private Sub frmPlace_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 12
    End Sub

    Private Sub frmPlace_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 12

        lblErr.Text = ""
        Flt = ""
        PopTypes()
        PopulatePlaces()
        'pl_name like 'B%'
    End Sub

    Private Sub PopTypes()
        Dim dt As New DataTable
        dt.Columns.Add("Tid", System.Type.GetType("System.String"))
        dt.Columns.Add("TypeM", System.Type.GetType("System.String"))

        dt.Rows.Add("L", "Loading Pt.")
        dt.Rows.Add("D", "Destination")
        cboType.DataSource = dt
        cboType.DisplayMember = "TypeM"
        cboType.ValueMember = "Tid"
    End Sub

    Private Sub PopulatePlaces()
        Dim dt As DataTable

        Label8.Visible = True

        dt = objPlc.GetPlaceList(gCoId, Flt)
        dgvPlaces.DataSource = dt
        dgvPlaces.Columns(0).Visible = False
        dgvPlaces.Columns(1).Width = 170
        dgvPlaces.Columns(2).Width = 50
        dgvPlaces.Columns(4).Width = 60
        dgvPlaces.Columns(3).Visible = False

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Plid = 0
        txtCode.Text = ""
        txtName.Text = ""
        cboType.SelectedValue = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable, dr As DataRow

        Plid = dgvPlaces.CurrentRow.Cells(0).Value
        dt = objPlc.GetPlaceDetails(Plid)
        dr = dt.Rows(0)
        txtCode.Text = dr("pl_sht")
        txtName.Text = dr("pl_name")
        cboType.SelectedValue = dr("pl_type")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sPlSht As String, sPlNam As String, sPlTy As String

            If Validation() = False Then
                Exit Sub
            End If

            sPlSht = Me.txtCode.Text.Trim
            sPlNam = Me.txtName.Text.Trim
            sPlTy = Me.cboType.SelectedValue

            Plid = objPlc.InsertUpdatePlace(Plid, sPlSht, sPlNam, sPlTy, gCoId)
            lPlac = True
            PopulatePlaces()
            btnNew_Click(sender, e)

            Dim Rw, rw2 As DataGridViewRow
            Dim i As Integer = 0

            i = dgvPlaces.SelectedRows.Count
            For Each Rw In dgvPlaces.Rows
                If Rw.Cells(0).Value.ToString.Equals(Plid.ToString.Trim) Then
                    For Each rw2 In dgvPlaces.SelectedRows
                        rw2.Selected = False
                    Next
                    dgvPlaces.Rows(Rw.Index).Selected = True
                    Exit For
                End If
            Next

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
            errMsgs = errMsgs + "Place code can not be blank." + vbCrLf
            passed = False
        End If

        If Me.txtName.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Place name can not be blank." + vbCrLf
            passed = False
        End If

        If Me.cboType.SelectedValue = "" Then
            errMsgs = errMsgs + "Place must be Loading Point or Destination." + vbCrLf
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

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PopulatePlaces()
    End Sub

    Private Sub frmPlace_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        gbEdit.Width = Me.Width - 36
        gbPls.Width = Me.Width - 36
        dgvPlaces.Width = gbPls.Width - 9
    End Sub

    Private Sub txtFindName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindName.TextChanged
        Dim Rw, rw2 As DataGridViewRow
        Dim i As Integer = 0

        If txtFindName.Text.ToUpper.Trim.Length > 0 Then
            i = dgvPlaces.SelectedRows.Count
            For Each Rw In dgvPlaces.Rows
                If Rw.Cells(1).Value.ToString.StartsWith(txtFindName.Text.ToUpper.Trim) Then
                    For Each rw2 In dgvPlaces.SelectedRows
                        rw2.Selected = False
                    Next
                    dgvPlaces.Rows(Rw.Index).Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub
End Class