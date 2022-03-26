using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.Interface
{
    public class FxInternalPanel : Controls.FxPanel
    {

        new public DockStyle Dock { get { return base.Dock; } }
        
        new public AnchorStyles Anchor { get { return base.Anchor; } }

        new public Size Size { get { return base.Size; } }

        new public Point Location { get { return base.Location; } }

        new public int Width { get { return base.Width; } }

        new public int Height { get { return base.Height; } }

        new public Size MinimumSize { get { return base.MinimumSize; } }

        new public Size MaximumSize { get { return base.MaximumSize; } }

        new public bool AutoSize { get { return base.AutoSize; } }

        new public AutoSizeMode AutoSizeMode { get { return base.AutoSizeMode; } }

        new public bool Visible { get { return base.Visible; } }

        new public bool Enabled { get { return base.Enabled; } }

    }
}
