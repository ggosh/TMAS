<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTLLdg
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
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgvTLs = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFindOnlyNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbEdit = New System.Windows.Forms.GroupBox
        Me.txtTLCode = New System.Windows.Forms.TextBox
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboOwners = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.gbTLs.SuspendLayout()
        CType(Me.dgvTLs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEdit.SuspendLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTLs
        '
        Me.gbTLs.Controls.Add(Me.Label8)
        Me.gbTLs.Controls.Add(Me.dgvTLs)
        Me.gbTLs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTLs.Location = New System.Drawing.Point(17, 182)
        Me.gbTLs.Name = "gbTLs"
        Me.gbTLs.Size = New System.Drawing.Size(522, 323)
        Me.gbTLs.TabIndex = 3
        Me.gbTLs.TabStop = False
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
        Me.dgvTLs.Size = New System.Drawing.Size(508, 301)
        Me.dgvTLs.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(243, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Find Only Number:"
        '
        'txtFindOnlyNo
        '
        Me.txtFindOnlyNo.Location = New System.Drawing.Point(358, 16)
        Me.txtFindOnlyNo.Name = "txtFindOnlyNo"
        Me.txtFindOnlyNo.Size = New System.Drawing.Size(89, 21)
        Me.txtFindOnlyNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vehicle Ledger (T/L)"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(393, 161)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Show"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(469, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 22)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.txtTLCode)
        Me.gbEdit.Controls.Add(Me.txtFindOnlyNo)
        Me.gbEdit.Controls.Add(Me.Label7)
        Me.gbEdit.Controls.Add(Me.dtpEnd)
        Me.gbEdit.Controls.Add(Me.Label10)
        Me.gbEdit.Controls.Add(Me.dtpStart)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.cboOwners)
        Me.gbEdit.Controls.Add(Me.Label3)
        Me.gbEdit.Controls.Add(Me.Label2)
        Me.gbEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEdit.Location = New System.Drawing.Point(16, 31)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(523, 123)
        Me.gbEdit.TabIndex = 0
        Me.gbEdit.TabStop = False
        '
        'txtTLCode
        '
        Me.txtTLCode.Location = New System.Drawing.Point(139, 16)
        Me.txtTLCode.Name = "txtTLCode"
        Me.txtTLCode.Size = New System.Drawing.Size(37, 21)
        Me.txtTLCode.TabIndex = 0
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(348, 84)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(106, 21)
        Me.dtpEnd.TabIndex = 4
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
        Me.dtpStart.Location = New System.Drawing.Point(139, 84)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(102, 21)
        Me.dtpStart.TabIndex = 3
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
        'cboOwners
        '
        Me.cboOwners.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboOwners.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOwners.FormattingEnabled = True
        Me.cboOwners.Location = New System.Drawing.Point(239, 50)
        Me.cboOwners.Name = "cboOwners"
        Me.cboOwners.Size = New System.Drawing.Size(132, 23)
        Me.cboOwners.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "T/L Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "T/L Number:"
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
        'frmTLLdg
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
        Me.Name = "frmTLLdg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vehicle Ledger (T/L)"
        Me.gbTLs.ResumeLayout(False)
        Me.gbTLs.PerformLayout()
        CType(Me.dgvTLs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbTLs As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTLs As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboOwners As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFindOnlyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblErr As System.Windows.Forms.Label
    Friend WithEvents txtTLCode As System.Windows.Forms.TextBox
End Class
