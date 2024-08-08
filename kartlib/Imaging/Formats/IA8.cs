namespace kartlib.Imaging.Formats
{
    public class IA8 : ImageFormat
    {
        public override int BitsPerPixel => 16;
        public override int BlockWidth   => 4;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> pixels = new List<uint>();
            for(int i = 0; i < buffer.Length; i += 2)
            {
                uint value = buffer[i];
                uint alpha = buffer[i + 1];
                uint pixel = (alpha << 24) | (value << 16) | (value << 8) | value;
                pixels.Add(pixel);
            }
            return pixels.ToArray();
        }
    }
}
