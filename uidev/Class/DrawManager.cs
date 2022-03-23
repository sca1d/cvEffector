using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using uidev.Class;
using uidev.Controls;
using uidev.Interface;

namespace uidev.Class
{
    public static class DrawManager
    {

        public static TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

        public static void DrawTextCenter(string Text, Color color, Control control, IDeviceContext graphics)
        {
            TextRenderer.DrawText(
                graphics,
                Text,
                uiCustoms.Font,
                new Point(control.Width, control.Height / 2),
                color,
                flags
                );
        }

        public static Size CalcTextSize(string text)
        {
            return TextRenderer.MeasureText(text, uiCustoms.Font);
        }

        public static string ChangeTextSize(string text, int width)
        {
            string _t = text + "...";
            Size s = CalcTextSize(_t);

            if (s.Width < width) return text;
            else
            {
                string t = text.Substring(0, text.Length - 1);
                _t = t + "...";
                if (CalcTextSize(_t).Width < width) return _t;
                else if (CalcTextSize(text.Substring(0, 1) + "...").Width >= width) return "";
                else return ChangeTextSize(t, width);
            }
        }

    }
}
