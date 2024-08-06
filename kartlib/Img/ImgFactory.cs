using kartlib.Img.Formats;
using System.Drawing;

namespace kartlib.Img
{
    public static class ImgFactory
    {
        public static Bitmap ToBitmap(byte[] buffer, ImageFormat format, int width, int height)
        {
            Bitmap result = new(width, height);
            switch (format)
            {
                case ImageFormat.I4:
                    result = I4.ToBitmap(buffer, width, height);
                    break;
            }
            return result;
        }
    }
}
