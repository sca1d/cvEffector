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

namespace thetaSuite
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            fxSlider1.StartThread();
            fxSlider2.StartThread();
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            fxPanel1.Enabled = !fxPanel1.Enabled;
            fxSplitPanels1.fxPanel1.Enabled = !fxSplitPanels1.fxPanel1.Enabled;
            //fxCombo1.Enabled = ControlEnabled;
            //fxButton2.Enabled = ControlEnabled;
            //fxSlider1.Enabled = ControlEnabled;
            //fxCheckbox1.Enabled = ControlEnabled;

            fxButton1.Text = "Enabled : " + fxPanel1.Enabled.ToString();
        }
    }
}
