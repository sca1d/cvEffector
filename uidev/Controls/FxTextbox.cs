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
    public partial class FxTextbox : FxBaseControl
    {
        private Pen borderPen = Class.uiCustoms.BorderPen;

        private bool _textEntryMode = false;
        private bool textEntryMode
        {
            get
            {
                return _textEntryMode;
            }
            set
            {
                if (value)
                {
                    verticalBar = true;
                    verticalBarTimer.Start();
                }
                else
                {
                    verticalBarTimer.Stop();
                }
                _textEntryMode = value;
            }
        }

        // テキストを表示する余白
        private int textSpace = 3;

        private bool verticalBar = true;
        private int verticalBarPoint = 0;

        public FxTextbox()
        {
            InitializeComponent();
        }

        private Size GetTextSize(string text)
        {
            return TextRenderer.MeasureText(text, Class.uiCustoms.Font, Size, TextFormatFlags.NoPadding);
        }

        private int Mouse2StringPoint(int x)
        {
            if (0 < Text.Length)
            {
                if (1 < Text.Length)
                {
                    for (int i = 1; i <= Text.Length; i++)
                    {
                        int half = (int)Math.Round((double)GetTextSize(Text.Substring((i - 1), 1)).Width / 2.0);
                        if (x < GetTextSize(Text.Substring(0, i)).Width - half)
                        {
                            return i - 1;
                        }
                    }
                }
                return Text.Length;
            }
            return 0;
        }

        private void FxTextbox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Class.uiCustoms.DarkColor);

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Class.uiCustoms.Font,
                new Point(textSpace, Height / 2),
                Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding
                );

            Size tTextSize = TextRenderer.MeasureText(e.Graphics, Text, Class.uiCustoms.Font, Size, TextFormatFlags.NoPadding);

            if (textEntryMode)
            {
                if (verticalBar)
                {
                    int p = 0;

                    if (0 < verticalBarPoint)
                    {
                        p = TextRenderer.MeasureText(e.Graphics, Text.Substring(0, verticalBarPoint), Class.uiCustoms.Font, Size, TextFormatFlags.NoPadding).Width;
                    }

                    TextRenderer.DrawText(
                        e.Graphics,
                        "|",
                        Class.uiCustoms.Font,
                        new Point(p - 1, Height / 2),
                        Color.White,
                        TextFormatFlags.VerticalCenter
                        );
                }
            }

            if (Border)
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }
        }
        
        private void FxTextbox_MouseDown(object sender, MouseEventArgs e)
        {
            textEntryMode = true;

            if (textSpace <= e.X && e.X < GetTextSize(Text).Width + textSpace)
            {
                verticalBarPoint = Mouse2StringPoint(e.X);
            }
            else
            {
                if (e.X < textSpace)
                {
                    verticalBarPoint = 0;
                }
                else if (GetTextSize(Text).Width + textSpace <= e.X)
                {
                    verticalBarPoint = Text.Length;
                }
            }

            Refresh();
        }

        private void FxTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Enter:
                    textEntryMode = false;
                    break;
            }
            Refresh();
        }

        private void FxTextbox_Leave(object sender, EventArgs e)
        {
            textEntryMode = false;
            Refresh();
        }

        private void verticalBarTimer_Tick(object sender, EventArgs e)
        {
            verticalBar = !verticalBar;
            Refresh();
        }
    }
}
