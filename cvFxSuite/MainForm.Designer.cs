
namespace cvFxSuite
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
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.tL_LayerItem1 = new uidev.TimeLineControls.TL_LayerItem();
            this.tL_LayerItem2 = new uidev.TimeLineControls.TL_LayerItem();
            this.SuspendLayout();
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(12, 12);
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(134, 36);
            this.fxButton1.TabIndex = 1;
            this.fxButton1.Text = "fxButton1";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
            // 
            // fxSlider1
            // 
            this.fxSlider1.Border = false;
            this.fxSlider1.Location = new System.Drawing.Point(12, 54);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(134, 36);
            this.fxSlider1.TabIndex = 2;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // tL_LayerItem1
            // 
            this.tL_LayerItem1.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem1.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.frame_width = 60;
            this.tL_LayerItem1.Location = new System.Drawing.Point(573, 229);
            this.tL_LayerItem1.Name = "tL_LayerItem1";
            this.tL_LayerItem1.selected = true;
            this.tL_LayerItem1.Size = new System.Drawing.Size(178, 29);
            this.tL_LayerItem1.srart_frame = 0;
            this.tL_LayerItem1.TabIndex = 3;
            this.tL_LayerItem1.Text = "tL_LayerItem1";
            this.tL_LayerItem1.view_text = true;
            // 
            // tL_LayerItem2
            // 
            this.tL_LayerItem2.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem2.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem2.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem2.frame_width = 60;
            this.tL_LayerItem2.Location = new System.Drawing.Point(414, 229);
            this.tL_LayerItem2.Name = "tL_LayerItem2";
            this.tL_LayerItem2.selected = true;
            this.tL_LayerItem2.Size = new System.Drawing.Size(153, 29);
            this.tL_LayerItem2.srart_frame = 0;
            this.tL_LayerItem2.TabIndex = 4;
            this.tL_LayerItem2.Text = "tL_LayerItem2";
            this.tL_LayerItem2.view_text = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.tL_LayerItem2);
            this.Controls.Add(this.tL_LayerItem1);
            this.Controls.Add(this.fxSlider1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "cvEffector";
            this.ResumeLayout(false);

        }

        #endregion
        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem1;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem2;
    }
}

