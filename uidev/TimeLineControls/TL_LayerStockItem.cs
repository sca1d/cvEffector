using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.TimeLineControls
{
    public partial class TL_LayerStockItem : Control
    {

        private bool _hide = false;
        public bool Hide
        {
            get
            {
                return _hide;
            }
            set
            {
                _hide = value;
                Refresh();
            }
        }

        public TL_LayerStockItem()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

    }
}
