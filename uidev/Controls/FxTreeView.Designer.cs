
namespace uidev.Controls
{
    partial class FxTreeView
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
            this.SuspendLayout();
            // 
            // FxTreeView
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.LineColor = System.Drawing.Color.Black;
            this.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.FxTreeView_DrawNode);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FxTreeView_NodeMouseClick);
            this.SizeChanged += new System.EventHandler(this.FxTreeView_SizeChanged);
            this.Click += new System.EventHandler(this.FxTreeView_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FxTreeView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FxTreeView_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
