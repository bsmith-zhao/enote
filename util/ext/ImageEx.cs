using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encoder = System.Drawing.Imaging.Encoder;

namespace util.ext
{
    public static class ImageEx
    {
        // quality: 0 - 100
        // 0 best compress
        // 50 default
        // 100 best quality
        public static void convToJpeg(this Image img, Stream dst, long quality = 50L)
        {
            using (EncoderParameters args = new EncoderParameters(1))
            using (EncoderParameter arg = new EncoderParameter(Encoder.Quality, quality))
            {
                ImageCodecInfo ci = ImageCodecInfo
                                    .GetImageDecoders()
                                    .First(c => 
                                    c.FormatID == ImageFormat.Jpeg.Guid);
                args.Param[0] = arg;
                img.Save(dst, ci, args);
            }
        }

        //FileStream stream = new FileStream("new.jpg", FileMode.Create);
        //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //encoder.QualityLevel = 100;   // "100" for maximum quality (largest file size).
        //encoder.Frames.Add(BitmapFrame.Create(image));
        //encoder.Save(stream);
    }
}
