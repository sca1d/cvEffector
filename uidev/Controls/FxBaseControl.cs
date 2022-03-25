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

        public new EventHandler EnabledChanged;

        private bool _enabled = true;
        public new bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                //Console.WriteLine("enabled change");
                EnabledChanged?.Invoke(this, new EventArgs());
                Refresh();
            }
        }

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

        private bool _dontOpenMenuMode = false;
        public bool DontOpenMenuMode
        {
            get
            {
                return _dontOpenMenuMode;
            }
            protected set
            {
                _dontOpenMenuMode = value;
            }
        }

        private FxMenu _menu;
        public FxMenu Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
                Refresh();
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

        private void FxBaseControl_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        private void FxBaseControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Menu != null && Enabled && !DontOpenMenuMode)
                {
                    Menu.Show(PointToScreen( e.Location));
                }
            }
        }

        private void FxBaseControl_EnabledChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
