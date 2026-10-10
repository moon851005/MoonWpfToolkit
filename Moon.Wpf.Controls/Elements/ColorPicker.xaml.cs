using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Moon.Wpf.Controls.Elements
{
    public enum ColorInputMode { Hex, Argb, Hsl }

    [TemplatePart(Name = PART_ToggleButton,      Type = typeof(ToggleButton))]
    [TemplatePart(Name = PART_SwatchRect,        Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_HexDisplay,        Type = typeof(TextBlock))]
    [TemplatePart(Name = PART_SvPanel,           Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PART_HueGradientRect,   Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_SvThumb,           Type = typeof(Ellipse))]
    [TemplatePart(Name = PART_HueSlider,         Type = typeof(Slider))]
    [TemplatePart(Name = PART_AlphaSlider,       Type = typeof(Slider))]
    [TemplatePart(Name = PART_AlphaRow,          Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PART_AlphaGradientRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_ModeButton,        Type = typeof(Button))]
    [TemplatePart(Name = PART_HexSliders,        Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PART_HexRSlider,        Type = typeof(Slider))]
    [TemplatePart(Name = PART_HexGSlider,        Type = typeof(Slider))]
    [TemplatePart(Name = PART_HexBSlider,        Type = typeof(Slider))]
    [TemplatePart(Name = PART_HexRTextBox,       Type = typeof(TextBox))]
    [TemplatePart(Name = PART_HexGTextBox,       Type = typeof(TextBox))]
    [TemplatePart(Name = PART_HexBTextBox,       Type = typeof(TextBox))]
    [TemplatePart(Name = PART_HexTextBox,        Type = typeof(TextBox))]
    [TemplatePart(Name = PART_ArgbRow,           Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PART_ASlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_RSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_GSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_BSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_ATextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_RTextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_GTextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_BTextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_HslRow,            Type = typeof(FrameworkElement))]
    [TemplatePart(Name = PART_HSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_SSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_LSlider,           Type = typeof(Slider))]
    [TemplatePart(Name = PART_HTextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_SHTextBox,         Type = typeof(TextBox))]
    [TemplatePart(Name = PART_LTextBox,          Type = typeof(TextBox))]
    [TemplatePart(Name = PART_PreviewRect,       Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_Popup,             Type = typeof(Popup))]
    public class ColorPicker : Control
    {
        #region 初始化
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }
        #endregion

        #region 常數
        private const string PART_ToggleButton      = "PART_ToggleButton";
        private const string PART_SwatchRect        = "PART_SwatchRect";
        private const string PART_HexDisplay        = "PART_HexDisplay";
        private const string PART_SvPanel           = "PART_SvPanel";
        private const string PART_HueGradientRect   = "PART_HueGradientRect";
        private const string PART_SvThumb           = "PART_SvThumb";
        private const string PART_HueSlider         = "PART_HueSlider";
        private const string PART_AlphaSlider       = "PART_AlphaSlider";
        private const string PART_AlphaRow          = "PART_AlphaRow";
        private const string PART_AlphaGradientRect = "PART_AlphaGradientRect";
        private const string PART_ModeButton        = "PART_ModeButton";
        private const string PART_HexSliders        = "PART_HexSliders";
        private const string PART_HexRSlider        = "PART_HexRSlider";
        private const string PART_HexGSlider        = "PART_HexGSlider";
        private const string PART_HexBSlider        = "PART_HexBSlider";
        private const string PART_HexRTextBox       = "PART_HexRTextBox";
        private const string PART_HexGTextBox       = "PART_HexGTextBox";
        private const string PART_HexBTextBox       = "PART_HexBTextBox";
        private const string PART_HexTextBox        = "PART_HexTextBox";
        private const string PART_ArgbRow           = "PART_ArgbRow";
        private const string PART_ASlider           = "PART_ASlider";
        private const string PART_RSlider           = "PART_RSlider";
        private const string PART_GSlider           = "PART_GSlider";
        private const string PART_BSlider           = "PART_BSlider";
        private const string PART_ATextBox          = "PART_ATextBox";
        private const string PART_RTextBox          = "PART_RTextBox";
        private const string PART_GTextBox          = "PART_GTextBox";
        private const string PART_BTextBox          = "PART_BTextBox";
        private const string PART_HslRow            = "PART_HslRow";
        private const string PART_HSlider           = "PART_HSlider";
        private const string PART_SSlider           = "PART_SSlider";
        private const string PART_LSlider           = "PART_LSlider";
        private const string PART_HTextBox          = "PART_HTextBox";
        private const string PART_SHTextBox         = "PART_SHTextBox";
        private const string PART_LTextBox          = "PART_LTextBox";
        private const string PART_PreviewRect       = "PART_PreviewRect";
        private const string PART_Popup             = "PART_Popup";
        private const double ThumbRadius            = 7.0;
        #endregion

        #region 依賴屬性
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(
                nameof(SelectedColor),
                typeof(Color),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    Colors.Red,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnSelectedColorChanged));

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public static readonly DependencyProperty ShowAlphaSliderProperty =
            DependencyProperty.Register(
                nameof(ShowAlphaSlider),
                typeof(bool),
                typeof(ColorPicker),
                new PropertyMetadata(false, OnShowAlphaSliderChanged));

        public bool ShowAlphaSlider
        {
            get => (bool)GetValue(ShowAlphaSliderProperty);
            set => SetValue(ShowAlphaSliderProperty, value);
        }

        public static readonly DependencyProperty InputModeProperty =
            DependencyProperty.Register(
                nameof(InputMode),
                typeof(ColorInputMode),
                typeof(ColorPicker),
                new PropertyMetadata(ColorInputMode.Hex, OnInputModeChanged));

        public ColorInputMode InputMode
        {
            get => (ColorInputMode)GetValue(InputModeProperty);
            set => SetValue(InputModeProperty, value);
        }

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (ColorPicker)d;
            if (picker._isUpdating) return;
            picker.SyncFromSelectedColor();
        }

        private static void OnShowAlphaSliderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((ColorPicker)d).RefreshAlphaVisibility();

        private static void OnInputModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = (ColorPicker)d;
            picker.RefreshInputVisibility();
            picker.UpdateAllVisuals();
        }
        #endregion

        #region 私有欄位
        private ToggleButton?     _toggleButton;
        private Rectangle?        _swatchRect;
        private TextBlock?        _hexDisplay;
        private FrameworkElement? _svPanel;
        private Rectangle?        _hueGradientRect;
        private Ellipse?          _svThumb;
        private Slider?           _hueSlider;
        private Slider?           _alphaSlider;
        private FrameworkElement? _alphaRow;
        private Rectangle?        _alphaGradientRect;
        private Button?           _modeButton;
        // HEX 模式
        private FrameworkElement? _hexSliders;
        private Slider?           _hexRSlider;
        private Slider?           _hexGSlider;
        private Slider?           _hexBSlider;
        private TextBox?          _hexRTextBox;
        private TextBox?          _hexGTextBox;
        private TextBox?          _hexBTextBox;
        private TextBox?          _hexTextBox;
        // ARGB 模式
        private FrameworkElement? _argbRow;
        private Slider?           _aSlider;
        private Slider?           _rSlider;
        private Slider?           _gSlider;
        private Slider?           _bSlider;
        private TextBox?          _aTextBox;
        private TextBox?          _rTextBox;
        private TextBox?          _gTextBox;
        private TextBox?          _bTextBox;
        // HSL 模式
        private FrameworkElement? _hslRow;
        private Slider?           _hSlider;
        private Slider?           _sSlider;
        private Slider?           _lSlider;
        private TextBox?          _hTextBox;
        private TextBox?          _shTextBox;
        private TextBox?          _lTextBox;
        // 共用
        private Rectangle?        _previewRect;
        private Popup?            _popup;

        private GradientStop? _hueColorStop;
        private GradientStop? _alphaColorStop;
        private readonly SolidColorBrush _previewBrush = new(Colors.Red);

        private double _hue;
        private double _saturation = 1.0;
        private double _value      = 1.0;
        private double _alpha      = 1.0;

        private bool _isUpdating;
        private bool _isDragging;
        #endregion

        #region 樣板套用
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DetachEvents();

            _toggleButton      = GetTemplateChild(PART_ToggleButton)      as ToggleButton;
            _swatchRect        = GetTemplateChild(PART_SwatchRect)        as Rectangle;
            _hexDisplay        = GetTemplateChild(PART_HexDisplay)        as TextBlock;
            _svPanel           = GetTemplateChild(PART_SvPanel)           as FrameworkElement;
            _hueGradientRect   = GetTemplateChild(PART_HueGradientRect)   as Rectangle;
            _svThumb           = GetTemplateChild(PART_SvThumb)           as Ellipse;
            _hueSlider         = GetTemplateChild(PART_HueSlider)         as Slider;
            _alphaSlider       = GetTemplateChild(PART_AlphaSlider)       as Slider;
            _alphaRow          = GetTemplateChild(PART_AlphaRow)          as FrameworkElement;
            _alphaGradientRect = GetTemplateChild(PART_AlphaGradientRect) as Rectangle;
            _modeButton        = GetTemplateChild(PART_ModeButton)        as Button;
            _hexSliders        = GetTemplateChild(PART_HexSliders)        as FrameworkElement;
            _hexRSlider        = GetTemplateChild(PART_HexRSlider)        as Slider;
            _hexGSlider        = GetTemplateChild(PART_HexGSlider)        as Slider;
            _hexBSlider        = GetTemplateChild(PART_HexBSlider)        as Slider;
            _hexRTextBox       = GetTemplateChild(PART_HexRTextBox)       as TextBox;
            _hexGTextBox       = GetTemplateChild(PART_HexGTextBox)       as TextBox;
            _hexBTextBox       = GetTemplateChild(PART_HexBTextBox)       as TextBox;
            _hexTextBox        = GetTemplateChild(PART_HexTextBox)        as TextBox;
            _argbRow           = GetTemplateChild(PART_ArgbRow)           as FrameworkElement;
            _aSlider           = GetTemplateChild(PART_ASlider)           as Slider;
            _rSlider           = GetTemplateChild(PART_RSlider)           as Slider;
            _gSlider           = GetTemplateChild(PART_GSlider)           as Slider;
            _bSlider           = GetTemplateChild(PART_BSlider)           as Slider;
            _aTextBox          = GetTemplateChild(PART_ATextBox)          as TextBox;
            _rTextBox          = GetTemplateChild(PART_RTextBox)          as TextBox;
            _gTextBox          = GetTemplateChild(PART_GTextBox)          as TextBox;
            _bTextBox          = GetTemplateChild(PART_BTextBox)          as TextBox;
            _hslRow            = GetTemplateChild(PART_HslRow)            as FrameworkElement;
            _hSlider           = GetTemplateChild(PART_HSlider)           as Slider;
            _sSlider           = GetTemplateChild(PART_SSlider)           as Slider;
            _lSlider           = GetTemplateChild(PART_LSlider)           as Slider;
            _hTextBox          = GetTemplateChild(PART_HTextBox)          as TextBox;
            _shTextBox         = GetTemplateChild(PART_SHTextBox)         as TextBox;
            _lTextBox          = GetTemplateChild(PART_LTextBox)          as TextBox;
            _previewRect       = GetTemplateChild(PART_PreviewRect)       as Rectangle;
            _popup             = GetTemplateChild(PART_Popup)             as Popup;

            BuildHueGradient();
            BuildAlphaGradient();

            if (_previewRect != null) _previewRect.Fill = _previewBrush;
            if (_swatchRect  != null) _swatchRect.Fill  = _previewBrush;
            if (_popup       != null) _popup.Closed    += Popup_Closed;

            RefreshAlphaVisibility();
            RefreshInputVisibility();
            AttachEvents();
            SyncFromSelectedColor();
        }

        private void BuildHueGradient()
        {
            if (_hueGradientRect == null) return;
            var brush = new LinearGradientBrush { StartPoint = new Point(0, 0), EndPoint = new Point(1, 0) };
            brush.GradientStops.Add(new GradientStop(Colors.White, 0));
            _hueColorStop = new GradientStop(Colors.Red, 1.0);
            brush.GradientStops.Add(_hueColorStop);
            _hueGradientRect.Fill = brush;
        }

        private void BuildAlphaGradient()
        {
            if (_alphaGradientRect == null) return;
            var brush = new LinearGradientBrush { StartPoint = new Point(0, 0), EndPoint = new Point(1, 0) };
            brush.GradientStops.Add(new GradientStop(Colors.Transparent, 0));
            _alphaColorStop = new GradientStop(Colors.Red, 1.0);
            brush.GradientStops.Add(_alphaColorStop);
            _alphaGradientRect.Fill = brush;
        }

        private void DetachEvents()
        {
            if (_svPanel     != null) { _svPanel.PreviewMouseDown -= SvPanel_MouseDown; _svPanel.PreviewMouseMove -= SvPanel_MouseMove; _svPanel.MouseUp -= SvPanel_MouseUp; _svPanel.SizeChanged -= SvPanel_SizeChanged; }
            if (_hueSlider   != null) _hueSlider.ValueChanged   -= HueSlider_ValueChanged;
            if (_alphaSlider != null) _alphaSlider.ValueChanged -= AlphaSlider_ValueChanged;
            if (_modeButton  != null) _modeButton.Click         -= ModeButton_Click;
            // HEX sliders
            if (_hexRSlider  != null) _hexRSlider.ValueChanged  -= HexRgbSlider_ValueChanged;
            if (_hexGSlider  != null) _hexGSlider.ValueChanged  -= HexRgbSlider_ValueChanged;
            if (_hexBSlider  != null) _hexBSlider.ValueChanged  -= HexRgbSlider_ValueChanged;
            if (_hexRTextBox != null) _hexRTextBox.LostFocus    -= HexRgbBox_LostFocus;
            if (_hexGTextBox != null) _hexGTextBox.LostFocus    -= HexRgbBox_LostFocus;
            if (_hexBTextBox != null) _hexBTextBox.LostFocus    -= HexRgbBox_LostFocus;
            if (_hexTextBox  != null) { _hexTextBox.LostFocus   -= HexBox_LostFocus; _hexTextBox.KeyDown -= HexBox_KeyDown; }
            // ARGB sliders + boxes
            if (_aSlider     != null) _aSlider.ValueChanged     -= ArgbSlider_ValueChanged;
            if (_rSlider     != null) _rSlider.ValueChanged     -= ArgbSlider_ValueChanged;
            if (_gSlider     != null) _gSlider.ValueChanged     -= ArgbSlider_ValueChanged;
            if (_bSlider     != null) _bSlider.ValueChanged     -= ArgbSlider_ValueChanged;
            if (_aTextBox    != null) _aTextBox.LostFocus       -= ArgbBox_LostFocus;
            if (_rTextBox    != null) _rTextBox.LostFocus       -= ArgbBox_LostFocus;
            if (_gTextBox    != null) _gTextBox.LostFocus       -= ArgbBox_LostFocus;
            if (_bTextBox    != null) _bTextBox.LostFocus       -= ArgbBox_LostFocus;
            // HSL sliders + boxes
            if (_hSlider     != null) _hSlider.ValueChanged     -= HslSlider_ValueChanged;
            if (_sSlider     != null) _sSlider.ValueChanged     -= HslSlider_ValueChanged;
            if (_lSlider     != null) _lSlider.ValueChanged     -= HslSlider_ValueChanged;
            if (_hTextBox    != null) _hTextBox.LostFocus       -= HslBox_LostFocus;
            if (_shTextBox   != null) _shTextBox.LostFocus      -= HslBox_LostFocus;
            if (_lTextBox    != null) _lTextBox.LostFocus       -= HslBox_LostFocus;
            if (_popup       != null) _popup.Closed             -= Popup_Closed;
        }

        private void AttachEvents()
        {
            if (_svPanel     != null) { _svPanel.PreviewMouseDown += SvPanel_MouseDown; _svPanel.PreviewMouseMove += SvPanel_MouseMove; _svPanel.MouseUp += SvPanel_MouseUp; _svPanel.SizeChanged += SvPanel_SizeChanged; }
            if (_hueSlider   != null) _hueSlider.ValueChanged   += HueSlider_ValueChanged;
            if (_alphaSlider != null) _alphaSlider.ValueChanged += AlphaSlider_ValueChanged;
            if (_modeButton  != null) _modeButton.Click         += ModeButton_Click;
            // HEX sliders
            if (_hexRSlider  != null) _hexRSlider.ValueChanged  += HexRgbSlider_ValueChanged;
            if (_hexGSlider  != null) _hexGSlider.ValueChanged  += HexRgbSlider_ValueChanged;
            if (_hexBSlider  != null) _hexBSlider.ValueChanged  += HexRgbSlider_ValueChanged;
            if (_hexRTextBox != null) _hexRTextBox.LostFocus    += HexRgbBox_LostFocus;
            if (_hexGTextBox != null) _hexGTextBox.LostFocus    += HexRgbBox_LostFocus;
            if (_hexBTextBox != null) _hexBTextBox.LostFocus    += HexRgbBox_LostFocus;
            if (_hexTextBox  != null) { _hexTextBox.LostFocus   += HexBox_LostFocus; _hexTextBox.KeyDown += HexBox_KeyDown; }
            // ARGB sliders + boxes
            if (_aSlider     != null) _aSlider.ValueChanged     += ArgbSlider_ValueChanged;
            if (_rSlider     != null) _rSlider.ValueChanged     += ArgbSlider_ValueChanged;
            if (_gSlider     != null) _gSlider.ValueChanged     += ArgbSlider_ValueChanged;
            if (_bSlider     != null) _bSlider.ValueChanged     += ArgbSlider_ValueChanged;
            if (_aTextBox    != null) _aTextBox.LostFocus       += ArgbBox_LostFocus;
            if (_rTextBox    != null) _rTextBox.LostFocus       += ArgbBox_LostFocus;
            if (_gTextBox    != null) _gTextBox.LostFocus       += ArgbBox_LostFocus;
            if (_bTextBox    != null) _bTextBox.LostFocus       += ArgbBox_LostFocus;
            // HSL sliders + boxes
            if (_hSlider     != null) _hSlider.ValueChanged     += HslSlider_ValueChanged;
            if (_sSlider     != null) _sSlider.ValueChanged     += HslSlider_ValueChanged;
            if (_lSlider     != null) _lSlider.ValueChanged     += HslSlider_ValueChanged;
            if (_hTextBox    != null) _hTextBox.LostFocus       += HslBox_LostFocus;
            if (_shTextBox   != null) _shTextBox.LostFocus      += HslBox_LostFocus;
            if (_lTextBox    != null) _lTextBox.LostFocus       += HslBox_LostFocus;
        }
        #endregion

        #region 事件處理
        private void SvPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            _isDragging = true;
            _svPanel!.CaptureMouse();
            UpdateSvFromPoint(e.GetPosition(_svPanel));
            e.Handled = true;
        }

        private void SvPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || e.LeftButton != MouseButtonState.Pressed) return;
            UpdateSvFromPoint(e.GetPosition(_svPanel!));
        }

        private void SvPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            _svPanel!.ReleaseMouseCapture();
        }

        private void SvPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!_isUpdating) UpdateAllVisuals();
        }

        private void HueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdating) return;
            _hue = e.NewValue;
            SyncFromHsv();
        }

        private void AlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdating) return;
            _alpha = e.NewValue / 255.0;
            SyncFromHsv();
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            InputMode = InputMode switch
            {
                ColorInputMode.Hex  => ColorInputMode.Argb,
                ColorInputMode.Argb => ColorInputMode.Hsl,
                _                   => ColorInputMode.Hex
            };
        }

        private void HexRgbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdating) return;
            byte r = Clamp255(_hexRSlider?.Value ?? SelectedColor.R);
            byte g = Clamp255(_hexGSlider?.Value ?? SelectedColor.G);
            byte b = Clamp255(_hexBSlider?.Value ?? SelectedColor.B);
            RgbToHsv(r, g, b, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }

        private void HexRgbBox_LostFocus(object sender, RoutedEventArgs e)
        {
            byte r = SelectedColor.R, g = SelectedColor.G, b = SelectedColor.B;
            if (_hexRTextBox != null) byte.TryParse(_hexRTextBox.Text, out r);
            if (_hexGTextBox != null) byte.TryParse(_hexGTextBox.Text, out g);
            if (_hexBTextBox != null) byte.TryParse(_hexBTextBox.Text, out b);
            RgbToHsv(r, g, b, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }

        private void HexBox_LostFocus(object sender, RoutedEventArgs e) => ParseHex();

        private void HexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ParseHex();
        }

        private void ArgbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdating) return;
            _alpha = (_aSlider?.Value ?? _alpha * 255) / 255.0;
            byte r = Clamp255(_rSlider?.Value ?? SelectedColor.R);
            byte g = Clamp255(_gSlider?.Value ?? SelectedColor.G);
            byte b = Clamp255(_bSlider?.Value ?? SelectedColor.B);
            RgbToHsv(r, g, b, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }

        private void ArgbBox_LostFocus(object sender, RoutedEventArgs e) => ParseArgb();

        private void HslSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdating) return;
            double h = _hSlider?.Value ?? _hue;
            double s = (_sSlider?.Value ?? 0) / 100.0;
            double l = (_lSlider?.Value ?? 0) / 100.0;
            HslToHsv(h, s, l, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }

        private void HslBox_LostFocus(object sender, RoutedEventArgs e) => ParseHsl();

        private void Popup_Closed(object? sender, EventArgs e)
        {
            if (_toggleButton != null) _toggleButton.IsChecked = false;
        }

        private static byte Clamp255(double v) => (byte)Math.Clamp(Math.Round(v), 0, 255);
        #endregion

        #region 同步方法
        private void SyncFromSelectedColor()
        {
            _isUpdating = true;
            try
            {
                var c = SelectedColor;
                _alpha = c.A / 255.0;
                RgbToHsv(c.R, c.G, c.B, out _hue, out _saturation, out _value);
                UpdateAllVisuals();
            }
            finally { _isUpdating = false; }
        }

        private void SyncFromHsv()
        {
            _isUpdating = true;
            try
            {
                var c = HsvToColor(_hue, _saturation, _value, _alpha);
                SetValue(SelectedColorProperty, c);
                UpdateAllVisuals();
            }
            finally { _isUpdating = false; }
        }

        private void UpdateSvFromPoint(Point p)
        {
            var w = _svPanel!.ActualWidth;
            var h = _svPanel.ActualHeight;
            if (w <= 0 || h <= 0) return;
            _saturation = Math.Clamp(p.X / w, 0.0, 1.0);
            _value      = Math.Clamp(1.0 - p.Y / h, 0.0, 1.0);
            SyncFromHsv();
        }

        private void UpdateAllVisuals()
        {
            var pureHue     = HsvToColor(_hue, 1.0, 1.0, 1.0);
            var opaqueColor = HsvToColor(_hue, _saturation, _value, 1.0);
            var fullColor   = HsvToColor(_hue, _saturation, _value, _alpha);

            if (_hueColorStop   != null) _hueColorStop.Color   = pureHue;
            if (_alphaColorStop != null) _alphaColorStop.Color = opaqueColor;
            _previewBrush.Color = fullColor;

            if (_svPanel != null && _svThumb != null)
            {
                var w = _svPanel.ActualWidth;
                var h = _svPanel.ActualHeight;
                _svThumb.Margin = new Thickness(
                    _saturation * w - ThumbRadius,
                    (1.0 - _value) * h - ThumbRadius,
                    0, 0);
            }

            if (_hueSlider   != null) _hueSlider.Value  = _hue;
            if (_alphaSlider != null) _alphaSlider.Value = _alpha * 255.0;

            // HEX display (button area)
            var hexText = ShowAlphaSlider
                ? $"#{(byte)(_alpha * 255):X2}{fullColor.R:X2}{fullColor.G:X2}{fullColor.B:X2}"
                : $"#{fullColor.R:X2}{fullColor.G:X2}{fullColor.B:X2}";
            if (_hexDisplay != null) _hexDisplay.Text = hexText;
            if (_hexTextBox != null) _hexTextBox.Text = hexText;

            // HEX mode sliders + boxes
            if (_hexRSlider  != null) _hexRSlider.Value  = fullColor.R;
            if (_hexGSlider  != null) _hexGSlider.Value  = fullColor.G;
            if (_hexBSlider  != null) _hexBSlider.Value  = fullColor.B;
            if (_hexRTextBox != null) _hexRTextBox.Text  = fullColor.R.ToString();
            if (_hexGTextBox != null) _hexGTextBox.Text  = fullColor.G.ToString();
            if (_hexBTextBox != null) _hexBTextBox.Text  = fullColor.B.ToString();

            // ARGB mode sliders + boxes
            if (_aSlider  != null) _aSlider.Value = _alpha * 255.0;
            if (_rSlider  != null) _rSlider.Value = fullColor.R;
            if (_gSlider  != null) _gSlider.Value = fullColor.G;
            if (_bSlider  != null) _bSlider.Value = fullColor.B;
            if (_aTextBox != null) _aTextBox.Text = ((byte)(_alpha * 255)).ToString();
            if (_rTextBox != null) _rTextBox.Text = fullColor.R.ToString();
            if (_gTextBox != null) _gTextBox.Text = fullColor.G.ToString();
            if (_bTextBox != null) _bTextBox.Text = fullColor.B.ToString();

            // HSL mode sliders + boxes
            HsvToHsl(_hue, _saturation, _value, out var hslH, out var hslS, out var hslL);
            if (_hSlider  != null) _hSlider.Value  = hslH;
            if (_sSlider  != null) _sSlider.Value  = hslS * 100.0;
            if (_lSlider  != null) _lSlider.Value  = hslL * 100.0;
            if (_hTextBox  != null) _hTextBox.Text  = Math.Round(hslH).ToString();
            if (_shTextBox != null) _shTextBox.Text = Math.Round(hslS * 100).ToString();
            if (_lTextBox  != null) _lTextBox.Text  = Math.Round(hslL * 100).ToString();
        }

        private void RefreshAlphaVisibility()
        {
            if (_alphaRow == null) return;
            _alphaRow.Visibility = ShowAlphaSlider ? Visibility.Visible : Visibility.Collapsed;
        }

        private void RefreshInputVisibility()
        {
            if (_hexSliders != null) _hexSliders.Visibility = InputMode == ColorInputMode.Hex  ? Visibility.Visible : Visibility.Collapsed;
            if (_argbRow    != null) _argbRow.Visibility    = InputMode == ColorInputMode.Argb ? Visibility.Visible : Visibility.Collapsed;
            if (_hslRow     != null) _hslRow.Visibility     = InputMode == ColorInputMode.Hsl  ? Visibility.Visible : Visibility.Collapsed;

            if (_modeButton != null)
                _modeButton.Content = InputMode switch
                {
                    ColorInputMode.Hex  => "HEX",
                    ColorInputMode.Argb => "ARGB",
                    _                   => "HSL"
                };
        }
        #endregion

        #region 文字解析
        private void ParseHex()
        {
            if (_hexTextBox == null) return;
            var text = _hexTextBox.Text.TrimStart('#');
            try
            {
                Color c = text.Length switch
                {
                    6 => Color.FromRgb(
                            Convert.ToByte(text[0..2], 16),
                            Convert.ToByte(text[2..4], 16),
                            Convert.ToByte(text[4..6], 16)),
                    8 => Color.FromArgb(
                            Convert.ToByte(text[0..2], 16),
                            Convert.ToByte(text[2..4], 16),
                            Convert.ToByte(text[4..6], 16),
                            Convert.ToByte(text[6..8], 16)),
                    _ => SelectedColor
                };
                _alpha = c.A / 255.0;
                RgbToHsv(c.R, c.G, c.B, out _hue, out _saturation, out _value);
                SyncFromHsv();
            }
            catch { /* 無效輸入，忽略 */ }
        }

        private void ParseArgb()
        {
            byte a = (byte)(_alpha * 255);
            byte r = SelectedColor.R, g = SelectedColor.G, b = SelectedColor.B;
            if (_aTextBox != null) byte.TryParse(_aTextBox.Text, out a);
            if (_rTextBox != null) byte.TryParse(_rTextBox.Text, out r);
            if (_gTextBox != null) byte.TryParse(_gTextBox.Text, out g);
            if (_bTextBox != null) byte.TryParse(_bTextBox.Text, out b);
            _alpha = a / 255.0;
            RgbToHsv(r, g, b, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }

        private void ParseHsl()
        {
            HsvToHsl(_hue, _saturation, _value, out var curH, out var curS, out var curL);
            double h = curH, s = curS, l = curL;
            if (_hTextBox  != null && double.TryParse(_hTextBox.Text,  out var ph)) h = Math.Clamp(ph, 0, 360);
            if (_shTextBox != null && double.TryParse(_shTextBox.Text, out var ps)) s = Math.Clamp(ps / 100.0, 0, 1);
            if (_lTextBox  != null && double.TryParse(_lTextBox.Text,  out var pl)) l = Math.Clamp(pl / 100.0, 0, 1);
            HslToHsv(h, s, l, out _hue, out _saturation, out _value);
            SyncFromHsv();
        }
        #endregion

        #region HSV ↔ RGB / HSL 轉換
        private static void RgbToHsv(byte r, byte g, byte b, out double h, out double s, out double v)
        {
            double rd = r / 255.0, gd = g / 255.0, bd = b / 255.0;
            double max   = Math.Max(rd, Math.Max(gd, bd));
            double min   = Math.Min(rd, Math.Min(gd, bd));
            double delta = max - min;

            v = max;
            s = max == 0 ? 0 : delta / max;

            if (delta == 0) { h = 0; return; }

            if      (max == rd) h = 60.0 * ((gd - bd) / delta % 6);
            else if (max == gd) h = 60.0 * ((bd - rd) / delta + 2);
            else                h = 60.0 * ((rd - gd) / delta + 4);

            if (h < 0) h += 360.0;
        }

        private static Color HsvToColor(double h, double s, double v, double a)
        {
            byte alpha = (byte)Math.Clamp(a * 255, 0, 255);

            if (s == 0)
            {
                var grey = (byte)Math.Clamp(v * 255, 0, 255);
                return Color.FromArgb(alpha, grey, grey, grey);
            }

            double sector = h / 60.0;
            int    i      = (int)Math.Floor(sector) % 6;
            double f      = sector - Math.Floor(sector);
            double p = v * (1 - s);
            double q = v * (1 - f * s);
            double t = v * (1 - (1 - f) * s);

            var (r, g, b) = i switch
            {
                0 => (v, t, p),
                1 => (q, v, p),
                2 => (p, v, t),
                3 => (p, q, v),
                4 => (t, p, v),
                _ => (v, p, q)
            };

            return Color.FromArgb(
                alpha,
                (byte)Math.Clamp(r * 255, 0, 255),
                (byte)Math.Clamp(g * 255, 0, 255),
                (byte)Math.Clamp(b * 255, 0, 255));
        }

        private static void HsvToHsl(double h, double s, double v, out double hslH, out double hslS, out double hslL)
        {
            hslH = h;
            hslL = v * (2.0 - s) / 2.0;
            double denom = 1.0 - Math.Abs(2.0 * hslL - 1.0);
            hslS = denom < 1e-10 ? 0 : v * s / denom;
        }

        private static void HslToHsv(double h, double s, double l, out double hsvH, out double hsvS, out double hsvV)
        {
            hsvH = h;
            double vMax = l + s * Math.Min(l, 1.0 - l);
            hsvV = vMax;
            hsvS = vMax < 1e-10 ? 0 : 2.0 * (1.0 - l / vMax);
        }
        #endregion
    }
}
