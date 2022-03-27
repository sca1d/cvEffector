using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.Controls
{
    public partial class FxInteriorButton : FxBaseControl
    {

        private Pen borderPen = Class.uiCustoms.BorderPen;

        private bool MouseIsEnter = false;
        private bool MouseIsDown = false;

        private Size BefSize;

        #region PROPERTIES
        private bool _border = false;
        new public bool Border { get { return _border; } set { _border = value; Refresh(); } }

        private Image _image;
        public Image image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Refresh();
            }
        }

        private double _imageDrawSize = 100;
        public double ImageDrawSize
        {
            get
            {
                return _imageDrawSize;
            }
            set
            {
                _imageDrawSize = value;
                Refresh();
            }
        }
        #endregion

        public FxInteriorButton()
        {
            InitializeComponent();

            BefSize = Size;

        }

        private void FxInteriorButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.High;

            if (MouseIsDown)
            {
                Color p20 = Color.FromArgb(BackColor.R + 20, BackColor.G + 20, BackColor.B + 20);
                e.Graphics.Clear(p20);
            }
            else if (MouseIsEnter)
            {
                Color p10 = Color.FromArgb(BackColor.R + 10, BackColor.G + 10, BackColor.B + 10);
                e.Graphics.Clear(p10);
            }
            else
            {
                e.Graphics.Clear(BackColor);
            }

            if (image != null)
            {
                float w = (float)((double)Width * (ImageDrawSize / 100.0));
                float h = (float)((double)Height * (ImageDrawSize / 100.0));

                e.Graphics.DrawImage(
                    image,
                    Width / 2 - w / 2,
                    Height / 2 - h / 2,
                    w,
                    h
                    );
            }

            if (Border)
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void FxInteriorButton_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                borderPen.Color = Class.Tools.rgb2gray(Class.uiCustoms.BorderPen.Color);
            }
            else
            {
                borderPen.Color = Class.uiCustoms.BorderPen.Color;
            }
            Refresh();
        }

        private void FxInteriorButton_MouseEnter(object sender, EventArgs e)
        {
            MouseIsEnter = true;
            Refresh();
        }

        private void FxInteriorButton_MouseLeave(object sender, EventArgs e)
        {
            MouseIsEnter = false;
            Refresh();
        }

        private void FxInteriorButton_Resize(object sender, EventArgs e)
        {
            if (BefSize.Width != Width)
            {
                Height = Width;
            }
            else if (BefSize.Height != Height)
            {
                Width = Height;
            }
        }

        private void FxInteriorButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = true;
                Refresh();
            }
        }

        private void FxInteriorButton_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
            Refresh();
        }
    }
}
