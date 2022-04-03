
namespace thetaSuite.Forms
{
    partial class TestForm
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
            this.fxSlider1 = new uidev.Controls.FxSlider();
            this.fxPanel1 = new uidev.Controls.FxPanel();
            this.tL_MainControl1 = new uidev.TimeLineControls.TL_MainControl();
            this.tL_LayerItem1 = new uidev.TimeLineControls.TL_LayerItem();
            this.fxPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Size = new System.Drawing.Size(1148, 575);
            // 
            // fxButton1
            // 
            this.fxButton1.Border = true;
            this.fxButton1.Location = new System.Drawing.Point(139, 266);
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
            this.fxControl1.Location = new System.Drawing.Point(139, 48);
            this.fxControl1.Menu = null;
            this.fxControl1.Name = "fxControl1";
            this.fxControl1.Size = new System.Drawing.Size(330, 185);
            this.fxControl1.TabIndex = 1;
            this.fxControl1.Text = "fxControl1";
            this.fxControl1.VisibleChanged += new System.EventHandler(this.fxControl1_VisibleChanged);
            this.fxControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.fxControl1_Paint);
            // 
            // fxSlider1
            // 
            this.fxSlider1.Border = false;
            this.fxSlider1.Enabled = false;
            this.fxSlider1.Location = new System.Drawing.Point(139, 239);
            this.fxSlider1.MaximumValue = 100;
            this.fxSlider1.Menu = null;
            this.fxSlider1.MinimumSize = new System.Drawing.Size(18, 14);
            this.fxSlider1.MinimumValue = 0;
            this.fxSlider1.MouseOnTheLineCursor = System.Windows.Forms.Cursors.Default;
            this.fxSlider1.Name = "fxSlider1";
            this.fxSlider1.Size = new System.Drawing.Size(298, 21);
            this.fxSlider1.TabIndex = 2;
            this.fxSlider1.Text = "fxSlider1";
            this.fxSlider1.Value = 0;
            // 
            // fxPanel1
            // 
            this.fxPanel1.Border = true;
            this.fxPanel1.Controls.Add(this.tL_MainControl1);
            this.fxPanel1.Controls.Add(this.tL_LayerItem1);
            this.fxPanel1.Controls.Add(this.fxSlider1);
            this.fxPanel1.Controls.Add(this.fxControl1);
            this.fxPanel1.Controls.Add(this.fxButton1);
            this.fxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fxPanel1.Location = new System.Drawing.Point(0, 0);
            this.fxPanel1.Menu = null;
            this.fxPanel1.Name = "fxPanel1";
            this.fxPanel1.Size = new System.Drawing.Size(1148, 575);
            this.fxPanel1.TabIndex = 3;
            // 
            // tL_MainControl1
            // 
            this.tL_MainControl1.Border = true;
            this.tL_MainControl1.Location = new System.Drawing.Point(139, 324);
            this.tL_MainControl1.Menu = null;
            this.tL_MainControl1.Name = "tL_MainControl1";
            this.tL_MainControl1.Size = new System.Drawing.Size(778, 172);
            this.tL_MainControl1.TabIndex = 4;
            this.tL_MainControl1.Text = "tL_MainControl1";
            // 
            // tL_LayerItem1
            // 
            this.tL_LayerItem1.clickColor = System.Drawing.Color.White;
            this.tL_LayerItem1.color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.enterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.tL_LayerItem1.frame_width = 60;
            this.tL_LayerItem1.Location = new System.Drawing.Point(139, 295);
            this.tL_LayerItem1.Menu = null;
            this.tL_LayerItem1.Name = "tL_LayerItem1";
            this.tL_LayerItem1.selected = false;
            this.tL_LayerItem1.Size = new System.Drawing.Size(298, 23);
            this.tL_LayerItem1.srart_frame = 0;
            this.tL_LayerItem1.TabIndex = 3;
            this.tL_LayerItem1.Text = "tL_LayerItem1";
            this.tL_LayerItem1.view_text = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 575);
            this.Controls.Add(this.fxPanel1);
            this.Name = "TestForm";
            this.Text = "theta";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Controls.SetChildIndex(this.dockPanel, 0);
            this.Controls.SetChildIndex(this.fxPanel1, 0);
            this.fxPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private uidev.Controls.FxButton fxButton1;
        private uidev.Controls.FxControl fxControl1;
        private uidev.Controls.FxSlider fxSlider1;
        private uidev.Controls.FxPanel fxPanel1;
        private uidev.TimeLineControls.TL_LayerItem tL_LayerItem1;
        private uidev.TimeLineControls.TL_MainControl tL_MainControl1;
    }
}