using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace kartlib.Img
{
    public class I4
    {
        public const int BitsPerPixel   = 4;
        public const int BlockWidth     = 8;
        public const int BlockHeight    = 8;
        public const int BlockSize      = 32;

        public static Bitmap ToBitmap(byte[] buffer, int width, int height)
        {
            Bitmap result = new(width, height);

            // Calculate amount of blocks
            int cols = width / BlockWidth;
            int rows = height / BlockHeight;
            int blockCount = cols * rows;

            Func<byte[], Color> operation = (x) =>
            {
                int value = BitConverter.ToInt32(x, 0);
                return Color.FromArgb(0xFF, value, value, value);
            };

            // Convert to bitmap
            for(int block = 0; block < blockCount; block++)
            {
                int blockStart = (BlockWidth * BlockHeight) * block;
                for(int c = blockStart; c < BlockWidth; c++)
                for(int r = blockStart; r < BlockHeight; r++)
                {
                    Debug.WriteLine("<" + c + ", " + r + ">");
                    //byte[] pixel = new byte[BitsPerPixel];
                    //result.SetPixel(c, r, operation())
                }
            }

            return result;
        }
    }
}
