Module modBill
    'Template worksheet
    Public Const RANGE_Template_BillDate = "P3"

    Public Const RANGE_Template_BillNum = "O5"
    Public Const RANGE_Template_Period = "K5"
    Public Const RANGE_Template_TOWER = "D5"
    Public Const RANGE_Template_FLAT = "H5"

    Public Const RANGE_Template_NAME = "D7"
    Public Const RANGE_Template_EMAIL = "M7"

    Public Const RANGE_Template_DueDate = "O9" ' "E13"

    Public Const RANGE_Template_Table_R1C1 = "B11"
    Public Const RANGE_Template_Table_R1C2 = "M11"
    Public Const RANGE_Template_Table_R1C3 = "O11"
    Public Const RANGE_Template_Table_R1C4 = "P11"


    'Public Const RANGE_Template_Table_R2C1 = "B18"
    'Public Const RANGE_Template_Table_R3C1 = "B19"

    'Public Const RANGE_Template_Table_R2C2 = "C18"
    'Public Const RANGE_Template_Table_R3C2 = "C19"

    'Public Const RANGE_Template_Table_R2C3 = "D18"
    'Public Const RANGE_Template_Table_R3C3 = "D19"

    'Public Const RANGE_Template_Table_R2C4 = "E18"
    'Public Const RANGE_Template_Table_R3C4 = "E19"

    'Public Const RANGE_Template_Table_R1C5 = "P11"
    'Public Const RANGE_Template_Table_R2C5 = "F18"
    'Public Const RANGE_Template_Table_R3C5 = "F19"

    'Public Const RANGE_Template_BillNet = "D20"


    Public Const RANGE_Template_Table_R2C1 = "B12"
    Public Const RANGE_Template_Table_R2C2 = "M12"
    Public Const RANGE_Template_Table_R2C3 = "O12"
    Public Const RANGE_Template_Table_R2C4 = "P12"

    Public Const RANGE_Template_Table_R3C1 = "B13"
    Public Const RANGE_Template_Table_R3C2 = "M13"
    Public Const RANGE_Template_Table_R3C3 = "O13"
    Public Const RANGE_Template_Table_R3C4 = "P13"

    Public Const RANGE_Template_TotalBillAmount = "P14"

    
    'Generate Bill
    'Public Const RANGE_GenBill_FromMonth = "L2"
    'Public Const RANGE_GenBill_ToMonth = "L3"
    'Public Const RANGE_GenBill_Year = "L4"
    'Public Const RANGE_GenBill_BillDate = "L5"
    'Public Const RANGE_GenBill_OutstandingDate = "L6"
    'Public Const RANGE_GenBill_DueDate = "L7"
    'Public Const RANGE_GenBill_BillPath = "L8"
    'Public Const RANGE_GenBill_Tower = "L10"
    'Public Const RANGE_GenBill_Flat = "L11"
    'Public Const RANGE_GenBill_Status = "K14"


    Public Const TEMPLATE_SHT_2ND_PAGE_STARTROW = 30
    Public Const TEMPLATE_SHT_2ND_PAGE_STARTCOL = "B"

    'Public fso As New FileIO.FileSystem
    Public xlApp As Microsoft.Office.Interop.Excel.Application, templateWrkBook As Microsoft.Office.Interop.Excel.Workbook
    Public sht As Microsoft.Office.Interop.Excel.Worksheet, newSht As Microsoft.Office.Interop.Excel.Worksheet
    Public curSht As Microsoft.Office.Interop.Excel.Worksheet, templateSht As Microsoft.Office.Interop.Excel.Worksheet

End Module
