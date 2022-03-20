using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uidev.Class
{
    public static class uiCustoms
    {

        public delegate void PropertyChangedEvent(object sender, EventArgs e);
        [Category("uiControl")]
        [Description("uiControl独自のプロパティが変更された場合に発生します。")]
        public static event PropertyChangedEvent PropertyChanged;

        private static Color _backColor = Color.FromArgb(30, 30, 30);
        [Category("色")]
        [Description("背景の色を設定します。")]
        public static Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Color _darkColor = Color.FromArgb(24, 24, 24);
        [Category("色")]
        [Description("暗めの色を設定します。")]
        public static Color DarkColor
        {
            get
            {
                return _darkColor;
            }
            set
            {
                _darkColor = value;
                PropertyChanged?.Invoke(null, new EventArgs()) ;
            }
        }

        private static Color _dashColor = Color.DimGray;
        [Category("色")]
        [Description("縁枠の色を設定します。")]
        public static Color DashColor
        {
            get
            {
                return _dashColor;
            }
            set
            {
                _dashColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }
        private static Pen _borderPen = new Pen(Class.uiCustoms.DashColor);
        public static Pen BorderPen
        {
            get
            {
                _borderPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                return _borderPen;
            }
            set
            {
                _borderPen = value;
            }
        }

        private static Color _clickColor = Color.LightGray;
        [Category("色")]
        [Description("コントロールがクリックされたときの色を設定します。")]
        public static Color ClickColor
        {
            get
            {
                return _clickColor;
            }
            set
            {
                _clickColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Font _font = new Font(
            "Yu Gothic UI",
            9F,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point,
            ((byte)(128))
            );
        [Category("フォント")]
        [Description("コントロールのフォントを設定します。")]
        public static Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static float _penWidth = 1F;
        [Category("グラフィック")]
        [Description("線の太さを設定します。")]
        public static float PenWidth
        {
            get
            {
                return _penWidth;
            }
            set
            {
                _penWidth = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static SmoothingMode _smoothingMode = SmoothingMode.HighSpeed;
        [Category("グラフィック")]
        [Description("グラフィック描画のアンチエイリアス処理設定を行います。")]
        public static SmoothingMode SmoothingMode
        {
            get
            {
                return _smoothingMode;
            }
            set
            {
                _smoothingMode = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }
    }
}
