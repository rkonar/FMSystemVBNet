<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.msMenubar = New System.Windows.Forms.MenuStrip()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSearchFlatOwner = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Manage = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageFlatAndOwnerDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiParking = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageTenants = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageServiceCase = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowFlatDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDefaulterList = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDefaulterListBGF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDefaulterListAssociation = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCOAReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCharting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMiscCharting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCashBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCashBook_WithSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCashBook_WithoutSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Sav = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Sav_WithSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Sav_WithoutSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Cur = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Cur_WithSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBook_Cur_WithoutSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpenseReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpenseReport_WithSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpenseReport_WithoutSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsForAuditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNewCashBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNewBankBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiIncomeExpenseReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBalanceSheet = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReceiptsPaymentsReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.CulturalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCashBookCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBankBookCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBalanceSheetCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiIncomeExpenseReportCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReceiptsPaymentsReportCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionDrillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BalanceSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPerformBilling = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBillMailer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBookReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiViewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBookReceiptCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiViewReceiptCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManagePayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManagePaymentCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReconcileBankStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiJournalBankStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiJournalBankStatementCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReconcileBankStatementCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_Journal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageJournal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSpecialTransactions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSpecialTransactionsCultural = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_System = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCOA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDBBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMarkEndOfDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSyncOwnerDetailsFromPortal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiFutureDateEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBackDateEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageReceiptBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageChequeBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageVoucherBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiManageSystemParameter = New System.Windows.Forms.ToolStripMenuItem()
        Me.SecurityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAccessManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiGeneratePWD = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiscToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowTemporaryReceipts = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLogOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatusBar = New System.Windows.Forms.StatusStrip()
        Me.sslabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusbarContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsChangeUserPassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon4OpenCases = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer4OpenCases = New System.Windows.Forms.Timer(Me.components)
        Me.tsmiExpenseReportCult = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpenseReportCult_WithSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExpenseReportCult_WithoutSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMenubar.SuspendLayout()
        Me.ssStatusBar.SuspendLayout()
        Me.statusbarContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMenubar
        '
        Me.msMenubar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.tsmi_Manage, Me.ReportToolStripMenuItem, Me.BillToolStripMenuItem, Me.ReceiptToolStripMenuItem, Me.PaymentToolStripMenuItem, Me.BankToolStripMenuItem, Me.tsmi_Journal, Me.InventoryToolStripMenuItem, Me.tsmi_System, Me.SecurityToolStripMenuItem, Me.MiscToolStripMenuItem, Me.tsmiClose})
        Me.msMenubar.Location = New System.Drawing.Point(0, 0)
        Me.msMenubar.Name = "msMenubar"
        Me.msMenubar.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.msMenubar.Size = New System.Drawing.Size(892, 24)
        Me.msMenubar.TabIndex = 1
        Me.msMenubar.Text = "msMenubar"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSearchFlatOwner})
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'tsmiSearchFlatOwner
        '
        Me.tsmiSearchFlatOwner.Name = "tsmiSearchFlatOwner"
        Me.tsmiSearchFlatOwner.Size = New System.Drawing.Size(133, 22)
        Me.tsmiSearchFlatOwner.Text = "Flat/Owner"
        '
        'tsmi_Manage
        '
        Me.tsmi_Manage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiManageFlatAndOwnerDetails, Me.tsmiParking, Me.tsmiManageTenants, Me.tsmiManageServiceCase, Me.tsmiShowFlatDetails})
        Me.tsmi_Manage.Name = "tsmi_Manage"
        Me.tsmi_Manage.Size = New System.Drawing.Size(38, 20)
        Me.tsmi_Manage.Text = "Flat"
        '
        'tsmiManageFlatAndOwnerDetails
        '
        Me.tsmiManageFlatAndOwnerDetails.Name = "tsmiManageFlatAndOwnerDetails"
        Me.tsmiManageFlatAndOwnerDetails.Size = New System.Drawing.Size(192, 22)
        Me.tsmiManageFlatAndOwnerDetails.Text = "Flat and Owner Details"
        '
        'tsmiParking
        '
        Me.tsmiParking.Name = "tsmiParking"
        Me.tsmiParking.Size = New System.Drawing.Size(192, 22)
        Me.tsmiParking.Text = "Parking Tracker"
        '
        'tsmiManageTenants
        '
        Me.tsmiManageTenants.Name = "tsmiManageTenants"
        Me.tsmiManageTenants.Size = New System.Drawing.Size(192, 22)
        Me.tsmiManageTenants.Text = "Manage Tenants"
        '
        'tsmiManageServiceCase
        '
        Me.tsmiManageServiceCase.Name = "tsmiManageServiceCase"
        Me.tsmiManageServiceCase.Size = New System.Drawing.Size(192, 22)
        Me.tsmiManageServiceCase.Text = "Manage Service Case"
        '
        'tsmiShowFlatDetails
        '
        Me.tsmiShowFlatDetails.Name = "tsmiShowFlatDetails"
        Me.tsmiShowFlatDetails.Size = New System.Drawing.Size(192, 22)
        Me.tsmiShowFlatDetails.Text = "Flat Details"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiDefaulterList, Me.tsmiCOAReports, Me.tsmiCharting, Me.tsmiMiscCharting, Me.tsmiCashBook, Me.tsmiBankBook_Sav, Me.tsmiBankBook_Cur, Me.tsmiExpenseReport, Me.ReportsForAuditToolStripMenuItem, Me.CulturalToolStripMenuItem, Me.TransactionDrillToolStripMenuItem, Me.BalanceSheetToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'tsmiDefaulterList
        '
        Me.tsmiDefaulterList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiDefaulterListBGF, Me.tsmiDefaulterListAssociation})
        Me.tsmiDefaulterList.Name = "tsmiDefaulterList"
        Me.tsmiDefaulterList.Size = New System.Drawing.Size(181, 22)
        Me.tsmiDefaulterList.Text = "Defaulter List"
        '
        'tsmiDefaulterListBGF
        '
        Me.tsmiDefaulterListBGF.Enabled = False
        Me.tsmiDefaulterListBGF.Name = "tsmiDefaulterListBGF"
        Me.tsmiDefaulterListBGF.Size = New System.Drawing.Size(135, 22)
        Me.tsmiDefaulterListBGF.Text = "BGF"
        Me.tsmiDefaulterListBGF.Visible = False
        '
        'tsmiDefaulterListAssociation
        '
        Me.tsmiDefaulterListAssociation.Name = "tsmiDefaulterListAssociation"
        Me.tsmiDefaulterListAssociation.Size = New System.Drawing.Size(135, 22)
        Me.tsmiDefaulterListAssociation.Text = "Association"
        '
        'tsmiCOAReports
        '
        Me.tsmiCOAReports.Name = "tsmiCOAReports"
        Me.tsmiCOAReports.Size = New System.Drawing.Size(181, 22)
        Me.tsmiCOAReports.Text = "COA Reports"
        '
        'tsmiCharting
        '
        Me.tsmiCharting.Name = "tsmiCharting"
        Me.tsmiCharting.Size = New System.Drawing.Size(181, 22)
        Me.tsmiCharting.Text = "Due Charting"
        '
        'tsmiMiscCharting
        '
        Me.tsmiMiscCharting.Name = "tsmiMiscCharting"
        Me.tsmiMiscCharting.Size = New System.Drawing.Size(181, 22)
        Me.tsmiMiscCharting.Text = "Misc Charting"
        '
        'tsmiCashBook
        '
        Me.tsmiCashBook.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCashBook_WithSummary, Me.tsmiCashBook_WithoutSummary})
        Me.tsmiCashBook.Name = "tsmiCashBook"
        Me.tsmiCashBook.Size = New System.Drawing.Size(181, 22)
        Me.tsmiCashBook.Text = "Cash Book"
        Me.tsmiCashBook.Visible = False
        '
        'tsmiCashBook_WithSummary
        '
        Me.tsmiCashBook_WithSummary.Name = "tsmiCashBook_WithSummary"
        Me.tsmiCashBook_WithSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiCashBook_WithSummary.Text = "With Monthly Summary"
        '
        'tsmiCashBook_WithoutSummary
        '
        Me.tsmiCashBook_WithoutSummary.Name = "tsmiCashBook_WithoutSummary"
        Me.tsmiCashBook_WithoutSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiCashBook_WithoutSummary.Text = "Without Monthly Summary"
        '
        'tsmiBankBook_Sav
        '
        Me.tsmiBankBook_Sav.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBankBook_Sav_WithSummary, Me.tsmiBankBook_Sav_WithoutSummary})
        Me.tsmiBankBook_Sav.Name = "tsmiBankBook_Sav"
        Me.tsmiBankBook_Sav.Size = New System.Drawing.Size(181, 22)
        Me.tsmiBankBook_Sav.Text = "Bank Book - Savings"
        Me.tsmiBankBook_Sav.Visible = False
        '
        'tsmiBankBook_Sav_WithSummary
        '
        Me.tsmiBankBook_Sav_WithSummary.Name = "tsmiBankBook_Sav_WithSummary"
        Me.tsmiBankBook_Sav_WithSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiBankBook_Sav_WithSummary.Text = "With Monthly Summary"
        '
        'tsmiBankBook_Sav_WithoutSummary
        '
        Me.tsmiBankBook_Sav_WithoutSummary.Name = "tsmiBankBook_Sav_WithoutSummary"
        Me.tsmiBankBook_Sav_WithoutSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiBankBook_Sav_WithoutSummary.Text = "Without Monthly Summary"
        '
        'tsmiBankBook_Cur
        '
        Me.tsmiBankBook_Cur.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBankBook_Cur_WithSummary, Me.tsmiBankBook_Cur_WithoutSummary})
        Me.tsmiBankBook_Cur.Name = "tsmiBankBook_Cur"
        Me.tsmiBankBook_Cur.Size = New System.Drawing.Size(181, 22)
        Me.tsmiBankBook_Cur.Text = "Bank Book - Current"
        Me.tsmiBankBook_Cur.Visible = False
        '
        'tsmiBankBook_Cur_WithSummary
        '
        Me.tsmiBankBook_Cur_WithSummary.Name = "tsmiBankBook_Cur_WithSummary"
        Me.tsmiBankBook_Cur_WithSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiBankBook_Cur_WithSummary.Text = "With Monthly Summary"
        '
        'tsmiBankBook_Cur_WithoutSummary
        '
        Me.tsmiBankBook_Cur_WithoutSummary.Name = "tsmiBankBook_Cur_WithoutSummary"
        Me.tsmiBankBook_Cur_WithoutSummary.Size = New System.Drawing.Size(219, 22)
        Me.tsmiBankBook_Cur_WithoutSummary.Text = "Without Monthly Summary"
        '
        'tsmiExpenseReport
        '
        Me.tsmiExpenseReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiExpenseReport_WithSummary, Me.tsmiExpenseReport_WithoutSummary})
        Me.tsmiExpenseReport.Name = "tsmiExpenseReport"
        Me.tsmiExpenseReport.Size = New System.Drawing.Size(181, 22)
        Me.tsmiExpenseReport.Text = "Expense"
        '
        'tsmiExpenseReport_WithSummary
        '
        Me.tsmiExpenseReport_WithSummary.Name = "tsmiExpenseReport_WithSummary"
        Me.tsmiExpenseReport_WithSummary.Size = New System.Drawing.Size(171, 22)
        Me.tsmiExpenseReport_WithSummary.Text = "With Summary"
        '
        'tsmiExpenseReport_WithoutSummary
        '
        Me.tsmiExpenseReport_WithoutSummary.Name = "tsmiExpenseReport_WithoutSummary"
        Me.tsmiExpenseReport_WithoutSummary.Size = New System.Drawing.Size(171, 22)
        Me.tsmiExpenseReport_WithoutSummary.Text = "Without Summary"
        '
        'ReportsForAuditToolStripMenuItem
        '
        Me.ReportsForAuditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNewCashBook, Me.tsmiNewBankBook, Me.tsmiIncomeExpenseReport, Me.tsmiBalanceSheet, Me.tsmiReceiptsPaymentsReport})
        Me.ReportsForAuditToolStripMenuItem.Name = "ReportsForAuditToolStripMenuItem"
        Me.ReportsForAuditToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ReportsForAuditToolStripMenuItem.Text = "Reports for Audit"
        '
        'tsmiNewCashBook
        '
        Me.tsmiNewCashBook.Name = "tsmiNewCashBook"
        Me.tsmiNewCashBook.Size = New System.Drawing.Size(211, 22)
        Me.tsmiNewCashBook.Text = "New Cash Book"
        '
        'tsmiNewBankBook
        '
        Me.tsmiNewBankBook.Name = "tsmiNewBankBook"
        Me.tsmiNewBankBook.Size = New System.Drawing.Size(211, 22)
        Me.tsmiNewBankBook.Text = "New Bank Book"
        '
        'tsmiIncomeExpenseReport
        '
        Me.tsmiIncomeExpenseReport.Name = "tsmiIncomeExpenseReport"
        Me.tsmiIncomeExpenseReport.Size = New System.Drawing.Size(211, 22)
        Me.tsmiIncomeExpenseReport.Text = "Income Expense Report"
        '
        'tsmiBalanceSheet
        '
        Me.tsmiBalanceSheet.Name = "tsmiBalanceSheet"
        Me.tsmiBalanceSheet.Size = New System.Drawing.Size(211, 22)
        Me.tsmiBalanceSheet.Text = "Balance Sheet"
        '
        'tsmiReceiptsPaymentsReport
        '
        Me.tsmiReceiptsPaymentsReport.Name = "tsmiReceiptsPaymentsReport"
        Me.tsmiReceiptsPaymentsReport.Size = New System.Drawing.Size(211, 22)
        Me.tsmiReceiptsPaymentsReport.Text = "Receipts Payments Report"
        '
        'CulturalToolStripMenuItem
        '
        Me.CulturalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCashBookCultural, Me.tsmiBankBookCultural, Me.tsmiBalanceSheetCultural, Me.tsmiIncomeExpenseReportCultural, Me.tsmiReceiptsPaymentsReportCultural, Me.tsmiExpenseReportCult})
        Me.CulturalToolStripMenuItem.Name = "CulturalToolStripMenuItem"
        Me.CulturalToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CulturalToolStripMenuItem.Text = "Cultural"
        '
        'tsmiCashBookCultural
        '
        Me.tsmiCashBookCultural.Name = "tsmiCashBookCultural"
        Me.tsmiCashBookCultural.Size = New System.Drawing.Size(211, 22)
        Me.tsmiCashBookCultural.Text = "Cash Book"
        '
        'tsmiBankBookCultural
        '
        Me.tsmiBankBookCultural.Name = "tsmiBankBookCultural"
        Me.tsmiBankBookCultural.Size = New System.Drawing.Size(211, 22)
        Me.tsmiBankBookCultural.Text = "Bank Book"
        '
        'tsmiBalanceSheetCultural
        '
        Me.tsmiBalanceSheetCultural.Name = "tsmiBalanceSheetCultural"
        Me.tsmiBalanceSheetCultural.Size = New System.Drawing.Size(211, 22)
        Me.tsmiBalanceSheetCultural.Text = "Balance Sheet"
        '
        'tsmiIncomeExpenseReportCultural
        '
        Me.tsmiIncomeExpenseReportCultural.Name = "tsmiIncomeExpenseReportCultural"
        Me.tsmiIncomeExpenseReportCultural.Size = New System.Drawing.Size(211, 22)
        Me.tsmiIncomeExpenseReportCultural.Text = "Income Expense Report"
        '
        'tsmiReceiptsPaymentsReportCultural
        '
        Me.tsmiReceiptsPaymentsReportCultural.Name = "tsmiReceiptsPaymentsReportCultural"
        Me.tsmiReceiptsPaymentsReportCultural.Size = New System.Drawing.Size(211, 22)
        Me.tsmiReceiptsPaymentsReportCultural.Text = "Receipts Payments Report"
        '
        'TransactionDrillToolStripMenuItem
        '
        Me.TransactionDrillToolStripMenuItem.Name = "TransactionDrillToolStripMenuItem"
        Me.TransactionDrillToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TransactionDrillToolStripMenuItem.Text = "Transaction Drill"
        '
        'BalanceSheetToolStripMenuItem
        '
        Me.BalanceSheetToolStripMenuItem.Name = "BalanceSheetToolStripMenuItem"
        Me.BalanceSheetToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.BalanceSheetToolStripMenuItem.Text = "Balance Sheet"
        '
        'BillToolStripMenuItem
        '
        Me.BillToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPerformBilling, Me.tsmiBillMailer})
        Me.BillToolStripMenuItem.Name = "BillToolStripMenuItem"
        Me.BillToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.BillToolStripMenuItem.Text = "Bill"
        '
        'tsmiPerformBilling
        '
        Me.tsmiPerformBilling.Name = "tsmiPerformBilling"
        Me.tsmiPerformBilling.Size = New System.Drawing.Size(153, 22)
        Me.tsmiPerformBilling.Text = "Perform Billing"
        '
        'tsmiBillMailer
        '
        Me.tsmiBillMailer.Name = "tsmiBillMailer"
        Me.tsmiBillMailer.Size = New System.Drawing.Size(153, 22)
        Me.tsmiBillMailer.Text = "Bill Mailer"
        '
        'ReceiptToolStripMenuItem
        '
        Me.ReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBookReceipt, Me.tsmiViewReceipt, Me.tsmiBookReceiptCultural, Me.tsmiViewReceiptCultural})
        Me.ReceiptToolStripMenuItem.Name = "ReceiptToolStripMenuItem"
        Me.ReceiptToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ReceiptToolStripMenuItem.Text = "Receipt"
        '
        'tsmiBookReceipt
        '
        Me.tsmiBookReceipt.Name = "tsmiBookReceipt"
        Me.tsmiBookReceipt.Size = New System.Drawing.Size(196, 22)
        Me.tsmiBookReceipt.Text = "Book Receipt"
        '
        'tsmiViewReceipt
        '
        Me.tsmiViewReceipt.Name = "tsmiViewReceipt"
        Me.tsmiViewReceipt.Size = New System.Drawing.Size(196, 22)
        Me.tsmiViewReceipt.Text = "View Receipt"
        '
        'tsmiBookReceiptCultural
        '
        Me.tsmiBookReceiptCultural.Name = "tsmiBookReceiptCultural"
        Me.tsmiBookReceiptCultural.Size = New System.Drawing.Size(196, 22)
        Me.tsmiBookReceiptCultural.Text = "Book Receipt - Cultural"
        '
        'tsmiViewReceiptCultural
        '
        Me.tsmiViewReceiptCultural.Name = "tsmiViewReceiptCultural"
        Me.tsmiViewReceiptCultural.Size = New System.Drawing.Size(196, 22)
        Me.tsmiViewReceiptCultural.Text = "View Receipt - Cultural"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiManagePayment, Me.tsmiManagePaymentCultural})
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'tsmiManagePayment
        '
        Me.tsmiManagePayment.Name = "tsmiManagePayment"
        Me.tsmiManagePayment.Size = New System.Drawing.Size(220, 22)
        Me.tsmiManagePayment.Text = "Manage Payment"
        '
        'tsmiManagePaymentCultural
        '
        Me.tsmiManagePaymentCultural.Name = "tsmiManagePaymentCultural"
        Me.tsmiManagePaymentCultural.Size = New System.Drawing.Size(220, 22)
        Me.tsmiManagePaymentCultural.Text = "Manage Payment - Cultural"
        '
        'BankToolStripMenuItem
        '
        Me.BankToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiReconcileBankStatement, Me.tsmiJournalBankStatement, Me.tsmiJournalBankStatementCultural, Me.tsmiReconcileBankStatementCultural})
        Me.BankToolStripMenuItem.Name = "BankToolStripMenuItem"
        Me.BankToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.BankToolStripMenuItem.Text = "Bank"
        '
        'tsmiReconcileBankStatement
        '
        Me.tsmiReconcileBankStatement.Name = "tsmiReconcileBankStatement"
        Me.tsmiReconcileBankStatement.Size = New System.Drawing.Size(264, 22)
        Me.tsmiReconcileBankStatement.Text = "Reconcile Bank Statement"
        '
        'tsmiJournalBankStatement
        '
        Me.tsmiJournalBankStatement.Name = "tsmiJournalBankStatement"
        Me.tsmiJournalBankStatement.Size = New System.Drawing.Size(264, 22)
        Me.tsmiJournalBankStatement.Text = "Journal Bank Statement"
        '
        'tsmiJournalBankStatementCultural
        '
        Me.tsmiJournalBankStatementCultural.Name = "tsmiJournalBankStatementCultural"
        Me.tsmiJournalBankStatementCultural.Size = New System.Drawing.Size(264, 22)
        Me.tsmiJournalBankStatementCultural.Text = "Journal Bank Statement - Cultural"
        '
        'tsmiReconcileBankStatementCultural
        '
        Me.tsmiReconcileBankStatementCultural.Name = "tsmiReconcileBankStatementCultural"
        Me.tsmiReconcileBankStatementCultural.Size = New System.Drawing.Size(264, 22)
        Me.tsmiReconcileBankStatementCultural.Text = "Reconcile Bank Statement - Cultural"
        '
        'tsmi_Journal
        '
        Me.tsmi_Journal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiManageJournal, Me.tsmiSpecialTransactions, Me.tsmiSpecialTransactionsCultural})
        Me.tsmi_Journal.Name = "tsmi_Journal"
        Me.tsmi_Journal.Size = New System.Drawing.Size(57, 20)
        Me.tsmi_Journal.Text = "Journal"
        '
        'tsmiManageJournal
        '
        Me.tsmiManageJournal.Name = "tsmiManageJournal"
        Me.tsmiManageJournal.Size = New System.Drawing.Size(234, 22)
        Me.tsmiManageJournal.Text = "Manage Journal"
        '
        'tsmiSpecialTransactions
        '
        Me.tsmiSpecialTransactions.Name = "tsmiSpecialTransactions"
        Me.tsmiSpecialTransactions.Size = New System.Drawing.Size(234, 22)
        Me.tsmiSpecialTransactions.Text = "Special Transactions"
        '
        'tsmiSpecialTransactionsCultural
        '
        Me.tsmiSpecialTransactionsCultural.Name = "tsmiSpecialTransactionsCultural"
        Me.tsmiSpecialTransactionsCultural.Size = New System.Drawing.Size(234, 22)
        Me.tsmiSpecialTransactionsCultural.Text = "Special Transactions - Cultural"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiManageInventory})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'tsmiManageInventory
        '
        Me.tsmiManageInventory.Name = "tsmiManageInventory"
        Me.tsmiManageInventory.Size = New System.Drawing.Size(170, 22)
        Me.tsmiManageInventory.Text = "Manage Inventory"
        '
        'tsmi_System
        '
        Me.tsmi_System.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCOA, Me.tsmiDBBackup, Me.tsmiMarkEndOfDay, Me.tsmiSyncOwnerDetailsFromPortal, Me.tsmiFutureDateEntry, Me.tsmiBackDateEntry, Me.tsmiManageReceiptBook, Me.tsmiManageChequeBook, Me.tsmiManageVoucherBook, Me.tsmiManageSystemParameter})
        Me.tsmi_System.Name = "tsmi_System"
        Me.tsmi_System.Size = New System.Drawing.Size(57, 20)
        Me.tsmi_System.Text = "System"
        '
        'tsmiCOA
        '
        Me.tsmiCOA.Name = "tsmiCOA"
        Me.tsmiCOA.Size = New System.Drawing.Size(238, 22)
        Me.tsmiCOA.Text = "ChartOfAccount"
        '
        'tsmiDBBackup
        '
        Me.tsmiDBBackup.Name = "tsmiDBBackup"
        Me.tsmiDBBackup.Size = New System.Drawing.Size(238, 22)
        Me.tsmiDBBackup.Text = "DB Backup / Restore"
        '
        'tsmiMarkEndOfDay
        '
        Me.tsmiMarkEndOfDay.Name = "tsmiMarkEndOfDay"
        Me.tsmiMarkEndOfDay.Size = New System.Drawing.Size(238, 22)
        Me.tsmiMarkEndOfDay.Text = "End Of Day Housekeeping"
        '
        'tsmiSyncOwnerDetailsFromPortal
        '
        Me.tsmiSyncOwnerDetailsFromPortal.Name = "tsmiSyncOwnerDetailsFromPortal"
        Me.tsmiSyncOwnerDetailsFromPortal.Size = New System.Drawing.Size(238, 22)
        Me.tsmiSyncOwnerDetailsFromPortal.Text = "Sync Owner Details from Portal"
        '
        'tsmiFutureDateEntry
        '
        Me.tsmiFutureDateEntry.Name = "tsmiFutureDateEntry"
        Me.tsmiFutureDateEntry.Size = New System.Drawing.Size(238, 22)
        Me.tsmiFutureDateEntry.Text = "Enable Future Date Entry"
        '
        'tsmiBackDateEntry
        '
        Me.tsmiBackDateEntry.Name = "tsmiBackDateEntry"
        Me.tsmiBackDateEntry.Size = New System.Drawing.Size(238, 22)
        Me.tsmiBackDateEntry.Text = "Enable Back Date Entry"
        '
        'tsmiManageReceiptBook
        '
        Me.tsmiManageReceiptBook.Name = "tsmiManageReceiptBook"
        Me.tsmiManageReceiptBook.Size = New System.Drawing.Size(238, 22)
        Me.tsmiManageReceiptBook.Text = "Manage Receipt Book"
        '
        'tsmiManageChequeBook
        '
        Me.tsmiManageChequeBook.Name = "tsmiManageChequeBook"
        Me.tsmiManageChequeBook.Size = New System.Drawing.Size(238, 22)
        Me.tsmiManageChequeBook.Text = "Manage Cheque Book"
        '
        'tsmiManageVoucherBook
        '
        Me.tsmiManageVoucherBook.Name = "tsmiManageVoucherBook"
        Me.tsmiManageVoucherBook.Size = New System.Drawing.Size(238, 22)
        Me.tsmiManageVoucherBook.Text = "Manage Voucher Book"
        '
        'tsmiManageSystemParameter
        '
        Me.tsmiManageSystemParameter.Name = "tsmiManageSystemParameter"
        Me.tsmiManageSystemParameter.Size = New System.Drawing.Size(238, 22)
        Me.tsmiManageSystemParameter.Text = "Manage System Parameters"
        '
        'SecurityToolStripMenuItem
        '
        Me.SecurityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAccessManager, Me.tsmiGeneratePWD})
        Me.SecurityToolStripMenuItem.Name = "SecurityToolStripMenuItem"
        Me.SecurityToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SecurityToolStripMenuItem.Text = "Security"
        '
        'tsmiAccessManager
        '
        Me.tsmiAccessManager.Name = "tsmiAccessManager"
        Me.tsmiAccessManager.Size = New System.Drawing.Size(174, 22)
        Me.tsmiAccessManager.Text = "Access Manager"
        '
        'tsmiGeneratePWD
        '
        Me.tsmiGeneratePWD.Name = "tsmiGeneratePWD"
        Me.tsmiGeneratePWD.Size = New System.Drawing.Size(174, 22)
        Me.tsmiGeneratePWD.Text = "Generate Password"
        '
        'MiscToolStripMenuItem
        '
        Me.MiscToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiShowTemporaryReceipts})
        Me.MiscToolStripMenuItem.Name = "MiscToolStripMenuItem"
        Me.MiscToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.MiscToolStripMenuItem.Text = "Misc"
        Me.MiscToolStripMenuItem.Visible = False
        '
        'tsmiShowTemporaryReceipts
        '
        Me.tsmiShowTemporaryReceipts.Name = "tsmiShowTemporaryReceipts"
        Me.tsmiShowTemporaryReceipts.Size = New System.Drawing.Size(211, 22)
        Me.tsmiShowTemporaryReceipts.Text = "Show Temporary Receipts"
        '
        'tsmiClose
        '
        Me.tsmiClose.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiLogOff, Me.tsmiExit})
        Me.tsmiClose.Name = "tsmiClose"
        Me.tsmiClose.Size = New System.Drawing.Size(48, 20)
        Me.tsmiClose.Text = "Close"
        '
        'tsmiLogOff
        '
        Me.tsmiLogOff.Name = "tsmiLogOff"
        Me.tsmiLogOff.Size = New System.Drawing.Size(114, 22)
        Me.tsmiLogOff.Text = "Log Off"
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.Size = New System.Drawing.Size(114, 22)
        Me.tsmiExit.Text = "E&xit"
        '
        'ssStatusBar
        '
        Me.ssStatusBar.BackColor = System.Drawing.Color.Black
        Me.ssStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslabel1, Me.sslabel2, Me.sslabel3})
        Me.ssStatusBar.Location = New System.Drawing.Point(0, 697)
        Me.ssStatusBar.Name = "ssStatusBar"
        Me.ssStatusBar.Size = New System.Drawing.Size(892, 22)
        Me.ssStatusBar.TabIndex = 3
        Me.ssStatusBar.Text = "ssStatusBar"
        '
        'sslabel1
        '
        Me.sslabel1.ForeColor = System.Drawing.Color.Lime
        Me.sslabel1.IsLink = True
        Me.sslabel1.LinkColor = System.Drawing.Color.Lime
        Me.sslabel1.Name = "sslabel1"
        Me.sslabel1.Size = New System.Drawing.Size(48, 17)
        Me.sslabel1.Text = "sslabel1"
        Me.sslabel1.VisitedLinkColor = System.Drawing.Color.Lime
        '
        'sslabel2
        '
        Me.sslabel2.ForeColor = System.Drawing.Color.Lime
        Me.sslabel2.IsLink = True
        Me.sslabel2.LinkColor = System.Drawing.Color.Lime
        Me.sslabel2.Name = "sslabel2"
        Me.sslabel2.Size = New System.Drawing.Size(48, 17)
        Me.sslabel2.Text = "sslabel2"
        Me.sslabel2.VisitedLinkColor = System.Drawing.Color.Lime
        '
        'sslabel3
        '
        Me.sslabel3.ForeColor = System.Drawing.Color.Lime
        Me.sslabel3.LinkColor = System.Drawing.Color.Lime
        Me.sslabel3.Name = "sslabel3"
        Me.sslabel3.Size = New System.Drawing.Size(48, 17)
        Me.sslabel3.Text = "sslabel3"
        Me.sslabel3.VisitedLinkColor = System.Drawing.Color.Lime
        '
        'statusbarContextMenu
        '
        Me.statusbarContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsChangeUserPassword})
        Me.statusbarContextMenu.Name = "cmsContextMenu"
        Me.statusbarContextMenu.Size = New System.Drawing.Size(169, 26)
        '
        'cmsChangeUserPassword
        '
        Me.cmsChangeUserPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmsChangeUserPassword.Name = "cmsChangeUserPassword"
        Me.cmsChangeUserPassword.Size = New System.Drawing.Size(168, 22)
        Me.cmsChangeUserPassword.Text = "Change Password"
        '
        'NotifyIcon4OpenCases
        '
        Me.NotifyIcon4OpenCases.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.NotifyIcon4OpenCases.Icon = CType(resources.GetObject("NotifyIcon4OpenCases.Icon"), System.Drawing.Icon)
        Me.NotifyIcon4OpenCases.Text = "Open Cases"
        Me.NotifyIcon4OpenCases.Visible = True
        '
        'Timer4OpenCases
        '
        Me.Timer4OpenCases.Interval = 60000
        '
        'tsmiExpenseReportCult
        '
        Me.tsmiExpenseReportCult.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiExpenseReportCult_WithSummary, Me.tsmiExpenseReportCult_WithoutSummary})
        Me.tsmiExpenseReportCult.Name = "tsmiExpenseReportCult"
        Me.tsmiExpenseReportCult.Size = New System.Drawing.Size(211, 22)
        Me.tsmiExpenseReportCult.Text = "Expense Report"
        '
        'tsmiExpenseReportCult_WithSummary
        '
        Me.tsmiExpenseReportCult_WithSummary.Name = "tsmiExpenseReportCult_WithSummary"
        Me.tsmiExpenseReportCult_WithSummary.Size = New System.Drawing.Size(171, 22)
        Me.tsmiExpenseReportCult_WithSummary.Text = "With Summary"
        '
        'tsmiExpenseReportCult_WithoutSummary
        '
        Me.tsmiExpenseReportCult_WithoutSummary.Name = "tsmiExpenseReportCult_WithoutSummary"
        Me.tsmiExpenseReportCult_WithoutSummary.Size = New System.Drawing.Size(171, 22)
        Me.tsmiExpenseReportCult_WithoutSummary.Text = "Without Summary"
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(892, 719)
        Me.Controls.Add(Me.ssStatusBar)
        Me.Controls.Add(Me.msMenubar)
        Me.ForeColor = System.Drawing.Color.Black
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMenubar
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facility Management Solution for GFH HIG Association"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMenubar.ResumeLayout(False)
        Me.msMenubar.PerformLayout()
        Me.ssStatusBar.ResumeLayout(False)
        Me.ssStatusBar.PerformLayout()
        Me.statusbarContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msMenubar As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_System As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLogOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssStatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents sslabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusbarContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsChangeUserPassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCOA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Manage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Journal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageFlatAndOwnerDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sslabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsmiDBBackup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiMarkEndOfDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDefaulterList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageJournal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MiscToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSyncOwnerDetailsFromPortal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowTemporaryReceipts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiPerformBilling As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecurityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAccessManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiGeneratePWD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReconcileBankStatement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiJournalBankStatement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManagePayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBookReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBillMailer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSearchFlatOwner As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCOAReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDefaulterListBGF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDefaulterListAssociation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCharting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiParking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBackDateEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageReceiptBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageChequeBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCashBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCashBook_WithSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCashBook_WithoutSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Sav As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Sav_WithSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Sav_WithoutSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Cur As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Cur_WithSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBook_Cur_WithoutSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageTenants As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReport_WithSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReport_WithoutSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiMiscCharting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageServiceCase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon4OpenCases As System.Windows.Forms.NotifyIcon
    Friend WithEvents Timer4OpenCases As System.Windows.Forms.Timer
    Friend WithEvents tsmiManageVoucherBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManageSystemParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsForAuditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReceiptsPaymentsReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiNewCashBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiNewBankBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiIncomeExpenseReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBalanceSheet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBookReceiptCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewReceiptCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSpecialTransactions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiManagePaymentCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiJournalBankStatementCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReconcileBankStatementCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowFlatDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CulturalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCashBookCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBankBookCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBalanceSheetCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiIncomeExpenseReportCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReceiptsPaymentsReportCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSpecialTransactionsCultural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionDrillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BalanceSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiFutureDateEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReportCult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReportCult_WithSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExpenseReportCult_WithoutSummary As System.Windows.Forms.ToolStripMenuItem

End Class
