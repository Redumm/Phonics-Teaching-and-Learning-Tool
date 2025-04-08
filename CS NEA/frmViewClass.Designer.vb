<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewClass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewClass))
        Me.lblViewClass = New System.Windows.Forms.Label()
        Me.grdStudentAchievementProperties = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Surname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhonicLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RateOfProgress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriorityGroups = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Target = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdStudentAchievementProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblViewClass
        '
        Me.lblViewClass.AutoSize = True
        Me.lblViewClass.BackColor = System.Drawing.Color.Transparent
        Me.lblViewClass.Font = New System.Drawing.Font("Century Gothic", 40.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewClass.Location = New System.Drawing.Point(40, 16)
        Me.lblViewClass.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblViewClass.Name = "lblViewClass"
        Me.lblViewClass.Size = New System.Drawing.Size(612, 126)
        Me.lblViewClass.TabIndex = 2
        Me.lblViewClass.Text = "View Class"
        '
        'grdStudentAchievementProperties
        '
        Me.grdStudentAchievementProperties.AllowUserToDeleteRows = False
        Me.grdStudentAchievementProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdStudentAchievementProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStudentAchievementProperties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Surname, Me.FirstName, Me.PhonicLevel, Me.RateOfProgress, Me.PriorityGroups, Me.Target})
        Me.grdStudentAchievementProperties.Location = New System.Drawing.Point(68, 155)
        Me.grdStudentAchievementProperties.Margin = New System.Windows.Forms.Padding(6)
        Me.grdStudentAchievementProperties.Name = "grdStudentAchievementProperties"
        Me.grdStudentAchievementProperties.ReadOnly = True
        Me.grdStudentAchievementProperties.RowHeadersWidth = 82
        Me.grdStudentAchievementProperties.Size = New System.Drawing.Size(1200, 380)
        Me.grdStudentAchievementProperties.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "StudentID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 10
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'Surname
        '
        Me.Surname.HeaderText = "Surname"
        Me.Surname.MinimumWidth = 10
        Me.Surname.Name = "Surname"
        Me.Surname.ReadOnly = True
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "First Name"
        Me.FirstName.MinimumWidth = 10
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        '
        'PhonicLevel
        '
        Me.PhonicLevel.HeaderText = "Phonic Level"
        Me.PhonicLevel.MinimumWidth = 10
        Me.PhonicLevel.Name = "PhonicLevel"
        Me.PhonicLevel.ReadOnly = True
        '
        'RateOfProgress
        '
        Me.RateOfProgress.HeaderText = "Rate Of Progress"
        Me.RateOfProgress.MinimumWidth = 10
        Me.RateOfProgress.Name = "RateOfProgress"
        Me.RateOfProgress.ReadOnly = True
        '
        'PriorityGroups
        '
        Me.PriorityGroups.HeaderText = "Priority Groups"
        Me.PriorityGroups.MinimumWidth = 10
        Me.PriorityGroups.Name = "PriorityGroups"
        Me.PriorityGroups.ReadOnly = True
        '
        'Target
        '
        Me.Target.HeaderText = "Target"
        Me.Target.MinimumWidth = 10
        Me.Target.Name = "Target"
        Me.Target.ReadOnly = True
        '
        'frmViewClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1824, 987)
        Me.Controls.Add(Me.grdStudentAchievementProperties)
        Me.Controls.Add(Me.lblViewClass)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewClass"
        Me.Text = "View Class"
        CType(Me.grdStudentAchievementProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblViewClass As Label
    Friend WithEvents grdStudentAchievementProperties As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Surname As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents PhonicLevel As DataGridViewTextBoxColumn
    Friend WithEvents RateOfProgress As DataGridViewTextBoxColumn
    Friend WithEvents PriorityGroups As DataGridViewTextBoxColumn
    Friend WithEvents Target As DataGridViewTextBoxColumn
End Class
