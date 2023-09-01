using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace util.ext
{
    public static class TextBoxEx
    {
        public static void loadRtf(this RichTextBox ui, Stream fin)
            => ui.LoadFile(fin, RichTextBoxStreamType.RichText);

        public static void saveRtf(this RichTextBox ui, Stream fout)
            => ui.SaveFile(fout, RichTextBoxStreamType.RichText);

        public static void enableZoom(this TextBox ui)
        {
            ui.MouseWheel += TextBox_MouseWheel;
        }

        private static void TextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            var ui = sender as TextBox;
            if ((Control.ModifierKeys & Keys.Control) == 0)
            {
                return;
            }
            var family = ui.Font.FontFamily;
            var size = ui.Font.Size;
            if (e.Delta > 0)
                ui.Font = new Font(family, size + 1);
            else if (size >= 8)
                ui.Font = new Font(family, size - 1);
        }

        public static void debugToMeAsync(this TextBoxBase ui)
            => Debug.output = ui.appendAsync;

        public static void logToMeAsync(this TextBoxBase ui)
            => Log.output = ui.appendAsync;

        public static void appendAsync(this TextBoxBase ui, object msg)
            => ui.callAsync(() => appendLine(ui, msg));

        static void appendLine(this TextBoxBase ui, object msg)
        {
            if (ui.Lines.Length > 200)
            {
                var text = ui.Text;
                var pos = text.Length / 2;
                pos = text.IndexOf("\r\n", pos) + 2;
                text = text.Substring(pos);
                ui.Text = text;
            }
            ui.AppendText((msg?.ToString() ?? "<null>") + "\r\n");
        }
    }
}
