using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uidev.Class;

namespace uidev.Controls
{
    public partial class FxButton : FxBaseControl
    {

        private bool InMouse = false;
        private bool DownMouse = false;

        public FxButton()
        {
            InitializeComponent();
        }

        private void FxButton_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = uiCustoms.SmoothingMode;

            if (DownMouse)
            {
                e.Graphics.Clear(uiCustoms.ClickColor);
                DrawManager.DrawText(uiCustoms.BackColor, this, e.Graphics);
                return;
            }

            if (InMouse)
            {
                e.Graphics.Clear(uiCustoms.DashColor);
                DrawManager.DrawText(uiCustoms.BackColor, this, e.Graphics);
                return;
            }

            Size tSize = TextRenderer.MeasureText(
                        this.Text,
                        uiCustoms.Font
                        );

            e.Graphics.Clear(uiCustoms.BackColor);

            DrawManager.DrawText(uiCustoms.MainColor, this, e.Graphics);

            if (Border) e.Graphics.DrawRectangle(uiCustoms.BorderPen, 0, 0, Width - 1, Height - 1);

        }

        private void FxButton_MouseEnter(object sender, EventArgs e)
        {
            InMouse = true;
            Refresh();
        }

        private void FxButton_MouseLeave(object sender, EventArgs e)
        {
            InMouse = false;
            Refresh();
        }

        private void FxButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DownMouse = true;
                Refresh();
            }
        }

        private void FxButton_MouseUp(object sender, MouseEventArgs e)
        {
            DownMouse = false;
            Refresh();
        }
    }
}
