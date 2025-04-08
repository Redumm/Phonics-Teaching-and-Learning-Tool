Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Public Class frmViewClass
    Dim lblXAxis(20) As Label
    Dim lblYAxis(10) As Label
    Dim Bitmap As Bitmap
    Dim ptcXAxis(20) As PictureBox
    Dim lblStudentName As Label
    Dim lblNormalToAlienWords As Label
    Dim lblCommonlyIncorrectAttributes As Label
    Dim lblNumberOfSounds As Label
    Dim lblPhonemes As Label

    Private Sub frmViewClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SelectedStudent As Student
        Dim SelectedStudentAchievement As StudentAchievement
        Dim Count As Integer = 0
        Dim SENList As String = ""
        Dim SENCount As Integer = 0
        Dim SelectedSettings As Settings
        frmViewClass_Resize(sender, e)
        'LOAD STUDENT FILE
        FileOpen(1, "Student.txt", OpenMode.Input)
        While Not EOF(1)
            SENCount = 0
            Input(1, SelectedStudent.StudentID)
            Input(1, SelectedStudent.Surname)
            Input(1, SelectedStudent.FirstName)
            Input(1, SelectedStudent.PupilPremium)
            Input(1, SelectedStudent.LAC)
            Input(1, SelectedStudent.SEND)
            Input(1, SelectedStudent.EAL)
            Input(1, SelectedStudent.SALT)
            Input(1, SelectedStudent.Target)
            'WRITE STRING OF PRIORITY GROUPS
            If SelectedStudent.PupilPremium = "Y" Then
                SENList = SENList & "PP"
                SENCount += 1
            End If
            If SelectedStudent.LAC = "Y" Then
                If SENCount > 0 Then
                    SENList = SENList & " , "
                End If
                SENList = SENList & "LAC"
                SENCount += 1
            End If
            If SelectedStudent.SEND = "Y" Then
                If SENCount > 0 Then
                    SENList = SENList & " , "
                End If
                SENList = SENList & "SEND"
                SENCount += 1
            End If
            If SelectedStudent.EAL = "Y" Then
                If SENCount > 0 Then
                    SENList = SENList & " , "
                End If
                SENList = SENList & "EAL"
                SENCount += 1
            End If
            If SelectedStudent.SALT = "Y" Then
                If SENCount > 0 Then
                    SENList = SENList & " , "
                End If
                SENList = SENList & "SALT"
                SENCount += 1
            End If
            'GET STUDENT ACHIEVEMENT CORRESPONDING TO ID
            FileOpen(2, "StudentAchievement.txt", OpenMode.Input)
            While Not EOF(2)
                Input(2, SelectedStudentAchievement.StudentID)
                Input(2, SelectedStudentAchievement.PhonicLevel)
                Input(2, SelectedStudentAchievement.RateOfProgress)
                If SelectedStudent.StudentID = SelectedStudentAchievement.StudentID Then
                    'WRITE TO DATA GRID VIEW
                    grdStudentAchievementProperties.Rows.Add(New String() {SelectedStudent.StudentID, SelectedStudent.Surname, SelectedStudent.FirstName, SelectedStudentAchievement.PhonicLevel, SelectedStudentAchievement.RateOfProgress, SENList, SelectedStudent.Target})
                    grdStudentAchievementProperties.Rows(Count).Cells(0).Value = SelectedStudent.StudentID
                    Count += 1
                    SENCount = 0
                    SENList = ""
                End If
            End While
            FileClose(2)
        End While
        FileClose(1)
        'LOAD SETTINGS
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        'SET FULLSRCEEN PREFERENCE
        If SelectedSettings.Fullscreen = True Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub frmViewClass_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim FontSize As Integer
        'RESIZE AND RELOCATE OBJECTS AFTER FORM RESIZE
        RemoveGraph()
        Try
            lblViewClass.Left = 20 * ((MyBase.Width - 16) / 912)
            lblViewClass.Top = 8 * ((MyBase.Height - 39) / 513)
            FontSize = 40 * MyBase.Width / 928
            lblViewClass.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            grdStudentAchievementProperties.Width = 600 * (MyBase.Width / 928)
            grdStudentAchievementProperties.Height = 195 * (MyBase.Height / 552)
            grdStudentAchievementProperties.Left = 34 * ((MyBase.Width - 16) / 912)
            grdStudentAchievementProperties.Top = 87 * ((MyBase.Height - 39) / 513)
            FontSize = 10 * MyBase.Width / 928
            grdStudentAchievementProperties.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
            grdStudentAchievementProperties.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
            grdStudentAchievementProperties.AutoResizeRows()
            'TEST IF DYNAMIC OBJECTS ARE CURRENTLY ADDED INTO THE FORM
            If Me.Controls.Contains(lblStudentName) Then
                lblStudentName.Width = 250 * (MyBase.Width / 928)
                lblStudentName.Height = 30 * (MyBase.Height / 552)
                lblStudentName.Left = 640 * ((MyBase.Width - 16) / 912)
                lblStudentName.Top = 98 * ((MyBase.Height - 39) / 552)
                FontSize = 18 * (MyBase.Width / 928)
                lblStudentName.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
                lblCommonlyIncorrectAttributes.Width = 250 * (MyBase.Width / 928)
                lblCommonlyIncorrectAttributes.Height = 20 * (MyBase.Height / 552)
                lblCommonlyIncorrectAttributes.Left = 640 * ((MyBase.Width - 16) / 912)
                lblCommonlyIncorrectAttributes.Top = 135 * ((MyBase.Height - 39) / 552)
                FontSize = 9 * (MyBase.Width / 928)
                lblCommonlyIncorrectAttributes.Font = New Font("Century Gothic", FontSize, FontStyle.Bold Or FontStyle.Underline)
                lblCommonlyIncorrectAttributes.Width = 250 * (MyBase.Width / 928)
                lblCommonlyIncorrectAttributes.Height = 20 * (MyBase.Height / 552)
                lblCommonlyIncorrectAttributes.Left = 640 * ((MyBase.Width - 16) / 912)
                lblCommonlyIncorrectAttributes.Top = 135 * ((MyBase.Height - 39) / 552)
                FontSize = 9 * (MyBase.Width / 928)
                lblCommonlyIncorrectAttributes.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
                lblNormalToAlienWords.Width = 250 * (MyBase.Width / 928)
                lblNormalToAlienWords.Height = 20 * (MyBase.Height / 552)
                lblNormalToAlienWords.Left = 640 * ((MyBase.Width - 16) / 912)
                lblNormalToAlienWords.Top = 157 * ((MyBase.Height - 39) / 552)
                lblNormalToAlienWords.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
                lblNumberOfSounds.Width = 250 * (MyBase.Width / 928)
                lblNumberOfSounds.Height = 20 * (MyBase.Height / 552)
                lblNumberOfSounds.Left = 640 * ((MyBase.Width - 16) / 912)
                lblNumberOfSounds.Top = 179 * ((MyBase.Height - 39) / 552)
                lblNumberOfSounds.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
                lblPhonemes.Width = 250 * (MyBase.Width / 928)
                lblPhonemes.Height = 20 * (MyBase.Height / 552)
                lblPhonemes.Left = 640 * ((MyBase.Width - 16) / 912)
                lblPhonemes.Top = 201 * ((MyBase.Height - 39) / 552)
                lblPhonemes.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
            End If
        Catch ex As Exception
        End Try
        grdStudentAchievementProperties.CurrentCell = grdStudentAchievementProperties.Rows(0).Cells(1)
    End Sub
    Private Sub grdStudentAchievementProperties_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdStudentAchievementProperties.CellClick
        'DRAW GRAPH AND SHOW STATISTICS WHEN A STUDENT IS SELECTED IN THE DATA GRID VIEW
        DrawGraph()
        ShowStatistics()
    End Sub
    Sub DrawGraph()
        Dim SelectedID As Integer = grdStudentAchievementProperties.Rows(grdStudentAchievementProperties.SelectedCells.Item(0).RowIndex).Cells(0).Value
        Dim SelectedProgressTime As ProgressTime
        Dim DataPoints As New List(Of ProgressTime)
        Dim SelectedProgressChange As ProgressChange
        Dim FirstProgressChangeDate As Date
        Dim NumberOfPoints As Integer = 0
        Dim MaxPhonicLevel As Integer = 0
        'NEW
        Dim StudentsExist As Boolean = False
        'LOAD PROGRESS CHANGE FILE
        FileOpen(1, "ProgressChange.txt", OpenMode.Input)
        While Not EOF(1)
            StudentsExist = True
            Input(1, SelectedProgressChange.StudentID)
            Input(1, SelectedProgressChange.PhonicLevel)
            Input(1, SelectedProgressChange.AchievementDate)
            If SelectedProgressChange.StudentID = SelectedID Then
                'ADD PROGRESS CHANGE TO DATA POINTS LIST IF ID'S MATCH
                SelectedProgressTime.PhonicLevel = SelectedProgressChange.PhonicLevel
                SelectedProgressTime.AchievementDate = SelectedProgressChange.AchievementDate
                If NumberOfPoints = 0 Then
                    FirstProgressChangeDate = SelectedProgressChange.AchievementDate
                End If
                DataPoints.Add(SelectedProgressTime)
                If GetPhonicLevelInt(SelectedProgressTime.PhonicLevel) > MaxPhonicLevel Then
                    MaxPhonicLevel = GetPhonicLevelInt(SelectedProgressTime.PhonicLevel)
                End If
                NumberOfPoints += 1
            End If
        End While
        FileClose(1)
        If StudentsExist = True Then
            Dim DateDifference As Integer = DateDiff(DateInterval.Day, FirstProgressChangeDate, Today)
            Dim FormGraphics As Drawing.Graphics
            Dim YPosition1 As Integer
            Dim YPosition2 As Integer
            Dim XPosition1 As Integer
            Dim XPosition2 As Integer
            Dim LocationX(NumberOfPoints) As Point
            Dim LocationY(9) As Point
            Dim Left As Integer = 90 * ((MyBase.Width - 16) / 912)
            Dim Top As Integer = 305 * ((MyBase.Height - 39) / 513)
            Dim Width As Integer = 780 * (MyBase.Width / 928)
            Dim Height As Integer = 175 * (MyBase.Height / 552)
            FormGraphics = Me.CreateGraphics
            'REMOVE OLD GRAPH
            RemoveGraph()
            'DRAW BACKGROUND
            Dim rect = New Rectangle(Left, Top, Width, Height)
            Dim GrayBrush = New SolidBrush(Color.White)
            FormGraphics.FillRectangle(GrayBrush, rect)
            'DRAW AXIS
            FormGraphics.DrawLine(Pens.Black, Left, Top, Left, Top + Height)
            FormGraphics.DrawLine(Pens.Black, Left, Top + Height, Left + Width, Top + Height)
            Dim FontSize As Single = 10 * ((MyBase.Width - 16) / 912) '(MyBase.Width / 925)
            'CREATE Y AXIS LABELS
            Dim LineHeight As Integer
            For i = 0 To 9
                LocationY(i).X = Left - 58 * (MyBase.Width / 925)
                LocationY(i).Y = Math.Round(Top + Height - ((Height / 9) * i) - (10 * (MyBase.Width / 925)), 0)
                LineHeight = Math.Round(Top + Height - ((Height / 9) * i), 0)
                FormGraphics.DrawLine(Pens.Silver, Left, LineHeight, Left + Width, LineHeight)
                lblYAxis(i) = New Label
                lblYAxis(i).AutoSize = True
                lblYAxis(i).Location = LocationY(i)
                lblYAxis(i).Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
                lblYAxis(i).BackColor = Color.LightGray
                lblYAxis(i).Text = GetPhonicLevelString(i)
                Me.Controls.Add(lblYAxis(i))
            Next
            If DateDifference > 0 Then
                'CREATE X AXIS LABELS
                Dim LineWidth As Integer
                For i = 0 To NumberOfPoints - 1
                    LocationX(i).X = Math.Round(((DateDiff(DateInterval.Day, FirstProgressChangeDate, DataPoints(i).AchievementDate) * Width) / DateDifference) + Left - (21 * (MyBase.Width / 925)), 0)
                    LocationX(i).Y = Top + Height + (10 * (MyBase.Width / 925))
                    LineWidth = Math.Round(((DateDiff(DateInterval.Day, FirstProgressChangeDate, DataPoints(i).AchievementDate) * Width) / DateDifference) + Left, 0)
                    FormGraphics.DrawLine(Pens.Silver, LineWidth, Top + Height, LineWidth, Top)
                    lblXAxis(i) = New Label
                    lblXAxis(i).AutoSize = True
                    lblXAxis(i).Location = LocationX(i)
                    lblXAxis(i).Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
                    lblXAxis(i).BackColor = Color.LightGray
                    If DataPoints(i).AchievementDate.Day < 10 And DataPoints(i).AchievementDate.Month < 10 Then
                        lblXAxis(i).Text = "0" & DataPoints(i).AchievementDate.Day & "/0" & DataPoints(i).AchievementDate.Month
                    ElseIf DataPoints(i).AchievementDate.Day < 10 And DataPoints(i).AchievementDate.Month > 9 Then
                        lblXAxis(i).Text = "0" & DataPoints(i).AchievementDate.Day & "/" & DataPoints(i).AchievementDate.Month
                    ElseIf DataPoints(i).AchievementDate.Day > 9 And DataPoints(i).AchievementDate.Month < 10 Then
                        lblXAxis(i).Text = DataPoints(i).AchievementDate.Day & "/0" & DataPoints(i).AchievementDate.Month
                    Else
                        lblXAxis(i).Text = DataPoints(i).AchievementDate.Day & "/" & DataPoints(i).AchievementDate.Month
                    End If
                    Me.Controls.Add(lblXAxis(i))
                    Bitmap = New Bitmap(lblXAxis(i).Width, lblXAxis(i).Height)
                    lblXAxis(i).DrawToBitmap(Bitmap, New Rectangle(0, 0, lblXAxis(i).Width, lblXAxis(i).Height))
                    Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    ptcXAxis(i) = New PictureBox
                    ptcXAxis(i).Location = LocationX(i)
                    ptcXAxis(i).Image = Bitmap
                    ptcXAxis(i).SizeMode = PictureBoxSizeMode.AutoSize
                    ptcXAxis(i).Left = LocationX(i).X + ptcXAxis(i).Width
                    ptcXAxis(i).Top = Top + Height + 1
                    Me.Controls.Add(ptcXAxis(i))
                    Me.Controls.Remove(lblXAxis(i))
                Next
            End If
            'DRAW GRAPH LINE
            Dim GraphPen As Pen = New Pen(Color.Crimson, 2)
            If DateDifference > 0 Then
                YPosition1 = Math.Round(Top + Height - ((Height / 9) * GetPhonicLevelInt(DataPoints(0).PhonicLevel)), 0)
                XPosition1 = Math.Round(((DateDiff(DateInterval.Day, FirstProgressChangeDate, DataPoints(0).AchievementDate) * Width) / DateDifference) + Left, 0)
                For i = 1 To NumberOfPoints - 1
                    'DRAW LINE BETWEEN TWO DATA POINTS
                    YPosition2 = Math.Round(Top + Height - ((Height / 9) * GetPhonicLevelInt(DataPoints(i).PhonicLevel)), 0)
                    XPosition2 = Math.Round(((DateDiff(DateInterval.Day, FirstProgressChangeDate, DataPoints(i).AchievementDate) * Width) / DateDifference) + Left, 0)
                    FormGraphics.DrawLine(GraphPen, XPosition1, YPosition1, XPosition2, YPosition2)
                    'MAKE END POSITION NEXT ITERATION'S START POSITION
                    YPosition1 = YPosition2
                    XPosition1 = XPosition2
                Next
                XPosition2 = Width + Left
                If NumberOfPoints <> 1 Then
                    FormGraphics.DrawLine(GraphPen, XPosition1, YPosition1, XPosition2, YPosition2)
                Else
                    FormGraphics.DrawLine(GraphPen, XPosition1, YPosition1, XPosition2, YPosition1)
                End If
            Else
                'DRAW FLAT LINE IF NO DATA POINTS EXIST
                FormGraphics.DrawLine(GraphPen, Left, Top + Height, Left + Width, Top + Height)
                LocationX(0).X = Math.Round((Width / 2) + Left - (21 * (MyBase.Width / 925)), 0)
                LocationX(0).Y = Top + Height + (10 * (MyBase.Width / 925))
                lblXAxis(0) = New Label
                lblXAxis(0).AutoSize = True
                lblXAxis(0).Location = LocationX(0)
                lblXAxis(0).Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
                lblXAxis(0).BackColor = Color.LightGray
                lblXAxis(0).Text = DataPoints(0).AchievementDate.Day & "/" & DataPoints(0).AchievementDate.Month
                Me.Controls.Add(lblXAxis(0))
            End If
        End If
    End Sub
    Sub ShowStatistics()
        Me.Controls.Remove(lblStudentName)
        Me.Controls.Remove(lblNormalToAlienWords)
        Me.Controls.Remove(lblCommonlyIncorrectAttributes)
        Me.Controls.Remove(lblNumberOfSounds)
        Me.Controls.Remove(lblPhonemes)
        'ALL NEW VARIABLES
        Dim SelectedID As Integer = grdStudentAchievementProperties.Rows(grdStudentAchievementProperties.SelectedCells.Item(0).RowIndex).Cells(0).Value
        Dim FontSize As Integer = 18 * ((MyBase.Width - 16) / 912) '(MyBase.Width / 928)
        Dim Location As Point
        Dim SelectedStudentWeakness As StudentWeakness
        Dim AlienWordsCount As Integer
        Dim NormalWordsCount As Integer
        Dim AlienWordsPercentage As Integer
        Dim NormalWordsPercentage As Integer
        Dim TwoSoundWordCount As Integer
        Dim ThreeSoundWordCount As Integer
        Dim FourSoundWordCount As Integer
        Dim MostCommonSoundWord As String
        Dim IncorrectPhoneme(3) As String
        Dim PhonemeOccurances(3) As Integer
        Dim InList As Boolean
        Dim PhonemesList As String
        'ADD NAME LABEL
        Location.X = 640 * ((MyBase.Width - 16) / 912)
        Location.Y = 98 * ((MyBase.Height - 39) / 552)
        lblStudentName = New Label
        lblStudentName.Location = Location
        lblStudentName.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
        lblStudentName.Width = 250 * (MyBase.Width / 928)
        lblStudentName.Height = 30 * (MyBase.Height / 552)
        lblStudentName.Text = grdStudentAchievementProperties.Rows(grdStudentAchievementProperties.SelectedCells.Item(0).RowIndex).Cells(2).Value & " " & grdStudentAchievementProperties.Rows(grdStudentAchievementProperties.SelectedCells.Item(0).RowIndex).Cells(1).Value
        lblStudentName.BackColor = Color.White
        Me.Controls.Add(lblStudentName)
        'GET DATA FROM STUDENT WEAKNESS FILE
        FileOpen(1, "StudentWeakness.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentWeakness.StudentID)
            Input(1, SelectedStudentWeakness.AttributeType)
            Input(1, SelectedStudentWeakness.Attribute)
            Input(1, SelectedStudentWeakness.Instances)
            If SelectedStudentWeakness.StudentID = SelectedID Then
                If SelectedStudentWeakness.Attribute = "Normal" Then
                    NormalWordsCount = SelectedStudentWeakness.Instances
                ElseIf SelectedStudentWeakness.Attribute = "Alien" Then
                    AlienWordsCount = SelectedStudentWeakness.Instances
                End If
                If SelectedStudentWeakness.AttributeType = "Sound" Then
                    If SelectedStudentWeakness.Attribute = "Two" Then
                        TwoSoundWordCount = SelectedStudentWeakness.Instances
                    ElseIf SelectedStudentWeakness.Attribute = "Three" Then
                        ThreeSoundWordCount = SelectedStudentWeakness.Instances
                    ElseIf SelectedStudentWeakness.Attribute = "Four" Then
                        FourSoundWordCount = SelectedStudentWeakness.Instances
                    End If
                End If
                If SelectedStudentWeakness.AttributeType = "Phoneme" Then
                    InList = False
                    For i = 0 To 2
                        If SelectedStudentWeakness.Instances > PhonemeOccurances(i) And InList = False Then
                            InList = True
                            If i = 0 Then
                                IncorrectPhoneme(2) = IncorrectPhoneme(1)
                                PhonemeOccurances(2) = PhonemeOccurances(1)
                                IncorrectPhoneme(1) = IncorrectPhoneme(0)
                                PhonemeOccurances(1) = PhonemeOccurances(0)
                            ElseIf i = 1 Then
                                IncorrectPhoneme(2) = IncorrectPhoneme(1)
                                PhonemeOccurances(2) = PhonemeOccurances(1)
                            End If
                            IncorrectPhoneme(i) = SelectedStudentWeakness.Attribute
                            PhonemeOccurances(i) = SelectedStudentWeakness.Instances
                        End If
                    Next
                End If
            End If
        End While
        FileClose(1)
        'DETERMINE NORMAL TO ALIEN WORDS RATIO
        Try
            NormalWordsPercentage = Math.Round(100 * NormalWordsCount / (NormalWordsCount + AlienWordsCount), 0)
        Catch Ex As Exception
            NormalWordsPercentage = 0
        End Try
        Try
            AlienWordsPercentage = Math.Round(100 * AlienWordsCount / (NormalWordsCount + AlienWordsCount), 0)
        Catch Ex As Exception
            AlienWordsPercentage = 0
        End Try
        'DETERMINE NUMBER OF SOUNDS
        If TwoSoundWordCount = 0 And ThreeSoundWordCount = 0 And FourSoundWordCount = 0 Then
            MostCommonSoundWord = "N/A"
        Else
            MostCommonSoundWord = "Two"
            If ThreeSoundWordCount > TwoSoundWordCount Then
                MostCommonSoundWord = "Three"
                If FourSoundWordCount > ThreeSoundWordCount Then
                    MostCommonSoundWord = "Four"
                End If
            Else
                If FourSoundWordCount > TwoSoundWordCount Then
                    MostCommonSoundWord = "Four"
                End If
            End If
        End If
        'DETERMINE PHONEMES
        If PhonemeOccurances(0) > 0 And PhonemeOccurances(1) > 0 And PhonemeOccurances(2) > 0 Then
            PhonemesList = IncorrectPhoneme(0) & ", " & IncorrectPhoneme(1) & ", " & IncorrectPhoneme(2)
        ElseIf PhonemeOccurances(0) > 0 And PhonemeOccurances(1) > 0 Then
            PhonemesList = IncorrectPhoneme(0) & ", " & IncorrectPhoneme(1)
        ElseIf PhonemeOccurances(0) > 0 Then
            PhonemesList = IncorrectPhoneme(0)
        Else
            PhonemesList = "N/A"
        End If
        'ADD COMMONLY INCORRECT ATTRIBUTES LABEL
        FontSize = 9 * ((MyBase.Width - 16) / 912) '(MyBase.Width / 928)
        Location.X = 640 * ((MyBase.Width - 16) / 912)
        Location.Y = 135 * ((MyBase.Height - 39) / 552)
        lblCommonlyIncorrectAttributes = New Label
        lblCommonlyIncorrectAttributes.Location = Location
        lblCommonlyIncorrectAttributes.Font = New Font("Century Gothic", FontSize, FontStyle.Bold Or FontStyle.Underline)
        lblCommonlyIncorrectAttributes.Width = 250 * (MyBase.Width / 928)
        lblCommonlyIncorrectAttributes.Height = 20 * (MyBase.Height / 552)
        lblCommonlyIncorrectAttributes.Text = "Commonly Incorrect Attributes"
        lblCommonlyIncorrectAttributes.BackColor = Color.White
        Me.Controls.Add(lblCommonlyIncorrectAttributes)
        'ADD NORMAL TO ALIEN WORDS RATIO LABEL
        Location.X = 640 * ((MyBase.Width - 16) / 912)
        Location.Y = 157 * ((MyBase.Height - 39) / 552)
        lblNormalToAlienWords = New Label
        lblNormalToAlienWords.Location = Location
        lblNormalToAlienWords.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
        lblNormalToAlienWords.Width = 250 * (MyBase.Width / 928)
        lblNormalToAlienWords.Height = 20 * (MyBase.Height / 552)
        If NormalWordsPercentage = 0 And AlienWordsPercentage = 0 Then
            lblNormalToAlienWords.Text = "Normal To Alien Words Incorrect: N/A"
        Else
            lblNormalToAlienWords.Text = "Normal To Alien Words Incorrect: " & NormalWordsPercentage & ":" & AlienWordsPercentage
        End If
        lblNormalToAlienWords.BackColor = Color.White
        Me.Controls.Add(lblNormalToAlienWords)
        'ADD NUMBER OF SOUNDS LABEL
        Location.X = 640 * ((MyBase.Width - 16) / 912)
        Location.Y = 179 * ((MyBase.Height - 39) / 552)
        lblNumberOfSounds = New Label
        lblNumberOfSounds.Location = Location
        lblNumberOfSounds.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
        lblNumberOfSounds.Width = 250 * (MyBase.Width / 928)
        lblNumberOfSounds.Height = 20 * (MyBase.Height / 552)
        lblNumberOfSounds.Text = "Number Of Sounds: " & MostCommonSoundWord
        lblNumberOfSounds.BackColor = Color.White
        Me.Controls.Add(lblNumberOfSounds)
        'ADD PHONEMES LABEL
        Location.X = 640 * ((MyBase.Width - 16) / 912)
        Location.Y = 201 * ((MyBase.Height - 39) / 552)
        lblPhonemes = New Label
        lblPhonemes.Location = Location
        lblPhonemes.Font = New Font("Century Gothic", FontSize, FontStyle.Regular)
        lblPhonemes.Width = 250 * (MyBase.Width / 928)
        lblPhonemes.Height = 20 * (MyBase.Height / 552)
        lblPhonemes.Text = "Phonemes: " & PhonemesList
        lblPhonemes.BackColor = Color.White
        Me.Controls.Add(lblPhonemes)
    End Sub
    Function GetPhonicLevelInt(ByVal PhonicLevel As String)
        'GET INTEGER CORRESPONDING TO PHONIC LEVEL
        Select Case PhonicLevel
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
    Function GetPhonicLevelString(ByVal PhonicLevel As Integer)
        'GET PHONIC LEVEL CORRESPONDING TO INTEGER
        Select Case PhonicLevel
            Case 0
                Return "Set1A"
            Case 1
                Return "Set1B"
            Case 2
                Return "Set1C"
            Case 3
                Return "Ditty"
            Case 4
                Return "Red"
            Case 5
                Return "Green"
            Case 6
                Return "Purple"
            Case 7
                Return "Pink"
            Case 8
                Return "Orange"
            Case 9
                Return "Yellow"
        End Select
    End Function
    Sub RemoveGraph()
        Dim FormGraphics As Drawing.Graphics
        FormGraphics = Me.CreateGraphics
        'REMOVE AXIS LABELS
        For i = 0 To 19
            Try
                Me.Controls.Remove(lblXAxis(i))
                Me.Controls.Remove(ptcXAxis(i))
            Catch
            End Try
        Next
        For i = 0 To 9
            Try
                Me.Controls.Remove(lblYAxis(i))
            Catch
            End Try
        Next
    End Sub
End Class