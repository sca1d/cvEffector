﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uidev.Class;

using uiplg;

namespace uidev.Forms
{
    public partial class BaseForm : System.Windows.Forms.Form
    {
        
        public BaseForm()
        {
            InitializeComponent();
            this.BackColor = Class.uiCustoms.BackColor;

            //Sample sample = new Sample();
            //Console.WriteLine(sample.HelloWorld("test"));
        }

        private int control_refresh(Control c)
        {
            c.Refresh();
            return 0;
        }
        public void AllRefresh()
        {
            Tools.DoAllControl(Controls, control_refresh);
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            AllRefresh();
        }

        private void BaseForm_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            AllRefresh();
        }
    }
}
