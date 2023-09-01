namespace enote
{
    partial class OptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionDialog));
            this.propUI = new System.Windows.Forms.PropertyGrid();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.openDirBtn = new System.Windows.Forms.ToolStripButton();
            this.resetBtn = new System.Windows.Forms.ToolStripButton();
            this.descUI = new System.Windows.Forms.TextBox();
            this.splitUI = new System.Windows.Forms.Splitter();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // propUI
            // 
            this.propUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propUI.HelpVisible = false;
            this.propUI.LargeButtons = true;
            this.propUI.Location = new System.Drawing.Point(0, 49);
            this.propUI.Name = "propUI";
            this.propUI.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propUI.Size = new System.Drawing.Size(874, 498);
            this.propUI.TabIndex = 0;
            this.propUI.ToolbarVisible = false;
            // 
            // toolbar
            // 
            this.toolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDirBtn,
            this.resetBtn});
            this.toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Padding = new System.Windows.Forms.Padding(5);
            this.toolbar.Size = new System.Drawing.Size(874, 49);
            this.toolbar.TabIndex = 1;
            // 
            // openDirBtn
            // 
            this.openDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("openDirBtn.Image")));
            this.openDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openDirBtn.Name = "openDirBtn";
            this.openDirBtn.Size = new System.Drawing.Size(147, 36);
            this.openDirBtn.Text = "OpenDir";
            this.openDirBtn.Click += new System.EventHandler(this.openDirBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetBtn.Image")));
            this.resetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(114, 36);
            this.resetBtn.Text = "Reset";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // descUI
            // 
            this.descUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.descUI.Location = new System.Drawing.Point(0, 557);
            this.descUI.Multiline = true;
            this.descUI.Name = "descUI";
            this.descUI.Size = new System.Drawing.Size(874, 145);
            this.descUI.TabIndex = 2;
            // 
            // splitUI
            // 
            this.splitUI.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.splitUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitUI.Location = new System.Drawing.Point(0, 547);
            this.splitUI.Name = "splitUI";
            this.splitUI.Size = new System.Drawing.Size(874, 10);
            this.splitUI.TabIndex = 3;
            this.splitUI.TabStop = false;
            // 
            // OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 702);
            this.Controls.Add(this.propUI);
            this.Controls.Add(this.splitUI);
            this.Controls.Add(this.descUI);
            this.Controls.Add(this.toolbar);
            this.Name = "OptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.OptionDialog_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propUI;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton resetBtn;
        private System.Windows.Forms.TextBox descUI;
        private System.Windows.Forms.Splitter splitUI;
        private System.Windows.Forms.ToolStripButton openDirBtn;
    }
}