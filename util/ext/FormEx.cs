using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace util.ext
{
    public static class FormEx
    {
        public static string appPath(this Form form)
            => Application.ExecutablePath.locUnify();

        public static string appTrunk(this Form form)
            => form.appPath().locTrunk();

        public static string addDir(this Form form)
            => Application.StartupPath.locUnify();
    }
}
