
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
            this.fxCombo1 = new uidev.Controls.FxCombo();
            this.fxButton1 = new uidev.Controls.FxButton();
            this.fxButton2 = new uidev.Controls.FxButton();
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.fxCheckbox1 = new uidev.Controls.FxCheckbox();
            this.fxPanel1 = new uidev.Controls.FxPanel();
            this.fxSlider2 = new uidev.Controls.FxSlider();
            this.tL_LayerItem1 = new uidev.TimeLineControls.TL_LayerItem();
            this.fxMenu1.SuspendLayout();
            this.fxPanel1.SuspendLayout();
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
            // fxCombo1
            // 
            this.fxCombo1.Border = true;
            this.fxCombo1.Location = new System.Drawing.Point(3, 3);
            this.fxCombo1.Menu = this.fxMenu1;
            this.fxCombo1.Name = "fxCombo1";
            this.fxCombo1.popup_menu = this.fxMenu1;
            this.fxCombo1.Size = new System.Drawing.Size(121, 34);
            this.fxCombo1.TabIndex = 1;
            this.fxCombo1.Text = "fxCombo1";
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(233, 341);
            this.fxButton1.Menu = null;
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(104, 30);
            this.fxButton1.TabIndex = 2;
            this.fxButton1.Text = "Enabled : true";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
            // 
            // fxButton2
            // 
            this.fxButton2.Border = true;
            this.fxButton2.Location = new System.Drawing.Point(127, 3);
            this.fxButton2.Menu = null;
            this.fxButton2.Name = "fxButton2";
            this.fxButton2.Size = new System.Drawing.Size(138, 34);
            this.fxButton2.TabIndex = 4;
            this.fxButton2.Text = "fxButton2";
            // 
            // fxSlider1
            // 
            this.fxSlider1.Border = true;
            this.fxSlider1.Location = new System.Drawing.Point(3, 43);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.Menu = null;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(121, 34);
            this.fxSlider1.TabIndex = 5;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // fxCheckbox1
            // 
            this.fxCheckbox1.Border = true;
            this.fxCheckbox1.Location = new System.Drawing.Point(130, 43);
            this.fxCheckbox1.Menu = null;
            this.fxCheckbox1.Name = "fxCheckbox1";
            this.fxCheckbox1.Size = new System.Drawing.Size(135, 34);
            this.fxCheckbox1.TabIndex = 6;
            this.fxCheckbox1.Text = "fxCheckbox1";
            this.fxCheckbox1.Value = false;
            // 
            // fxPanel1
            // 
            this.fxPanel1.Border = true;
            this.fxPanel1.Controls.Add(this.tL_LayerItem1);
            this.fxPanel1.Controls.Add(this.fxCombo1);
            this.fxPanel1.Controls.Add(this.fxButton2);
            this.fxPanel1.Controls.Add(this.fxCheckbox1);
            this.fxPanel1.Controls.Add(this.fxSlider1);
            this.fxPanel1.Location = new System.Drawing.Point(233, 139);
            this.fxPanel1.Menu = null;
            this.fxPanel1.Name = "fxPanel1";
            this.fxPanel1.Size = new System.Drawing.Size(268, 196);
            this.fxPanel1.TabIndex = 7;
            // 
            // fxSlider2
            // 
            this.fxSlider2.Border = false;
            this.fxSlider2.Location = new System.Drawing.Point(283, 91);
            this.fxSlider2.MaximumValue = 100;
            this.fxSlider2.Menu = null;
            this.fxSlider2.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider2.MinimumValue = 0;
            this.fxSlider2.Name = "fxSlider2";
            this.fxSlider2.Size = new System.Drawing.Size(131, 15);
            this.fxSlider2.TabIndex = 8;
            this.fxSlider2.Text = "fxSlider2";
            this.fxSlider2.Value = 0;
            // 
            // tL_LayerItem1
            // 
            this.tL_LayerItem1.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem1.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.frame_width = 60;
            this.tL_LayerItem1.Location = new System.Drawing.Point(3, 83);
            this.tL_LayerItem1.Menu = null;
            this.tL_LayerItem1.Name = "tL_LayerItem1";
            this.tL_LayerItem1.selected = false;
            this.tL_LayerItem1.Size = new System.Drawing.Size(262, 23);
            this.tL_LayerItem1.srart_frame = 0;
            this.tL_LayerItem1.TabIndex = 7;
            this.tL_LayerItem1.Text = "tL_LayerItem1";
            this.tL_LayerItem1.view_text = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.fxSlider2);
            this.Controls.Add(this.fxPanel1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "theta";
            this.fxMenu1.ResumeLayout(false);
            this.fxPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private uidev.Controls.FxMenu fxMenu1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private uidev.Controls.FxCombo fxCombo1;
        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxButton fxButton2;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.Controls.FxCheckbox fxCheckbox1;
        private uidev.Controls.FxPanel fxPanel1;
        private uidev.Controls.FxSlider fxSlider2;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem1;
    }
}

