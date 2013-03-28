<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBill2i
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
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRnd = New System.Windows.Forms.TextBox
        Me.cboST = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboRep = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPCode = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.dtpBlDt = New System.Windows.Forms.DateTimePicker
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtLessFrt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNTax = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTaxbl = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSTax = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPost = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboPtys = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtStPc = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.ErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblErr = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.NavajoWhite
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(717, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Loading..."
        Me.Label8.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(361, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(196, 39)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Billing Info"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtRnd)
        Me.GroupBox2.Controls.Add(Me.cboST)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboRep)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtPCode)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txtLessFrt)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtNTax)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtTaxbl)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtSTax)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtPost)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboPtys)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(14, 47)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(881, 209)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(612, 169)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 15)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Round Off:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(612, 139)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Add Postage:"
        '
        'txtRnd
        '
        Me.txtRnd.Location = New System.Drawing.Point(732, 165)
        Me.txtRnd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRnd.Name = "txtRnd"
        Me.txtRnd.Size = New System.Drawing.Size(144, 21)
        Me.txtRnd.TabIndex = 9
        Me.txtRnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboST
        '
        Me.cboST.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboST.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboST.FormattingEnabled = True
        Me.cboST.Location = New System.Drawing.Point(613, 103)
        Me.cboST.Margin = New System.Windows.Forms.Padding(4)
        Me.cboST.Name = "cboST"
        Me.cboST.Size = New System.Drawing.Size(116, 23)
        Me.cboST.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 175)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Rep:"
        '
        'cboRep
        '
        Me.cboRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRep.FormattingEnabled = True
        Me.cboRep.Location = New System.Drawing.Point(307, 172)
        Me.cboRep.Margin = New System.Windows.Forms.Padding(4)
        Me.cboRep.Name = "cboRep"
        Me.cboRep.Size = New System.Drawing.Size(294, 23)
        Me.cboRep.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(307, 144)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(293, 24)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Zone"
        '
        'txtPCode
        '
        Me.txtPCode.Location = New System.Drawing.Point(307, 16)
        Me.txtPCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPCode.Name = "txtPCode"
        Me.txtPCode.Size = New System.Drawing.Size(50, 21)
        Me.txtPCode.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAmount)
        Me.GroupBox3.Controls.Add(Me.dtpBlDt)
        Me.GroupBox3.Controls.Add(Me.txtBillNo)
        Me.GroupBox3.Controls.Add(Me.cboType)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(246, 187)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(85, 143)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(144, 22)
        Me.txtAmount.TabIndex = 20
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpBlDt
        '
        Me.dtpBlDt.CustomFormat = "dd/MM/yy"
        Me.dtpBlDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBlDt.Location = New System.Drawing.Point(85, 64)
        Me.dtpBlDt.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpBlDt.Name = "dtpBlDt"
        Me.dtpBlDt.Size = New System.Drawing.Size(144, 21)
        Me.dtpBlDt.TabIndex = 1
        Me.dtpBlDt.Value = New Date(2010, 7, 1, 12, 55, 0, 0)
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(85, 101)
        Me.txtBillNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(144, 21)
        Me.txtBillNo.TabIndex = 2
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(85, 24)
        Me.cboType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(144, 23)
        Me.cboType.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(15, 145)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Amount:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 67)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Date:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 105)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Number:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 26)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 15)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Type:"
        '
        'txtLessFrt
        '
        Me.txtLessFrt.Location = New System.Drawing.Point(732, 73)
        Me.txtLessFrt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLessFrt.Name = "txtLessFrt"
        Me.txtLessFrt.Size = New System.Drawing.Size(144, 21)
        Me.txtLessFrt.TabIndex = 5
        Me.txtLessFrt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Party:"
        '
        'txtNTax
        '
        Me.txtNTax.Location = New System.Drawing.Point(732, 16)
        Me.txtNTax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNTax.Name = "txtNTax"
        Me.txtNTax.Size = New System.Drawing.Size(144, 21)
        Me.txtNTax.TabIndex = 3
        Me.txtNTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(612, 20)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 15)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Non-Taxable Amt:"
        '
        'txtTaxbl
        '
        Me.txtTaxbl.Location = New System.Drawing.Point(732, 44)
        Me.txtTaxbl.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTaxbl.Name = "txtTaxbl"
        Me.txtTaxbl.Size = New System.Drawing.Size(144, 21)
        Me.txtTaxbl.TabIndex = 4
        Me.txtTaxbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(612, 47)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 15)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Taxable Amt:"
        '
        'txtSTax
        '
        Me.txtSTax.Location = New System.Drawing.Point(732, 104)
        Me.txtSTax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSTax.Name = "txtSTax"
        Me.txtSTax.Size = New System.Drawing.Size(144, 21)
        Me.txtSTax.TabIndex = 7
        Me.txtSTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(612, 107)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Tax:"
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(732, 135)
        Me.txtPost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPost.Name = "txtPost"
        Me.txtPost.Size = New System.Drawing.Size(144, 21)
        Me.txtPost.TabIndex = 8
        Me.txtPost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(612, 76)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Less Freight:"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(267, 71)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(334, 71)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Address"
        '
        'cboPtys
        '
        Me.cboPtys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPtys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPtys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPtys.FormattingEnabled = True
        Me.cboPtys.Location = New System.Drawing.Point(267, 41)
        Me.cboPtys.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPtys.Name = "cboPtys"
        Me.cboPtys.Size = New System.Drawing.Size(333, 23)
        Me.cboPtys.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(263, 149)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 15)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Zone:"
        '
        'txtStPc
        '
        Me.txtStPc.Location = New System.Drawing.Point(839, 16)
        Me.txtStPc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStPc.Name = "txtStPc"
        Me.txtStPc.Size = New System.Drawing.Size(50, 21)
        Me.txtStPc.TabIndex = 22
        Me.txtStPc.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCancel.Location = New System.Drawing.Point(825, 267)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightGreen
        Me.btnSave.Location = New System.Drawing.Point(736, 267)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 25)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'ErrorPro
        '
        Me.ErrorPro.ContainerControl = Me
        '
        'lblErr
        '
        Me.lblErr.AutoSize = True
        Me.lblErr.BackColor = System.Drawing.Color.Orange
        Me.lblErr.Location = New System.Drawing.Point(644, 26)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(34, 15)
        Me.lblErr.TabIndex = 47
        Me.lblErr.Text = "Error"
        Me.lblErr.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmBill2i
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(900, 304)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtStPc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label8)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBill2i"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bill"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPtys As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtTaxbl As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSTax As System.Windows.Forms.TextBox
    Friend WithEvents txtPost As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNTax As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtStPc As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLessFrt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents dtpBlDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboRep As System.Windows.Forms.ComboBox
    Friend WithEvents cboST As System.Windows.Forms.ComboBox
    Friend WithEvents txtRnd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblErr As System.Windows.Forms.Label
End Class
