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
            controlManager.OpenVideo();
            this.fxSlider1.Enabled = true;
            this.fxSlider1.MaximumValue = controlManager.GetVideoFrames();
            Console.WriteLine(this.fxSlider1.MaximumValue);
        }
        private void fxSlider1_Slide(object sender, uidev.Class.SlideArgs e)
        {
            controlManager.ShowMat(e.value);
        }
    }
}
