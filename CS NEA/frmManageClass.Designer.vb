<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageClass
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageClass))
        Me.grdStudentProperties = New System.Windows.Forms.DataGridView()
        Me.StudentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PupilPremium = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Target = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblManageClass = New System.Windows.Forms.Label()
        Me.picSave = New System.Windows.Forms.PictureBox()
        Me.picReset = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.picPrint = New System.Windows.Forms.PictureBox()
        CType(Me.grdStudentProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picReset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdStudentProperties
        '
        Me.grdStudentProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStudentProperties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StudentID, Me.Surname, Me.FirstName, Me.PupilPremium, Me.LAC, Me.SEND, Me.EAL, Me.SALT, Me.Target})
        Me.grdStudentProperties.Location = New System.Drawing.Point(68, 250)
        Me.grdStudentProperties.Margin = New System.Windows.Forms.Padding(6)
        Me.grdStudentProperties.Name = "grdStudentProperties"
        Me.grdStudentProperties.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.grdStudentProperties.Size = New System.Drawing.Size(1688, 538)
        Me.grdStudentProperties.TabIndex = 0
        '
        'StudentID
        '
        Me.StudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.StudentID.HeaderText = "StudentID"
        Me.StudentID.MinimumWidth = 10
        Me.StudentID.Name = "StudentID"
        Me.StudentID.Visible = False
        Me.StudentID.Width = 200
        '
        'Surname
        '
        Me.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Surname.HeaderText = "Surname"
        Me.Surname.MinimumWidth = 10
        Me.Surname.Name = "Surname"
        '
        'FirstName
        '
        Me.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FirstName.HeaderText = "First Name"
        Me.FirstName.MinimumWidth = 10
        Me.FirstName.Name = "FirstName"
        '
        'PupilPremium
        '
        Me.PupilPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PupilPremium.HeaderText = "Pupil Premium"
        Me.PupilPremium.MinimumWidth = 10
        Me.PupilPremium.Name = "PupilPremium"
        '
        'LAC
        '
        Me.LAC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LAC.HeaderText = "LAC"
        Me.LAC.MinimumWidth = 10
        Me.LAC.Name = "LAC"
        '
        'SEND
        '
        Me.SEND.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SEND.HeaderText = "SEND"
        Me.SEND.MinimumWidth = 10
        Me.SEND.Name = "SEND"
        '
        'EAL
        '
        Me.EAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EAL.HeaderText = "EAL"
        Me.EAL.MinimumWidth = 10
        Me.EAL.Name = "EAL"
        '
        'SALT
        '
        Me.SALT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SALT.HeaderText = "SALT"
        Me.SALT.MinimumWidth = 10
        Me.SALT.Name = "SALT"
        '
        'Target
        '
        Me.Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Target.HeaderText = "Target"
        Me.Target.MinimumWidth = 10
        Me.Target.Name = "Target"
        '
        'lblManageClass
        '
        Me.lblManageClass.AutoSize = True
        Me.lblManageClass.BackColor = System.Drawing.Color.Transparent
        Me.lblManageClass.Font = New System.Drawing.Font("Century Gothic", 40.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManageClass.Location = New System.Drawing.Point(40, 58)
        Me.lblManageClass.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblManageClass.Name = "lblManageClass"
        Me.lblManageClass.Size = New System.Drawing.Size(798, 126)
        Me.lblManageClass.TabIndex = 1
        Me.lblManageClass.Text = "Manage Class"
        '
        'picSave
        '
        Me.picSave.BackColor = System.Drawing.Color.Transparent
        Me.picSave.Image = CType(resources.GetObject("picSave.Image"), System.Drawing.Image)
        Me.picSave.Location = New System.Drawing.Point(68, 873)
        Me.picSave.Margin = New System.Windows.Forms.Padding(6)
        Me.picSave.Name = "picSave"
        Me.picSave.Size = New System.Drawing.Size(94, 90)
        Me.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSave.TabIndex = 6
        Me.picSave.TabStop = False
        '
        'picReset
        '
        Me.picReset.BackColor = System.Drawing.Color.Transparent
        Me.picReset.Image = CType(resources.GetObject("picReset.Image"), System.Drawing.Image)
        Me.picReset.Location = New System.Drawing.Point(214, 873)
        Me.picReset.Margin = New System.Windows.Forms.Padding(6)
        Me.picReset.Name = "picReset"
        Me.picReset.Size = New System.Drawing.Size(94, 90)
        Me.picReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picReset.TabIndex = 7
        Me.picReset.TabStop = False
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'picPrint
        '
        Me.picPrint.BackColor = System.Drawing.Color.Transparent
        Me.picPrint.Image = CType(resources.GetObject("picPrint.Image"), System.Drawing.Image)
        Me.picPrint.Location = New System.Drawing.Point(360, 873)
        Me.picPrint.Margin = New System.Windows.Forms.Padding(6)
        Me.picPrint.Name = "picPrint"
        Me.picPrint.Size = New System.Drawing.Size(94, 90)
        Me.picPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPrint.TabIndex = 8
        Me.picPrint.TabStop = False
        '
        'frmManageClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1824, 987)
        Me.Controls.Add(Me.picPrint)
        Me.Controls.Add(Me.picReset)
        Me.Controls.Add(Me.picSave)
        Me.Controls.Add(Me.lblManageClass)
        Me.Controls.Add(Me.grdStudentProperties)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmManageClass"
        Me.Text = "Manage Class"
        CType(Me.grdStudentProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picReset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdStudentProperties As DataGridView
    Friend WithEvents lblManageClass As Label
    Friend WithEvents picSave As PictureBox
    Friend WithEvents picReset As PictureBox
    Friend WithEvents StudentID As DataGridViewTextBoxColumn
    Friend WithEvents Surname As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents PupilPremium As DataGridViewTextBoxColumn
    Friend WithEvents LAC As DataGridViewTextBoxColumn
    Friend WithEvents SEND As DataGridViewTextBoxColumn
    Friend WithEvents EAL As DataGridViewTextBoxColumn
    Friend WithEvents SALT As DataGridViewTextBoxColumn
    Friend WithEvents Target As DataGridViewTextBoxColumn
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents picPrint As PictureBox
End Class
