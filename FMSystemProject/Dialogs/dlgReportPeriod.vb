Imports System.Windows.Forms

Public Class dlgReportPeriod



    Private Sub dlgDtpDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboFinYear.Items.Clear()
        For x = 2011 To Year(DateTime.Now)
            cboFinYear.Items.Add("FY " & x & "-" & x + 1)
        Next
        cboFinYear.SelectedIndex = -1

        If Month(DateTime.Now) < 4 Then
            dtpFromDate.Text = "01-Apr-" & Year(DateTime.Now) - 1
        Else
            dtpFromDate.Text = "01-Apr-" & Year(DateTime.Now)
        End If
        dtpToDate.Text = DateTime.Now.ToString(SCREEN_DATEFORMAT)

        dtpFromDateSelected = ""
        dtpToDateSelected = ""

        Me.Left = Cursor.Position.X
        Me.Top = Cursor.Position.Y
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    

    Private Sub cboFinYear_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboFinYear.SelectedValueChanged
        Dim tmpToYear As String
        If cboFinYear.Text = "" Then Exit Sub

        tmptoYear = myRight(cboFinYear.Text, 4)

        dtpFromDate.Text = "01-Apr-" & tmpToYear - 1
        dtpToDate.Text = "31-Mar-" & tmpToYear


    End Sub

    Private Sub dtpFromDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFromDate.ValueChanged
        cboFinYear.SelectedIndex = -1
    End Sub

    Private Sub dtpToDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpToDate.ValueChanged
        cboFinYear.SelectedIndex = -1
    End Sub

   
    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        dtpFromDateSelected = dtpFromDate.Text
        dtpToDateSelected = dtpToDate.Text
        Me.Close()
    End Sub
End Class
