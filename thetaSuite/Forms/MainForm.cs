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

namespace thetaSuite.Forms
{
    public partial class MainForm : BaseForm
    {
        ControlManager controlManager;

        public MainForm()
        {
            InitializeComponent();

            controlManager = new ControlManager(this.fxControl1);
            //this.fxSplitPanels1.Panel1.Controls.Add(new Button());
        }

        private void fxButton1_Click(object sender, EventArgs e)
        {
            controlManager.OpenVideo();
        }
    }
}
