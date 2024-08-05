using System.Text;
using static System.Net.Mime.MediaTypeNames;

public class OBJ
{
    public class _Face
    {
        public uint[] Vertices;

        public uint[] UVs;

        public uint[] Normals;

        public bool UsesUVs;

        public bool UsesNormals;

        public _Face()
        {
            this.Vertices = new uint[3];
            this.UVs = new uint[3];
            this.Normals = new uint[3];
        }

        public _Face(uint[] Vertices)
        {
            this.Vertices = Vertices;
            this.UVs = null;
            this.Normals = null;
        }

        public _Face(uint[] Vertices, uint[] UVs, uint[] Normals)
        {
            this.Vertices = Vertices;
            this.UVs = UVs;
            this.Normals = Normals;
        }
    }

    public class _Group
    {
        public string Name;

        public string Material;

        public List<_Face> Faces;

        public bool HasNormals
        {
            get
            {
                if (this.Faces == null || this.Faces.Count == 0)
                {
                    return false;
                }
                return this.Faces[0].UsesNormals;
            }
        }

        public bool HasUV
        {
            get
            {
                if (this.Faces == null || this.Faces.Count == 0)
                {
                    return false;
                }
                return this.Faces[0].UsesUVs;
            }
        }

        public _Group(string Name)
        {
            this.Faces = new List<_Face>();
            this.Name = Name;
            this.Material = "";
        }
    }

    public string FileName { get; set; }

    public string LibraryPath { get; set; }

    public List<_Group> Groups { get; set; }

    public List<Vector3f> Vertices { get; set; }

    public List<Vector3f> Normals { get; set; }

    public List<Vector3f> UVs { get; set; }

    public OBJ()
    {
        this.Groups = new List<_Group>();
        this.Vertices = new List<Vector3f>();
        this.Normals = new List<Vector3f>();
        this.UVs = new List<Vector3f>();
    }

    public OBJ(byte[] Data, string FileName)
    {
        this.FileName = FileName;
        this.Groups = new List<_Group>();
        this.Vertices = new List<Vector3f>();
        this.Normals = new List<Vector3f>();
        this.UVs = new List<Vector3f>();
        StreamReader streamReader = new StreamReader(new MemoryStream(Data));
        try
        {
            string text = "";
            List<string> list = null;
            while ((text = streamReader.ReadLine()) != null)
            {
                if (text.StartsWith("#"))
                {
                    continue;
                }
                list = text.Split(' ').ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "" || list[i] == "\t" || list[i] == null)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }
                if (list.Count == 0)
                {
                    continue;
                }
                switch (list[0])
                {
                    case "mtllib":
                        if (list.Count >= 2)
                        {
                            this.LibraryPath = Path.Combine(Path.GetDirectoryName(FileName), OBJ.GetName(list, 1));
                            if (!File.Exists(this.LibraryPath))
                            {
                            }
                            else
                            {
                            }
                            break;
                        }
                        throw new Exception("Invalid material library.");
                    case "g":
                        this.ReadGroup(list.ToArray());
                        break;
                    case "v":
                        this.ReadVertex(list.ToArray());
                        break;
                    case "vn":
                        this.ReadNormal(list.ToArray());
                        break;
                    case "vt":
                        this.ReadUV(list.ToArray());
                        break;
                    case "f":
                        if (this.Groups.Count == 0)
                        {
                            throw new Exception("Group data found before any groups have been defined.");
                        }
                        this.ReadFace(list.ToArray());
                        break;
                    case "usemtl":
                        if (this.Groups.Count == 0)
                        {
                            throw new Exception("Group data found before any groups have been defined.");
                        }
                        this.Groups[this.Groups.Count - 1].Material = list[1];
                        break;
                }
            }
        }
        finally
        {
            streamReader.Close();
        }
    }

    public byte[] Write()
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (this.LibraryPath != null && this.LibraryPath != "")
        {
            stringBuilder.AppendLine($"mtllib {this.LibraryPath}");
            stringBuilder.AppendLine();
        }
        foreach (Vector3f vertex in this.Vertices)
        {
            stringBuilder.AppendLine($"v {vertex.X.ToString()} {vertex.Y.ToString()} {vertex.Z.ToString()}");
        }
        if (this.Normals != null)
        {
            foreach (Vector3f normal in this.Normals)
            {
                stringBuilder.AppendLine($"vn {normal.X.ToString()} {normal.Y.ToString()} {normal.Z.ToString()}");
            }
        }
        if (this.UVs != null)
        {
            foreach (Vector3f uV in this.UVs)
            {
                stringBuilder.AppendLine($"vt {uV.X.ToString()} {uV.Y.ToString()} {uV.Z.ToString()}");
            }
        }
        foreach (_Group group in this.Groups)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"# Start of {group.Name} with {group.Faces.Count.ToString()} faces.");
            stringBuilder.AppendLine($"g {group.Name}");
            if (group.Material != null && group.Material != "")
            {
                stringBuilder.AppendLine($"usemtl {group.Material}");
            }
            stringBuilder.AppendLine();
            foreach (_Face face in group.Faces)
            {
                if (face.Normals == null && face.UVs == null)
                {
                    stringBuilder.AppendLine($"f {(face.Vertices[0] + 1).ToString()} {(face.Vertices[1] + 1).ToString()} {(face.Vertices[2] + 1).ToString()}");
                }
                if (face.Normals == null && face.UVs != null)
                {
                    stringBuilder.AppendLine($"f {(face.Vertices[0] + 1).ToString()}/{(face.UVs[0] + 1).ToString()} {(face.Vertices[1] + 1).ToString()}/{(face.UVs[1] + 1).ToString()} {(face.Vertices[2] + 1).ToString()}/{(face.UVs[2] + 1).ToString()}");
                }
                if (face.Normals != null && face.UVs == null)
                {
                    stringBuilder.AppendLine($"f {(face.Vertices[0] + 1).ToString()}//{(face.Normals[0] + 1).ToString()} {(face.Vertices[1] + 1).ToString()}//{(face.Normals[1] + 1).ToString()} {(face.Vertices[2] + 1).ToString()}//{(face.Normals[2] + 1).ToString()}");
                }
                if (face.Normals != null && face.UVs != null)
                {
                    stringBuilder.AppendLine($"f {(face.Vertices[0] + 1).ToString()}/{(face.UVs[0] + 1).ToString()}/{(face.Normals[0] + 1).ToString()} {(face.Vertices[1] + 1).ToString()}/{(face.UVs[1] + 1).ToString()}/{(face.Normals[1] + 1).ToString()} {(face.Vertices[2] + 1).ToString()}/{(face.UVs[2] + 1).ToString()}/{(face.Normals[2] + 1).ToString()}");
                }
            }
        }
        return Encoding.ASCII.GetBytes(stringBuilder.ToString());
    }

    public static string GetOpenFilter()
    {
        return "Wavefront OBJ (*.obj)|*.obj";
    }

    public static string GetSaveFilter()
    {
        return "Wavefront OBJ (*.obj)|*.obj";
    }

    public static bool IsMatch(byte[] Data, string FileName)
    {
        if (!FileName.EndsWith(".obj"))
        {
            return false;
        }
        try
        {
            Encoding.ASCII.GetString(Data);
        }
        catch
        {
            return false;
        }
        return true;
    }

    internal static string GetName(string[] Strings, int StartIndex)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = StartIndex; i < Strings.Length; i++)
        {
            stringBuilder.Append(Strings[i]);
            stringBuilder.Append(" ");
        }
        string text = stringBuilder.ToString();
        return text.Substring(0, text.Length - 1);
    }

    internal static string GetName(List<string> Strings, int StartIndex)
    {
        return OBJ.GetName(Strings.ToArray(), StartIndex);
    }

    public void FlipYZ()
    {
        for (int i = 0; i < this.Vertices.Count; i++)
        {
            Vector3f vector3f = this.Vertices[i];
            this.Vertices[i] = new Vector3f(vector3f.X, 0f - vector3f.Z, vector3f.Y);
        }
        for (int j = 0; j < this.Normals.Count; j++)
        {
            Vector3f vector3f2 = this.Normals[j];
            this.Normals[j] = new Vector3f(vector3f2.X, 0f - vector3f2.Z, vector3f2.Y);
        }
    }

    private void ReadGroup(string[] Line)
    {
        if (Line.Length >= 2)
        {
            this.Groups.Add(new _Group(OBJ.GetName(Line, 1)));
            return;
        }
        throw new Exception("Invalid group.");
    }

    private void ReadVertex(string[] Line)
    {
        if (Line.Length >= 4)
        {
            this.Vertices.Add(new Vector3f(Convert.ToSingle(Line[1]), Convert.ToSingle(Line[2]), Convert.ToSingle(Line[3])));
            return;
        }
        throw new Exception("Invalid vertex group.");
    }

    private void ReadNormal(string[] Line)
    {
        if (Line.Length >= 4)
        {
            this.Normals.Add(new Vector3f(Convert.ToSingle(Line[1]), Convert.ToSingle(Line[2]), Convert.ToSingle(Line[3])));
            return;
        }
        throw new Exception("Invalid normal group.");
    }

    private void ReadUV(string[] Line)
    {
        if (Line.Length >= 4)
        {
            this.UVs.Add(new Vector3f(Convert.ToSingle(Line[1]), Convert.ToSingle(Line[2]), Convert.ToSingle(Line[3])));
            return;
        }
        if (Line.Length == 3)
        {
            this.UVs.Add(new Vector3f(Convert.ToSingle(Line[1]), Convert.ToSingle(Line[2]), 0f));
            return;
        }
        throw new Exception("Invalid UV group.");
    }

    private void ReadFace(string[] Line)
    {
        if (Line.Length >= 4)
        {
            _Face face = new _Face();
            for (int i = 1; i < 4; i++)
            {
                string[] array = Line[i].Split('/');
                if (array.Length == 1)
                {
                    face.Vertices[i - 1] = Convert.ToUInt32(array[0]) - 1;
                    face.UsesUVs = false;
                    face.UsesNormals = false;
                    continue;
                }
                if (array.Length == 2)
                {
                    face.Vertices[i - 1] = Convert.ToUInt32(array[0]) - 1;
                    face.UVs[i - 1] = Convert.ToUInt32(array[1]) - 1;
                    face.UsesUVs = true;
                    face.UsesNormals = false;
                    continue;
                }
                if (array.Length == 3 && array[1] != "")
                {
                    face.Vertices[i - 1] = Convert.ToUInt32(array[0]) - 1;
                    face.UVs[i - 1] = Convert.ToUInt32(array[1]) - 1;
                    face.Normals[i - 1] = Convert.ToUInt32(array[2]) - 1;
                    face.UsesUVs = true;
                    face.UsesNormals = true;
                    continue;
                }
                if (array.Length == 3 && array[1] == "")
                {
                    face.Vertices[i - 1] = Convert.ToUInt32(array[0]) - 1;
                    face.Normals[i - 1] = Convert.ToUInt32(array[2]) - 1;
                    face.UsesUVs = false;
                    face.UsesNormals = true;
                    continue;
                }
                throw new Exception("Invalid face group.");
            }
            this.Groups[this.Groups.Count - 1].Faces.Add(face);
            return;
        }
        throw new Exception("Invalid face group.");
    }

    public Vector3f GetVertex(uint Index)
    {
        return this.Vertices[(int)Index];
    }

    public Vector3f GetVertex(int Index)
    {
        return this.Vertices[Index];
    }

    public Vector3f GetNormal(uint Index)
    {
        return this.Normals[(int)Index];
    }

    public Vector3f GetNormal(int Index)
    {
        return this.Normals[Index];
    }

    public Vector3f GetUV(uint Index)
    {
        return this.UVs[(int)Index];
    }

    public Vector3f GetUV(int Index)
    {
        return this.UVs[Index];
    }

    public _Group GetGroup(uint Index)
    {
        return this.Groups[(int)Index];
    }

    public _Group GetGroup(int Index)
    {
        return this.Groups[Index];
    }
}
