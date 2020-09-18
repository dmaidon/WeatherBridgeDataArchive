<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TC = New System.Windows.Forms.TabControl()
        Me.TpRecords = New System.Windows.Forms.TabPage()
        Me.DgvRecords = New System.Windows.Forms.DataGridView()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TpAmbient = New System.Windows.Forms.TabPage()
        Me.DgvAmbient = New System.Windows.Forms.DataGridView()
        Me.TpWeatherBridge = New System.Windows.Forms.TabPage()
        Me.DgvWb = New System.Windows.Forms.DataGridView()
        Me.TpLogs = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RtbLog = New System.Windows.Forms.RichTextBox()
        Me.TpOptions = New System.Windows.Forms.TabPage()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtnRunEvents = New System.Windows.Forms.Button()
        Me.ChkEnableWb = New System.Windows.Forms.CheckBox()
        Me.ChkLogHdrData = New System.Windows.Forms.CheckBox()
        Me.TxtYearStarted = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumWbUpdateInt = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumAmbientUpdate = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkEnableAmbient = New System.Windows.Forms.CheckBox()
        Me.TxtStationName = New System.Windows.Forms.TextBox()
        Me.NumElevation = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumRecordUpdate = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtWbPassword = New System.Windows.Forms.TextBox()
        Me.TxtWbLogin = New System.Windows.Forms.TextBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.TxtWbIP = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TxtAmbientAppKey = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.TxtAmbientApiKey = New System.Windows.Forms.TextBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.NumArchiveInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Ss1 = New System.Windows.Forms.StatusStrip()
        Me.TsslVer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslRecordUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslArchiveUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslAmbientUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslWbUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslCpy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmrClock = New System.Timers.Timer()
        Me.TmrRecUpdate = New System.Timers.Timer()
        Me.TmrMidnight = New System.Timers.Timer()
        Me.TmrHrUdt = New System.Timers.Timer()
        Me.Ttip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TmrArcUpdate = New System.Timers.Timer()
        Me.TmrAmbUpdate = New System.Timers.Timer()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TmrWbUpdate = New System.Timers.Timer()
        Me.TC.SuspendLayout()
        Me.TpRecords.SuspendLayout()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpAmbient.SuspendLayout()
        CType(Me.DgvAmbient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpWeatherBridge.SuspendLayout()
        CType(Me.DgvWb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpLogs.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpOptions.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.NumWbUpdateInt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumAmbientUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumElevation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumRecordUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        CType(Me.NumArchiveInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ss1.SuspendLayout()
        CType(Me.TmrClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrRecUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrMidnight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrHrUdt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrArcUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrAmbUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmrWbUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TpRecords)
        Me.TC.Controls.Add(Me.TpAmbient)
        Me.TC.Controls.Add(Me.TpWeatherBridge)
        Me.TC.Controls.Add(Me.TpLogs)
        Me.TC.Controls.Add(Me.TpOptions)
        Me.TC.Dock = System.Windows.Forms.DockStyle.Top
        Me.TC.Location = New System.Drawing.Point(0, 0)
        Me.TC.MaximumSize = New System.Drawing.Size(7856, 346)
        Me.TC.MinimumSize = New System.Drawing.Size(786, 346)
        Me.TC.Name = "TC"
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(786, 346)
        Me.TC.TabIndex = 0
        '
        'TpRecords
        '
        Me.TpRecords.Controls.Add(Me.DgvRecords)
        Me.TpRecords.Location = New System.Drawing.Point(4, 26)
        Me.TpRecords.Name = "TpRecords"
        Me.TpRecords.Padding = New System.Windows.Forms.Padding(3)
        Me.TpRecords.Size = New System.Drawing.Size(778, 316)
        Me.TpRecords.TabIndex = 0
        Me.TpRecords.Text = "Records"
        Me.TpRecords.UseVisualStyleBackColor = True
        '
        'DgvRecords
        '
        Me.DgvRecords.AllowUserToAddRows = False
        Me.DgvRecords.AllowUserToDeleteRows = False
        Me.DgvRecords.AllowUserToResizeColumns = False
        Me.DgvRecords.AllowUserToResizeRows = False
        Me.DgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvRecords.ColumnHeadersHeight = 19
        Me.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column4, Me.Column5})
        Me.DgvRecords.Enabled = False
        Me.DgvRecords.Location = New System.Drawing.Point(3, 3)
        Me.DgvRecords.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvRecords.MaximumSize = New System.Drawing.Size(985, 390)
        Me.DgvRecords.MultiSelect = False
        Me.DgvRecords.Name = "DgvRecords"
        Me.DgvRecords.ReadOnly = True
        Me.DgvRecords.RowHeadersVisible = False
        Me.DgvRecords.RowHeadersWidth = 62
        Me.DgvRecords.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gainsboro
        Me.DgvRecords.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvRecords.RowTemplate.Height = 40
        Me.DgvRecords.RowTemplate.ReadOnly = True
        Me.DgvRecords.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvRecords.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgvRecords.Size = New System.Drawing.Size(771, 321)
        Me.DgvRecords.TabIndex = 2
        '
        'Column0
        '
        Me.Column0.FillWeight = 27.27273!
        Me.Column0.HeaderText = ""
        Me.Column0.MaxInputLength = 100
        Me.Column0.MinimumWidth = 110
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column0.Width = 110
        '
        'Column1
        '
        Me.Column1.HeaderText = "All-Time"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 110
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 463.6364!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Year"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 27.27273!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Month"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 27.27273!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Yesterday"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'Column4
        '
        Me.Column4.FillWeight = 27.27273!
        Me.Column4.HeaderText = "Today"
        Me.Column4.MinimumWidth = 110
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 110
        '
        'Column5
        '
        Me.Column5.FillWeight = 27.27273!
        Me.Column5.HeaderText = "Hour"
        Me.Column5.MaxInputLength = 300
        Me.Column5.MinimumWidth = 110
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 110
        '
        'TpAmbient
        '
        Me.TpAmbient.Controls.Add(Me.DgvAmbient)
        Me.TpAmbient.Location = New System.Drawing.Point(4, 26)
        Me.TpAmbient.Name = "TpAmbient"
        Me.TpAmbient.Size = New System.Drawing.Size(778, 316)
        Me.TpAmbient.TabIndex = 3
        Me.TpAmbient.Text = "Ambient"
        Me.TpAmbient.UseVisualStyleBackColor = True
        '
        'DgvAmbient
        '
        Me.DgvAmbient.AllowUserToDeleteRows = False
        Me.DgvAmbient.AllowUserToResizeColumns = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew
        Me.DgvAmbient.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvAmbient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvAmbient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAmbient.ColumnHeadersVisible = False
        Me.DgvAmbient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAmbient.Location = New System.Drawing.Point(0, 0)
        Me.DgvAmbient.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DgvAmbient.Name = "DgvAmbient"
        Me.DgvAmbient.RowHeadersVisible = False
        Me.DgvAmbient.RowHeadersWidth = 62
        Me.DgvAmbient.RowTemplate.Height = 19
        Me.DgvAmbient.Size = New System.Drawing.Size(778, 316)
        Me.DgvAmbient.TabIndex = 3
        Me.DgvAmbient.TabStop = False
        '
        'TpWeatherBridge
        '
        Me.TpWeatherBridge.Controls.Add(Me.DgvWb)
        Me.TpWeatherBridge.Location = New System.Drawing.Point(4, 26)
        Me.TpWeatherBridge.Name = "TpWeatherBridge"
        Me.TpWeatherBridge.Size = New System.Drawing.Size(778, 316)
        Me.TpWeatherBridge.TabIndex = 4
        Me.TpWeatherBridge.Text = "WeatherBridge"
        Me.TpWeatherBridge.UseVisualStyleBackColor = True
        '
        'DgvWb
        '
        Me.DgvWb.AllowUserToAddRows = False
        Me.DgvWb.AllowUserToDeleteRows = False
        Me.DgvWb.AllowUserToResizeColumns = False
        Me.DgvWb.AllowUserToResizeRows = False
        Me.DgvWb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvWb.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvWb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvWb.ColumnHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvWb.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvWb.Dock = System.Windows.Forms.DockStyle.Left
        Me.DgvWb.Location = New System.Drawing.Point(0, 0)
        Me.DgvWb.Margin = New System.Windows.Forms.Padding(0)
        Me.DgvWb.MultiSelect = False
        Me.DgvWb.Name = "DgvWb"
        Me.DgvWb.ReadOnly = True
        Me.DgvWb.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgvWb.RowHeadersVisible = False
        Me.DgvWb.RowHeadersWidth = 62
        Me.DgvWb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvWb.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvWb.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.DgvWb.RowTemplate.Height = 18
        Me.DgvWb.RowTemplate.ReadOnly = True
        Me.DgvWb.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvWb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvWb.ShowEditingIcon = False
        Me.DgvWb.Size = New System.Drawing.Size(773, 316)
        Me.DgvWb.TabIndex = 4
        Me.DgvWb.TabStop = False
        '
        'TpLogs
        '
        Me.TpLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TpLogs.Controls.Add(Me.PictureBox1)
        Me.TpLogs.Controls.Add(Me.RtbLog)
        Me.TpLogs.Location = New System.Drawing.Point(4, 26)
        Me.TpLogs.Name = "TpLogs"
        Me.TpLogs.Padding = New System.Windows.Forms.Padding(3)
        Me.TpLogs.Size = New System.Drawing.Size(778, 316)
        Me.TpLogs.TabIndex = 1
        Me.TpLogs.Text = "Logs"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WeatherBridgeDataArchive.My.Resources.Resources.PS_LOGO_transparent_190x150
        Me.PictureBox1.Location = New System.Drawing.Point(558, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'RtbLog
        '
        Me.RtbLog.BackColor = System.Drawing.SystemColors.Info
        Me.RtbLog.Dock = System.Windows.Forms.DockStyle.Left
        Me.RtbLog.Location = New System.Drawing.Point(3, 3)
        Me.RtbLog.Name = "RtbLog"
        Me.RtbLog.ReadOnly = True
        Me.RtbLog.ShowSelectionMargin = True
        Me.RtbLog.Size = New System.Drawing.Size(494, 310)
        Me.RtbLog.TabIndex = 0
        Me.RtbLog.Text = ""
        '
        'TpOptions
        '
        Me.TpOptions.BackColor = System.Drawing.Color.FloralWhite
        Me.TpOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TpOptions.Controls.Add(Me.Panel10)
        Me.TpOptions.Location = New System.Drawing.Point(4, 26)
        Me.TpOptions.Name = "TpOptions"
        Me.TpOptions.Size = New System.Drawing.Size(778, 316)
        Me.TpOptions.TabIndex = 2
        Me.TpOptions.Text = "Options"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.BtnRunEvents)
        Me.Panel10.Controls.Add(Me.ChkEnableWb)
        Me.Panel10.Controls.Add(Me.ChkLogHdrData)
        Me.Panel10.Controls.Add(Me.TxtYearStarted)
        Me.Panel10.Controls.Add(Me.Label7)
        Me.Panel10.Controls.Add(Me.NumWbUpdateInt)
        Me.Panel10.Controls.Add(Me.Label6)
        Me.Panel10.Controls.Add(Me.NumAmbientUpdate)
        Me.Panel10.Controls.Add(Me.Label5)
        Me.Panel10.Controls.Add(Me.ChkEnableAmbient)
        Me.Panel10.Controls.Add(Me.TxtStationName)
        Me.Panel10.Controls.Add(Me.NumElevation)
        Me.Panel10.Controls.Add(Me.Label2)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Controls.Add(Me.NumRecordUpdate)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Controls.Add(Me.TxtWbPassword)
        Me.Panel10.Controls.Add(Me.TxtWbLogin)
        Me.Panel10.Controls.Add(Me.Label123)
        Me.Panel10.Controls.Add(Me.Label122)
        Me.Panel10.Controls.Add(Me.TxtWbIP)
        Me.Panel10.Controls.Add(Me.Label75)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Controls.Add(Me.NumArchiveInterval)
        Me.Panel10.Controls.Add(Me.Label90)
        Me.Panel10.Controls.Add(Me.Label27)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(776, 314)
        Me.Panel10.TabIndex = 17
        '
        'BtnRunEvents
        '
        Me.BtnRunEvents.BackColor = System.Drawing.Color.Silver
        Me.BtnRunEvents.Enabled = False
        Me.BtnRunEvents.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.BtnRunEvents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnRunEvents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.BtnRunEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRunEvents.Location = New System.Drawing.Point(613, 142)
        Me.BtnRunEvents.Name = "BtnRunEvents"
        Me.BtnRunEvents.Size = New System.Drawing.Size(98, 29)
        Me.BtnRunEvents.TabIndex = 35
        Me.BtnRunEvents.Text = "Run Events"
        Me.BtnRunEvents.UseVisualStyleBackColor = False
        '
        'ChkEnableWb
        '
        Me.ChkEnableWb.AutoSize = True
        Me.ChkEnableWb.Location = New System.Drawing.Point(461, 55)
        Me.ChkEnableWb.Name = "ChkEnableWb"
        Me.ChkEnableWb.Size = New System.Drawing.Size(227, 21)
        Me.ChkEnableWb.TabIndex = 34
        Me.ChkEnableWb.Tag = "1"
        Me.ChkEnableWb.Text = "Enable WeatherBridge Update"
        Me.ChkEnableWb.UseVisualStyleBackColor = True
        '
        'ChkLogHdrData
        '
        Me.ChkLogHdrData.AutoSize = True
        Me.ChkLogHdrData.Location = New System.Drawing.Point(461, 76)
        Me.ChkLogHdrData.Name = "ChkLogHdrData"
        Me.ChkLogHdrData.Size = New System.Drawing.Size(143, 21)
        Me.ChkLogHdrData.TabIndex = 33
        Me.ChkLogHdrData.Tag = "2"
        Me.ChkLogHdrData.Text = "Log Header Data"
        Me.ChkLogHdrData.UseVisualStyleBackColor = True
        '
        'TxtYearStarted
        '
        Me.TxtYearStarted.Location = New System.Drawing.Point(519, 264)
        Me.TxtYearStarted.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtYearStarted.Name = "TxtYearStarted"
        Me.TxtYearStarted.Size = New System.Drawing.Size(82, 23)
        Me.TxtYearStarted.TabIndex = 31
        Me.TxtYearStarted.Tag = "6"
        Me.Ttip.SetToolTip(Me.TxtYearStarted, "Weatherbridge/Meteobridge " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "login name")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(383, 267)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 17)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Year Station Started"
        '
        'NumWbUpdateInt
        '
        Me.NumWbUpdateInt.Location = New System.Drawing.Point(256, 226)
        Me.NumWbUpdateInt.Margin = New System.Windows.Forms.Padding(4)
        Me.NumWbUpdateInt.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.NumWbUpdateInt.Name = "NumWbUpdateInt"
        Me.NumWbUpdateInt.Size = New System.Drawing.Size(72, 23)
        Me.NumWbUpdateInt.TabIndex = 29
        Me.NumWbUpdateInt.Tag = "4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 229)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(239, 17)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "WeatherBridge Update Interval (Min)"
        '
        'NumAmbientUpdate
        '
        Me.NumAmbientUpdate.Location = New System.Drawing.Point(256, 202)
        Me.NumAmbientUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.NumAmbientUpdate.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.NumAmbientUpdate.Name = "NumAmbientUpdate"
        Me.NumAmbientUpdate.Size = New System.Drawing.Size(72, 23)
        Me.NumAmbientUpdate.TabIndex = 2
        Me.NumAmbientUpdate.Tag = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 205)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 17)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Ambient Update Interval (Min)"
        '
        'ChkEnableAmbient
        '
        Me.ChkEnableAmbient.AutoSize = True
        Me.ChkEnableAmbient.Location = New System.Drawing.Point(461, 34)
        Me.ChkEnableAmbient.Name = "ChkEnableAmbient"
        Me.ChkEnableAmbient.Size = New System.Drawing.Size(183, 21)
        Me.ChkEnableAmbient.TabIndex = 8
        Me.ChkEnableAmbient.Tag = "0"
        Me.ChkEnableAmbient.Text = "Enable Ambient Update"
        Me.ChkEnableAmbient.UseVisualStyleBackColor = True
        '
        'TxtStationName
        '
        Me.TxtStationName.Location = New System.Drawing.Point(155, 264)
        Me.TxtStationName.Name = "TxtStationName"
        Me.TxtStationName.Size = New System.Drawing.Size(201, 23)
        Me.TxtStationName.TabIndex = 6
        Me.TxtStationName.Tag = "5"
        '
        'NumElevation
        '
        Me.NumElevation.DecimalPlaces = 2
        Me.NumElevation.Location = New System.Drawing.Point(559, 5)
        Me.NumElevation.Maximum = New Decimal(New Integer() {35000, 0, 0, 0})
        Me.NumElevation.Name = "NumElevation"
        Me.NumElevation.Size = New System.Drawing.Size(103, 23)
        Me.NumElevation.TabIndex = 7
        Me.NumElevation.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(461, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Elevation (Ft)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 267)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Ambient Station Name"
        '
        'NumRecordUpdate
        '
        Me.NumRecordUpdate.Location = New System.Drawing.Point(256, 179)
        Me.NumRecordUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.NumRecordUpdate.Maximum = New Decimal(New Integer() {1440, 0, 0, 0})
        Me.NumRecordUpdate.Name = "NumRecordUpdate"
        Me.NumRecordUpdate.Size = New System.Drawing.Size(72, 23)
        Me.NumRecordUpdate.TabIndex = 1
        Me.NumRecordUpdate.Tag = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 182)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Records Update Interval (Min)"
        '
        'TxtWbPassword
        '
        Me.TxtWbPassword.Location = New System.Drawing.Point(435, 179)
        Me.TxtWbPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtWbPassword.Name = "TxtWbPassword"
        Me.TxtWbPassword.Size = New System.Drawing.Size(126, 23)
        Me.TxtWbPassword.TabIndex = 4
        Me.TxtWbPassword.Tag = "4"
        Me.Ttip.SetToolTip(Me.TxtWbPassword, "Weatherbridge/Meteobridge " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "login password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'TxtWbLogin
        '
        Me.TxtWbLogin.Location = New System.Drawing.Point(435, 156)
        Me.TxtWbLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtWbLogin.Name = "TxtWbLogin"
        Me.TxtWbLogin.Size = New System.Drawing.Size(126, 23)
        Me.TxtWbLogin.TabIndex = 3
        Me.TxtWbLogin.Tag = "3"
        Me.Ttip.SetToolTip(Me.TxtWbLogin, "Weatherbridge/Meteobridge " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "login name")
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.Location = New System.Drawing.Point(366, 182)
        Me.Label123.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(69, 17)
        Me.Label123.TabIndex = 21
        Me.Label123.Text = "Password"
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.Location = New System.Drawing.Point(392, 159)
        Me.Label122.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(43, 17)
        Me.Label122.TabIndex = 20
        Me.Label122.Text = "Login"
        '
        'TxtWbIP
        '
        Me.TxtWbIP.Location = New System.Drawing.Point(435, 202)
        Me.TxtWbIP.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtWbIP.Name = "TxtWbIP"
        Me.TxtWbIP.Size = New System.Drawing.Size(126, 23)
        Me.TxtWbIP.TabIndex = 5
        Me.TxtWbIP.Tag = "2"
        Me.Ttip.SetToolTip(Me.TxtWbIP, "Weatherbridge/Meteobridge " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "network address")
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(359, 205)
        Me.Label75.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(76, 17)
        Me.Label75.TabIndex = 18
        Me.Label75.Text = "IP Address"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.TxtAmbientAppKey)
        Me.Panel11.Controls.Add(Me.Label1)
        Me.Panel11.Controls.Add(Me.Label114)
        Me.Panel11.Controls.Add(Me.TxtAmbientApiKey)
        Me.Panel11.Controls.Add(Me.Label113)
        Me.Panel11.Controls.Add(Me.Label112)
        Me.Panel11.Location = New System.Drawing.Point(6, 31)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(441, 117)
        Me.Panel11.TabIndex = 17
        '
        'TxtAmbientAppKey
        '
        Me.TxtAmbientAppKey.Location = New System.Drawing.Point(67, 49)
        Me.TxtAmbientAppKey.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAmbientAppKey.MaxLength = 200
        Me.TxtAmbientAppKey.Name = "TxtAmbientAppKey"
        Me.TxtAmbientAppKey.Size = New System.Drawing.Size(365, 23)
        Me.TxtAmbientAppKey.TabIndex = 1
        Me.TxtAmbientAppKey.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "App Key"
        '
        'Label114
        '
        Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.Location = New System.Drawing.Point(6, 77)
        Me.Label114.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(426, 35)
        Me.Label114.TabIndex = 20
        Me.Label114.Text = "An Api Key may be generated on your Account page of Ambient Weather.  https://das" &
    "hboard.ambientweather.net/account  "
        '
        'TxtAmbientApiKey
        '
        Me.TxtAmbientApiKey.Location = New System.Drawing.Point(67, 26)
        Me.TxtAmbientApiKey.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAmbientApiKey.MaxLength = 200
        Me.TxtAmbientApiKey.Name = "TxtAmbientApiKey"
        Me.TxtAmbientApiKey.Size = New System.Drawing.Size(365, 23)
        Me.TxtAmbientApiKey.TabIndex = 0
        Me.TxtAmbientApiKey.Tag = "0"
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.Location = New System.Drawing.Point(12, 29)
        Me.Label113.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(56, 17)
        Me.Label113.TabIndex = 18
        Me.Label113.Text = "Api Key"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.Location = New System.Drawing.Point(4, 2)
        Me.Label112.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(132, 17)
        Me.Label112.TabIndex = 1
        Me.Label112.Text = "Ambient Weather" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'NumArchiveInterval
        '
        Me.NumArchiveInterval.Location = New System.Drawing.Point(256, 156)
        Me.NumArchiveInterval.Margin = New System.Windows.Forms.Padding(4)
        Me.NumArchiveInterval.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NumArchiveInterval.Name = "NumArchiveInterval"
        Me.NumArchiveInterval.Size = New System.Drawing.Size(72, 23)
        Me.NumArchiveInterval.TabIndex = 0
        Me.NumArchiveInterval.Tag = "0"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(63, 159)
        Me.Label90.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(193, 17)
        Me.Label90.TabIndex = 7
        Me.Label90.Text = "Archive Update Interval (Sec)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(7, 8)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(350, 17)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Weatherbridge/Ambient Connection Information"
        '
        'Ss1
        '
        Me.Ss1.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.Ss1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.Ss1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Ss1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsslVer, Me.TsslRecordUpdate, Me.TsslArchiveUpdate, Me.TsslAmbientUpdate, Me.TsslWbUpdate, Me.TsslCpy})
        Me.Ss1.Location = New System.Drawing.Point(0, 359)
        Me.Ss1.Name = "Ss1"
        Me.Ss1.Padding = New System.Windows.Forms.Padding(1, 0, 12, 0)
        Me.Ss1.Size = New System.Drawing.Size(779, 26)
        Me.Ss1.SizingGrip = False
        Me.Ss1.TabIndex = 1
        Me.Ss1.Text = "StatusStrip1"
        '
        'TsslVer
        '
        Me.TsslVer.Name = "TsslVer"
        Me.TsslVer.Size = New System.Drawing.Size(16, 19)
        Me.TsslVer.Text = "v"
        '
        'TsslRecordUpdate
        '
        Me.TsslRecordUpdate.BackColor = System.Drawing.Color.Honeydew
        Me.TsslRecordUpdate.Name = "TsslRecordUpdate"
        Me.TsslRecordUpdate.Size = New System.Drawing.Size(15, 19)
        Me.TsslRecordUpdate.Text = "-"
        Me.TsslRecordUpdate.ToolTipText = "Time to next" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Records update"
        '
        'TsslArchiveUpdate
        '
        Me.TsslArchiveUpdate.BackColor = System.Drawing.Color.SeaShell
        Me.TsslArchiveUpdate.Name = "TsslArchiveUpdate"
        Me.TsslArchiveUpdate.Size = New System.Drawing.Size(15, 19)
        Me.TsslArchiveUpdate.Text = "-"
        Me.TsslArchiveUpdate.ToolTipText = "Time to next" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archive update"
        '
        'TsslAmbientUpdate
        '
        Me.TsslAmbientUpdate.BackColor = System.Drawing.Color.Lavender
        Me.TsslAmbientUpdate.Name = "TsslAmbientUpdate"
        Me.TsslAmbientUpdate.Size = New System.Drawing.Size(15, 19)
        Me.TsslAmbientUpdate.Text = "-"
        Me.TsslAmbientUpdate.ToolTipText = "Ambient Weather " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "data update"
        '
        'TsslWbUpdate
        '
        Me.TsslWbUpdate.BackColor = System.Drawing.Color.LightCyan
        Me.TsslWbUpdate.Name = "TsslWbUpdate"
        Me.TsslWbUpdate.Size = New System.Drawing.Size(15, 19)
        Me.TsslWbUpdate.Text = "-"
        Me.TsslWbUpdate.ToolTipText = "WeatherBridge Data Update"
        '
        'TsslCpy
        '
        Me.TsslCpy.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Italic)
        Me.TsslCpy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TsslCpy.Name = "TsslCpy"
        Me.TsslCpy.Size = New System.Drawing.Size(690, 19)
        Me.TsslCpy.Spring = True
        Me.TsslCpy.Text = "cpy"
        '
        'TmrClock
        '
        Me.TmrClock.Interval = 1000.0R
        Me.TmrClock.SynchronizingObject = Me
        '
        'TmrRecUpdate
        '
        Me.TmrRecUpdate.SynchronizingObject = Me
        '
        'TmrMidnight
        '
        Me.TmrMidnight.AutoReset = False
        Me.TmrMidnight.SynchronizingObject = Me
        '
        'TmrHrUdt
        '
        Me.TmrHrUdt.SynchronizingObject = Me
        '
        'Ttip
        '
        Me.Ttip.IsBalloon = True
        '
        'TmrArcUpdate
        '
        Me.TmrArcUpdate.SynchronizingObject = Me
        '
        'TmrAmbUpdate
        '
        Me.TmrAmbUpdate.SynchronizingObject = Me
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'TmrWbUpdate
        '
        Me.TmrWbUpdate.SynchronizingObject = Me
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(779, 385)
        Me.Controls.Add(Me.Ss1)
        Me.Controls.Add(Me.TC)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.WeatherBridgeDataArchive.My.MySettings.Default, "MainFormLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = Global.WeatherBridgeDataArchive.My.MySettings.Default.MainFormLocation
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "Form1"
        Me.TC.ResumeLayout(False)
        Me.TpRecords.ResumeLayout(False)
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpAmbient.ResumeLayout(False)
        CType(Me.DgvAmbient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpWeatherBridge.ResumeLayout(False)
        CType(Me.DgvWb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpLogs.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpOptions.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.NumWbUpdateInt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumAmbientUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumElevation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumRecordUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.NumArchiveInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ss1.ResumeLayout(False)
        Me.Ss1.PerformLayout()
        CType(Me.TmrClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrRecUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrMidnight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrHrUdt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrArcUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrAmbUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmrWbUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TC As TabControl
    Friend WithEvents TpRecords As TabPage
    Friend WithEvents TpLogs As TabPage
    Friend WithEvents Ss1 As StatusStrip
    Friend WithEvents TmrClock As Timers.Timer
    Friend WithEvents TsslVer As ToolStripStatusLabel
    Friend WithEvents TsslCpy As ToolStripStatusLabel
    Friend WithEvents RtbLog As RichTextBox
    Friend WithEvents DgvRecords As DataGridView
    Friend WithEvents TpOptions As TabPage
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TxtWbPassword As TextBox
    Friend WithEvents TxtWbLogin As TextBox
    Friend WithEvents Label123 As Label
    Friend WithEvents Label122 As Label
    Friend WithEvents TxtWbIP As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TxtAmbientAppKey As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label114 As Label
    Friend WithEvents TxtAmbientApiKey As TextBox
    Friend WithEvents Label113 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents NumArchiveInterval As NumericUpDown
    Friend WithEvents Label90 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents TmrRecUpdate As Timers.Timer
    Friend WithEvents TsslRecordUpdate As ToolStripStatusLabel
    Friend WithEvents NumElevation As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents TmrMidnight As Timers.Timer
    Friend WithEvents NumRecordUpdate As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents TmrHrUdt As Timers.Timer
    Friend WithEvents Ttip As ToolTip
    Friend WithEvents TmrArcUpdate As Timers.Timer
    Friend WithEvents TsslArchiveUpdate As ToolStripStatusLabel
    Friend WithEvents TpAmbient As TabPage
    Friend WithEvents TxtStationName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DgvAmbient As DataGridView
    Friend WithEvents ChkEnableAmbient As CheckBox
    Friend WithEvents NumAmbientUpdate As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents TmrAmbUpdate As Timers.Timer
    Friend WithEvents TsslAmbientUpdate As ToolStripStatusLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents TpWeatherBridge As TabPage
    Friend WithEvents DgvWb As DataGridView
    Friend WithEvents NumWbUpdateInt As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents TmrWbUpdate As Timers.Timer
    Friend WithEvents TsslWbUpdate As ToolStripStatusLabel
    Friend WithEvents Column0 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents TxtYearStarted As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ChkLogHdrData As CheckBox
    Friend WithEvents ChkEnableWb As CheckBox
    Friend WithEvents BtnRunEvents As Button
End Class
