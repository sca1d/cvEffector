using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.TimeLineControls
{
    public partial class TL_MainControl : Controls.FxBaseControl
    {
        Pen BorderPen = Class.uiCustoms.BorderPen;

        public TL_MainControl()
        {
            InitializeComponent();
        }

        private void TL_MainControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Class.uiCustoms.DarkColor);

            e.Graphics.DrawRectangle(BorderPen, 0, 0, Width - 1, Height - 1);
        }

        private void TL_MainControl_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                BorderPen.Color = Class.Tools.rgb2gray(Class.uiCustoms.BorderPen.Color);
            }
            else
            {
                BorderPen.Color = Class.uiCustoms.BorderPen.Color;
            }
            Refresh();
        }
    }
}
