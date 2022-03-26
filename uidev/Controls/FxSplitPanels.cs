using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace uidev.Controls
{
    [Designer(typeof(Designs.FxSplitPanelsDesigner))]
    public partial class FxSplitPanels : UserControl
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Controls.FxPanel Panel1
        {
            get { return fxPanel1; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Controls.FxPanel Panel2
        {
            get { return fxPanel2; }
        }

        private int _panelMinSize = 10;
        public int PanelMinimumSize
        {
            get
            {
                return _panelMinSize;
            }
            set
            {
                _panelMinSize = value;
            }
        }

        private int _holdSpace = 4;
        public int HoldSpace
        {
            get
            {
                return _holdSpace;
            }
            set
            {
                _holdSpace = value;
                InitPanels();
            }
        }

        private int _splitPoint = 30;
        public int SplitPoint
        {
            get
            {
                return _splitPoint;
            }
            set
            {
                _splitPoint = PanelMinimumSize <= value ? value <= Width - PanelMinimumSize ? value : Width - PanelMinimumSize : PanelMinimumSize;
                InitPanels();
            }
        }

        private void InitPanels()
        {
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(SplitPoint, Height);
            Panel2.Location = new Point(SplitPoint, 0);
            Panel2.Size = new Size(Width - SplitPoint, Height);
            Refresh();
        }

        public FxSplitPanels()
        {
            InitializeComponent();

            _splitPoint = Width / 2;
            InitPanels();

            TypeDescriptor.AddAttributes(this.fxPanel1, new DesignerAttribute(typeof(Designs.PanelDesigner)));
            TypeDescriptor.AddAttributes(this.fxPanel2, new DesignerAttribute(typeof(Designs.PanelDesigner)));
        }

        private void FxSplitPanels_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Class.uiCustoms.BackColor);
        }

        private void FxSplitPanels_Resize(object sender, EventArgs e)
        {
            InitPanels();
        }

        private void FxSplitPanels_SizeChanged(object sender, EventArgs e)
        {
            InitPanels();
        }
    }
}
