Public Class clsFinYear
    Public startYear As String
    Public endYear As String
    Public startMonth As String
    Public endMonth As String
    Public startDay As String
    Public endDay As String
    Public startDate As String
    Public endDate As String
    Public startDateDisplay As String
    Public endDateDisplay As String

    Public Sub New()
        SetToCurFinYear()
    End Sub

    Public Sub SetToFinYearByDate(thisDate As Long)

        Dim thisYear = Left(thisDate, 4)
        Dim thisMonth = Mid(thisDate, 5, 2)
        Dim thisDay = Right(thisDate, 2)

        If thisMonth >= 4 Then
            startYear = thisYear
        Else
            startYear = thisYear - 1
        End If
        endYear = startYear + 1


        If startYear = "2012" Then
            startDay = "01"
            endDay = "31"
            startMonth = "01"
            endMonth = "03"
        Else
            startDay = "01"
            endDay = "31"
            startMonth = "04"
            endMonth = "03"
        End If

        startDate = startYear & startMonth & startDay
        endDate = endYear & endMonth & endDay

        startDateDisplay = formatInt2Date(startDate)
        endDateDisplay = formatInt2Date(endDate)

    End Sub

    Public Sub SetToCurFinYear()

        If Month(DateTime.Now) >= 4 Then
            startYear = Year(DateTime.Now)
            endYear = Year(DateTime.Now) + 1
        Else
            startYear = Year(DateTime.Now) - 1
            endYear = Year(DateTime.Now)
        End If

        If startYear = "2012" Then
            startDay = "01"
            endDay = "31"
            startMonth = "01"
            endMonth = "03"
        Else
            startDay = "01"
            endDay = "31"
            startMonth = "04"
            endMonth = "03"
        End If

        startDate = startYear & startMonth & startDay
        endDate = endYear & endMonth & endDay

        startDateDisplay = formatInt2Date(startDate)
        endDateDisplay = formatInt2Date(endDate)

    End Sub

    Public Sub SetToFinYear(startyear_endyear As String)

        startYear = Left(startyear_endyear, 4)
        endYear = Right(startyear_endyear, 4)

        If startYear <= "2012" Then
            startDay = "23"
            endDay = "31"
            startMonth = "06"
            endMonth = "03"
            startYear = "2011"
        Else
            startDay = "01"
            endDay = "31"
            startMonth = "04"
            endMonth = "03"
        End If

        startDate = startYear & startMonth & startDay
        endDate = endYear & endMonth & endDay

        startDateDisplay = formatInt2Date(startDate)
        endDateDisplay = formatInt2Date(endDate)
    End Sub
    
    Public Function IsDateInFinYear(thisDate As String) As Boolean
        IsDateInFinYear = False
        gLastAuditDate = getSysParamValue("LAST_AUDIT_DATE") 'in YYYYMMDD format

        If thisDate <= gLastAuditDate Then
            MsgBox("Data can't be modified before last audit date")
            Exit Function
        End If

        If thisDate >= startDate And thisDate <= endDate Then
            IsDateInFinYear = True
            Exit Function
        End If
        If thisDate < startDate And gAllowBackDateEntry = True Then
            IsDateInFinYear = True
            Exit Function
        End If
        If thisDate > endDate And gAllowFutureDateEntry = True Then
            IsDateInFinYear = True
            Exit Function
        End If

    End Function

    Public Function IsDateAfterFinYear(thisDate As String) As Boolean
        IsDateAfterFinYear = False

        If thisDate > endDate Then
            IsDateAfterFinYear = True
        End If

    End Function

    Public Function IsDateBeforeFinYear(thisDate As String) As Boolean
        IsDateBeforeFinYear = False

        If thisDate < startDate Then
            IsDateBeforeFinYear = True
        End If

    End Function

End Class
