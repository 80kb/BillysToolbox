using System.Text;

namespace kartlib.Serial
{
    public class BRRES
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt16 ByteOrderMark;
            public UInt16 Padding;
            public UInt32 FileLength;
            public UInt16 RootOffset;
            public UInt16 SectionCount;

            public _Header()
            {
                Magic = 0x62726573;
                ByteOrderMark = 0xFEFF;
                Padding = 0;
                FileLength = 0;
                RootOffset = 0x10;
                SectionCount = 0;
            }

            public _Header(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                ByteOrderMark = reader.ReadUInt16();
                Padding = reader.ReadUInt16();
                FileLength = reader.ReadUInt32();
                RootOffset = reader.ReadUInt16();
                SectionCount = reader.ReadUInt16();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic); 
                writer.WriteUInt16(ByteOrderMark);
                writer.WriteUInt16(Padding);
                writer.WriteUInt32(FileLength);
                writer.WriteUInt16(RootOffset);
                writer.WriteUInt16(SectionCount);
            }
        }

        public class _Root
        {
            public UInt32 Magic;
            public UInt32 SectionLength;

            public _Root()
            {
                Magic = 0x726F6F74;
                SectionLength = 0;
            }

            public _Root(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                SectionLength = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(SectionLength);
            }
        }

        public class _IndexGroupEntry
        {
            public UInt16 EntryID;
            public UInt16 Flag;
            public UInt16 LeftIndex;
            public UInt16 RightIndex;
            public Int32 NameOffset;
            public Int32 DataOffset;

            public readonly int GlobalNameOffset;
            public readonly int GlobalDataOffset;

            public _IndexGroupEntry(EndianReader reader)
            {
                EntryID = reader.ReadUInt16();
                Flag = reader.ReadUInt16();
                LeftIndex = reader.ReadUInt16();
                RightIndex = reader.ReadUInt16();
                NameOffset = reader.ReadInt32();
                DataOffset = reader.ReadInt32();

                GlobalNameOffset = NameOffset + reader.PeekPosition();
                GlobalDataOffset = DataOffset + reader.PeekPosition();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt16(EntryID);
                writer.WriteUInt16(Flag);
                writer.WriteUInt16(LeftIndex);
                writer.WriteUInt16(RightIndex);
                writer.WriteInt32(NameOffset);
                writer.WriteInt32(DataOffset);
            }
        }

        public class _IndexGroup
        {
            public UInt32 GroupLength;
            public UInt32 EntryCount;
            public List<_IndexGroupEntry> Entries;

            public _IndexGroupEntry this[int index]
            {
                get { return Entries[index]; }
                set { Entries[index] = value; }
            }

            public _IndexGroup(EndianReader reader)
            {
                reader.PushPosition();
                GroupLength = reader.ReadUInt32();
                EntryCount = reader.ReadUInt32();
                Entries = new List<_IndexGroupEntry>()
                {
                    new _IndexGroupEntry(reader) // reference point entry
                };

                for (int i = 0; i < EntryCount; i++)
                {
                    Entries.Add(new _IndexGroupEntry(reader));
                }
                reader.PopPosition();
            }
        }

        public class _Subfile
        {
            public string Name;
            public string Magic;

            public MDL0? mdl0;

            public _Subfile(EndianReader reader, _IndexGroupEntry entry)
            {
                // Get name from name offset
                int tempPosition = reader.Position;
                reader.Position = entry.GlobalNameOffset - 4;
                Name = reader.ReadString(reader.ReadInt32(), Encoding.ASCII);
                reader.Position = tempPosition;

                // Get data from data offset
                reader.Position = entry.GlobalDataOffset;
                Magic = reader.ReadString(4, Encoding.ASCII);
                reader.Position = entry.GlobalDataOffset;

                switch (Magic)
                {
                    case "MDL0":
                        mdl0 = new MDL0(reader);
                        break;
                }
            }
        }

        public string               Filename;
        public _Header              Header;
        public _Root                Root;
        public List<_IndexGroup>    IndexGroups;
        public List<_Subfile>       Subfiles;

        public BRRES(byte[] buffer, string filename)
        {
            Filename = filename;
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                Header      = new _Header(reader);
                Root        = new _Root(reader);
                IndexGroups = new List<_IndexGroup>();
                Subfiles    = new List<_Subfile>();

                int sectionEnd = Header.RootOffset + (int)Root.SectionLength;
                while(reader.Position < sectionEnd)
                    IndexGroups.Add( new _IndexGroup(reader) );

                foreach( _IndexGroup group in IndexGroups )
                    foreach( _IndexGroupEntry entry in group.Entries)
                        if (entry.GlobalDataOffset >= sectionEnd)
                            Subfiles.Add(new _Subfile(reader, entry));
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
