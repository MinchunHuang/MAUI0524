Module Waverunner
    Public rm As Ivi.Visa.Interop.ResourceManager
    Public scope As Ivi.Visa.Interop.FormattedIO488
    Public strL255volt As String, strL0volt As String
    Public L255volt As Single, L0volt As Single, volt As Single
    Public Sub Initial()
        Dim ID, x As String
        FormMain.saveparameter(255, 255, 255, 255, FormMain.Stepchoose)
        rm = New Ivi.Visa.Interop.ResourceManager
        scope = New Ivi.Visa.Interop.FormattedIO488
        FormMain.getparameter()
        ID = FormMain.Internetname
        x = String.Format("{0}", ID)
        scope.IO = rm.Open(x)
        scope.WriteString("*RST")
        scope.WriteString("*CLS")
        scope.WriteString("TRIG_MODE AUTO")
        scope.WriteString("C2:TRACE OFF")
        scope.WriteString("MSIZ 10K")                   'Sample size
        scope.WriteString("TDIV 0.1")                   'Time division
        scope.WriteString("C1:OFST 0")                  'offset 
        scope.WriteString("TRDL 0")                     'Time delay
        scope.WriteString("PARAMETER_CUSTOM 1,TOP,C1")
        scope.WriteString("PARAMETER_CUSTOM 2,BASE,C1")
        scope.WriteString("PARAMETER_CUSTOM 3,RISE,C1")
        scope.WriteString("PARAMETER_CUSTOM 4,FALL,C1")
        scope.WriteString("PARAMETER_CUSTOM 5,OVSP,C1")
        scope.WriteString("PARAMETER_CUSTOM 6,OVSN,C1")
        scope.WriteString("PARAMETER_CUSTOM 7,MAX,C1")
        scope.WriteString("PARAMETER_CUSTOM 8,MIN,C1")
    End Sub

    Public Sub Calibration() '校正
        Dim IndexLAST As String, IndexLOW As String, IndexMid As String
        Dim Indexint As Integer
        scope.WriteString("C1:VDIV 3V")                 'Vertical division
        FormMain.saveparameter(0, 255, 255, 0, FormMain.Stepchoose)
        System.Threading.Thread.Sleep(5000)
        scope.WriteString("PAST? CUST,P1")
        strL255volt = scope.ReadString
        IndexLAST = strL255volt.IndexOf("LAST")
        IndexLOW = strL255volt.IndexOf("LOW")
        IndexMid = Mid(strL255volt, IndexLAST + 6, IndexLOW - IndexLAST - 8)
        Indexint = CInt(IndexMid * 1000)
        L255volt = Indexint
        scope.WriteString("PAST? CUST,P2")
        strL0volt = scope.ReadString
        IndexLAST = strL0volt.IndexOf("LAST")
        IndexLOW = strL0volt.IndexOf("LOW")
        IndexMid = Mid(strL0volt, IndexLAST + 6, IndexLOW - IndexLAST - 8)
        Indexint = CInt(IndexMid * 1000)
        L0volt = Indexint
        volt = L255volt - L0volt
        Dim x As Single = (Math.Round(L0volt + (volt / 2), 1)) / 1000
        Dim x1 As String = String.Format("C1:OFST -{0}V", x)

        If 11200 < volt And volt < 19200 Then
            scope.WriteString("C1:VDIV 3V")
        ElseIf 5600 < volt And volt < 11200 Then
            scope.WriteString("C1:VDIV 2V")
        ElseIf 2800 < volt And volt < 5600 Then
            scope.WriteString("C1:VDIV 1V")
        ElseIf 1120 < volt And volt < 2800 Then
            scope.WriteString("C1:VDIV 0.5V")
        ElseIf 560 < volt And volt < 1120 Then
            scope.WriteString("C1:VDIV 0.2V")
        ElseIf 280 < volt And volt < 560 Then
            scope.WriteString("C1:VDIV 0.1V")
        ElseIf 112 < volt And volt < 280 Then
            scope.WriteString("C1:VDIV 0.05V")
        ElseIf 56 < volt And volt < 112 Then
            scope.WriteString("C1:VDIV 0.02V")
        Else
            scope.WriteString("C1:VDIV 0.01V")
        End If
        scope.WriteString(x1)
        System.Threading.Thread.Sleep(5000)
        scope.WriteString("PAST? CUST,P1")
        strL255volt = scope.ReadString
        IndexLAST = strL255volt.IndexOf("LAST")
        IndexLOW = strL255volt.IndexOf("LOW")
        IndexMid = Mid(strL255volt, IndexLAST + 6, IndexLOW - IndexLAST - 8)
        Indexint = CInt(IndexMid * 1000)
        L255volt = Indexint
        scope.WriteString("PAST? CUST,P2")
        strL0volt = scope.ReadString
        IndexLAST = strL0volt.IndexOf("LAST")
        IndexLOW = strL0volt.IndexOf("LOW")
        IndexMid = Mid(strL0volt, IndexLAST + 6, IndexLOW - IndexLAST - 8)
        Indexint = CInt(IndexMid * 1000)
        L0volt = Indexint
        volt = L255volt - L0volt

    End Sub

End Module
