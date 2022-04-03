using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using uidev.Forms;
using thetaLib;
using thetaLib.MemoryScope;
using thetaLib.MemoryScope.Controls;

namespace thetaSuite.Forms
{
    public partial class TestForm : BaseForm
    {
        bool read = false;

        ControlManager controlManager;

        private void OpenVideoFile()
        {
            this.fxSlider1.Slide += fxSlider1_Slide;
            controlManager = new ControlManager(this.fxControl1, this.FindForm());

            int ret = controlManager.OpenVideo(1.0 / 4.0);
            if (ret != 0)
            {
                controlManager.Dispose();
                return;
            }
            read = true;
            this.fxSlider1.Enabled = true;

            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.MaximumValue = controlManager.GetVideoFrames();
            this.fxSlider1.Value = 0;

            controlManager.ShowMat(fxSlider1.Value);

            fxControl1.Refresh();
        }

        public TestForm()
        {
            InitializeComponent();

            OpenVideoFile();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // WM_PAINT
            if (m.Msg == 0x000F || m.Msg == 0x0005)
            {
                controlManager.Update();
            }
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            OpenVideoFile();
        }
        private void fxSlider1_Slide(object sender, uidev.Class.SlideArgs e)
        {
            if (read)
            controlManager.ShowMat(e.value);
        }

        private void fxControl1_Paint(object sender, PaintEventArgs e)
        {
            if (read) controlManager.Update();
        }
        private void fxControl1_VisibleChanged(object sender, EventArgs e)
        {
            if (read) controlManager.Update();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //controlManager.Update();
        }
    }
}
