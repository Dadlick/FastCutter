<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FastCutter
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FastCutter))
        Me.TopLeft = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.YOfsetTxt = New System.Windows.Forms.TextBox()
        Me.XOfsetTxt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RectHeightTxt = New System.Windows.Forms.TextBox()
        Me.RectWidthTxt = New System.Windows.Forms.TextBox()
        Me.DownRight = New System.Windows.Forms.RadioButton()
        Me.DownLeft = New System.Windows.Forms.RadioButton()
        Me.TopRight = New System.Windows.Forms.RadioButton()
        Me.RectanglePb = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AllowFinishPassChb = New System.Windows.Forms.CheckBox()
        Me.ThicknessTxt = New System.Windows.Forms.TextBox()
        Me.AllowFinishPassTxt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FinishPassTxt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DepthPerPassTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DiaCutterTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FeedSpeedTxt = New System.Windows.Forms.TextBox()
        Me.InFeedSpeedTxt = New System.Windows.Forms.TextBox()
        Me.RotateFreqTxt = New System.Windows.Forms.TextBox()
        Me.StepCutTxt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.SafetyLevelTxt = New System.Windows.Forms.TextBox()
        Me.SafetyHeightTxt = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CncFilePathBtn = New System.Windows.Forms.Button()
        Me.CncFilePathTxt = New System.Windows.Forms.TextBox()
        Me.GoRectangleBtn = New System.Windows.Forms.Button()
        Me.InExtCuttingCmbx = New System.Windows.Forms.ComboBox()
        Me.CwCCwCmbx = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.StartCenterBtn = New System.Windows.Forms.RadioButton()
        Me.StartLeftDownBtn = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureSizeLbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PixelSizeTxt = New System.Windows.Forms.TextBox()
        Me.DeltaXTxt = New System.Windows.Forms.TextBox()
        Me.DeltaYTxt = New System.Windows.Forms.TextBox()
        Me.RotateBtn = New System.Windows.Forms.Button()
        Me.DragImage = New System.Windows.Forms.PictureBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PocketCutoutBtn = New System.Windows.Forms.CheckBox()
        Me.PocketCuttingCmbx = New System.Windows.Forms.ComboBox()
        Me.PocketBtn = New System.Windows.Forms.RadioButton()
        Me.CutOutBtn = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.StartZDownBtn = New System.Windows.Forms.RadioButton()
        Me.StartZTopBtn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RectanglePb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DragImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopLeft
        '
        Me.TopLeft.AutoSize = True
        Me.TopLeft.Location = New System.Drawing.Point(17, 22)
        Me.TopLeft.Name = "TopLeft"
        Me.TopLeft.Size = New System.Drawing.Size(14, 13)
        Me.TopLeft.TabIndex = 1
        Me.TopLeft.TabStop = True
        Me.TopLeft.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.YOfsetTxt)
        Me.GroupBox1.Controls.Add(Me.XOfsetTxt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.RectHeightTxt)
        Me.GroupBox1.Controls.Add(Me.RectWidthTxt)
        Me.GroupBox1.Controls.Add(Me.DownRight)
        Me.GroupBox1.Controls.Add(Me.DownLeft)
        Me.GroupBox1.Controls.Add(Me.TopRight)
        Me.GroupBox1.Controls.Add(Me.TopLeft)
        Me.GroupBox1.Controls.Add(Me.RectanglePb)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 306)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Прямоугольник"
        '
        'YOfsetTxt
        '
        Me.YOfsetTxt.Location = New System.Drawing.Point(130, 213)
        Me.YOfsetTxt.Name = "YOfsetTxt"
        Me.YOfsetTxt.Size = New System.Drawing.Size(60, 20)
        Me.YOfsetTxt.TabIndex = 11
        '
        'XOfsetTxt
        '
        Me.XOfsetTxt.Location = New System.Drawing.Point(130, 191)
        Me.XOfsetTxt.Name = "XOfsetTxt"
        Me.XOfsetTxt.Size = New System.Drawing.Size(60, 20)
        Me.XOfsetTxt.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(113, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Y:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(113, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "X:"
        '
        'RectHeightTxt
        '
        Me.RectHeightTxt.Location = New System.Drawing.Point(10, 142)
        Me.RectHeightTxt.Name = "RectHeightTxt"
        Me.RectHeightTxt.Size = New System.Drawing.Size(79, 20)
        Me.RectHeightTxt.TabIndex = 7
        '
        'RectWidthTxt
        '
        Me.RectWidthTxt.Location = New System.Drawing.Point(80, 23)
        Me.RectWidthTxt.Name = "RectWidthTxt"
        Me.RectWidthTxt.Size = New System.Drawing.Size(79, 20)
        Me.RectWidthTxt.TabIndex = 6
        '
        'DownRight
        '
        Me.DownRight.AutoSize = True
        Me.DownRight.Location = New System.Drawing.Point(221, 285)
        Me.DownRight.Name = "DownRight"
        Me.DownRight.Size = New System.Drawing.Size(14, 13)
        Me.DownRight.TabIndex = 5
        Me.DownRight.TabStop = True
        Me.DownRight.UseVisualStyleBackColor = True
        '
        'DownLeft
        '
        Me.DownLeft.AutoSize = True
        Me.DownLeft.Location = New System.Drawing.Point(16, 286)
        Me.DownLeft.Name = "DownLeft"
        Me.DownLeft.Size = New System.Drawing.Size(14, 13)
        Me.DownLeft.TabIndex = 4
        Me.DownLeft.TabStop = True
        Me.DownLeft.UseVisualStyleBackColor = True
        '
        'TopRight
        '
        Me.TopRight.AutoSize = True
        Me.TopRight.Location = New System.Drawing.Point(224, 23)
        Me.TopRight.Name = "TopRight"
        Me.TopRight.Size = New System.Drawing.Size(14, 13)
        Me.TopRight.TabIndex = 3
        Me.TopRight.TabStop = True
        Me.TopRight.UseVisualStyleBackColor = True
        '
        'RectanglePb
        '
        Me.RectanglePb.Location = New System.Drawing.Point(4, 15)
        Me.RectanglePb.Name = "RectanglePb"
        Me.RectanglePb.Size = New System.Drawing.Size(215, 268)
        Me.RectanglePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RectanglePb.TabIndex = 0
        Me.RectanglePb.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.AllowFinishPassChb, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.ThicknessTxt, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.AllowFinishPassTxt, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.FinishPassTxt, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.DepthPerPassTxt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DiaCutterTxt, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.FeedSpeedTxt, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.InFeedSpeedTxt, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.RotateFreqTxt, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.StepCutTxt, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(245, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(183, 289)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'AllowFinishPassChb
        '
        Me.AllowFinishPassChb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AllowFinishPassChb.Location = New System.Drawing.Point(3, 240)
        Me.AllowFinishPassChb.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.AllowFinishPassChb.Name = "AllowFinishPassChb"
        Me.AllowFinishPassChb.Size = New System.Drawing.Size(110, 49)
        Me.AllowFinishPassChb.TabIndex = 5
        Me.AllowFinishPassChb.Text = "Припуск на финишный проход"
        Me.AllowFinishPassChb.UseVisualStyleBackColor = True
        '
        'ThicknessTxt
        '
        Me.ThicknessTxt.Location = New System.Drawing.Point(119, 191)
        Me.ThicknessTxt.Name = "ThicknessTxt"
        Me.ThicknessTxt.Size = New System.Drawing.Size(60, 20)
        Me.ThicknessTxt.TabIndex = 8
        '
        'AllowFinishPassTxt
        '
        Me.AllowFinishPassTxt.Enabled = False
        Me.AllowFinishPassTxt.Location = New System.Drawing.Point(119, 255)
        Me.AllowFinishPassTxt.Margin = New System.Windows.Forms.Padding(3, 15, 3, 0)
        Me.AllowFinishPassTxt.Name = "AllowFinishPassTxt"
        Me.AllowFinishPassTxt.Size = New System.Drawing.Size(60, 20)
        Me.AllowFinishPassTxt.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 26)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Безопасная высота"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(3, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 26)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Финишный проход"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FinishPassTxt
        '
        Me.FinishPassTxt.Location = New System.Drawing.Point(119, 217)
        Me.FinishPassTxt.Name = "FinishPassTxt"
        Me.FinishPassTxt.Size = New System.Drawing.Size(60, 20)
        Me.FinishPassTxt.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 26)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Толщина заготовки"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 26)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Частота вращения"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 26)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Подача врезания"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthPerPassTxt
        '
        Me.DepthPerPassTxt.Location = New System.Drawing.Point(119, 32)
        Me.DepthPerPassTxt.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.DepthPerPassTxt.Name = "DepthPerPassTxt"
        Me.DepthPerPassTxt.Size = New System.Drawing.Size(60, 20)
        Me.DepthPerPassTxt.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Диаметр фрезы"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Глубина обработки за проход"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DiaCutterTxt
        '
        Me.DiaCutterTxt.Location = New System.Drawing.Point(119, 3)
        Me.DiaCutterTxt.Name = "DiaCutterTxt"
        Me.DiaCutterTxt.Size = New System.Drawing.Size(60, 20)
        Me.DiaCutterTxt.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Рабочая подача"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FeedSpeedTxt
        '
        Me.FeedSpeedTxt.Location = New System.Drawing.Point(119, 87)
        Me.FeedSpeedTxt.Name = "FeedSpeedTxt"
        Me.FeedSpeedTxt.Size = New System.Drawing.Size(60, 20)
        Me.FeedSpeedTxt.TabIndex = 6
        '
        'InFeedSpeedTxt
        '
        Me.InFeedSpeedTxt.Location = New System.Drawing.Point(119, 113)
        Me.InFeedSpeedTxt.Name = "InFeedSpeedTxt"
        Me.InFeedSpeedTxt.Size = New System.Drawing.Size(60, 20)
        Me.InFeedSpeedTxt.TabIndex = 7
        '
        'RotateFreqTxt
        '
        Me.RotateFreqTxt.Location = New System.Drawing.Point(119, 139)
        Me.RotateFreqTxt.Name = "RotateFreqTxt"
        Me.RotateFreqTxt.Size = New System.Drawing.Size(60, 20)
        Me.RotateFreqTxt.TabIndex = 8
        '
        'StepCutTxt
        '
        Me.StepCutTxt.Location = New System.Drawing.Point(119, 61)
        Me.StepCutTxt.Name = "StepCutTxt"
        Me.StepCutTxt.Size = New System.Drawing.Size(60, 20)
        Me.StepCutTxt.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Location = New System.Drawing.Point(3, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(110, 26)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Шаг"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.SafetyLevelTxt, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.SafetyHeightTxt, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(116, 162)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(67, 26)
        Me.TableLayoutPanel2.TabIndex = 14
        '
        'SafetyLevelTxt
        '
        Me.SafetyLevelTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SafetyLevelTxt.Location = New System.Drawing.Point(34, 3)
        Me.SafetyLevelTxt.Margin = New System.Windows.Forms.Padding(1, 3, 3, 0)
        Me.SafetyLevelTxt.Name = "SafetyLevelTxt"
        Me.SafetyLevelTxt.ReadOnly = True
        Me.SafetyLevelTxt.Size = New System.Drawing.Size(30, 20)
        Me.SafetyLevelTxt.TabIndex = 13
        '
        'SafetyHeightTxt
        '
        Me.SafetyHeightTxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SafetyHeightTxt.Location = New System.Drawing.Point(3, 3)
        Me.SafetyHeightTxt.Margin = New System.Windows.Forms.Padding(3, 3, 1, 0)
        Me.SafetyHeightTxt.Name = "SafetyHeightTxt"
        Me.SafetyHeightTxt.Size = New System.Drawing.Size(29, 20)
        Me.SafetyHeightTxt.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CncFilePathBtn)
        Me.GroupBox2.Controls.Add(Me.CncFilePathTxt)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 369)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(558, 41)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Путь к файлу"
        '
        'CncFilePathBtn
        '
        Me.CncFilePathBtn.Location = New System.Drawing.Point(514, 10)
        Me.CncFilePathBtn.Name = "CncFilePathBtn"
        Me.CncFilePathBtn.Size = New System.Drawing.Size(40, 28)
        Me.CncFilePathBtn.TabIndex = 10
        Me.CncFilePathBtn.Text = ". . ."
        Me.CncFilePathBtn.UseVisualStyleBackColor = True
        '
        'CncFilePathTxt
        '
        Me.CncFilePathTxt.Location = New System.Drawing.Point(3, 15)
        Me.CncFilePathTxt.Name = "CncFilePathTxt"
        Me.CncFilePathTxt.Size = New System.Drawing.Size(507, 20)
        Me.CncFilePathTxt.TabIndex = 9
        '
        'GoRectangleBtn
        '
        Me.GoRectangleBtn.Location = New System.Drawing.Point(562, 377)
        Me.GoRectangleBtn.Name = "GoRectangleBtn"
        Me.GoRectangleBtn.Size = New System.Drawing.Size(68, 30)
        Me.GoRectangleBtn.TabIndex = 6
        Me.GoRectangleBtn.Text = "Создать"
        Me.GoRectangleBtn.UseVisualStyleBackColor = True
        '
        'InExtCuttingCmbx
        '
        Me.InExtCuttingCmbx.FormattingEnabled = True
        Me.InExtCuttingCmbx.Items.AddRange(New Object() {"Снаружи", "Внутри"})
        Me.InExtCuttingCmbx.Location = New System.Drawing.Point(5, 41)
        Me.InExtCuttingCmbx.Name = "InExtCuttingCmbx"
        Me.InExtCuttingCmbx.Size = New System.Drawing.Size(108, 21)
        Me.InExtCuttingCmbx.TabIndex = 7
        '
        'CwCCwCmbx
        '
        Me.CwCCwCmbx.FormattingEnabled = True
        Me.CwCCwCmbx.Items.AddRange(New Object() {"По часовой", "Против часовой"})
        Me.CwCCwCmbx.Location = New System.Drawing.Point(5, 15)
        Me.CwCCwCmbx.Name = "CwCCwCmbx"
        Me.CwCCwCmbx.Size = New System.Drawing.Size(109, 21)
        Me.CwCCwCmbx.TabIndex = 8
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.StartCenterBtn)
        Me.GroupBox4.Controls.Add(Me.StartLeftDownBtn)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 306)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(140, 64)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Начало координат X/Y"
        '
        'StartCenterBtn
        '
        Me.StartCenterBtn.AutoSize = True
        Me.StartCenterBtn.Location = New System.Drawing.Point(5, 39)
        Me.StartCenterBtn.Name = "StartCenterBtn"
        Me.StartCenterBtn.Size = New System.Drawing.Size(56, 17)
        Me.StartCenterBtn.TabIndex = 1
        Me.StartCenterBtn.Text = "Центр"
        Me.StartCenterBtn.UseVisualStyleBackColor = True
        '
        'StartLeftDownBtn
        '
        Me.StartLeftDownBtn.AutoSize = True
        Me.StartLeftDownBtn.Checked = True
        Me.StartLeftDownBtn.Location = New System.Drawing.Point(5, 16)
        Me.StartLeftDownBtn.Name = "StartLeftDownBtn"
        Me.StartLeftDownBtn.Size = New System.Drawing.Size(125, 17)
        Me.StartLeftDownBtn.TabIndex = 0
        Me.StartLeftDownBtn.TabStop = True
        Me.StartLeftDownBtn.Text = "Левый нижний угол"
        Me.StartLeftDownBtn.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PictureSizeLbl)
        Me.GroupBox5.Controls.Add(Me.Panel1)
        Me.GroupBox5.Controls.Add(Me.DragImage)
        Me.GroupBox5.Location = New System.Drawing.Point(436, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(195, 306)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Размеры с рисунка"
        '
        'PictureSizeLbl
        '
        Me.PictureSizeLbl.BackColor = System.Drawing.Color.Transparent
        Me.PictureSizeLbl.Location = New System.Drawing.Point(5, 177)
        Me.PictureSizeLbl.Name = "PictureSizeLbl"
        Me.PictureSizeLbl.Size = New System.Drawing.Size(185, 14)
        Me.PictureSizeLbl.TabIndex = 12
        Me.PictureSizeLbl.Text = "0x0"
        Me.PictureSizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Location = New System.Drawing.Point(1, 210)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 88)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PixelSizeTxt, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DeltaXTxt, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.DeltaYTxt, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.RotateBtn, 2, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(192, 78)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(3, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 26)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Дельта Y:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(3, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 26)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Дельта X:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 26)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Размер " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "пикселя:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PixelSizeTxt
        '
        Me.PixelSizeTxt.Location = New System.Drawing.Point(67, 3)
        Me.PixelSizeTxt.Name = "PixelSizeTxt"
        Me.PixelSizeTxt.Size = New System.Drawing.Size(73, 20)
        Me.PixelSizeTxt.TabIndex = 6
        '
        'DeltaXTxt
        '
        Me.DeltaXTxt.Location = New System.Drawing.Point(67, 29)
        Me.DeltaXTxt.Name = "DeltaXTxt"
        Me.DeltaXTxt.Size = New System.Drawing.Size(73, 20)
        Me.DeltaXTxt.TabIndex = 8
        '
        'DeltaYTxt
        '
        Me.DeltaYTxt.Location = New System.Drawing.Point(67, 55)
        Me.DeltaYTxt.Name = "DeltaYTxt"
        Me.DeltaYTxt.Size = New System.Drawing.Size(73, 20)
        Me.DeltaYTxt.TabIndex = 10
        '
        'RotateBtn
        '
        Me.RotateBtn.Image = Global.FastCutter.My.Resources.Resources.Rotate
        Me.RotateBtn.Location = New System.Drawing.Point(143, 15)
        Me.RotateBtn.Margin = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.RotateBtn.Name = "RotateBtn"
        Me.TableLayoutPanel3.SetRowSpan(Me.RotateBtn, 3)
        Me.RotateBtn.Size = New System.Drawing.Size(48, 48)
        Me.RotateBtn.TabIndex = 11
        Me.RotateBtn.UseVisualStyleBackColor = True
        '
        'DragImage
        '
        Me.DragImage.AllowDrop = True
        Me.DragImage.Image = Global.FastCutter.My.Resources.Resources.DragFile
        Me.DragImage.Location = New System.Drawing.Point(1, 15)
        Me.DragImage.Name = "DragImage"
        Me.DragImage.Size = New System.Drawing.Size(192, 192)
        Me.DragImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.DragImage.TabIndex = 0
        Me.DragImage.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PocketCutoutBtn)
        Me.GroupBox6.Controls.Add(Me.PocketCuttingCmbx)
        Me.GroupBox6.Controls.Add(Me.PocketBtn)
        Me.GroupBox6.Controls.Add(Me.CutOutBtn)
        Me.GroupBox6.Controls.Add(Me.InExtCuttingCmbx)
        Me.GroupBox6.Controls.Add(Me.CwCCwCmbx)
        Me.GroupBox6.Location = New System.Drawing.Point(436, 306)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(195, 64)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Обработка"
        '
        'PocketCutoutBtn
        '
        Me.PocketCutoutBtn.AutoSize = True
        Me.PocketCutoutBtn.Location = New System.Drawing.Point(158, 16)
        Me.PocketCutoutBtn.Name = "PocketCutoutBtn"
        Me.PocketCutoutBtn.Size = New System.Drawing.Size(85, 17)
        Me.PocketCutoutBtn.TabIndex = 13
        Me.PocketCutoutBtn.Text = "Оконтурить"
        Me.PocketCutoutBtn.UseVisualStyleBackColor = True
        Me.PocketCutoutBtn.Visible = False
        '
        'PocketCuttingCmbx
        '
        Me.PocketCuttingCmbx.FormattingEnabled = True
        Me.PocketCuttingCmbx.Items.AddRange(New Object() {"По спирали", "Вдоль X", "Вдоль Y"})
        Me.PocketCuttingCmbx.Location = New System.Drawing.Point(158, 39)
        Me.PocketCuttingCmbx.Name = "PocketCuttingCmbx"
        Me.PocketCuttingCmbx.Size = New System.Drawing.Size(108, 21)
        Me.PocketCuttingCmbx.TabIndex = 13
        Me.PocketCuttingCmbx.Visible = False
        '
        'PocketBtn
        '
        Me.PocketBtn.AutoSize = True
        Me.PocketBtn.Location = New System.Drawing.Point(120, 43)
        Me.PocketBtn.Name = "PocketBtn"
        Me.PocketBtn.Size = New System.Drawing.Size(64, 17)
        Me.PocketBtn.TabIndex = 10
        Me.PocketBtn.Text = "Карман"
        Me.PocketBtn.UseVisualStyleBackColor = True
        '
        'CutOutBtn
        '
        Me.CutOutBtn.AutoSize = True
        Me.CutOutBtn.Checked = True
        Me.CutOutBtn.Location = New System.Drawing.Point(120, 17)
        Me.CutOutBtn.Name = "CutOutBtn"
        Me.CutOutBtn.Size = New System.Drawing.Size(60, 17)
        Me.CutOutBtn.TabIndex = 9
        Me.CutOutBtn.TabStop = True
        Me.CutOutBtn.Text = "Контур"
        Me.CutOutBtn.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.StartZDownBtn)
        Me.GroupBox7.Controls.Add(Me.StartZTopBtn)
        Me.GroupBox7.Location = New System.Drawing.Point(144, 306)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(130, 64)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Начало координат Z"
        '
        'StartZDownBtn
        '
        Me.StartZDownBtn.AutoSize = True
        Me.StartZDownBtn.Location = New System.Drawing.Point(5, 39)
        Me.StartZDownBtn.Name = "StartZDownBtn"
        Me.StartZDownBtn.Size = New System.Drawing.Size(100, 17)
        Me.StartZDownBtn.TabIndex = 1
        Me.StartZDownBtn.Text = "Низ заготовки"
        Me.StartZDownBtn.UseVisualStyleBackColor = True
        '
        'StartZTopBtn
        '
        Me.StartZTopBtn.AutoSize = True
        Me.StartZTopBtn.Checked = True
        Me.StartZTopBtn.Location = New System.Drawing.Point(5, 16)
        Me.StartZTopBtn.Name = "StartZTopBtn"
        Me.StartZTopBtn.Size = New System.Drawing.Size(104, 17)
        Me.StartZTopBtn.TabIndex = 0
        Me.StartZTopBtn.TabStop = True
        Me.StartZTopBtn.Text = "Верх заготовки"
        Me.StartZTopBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 412)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GoRectangleBtn)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Fast cutter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RectanglePb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.DragImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RectanglePb As System.Windows.Forms.PictureBox
    Friend WithEvents TopLeft As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DownRight As System.Windows.Forms.RadioButton
    Friend WithEvents DownLeft As System.Windows.Forms.RadioButton
    Friend WithEvents TopRight As System.Windows.Forms.RadioButton
    Friend WithEvents RectHeightTxt As System.Windows.Forms.TextBox
    Friend WithEvents RectWidthTxt As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DepthPerPassTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DiaCutterTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FeedSpeedTxt As System.Windows.Forms.TextBox
    Friend WithEvents InFeedSpeedTxt As System.Windows.Forms.TextBox
    Friend WithEvents RotateFreqTxt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CncFilePathBtn As System.Windows.Forms.Button
    Friend WithEvents CncFilePathTxt As System.Windows.Forms.TextBox
    Friend WithEvents AllowFinishPassTxt As System.Windows.Forms.TextBox
    Friend WithEvents FinishPassTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AllowFinishPassChb As System.Windows.Forms.CheckBox
    Friend WithEvents GoRectangleBtn As System.Windows.Forms.Button
    Friend WithEvents YOfsetTxt As System.Windows.Forms.TextBox
    Friend WithEvents XOfsetTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents InExtCuttingCmbx As System.Windows.Forms.ComboBox
    Friend WithEvents CwCCwCmbx As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents StartCenterBtn As System.Windows.Forms.RadioButton
    Friend WithEvents StartLeftDownBtn As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DragImage As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PixelSizeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DeltaXTxt As System.Windows.Forms.TextBox
    Friend WithEvents DeltaYTxt As System.Windows.Forms.TextBox
    Friend WithEvents RotateBtn As System.Windows.Forms.Button
    Friend WithEvents PictureSizeLbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ThicknessTxt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PocketBtn As RadioButton
    Friend WithEvents CutOutBtn As RadioButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents StartZDownBtn As RadioButton
    Friend WithEvents StartZTopBtn As RadioButton
    Friend WithEvents PocketCuttingCmbx As ComboBox
    Friend WithEvents PocketCutoutBtn As CheckBox
    Friend WithEvents SafetyHeightTxt As TextBox
    Friend WithEvents StepCutTxt As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SafetyLevelTxt As TextBox
End Class
