<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCsgr
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDref = New System.Windows.Forms.Button
        Me.cboLocs = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.dgvCsgrs = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnRef = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCsgrs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consignor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDref)
        Me.GroupBox1.Controls.Add(Me.cboLocs)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnDref
        '
        Me.btnDref.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDref.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.btnDref.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDref.Location = New System.Drawing.Point(304, 44)
        Me.btnDref.Name = "btnDref"
        Me.btnDref.Size = New System.Drawing.Size(22, 23)
        Me.btnDref.TabIndex = 27
        Me.btnDref.UseVisualStyleBackColor = False
        '
        'cboLocs
        '
        Me.cboLocs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocs.FormattingEnabled = True
        Me.cboLocs.Items.AddRange(New Object() {"Destination", "Loading Point"})
        Me.cboLocs.Location = New System.Drawing.Point(59, 46)
        Me.cboLocs.Name = "cboLocs"
        Me.cboLocs.Size = New System.Drawing.Size(243, 21)
        Me.cboLocs.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Load.Pt."
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(184, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(142, 20)
        Me.txtName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Code:"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(59, 13)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(67, 20)
        Me.txtCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(291, 122)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(215, 122)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 22)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dgvCsgrs
        '
        Me.dgvCsgrs.AllowUserToAddRows = False
        Me.dgvCsgrs.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Sienna
        Me.dgvCsgrs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCsgrs.BackgroundColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCsgrs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCsgrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Sienna
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCsgrs.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCsgrs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCsgrs.GridColor = System.Drawing.Color.Brown
        Me.dgvCsgrs.Location = New System.Drawing.Point(16, 153)
        Me.dgvCsgrs.Name = "dgvCsgrs"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCsgrs.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCsgrs.RowHeadersWidth = 18
        Me.dgvCsgrs.RowTemplate.Height = 18
        Me.dgvCsgrs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCsgrs.Size = New System.Drawing.Size(334, 201)
        Me.dgvCsgrs.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Loading..."
        '
        'btnRef
        '
        Me.btnRef.BackColor = System.Drawing.Color.PeachPuff
        Me.btnRef.BackgroundImage = Global.WinAc.My.Resources.Resources.refr2
        Me.btnRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRef.Location = New System.Drawing.Point(329, 356)
        Me.btnRef.Name = "btnRef"
        Me.btnRef.Size = New System.Drawing.Size(22, 23)
        Me.btnRef.TabIndex = 25
        Me.btnRef.UseVisualStyleBackColor = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.PeachPuff
        Me.btnDel.Location = New System.Drawing.Point(135, 356)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(60, 23)
        Me.btnDel.TabIndex = 24
        Me.btnDel.Text = "&Delete"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.PeachPuff
        Me.btnEdit.Location = New System.Drawing.Point(78, 356)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnEdit.TabIndex = 23
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.PeachPuff
        Me.btnNew.Location = New System.Drawing.Point(17, 356)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 23)
        Me.btnNew.TabIndex = 22
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(186, 17)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(29, 13)
        Me.lblErr.TabIndex = 47
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCsgr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(363, 391)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.btnRef)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvCsgrs)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCsgr"
        Me.Text = "Consignor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCsgrs, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboLocs As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvCsgrs As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRef As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDref As System.Windows.Forms.Button
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblErr As System.Windows.Forms.Label
End Class
