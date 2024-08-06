using System.ComponentModel;

namespace kartlib.Serial
{
    public class BDOF
    {
        public enum DrawModeEnum : byte
        {
            None = 0,
            InverseOnly = 1,
            NormalAndInverse = 2,
        }

        public string Filename;
        public UInt32 Magic;
        public UInt32 Size;
        [Category("Settings")] public UInt32 Unknown0 { get; set; }
        [Category("Settings")] public UInt32 Unknown1 { get; set; }
        [Category("Settings")] public UInt16 Flags { get; set; }
        [Category("Alpha")] public Byte InverseAlpha { get; set; }
        [Category("Alpha")] public Byte Alpha { get; set; }
        [Category("Drawing")] public DrawModeEnum DrawMode { get; set; }
        [Category("Drawing")] public Byte DrawAmount { get; set; }
        [Category("Drawing")] public Byte CurveType { get; set; }
        [Category("Drawing")] public Byte Unknown2 { get; set; }
        [Category("View")] public float PlaneDistance { get; set; }
        [Category("View")] public float PlaneRange { get; set; }
        [Category("View")] public float Unknown3 { get; set; }
        [Category("View")] public float BlurAmount { get; set; }
        [Category("Indirect Texture")] public Vector2f TextureScrollVelocity { get; set; }
        [Category("Indirect Texture")] public Vector2f TextureIndirectScale { get; set; }
        [Category("Indirect Texture")] public Vector2f TextureScale { get; set; }
        public Byte[] Reserved;

        public BDOF()
        {
            Filename = "Untitled.bdof":
            Magic = 0x50444F46;
            Size = 0x50;
            Unknown0 = 0;
            Unknown1 = 0;
            Flags = 0;
            InverseAlpha = 0;
            Alpha = 0;
            DrawMode = DrawModeEnum.None;
            DrawAmount = 0;
            CurveType = 0;
            Unknown2 = 0;
            PlaneDistance = 0;
            PlaneRange = 0;
            Unknown3 = 0;
            BlurAmount = 0;
            TextureScrollVelocity = default(Vector2f);
            TextureIndirectScale = default(Vector2f);
            TextureScale = default(Vector2f);
            Reserved = new byte[16];
        }

        public BDOF(byte[] buffer, string filename)
        {
            Filename = filename;
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                Magic = reader.ReadUInt32();
                Size = reader.ReadUInt32();
                Unknown0 = reader.ReadUInt32();
                Unknown1 = reader.ReadUInt32();
                Flags = reader.ReadUInt16();
                InverseAlpha = reader.ReadByte();
                Alpha = reader.ReadByte();
                DrawMode = (DrawModeEnum)reader.ReadByte();
                DrawAmount = reader.ReadByte();
                CurveType = reader.ReadByte();
                Unknown2 = reader.ReadByte();
                PlaneDistance = reader.ReadSingle();
                PlaneRange = reader.ReadSingle();
                Unknown3 = reader.ReadSingle();
                BlurAmount = reader.ReadSingle();
                TextureScrollVelocity = reader.ReadSingles(2);
                TextureIndirectScale = reader.ReadSingles(2);
                TextureScale = reader.ReadSingles(2);
                Reserved = reader.ReadBytes(16);
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
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(Size);
                writer.WriteUInt32(Unknown0);
                writer.WriteUInt32(Unknown1);
                writer.WriteUInt16(Flags);
                writer.WriteByte(InverseAlpha);
                writer.WriteByte(Alpha);
                writer.WriteByte((byte)DrawMode);
                writer.WriteByte(DrawAmount);
                writer.WriteByte(CurveType);
                writer.WriteByte(Unknown2);
                writer.WriteSingle(PlaneDistance);
                writer.WriteSingle(PlaneRange);
                writer.WriteSingle(Unknown3);
                writer.WriteSingle(BlurAmount);
                writer.WriteSingles(TextureScrollVelocity);
                writer.WriteSingles(TextureIndirectScale);
                writer.WriteSingles(TextureScale);
                writer.WriteBytes(Reserved);
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
