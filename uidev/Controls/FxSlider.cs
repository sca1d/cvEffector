using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace uidev.Controls
{
    public partial class FxSlider : Interface.FxAlwaysMouseActive, Interface.FxUiBase
    {

        const int knobMoveRange = 2;

        private int knobSize = 7;
        private int knobPoint = 7 + 2;

        private float yp
        {
            get
            {
                return (float)(Height - 1) / 2F;
            }
        }

        private bool MouseIsEnter = false;
        private bool MouseIsDown = false;

        private Color knobColor = Color.SlateBlue;
        private Color mouseEnterKnobColor = Color.FromArgb(170, 160, 226);
        private Color mouseClickKnobColor = Color.GhostWhite;

        private Color mainColor = Color.SlateBlue;
        private Color mouseEnterColor = Color.FromArgb(170, 160, 226);
        private Color mouseClickColor = Color.GhostWhite;

        private int _minValue = 0;
        public int MinimumValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }

        private int _maxValue = 100;
        public int MaximumValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        private bool _border = false;
        public bool Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                Refresh();
            }
        }

        public FxSlider() {
            InitializeComponent();
            this.ThreadMainLoop += FxSlider_ThreadMainLoop;
        }

        public int GetValue()
        {
            return (int)((knobPoint - knobSize) / ((this.Width - 1 - knobSize * 2)
                / (MaximumValue - MinimumValue)) + MinimumValue);
        }

        private void FxSlider_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.Clear(Class.uiCustoms.BackColor);

            PointF[] dps = new PointF[4];
            dps[0] = new PointF((float)knobPoint - (float)knobSize, yp);
            dps[1] = new PointF((float)knobPoint, yp - (float)knobSize);
            dps[2] = new PointF((float)knobPoint + (float)knobSize, yp);
            dps[3] = new PointF((float)knobPoint, yp + (float)knobSize);

            Pen linepen = new Pen(Color.Gray, 2F);
            e.Graphics.DrawLine(
                linepen,
                new PointF(knobSize + 2, Height / 2 + 0.05F),
                new PointF(Width - 1 - (knobSize + 2), Height / 2 + 0.05F)
                );

            if (MouseIsDown)
            {
                e.Graphics.FillPolygon(new SolidBrush(this.mouseClickColor), dps);
            }
            else if (MouseIsEnter)
            {
                e.Graphics.FillPolygon(new SolidBrush(this.mouseEnterColor), dps);
            }
            else
            {
                e.Graphics.FillPolygon(new SolidBrush(this.knobColor), dps);
            }

            if (Border) e.Graphics.DrawRectangle(Class.uiCustoms.BorderPen, 0, 0, Width - 1, Height - 1);

        }

        private void FxSlider_ThreadMainLoop(Point point)
        {

            int futureX = point.X - this.FindForm().Location.X - this.Location.X - knobSize;

            if (MouseIsDown)
            {
                knobPoint = knobSize <= futureX ? (futureX <= (this.Width - knobSize) ? futureX : this.Width - knobSize) : knobSize;
               // Console.WriteLine(GetValue());
            }
        }

        private void FxSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (
                e.X >= this.knobPoint - this.knobSize &&
                e.X <= this.knobPoint + this.knobSize &&
                e.Y >= yp - this.knobSize &&
                e.Y <= yp + this.knobSize)
            {
                MouseIsEnter = true;
            }
            else
            {
                MouseIsEnter = false;
            }
            Refresh();
        }

        private void FxSlider_MouseDown(object sender, MouseEventArgs e) {
            if (
                e.X >= this.knobPoint - this.knobSize &&
                e.X <= this.knobPoint + this.knobSize &&
                e.Y >= yp - this.knobSize &&
                e.Y <= yp + this.knobSize
                )
            {
                MouseIsDown = true;
            }
            Refresh();
        }

        private void FxSlider_MouseUp(object sender, MouseEventArgs e) {
            MouseIsDown = false;
            Refresh();
        }

        /*
        private void FxSlider_TheMouseMove(Point point)
        {
            int Lx = FindForm().Location.X;
            int Ly = FindForm().Location.Y;
            
            this.Location = new Point(point.X - Lx, point.Y - Ly);

            FindForm().Refresh();
        }
        */
    }
}
