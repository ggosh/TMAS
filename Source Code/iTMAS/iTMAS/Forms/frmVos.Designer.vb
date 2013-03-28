<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvVos = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnFilt = New System.Windows.Forms.Button
        Me.dtpVoDt = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFindVoNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCBV = New System.Windows.Forms.Button
        Me.btnJV = New System.Windows.Forms.Button
        CType(Me.dgvVos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vouchers List"
        '
        'dgvVos
        '
        Me.dgvVos.AllowUserToAddRows = False
        Me.dgvVos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvVos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVos.BackgroundColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvVos.Location = New System.Drawing.Point(13, 46)
        Me.dgvVos.Name = "dgvVos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVos.RowTemplate.Height = 18
        Me.dgvVos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVos.Size = New System.Drawing.Size(773, 363)
        Me.dgvVos.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PeachPuff
        Me.Button2.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(761, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 27)
        Me.Button2.TabIndex = 28
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEdit.Location = New System.Drawing.Point(90, 417)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(64, 27)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.PeachPuff
        Me.btnNew.Location = New System.Drawing.Point(13, 417)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(70, 27)
        Me.btnNew.TabIndex = 26
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Loading..."
        Me.Label8.Visible = False
        '
        'btnFilt
        '
        Me.btnFilt.Location = New System.Drawing.Point(729, 416)
        Me.btnFilt.Name = "btnFilt"
        Me.btnFilt.Size = New System.Drawing.Size(59, 28)
        Me.btnFilt.TabIndex = 43
        Me.btnFilt.Text = "&Filter"
        Me.btnFilt.UseVisualStyleBackColor = True
        '
        'dtpVoDt
        '
        Me.dtpVoDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVoDt.Location = New System.Drawing.Point(616, 420)
        Me.dtpVoDt.Name = "dtpVoDt"
        Me.dtpVoDt.Size = New System.Drawing.Size(107, 21)
        Me.dtpVoDt.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(541, 423)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Filter Date:"
        '
        'txtFindVoNo
        '
        Me.txtFindVoNo.Location = New System.Drawing.Point(429, 420)
        Me.txtFindVoNo.Name = "txtFindVoNo"
        Me.txtFindVoNo.Size = New System.Drawing.Size(104, 21)
        Me.txtFindVoNo.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(330, 423)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 15)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Find Voucher No.:"
        '
        'btnCBV
        '
        Me.btnCBV.BackColor = System.Drawing.Color.PeachPuff
        Me.btnCBV.Image = Global.WinAc.My.Resources.Resources.blank1
        Me.btnCBV.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCBV.Location = New System.Drawing.Point(591, 15)
        Me.btnCBV.Name = "btnCBV"
        Me.btnCBV.Size = New System.Drawing.Size(83, 27)
        Me.btnCBV.TabIndex = 44
        Me.btnCBV.Text = "Cash/Bank"
        Me.btnCBV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCBV.UseVisualStyleBackColor = False
        '
        'btnJV
        '
        Me.btnJV.BackColor = System.Drawing.Color.PeachPuff
        Me.btnJV.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnJV.Location = New System.Drawing.Point(674, 15)
        Me.btnJV.Name = "btnJV"
        Me.btnJV.Size = New System.Drawing.Size(83, 27)
        Me.btnJV.TabIndex = 45
        Me.btnJV.Text = "Journal"
        Me.btnJV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJV.UseVisualStyleBackColor = False
        '
        'frmVos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(800, 448)
        Me.Controls.Add(Me.btnJV)
        Me.Controls.Add(Me.btnCBV)
        Me.Controls.Add(Me.btnFilt)
        Me.Controls.Add(Me.dtpVoDt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFindVoNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvVos)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmVos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Vouchers"
        CType(Me.dgvVos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvVos As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnFilt As System.Windows.Forms.Button
    Friend WithEvents dtpVoDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFindVoNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCBV As System.Windows.Forms.Button
    Friend WithEvents btnJV As System.Windows.Forms.Button
End Class
