<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.OperationMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuChallans = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTSP = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHFBills = New System.Windows.Forms.ToolStripMenuItem
        Me.AccountsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCBV = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuJV = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuBills = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAdjustR = New System.Windows.Forms.ToolStripMenuItem
        Me.OReportsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLoadReg = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVhldg = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVhLOw = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuParShip = New System.Windows.Forms.ToolStripMenuItem
        Me.AReportsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCBook = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuJrBook = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPOS = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPOSum = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuParLdg = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuParRem = New System.Windows.Forms.ToolStripMenuItem
        Me.MISMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDailyCash = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBilAge = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOwnGP = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHiredGI = New System.Windows.Forms.ToolStripMenuItem
        Me.MasterMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLedger = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSubGL = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGroup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuVehicle = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCsgr = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCsge = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProduct = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPlaces = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOwnXp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRates = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExpiry = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuCompany = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBranch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUser = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuImp = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.TTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperationMenu, Me.AccountsMenu, Me.OReportsMenu, Me.AReportsMenu, Me.MISMenu, Me.MasterMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'OperationMenu
        '
        Me.OperationMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuChallans, Me.mnuTSP, Me.mnuHFBills})
        Me.OperationMenu.Name = "OperationMenu"
        Me.OperationMenu.Size = New System.Drawing.Size(72, 20)
        Me.OperationMenu.Text = "&Operations"
        '
        'mnuChallans
        '
        Me.mnuChallans.Name = "mnuChallans"
        Me.mnuChallans.Size = New System.Drawing.Size(173, 22)
        Me.mnuChallans.Text = "&Loading/Unloading"
        Me.mnuChallans.ToolTipText = "Enter Loading / Unloading / Detention"
        '
        'mnuTSP
        '
        Me.mnuTSP.Name = "mnuTSP"
        Me.mnuTSP.Size = New System.Drawing.Size(173, 22)
        Me.mnuTSP.Text = "&Shortage/Penalty"
        '
        'mnuHFBills
        '
        Me.mnuHFBills.Name = "mnuHFBills"
        Me.mnuHFBills.Size = New System.Drawing.Size(173, 22)
        Me.mnuHFBills.Text = "&Hire Freight Billing"
        '
        'AccountsMenu
        '
        Me.AccountsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCBV, Me.mnuJV, Me.ToolStripSeparator1, Me.mnuBills, Me.mnuAdjustR})
        Me.AccountsMenu.Name = "AccountsMenu"
        Me.AccountsMenu.Size = New System.Drawing.Size(63, 20)
        Me.AccountsMenu.Text = "&Accounts"
        '
        'mnuCBV
        '
        Me.mnuCBV.Name = "mnuCBV"
        Me.mnuCBV.Size = New System.Drawing.Size(193, 22)
        Me.mnuCBV.Text = "&Cash/Bank Vouchers"
        '
        'mnuJV
        '
        Me.mnuJV.Name = "mnuJV"
        Me.mnuJV.ShortcutKeyDisplayString = ""
        Me.mnuJV.Size = New System.Drawing.Size(193, 22)
        Me.mnuJV.Text = "&Journal Vouchers"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(190, 6)
        '
        'mnuBills
        '
        Me.mnuBills.Name = "mnuBills"
        Me.mnuBills.Size = New System.Drawing.Size(193, 22)
        Me.mnuBills.Text = "&Billing to Party"
        '
        'mnuAdjustR
        '
        Me.mnuAdjustR.Name = "mnuAdjustR"
        Me.mnuAdjustR.Size = New System.Drawing.Size(193, 22)
        Me.mnuAdjustR.Text = "Adjust Adhoc Receipts"
        '
        'OReportsMenu
        '
        Me.OReportsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoadReg, Me.mnuVhldg, Me.mnuVhLOw, Me.mnuParShip})
        Me.OReportsMenu.Name = "OReportsMenu"
        Me.OReportsMenu.Size = New System.Drawing.Size(75, 20)
        Me.OReportsMenu.Text = "Re&ports-Op"
        '
        'mnuLoadReg
        '
        Me.mnuLoadReg.Name = "mnuLoadReg"
        Me.mnuLoadReg.Size = New System.Drawing.Size(197, 22)
        Me.mnuLoadReg.Text = "Loading Register"
        '
        'mnuVhldg
        '
        Me.mnuVhldg.Name = "mnuVhldg"
        Me.mnuVhldg.Size = New System.Drawing.Size(197, 22)
        Me.mnuVhldg.Text = "Vehicle Ledger (T/L)"
        '
        'mnuVhLOw
        '
        Me.mnuVhLOw.Name = "mnuVhLOw"
        Me.mnuVhLOw.Size = New System.Drawing.Size(197, 22)
        Me.mnuVhLOw.Text = "Vehicle Ledger (Owner)"
        '
        'mnuParShip
        '
        Me.mnuParShip.Name = "mnuParShip"
        Me.mnuParShip.Size = New System.Drawing.Size(197, 22)
        Me.mnuParShip.Text = "Party Shipment Details"
        '
        'AReportsMenu
        '
        Me.AReportsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCBook, Me.mnuJrBook, Me.mnuPOS, Me.mnuPOSum, Me.mnuParLdg, Me.mnuParRem})
        Me.AReportsMenu.Name = "AReportsMenu"
        Me.AReportsMenu.Size = New System.Drawing.Size(77, 20)
        Me.AReportsMenu.Text = "&Reports-A/c"
        '
        'mnuCBook
        '
        Me.mnuCBook.Name = "mnuCBook"
        Me.mnuCBook.Size = New System.Drawing.Size(191, 22)
        Me.mnuCBook.Text = "Cash Book"
        '
        'mnuJrBook
        '
        Me.mnuJrBook.Name = "mnuJrBook"
        Me.mnuJrBook.Size = New System.Drawing.Size(191, 22)
        Me.mnuJrBook.Text = "Journal Book"
        '
        'mnuPOS
        '
        Me.mnuPOS.Name = "mnuPOS"
        Me.mnuPOS.Size = New System.Drawing.Size(191, 22)
        Me.mnuPOS.Text = "Party O/s Details"
        '
        'mnuPOSum
        '
        Me.mnuPOSum.Name = "mnuPOSum"
        Me.mnuPOSum.Size = New System.Drawing.Size(191, 22)
        Me.mnuPOSum.Text = "Party O/s Summary"
        '
        'mnuParLdg
        '
        Me.mnuParLdg.Name = "mnuParLdg"
        Me.mnuParLdg.Size = New System.Drawing.Size(191, 22)
        Me.mnuParLdg.Text = "Party Ledger"
        '
        'mnuParRem
        '
        Me.mnuParRem.Name = "mnuParRem"
        Me.mnuParRem.Size = New System.Drawing.Size(191, 22)
        Me.mnuParRem.Text = "Party Reminder Letter"
        '
        'MISMenu
        '
        Me.MISMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDailyCash, Me.mnuBilAge, Me.mnuOwnGP, Me.mnuHiredGI})
        Me.MISMenu.Name = "MISMenu"
        Me.MISMenu.Size = New System.Drawing.Size(49, 20)
        Me.MISMenu.Text = "M.&I.S."
        '
        'mnuDailyCash
        '
        Me.mnuDailyCash.Name = "mnuDailyCash"
        Me.mnuDailyCash.Size = New System.Drawing.Size(196, 22)
        Me.mnuDailyCash.Text = "Daily Cash Balance"
        '
        'mnuBilAge
        '
        Me.mnuBilAge.Name = "mnuBilAge"
        Me.mnuBilAge.Size = New System.Drawing.Size(196, 22)
        Me.mnuBilAge.Text = "Bills Aging Analysis"
        '
        'mnuOwnGP
        '
        Me.mnuOwnGP.Name = "mnuOwnGP"
        Me.mnuOwnGP.Size = New System.Drawing.Size(196, 22)
        Me.mnuOwnGP.Text = "Own Vehicle GP Report"
        '
        'mnuHiredGI
        '
        Me.mnuHiredGI.Name = "mnuHiredGI"
        Me.mnuHiredGI.Size = New System.Drawing.Size(196, 22)
        Me.mnuHiredGI.Text = "Hired Vehicle GI Report"
        '
        'MasterMenu
        '
        Me.MasterMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLedger, Me.mnuSubGL, Me.mnuGroup, Me.ToolStripSeparator3, Me.mnuVehicle, Me.mnuCsgr, Me.mnuCsge, Me.mnuProduct, Me.mnuPlaces, Me.mnuOwnXp, Me.mnuRates, Me.mnuExpiry, Me.ToolStripSeparator4, Me.mnuCompany, Me.mnuBranch, Me.mnuUser, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem, Me.mnuImp})
        Me.MasterMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.MasterMenu.Name = "MasterMenu"
        Me.MasterMenu.Size = New System.Drawing.Size(52, 20)
        Me.MasterMenu.Text = "&Master"
        '
        'mnuLedger
        '
        Me.mnuLedger.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuLedger.Name = "mnuLedger"
        Me.mnuLedger.Size = New System.Drawing.Size(207, 22)
        Me.mnuLedger.Text = "&Ledger A/c"
        '
        'mnuSubGL
        '
        Me.mnuSubGL.Name = "mnuSubGL"
        Me.mnuSubGL.Size = New System.Drawing.Size(207, 22)
        Me.mnuSubGL.Text = "Sub Ledger A/c"
        '
        'mnuGroup
        '
        Me.mnuGroup.Name = "mnuGroup"
        Me.mnuGroup.Size = New System.Drawing.Size(207, 22)
        Me.mnuGroup.Text = "A/c &Group"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(204, 6)
        '
        'mnuVehicle
        '
        Me.mnuVehicle.Name = "mnuVehicle"
        Me.mnuVehicle.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuVehicle.Size = New System.Drawing.Size(207, 22)
        Me.mnuVehicle.Text = "&Vehicle"
        '
        'mnuCsgr
        '
        Me.mnuCsgr.Name = "mnuCsgr"
        Me.mnuCsgr.Size = New System.Drawing.Size(207, 22)
        Me.mnuCsgr.Text = "C&onsignor"
        '
        'mnuCsge
        '
        Me.mnuCsge.Name = "mnuCsge"
        Me.mnuCsge.Size = New System.Drawing.Size(207, 22)
        Me.mnuCsge.Text = "Co&nsignee"
        '
        'mnuProduct
        '
        Me.mnuProduct.Name = "mnuProduct"
        Me.mnuProduct.Size = New System.Drawing.Size(207, 22)
        Me.mnuProduct.Text = "&Product"
        '
        'mnuPlaces
        '
        Me.mnuPlaces.Name = "mnuPlaces"
        Me.mnuPlaces.Size = New System.Drawing.Size(207, 22)
        Me.mnuPlaces.Text = "&Destination/Loading Point"
        '
        'mnuOwnXp
        '
        Me.mnuOwnXp.Name = "mnuOwnXp"
        Me.mnuOwnXp.Size = New System.Drawing.Size(207, 22)
        Me.mnuOwnXp.Text = "O&wn Expense"
        '
        'mnuRates
        '
        Me.mnuRates.Name = "mnuRates"
        Me.mnuRates.Size = New System.Drawing.Size(207, 22)
        Me.mnuRates.Text = "&Rate Chart"
        '
        'mnuExpiry
        '
        Me.mnuExpiry.Name = "mnuExpiry"
        Me.mnuExpiry.Size = New System.Drawing.Size(207, 22)
        Me.mnuExpiry.Text = "License E&xpiry"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(204, 6)
        '
        'mnuCompany
        '
        Me.mnuCompany.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuCompany.Name = "mnuCompany"
        Me.mnuCompany.Size = New System.Drawing.Size(207, 22)
        Me.mnuCompany.Text = "&Company"
        '
        'mnuBranch
        '
        Me.mnuBranch.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuBranch.Name = "mnuBranch"
        Me.mnuBranch.Size = New System.Drawing.Size(207, 22)
        Me.mnuBranch.Text = "&Branch"
        '
        'mnuUser
        '
        Me.mnuUser.Name = "mnuUser"
        Me.mnuUser.Size = New System.Drawing.Size(207, 22)
        Me.mnuUser.Text = "&User Management"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(204, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'mnuImp
        '
        Me.mnuImp.Name = "mnuImp"
        Me.mnuImp.Size = New System.Drawing.Size(207, 22)
        Me.mnuImp.Text = "Import Data"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseAllToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(62, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(40, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(170, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'TTips
        '
        Me.TTips.AutoPopDelay = 5000
        Me.TTips.InitialDelay = 300
        Me.TTips.ReshowDelay = 100
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "RECON - Transport Management & Accounting"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TTips As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVehicle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCompany As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBranch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLedger As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents AccountsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCsgr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCsge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuJV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCBV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OperationMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuChallans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AReportsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPOS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPOSum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuProduct As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlaces As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOwnXp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExpiry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MISMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTSP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHFBills As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdjustR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuParLdg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuParRem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OReportsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVhldg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVhLOw As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLoadReg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuParShip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDailyCash As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBilAge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOwnGP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHiredGI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBills As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuJrBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSubGL As System.Windows.Forms.ToolStripMenuItem

End Class
