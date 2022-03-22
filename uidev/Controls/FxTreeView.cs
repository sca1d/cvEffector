using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using uidev.Class;

namespace uidev.Controls
{
    public partial class FxTreeView : TreeView, Interface.FxUiBase
    {

        private Point mouseP;

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
            }
        }

        public void Init()
        {
            ///*
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //*/

            mouseP = Cursor.Position;
            this.BackColor = uiCustoms.BackColor;

            Class.uiCustoms.PropertyChanged += PropertiesChanged;
        }

        public FxTreeView()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(uiCustoms.BackColor);
            e.Graphics.DrawRectangle(uiCustoms.BorderPen, e.ClipRectangle);

        }

        private void PropertiesChanged(object sender, EventArgs e)
        {
            this.BackColor = uiCustoms.BackColor;
            Refresh();
        }

        private void FxTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Graphics g = e.Graphics;
            TreeNode n = e.Node;

            Console.WriteLine("Node name=" + n.Name + ", level=" + n.Level);

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                g.FillRectangle(new SolidBrush(uiCustoms.SelectColor), n.Bounds);

                TextRenderer.DrawText(
                    g,
                    n.Text,
                    uiCustoms.Font,
                    n.Bounds,
                    uiCustoms.ClickColor
                    );
            }
            else if (e.State == 0)
            {

                Console.WriteLine("mx:" + mouseP.X + ", bx:" + e.Bounds.X);

                if (e.Bounds.Width <= mouseP.X &&
                    e.Bounds.Height <= mouseP.Y)
                {
                    g.FillRectangle(new SolidBrush(uiCustoms.EnterColor), n.Bounds);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(uiCustoms.BackColor), n.Bounds);
                }

                TextRenderer.DrawText(
                    g,
                    n.Text,
                    uiCustoms.Font,
                    n.Bounds,
                    uiCustoms.ClickColor
                    );

                /*
                if (Border)
                {
                    e.Graphics.DrawRectangle(uiCustoms.BorderPen, -e.Bounds.X, -e.Bounds.Y, this.Size.Width - 1, this.Size.Height - 1);
                }
                */
            }

        }

        private void FxTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Console.WriteLine("Clicked:" + e.Node.Name);
        }

        private void FxTreeView_MouseMove(object sender, MouseEventArgs e)
        {
            mouseP = e.Location;
            Refresh();
        }

        private void FxTreeView_Click(object sender, EventArgs e)
        {

        }

        private void FxTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedNode = null;
            Refresh();
        }

        private void FxTreeView_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
