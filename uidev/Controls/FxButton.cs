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

        private Color mainColor = uiCustoms.MainColor;
        private Color clickColor = uiCustoms.ClickColor;
        private Color dashColor = uiCustoms.DashColor;

        private Color backColor = uiCustoms.BackColor;
        private Color borderColor = uiCustoms.BorderPen.Color;

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
                e.Graphics.Clear(clickColor);
                DrawManager.DrawTextCenter(this.Text, backColor, this, e.Graphics);
                return;
            }

            if (InMouse)
            {
                e.Graphics.Clear(dashColor);
                DrawManager.DrawTextCenter(this.Text, backColor, this, e.Graphics);
                return;
            }

            e.Graphics.Clear(backColor);

            DrawManager.DrawTextCenter(this.Text, mainColor, this, e.Graphics);

            if (Border) e.Graphics.DrawRectangle(new Pen(borderColor), 0, 0, Width - 1, Height - 1);

        }

        private void FxButton_MouseEnter(object sender, EventArgs e)
        {
            if (Enabled) InMouse = true;
            Refresh();
        }

        private void FxButton_MouseLeave(object sender, EventArgs e)
        {
            if (Enabled) InMouse = false;
            Refresh();
        }

        private void FxButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (Enabled && e.Button == MouseButtons.Left)
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

        private void FxButton_EnabledChanged(object sender, EventArgs e)
        {
            Color _mainColor = uiCustoms.MainColor;
            Color _clickColor = uiCustoms.ClickColor;
            Color _dashColor = uiCustoms.DashColor;

            Color _backColor = uiCustoms.BackColor;
            Color _borderColor = uiCustoms.BorderPen.Color;

            if (!Enabled)
            {
                mainColor = Tools.rgb2gray(_mainColor);
                clickColor = Tools.rgb2gray(_mainColor);
                dashColor = Tools.rgb2gray(_dashColor);

                backColor = Tools.rgb2gray(_backColor);
                borderColor = Tools.rgb2gray(_borderColor);
            }
            else
            {
                mainColor = _mainColor;
                clickColor = _clickColor;
                dashColor = _dashColor;

                backColor = _backColor;
                borderColor = _borderColor;
            }
            Refresh();
        }
    }
}
