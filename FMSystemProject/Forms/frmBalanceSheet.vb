Public Class frmBalanceSheet
    Private allAccountsStr As String = ""
    Private lFinYear As New clsFinYear
    Dim curStartDate As Long, curEndDate As Long, PrevStartDate As Long, PrevEndDate As Long
    Dim pv As Double = 0, pv2 As Double = 0, cv As Double = 0, an As String, sr As Integer, cvA As Double, cvP As Double, cv2 As Double
   
    Private Sub frmBalanceSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBalancesheet()
    End Sub

    Sub setDatesForBalancesheet()
        '=========================================
        dlgDtpDialog.ShowDialog()
        dlgDtpDialog.Dispose()
        If dtpDateSelected = "" Then Exit Sub
        '=========================================
        curEndDate = DateTime.Parse(dtpDateSelected).ToString(DB_DATEFORMAT)
        lFinYear.SetToFinYearByDate(curEndDate)
        curStartDate = lFinYear.startDate
        ' ''PrevStartDate = "20110622" 'First transaction date in system is of 23-Jun-2011
        PrevEndDate = (lFinYear.endYear - 1) & "0331"

        PrevStartDate = DateTime.Parse(CDate(lFinYear.startDateDisplay).AddYears(-1)).ToString(DB_DATEFORMAT)


        If curEndDate = "20130331" Then 'First Year Audit was done for the period between 23/06/2011 to 31/03/2013
            curStartDate = "20110623"
            PrevEndDate = "20110622"
        End If
        '============================================
    End Sub

    Sub loadBalancesheet()
        Dim clsAR As New clsAuditReports

        setDatesForBalancesheet()

        With clsAR
            an = "FIXED-ASSET-COMP-PERIPHERAL"
            pv = .getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
            cv = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
            cv2 = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
            lnkFAComputerPeripheral.Text = pv + cv - cv2
            lnkFAComputerPeripheral1.Text = pv
            lnkFAComputerPeripheral2.Text = cv
            lnkFAComputerPeripheral3.Text = -cv2

            an = "FIXED-ASSET-FURNITURE"
            pv = .getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
            cv = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
            cv2 = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
            lnkFAFurnitureFixture.Text = pv + cv - cv2
            lnkFAFurnitureFixture1.Text = pv
            lnkFAFurnitureFixture2.Text = cv
            lnkFAFurnitureFixture3.Text = -cv2

            an = "FIXED-ASSET-AC"
            pv = .getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
            cv = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
            cv2 = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
            lnkFAAC.Text = pv + cv - cv2
            lnkFAAC1.Text = pv
            lnkFAAC2.Text = cv
            lnkFAAC3.Text = -cv2

            an = "FIXED-ASSET-ELECTRICALS"
            pv = .getAccountBalanceAsOfDate(PrevEndDate, an, "NET")
            cv = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "DR")
            cv2 = .getAccountBalanceBetweenDates(curStartDate, curEndDate, an, "CR")
            lnkFAElectEquip.Text = pv + cv - cv2
            lnkFAElectEquip1.Text = pv
            lnkFAElectEquip2.Text = cv
            lnkFAElectEquip3.Text = -cv2
        End With

    End Sub
    Sub showTxnDetails(stDt As Long, enDt As Long, accountNo As String, drORcrORnet As String)
        With frmTxnDrill
            .pAccountNo = accountNo
            .pFromDate = formatInt2Date(stDt)
            .pToDate = formatInt2Date(enDt)
            .pDROrCROrNET = drORcrORnet

            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub lnkFAComputerPeripheral1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAComputerPeripheral1.LinkClicked
        showTxnDetails("20110101", PrevEndDate, "FIXED-ASSET-COMP-PERIPHERAL", "NET")
    End Sub

    Private Sub lnkFAComputerPeripheral2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAComputerPeripheral2.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-COMP-PERIPHERAL", "DR")
    End Sub

    Private Sub lnkFAComputerPeripheral3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAComputerPeripheral3.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-COMP-PERIPHERAL", "CR")
    End Sub

    Private Sub lnkFAFurnitureFixture1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAFurnitureFixture1.LinkClicked
        showTxnDetails("20110101", PrevEndDate, "FIXED-ASSET-FURNITURE", "NET")
    End Sub

    Private Sub lnkFAFurnitureFixture2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAFurnitureFixture2.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-FURNITURE", "DR")
    End Sub

    Private Sub lnkFAFurnitureFixture3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAFurnitureFixture3.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-FURNITURE", "CR")
    End Sub

    Private Sub lnkFAAC1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAAC1.LinkClicked
        showTxnDetails("20110101", PrevEndDate, "FIXED-ASSET-AC", "NET")
    End Sub

    Private Sub lnkFAAC2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAAC2.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-AC", "DR")
    End Sub

    Private Sub lnkFAAC3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAAC3.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-AC", "CR")
    End Sub

    Private Sub lnkFAElectEquip1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAElectEquip1.LinkClicked
        showTxnDetails("20110101", PrevEndDate, "FIXED-ASSET-ELECTRICALS", "NET")
    End Sub

    Private Sub lnkFAElectEquip2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAElectEquip2.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-ELECTRICALS", "DR")
    End Sub

    Private Sub lnkFAElectEquip3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFAElectEquip3.LinkClicked
        showTxnDetails(curStartDate, curEndDate, "FIXED-ASSET-ELECTRICALS", "CR")
    End Sub
End Class