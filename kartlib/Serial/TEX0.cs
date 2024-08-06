namespace kartlib.Serial
{
    public class TEX0
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt32 SubFileLength;
            public UInt32 Version;
            public Int32 ParentOffset;
            public Int32[] SectionOffsets;
            public Int32 NameOffset;

            public _Header()
            {
                Magic = 0x54455830;
                SubFileLength = 0;
                Version = 3;
                ParentOffset = 0;
                SectionOffsets = new Int32[1];
                NameOffset = 0;
            }

            public _Header(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
            }
        }

        public class _ImageHeader
        {
            public enum ImageFormatEnum : int
            {
                I4 = 0x00,
                I8 = 0x01,
                IA4 = 0x02,
                IA8 = 0x03,
                RGB565 = 0x04,
                RGB5A3 = 0x05,
                RGBA8 = 0x06,
                C4 = 0x08,
                C8 = 0x09,
                C14 = 0x0A,
                CMPR = 0x0E
            }

            public UInt32 Flag;
            public UInt16 Width;
            public UInt16 Height;
            public ImageFormatEnum ImageFormat;
            public UInt32 MipMapCount;
            public float MinMipMap;
            public float MaxMipMap;
            public UInt32 ParentOffset;
        }
    }
}
