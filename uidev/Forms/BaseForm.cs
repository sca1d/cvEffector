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

namespace uidev.Forms
{
    public partial class BaseForm : System.Windows.Forms.Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.BackColor = Class.uiCustoms.BackColor;
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
