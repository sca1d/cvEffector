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
using uidev.Forms;
using uidev.Controls;

namespace cvFxSuite
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            fxSlider1.StartThread();
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("slider value : " + fxSlider1.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            fxSlider1.Value = this.trackBar1.Value;
        }
    }
}
