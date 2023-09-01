using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.ext
{
    public static class FileEx
    {
        public static void bakSaveText(this string path, string text)
            => path.bakSaveText(fout => fout.Write(text));

        public static void bakSaveText(this string path, Action<TextWriter> func)
        {
            var tmp = $"{path}.tmp";
            using (var fout = File.CreateText(tmp))
            {
                func(fout);
            }
            var bak = $"{path}.bak";
            if (File.Exists(bak))
                File.Delete(bak);
            if (File.Exists(path))
                File.Move(path, bak);
            File.Move(tmp, path);
        }

        public static void bakSave(this string path, Action<Stream> func)
        {
            var tmp = $"{path}.tmp";
            using (var fout = File.Create(tmp))
            {
                func(fout);
            }
            var bak = $"{path}.bak";
            if (File.Exists(bak))
                File.Delete(bak);
            if (File.Exists(path))
                File.Move(path, bak);
            File.Move(tmp, path);
        }

        public static void dirOpen(this string dir)
        {
            dir = dir.Replace("/", "\\");
            Process.Start("explorer.exe", dir);
        }
    }
}
