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
