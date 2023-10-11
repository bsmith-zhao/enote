namespace enote
{
    partial class NoteForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.topBar = new System.Windows.Forms.ToolStrip();
            this.optionBtn = new System.Windows.Forms.ToolStripButton();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.openBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.saveAsBtn = new System.Windows.Forms.ToolStripButton();
            this.viewCodeBtn = new System.Windows.Forms.ToolStripButton();
            this.verifyBtn = new System.Windows.Forms.ToolStripButton();
            this.foreColorBtn = new System.Windows.Forms.ToolStripButton();
            this.backColorBtn = new System.Windows.Forms.ToolStripButton();
            this.fontBtn = new System.Windows.Forms.ToolStripButton();
            this.noteUI = new System.Windows.Forms.RichTextBox();
            this.leftBar = new System.Windows.Forms.ToolStrip();
            this.setPwdBtn = new System.Windows.Forms.ToolStripButton();
            this.viewRtfBtn = new System.Windows.Forms.ToolStripButton();
            this.wordWrapBtn = new System.Windows.Forms.ToolStripButton();
            this.cutBtn = new System.Windows.Forms.ToolStripButton();
            this.copyBtn = new System.Windows.Forms.ToolStripButton();
            this.pasteBtn = new System.Windows.Forms.ToolStripButton();
            this.infoUI = new System.Windows.Forms.RichTextBox();
            this.infoSplit = new System.Windows.Forms.Splitter();
            this.topBar.SuspendLayout();
            this.leftBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.topBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionBtn,
            this.newBtn,
            this.openBtn,
            this.saveBtn,
            this.saveAsBtn,
            this.viewCodeBtn,
            this.verifyBtn,
            this.foreColorBtn,
            this.backColorBtn,
            this.fontBtn});
            this.topBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Padding = new System.Windows.Forms.Padding(5);
            this.topBar.Size = new System.Drawing.Size(1506, 80);
            this.topBar.TabIndex = 0;
            this.topBar.Text = "Toolbar";
            // 
            // optionBtn
            // 
            this.optionBtn.Image = ((System.Drawing.Image)(resources.GetObject("optionBtn.Image")));
            this.optionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(98, 67);
            this.optionBtn.Text = "Option";
            this.optionBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.optionBtn.Click += new System.EventHandler(this.setupBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(71, 67);
            this.newBtn.Text = "New";
            this.newBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Image = ((System.Drawing.Image)(resources.GetObject("openBtn.Image")));
            this.openBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(82, 67);
            this.openBtn.Text = "Open";
            this.openBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(72, 67);
            this.saveBtn.Text = "Save";
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveAsBtn
            // 
            this.saveAsBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAsBtn.Image")));
            this.saveAsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsBtn.Name = "saveAsBtn";
            this.saveAsBtn.Size = new System.Drawing.Size(100, 67);
            this.saveAsBtn.Text = "SaveAs";
            this.saveAsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveAsBtn.Click += new System.EventHandler(this.saveAsBtn_Click);
            // 
            // viewCodeBtn
            // 
            this.viewCodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewCodeBtn.Image")));
            this.viewCodeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewCodeBtn.Name = "viewCodeBtn";
            this.viewCodeBtn.Size = new System.Drawing.Size(133, 67);
            this.viewCodeBtn.Text = "ViewCode";
            this.viewCodeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.viewCodeBtn.Click += new System.EventHandler(this.viewCodeBtn_Click);
            // 
            // verifyBtn
            // 
            this.verifyBtn.Image = ((System.Drawing.Image)(resources.GetObject("verifyBtn.Image")));
            this.verifyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(84, 67);
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // foreColorBtn
            // 
            this.foreColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("foreColorBtn.Image")));
            this.foreColorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.foreColorBtn.Name = "foreColorBtn";
            this.foreColorBtn.Size = new System.Drawing.Size(130, 67);
            this.foreColorBtn.Text = "ForeColor";
            this.foreColorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.foreColorBtn.Click += new System.EventHandler(this.foreColorBtn_Click);
            // 
            // backColorBtn
            // 
            this.backColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("backColorBtn.Image")));
            this.backColorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backColorBtn.Name = "backColorBtn";
            this.backColorBtn.Size = new System.Drawing.Size(132, 67);
            this.backColorBtn.Text = "BackColor";
            this.backColorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.backColorBtn.Click += new System.EventHandler(this.backColorBtn_Click);
            // 
            // fontBtn
            // 
            this.fontBtn.Image = ((System.Drawing.Image)(resources.GetObject("fontBtn.Image")));
            this.fontBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontBtn.Name = "fontBtn";
            this.fontBtn.Size = new System.Drawing.Size(70, 67);
            this.fontBtn.Text = "Font";
            this.fontBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.fontBtn.Click += new System.EventHandler(this.fontBtn_Click);
            // 
            // noteUI
            // 
            this.noteUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteUI.Location = new System.Drawing.Point(147, 80);
            this.noteUI.Name = "noteUI";
            this.noteUI.Size = new System.Drawing.Size(884, 772);
            this.noteUI.TabIndex = 2;
            this.noteUI.Text = "";
            // 
            // leftBar
            // 
            this.leftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.leftBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.leftBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPwdBtn,
            this.viewRtfBtn,
            this.wordWrapBtn,
            this.cutBtn,
            this.copyBtn,
            this.pasteBtn});
            this.leftBar.Location = new System.Drawing.Point(0, 80);
            this.leftBar.Name = "leftBar";
            this.leftBar.Size = new System.Drawing.Size(147, 772);
            this.leftBar.TabIndex = 3;
            // 
            // setPwdBtn
            // 
            this.setPwdBtn.Image = ((System.Drawing.Image)(resources.GetObject("setPwdBtn.Image")));
            this.setPwdBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setPwdBtn.Name = "setPwdBtn";
            this.setPwdBtn.Size = new System.Drawing.Size(144, 36);
            this.setPwdBtn.Text = "SetPwd";
            this.setPwdBtn.Click += new System.EventHandler(this.setPwdBtn_Click);
            // 
            // viewRtfBtn
            // 
            this.viewRtfBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewRtfBtn.Image")));
            this.viewRtfBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewRtfBtn.Name = "viewRtfBtn";
            this.viewRtfBtn.Size = new System.Drawing.Size(144, 36);
            this.viewRtfBtn.Text = "ViewRtf";
            this.viewRtfBtn.Click += new System.EventHandler(this.viewRtfBtn_Click);
            // 
            // wordWrapBtn
            // 
            this.wordWrapBtn.CheckOnClick = true;
            this.wordWrapBtn.Image = ((System.Drawing.Image)(resources.GetObject("wordWrapBtn.Image")));
            this.wordWrapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wordWrapBtn.Name = "wordWrapBtn";
            this.wordWrapBtn.Size = new System.Drawing.Size(144, 36);
            this.wordWrapBtn.Text = "NoWrap";
            this.wordWrapBtn.Click += new System.EventHandler(this.noWrapBtn_Click);
            // 
            // cutBtn
            // 
            this.cutBtn.Image = ((System.Drawing.Image)(resources.GetObject("cutBtn.Image")));
            this.cutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(144, 36);
            this.cutBtn.Text = "Cut";
            this.cutBtn.Click += new System.EventHandler(this.cutBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Image = ((System.Drawing.Image)(resources.GetObject("copyBtn.Image")));
            this.copyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(144, 36);
            this.copyBtn.Text = "Copy";
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // pasteBtn
            // 
            this.pasteBtn.Image = ((System.Drawing.Image)(resources.GetObject("pasteBtn.Image")));
            this.pasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(144, 36);
            this.pasteBtn.Text = "Paste";
            this.pasteBtn.Click += new System.EventHandler(this.pasteBtn_Click);
            // 
            // infoUI
            // 
            this.infoUI.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoUI.Location = new System.Drawing.Point(1041, 80);
            this.infoUI.Name = "infoUI";
            this.infoUI.Size = new System.Drawing.Size(465, 772);
            this.infoUI.TabIndex = 4;
            this.infoUI.Text = "";
            // 
            // infoSplit
            // 
            this.infoSplit.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.infoSplit.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoSplit.Location = new System.Drawing.Point(1031, 80);
            this.infoSplit.MinSize = 0;
            this.infoSplit.Name = "infoSplit";
            this.infoSplit.Size = new System.Drawing.Size(10, 772);
            this.infoSplit.TabIndex = 5;
            this.infoSplit.TabStop = false;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 852);
            this.Controls.Add(this.noteUI);
            this.Controls.Add(this.infoSplit);
            this.Controls.Add(this.infoUI);
            this.Controls.Add(this.leftBar);
            this.Controls.Add(this.topBar);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "NoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EncryptNote";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.leftBar.ResumeLayout(false);
            this.leftBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip topBar;
        private System.Windows.Forms.ToolStripButton openBtn;
        private System.Windows.Forms.ToolStripButton saveBtn;
        private System.Windows.Forms.ToolStripButton saveAsBtn;
        private System.Windows.Forms.RichTextBox noteUI;
        private System.Windows.Forms.ToolStripButton fontBtn;
        private System.Windows.Forms.ToolStripButton backColorBtn;
        private System.Windows.Forms.ToolStripButton foreColorBtn;
        private System.Windows.Forms.ToolStrip leftBar;
        private System.Windows.Forms.RichTextBox infoUI;
        private System.Windows.Forms.Splitter infoSplit;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripButton viewRtfBtn;
        private System.Windows.Forms.ToolStripButton setPwdBtn;
        private System.Windows.Forms.ToolStripButton wordWrapBtn;
        private System.Windows.Forms.ToolStripButton verifyBtn;
        private System.Windows.Forms.ToolStripButton optionBtn;
        private System.Windows.Forms.ToolStripButton viewCodeBtn;
        private System.Windows.Forms.ToolStripButton cutBtn;
        private System.Windows.Forms.ToolStripButton copyBtn;
        private System.Windows.Forms.ToolStripButton pasteBtn;
    }
}

