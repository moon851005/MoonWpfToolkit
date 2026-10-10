using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Moon.Wpf.Controls.Elements
{
    public class FontIcon : System.Windows.Controls.Control
    {
        #region 依賴屬性
        //新增屬性Glyph，型別同string
        public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
            nameof(Glyph),
            typeof(string),
            typeof(FontIcon),
            new PropertyMetadata(default(string))
        );
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        //新增屬性IsFilled，型別同bool
        public static readonly DependencyProperty IsFilledProperty = DependencyProperty.Register(
            nameof(IsFilled),
            typeof(bool),
            typeof(FontIcon),
            new PropertyMetadata(true)
        );
        public bool IsFilled
        {
            get { return (bool)GetValue(IsFilledProperty); }
            set { SetValue(IsFilledProperty, value); }
        }

        //新增屬性CornerRadius，型別同CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(FontIcon),
            new PropertyMetadata(default(CornerRadius))
        );
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion
    }
}
