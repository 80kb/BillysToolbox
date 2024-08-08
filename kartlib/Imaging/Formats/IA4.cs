namespace kartlib.Imaging.Formats
{
    public class IA4 : ImageFormat
    {
        public override int BitsPerPixel => 8;
        public override int BlockWidth   => 8;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> result = new List<uint>();
            for(int i = 0; i < buffer.Length; i++)
            {
                uint input = buffer[i];

                uint pixelA = (input >> 4) * 0x11;
                uint pixelI = (input & 0xF) * 0x11;

                uint pixel = (pixelA << 24) | (pixelI << 16) | (pixelI << 8) | pixelI;
                result.Add(pixel);
            }
            return result.ToArray();
        }
    }
}
