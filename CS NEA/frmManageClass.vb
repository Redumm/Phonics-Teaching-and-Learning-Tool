Public Class frmManageClass
    Dim Bitmap As Bitmap
    Private Sub frmManageClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SelectedSettings As Settings
        LoadClass()
        frmManageClass_Resize(sender, e)
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
    Private Sub frmManageClass_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim FontSize As Integer
        'RESIZE AND RELOCATE OBJECTS AFTER FORM RESIZE
        Try
            lblManageClass.Left = 20 * ((MyBase.Width - 16) / 912)
            lblManageClass.Top = 29 * ((MyBase.Height - 39) / 513)
            FontSize = 40 * MyBase.Width / 928
            lblManageClass.Font = New Font("Century Gothic", FontSize, FontStyle.Bold)
            grdStudentProperties.Width = 844 * (MyBase.Width / 928)
            grdStudentProperties.Height = 300 * (MyBase.Height / 552)
            grdStudentProperties.Left = 34 * ((MyBase.Width - 16) / 912)
            grdStudentProperties.Top = 110 * ((MyBase.Height - 39) / 513)
            FontSize = 12 * MyBase.Width / 928
            grdStudentProperties.RowsDefaultCellStyle.Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
            grdStudentProperties.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", FontSize, FontStyle.Regular)
            grdStudentProperties.AutoResizeRows()
            picSave.Width = 47 * (MyBase.Height / 552)
            picSave.Height = 47 * (MyBase.Height / 552)
            picSave.Left = 30 * ((MyBase.Width - 16) / 912)
            picSave.Top = 453 * ((MyBase.Height - 39) / 513)
            picReset.Width = 47 * (MyBase.Height / 552)
            picReset.Height = 47 * (MyBase.Height / 552)
            picReset.Left = 107 * ((MyBase.Width - 16) / 912)
            picReset.Top = 453 * ((MyBase.Height - 39) / 513)
            picPrint.Width = 47 * (MyBase.Height / 552)
            picPrint.Height = 47 * (MyBase.Height / 552)
            picPrint.Left = 180 * ((MyBase.Width - 16) / 912)
            picPrint.Top = 453 * ((MyBase.Height - 39) / 513)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picSave_Click(sender As Object, e As EventArgs) Handles picSave.Click
        Dim NullValuePresent As Boolean = False
        Dim NewID As Integer
        grdStudentProperties.CurrentCell = grdStudentProperties.Rows(grdStudentProperties.Rows.Count - 1).Cells(1)
        'CHECK FOR INSTANCES OF A NULL VALUE IN THE TABLE
        For Row = 0 To grdStudentProperties.Rows.Count - 1
            If Row <> grdStudentProperties.Rows.Count - 1 Then
                For Collumn = 1 To 8
                    If grdStudentProperties.Rows(Row).Cells(Collumn).Value = "" Then
                        If Collumn = 8 Then
                            grdStudentProperties.Rows(Row).Cells(Collumn).Value = "N/A"
                        ElseIf Collumn > 2 And Collumn < 8 Then
                            grdStudentProperties.Rows(Row).Cells(Collumn).Value = "N"
                        Else
                            NullValuePresent = True
                        End If
                    End If
                    'CHECK FOR INSTANCES OF INVALID VALUES
                    If Collumn > 2 And Collumn < 8 And grdStudentProperties.Rows(Row).Cells(Collumn).Value <> "N" And grdStudentProperties.Rows(Row).Cells(Collumn).Value <> "Y" Then
                        grdStudentProperties.Rows(Row).Cells(Collumn).Value = "N"
                    End If
                Next
            End If
        Next
        If NullValuePresent = False Then
            'CHECK ID'S IN THE TABLE
            For Row = 0 To grdStudentProperties.Rows.Count - 1
                If Row <> grdStudentProperties.Rows.Count - 1 Then
                    If grdStudentProperties.Rows(Row).Cells(0).Value Like "[0-9]" = False And grdStudentProperties.Rows(Row).Cells(0).Value Like "[0-9][0-9]" = False Then
                        'ASSIGN NEW ID
                        FileOpen(1, "StudentID.txt", OpenMode.Input)
                        Input(1, NewID)
                        FileClose(1)
                        Kill("StudentID.txt")
                        FileOpen(1, "StudentID.txt", OpenMode.Append)
                        Write(1, NewID + 1)
                        FileClose(1)
                        grdStudentProperties.Rows(Row).Cells(0).Value = NewID
                        'AND NEW RECORD TO STUDENT ACHIEVEMENT
                        FileOpen(1, "StudentAchievement.txt", OpenMode.Append)
                        Write(1, NewID)
                        Write(1, "Set1A")
                        WriteLine(1, 0)
                        FileClose(1)
                        'AND NEW RECORD TO PROGRESS CHANGE
                        FileOpen(1, "ProgressChange.txt", OpenMode.Append)
                        Write(1, NewID)
                        Write(1, "Set1A")
                        WriteLine(1, Today)
                        FileClose(1)
                    End If
                End If
            Next
            Kill("Student.txt")
            'REWRITE STUDENT FILE
            FileOpen(1, "Student.txt", OpenMode.Output)
            For Row = 0 To grdStudentProperties.Rows.Count - 1
                If Row <> grdStudentProperties.Rows.Count - 1 Then
                    For Collumn = 0 To 8
                        If Collumn <> 8 Then
                            Write(1, grdStudentProperties.Rows(Row).Cells(Collumn).Value)
                        Else
                            WriteLine(1, grdStudentProperties.Rows(Row).Cells(Collumn).Value)
                        End If
                    Next
                End If
            Next
            FileClose(1)
            picReset_Click(sender, e)
            MessageBox.Show("Class Saved")
        Else
            'ERROR MESSAGE IF KEY FIELDS ARE LEFT BLANK
            MessageBox.Show("Changes Not Saved - Some Fields Are Blank")
        End If
    End Sub
    Private Sub PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'PRINT THE BITMAP
        e.Graphics.DrawImage(Bitmap, 20, 20)
    End Sub
    Private Sub picReset_Click(sender As Object, e As EventArgs) Handles picReset.Click
        grdStudentProperties.Rows.Clear()
        'RELOAD THE DATA GRID VIEW FROM FILE
        LoadClass()
        frmManageClass_Resize(sender, e)
    End Sub
    Private Sub LoadClass()
        Dim SelectedStudent As Student
        Dim Count As Integer = 0
        'OPEN STUDENT FILE
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
            'ADD DATA FROM STUDENT FILE TO DATA GRID VIEW
            grdStudentProperties.Rows.Add(New String() {SelectedStudent.StudentID, SelectedStudent.Surname, SelectedStudent.FirstName, SelectedStudent.PupilPremium, SelectedStudent.LAC, SelectedStudent.SEND, SelectedStudent.EAL, SelectedStudent.SALT, SelectedStudent.Target})
            grdStudentProperties.Rows(Count).Cells(0).Value = SelectedStudent.StudentID
            For i = 0 To 4
                'HIGHLIGHT CELLS OF PRIORITY GROUPS
                If grdStudentProperties.Rows(Count).Cells(3 + i).Value = "Y" Then
                    grdStudentProperties.Rows(Count).Cells(3 + i).Style.BackColor = Color.LightGreen
                End If
            Next
            Count += 1
        End While
        FileClose(1)
    End Sub
    Private Sub picPrint_Click(sender As Object, e As EventArgs) Handles picPrint.Click
        Dim height As Integer = grdStudentProperties.Height
        Dim x As Integer = PrintDocument1.PrinterSettings.DefaultPageSettings.PrintableArea.Width - 40
        Dim y As Integer
        'RESIZE DATA GRID VIEW
        grdStudentProperties.Height = ((grdStudentProperties.RowCount - 1) / (grdStudentProperties.RowCount)) * grdStudentProperties.Rows.GetRowsHeight(0) + grdStudentProperties.ColumnHeadersHeight
        y = grdStudentProperties.Height * (x / grdStudentProperties.Width)
        grdStudentProperties.DefaultCellStyle.SelectionBackColor = Color.White
        grdStudentProperties.DefaultCellStyle.SelectionForeColor = Color.Black
        'DRAW DATA GRID VIEW TO BITMAP
        Bitmap = New Bitmap(Me.grdStudentProperties.Width, Me.grdStudentProperties.Height)
        grdStudentProperties.DrawToBitmap(Bitmap, New Rectangle(0, 0, Me.grdStudentProperties.Width, Me.grdStudentProperties.Height))
        Bitmap = New Bitmap(Bitmap, New Size(x, y))
        'RETURN DATAGRIDVIEW TO ORIGNAL SETTINGS
        grdStudentProperties.Height = height
        grdStudentProperties.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#0078D7")
        grdStudentProperties.DefaultCellStyle.SelectionForeColor = Color.White
        'SHOW PRINT PREVIEW DIALOGUE
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class