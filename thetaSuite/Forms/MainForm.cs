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
        ControlManager controlManager;

        public MainForm()
        {
            InitializeComponent();

            this.fxSlider1.Slide += fxSlider1_Slide;
            controlManager = new ControlManager(this.fxControl1);
            //this.fxSplitPanels1.Panel1.Controls.Add(new Button());
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            int ret = controlManager.OpenVideo();
            if (ret != 0) return;
            this.fxSlider1.Enabled = true;

            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.MaximumValue = controlManager.GetVideoFrames();
            this.fxSlider1.Value = 0;

            controlManager.ShowMat(fxSlider1.Value);
        }
        private void fxSlider1_Slide(object sender, uidev.Class.SlideArgs e)
        {
            controlManager.ShowMat(e.value);
        }
    }
}
