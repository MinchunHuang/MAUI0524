Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Module Datagrid
    Public Sub Loadexcel()
        FormMain.dt.Columns.Clear()
        FormMain.dt.AllowUserToAddRows = True
        FormMain.dt2.Columns.Clear()
        FormMain.dt2.AllowUserToAddRows = True
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = FormMain.sPath           '開啟時預設的資料夾路徑 
        openfile.Filter = "|*.xlsm"    '只抓excel檔 
        openfile.ShowDialog()

        '塞資料至DataGridView1 
        If openfile.FileName <> "" Then
            Dim conn As String            '連線字串 
            Dim Mycon As OleDbConnection
            Dim myDa As OleDbDataAdapter
            Dim dtt As New DataTable
            Dim aa As Integer
            Dim aaa As Integer
            Dim conn2 As String            '連線字串 
            Dim Mycon2 As OleDbConnection
            Dim myDa2 As OleDbDataAdapter
            Dim dtt2 As New DataTable
            Dim aa2 As Integer
            Dim aaa2 As Integer

            conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'"
            conn2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'"

            Mycon = New OleDb.OleDbConnection(conn)
            myDa = New OleDb.OleDbDataAdapter("select * from [Forload$]", Mycon)
            myDa.Fill(dtt)
            FormMain.dt.DataSource = dtt
            Mycon2 = New OleDb.OleDbConnection(conn2)
            myDa2 = New OleDb.OleDbDataAdapter("select * from [Forload2$]", Mycon2)
            myDa2.Fill(dtt2)
            FormMain.dt2.DataSource = dtt2

            'dt
            For aa = 0 To FormMain.dt.Rows.Count - 2
                FormMain.dt.Rows(aa).HeaderCell.Value = Str(FormMain.dt.Rows(aa).Cells(0).Value)
                FormMain.dt.Columns(aa).HeaderCell.Value = Str(FormMain.dt.Columns(aa + 1).HeaderCell.Value)
            Next
            For aa = 0 To FormMain.dt.Rows.Count - 2
                For aaa = 0 To FormMain.dt.Rows.Count - 2
                    FormMain.dt.Rows(aa).Cells(aaa).Value = FormMain.dt.Rows(aa).Cells(aaa + 1).Value
                Next
            Next
            FormMain.dt.Columns.RemoveAt(FormMain.dt.Rows.Count - 1)
            FormMain.dt.DefaultCellStyle.ForeColor = Color.Black
            FormMain.dt.DefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt.RowHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt.AllowUserToAddRows = False

            'dt2
            For aa2 = 0 To FormMain.dt2.Rows.Count - 2
                FormMain.dt2.Rows(aa2).HeaderCell.Value = Str(FormMain.dt2.Rows(aa2).Cells(0).Value)
                FormMain.dt2.Columns(aa2).HeaderCell.Value = Str(FormMain.dt2.Columns(aa2 + 1).HeaderCell.Value)
            Next
            For aa2 = 0 To FormMain.dt2.Rows.Count - 2
                For aaa2 = 0 To FormMain.dt2.Rows.Count - 2
                    FormMain.dt2.Rows(aa2).Cells(aaa2).Value = FormMain.dt2.Rows(aa2).Cells(aaa2 + 1).Value
                Next
            Next
            FormMain.dt2.Columns.RemoveAt(FormMain.dt2.Rows.Count - 1)
            FormMain.dt2.DefaultCellStyle.ForeColor = Color.Black
            FormMain.dt2.DefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt2.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt2.RowHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
            FormMain.dt2.AllowUserToAddRows = False
        End If
    End Sub
    Public Sub GridExport()
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application()
        MyExcel.Application.Workbooks.Add()
        MyExcel.Visible = True

        '獲取標題
        Dim Cols As Integer
        For Cols = 1 To FormMain.dt.ColumnCount
            MyExcel.Cells(1, Cols + 1) = FormMain.dt.Columns(Cols - 1).HeaderCell.Value
            MyExcel.Cells(Cols + 1, 1) = FormMain.dt.Rows(Cols - 1).HeaderCell.Value
            MyExcel.Cells(3 + FormMain.dt.ColumnCount, Cols + 1) = FormMain.dt.Columns(Cols - 1).HeaderCell.Value
            MyExcel.Cells(Cols + 3 + FormMain.dt.ColumnCount, 1) = FormMain.dt.Rows(Cols - 1).HeaderCell.Value
        Next
        '往excel表裡添加資料()
        Dim i, j As Integer
        For i = 0 To FormMain.dt.RowCount - 1
            For j = 0 To FormMain.dt.ColumnCount - 1
                MyExcel.Cells(i + 2, j + 2) = FormMain.dt(j, i).Value
                MyExcel.Cells(i + 4 + FormMain.dt.ColumnCount, j + 2) = FormMain.dt2(j, i).Value
            Next j
        Next i
    End Sub





End Module

