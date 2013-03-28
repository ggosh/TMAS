<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubMast
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboGrp = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPh = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtVAT = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRC = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPAN = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAddr = New System.Windows.Forms.TextBox
        Me.txtOpb = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.dgvSubs = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnSRef = New System.Windows.Forms.Button
        Me.dgvGLs = New System.Windows.Forms.DataGridView
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSubs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sub-Head"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboGrp)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPh)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtVAT)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtRC)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPAN)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtAddr)
        Me.GroupBox1.Controls.Add(Me.txtOpb)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(513, 150)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'cboGrp
        '
        Me.cboGrp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGrp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrp.FormattingEnabled = True
        Me.cboGrp.Location = New System.Drawing.Point(76, 39)
        Me.cboGrp.Name = "cboGrp"
        Me.cboGrp.Size = New System.Drawing.Size(206, 21)
        Me.cboGrp.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Sub-Grp:"
        '
        'txtPh
        '
        Me.txtPh.Location = New System.Drawing.Point(389, 68)
        Me.txtPh.Name = "txtPh"
        Me.txtPh.Size = New System.Drawing.Size(108, 20)
        Me.txtPh.TabIndex = 6
        Me.txtPh.Text = " "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(319, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Phone No.:"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(389, 120)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(108, 20)
        Me.txtVAT.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(319, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "VAT No.:"
        '
        'txtRC
        '
        Me.txtRC.Location = New System.Drawing.Point(76, 122)
        Me.txtRC.Name = "txtRC"
        Me.txtRC.Size = New System.Drawing.Size(97, 20)
        Me.txtRC.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "R.C.No.:"
        '
        'txtPAN
        '
        Me.txtPAN.Location = New System.Drawing.Point(389, 94)
        Me.txtPAN.Name = "txtPAN"
        Me.txtPAN.Size = New System.Drawing.Size(108, 20)
        Me.txtPAN.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(319, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "PAN:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Address:"
        '
        'txtAddr
        '
        Me.txtAddr.Location = New System.Drawing.Point(76, 67)
        Me.txtAddr.Multiline = True
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(206, 47)
        Me.txtAddr.TabIndex = 5
        '
        'txtOpb
        '
        Me.txtOpb.Location = New System.Drawing.Point(389, 39)
        Me.txtOpb.Name = "txtOpb"
        Me.txtOpb.Size = New System.Drawing.Size(118, 20)
        Me.txtOpb.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Opening Bal:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(76, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(206, 20)
        Me.txtName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Code:"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(389, 13)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(43, 20)
        Me.txtCode.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(469, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(396, 192)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvSubs
        '
        Me.dgvSubs.AllowUserToAddRows = False
        Me.dgvSubs.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvSubs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSubs.BackgroundColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSubs.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSubs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSubs.GridColor = System.Drawing.Color.Brown
        Me.dgvSubs.Location = New System.Drawing.Point(16, 218)
        Me.dgvSubs.MultiSelect = False
        Me.dgvSubs.Name = "dgvSubs"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSubs.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSubs.RowHeadersWidth = 18
        Me.dgvSubs.RowTemplate.Height = 18
        Me.dgvSubs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubs.Size = New System.Drawing.Size(295, 199)
        Me.dgvSubs.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Loading..."
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDel.Enabled = False
        Me.btnDel.Location = New System.Drawing.Point(134, 425)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(60, 23)
        Me.btnDel.TabIndex = 4
        Me.btnDel.Text = "&Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEdit.Location = New System.Drawing.Point(77, 425)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.PeachPuff
        Me.btnNew.Location = New System.Drawing.Point(16, 425)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 23)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(224, 427)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(85, 20)
        Me.txtFind.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(194, 430)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Find:"
        '
        'btnSRef
        '
        Me.btnSRef.BackColor = System.Drawing.Color.PeachPuff
        Me.btnSRef.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.btnSRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSRef.Location = New System.Drawing.Point(287, 192)
        Me.btnSRef.Name = "btnSRef"
        Me.btnSRef.Size = New System.Drawing.Size(22, 23)
        Me.btnSRef.TabIndex = 7
        Me.btnSRef.UseVisualStyleBackColor = False
        '
        'dgvGLs
        '
        Me.dgvGLs.AllowUserToAddRows = False
        Me.dgvGLs.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvGLs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvGLs.BackgroundColor = System.Drawing.Color.Snow
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGLs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvGLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGLs.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvGLs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvGLs.GridColor = System.Drawing.Color.Brown
        Me.dgvGLs.Location = New System.Drawing.Point(313, 218)
        Me.dgvGLs.MultiSelect = False
        Me.dgvGLs.Name = "dgvGLs"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGLs.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvGLs.RowHeadersWidth = 18
        Me.dgvGLs.RowTemplate.Height = 18
        Me.dgvGLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLs.Size = New System.Drawing.Size(216, 199)
        Me.dgvGLs.TabIndex = 31
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(335, 17)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(29, 13)
        Me.lblErr.TabIndex = 45
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmSubMast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(541, 456)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.dgvGLs)
        Me.Controls.Add(Me.btnSRef)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvSubs)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSubMast"
        Me.Text = "Sub-Head"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSubs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvSubs As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtOpb As System.Windows.Forms.TextBox
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRC As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPAN As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPh As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnSRef As System.Windows.Forms.Button
    Friend WithEvents cboGrp As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvGLs As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblErr As System.Windows.Forms.Label
End Class
