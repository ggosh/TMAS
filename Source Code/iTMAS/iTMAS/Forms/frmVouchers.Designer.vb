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
        Me.gbVoDtl = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAmt = New System.Windows.Forms.TextBox()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboGLs = New System.Windows.Forms.ComboBox()
        Me.dgvVoDtl = New System.Windows.Forms.DataGridView()
        Me.Dr = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Account = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTL = New System.Windows.Forms.DataGridView()
        Me.lblGridHeader = New System.Windows.Forms.Label()
        Me.dgvParty = New System.Windows.Forms.DataGridView()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Bill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCOlumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbVoDtl.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVoDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbVoDtl
        '
        Me.gbVoDtl.Controls.Add(Me.lblMessage)
        Me.gbVoDtl.Controls.Add(Me.GroupBox2)
        Me.gbVoDtl.Controls.Add(Me.TextBox2)
        Me.gbVoDtl.Controls.Add(Me.TextBox1)
        Me.gbVoDtl.Controls.Add(Me.Label2)
        Me.gbVoDtl.Controls.Add(Me.Label3)
        Me.gbVoDtl.Controls.Add(Me.GroupBox1)
        Me.gbVoDtl.Controls.Add(Me.dgvVoDtl)
        Me.gbVoDtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVoDtl.Location = New System.Drawing.Point(12, 50)
        Me.gbVoDtl.Name = "gbVoDtl"
        Me.gbVoDtl.Size = New System.Drawing.Size(596, 360)
        Me.gbVoDtl.TabIndex = 34
        Me.gbVoDtl.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(345, 30)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(161, 15)
        Me.lblMessage.TabIndex = 36
        Me.lblMessage.Text = "(Payment to market rankers)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(305, 38)
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
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(371, 100)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(62, 21)
        Me.TextBox2.TabIndex = 11
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(505, 100)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(70, 21)
        Me.TextBox1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(453, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "T/L No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(293, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Cheque No."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAmt)
        Me.GroupBox1.Controls.Add(Me.lblDay)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.cboGLs)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 90)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'txtAmt
        '
        Me.txtAmt.Location = New System.Drawing.Point(63, 59)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(138, 21)
        Me.txtAmt.TabIndex = 2
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(208, 62)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(41, 15)
        Me.lblDay.TabIndex = 7
        Me.lblDay.Text = "lblDay"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(24, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 15)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Type:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(24, 62)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 15)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Date:"
        '
        'cboGLs
        '
        Me.cboGLs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGLs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGLs.FormattingEnabled = True
        Me.cboGLs.Location = New System.Drawing.Point(63, 29)
        Me.cboGLs.Name = "cboGLs"
        Me.cboGLs.Size = New System.Drawing.Size(138, 23)
        Me.cboGLs.TabIndex = 1
        '
        'dgvVoDtl
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoDtl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVoDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoDtl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dr, Me.Account, Me.DrAmt, Me.CrAmt, Me.Balance, Me.DC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVoDtl.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVoDtl.Location = New System.Drawing.Point(10, 174)
        Me.dgvVoDtl.Name = "dgvVoDtl"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoDtl.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVoDtl.RowHeadersWidth = 20
        Me.dgvVoDtl.Size = New System.Drawing.Size(565, 178)
        Me.dgvVoDtl.TabIndex = 5
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
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TL, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTL.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTL.Location = New System.Drawing.Point(617, 50)
        Me.dgvTL.Name = "dgvTL"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.PapayaWhip
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTL.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTL.RowHeadersWidth = 20
        Me.dgvTL.Size = New System.Drawing.Size(274, 322)
        Me.dgvTL.TabIndex = 36
        '
        'lblGridHeader
        '
        Me.lblGridHeader.AutoSize = True
        Me.lblGridHeader.Location = New System.Drawing.Point(627, 23)
        Me.lblGridHeader.Name = "lblGridHeader"
        Me.lblGridHeader.Size = New System.Drawing.Size(161, 13)
        Me.lblGridHeader.TabIndex = 37
        Me.lblGridHeader.Text = "(sub entry for 2nd a/c onwards)"
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
        Me.dgvParty.Location = New System.Drawing.Point(617, 50)
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
        Me.dgvParty.Size = New System.Drawing.Size(274, 322)
        Me.dgvParty.TabIndex = 39
        '
        'cboType
        '
        Me.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"T/L", "Party", "Drivers", "Others"})
        Me.cboType.Location = New System.Drawing.Point(108, 23)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(149, 21)
        Me.cboType.TabIndex = 40
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(23, 27)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(77, 13)
        Me.Label47.TabIndex = 41
        Me.Label47.Text = "Voucher Type:"
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
        'frmVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(939, 449)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.dgvParty)
        Me.Controls.Add(Me.lblGridHeader)
        Me.Controls.Add(Me.dgvTL)
        Me.Controls.Add(Me.gbVoDtl)
        Me.Name = "frmVouchers"
        Me.Text = "frmVouchers"
        Me.gbVoDtl.ResumeLayout(False)
        Me.gbVoDtl.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvVoDtl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbVoDtl As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVoDtl As System.Windows.Forms.DataGridView
    Friend WithEvents txtAmt As System.Windows.Forms.TextBox
    Friend WithEvents cboGLs As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Dr As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Account As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTL As System.Windows.Forms.DataGridView
    Friend WithEvents lblGridHeader As System.Windows.Forms.Label
    Friend WithEvents dgvParty As System.Windows.Forms.DataGridView
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCOlumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
