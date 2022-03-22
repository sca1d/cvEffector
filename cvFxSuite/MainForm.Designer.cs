
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("c-0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("p-0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("p-1");
            this.fxButton1 = new uidev.Controls.FxButton();
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.fxTreeView1 = new uidev.Controls.FxTreeView();
            this.SuspendLayout();
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(78, 245);
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(134, 36);
            this.fxButton1.TabIndex = 1;
            this.fxButton1.Text = "fxButton1";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
            // 
            // fxSlider1
            // 
            this.fxSlider1.Border = false;
            this.fxSlider1.Location = new System.Drawing.Point(218, 245);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(134, 36);
            this.fxSlider1.TabIndex = 2;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // fxTreeView1
            // 
            this.fxTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fxTreeView1.Border = true;
            this.fxTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fxTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.fxTreeView1.Location = new System.Drawing.Point(342, 287);
            this.fxTreeView1.Name = "fxTreeView1";
            treeNode1.Name = "c0";
            treeNode1.Text = "c-0";
            treeNode2.Name = "p0";
            treeNode2.Text = "p-0";
            treeNode3.Name = "p1";
            treeNode3.Text = "p-1";
            this.fxTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.fxTreeView1.Size = new System.Drawing.Size(181, 135);
            this.fxTreeView1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.fxTreeView1);
            this.Controls.Add(this.fxSlider1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "cvEffector";
            this.ResumeLayout(false);

        }

        #endregion
        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.Controls.FxTreeView fxTreeView1;
    }
}

