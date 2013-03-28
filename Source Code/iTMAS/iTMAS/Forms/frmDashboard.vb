Imports System.Collections

Public Class frmDashboard

    Dim objDashB As New clsDashboard
    Dim y As Int16 = 0

    Private Sub frmDashboard_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gUObj = 1
    End Sub

    Private Sub frmDashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        gUObj = 1
        Label1.Left = 10      ' Me.ClientSize.Width - Label1.Width
        Label1.Text = gCoName
        Label18.Text = gCoName
        If gCoBuTy = "T" Then
            lbli.Visible = True
            Label2.Text = "Transport Management && Accounting Solution"
            Label10.Visible = True
            Label3.Top = 80
        Else
            lbli.Visible = False
            Label2.Text = "Integrated Accounting Solution"
            Label10.Visible = False
            Label3.Top = 60
            lblLogo.Text = "WinAc 2"
        End If
        Label1.Width = Label2.Left - 50
        If Label1.Text.Length > 24 Then
            Label18.Visible = True
            Label18.Width = Label1.Width
        End If
        Label9.Left = 10
        Label9.Text = gCoAddr
        lblTime.Text = Now.ToShortDateString + " " + Now.ToShortTimeString
        Label7.Text = gUserName
        Label16.Text = Environment.MachineName

        Timer1.Enabled = True

        PopulateUsers(True)
        PopulateBrns()
        btnSetBrn_Click(sender, e)
        PopulateYears()
        btnSetYr_Click(sender, e)
        PopulateBalances()
        PopulateFavs()
    End Sub

    Private Sub frmDashboard_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lblLogo.Left = Me.ClientSize.Width / 2 - lblLogo.Width / 2
        Label2.Left = Me.ClientSize.Width / 2 - Label2.Width / 2
        lbli.Left = Label2.Left
        Label1.Width = Label2.Left - 50
        Label18.Width = Label1.Width
        Label10.Left = Me.ClientSize.Width / 2 - Label10.Width / 2
        Label3.Left = Me.ClientSize.Width / 2 - Label3.Width / 2
        lblTime.Left = Me.ClientSize.Width - lblTime.Width
        Label7.Left = Me.ClientSize.Width - Label7.Width - 7
        Label6.Left = Label7.Left - 10 - Label6.Width
        Label6.Top = Label7.Top
        lblGinc.Top = Me.ClientSize.Height - lblGinc.Height - 10
        lblGinc.Left = Me.ClientSize.Width / 2 - lblGinc.Width / 2
        Label16.Top = Me.ClientSize.Height - Label16.Height - 10
        Label16.Left = Me.ClientSize.Width - Label16.Width - 7
        Label17.Top = Label16.Top
        Label17.Left = Label16.Left - 10 - Label17.Width

        gbOnline.Top = Me.ClientSize.Height - gbOnline.Height - 10
        gbFav1.Width = 196 : gbFav1.Height = 216 : dgvFav1.Height = gbFav1.Height - 36 : gbFav1.Left = 12
        gbBalances.Left = Me.ClientSize.Width - gbBalances.Width - 5
        gbFav2.Top = gbBalances.Top + gbBalances.Height + 12
        gbFav2.Width = gbBalances.Width : gbFav2.Height = gbFav1.Height
        gbFav2.Left = Me.ClientSize.Width - gbFav2.Width - 5 : dgvFav2.Height = gbFav2.Height - 36
    End Sub

    Private Sub PopulateUsers(ByVal lIn As Boolean)
        Dim dt As DataTable

        Label8.Visible = True

        objDashB.InsertUpdteULog(gCoId, gUser_ID, gUObj, lIn)

        dt = objDashB.GetCurrUsers(gCoId)
        dgvUsers.DataSource = dt
        dgvUsers.Columns(0).Visible = False
        dgvUsers.Columns(1).Width = 58

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
            Label15.Visible = False
            btnBrRef.Visible = False
            btnSetBrn.Visible = False
            cboYears.Top = cboBrns.Top
            Label4.Top = Label15.Top
            btnAYRef.Top = btnBrRef.Top
            btnSetYr.Top = btnSetBrn.Top
        End If
        gbFav1.Top = cboYears.Top + 32
        Label8.Visible = False

    End Sub

    Private Sub PopulateYears()
        Dim dt As DataTable

        Label8.Visible = True
        dt = objDashB.GetYears(gCoId)
        cboYears.DisplayMember = "YrDesc"
        cboYears.ValueMember = "Yr_id"
        cboYears.DataSource = dt
        If dt.Rows.Count = 1 Then
            cboYears.Enabled = False
            btnSetYr.Enabled = False
        End If
        Label8.Visible = False

    End Sub

    Private Sub PopulateBalances()
        Dim dt As DataTable

        Label8.Visible = True
        dt = objDashB.GetHiBals(gCoId, gUser_ID)
        If dt.Rows.Count > 5 Then
            dgvBalances.RowHeadersWidth = 12
        Else
            dgvBalances.RowHeadersWidth = 21
        End If
        dgvBalances.DataSource = dt

        dgvBalances.Columns(0).Visible = False
        dgvBalances.Columns(1).Width = 60
        dgvBalances.Columns(2).Width = 80
        dgvBalances.Columns(3).Visible = False
        Label8.Visible = False

    End Sub

    Private Sub PopulateFavs()
        Dim dt1, dt2 As DataTable

        Label8.Visible = True

        dt1 = objDashB.GetFavs(gCoId, gUser_ID, "1", False)
        dgvFav1.DataSource = dt1
        dgvFav1.Columns(0).Visible = False
        dgvFav1.Columns(1).Visible = False
        dgvFav1.Columns(2).Width = 150
        dgvFav1.Columns(3).Visible = False

        dt2 = objDashB.GetFavs(gCoId, gUser_ID, "2", False)
        dgvFav2.DataSource = dt2
        dgvFav2.Columns(0).Visible = False
        dgvFav2.Columns(1).Visible = False
        dgvFav2.Columns(2).Width = 150
        dgvFav2.Columns(3).Visible = False

        Label8.Visible = False

    End Sub

    Private Sub btnAYRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAYRef.Click
        PopulateYears()
    End Sub

    Private Sub btnIBRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIBRef.Click
        btnViewIB_Click(sender, e)
        PopulateBalances()
    End Sub

    Private Sub btnViewOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewOL.Click
        Me.gbOnline.Size = New Point(87, 151)
        gbOnline.Top = Me.ClientSize.Height - gbOnline.Height - 10
        btnHideOL.Visible = True
    End Sub

    Private Sub btnHideOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHideOL.Click
        Me.gbOnline.Size = New Point(87, 32)
        gbOnline.Top = Me.ClientSize.Height - gbOnline.Height - 10
        btnHideOL.Visible = False
    End Sub

    Private Sub btnViewIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewIB.Click
        gbBalances.Size = New Point(198, 192)
        btnHideIB.Visible = True
        gbFav2.Top = gbBalances.Top + gbBalances.Height + 12
    End Sub

    Private Sub btnHideIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHideIB.Click
        gbBalances.Size = New Point(198, 45)
        btnHideIB.Visible = False
        gbFav2.Top = gbBalances.Top + gbBalances.Height + 12
    End Sub

    Private Sub btnSetBrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBrn.Click
        If cboBrns.Items.Count > 0 Then
            gAcBrn = cboBrns.Text
            gAcBrId = cboBrns.SelectedValue
        End If
    End Sub

    Private Sub btnSetYr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetYr.Click
        Dim dt As DataTable

        If cboYears.Items.Count > 0 Then
            gAcYr = cboYears.Text
            gYrCd = gAcYr.Substring(0, 2)
            dt = objDashB.GetYears(gCoId)
            For Each dr As DataRow In dt.Rows
                If dr.Item("YrDesc") = gAcYr Then
                    gYrStart = dr.Item("YrStart")
                    gYrEnd = dr.Item("YrEnd")
                End If
            Next
        End If
    End Sub

    Private Sub dgvFav1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFav1.CellContentDoubleClick
        Dim ECh As Int64, rw As DataGridViewRow

        rw = dgvFav1.CurrentRow
        ECh = rw.Cells(1).Value

        FavAction(ECh)

    End Sub

    Private Sub dgvFav2_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFav2.CellContentDoubleClick
        Dim ECh As Int64, rw As DataGridViewRow

        rw = dgvFav2.CurrentRow
        ECh = rw.Cells(1).Value

        FavAction(ECh)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Now.ToShortDateString + " " + Now.ToShortTimeString
        PopulateUsers(False)
    End Sub

    Private Sub FavAction(ByVal eCh As Int64)
        Select Case eCh
            Case 2
                Dim objChallans As New frmChallans
                objChallans.MdiParent = Me.MdiParent
                objChallans.Show()
                objChallans.BringToFront()
            Case 3
                Dim objBills As New frmBills
                objBills.MdiParent = Me.MdiParent
                objBills.Show()
                objBills.BringToFront()
            Case 5
                Dim objVo As New frmVos
                objVo.MdiParent = Me.MdiParent
                objVo.Show()
                objVo.BringToFront()
            Case 6
                Dim objVo As New frmVos
                objVo.MdiParent = Me.MdiParent
                objVo.Show()
                objVo.BringToFront()
        End Select

        Select Case eCh
            Case 11
                Dim objTL As New frmTLmast
                objTL.MdiParent = Me.MdiParent
                objTL.Show()
                objTL.BringToFront()
            Case 12
                Dim objPl As New frmPlace
                objPl.MdiParent = Me.MdiParent
                objPl.Show()
                objPl.BringToFront()
            Case 13
                Dim objCsge As New frmCsge
                objCsge.MdiParent = Me
                objCsge.Show()
                objCsge.BringToFront()
            Case 14
                Dim objCsgr As New frmCsgr
                objCsgr.MdiParent = Me
                objCsgr.Show()
                objCsgr.BringToFront()
            Case 15
                Dim objProduct As New frmProduct
                objProduct.MdiParent = Me
                objProduct.Show()
                objProduct.BringToFront()
            Case 16
                Dim objGl As New frmGLmast
                objGl.MdiParent = Me.MdiParent
                objGl.Show()
                objGl.BringToFront()
            Case 17
                Dim objGl As New frmSubMast
                objGl.MdiParent = Me.MdiParent
                objGl.Show()
                objGl.BringToFront()
            Case 18
                Dim objTLmast As New frmTLmast
                objTLmast.MdiParent = Me
                objTLmast.Show()
                objTLmast.BringToFront()
        End Select

        For Each ChildForm As Form In Me.MdiParent.MdiChildren
            If ChildForm.Name <> "frmDashboard" Then
                ChildForm.Select()
            End If
        Next

    End Sub

End Class