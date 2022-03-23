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
    public partial class FxMenu : ContextMenuStrip
    {
        public FxMenu()
        {
            InitializeComponent();

            ToolStripProfessionalRenderer renderer = new Class.DarkColor(Color.FromArgb(241, 241, 241), new Class.VS2019ColorTable());
            renderer.RoundedEdges = false;
            ToolStripManager.Renderer = renderer;
            ToolStripManager.VisualStylesEnabled = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
