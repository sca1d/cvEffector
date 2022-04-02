using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uidev.Forms;
using thetaLib;
using thetaLib.MemoryScope;
using thetaLib.MemoryScope.Controls;

namespace thetaSuite.Forms
{
    public partial class MainForm : BaseForm
    {
        bool read = false;

        ControlManager controlManager;

        private void OpenVideoFile()
        {
            this.fxSlider1.Slide += fxSlider1_Slide;
            controlManager = new ControlManager(this.fxControl1);

            int ret = controlManager.OpenVideo(1.0 / 4.0);
            if (ret != 0) return;
            read = true;
            this.fxSlider1.Enabled = true;

            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.MaximumValue = controlManager.GetVideoFrames();
            this.fxSlider1.Value = 0;

            controlManager.ShowMat(fxSlider1.Value);

            fxControl1.Refresh();
        }

        public MainForm()
        {
            InitializeComponent();

            OpenVideoFile();
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            OpenVideoFile();
        }
        private void fxSlider1_Slide(object sender, uidev.Class.SlideArgs e)
        {
            if (read)
            controlManager.ShowMat(e.value);
            Console.WriteLine("max:" + controlManager.GetVideoFrames());
            Console.WriteLine("slider:" + e.value.ToString());
        }

        private void fxControl1_Paint(object sender, PaintEventArgs e)
        {
            if (read)
                controlManager.ShowMat(fxSlider1.Value);
        }
    }
}
