using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace util.ext
{
    public static class ToolStripEx
    {
        public static void fixBorderBug(this ToolStrip tb)
        {
            tb.Paint += ToolStrip_Paint;
        }

        static void ToolStrip_Paint(object sender, PaintEventArgs e)
        {
            var tb = sender as ToolStrip;
            var rec = new Rectangle(2, 0, tb.Width - 4, tb.Height - 2);
            e.Graphics.SetClip(rec);
        }
    }
}
