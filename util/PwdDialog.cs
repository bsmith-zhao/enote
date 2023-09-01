using util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using util.ext;
using util.crypt;

namespace util
{
    public partial class PwdDialog : Form
    {
        public PwdDialog()
        {
            InitializeComponent();
        }

        private void PwdDialog_Load(object sender, EventArgs e)
        {
        }

        public bool verifyPwd(string msg, Action<byte[]> verify)
        {
            msgUI.Text = msg;
            hidePwdRows(1, 2);
            okBtn.Click += (s, e) =>
            {
                try
                {
                    verify(pwdUI.Text.utf8().sha256());

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception err)
                {
                    $"Verify error: {err.Message}".dlgError();
                }
            };
            return this.ShowDialog() == DialogResult.OK;
        }

        public byte[] setNewPwd(string msg)
        {
            msgUI.Text = msg;
            hidePwdRows(0);
            okBtn.Click += (s, e) =>
            {
                if (newPwdUI.Text != repeatPwdUI.Text)
                {
                    "New pwd and repeat not match!!".dlgError();
                    return;
                }
                this.DialogResult = DialogResult.OK;
                Close();
            };
            if (this.ShowDialog() == DialogResult.OK)
                return newPwdUI.Text.utf8().sha256();
            return null;
        }

        void hidePwdRows(params int[] rows)
        {
            float sum = 0;
            foreach (var idx in rows)
            {
                sum += hidePwdRow(idx);
            }
            this.Height -= (int)sum;
        }

        float hidePwdRow(int idx)
        {
            idx += 1;
            var tb = fldsLayout;
            var height = tb.RowStyles[idx].Height;
            tb.RowStyles[idx].Height = 0;
            for (int i = 0; i < tb.ColumnCount; i++)
            {
                var ui = tb.GetControlFromPosition(i, idx);
                if (null != ui)
                    ui.Visible = false;
            }
            return height;
        }

        private void pwdIcon_Click(object sender, EventArgs e)
        {
            if (pwdIcon.Image == showIcon.Image)
            {
                pwdUI.PasswordChar = '*';
                pwdIcon.Image = hideIcon.Image;
            }
            else
            {
                pwdUI.PasswordChar = new char();
                pwdIcon.Image = showIcon.Image;
            }
        }

        private void newPwdIcon_Click(object sender, EventArgs e)
        {
            if (newPwdIcon.Image == showIcon.Image)
            {
                newPwdUI.PasswordChar = '*';
                repeatPwdUI.PasswordChar = '*';
                newPwdIcon.Image = hideIcon.Image;
            }
            else
            {
                newPwdUI.PasswordChar = new char();
                repeatPwdUI.PasswordChar = new char();
                newPwdIcon.Image = showIcon.Image;
            }
        }

        private void PwdDialog_Activated(object sender, EventArgs e)
        {
            if (pwdUI.Visible)
                pwdUI.Focus();
            else
                newPwdUI.Focus();
        }
    }
}
