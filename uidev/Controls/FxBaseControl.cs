using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.Controls
{
    public partial class FxBaseControl : Control, Interface.FxUiBase
    {

        private bool _border = true;
        public bool Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                Refresh();
            }
        }

        public new bool DesignMode
        {
            get
            {
                return GetDesignMode(this);
            }
        }

        public void Init()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Class.uiCustoms.PropertyChanged += PropertiesChanged;
        }

        public FxBaseControl()
        {
            InitializeComponent();

            Init();
        }

        private bool GetDesignMode(Control control)
        {
            if (control == null) return false;

            bool mode = control.Site == null ? false : control.Site.DesignMode;

            return mode | GetDesignMode(control.Parent);
        }

        private void PropertiesChanged(object sender, EventArgs e)
        {
            Refresh();
        }

    }
}
