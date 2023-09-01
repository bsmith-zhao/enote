using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace util.ext
{
    public static class ControlEx
    {
        public static void setTextAsync(this Control ui, string text)
        {
            ui.callAsync(() => ui.Text = text);
        }

        public static R callWait<R>(this Control ui, Func<R> func)
        {
            if (ui.InvokeRequired)
                return (R)ui.Invoke(func);
            else
                return func();
        }

        public static void callAsync(this Control ui, Action func)
        {
            ui.call(false, func);
        }

        public static void callWait(this Control ui, Action func)
        {
            ui.call(true, func);
        }

        static void call(this Control ui, bool sync, Action func)
        {
            if (ui.InvokeRequired)
            {
                if (sync)
                    ui.Invoke(func);
                else
                    ui.BeginInvoke(func);
            }
            else
                func();
        }
    }
}
