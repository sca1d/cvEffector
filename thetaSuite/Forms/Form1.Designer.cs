
namespace thetaSuite.Forms
{
    partial class Form1
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
            this.fxSplitPanels1 = new uidev.Controls.FxSplitPanels();
            this.fxSplitPanels1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fxSplitPanels1
            // 
            this.fxSplitPanels1.Border = true;
            this.fxSplitPanels1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fxSplitPanels1.HoldSpace = 4;
            this.fxSplitPanels1.Location = new System.Drawing.Point(0, 0);
            this.fxSplitPanels1.Menu = null;
            this.fxSplitPanels1.Name = "fxSplitPanels1";
            this.fxSplitPanels1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // fxSplitPanels1.Panel1
            // 
            this.fxSplitPanels1.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fxSplitPanels1.Panel1.Border = true;
            this.fxSplitPanels1.Panel1.Enabled = true;
            this.fxSplitPanels1.Panel1.Location = new System.Drawing.Point(3, 3);
            this.fxSplitPanels1.Panel1.Menu = null;
            this.fxSplitPanels1.Panel1.Name = "Panel1";
            this.fxSplitPanels1.Panel1.Size = new System.Drawing.Size(495, 396);
            this.fxSplitPanels1.Panel1.TabIndex = 0;
            this.fxSplitPanels1.Panel1.Visible = true;
            // 
            // fxSplitPanels1.Panel2
            // 
            this.fxSplitPanels1.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fxSplitPanels1.Panel2.Border = true;
            this.fxSplitPanels1.Panel2.Enabled = true;
            this.fxSplitPanels1.Panel2.Location = new System.Drawing.Point(502, 3);
            this.fxSplitPanels1.Panel2.Menu = null;
            this.fxSplitPanels1.Panel2.Name = "Panel2";
            this.fxSplitPanels1.Panel2.Size = new System.Drawing.Size(387, 396);
            this.fxSplitPanels1.Panel2.TabIndex = 1;
            this.fxSplitPanels1.Panel2.Visible = true;
            this.fxSplitPanels1.PanelMinimumSize = 10;
            this.fxSplitPanels1.PanelsMargin = 3;
            this.fxSplitPanels1.Size = new System.Drawing.Size(892, 402);
            this.fxSplitPanels1.SplitCursorHorizon = System.Windows.Forms.Cursors.SizeNS;
            this.fxSplitPanels1.SplitCursorVertical = System.Windows.Forms.Cursors.SizeWE;
            this.fxSplitPanels1.SplitPoint = 500;
            this.fxSplitPanels1.TabIndex = 1;
            this.fxSplitPanels1.Text = "fxSplitPanels1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(892, 402);
            this.Controls.Add(this.fxSplitPanels1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.dockPanel, 0);
            this.Controls.SetChildIndex(this.fxSplitPanels1, 0);
            this.fxSplitPanels1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private uidev.Controls.FxSplitPanels fxSplitPanels1;
    }
}
