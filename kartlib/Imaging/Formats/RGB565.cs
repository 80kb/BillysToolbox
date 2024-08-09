namespace kartlib.Imaging.Formats
{
    public class RGB565 : ImageFormat
    {
        public override int BitsPerPixel => 16;
        public override int BlockWidth   => 4;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> pixels = new List<uint>();
            for(int i = 0; i < buffer.Length; i += 2)
            {
                uint R = ((uint)buffer[i] >> 3) * 0x8;
                uint G = ((((uint)buffer[i] & 0x7) << 3) | ((uint)buffer[i + 1] >> 5)) * 0x4;
                uint B = ((uint)buffer[i + 1] & 0x1F) * 0x8;

                uint pixel = (uint)((0xFF << 24) | (R << 16) | (G << 8) | B);
                pixels.Add(pixel);
            }
            return pixels.ToArray();
        }
    }
}
