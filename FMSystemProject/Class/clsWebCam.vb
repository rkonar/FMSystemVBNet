Imports System.Runtime.InteropServices
Public Class clsWebCam
    Const WM_CAP As Short = &H400S

    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Public hHwnd As Integer ' Handle to preview window

    Public curImageDeviceID As Integer
    Public ImageDevices As New List(Of String)

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    Public Sub New()
        curImageDeviceID = 0
    End Sub

    Public Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0

        ' Load name of all avialable devices into the lstDevices
        Do
            '   Get Driver name and version
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)

            ' If there was a device, add device name to the list
            If bReturn Then ImageDevices.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False

    End Sub
    Public Sub OpenPreviewWindow(picBox As PictureBox)
        'Dim piccapture As PictureBox = PictureBox1
        Dim iHeight As Integer = picBox.Height
        Dim iWidth As Integer = picBox.Width

        ' Open Preview window in picturebox
        hHwnd = capCreateCaptureWindowA(curImageDeviceID, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, picBox.Handle.ToInt32, 0)

        ' Connect to device
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, curImageDeviceID, 0) Then

            'Set the preview scale
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            'Set the preview rate in milliseconds
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            'Start previewing the image from the camera
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            ' Resize window to fit in picturebox
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picBox.Width, picBox.Height, SWP_NOMOVE Or SWP_NOZORDER)

        End If

    End Sub

    Public Sub TakeSnapToPicBox(picBox As PictureBox)
        Dim ClipData As IDataObject
        Dim bmap As Image

        ' Copy image to clipboard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        ' Get image from clipboard and convert it to a bitmap
        ClipData = Clipboard.GetDataObject()
        If ClipData.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(ClipData.GetData(GetType(System.Drawing.Bitmap)), Image)
            picBox.Image = bmap
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        bmap = Nothing
        ClipData = Nothing
        Clipboard.Clear()
    End Sub
    Public Sub TakeSnapToJpgFile(fileNameWithPath As String)
        Dim ClipData As IDataObject
        Dim bmap As Image

        ' Copy image to clipboard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        ' Get image from clipboard and convert it to a bitmap
        ClipData = Clipboard.GetDataObject()
        If ClipData.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(ClipData.GetData(GetType(System.Drawing.Bitmap)), Image)
            bmap.Save(fileNameWithPath, Imaging.ImageFormat.Jpeg)
        End If

        bmap = Nothing
        ClipData = Nothing
        Clipboard.Clear()

    End Sub
End Class
