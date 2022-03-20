using System;
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
    public class AlwaysMouse : System.Windows.Forms.Control
    {

        private Thread th;

        protected bool MouseDownNow = false;
        private Point MousePoint { get; set; }

        public delegate void MouseMoveHandler(Point point);
        public MouseMoveHandler TheMouseMove;

        public AlwaysMouse()
        {
            this.SuspendLayout();

            //this.MouseDown += am_MouseDown;
            //this.MouseUp += am_MouseUp;

            this.ResumeLayout(false);

            th = new Thread(new ThreadStart(GetMousePosition));
            th.Start();
        }

        public void GetMousePosition()
        {

            while (true)
            {
                MousePoint = Cursor.Position;
                Thread.Sleep(10);
            }

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (MouseDownNow) TheMouseMove?.Invoke(MousePoint);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            th.Abort();
        }

        public void StartMeasurement()
        {
            MouseDownNow = true;
        }
        public void FinishMeasurement()
        {
            MouseDownNow = false;
        }

    }
}
