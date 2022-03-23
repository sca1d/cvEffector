using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidev.Class
{
    public partial class DarkColor : ToolStripProfessionalRenderer
    {
        public DarkColor()
        {

        }

        private Color foreColor;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="colorTable"></param>
        public DarkColor(ProfessionalColorTable colorTable)
            : this(SystemColors.ControlText, colorTable)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="foreColor"></param>
        /// <param name="colorTable"></param>
        public DarkColor(Color foreColor, ProfessionalColorTable colorTable)
            : base(colorTable)
        {
            this.foreColor = foreColor;
        }

        /// <summary>
        /// メニューの色設定
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = this.foreColor;
            base.OnRenderItemText(e);
        }

        /// <summary>
        /// OnRenderMenuItemBackground
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            e.Item.ForeColor = this.foreColor;
            base.OnRenderMenuItemBackground(e);
        }

        /// <summary>
        /// OnRenderToolStripBorder
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);

            ToolStrip toolStrip = e.ToolStrip;
            if (toolStrip is StatusStrip)
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(45, 45, 48)), 0, 0, e.ToolStrip.Width, 0);
            }
        }
    }
}
