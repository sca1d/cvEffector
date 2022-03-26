
namespace uidev.Controls
{
    partial class FxSplitPanels
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.fxPanel1 = new uidev.Controls.FxPanel();
            this.fxPanel2 = new uidev.Controls.FxPanel();
            this.SuspendLayout();
            // 
            // fxPanel1
            // 
            this.fxPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fxPanel1.Border = true;
            this.fxPanel1.Location = new System.Drawing.Point(0, 0);
            this.fxPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.fxPanel1.Menu = null;
            this.fxPanel1.Name = "fxPanel1";
            this.fxPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.fxPanel1.Size = new System.Drawing.Size(147, 179);
            this.fxPanel1.TabIndex = 1;
            // 
            // fxPanel2
            // 
            this.fxPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fxPanel2.Border = true;
            this.fxPanel2.Location = new System.Drawing.Point(150, 0);
            this.fxPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.fxPanel2.Menu = null;
            this.fxPanel2.Name = "fxPanel2";
            this.fxPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.fxPanel2.Size = new System.Drawing.Size(173, 179);
            this.fxPanel2.TabIndex = 0;
            // 
            // FxSplitPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fxPanel1);
            this.Controls.Add(this.fxPanel2);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FxSplitPanels";
            this.Size = new System.Drawing.Size(323, 179);
            this.SizeChanged += new System.EventHandler(this.FxSplitPanels_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FxSplitPanels_Paint);
            this.Resize += new System.EventHandler(this.FxSplitPanels_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        protected FxPanel fxPanel2;
        protected FxPanel fxPanel1;
    }
}
