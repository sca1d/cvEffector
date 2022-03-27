
namespace uidev.Controls
{
    partial class FxTextbox
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
            this.components = new System.ComponentModel.Container();
            this.verticalBarTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // verticalBarTimer
            // 
            this.verticalBarTimer.Interval = 500;
            this.verticalBarTimer.Tick += new System.EventHandler(this.verticalBarTimer_Tick);
            // 
            // FxTextbox
            // 
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(50, 20);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FxTextbox_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FxTextbox_KeyDown);
            this.Leave += new System.EventHandler(this.FxTextbox_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FxTextbox_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer verticalBarTimer;
    }
}
