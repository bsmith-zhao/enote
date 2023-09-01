using util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using util.ext;
using System.Drawing;

namespace util
{
    public static class Dialog
    {
        public static bool pickFile(out string path, string filter = null)
        {
            path = null;
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = filter
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return false;

            path = dlg.FileName;
            return true;
        }

        public static string saveFile(string filter = null, string name = null)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = filter,
                FileName = name,
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return null;

            return dlg.FileName;
        }

        public static bool saveFile(out string path, string filter = null, string name = null)
        {
            return (path = saveFile(filter, name)) != null;
        }

        public static bool confirm(this string msg)
        {
            return MessageBox.Show(msg, "Confirm", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void dlgInfo(this string msg)
        {
            MessageBox.Show(msg, "Info", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        public static void dlgAlert(this string msg)
        {
            MessageBox.Show(msg, "Alert", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Exclamation);
        }

        public static void dlgError(this string msg)
        {
            MessageBox.Show(msg, "Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Exclamation);
        }

        public static bool pickColor(this Control ui, out Color value, Color old = default(Color))
        {
            value = old;
            var dlg = new ColorDialog
            {
                Color = old,
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return false;

            value = dlg.Color;
            return true;
        }

        public static bool pickFont(this Control ui, out Font value, Font old = null)
        {
            value = old;
            var dlg = new FontDialog
            {
                Font = old,
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return false;

            value = dlg.Font;
            return true;
        }
    }
}
