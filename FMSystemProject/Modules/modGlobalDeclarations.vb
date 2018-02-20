Module modGlobalDeclarations

    Public Structure flatType
        Dim tblid As String
        Dim FlatCode As String
        Dim TowerName As String
        Dim SBUSqFtArea As String
        Dim TerraceSqFtArea As String
        Dim NoOfRooms As String
        Dim IsPartOfDuplex As String
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
    End Structure

    Public Structure Parking
        Dim ParkingButton As Button
        Dim BackColor As Color
    End Structure

    Public Const MAX_XL_ROWCOUNT = 65536
    Public Const MAX_XL_WRKSHT_NAME_LEN = 31
    Public Const MAX_IMAGE_SIZE_KB = 1500

    Public Const SCREEN_BASE_WIDTH = 1920
    Public Const SCREEN_BASE_HEIGHT = 1080

    Public DSN_NAME As String
    Public gcon As New ADODB.Connection
    Public gcon2 As New ADODB.Connection
    Public grset As ADODB.Recordset
    Public grecAffected As Integer

    Public rsReceipts As ADODB.Recordset
    Public rsReceipts2 As ADODB.Recordset

    Public rsBills As ADODB.Recordset
    Public rsBills2 As ADODB.Recordset

    Public rsJournalBilled As ADODB.Recordset

    Public rsJournalPaid As ADODB.Recordset

    Public tmpRS As ADODB.Recordset
    Public tmpRS2 As ADODB.Recordset

    Public ssql As String
    Public FLATS() As String = {"SAP01A", "SAP01B", "SAP01C", "SAP01D", "SAP02A", "SAP02B", "SAP02C", "SAP02D", "SAP03A", "SAP03B", "SAP03C", "SAP03D", "SAP04A", "SAP04B", "SAP04C", "SAP04D", "SAP05A", "SAP05B", "SAP05C", "SAP05D", "SAP06A", "SAP06B", "SAP06C", "SAP06D", "SAP07A", "SAP07B", "SAP07C", "SAP07D", "SAP08A", "SAP08B", "SAP08C", "SAP08D", "SAP09A", "SAP09B", "SAP09C", "SAP09D", "SAP10A", "SAP10B", "SAP10C", "SAP10D", "SAP11A", "SAP11B", "SAP11C", "SAP11D", "SAP12A", "SAP12B", "SAP12C", "SAP12D", "SAP13A", "SAP13B", "SAP13C", "SAP13D", "SAP14A", "SAP14B", "SAP14C", "SAP14D", "SAP15A", "SAP15B", "SAP15C", "SAP15D", "SAP16A", "SAP16B", "SAP16C", "SAP16D", "SAP17A", "SAP17B", "SAP17C", "SAP17D", "SAN01A", "SAN01B", "SAN01C", "SAN01D", "SAN02A", "SAN02B", "SAN02C", "SAN02D", "SAN03A", "SAN03B", "SAN03C", "SAN03D", "SAN04A", "SAN04B", "SAN04C", "SAN04D", "SAN05A", "SAN05B", "SAN05C", "SAN05D", "SAN06A", "SAN06B", "SAN06C", "SAN06D", "SAN07A", "SAN07B", "SAN07C", "SAN07D", "SAN08A", "SAN08B", "SAN08C", "SAN08D", "SAN09A", "SAN09B", "SAN09C", "SAN09D", "SAN10A", "SAN10B", "SAN10C", "SAN10D", "SAN11A", "SAN11B", "SAN11C", "SAN11D", "SAN12A", "SAN12B", "SAN12C", "SAN12D", "SAN13A", "SAN13B", "SAN13C", "SAN13D", "SAN14A", "SAN14B", "SAN14C", "SAN14D", "SAN15A", "SAN15B", "SAN15C", "SAN15D", "SAN16A", "SAN16B", "SAN16C", "SAN16D", "SAN17A", "SAN17B", "SAN17C", "SAN17D", "SHR01A", "SHR01B", "SHR01C", "SHR01D", "SHR02A", "SHR02B", "SHR02C", "SHR02D", "SHR03A", "SHR03B", "SHR03C", "SHR03D", "SHR04A", "SHR04B", "SHR04C", "SHR04D", "SHR05A", "SHR05B", "SHR05C", "SHR05D", "SHR06A", "SHR06B", "SHR06C", "SHR06D", "SHR07A", "SHR07B", "SHR07C", "SHR07D", "SHR08A", "SHR08B", "SHR08C", "SHR08D", "SHR09A", "SHR09B", "SHR09C", "SHR09D", "SHR10A", "SHR10B", "SHR10C", "SHR10D", "SHR11A", "SHR11B", "SHR11C", "SHR11D", "SHR12A", "SHR12B", "SHR12C", "SHR12D", "SHR13A", "SHR13B", "SHR13C", "SHR13D", "SHR14A", "SHR14B", "SHR14C", "SHR14D", "SHR15A", "SHR15B", "SHR15C", "SHR15D", "SHR16A", "SHR16B", "SHR16C", "SHR16D", "SHR17A", "SHR17B", "SHR17C", "SHR17D", "SUK01A", "SUK01B", "SUK01C", "SUK01D", "SUK02A", "SUK02B", "SUK02C", "SUK02D", "SUK03A", "SUK03B", "SUK03C", "SUK03D", "SUK04A", "SUK04B", "SUK04C", "SUK04D", "SUK05A", "SUK05B", "SUK05C", "SUK05D", "SUK06A", "SUK06B", "SUK06C", "SUK06D", "SUK07A", "SUK07B", "SUK07C", "SUK07D", "SUK08A", "SUK08B", "SUK08C", "SUK08D", "SUK09A", "SUK09B", "SUK09C", "SUK09D", "SUK10A", "SUK10B", "SUK10C", "SUK10D", "SUK11A", "SUK11B", "SUK11C", "SUK11D", "SUK12A", "SUK12B", "SUK12C", "SUK12D", "SUK13A", "SUK13B", "SUK13C", "SUK13D", "SUK14A", "SUK14B", "SUK14C", "SUK14D", "SUK15A", "SUK15B", "SUK15C", "SUK15D", "SUK16A", "SUK16B", "SUK16C", "SUK16D", "SUK17A", "SUK17B", "SUK17C", "SUK17D"} ', "NONAME"}
    Public MISC_PAYEE() As String = {"BSNLTD", "OTHERS", "TENANT", "VODAFO"}
    Public UNKNOWN_PAYEE() As String = {"------"}
    Public MISC_PAYEE_CULT() As String = {"WBSEB", "TENANT", "OTHERS"}
    Public TOWERS() As String = {"SAPTARSHI", "SANDHYATARA", "SHROBONA", "SUKTARA"}
    Public INSTRUMENT_TYPES() As String = {"CHEQUE", "CASH", "ONLINE"}

    Public dtpDateSelected As String
    Public dtpFromDateSelected As String
    Public dtpToDateSelected As String
    Public Const DB_DATEFORMAT = "yyyyMMdd"
    Public Const DB_TIMEFORMAT = "HHmmss"
    Public Const SCREEN_DATEFORMAT = "dd-MMM-yyyy"
    Public Const SCREEN_TIMEFORMAT = "HH:mm:ss"
    Public Const SCREEN_DATETIMEFORMAT = "dd-MMM-yyyy HH:mm:ss"
    Public Const DB_DATETIMEFORMAT = "yyyyMMddHHmm"

    Public gUserID As String, gLoginID As String, gUserName As String, gItemCode As String, gOldItemCode As String, gItemID As String, gItemAction As String, gRoleID As String, gCurRoleID As String, gRoleCode As String, gCurRoleCode As String, gRoleDesc As String, gCurRoleDesc As String, gRoleStatus As String, gCurRoleStatus As String, gCanView As String, gCanCreate As String, gCanEdit As String, gCanDelete As String
    Public gCurFlatCode As String, gCurTowerName As String, gCurBillNo As String, gCurReceiptNo As String, gCurTblID As String, gCurGID As String, gCurRefGID As String

    Public gChildActStr As String
    Public BankNames() As String
    Public OurBankNames() As String = {"South Indian Bank"}

    Public ImageItemType As String
    Public ImageItemNo As String
    Public NetLineStyle As New DataGridViewCellStyle

    Public gFlats As New clsFlat
    Public gUserResponse As MsgBoxResult

    Public gFinYear As New clsFinYear
    Public gAllowBackDateEntry As Boolean = False
    Public gAllowFutureDateEntry As Boolean = False
    Public gAllowBankChargeEntryOnly As Boolean = False
    Public gLastAuditDate As String = ""

    Public gSMS As New clsSendSMS

    Public gFormDataChanged As Boolean = False
    'SaveImageData Form Public variables
    Public gFormTitle As String = ""

    Public gSortCol As String
    Public gOrderbyStr As String
    Public gParentReportAccount As String = ""
    Public gSelectedReportAccount As String = ""

    Public gOrgCaption As String = ""
    Structure structSysParams
        Dim paramname As String
        Dim paramvalue As String
        Dim encrypted As String
    End Structure
    Public gSysParams As New List(Of structSysParams)
    Public gBackupCommandString As String = ""

    Public gErrMsg As String
    Public gErrDesc As String

    Public gReportPeriodFormat As String 'Date or DateTime
End Module
