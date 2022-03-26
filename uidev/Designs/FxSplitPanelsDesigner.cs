using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace uidev.Designs
{
    public class FxSplitPanelsDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            
            var panel1 = ((Controls.FxSplitPanels)this.Control).Panel1;
            var panel2 = ((Controls.FxSplitPanels)this.Control).Panel2;

            this.EnableDesignMode(panel1, "Panel1");
            this.EnableDesignMode(panel2, "Panel2");
        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {
            de.Effect = DragDropEffects.None;
        }
        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            return null;
        }
    }
}
