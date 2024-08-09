namespace kartlib.Imaging.Formats
{
    public class RGBA8 : ImageFormat
    {
        public override int BitsPerPixel => 32;
        public override int BlockWidth   => 4;
        public override int BlockHeight  => 4;

        protected override uint[] DecodePixels(byte[] buffer)
        {
            List<uint> pixels = new();

            List<uint> A = new();
            List<uint> R = new();
            List<uint> G = new();
            List<uint> B = new();

            for(int i = 0; i < buffer.Length;)
            {
                for(int j = 0; j < 16; j++)
                {
                    A.Add( buffer[i++] );
                    R.Add( buffer[i++] );
                }

                for(int j = 0; j < 16; j++)
                {
                    G.Add( buffer[i++] );
                    B.Add( buffer[i++] );
                }
            }

            for(int i = 0; i < A.Count; i++)
            {
                uint pixel = (A[i] << 24) | (R[i] << 16) | (G[i] << 8) | B[i];
                pixels.Add(pixel);
            }

            return pixels.ToArray();
        }
    }
}
