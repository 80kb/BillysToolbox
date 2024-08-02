namespace kartlib.Serial
{
    public class BLIGHT
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt32 Size;
            public Byte Version;
            public Byte[] Reserved0;
            public UInt32 Reserved1;
            public UInt16 LOBJCount;
            public UInt16 AmbientLightCount;
            public Byte[] RGBAAmbienceColor;
            public Byte[] Reserved2;

            public _Header()
            {
                Magic = 0x4C474854;
                Size = 0x5A8;
                Version = 2;
                Reserved0 = new byte[3];
                Reserved1 = 0;
                LOBJCount = 0x10;
                AmbientLightCount = 0x10;
                RGBAAmbienceColor = new byte[4] { 0, 0, 0, 0xFF };
                Reserved2 = new byte[16];
            }

            public _Header(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                if (Magic != 0x4C474854)
                    throw new Exception("Invalid data: Magics dont match!");

                Size = reader.ReadUInt32();
                Version = reader.ReadByte();
                Reserved0 = reader.ReadBytes(3);
                Reserved1 = reader.ReadUInt32();
                LOBJCount = reader.ReadUInt16();
                AmbientLightCount = reader.ReadUInt16();
                RGBAAmbienceColor = reader.ReadBytes(4);
                Reserved2 = reader.ReadBytes(16);
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(Size);
                writer.WriteByte(Version);
                writer.WriteBytes(Reserved0);
                writer.WriteUInt32(Reserved1);
                writer.WriteUInt16(LOBJCount);
                writer.WriteUInt16(AmbientLightCount);
                writer.WriteBytes(RGBAAmbienceColor);
                writer.WriteBytes(Reserved2);
            }
        }

        public class _LightObject
        {
            public enum AngleFuncEnum : byte
            {
                Disabled = 0,
                Flat = 1,
                Cosine = 2,
                CosineSmooth = 3,
                Sharp = 4,
                RingDim = 5,
                Ring = 6
            }

            public enum DistanceFuncEnum : byte
            {
                Disabled = 0,
                Gentle = 1,
                Medium = 2,
                Steep = 3,
            }

            public enum CoordDestEnum : byte
            {
                World = 0,
                View = 1,
                TopDown = 2,
                BottomUp = 3,
            }

            public enum LightTypeEnum : byte
            {
                Omni = 0,
                Directional = 1,
                Spotlight = 2,
            }

            public UInt32           Magic { get; internal set; }
            public UInt32           Size { get; internal set; }
            public Byte             Version { get; internal set; }
            public Byte[]           Reserved0;
            public Byte[]           Reserved1;
            public AngleFuncEnum    AngleFunction { get; set; }
            public DistanceFuncEnum DistanceFunction { get; set; }
            public CoordDestEnum    CoordDest { get; set; }
            public LightTypeEnum    LightType { get; set; }
            public UInt16           AmbientLightIndex { get; set; }
             
            //----------------- bitfield flags -------------------//
            public bool EnableVectorsAndColors /* 0x1 & 0x40 */ { get; set; }
            public bool EnableVectorShift      /* 0x2 */        { get; set; }
            public bool EnableBLMAPLink        /* 0x20 */       { get; set; }
            public bool EnableAngleFunction    /* 0x80 */       { get; set; }
            public bool EnableDistanceFunction /* 0x100 */      { get; set; }
            public bool EnableFixedFunctions   /* 0x800 */      { get; set; }
            //----------------------------------------------------//

            public float[] OriginVector { get; set; }
            public float[] DestVector { get; set; }
            public float ColorStrength { get; set; }
            public Byte[] RGBAColor { get; set; }
            public Byte[] AmbientRGBAColor { get; set; } 
            public float SpotlightCutoffAngle { get; set; }
            public float ReferenceDistance { get; set; }
            public float ReferenceBrightness { get; set; }
            public UInt32 Reserved2;
            public UInt16 VectorShiftIndex { get; set; }
            public UInt16 Reserved3;

            public _LightObject()
            {
                Magic = 0x4C4F424A;
                Size = 0x50;
                Version = 2;
                Reserved0 = new byte[3];
                Reserved1 = new byte[4];
                AngleFunction = AngleFuncEnum.Disabled;
                DistanceFunction = DistanceFuncEnum.Disabled;
                CoordDest = CoordDestEnum.World;
                LightType = LightTypeEnum.Omni;
                AmbientLightIndex = 0;
                EnableVectorsAndColors = true;
                EnableVectorShift = false;
                EnableBLMAPLink = false;
                EnableAngleFunction = false;
                EnableDistanceFunction = false;
                EnableFixedFunctions = false;
                OriginVector = new float[3];
                DestVector = new float[3];
                ColorStrength = 1;
                RGBAColor = new Byte[4];
                AmbientRGBAColor = new Byte[4];
                SpotlightCutoffAngle = 0;
                ReferenceDistance = 0;
                ReferenceBrightness = 0;
                Reserved2 = 0;
                VectorShiftIndex = 0;
                Reserved3 = 0;
            }

            public _LightObject(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                if(Magic != 0x4C4F424A)
                    throw new Exception("Invalid data: Magics dont match!");

                Size = reader.ReadUInt32();
                Version = reader.ReadByte();
                Reserved0 = reader.ReadBytes(3);
                Reserved1 = reader.ReadBytes(4);
                AngleFunction = (AngleFuncEnum)reader.ReadByte();
                DistanceFunction = (DistanceFuncEnum)reader.ReadByte();
                CoordDest = (CoordDestEnum)reader.ReadByte();
                LightType = (LightTypeEnum)reader.ReadByte();
                AmbientLightIndex = reader.ReadUInt16();

                // parse bitfield
                ushort bitfield = reader.ReadUInt16();
                if(((bitfield & 0x1) > 0) && ((bitfield & 0x40) > 0))
                                            EnableVectorsAndColors  = true;
                if((bitfield & 0x2) > 0)    EnableVectorShift       = true;
                if((bitfield & 0x20) > 0)   EnableBLMAPLink         = true;
                if((bitfield & 0x80) > 0)   EnableAngleFunction     = true;
                if((bitfield & 0x100) > 0)  EnableDistanceFunction  = true;
                if((bitfield & 0x800) > 0)  EnableFixedFunctions    = true;
                //---------------------//

                OriginVector = reader.ReadFloats(3);
                DestVector = reader.ReadFloats(3);
                ColorStrength = reader.ReadFloat();
                RGBAColor = reader.ReadBytes(4);
                AmbientRGBAColor = reader.ReadBytes(4);
                SpotlightCutoffAngle = reader.ReadFloat();
                ReferenceDistance = reader.ReadFloat();
                ReferenceBrightness = reader.ReadFloat();
                Reserved2 = reader.ReadUInt32();
                VectorShiftIndex = reader.ReadUInt16();
                Reserved3 = reader.ReadUInt16();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(Size);
                writer.WriteByte(Version);
                writer.WriteBytes(Reserved0);
                writer.WriteBytes(Reserved1);
                writer.WriteByte((byte)AngleFunction);
                writer.WriteByte((byte)DistanceFunction);
                writer.WriteByte((byte)CoordDest);
                writer.WriteByte((byte)LightType);
                writer.WriteUInt16(AmbientLightIndex);

                // bitfield again
                ushort bitfield = 0;
                if(EnableVectorsAndColors)  bitfield |= 0x1 | 0x40;
                if(EnableVectorShift)       bitfield |= 0x2;
                if(EnableBLMAPLink)         bitfield |= 0x20;
                if(EnableAngleFunction)     bitfield |= 0x80;
                if(EnableDistanceFunction)  bitfield |= 0x100;
                if(EnableFixedFunctions)    bitfield |= 0x800;
                writer.WriteUInt16(bitfield);
                //-----------------//

                writer.WriteSingles(OriginVector);
                writer.WriteSingles(DestVector);
                writer.WriteSingle(ColorStrength);
                writer.WriteBytes(RGBAColor);
                writer.WriteBytes(AmbientRGBAColor);
                writer.WriteSingle(SpotlightCutoffAngle);
                writer.WriteSingle(ReferenceDistance);
                writer.WriteSingle(ReferenceBrightness);
                writer.WriteUInt32(Reserved2);
                writer.WriteUInt16(VectorShiftIndex);
                writer.WriteUInt16(Reserved3);
            }
        }

        public class _AmbientLight
        {
            public Byte[] RGBAColor { get; set; }
            public UInt32 Reserved;

            public _AmbientLight()
            {
                RGBAColor = new Byte[4] { 0x64, 0x64, 0x64, 0xFF };
                Reserved = 0;
            }

            public _AmbientLight(EndianReader reader)
            {
                RGBAColor = reader.ReadBytes(4);
                Reserved = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteBytes(RGBAColor);
                writer.WriteUInt32(Reserved);
            }
        }

        public string Filename;
        public _Header Header;
        public List<_LightObject> LightObjects;
        public List<_AmbientLight> AmbientLights;

        public BLIGHT()
        {
            Filename = "Untitled.blight";
            Header = new _Header();
            LightObjects = new List<_LightObject>();
            AmbientLights = new List<_AmbientLight>();
            
            for(int i = 0; i < Header.LOBJCount; i++)
                LightObjects.Add(new _LightObject());

            for(int i = 0; i < Header.AmbientLightCount; i++)
                AmbientLights.Add(new _AmbientLight());
        }

        public BLIGHT(byte[] buffer, string filename)
        {
            Filename = filename;
            LightObjects = new List<_LightObject>();
            AmbientLights = new List<_AmbientLight>();

            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                Header = new _Header(reader);

                for (int i = 0; i < Header.LOBJCount; i++)
                    LightObjects.Add(new _LightObject(reader));

                for (int i = 0; i < Header.AmbientLightCount; i++)
                    AmbientLights.Add(new _AmbientLight(reader));
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
                Header.Write(writer);

                foreach(_LightObject obj in LightObjects)
                    obj.Write(writer);

                foreach(_AmbientLight amb in AmbientLights)
                    amb.Write(writer);
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
