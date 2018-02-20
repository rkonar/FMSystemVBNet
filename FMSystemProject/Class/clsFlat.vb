Public Class clsFlat

    Structure flatType
        Dim FlatCode As String
        Dim TowerName As String
        Dim SBUSqFtArea As String
        Dim TerraceSqFtArea As String
        Dim NoOfRooms As String
        Dim DuplexFlatCode As String
        Dim OwnerFullName As String
        Dim CoOwnerFullName As String
        Dim PrimaryEmail As String
        Dim PrimaryPhone As String
        Dim email1 As String
        Dim email2 As String
        Dim landline1 As String
        Dim landline2 As String
        Dim mobile1 As String
        Dim mobile2 As String
        Dim FullPresentAddress As String
        Dim FullCommunicationAddress As String
        Dim usingPortal As String
        Dim p_softBill As String
        Dim p_email1 As String
        Dim p_email2 As String
        Dim p_mobile1 As String
        Dim p_mobile2 As String
        Dim p_landline1 As String
        Dim balance As Double
        Dim BGFBalance As Double
        Dim AssocBalance As Double
        Dim eVotingMailId As String
        Dim blockedeMails As String
        Dim eMailBlockReason As String

        Dim isOnTenancy As Integer ' this is not a table column; -1 => not on tenancy; x=> x out of 6 docs furnished
    End Structure

    Public allFlats() As flatType

    Public Status As Boolean

    Dim flatRS As ADODB.Recordset

    Public Sub New()
        resetAll()

    End Sub
    Private Sub resetAll()
        ReDim allFlats(0)
        Status = False
    End Sub

    Public Sub loadAll()
        On Error GoTo errH

        Dim r As Integer
        flatRS = gcon.Execute("select f.FlatCode as thisFlatCode,f.DuplexFlatCode,f.SBUSqFtArea,f.TerraceSqFtArea,f.NoOfRooms,fo.* from tblflats f, tblflatowners fo where fo.FlatCode=f.FlatCode and fo.IsActiveOwner='Y' order by f.FlatCode ASC") 'Lower flatcode to be loaded first than upper so that during combining duplex amt, higher flatcode can be made zero without affecting the sum of lower flat code
        ReDim allFlats(0)
        While flatRS.EOF = False
            ReDim Preserve allFlats(UBound(allFlats) + 1)
            r = UBound(allFlats)

            allFlats(r).FlatCode = flatRS("thisFlatCode").Value.ToString
            'allFlats(r).TowerName = flatRS("TowerName").Value.ToString
            allFlats(r).SBUSqFtArea = flatRS("SBUSqFtArea").Value.ToString
            allFlats(r).TerraceSqFtArea = flatRS("TerraceSqFtArea").Value.ToString
            allFlats(r).NoOfRooms = flatRS("NoOfRooms").Value.ToString
            allFlats(r).DuplexFlatCode = flatRS("DuplexFlatCode").Value.ToString
            allFlats(r).OwnerFullName = flatRS("OwnerFullName").Value.ToString
            allFlats(r).CoOwnerFullName = flatRS("CoOwnerFullName").Value.ToString
            allFlats(r).PrimaryEmail = flatRS("PrimaryEmail").Value.ToString
            allFlats(r).PrimaryPhone = flatRS("PrimaryPhone").Value.ToString
            allFlats(r).email1 = flatRS("email1").Value.ToString
            allFlats(r).email2 = flatRS("email2").Value.ToString
            allFlats(r).landline1 = flatRS("landline1").Value.ToString
            allFlats(r).landline2 = flatRS("landline2").Value.ToString
            allFlats(r).mobile1 = flatRS("mobile1").Value.ToString
            allFlats(r).mobile2 = flatRS("mobile2").Value.ToString
            allFlats(r).FullPresentAddress = flatRS("FullPresentAddress").Value.ToString
            allFlats(r).FullCommunicationAddress = flatRS("FullCommunicationAddress").Value.ToString
            allFlats(r).usingPortal = flatRS("usingPortal").Value.ToString
            allFlats(r).p_softBill = flatRS("p_softBill").Value.ToString
            allFlats(r).p_email1 = flatRS("p_email1").Value.ToString
            allFlats(r).p_email2 = flatRS("p_email2").Value.ToString
            allFlats(r).p_mobile1 = flatRS("p_mobile1").Value.ToString
            allFlats(r).p_mobile2 = flatRS("p_mobile2").Value.ToString
            allFlats(r).p_landline1 = flatRS("p_landline1").Value.ToString
            allFlats(r).eVotingMailId = flatRS("evoting_mailid").Value.ToString
            allFlats(r).blockedemails = flatRS("blockedemails").Value.ToString
            allFlats(r).eMailBlockReason = flatRS("emailblockreason").Value.ToString
            allFlats(r).isOnTenancy = isFlatOnTenancy(flatRS("thisFlatCode").Value.ToString)
            allFlats(r).balance = 0
            allFlats(r).BGFBalance = 0
            allFlats(r).AssocBalance = 0
            flatRS.MoveNext()
        End While

        flatRS.Close()

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub
    Function isFlatOnTenancy(flat_code As String) As Integer
        Dim tmpRS As ADODB.Recordset

        isFlatOnTenancy = -1 ' no tenancy

        tmpRS = gcon.Execute("select FlatCode,concat(ApplicationFormSubmitted, PhotoIDProofSubmitted, TenancyAgreementSubmitted, PhotoTaken, PoliceFormSubmitted, FeePaid) as completeStr from tbltenants where (TenancyEndDate >=" & DateTime.Now.ToString(DB_DATEFORMAT) & ") and FlatCode='" & flat_code & "'")
        If tmpRS.EOF = False Then
            If tmpRS("completeStr").Value.ToString <> "" Then
                'gCurFlatCode is already set
                'MsgBox(tmpRS("completeStr").Value.ToString)
                isFlatOnTenancy = Len(tmpRS("completeStr").Value.ToString) - Len(Replace(tmpRS("completeStr").Value.ToString, "Y", ""))
            End If
        End If
        tmpRS.Close()
    End Function
    

    Public Sub updateBalance()
        On Error GoTo errH
        Dim r As Integer, x As Integer, flcode As String
        x = UBound(allFlats)
        For r = 1 To x
            allFlats(r).BGFBalance = 0
            allFlats(r).AssocBalance = 0
            allFlats(r).balance = 0
        Next

        flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt, AccountNo from gfhdb.tbljournal where Status is null and AccountNo like 'DEBTOR-CORPUS-FUND-%' group by AccountNo having netAmt<>0")
        While flatRS.EOF = False
            flcode = Right(flatRS("AccountNo").Value.ToString, 6)
            r = gFlats.getArrayIndex(flcode)
            allFlats(r).BGFBalance = adjDouble(flatRS("netAmt").Value.ToString)
            flatRS.MoveNext()
        End While
        flatRS.Close()

        flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt, AccountNo from gfhdb.tbljournal where Status is null and AccountNo like 'DEBTOR-FLAT-%' group by AccountNo having netAmt<>0")
        While flatRS.EOF = False
            flcode = Right(flatRS("AccountNo").Value.ToString, 6)
            r = gFlats.getArrayIndex(flcode)
            If r <> -1 Then
                allFlats(r).AssocBalance = adjDouble(flatRS("netAmt").Value.ToString)

                allFlats(r).balance = allFlats(r).BGFBalance + allFlats(r).AssocBalance
            End If
            flatRS.MoveNext()
        End While
        flatRS.Close()

        'For r = 1 To x
        '    'If allFlats(r).DuplexFlatCode <> "" Then
        '    '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where (AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "' or AccountNo='DEBTOR-FLAT-" & allFlats(r).DuplexFlatCode & "')")
        '    'Else
        '    ' ''flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where (AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "' or AccountNo='DEBTOR-CORPUS-FUND-" & allFlats(r).FlatCode & "')")
        '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null and AccountNo='DEBTOR-CORPUS-FUND-" & allFlats(r).FlatCode & "'")
        '    allFlats(r).BGFBalance = adjDouble(flatRS("netAmt").Value.ToString)
        '    flatRS.Close()

        '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null and AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "'")
        '    allFlats(r).AssocBalance = adjDouble(flatRS("netAmt").Value.ToString)
        '    'End If
        '    allFlats(r).balance = allFlats(r).BGFBalance + allFlats(r).AssocBalance
        '    ' ''allFlats(r).balance = flatRS("netAmt").Value.ToString
        '    flatRS.Close()
        'Next r

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub
    Public Sub updateBalanceUptoThisDate(todate As String)
        On Error GoTo errH
        Dim r As Integer, x As Integer, flcode As String
        x = UBound(allFlats)

        For r = 1 To x
            allFlats(r).BGFBalance = 0
            allFlats(r).AssocBalance = 0
            allFlats(r).balance = 0
        Next

        flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt, AccountNo from gfhdb.tbljournal where Status is null and TxnDate <='" & DateTime.Parse(todate).ToString(DB_DATEFORMAT) & "' and AccountNo like 'DEBTOR-CORPUS-FUND-%' group by AccountNo having netAmt<>0")
        While flatRS.EOF = False
            flcode = Right(flatRS("AccountNo").Value.ToString, 6)
            r = gFlats.getArrayIndex(flcode)
            allFlats(r).BGFBalance = adjDouble(flatRS("netAmt").Value.ToString)
            flatRS.MoveNext()
        End While
        flatRS.Close()

        flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt, AccountNo from gfhdb.tbljournal where Status is null and TxnDate <='" & DateTime.Parse(todate).ToString(DB_DATEFORMAT) & "' and AccountNo like 'DEBTOR-FLAT-%' group by AccountNo having netAmt<>0")
        While flatRS.EOF = False
            flcode = Right(flatRS("AccountNo").Value.ToString, 6)
            r = gFlats.getArrayIndex(flcode)
            If r <> -1 Then
                allFlats(r).AssocBalance = adjDouble(flatRS("netAmt").Value.ToString)

                allFlats(r).balance = allFlats(r).BGFBalance + allFlats(r).AssocBalance
            End If
            flatRS.MoveNext()
        End While
        flatRS.Close()


        'For r = 1 To x
        '    'If allFlats(r).DuplexFlatCode <> "" Then
        '    '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where (AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "' or AccountNo='DEBTOR-FLAT-" & allFlats(r).DuplexFlatCode & "')")
        '    'Else
        '    ' ''flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where (AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "' or AccountNo='DEBTOR-CORPUS-FUND-" & allFlats(r).FlatCode & "')")
        '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null and AccountNo='DEBTOR-CORPUS-FUND-" & allFlats(r).FlatCode & "' and TxnDate <='" & DateTime.Parse(todate).ToString(DB_DATEFORMAT) & "'")
        '    allFlats(r).BGFBalance = adjDouble(flatRS("netAmt").Value.ToString)
        '    flatRS.Close()

        '    flatRS = gcon.Execute("select sum(DrAmount-CrAmount) as netAmt from tbljournal where Status is null and AccountNo='DEBTOR-FLAT-" & allFlats(r).FlatCode & "' and TxnDate <='" & DateTime.Parse(todate).ToString(DB_DATEFORMAT) & "'")
        '    allFlats(r).AssocBalance = adjDouble(flatRS("netAmt").Value.ToString)
        '    'End If
        '    allFlats(r).balance = allFlats(r).BGFBalance + allFlats(r).AssocBalance
        '    ' ''allFlats(r).balance = flatRS("netAmt").Value.ToString
        '    flatRS.Close()
        'Next r

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Public Sub combineDuplexAmounts()
        On Error GoTo errH
        Dim r As Integer, x As Integer, flcode As String
        Dim tmpR As Integer, tmpC As Integer, curR As Integer, tmpFlatNo As String, tmpOutstanding As Double, tmpIndx As Integer, tmpDupIndx As Integer, tmpDupFlatCode As String, tmpDupOutstanding As Double
        x = UBound(allFlats)

        For r = 1 To x

            flcode = gFlats.allFlats(r).FlatCode
            tmpDupFlatCode = gFlats.allFlats(r).DuplexFlatCode
            If tmpDupFlatCode <> "" Then 'This is a duplex flat

                tmpDupIndx = gFlats.getArrayIndex(tmpDupFlatCode)

                If CInt(Mid(flcode, 4, 2)) < CInt(Mid(tmpDupFlatCode, 4, 2)) Then 'this is the lower duplex flat
                    'show the entire outstanding against the lower duplex flat number
                    allFlats(r).BGFBalance = allFlats(r).BGFBalance + allFlats(tmpDupIndx).BGFBalance
                    allFlats(r).AssocBalance = allFlats(r).AssocBalance + allFlats(tmpDupIndx).AssocBalance
                    allFlats(r).balance = allFlats(r).BGFBalance + allFlats(r).AssocBalance
                Else
                    'show the outstanding as zero for higher duplex flat number as the entire amount has been shown against the lower duplex flat number
                    allFlats(r).BGFBalance = 0
                    allFlats(r).AssocBalance = 0
                    allFlats(r).balance = 0
                End If

            End If

        Next

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Public Function getArrayIndex(thisFlatCode As String) As Integer
        Dim r As Integer, x As Integer
        x = UBound(allFlats)
        getArrayIndex = -1
        For r = 1 To x
            If allFlats(r).FlatCode = thisFlatCode Then
                getArrayIndex = r
                Exit Function
            End If
        Next r
    End Function
End Class
