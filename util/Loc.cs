using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util
{
    public static class Loc
    {
        public static string[] locSplit(this string path)
        {
            return path.Split('/', '\\');
        }

        public static void locPush(this string path, int cnt, Func<string, bool> exist, Action<string> delete, Action<string, string> move, string sep = null)
        {
            var trk = path.locTrunk();
            var ext = path.locExt();
            var lastPath = $"{trk}{sep}{cnt}{ext}";
            if (exist(lastPath))
                delete(lastPath);
            while (cnt > 1)
            {
                var bakPath = $"{trk}{sep}{cnt - 1}{ext}";
                if (exist(bakPath))
                    move(bakPath, $"{trk}{sep}{cnt}{ext}");
                cnt--;
            }
            if (exist(path))
                move(path, $"{trk}{sep}{1}{ext}");
        }

        public static string locSettle(this string path, Func<string, bool> exist, string sep = null)
        {
            if (exist(path) == false)
                return path;
            var trk = path.locTrunk();
            var ext = path.locExt();
            int idx = 1;
            while (true)
            {
                var newPath = $"{trk}{sep}{idx++}{ext}";
                if (exist(newPath) == false)
                    return newPath;
            }
        }

        public static string locUnify(this string path)
        {
            if (null == path)
                return null;
            var nodes = path.Split('/', '\\');
            var buff = new StringBuilder();
            foreach (var nd in nodes)
            {
                var item = nd.Trim();
                if (item.Length > 0)
                {
                    if (buff.Length > 0)
                        buff.Append('/');
                    buff.Append(item);
                }
            }
            return buff.ToString();
        }

        public static string locDir(this string path)
        {
            if (null == path)
                return null;
            var pos = path.LastIndexOf("/");
            if (-1 == pos)
                return null;
            return path.Substring(0, pos);
        }

        public static string locName(this string path)
        {
            if (null == path)
                return null;
            int pos = path.LastIndexOf('/');
            if (pos == -1)
                return path;
            return path.Substring(pos + 1, path.Length - pos - 1);
        }

        public static string locTrunk(this string path)
        {
            if (null == path)
                return null;
            var pos = path.Length - 1;
            pos = path.LastIndexOf('.', pos, pos - path.LastIndexOf('/'));
            if (pos == -1)
                return path;
            return path.Substring(0, pos);
        }

        public static string locExt(this string path)
        {
            if (null == path)
                return null;
            var pos = path.Length - 1;
            pos = path.LastIndexOf('.', pos, pos - path.LastIndexOf('/'));
            if (pos == -1)
                return null;
            return path.Substring(pos, path.Length - pos);
        }

        public static string locMerge(this string first, string second, params string[] others)
        {
            if (others.Length == 0)
                return $"{first}/{second}";
            else
                return $"{first}/{second}/{string.Join("/", others)}";
        }
    }
}
