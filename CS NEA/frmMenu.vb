Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmMenu
    Dim lstNotificationsList As ListBox
    Dim lstSettingsList As ListBox
    Dim chkFullscreen As CheckBox
    Dim nudWeeksWithoutProgress As NumericUpDown
    Dim nudTargetProgressRate As NumericUpDown
    Structure PhonicLevelsCount
        Dim Set1A As Integer
        Dim Set1B As Integer
        Dim Set1C As Integer
        Dim Ditty As Integer
        Dim Red As Integer
        Dim Green As Integer
        Dim Purple As Integer
        Dim Pink As Integer
        Dim Orange As Integer
        Dim Yellow As Integer
    End Structure
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMenu_Resize(sender, e)
        Dim SelectedProgressChange As ProgressChange
        Dim LastProgressChange As ProgressChange
        Dim SelectedStudent As Student
        Dim Levels As PhonicLevelsCount
        Dim StudentIDList As New List(Of Integer)
        Dim InList As Boolean
        Dim SelectedStudentAchievement As StudentAchievement
        Dim FirstProgressChangeList As New List(Of ProgressChange)
        Dim LastProgressChangeList As New List(Of ProgressChange)
        Dim StudentAchievementList As New List(Of StudentAchievement)
        Dim SelectedSettings As Settings
        'GET LIST OF ID'S
        FileOpen(1, "Student.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudent.StudentID)
            Input(1, SelectedStudent.Surname)
            Input(1, SelectedStudent.FirstName)
            Input(1, SelectedStudent.PupilPremium)
            Input(1, SelectedStudent.LAC)
            Input(1, SelectedStudent.SEND)
            Input(1, SelectedStudent.EAL)
            Input(1, SelectedStudent.SALT)
            Input(1, SelectedStudent.Target)
            StudentIDList.Add(SelectedStudent.StudentID)
        End While
        FileClose(1)
        'GET PHONIC LEVELS
        For i = 0 To StudentIDList.Count - 1
            FileOpen(1, "ProgressChange.txt", OpenMode.Input)
            While Not EOF(1)
                Input(1, SelectedProgressChange.StudentID)
                Input(1, SelectedProgressChange.PhonicLevel)
                Input(1, SelectedProgressChange.AchievementDate)
                If SelectedProgressChange.StudentID = StudentIDList(i) Then
                    LastProgressChange = SelectedProgressChange
                End If
            End While
            FileClose(1)
            'ADD EACH PHONIC LEVEL TO THE COUNT
            Select Case LastProgressChange.PhonicLevel
                Case "Set1A"
                    Levels.Set1A += 1
                Case "Set1B"
                    Levels.Set1B += 1
                Case "Set1C"
                    Levels.Set1C += 1
                Case "Ditty"
                    Levels.Ditty += 1
                Case "Red"
                    Levels.Red += 1
                Case "Green"
                    Levels.Green += 1
                Case "Purple"
                    Levels.Purple += 1
                Case "Pink"
                    Levels.Pink += 1
                Case "Orange"
                    Levels.Orange += 1
                Case "Yellow"
                    Levels.Yellow += 1
            End Select
        Next
        'ADD THE PHONIC LEVELS TO THE PIE CHART
        graClassLevels.Series("ClassLevels").Points.AddXY("Set1A", Levels.Set1A)
        graClassLevels.Series("ClassLevels").Points.AddXY("Set1B", Levels.Set1B)
        graClassLevels.Series("ClassLevels").Points.AddXY("Set1C", Levels.Set1C)
        graClassLevels.Series("ClassLevels").Points.AddXY("Ditty", Levels.Ditty)
        graClassLevels.Series("ClassLevels").Points.AddXY("Red", Levels.Red)
        graClassLevels.Series("ClassLevels").Points.AddXY("Green", Levels.Green)
        graClassLevels.Series("ClassLevels").Points.AddXY("Purple", Levels.Purple)
        graClassLevels.Series("ClassLevels").Points.AddXY("Pink", Levels.Pink)
        graClassLevels.Series("ClassLevels").Points.AddXY("Orange", Levels.Orange)
        graClassLevels.Series("ClassLevels").Points.AddXY("Yellow", Levels.Yellow)
        'ASSIGN COLOURS TO EACH LEVEL IN THE PIE CHART
        graClassLevels.Series("ClassLevels").Points(0).Color = ColorTranslator.FromHtml("#444444")
        graClassLevels.Series("ClassLevels").Points(1).Color = ColorTranslator.FromHtml("#666666")
        graClassLevels.Series("ClassLevels").Points(2).Color = ColorTranslator.FromHtml("#888888")
        graClassLevels.Series("ClassLevels").Points(3).Color = ColorTranslator.FromHtml("#AAAAAA")
        graClassLevels.Series("ClassLevels").Points(4).Color = Color.Red
        graClassLevels.Series("ClassLevels").Points(5).Color = Color.Green
        graClassLevels.Series("ClassLevels").Points(6).Color = Color.Purple
        graClassLevels.Series("ClassLevels").Points(7).Color = Color.Pink
        graClassLevels.Series("ClassLevels").Points(8).Color = Color.Orange
        graClassLevels.Series("ClassLevels").Points(9).Color = Color.Yellow
        graClassLevels.Series("ClassLevels")("PieLabelStyle") = "Disabled"
        'GET PROGRESS CHANGE LISTS
        FileOpen(1, "ProgressChange.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedProgressChange.StudentID)
            Input(1, SelectedProgressChange.PhonicLevel)
            Input(1, SelectedProgressChange.AchievementDate)
            InList = False
            For i = 0 To LastProgressChangeList.Count - 1
                If LastProgressChangeList(i).StudentID = SelectedProgressChange.StudentID Then
                    InList = True
                    LastProgressChangeList.RemoveAt(i)
                    LastProgressChangeList.Add(SelectedProgressChange)
                End If
            Next
            If InList = False Then
                FirstProgressChangeList.Add(SelectedProgressChange)
                LastProgressChangeList.Add(SelectedProgressChange)
            End If
        End While
        FileClose(1)
        'GET CURRENT STUDENT ACHIEVEMENT'S STORED IN FILE
        FileOpen(1, "StudentAchievement.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentAchievement.StudentID)
            Input(1, SelectedStudentAchievement.PhonicLevel)
            Input(1, SelectedStudentAchievement.RateOfProgress)
            StudentAchievementList.Add(SelectedStudentAchievement)
        End While
        FileClose(1)
        Kill("StudentAchievement.txt")
        'REWRITE STUDENT ACHIEVEMENT FILE WITH NEW RATE OF PROGRESS
        FileOpen(1, "StudentAchievement.txt", OpenMode.Output)
        For i = 0 To StudentAchievementList.Count - 1
            Write(1, StudentAchievementList(i).StudentID)
            Write(1, StudentAchievementList(i).PhonicLevel)
            For x = 0 To FirstProgressChangeList.Count - 1
                If FirstProgressChangeList(x).StudentID = StudentAchievementList(i).StudentID Then
                    SelectedProgressChange = FirstProgressChangeList(x)
                End If
            Next
            For x = 0 To LastProgressChangeList.Count - 1
                If LastProgressChangeList(x).StudentID = StudentAchievementList(i).StudentID Then
                    'CALCULATE RATE OF PROGRESS
                    If DateDiff(DateInterval.Day, SelectedProgressChange.AchievementDate, Today) <> 0 Then
                        WriteLine(1, Math.Round(1000 * GetPhonicLevelInt(LastProgressChangeList(x).PhonicLevel) / DateDiff(DateInterval.Day, SelectedProgressChange.AchievementDate, Today), 2))
                    Else
                        WriteLine(1, 0)
                    End If
                End If
            Next
        Next
        FileClose(1)
        'LOAD SETTINGS
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        'SET FULLSCREEN PREFERENCE
        If SelectedSettings.Fullscreen = True Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub frmMenu_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim FontSize As Integer
        'RESIZE AND RELOCATE OBJECTS AFTER FORM RESIZE
        Try
            lblWelcomeMessage.Left = 20 * ((MyBase.Width - 16) / 912)
            lblWelcomeMessage.Top = 29 * ((MyBase.Height - 39) / 513)
            FontSize = Math.Round(40 * MyBase.Width / 928, 0)
            lblWelcomeMessage.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            graClassLevels.Width = 411 * (MyBase.Width / 928)
            graClassLevels.Height = 284 * (MyBase.Height / 552)
            graClassLevels.Left = 471 * ((MyBase.Width - 16) / 912)
            graClassLevels.Top = 30 * ((MyBase.Height - 39) / 513)
            FontSize = Math.Round(12 * MyBase.Width / 928, 0)
            graClassLevels.Legends("ClassLevelsLegend").Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
            btnViewClass.Width = 411 * (MyBase.Width / 928)
            btnViewClass.Height = 130 * (MyBase.Height / 552)
            btnViewClass.Left = 30 * ((MyBase.Width - 16) / 912)
            btnViewClass.Top = 130 * ((MyBase.Height - 39) / 513)
            FontSize = Math.Round(20 * MyBase.Width / 928, 0)
            btnViewClass.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            btnAssessments.Width = 411 * (MyBase.Width / 928)
            btnAssessments.Height = 130 * (MyBase.Height / 552)
            btnAssessments.Left = 30 * ((MyBase.Width - 16) / 912)
            btnAssessments.Top = 280 * ((MyBase.Height - 39) / 513)
            btnAssessments.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            btnManageClass.Width = 411 * (MyBase.Width / 928)
            btnManageClass.Height = 90 * (MyBase.Height / 552)
            btnManageClass.Left = 471 * ((MyBase.Width - 16) / 912)
            btnManageClass.Top = 320 * ((MyBase.Height - 39) / 513)
            btnManageClass.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            picSettings.Width = 47 * (MyBase.Height / 552)
            picSettings.Height = 47 * (MyBase.Height / 552)
            picSettings.Left = 30 * ((MyBase.Width - 16) / 912)
            picSettings.Top = 453 * ((MyBase.Height - 39) / 513)
            picNotifications.Width = 47 * (MyBase.Height / 552)
            picNotifications.Height = 47 * (MyBase.Height / 552)
            picNotifications.Left = 107 * ((MyBase.Width - 16) / 912)
            picNotifications.Top = 453 * ((MyBase.Height - 39) / 513)
            'TEST IF DYNAMIC OBJECTS ARE CURRENTLY ADDED INTO THE FORM
            If Me.Controls.Contains(lstNotificationsList) = True Then
                FontSize = 14 * (MyBase.Width / 928)
                lstNotificationsList.Width = 698 * (MyBase.Width / 928)
                lstNotificationsList.Height = 47 * (MyBase.Height / 552)
                lstNotificationsList.Left = 184 * ((MyBase.Width - 16) / 912)
                lstNotificationsList.Top = 453 * ((MyBase.Height - 39) / 513)
                lstNotificationsList.Font = New Font("Ariel", FontSize, FontStyle.Regular)
            End If
            If Me.Controls.Contains(lstSettingsList) = True Then
                FontSize = 14 * (MyBase.Width / 928)
                lstSettingsList.Width = 568 * (MyBase.Width / 928)
                lstSettingsList.Height = 47 * (MyBase.Height / 552)
                lstSettingsList.Left = 184 * ((MyBase.Width - 16) / 912)
                lstSettingsList.Top = 453 * ((MyBase.Height - 39) / 513)
                lstSettingsList.Font = New Font("Ariel", FontSize, FontStyle.Regular)
            End If
            If Me.Controls.Contains(chkFullscreen) = True Then
                chkFullscreen.Width = 47 * (MyBase.Width / 928)
                chkFullscreen.Height = 47 * (MyBase.Height / 552)
                chkFullscreen.Left = 782 * ((MyBase.Width - 16) / 912)
                chkFullscreen.Top = 453 * ((MyBase.Height - 39) / 513)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnManageClass_Click(sender As Object, e As EventArgs) Handles btnManageClass.Click
        'OPEN MANAGE CLASS FORM
        Dim frmManageClass As New frmManageClass
        frmManageClass.Show()
    End Sub
    Private Sub btnViewClass_Click(sender As Object, e As EventArgs) Handles btnViewClass.Click
        'OPEN VIEW CLASS FORM
        Dim frmViewClass As New frmViewClass
        frmViewClass.Show()
    End Sub
    Private Sub btnAssessments_Click(sender As Object, e As EventArgs) Handles btnAssessments.Click
        'OPEN ASSESSMENTS FORM
        Dim frmAssessments As New frmAssessments
        frmAssessments.Show()
    End Sub
    Function GetPhonicLevelInt(ByVal PhonicLevel As String)
        'GET INTEGER CORRESPONDING TO PHONIC LEVEL
        Select Case PhonicLevel
            Case "N/A"
                Return -1
            Case "Set1A"
                Return 0
            Case "Set1B"
                Return 1
            Case "Set1C"
                Return 2
            Case "Ditty"
                Return 3
            Case "Red"
                Return 4
            Case "Green"
                Return 5
            Case "Purple"
                Return 6
            Case "Pink"
                Return 7
            Case "Orange"
                Return 8
            Case "Yellow"
                Return 9
        End Select
    End Function
    Private Sub picNotifications_Click(sender As Object, e As EventArgs) Handles picNotifications.Click
        If Me.Controls.Contains(lstNotificationsList) Then
            'REMOVE NOTIFICATIONS IF ALREADY DISPLAYED WHEN CLICKED
            Me.Controls.Remove(lstNotificationsList)
        Else
            Me.Controls.Remove(lstSettingsList)
            Me.Controls.Remove(chkFullscreen)
            Me.Controls.Remove(nudWeeksWithoutProgress)
            Me.Controls.Remove(nudTargetProgressRate)
            Dim Location As Point
            Dim FontSize As Integer = 14 * (MyBase.Width / 928)
            Dim SelectedSettings As Settings
            Dim SelectedStudentAchievement As StudentAchievement
            Dim SelectedStudent As Student
            Dim LastProgressChangeDate As Date = Today
            Dim LastProgressChangeLevel As String
            Dim SelectedProgressChange As ProgressChange
            Dim ProgressMade As Boolean
            'ADD NOTIFICATIONS LIST BOX
            Location.X = 184 * ((MyBase.Width - 16) / 912)
            Location.Y = 453 * ((MyBase.Height - 39) / 513)
            lstNotificationsList = New ListBox
            lstNotificationsList.Location = Location
            lstNotificationsList.Font = New Font("Ariel", FontSize, FontStyle.Regular)
            lstNotificationsList.Width = 698 * (MyBase.Width / 928)
            lstNotificationsList.Height = 47 * (MyBase.Height / 552)
            lstNotificationsList.BackColor = Color.White
            Me.Controls.Add(lstNotificationsList)
            lstNotificationsList.Items.Clear()
            'LOAD SETTINGS
            FileOpen(1, "Settings.txt", OpenMode.Input)
            Input(1, SelectedSettings.Fullscreen)
            Input(1, SelectedSettings.MaxTimeToImprove)
            Input(1, SelectedSettings.TargetProgressRate)
            FileClose(1)
            'GET RATE OF PROGRESS FOR EACH STUDENT
            FileOpen(1, "StudentAchievement.txt", OpenMode.Input)
            While Not EOF(1)
                Input(1, SelectedStudentAchievement.StudentID)
                Input(1, SelectedStudentAchievement.PhonicLevel)
                Input(1, SelectedStudentAchievement.RateOfProgress)
                FileOpen(2, "Student.txt", OpenMode.Input)
                While Not EOF(2)
                    Input(2, SelectedStudent.StudentID)
                    Input(2, SelectedStudent.Surname)
                    Input(2, SelectedStudent.FirstName)
                    Input(2, SelectedStudent.PupilPremium)
                    Input(2, SelectedStudent.LAC)
                    Input(2, SelectedStudent.SEND)
                    Input(2, SelectedStudent.EAL)
                    Input(2, SelectedStudent.SALT)
                    Input(2, SelectedStudent.Target)
                    'ADD TO LIST BOX IF STUDENT IS BELOW IDEAL RATE OF PROGRESS
                    If SelectedStudent.StudentID = SelectedStudentAchievement.StudentID And SelectedStudentAchievement.RateOfProgress <= SelectedSettings.TargetProgressRate And SelectedStudentAchievement.RateOfProgress <> 0 Then
                        lstNotificationsList.Items.Add(SelectedStudent.FirstName & " " & SelectedStudent.Surname & " is below the target progress rate")
                    End If
                End While
                FileClose(2)
            End While
            FileClose(1)
            'GET THE NUMBER OF WEEKS SINCE LAST ASSESSMENT FOR EACH STUDENT
            FileOpen(1, "Student.txt", OpenMode.Input)
            While Not EOF(1)
                Input(1, SelectedStudent.StudentID)
                Input(1, SelectedStudent.Surname)
                Input(1, SelectedStudent.FirstName)
                Input(1, SelectedStudent.PupilPremium)
                Input(1, SelectedStudent.LAC)
                Input(1, SelectedStudent.SEND)
                Input(1, SelectedStudent.EAL)
                Input(1, SelectedStudent.SALT)
                Input(1, SelectedStudent.Target)
                FileOpen(2, "ProgressChange.txt", OpenMode.Input)
                While Not EOF(2)
                    Input(2, SelectedProgressChange.StudentID)
                    Input(2, SelectedProgressChange.PhonicLevel)
                    Input(2, SelectedProgressChange.AchievementDate)
                    If SelectedProgressChange.StudentID = SelectedStudent.StudentID Then
                        LastProgressChangeDate = SelectedProgressChange.AchievementDate
                    End If
                End While
                FileClose(2)
                'ADD TO LIST BOX IF STUDENT HAS NOT PROGRESSED IN THE IDEAL AMOUNT OF TIME
                If (DateDiff(DateInterval.Day, LastProgressChangeDate, Today) / 7) > SelectedSettings.MaxTimeToImprove Then
                    lstNotificationsList.Items.Add(SelectedStudent.FirstName & " " & SelectedStudent.Surname & " has not progressed in over " & SelectedSettings.MaxTimeToImprove & " weeks")
                End If
            End While
            FileClose(1)
            'GET THE LAST TWO PHONIC LEVELS ACHIEVED FOR EACH STUDENT
            FileOpen(1, "Student.txt", OpenMode.Input)
            While Not EOF(1)
                LastProgressChangeLevel = "N/A"
                ProgressMade = True
                Input(1, SelectedStudent.StudentID)
                Input(1, SelectedStudent.Surname)
                Input(1, SelectedStudent.FirstName)
                Input(1, SelectedStudent.PupilPremium)
                Input(1, SelectedStudent.LAC)
                Input(1, SelectedStudent.SEND)
                Input(1, SelectedStudent.EAL)
                Input(1, SelectedStudent.SALT)
                Input(1, SelectedStudent.Target)
                FileOpen(2, "ProgressChange.txt", OpenMode.Input)
                While Not EOF(2)
                    Input(2, SelectedProgressChange.StudentID)
                    Input(2, SelectedProgressChange.PhonicLevel)
                    Input(2, SelectedProgressChange.AchievementDate)
                    If SelectedProgressChange.StudentID = SelectedStudent.StudentID Then
                        If GetPhonicLevelInt(SelectedProgressChange.PhonicLevel) <= GetPhonicLevelInt(LastProgressChangeLevel) Then
                            ProgressMade = False
                        Else
                            ProgressMade = True
                        End If
                        LastProgressChangeLevel = SelectedProgressChange.PhonicLevel
                    End If
                End While
                FileClose(2)
                'ADD TO LIST BOX IF NO PROGRESSION OR LOSS OF PROGRESSION SINCE LAST ASSESSMENT
                If ProgressMade = False Then
                    lstNotificationsList.Items.Add(SelectedStudent.FirstName & " " & SelectedStudent.Surname & " did not progress in their last assessment")
                End If
            End While
            FileClose(1)
        End If
    End Sub
    Private Sub picSettings_Click(sender As Object, e As EventArgs) Handles picSettings.Click
        If Me.Controls.Contains(lstSettingsList) Then
            'REMOVE SETTINGS IF ALREADY DISPLAYED WHEN CLICKED
            Me.Controls.Remove(lstSettingsList)
            Me.Controls.Remove(chkFullscreen)
            Me.Controls.Remove(nudWeeksWithoutProgress)
            Me.Controls.Remove(nudTargetProgressRate)
        Else
            Me.Controls.Remove(lstNotificationsList)
            Dim Location As Point
            Dim FontSize As Single = 14 * (MyBase.Width / 928)
            Dim SelectedSettings As Settings
            'ADD SETTINGS LIST BOX
            Location.X = 184 * ((MyBase.Width - 16) / 912)
            Location.Y = 453 * ((MyBase.Height - 39) / 513)
            lstSettingsList = New ListBox
            lstSettingsList.Location = Location
            lstSettingsList.Font = New Font("Ariel", FontSize, FontStyle.Regular)
            lstSettingsList.Width = 568 * (MyBase.Width / 928)
            lstSettingsList.Height = 47 * (MyBase.Height / 552)
            lstSettingsList.BackColor = Color.White
            Me.Controls.Add(lstSettingsList)
            lstSettingsList.Items.Clear()
            'ADD SETTINGS TO THE LIST AND HANDLER FOR WHEN AN INDEX IS SELECTED
            lstSettingsList.Items.Add("Fullscreen")
            lstSettingsList.Items.Add("Weeks Without Improvement Notification")
            lstSettingsList.Items.Add("Rate Of Progress Level Notification")
            AddHandler lstSettingsList.SelectedIndexChanged, AddressOf lstSettingsList_SelectedIndexChanged
        End If
    End Sub
    Sub lstSettingsList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim Location As Point
        Dim SelectedSettings As Settings
        Dim FontSize As Single = 8 * (MyBase.Width / 928)
        'LOAD SETTINGS
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        'DETERMINE WHICH SETTING HAS BEEN SELECTED IN LIST BOX
        Select Case lstSettingsList.SelectedIndex
            Case 0
                If Me.Controls.Contains(chkFullscreen) = False Then
                    'DISPLAY CHECK BOX FOR FULLSCREEN SETTING
                    Me.Controls.Remove(nudWeeksWithoutProgress)
                    Me.Controls.Remove(nudTargetProgressRate)
                    Location.X = 782 * ((MyBase.Width - 16) / 912)
                    Location.Y = 453 * ((MyBase.Height - 39) / 513)
                    chkFullscreen = New CheckBox
                    chkFullscreen.Location = Location
                    chkFullscreen.Width = 47 * (MyBase.Height / 552)
                    chkFullscreen.Height = 47 * (MyBase.Height / 552)
                    chkFullscreen.Appearance = Appearance.Button
                    Me.Controls.Add(chkFullscreen)
                    chkFullscreen.Checked = SelectedSettings.Fullscreen
                    'ADD HANDLER FOR WHEN CHECKED OR UNCHECKED
                    AddHandler chkFullscreen.CheckedChanged, AddressOf chkFullscreen_CheckedChanged
                End If
            Case 1
                If Me.Controls.Contains(nudWeeksWithoutProgress) = False Then
                    'DISPLAY NUMERIC UP DOWN FOR WEEKS WITHOUT PROGRESS SETTING
                    Me.Controls.Remove(chkFullscreen)
                    Me.Controls.Remove(nudTargetProgressRate)
                    Location.X = 782 * ((MyBase.Width - 16) / 912)
                    Location.Y = 453 * ((MyBase.Height - 39) / 513)
                    nudWeeksWithoutProgress = New NumericUpDown
                    nudWeeksWithoutProgress.Location = Location
                    nudWeeksWithoutProgress.Width = 80 * (MyBase.Height / 552)
                    nudWeeksWithoutProgress.Value = SelectedSettings.MaxTimeToImprove
                    Do Until nudWeeksWithoutProgress.Height > 46.9 * (MyBase.Height / 552) And nudWeeksWithoutProgress.Height < 47.1 * (MyBase.Height / 552)
                        nudWeeksWithoutProgress.Font = New Font("Ariel", FontSize, FontStyle.Regular)
                        FontSize += 0.1
                    Loop
                    Me.Controls.Add(nudWeeksWithoutProgress)
                    'ADD HANDLER FOR WHEN INCREMENTED
                    AddHandler nudWeeksWithoutProgress.ValueChanged, AddressOf nudWeeksWithoutProgress_ValueChanged
                End If
            Case 2
                If Me.Controls.Contains(nudTargetProgressRate) = False Then
                    'DISPLAY NUMERIC UP DOWN FOR TARGET PROGRESS RATE
                    Me.Controls.Remove(chkFullscreen)
                    Me.Controls.Remove(nudWeeksWithoutProgress)
                    Location.X = 782 * ((MyBase.Width - 16) / 912)
                    Location.Y = 453 * ((MyBase.Height - 39) / 513)
                    nudTargetProgressRate = New NumericUpDown
                    nudTargetProgressRate.Location = Location
                    nudTargetProgressRate.Width = 80 * (MyBase.Height / 552)
                    nudTargetProgressRate.Value = SelectedSettings.TargetProgressRate
                    Do Until nudTargetProgressRate.Height > 46.8 * (MyBase.Height / 552) And nudTargetProgressRate.Height < 47.2 * (MyBase.Height / 552)
                        nudTargetProgressRate.Font = New Font("Ariel", FontSize, FontStyle.Regular)
                        FontSize += 0.05
                    Loop
                    Me.Controls.Add(nudTargetProgressRate)
                    'ADD HANDLER FOR WHEN INCREMENTED
                    AddHandler nudTargetProgressRate.ValueChanged, AddressOf nudTargetProgressRate_ValueChanged
                End If
        End Select
    End Sub
    Sub chkFullscreen_CheckedChanged(sender As Object, e As EventArgs)
        Dim SelectedSettings As Settings
        'REWRITE SETTINGS FILE
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        Kill("Settings.txt")
        FileOpen(1, "Settings.txt", OpenMode.Append)
        Write(1, chkFullscreen.Checked)
        Write(1, SelectedSettings.MaxTimeToImprove)
        WriteLine(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
    End Sub
    Sub nudWeeksWithoutProgress_ValueChanged(sender As Object, e As EventArgs)
        Dim SelectedSettings As Settings
        'REWRITE SETTINGS FILE
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        Kill("Settings.txt")
        FileOpen(1, "Settings.txt", OpenMode.Append)
        Write(1, SelectedSettings.Fullscreen)
        Write(1, nudWeeksWithoutProgress.Value)
        WriteLine(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
    End Sub
    Sub nudTargetProgressRate_ValueChanged(sender As Object, e As EventArgs)
        Dim SelectedSettings As Settings
        'REWRITE SETTINGS FILE
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        Kill("Settings.txt")
        FileOpen(1, "Settings.txt", OpenMode.Append)
        Write(1, SelectedSettings.Fullscreen)
        Write(1, SelectedSettings.MaxTimeToImprove)
        WriteLine(1, nudTargetProgressRate.Value)
        FileClose(1)
    End Sub
End Class