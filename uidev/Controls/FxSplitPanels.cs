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

        #region COLORING DEFINE
        private Pen borderPen = Class.uiCustoms.BorderPen;
        #endregion

        private void InitPanels()
        {
            //panel1.Visible = true;
            //panel2.Visible = true;

            //panel1.BorderStyle = BorderStyle.FixedSingle;
            //panel2.BorderStyle;

            Refresh();
        }
        private void UpdatePanels()
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
            */

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

            //int p = Width / 2;
            //e.Graphics.DrawLine(borderPen, new Point(panel1.Width, panel1.Location.Y), new Point(panel1.Width, panel1.Location.Y + panel1.Height));

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
    }
}
