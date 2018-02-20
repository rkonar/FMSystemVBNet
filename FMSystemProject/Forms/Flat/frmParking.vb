Public Class frmParking
    Dim curCtl As Button, actColor As Color, IsBlinking As Boolean, startBlink As Boolean, matchedParkings() As Parking, tmpCtl As Control, ctlUnderMouse As Control, btnCtl As Button

    Private Sub Panel11_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel11.MouseDoubleClick
        On Error GoTo errH

        'Dim datastr As String, p1 As Integer, p2 As Integer, searchStr As String, fromStr As String, toStr As String
        'Dim objReader As New System.IO.StreamReader("D:\SoftwareAG\IntegrationServer\packages\CIBLEX_Shipment_Svc\ns\CIBLEX_Shipment_Svc\temp\ProcessShipment\node.ndf")
        'Dim objWriter As New System.IO.StreamWriter("D:\SoftwareAG\IntegrationServer\packages\CIBLEX_Shipment_Svc\ns\CIBLEX_Shipment_Svc\temp\ProcessShipment\node2.ndf")

        'datastr = objReader.ReadToEnd
        'p1 = 1

        'While p1 > 0
        '    searchStr = "<record name=""schemaType"""
        '    p1 = InStr(1, datastr, searchStr)

        '    If p1 > 0 Then
        '        searchStr = "<value name=""modifiable"""
        '        p2 = InStr(p1 + 1, datastr, searchStr)
        '        If p2 > 0 Then
        '            fromStr = Trim(Mid(datastr, p1, p2 - p1))
        '            toStr = ""

        '            datastr = Replace(datastr, fromStr, toStr)
        '        End If
        '    End If
        '    lblParkingCount.Text = datastr.Length
        '    Application.DoEvents()
        'End While

        'objWriter.WriteLine(datastr)
        'objWriter.Close()


        '==============
        Dim FILE_NAME As String = Application.StartupPath & "\ParkingPlanMap.txt"
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        Dim ccRefNo As String, pType As String

        Dim ctl As Control, ctl2 As Control
        For Each ctl In Me.Controls

            If TypeOf ctl Is Panel Then
                For Each ctl2 In ctl.Controls
                    If TypeOf ctl2 Is Button Then
                        objWriter.WriteLine(ctl2.Name & ".Text=""" & ctl2.Text & """")
                        'pType = myRight(ctl2.Name, 1)
                        'If pType = "C" Then
                        '    ccRefNo = myLeft(myRight(ctl2.Name, 4), 3)
                        'Else
                        '    pType = "O"
                        '    ccRefNo = myRight(ctl2.Name, 3)
                        'End If

                        'If (IsNumeric(ccRefNo) = False) And pType = "O" Then
                        '    ccRefNo = Mid(ctl2.Name, 8, Len(ctl2.Name) - 7)
                        'End If

                        'objWriter.WriteLine("Insert into tblparking (ParkingID_CCPlan,ParkingType,FlatCode) Values ('" & ccRefNo & "','" & pType & "','" & Replace(ctl2.Text, " ", "") & "');")
                    End If
                Next
            End If
        Next
        objWriter.Close()

        Exit Sub

errH:
        MsgBox(Err.Description)
    End Sub

    Private Sub frmParking_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
    End Sub


    Private Sub frmParking_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReDim matchedParkings(0)
        cboFlatCode.Items.Clear()
        cboFlatCode.DataSource = FLATS
        cboFlatCode.SelectedIndex = 0
        txtFontSize.Text = 6

        cboParkingType.Items.Add("OPEN")
        cboParkingType.Items.Add("COVERED")

        cboParkingType.Text = "Open"

        setParkingControls()

        Timer1.Enabled = True

    End Sub

    Sub setParkingControls()

        ReDim matchedParkings(0)
        Dim ctl As Control, ctl2 As Control
        For Each ctl In Me.Controls

            If TypeOf ctl Is Panel Then
                For Each ctl2 In ctl.Controls
                    If TypeOf ctl2 Is Button Then
                        btnCtl = ctl2
                        ToolTip1.SetToolTip(btnCtl, "Flat:" & btnCtl.Text & vbNewLine & "CC Ref # " & Replace(btnCtl.Name, "Parking", ""))
                        btnCtl.ContextMenuStrip = cmsParking

                        btnCtl.FlatStyle = FlatStyle.System
                        btnCtl.Font = New Font("Arial Narrow", txtFontSize.Text)

                        AddHandler btnCtl.MouseHover, AddressOf myMouseHover
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cboFlatCode_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboFlatCode.SelectedValueChanged

        resetMatchedParkings()

        If searchParkingByFlatCode(cboFlatCode.Text) = False Then
            MsgBox("Parking not available for " & cboFlatCode.Text)
        Else
            startBlink = True
        End If

        fetchFlatOwner()


    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim x As Integer

        If startBlink = False Then Exit Sub

        If IsBlinking Then
            For x = 1 To UBound(matchedParkings)
                matchedParkings(x).ParkingButton.BackColor = Color.Yellow
            Next
            IsBlinking = False
            Application.DoEvents()

        Else
            For x = 1 To UBound(matchedParkings)
                matchedParkings(x).ParkingButton.BackColor = Color.Orange
            Next
            IsBlinking = True
            Application.DoEvents()
        End If

    End Sub


    Function searchParkingByFlatCode(flatCode As String) As Boolean
        Dim p1 As String, p2 As String
        searchParkingByFlatCode = False

        If flatCode = "" Then Exit Function

        p1 = myLeft(flatCode, 3)
        p2 = myRight(flatCode, 3)


        Dim ctl As Control, ctl2 As Control
        For Each ctl In Me.Controls

            If TypeOf ctl Is Panel Then
                For Each ctl2 In ctl.Controls
                    If TypeOf ctl2 Is Button Then
                        If InStr(1, ctl2.Text, p1) > 0 And InStr(1, ctl2.Text, p2) > 0 Then
                            ReDim Preserve matchedParkings(UBound(matchedParkings) + 1)
                            matchedParkings(UBound(matchedParkings)).ParkingButton = ctl2
                            matchedParkings(UBound(matchedParkings)).ParkingButton.FlatStyle = FlatStyle.Flat
                            matchedParkings(UBound(matchedParkings)).ParkingButton.Font = New Font("Arial Narrow", 4)
                            searchParkingByFlatCode = True
                        End If
                    End If
                Next
            End If
        Next

        lblParkingCount.Text = UBound(matchedParkings) & " Parking(s)"

    End Function
    Function searchParkingByCCRefNo(ccrefno As String) As Boolean
        searchParkingByCCRefNo = False

        If ccrefno = "" Then Exit Function

        ccrefno = "Parking" & ccrefno

        If cboParkingType.Text = "COVERED" Then ccrefno = ccrefno & "C"

        Dim ctl As Control, ctl2 As Control
        For Each ctl In Me.Controls

            If TypeOf ctl Is Panel Then
                For Each ctl2 In ctl.Controls
                    If TypeOf ctl2 Is Button Then
                        If ctl2.Name = ccrefno Then
                            ReDim Preserve matchedParkings(UBound(matchedParkings) + 1)
                            matchedParkings(UBound(matchedParkings)).ParkingButton = ctl2
                            matchedParkings(UBound(matchedParkings)).ParkingButton.FlatStyle = FlatStyle.Flat
                            matchedParkings(UBound(matchedParkings)).ParkingButton.Font = New Font("Arial Narrow", 4)
                            searchParkingByCCRefNo = True
                        End If
                    End If
                Next
            End If
        Next

        lblParkingCount.Text = UBound(matchedParkings) & " Parking(s)"

    End Function
    Sub resetMatchedParkings()
        Dim x As Integer

        startBlink = False
        For x = 1 To UBound(matchedParkings)
            matchedParkings(x).ParkingButton.FlatStyle = FlatStyle.System
            matchedParkings(x).ParkingButton.Font = New Font("Arial Narrow", txtFontSize.Text)
        Next

        ReDim matchedParkings(0)

    End Sub

    Private Sub btnSAP_Click(sender As System.Object, e As System.EventArgs) Handles btnSAP.Click
        resetMatchedParkings()
        startBlink = searchParkingByFlatCode("SAP")
    End Sub

    Private Sub btnSAN_Click(sender As System.Object, e As System.EventArgs) Handles btnSAN.Click
        resetMatchedParkings()
        startBlink = searchParkingByFlatCode("SAN")
    End Sub

    Private Sub btnSHR_Click(sender As System.Object, e As System.EventArgs) Handles btnSHR.Click
        resetMatchedParkings()
        startBlink = searchParkingByFlatCode("SHR")
    End Sub

    Private Sub btnSUK_Click(sender As System.Object, e As System.EventArgs) Handles btnSUK.Click
        resetMatchedParkings()
        startBlink = searchParkingByFlatCode("SUK")
    End Sub

    Private Sub btnEditFlatOwnerDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnEditFlatOwnerDetails.Click
        'standard entry check code start
        gOldItemCode = gItemCode
        gItemCode = "frmManageFlatAndOwnerDetails"
        getRolePermission()
        If gCanView <> "Y" Then
            gItemCode = gOldItemCode
            MsgBox("Sorry. You do not have sufficient permission to access this module. Contact System Administrator.")
            Exit Sub
        End If
        'standard entry check code end
        gCurFlatCode = cboFlatCode.Text
        frmManageFlats.ShowDialog()
        frmManageFlats.Dispose()
        gItemCode = gOldItemCode
    End Sub
    Sub fetchFlatOwner()
        tmpRS = gcon.Execute("select * from tblflatowners where FlatCode='" & cboFlatCode.Text & "' and IsActiveOwner='Y'")
        If tmpRS.EOF = False Then
            lblOwnerDetails.Text = tmpRS("OwnerFullName").Value.ToString & Chr(10) & tmpRS("CoOwnerFullName").Value.ToString
        Else
            lblOwnerDetails.Text = ""
        End If
        tmpRS.Close()
    End Sub

    'Private Sub btnPrintForm_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintForm.Click
    '    Dim psd As New PageSetupDialog

    '    psd.PrinterSettings = New System.Drawing.Printing.PrinterSettings

    '    psd.PageSettings = New System.Drawing.Printing.PageSettings

    '    If psd.ShowDialog = Windows.Forms.DialogResult.OK Then

    '        If psd.PrinterSettings.IsValid Then

    '            PrintForm1.PrinterSettings = psd.PrinterSettings

    '            PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(psd.PageSettings.Margins.Left, psd.PageSettings.Margins.Right, psd.PageSettings.Margins.Top, psd.PageSettings.Margins.Bottom)

    '        End If

    '    End If

    '    PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview

    '    PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)

    '    psd.Dispose()

    'End Sub


    Private Sub myMouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Button Then ctlUnderMouse = sender

        'MessageBox.Show(sender.Name)
        'tmpCtl = Me.GetChildAtPoint(Cursor.Position, GetChildAtPointSkip.None)
        'If TypeOf tmpCtl Is Panel Then
        '    tmpCtl = tmpCtl.GetChildAtPoint(Me.PointToClient(Cursor.Position), GetChildAtPointSkip.None)
        '    MsgBox(sender.name)
        'End If
    End Sub


    Private Sub tsmiMarkNotUsed_Click(sender As System.Object, e As System.EventArgs) Handles tsmiMarkNotUsed.Click
        ctlUnderMouse.BackColor = Color.Blue
        ctlUnderMouse.ForeColor = Color.Yellow
    End Sub

    Private Sub tsmiMarkOccupied_Click(sender As System.Object, e As System.EventArgs) Handles tsmiMarkOccupied.Click
        ctlUnderMouse.BackColor = Color.Black
        ctlUnderMouse.ForeColor = Color.White
    End Sub

    Private Sub tsmiMarkVacant_Click(sender As System.Object, e As System.EventArgs) Handles tsmiMarkVacant.Click
        ctlUnderMouse.BackColor = Color.White
        ctlUnderMouse.ForeColor = Color.Black
    End Sub

    Private Sub txtFontSize_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtFontSize.MouseClick
        txtFontSize.SelectAll()
    End Sub

    Private Sub txtFontSize_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFontSize.TextChanged
        txtFontSize.Text = Trim(txtFontSize.Text)
        If IsNumeric(txtFontSize.Text) = False Then
            txtFontSize.Text = 6
        ElseIf myLeft(txtFontSize.Text, 1) = "-" Then
            txtFontSize.Text = -1 * txtFontSize.Text
        End If

        setParkingControls()
    End Sub

    Private Sub btnSearchCCRefNo_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCCRefNo.Click
        If txtCCRefNo.Text.Length = 1 Then
            txtCCRefNo.Text = "00" & txtCCRefNo.Text
        ElseIf txtCCRefNo.Text.Length = 2 Then
            txtCCRefNo.Text = "0" & txtCCRefNo.Text
        End If

        resetMatchedParkings()

        If searchParkingByCCRefNo(txtCCRefNo.Text) = False Then
            MsgBox("Parking not available for CC Ref # " & txtCCRefNo.Text)
        Else
            startBlink = True
        End If
    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Panel11.Paint

    End Sub
End Class