<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRates
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbTLs = New System.Windows.Forms.GroupBox
        Me.btnRef = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.dgvRates = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtFindNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbEdit = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtRtKM = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtORPer = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtORat = New System.Windows.Forms.TextBox
        Me.txtORName = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSRPer = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSRat = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtHRat = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtBRat = New System.Windows.Forms.TextBox
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDest = New System.Windows.Forms.ComboBox
        Me.cboLoad = New System.Windows.Forms.ComboBox
        Me.cboProd = New System.Windows.Forms.ComboBox
        Me.cboCsge = New System.Windows.Forms.ComboBox
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPty = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.gbTLs.SuspendLayout()
        CType(Me.dgvRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbEdit.SuspendLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTLs
        '
        Me.gbTLs.Controls.Add(Me.btnRef)
        Me.gbTLs.Controls.Add(Me.btnDel)
        Me.gbTLs.Controls.Add(Me.Label8)
        Me.gbTLs.Controls.Add(Me.btnEdit)
        Me.gbTLs.Controls.Add(Me.btnNew)
        Me.gbTLs.Controls.Add(Me.dgvRates)
        Me.gbTLs.Controls.Add(Me.GroupBox2)
        Me.gbTLs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTLs.Location = New System.Drawing.Point(16, 212)
        Me.gbTLs.Name = "gbTLs"
        Me.gbTLs.Size = New System.Drawing.Size(612, 305)
        Me.gbTLs.TabIndex = 0
        Me.gbTLs.TabStop = False
        '
        'btnRef
        '
        Me.btnRef.BackColor = System.Drawing.Color.PeachPuff
        Me.btnRef.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.btnRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRef.Location = New System.Drawing.Point(584, 271)
        Me.btnRef.Name = "btnRef"
        Me.btnRef.Size = New System.Drawing.Size(22, 23)
        Me.btnRef.TabIndex = 5
        Me.btnRef.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDel.Location = New System.Drawing.Point(524, 269)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(54, 26)
        Me.btnDel.TabIndex = 4
        Me.btnDel.Text = "&Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(90, -2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Loading..."
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEdit.Location = New System.Drawing.Point(468, 269)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 26)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.PeachPuff
        Me.btnNew.Location = New System.Drawing.Point(411, 269)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(51, 26)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'dgvRates
        '
        Me.dgvRates.AllowUserToAddRows = False
        Me.dgvRates.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvRates.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRates.BackgroundColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRates.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRates.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvRates.GridColor = System.Drawing.Color.Brown
        Me.dgvRates.Location = New System.Drawing.Point(8, 16)
        Me.dgvRates.Name = "dgvRates"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRates.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRates.RowHeadersWidth = 18
        Me.dgvRates.RowTemplate.Height = 30
        Me.dgvRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRates.Size = New System.Drawing.Size(596, 247)
        Me.dgvRates.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFindNo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 37)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'txtFindNo
        '
        Me.txtFindNo.Location = New System.Drawing.Point(144, 10)
        Me.txtFindNo.Name = "txtFindNo"
        Me.txtFindNo.Size = New System.Drawing.Size(161, 21)
        Me.txtFindNo.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Party Name starting with:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Party Rate Master"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(483, 189)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(559, 189)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 22)
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.Label19)
        Me.gbEdit.Controls.Add(Me.txtRtKM)
        Me.gbEdit.Controls.Add(Me.Label18)
        Me.gbEdit.Controls.Add(Me.txtORPer)
        Me.gbEdit.Controls.Add(Me.Label17)
        Me.gbEdit.Controls.Add(Me.txtORat)
        Me.gbEdit.Controls.Add(Me.txtORName)
        Me.gbEdit.Controls.Add(Me.Label15)
        Me.gbEdit.Controls.Add(Me.txtSRPer)
        Me.gbEdit.Controls.Add(Me.Label14)
        Me.gbEdit.Controls.Add(Me.txtSRat)
        Me.gbEdit.Controls.Add(Me.Label13)
        Me.gbEdit.Controls.Add(Me.txtHRat)
        Me.gbEdit.Controls.Add(Me.Label12)
        Me.gbEdit.Controls.Add(Me.txtBRat)
        Me.gbEdit.Controls.Add(Me.txtStart)
        Me.gbEdit.Controls.Add(Me.Label11)
        Me.gbEdit.Controls.Add(Me.Label4)
        Me.gbEdit.Controls.Add(Me.Label3)
        Me.gbEdit.Controls.Add(Me.cboDest)
        Me.gbEdit.Controls.Add(Me.cboLoad)
        Me.gbEdit.Controls.Add(Me.cboProd)
        Me.gbEdit.Controls.Add(Me.cboCsge)
        Me.gbEdit.Controls.Add(Me.txtEnd)
        Me.gbEdit.Controls.Add(Me.dtpEnd)
        Me.gbEdit.Controls.Add(Me.Label10)
        Me.gbEdit.Controls.Add(Me.dtpStart)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.cboPty)
        Me.gbEdit.Controls.Add(Me.Label5)
        Me.gbEdit.Controls.Add(Me.Label2)
        Me.gbEdit.Controls.Add(Me.Label16)
        Me.gbEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEdit.Location = New System.Drawing.Point(16, 31)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(613, 152)
        Me.gbEdit.TabIndex = 21
        Me.gbEdit.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(287, 127)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 15)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "Route KM:"
        '
        'txtRtKM
        '
        Me.txtRtKM.Location = New System.Drawing.Point(359, 126)
        Me.txtRtKM.Name = "txtRtKM"
        Me.txtRtKM.Size = New System.Drawing.Size(64, 21)
        Me.txtRtKM.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(357, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 15)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Per:"
        '
        'txtORPer
        '
        Me.txtORPer.Location = New System.Drawing.Point(387, 100)
        Me.txtORPer.Name = "txtORPer"
        Me.txtORPer.Size = New System.Drawing.Size(36, 21)
        Me.txtORPer.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(214, 102)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 15)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Other Rate:"
        '
        'txtORat
        '
        Me.txtORat.Location = New System.Drawing.Point(290, 100)
        Me.txtORat.Name = "txtORat"
        Me.txtORat.Size = New System.Drawing.Size(64, 21)
        Me.txtORat.TabIndex = 10
        '
        'txtORName
        '
        Me.txtORName.Location = New System.Drawing.Point(290, 75)
        Me.txtORName.Name = "txtORName"
        Me.txtORName.Size = New System.Drawing.Size(133, 21)
        Me.txtORName.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(149, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Per:"
        '
        'txtSRPer
        '
        Me.txtSRPer.Location = New System.Drawing.Point(179, 126)
        Me.txtSRPer.Name = "txtSRPer"
        Me.txtSRPer.Size = New System.Drawing.Size(36, 21)
        Me.txtSRPer.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 15)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Short Rate:"
        '
        'txtSRat
        '
        Me.txtSRat.Location = New System.Drawing.Point(85, 126)
        Me.txtSRat.Name = "txtSRat"
        Me.txtSRat.Size = New System.Drawing.Size(64, 21)
        Me.txtSRat.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Hire Rate:"
        '
        'txtHRat
        '
        Me.txtHRat.Location = New System.Drawing.Point(85, 100)
        Me.txtHRat.Name = "txtHRat"
        Me.txtHRat.Size = New System.Drawing.Size(64, 21)
        Me.txtHRat.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 15)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Bill Rate:"
        '
        'txtBRat
        '
        Me.txtBRat.Location = New System.Drawing.Point(85, 75)
        Me.txtBRat.Name = "txtBRat"
        Me.txtBRat.Size = New System.Drawing.Size(64, 21)
        Me.txtBRat.TabIndex = 5
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(501, 76)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(87, 21)
        Me.txtStart.TabIndex = 13
        Me.txtStart.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(400, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 15)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Destination:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(185, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Loading Pt."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Product:"
        '
        'cboDest
        '
        Me.cboDest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDest.FormattingEnabled = True
        Me.cboDest.Location = New System.Drawing.Point(478, 45)
        Me.cboDest.Name = "cboDest"
        Me.cboDest.Size = New System.Drawing.Size(129, 23)
        Me.cboDest.TabIndex = 4
        '
        'cboLoad
        '
        Me.cboLoad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboLoad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoad.FormattingEnabled = True
        Me.cboLoad.Location = New System.Drawing.Point(259, 45)
        Me.cboLoad.Name = "cboLoad"
        Me.cboLoad.Size = New System.Drawing.Size(129, 23)
        Me.cboLoad.TabIndex = 3
        '
        'cboProd
        '
        Me.cboProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProd.FormattingEnabled = True
        Me.cboProd.Location = New System.Drawing.Point(85, 45)
        Me.cboProd.Name = "cboProd"
        Me.cboProd.Size = New System.Drawing.Size(80, 23)
        Me.cboProd.TabIndex = 2
        '
        'cboCsge
        '
        Me.cboCsge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCsge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCsge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCsge.FormattingEnabled = True
        Me.cboCsge.Location = New System.Drawing.Point(399, 16)
        Me.cboCsge.Name = "cboCsge"
        Me.cboCsge.Size = New System.Drawing.Size(208, 23)
        Me.cboCsge.TabIndex = 1
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(501, 103)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(86, 21)
        Me.txtEnd.TabIndex = 14
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(500, 102)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(106, 21)
        Me.dtpEnd.TabIndex = 16
        Me.dtpEnd.Value = New Date(2099, 12, 31, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(432, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "End Date:"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(500, 77)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(108, 21)
        Me.dtpStart.TabIndex = 15
        Me.dtpStart.Value = New Date(2010, 2, 2, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(432, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Start Date:"
        '
        'cboPty
        '
        Me.cboPty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPty.FormattingEnabled = True
        Me.cboPty.Location = New System.Drawing.Point(85, 16)
        Me.cboPty.Name = "cboPty"
        Me.cboPty.Size = New System.Drawing.Size(208, 23)
        Me.cboPty.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Consignee:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Party:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(214, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 15)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Other Name:"
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(386, 11)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(29, 13)
        Me.lblErr.TabIndex = 47
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmRates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(641, 517)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbTLs)
        Me.Name = "frmRates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Party Rates"
        Me.gbTLs.ResumeLayout(False)
        Me.gbTLs.PerformLayout()
        CType(Me.dgvRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbTLs As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRates As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRef As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPty As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFindNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCsge As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDest As System.Windows.Forms.ComboBox
    Friend WithEvents cboLoad As System.Windows.Forms.ComboBox
    Friend WithEvents cboProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBRat As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSRPer As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSRat As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHRat As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtORPer As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtORat As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtORName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRtKM As System.Windows.Forms.TextBox
    Friend WithEvents lblErr As System.Windows.Forms.Label
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
End Class
