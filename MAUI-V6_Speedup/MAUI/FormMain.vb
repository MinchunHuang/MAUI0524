Imports System.Threading
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Public Class FormMain
    Public sPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Int32, ByVal FileName As String) As Int32
    Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal AppName As String, ByVal KeyName As String, ByVal lpString As String, ByVal FileName As String) As Int32
    Dim ODgray As New List(Of Integer)({0, 255})
    Dim ODLgray As New List(Of Integer)({0, 255})
    Dim JSgray As New List(Of Integer)({0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 176, 192, 208, 224, 240, 255})
    Dim OD110gray As New List(Of Integer)({})
    Dim OD110percent As New List(Of Integer)({})
    Dim OD110percent2 As New List(Of Integer)({})
    Dim OD90gray As New List(Of Integer)({})
    Dim OD90percent As New List(Of Integer)({})
    Dim OD90percent2 As New List(Of Integer)({})
    Dim OD110grayrise As New List(Of Integer)({})
    Dim OD110percentrise As New List(Of Integer)({})
    Dim OD110percentrise2 As New List(Of Integer)({})
    Dim OD90grayrise As New List(Of Integer)({})
    Dim OD90percentrise As New List(Of Integer)({})
    Dim OD90percentrise2 As New List(Of Integer)({})
    Dim OD110grayfall As New List(Of Integer)({})
    Dim OD110percentfall As New List(Of Integer)({})
    Dim OD110percentfall2 As New List(Of Integer)({})
    Dim OD90grayfall As New List(Of Integer)({})
    Dim OD90percentfall As New List(Of Integer)({})
    Dim OD90percentfall2 As New List(Of Integer)({})
    Dim Colorlist As New List(Of Integer)({})
    Dim sInputInifile As String
    Public Internetname As String
    Public Stepchoose As String
    Public SG, TG, OG, OGL, NextOG, NextOGL, STG, Colorindex As Integer
    Dim col, ro As Integer
    Dim Singlearray(300, 4) As Integer
    Dim check As Integer, check1 As Integer, check2 As Integer
    Dim thesame As Integer, thesame1 As Integer, thesame2 As Integer
    Dim countfail As Integer, countrise As Integer, countfall As Integer
    Dim i As Integer, j As Integer
    Dim icount, pcount As Integer
    Dim Colorcount As Integer
    Dim Dontfindod As Boolean, Dontclose As Boolean
    Dim Findsingleodpercent As Boolean
    Dim Findsingleod As Boolean
    Dim Savecurve As Boolean
    Dim Checkhalf As Boolean
    Dim Find100 As Boolean
    Dim Cycle As Boolean
    Dim Graylevel As Boolean
    Dim Tenp As Boolean
    Dim Sametime As Boolean
    Dim ODpercent As Single
    Dim RT, RTL As Single
    Dim risetime As Single, falltime As Single
    Dim Nover As Single, sNover As Single, Pover As Single, sPover As Single
    Dim ampMax As Single, ampMin As Single, Max As Single, Min As Single
    Dim amp10 As Single, amp90 As Single

    Public Function CTGetProfileString(ByVal sConfigFileName As String, ByVal sSection As String, ByVal sKey As String) As String
        Dim sBuffer As String
        sBuffer = Space(256)
        Dim lResult As Int32
        lResult = GetPrivateProfileString(sSection, sKey, "", sBuffer, 256, sConfigFileName)
        CTGetProfileString = Mid(sBuffer, 1, InStr(sBuffer, Chr(0)) - 1)
    End Function

    Public Sub CTSaveProfileString(ByVal sConfigFileName As String, ByVal sSection As String, ByVal sKey As String, ByVal sValue As String)
        Call WritePrivateProfileString(sSection, sKey, sValue, sConfigFileName)
    End Sub

    Public Sub getparameter()
        sInputInifile = sPath & "\" & "Setting.ini"
        Internetname = CStr(CTGetProfileString(sInputInifile, "Condition", "ID"))
        SG = CInt(CTGetProfileString(sInputInifile, "Condition", "Start"))
        OG = CInt(CTGetProfileString(sInputInifile, "Condition", "OD"))
        TG = CInt(CTGetProfileString(sInputInifile, "Condition", "Target"))
        OGL = CInt(CTGetProfileString(sInputInifile, "Condition", "ODL"))
        STG = CInt(CTGetProfileString(sInputInifile, "Condition", "Step"))
        Colorindex = CInt(CTGetProfileString(sInputInifile, "Condition", "Color"))
        pcount = CInt(CTGetProfileString(sInputInifile, "Condition", "Count"))
    End Sub

    Public Sub saveparameter(ByVal Sgray As Integer, ByVal Ogray As Integer, ByVal Tgray As Integer, ByVal OLgray As Integer, ByVal STgray As Integer)
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Start", Sgray)
        CTSaveProfileString(sInputInifile, "Condition", "OD", Ogray)
        CTSaveProfileString(sInputInifile, "Condition", "Target", Tgray)
        CTSaveProfileString(sInputInifile, "Condition", "ODL", OLgray)
        CTSaveProfileString(sInputInifile, "Condition", "Step", STgray)
    End Sub

    Private Sub savelocation(ByVal closejudge As Integer)
        sInputInifile = sPath & "\" & "Settinglo.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Judge", closejudge)
    End Sub

    Private Sub savecolor(ByVal colorjudge As Integer)
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Color", colorjudge)
    End Sub

    Private Sub ColorW_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorW.CheckedChanged
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Color", 0)
        If ColorW.Checked = False Then
            Colorlist.RemoveAt(Colorlist.IndexOf(0))
        Else
            Colorlist.Add(0)
        End If
        Cycle = False
    End Sub

    Private Sub ColorR_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorR.CheckedChanged
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Color", 1)
        If ColorR.Checked = False Then
            Colorlist.RemoveAt(Colorlist.IndexOf(1))
        Else
            Colorlist.Add(1)
        End If
        Cycle = False
    End Sub

    Private Sub ColorG_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorG.CheckedChanged
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Color", 2)
        If ColorG.Checked = False Then
            Colorlist.RemoveAt(Colorlist.IndexOf(2))
        Else
            Colorlist.Add(2)
        End If
        Cycle = False
    End Sub

    Private Sub ColorB_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorB.CheckedChanged
        sInputInifile = sPath & "\" & "Setting.ini"
        CTSaveProfileString(sInputInifile, "Condition", "Color", 3)
        If ColorB.Checked = False Then
            Colorlist.RemoveAt(Colorlist.IndexOf(3))
        Else
            Colorlist.Add(3)
        End If
        Cycle = False
    End Sub

    Private Sub ColorAll_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorAll.CheckedChanged
        Cycle = True
    End Sub

    Private Sub Autostep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Autostep.CheckedChanged
        Graylevel = True
    End Sub

    Private Sub Manualstep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manualstep.CheckedChanged
        Graylevel = False
    End Sub

    Private Sub JSstep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JSstep.CheckedChanged
        Graylevel = False
        For s = 0 To 32
            ListBox1.Items.Add(JSgray(s))
        Next
    End Sub

    Private Sub CallDraw()
        Dim retVal As Process
        retVal = Process.Start(sPath & "\" & "CallDraw.pyw")
        retVal.WaitForExit()
    End Sub

    Private Sub CallDraw2()
        Dim retVal As Process
        retVal = Process.Start(sPath & "\" & "CallDraw2.pyw")
        retVal.WaitForExit()
    End Sub

    Private Sub dt_CellContentClick(ByVal sender As Object, ByVal e As EventArgs) Handles dt.Click
        Static i As Integer
        i = i + 1
        col = dt.CurrentCell.ColumnIndex
        ro = dt.CurrentCell.RowIndex
        saveparameter(CInt(dt.Columns(col).HeaderCell.Value), CInt(dt.CurrentCell.Value), CInt(dt.Rows(ro).HeaderCell.Value), CInt(dt.Rows(ro).HeaderCell.Value), 0)
        Singlearray(i - 1, 0) = CInt(dt.Columns(col).HeaderCell.Value)
        Singlearray(i - 1, 1) = CInt(dt.CurrentCell.Value)
        Singlearray(i - 1, 2) = CInt(dt.Rows(ro).HeaderCell.Value)
        Singlearray(i - 1, 3) = ro
        Singlearray(i - 1, 4) = col
        icount = i - 1
    End Sub

    Private Sub LCRT_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LCRT.Click
        Tenp = False
        Dontclose = False
        Dontfindod = True
        Checkhalf = True
        Find100 = False
        GroupBox4.Visible = False
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub Normal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Normal.Click
        Tenp = False
        Dontclose = False
        Dontfindod = False
        Checkhalf = False
        Find100 = False
        GroupBox4.Visible = False
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub Manual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual.CheckedChanged
        GroupBox4.Visible = True
        Me.Size = New System.Drawing.Size(1093, 723)
    End Sub

    Private Sub Noover_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Noover.CheckedChanged
        Tenp = False
        Sametime = True
        Dontclose = False
        Dontfindod = False
        Checkhalf = True
        Find100 = True
        GroupBox4.Visible = False
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub tenpercent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tenpercent.CheckedChanged
        Tenp = True
        Sametime = True
        Dontclose = False
        Dontfindod = False
        Checkhalf = True
        Find100 = True
        GroupBox4.Visible = False
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub BM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BM.CheckedChanged
        Tenp = False
        Dontclose = False
        Dontfindod = True
        Checkhalf = True
        Find100 = False
        GroupBox4.Visible = False
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub BMODSimu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMODSimu.CheckedChanged
        Tenp = False
        Dontclose = False
        Sametime = True
        Findsingleodpercent = True
        Dontfindod = True
        Checkhalf = True
        Find100 = False
        GroupBox4.Visible = True
        Me.Size = New System.Drawing.Size(1093, 723)
    End Sub

    Private Sub BMGL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMGL.CheckedChanged
        Tenp = False
        Dontclose = False
        Findsingleod = True
        Dontfindod = False
        Checkhalf = False
        Find100 = False
        GroupBox4.Visible = True
        Me.Size = New System.Drawing.Size(1093, 723)
    End Sub

    Private Sub Savedata_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savedata.CheckedChanged
        Savecurve = True
    End Sub

    Private Sub Dontsavedata_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dontsavedata.CheckedChanged
        Savecurve = False
    End Sub

    Private Sub pattern_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pattern.Click
        If Dontclose = True Then
            savelocation(20)
        Else
            savelocation(0)
        End If
        callpattern()
    End Sub

    Private Sub Exitbutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Exitbutton.Click
        Environment.Exit(Environment.ExitCode)
        Application.Exit()
    End Sub

    Private Sub LoadExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadExcel.Click
        Datagrid.Loadexcel()
    End Sub

    Private Sub Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatagridExport.Click
        Datagrid.GridExport()
    End Sub

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(367, 723)
    End Sub

    Private Sub Start_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Start.Click, SingleStart.Click, MultiStart.Click
        Dim SGvolt As Single, OGvolt As Single, SOvolt As Single, Scalechoose As Single
        Dim scale0 As Double, scale1 As Double, scale2 As Double
        Dim x As Single, x1 As String
        Dim multiple As Integer
        Dim OGindex As Integer
        Dim OGLindex As Integer
        Dim Stepcount As Integer, Graycount As Integer, Listcount As Integer
        Dim Mode As Integer
        Dim loopcount As Integer
        Dim IndexLAST As String, IndexLOW As String, IndexMid As String, strread As String, IndexMid2 As String, IndexLOW2 As String, Judgestatus As String, IndexMidP As String, IndexMidN As String
        Dim Indexint As Single
        Dim SGchange As Boolean

        If DirectCast((sender), Button).Text = "Single Start" Then
            Mode = 1
        ElseIf DirectCast((sender), Button).Text = "Multi Start" Then
            Mode = 2
        ElseIf DirectCast((sender), Button).Text = "Start" Then
            Mode = 0
        Else
        End If
        If Cycle = True Then
            Colorindex = Colorlist(0)
            sInputInifile = sPath & "\" & "Setting.ini"
            CTSaveProfileString(sInputInifile, "Condition", "Color", Colorindex)
            Colorcount = 1
        End If
        Waverunner.Initial()
        System.Threading.Thread.Sleep(8000)
        Waverunner.Calibration()
        If Graylevel = True Then
            Stepchoose = Graylevelstep.Text
        Else
            SGchange = False
            Listcount = ListBox1.Items.Count()
            Stepcount = 1
            Graycount = 0
            Stepchoose = ListBox1.Items(1) - ListBox1.Items(0)
        End If
        If Mode = 0 Then
            ODpercent = (0.01 * (Overshoot.Text - 2)) - 1
            saveparameter(0, Stepchoose, Stepchoose, 0, Stepchoose)
            'saveparameter(176, 192, 192, Stepchoose)
        ElseIf Mode = 1 Then
            ODpercent = (0.01 * (NewOD.Text - 2)) - 1
            saveparameter(CInt(dt.Columns(col).HeaderCell.Value), CInt(dt.CurrentCell.Value), CInt(dt.Rows(ro).HeaderCell.Value), CInt(dt.Rows(ro).HeaderCell.Value), 0)
        ElseIf Mode = 2 Then
        ODpercent = (0.01 * (NewOD.Text - 2)) - 1
        saveparameter(Singlearray(0, 0), Singlearray(0, 1), Singlearray(0, 2), Singlearray(0, 2), 0)
        Else
        End If
        getparameter()
        Cleanexcel()
        Do While check = 0
            Try
                Application.DoEvents()
                thesame = 0
                If Findsingleod = True Then
                    For Me.i = 0 To 16
                        If dt2.Columns(i).HeaderCell.Value = SG Then
                            col = i
                            Exit For
                        End If
                    Next
                    For Me.j = 0 To 16
                        If dt2.Rows(j).HeaderCell.Value = TG Then
                            ro = j
                            Exit For
                        End If
                    Next
                    Overshoot.Text = dt2.Rows(ro).Cells(col).Value
                    ODpercent = (0.00995 * Overshoot.Text) - 1
                Else
                End If

                If Findsingleodpercent = True Then
                    For Me.i = 0 To 16
                        If dt.Columns(i).HeaderCell.Value = SG Then
                            col = i
                            Exit For
                        End If
                    Next
                    For Me.j = 0 To 16
                        If dt.Rows(j).HeaderCell.Value = TG Then
                            ro = j
                            Exit For
                        End If
                    Next
                    OG = dt.Rows(ro).Cells(col).Value
                    OGL = dt.Rows(col).Cells(ro).Value
                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                    ODpercent = (0.00995 * Overshoot.Text) - 1
                Else
                End If
                getparameter()
                If pcount Mod 59 = 0 Then
                    System.Threading.Thread.Sleep(10000)
                Else
                End If

                scope.WriteString("C1:OFST 0")

                If Sametime = True Then
                    SGvolt = (OG / 255) ^ 2.2
                    OGvolt = (OGL / 255) ^ 2.2
                    SOvolt = Int(Math.Abs(OGvolt - SGvolt) * volt)
                    Scalechoose = SOvolt
                Else
                    SGvolt = (SG / 255) ^ 2.2
                    OGvolt = (OG / 255) ^ 2.2
                    SOvolt = Int(Math.Abs(OGvolt - SGvolt) * volt)
                    Scalechoose = SOvolt
                End If

                'First time
                If Sametime = True Then
                    x = Math.Round((OGvolt * volt) + Math.Abs(SOvolt), 1)
                Else
                    If OG > SG Then
                        x = Math.Round((SGvolt * volt) + Math.Abs(SOvolt), 1)
                    Else
                        x = Math.Round((OGvolt * volt) + Math.Abs(SOvolt), 1)
                    End If
                End If
                x1 = String.Format("C1:OFST -{0}V", x / 1000)
                If 6500 < Scalechoose And Scalechoose <= 9000 Then
                    scope.WriteString("C1:VDIV 3V")
                    scale0 = 3
                ElseIf 6000 < Scalechoose And Scalechoose <= 6500 Then
                    scope.WriteString("C1:VDIV 2.5V")
                    scale0 = 2.5
                ElseIf 4500 < Scalechoose And Scalechoose <= 6000 Then
                    scope.WriteString("C1:VDIV 2V")
                    scale0 = 2
                ElseIf 3000 < Scalechoose And Scalechoose <= 4500 Then
                    scope.WriteString("C1:VDIV 1.5V")
                    scale0 = 1.5
                ElseIf 2250 < Scalechoose And Scalechoose <= 3000 Then
                    scope.WriteString("C1:VDIV 1V")
                    scale0 = 1
                ElseIf 1500 < Scalechoose And Scalechoose <= 2250 Then
                    scope.WriteString("C1:VDIV 0.75V")
                    scale0 = 0.75
                Else
                    scope.WriteString("C1:VDIV 0.5V")
                    scale0 = 0.5
                End If
                scope.WriteString(x1)
                System.Threading.Thread.Sleep(3500)
                scope.WriteString("PAST? CUST,P7")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Max = Indexint
                scope.WriteString("PAST? CUST,P8")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Min = Indexint
                Scalechoose = Max - Min
                Application.DoEvents()

                'Second time
                If 11200 < Scalechoose And Scalechoose <= 16800 Then
                    scope.WriteString("C1:VDIV 3V")
                    scale1 = 3
                ElseIf 5600 < Scalechoose And Scalechoose <= 11200 Then
                    scope.WriteString("C1:VDIV 2V")
                    scale1 = 2
                ElseIf 2800 < Scalechoose And Scalechoose <= 5600 Then
                    scope.WriteString("C1:VDIV 1V")
                    scale1 = 1
                ElseIf 1120 < Scalechoose And Scalechoose <= 2800 Then
                    scope.WriteString("C1:VDIV 0.5V")
                    scale1 = 0.5
                ElseIf 560 < Scalechoose And Scalechoose <= 1120 Then
                    scope.WriteString("C1:VDIV 0.2V")
                    scale1 = 0.2
                ElseIf 280 < Scalechoose And Scalechoose <= 560 Then
                    scope.WriteString("C1:VDIV 0.1V")
                    scale1 = 0.1
                ElseIf 140 < Scalechoose And Scalechoose <= 280 Then
                    scope.WriteString("C1:VDIV 0.05V")
                    scale1 = 0.05
                Else
                    scope.WriteString("C1:VDIV 0.02V")
                    scale1 = 0.02
                End If
                If scale0 <> scale1 Then
                    x = Math.Round((Scalechoose / 2) + Min, 1)
                    x1 = String.Format("C1:OFST -{0}V", x / 1000)
                    scope.WriteString(x1)
                    System.Threading.Thread.Sleep(3500)
                Else
                End If
                scope.WriteString("PAST? CUST,P7")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Max = Indexint
                scope.WriteString("PAST? CUST,P8")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Min = Indexint
                Scalechoose = Max - Min
                Application.DoEvents()

                'Third time
                If 14400 < Scalechoose And Scalechoose <= 19200 Then
                    scope.WriteString("C1:VDIV 3V")
                    scale2 = 3
                ElseIf 6400 < Scalechoose And Scalechoose <= 14400 Then
                    scope.WriteString("C1:VDIV 2V")
                    scale2 = 2
                ElseIf 3200 < Scalechoose And Scalechoose <= 6400 Then
                    scope.WriteString("C1:VDIV 1V")
                    scale2 = 1
                ElseIf 1440 < Scalechoose And Scalechoose <= 3200 Then
                    scope.WriteString("C1:VDIV 0.5V")
                    scale2 = 0.5
                ElseIf 640 < Scalechoose And Scalechoose <= 1440 Then
                    scope.WriteString("C1:VDIV 0.2V")
                    scale2 = 0.2
                ElseIf 320 < Scalechoose And Scalechoose <= 640 Then
                    scope.WriteString("C1:VDIV 0.1V")
                    scale2 = 0.1
                ElseIf 128 < Scalechoose And Scalechoose <= 320 Then
                    scope.WriteString("C1:VDIV 0.05V")
                    scale2 = 0.05
                ElseIf 64 < Scalechoose And Scalechoose <= 128 Then
                    scope.WriteString("C1:VDIV 0.02V")
                    scale2 = 0.02
                ElseIf 32 < Scalechoose And Scalechoose <= 64 Then
                    scope.WriteString("C1:VDIV 0.01V")
                    scale2 = 0.01
                ElseIf 13 < Scalechoose And Scalechoose <= 32 Then
                    scope.WriteString("C1:VDIV 0.005V")
                    scale2 = 0.005
                ElseIf 7 < Scalechoose And Scalechoose <= 13 Then
                    scope.WriteString("C1:VDIV 0.002V")
                    scale2 = 0.002
                ElseIf 0 < Scalechoose And Scalechoose <= 7 Then
                    scope.WriteString("C1:VDIV 0.001V")
                    scale2 = 0.001
                Else
                    scope.WriteString("C1:VDIV 0.02V")
                    scale2 = 0.02
                End If
                If scale1 <> scale2 Then
                    x = Math.Round((Scalechoose / 2) + Min, 1)
                    x1 = String.Format("C1:OFST -{0}V", x / 1000)
                    scope.WriteString(x1)
                    System.Threading.Thread.Sleep(3500)
                Else
                End If
                Application.DoEvents()
                scope.WriteString("PAST? CUST,P7")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Max = Indexint
                scope.WriteString("PAST? CUST,P8")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Min = Indexint
                scope.WriteString("C1:PAVA? TOP")
                strread = scope.ReadString
                IndexLAST = Microsoft.VisualBasic.Right(strread, 3)
                Judgestatus = Microsoft.VisualBasic.Left(IndexLAST, 2)
                If scale2 = 0.02 Then
                    If Judgestatus = "UF" Or Judgestatus = "OF" Then
                        x1 = String.Format("C1:VDIV 0.05V")
                        scope.WriteString(x1)
                        System.Threading.Thread.Sleep(3500)
                    Else
                    End If
                ElseIf scale2 = 0.05 Then
                    If Judgestatus = "UF" Or Judgestatus = "OF" Then
                        x1 = String.Format("C1:VDIV 0.1V")
                        scope.WriteString(x1)
                        System.Threading.Thread.Sleep(3500)
                    Else
                    End If
                ElseIf scale2 = 0.1 Then
                    If Judgestatus = "UF" Or Judgestatus = "OF" Then
                        x1 = String.Format("C1:VDIV 0.2V")
                        scope.WriteString(x1)
                        System.Threading.Thread.Sleep(3500)
                    Else
                    End If
                Else
                End If

                scope.WriteString("PAST? CUST,P1")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                ampMax = Indexint

                scope.WriteString("PAST? CUST,P2")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                ampMin = Indexint

                scope.WriteString("PAST? CUST,P3")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                IndexLOW2 = IndexMid.IndexOf("E")
                IndexMid2 = Mid(IndexMid, 1, IndexLOW2)
                If Microsoft.VisualBasic.Right(IndexMid, 1) = 3 Then
                    Indexint = CSng(IndexMid2 * 1)
                ElseIf Microsoft.VisualBasic.Right(IndexMid, 1) = 6 Then
                    Indexint = CSng(IndexMid2 / 1000)
                Else
                End If
                risetime = Indexint

                scope.WriteString("PAST? CUST,P4")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                IndexLOW2 = IndexMid.IndexOf("E")
                IndexMid2 = Mid(IndexMid, 1, IndexLOW2)
                If Microsoft.VisualBasic.Right(IndexMid, 1) = 3 Then
                    Indexint = CSng(IndexMid2 * 1)
                ElseIf Microsoft.VisualBasic.Right(IndexMid, 1) = 6 Then
                    Indexint = CSng(IndexMid2 / 1000)
                Else
                End If
                falltime = Indexint

                scope.WriteString("PAST? CUST,P5")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMidP = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 9)
                If IndexMidP = "UN" Then
                    System.Threading.Thread.Sleep(1000)
                Else
                    Indexint = CSng(IndexMidP * 1)
                End If
                Pover = Indexint

                scope.WriteString("PAST? CUST,P6")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMidN = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 9)
                If IndexMidN = "UN" Then
                    System.Threading.Thread.Sleep(1000)
                Else
                    Indexint = CSng(IndexMidN * 1)
                End If
                Nover = Indexint

                scope.WriteString("PAST? CUST,P7")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Max = Indexint

                scope.WriteString("PAST? CUST,P8")
                strread = scope.ReadString
                IndexLAST = strread.IndexOf("LAST")
                IndexLOW = strread.IndexOf("LOW")
                IndexMid = Mid(strread, IndexLAST + 6, IndexLOW - IndexLAST - 8)
                Indexint = CInt(IndexMid * 1000)
                Min = Indexint

                amp10 = ampMin + (ampMax - ampMin) * 0.1
                amp90 = ampMin + (ampMax - ampMin) * 0.9

                If TG = OG Or sPover = 1 Or sNover = 1 Then
                    sPover = Pover
                    sNover = Nover
                End If

                If Dontfindod = False Then
                    RT = 0.8 * 1000 / Framerate.Text
                    RTL = 0.7 * 1000 / Framerate.Text
                    If Graylevel = False And ODgray.Count() = 2 Then
                        multiple = 64
                    ElseIf Graylevel = False And ODgray.Count() = 3 Then
                        multiple = 16
                        'ElseIf Graylevel = True And ODgray.Count() = 2 Then
                        'multiple = 16
                        'ElseIf Graylevel = True And ODgray.Count() = 3 Then
                        'multiple = 8
                    Else
                        multiple = 4
                    End If
                    If TG > SG Then
                        If Sametime = True Then
                            For Each p In ODgray
                                If p = OG Then
                                    check1 = 1
                                    thesame1 = 1
                                Else
                                End If
                            Next
                            ODgray.Insert(1, OG)
                            If Mode <> 0 Then
                                ODgray.Insert(1, TG)
                            Else
                            End If
                            ODgray.Sort()
                            OGindex = ODgray.IndexOf(OG)
                            For Each p In ODLgray
                                If p = OGL Then
                                    check2 = 1
                                    thesame2 = 1
                                Else
                                End If
                            Next
                            ODLgray.Insert(1, OGL)
                            If Mode <> 0 Then
                                ODLgray.Insert(1, TG)
                            Else
                            End If
                            ODLgray.Sort()
                            OGLindex = ODLgray.IndexOf(OGL)
                        Else
                            For Each p In ODgray
                                If p = OG Then
                                    check = 1
                                    thesame = 1
                                Else
                                End If
                            Next
                            ODgray.Insert(1, OG)
                            If Mode <> 0 Then
                                ODgray.Insert(1, TG)
                            Else
                            End If
                            ODgray.Sort()
                            OGindex = ODgray.IndexOf(OG)
                        End If

                        If Find100 = False Then
                            If ampMax + (ampMax - ampMin) * ODpercent > Max And OG < 255 And check <> 1 Then
                                If IndexMidP = "UN" Then
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / 2)
                                Else
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / 2)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            ElseIf ampMax + (ampMax - ampMin) * (ODpercent + 0.02) < Max And OG < 255 And check <> 1 Then
                                If OG = TG Then
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / 2)
                                Else
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / 2)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            Else
                                If TG = OG And OG < 255 Then
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / 2)
                                    saveparameter(SG, OG, TG, TG, Stepchoose)
                                Else
                                    check = 1
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                End If
                            End If
                        Else
                            If Sametime = True Then
                                If risetime > RT And OG < 255 And check1 <> 1 Then
                                    If IndexMidP = "UN" Then
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    Else
                                        OD90grayrise.Add(OG)
                                        OD90percentrise.Add(risetime)
                                        OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf risetime < RT And Pover > sPover * 1.1 And OG < 255 And check1 <> 1 Then
                                    If OG = TG Then
                                        check1 = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    Else
                                        OD110grayrise.Add(OG)
                                        OD110percentrise.Add(risetime)
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf risetime < RT And Pover < sPover * 1.1 And OG < 255 And check1 <> 1 Then
                                    If OG = TG Then
                                        check1 = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    ElseIf RTL < risetime And risetime < RT Then
                                        check1 = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    Else
                                        OD110grayrise.Add(OG)
                                        OD110percentrise.Add(risetime)
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                Else
                                    check1 = 1
                                End If
                                If falltime > RT And OGL > 0 And check2 <> 1 Then
                                    If IndexMidN = "UN" Then
                                        OGL = ODLgray(OGLindex) + Math.Ceiling((ODLgray(OGLindex + 1) - ODLgray(OGLindex)) / multiple)
                                    Else
                                        OD90grayfall.Add(OGL)
                                        OD90percentfall.Add(falltime)
                                        OGL = ODLgray(OGLindex) - Math.Ceiling((ODLgray(OGLindex) - ODLgray(OGLindex - 1)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf falltime < RT And Nover > sNover * 1.1 And OGL > 0 And check2 <> 1 Then
                                    If OGL = SG Then
                                        check2 = 1
                                        NextOGL = OGL
                                        ODLgray.Clear()
                                        ODLgray.Insert(0, 255)
                                        ODLgray.Insert(0, 0)
                                    Else
                                        OD110grayfall.Add(OGL)
                                        OD110percentfall.Add(falltime)
                                        OGL = ODLgray(OGLindex) + Math.Ceiling((ODLgray(OGLindex + 1) - ODLgray(OGLindex)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf falltime < RT And Nover < sNover * 1.1 And OGL > 0 And check2 <> 1 Then
                                    If OGL = SG Then
                                        check2 = 1
                                        NextOGL = OGL
                                        ODLgray.Clear()
                                        ODLgray.Insert(0, 255)
                                        ODLgray.Insert(0, 0)
                                    ElseIf RTL < falltime And falltime < RT Then
                                        check2 = 1
                                        NextOGL = OGL
                                        ODLgray.Clear()
                                        ODLgray.Insert(0, 255)
                                        ODLgray.Insert(0, 0)
                                    Else
                                        OD110grayfall.Add(OGL)
                                        OD110percentfall.Add(falltime)
                                        OGL = ODLgray(OGLindex) + Math.Ceiling((ODLgray(OGLindex + 1) - ODLgray(OGLindex)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                Else
                                    check2 = 1
                                End If
                                If check1 = 1 And check2 = 1 Then
                                    check = 1
                                    NextOG = OG
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                    NextOGL = OGL
                                    ODLgray.Clear()
                                    ODLgray.Insert(0, 255)
                                    ODLgray.Insert(0, 0)
                                End If
                            Else
                                If risetime > RT And OG < 255 And check <> 1 Then
                                    If IndexMidP = "UN" Then
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    Else
                                        OD90gray.Add(OG)
                                        OD90percent.Add(risetime)
                                        OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf risetime < RT And Pover > sPover * 1.1 And OG < 255 And check <> 1 Then
                                    If OG = TG Then
                                        check = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    Else
                                        OD110gray.Add(OG)
                                        OD110percent.Add(risetime)
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                ElseIf risetime < RT And Pover < sPover * 1.1 And OG < 255 And check <> 1 Then
                                    If OG = TG Then
                                        check = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    ElseIf RTL < risetime And risetime < RT Then
                                        check = 1
                                        NextOG = OG
                                        ODgray.Clear()
                                        ODgray.Insert(0, 255)
                                        ODgray.Insert(0, 0)
                                    Else
                                        OD110gray.Add(OG)
                                        OD110percent.Add(risetime)
                                        OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                    End If
                                    saveparameter(SG, OG, TG, OGL, Stepchoose)
                                Else
                                    check = 1
                                    NextOG = OG
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                End If
                            End If

                        End If
                    End If

                    If SG > TG Then
                        For Each p In ODgray
                            If p = OG Then
                                check = 1
                                thesame = 1
                            Else
                            End If
                        Next
                        ODgray.Insert(1, OG)
                        If Mode <> 0 Then
                            ODgray.Insert(1, TG)
                        Else
                        End If
                        ODgray.Sort()
                        OGindex = ODgray.IndexOf(OG)
                        If Find100 = False Then
                            If ampMin - (ampMax - ampMin) * ODpercent < Min And OG > 0 And check <> 1 Then
                                If IndexMidN = "UN" Then
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / 2)
                                Else
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / 2)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            ElseIf ampMin - (ampMax - ampMin) * (ODpercent + 0.02) > Min And OG > 0 And check <> 1 Then
                                If OG = TG Then
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / 2)
                                Else
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / 2)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            Else
                                If TG = OG And OG > 0 Then
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / 2)
                                    saveparameter(SG, OG, TG, TG, Stepchoose)
                                Else
                                    check = 1
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                End If
                            End If
                        Else
                            If falltime > RT And OG > 0 And check <> 1 Then
                                If IndexMidN = "UN" Then
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / multiple)
                                Else
                                    OD90gray.Add(OG)
                                    OD90percent.Add(falltime)
                                    OG = ODgray(OGindex) - Math.Ceiling((ODgray(OGindex) - ODgray(OGindex - 1)) / multiple)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            ElseIf falltime < RT And Nover > sNover * 1.1 And OG > 0 And check <> 1 Then
                                If OG = TG Then
                                    check = 1
                                    NextOG = OG
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                Else
                                    OD110gray.Add(OG)
                                    OD110percent.Add(falltime)
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / multiple)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            ElseIf falltime < RT And Nover < sNover * 1.1 And OG > 0 And check <> 1 Then
                                If OG = TG Then
                                    check = 1
                                    NextOG = OG
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                ElseIf RTL < falltime And falltime < RT Then
                                    check = 1
                                    NextOG = OG
                                    ODgray.Clear()
                                    ODgray.Insert(0, 255)
                                    ODgray.Insert(0, 0)
                                Else
                                    OD110gray.Add(OG)
                                    OD110percent.Add(falltime)
                                    OG = ODgray(OGindex) + Math.Ceiling((ODgray(OGindex + 1) - ODgray(OGindex)) / multiple)
                                End If
                                saveparameter(SG, OG, TG, TG, Stepchoose)
                            Else
                                check = 1
                                NextOG = OG
                                ODgray.Clear()
                                ODgray.Insert(0, 255)
                                ODgray.Insert(0, 0)
                            End If
                        End If
                    End If
                Else
                    check = 1
                End If

                If check = 1 And Mode = 1 Then
                    dt.CurrentCell.Value = OG
                    If TG > SG Then
                        dt2.Rows(ro).Cells(col).Value = Pover
                    Else
                        dt2.Rows(ro).Cells(col).Value = Nover
                    End If
                    Export()
                    savelocation(11)
                    saveparameter(255, 255, 255, 255, 0)
                    Exit Do
                ElseIf check = 1 And Mode = 2 Then
                    Export()
                    dt.Rows(Singlearray(loopcount, 3)).Cells(Singlearray(loopcount, 4)).Value = OG
                    If TG > SG Then
                        dt2.Rows(Singlearray(loopcount, 3)).Cells(Singlearray(loopcount, 4)).Value = Pover
                    Else
                        dt2.Rows(Singlearray(loopcount, 3)).Cells(Singlearray(loopcount, 4)).Value = Nover
                    End If
                    loopcount = loopcount + 1
                    If loopcount > icount Then
                        savelocation(11)
                        saveparameter(255, 255, 255, 255, 0)
                        Exit Do
                    Else
                        SG = Singlearray(loopcount, 0)
                        OG = Singlearray(loopcount, 1)
                        TG = Singlearray(loopcount, 2)
                        saveparameter(Singlearray(loopcount, 0), Singlearray(loopcount, 1), Singlearray(loopcount, 2), Singlearray(loopcount, 2), 0)
                        check = 0
                    End If
                ElseIf check = 1 And Mode = 0 Then
                    Export()
                    countfail = 0
                    If Sametime = True Then
                        If thesame1 = 1 Then
                            ODgray.Clear()
                            ODgray.Insert(0, 255)
                            ODgray.Insert(0, 0)
                        End If
                        If thesame2 = 1 Then
                            ODLgray.Clear()
                            ODLgray.Insert(0, 255)
                            ODLgray.Insert(0, 0)
                        End If
                    Else
                        If thesame = 1 Then
                            ODgray.Clear()
                            ODgray.Insert(0, 255)
                            ODgray.Insert(0, 0)
                        End If
                    End If
                    If Savecurve = True Then
                        If TG > SG Then
                            CallDraw()
                        Else
                            CallDraw2()
                        End If
                    Else
                    End If
                    GC.Collect()

                    If Graylevel = False Then
                        If Stepcount = Listcount - 1 Then
                            Graycount += 1
                            If Graycount = Listcount - 1 Then
                                Stepchoose = ListBox1.Items(Graycount) - ListBox1.Items(Graycount - 1)
                                SGchange = True
                            Else
                                Stepcount = Graycount + 1
                                Stepchoose = ListBox1.Items(Graycount) - ListBox1.Items(Graycount - 1)
                                SGchange = True
                            End If
                        Else
                            Stepcount += 1
                            Stepchoose = ListBox1.Items(Stepcount) - ListBox1.Items(Stepcount - 1)
                            SGchange = False
                        End If
                        STG = Stepchoose
                        If TG > SG Then
                            TG = TG + STG
                            If Sametime = True Then
                                If NextOG > TG Then
                                    OG = NextOG
                                Else
                                    OG = TG
                                End If
                                If NextOGL < SG Then
                                    OGL = NextOGL
                                Else
                                    OGL = SG
                                End If
                            End If
                            sPover = 1
                            If SGchange = True Then
                                SG = SG + STG
                                TG = SG + ListBox1.Items(Stepcount) - ListBox1.Items(Stepcount - 1)
                                OG = TG
                                OGL = SG
                                If Graycount = Listcount - 1 Then
                                    If Checkhalf = True Then
                                        savelocation(11)
                                        saveparameter(255, 255, 255, 255, Stepchoose)
                                        If Cycle = True Then
                                            If Colorcount = Colorlist.Count Then
                                                Exit Do
                                            End If
                                            Colorindex = Colorlist(Colorcount)
                                            Colorcount += 1
                                            If Colorindex = 0 Then
                                                savecolor(0)
                                                Cleanexcel()
                                            ElseIf Colorindex = 1 Then
                                                savecolor(1)
                                                Cleanexcel()
                                            ElseIf Colorindex = 2 Then
                                                savecolor(2)
                                                Cleanexcel()
                                            ElseIf Colorindex = 3 Then
                                                savecolor(3)
                                                Cleanexcel()
                                            End If
                                            System.Threading.Thread.Sleep(10000)
                                            SG = 0
                                            TG = ListBox1.Items(1) - ListBox1.Items(0)
                                            OG = ListBox1.Items(1) - ListBox1.Items(0)
                                            OGL = 0
                                            countrise = 0
                                            countfall = 0
                                            Stepcount = 1
                                            Graycount = 0
                                            callpattern()
                                            Waverunner.Calibration()
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        SG = ListBox1.Items(1) - ListBox1.Items(0)
                                        TG = 0
                                        OG = 0
                                        OGL = 0
                                        Graycount = 0
                                        Stepcount = 1
                                    End If
                                Else
                                End If
                                Else
                                End If

                        ElseIf TG < SG Then
                            SG = SG + STG
                            If NextOG < TG Then
                                OG = NextOG
                            Else
                                OG = TG
                            End If
                            sNover = 1
                            If SGchange = True Then
                                TG = TG + STG
                                SG = TG + ListBox1.Items(Stepcount) - ListBox1.Items(Stepcount - 1)
                                OG = TG
                                If Graycount = Listcount - 1 Then
                                    savelocation(11)
                                    saveparameter(255, 255, 255, 255, Stepchoose)
                                    If Cycle = True Then
                                        If Colorcount = Colorlist.Count Then
                                            Exit Do
                                        End If
                                        Colorindex = Colorlist(Colorcount)
                                        Colorcount += 1
                                        If Colorindex = 0 Then
                                            savecolor(0)
                                            Cleanexcel()
                                        ElseIf Colorindex = 1 Then
                                            savecolor(1)
                                            Cleanexcel()
                                        ElseIf Colorindex = 2 Then
                                            savecolor(2)
                                            Cleanexcel()
                                        ElseIf Colorindex = 3 Then
                                            savecolor(3)
                                            Cleanexcel()
                                        End If
                                        System.Threading.Thread.Sleep(10000)
                                        SG = 0
                                        TG = ListBox1.Items(1) - ListBox1.Items(0)
                                        OG = ListBox1.Items(1) - ListBox1.Items(0)
                                        countrise = 0
                                        countfall = 0
                                        Stepcount = 1
                                        Graycount = 0
                                        callpattern()
                                        Waverunner.Calibration()
                                    Else
                                        Exit Do
                                    End If
                                Else
                                End If
                            Else
                            End If
                        Else
                        End If
                    Else
                        STG = Stepchoose
                        If TG > SG Then
                            TG = TG + STG
                            If NextOG > TG Then
                                OG = NextOG
                            Else
                                OG = TG
                            End If
                            If Sametime = True Then
                                If NextOG > TG Then
                                    OG = NextOG
                                Else
                                    OG = TG
                                End If
                                If NextOGL < SG Then
                                    OGL = NextOGL
                                Else
                                    OGL = SG
                                End If
                            End If
                            sPover = 1
                            If TG = 256 Then
                                OG = 255
                                TG = 255
                            ElseIf TG > 256 Then
                                SG = SG + STG
                                TG = SG + STG
                                OG = TG
                                OGL = SG
                                If TG = 256 Then
                                    TG = 255
                                    OG = 255
                                Else
                                End If
                                If SG = 256 Then
                                    If Checkhalf = True Then
                                        savelocation(11)
                                        saveparameter(255, 255, 255, 255, Stepchoose)
                                        If Cycle = True Then
                                            If Colorcount = Colorlist.Count Then
                                                Exit Do
                                            End If
                                            Colorindex = Colorlist(Colorcount)
                                            Colorcount += 1
                                            If Colorindex = 0 Then
                                                savecolor(0)
                                                Cleanexcel()
                                            ElseIf Colorindex = 1 Then
                                                savecolor(1)
                                                Cleanexcel()
                                            ElseIf Colorindex = 2 Then
                                                savecolor(2)
                                                Cleanexcel()
                                            ElseIf Colorindex = 3 Then
                                                savecolor(3)
                                                Cleanexcel()
                                            End If
                                            System.Threading.Thread.Sleep(10000)
                                            SG = 0
                                            TG = Stepchoose
                                            OG = Stepchoose
                                            OGL = 0
                                            countrise = 0
                                            countfall = 0
                                            callpattern()
                                            Waverunner.Calibration()
                                        Else
                                            Exit Do
                                        End If
                                    Else
                                        SG = STG
                                        TG = 0
                                        OG = 0
                                        OGL = 0
                                    End If
                                Else
                                End If
                            Else
                            End If

                        ElseIf TG < SG Then
                            SG = SG + STG
                            If NextOG < TG Then
                                OG = NextOG
                            Else
                                OG = TG
                            End If
                            sNover = 1
                            If SG = 256 Then
                                SG = 255

                            ElseIf SG > 256 Then
                                TG = TG + STG
                                SG = TG + STG
                                OG = TG
                                If SG = 256 Then
                                    SG = 255
                                Else
                                End If
                                If TG = 256 Then
                                    savelocation(11)
                                    saveparameter(255, 255, 255, 255, Stepchoose)
                                    If Cycle = True Then
                                        If Colorcount = Colorlist.Count Then
                                            Exit Do
                                        End If
                                        Colorindex = Colorlist(Colorcount)
                                        Colorcount += 1
                                        If Colorindex = 0 Then
                                            savecolor(0)
                                            Cleanexcel()
                                        ElseIf Colorindex = 1 Then
                                            savecolor(1)
                                            Cleanexcel()
                                        ElseIf Colorindex = 2 Then
                                            savecolor(2)
                                            Cleanexcel()
                                        ElseIf Colorindex = 3 Then
                                            savecolor(3)
                                            Cleanexcel()
                                        End If
                                        System.Threading.Thread.Sleep(10000)
                                        SG = 0
                                        TG = Stepchoose
                                        OG = Stepchoose
                                        countrise = 0
                                        countfall = 0
                                        callpattern()
                                        Waverunner.Calibration()
                                    Else
                                        Exit Do
                                    End If
                                Else
                                End If
                            Else
                            End If
                        Else
                        End If
                    End If
                    If Findsingleodpercent = False Then
                        saveparameter(SG, OG, TG, OGL, Stepchoose)
                    End If

                    check = 0
                    check1 = 0
                    check2 = 0
                End If


            Catch ex As Exception
                check = 0
                countfail += 1
                If countfail > 3 Then
                    saveparameter(SG + Stepchoose, TG + Stepchoose, TG + Stepchoose, TG + Stepchoose, Stepchoose)
                End If
            End Try
        Loop
        check = 0
        countrise = 0
        countfall = 0
    End Sub

    Private Sub Export()
        Dim app As New Excel.Application 'app 是操作 Excel 的變數
        Dim worksheet As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim worksheet1 As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim worksheet2 As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim workbook As Excel.Workbook 'Workbook 代表的是一個 Excel 本體
        Dim OD110MinIndex As Integer, OD90MinIndex As Integer, OD110MinGray As Integer, OD90MinGray As Integer, OD110MinTime As Single, OD90MinTime As Single
        Dim OD110MinIndexrise As Integer, OD90MinIndexrise As Integer, OD110MinGrayrise As Integer, OD90MinGrayrise As Integer, OD110MinTimerise As Single, OD90MinTimerise As Single
        Dim OD110MinIndexfall As Integer, OD90MinIndexfall As Integer, OD110MinGrayfall As Integer, OD90MinGrayfall As Integer, OD110MinTimefall As Single, OD90MinTimefall As Single
        Dim Npercent As Integer

        Npercent = Percent.Text
        workbook = app.Workbooks.Open(sPath & "\" & "DPOresult.xlsx") '開啟一張已存在的 Excel 檔案

        If Tenp = True Then
            If Sametime = True Then
                If OD110percentrise.Count <> 0 Then
                    For c1 = 0 To OD110grayrise.Count - 1
                        OD110percentrise2.Add((OD110percentrise(c1) - RTL * (1 + Npercent * 0.1)) ^ 2)
                    Next
                    OD110MinIndexrise = OD110percentrise2.IndexOf(OD110percentrise2.Min)
                    OD110MinGrayrise = OD110grayrise(OD110MinIndexrise)
                    OD110MinTimerise = OD110percentrise(OD110MinIndexrise)
                End If
                If OD90percentrise.Count <> 0 Then
                    For c2 = 0 To OD90grayrise.Count - 1
                        OD90percentrise2.Add((OD90percentrise(c2) - RT * (1 - Npercent * 0.1)) ^ 2)
                    Next
                    OD90MinIndexrise = OD90percentrise2.IndexOf(OD90percentrise2.Min)
                    OD90MinGrayrise = OD90grayrise(OD90MinIndexrise)
                    OD90MinTimerise = OD90percentrise(OD90MinIndexrise)
                End If
                If OD110percentfall.Count <> 0 Then
                    For c1 = 0 To OD110grayfall.Count - 1
                        OD110percentfall2.Add((OD110percentfall(c1) - RTL * (1 + Npercent * 0.1)) ^ 2)
                    Next
                    OD110MinIndexfall = OD110percentfall2.IndexOf(OD110percentfall2.Min)
                    OD110MinGrayfall = OD110grayfall(OD110MinIndexfall)
                    OD110MinTimefall = OD110percentfall(OD110MinIndexfall)
                End If
                If OD90percentfall.Count <> 0 Then
                    For c2 = 0 To OD90grayfall.Count - 1
                        OD90percentfall2.Add((OD90percentfall(c2) - RT * (1 - Npercent * 0.1)) ^ 2)
                    Next
                    OD90MinIndexfall = OD90percentfall2.IndexOf(OD90percentfall2.Min)
                    OD90MinGrayfall = OD90grayfall(OD90MinIndexfall)
                    OD90MinTimefall = OD90percentfall(OD90MinIndexfall)
                End If
            Else
                If OD110percent.Count <> 0 Then
                    For c1 = 0 To OD110gray.Count - 1
                        OD110percent2.Add((OD110percent(c1) - RTL * (1 + Npercent * 0.1)) ^ 2)
                    Next
                    OD110MinIndex = OD110percent2.IndexOf(OD110percent2.Min)
                    OD110MinGray = OD110gray(OD110MinIndex)
                    OD110MinTime = OD110percent(OD110MinIndex)
                End If
                If OD90percent.Count <> 0 Then
                    For c2 = 0 To OD90gray.Count - 1
                        OD90percent2.Add((OD90percent(c2) - RT * (1 - Npercent * 0.1)) ^ 2)
                    Next
                    OD90MinIndex = OD90percent2.IndexOf(OD90percent2.Min)
                    OD90MinGray = OD90gray(OD90MinIndex)
                    OD90MinTime = OD90percent(OD90MinIndex)
                End If
            End If
        End If
        If Colorindex = 0 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("W")
                worksheet1 = workbook.Worksheets("W1")
                worksheet2 = workbook.Worksheets("W2")
            Else
                worksheet = workbook.Worksheets("W") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 1 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("R")
                worksheet1 = workbook.Worksheets("R1")
                worksheet2 = workbook.Worksheets("R2")
            Else
                worksheet = workbook.Worksheets("R") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 2 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("G")
                worksheet1 = workbook.Worksheets("G1")
                worksheet2 = workbook.Worksheets("G2")
            Else
                worksheet = workbook.Worksheets("G") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 3 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("B")
                worksheet1 = workbook.Worksheets("B1")
                worksheet2 = workbook.Worksheets("B2")
            Else
                worksheet = workbook.Worksheets("B") '讀取其中一張工作表
            End If
        End If

        If Tenp = False Then
            If Checkhalf = True Then
                If Sametime = True Then
                    worksheet.Cells(3 + countrise, 2) = SG
                    worksheet.Cells(3 + countrise, 3) = TG
                    worksheet.Cells(3 + countrise, 4) = OG
                    worksheet.Cells(3 + countrise, 5) = ampMin
                    worksheet.Cells(3 + countrise, 6) = ampMax
                    worksheet.Cells(3 + countrise, 7) = Max
                    worksheet.Cells(3 + countrise, 8) = amp10
                    worksheet.Cells(3 + countrise, 9) = amp90
                    worksheet.Cells(3 + countrise, 10) = Pover
                    worksheet.Cells(3 + countrise, 11) = risetime
                    countrise = countrise + 1
                    worksheet.Cells(3 + countfall, 13) = TG
                    worksheet.Cells(3 + countfall, 14) = SG
                    worksheet.Cells(3 + countfall, 15) = OGL
                    worksheet.Cells(3 + countfall, 16) = ampMax
                    worksheet.Cells(3 + countfall, 17) = ampMin
                    worksheet.Cells(3 + countfall, 18) = Min
                    worksheet.Cells(3 + countfall, 19) = amp10
                    worksheet.Cells(3 + countfall, 20) = amp90
                    worksheet.Cells(3 + countfall, 21) = Nover
                    worksheet.Cells(3 + countfall, 22) = falltime
                    countfall = countfall + 1
                Else
                    worksheet.Cells(3 + countrise, 2) = SG
                    worksheet.Cells(3 + countrise, 3) = TG
                    worksheet.Cells(3 + countrise, 4) = TG
                    worksheet.Cells(3 + countrise, 5) = ampMin
                    worksheet.Cells(3 + countrise, 6) = ampMax
                    worksheet.Cells(3 + countrise, 7) = Max
                    worksheet.Cells(3 + countrise, 8) = amp10
                    worksheet.Cells(3 + countrise, 9) = amp90
                    worksheet.Cells(3 + countrise, 10) = Pover
                    worksheet.Cells(3 + countrise, 11) = risetime
                    countrise = countrise + 1
                    worksheet.Cells(3 + countfall, 13) = TG
                    worksheet.Cells(3 + countfall, 14) = SG
                    worksheet.Cells(3 + countfall, 15) = SG
                    worksheet.Cells(3 + countfall, 16) = ampMax
                    worksheet.Cells(3 + countfall, 17) = ampMin
                    worksheet.Cells(3 + countfall, 18) = Min
                    worksheet.Cells(3 + countfall, 19) = amp10
                    worksheet.Cells(3 + countfall, 20) = amp90
                    worksheet.Cells(3 + countfall, 21) = Nover
                    worksheet.Cells(3 + countfall, 22) = falltime
                    countfall = countfall + 1
                End If
            Else
                If TG > SG Then
                    worksheet.Cells(3 + countrise, 2) = SG
                    worksheet.Cells(3 + countrise, 3) = TG
                    worksheet.Cells(3 + countrise, 4) = OG
                    worksheet.Cells(3 + countrise, 5) = ampMin
                    worksheet.Cells(3 + countrise, 6) = ampMax
                    worksheet.Cells(3 + countrise, 7) = Max
                    worksheet.Cells(3 + countrise, 8) = amp10
                    worksheet.Cells(3 + countrise, 9) = amp90
                    worksheet.Cells(3 + countrise, 10) = Pover
                    worksheet.Cells(3 + countrise, 11) = risetime
                    countrise = countrise + 1
                ElseIf SG > TG Then
                    worksheet.Cells(3 + countfall, 13) = SG
                    worksheet.Cells(3 + countfall, 14) = TG
                    worksheet.Cells(3 + countfall, 15) = OG
                    worksheet.Cells(3 + countfall, 16) = ampMax
                    worksheet.Cells(3 + countfall, 17) = ampMin
                    worksheet.Cells(3 + countfall, 18) = Min
                    worksheet.Cells(3 + countfall, 19) = amp10
                    worksheet.Cells(3 + countfall, 20) = amp90
                    worksheet.Cells(3 + countfall, 21) = Nover
                    worksheet.Cells(3 + countfall, 22) = falltime
                    countfall = countfall + 1
                End If
            End If
        Else
            worksheet.Cells(3 + countrise, 2) = SG
            worksheet.Cells(3 + countrise, 3) = TG
            worksheet.Cells(3 + countrise, 4) = OG
            worksheet.Cells(3 + countrise, 5) = ampMin
            worksheet.Cells(3 + countrise, 6) = ampMax
            worksheet.Cells(3 + countrise, 7) = Max
            worksheet.Cells(3 + countrise, 8) = amp10
            worksheet.Cells(3 + countrise, 9) = amp90
            worksheet.Cells(3 + countrise, 10) = Pover
            worksheet.Cells(3 + countrise, 11) = risetime
            worksheet.Cells(3 + countfall, 13) = TG
            worksheet.Cells(3 + countfall, 14) = SG
            worksheet.Cells(3 + countfall, 15) = OGL
            worksheet.Cells(3 + countfall, 16) = ampMax
            worksheet.Cells(3 + countfall, 17) = ampMin
            worksheet.Cells(3 + countfall, 18) = Min
            worksheet.Cells(3 + countfall, 19) = amp10
            worksheet.Cells(3 + countfall, 20) = amp90
            worksheet.Cells(3 + countfall, 21) = Nover
            worksheet.Cells(3 + countfall, 22) = falltime
            If OD110percentrise.Count <> 0 Then
                worksheet1.Cells(3 + countrise, 2) = SG
                worksheet1.Cells(3 + countrise, 3) = TG
                worksheet1.Cells(3 + countrise, 4) = OD110MinGrayrise
                worksheet1.Cells(3 + countrise, 11) = OD110MinTimerise
            Else
                worksheet1.Cells(3 + countrise, 2) = SG
                worksheet1.Cells(3 + countrise, 3) = TG
                worksheet1.Cells(3 + countrise, 4) = OG
                worksheet1.Cells(3 + countrise, 11) = risetime
            End If
            If OD110percentfall.Count <> 0 Then
                worksheet1.Cells(3 + countrise, 13) = TG
                worksheet1.Cells(3 + countrise, 14) = SG
                worksheet1.Cells(3 + countrise, 15) = OD110MinGrayfall
                worksheet1.Cells(3 + countrise, 22) = OD110MinTimefall
            Else
                worksheet1.Cells(3 + countrise, 13) = TG
                worksheet1.Cells(3 + countrise, 14) = SG
                worksheet1.Cells(3 + countrise, 15) = OGL
                worksheet1.Cells(3 + countrise, 22) = falltime
            End If
            If OD90percentrise.Count <> 0 Then
                worksheet2.Cells(3 + countrise, 2) = SG
                worksheet2.Cells(3 + countrise, 3) = TG
                worksheet2.Cells(3 + countrise, 4) = OD90MinGrayrise
                worksheet2.Cells(3 + countrise, 11) = OD90MinTimerise
            Else
                worksheet2.Cells(3 + countrise, 2) = SG
                worksheet2.Cells(3 + countrise, 3) = TG
                worksheet2.Cells(3 + countrise, 4) = OG
                worksheet2.Cells(3 + countrise, 11) = risetime
            End If
            If OD90percentfall.Count <> 0 Then
                worksheet2.Cells(3 + countrise, 13) = TG
                worksheet2.Cells(3 + countrise, 14) = SG
                worksheet2.Cells(3 + countrise, 15) = OD90MinGrayfall
                worksheet2.Cells(3 + countrise, 22) = OD90MinTimefall
            Else
                worksheet2.Cells(3 + countrise, 13) = TG
                worksheet2.Cells(3 + countrise, 14) = SG
                worksheet2.Cells(3 + countrise, 15) = OGL
                worksheet2.Cells(3 + countrise, 22) = falltime
            End If
            countrise = countrise + 1
            countfall = countfall + 1
        End If

        OD110gray.Clear()
        OD110percent.Clear()
        OD110percent2.Clear()
        OD90gray.Clear()
        OD90percent.Clear()
        OD90percent2.Clear()

        OD110grayrise.Clear()
        OD110percentrise.Clear()
        OD110percentrise2.Clear()
        OD90grayrise.Clear()
        OD90percentrise.Clear()
        OD90percentrise2.Clear()

        OD110grayfall.Clear()
        OD110percentfall.Clear()
        OD110percentfall2.Clear()
        OD90grayfall.Clear()
        OD90percentfall.Clear()
        OD90percentfall2.Clear()

        workbook.Save() '儲存動作
        workbook.Close() '關閉檔案
        app.Quit() '結束操作
        If Tenp = True Then
            ReleaseComObject(worksheet)
            ReleaseComObject(worksheet1)
            ReleaseComObject(worksheet2)
        Else
            ReleaseComObject(worksheet)
        End If
            ReleaseComObject(workbook)
            ReleaseComObject(app)
            GC.Collect()
    End Sub

    Private Sub Cleanexcel()
        Dim app As New Excel.Application 'app 是操作 Excel 的變數
        Dim worksheet As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim worksheet1 As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim worksheet2 As Excel.Worksheet 'Worksheet 代表的是 Excel 工作表
        Dim workbook As Excel.Workbook 'Workbook 代表的是一個 Excel 本體
        workbook = app.Workbooks.Open(sPath & "\" & "DPOresult.xlsx") '開啟一張已存在的 Excel 檔案
        If Colorindex = 0 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("W")
                worksheet1 = workbook.Worksheets("W1")
                worksheet2 = workbook.Worksheets("W2")
            Else
                worksheet = workbook.Worksheets("W") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 1 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("R")
                worksheet1 = workbook.Worksheets("R1")
                worksheet2 = workbook.Worksheets("R2")
            Else
                worksheet = workbook.Worksheets("R") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 2 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("G")
                worksheet1 = workbook.Worksheets("G1")
                worksheet2 = workbook.Worksheets("G2")
            Else
                worksheet = workbook.Worksheets("G") '讀取其中一張工作表
            End If
        ElseIf Colorindex = 3 Then
            If Tenp = True Then
                worksheet = workbook.Worksheets("B")
                worksheet1 = workbook.Worksheets("B1")
                worksheet2 = workbook.Worksheets("B2")
            Else
                worksheet = workbook.Worksheets("B") '讀取其中一張工作表
            End If
        End If

        If Tenp = True Then
            worksheet.Range("B3:V138").Clear()
            worksheet1.Range("B3:V138").Clear()
            worksheet2.Range("B3:V138").Clear()
        Else
            worksheet.Range("B3:V138").Clear()
        End If

        workbook.Save() '儲存動作
        workbook.Close() '關閉檔案
        app.Quit() '結束操作

        If Tenp = True Then
            ReleaseComObject(worksheet)
            ReleaseComObject(worksheet1)
            ReleaseComObject(worksheet2)
        Else
            ReleaseComObject(worksheet)
        End If

        ReleaseComObject(workbook)
        ReleaseComObject(app)
        GC.Collect()
    End Sub

    Private Sub callpattern()
        Shell(sPath & "\" & "ODpattern.exe", vbNormalFocus)
        check = 0
    End Sub

    Private Sub Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Del.Click
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        'MsgBox(ListBox1.Items.Count())
        'MsgBox(ListBox1.Items(3))
    End Sub

    Private Sub Graylevelstep_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Graylevelstep.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            ListBox1.Items.Add(Graylevelstep.Text)
            Graylevelstep.Clear()
        End If
    End Sub


End Class
