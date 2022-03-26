using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace uidev.Class
{
    public static class Tools
    {

        public static int MinMax(int value, int min, int max)
        {
            return min <= value ? value <= max ? value : max : min;
        }

        public static Color rgb2gray(Color c)
        {
            double r = c.R;
            double g = c.G;
            double b = c.B;

            double gray = (r + g + b) / 3.0;

            int gr = (int)((double)0x00 <= gray ? gray <= (double)0xFF ? (int)gray : (double)0xFF : (double)0x00);

            return Color.FromArgb(gr, gr, gr);
        }

        public static void DoAllParent(Control _this, Func<Control, int> func)
        {
            if (_this.Parent != null)
            {
                func(_this.Parent);
                DoAllParent(_this.Parent, func);
            }
        }

        public static void DoAllControl(Control.ControlCollection c, Func<Control, int> func)
        {
            foreach (Control _c in c)
            {
                if (0 < _c.Controls.Count) DoAllControl(_c.Controls, func);
                func(_c);
            }
        }
        public static void RefreshAllControl(Control.ControlCollection c)
        {
            foreach (Control _c in c)
            {
                if (0 < _c.Controls.Count) RefreshAllControl(_c.Controls);
                _c.Refresh();
            }
        }

        // get window client
        public static Rectangle GetClientRectangle(Control ctrl)
        {
            Debug.Assert(ctrl.ClientRectangle.Location == new Point(0, 0));
            Debug.Assert(ctrl.ClientRectangle.Size == ctrl.ClientSize);

            return ctrl.ClientRectangle;
        }

        // get window region
        public static Rectangle GetWindowRectangle(Control ctrl)
        {

            Debug.Assert(ctrl.Bounds.Location == ctrl.Location);
            Debug.Assert(ctrl.Location == new Point(ctrl.Left, ctrl.Top));
            Debug.Assert(ctrl.Bounds.Size == ctrl.Size);
            Debug.Assert(ctrl.Size ==
              new Size(ctrl.Right - ctrl.Left, ctrl.Bottom - ctrl.Top));

            if (ctrl is Form)
            {

                Point winRectLocation = ctrl.PointToClient(ctrl.Bounds.Location);

                Rectangle winRect = new Rectangle(winRectLocation, ctrl.Bounds.Size);
                return winRect;

            }
            else
            {

                Point screenLocation =
                  ctrl.Parent.PointToScreen(ctrl.Bounds.Location);

                Point winRectLocation =
                  ctrl.PointToClient(screenLocation);

                Rectangle winRect =
                  new Rectangle(winRectLocation, ctrl.Bounds.Size);
                return winRect;

            }
        }

        public static string GetClientContainState(Control ctrl)
        {
            Rectangle rect = ctrl.ClientRectangle;
            return GetContainState(ctrl, rect);
        }

        public static string GetWindowContainState(Control ctrl)
        {
            Rectangle rect = GetWindowRectangle(ctrl);
            return GetContainState(ctrl, rect);
        }

        public static string GetContainState(Control ctrl, Rectangle rect)
        {
            string output;

            Point mouseScreenPos = Control.MousePosition;
            Point mouseClientPos = ctrl.PointToClient(mouseScreenPos);

            bool inside = rect.Contains(mouseClientPos);
            output = String.Format("{0}\n{1} － {2}",
                  rect,
                  inside ? "内部" : "外部",
                  mouseClientPos);
            return output;
        }

    }
}
