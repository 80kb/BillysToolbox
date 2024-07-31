namespace kartlib.Serial
{
    public class YAZ0
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt32 UncompressedSize;
            public UInt32[] Reserved;

            public _Header(EndianReader reader)
            {
                Magic               = reader.ReadUInt32();
                UncompressedSize    = reader.ReadUInt32();
                Reserved            = reader.ReadUInt32s(2);
            }

            public static void Write(EndianWriter writer, uint size)
            {
                writer.WriteUInt32(0x59617A30);
                writer.WriteUInt32(size);
                writer.WriteUInt32(0);
                writer.WriteUInt32(0);
            }
        }

        public enum CompressionAlgorithm
        {
            Fast = 0,
        }

        public static byte[] Decompress(byte[] buffer)
        {
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                _Header header = new _Header(reader);
                byte[]  result = new byte[header.UncompressedSize]; 
                int     offset = 0;

                Func<bool, int> readGroup = (x) =>
                {
                    if(x)
                    {
                        result[offset++] = reader.ReadByte();
                        return 0;
                    }

                    int group   = (reader.ReadByte() << 8) | reader.ReadByte();
                    int reverse = (group & 0xFFF) + 1;
                    int gSize   = group >> 12;

                    int size = gSize > 0 ? gSize + 2 : reader.ReadByte() + 18;

                    for(int i = 0; i < size; i++) 
                        result[offset] = result[offset++ - reverse];
                    return 0;
                };

                Func<int> readChunk = () =>
                {
                    byte chunkHeader = reader.ReadByte();
                    for(int i = 0; i < 8; i++)
                    {
                        if(reader.Position >= reader.StreamLength)  return 1;
                        if(offset >= header.UncompressedSize)       return 1;
                        readGroup((chunkHeader & (1 << (7 - i))) > 0);
                    }
                    return 0;
                };

                while (reader.Position < reader.StreamLength && offset < header.UncompressedSize)
                    readChunk();

                return result;
            }
            finally
            {
                reader.Close();
            }
        }

        public static byte[] Compress(byte[] data, CompressionAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case CompressionAlgorithm.Fast:
                    return FastEncode(data);
                default:
                    return FastEncode(data);
            }
        }

        private static byte[] FastEncode(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream();
            EndianWriter writer = new EndianWriter(stream, Endianness.BigEndian);
            try
            {
                _Header.Write(writer, (uint)buffer.Length);

                int counter = 0;
                for(int i = 0; i < buffer.Length; counter--)
                {
                    if(counter == 0)
                    {
                        writer.WriteByte(0xFF);
                        counter = 8;
                    }
                    writer.WriteByte(buffer[i++]);
                }
            }
            finally
            {

                stream.Close();
                writer.Close();
            }

            return stream.ToArray();
        }
    }
}
