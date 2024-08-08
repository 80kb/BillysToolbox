namespace kartlib.Imaging.Formats
{
    public class I8 : ImageFormat
    {
        public override int BitsPerPixel => 8;
        public override int BlockWidth   => 8;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> result = new List<uint>();
            for(int i = 0; i < buffer.Length; i++)
            {
                uint pixel = buffer[i];    
                pixel = (uint)((0xFF << 24) | (pixel << 16) | (pixel << 8) | pixel);
                result.Add(pixel);
            }
            return result.ToArray();
        }
    }
}
