using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace uidev.Controls
{
    //[Designer(typeof(Designs.FxSplitPanelsDesigner), typeof(IRootDesigner))]
    [Designer(typeof(Designs.oldFxSplitPanelsDesigner))]
    public partial class oldFxSplitPanels : FxBaseControl
    {
        private Pen borderPen = Class.uiCustoms.BorderPen;

        private bool MouseIsDown = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel Panel1 = new Panel();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel Panel2 = new Panel();

        //public bool Visible { get; set; }

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
                Refresh();
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
                Refresh();
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

        private void InitPanels()
        {
            // /*
            Panel1.Size = new Size(SplitPoint - HoldSpace, Height);
            Panel2.Size = new Size(SplitPoint - HoldSpace, Height);

            //fxPanel1.Location = new Point(0, 0);
            Panel2.Location = new Point(SplitPoint + HoldSpace / 2, 0);

            Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            // */

            Refresh();
        }

        public oldFxSplitPanels()
        {
            InitializeComponent();

            _splitPoint = Width / 2;

            //Panel1.Visible = false;
            //Panel2.Visible = false;

            InitPanels();

            this.Controls.Add(Panel1);
            this.Controls.Add(Panel2);

            TypeDescriptor.AddAttributes(this.Panel1, new DesignerAttribute(typeof(Designs.oldPanelDesigner)));
            TypeDescriptor.AddAttributes(this.Panel2, new DesignerAttribute(typeof(Designs.oldPanelDesigner)));
        }

        private void FxSplitPanels_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawLine(
                borderPen,
                new PointF((float)SplitPoint - (float)HoldSpace / 2F, 0),
                new PointF((float)SplitPoint - (float)HoldSpace / 2F, Height)
                );

            e.Graphics.DrawLine(
                borderPen,
                new PointF((float)SplitPoint + (float)HoldSpace / 2F, 0),
                new PointF((float)SplitPoint + (float)HoldSpace / 2F, Height)
                );

            if (Border)
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void FxSplitPanels_EnabledChanged(object sender, EventArgs e)
        {
            Color _borderColor = Class.uiCustoms.BorderPen.Color;

            if (!Enabled)
            {
                borderPen = new Pen(Class.Tools.rgb2gray(_borderColor));
            }
            else
            {
                borderPen = new Pen(_borderColor);
            }
            Refresh();
        }

        private void FxSplitPanels_Resize(object sender, EventArgs e)
        {
            InitPanels();
        }
        private void FxSplitPanels_SizeChanged(object sender, EventArgs e)
        {
            InitPanels();
        }

        private bool GetMouseInSplit(int mouseX)
        {
            int halfs = (int)Math.Round((double)HoldSpace / 2.0);
            return (SplitPoint - halfs <= mouseX && mouseX <= SplitPoint + halfs);
        }

        private void FxSplitPanels_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                Cursor = SplitCursor;
                SplitPoint = e.Location.X;
                InitPanels();
            }
            else if (GetMouseInSplit(e.Location.X))
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
            if (GetMouseInSplit(e.Location.X) && e.Button == MouseButtons.Left) MouseIsDown = true;
        }

        private void FxSplitPanels_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }
    }
}
