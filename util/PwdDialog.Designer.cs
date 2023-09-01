namespace util
{
    partial class PwdDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwdDialog));
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.showIcon = new System.Windows.Forms.Label();
            this.fldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.newPwdUI = new System.Windows.Forms.TextBox();
            this.repeatPwdUI = new System.Windows.Forms.TextBox();
            this.newPwdLabel = new System.Windows.Forms.Label();
            this.repeatPwdLabel = new System.Windows.Forms.Label();
            this.msgUI = new System.Windows.Forms.Label();
            this.pwdIcon = new System.Windows.Forms.Label();
            this.newPwdIcon = new System.Windows.Forms.Label();
            this.hideIcon = new System.Windows.Forms.Label();
            this.pwdUI = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.fldsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okBtn.Location = new System.Drawing.Point(201, 21);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(137, 53);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(440, 21);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(137, 53);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Controls.Add(this.okBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancelBtn, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 305);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 95);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // showIcon
            // 
            this.showIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showIcon.Image = ((System.Drawing.Image)(resources.GetObject("showIcon.Image")));
            this.showIcon.Location = new System.Drawing.Point(645, 243);
            this.showIcon.Name = "showIcon";
            this.showIcon.Size = new System.Drawing.Size(32, 37);
            this.showIcon.TabIndex = 10;
            this.showIcon.Visible = false;
            // 
            // fldsLayout
            // 
            this.fldsLayout.ColumnCount = 3;
            this.fldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.fldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.fldsLayout.Controls.Add(this.pwdLabel, 0, 1);
            this.fldsLayout.Controls.Add(this.newPwdUI, 1, 2);
            this.fldsLayout.Controls.Add(this.repeatPwdUI, 1, 3);
            this.fldsLayout.Controls.Add(this.newPwdLabel, 0, 2);
            this.fldsLayout.Controls.Add(this.repeatPwdLabel, 0, 3);
            this.fldsLayout.Controls.Add(this.msgUI, 1, 0);
            this.fldsLayout.Controls.Add(this.pwdIcon, 2, 1);
            this.fldsLayout.Controls.Add(this.newPwdIcon, 2, 2);
            this.fldsLayout.Controls.Add(this.hideIcon, 2, 0);
            this.fldsLayout.Controls.Add(this.pwdUI, 1, 1);
            this.fldsLayout.Controls.Add(this.showIcon, 2, 3);
            this.fldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fldsLayout.Location = new System.Drawing.Point(10, 11);
            this.fldsLayout.Name = "fldsLayout";
            this.fldsLayout.RowCount = 4;
            this.fldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.fldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.fldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.fldsLayout.Size = new System.Drawing.Size(690, 294);
            this.fldsLayout.TabIndex = 12;
            // 
            // pwdLabel
            // 
            this.pwdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Location = new System.Drawing.Point(87, 114);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(63, 31);
            this.pwdLabel.TabIndex = 0;
            this.pwdLabel.Text = "Pwd";
            // 
            // newPwdUI
            // 
            this.newPwdUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newPwdUI.Location = new System.Drawing.Point(156, 178);
            this.newPwdUI.Name = "newPwdUI";
            this.newPwdUI.PasswordChar = '*';
            this.newPwdUI.Size = new System.Drawing.Size(483, 39);
            this.newPwdUI.TabIndex = 1;
            // 
            // repeatPwdUI
            // 
            this.repeatPwdUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatPwdUI.Location = new System.Drawing.Point(156, 242);
            this.repeatPwdUI.Name = "repeatPwdUI";
            this.repeatPwdUI.PasswordChar = '*';
            this.repeatPwdUI.Size = new System.Drawing.Size(483, 39);
            this.repeatPwdUI.TabIndex = 2;
            // 
            // newPwdLabel
            // 
            this.newPwdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.newPwdLabel.AutoSize = true;
            this.newPwdLabel.Location = new System.Drawing.Point(34, 182);
            this.newPwdLabel.Name = "newPwdLabel";
            this.newPwdLabel.Size = new System.Drawing.Size(116, 31);
            this.newPwdLabel.TabIndex = 6;
            this.newPwdLabel.Text = "NewPwd";
            // 
            // repeatPwdLabel
            // 
            this.repeatPwdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.repeatPwdLabel.AutoSize = true;
            this.repeatPwdLabel.Location = new System.Drawing.Point(6, 246);
            this.repeatPwdLabel.Name = "repeatPwdLabel";
            this.repeatPwdLabel.Size = new System.Drawing.Size(144, 31);
            this.repeatPwdLabel.TabIndex = 7;
            this.repeatPwdLabel.Text = "RepeatPwd";
            // 
            // msgUI
            // 
            this.msgUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgUI.Location = new System.Drawing.Point(156, 0);
            this.msgUI.Name = "msgUI";
            this.msgUI.Size = new System.Drawing.Size(483, 93);
            this.msgUI.TabIndex = 8;
            this.msgUI.Text = "label1\r\n这是第2行这是第3行这是第4行这是第5";
            this.msgUI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pwdIcon
            // 
            this.pwdIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pwdIcon.Image = ((System.Drawing.Image)(resources.GetObject("pwdIcon.Image")));
            this.pwdIcon.Location = new System.Drawing.Point(645, 111);
            this.pwdIcon.Name = "pwdIcon";
            this.pwdIcon.Size = new System.Drawing.Size(32, 37);
            this.pwdIcon.TabIndex = 10;
            this.pwdIcon.Click += new System.EventHandler(this.pwdIcon_Click);
            // 
            // newPwdIcon
            // 
            this.newPwdIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newPwdIcon.Image = ((System.Drawing.Image)(resources.GetObject("newPwdIcon.Image")));
            this.newPwdIcon.Location = new System.Drawing.Point(645, 179);
            this.newPwdIcon.Name = "newPwdIcon";
            this.newPwdIcon.Size = new System.Drawing.Size(32, 37);
            this.newPwdIcon.TabIndex = 11;
            this.newPwdIcon.Click += new System.EventHandler(this.newPwdIcon_Click);
            // 
            // hideIcon
            // 
            this.hideIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hideIcon.Image = ((System.Drawing.Image)(resources.GetObject("hideIcon.Image")));
            this.hideIcon.Location = new System.Drawing.Point(645, 28);
            this.hideIcon.Name = "hideIcon";
            this.hideIcon.Size = new System.Drawing.Size(32, 37);
            this.hideIcon.TabIndex = 9;
            this.hideIcon.Visible = false;
            // 
            // pwdUI
            // 
            this.pwdUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdUI.Location = new System.Drawing.Point(156, 110);
            this.pwdUI.Name = "pwdUI";
            this.pwdUI.PasswordChar = '*';
            this.pwdUI.Size = new System.Drawing.Size(483, 39);
            this.pwdUI.TabIndex = 0;
            // 
            // PwdDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(710, 400);
            this.Controls.Add(this.fldsLayout);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PwdDialog";
            this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PwdDialog";
            this.Activated += new System.EventHandler(this.PwdDialog_Activated);
            this.Load += new System.EventHandler(this.PwdDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.fldsLayout.ResumeLayout(false);
            this.fldsLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button okBtn;
        public System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TableLayoutPanel fldsLayout;
        private System.Windows.Forms.TextBox pwdUI;
        private System.Windows.Forms.TextBox newPwdUI;
        private System.Windows.Forms.TextBox repeatPwdUI;
        private System.Windows.Forms.Label msgUI;
        private System.Windows.Forms.Label hideIcon;
        private System.Windows.Forms.Label showIcon;
        private System.Windows.Forms.Label newPwdIcon;
        private System.Windows.Forms.Label pwdIcon;
        public System.Windows.Forms.Label pwdLabel;
        public System.Windows.Forms.Label newPwdLabel;
        public System.Windows.Forms.Label repeatPwdLabel;
    }
}