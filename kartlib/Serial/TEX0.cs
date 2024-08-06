namespace kartlib.Serial
{
    public class TEX0
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt32 SubFileLength;
            public UInt32 Version;
            public Int32 OffsetToParent;
            public Int32[] SectionOffsets;
            public Int32 NameOffset;
        }
    }
}
