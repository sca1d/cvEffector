using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace thetaSuite.Forms
{
    public partial class MainForm : uidev.Forms.BaseForm
    {
        protected Form1 form1 = null;
        protected TestForm testForm = null;

        public MainForm()
        {
            InitializeComponent();

            form1 = new Form1();
            form1.Show(dockPanel);

            testForm = new TestForm();
            testForm.Show(dockPanel);
        }
    }
}
