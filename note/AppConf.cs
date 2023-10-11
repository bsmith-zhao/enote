using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using util;
using util.ext;
using util.prop;

namespace enote
{
    public class AppConf : NoteConf
    {
        public bool ShowVerifyRtf { get; set; } = false;

        public JpegQuality JpgQuality { get; set; } = JpegQuality.Balance;
        public long getJpgQuality() => (long)JpgQuality;

        HashSet<string> imgExts = new HashSet<string>
        {
            "tif", "tiff",
            "bmp",
            "jpg", "jpeg",
            "gif",
            "png",
            "eps",
            "svg",
        };
        [TypeConverter(typeof(ArrayFormat<string>))]
        public string[] ImageExts
        {
            get => imgExts.ToArray();
            set
            {
                imgExts.Clear();
                value.each(ext => 
                {
                    ext = ext.Trim().TrimStart('.').ToLower();
                    if (ext.Length > 0)
                        imgExts.Add(ext);
                });
            }
        }

        [ByteSize, ReadOnly(true)]
        public string ImageLimit { get; set; } = "1M";
        public long imageLimit() => ImageLimit.byteSize();

        public bool isImage(string path)
        {
            var ext = path.locExt()?.TrimStart('.').ToLower();
            if (null == ext)
                return false;
            return imgExts.Contains(ext);
        }
    }

    public enum JpegQuality
    {
        BestCompress = 0,
        SuperCompress = 15,
        HighCompress = 30,
        Balance = 50,
        HighQuality = 70,
        SuperQuality = 85,
        BestQuality = 100,
    }
}
