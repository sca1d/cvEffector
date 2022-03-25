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
    public partial class FxPanel : Panel, Interface.FxUiBase
    {

        private Color backColor = Class.uiCustoms.BackColor;
        private Color borderColor = Class.uiCustoms.BorderPen.Color;

        [BrowsableAttribute(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle { get; set; }

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

        private FxMenu _menu = null;
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
        }

        public FxPanel()
        {
            InitializeComponent();

            Init();
        }

        private void FxPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(backColor);

            if (Border) e.Graphics.DrawRectangle(new Pen(borderColor), 0, 0, Width - 1, Height - 1);
        }

        private void FxPanel_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                borderColor = Class.Tools.rgb2gray(Class.uiCustoms.BorderPen.Color);
            }
            else
            {
                borderColor = Class.uiCustoms.BorderPen.Color;
            }
        }
    }
}
