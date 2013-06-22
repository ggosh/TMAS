<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVouchers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbVoDtl = New System.Windows.Forms.GroupBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvVoucherDetail = New System.Windows.Forms.DataGridView()
        Me.Dr = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Account = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTL = New System.Windows.Forms.DataGridView()
        Me.TL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvParty = New System.Windows.Forms.DataGridView()
        Me.Bill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCOlumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dgvOthers = New System.Windows.Forms.DataGridView()
        Me.SubLedgerAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbVoDtl.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvVoucherDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOthers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbVoDtl
        '
        Me.gbVoDtl.Controls.Add(Me.txtDate)
        Me.gbVoDtl.Controls.Add(Me.lblDay)
        Me.gbVoDtl.Controls.Add(Me.GroupBox2)
        Me.gbVoDtl.Controls.Add(Me.Label25)
        Me.gbVoDtl.Controls.Add(Me.TextBox2)
        Me.gbVoDtl.Controls.Add(Me.Label3)
        Me.gbVoDtl.Controls.Add(Me.dgvVoucherDetail)
        Me.gbVoDtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVoDtl.Location = New System.Drawing.Point(12, 50)
        Me.gbVoDtl.Name = "gbVoDtl"
        Me.gbVoDtl.Size = New System.Drawing.Size(590, 284)
        Me.gbVoDtl.TabIndex = 34
        Me.gbVoDtl.TabStop = False
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(51, 81)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(138, 21)
        Me.txtDate.TabIndex = 2
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(196, 84)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(41, 15)
        Me.lblDay.TabIndex = 7
        Me.lblDay.Text = "lblDay"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(180, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 32)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cash/Bank Voucher"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 15)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Date:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(482, 81)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(93, 21)
        Me.TextBox2.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Cheque No."
        '
        'dgvVoucherDetail
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVoucherDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dr, Me.Account, Me.DrAmt, Me.CrAmt, Me.Balance, Me.DC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVoucherDetail.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVoucherDetail.Location = New System.Drawing.Point(10, 125)
        Me.dgvVoucherDetail.Name = "dgvVoucherDetail"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVoucherDetail.RowHeadersWidth = 20
        Me.dgvVoucherDetail.Size = New System.Drawing.Size(565, 134)
        Me.dgvVoucherDetail.TabIndex = 5
        '
        'Dr
        '
        Me.Dr.Frozen = True
        Me.Dr.HeaderText = "Dr"
        Me.Dr.Name = "Dr"
        Me.Dr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Dr.Width = 35
        '
        'Account
        '
        Me.Account.Frozen = True
        Me.Account.HeaderText = "Account"
        Me.Account.Name = "Account"
        Me.Account.Width = 150
        '
        'DrAmt
        '
        Me.DrAmt.Frozen = True
        Me.DrAmt.HeaderText = "Dr. Amount"
        Me.DrAmt.Name = "DrAmt"
        '
        'CrAmt
        '
        Me.CrAmt.Frozen = True
        Me.CrAmt.HeaderText = "Cr. Amount"
        Me.CrAmt.Name = "CrAmt"
        '
        'Balance
        '
        Me.Balance.Frozen = True
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        '
        'DC
        '
        Me.DC.Frozen = True
        Me.DC.HeaderText = "D/C"
        Me.DC.Name = "DC"
        Me.DC.ReadOnly = True
        Me.DC.Width = 50
        '
        'dgvTL
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TL, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTL.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTL.Location = New System.Drawing.Point(12, 350)
        Me.dgvTL.Name = "dgvTL"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTL.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTL.RowHeadersWidth = 20
        Me.dgvTL.Size = New System.Drawing.Size(575, 253)
        Me.dgvTL.TabIndex = 36
        '
        'TL
        '
        Me.TL.Frozen = True
        Me.TL.HeaderText = "T\L"
        Me.TL.Name = "TL"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "Account"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'dgvParty
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvParty.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvParty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParty.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Bill, Me.DateCOlumn, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvParty.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvParty.Location = New System.Drawing.Point(12, 350)
        Me.dgvParty.Name = "dgvParty"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvParty.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvParty.RowHeadersWidth = 20
        Me.dgvParty.Size = New System.Drawing.Size(575, 253)
        Me.dgvParty.TabIndex = 39
        '
        'Bill
        '
        Me.Bill.HeaderText = "Bill"
        Me.Bill.Name = "Bill"
        Me.Bill.Width = 80
        '
        'DateCOlumn
        '
        Me.DateCOlumn.HeaderText = "Date"
        Me.DateCOlumn.Name = "DateCOlumn"
        Me.DateCOlumn.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Account"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(9, 23)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(77, 13)
        Me.Label47.TabIndex = 41
        Me.Label47.Text = "Voucher Type:"
        '
        'cboType
        '
        Me.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Payment", "Receipt", "Contra", "Journal"})
        Me.cboType.Location = New System.Drawing.Point(92, 23)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(149, 21)
        Me.cboType.TabIndex = 40
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(224, 625)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(315, 625)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dgvOthers
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOthers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvOthers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOthers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SubLedgerAccount, Me.ParentAccount, Me.Amount})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOthers.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvOthers.Location = New System.Drawing.Point(12, 350)
        Me.dgvOthers.Name = "dgvOthers"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOthers.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvOthers.RowHeadersWidth = 20
        Me.dgvOthers.Size = New System.Drawing.Size(575, 253)
        Me.dgvOthers.TabIndex = 44
        '
        'SubLedgerAccount
        '
        Me.SubLedgerAccount.Frozen = True
        Me.SubLedgerAccount.HeaderText = "Sub Ledger Account"
        Me.SubLedgerAccount.Name = "SubLedgerAccount"
        Me.SubLedgerAccount.Width = 150
        '
        'ParentAccount
        '
        Me.ParentAccount.Frozen = True
        Me.ParentAccount.HeaderText = "Parent Account"
        Me.ParentAccount.Name = "ParentAccount"
        Me.ParentAccount.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'frmVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(614, 663)
        Me.Controls.Add(Me.dgvOthers)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.gbVoDtl)
        Me.Controls.Add(Me.dgvTL)
        Me.Controls.Add(Me.dgvParty)
        Me.Name = "frmVouchers"
        Me.Text = "frmVouchers"
        Me.gbVoDtl.ResumeLayout(False)
        Me.gbVoDtl.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvVoucherDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOthers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbVoDtl As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVoucherDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dr As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Account As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTL As System.Windows.Forms.DataGridView
    Friend WithEvents dgvParty As System.Windows.Forms.DataGridView
    Friend WithEvents TL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCOlumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgvOthers As System.Windows.Forms.DataGridView
    Friend WithEvents SubLedgerAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
