Module modStructures
    Structure Student
        Dim StudentID As Integer
        Dim Surname As String
        Dim FirstName As String
        Dim PupilPremium As String
        Dim LAC As String
        Dim SEND As String
        Dim EAL As String
        Dim SALT As String
        Dim Target As String
    End Structure
    Structure StudentAchievement
        Dim StudentID As Integer
        Dim PhonicLevel As String
        Dim RateOfProgress As Long
    End Structure
    Structure ProgressChange
        Dim StudentID As Integer
        Dim PhonicLevel As String
        Dim AchievementDate As Date
    End Structure
    Structure ProgressTime
        Dim PhonicLevel As String
        Dim AchievementDate As Date
    End Structure
    Structure WordAttribute
        Dim Word As String
        Dim AlienWord As Boolean
        Dim NumberOfSounds As Integer
        Dim NumberOfDigraphs As Integer
        Dim NumberOfTrigraphs As Integer
        Dim ActualSounds As List(Of String)
    End Structure
    Structure StudentWeakness
        Dim StudentID As Integer
        Dim AttributeType As String
        Dim Attribute As String
        Dim Instances As Integer
    End Structure
    Structure Settings
        Dim Fullscreen As Boolean
        Dim MaxTimeToImprove As Integer
        Dim TargetProgressRate As Integer
    End Structure
End Module