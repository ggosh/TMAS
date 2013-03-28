Public Class frmBills

    Dim objBill As New clsBill

    Private Sub frmBills_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 3
        PopulateBills()
    End Sub

    Private Sub frmBills_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gUObj = 3
        PopulateBills()
    End Sub

    Private Sub PopulateBills()
        Dim dt As DataTable
        Dim Flt As String = ""

        Label8.Visible = True
        dtpBlDt.Value = Today
        'Flt = "b.bill_dt='" & Today.ToLongDateString.Substring(InStr(Today.ToLongDateString, ",") + 1) & "'"

        dt = objBill.GetBillList(gCoId, Flt)
        dgvBills.DataSource = dt
        dgvBills.Columns(0).Visible = False
        dgvBills.Columns(1).Width = 100
        dgvBills.Columns(2).Width = 100
        dgvBills.Columns(3).Width = 100
        dgvBills.Columns(4).Width = 40
        dgvBills.Columns(5).Width = 200

        Label8.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If gCoBuTy = "T" Then
            Dim objBill As New frmBill
            objBill.MdiParent = Me.MdiParent
            objBill.Show()
            objBill.BringToFront()
        Else
            Dim objBill As New frmBill2i
            objBill.MdiParent = Me.MdiParent
            objBill.Show()
            objBill.BringToFront()
        End If
    End Sub

    Private Sub frmBills_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Left = 0
        Me.Top = 40
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If gCoBuTy = "T" Then
            Dim objBill As New frmBill
            objBill.MdiParent = Me.MdiParent
            objBill.Show()
            objBill.BringToFront()
        Else
            Dim objBill As New frmBill2i
            objBill.MdiParent = Me.MdiParent
            objBill.iBill_id = dgvBills.CurrentRow.Cells(0).Value
            objBill.Show()
            objBill.BringToFront()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PopulateBills()
    End Sub

End Class