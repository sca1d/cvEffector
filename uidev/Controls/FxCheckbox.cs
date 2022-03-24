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
    public partial class FxCheckbox : FxBaseControl
    {

        public delegate void ChangedValueEvent(bool value);
        public ChangedValueEvent ChangedValue;

        private const float box_size_half = 5F;
        private const float box_padding   = 4F;
        private const float box_width   = 2F;

        private Color mainColor = Color.SlateBlue;
        private Color mouseEnterColor = Color.FromArgb(170, 160, 226);
        private Color mouseClickColor = Color.GhostWhite;

        private Color checkColor = uiCustoms.BackColor;

        private Color borderColor = uiCustoms.BorderPen.Color;

        private bool MouseIsEnter = false;
        private bool MouseIsDown = false;

        private bool _value = false;
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                ChangedValue?.Invoke(value);
                Refresh();
            }
        }

        public FxCheckbox()
        {
            InitializeComponent();
        }

        private void FxCheckbox_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.Clear(uiCustoms.BackColor);

            System.Drawing.PointF[] boxp = new System.Drawing.PointF[4];
            boxp[0] = new System.Drawing.PointF(box_padding, (float)Height / 2F - box_size_half);
            boxp[1] = new System.Drawing.PointF(box_padding + box_size_half * 2, (float)Height / 2F - box_size_half);
            boxp[2] = new System.Drawing.PointF(box_padding + box_size_half * 2, (float)Height / 2F + box_size_half);
            boxp[3] = new System.Drawing.PointF(box_padding, (float)Height / 2F + box_size_half);

            System.Drawing.PointF[] checkp = new System.Drawing.PointF[3];
            checkp[0] = new System.Drawing.PointF(boxp[0].X + 2, Height / 2);
            checkp[1] = new System.Drawing.PointF((boxp[1].X - boxp[0].X) / 2F + 3F, boxp[3].Y - 2);
            checkp[2] = new System.Drawing.PointF(boxp[1].X - 2, boxp[1].Y + 2);

            Color main_color = mainColor;
            Color check_color = checkColor;

            if (MouseIsDown)
            {
                main_color = mouseClickColor;
            }
            else if (MouseIsEnter)
            {
                main_color = mouseEnterColor;
            }

            e.Graphics.DrawPolygon(new Pen(main_color, box_width), boxp);
            if (Value)
            {
                e.Graphics.FillPolygon(new SolidBrush(main_color), boxp);
                e.Graphics.DrawLines(new Pen(check_color, 2F), checkp);
            }

            int sp = (int)(boxp[2].X + 3F);
            string t =DrawManager.ChangeTextSize(Text, Width - 1 - sp);

            TextRenderer.DrawText(
                e.Graphics,
                t,
                uiCustoms.Font,
                new Point(sp, Height / 2),
                main_color,
                TextFormatFlags.VerticalCenter);

            if (Border)
            {
                e.Graphics.DrawRectangle(new Pen(borderColor), 0, 0, Width - 1, Height - 1);
            }

        }

        private void FxCheckbox_MouseEnter(object sender, EventArgs e)
        {
            MouseIsEnter = true;
            Refresh();
        }

        private void FxCheckbox_MouseLeave(object sender, EventArgs e)
        {
            MouseIsEnter = false;
            Refresh();
        }

        private void FxCheckbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = true;
                Refresh();
            }
        }

        private void FxCheckbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Enabled)
                {
                    MouseIsDown = false;
                    Value = !Value;
                }
            }
        }

        private void FxCheckbox_EnabledChanged(object sender, EventArgs e)
        {
            Color _mainColor = Color.SlateBlue;
            Color _mouseEnterColor = Color.FromArgb(170, 160, 226);
            Color _mouseClickColor = Color.GhostWhite;

            Color _checkColor = uiCustoms.BackColor;

            Color _borderColor = uiCustoms.BorderPen.Color;

            if (!Enabled)
            {
                mainColor = Tools.rgb2gray(_mainColor);
                mouseEnterColor = Tools.rgb2gray(_mainColor);
                mouseClickColor = Tools.rgb2gray(_mainColor);

                checkColor = Tools.rgb2gray(_checkColor);

                borderColor = Tools.rgb2gray(_borderColor);
            }
            else
            {
                mainColor = _mainColor;
                mouseEnterColor = _mouseEnterColor;
                mouseClickColor = _mouseClickColor;

                checkColor = _checkColor;

                borderColor = _borderColor;
            }
            Refresh();
        }
    }
}
