using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using uidev.Class;
using uidev.Controls;
using uidev.Interface;
using uidev.TimeLineControls;

namespace uidev.Controls
{
    public partial class FxCombo : FxBaseControl
    {

        public delegate void PopupEvent(EventArgs e);
        public PopupEvent Popup;

        private FxMenu _popupMenu;
        public FxMenu popup_menu
        {
            get
            {
                return _popupMenu;
            }
            set
            {
                _popupMenu = value;
                value.Opening += PopupOpening;
                value.Closed += Popup_Closed;
            }
        }

        private const int space = 4;

        private bool InMouse = false;
        private bool DownMouse = false;
        private bool TrueThisOpenes = false;
        private bool OpeningMenu = false;

        public FxCombo()
        {
            InitializeComponent();
        }

        private void FxCombo_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = uiCustoms.SmoothingMode;

            Color   back_color = uiCustoms.BackColor,
                    main_color = uiCustoms.MainColor;

            if (DownMouse || (OpeningMenu && TrueThisOpenes))
            {
                back_color = uiCustoms.ClickColor;
                main_color = uiCustoms.BackColor;
            }

            if (InMouse && !DownMouse && !OpeningMenu)
            {
                back_color = uiCustoms.DashColor;
                main_color = uiCustoms.BackColor;
            }

            e.Graphics.Clear(back_color);

            string t = DrawManager.ChangeTextSize(this.Text, Width - (1 + space * 2 + 8));
            TextRenderer.DrawText(
                e.Graphics,
                t,
                uiCustoms.Font,
                new Point(space, Height / 2),
                main_color,
                TextFormatFlags.VerticalCenter
                );

            float   w = Width - 1F,
                    h = Height - 1F;

            System.Drawing.PointF[] dps = new System.Drawing.PointF[4];
            dps[0] = new System.Drawing.PointF(w - 4F, h / 2F - 2.25F);
            dps[1] = new System.Drawing.PointF(w - 8.5F, h / 2F + 2.25F);
            dps[2] = new System.Drawing.PointF(w - 13F, h / 2F - 2.25F);
            dps[3] = dps[1];

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.DrawPolygon(new Pen(main_color, 1.3F), dps);

            if (Border) e.Graphics.DrawRectangle(new Pen(main_color), 0, 0, Width - 1, Height - 1);

        }
        
        private void PopupOpening(object sender, CancelEventArgs e)
        {
            OpeningMenu = true;
            Refresh();
        }
        private void Popup_Closed(object sender, EventArgs e)
        {
            OpeningMenu = false;
            TrueThisOpenes = false;
            Refresh();
        }

        private void FxCombo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DownMouse = true;
                if (popup_menu != null)
                {
                    TrueThisOpenes = true;
                    popup_menu.Show(this, new Point(0, Height - 1));
                }
                Popup?.Invoke(new EventArgs());
            }
            Refresh();
        }

        private void FxCombo_MouseUp(object sender, MouseEventArgs e)
        {
            DownMouse = false;
            Refresh();
        }

        private void FxCombo_MouseEnter(object sender, EventArgs e)
        {
            InMouse = true;
            Refresh();
        }

        private void FxCombo_MouseLeave(object sender, EventArgs e)
        {
            InMouse = false;
            Refresh();
        }

    }
}
