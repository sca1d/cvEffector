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

        public static void DrawText(Color color, Control control, IDeviceContext graphics)
        {
            TextRenderer.DrawText(
                graphics,
                control.Text,
                uiCustoms.Font,
                new Point(control.Width, control.Height / 2),
                color,
                flags
                );
        }

    }
}
