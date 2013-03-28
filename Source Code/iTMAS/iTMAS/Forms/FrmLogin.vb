Public Class frmLogin

    Dim objMain As New clsMain
    Dim objLogin As New clsLogin
    Dim objDB As New clsDashboard

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim dt As DataTable
        dt = objLogin.GetUserDetails(txtUID.Text, txtPWD.Text)
        If dt.Rows.Count = 0 Then
            gError_Message("User not found.", MessageBoxButtons.OK + MessageBoxIcon.Error)
        Else
            Dim f1 As New frmMain
            gUser_ID = dt.Rows(0).Item("Usr_ID")
            gUserName = Trim(txtUID.Text)
            gUserType = dt.Rows(0).Item("userType")
            gUserDescription = dt.Rows(0).Item("description")

            If gCoBuTy = "T" Then
                ShowTMenu(True, f1)
            Else
                ShowTMenu(False, f1)
            End If
            f1.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub ShowTMenu(ByVal blShw As Boolean, ByRef F1 As frmMain)
        F1.mnuChallans.Visible = blShw
        F1.mnuCsge.Visible = blShw
        F1.mnuCsgr.Visible = blShw
        F1.mnuExpiry.Visible = blShw
        F1.mnuTSP.Visible = blShw

        F1.mnuHFBills.Visible = blShw
        F1.mnuHiredGI.Visible = blShw
        F1.mnuLoadReg.Visible = blShw
        F1.mnuOwnGP.Visible = blShw
        F1.mnuOwnXp.Visible = blShw
        F1.mnuParShip.Visible = blshw

        F1.mnuPlaces.Visible = blshw
        F1.mnuProduct.Visible = blshw
        F1.mnuRates.Visible = blShw
        F1.mnuVehicle.Visible = blShw
        F1.mnuVhldg.Visible = blShw
        F1.mnuVhLOw.Visible = blShw
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable

        If objMain.CheckDBConnection = False Then
            gError_Message("Could not connect to Database server", MessageBoxButtons.OK + MessageBoxIcon.Error)
            End
        Else
            txtUID.Text = "admin"
            txtPWD.Text = "admin"

            dt = objDB.GetCoDetails(gCoId)
            gCoType = dt.Rows(0).Item("co_type")        '"P"
            gCoBuTy = dt.Rows(0).Item("cobu_type")      '"T"
            gCoSht = dt.Rows(0).Item("co_sht")
            gCoName = dt.Rows(0).Item("co_name")
            gCoAddr = dt.Rows(0).Item("co_add")
            gProduct = dt.Rows(0).Item("product")
            gStock = dt.Rows(0).Item("stock")
            gPurch = dt.Rows(0).Item("purchase")
            gAcc = dt.Rows(0).Item("accounts")
            gCashPty = dt.Rows(0).Item("CashParty")
            gDtnB4Ldg = dt.Rows(0).Item("dtn_b4_ldg")
            gAcEffctB4dlv = dt.Rows(0).Item("AcEffctB4Dlv")
            gDrShrtge2Drv = dt.Rows(0).Item("DrShrtge2Drv")
            gDtn2ShrMktTL = dt.Rows(0).Item("Dtn2ShrMktTL")
            gShrtgeIncldBill = dt.Rows(0).Item("ShrtgeIncldBill")
            gMaxChlinBill = dt.Rows(0).Item("MaxChlinBill")
            gVoNoGen = dt.Rows(0).Item("VoNoGen")
            gPrintVouch = dt.Rows(0).Item("PrintVouch")

            If gCoBuTy = "T" Then
            Else
                Label1.Left = Me.Width + 1
                Label3.Left = (Me.Width - Label3.Width) / 2
                Label4.Left = (Me.Width - Label4.Width) / 2
                lblLogo.Text = "WinAc 2"
            End If
        End If
    End Sub
End Class
