<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTLmast
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
        Me.gbTLs = New System.Windows.Forms.GroupBox
        Me.btnRef = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnDupli = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.dgvTLs = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtFindNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFindOnlyNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbEdit = New System.Windows.Forms.GroupBox
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.cboOwners = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkOwn = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTL_NO = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.gbTLs.SuspendLayout()
        CType(Me.dgvTLs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbTLs.Controls.Add(Me.btnDupli)
        Me.gbTLs.Controls.Add(Me.btnEdit)
        Me.gbTLs.Controls.Add(Me.btnNew)
        Me.gbTLs.Controls.Add(Me.dgvTLs)
        Me.gbTLs.Controls.Add(Me.GroupBox2)
        Me.gbTLs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTLs.Location = New System.Drawing.Point(17, 182)
        Me.gbTLs.Name = "gbTLs"
        Me.gbTLs.Size = New System.Drawing.Size(522, 323)
        Me.gbTLs.TabIndex = 0
        Me.gbTLs.TabStop = False
        '
        'btnRef
        '
        Me.btnRef.BackColor = System.Drawing.Color.PeachPuff
        Me.btnRef.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.btnRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRef.Location = New System.Drawing.Point(494, 271)
        Me.btnRef.Name = "btnRef"
        Me.btnRef.Size = New System.Drawing.Size(22, 23)
        Me.btnRef.TabIndex = 5
        Me.btnRef.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDel.Location = New System.Drawing.Point(434, 269)
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
        'btnDupli
        '
        Me.btnDupli.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDupli.Location = New System.Drawing.Point(348, 269)
        Me.btnDupli.Name = "btnDupli"
        Me.btnDupli.Size = New System.Drawing.Size(80, 26)
        Me.btnDupli.TabIndex = 3
        Me.btnDupli.Text = "New &Owner"
        Me.btnDupli.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEdit.Location = New System.Drawing.Point(292, 269)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 26)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.PeachPuff
        Me.btnNew.Location = New System.Drawing.Point(235, 269)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(51, 26)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'dgvTLs
        '
        Me.dgvTLs.AllowUserToAddRows = False
        Me.dgvTLs.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvTLs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTLs.BackgroundColor = System.Drawing.Color.Snow
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTLs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTLs.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvTLs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTLs.GridColor = System.Drawing.Color.Brown
        Me.dgvTLs.Location = New System.Drawing.Point(8, 16)
        Me.dgvTLs.Name = "dgvTLs"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTLs.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTLs.RowHeadersWidth = 18
        Me.dgvTLs.RowTemplate.Height = 30
        Me.dgvTLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTLs.Size = New System.Drawing.Size(508, 247)
        Me.dgvTLs.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFindNo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFindOnlyNo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(210, 60)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'txtFindNo
        '
        Me.txtFindNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFindNo.Location = New System.Drawing.Point(112, 11)
        Me.txtFindNo.Name = "txtFindNo"
        Me.txtFindNo.Size = New System.Drawing.Size(89, 21)
        Me.txtFindNo.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Find Only Number:"
        '
        'txtFindOnlyNo
        '
        Me.txtFindOnlyNo.Location = New System.Drawing.Point(112, 34)
        Me.txtFindOnlyNo.Name = "txtFindOnlyNo"
        Me.txtFindOnlyNo.Size = New System.Drawing.Size(89, 21)
        Me.txtFindOnlyNo.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "T/L No.starting with:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "T/L Master"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(393, 157)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(469, 157)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 22)
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.txtEnd)
        Me.gbEdit.Controls.Add(Me.dtpEnd)
        Me.gbEdit.Controls.Add(Me.Label10)
        Me.gbEdit.Controls.Add(Me.dtpStart)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.lblCode)
        Me.gbEdit.Controls.Add(Me.cboOwners)
        Me.gbEdit.Controls.Add(Me.Label5)
        Me.gbEdit.Controls.Add(Me.chkOwn)
        Me.gbEdit.Controls.Add(Me.Label4)
        Me.gbEdit.Controls.Add(Me.Label3)
        Me.gbEdit.Controls.Add(Me.txtTL_NO)
        Me.gbEdit.Controls.Add(Me.Label2)
        Me.gbEdit.Controls.Add(Me.txtStart)
        Me.gbEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEdit.Location = New System.Drawing.Point(16, 31)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(523, 123)
        Me.gbEdit.TabIndex = 21
        Me.gbEdit.TabStop = False
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(348, 84)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(86, 21)
        Me.txtEnd.TabIndex = 29
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(348, 84)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(106, 21)
        Me.dtpEnd.TabIndex = 35
        Me.dtpEnd.Value = New Date(2099, 12, 31, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(284, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "End Date:"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(121, 83)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(108, 21)
        Me.dtpStart.TabIndex = 27
        Me.dtpStart.Value = New Date(2010, 2, 2, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(58, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Start Date:"
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(121, 17)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(38, 18)
        Me.lblCode.TabIndex = 27
        Me.lblCode.Text = "0000"
        '
        'cboOwners
        '
        Me.cboOwners.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboOwners.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOwners.FormattingEnabled = True
        Me.cboOwners.Location = New System.Drawing.Point(121, 49)
        Me.cboOwners.Name = "cboOwners"
        Me.cboOwners.Size = New System.Drawing.Size(331, 23)
        Me.cboOwners.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Owner:"
        '
        'chkOwn
        '
        Me.chkOwn.AutoSize = True
        Me.chkOwn.Location = New System.Drawing.Point(438, 20)
        Me.chkOwn.Name = "chkOwn"
        Me.chkOwn.Size = New System.Drawing.Size(15, 14)
        Me.chkOwn.TabIndex = 24
        Me.chkOwn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(399, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Own:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Code:"
        '
        'txtTL_NO
        '
        Me.txtTL_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTL_NO.Location = New System.Drawing.Point(255, 17)
        Me.txtTL_NO.Name = "txtTL_NO"
        Me.txtTL_NO.Size = New System.Drawing.Size(132, 21)
        Me.txtTL_NO.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "T/L Number:"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(123, 84)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(87, 21)
        Me.txtStart.TabIndex = 34
        Me.txtStart.Visible = False
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(306, 11)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(29, 13)
        Me.lblErr.TabIndex = 47
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmTLmast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(555, 517)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbTLs)
        Me.Name = "frmTLmast"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "T/Lorry"
        Me.gbTLs.ResumeLayout(False)
        Me.gbTLs.PerformLayout()
        CType(Me.dgvTLs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbTLs As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTLs As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDupli As System.Windows.Forms.Button
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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents cboOwners As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkOwn As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTL_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFindNo As System.Windows.Forms.TextBox
    Friend WithEvents txtFindOnlyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblErr As System.Windows.Forms.Label
End Class
