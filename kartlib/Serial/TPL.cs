using kartlib.Img;
using System.Drawing;

namespace kartlib.Serial
{
    public class TPL
    {
        public class _FileHeader
        {
            public UInt32 Version;
            public UInt32 ImageCount;
            public UInt32 ImageTableOffset;

            public _FileHeader()
            {
                Version = 0x00;
                ImageCount = 1;
                ImageTableOffset = 0x0C;
            }

            public _FileHeader(EndianReader reader)
            {
                Version = reader.ReadUInt32();
                ImageCount = reader.ReadUInt32();
                ImageTableOffset = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Version);
                writer.WriteUInt32(ImageCount);
                writer.WriteUInt32(ImageTableOffset);
            }
        }

        public class _ImageTable
        {
            public UInt32 ImageOffset;
            public UInt32 PaletteOffset;

            public _ImageTable() { }

            public _ImageTable(EndianReader reader)
            {
                ImageOffset = reader.ReadUInt32();
                PaletteOffset = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(ImageOffset);
                writer.WriteUInt32(PaletteOffset);
            }
        }

        public class _PaletteHeader
        {
            public enum PaletteFormat : int
            {
                IA8 = 0x00,
                RGB565 = 0x01,
                RGB5A3 = 0x02,
            }

            public UInt16 EntryCount;
            public Byte Unpacked;
            public Byte Reserved;
            public PaletteFormat Format;
            public UInt32 DataAddress;

            public _PaletteHeader() { }

            public _PaletteHeader(EndianReader reader)
            {
                EntryCount = reader.ReadUInt16();
                Unpacked = reader.ReadByte();
                Reserved = reader.ReadByte();
                Format = (PaletteFormat)reader.ReadUInt32();
                DataAddress = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt16(EntryCount);
                writer.WriteByte(Unpacked);
                writer.WriteByte(Reserved);
                writer.WriteUInt32((uint)Format);
                writer.WriteUInt32(DataAddress);
            }
        }

        public class _ImageHeader
        {
            public UInt16 Height;
            public UInt16 Width;
            public ImageFormat Format;
            public UInt32 DataAddress;
            public UInt32 WrapS;
            public UInt32 WrapT;
            public UInt32 MinFilter;
            public UInt32 MagFilter;
            public float LODBias;
            public Byte EdgeLODEnable;
            public Byte MinLOD;
            public Byte MaxLOD;
            public Byte Unpacked;

            public _ImageHeader()
            {
            }

            public _ImageHeader(EndianReader reader)
            {
                Height = reader.ReadUInt16();
                Width = reader.ReadUInt16();
                Format = (ImageFormat)reader.ReadUInt32();
                DataAddress = reader.ReadUInt32();
                WrapS = reader.ReadUInt32();
                WrapT = reader.ReadUInt32();
                MinFilter = reader.ReadUInt32();
                MagFilter = reader.ReadUInt32();
                LODBias = reader.ReadFloat();
                EdgeLODEnable = reader.ReadByte();
                MinLOD = reader.ReadByte();
                MaxLOD = reader.ReadByte();
                Unpacked = reader.ReadByte();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt16(Height);
                writer.WriteUInt16(Width);
                writer.WriteUInt32((uint)Format);
                writer.WriteUInt32(DataAddress);
                writer.WriteUInt32(WrapS);
                writer.WriteUInt32(WrapT);
                writer.WriteUInt32(MinFilter);
                writer.WriteUInt32(MagFilter);
                writer.WriteSingle(LODBias);
                writer.WriteByte(EdgeLODEnable);
                writer.WriteByte(MinLOD);
                writer.WriteByte(MaxLOD);
                writer.WriteByte(Unpacked);
            }
        }

        public class _Image
        {
            public _ImageHeader ImageHeader;
            public byte[] ImageData;

            public _PaletteHeader? PaletteHeader;
            public byte[] PaletteData;

            public _Image (EndianReader reader, _ImageTable table)
            {
                // Image Header
                reader.Position = (int)table.ImageOffset;
                ImageHeader = new _ImageHeader(reader);

                // Palette Header
                if(table.PaletteOffset != 0)
                {
                    reader.Position = (int)table.PaletteOffset;
                    PaletteHeader = new _PaletteHeader(reader);
                }
            }
        }

        public string Filename;
        public _FileHeader FileHeader;
        public List<_ImageTable> ImageTables;
        public List<_Image> Images;

        public TPL(byte[] buffer, string filename)
        {
            Filename = filename;
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                FileHeader = new _FileHeader(reader);
                ImageTables = new List<_ImageTable>();
                Images = new List<_Image>();

                for(int i = 0; i < FileHeader.ImageCount; i++)
                    ImageTables.Add(new _ImageTable(reader));

                foreach(_ImageTable table in ImageTables)
                    Images.Add(new _Image(reader, table));
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
