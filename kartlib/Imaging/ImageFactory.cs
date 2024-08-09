using kartlib.Imaging.Formats;

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
                case ImageFormatEnum.RGB565:
                    return new RGB565();
                case ImageFormatEnum.RGB5A3:
                    return new RGB5A3();
                case ImageFormatEnum.RGBA8:
                    return new RGBA8();
                default:
                    return null;
            }
        }
    }
}
