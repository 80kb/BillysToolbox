using kartlib.Serial;

namespace BillysToolbox.Editors
{
    public static class FileConverter
    {
        public static OBJ KCLToOBJ(KCL kcl)
        {
            return kcl.ToOBJ();
        }

        public static KCL OBJToKCL(OBJ obj, KeyValuePair<ushort, bool>[] collision)
        {
            return new KCL(obj, collision);
        }

        public static MDL0 BRRESToMDL0(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public static OBJ MDL0ToOBJ(MDL0 mdl0)
        {
            throw new NotImplementedException();
        }
    }
}
