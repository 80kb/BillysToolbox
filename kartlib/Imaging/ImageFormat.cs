using System.Drawing;
using System.Drawing.Imaging;

namespace kartlib.Imaging
{
    public abstract class ImageFormat
    {
        public abstract int BitsPerPixel { get; }
        public abstract int BlockWidth { get; }
        public abstract int BlockHeight { get; }

        protected virtual uint[]? DecodePixels(byte[] buffer) { return null; }

        private byte[]? SortBlocks(byte[] buffer, int width, int height)
        {
            uint[]? formattedBuffer = DecodePixels(buffer);
            if (formattedBuffer == null)
                return null;

            List<byte> result = new List<byte>();
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    // crazy math!!
                    int a = (int)Math.Floor((double)x / BlockWidth) * BlockWidth * BlockHeight + (x % BlockWidth);
                    int b = y * BlockWidth + a;
                    int c = (int)Math.Floor((double)y / BlockHeight) * BlockWidth * BlockHeight * (width / BlockWidth - 1) + b;

                    result.AddRange( BitConverter.GetBytes(formattedBuffer[c]) );
                }
            }

            return result.ToArray();
        }

        public Bitmap? ToBitmap(byte[] buffer, int width, int height)
        {
            byte[]? formattedBuffer = SortBlocks(buffer, width, height);
            if(formattedBuffer == null) 
                return null;

            PixelFormat format = PixelFormat.Format32bppPArgb;
            Bitmap result = new Bitmap(width, height, format);
            BitmapData bitmapData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, format);
            System.Runtime.InteropServices.Marshal.Copy(formattedBuffer, 0, bitmapData.Scan0, formattedBuffer.Length);
            result.UnlockBits(bitmapData);
            return result;
        }
    }

    public enum ImageFormatEnum : uint
    {
        I4 = 0x00,
        I8 = 0x01,
        IA4 = 0x02,
        IA8 = 0x03,
        RGB565 = 0x04,
        RGB5A3 = 0x05,
        RGBA8 = 0x06,
        C4 = 0x08,
        C8 = 0x09,
        C14 = 0x0A,
        CMPR = 0x0E
    }
}
