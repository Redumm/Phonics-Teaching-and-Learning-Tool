<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
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
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.graClassLevels = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblWelcomeMessage = New System.Windows.Forms.Label()
        Me.btnViewClass = New System.Windows.Forms.Button()
        Me.btnAssessments = New System.Windows.Forms.Button()
        Me.btnManageClass = New System.Windows.Forms.Button()
        Me.picSettings = New System.Windows.Forms.PictureBox()
        Me.picNotifications = New System.Windows.Forms.PictureBox()
        CType(Me.graClassLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNotifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'graClassLevels
        '
        ChartArea7.Name = "ChartArea1"
        Me.graClassLevels.ChartAreas.Add(ChartArea7)
        Me.graClassLevels.Enabled = False
        Legend7.Name = "ClassLevelsLegend"
        Me.graClassLevels.Legends.Add(Legend7)
        Me.graClassLevels.Location = New System.Drawing.Point(942, 58)
        Me.graClassLevels.Margin = New System.Windows.Forms.Padding(6)
        Me.graClassLevels.Name = "graClassLevels"
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series7.Legend = "ClassLevelsLegend"
        Series7.Name = "ClassLevels"
        Me.graClassLevels.Series.Add(Series7)
        Me.graClassLevels.Size = New System.Drawing.Size(822, 519)
        Me.graClassLevels.TabIndex = 0
        Me.graClassLevels.Text = "graClassLevels"
        '
        'lblWelcomeMessage
        '
        Me.lblWelcomeMessage.AutoSize = True
        Me.lblWelcomeMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcomeMessage.Font = New System.Drawing.Font("Century Gothic", 40.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeMessage.Location = New System.Drawing.Point(40, 58)
        Me.lblWelcomeMessage.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblWelcomeMessage.Name = "lblWelcomeMessage"
        Me.lblWelcomeMessage.Size = New System.Drawing.Size(871, 126)
        Me.lblWelcomeMessage.TabIndex = 1
        Me.lblWelcomeMessage.Text = "Welcome Back!"
        '
        'btnViewClass
        '
        Me.btnViewClass.BackColor = System.Drawing.SystemColors.Control
        Me.btnViewClass.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnViewClass.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewClass.Location = New System.Drawing.Point(60, 250)
        Me.btnViewClass.Margin = New System.Windows.Forms.Padding(6)
        Me.btnViewClass.Name = "btnViewClass"
        Me.btnViewClass.Size = New System.Drawing.Size(822, 250)
        Me.btnViewClass.TabIndex = 2
        Me.btnViewClass.Text = "View Class"
        Me.btnViewClass.UseVisualStyleBackColor = True
        '
        'btnAssessments
        '
        Me.btnAssessments.Font = New System.Drawing.Font("Myanmar Text", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssessments.Location = New System.Drawing.Point(60, 538)
        Me.btnAssessments.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAssessments.Name = "btnAssessments"
        Me.btnAssessments.Size = New System.Drawing.Size(822, 250)
        Me.btnAssessments.TabIndex = 3
        Me.btnAssessments.Text = "Assessments"
        Me.btnAssessments.UseVisualStyleBackColor = True
        '
        'btnManageClass
        '
        Me.btnManageClass.Font = New System.Drawing.Font("Myanmar Text", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageClass.Location = New System.Drawing.Point(942, 615)
        Me.btnManageClass.Margin = New System.Windows.Forms.Padding(6)
        Me.btnManageClass.Name = "btnManageClass"
        Me.btnManageClass.Size = New System.Drawing.Size(822, 173)
        Me.btnManageClass.TabIndex = 4
        Me.btnManageClass.Text = "Manage Class"
        Me.btnManageClass.UseVisualStyleBackColor = True
        '
        'picSettings
        '
        Me.picSettings.BackColor = System.Drawing.Color.Transparent
        Me.picSettings.Image = CType(resources.GetObject("picSettings.Image"), System.Drawing.Image)
        Me.picSettings.Location = New System.Drawing.Point(60, 871)
        Me.picSettings.Margin = New System.Windows.Forms.Padding(6)
        Me.picSettings.Name = "picSettings"
        Me.picSettings.Size = New System.Drawing.Size(94, 90)
        Me.picSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSettings.TabIndex = 5
        Me.picSettings.TabStop = False
        '
        'picNotifications
        '
        Me.picNotifications.BackColor = System.Drawing.Color.Transparent
        Me.picNotifications.Image = CType(resources.GetObject("picNotifications.Image"), System.Drawing.Image)
        Me.picNotifications.Location = New System.Drawing.Point(214, 871)
        Me.picNotifications.Margin = New System.Windows.Forms.Padding(6)
        Me.picNotifications.Name = "picNotifications"
        Me.picNotifications.Size = New System.Drawing.Size(94, 90)
        Me.picNotifications.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNotifications.TabIndex = 6
        Me.picNotifications.TabStop = False
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1824, 987)
        Me.Controls.Add(Me.picNotifications)
        Me.Controls.Add(Me.picSettings)
        Me.Controls.Add(Me.btnManageClass)
        Me.Controls.Add(Me.btnAssessments)
        Me.Controls.Add(Me.btnViewClass)
        Me.Controls.Add(Me.lblWelcomeMessage)
        Me.Controls.Add(Me.graClassLevels)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        CType(Me.graClassLevels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNotifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents graClassLevels As DataVisualization.Charting.Chart
    Friend WithEvents lblWelcomeMessage As Label
    Friend WithEvents btnViewClass As Button
    Friend WithEvents btnAssessments As Button
    Friend WithEvents btnManageClass As Button
    Friend WithEvents picSettings As PictureBox
    Friend WithEvents picNotifications As PictureBox
End Class
