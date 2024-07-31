namespace kartlib.Serial
{
    public class BMM
    {
        public string Filename;
        public Byte[] RGBAColor;
        public float ScaleS;
        public float TranslationS;
        public float ScaleT;
        public float TranslationT;

        public BMM()
        {
            Filename = "course.bmm";
            RGBAColor = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
            ScaleS = 1f;
            TranslationS = 0f;
            ScaleT = -30f;
            TranslationT = 0f;
        }

        public BMM(byte[] buffer, string filename)
        {
            Filename = filename;
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                RGBAColor = reader.ReadBytes(4);
                ScaleS = reader.ReadSingle();
                TranslationS = reader.ReadSingle();
                ScaleT = reader.ReadSingle();
                TranslationT = reader.ReadSingle();
            }
            finally
            {
                reader.Close();
            }
        }

        public byte[] Write()
        {
            MemoryStream stream = new MemoryStream();
            EndianWriter writer = new EndianWriter(stream, Endianness.BigEndian);
            try
            {
                writer.WriteBytes(RGBAColor);
                writer.WriteSingle(ScaleS);
                writer.WriteSingle(TranslationS);
                writer.WriteSingle(ScaleT);
                writer.WriteSingle(TranslationT);
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
            return stream.ToArray();
        }
    }
}
