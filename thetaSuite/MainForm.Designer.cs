
namespace thetaSuite
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.fxMenu1 = new uidev.Controls.FxMenu();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fxButton1 = new uidev.Controls.FxButton();
            this.fxPanel2 = new uidev.Controls.FxPanel();
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.fxPanel1 = new uidev.Controls.FxPanel();
            this.fxSplitPanels2 = new uidev.Controls.FxSplitPanels();
            this.fxButton2 = new uidev.Controls.FxButton();
            this.fxMenu1.SuspendLayout();
            this.fxPanel1.SuspendLayout();
            this.fxSplitPanels2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fxMenu1
            // 
            this.fxMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem});
            this.fxMenu1.Name = "fxMenu1";
            this.fxMenu1.Size = new System.Drawing.Size(100, 26);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.test1ToolStripMenuItem.Text = "test1";
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(182, 303);
            this.fxButton1.Menu = null;
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(104, 30);
            this.fxButton1.TabIndex = 2;
            this.fxButton1.Text = "Enabled : true";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
            // 
            // fxPanel2
            // 
            this.fxPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fxPanel2.Border = true;
            this.fxPanel2.Location = new System.Drawing.Point(152, 0);
            this.fxPanel2.Menu = null;
            this.fxPanel2.Name = "fxPanel2";
            this.fxPanel2.Size = new System.Drawing.Size(146, 282);
            this.fxPanel2.TabIndex = 1;
            // 
            // fxSlider1
            // 
            this.fxSlider1.Border = false;
            this.fxSlider1.Location = new System.Drawing.Point(0, 0);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.Menu = null;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(243, 32);
            this.fxSlider1.TabIndex = 3;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // fxPanel1
            // 
            this.fxPanel1.Border = true;
            this.fxPanel1.Controls.Add(this.fxSlider1);
            this.fxPanel1.Location = new System.Drawing.Point(182, 158);
            this.fxPanel1.Menu = null;
            this.fxPanel1.Name = "fxPanel1";
            this.fxPanel1.Size = new System.Drawing.Size(374, 139);
            this.fxPanel1.TabIndex = 4;
            // 
            // fxSplitPanels2
            // 
            this.fxSplitPanels2.Border = true;
            this.fxSplitPanels2.HoldSpace = 4;
            this.fxSplitPanels2.Location = new System.Drawing.Point(562, 158);
            this.fxSplitPanels2.Menu = null;
            this.fxSplitPanels2.Name = "fxSplitPanels2";
            this.fxSplitPanels2.PanelMinimumSize = 10;
            this.fxSplitPanels2.Size = new System.Drawing.Size(268, 190);
            this.fxSplitPanels2.SplitCursor = System.Windows.Forms.Cursors.SizeWE;
            this.fxSplitPanels2.SplitPoint = 150;
            this.fxSplitPanels2.TabIndex = 5;
            this.fxSplitPanels2.Text = "fxSplitPanels2";
            // 
            // fxButton2
            // 
            this.fxButton2.Border = true;
            this.fxButton2.Location = new System.Drawing.Point(78, 64);
            this.fxButton2.Menu = null;
            this.fxButton2.Name = "fxButton2";
            this.fxButton2.Size = new System.Drawing.Size(75, 23);
            this.fxButton2.TabIndex = 0;
            this.fxButton2.Text = "fxButton2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.fxSplitPanels2);
            this.Controls.Add(this.fxPanel1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "theta";
            this.fxMenu1.ResumeLayout(false);
            this.fxPanel1.ResumeLayout(false);
            this.fxSplitPanels2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private uidev.Controls.FxMenu fxMenu1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxSplitPanels fxSplitPanels1;
        private uidev.Controls.FxPanel fxPanel2;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.Controls.FxPanel fxPanel1;
        private uidev.Controls.FxSplitPanels fxSplitPanels2;
        private uidev.Controls.FxButton fxButton2;
    }
}

