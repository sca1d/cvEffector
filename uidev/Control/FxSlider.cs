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

namespace uidev.Control
{
    public partial class FxSlider : uidev.Interface.AlwaysMouse
    {
        public FxSlider() {
            InitializeComponent();
            this.TheMouseMove += FxSlider_TheMouseMove;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        private void FxSlider_MouseDown(object sender, MouseEventArgs e) {
            StartMeasurement();
        }

        private void FxSlider_MouseUp(object sender, MouseEventArgs e) {
            FinishMeasurement();
        }

        private void FxSlider_TheMouseMove(Point point)
        {
            this.FindForm().Text = point.ToString();
        }
    }
}
