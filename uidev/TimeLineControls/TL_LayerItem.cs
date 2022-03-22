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
using uidev.Interface;

namespace uidev.TimeLineControls
{
    public partial class TL_LayerItem : Control, TL_LayerItemBase
    {

        public delegate void MovingLayerEvent(EventArgs e);
        public MovingLayerEvent movingLayer_Start;
        public MovingLayerEvent movingLayer_End;

        public delegate void ChangingLayerSizeEventStart(ChangeSizeEventArgs e);
        public delegate void ChangingLayerSizeEventEnd(EventArgs e);
        public ChangingLayerSizeEventStart changingLayerSize_Start;
        public ChangingLayerSizeEventEnd changingLayerSize_End;

        private Color _color = Color.FromArgb(220, 180, 255);
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                Refresh();
            }
        }

        private Color _enterColor = uiCustoms.ToEnterColor(Color.FromArgb(220, 180, 255));
        public Color enterColor
        {
            get
            {
                return _enterColor;
            }
            set
            {
                _enterColor = value;
                Refresh();
            }
        }

        private Color _clickColor = Color.White;
        public Color clickColor
        {
            get
            {
                return _clickColor;
            }
            set
            {
                _clickColor = value;
                Refresh();
            }
        }

        private int _startFrame = 0;
        public int srart_frame
        {
            get
            {
                return _startFrame;
            }
            set
            {
                _startFrame = value;
                Refresh();
            }
        }

        private int _frameNum = 60;
        public int frame_num
        {
            get
            {
                return _frameNum;
            }
            set
            {
                _frameNum = value;
                Refresh();
            }
        }

        private bool _selected = true;
        public bool selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                Refresh();
            }
        }

        // レイヤーサイズの調整が可能な範囲
        private int changeSizePoint = 4;

        ChangeSizeEventArgs.CenterBackward cb;

        private bool _changingLayerSizeNow = false;
        private bool ChangingLayerSizeNow
        {
            get
            {
                return _changingLayerSizeNow;
            }
            set
            {
                _changingLayerSizeNow = value;

                /*
                if (value)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
                */
            }
        }
        private bool MovingLayerPointNow = false;

        private bool MouseIsEnter = false;
        private bool MouseIsDown = false;

        public void Init()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Class.uiCustoms.PropertyChanged += PropertiesChanged;

            movingLayer_Start += move_start;
            movingLayer_End += move_end;
            changingLayerSize_Start += size_start;
            changingLayerSize_End += size_end;
        }

        public TL_LayerItem()
        {
            InitializeComponent();
            Init();
        }

        private void PropertiesChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void move_start(EventArgs e)
        {
            Console.WriteLine("move start");
        }
        private void move_end(EventArgs e)
        {
            Console.WriteLine("move end");
        }
        private void size_start(ChangeSizeEventArgs e)
        {
            Console.WriteLine("size start " + e.centerBackward);
        }
        private void size_end(EventArgs e)
        {
            Console.WriteLine("size end");
        }

        private void TL_LayerItem_Paint(object sender, PaintEventArgs e)
        {

            int CornerSize = 3;
            Color TriColor = Color.FromArgb(50, 50, 50);

            Point[] STriP = new Point[3];
            STriP[0] = new Point(e.ClipRectangle.X + CornerSize + 1, e.ClipRectangle.Y);
            STriP[1] = new Point(e.ClipRectangle.X + 1, e.ClipRectangle.Y);
            STriP[2] = new Point(e.ClipRectangle.X + 1, e.ClipRectangle.Y + CornerSize);

            Point[] ETriP = new Point[3];
            ETriP[0] = new Point(e.ClipRectangle.X + e.ClipRectangle.Width - 1 - CornerSize, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            ETriP[1] = new Point(e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            ETriP[2] = new Point(e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1 - CornerSize);

            if (MouseIsEnter)
            {
                if (ChangingLayerSizeNow)
                {
                    e.Graphics.Clear(enterColor);
                }
                else if (MouseIsDown)
                {
                    e.Graphics.Clear(clickColor);
                }
                else
                {
                    e.Graphics.Clear(enterColor);
                }
            }
            else
            {
                e.Graphics.Clear(color);
            }

            e.Graphics.FillPolygon(
                new SolidBrush(TriColor),
                STriP
                );
            e.Graphics.FillPolygon(
                new SolidBrush(TriColor),
                ETriP
                );
            e.Graphics.DrawLine(
                new Pen(TriColor, 1.2F),
                e.Graphics.ClipBounds.X + e.Graphics.ClipBounds.Width - 1F - (CornerSize + 2),
                e.Graphics.ClipBounds.Y + e.Graphics.ClipBounds.Height - 1F,
                e.Graphics.ClipBounds.X + e.Graphics.ClipBounds.Width - 1F,
                e.Graphics.ClipBounds.Y + e.Graphics.ClipBounds.Height - 1F - (CornerSize + 2)
                );

            if (selected)
            {
                e.Graphics.DrawRectangle(uiCustoms.BorderPen, 0, 0, Width - 1, Height - 1);
            }
            else
            {
                e.Graphics.DrawRectangle(uiCustoms.GrayPen, 0, 0, Width - 1, Height - 1);
            }

        }

        private void TL_LayerItem_MouseEnter(object sender, EventArgs e)
        {
            MouseIsEnter = true;
            Refresh();
        }

        private void TL_LayerItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!ChangingLayerSizeNow)
                {
                    MovingLayerPointNow = true;
                    movingLayer_Start?.Invoke(new EventArgs());
                }
                else
                {
                    changingLayerSize_Start?.Invoke(new ChangeSizeEventArgs(cb));

                }
                MouseIsDown = true;
            }
            Refresh();
        }

        private void TL_LayerItem_MouseLeave(object sender, EventArgs e)
        {
            MouseIsEnter = false;
            Refresh();
        }

        private void TL_LayerItem_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = false;

                if (ChangingLayerSizeNow || !MovingLayerPointNow)
                {
                    ChangingLayerSizeNow = false;
                    changingLayerSize_End?.Invoke(new EventArgs());
                }
                if (MovingLayerPointNow)
                {
                    MovingLayerPointNow = false;
                    movingLayer_End?.Invoke(new EventArgs());
                }

                Refresh();
            }

        }

        private void TL_LayerItem_MouseMove(object sender, MouseEventArgs e)
        {
            bool centerLoc = 0 <= e.Location.X && e.Location.X <= changeSizePoint;
            bool backwardLoc = this.Width - changeSizePoint <= e.Location.X && e.Location.X < this.Width;

            cb = centerLoc ? ChangeSizeEventArgs.CenterBackward.Center : ChangeSizeEventArgs.CenterBackward.Backward;

            if ((centerLoc || backwardLoc) && !MovingLayerPointNow)
            {
                this.Cursor = Cursors.SizeWE;
                ChangingLayerSizeNow = true;
            }
            else if (!MouseIsDown)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                ChangingLayerSizeNow = false;
            }

            Refresh();
        }
    }
}
