using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;

namespace util
{
    public static class Error
    {
        public static Action<Exception> notify = dlgNotify;

        public static void trydo(this object obj, Action func, Action<Exception> notify = null)
        {
            try { func(); }
            catch (Exception err)
            {
                //throw err;
                (notify ?? Error.notify)?.Invoke(err);
            }
        }

        static void dlgNotify(Exception err)
            => err.Message.dlgError();
    }
}
