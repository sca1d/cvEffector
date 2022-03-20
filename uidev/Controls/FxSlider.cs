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
    public partial class FxSlider : Interface.FxAlwaysMouse, Interface.FxUiBase
    {

        private Color mainColor = Color.SlateBlue;
        private Color mouseEnterColor = Color.FromArgb(170, 160, 226);
        private Color mouseClickColor = Color.GhostWhite;

        private bool _border = true;

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
            //this.TheMouseMove += FxSlider_TheMouseMove;
        }

        private void FxSlider_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.Clear(Class.uiCustoms.BackColor);

            if (Border)
            {
                e.Graphics.DrawRectangle(Class.uiCustoms.BorderPen, 0, 0, Width - 1, Height - 1);
            }

        }

        private void FxSlider_MouseDown(object sender, MouseEventArgs e) {
            StartMeasurement();
        }

        private void FxSlider_MouseUp(object sender, MouseEventArgs e) {
            FinishMeasurement();
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
