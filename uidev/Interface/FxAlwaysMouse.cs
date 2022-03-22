using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace uidev.Interface
{
    public class FxAlwaysMouse : Controls.FxBaseControl
    {

        private Thread th;
        private Point _mp;
        private Point _mousePoint 
        {
            get
            {
                return _mp;
            }
            set
            {
                _mp = value;
                ThreadMainLoop?.Invoke(_mp);
            }
        }

        public Point MousePoint
        {
            get
            {
                return _mousePoint;
            }
        }

        public delegate void ThreadMainLoopEvent(Point point);
        public ThreadMainLoopEvent ThreadMainLoop;

        public FxAlwaysMouse()
        {
            this.SuspendLayout();

            //this.MouseDown += am_MouseDown;
            //this.MouseUp += am_MouseUp;

            this.ResumeLayout(false);

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime) return;
            th = new Thread(new ThreadStart(GetMousePosition));
            th.Start();
        }

        public void GetMousePosition()
        {

            while (true)
            {
                _mousePoint = Cursor.Position;
                Thread.Sleep(10);
            }

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            th.Abort();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
