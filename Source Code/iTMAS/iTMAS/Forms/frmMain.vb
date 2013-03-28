Imports System.Windows.Forms

Public Class frmMain
    Dim objMain As New clsMain

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name <> "frmDashboard" Then
                ChildForm.Close()
            End If
        Next
        frmDashboard.Close()
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If gUserType = "LI" Then
            Me.mnuCompany.Enabled = False
            Me.mnuBranch.Enabled = False
            Me.mnuUser.Enabled = False
        End If
        If gCoBuTy <> "T" Then
            Me.Text = "WinAc - Accounting"
        End If

        Dim objDBrd As New frmDashboard
        objDBrd.MdiParent = Me
        objDBrd.Show()
        objDBrd.Location = New Point(0, 0)
        objDBrd.Size = New Point(objDBrd.MdiParent.ClientSize.Width - 4, objDBrd.MdiParent.ClientSize.Height - 54)

        'Me.Text = Me.Text & "          (Login as  " & gUserDescription & ")"
    End Sub

    Private Sub mnuUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUser.Click
        'Dim objReport As New clsUser
        'objReport.MdiParent = Me
        'objReport.Show()
        'objReport.Location = New Point(objReport.MdiParent.ClientSize.Width / 2 - objReport.Width / 2, objReport.MdiParent.ClientSize.Height / 2 - objReport.Height / 2 - 100)

    End Sub

    Private Sub mnuChallans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuChallans.Click
        Dim objChallans As New frmChallans
        objChallans.MdiParent = Me
        objChallans.Show()
        objChallans.Location = New Point(objChallans.MdiParent.ClientSize.Width / 2 - objChallans.Width / 2, objChallans.MdiParent.ClientSize.Height / 2 - objChallans.Height / 2)
        objChallans.BringToFront()
    End Sub

    Private Sub mnuBills_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objBills As New frmBills
        objBills.MdiParent = Me
        objBills.Show()
        objBills.Location = New Point(objBills.MdiParent.ClientSize.Width / 2 - objBills.Width / 2, objBills.MdiParent.ClientSize.Height / 2 - objBills.Height / 2)
        objBills.BringToFront()
    End Sub

    Private Sub mnuVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVehicle.Click
        Dim objTLmast As New frmTLmast
        objTLmast.MdiParent = Me
        objTLmast.Show()
        objTLmast.Location = New Point(objTLmast.MdiParent.ClientSize.Width / 2 - objTLmast.Width / 2, objTLmast.MdiParent.ClientSize.Height / 2 - objTLmast.Height / 2)
        objTLmast.BringToFront()
    End Sub

    Private Sub mnuPlaces_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPlaces.Click
        Dim objPlace As New frmPlace
        objPlace.MdiParent = Me
        objPlace.Show()
        objPlace.Location = New Point(objPlace.MdiParent.ClientSize.Width / 2 - objPlace.Width / 2, objPlace.MdiParent.ClientSize.Height / 2 - objPlace.Height / 2)
        objPlace.BringToFront()
    End Sub

    Private Sub mnuCsgr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCsgr.Click
        Dim objCsgr As New frmCsgr
        objCsgr.MdiParent = Me
        objCsgr.Show()
        objCsgr.Location = New Point(objCsgr.MdiParent.ClientSize.Width / 2 - objCsgr.Width / 2, objCsgr.MdiParent.ClientSize.Height / 2 - objCsgr.Height / 2)
    End Sub

    Private Sub mnuCsge_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCsge.Click
        Dim objCsge As New frmCsge
        objCsge.MdiParent = Me
        objCsge.Show()
        objCsge.Location = New Point(objCsge.MdiParent.ClientSize.Width / 2 - objCsge.Width / 2, objCsge.MdiParent.ClientSize.Height / 2 - objCsge.Height / 2)
    End Sub

    Private Sub mnuProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProduct.Click
        Dim objProduct As New frmProduct
        objProduct.MdiParent = Me
        objProduct.Show()
        objProduct.Location = New Point(objProduct.MdiParent.ClientSize.Width / 2 - objProduct.Width / 2, objProduct.MdiParent.ClientSize.Height / 2 - objProduct.Height / 2)
    End Sub

    Private Sub mnuReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '
    End Sub

    Private Sub mnuCBV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCBV.Click
        Dim objVos As New frmVos
        objVos.MdiParent = Me
        objVos.Show()
    End Sub

    Private Sub mnuJV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuJV.Click
        Dim objVos As New frmVos
        objVos.MdiParent = Me
        objVos.Show()
        objVos.BringToFront()
    End Sub

    Private Sub mnuLedger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLedger.Click
        Dim objGL As New frmGLmast
        objGL.MdiParent = Me
        objGL.Show()
        objGL.Location = New Point(objGL.MdiParent.ClientSize.Width - objGL.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGroup.Click
        '
    End Sub

    Private Sub mnuRates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRates.Click
        Dim objGL As New frmRates
        objGL.MdiParent = Me
        objGL.Show()
        objGL.Location = New Point(objGL.MdiParent.ClientSize.Width - objGL.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuImp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuImp.Click
        Dim objGL As New DbfImp
        objGL.MdiParent = Me
        objGL.Show()
        objGL.Location = New Point(objGL.MdiParent.ClientSize.Width - objGL.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuSubGL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSubGL.Click
        Dim objGl As New frmSubMast
        objGl.MdiParent = Me
        objGl.Show()
        objGl.Location = New Point(objGl.MdiParent.ClientSize.Width - objGl.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuBilAge_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuBilAge.Click

    End Sub

    Private Sub mnuOwnXp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOwnXp.Click
        Dim objTE As New frmTLexp
        objTE.MdiParent = Me
        objTE.Show()
        objTE.Location = New Point(objTE.MdiParent.ClientSize.Width - objTE.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuVhldg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVhldg.Click
        Dim objTE As New frmTLLdg
        objTE.MdiParent = Me
        objTE.Show()
        objTE.Location = New Point(objTE.MdiParent.ClientSize.Width - objTE.ClientSize.Width - 20, 50)
    End Sub

    Private Sub mnuVhLOw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVhLOw.Click
        Dim objTE As New frmOwnrLdg
        objTE.MdiParent = Me
        objTE.Show()
        objTE.Location = New Point(objTE.MdiParent.ClientSize.Width - objTE.ClientSize.Width - 20, 50)

    End Sub
End Class
