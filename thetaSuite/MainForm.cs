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
        private bool ControlEnabled = true;

        public MainForm()
        {
            InitializeComponent();

            fxSlider1.StartThread();
            fxSlider2.StartThread();
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            ControlEnabled = fxPanel1.Enabled;

            fxPanel1.Enabled = !ControlEnabled;
            //fxCombo1.Enabled = ControlEnabled;
            //fxButton2.Enabled = ControlEnabled;
            //fxSlider1.Enabled = ControlEnabled;
            //fxCheckbox1.Enabled = ControlEnabled;

            fxButton1.Text = "Enabled : " + ControlEnabled.ToString();
        }
    }
}
