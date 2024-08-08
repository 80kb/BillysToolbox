using kartlib.Imaging.Formats;
using kartlib.Serial;
using System.Drawing;

namespace kartlib.Imaging
{
    public static class ImageFactory
    {
        public static ImageFormat? GetFormat(ImageFormatEnum format)
        {
            switch (format)
            {
                case ImageFormatEnum.I4:
                    return new I4();
                case ImageFormatEnum.I8:
                    return new I8();
                case ImageFormatEnum.IA4:
                    return new IA4();
                case ImageFormatEnum.IA8:
                    return new IA8();
                default:
                    return null;
            }
        }
    }
}
