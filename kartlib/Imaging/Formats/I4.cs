namespace kartlib.Imaging.Formats
{
    public class I4 : ImageFormat
    {
        public override int BitsPerPixel => 4;
        public override int BlockWidth   => 8;
        public override int BlockHeight  => 8;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> formattedData = new List<uint>();
            for(int i = 0; i < buffer.Length; i++)
            {
                uint pixel = buffer[i];

                uint pixel1 = (pixel >> 4) * 0x11;
                pixel1 = (uint)((0xFF << 24) | (pixel1 << 16) | (pixel1 << 8) | pixel1);
                formattedData.Add(pixel1);

                uint pixel2 = (pixel & 0xF) * 0x11;
                pixel2 = (uint)((0xFF << 24) | (pixel2 << 16) | (pixel2 << 8) | pixel2);
                formattedData.Add(pixel2);
            }
            return formattedData.ToArray();
        }
    }
}
