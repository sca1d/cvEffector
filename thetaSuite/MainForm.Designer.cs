
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
            this.fxButton1 = new uidev.Controls.FxButton();
            this.fxMenu1 = new uidev.Controls.FxMenu();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.fxCombo1 = new uidev.Controls.FxCombo();
            this.tL_LayerItem2 = new uidev.TimeLineControls.TL_LayerItem();
            this.tL_LayerItem1 = new uidev.TimeLineControls.TL_LayerItem();
            this.fxMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(12, 12);
            this.fxButton1.Menu = this.fxMenu1;
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(134, 36);
            this.fxButton1.TabIndex = 1;
            this.fxButton1.Text = "fxButton1";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
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
            // fxSlider1
            // 
            this.fxSlider1.Border = false;
            this.fxSlider1.Location = new System.Drawing.Point(12, 54);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.Menu = this.fxMenu1;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(134, 36);
            this.fxSlider1.TabIndex = 2;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // fxCombo1
            // 
            this.fxCombo1.Border = true;
            this.fxCombo1.Location = new System.Drawing.Point(12, 96);
            this.fxCombo1.Menu = null;
            this.fxCombo1.Name = "fxCombo1";
            this.fxCombo1.popup_menu = this.fxMenu1;
            this.fxCombo1.Size = new System.Drawing.Size(134, 36);
            this.fxCombo1.TabIndex = 5;
            this.fxCombo1.Text = "fxCombo1";
            // 
            // tL_LayerItem2
            // 
            this.tL_LayerItem2.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem2.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem2.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem2.frame_width = 60;
            this.tL_LayerItem2.Location = new System.Drawing.Point(704, 184);
            this.tL_LayerItem2.Menu = null;
            this.tL_LayerItem2.Name = "tL_LayerItem2";
            this.tL_LayerItem2.selected = false;
            this.tL_LayerItem2.Size = new System.Drawing.Size(171, 23);
            this.tL_LayerItem2.srart_frame = 0;
            this.tL_LayerItem2.TabIndex = 6;
            this.tL_LayerItem2.Text = "tL_LayerItem1";
            this.tL_LayerItem2.view_text = true;
            // 
            // tL_LayerItem1
            // 
            this.tL_LayerItem1.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem1.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.frame_width = 60;
            this.tL_LayerItem1.Location = new System.Drawing.Point(527, 184);
            this.tL_LayerItem1.Menu = this.fxMenu1;
            this.tL_LayerItem1.Name = "tL_LayerItem1";
            this.tL_LayerItem1.selected = false;
            this.tL_LayerItem1.Size = new System.Drawing.Size(171, 23);
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
            this.Controls.Add(this.tL_LayerItem1);
            this.Controls.Add(this.tL_LayerItem2);
            this.Controls.Add(this.fxCombo1);
            this.Controls.Add(this.fxSlider1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "theta";
            this.fxMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.Controls.FxCombo fxCombo1;
        private uidev.Controls.FxMenu fxMenu1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem2;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem1;
    }
}

