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
    public partial class FxSeparator : FxBaseControl
    {
        private Color lineColor = Color.FromArgb(43, 43, 43);

        #region PROPERTIES
        private bool _border = false;
        new public bool Border
        {
            get
            {
                return _border;
            }
            set
            {

            }
        }

        private Orientation _orientation = Orientation.Horizontal;
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                Refresh();
            }
        }

        private float _lineWidth = 1.6F;
        public float LineWidth
        {
            get
            {
                return _lineWidth;
            }
            set
            {
                _lineWidth = value;
                Refresh();
            }
        }
        #endregion

        public FxSeparator()
        {
            InitializeComponent();

            //UpdateSize();
        }

        private void FxSeparator_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Pen linePen = new Pen(lineColor);
            linePen.Width = _lineWidth;

            if (Orientation == Orientation.Horizontal)
            {
                e.Graphics.DrawLine(linePen, new Point(0, Height / 2), new Point(Width, Height / 2));
            }
            else
            {
                e.Graphics.DrawLine(linePen, new Point(Width / 2, 0), new Point(Width / 2, Height));
            }
        }

        private void FxSeparator_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                lineColor = Class.Tools.rgb2gray(Color.FromArgb(43, 43, 43));
            }
            else
            {
                lineColor = Color.FromArgb(43, 43, 43);
            }
            Refresh();
        }
    }
}
