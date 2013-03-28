Public Class frmProduct

    Dim objPr As New clsProduct
    Dim Plid As Int32

    Private Sub frmProduct_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 15
    End Sub

    Private Sub frmProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 15

        lblErr.Text = ""
        PopulateProducts()
    End Sub

    Private Sub PopulateProducts()
        Dim dt As DataTable
        Dim Flt As String

        Label8.Visible = True
        Flt = ""

        dt = objPr.GetProductList(gCoId)
        dgvProducts.DataSource = dt
        dgvProducts.Columns(0).Visible = False
        dgvProducts.Columns(1).Width = 100
        dgvProducts.Columns(2).Width = 200

        Label8.Visible = False

    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Plid = 0
        txtCode.Text = ""
        txtName.Text = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dt As DataTable, dr As DataRow

        Plid = dgvProducts.CurrentRow.Cells(0).Value
        dt = objPr.GetProductDetails(Plid)
        dr = dt.Rows(0)
        txtCode.Text = dr("pl_sht")
        txtName.Text = dr("pl_name")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sPlSht As String, sPlNam As String, yrOpen As String

            If Validation() = False Then
                Exit Sub
            End If

            sPlSht = Me.txtCode.Text.Trim
            sPlNam = Me.txtName.Text.Trim
            yrOpen = gAcYr.Substring(0, 3)

            Plid = objPr.InsertUpdateProduct(Plid, sPlSht, sPlNam, yrOpen, gCoId)
            lProd = True
            PopulateProducts()
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
            errMsgs = errMsgs + "Product code can not be blank." + vbCrLf
            passed = False
        End If

        If Me.txtName.Text.Trim.Length = 0 Then
            errMsgs = errMsgs + "Product name can not be blank." + vbCrLf
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

    Private Sub btnRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRef.Click
        PopulateProducts()
    End Sub
End Class