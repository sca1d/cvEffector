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
    public partial class FxSplitPanels : FxBaseControl
    {

        // panel objects
        protected FxPanel panel1 = new FxPanel();
        protected FxPanel panel2 = new FxPanel();

        #region PROPERTIES
        private int _panelsMargin = 4;
        public int PanelsMargin
        {
            get
            {
                return _panelsMargin;
            }
            set
            {
                _panelsMargin = value;
                UpdatePanels();
            }
        }
        #endregion

        #region COLORING DEFINE
        private Pen borderPen = Class.uiCustoms.BorderPen;
        #endregion

        private void InitPanels()
        {
            panel1.Visible = false;
            panel2.Visible = false;

            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            Refresh();
        }
        private void UpdatePanels()
        {
            panel1.Margin = new Padding(PanelsMargin);
            panel2.Margin = new Padding(PanelsMargin);
        }

        public FxSplitPanels()
        {
            InitializeComponent();
            
            InitPanels();
            UpdatePanels();
        }

        private void FxSplitPanels_Paint(object sender, PaintEventArgs e)
        {

            if (Border) e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);

        }

        private void FxSplitPanels_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                borderPen.Color = Class.Tools.rgb2gray(Class.uiCustoms.BorderPen.Color);
            }
            else
            {
                borderPen.Color = Class.uiCustoms.BorderPen.Color;
            }
        }
    }
}
