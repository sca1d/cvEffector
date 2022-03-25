using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.Controls
{
    public partial class FxControl : FxBaseControl
    {
        private Pen borderPen = Class.uiCustoms.BorderPen;

        public FxControl()
        {
            InitializeComponent();
        }

        private void FxControl_Paint(object sender, PaintEventArgs e)
        {
            if (Border) e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }

        private int EnabledControl(Control c)
        {
            c.Enabled = Enabled;
            c.Refresh();
            return 0;
        }
        private void FxControl_EnabledChanged(object sender, EventArgs e)
        {
            Class.Tools.DoAllControl(this.Controls, EnabledControl);

            if (!Enabled)
            {
                borderPen = new Pen(Class.Tools.rgb2gray(Class.uiCustoms.BorderPen.Color));
            }
            else
            {
                borderPen = new Pen(Class.uiCustoms.BorderPen.Color);
            }

            Refresh();
        }
    }
}
