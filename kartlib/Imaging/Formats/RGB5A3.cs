namespace kartlib.Imaging.Formats
{
    public class RGB5A3 : ImageFormat
    {
        public override int BitsPerPixel => 16;
        public override int BlockWidth   => 4;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> pixels = new List<uint>();
            for(int i = 0; i < buffer.Length; i += 2)
            {
                bool alphaEnabled = ((uint)buffer[i] >> 7) == 0;
                uint pixel;
                if (alphaEnabled)
                {
                    uint A = (((uint)buffer[i] >> 4) & 0x7) * 0x20;
                    uint R = ((uint)buffer[i] & 0xF) * 0x11;
                    uint G = ((uint)buffer[i + 1] >> 4) * 0x11;
                    uint B = ((uint)buffer[i + 1] & 0xF) * 0x11;

                    pixel = (A << 24) | (R << 16) | (G << 8) | B;
                }
                else
                {
                    uint R = (((uint)buffer[i] >> 2) & 0x1F) * 0x8;
                    uint G = ((((uint)buffer[i] & 0x3) << 3) | ((uint)buffer[i + 1] >> 5)) * 0x8;
                    uint B = ((uint)buffer[i + 1] & 0x1F) * 0x8;

                    pixel = (uint)((0xFF << 24) | (R << 16) | (G << 8) | B);
                }
                pixels.Add(pixel);
            }
            return pixels.ToArray();
        }
    }
}
