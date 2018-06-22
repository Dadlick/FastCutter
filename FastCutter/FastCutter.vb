Imports System.Xml
Imports System.IO
Imports System.Math
Public Class FastCutter
    Private MeLoad As Boolean
    Private ValidSeparotor As String
    Private NotValidSeparotor As String
    Private CncFolderPath As String
    Private HeightImage As Integer
    Private WidthImage As Integer
    Private Precision As Integer = 3
    Private Structure GPoint
        Dim X As Double
        Dim Y As Double
    End Structure

    Private Structure EDLine_
        Dim P1() As Double
        Dim P2() As Double
        Dim OldP1() As Double
        Dim OldP2() As Double
        Dim CP() As Double
        Dim Radius As Double
        Dim Bulge As Double
    End Structure
    Private Structure CurveSegment
        Dim CentrPoint() As Double
        Dim Radius As Double
    End Structure

    Private Structure ReturnIntersectionPoint
        Enum errors
            NoErr = 0
            Parallel = 1
            Coincide = 2
            CircleWithinCircle = 3
        End Enum

        Dim X() As Double
        Dim Y() As Double
        Dim CountPoint As Byte
        Dim err As errors
    End Structure

    Sub New()
        ValidSeparotor = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator()
        If ValidSeparotor = "." Then NotValidSeparotor = "," Else NotValidSeparotor = "."
        InitializeComponent()
        PocketCuttingCmbx.Location = New Point(5, 41)
        PocketCutoutBtn.Location = New Point(5, 15)
        If Not (System.IO.File.Exists(Application.StartupPath & "\Default.xml")) Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Default.xml", My.Resources.ResourceManager.GetObject("_Default").TrimStart(vbCrLf), False, System.Text.Encoding.ASCII)
        End If
        LoadSettings(Application.StartupPath & "\Default.xml")
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Private Function ValidValue(Value As String) As String
        Try
            Return CStr(CDbl(Replace(Value, NotValidSeparotor, ValidSeparotor)))
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()>
    Private Function ValidDouble(Value As String) As Double
        Try
            Return CDbl(Replace(Value, NotValidSeparotor, ValidSeparotor))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Ver-" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.MinorRevision
        MeLoad = True
        RedrawrectImage()
        ReNameCncFile(Nothing, Nothing)
    End Sub

    Private Sub InitChange(sender As Object, e As EventArgs) Handles StartLeftDownBtn.CheckedChanged, StartCenterBtn.CheckedChanged, InExtCuttingCmbx.SelectedIndexChanged, CwCCwCmbx.SelectedIndexChanged
        If MeLoad = True Then
            RedrawrectImage()
        End If
        ReNameCncFile(sender, e)
    End Sub

    Private Sub ReNameCncFile(sender As Object, e As EventArgs) Handles RectHeightTxt.TextChanged, RectWidthTxt.TextChanged
        If MeLoad = False Then Exit Sub
        Dim Filename As String
        If InExtCuttingCmbx.Text = "Снаружи" Then
            Filename = "CutOut"
        ElseIf InExtCuttingCmbx.Text = "Внутри" Then
            Filename = "CutIn"
        End If
        Filename = Filename & "_" & RectWidthTxt.Text & "x" & RectHeightTxt.Text
        CncFilePathTxt.Text = CncFolderPath & Filename
    End Sub

    Sub RedrawrectImage()
        Try
            Dim StartPoint As Bitmap
            Dim Cutter As Bitmap
            If StartLeftDownBtn.Checked = True Then
                StartPoint = My.Resources.StartLeftDown
            Else
                StartPoint = My.Resources.StartCentr
            End If

            If CutOutBtn.Checked = True Then
                If InExtCuttingCmbx.Text = "Снаружи" Then
                    If CwCCwCmbx.Text = "По часовой" Then
                        Cutter = My.Resources.CutExtCw
                    Else
                        Cutter = My.Resources.CutExtCCw
                    End If
                ElseIf InExtCuttingCmbx.Text = "Внутри" Then
                    If CwCCwCmbx.Text = "По часовой" Then
                        Cutter = My.Resources.CutIntCw
                    Else
                        Cutter = My.Resources.CutIntCCw
                    End If
                End If
            Else
                If PocketCuttingCmbx.Text = "По спирали" Then
                    If CwCCwCmbx.Text = "По часовой" Then
                        Cutter = My.Resources.PocketHelixCW
                    Else
                        Cutter = My.Resources.PocketHelixCCW
                    End If
                ElseIf PocketCuttingCmbx.Text = "Вдоль X" Then
                    Cutter = My.Resources.PocketX
                ElseIf PocketCuttingCmbx.Text = "Вдоль Y" Then
                    Cutter = My.Resources.PocketY
                End If
            End If

            Dim bm_dest As New Bitmap(My.Resources.MainRect)
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
            gr_dest.DrawImage(StartPoint, 0, 0, bm_dest.Width, bm_dest.Height)
            gr_dest.DrawImage(Cutter, 0, 0, bm_dest.Width, bm_dest.Height)
            RectanglePb.Image = bm_dest
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LoadSettings(ByVal FileName As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmld = New XmlDocument
        m_xmld.Load(FileName)
        m_nodelist = m_xmld.SelectNodes("Config/GlobalConfig")
        m_node = m_nodelist(0)

        RectWidthTxt.Text = ValidValue(m_node.Item("RectWidth").InnerText)
        RectHeightTxt.Text = ValidValue(m_node.Item("RectHeight").InnerText)
        XOfsetTxt.Text = ValidValue(m_node.Item("XOfset").InnerText)
        YOfsetTxt.Text = ValidValue(m_node.Item("YOfset").InnerText)
        Me.OriginXY = m_node.Item("OriginXY").InnerText
        Me.OriginZ = m_node.Item("OriginZ").InnerText
        Me.InExtCutting = m_node.Item("InExtCutting").InnerText
        Me.CwCCw = m_node.Item("CwCCw").InnerText
        CncFolderPath = m_node.Item("CncFolderPath").InnerText
        Me.StartPoint = m_node.Item("StartPoint").InnerText
        DiaCutterTxt.Text = ValidValue(m_node.Item("DiaCutter").InnerText)
        DepthPerPassTxt.Text = ValidValue(m_node.Item("DepthPerPass").InnerText)
        StepCutTxt.Text = ValidValue(m_node.Item("StepCut").InnerText)

        FeedSpeedTxt.Text = ValidValue(m_node.Item("FeedSpeed").InnerText)
        InFeedSpeedTxt.Text = ValidValue(m_node.Item("InFeedSpeed").InnerText)
        RotateFreqTxt.Text = ValidValue(m_node.Item("RotateFreq").InnerText)
        FinishPassTxt.Text = ValidValue(m_node.Item("Pass").InnerText)
        AllowFinishPassChb.Checked = CBool(m_node.Item("AllowFinishPass").InnerText)

        ThicknessTxt.Text = ValidValue(m_node.Item("Thickness").InnerText)
        AllowFinishPassTxt.Text = ValidValue(m_node.Item("FinishPass").InnerText)
        SafetyHeightTxt.Text = ValidValue(m_node.Item("SafetyLevel").InnerText)
        PixelSizeTxt.Text = ValidValue(m_node.Item("PixelSize").InnerText)
        DeltaXTxt.Text = ValidValue(m_node.Item("DeltaX").InnerText)
        DeltaYTxt.Text = ValidValue(m_node.Item("DeltaY").InnerText)
        Me.ControlType = m_node.Item("ControlType").InnerText
        Me.PocketCutting = m_node.Item("PocketCutting").InnerText
        PocketCutoutBtn.Checked = CBool(m_node.Item("PocketCutout").InnerText)
    End Sub

    Private Sub SaveSettings(ByVal FileName As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmld = New XmlDocument
        m_xmld.Load(FileName)
        m_nodelist = m_xmld.SelectNodes("Config/GlobalConfig")
        m_node = m_nodelist(0)

        m_node.Item("RectWidth").InnerText = RectWidthTxt.Text
        m_node.Item("RectHeight").InnerText = RectHeightTxt.Text
        m_node.Item("XOfset").InnerText = XOfsetTxt.Text
        m_node.Item("YOfset").InnerText = YOfsetTxt.Text
        m_node.Item("OriginXY").InnerText = Me.OriginXY
        m_node.Item("OriginZ").InnerText = Me.OriginZ
        m_node.Item("InExtCutting").InnerText = Me.InExtCutting
        m_node.Item("CwCCw").InnerText = Me.CwCCw
        m_node.Item("CncFolderPath").InnerText = CncFolderPath
        m_node.Item("StartPoint").InnerText = Me.StartPoint
        m_node.Item("DiaCutter").InnerText = DiaCutterTxt.Text
        m_node.Item("DepthPerPass").InnerText = DepthPerPassTxt.Text
        m_node.Item("StepCut").InnerText = StepCutTxt.Text
        m_node.Item("FeedSpeed").InnerText = FeedSpeedTxt.Text
        m_node.Item("InFeedSpeed").InnerText = InFeedSpeedTxt.Text
        m_node.Item("RotateFreq").InnerText = RotateFreqTxt.Text
        m_node.Item("Pass").InnerText = FinishPassTxt.Text
        m_node.Item("AllowFinishPass").InnerText = AllowFinishPassChb.Checked
        m_node.Item("Thickness").InnerText = ThicknessTxt.Text
        m_node.Item("FinishPass").InnerText = AllowFinishPassTxt.Text
        m_node.Item("SafetyLevel").InnerText = SafetyHeightTxt.Text
        m_node.Item("PixelSize").InnerText = PixelSizeTxt.Text
        m_node.Item("DeltaX").InnerText = DeltaXTxt.Text
        m_node.Item("DeltaY").InnerText = DeltaYTxt.Text

        m_node.Item("ControlType").InnerText = Me.ControlType
        m_node.Item("PocketCutting").InnerText = Me.PocketCutting
        m_node.Item("PocketCutout").InnerText = PocketCutoutBtn.Checked
        m_xmld.Save(FileName)
    End Sub

    Property OriginXY As String
        Get
            If StartLeftDownBtn.Checked Then Return "0"
            If StartCenterBtn.Checked Then Return "1"
            Return ""
        End Get
        Set(value As String)
            If value = "0" Then StartLeftDownBtn.Checked = True
            If value = "1" Then StartCenterBtn.Checked = True
        End Set
    End Property

    Property OriginZ As String
        Get
            If StartZTopBtn.Checked Then Return "0"
            If StartZDownBtn.Checked Then Return "1"
            Return ""
        End Get
        Set(value As String)
            If value = "0" Then StartZTopBtn.Checked = True
            If value = "1" Then StartZDownBtn.Checked = True
        End Set
    End Property

    Property InExtCutting As String
        Get
            Return InExtCuttingCmbx.SelectedIndex
        End Get
        Set(value As String)
            Try
                InExtCuttingCmbx.SelectedIndex = CInt(value)
            Catch ex As Exception
                InExtCuttingCmbx.SelectedIndex = 0
            End Try
        End Set
    End Property

    Property CwCCw As String
        Get
            Return CwCCwCmbx.SelectedIndex
        End Get
        Set(value As String)
            Try
                CwCCwCmbx.SelectedIndex = CInt(value)
            Catch ex As Exception
                CwCCwCmbx.SelectedIndex = 0
            End Try
        End Set
    End Property

    Property PocketCutting As String
        Get
            Return PocketCuttingCmbx.SelectedIndex
        End Get
        Set(value As String)
            Try
                PocketCuttingCmbx.SelectedIndex = CInt(value)
            Catch ex As Exception
                PocketCuttingCmbx.SelectedIndex = 0
            End Try
        End Set
    End Property

    Property StartPoint As String
        Get
            If TopLeft.Checked Then Return "0"
            If TopRight.Checked Then Return "1"
            If DownRight.Checked Then Return "2"
            If DownLeft.Checked Then Return "3"

            Return ""
        End Get
        Set(value As String)
            If value = "0" Then TopLeft.Checked = True
            If value = "1" Then TopRight.Checked = True
            If value = "2" Then DownRight.Checked = True
            If value = "3" Then DownLeft.Checked = True
        End Set
    End Property

    Property ControlType As String
        Get
            If CutOutBtn.Checked Then Return "0"
            If PocketBtn.Checked Then Return "1"
            Return ""
        End Get
        Set(value As String)
            If value = "0" Then CutOutBtn.Checked = True
            If value = "1" Then PocketBtn.Checked = True
        End Set
    End Property

    Private Sub AllowFinishPassChb_CheckedChanged(sender As Object, e As EventArgs) Handles AllowFinishPassChb.CheckedChanged
        AllowFinishPassTxt.Enabled = AllowFinishPassChb.Checked
    End Sub

    Private Sub GoRectangleBtn_Click(sender As Object, e As EventArgs) Handles GoRectangleBtn.Click
        Dim i As Integer
        Dim Bulge As Double
        Dim Spoint(0 To 1) As Double
        Dim Epoint(0 To 1) As Double
        Dim CPoint As New ArrayList
        Dim TPoint(0 To 1) As Double
        Dim XOfset As Double
        Dim YOfset As Double
        Dim SafetyLevel As Double = ValidDouble(SafetyLevelTxt.Text)

        Dim CuttingFeed As Double = ValidDouble(FeedSpeedTxt.Text)
        Dim InCuttingFeed As Double = ValidDouble(InFeedSpeedTxt.Text)

        Dim CuttingCount As Integer
        Dim CuttingLayer As Double
        Dim CutElevation As Double

        If StartZTopBtn.Checked = True Then
            If AllowFinishPassChb.Checked = True Then
                CuttingCount = Ceiling((ValidDouble(FinishPassTxt.Text) - ValidDouble(AllowFinishPassTxt.Text)) / ValidDouble(DepthPerPassTxt.Text))
                CuttingLayer = (ValidDouble(FinishPassTxt.Text) - ValidDouble(AllowFinishPassTxt.Text)) / CuttingCount
                CuttingCount = CuttingCount + 1
            Else
                CuttingCount = Ceiling(ValidDouble(FinishPassTxt.Text) / ValidDouble(DepthPerPassTxt.Text))
                CuttingLayer = ValidDouble(FinishPassTxt.Text) / CuttingCount
            End If
        ElseIf StartZDownBtn.Checked = True Then
            If AllowFinishPassChb.Checked = True Then
                CuttingCount = Ceiling((ValidDouble(ThicknessTxt.Text) - ValidDouble(FinishPassTxt.Text) - ValidDouble(AllowFinishPassTxt.Text)) / ValidDouble(DepthPerPassTxt.Text))
                CuttingLayer = (ValidDouble(ThicknessTxt.Text) - ValidDouble(FinishPassTxt.Text) - ValidDouble(AllowFinishPassTxt.Text)) / CuttingCount
                CuttingCount = CuttingCount + 1
            Else
                CuttingCount = Ceiling((ValidDouble(ThicknessTxt.Text) - ValidDouble(FinishPassTxt.Text)) / ValidDouble(DepthPerPassTxt.Text))
                CuttingLayer = (ValidDouble(ThicknessTxt.Text) - ValidDouble(FinishPassTxt.Text)) / CuttingCount
            End If
        End If

        If StartLeftDownBtn.Checked = True Then
            XOfset = ValidDouble(XOfsetTxt.Text)
            YOfset = ValidDouble(YOfsetTxt.Text)
        ElseIf StartCenterBtn.Checked = True Then
            XOfset = ValidDouble(XOfsetTxt.Text) - ValidDouble(RectWidthTxt.Text) / 2
            YOfset = ValidDouble(YOfsetTxt.Text) - ValidDouble(RectHeightTxt.Text) / 2
        End If


        If CutOutBtn.Checked = True Or (PocketBtn.Checked = True And PocketCuttingCmbx.SelectedIndex = 0) Then
            Dim Cw As Boolean
            If CwCCwCmbx.Text = "По часовой" And CutOutBtn.Checked = True Then
                Cw = True
            ElseIf CwCCwCmbx.Text = "Против часовой" And CutOutBtn.Checked = True Then
                Cw = False
            ElseIf CwCCwCmbx.Text = "По часовой" And PocketBtn.Checked = True Then
                Cw = False
            ElseIf CwCCwCmbx.Text = "Против часовой" And PocketBtn.Checked = True Then
                Cw = True
            End If
            If DownLeft.Checked = True Then
                If Cw = True Then
                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)
                Else
                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)
                End If
            ElseIf TopLeft.Checked = True Then
                If Cw = True Then
                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)
                Else
                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)
                End If
            ElseIf TopRight.Checked = True Then
                If Cw = True Then
                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)
                Else
                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)
                End If
            ElseIf DownRight.Checked = True Then
                If Cw = True Then
                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)
                Else
                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = ValidDouble(RectHeightTxt.Text)
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = 0
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)

                    TPoint(0) = ValidDouble(RectWidthTxt.Text)
                    TPoint(1) = 0
                    CPoint.Add(TPoint.Clone)
                End If
            End If
        End If

        If CutOutBtn.Checked = True Then


            Dim h As Double

            If InExtCuttingCmbx.Text = "Снаружи" Then
                If CwCCwCmbx.Text = "По часовой" Then
                    h = ValidDouble(DiaCutterTxt.Text) / 2
                Else
                    h = -ValidDouble(DiaCutterTxt.Text) / 2
                End If
            ElseIf InExtCuttingCmbx.Text = "Внутри" Then
                If CwCCwCmbx.Text = "По часовой" Then
                    h = -ValidDouble(DiaCutterTxt.Text) / 2
                Else
                    h = ValidDouble(DiaCutterTxt.Text) / 2
                End If
            End If

            Dim EquiPline As List(Of EDLine_) = EquiTest(CPoint, h)

            Dim sw1 As StreamWriter = New StreamWriter(CncFilePathTxt.Text, False, System.Text.Encoding.GetEncoding(1251))
            Dim Out As String
            Dim Curve As CurveSegment

            Out = "%"
            sw1.WriteLine(Out)
            Out = "G90"
            sw1.WriteLine(Out)
            Out = "G49"
            sw1.WriteLine(Out)
            Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
            sw1.WriteLine(Out)
            Out = "M3 S" + GcodeRound(ValidDouble(RotateFreqTxt.Text))
            sw1.WriteLine(Out)
            Spoint = EquiPline(0).P1
            Out = "G0" + " X" + GcodeRound(Spoint(0) + XOfset, Precision) + " Y" + GcodeRound(Spoint(1) + YOfset, Precision)
            sw1.WriteLine(Out)

            For z = 1 To CuttingCount
                If StartZTopBtn.Checked = True Then
                    If z = CuttingCount Then
                        CutElevation = -ValidDouble(FinishPassTxt.Text)
                    Else
                        CutElevation = -z * CuttingLayer
                    End If
                ElseIf StartZDownBtn.Checked = True Then
                    If z = CuttingCount Then
                        CutElevation = ValidDouble(FinishPassTxt.Text)
                    Else
                        CutElevation = ValidDouble(ThicknessTxt.Text) - z * CuttingLayer
                    End If
                End If

                For i = 0 To EquiPline.Count - 1
                    Bulge = EquiPline(i).Bulge
                    Spoint = EquiPline(i).P1
                    Epoint = EquiPline(i).P2
                    If i = 0 Then
                        Out = "G1" + " Z" + GcodeRound(CutElevation, Precision) + " F" + GcodeRound(InCuttingFeed)
                        sw1.WriteLine(Out)
                    End If
                    If Bulge <> 0 Then
                        Curve = CurvePline(Spoint, Epoint, Bulge)
                    End If
                    If Bulge = 0 Then
                        Out = "G1" + " X" + GcodeRound(Epoint(0) + XOfset, Precision) + " Y" + GcodeRound(Epoint(1) + YOfset, Precision)
                    ElseIf Bulge < 0 Then
                        Out = "G2" + " X" + GcodeRound(Epoint(0) + XOfset, Precision) + " Y" + GcodeRound(Epoint(1) + YOfset, Precision) + " I" + GcodeRound(Curve.CentrPoint(0) - Spoint(0), Precision) + " J" + GcodeRound(Curve.CentrPoint(1) - Spoint(1), Precision)
                    ElseIf Bulge > 0 Then
                        Out = "G3" + " X" + GcodeRound(Epoint(0) + XOfset, Precision) + " Y" + GcodeRound(Epoint(1) + YOfset, Precision) + " I" + GcodeRound(Curve.CentrPoint(0) - Spoint(0), Precision) + " J" + GcodeRound(Curve.CentrPoint(1) - Spoint(1), Precision)
                    End If
                    If i = 0 Then
                        Out = Out + " F" + GcodeRound(CuttingFeed)
                    End If
                    sw1.WriteLine(Out)
                Next
            Next z
            Out = "G0" + " Z" + GcodeRound(SafetyLevel, Precision)
            sw1.WriteLine(Out)
            Out = "M05"
            sw1.WriteLine(Out)
            Out = "M02"
            sw1.WriteLine(Out)
            Out = "%"
            sw1.WriteLine(Out)
            sw1.Close()
        ElseIf PocketBtn.Checked = True Then
            If PocketCuttingCmbx.Text = "По спирали" Then
                Dim h As Double = ValidDouble(DiaCutterTxt.Text) / 2
                Dim h1 As Double = ValidDouble(StepCutTxt.Text)
                Dim Cycle As Integer
                Dim PrevPoint(0 To 1) As Double

                If ValidDouble(RectWidthTxt.Text) > ValidDouble(RectHeightTxt.Text) Then
                    Cycle = Floor((ValidDouble(RectHeightTxt.Text) / 2 - h) / h1)
                Else
                    Cycle = Floor((ValidDouble(RectWidthTxt.Text) / 2 - h) / h1)
                End If

                If CwCCwCmbx.Text = "Против часовой" Then
                    h = -1 * h
                    h1 = -1 * h1
                End If

                Dim EquiPline As List(Of EDLine_) = EquiTest(CPoint, h)
                Dim OutPath As New List(Of EDLine_)

                For i = 0 To Cycle
                    CPoint = New ArrayList
                    For z = 0 To EquiPline.Count - 1
                        Dim Point As EDLine_ = EquiPline(z)

                        OutPath.Add(Point)

                        If z < EquiPline.Count - 1 Then
                            TPoint(0) = Point.P1(0)
                            TPoint(1) = Point.P1(1)
                            CPoint.Add(TPoint.Clone)
                        Else
                            TPoint(0) = Point.P1(0)
                            TPoint(1) = Point.P1(1)
                            CPoint.Add(TPoint.Clone)
                            TPoint(0) = Point.P2(0)
                            TPoint(1) = Point.P2(1)
                            CPoint.Add(TPoint.Clone)

                        End If

                    Next
                    EquiPline = EquiTest(CPoint, h1)
                Next i

                OutPath.Reverse()
                Dim sw1 As StreamWriter = New StreamWriter(CncFilePathTxt.Text, False, System.Text.Encoding.GetEncoding(1251))
                Dim Out As String

                Out = "%"
                sw1.WriteLine(Out)
                Out = "G90"
                sw1.WriteLine(Out)
                Out = "G49"
                sw1.WriteLine(Out)
                Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
                sw1.WriteLine(Out)
                Out = "M3 S" + GcodeRound(ValidDouble(RotateFreqTxt.Text))
                sw1.WriteLine(Out)
                Spoint = OutPath(0).P2
                Out = "G0" + " X" + GcodeRound(Spoint(0) + XOfset, Precision) + " Y" + GcodeRound(Spoint(1) + YOfset, Precision)
                sw1.WriteLine(Out)

                For z = 1 To CuttingCount
                    If StartZTopBtn.Checked = True Then
                        If z = CuttingCount Then
                            CutElevation = -ValidDouble(FinishPassTxt.Text)
                        Else
                            CutElevation = -z * CuttingLayer
                        End If
                    ElseIf StartZDownBtn.Checked = True Then
                        If z = CuttingCount Then
                            CutElevation = ValidDouble(FinishPassTxt.Text)
                        Else
                            CutElevation = ValidDouble(ThicknessTxt.Text) - z * CuttingLayer
                        End If
                    End If

                    For i = 0 To OutPath.Count - 1
                        Bulge = OutPath(i).Bulge
                        If i > 0 Then
                            PrevPoint = OutPath(i - 1).P1
                        End If
                        Spoint = OutPath(i).P2
                        Epoint = OutPath(i).P1
                        If i = 0 Then
                            Out = "G1" + " Z" + GcodeRound(CutElevation, Precision) + " F" + GcodeRound(InCuttingFeed)
                            sw1.WriteLine(Out)
                        End If

                        If i > 0 Then
                            If Spoint(0) <> PrevPoint(0) And Spoint(0) <> PrevPoint(0) Then
                                Out = "G1" + " X" + GcodeRound(Spoint(0) + XOfset, Precision) + " Y" + GcodeRound(Spoint(1) + YOfset, Precision)
                                sw1.WriteLine(Out)
                            End If
                        End If

                        Out = "G1" + " X" + GcodeRound(Epoint(0) + XOfset, Precision) + " Y" + GcodeRound(Epoint(1) + YOfset, Precision)
                        If i = 0 Then
                            Out = Out + " F" + GcodeRound(CuttingFeed)
                        End If
                        sw1.WriteLine(Out)
                    Next
                    If z < CuttingCount Then
                        Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
                        sw1.WriteLine(Out)
                        Spoint = OutPath(0).P1
                        Out = "G0" + " X" + GcodeRound(Spoint(0) + XOfset, Precision) + " Y" + GcodeRound(Spoint(1) + YOfset, Precision)
                        sw1.WriteLine(Out)
                    End If
                Next z
                Out = "G0" + " Z" + GcodeRound(SafetyLevel, Precision)
                sw1.WriteLine(Out)
                Out = "M05"
                sw1.WriteLine(Out)
                Out = "M02"
                sw1.WriteLine(Out)
                Out = "%"
                sw1.WriteLine(Out)
                sw1.Close()
            ElseIf PocketCuttingCmbx.Text = "Вдоль X" Then
                Dim DownLeftX As Double
                Dim TopRightX As Double
                Dim DownLeftY As Double
                Dim TopRightY As Double
                Dim h As Double = ValidDouble(DiaCutterTxt.Text) / 2
                Dim h1 As Double = ValidDouble(StepCutTxt.Text)
                Dim Cycle As Integer
                Dim OutPath As New List(Of GPoint)
                Dim ConturPath As New List(Of GPoint)

                Dim Gpoint As GPoint
                Dim CurY As Double
                Dim StepY As Double

                If PocketCutoutBtn.Checked = True Then
                    If StartLeftDownBtn.Checked = True Then
                        DownLeftX = h + h1
                        DownLeftY = h + h1
                        TopRightX = ValidDouble(RectWidthTxt.Text) - h - h1
                        TopRightY = ValidDouble(RectHeightTxt.Text) - h - h1
                    Else
                        DownLeftX = h1 + h - ValidDouble(RectWidthTxt.Text) / 2
                        DownLeftY = h1 + h - ValidDouble(RectHeightTxt.Text) / 2
                        TopRightX = ValidDouble(RectWidthTxt.Text) / 2 - h - h1
                        TopRightY = ValidDouble(RectHeightTxt.Text) / 2 - h - h1
                    End If
                    Cycle = Ceiling((ValidDouble(RectHeightTxt.Text) - 2 * h - 2 * h1) / h1)
                    StepY = (ValidDouble(RectHeightTxt.Text) - 2 * h - 2 * h1) / Cycle
                Else
                    If StartLeftDownBtn.Checked = True Then
                        DownLeftX = h
                        DownLeftY = h
                        TopRightX = ValidDouble(RectWidthTxt.Text) - h
                        TopRightY = ValidDouble(RectHeightTxt.Text) - h
                    Else
                        DownLeftX = h - ValidDouble(RectWidthTxt.Text) / 2
                        DownLeftY = h - ValidDouble(RectHeightTxt.Text) / 2
                        TopRightX = ValidDouble(RectWidthTxt.Text) / 2 - h
                        TopRightY = ValidDouble(RectHeightTxt.Text) / 2 - h
                    End If
                    Cycle = Ceiling((ValidDouble(RectHeightTxt.Text) - 2 * h) / h1)
                    StepY = (ValidDouble(RectHeightTxt.Text) - 2 * h) / Cycle
                End If

                If DownLeft.Checked = True Then
                    If PocketCutoutBtn.Checked = True Then
                        Gpoint.X = DownLeftX - h1
                        Gpoint.Y = DownLeftY - h1
                        ConturPath.Add(Gpoint)

                        Gpoint.X = TopRightX + h1
                        Gpoint.Y = DownLeftY - h1
                        ConturPath.Add(Gpoint)

                        Gpoint.X = TopRightX + h1
                        Gpoint.Y = TopRightY + h1
                        ConturPath.Add(Gpoint)

                        Gpoint.X = DownLeftX - h1
                        Gpoint.Y = TopRightY + h1
                        ConturPath.Add(Gpoint)

                        Gpoint.X = DownLeftX - h1
                        Gpoint.Y = DownLeftY - h1
                        ConturPath.Add(Gpoint)
                    End If
                    For i = 0 To Cycle
                        If i = 0 Then
                            CurY = DownLeftY
                        ElseIf i = Cycle Then
                            CurY = TopRightY
                        End If
                        If i Mod 2 Then
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY + StepY
                        Else
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY + StepY
                        End If
                    Next
                ElseIf TopLeft.Checked = True Then
                    For i = 0 To Cycle
                        If i = 0 Then
                            CurY = TopRightY
                        ElseIf i = Cycle Then
                            CurY = DownLeftY
                        End If
                        If i Mod 2 Then
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY - StepY
                        Else
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY - StepY
                        End If
                    Next
                ElseIf TopRight.Checked = True Then
                    For i = 0 To Cycle
                        If i = 0 Then
                            CurY = TopRightY
                        ElseIf i = Cycle Then
                            CurY = DownLeftY
                        End If
                        If i Mod 2 Then
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY - StepY
                        Else
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY - StepY
                        End If
                    Next
                ElseIf DownRight.Checked = True Then
                    For i = 0 To Cycle
                        If i = 0 Then
                            CurY = DownLeftY
                        ElseIf i = Cycle Then
                            CurY = TopRightY
                        End If
                        If i Mod 2 Then
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY + StepY
                        Else
                            Gpoint.X = TopRightX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            Gpoint.X = DownLeftX
                            Gpoint.Y = CurY
                            OutPath.Add(Gpoint)
                            CurY = CurY + StepY
                        End If
                    Next
                End If

                Dim sw1 As StreamWriter = New StreamWriter(CncFilePathTxt.Text, False, System.Text.Encoding.GetEncoding(1251))
                Dim Out As String
                Out = "%"
                sw1.WriteLine(Out)
                Out = "G90"
                sw1.WriteLine(Out)
                Out = "G49"
                sw1.WriteLine(Out)
                Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
                sw1.WriteLine(Out)
                Out = "M3 S" + GcodeRound(ValidDouble(RotateFreqTxt.Text))
                sw1.WriteLine(Out)
                Out = "G0" + " X" + GcodeRound(OutPath(0).X, Precision) + " Y" + GcodeRound(OutPath(0).Y, Precision)
                sw1.WriteLine(Out)

                For z = 1 To CuttingCount
                    If StartZTopBtn.Checked = True Then
                        If z = CuttingCount Then
                            CutElevation = -ValidDouble(FinishPassTxt.Text)
                        Else
                            CutElevation = -z * CuttingLayer
                        End If
                    ElseIf StartZDownBtn.Checked = True Then
                        If z = CuttingCount Then
                            CutElevation = ValidDouble(FinishPassTxt.Text)
                        Else
                            CutElevation = ValidDouble(ThicknessTxt.Text) - z * CuttingLayer
                        End If
                    End If

                    For i = 0 To OutPath.Count - 1
                        If i = 0 Then
                            Out = "G1" + " Z" + GcodeRound(CutElevation, Precision) + " F" + GcodeRound(InCuttingFeed)
                            sw1.WriteLine(Out)
                        End If
                        Out = "G1" + " X" + GcodeRound(OutPath(i).X, Precision) + " Y" + GcodeRound(OutPath(i).Y, Precision)
                        If i = 0 Then
                            Out = Out + " F" + GcodeRound(CuttingFeed)
                        End If
                        sw1.WriteLine(Out)
                    Next
                    If z < CuttingCount Then
                        Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
                        sw1.WriteLine(Out)
                        Out = "G0" + " X" + GcodeRound(OutPath(0).X, Precision) + " Y" + GcodeRound(OutPath(0).Y, Precision)
                        sw1.WriteLine(Out)
                    End If
                Next z

                If PocketCutoutBtn.Checked = True Then
                    Out = "G0" + " Z" + GcodeRound(SafetyLevel, Precision)
                    sw1.WriteLine(Out)

                    Out = "G0" + " X" + GcodeRound(ConturPath(0).X, Precision) + " Y" + GcodeRound(ConturPath(0).Y, Precision)
                    sw1.WriteLine(Out)

                    For z = 1 To CuttingCount
                        If StartZTopBtn.Checked = True Then
                            If z = CuttingCount Then
                                CutElevation = -ValidDouble(FinishPassTxt.Text)
                            Else
                                CutElevation = -z * CuttingLayer
                            End If
                        ElseIf StartZDownBtn.Checked = True Then
                            If z = CuttingCount Then
                                CutElevation = ValidDouble(FinishPassTxt.Text)
                            Else
                                CutElevation = ValidDouble(ThicknessTxt.Text) - z * CuttingLayer
                            End If
                        End If

                        For i = 0 To ConturPath.Count - 1
                            If i = 0 Then
                                Out = "G1" + " Z" + GcodeRound(CutElevation, Precision) + " F" + GcodeRound(InCuttingFeed)
                                sw1.WriteLine(Out)
                            End If
                            Out = "G1" + " X" + GcodeRound(ConturPath(i).X, Precision) + " Y" + GcodeRound(ConturPath(i).Y, Precision)
                            If i = 0 Then
                                Out = Out + " F" + GcodeRound(CuttingFeed)
                            End If
                            sw1.WriteLine(Out)
                        Next
                        If z < CuttingCount Then
                            Out = "G0 Z" + GcodeRound(SafetyLevel, Precision)
                            sw1.WriteLine(Out)
                            Out = "G0" + " X" + GcodeRound(ConturPath(0).X, Precision) + " Y" + GcodeRound(ConturPath(0).Y, Precision)
                            sw1.WriteLine(Out)
                        End If
                    Next z
                End If

                Out = "G0" + " Z" + GcodeRound(SafetyLevel, Precision)
                sw1.WriteLine(Out)
                Out = "M05"
                sw1.WriteLine(Out)
                Out = "M02"
                sw1.WriteLine(Out)
                Out = "%"
                sw1.WriteLine(Out)
                sw1.Close()

            ElseIf PocketCuttingCmbx.Text = "Вдоль Y" Then
                If PocketCutoutBtn.Checked = True Then

                End If
                If DownLeft.Checked = True Then

                ElseIf TopLeft.Checked = True Then

                ElseIf TopRight.Checked = True Then

                ElseIf DownRight.Checked = True Then

                End If

            End If
        End If
        SaveSettings(Application.StartupPath & "\Default.xml")
    End Sub

    Private Function EquiTest(ByVal CPoint As ArrayList, ByVal h As Double) As List(Of EDLine_)
        Dim i As Integer
        Dim Bulge As Double
        Dim Spoint(0 To 1) As Double
        Dim Epoint(0 To 1) As Double
        Dim InPlines(0 To 3) As Double
        Dim TempPoints(0 To 1) As Double
        Dim InPline As New List(Of EDLine_)
        Dim EquiPline As New List(Of EDLine_)
        Dim EDLine As EDLine_
        Dim EDLineNext As EDLine_
        Dim EDLineAdditional As EDLine_
        Dim Delta As Double = 0.001
        Dim TempIntersectPoint As ReturnIntersectionPoint
        Dim IntersectPoint(0 To 1) As Double
        Dim PointBelongFirstLine As Boolean
        Dim PointBelongSecondLine As Boolean
        Dim Angle As Double

        For i = 0 To CPoint.Count - 2
            Bulge = 0
            Spoint = CPoint(i)
            Epoint = CPoint(i + 1)
            EDLine = EDLinePoint(Spoint, Epoint, Bulge, h)
            InPline.Add(EDLine)
        Next i

        For i = 0 To InPline.Count - 1
            EDLine = InPline(i)
            If i = InPline.Count - 1 Then
                EDLineNext = InPline(0)
            Else
                EDLineNext = InPline(i + 1)
            End If

            If EDLine.Bulge = 0 And EDLineNext.Bulge = 0 Then
                'прямая-прямая
                TempIntersectPoint = IntersectLineLine(EDLine.P1, EDLine.P2, EDLineNext.P1, EDLineNext.P2)
                IntersectPoint(0) = TempIntersectPoint.X(0)
                IntersectPoint(1) = TempIntersectPoint.Y(0)
                PointBelongFirstLine = PointBelongLine(EDLine.P1, EDLine.P2, IntersectPoint)
                PointBelongSecondLine = PointBelongLine(EDLineNext.P1, EDLineNext.P2, IntersectPoint)

                If PointBelongFirstLine = False Or PointBelongSecondLine = False Then
                    'прямые не пересекаются добавляем дуговой сегмент
                    Angle = angle3Point(EDLine.P1, IntersectPoint, EDLineNext.P2)
                    EquiPline.Add(EDLine)
                    EDLineAdditional.P1 = EDLine.P2
                    EDLineAdditional.P2 = EDLineNext.P1
                    If Angle > 0 Then
                        EDLineAdditional.Bulge = -1 * Tan((PI - Angle) / 4)
                    Else
                        EDLineAdditional.Bulge = Tan((PI + Angle) / 4)
                    End If
                    EquiPline.Add(EDLineAdditional)
                Else
                    ' прямые пересекабтся используем точку пересечения
                    EDLine.P2(0) = IntersectPoint(0)
                    EDLine.P2(1) = IntersectPoint(1)
                    EquiPline.Add(EDLine)
                    If i = InPline.Count - 1 Then
                        EDLine = EquiPline(0)
                        EDLine.P1(0) = IntersectPoint(0)
                        EDLine.P1(1) = IntersectPoint(1)
                        EquiPline(0) = EDLine
                    Else
                        EDLineNext.P1(0) = IntersectPoint(0)
                        EDLineNext.P1(1) = IntersectPoint(1)
                        InPline(i + 1) = EDLineNext
                    End If
                End If
            End If
        Next i

        Return EquiPline
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function GcodeRound(ByVal Value As Double, Optional ByVal Precision As Integer = -1) As String
        If Precision > -1 Then
            GcodeRound = CStr(Replace(Round(Value, Precision), ",", "."))
        Else
            GcodeRound = CStr(Replace(Value, ",", "."))
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function CurvePline(ByVal SPnt() As Double, ByVal EPnt() As Double, ByVal Bulge As Double) As CurveSegment
        ' Функция определяющая радиус и центр дугового сегмента полилинии
        Dim Len As Double
        Dim InclAng As Double
        Dim Rad As Double
        Dim Ang As Double
        Dim Center() As Double
        Dim Base As Double
        Dim Pnt(0 To 2) As Double : Pnt(0) = SPnt(0) : Pnt(1) = SPnt(1)
        Len = LineLenght(SPnt, EPnt)
        InclAng = Atan(Abs(Bulge)) * 4
        Ang = (InclAng / 2) - ((Atan(1) * 4) / 2)
        Rad = (Len / 2) / (Cos(Ang))
        Base = angle2Point(SPnt, EPnt)

        If Bulge > 0 Then
            Center = PolarPoint(Pnt, Base - Ang, Rad)
        Else
            Center = PolarPoint(Pnt, Base + Ang, Rad)
        End If

        CurvePline.Radius = Rad
        CurvePline.CentrPoint = Center
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function PolarPoint(Pnt() As Double, Ang As Double, rad As Double) As Double()
        Dim X As Double = rad * Cos(Ang)
        Dim Y As Double = rad * Sin(Ang)
        Pnt(0) = Pnt(0) + X
        Pnt(1) = Pnt(1) + Y
        Return Pnt
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function LineLenght(ByVal point1() As Double, ByVal point2() As Double) As Double
        'функция возвращает длинну между точками
        LineLenght = Sqrt((point2(0) - point1(0)) ^ 2 + (point2(1) - point1(1)) ^ 2)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function angle2Point(ByVal StartPoint() As Double, ByVal Endpoint() As Double) As Double
        'функция  возвращает угол наклона линии
        Dim dY As Double = Endpoint(1) - StartPoint(1)
        Dim dX As Double = Endpoint(0) - StartPoint(0)
        angle2Point = Atan2(dY, dX)
    End Function

    Private Function EDLinePoint(ByVal P1() As Double, ByVal P2() As Double, ByVal Bulge As Double, ByVal h As Double) As EDLine_
        'функция  возвращает эквидистантную линию
        Dim Temp As EDLine_
        ReDim Temp.P1(0 To 1)
        ReDim Temp.P2(0 To 1)
        Dim Alfa As Double
        Dim CurveSegment_ As CurveSegment
        Temp.OldP1 = P1
        Temp.OldP2 = P2
        If Bulge = 0 Then
            Alfa = angle2Point(P1, P2)
            Temp.P1(0) = P1(0) + h * Cos(Alfa + PI / 2)
            Temp.P1(1) = P1(1) + h * Sin(Alfa + PI / 2)
            Temp.P2(0) = P2(0) + h * Cos(Alfa + PI / 2)
            Temp.P2(1) = P2(1) + h * Sin(Alfa + PI / 2)
        Else
            CurveSegment_ = CurvePline(P1, P2, Bulge)
            If Bulge > 0 Then
                h = -1 * h
            End If
            Temp.Radius = CurveSegment_.Radius + h
            Temp.CP = CurveSegment_.CentrPoint
            Alfa = angle2Point(CurveSegment_.CentrPoint, P1)

            Temp.P1(0) = P1(0) + h * Cos(Alfa)
            Temp.P1(1) = P1(1) + h * Sin(Alfa)

            Alfa = angle2Point(CurveSegment_.CentrPoint, P2)
            Temp.P2(0) = P2(0) + h * Cos(Alfa)
            Temp.P2(1) = P2(1) + h * Sin(Alfa)

            Temp.Bulge = Bulge
        End If

        Return Temp
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function IntersectLineLine(ByVal Line1StartPoint() As Double, ByVal Line1EndPoint() As Double, ByVal Line2StartPoint() As Double, ByVal Line2EndPoint() As Double) As ReturnIntersectionPoint
        'Функция возвращает точку пересечения линии с линией
        Dim A1 As Double
        Dim B1 As Double
        Dim C1 As Double
        Dim A2 As Double
        Dim B2 As Double
        Dim C2 As Double
        Dim X As Double
        Dim Y As Double
        Dim B1B2 As Double = 1
        Dim A1A2 As Double = 1
        Dim C1C2 As Double = 1
        ' XA+YB+C=0
        A1 = Line1StartPoint(1) - Line1EndPoint(1)
        B1 = Line1EndPoint(0) - Line1StartPoint(0)
        C1 = Line1StartPoint(0) * Line1EndPoint(1) - Line1StartPoint(1) * Line1EndPoint(0)
        A2 = Line2StartPoint(1) - Line2EndPoint(1)
        B2 = Line2EndPoint(0) - Line2StartPoint(0)
        C2 = Line2StartPoint(0) * Line2EndPoint(1) - Line2StartPoint(1) * Line2EndPoint(0)
        If B2 <> 0 Then B1B2 = B1 / B2
        If A2 <> 0 Then A1A2 = A1 / A2
        If C2 <> 0 Then C1C2 = C1 / C2
        If A1A2 <> B1B2 Then
            If Abs(A1 * B2) > Abs(A2 * B1) Then
                X = (C2 * B1 - C1 * B2) / (B2 * A1 - A2 * B1)
                Y = (C1 * A2 - C2 * A1) / (A1 * B2 - B1 * A2)
            Else
                X = (C1 * B2 - C2 * B1) / (B1 * A2 - A1 * B2)
                Y = (C2 * A1 - C1 * A2) / (B1 * A2 - A1 * B2)
            End If
        Else
            IntersectLineLine.err = ReturnIntersectionPoint.errors.NoErr
            If C1C2 = A1A2 Then
                IntersectLineLine.err = ReturnIntersectionPoint.errors.Coincide  '"Линии совпадают"
            Else
                IntersectLineLine.err = ReturnIntersectionPoint.errors.Parallel  ' "Линии паралельны"
            End If
        End If
        If IntersectLineLine.err = ReturnIntersectionPoint.errors.NoErr Then
            IntersectLineLine.CountPoint = 1
            ReDim IntersectLineLine.X(0)
            ReDim IntersectLineLine.Y(0)
            IntersectLineLine.X(0) = X
            IntersectLineLine.Y(0) = Y
        Else
            IntersectLineLine.CountPoint = 0
        End If
        Return IntersectLineLine
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function PointBelongLine(ByVal StartPoint() As Double, ByVal EndPoint() As Double, ByVal CurentPoint() As Double) As Boolean
        ' функция проверяет принадлежит ли точкка отрезку
        Dim p1 As Double
        PointBelongLine = False
        If Abs(StartPoint(0) - EndPoint(0)) < Abs(StartPoint(1) - EndPoint(1)) Then
            p1 = Round((CurentPoint(1) - EndPoint(1)) / (StartPoint(1) - EndPoint(1)), 5)
        Else
            p1 = Round((CurentPoint(0) - EndPoint(0)) / (StartPoint(0) - EndPoint(0)), 5)
        End If
        If p1 >= 0 And p1 <= 1 Then
            PointBelongLine = True
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function angle3Point(ByVal StartPoint() As Double, ByVal CenterPoint() As Double, ByVal Endpoint() As Double) As Double
        'функция  возвращает угол между двумя векторами заданными 3 мя точками
        'angle3Point = atan2(OA.x * OB.y - OA.y * OB.x, OA.x * OB.x + OA.y * OB.y)
        Dim dY As Double = (CenterPoint(0) - StartPoint(0)) * (CenterPoint(1) - Endpoint(1)) - (CenterPoint(1) - StartPoint(1)) * (CenterPoint(0) - Endpoint(0))
        Dim dX As Double = (CenterPoint(0) - StartPoint(0)) * (CenterPoint(0) - Endpoint(0)) + (CenterPoint(1) - StartPoint(1)) * (CenterPoint(1) - Endpoint(1))
        angle3Point = Atan2(dY, dX)
    End Function

    Private Sub CncFilePathBtn_Click(sender As Object, e As EventArgs) Handles CncFilePathBtn.Click
        Dim FFD As New FileFolderDialog
        FFD.ShowDialog()
        CncFolderPath = FFD.SelectedPath & "\"
        ReNameCncFile(Nothing, Nothing)
    End Sub

    Private Sub DragImage_DragDrop(sender As Object, e As DragEventArgs) Handles DragImage.DragDrop
        Try
            Dim FileName As String = e.Data.GetData(DataFormats.FileDrop)(0)
            Dim Img As Bitmap = Image.FromFile(FileName)
            HeightImage = Img.Size.Height
            WidthImage = Img.Size.Width
            Img.Dispose()
            UpdateSizeImage()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UpdateSizeImage()
        Dim PixelSize As Double = ValidDouble(PixelSizeTxt.Text)
        Dim DeltaX As Double = ValidDouble(DeltaXTxt.Text)
        Dim DeltaY As Double = ValidDouble(DeltaYTxt.Text)
        PictureSizeLbl.Text = WidthImage & "x" & HeightImage
        RectWidthTxt.Text = WidthImage * PixelSize + DeltaX
        RectHeightTxt.Text = HeightImage * PixelSize + DeltaY
    End Sub

    Private Sub DragImage_DragEnter(sender As Object, e As DragEventArgs) Handles DragImage.DragEnter
        Try
            Dim Ext As String = LCase(Path.GetExtension(e.Data.GetData(DataFormats.FileDrop)(0)))
            If Ext = ".bmp" Or Ext = ".jpg" Or Ext = ".png" Or Ext = ".gif" Then
                e.Effect = DragDropEffects.Move
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RotateBtn_Click(sender As Object, e As EventArgs) Handles RotateBtn.Click
        If WidthImage > 0 And HeightImage > 0 Then
            Dim Temp As Integer = WidthImage
            WidthImage = HeightImage
            HeightImage = Temp
            UpdateSizeImage()
        End If
    End Sub

    Private Sub CutoutBtn_CheckedChanged(sender As Object, e As EventArgs) Handles CutOutBtn.CheckedChanged, PocketBtn.CheckedChanged
        If PocketBtn.Checked = True Then
            InExtCuttingCmbx.Visible = False
            PocketCuttingCmbx.Visible = True
            PocketCuttingCmbx_SelectedIndexChanged(Nothing, Nothing)
        Else
            InExtCuttingCmbx.Visible = True
            PocketCuttingCmbx.Visible = False
            CwCCwCmbx.Visible = True
            PocketCutoutBtn.Visible = False
        End If
        InitChange(Nothing, Nothing)
    End Sub

    Private Sub PocketCuttingCmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PocketCuttingCmbx.SelectedIndexChanged
        If PocketCuttingCmbx.SelectedIndex = 0 Then
            PocketCutoutBtn.Visible = False
            CwCCwCmbx.Visible = True
            'TopLeft.Visible = False
            'TopRight.Visible = False
            'DownRight.Visible = False
            'DownLeft.Visible = False
        ElseIf PocketCuttingCmbx.SelectedIndex = 1 Or PocketCuttingCmbx.SelectedIndex = 2 Then
            PocketCutoutBtn.Visible = True
            CwCCwCmbx.Visible = False
            'TopLeft.Visible = True
            'TopRight.Visible = True
            'DownRight.Visible = True
            'DownLeft.Visible = True
        End If
        InitChange(Nothing, Nothing)
    End Sub

    Private Sub SafetyHeightTxt_TextChanged(sender As Object, e As EventArgs) Handles SafetyHeightTxt.TextChanged, ThicknessTxt.TextChanged
        If StartZTopBtn.Checked = True Then
            SafetyLevelTxt.Text = SafetyHeightTxt.Text
        Else
            Try
                SafetyLevelTxt.Text = ValidDouble(SafetyHeightTxt.Text) + ValidDouble(ThicknessTxt.Text)
            Catch ex As Exception
                SafetyLevelTxt.Text = ""
            End Try
        End If
    End Sub

    Private Sub StartZDownBtn_CheckedChanged(sender As Object, e As EventArgs) Handles StartZDownBtn.CheckedChanged
        SafetyHeightTxt_TextChanged(Nothing, Nothing)
    End Sub
End Class
