<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ColorAll = New System.Windows.Forms.CheckBox()
        Me.ColorB = New System.Windows.Forms.CheckBox()
        Me.ColorG = New System.Windows.Forms.CheckBox()
        Me.ColorR = New System.Windows.Forms.CheckBox()
        Me.ColorW = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Framerate = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Dontsavedata = New System.Windows.Forms.RadioButton()
        Me.Savedata = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Percent = New System.Windows.Forms.TextBox()
        Me.tenpercent = New System.Windows.Forms.RadioButton()
        Me.Noover = New System.Windows.Forms.RadioButton()
        Me.BMODSimu = New System.Windows.Forms.RadioButton()
        Me.Manual = New System.Windows.Forms.RadioButton()
        Me.LCRT = New System.Windows.Forms.RadioButton()
        Me.BMGL = New System.Windows.Forms.RadioButton()
        Me.BM = New System.Windows.Forms.RadioButton()
        Me.Normal = New System.Windows.Forms.RadioButton()
        Me.Exitbutton = New System.Windows.Forms.Button()
        Me.pattern = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.JSstep = New System.Windows.Forms.RadioButton()
        Me.Del = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Manualstep = New System.Windows.Forms.RadioButton()
        Me.Autostep = New System.Windows.Forms.RadioButton()
        Me.Graylevelstep = New System.Windows.Forms.TextBox()
        Me.Start = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Overshoot = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dt2 = New System.Windows.Forms.DataGridView()
        Me.MultiStart = New System.Windows.Forms.Button()
        Me.DatagridExport = New System.Windows.Forms.Button()
        Me.SingleStart = New System.Windows.Forms.Button()
        Me.NewOD = New System.Windows.Forms.TextBox()
        Me.dt = New System.Windows.Forms.DataGridView()
        Me.LoadExcel = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.GroupBox8)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.Exitbutton)
        Me.GroupBox5.Controls.Add(Me.pattern)
        Me.GroupBox5.Controls.Add(Me.GroupBox3)
        Me.GroupBox5.Controls.Add(Me.Start)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(335, 661)
        Me.GroupBox5.TabIndex = 62
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Auto"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox8.Controls.Add(Me.ColorAll)
        Me.GroupBox8.Controls.Add(Me.ColorB)
        Me.GroupBox8.Controls.Add(Me.ColorG)
        Me.GroupBox8.Controls.Add(Me.ColorR)
        Me.GroupBox8.Controls.Add(Me.ColorW)
        Me.GroupBox8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.White
        Me.GroupBox8.Location = New System.Drawing.Point(21, 272)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(289, 54)
        Me.GroupBox8.TabIndex = 16
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Color"
        '
        'ColorAll
        '
        Me.ColorAll.AutoSize = True
        Me.ColorAll.Location = New System.Drawing.Point(201, 26)
        Me.ColorAll.Name = "ColorAll"
        Me.ColorAll.Size = New System.Drawing.Size(70, 22)
        Me.ColorAll.TabIndex = 4
        Me.ColorAll.Text = "Cycle"
        Me.ColorAll.UseVisualStyleBackColor = True
        '
        'ColorB
        '
        Me.ColorB.AutoSize = True
        Me.ColorB.Location = New System.Drawing.Point(157, 26)
        Me.ColorB.Name = "ColorB"
        Me.ColorB.Size = New System.Drawing.Size(38, 22)
        Me.ColorB.TabIndex = 3
        Me.ColorB.Text = "B"
        Me.ColorB.UseVisualStyleBackColor = True
        '
        'ColorG
        '
        Me.ColorG.AutoSize = True
        Me.ColorG.Location = New System.Drawing.Point(113, 26)
        Me.ColorG.Name = "ColorG"
        Me.ColorG.Size = New System.Drawing.Size(39, 22)
        Me.ColorG.TabIndex = 2
        Me.ColorG.Text = "G"
        Me.ColorG.UseVisualStyleBackColor = True
        '
        'ColorR
        '
        Me.ColorR.AutoSize = True
        Me.ColorR.Location = New System.Drawing.Point(63, 26)
        Me.ColorR.Name = "ColorR"
        Me.ColorR.Size = New System.Drawing.Size(38, 22)
        Me.ColorR.TabIndex = 1
        Me.ColorR.Text = "R"
        Me.ColorR.UseVisualStyleBackColor = True
        '
        'ColorW
        '
        Me.ColorW.AutoSize = True
        Me.ColorW.Location = New System.Drawing.Point(13, 26)
        Me.ColorW.Name = "ColorW"
        Me.ColorW.Size = New System.Drawing.Size(44, 22)
        Me.ColorW.TabIndex = 0
        Me.ColorW.Text = "W"
        Me.ColorW.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox7.Controls.Add(Me.Framerate)
        Me.GroupBox7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.White
        Me.GroupBox7.Location = New System.Drawing.Point(19, 540)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(137, 79)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Frame rate"
        '
        'Framerate
        '
        Me.Framerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Framerate.ForeColor = System.Drawing.Color.White
        Me.Framerate.Location = New System.Drawing.Point(20, 35)
        Me.Framerate.Name = "Framerate"
        Me.Framerate.Size = New System.Drawing.Size(85, 27)
        Me.Framerate.TabIndex = 0
        Me.Framerate.Text = "60"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.Dontsavedata)
        Me.GroupBox6.Controls.Add(Me.Savedata)
        Me.GroupBox6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(162, 540)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(146, 79)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Raw data"
        '
        'Dontsavedata
        '
        Me.Dontsavedata.AutoSize = True
        Me.Dontsavedata.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dontsavedata.Location = New System.Drawing.Point(77, 26)
        Me.Dontsavedata.Name = "Dontsavedata"
        Me.Dontsavedata.Size = New System.Drawing.Size(48, 22)
        Me.Dontsavedata.TabIndex = 5
        Me.Dontsavedata.Text = "No"
        Me.Dontsavedata.UseVisualStyleBackColor = True
        '
        'Savedata
        '
        Me.Savedata.AutoSize = True
        Me.Savedata.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Savedata.Location = New System.Drawing.Point(19, 26)
        Me.Savedata.Name = "Savedata"
        Me.Savedata.Size = New System.Drawing.Size(56, 22)
        Me.Savedata.TabIndex = 4
        Me.Savedata.Text = "Yes"
        Me.Savedata.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Percent)
        Me.GroupBox1.Controls.Add(Me.tenpercent)
        Me.GroupBox1.Controls.Add(Me.Noover)
        Me.GroupBox1.Controls.Add(Me.BMODSimu)
        Me.GroupBox1.Controls.Add(Me.Manual)
        Me.GroupBox1.Controls.Add(Me.LCRT)
        Me.GroupBox1.Controls.Add(Me.BMGL)
        Me.GroupBox1.Controls.Add(Me.BM)
        Me.GroupBox1.Controls.Add(Me.Normal)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(19, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 240)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Function"
        '
        'Percent
        '
        Me.Percent.Location = New System.Drawing.Point(100, 81)
        Me.Percent.Name = "Percent"
        Me.Percent.Size = New System.Drawing.Size(57, 27)
        Me.Percent.TabIndex = 9
        Me.Percent.Text = "10"
        '
        'tenpercent
        '
        Me.tenpercent.AutoSize = True
        Me.tenpercent.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tenpercent.Location = New System.Drawing.Point(21, 82)
        Me.tenpercent.Name = "tenpercent"
        Me.tenpercent.Size = New System.Drawing.Size(73, 22)
        Me.tenpercent.TabIndex = 8
        Me.tenpercent.Text = "+-n%"
        Me.tenpercent.UseVisualStyleBackColor = True
        '
        'Noover
        '
        Me.Noover.AutoSize = True
        Me.Noover.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Noover.Location = New System.Drawing.Point(21, 54)
        Me.Noover.Name = "Noover"
        Me.Noover.Size = New System.Drawing.Size(138, 22)
        Me.Noover.TabIndex = 7
        Me.Noover.Text = "No Overshoot"
        Me.Noover.UseVisualStyleBackColor = True
        '
        'BMODSimu
        '
        Me.BMODSimu.AutoSize = True
        Me.BMODSimu.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BMODSimu.Location = New System.Drawing.Point(21, 172)
        Me.BMODSimu.Name = "BMODSimu"
        Me.BMODSimu.Size = New System.Drawing.Size(236, 22)
        Me.BMODSimu.TabIndex = 6
        Me.BMODSimu.Text = "Benchmark - OD%(Simu.)"
        Me.BMODSimu.UseVisualStyleBackColor = True
        '
        'Manual
        '
        Me.Manual.AutoSize = True
        Me.Manual.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Manual.Location = New System.Drawing.Point(128, 26)
        Me.Manual.Name = "Manual"
        Me.Manual.Size = New System.Drawing.Size(84, 22)
        Me.Manual.TabIndex = 5
        Me.Manual.Text = "Manual"
        Me.Manual.UseVisualStyleBackColor = True
        '
        'LCRT
        '
        Me.LCRT.AutoSize = True
        Me.LCRT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCRT.Location = New System.Drawing.Point(21, 110)
        Me.LCRT.Name = "LCRT"
        Me.LCRT.Size = New System.Drawing.Size(148, 22)
        Me.LCRT.TabIndex = 4
        Me.LCRT.Text = "Response time"
        Me.LCRT.UseVisualStyleBackColor = True
        '
        'BMGL
        '
        Me.BMGL.AutoSize = True
        Me.BMGL.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BMGL.Location = New System.Drawing.Point(21, 204)
        Me.BMGL.Name = "BMGL"
        Me.BMGL.Size = New System.Drawing.Size(216, 22)
        Me.BMGL.TabIndex = 3
        Me.BMGL.Text = "Benchmark - Gray level"
        Me.BMGL.UseVisualStyleBackColor = True
        '
        'BM
        '
        Me.BM.AutoSize = True
        Me.BM.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BM.Location = New System.Drawing.Point(21, 140)
        Me.BM.Name = "BM"
        Me.BM.Size = New System.Drawing.Size(226, 22)
        Me.BM.TabIndex = 2
        Me.BM.Text = "Benchmark - OD%(Real)"
        Me.BM.UseVisualStyleBackColor = True
        '
        'Normal
        '
        Me.Normal.AutoSize = True
        Me.Normal.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Normal.Location = New System.Drawing.Point(21, 26)
        Me.Normal.Name = "Normal"
        Me.Normal.Size = New System.Drawing.Size(84, 22)
        Me.Normal.TabIndex = 1
        Me.Normal.Text = "Normal"
        Me.Normal.UseVisualStyleBackColor = True
        '
        'Exitbutton
        '
        Me.Exitbutton.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Exitbutton.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exitbutton.ForeColor = System.Drawing.Color.White
        Me.Exitbutton.Location = New System.Drawing.Point(228, 625)
        Me.Exitbutton.Name = "Exitbutton"
        Me.Exitbutton.Size = New System.Drawing.Size(75, 30)
        Me.Exitbutton.TabIndex = 14
        Me.Exitbutton.Text = "Exit"
        Me.Exitbutton.UseVisualStyleBackColor = False
        '
        'pattern
        '
        Me.pattern.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.pattern.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pattern.ForeColor = System.Drawing.Color.White
        Me.pattern.Location = New System.Drawing.Point(21, 625)
        Me.pattern.Name = "pattern"
        Me.pattern.Size = New System.Drawing.Size(120, 30)
        Me.pattern.TabIndex = 15
        Me.pattern.Text = "Call pattern"
        Me.pattern.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.JSstep)
        Me.GroupBox3.Controls.Add(Me.Del)
        Me.GroupBox3.Controls.Add(Me.ListBox1)
        Me.GroupBox3.Controls.Add(Me.Manualstep)
        Me.GroupBox3.Controls.Add(Me.Autostep)
        Me.GroupBox3.Controls.Add(Me.Graylevelstep)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(21, 332)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 127)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Gray level step"
        '
        'JSstep
        '
        Me.JSstep.AutoSize = True
        Me.JSstep.Location = New System.Drawing.Point(13, 54)
        Me.JSstep.Name = "JSstep"
        Me.JSstep.Size = New System.Drawing.Size(43, 22)
        Me.JSstep.TabIndex = 18
        Me.JSstep.TabStop = True
        Me.JSstep.Text = "JS"
        Me.JSstep.UseVisualStyleBackColor = True
        '
        'Del
        '
        Me.Del.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Del.Location = New System.Drawing.Point(104, 90)
        Me.Del.Name = "Del"
        Me.Del.Size = New System.Drawing.Size(58, 23)
        Me.Del.TabIndex = 17
        Me.Del.Text = "Del"
        Me.Del.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 18
        Me.ListBox1.Location = New System.Drawing.Point(176, 22)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(101, 94)
        Me.ListBox1.TabIndex = 5
        '
        'Manualstep
        '
        Me.Manualstep.AutoSize = True
        Me.Manualstep.Location = New System.Drawing.Point(78, 26)
        Me.Manualstep.Name = "Manualstep"
        Me.Manualstep.Size = New System.Drawing.Size(84, 22)
        Me.Manualstep.TabIndex = 4
        Me.Manualstep.TabStop = True
        Me.Manualstep.Text = "Manual"
        Me.Manualstep.UseVisualStyleBackColor = True
        '
        'Autostep
        '
        Me.Autostep.AutoSize = True
        Me.Autostep.Location = New System.Drawing.Point(13, 26)
        Me.Autostep.Name = "Autostep"
        Me.Autostep.Size = New System.Drawing.Size(64, 22)
        Me.Autostep.TabIndex = 3
        Me.Autostep.TabStop = True
        Me.Autostep.Text = "Auto"
        Me.Autostep.UseVisualStyleBackColor = True
        '
        'Graylevelstep
        '
        Me.Graylevelstep.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Graylevelstep.ForeColor = System.Drawing.Color.White
        Me.Graylevelstep.Location = New System.Drawing.Point(13, 89)
        Me.Graylevelstep.Name = "Graylevelstep"
        Me.Graylevelstep.Size = New System.Drawing.Size(85, 27)
        Me.Graylevelstep.TabIndex = 0
        Me.Graylevelstep.Text = "16"
        '
        'Start
        '
        Me.Start.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Start.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Start.ForeColor = System.Drawing.Color.White
        Me.Start.Location = New System.Drawing.Point(147, 625)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(75, 30)
        Me.Start.TabIndex = 12
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Overshoot)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(19, 465)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(289, 71)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OD percent"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(128, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(151, 16)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "* Bypass,if benchmark"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox4.Location = New System.Drawing.Point(128, 26)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(140, 16)
        Me.TextBox4.TabIndex = 2
        Me.TextBox4.Text = "* Ex. 110、120...etc"
        '
        'Overshoot
        '
        Me.Overshoot.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Overshoot.ForeColor = System.Drawing.Color.White
        Me.Overshoot.Location = New System.Drawing.Point(19, 27)
        Me.Overshoot.Name = "Overshoot"
        Me.Overshoot.Size = New System.Drawing.Size(86, 27)
        Me.Overshoot.TabIndex = 0
        Me.Overshoot.Text = "110"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.dt2)
        Me.GroupBox4.Controls.Add(Me.MultiStart)
        Me.GroupBox4.Controls.Add(Me.DatagridExport)
        Me.GroupBox4.Controls.Add(Me.SingleStart)
        Me.GroupBox4.Controls.Add(Me.NewOD)
        Me.GroupBox4.Controls.Add(Me.dt)
        Me.GroupBox4.Controls.Add(Me.LoadExcel)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(352, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(713, 663)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Manual"
        Me.GroupBox4.Visible = False
        '
        'dt2
        '
        Me.dt2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dt2.BackgroundColor = System.Drawing.Color.White
        Me.dt2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dt2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dt2.Location = New System.Drawing.Point(20, 358)
        Me.dt2.Name = "dt2"
        Me.dt2.RowHeadersWidth = 80
        Me.dt2.RowTemplate.Height = 24
        Me.dt2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt2.Size = New System.Drawing.Size(672, 285)
        Me.dt2.TabIndex = 63
        '
        'MultiStart
        '
        Me.MultiStart.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.MultiStart.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiStart.ForeColor = System.Drawing.Color.White
        Me.MultiStart.Location = New System.Drawing.Point(452, 26)
        Me.MultiStart.Name = "MultiStart"
        Me.MultiStart.Size = New System.Drawing.Size(117, 30)
        Me.MultiStart.TabIndex = 62
        Me.MultiStart.Text = "Multi Start"
        Me.MultiStart.UseVisualStyleBackColor = False
        '
        'DatagridExport
        '
        Me.DatagridExport.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.DatagridExport.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatagridExport.ForeColor = System.Drawing.Color.White
        Me.DatagridExport.Location = New System.Drawing.Point(575, 26)
        Me.DatagridExport.Name = "DatagridExport"
        Me.DatagridExport.Size = New System.Drawing.Size(117, 30)
        Me.DatagridExport.TabIndex = 61
        Me.DatagridExport.Text = "Export"
        Me.DatagridExport.UseVisualStyleBackColor = False
        '
        'SingleStart
        '
        Me.SingleStart.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.SingleStart.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SingleStart.ForeColor = System.Drawing.Color.White
        Me.SingleStart.Location = New System.Drawing.Point(329, 26)
        Me.SingleStart.Name = "SingleStart"
        Me.SingleStart.Size = New System.Drawing.Size(117, 30)
        Me.SingleStart.TabIndex = 16
        Me.SingleStart.Text = "Single Start"
        Me.SingleStart.UseVisualStyleBackColor = False
        '
        'NewOD
        '
        Me.NewOD.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.NewOD.ForeColor = System.Drawing.Color.White
        Me.NewOD.Location = New System.Drawing.Point(20, 26)
        Me.NewOD.Name = "NewOD"
        Me.NewOD.Size = New System.Drawing.Size(45, 27)
        Me.NewOD.TabIndex = 60
        Me.NewOD.Text = "110"
        '
        'dt
        '
        Me.dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dt.BackgroundColor = System.Drawing.Color.White
        Me.dt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dt.Location = New System.Drawing.Point(20, 67)
        Me.dt.Name = "dt"
        Me.dt.RowHeadersWidth = 80
        Me.dt.RowTemplate.Height = 24
        Me.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dt.Size = New System.Drawing.Size(672, 285)
        Me.dt.TabIndex = 59
        '
        'LoadExcel
        '
        Me.LoadExcel.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.LoadExcel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadExcel.ForeColor = System.Drawing.Color.White
        Me.LoadExcel.Location = New System.Drawing.Point(206, 26)
        Me.LoadExcel.Name = "LoadExcel"
        Me.LoadExcel.Size = New System.Drawing.Size(117, 30)
        Me.LoadExcel.TabIndex = 16
        Me.LoadExcel.Text = "Load Excel"
        Me.LoadExcel.UseVisualStyleBackColor = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1077, 769)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FormMain"
        Me.Text = "Lecory MAUI"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Dontsavedata As System.Windows.Forms.RadioButton
    Friend WithEvents Savedata As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BMGL As System.Windows.Forms.RadioButton
    Friend WithEvents BM As System.Windows.Forms.RadioButton
    Friend WithEvents Normal As System.Windows.Forms.RadioButton
    Friend WithEvents Exitbutton As System.Windows.Forms.Button
    Friend WithEvents pattern As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Graylevelstep As System.Windows.Forms.TextBox
    Friend WithEvents Start As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Overshoot As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dt2 As System.Windows.Forms.DataGridView
    Friend WithEvents MultiStart As System.Windows.Forms.Button
    Friend WithEvents DatagridExport As System.Windows.Forms.Button
    Friend WithEvents SingleStart As System.Windows.Forms.Button
    Friend WithEvents NewOD As System.Windows.Forms.TextBox
    Friend WithEvents dt As System.Windows.Forms.DataGridView
    Friend WithEvents LoadExcel As System.Windows.Forms.Button
    Friend WithEvents LCRT As System.Windows.Forms.RadioButton
    Friend WithEvents Manual As System.Windows.Forms.RadioButton
    Friend WithEvents BMODSimu As System.Windows.Forms.RadioButton
    Friend WithEvents Noover As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Framerate As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Manualstep As System.Windows.Forms.RadioButton
    Friend WithEvents Autostep As System.Windows.Forms.RadioButton
    Friend WithEvents Del As System.Windows.Forms.Button
    Friend WithEvents tenpercent As System.Windows.Forms.RadioButton
    Friend WithEvents JSstep As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents ColorAll As System.Windows.Forms.CheckBox
    Friend WithEvents ColorB As System.Windows.Forms.CheckBox
    Friend WithEvents ColorG As System.Windows.Forms.CheckBox
    Friend WithEvents ColorR As System.Windows.Forms.CheckBox
    Friend WithEvents ColorW As System.Windows.Forms.CheckBox
    Friend WithEvents Percent As System.Windows.Forms.TextBox

End Class
