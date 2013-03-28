<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBill
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtROff = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtOthNam = New System.Windows.Forms.TextBox
        Me.btnChange = New System.Windows.Forms.Button
        Me.txtServPc = New System.Windows.Forms.TextBox
        Me.txtOther = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtDeten = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.chkSTax = New System.Windows.Forms.CheckBox
        Me.txtServTax = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.dtpBlDt = New System.Windows.Forms.DateTimePicker
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblRef = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboPtys = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblTot = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvChals = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblLodLoc = New System.Windows.Forms.Label
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.TTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvChals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(614, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Loading..."
        Me.Label8.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(310, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 34)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Billing Info"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtROff)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtOthNam)
        Me.GroupBox2.Controls.Add(Me.btnChange)
        Me.GroupBox2.Controls.Add(Me.txtServPc)
        Me.GroupBox2.Controls.Add(Me.txtOther)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtDeten)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.chkSTax)
        Me.GroupBox2.Controls.Add(Me.txtServTax)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtFreight)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.dtpBlDt)
        Me.GroupBox2.Controls.Add(Me.txtBillNo)
        Me.GroupBox2.Controls.Add(Me.cboType)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblRef)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboPtys)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 192)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        '
        'txtROff
        '
        Me.txtROff.Location = New System.Drawing.Point(631, 168)
        Me.txtROff.Name = "txtROff"
        Me.txtROff.Size = New System.Drawing.Size(124, 21)
        Me.txtROff.TabIndex = 27
        Me.txtROff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(524, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Round Off:"
        '
        'txtOthNam
        '
        Me.txtOthNam.Location = New System.Drawing.Point(528, 143)
        Me.txtOthNam.Name = "txtOthNam"
        Me.txtOthNam.Size = New System.Drawing.Size(227, 21)
        Me.txtOthNam.TabIndex = 25
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(650, 66)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(59, 25)
        Me.btnChange.TabIndex = 24
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'txtServPc
        '
        Me.txtServPc.Location = New System.Drawing.Point(543, 67)
        Me.txtServPc.Name = "txtServPc"
        Me.txtServPc.Size = New System.Drawing.Size(44, 21)
        Me.txtServPc.TabIndex = 22
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(632, 119)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(124, 21)
        Me.txtOther.TabIndex = 21
        Me.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(524, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 15)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Other Charges"
        '
        'txtDeten
        '
        Me.txtDeten.Enabled = False
        Me.txtDeten.Location = New System.Drawing.Point(632, 93)
        Me.txtDeten.Name = "txtDeten"
        Me.txtDeten.Size = New System.Drawing.Size(124, 21)
        Me.txtDeten.TabIndex = 19
        Me.txtDeten.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(524, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 15)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Detention:"
        '
        'chkSTax
        '
        Me.chkSTax.AutoSize = True
        Me.chkSTax.CheckAlign = System.Drawing.ContentAlignment.BottomRight
        Me.chkSTax.Location = New System.Drawing.Point(521, 43)
        Me.chkSTax.Name = "chkSTax"
        Me.chkSTax.Size = New System.Drawing.Size(89, 19)
        Me.chkSTax.TabIndex = 17
        Me.chkSTax.Text = "Service Tax"
        Me.chkSTax.UseVisualStyleBackColor = True
        '
        'txtServTax
        '
        Me.txtServTax.Location = New System.Drawing.Point(634, 41)
        Me.txtServTax.Name = "txtServTax"
        Me.txtServTax.Size = New System.Drawing.Size(124, 21)
        Me.txtServTax.TabIndex = 16
        Me.txtServTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(588, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 15)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "% of 25%)"
        '
        'txtFreight
        '
        Me.txtFreight.Enabled = False
        Me.txtFreight.Location = New System.Drawing.Point(634, 14)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(124, 21)
        Me.txtFreight.TabIndex = 14
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(524, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 15)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Freight:"
        '
        'txtAmount
        '
        Me.txtAmount.Enabled = False
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(359, 147)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(124, 21)
        Me.txtAmount.TabIndex = 12
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpBlDt
        '
        Me.dtpBlDt.CustomFormat = "dd/MM/yy"
        Me.dtpBlDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBlDt.Location = New System.Drawing.Point(359, 109)
        Me.dtpBlDt.Name = "dtpBlDt"
        Me.dtpBlDt.Size = New System.Drawing.Size(124, 21)
        Me.dtpBlDt.TabIndex = 11
        Me.dtpBlDt.Value = New Date(2010, 7, 1, 12, 55, 0, 0)
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(359, 70)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(124, 21)
        Me.txtBillNo.TabIndex = 10
        '
        'cboType
        '
        Me.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Freight", "Supplementary", "Detention", "Others"})
        Me.cboType.Location = New System.Drawing.Point(359, 32)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(124, 23)
        Me.cboType.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(297, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Amount:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(297, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 15)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Bill Date:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(297, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Bill No."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(297, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Bill Type:"
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(288, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(211, 182)
        Me.Label9.TabIndex = 4
        '
        'lblRef
        '
        Me.lblRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRef.Location = New System.Drawing.Point(70, 121)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(207, 70)
        Me.lblRef.TabIndex = 3
        Me.lblRef.Text = "P.O."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Reference:"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(9, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 76)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Address"
        '
        'cboPtys
        '
        Me.cboPtys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPtys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPtys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPtys.FormattingEnabled = True
        Me.cboPtys.Location = New System.Drawing.Point(9, 10)
        Me.cboPtys.Name = "cboPtys"
        Me.cboPtys.Size = New System.Drawing.Size(268, 23)
        Me.cboPtys.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(524, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(23, 15)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "(@"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblTot)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dgvChals)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 232)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(764, 265)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        '
        'lblTot
        '
        Me.lblTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTot.Location = New System.Drawing.Point(632, 242)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(126, 20)
        Me.lblTot.TabIndex = 5
        Me.lblTot.Text = "0.00"
        Me.lblTot.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(587, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Total:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "0 Challans"
        '
        'dgvChals
        '
        Me.dgvChals.AllowUserToAddRows = False
        Me.dgvChals.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvChals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvChals.BackgroundColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvChals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSalmon
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvChals.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvChals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvChals.Location = New System.Drawing.Point(5, 10)
        Me.dgvChals.Name = "dgvChals"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChals.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvChals.RowHeadersWidth = 25
        Me.dgvChals.RowTemplate.Height = 18
        Me.dgvChals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChals.Size = New System.Drawing.Size(753, 232)
        Me.dgvChals.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Party:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(716, 501)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 21)
        Me.btnCancel.TabIndex = 35
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(640, 501)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblLodLoc
        '
        Me.lblLodLoc.AutoSize = True
        Me.lblLodLoc.Location = New System.Drawing.Point(9, 509)
        Me.lblLodLoc.Name = "lblLodLoc"
        Me.lblLodLoc.Size = New System.Drawing.Size(39, 13)
        Me.lblLodLoc.TabIndex = 36
        Me.lblLodLoc.Text = "Label7"
        Me.lblLodLoc.Visible = False
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(570, 25)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(29, 13)
        Me.lblErr.TabIndex = 47
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(788, 534)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.lblLodLoc)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label8)
        Me.Name = "frmBill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bill"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvChals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvChals As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPtys As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents dtpBlDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDeten As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkSTax As System.Windows.Forms.CheckBox
    Friend WithEvents txtServTax As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents txtServPc As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtOthNam As System.Windows.Forms.TextBox
    Friend WithEvents lblLodLoc As System.Windows.Forms.Label
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtROff As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblErr As System.Windows.Forms.Label
    Friend WithEvents TTips As System.Windows.Forms.ToolTip
End Class
