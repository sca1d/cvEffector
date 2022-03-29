
namespace thetaSuite.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fxButton1 = new uidev.Controls.FxButton();
            this.fxControl1 = new uidev.Controls.FxControl();
            this.SuspendLayout();
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(286, 240);
            this.fxButton1.Menu = null;
            this.fxButton1.Name = "fxButton1";
            this.fxButton1.Size = new System.Drawing.Size(75, 23);
            this.fxButton1.TabIndex = 0;
            this.fxButton1.Text = "file open";
            this.fxButton1.Click += new System.EventHandler(this.fxButton1_Click);
            // 
            // fxControl1
            // 
            this.fxControl1.Border = true;
            this.fxControl1.Location = new System.Drawing.Point(286, 49);
            this.fxControl1.Menu = null;
            this.fxControl1.Name = "fxControl1";
            this.fxControl1.Size = new System.Drawing.Size(298, 185);
            this.fxControl1.TabIndex = 1;
            this.fxControl1.Text = "fxControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 575);
            this.Controls.Add(this.fxControl1);
            this.Controls.Add(this.fxButton1);
            this.Name = "MainForm";
            this.Text = "theta";
            this.ResumeLayout(false);

        }

        #endregion

        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxControl fxControl1;
    }
}