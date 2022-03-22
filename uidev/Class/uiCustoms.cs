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
        public static event PropertyChangedEvent PropertyChanged;

        private static Color _backColor = Color.FromArgb(30, 30, 30);
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

        private static Color _enterColor = Color.FromArgb(50, 50, 50);
        public static Color EnterColor
        {
            get
            {
                return _enterColor;
            }
            set
            {
                _enterColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Color _selectColor = Color.FromArgb(70, 70, 70);
        public static Color SelectColor
        {
            get
            {
                return _selectColor;
            }
            set
            {
                _selectColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Color _darkColor = Color.FromArgb(24, 24, 24);
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
        
        private static Color _mainColor = Color.SlateBlue;
        public static Color MainColor
        {
            get
            {
                return _mainColor;
            }
            set
            {
                _mainColor = value;
                PropertyChanged?.Invoke(null, new EventArgs()) ;
            }
        }

        private static Color _mainEnterColor = Color.FromArgb(170, 160, 226);
        public static Color MainEnterColor
        {
            get
            {
                return _mainEnterColor;
            }
            set
            {
                _mainEnterColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Color _mainClickColor = Color.GhostWhite;
        public static Color MainClickColor
        {
            get
            {
                return _mainClickColor;
            }
            set
            {
                _mainClickColor = value;
                PropertyChanged?.Invoke(null, new EventArgs());
            }
        }

        private static Color _dashColor = Color.SlateBlue;
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
