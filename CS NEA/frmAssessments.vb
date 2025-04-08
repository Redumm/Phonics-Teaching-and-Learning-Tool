Imports System.Media
Imports System.Net.Security
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports System.Xml
Imports CS_NEA.modStructures

Public Class frmAssessments
    Dim btnRegularAssessmentNumber(3) As Button
    Dim lstStudents As ListBox
    Dim lblSelectAssessmentMessage As Label
    Dim lblWord(200) As Label
    Dim lblAssessmentTitle As Label
    Dim btnSet1Groups As Button
    Dim btnSet2Groups As Button
    Dim ButtonPressed As String
    Dim lblGroupLabels(9) As Label
    Dim btnSubmit As Button
    Dim lblStudentName As Label
    Dim btnTargetWords As Button
    Dim picGroupImage(13) As PictureBox
    Dim grdTargetWords As DataGridView
    Dim picPrint As PictureBox
    Dim picReset As PictureBox
    Dim Bitmap As Bitmap
    Dim Bitmap1 As Bitmap
    Private Sub frmAssessments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SelectedSettings As Settings
        Dim Location As Point
        Dim FontSize As Single = 14 * (MyBase.Width / 928)
        Dim SelectedStudent As Student
        'LOAD SETTINGS
        FileOpen(1, "Settings.txt", OpenMode.Input)
        Input(1, SelectedSettings.Fullscreen)
        Input(1, SelectedSettings.MaxTimeToImprove)
        Input(1, SelectedSettings.TargetProgressRate)
        FileClose(1)
        If SelectedSettings.Fullscreen = True Then
            Me.WindowState = FormWindowState.Maximized
        End If
        ClearButtons(False)
        'ADD ASSESSMENTS BUTTONS
        Location.X = 30 * ((MyBase.Width - 16) / 912)
        For i = 0 To 2
            Location.Y = (125 + (i * 90)) * ((MyBase.Height - 39) / 513)
            btnRegularAssessmentNumber(i) = New Button
            btnRegularAssessmentNumber(i).Location = Location
            btnRegularAssessmentNumber(i).Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            btnRegularAssessmentNumber(i).Width = 411 * (MyBase.Width / 928)
            btnRegularAssessmentNumber(i).Height = 75 * (MyBase.Height / 552)
            btnRegularAssessmentNumber(i).Text = "Assessment " & (i + 1)
            Me.Controls.Add(btnRegularAssessmentNumber(i))
            AddHandler btnRegularAssessmentNumber(i).Click, AddressOf btnRegularAssessmentNumber_Click
        Next
        'ADD TARGET WORDS BUTTON
        Location.X = 30 * ((MyBase.Width - 16) / 912)
        Location.Y = 395 * ((MyBase.Height - 39) / 513)
        btnTargetWords = New Button
        btnTargetWords.Location = Location
        btnTargetWords.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
        btnTargetWords.Width = 411 * (MyBase.Width / 928)
        btnTargetWords.Height = 75 * (MyBase.Height / 552)
        btnTargetWords.Text = "Create Target Words"
        Me.Controls.Add(btnTargetWords)
        AddHandler btnTargetWords.Click, AddressOf btnTargetWords_Click
        'ADD STUDENT LIST BOX
        Location.X = 471 * ((MyBase.Width - 16) / 912)
        Location.Y = 125 * ((MyBase.Height - 39) / 513)
        FontSize = Math.Round(10 * MyBase.Width / 928, 0)
        lstStudents = New ListBox
        lstStudents.Location = Location
        lstStudents.Font = New Font("Ariel", FontSize, FontStyle.Regular)
        lstStudents.Width = 411 * (MyBase.Width / 928)
        lstStudents.Height = 360 * (MyBase.Height / 552)
        'LOAD STUDENT FILE
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
            'ADD STUDENT NAMES TO THE LIST BOX
            lstStudents.Items.Add(SelectedStudent.FirstName & " " & SelectedStudent.Surname)
        End While
        FileClose(1)
        Me.Controls.Add(lstStudents)
        'SET FULLSRCEEN PREFERENCE
        If SelectedSettings.Fullscreen = True Then
            Me.WindowState = FormWindowState.Maximized
        End If
        frmAssessments_Resize(sender, e)
    End Sub
    Private Sub frmAssessments_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim FontSize As Integer
        'RESIZE AND RELOCATE OBJECTS AFTER FORM RESIZE
        Try
            'TEST IF DYNAMIC OBJECTS ARE CURRENTLY ADDED INTO THE FORM
            If Me.Controls.Contains(lblAssessments) = True Then
                lblAssessments.Left = 20 * ((MyBase.Width - 16) / 912)
                lblAssessments.Top = 29 * ((MyBase.Height - 39) / 513)
                FontSize = 40 * MyBase.Width / 928
                lblAssessments.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            End If
            For i = 0 To 2
                If Me.Controls.Contains(btnRegularAssessmentNumber(i)) = True Then
                    FontSize = 14 * MyBase.Width / 928
                    btnRegularAssessmentNumber(i).Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
                    btnRegularAssessmentNumber(i).Width = 411 * (MyBase.Width / 928)
                    btnRegularAssessmentNumber(i).Height = 75 * (MyBase.Height / 552)
                    btnRegularAssessmentNumber(i).Left = 30 * ((MyBase.Width - 16) / 912)
                    btnRegularAssessmentNumber(i).Top = (125 + (i * 90)) * ((MyBase.Height - 39) / 513)
                End If
            Next
            If Me.Controls.Contains(btnTargetWords) = True Then
                FontSize = 14 * MyBase.Width / 928
                btnTargetWords.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
                btnTargetWords.Width = 411 * (MyBase.Width / 928)
                btnTargetWords.Height = 75 * (MyBase.Height / 552)
                btnTargetWords.Left = 30 * ((MyBase.Width - 16) / 912)
                btnTargetWords.Top = 395 * ((MyBase.Height - 39) / 513)
            End If
            If Me.Controls.Contains(lstStudents) = True Then
                FontSize = 10 * MyBase.Width / 928
                lstStudents.Font = New Font("Ariel", FontSize, FontStyle.Regular)
                lstStudents.Width = 411 * (MyBase.Width / 928)
                lstStudents.Height = 360 * (MyBase.Height / 552)
                lstStudents.Left = 471 * ((MyBase.Width - 16) / 912)
                lstStudents.Top = 125 * ((MyBase.Height - 39) / 513)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub btnRegularAssessmentNumber_Click(sender As Object, e As EventArgs)
        If lstStudents.SelectedItem <> "" Then
            Dim Count As Integer = 0
            Dim Location As Point
            Dim Fontsize As Integer = 14 * (MyBase.Width / 928)
            Dim Line As String
            Dim WordsPerLine As New List(Of Integer)
            Dim WordsPerLineCount As Integer
            Dim WordsPerLineIndex As Integer
            Dim Set1WordCount As Integer = 0
            Dim Set2WordCount As Integer = 0
            Dim StudentName As String = lstStudents.SelectedItem
            'GET FILE NAME TO OPEN FROM TEXT IN BUTTON
            ButtonPressed = ""
            For i = 0 To Len(sender.text) - 1
                If sender.text(i) <> " " Then
                    ButtonPressed = ButtonPressed & sender.text(i)
                End If
            Next
            'REMOVE MENU
            ClearButtons(True)
            'ADD TITLE
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            Location.Y = 10 * ((MyBase.Height - 39) / 513)
            lblSelectAssessmentMessage = New Label
            lblSelectAssessmentMessage.Location = Location
            lblSelectAssessmentMessage.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            lblSelectAssessmentMessage.Width = 210 * (MyBase.Width / 928)
            lblSelectAssessmentMessage.Height = 25 * (MyBase.Height / 552)
            lblSelectAssessmentMessage.Text = sender.text
            lblSelectAssessmentMessage.BackColor = Color.White
            Me.Controls.Add(lblSelectAssessmentMessage)
            'ADD STUDENT NAME
            Fontsize = 10 * (MyBase.Width / 928)
            Location.X = 250 * ((MyBase.Width - 16) / 912)
            Location.Y = 15 * ((MyBase.Height - 39) / 513)
            lblStudentName = New Label
            lblStudentName.Location = Location
            lblStudentName.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            lblStudentName.Width = 200 * (MyBase.Width / 928)
            lblStudentName.Height = 25 * (MyBase.Height / 552)
            lblStudentName.Text = StudentName
            lblStudentName.BackColor = Color.White
            Me.Controls.Add(lblStudentName)
            'ADD SET 1 GROUPS BUTTON
            Location.X = 643 * ((MyBase.Width - 16) / 912)
            Location.Y = 470 * ((MyBase.Height - 39) / 513)
            btnSet1Groups = New Button
            btnSet1Groups.Location = Location
            btnSet1Groups.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            btnSet1Groups.Width = 120 * (MyBase.Width / 928)
            btnSet1Groups.Height = 25 * (MyBase.Height / 552)
            btnSet1Groups.Text = "Set 1 Groups"
            Me.Controls.Add(btnSet1Groups)
            AddHandler btnSet1Groups.Click, AddressOf btnSet1Groups_Click
            'ADD SET 2 GROUPS BUTTON
            Location.X = 778 * ((MyBase.Width - 16) / 912)
            btnSet2Groups = New Button
            btnSet2Groups.Location = Location
            btnSet2Groups.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            btnSet2Groups.Width = 120 * (MyBase.Width / 928)
            btnSet2Groups.Height = 25 * (MyBase.Height / 552)
            btnSet2Groups.Text = "Set 2 Groups"
            Me.Controls.Add(btnSet2Groups)
            AddHandler btnSet2Groups.Click, AddressOf btnSet2Groups_Click
            'ADD SUBMIT BUTTON
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            btnSubmit = New Button
            btnSubmit.Location = Location
            btnSubmit.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            btnSubmit.Width = 280 * (MyBase.Width / 928)
            btnSubmit.Height = 25 * (MyBase.Height / 552)
            btnSubmit.Text = "Submit Assessment"
            Me.Controls.Add(btnSubmit)
            AddHandler btnSubmit.Click, AddressOf btnSubmit_Click
            'ADD PICTURES
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            For i = 0 To 13
                picGroupImage(i) = New PictureBox
                'LOAD IMAGE FROM FILE BASED UPON WHICH NUMBER IMAGE IT IS
                Select Case i
                    Case 0
                        Location.Y = 170 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Normal.png")
                    Case 1
                        Location.Y = 245 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Normal.png")
                    Case 2
                        Location.Y = 270 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Alien.png")
                    Case 3
                        Location.Y = 320 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Normal.png")
                    Case 4
                        Location.Y = 345 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Alien.png")
                    Case 5
                        Location.Y = 395 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("FredInYourHead.png")
                    Case 6
                        Location.Y = 95 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Normal.png")
                    Case 7
                        Location.Y = 120 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Alien.png")
                    Case 8
                        Location.Y = 145 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("FredInYourHead.png")
                    Case 9
                        Location.Y = 220 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Normal.png")
                    Case 10
                        Location.Y = 245 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Alien.png")
                    Case 11
                        Location.Y = 270 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("FredInYourHead.png")
                    Case 12
                        Location.Y = 320 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("Alien.png")
                    Case 13
                        Location.Y = 345 * ((MyBase.Height - 39) / 513)
                        picGroupImage(i).Image = Image.FromFile("FredInYourHead.png")
                End Select
                picGroupImage(i).Location = Location
                picGroupImage(i).SizeMode = PictureBoxSizeMode.StretchImage
                picGroupImage(i).Width = 24 * (MyBase.Width / 928)
                picGroupImage(i).Height = 24 * (MyBase.Width / 928)
                picGroupImage(i).BringToFront()
                'ONLY SHOW SET 1 GROUPS IMAGES
                If i < 6 Then
                    Me.Controls.Add(picGroupImage(i))
                End If
            Next
            'ADD GROUP LABELS
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            For i = 0 To 8
                lblGroupLabels(i) = New Label
                Select Case i
                    Case 0
                        lblGroupLabels(i).Text = "Set 1 Sounds Groups A or B"
                        Location.Y = 50 * ((MyBase.Height - 39) / 513)
                    Case 1
                        lblGroupLabels(i).Text = "Set 1 Sounds Group C"
                        Location.Y = 100 * ((MyBase.Height - 39) / 513)
                    Case 2
                        lblGroupLabels(i).Text = "Ditty Group"
                        Location.Y = 150 * ((MyBase.Height - 39) / 513)
                    Case 3
                        lblGroupLabels(i).Text = "Red Group"
                        Location.Y = 200 * ((MyBase.Height - 39) / 513)
                    Case 4
                        lblGroupLabels(i).Text = "Green Group"
                        Location.Y = 300 * ((MyBase.Height - 39) / 513)
                    Case 5
                        lblGroupLabels(i).Text = "Purple Group"
                        Location.Y = 375 * ((MyBase.Height - 39) / 513)
                    Case 6
                        lblGroupLabels(i).Text = "Pink Group"
                        Location.Y = 50 * ((MyBase.Height - 39) / 513)
                    Case 7
                        lblGroupLabels(i).Text = "Orange Group"
                        Location.Y = 175 * ((MyBase.Height - 39) / 513)
                    Case 8
                        lblGroupLabels(i).Text = "Yellow Group"
                        Location.Y = 300 * ((MyBase.Height - 39) / 513)
                End Select
                lblGroupLabels(i).Location = Location
                lblGroupLabels(i).Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
                lblGroupLabels(i).Width = 250 * (MyBase.Width / 928)
                lblGroupLabels(i).Height = 25 * (MyBase.Height / 552)
                lblGroupLabels(i).BackColor = Color.White
                lblGroupLabels(i).SendToBack()
                'ONLY SHOW SET 1 GROUP LABELS
                If i < 6 Then
                    Me.Controls.Add(lblGroupLabels(i))
                End If
            Next
            'CALCULATE WORDS PER LINE IN EACH LINE OF THE TEXT FILE
            FileOpen(1, ButtonPressed & ".txt", OpenMode.Input)
            While Not EOF(1)
                WordsPerLineCount = 0
                Line = LineInput(1)
                'COUNT WORDS IN LINE BY THE NUMBER OF COMMAS IN THE LINE
                For i = 0 To Len(Line) - 1
                    If Line(i) = "," Then
                        WordsPerLineCount += 1
                    End If
                Next
                WordsPerLine.Add(WordsPerLineCount + 1)
                If WordsPerLine.Count <= 9 Then
                    Set1WordCount += WordsPerLineCount + 1
                Else
                    Set2WordCount += WordsPerLineCount + 1
                End If
                WordsPerLineCount = 0
            End While
            FileClose(1)
            'ADD ASSESSMENT WORDS
            Location.X = 60 * ((MyBase.Width - 16) / 912)
            Location.Y = 75 * ((MyBase.Height - 39) / 513)
            FileOpen(1, ButtonPressed & ".txt", OpenMode.Input)
            WordsPerLineCount = 1
            WordsPerLineIndex = 0
            While Not EOF(1)
                lblWord(Count) = New Label
                Input(1, lblWord(Count).Text)
                lblWord(Count).Font = New Font("Century Gothic", Fontsize, FontStyle.Regular)
                lblWord(Count).Location = Location
                lblWord(Count).Width = (12 + 9 * Len(lblWord(Count).Text)) * (MyBase.Width / 928)
                lblWord(Count).Height = 20 * (MyBase.Height / 552)
                lblWord(Count).BackColor = Color.White
                If Count < Set1WordCount Then
                    Me.Controls.Add(lblWord(Count))
                End If
                AddHandler lblWord(Count).Click, AddressOf lblWord_Click
                If WordsPerLineCount = WordsPerLine(WordsPerLineIndex) Then
                    'CHANGE Y POSITION TO NEXT LINE IF LINE COMPLETE
                    WordsPerLineCount = 1
                    WordsPerLineIndex += 1
                    Location.X = 60 * ((MyBase.Width - 16) / 912)
                    Location.Y = GetLineYPosition(Location, WordsPerLineIndex)
                    Count += 1
                Else
                    'CHANGE X POSITION IF LINE NOT COMPLETE
                    Location.X += (20 + 12 * Len(lblWord(Count).Text)) * (MyBase.Width / 928)
                    Count += 1
                    WordsPerLineCount += 1
                End If
                If Count = Set1WordCount Then
                    'GO TO TOP ONCE SET 1 WORDS ARE ALL CREATED
                    Location.X = 60 * ((MyBase.Width - 16) / 912)
                    Location.Y = 75 * ((MyBase.Height - 39) / 513)
                End If
            End While
            FileClose(1)
        Else
            'DISPLAY MESSAGE IF NO PUPIL IS SELECTED
            MessageBox.Show("Please select a pupil")
        End If
    End Sub
    Sub GetWordsPerLine(ByRef WordsPerLineCount As Integer, ByRef WordsPerLine As List(Of Integer))
        Dim Line As String
        'CALCULATE WORDS PER LINE IN EACH LINE OF THE TEXT FILE
        FileOpen(1, ButtonPressed & ".txt", OpenMode.Input)
        While Not EOF(1)
            WordsPerLineCount = 0
            Line = LineInput(1)
            'COUNT WORDS IN LINE BY THE NUMBER OF COMMAS IN THE LINE
            For i = 0 To Len(Line) - 1
                If Line(i) = "," Then
                    WordsPerLineCount += 1
                End If
            Next
            WordsPerLine.Add(WordsPerLineCount + 1)
            WordsPerLineCount = 0
        End While
        FileClose(1)
        'BYREF MEANS WORDSPERLINE VARIABLE IS CHANGED IN CALLING SUBROUTINE
    End Sub
    Sub lblWord_Click(sender As Object, e As EventArgs)
        'TOGGLE HIGHLIGHT OF WORD CLICKED
        If sender.BackColor = Color.White Then
            sender.BackColor = Color.LightGreen
        Else
            sender.BackColor = Color.White
        End If
    End Sub
    Sub btnSet1Groups_Click(sender As Object, e As EventArgs)
        Dim Set1WordCount As Integer
        Dim Set2WordCount As Integer
        Dim WordsPerLineCount As Integer
        Dim WordsPerLine As New List(Of Integer)
        'CALCULATE NUMBER OF WORDS IN EACH SET
        GetWordsPerLine(WordsPerLineCount, WordsPerLine)
        For i = 0 To WordsPerLine.Count - 1
            If i < 9 Then
                Set1WordCount += WordsPerLine(i)
            Else
                Set2WordCount += WordsPerLine(i)
            End If
        Next
        'REMOVE CONTROLS OF SET 2 WORDS AND ADD CONTROLS TO SET 1 WORDS
        For i = 0 To Set1WordCount + Set2WordCount
            If i < Set1WordCount Then
                Me.Controls.Add(lblWord(i))
            Else
                Me.Controls.Remove(lblWord(i))
            End If
        Next
        'ADD / REMOVE IMAGES
        For i = 0 To 13
            If i < 6 Then
                Me.Controls.Add(picGroupImage(i))
            Else
                Me.Controls.Remove(picGroupImage(i))
            End If
        Next
        'ADD / REMOVE LABELS
        For i = 0 To 8
            If i < 6 Then
                Me.Controls.Add(lblGroupLabels(i))
            Else
                Me.Controls.Remove(lblGroupLabels(i))
            End If
        Next
    End Sub
    Sub btnSet2Groups_Click(sender As Object, e As EventArgs)
        Dim Set1WordCount As Integer
        Dim Set2WordCount As Integer
        Dim WordsPerLineCount As Integer
        Dim WordsPerLine As New List(Of Integer)
        'CALCULATE NUMBER OF WORDS IN EACH SET
        GetWordsPerLine(WordsPerLineCount, WordsPerLine)
        For i = 0 To WordsPerLine.Count - 1
            If i < 9 Then
                Set1WordCount += WordsPerLine(i)
            Else
                Set2WordCount += WordsPerLine(i)
            End If
        Next
        'REMOVE CONTROLS OF SET 1 WORDS AND ADD CONTROLS TO SET 2 WORDS
        For i = 0 To Set1WordCount + Set2WordCount
            If i < Set1WordCount Then
                Me.Controls.Remove(lblWord(i))
            Else
                Me.Controls.Add(lblWord(i))
            End If
        Next
        'ADD / REMOVE IMAGES
        For i = 0 To 13
            If i < 6 Then
                Me.Controls.Remove(picGroupImage(i))
            Else
                Me.Controls.Add(picGroupImage(i))
            End If
        Next
        'ADD / REMOVE LABELS
        For i = 0 To 8
            If i < 6 Then
                Me.Controls.Remove(lblGroupLabels(i))
            Else
                Me.Controls.Add(lblGroupLabels(i))
            End If
        Next
    End Sub
    Function GetLineYPosition(ByRef Location As Point, ByRef WordsPerLineIndex As Integer)
        Dim SpaceFree As Boolean = True
        Dim SizeEstimate As Integer = Math.Round(Location.Y + (25 * ((MyBase.Height - 39) / 513)), 0)
        'DETERMINE IF GROUP NAME LABLE IS ALREADY ON THE NEXT LINE
        For i = 0 To 8
            If SizeEstimate * 0.98 < lblGroupLabels(i).Top And SizeEstimate * 1.02 > lblGroupLabels(i).Top Then
                If (i < 6 And WordsPerLineIndex < 9) Or (i >= 6 And WordsPerLineIndex >= 9) Then
                    SpaceFree = False
                End If
            End If
        Next
        If SpaceFree = True Then
            'IF NO GROUP LABEL, RETURN THE Y COORDINATE OF THE NEXT LINE
            Return Location.Y + (25 * ((MyBase.Height - 39) / 513))
        Else
            'IF GROUP LABEL ON NEXT LINE, RETURN THE Y COORDINATE OF THE LINE AFTER
            Return Location.Y + (50 * ((MyBase.Height - 39) / 513))
        End If
    End Function
    Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim WordsPerLineCount As Integer
        Dim WordsPerLine As New List(Of Integer)
        Dim TotalWords As Integer
        Dim LineIndex As Integer = 0
        Dim WordsCorrect As Integer = 0
        Dim ContinueChecking As Boolean = True
        Dim IncorrectWordList As New List(Of WordAttribute)
        Dim StudentID As Integer
        Dim PhonicLevel As String
        Dim SelectedStudentAchievement As StudentAchievement
        Dim StudentAchievementList As New List(Of StudentAchievement)
        'GET WORDS PER LINE LIST
        GetWordsPerLine(WordsPerLineCount, WordsPerLine)
        'GET TOTAL WORD COUNT
        For i = 0 To WordsPerLine.Count - 1
            TotalWords += WordsPerLine(i)
        Next
        WordsPerLineCount = 0
        For i = 0 To TotalWords - 1
            If ContinueChecking = True Then
                'CHECK IF WORD HAS BEEN HIGHLIGHTED
                If lblWord(i).BackColor = Color.LightGreen Then
                    WordsCorrect += 1
                Else
                    'DETERMINE INCORRECT WORD ATTRIBUTES
                    IncorrectWordList.Add(GetIncorrectWordAttributes(lblWord(i).Text, LineIndex))
                End If
                WordsPerLineCount += 1
                'CHECK HOW MANY WORDS ARE CORRECT AT THE END OF THE GROUP
                If WordsPerLineCount = WordsPerLine(LineIndex) Then
                    Select Case CheckIfContinue(LineIndex, WordsCorrect, WordsPerLine)
                        Case "KeepWordsCorrect"
                            WordsPerLineCount = 0
                            LineIndex += 1
                        Case "GroupPassed"
                            LineIndex += 1
                            WordsCorrect = 0
                            WordsPerLineCount = 0
                            If i = TotalWords - 1 Then
                                PhonicLevel = "Yellow"
                            End If
                        Case "GroupFailed"
                            ContinueChecking = False
                            PhonicLevel = GetPhonicLevel(LineIndex)
                    End Select
                End If
            End If
        Next
        MessageBox.Show(lblStudentName.Text & " achieved the phonic level " & PhonicLevel & "!")
        'UPDATE PROGRESSCHANGE FILE
        StudentID = GetStudentID()
        FileOpen(1, "ProgressChange.txt", OpenMode.Append)
        Write(1, StudentID)
        Write(1, PhonicLevel)
        WriteLine(1, Today)
        FileClose(1)
        'UPDATE STUDENTACHIEVEMENT FILE
        FileOpen(1, "StudentAchievement.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentAchievement.StudentID)
            Input(1, SelectedStudentAchievement.PhonicLevel)
            Input(1, SelectedStudentAchievement.RateOfProgress)
            If SelectedStudentAchievement.StudentID = StudentID Then
                SelectedStudentAchievement.PhonicLevel = PhonicLevel
            End If
            StudentAchievementList.Add(SelectedStudentAchievement)
        End While
        FileClose(1)
        Kill("StudentAchievement.txt")
        FileOpen(1, "StudentAchievement.txt", OpenMode.Output)
        For i = 0 To StudentAchievementList.Count - 1
            Write(1, StudentAchievementList(i).StudentID)
            Write(1, StudentAchievementList(i).PhonicLevel)
            WriteLine(1, StudentAchievementList(i).RateOfProgress)
        Next
        FileClose(1)
        'ANALYISE INCORRECT WORDS
        For i = 0 To IncorrectWordList.Count - 1
            'ADD TYPE TO STUDENTWEAKNESS FILE
            If IncorrectWordList(i).AlienWord = True Then
                AddStudentWeakness(StudentID, "Type", "Alien")
            Else
                If CheckIfWordIsPhoneme(IncorrectWordList(i).Word) = False Then
                    AddStudentWeakness(StudentID, "Type", "Normal")
                End If
            End If
            'ADD SOUNDS TO STUDENTWEAKNESS FILE
            Select Case IncorrectWordList(i).NumberOfSounds
                Case 2
                    AddStudentWeakness(StudentID, "Sound", "Two")
                Case 3
                    AddStudentWeakness(StudentID, "Sound", "Three")
                Case 4
                    AddStudentWeakness(StudentID, "Sound", "Four")
                Case 5
                    AddStudentWeakness(StudentID, "Sound", "Five")
            End Select
            'ADD DIGRAPHS TO STUDENTWEAKNESS FILE
            Select Case IncorrectWordList(i).NumberOfDigraphs
                Case 1
                    AddStudentWeakness(StudentID, "Digraph", "One")
                Case 2
                    AddStudentWeakness(StudentID, "Digraph", "Two")
            End Select
            'ADD TRIGRAPHS TO STUDENTWEAKNESS FILE
            If IncorrectWordList(i).NumberOfTrigraphs = 1 Then
                AddStudentWeakness(StudentID, "Trigraph", "One")
            End If
            'ADD WORD TO STUDENTWEAKNESS FILE
            If CheckIfWordIsPhoneme(IncorrectWordList(i).Word) = False Then
                AddStudentWeakness(StudentID, "Word", IncorrectWordList(i).Word)
            End If
            'ADD PHONEMES TO STUDENTWEAKNESS FILE
            For x = 0 To IncorrectWordList(i).ActualSounds.Count - 1
                AddStudentWeakness(StudentID, "Phoneme", IncorrectWordList(i).ActualSounds(x))
            Next
        Next
    End Sub
    Function CheckIfWordIsPhoneme(ByRef SelectedWord As String)
        Dim InPhonemeFile As Boolean = False
        Dim SelectedPhoneme As String
        'CHECK WORD AGAINST EVERY PHONEME IN THE SOUND FILE
        FileOpen(1, "Sound.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedPhoneme)
            If SelectedPhoneme = SelectedWord Then
                'SET VARIABLE TO TRUE IF FOUND THE WORD IN THE SOUND FILE
                InPhonemeFile = True
            End If
        End While
        FileClose(1)
        Return InPhonemeFile
    End Function
    Sub AddStudentWeakness(ByRef StudentID As Integer, ByRef AttributeType As String, ByRef Attribute As String)
        Dim SelectedStudentWeakness As StudentWeakness
        Dim StudentWeaknessList As New List(Of StudentWeakness)
        Dim InstancesExist As Boolean = False
        'CHECK IF PREVIOUS INSTANCES EXIST
        FileOpen(1, "StudentWeakness.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentWeakness.StudentID)
            Input(1, SelectedStudentWeakness.AttributeType)
            Input(1, SelectedStudentWeakness.Attribute)
            Input(1, SelectedStudentWeakness.Instances)
            If SelectedStudentWeakness.StudentID = StudentID And SelectedStudentWeakness.AttributeType = AttributeType And SelectedStudentWeakness.Attribute = Attribute Then
                SelectedStudentWeakness.Instances += 1
                InstancesExist = True
            End If
            StudentWeaknessList.Add(SelectedStudentWeakness)
        End While
        FileClose(1)
        'ADD INSTANCE IF NO PREVIOUS INSTANCE EXISTS
        If InstancesExist = False Then
            SelectedStudentWeakness.StudentID = StudentID
            SelectedStudentWeakness.AttributeType = AttributeType
            SelectedStudentWeakness.Attribute = Attribute
            SelectedStudentWeakness.Instances = 1
            StudentWeaknessList.Add(SelectedStudentWeakness)
        End If
        'REWRITE STUDENTWEAKNESS FILE
        Kill("StudentWeakness.txt")
        FileOpen(1, "StudentWeakness.txt", OpenMode.Output)
        For i = 0 To StudentWeaknessList.Count - 1
            Write(1, StudentWeaknessList(i).StudentID)
            Write(1, StudentWeaknessList(i).AttributeType)
            Write(1, StudentWeaknessList(i).Attribute)
            WriteLine(1, StudentWeaknessList(i).Instances)
        Next
        FileClose(1)
    End Sub
    Function GetPhonicLevel(ByRef LineIndex As Integer)
        'GET PHONIC LEVEL CORRESPONDING TO LINE NUMBER REACHED
        Select Case LineIndex
            Case 0
                Return "Set1A"
            Case 1
                Return "Set1B"
            Case 2
                Return "Set1C"
            Case 5
                Return "Ditty"
            Case 7
                Return "Red"
            Case 8
                Return "Green"
            Case 12
                Return "Purple"
            Case 16
                Return "Pink"
            Case 18
                Return "Orange"
        End Select
    End Function
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
    Function CheckIfContinue(ByRef LineIndex As Integer, ByRef WordsCorrect As Integer, ByRef WordsPerLine As List(Of Integer))
        'DETERMINE IF NUMBER OF WORDS CORRECT IN GROUP IS ABOVE OR EQUAL TO 90%
        Select Case LineIndex
            Case 0
                If WordsCorrect / WordsPerLine(0) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 1
                If WordsCorrect / WordsPerLine(1) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 2
                If WordsCorrect / WordsPerLine(2) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 5
                If WordsCorrect / (WordsPerLine(3) + WordsPerLine(4) + WordsPerLine(5)) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 7
                If WordsCorrect / (WordsPerLine(6) + WordsPerLine(7)) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 8
                If WordsCorrect / WordsPerLine(8) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 12
                If WordsCorrect / (WordsPerLine(9) + WordsPerLine(10) + WordsPerLine(11) + WordsPerLine(12)) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 16
                If WordsCorrect / (WordsPerLine(13) + WordsPerLine(14) + WordsPerLine(15) + WordsPerLine(16)) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 18
                If WordsCorrect / (WordsPerLine(17) + WordsPerLine(18)) >= 0.9 Then
                    Return "GroupPassed"
                Else
                    Return "GroupFailed"
                End If
            Case 3, 4, 6, 9, 10, 11, 13, 14, 15, 17
                'IF NOT THE LAST LINE OF THE GROUP, KEEP A TRACK OF THE WORDS CORRECT IN THE GROUP FROM PREVIOUS LINES
                Return "KeepWordsCorrect"
        End Select
    End Function
    Function GetIncorrectWordAttributes(ByRef lblWordText As String, ByRef LineIndex As Integer)
        Dim IncorrectWord As WordAttribute
        Dim SoundFileLine As Integer = 0
        Dim SoundFileSound As String
        Dim Skip As Integer = 0
        Dim SoundList As New List(Of String)
        Dim SoundFound As Boolean = False
        'REMOVE DASHES BETWEEN LETTERS FROM WORDS IN THE SET 1 SOUNDS GROUP C LEVEL
        If LineIndex <> 1 Then
            IncorrectWord.Word = lblWordText
        Else
            IncorrectWord.Word = lblWordText(0) & lblWordText(2) & lblWordText(4)
        End If
        'DETERMINE THE NATURE OF THE WORD BASED ON THE LINE NUMBER
        Select Case LineIndex
            Case 0, 1, 2, 3, 4, 6, 8, 9, 10, 12, 13, 14, 16, 18
                IncorrectWord.AlienWord = False
            Case 5, 7, 11, 15, 17
                IncorrectWord.AlienWord = True
        End Select
        'DETERMINE THE PHONEMES IN THE WORD
        For x = 0 To IncorrectWord.Word.Length - 1
            If Skip = 0 Then
                SoundFileLine = 0
                SoundFound = False
                FileOpen(1, "Sound.txt", OpenMode.Input)
                While Not EOF(1)
                    Input(1, SoundFileSound)
                    If SoundFound = False Then
                        Select Case SoundFileLine
                            'DETERMINE LENGTH OF PHONEME BY THE LINE IT WAS ON IN THE SOUND FILE
                            Case 0
                                'LINE 0 FOR 3 LETTER PHONEMES
                                If IncorrectWord.Word.Length - 1 >= x + 2 Then
                                    If IncorrectWord.Word(x) = SoundFileSound(0) And IncorrectWord.Word(x + 1) = SoundFileSound(1) And IncorrectWord.Word(x + 2) = SoundFileSound(2) Then
                                        'IF PHONEME MATCHES, ADD DATA TO STRUCTURES AND LISTS
                                        IncorrectWord.NumberOfTrigraphs += 1
                                        IncorrectWord.NumberOfSounds += 1
                                        SoundList.Add(SoundFileSound)
                                        'SKIP THE NEXT TWO LETTERS IN THE WORD AS THEY ARE PART OF THIS PHONEME
                                        Skip = 2
                                        SoundFound = True
                                    End If
                                End If
                            Case 1
                                'LINE 1 FOR 2 LETTER PHONEMES
                                If IncorrectWord.Word.Length - 1 >= x + 1 Then
                                    If IncorrectWord.Word(x) = SoundFileSound(0) And IncorrectWord.Word(x + 1) = SoundFileSound(1) Then
                                        'IF PHONEME MATCHES, ADD DATA TO STRUCTURES AND LISTS
                                        IncorrectWord.NumberOfDigraphs += 1
                                        IncorrectWord.NumberOfSounds += 1
                                        SoundList.Add(SoundFileSound)
                                        'SKIP THE NEXT LETTER IN THE WORD AS IT IS PART OF THIS PHONEME
                                        Skip = 1
                                        SoundFound = True
                                    End If
                                End If
                            Case 2
                                'LINE 2 FOR SINGLE LETTER PHONEMES
                                If IncorrectWord.Word(x) = SoundFileSound Then
                                    'IF PHONEME MATCHES, ADD DATA TO STRUCTURES AND LISTS
                                    IncorrectWord.NumberOfSounds += 1
                                    SoundList.Add(SoundFileSound)
                                    SoundFound = True
                                End If
                        End Select
                        'INCREMENTS LINE NUMBER IF AT THE END OF A LINE IN THE SOUND FILE
                        If SoundFileSound = "air" Then
                            SoundFileLine = 1
                        ElseIf SoundFileSound = "zz" Then
                            SoundFileLine = 2
                        End If
                    End If
                End While
                FileClose(1)
            Else
                'REDUCE VARIABLE AFTER LETTER SKIPPED
                Skip -= 1
            End If
        Next
        IncorrectWord.ActualSounds = SoundList
        'RETURN THE STRUCTURE CONTAINING THE ATTRIBUTES FOR THE WORD
        Return IncorrectWord
    End Function
    Sub btnTargetWords_Click(sender As Object, e As EventArgs)
        If lstStudents.SelectedItem <> "" Then
            Dim Count As Integer = 0
            Dim Location As Point
            Dim Fontsize As Integer = 14 * (MyBase.Width / 928)
            Dim StudentName As String = lstStudents.SelectedItem
            'REMOVE MENU
            ClearButtons(True)
            Me.BackgroundImage = Image.FromFile("Background.png")
            'ADD TITLE
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            Location.Y = 10 * ((MyBase.Height - 39) / 513)
            lblSelectAssessmentMessage = New Label
            lblSelectAssessmentMessage.Location = Location
            lblSelectAssessmentMessage.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            lblSelectAssessmentMessage.Width = 210 * (MyBase.Width / 928)
            lblSelectAssessmentMessage.Height = 25 * (MyBase.Height / 552)
            lblSelectAssessmentMessage.Text = "Target Words"
            lblSelectAssessmentMessage.BackColor = Color.White
            Me.Controls.Add(lblSelectAssessmentMessage)
            'ADD STUDENT NAME
            Fontsize = 10 * (MyBase.Width / 928)
            Location.X = 250 * ((MyBase.Width - 16) / 912)
            Location.Y = 15 * ((MyBase.Height - 39) / 513)
            lblStudentName = New Label
            lblStudentName.Location = Location
            lblStudentName.Font = New Font("Century Gothic", Fontsize, FontStyle.Bold)
            lblStudentName.Width = 200 * (MyBase.Width / 928)
            lblStudentName.Height = 25 * (MyBase.Height / 552)
            lblStudentName.Text = StudentName
            lblStudentName.BackColor = Color.White
            Me.Controls.Add(lblStudentName)
            'ADD PRINT BUTTON
            Location.X = 30 * ((MyBase.Width - 16) / 912)
            Location.Y = 453 * ((MyBase.Height - 39) / 513)
            picPrint = New PictureBox
            picPrint.Image = Image.FromFile("Print.png")
            picPrint.SizeMode = PictureBoxSizeMode.StretchImage
            picPrint.BackColor = Color.Transparent
            picPrint.Location = Location
            picPrint.Width = 47 * (MyBase.Height / 552)
            picPrint.Height = 47 * (MyBase.Height / 552)
            Me.Controls.Add(picPrint)
            AddHandler picPrint.Click, AddressOf picPrint_Click
            'ADD RESET BUTTON
            Location.X = 107 * ((MyBase.Width - 16) / 912)
            Location.Y = 453 * ((MyBase.Height - 39) / 513)
            picReset = New PictureBox
            picReset.Image = Image.FromFile("Reset.png")
            picReset.SizeMode = PictureBoxSizeMode.StretchImage
            picReset.BackColor = Color.Transparent
            picReset.Location = Location
            picReset.Width = 47 * (MyBase.Height / 552)
            picReset.Height = 47 * (MyBase.Height / 552)
            Me.Controls.Add(picReset)
            AddHandler picReset.Click, AddressOf picReset_Click
            'CREATE THE TARGET WORDS
            GetTargetWords()
        Else
            'DISPLAY MESSAGE IF NO PUPIL IS SELECTED
            MessageBox.Show("Please select a pupil")
        End If
    End Sub
    Sub GetTargetWords()
        Dim Location As Point
        Dim Fontsize As Integer = 14 * (MyBase.Width / 928)
        Dim StudentID As Integer
        Dim StudentWeaknessList As New List(Of StudentWeakness)
        Dim PhonemeList As New List(Of String)
        Dim WordList As New List(Of String)
        Dim NewWordList As New List(Of String)
        Dim AttributeList As New List(Of String)
        Dim InstanceList As New List(Of Integer)
        Dim SelectedStudentAchievement As StudentAchievement
        Dim PhonicLevel As Integer
        'READ STUDENT WEAKNESS FILE
        FileOpen(1, "StudentAchievement.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentAchievement.StudentID)
            Input(1, SelectedStudentAchievement.PhonicLevel)
            Input(1, SelectedStudentAchievement.RateOfProgress)
            If SelectedStudentAchievement.StudentID = StudentID Then
                PhonicLevel = GetPhonicLevelInt(SelectedStudentAchievement.PhonicLevel)
            End If
        End While
        FileClose(1)
        'GET PHONEMES WHICH THE STUDENT PREVIOUSLY GOT WRONG
        For i = 0 To StudentWeaknessList.Count - 1
            If StudentWeaknessList(i).AttributeType = "Phoneme" Then
                AttributeList.Add(StudentWeaknessList(i).Attribute)
                InstanceList.Add(StudentWeaknessList(i).Instances)
            End If
        Next
        PhonemeList = GetAttributeList(AttributeList, InstanceList, 2)
        'GET WORDS WHICH THE STUDENT PREVIOUSLY GOT WRONG
        AttributeList.Clear()
        InstanceList.Clear()
        For i = 0 To StudentWeaknessList.Count - 1
            If StudentWeaknessList(i).AttributeType = "Word" Then
                AttributeList.Add(StudentWeaknessList(i).Attribute)
                InstanceList.Add(StudentWeaknessList(i).Instances)
            End If
        Next
        WordList = GetAttributeList(AttributeList, InstanceList, 2)
        'GET NEW WORDS FROM CUSTOM ASSESSMENT FILE
        NewWordList = GetNewWords(StudentID, PhonicLevel)
        'ADD THE TARGET WORDS GRID
        Me.Controls.Remove(grdTargetWords)
        Location.X = 30 * ((MyBase.Width - 16) / 912)
        Location.Y = 45 * ((MyBase.Height - 39) / 513)
        grdTargetWords = New DataGridView
        grdTargetWords.Rows.Clear()
        grdTargetWords.Columns.Clear()
        grdTargetWords.Location = Location
        grdTargetWords.Width = 597 * (MyBase.Width / 928)
        grdTargetWords.Height = 422 * (MyBase.Width / 928)
        'ADD THE COLUMNS AND ROWS TO THE TABLE
        grdTargetWords.Columns.Add("Column1", "Column1")
        grdTargetWords.Columns.Add("Column2", "Column2")
        'ADD TWO PHONEMES
        grdTargetWords.Rows.Add(PhonemeList(0), PhonemeList(1))
        'ADD TWO WORDS THE STUDENT PREVIOUSLY GOT WRONG
        grdTargetWords.Rows.Add(WordList(0), WordList(1))
        'ADD FOUR NEW WORDS
        grdTargetWords.Rows.Add(NewWordList(0), NewWordList(1))
        grdTargetWords.Rows.Add(NewWordList(2), NewWordList(3))
        'SIZE THE GRID
        grdTargetWords.Columns(0).Width = grdTargetWords.Width / 2
        grdTargetWords.Columns(1).Width = grdTargetWords.Width / 2
        grdTargetWords.Rows(0).Height = grdTargetWords.Height / 4
        grdTargetWords.Rows(1).Height = grdTargetWords.Height / 4
        grdTargetWords.Rows(2).Height = grdTargetWords.Height / 4
        grdTargetWords.Rows(3).Height = grdTargetWords.Height / 4
        'REMOVE HEADERS, SCROLLBAR AND MAKE THE GRID READ ONLY
        grdTargetWords.RowHeadersVisible = False
        grdTargetWords.ColumnHeadersVisible = False
        grdTargetWords.ScrollBars = ScrollBars.None
        grdTargetWords.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Fontsize = 20 * MyBase.Width / 928
        grdTargetWords.RowsDefaultCellStyle.Font = New Font("Century Gothic", Fontsize, FontStyle.Regular)
        grdTargetWords.DefaultCellStyle.SelectionBackColor = Color.White
        grdTargetWords.DefaultCellStyle.SelectionForeColor = Color.Black
        grdTargetWords.ReadOnly = True
        Me.Controls.Add(grdTargetWords)
    End Sub
    Private Sub picPrint_Click(sender As Object, e As EventArgs)
        'RESIZE TARGET WORDS GRID TO FIT PAGE
        Dim x As Integer = PrintDocument1.PrinterSettings.DefaultPageSettings.PrintableArea.Width - 10
        Dim y As Integer = PrintDocument1.PrinterSettings.DefaultPageSettings.PrintableArea.Height - 20
        Dim g As Graphics
        'CREATE A BITMAP WITH THE GRID ON IT
        Bitmap = New Bitmap(Me.grdTargetWords.Width, Me.grdTargetWords.Height)
        grdTargetWords.DrawToBitmap(Bitmap, New Rectangle(0, 0, Me.grdTargetWords.Width, Me.grdTargetWords.Height))
        Bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Bitmap = New Bitmap(Bitmap, New Size(x, y))
        'CREATE A BITMAP OF THE STUDENT'S NAME
        Bitmap1 = New Bitmap(Me.lblStudentName.Width, Me.lblStudentName.Height)
        lblStudentName.DrawToBitmap(Bitmap1, New Rectangle(0, 0, Me.lblStudentName.Width, Me.lblStudentName.Height))
        Bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Bitmap1 = New Bitmap(Bitmap1, New Size(lblStudentName.Height * ((y / 4) / lblStudentName.Width), y / 4))
        'ADD THE STUDENT'S NAME TO THE BITMAP OF THE GRID
        Bitmap1.MakeTransparent(Color.White)
        g = Graphics.FromImage(Bitmap)
        For vertical = 0 To 1
            For horizontal = 0 To 3
                g.DrawImage(Bitmap1, New Point(0 + (horizontal * x / 4), 10 + (vertical * y / 2)))
            Next
        Next
        'SHOW THE PRINT PREVIEW DIALOGUE
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub
    Private Sub PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'PRINT THE GRID
        e.Graphics.DrawImage(Bitmap, 0, 0)
    End Sub
    Private Sub picReset_Click(sender As Object, e As EventArgs)
        'RECREATE THE GRID OF TARGET WORDS
        GetTargetWords()
    End Sub
    Function GetNewWords(ByRef StudentID As Integer, ByRef PhonicLevel As Integer)
        Dim StudentWeaknessList As New List(Of StudentWeakness)
        Dim Random As System.Random = New System.Random()
        Dim NumberCount As Integer
        Dim Count As Integer
        Dim SelectedCount As Integer
        Dim SelectedWord As String
        Dim TempString As String
        StudentWeaknessList = GetStudentWeaknessList(StudentID)
        Dim AlienWordCount As Integer
        Dim NormalWordCount As Integer
        Dim TwoSoundWordsCount As Integer
        Dim ThreeSoundWordsCount As Integer
        Dim FourSoundWordsCount As Integer
        Dim IdealType As String
        Dim IdealSound As String
        Dim CurrentType As String
        Dim CurrentSound As String
        Dim OtherAttributesCount As Integer
        Dim SelectedWordAttributes As WordAttribute
        Dim NewWordList As New List(Of String)
        Dim InNewWordList As Boolean
        Dim AppropriateForLevel As Boolean = False
        Dim HighAccuracy As Boolean = True
        Dim Iterations As Integer = 0
        'GET ALIEN WORDS AND NORMAL WORDS AND SOUNDS COUNT
        For i = 0 To StudentWeaknessList.Count - 1
            If StudentWeaknessList(i).AttributeType = "Type" And StudentWeaknessList(i).Attribute = "Alien" Then
                AlienWordCount = StudentWeaknessList(i).Instances
            ElseIf StudentWeaknessList(i).AttributeType = "Type" And StudentWeaknessList(i).Attribute = "Normal" Then
                NormalWordCount = StudentWeaknessList(i).Instances
            ElseIf StudentWeaknessList(i).AttributeType = "Sound" And StudentWeaknessList(i).Attribute = "Two" Then
                TwoSoundWordsCount += StudentWeaknessList(i).Instances
            ElseIf StudentWeaknessList(i).AttributeType = "Sound" And StudentWeaknessList(i).Attribute = "Three" Then
                ThreeSoundWordsCount += StudentWeaknessList(i).Instances
            ElseIf StudentWeaknessList(i).AttributeType = "Sound" And StudentWeaknessList(i).Attribute = "Four" Then
                FourSoundWordsCount += StudentWeaknessList(i).Instances
            End If
        Next
        'READ IN THE LIST OF WORDS TO PICK TARGET WORDS FROM
        FileOpen(1, "CustomAssessment.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, TempString)
            NumberCount += 1
        End While
        FileClose(1)
        If NormalWordCount + AlienWordCount > 0 Then
            For i = 1 To 4
                'DETERMINE IDEAL WORD TYPE
                SelectedCount = Random.Next(1, (AlienWordCount + NormalWordCount))
                If SelectedCount <= AlienWordCount And AlienWordCount <> 0 Then
                    IdealType = "Alien"
                Else
                    IdealType = "Normal"
                End If
                'DETERMINE THE IDEAL NUMBER OF SOUNDS
                SelectedCount = Random.Next(1, (TwoSoundWordsCount + ThreeSoundWordsCount + FourSoundWordsCount))
                If SelectedCount <= TwoSoundWordsCount And TwoSoundWordsCount <> 0 Then
                    IdealSound = "Two"
                ElseIf SelectedCount <= ThreeSoundWordsCount And ThreeSoundWordsCount <> 0 Then
                    IdealSound = "Three"
                Else
                    IdealSound = "Four"
                End If
                CurrentType = ""
                CurrentSound = ""
                'SELECT A WORD FROM THE FILE
                Do Until CurrentSound = IdealSound And CurrentType = IdealType And OtherAttributesCount > 1 And (AppropriateForLevel = True Or HighAccuracy = False)
                    SelectedCount = Random.Next(1, NumberCount)
                    OtherAttributesCount = 0
                    Count = 0
                    TempString = "X"
                    AppropriateForLevel = True
                    FileOpen(1, "CustomAssessment.txt", OpenMode.Input)
                    While Not EOF(1)
                        If Count <> SelectedCount Then
                            Input(1, TempString)
                            Count += 1
                            'DETERMINE THE TYPE AND NUMBER OF SOUNDS IN THE SELECTED WORD
                            If TempString = "pok" Or TempString = "cowst" Then
                                CurrentType = "Alien"
                            ElseIf TempString = "is" Or TempString = "sat" Or TempString = "crab" Then
                                CurrentType = "Normal"
                                Select Case TempString
                                    Case "is"
                                        CurrentSound = "Two"
                                    Case "sat"
                                        CurrentSound = "Three"
                                    Case "crab"
                                        CurrentSound = "Four"
                                End Select
                            End If
                            If Count = SelectedCount Then
                                SelectedWord = TempString
                            End If
                        Else
                            Input(1, TempString)
                        End If
                    End While
                    FileClose(1)
                    'IDENTIFY PHONEMES IN THE SELECTED WORD
                    SelectedWordAttributes = GetIncorrectWordAttributes(SelectedWord, 0)
                    For x = 0 To StudentWeaknessList.Count - 1
                        If StudentWeaknessList(x).AttributeType = "Digraph" Then
                            If (StudentWeaknessList(x).Attribute = "One" And SelectedWordAttributes.NumberOfDigraphs = 1) Or (StudentWeaknessList(x).Attribute = "Two" And SelectedWordAttributes.NumberOfDigraphs = 2) Then
                                OtherAttributesCount += 1
                            End If
                        ElseIf StudentWeaknessList(x).AttributeType = "Trigraph" Then
                            If StudentWeaknessList(x).Attribute = "One" And SelectedWordAttributes.NumberOfTrigraphs = 1 Then
                                OtherAttributesCount += 1
                            End If
                        ElseIf StudentWeaknessList(x).AttributeType = "Phoneme" Then
                            For y = 0 To SelectedWordAttributes.ActualSounds.Count - 1
                                If SelectedWordAttributes.ActualSounds(y) = StudentWeaknessList(x).Attribute Then
                                    OtherAttributesCount += 1
                                End If
                            Next
                        End If
                    Next
                    'IDENTIFY IF APPROPRIATE FOR LEVEL
                    If SelectedWord.Length > 3 And PhonicLevel < 4 Then
                        AppropriateForLevel = False
                    End If
                    If SelectedWord.Length > 4 And PhonicLevel < 6 Then
                        AppropriateForLevel = False
                    End If
                    'CHECK IF THIS WORD HAS BEEN SELECTED AND APPROVED BEFORE
                    InNewWordList = False
                    For x = 0 To NewWordList.Count - 1
                        If SelectedWord = NewWordList(x) Then
                            InNewWordList = True
                        End If
                    Next
                    If InNewWordList = True Then
                        AppropriateForLevel = False
                    End If
                    'DETERMINE ACCURACY
                    Iterations += 1
                    If Iterations > 1000 Then
                        HighAccuracy = False
                    End If
                Loop
                'ADD WORD TO THE LIST IF IT IS SUITABLE
                NewWordList.Add(SelectedWord)
            Next
        End If
        'IF FOUR APPROPRIATE WORDS ARE NOT FOUND, FILL OUT THE LIST UNTIL IT HAS FOUR ITEMS
        Do Until NewWordList.Count = 4
            NewWordList.Add("")
        Loop
        'RETURN THE LIST OF TARGET WORDS
        Return NewWordList
    End Function
    Function GetStudentWeaknessList(ByRef StudentID As Integer)
        Dim StudentWeaknessList As New List(Of StudentWeakness)
        Dim SelectedStudentWeakness As StudentWeakness
        'CREATE A LIST OF ALL OF THE STUDENT'S WEAKNESSES
        FileOpen(1, "StudentWeakness.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, SelectedStudentWeakness.StudentID)
            Input(1, SelectedStudentWeakness.AttributeType)
            Input(1, SelectedStudentWeakness.Attribute)
            Input(1, SelectedStudentWeakness.Instances)
            If SelectedStudentWeakness.StudentID = StudentID Then
                'IF ID IN FILE MATCHES ID PASSED INTO FUNCTION, ADD TO LIST
                StudentWeaknessList.Add(SelectedStudentWeakness)
            End If
        End While
        FileClose(1)
        Return StudentWeaknessList
    End Function
    Function GetAttributeList(ByRef AttributeList As List(Of String), ByRef InstanceList As List(Of Integer), ByRef MaxNumberOfItems As Integer)
        Dim SelectedList As New List(Of String)
        Dim NumberCount As Integer
        Dim Random As System.Random = New System.Random()
        Dim SelectedCount As Integer
        Dim Index As Integer
        Dim Count As Integer
        Dim PreviousCount As Integer
        If AttributeList.Count <= MaxNumberOfItems Then
            Do Until AttributeList.Count = 2
                AttributeList.Add("")
            Loop
            'RETURN LIST OF NULL VALUES IF NOT ENOUGH ATTRIBUTES
            Return AttributeList
        Else
            For i = 0 To InstanceList.Count - 1
                NumberCount += InstanceList(i)
            Next
            For i = 0 To MaxNumberOfItems - 1
                PreviousCount = 0
                Count = 0
                Index = -1
                'RANDOMLY SELECT AN INDEX
                SelectedCount = Random.Next(1, NumberCount)
                Do
                    Index += 1
                    PreviousCount = Count
                    Count += InstanceList(Index)
                Loop Until PreviousCount < SelectedCount And SelectedCount <= Count
                'ADD ATTRIBUTE TO THE LIST OF SELECTED ATTRIBUTES
                SelectedList.Add(AttributeList(Index))
                NumberCount -= InstanceList(Index)
                'REMOVE THE ATTRIBUTE FROM THE LIST IT IS SELCTED FROM TO AVOID BEING SELECTED AGAIN
                AttributeList.RemoveAt(Index)
                InstanceList.RemoveAt(Index)
            Next
            Do Until SelectedList.Count = 2
                SelectedList.Add("")
                'ADD EXTRA VALUE(S) IF NOT ENOUGH ATTRIBUTES
            Loop
            Return SelectedList
        End If
    End Function
    Sub ClearButtons(ByRef Full As Boolean)
        'REMOVES BUTTONS FROM THE FORM
        For i = 0 To 2
            Me.Controls.Remove(btnRegularAssessmentNumber(i))
        Next
        Me.Controls.Remove(lblSelectAssessmentMessage)
        Me.Controls.Remove(lstStudents)
        Me.Controls.Remove(btnTargetWords)
        If Full = True Then
            'REMOVES THE ASSESSMENTS LABEL IF CREATING TARGET WORDS
            Me.Controls.Remove(lblAssessments)
        End If
    End Sub
    Function GetStudentID()
        Dim FirstName As String
        Dim Surname As String
        Dim First As Boolean = True
        Dim SelectedStudent As Student
        Dim StudentID As Integer
        'SPLIT THE STUDENT'S NAME ON THE LABLE INTO FIRST AND LAST NAMES
        For i = 0 To lblStudentName.Text.Length - 1
            If lblStudentName.Text(i) <> " " Then
                If First = True Then
                    FirstName = FirstName & lblStudentName.Text(i)
                Else
                    Surname = Surname & lblStudentName.Text(i)
                End If
            Else
                First = False
            End If
        Next
        'RETRIEVE THE STUDENT'S ID FROM THE STUDENT FILE
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
            If SelectedStudent.FirstName = FirstName And SelectedStudent.Surname = Surname Then
                StudentID = SelectedStudent.StudentID
            End If
        End While
        FileClose(1)
        'RETURN THE STUDENT'S ID
        Return StudentID
    End Function
End Class