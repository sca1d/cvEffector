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
    [Designer(typeof(Designs.FxSplitPanelsDesigner))]
    public partial class FxSplitPanels : FxBaseControl
    {

        // panel objects
        protected FxPanel panel1 = new FxPanel();
        protected FxPanel panel2 = new FxPanel();

        // public panel properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FxPanel Panel1
        {
            get
            {
                return panel1;
            }
            set
            {
                panel1 = value;
                UpdatePanels();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FxPanel Panel2
        {
            get
            {
                return panel2;
            }
            set
            {
                panel2 = value;
                UpdatePanels();
            }
        }

        #region PROPERTIES
        private int _panelsMargin = 3;
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
                UpdatePanels();
            }
        }

        private int _spitPoint = 30;
        public int SplitPoint
        {
            get
            {
                return _spitPoint;
            }
            set
            {
                _spitPoint = Class.Tools.MinMax(value, PanelMinimumSize, Width - PanelMinimumSize);
                UpdatePanels();
            }
        }

        private Cursor _splitCursor = Cursors.SizeWE;
        public Cursor SplitCursor
        {
            get
            {
                return _splitCursor;
            }
            set
            {
                _splitCursor = value;
            }
        }
        #endregion

        private bool MouseIsDown = false;

        #region COLORING DEFINE
        private Pen borderPen = Class.uiCustoms.BorderPen;
        #endregion

        private void InitPanels()
        {
            //panel1.Visible = true;
            //panel2.Visible = true;

            TypeDescriptor.AddAttributes(this.panel1, new DesignerAttribute(typeof(Designs.PanelDesigner)));
            TypeDescriptor.AddAttributes(this.panel2, new DesignerAttribute(typeof(Designs.PanelDesigner)));

            Refresh();
        }
        private void UpdatePanels()
        {
            //panel1.Margin = new Padding(PanelsMargin);
            //panel2.Margin = new Padding(PanelsMargin);

            int SizeMargin = PanelsMargin * 2;

            panel1.Size = new Size(SplitPoint - HoldSpace / 2 - PanelsMargin, Height - SizeMargin);
            panel2.Size = new Size(Width - (SplitPoint + HoldSpace / 2) - PanelsMargin, Height - SizeMargin);
            
            panel1.Location = new Point(PanelsMargin, PanelsMargin);
            panel2.Location = new Point(SplitPoint + HoldSpace / 2, PanelsMargin);

            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            Refresh();
        }

        public FxSplitPanels()
        {
            InitializeComponent();

            //_spitPoint = Width / 2;

            InitPanels();
            UpdatePanels();

            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
        }

        private bool GetMouseInSplit(Point mouseP)
        {
            int halfs = (int)Math.Round((double)HoldSpace / 2.0);
            return (SplitPoint - halfs <= mouseP.X && mouseP.X <= SplitPoint + halfs && PanelsMargin <= mouseP.Y && mouseP.Y <= Height - PanelsMargin);
        }

        private void FxSplitPanels_Paint(object sender, PaintEventArgs e)
        {

            /*
            int w = Width - 1;
            int h = Height - 1;

            RectangleF p1r = new RectangleF(
                PanelsMargin,
                PanelsMargin,
                SplitPoint - HoldSpace / 2 - PanelsMargin * 2,
                h - PanelsMargin * 2
                );
            RectangleF p2r = new RectangleF(
                SplitPoint + HoldSpace / 2 + PanelsMargin,
                PanelsMargin,
                w - (SplitPoint + HoldSpace) - PanelsMargin * 2,
                h - PanelsMargin * 2
                );

            RectangleF[] r = { p1r, p2r };

            e.Graphics.DrawRectangles(borderPen, r);
            */

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
            Refresh();
        }

        private void FxSplitPanels_Resize(object sender, EventArgs e)
        {
            UpdatePanels();
        }

        private void FxSplitPanels_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                Cursor = SplitCursor;
                SplitPoint = e.X;
                UpdatePanels();
            }
            else if (GetMouseInSplit(e.Location))
            {
                Cursor = SplitCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void FxSplitPanels_MouseDown(object sender, MouseEventArgs e)
        {
            if (GetMouseInSplit(e.Location)) MouseIsDown = true;
        }

        private void FxSplitPanels_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void FxSplitPanels_MouseEnter(object sender, EventArgs e)
        {

        }

        private void FxSplitPanels_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
