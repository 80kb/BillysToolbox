namespace BillysToolbox.Editors
{
    public static class KClFlagCalculator
    {
        public class _KCLFlag
        {
            public string _flag { get; }
            public string[] _variants { get; }

            public _KCLFlag(string flag, string[] variants)
            {
                _flag = flag;
                _variants = variants;
            }
        }

        public static List<_KCLFlag> KCLFlags = new List<_KCLFlag>()
        {
            new _KCLFlag(
                "0x00 - Road 1",
                new string[8]
                {
                    "Normal",
                    "Dirt (GFX)",
                    "Dirt (no GFX)",
                    "Smooth",
                    "Wood",
                    "Snow (GFX)",
                    "Metal Grate",
                    "Road (Weird sound)"
                }),
            new _KCLFlag(
                "0x01 - Slippery Road 1",
                new string[8]
                {
                    "White Sand",
                    "Dirt",
                    "Water",
                    "Snow",
                    "Grass",
                    "Yellow Sand",
                    "Sand (no GFX)",
                    "Dirt (no GFX)"
                }),
            new _KCLFlag(
                "0x02 - Weak Off-Road",
                new string[8]
                {
                    "Orange Sand",
                    "Dirt",
                    "Water",
                    "Dark Grass",
                    "Sand",
                    "Carpet",
                    "Gravel",
                    "Gravel (Different sound)"
                }),
            new _KCLFlag(
                "0x03 - Off-Road",
                new string[8]
                {
                    "Sand",
                    "Dirt",
                    "Mud",
                    "Water (no GFX)",
                    "Grass",
                    "Sand",
                    "Gravel",
                    "Carpet"
                }),
            new _KCLFlag(
                "0x04 - Heavy Off-Road",
                new string[8]
                {
                    "Sand",
                    "Dirt",
                    "Mud",
                    "Flowers",
                    "Grass",
                    "Snow",
                    "Sand",
                    "Dirt (no GFX)"
                }),
            new _KCLFlag(
                "0x05 - Slippery Road 2",
                new string[8]
                {
                    "Ice",
                    "Mud (no GFX)",
                    "Water (no GFX)",
                    "Water (no GFX)",
                    "Water (no GFX)",
                    "Water (no GFX)",
                    "Normal Road",
                    "Normal Road"
                }),
            new _KCLFlag(
                "0x06 - Boost Panel",
                new string[8]
                {
                    "Default",
                    "Rotates w/ casino_roulette",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x07 - Boost Ramp",
                new string[8]
                {
                    "Double Flip",
                    "Single Flip",
                    "Stunt Trick",
                    "Stunt Trick",
                    "Stunt Trick",
                    "Stunt Trick",
                    "Stunt Trick",
                    "Stunt Trick"
                }),
            new _KCLFlag(
                "0x08 - Bounce Pad",
                new string[8]
                {
                    "Speed: 50, Y Vel: 35",
                    "Speed: 50, Y Vel: 47",
                    "Speed: 59, Y Vel: 30",
                    "Speed: 73, Y Vel: 45",
                    "Bouncy Mushroom",
                    "Speed: 56, Y Vel: 50",
                    "Speed: 55, Y Vel: 35",
                    "Speed: 56, Y Vel: 50"
                }),
            new _KCLFlag(
                "0x09 - Item Road",
                new string[8]
                {
                    "Unknown",
                    "Unknown",
                    "Metal Grate",
                    "Wood",
                    "Unknown",
                    "Unknown",
                    "Grass Bush",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x0A - Solid OOB",
                new string[8]
                {
                    "Sand",
                    "Sand/Underwater",
                    "Unknown",
                    "Ice",
                    "Dirt",
                    "Grass",
                    "Wood",
                    "Dark Sand (GFX)"
                }),
            new _KCLFlag(
                "0x0B - Moving Water",
                new string[8]
                {
                    "Follows Route, Lightly Pulls Down",
                    "Follows Route, Strongly Pulls Down",
                    "Follows Route",
                    "Follows Route, Disables Acceleration",
                    "Moving Asphalt, Lightly Pulls Down",
                    "Moving Asphalt, Lightly Pulls Down",
                    "Moving Road, Lightly Pulls Down",
                    "Moving Road, Lightly Pulls Down"
                }),
            new _KCLFlag(
                "0x0C - Wall 1",
                new string[8]
                {
                    "Normal",
                    "Rock",
                    "Metal",
                    "Wood",
                    "Ice",
                    "Bush (GFX)",
                    "Rope",
                    "Rubber"
                }),
            new _KCLFlag(
                "0x0D - Invisible Wall",
                new string[8]
                {
                    "No Spark",
                    "Spark",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x0E - Item Wall",
                new string[8]
                {
                    "Unknown",
                    "Rock",
                    "Metal",
                    "Unknown",
                    "Unknown",
                    "Grass/Bush",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x0F - Wall 2",
                new string[8]
                {
                    "Normal",
                    "Rock",
                    "Metal",
                    "Wood",
                    "Ice",
                    "Bush (no GFX)",
                    "Rope",
                    "Rubber"
                }),
            new _KCLFlag(
                "0x10 - Fall Boundary",
                new string[8]
                {
                    "Air Fall",
                    "Water",
                    "Lava",
                    "Icy Water",
                    "Lava (no GFX)",
                    "Burning Air Fall",
                    "Quicksand",
                    "Short Fall"
                }),
            new _KCLFlag(
                "0x11 - Cannon Trigger",
                new string[8]
                {
                    "Cannon 0",
                    "Cannon 1",
                    "Cannon 2",
                    "Cannon 3",
                    "Cannon 4",
                    "Cannon 5",
                    "Cannon 6",
                    "Cannon 7",
                }),
            new _KCLFlag(
                "0x12 - Force Enemy/Item Recalculation",
                new string[8]
                {
                    "Default",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x13 - Half Pipe Ramp",
                new string[8]
                {
                    "Default",
                    "Applies Boost",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x14 - Player-Only Wall",
                new string[8]
                {
                    "Normal",
                    "Rock",
                    "Metal",
                    "Wood",
                    "Ice",
                    "Bush",
                    "Rope",
                    "No SFX/GFX"
                }),
            new _KCLFlag(
                "0x15 - Moving Road",
                new string[8]
                {
                    "Moves West w/ BeltCrossing",
                    "Moves East w/ BeltCrossing",
                    "Moves East w/ BeltEasy",
                    "Moves West w/ BeltEast",
                    "Rotates around BeltCurveA Clockwise",
                    "Rotates around BeltCurveA Counterclockwise",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x16 - Sticky Road",
                new string[8]
                {
                    "Wood",
                    "Gravel",
                    "Carpet",
                    "Dirt (no GFX)",
                    "Sand",
                    "Normal Road (RR SFX)",
                    "Normal Road",
                    "Mud (GFX)"
                }),
            new _KCLFlag(
                "0x17 - Road 2",
                new string[8]
                {
                    "Normal",
                    "Carpet",
                    "Grass (GFX)",
                    "Green Mushroom",
                    "Grass",
                    "Glass",
                    "Dirt",
                    "Normal (Different SFX)"
                }),
            new _KCLFlag(
                "0x18 - Sound Trigger",
                new string[8]
                {
                    "0",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7"
                }),
            new _KCLFlag(
                "0x19 - Weak Wall",
                new string[8]
                {
                    "Default",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x1A - Effect Trigger",
                new string[8]
                {
                    "Change BLIGHT To Index",
                    "Change BLIGHT To Index",
                    "Trigger Water Splash",
                    "Activate starGate Object",
                    "Force Half-Pipe Cancellation",
                    "Despawn Coin",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x1B - Item State Modifier",
                new string[8]
                {
                    "Default",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x1C - Half-Pipe Invisible Wall",
                new string[8]
                {
                    "Default",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                }),
            new _KCLFlag(
                "0x1D - Rotating Road (casino_roulette)",
                new string[8]
                {
                    "Carpet",
                    "Normal (Different SFX)",
                    "Normal",
                    "Glass",
                    "Carpet (Different SFX)",
                    "Star Crash SFX",
                    "Sand",
                    "Dirt"
                }),
            new _KCLFlag(
                "0x1E - Special Wall",
                new string[8]
                {
                    "Cactus",
                    "No SFX/GFX",
                    "Bouncy Wall",
                    "No SFX/GFX",
                    "Rainbow Road Railings",
                    "Mushroom Stem",
                    "Metal SFX",
                    "Competition Gate"
                }),
            new _KCLFlag(
                "0x1F - Invisible Wall 2",
                new string[8]
                {
                    "No SFX/GFX",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown",
                    "Unknown"
                })
        };

        public static ushort CalculateFlag(int flag, int variant, int blight, int depth, int effect)
        {
            ushort _effect = (ushort)(effect << 13);
            ushort _depth = (ushort)(depth << 11);
            ushort _blight = (ushort)(blight << 8);
            ushort _variant = (ushort)(variant << 5);
            ushort _flag = (ushort)flag;

            return (ushort)(_effect | _depth | _blight | _variant | _flag);
        }

        public static int GetFlag(ushort flag)
        {
            return flag & 0x1F;
        }

        public static int GetVariant(ushort flag)
        {
            return (flag & 0xE0) >> 5;
        }

        public static int GetBlight(ushort flag)
        {
            return (flag & 0x700) >> 8;
        }

        public static int GetDepth(ushort flag)
        {
            return (flag & 0x1800) >> 11;
        }

        public static int GetEffect(ushort flag)
        {
            return (flag & 0xE000) >> 13;
        }

        public static string FlagString(ushort flag)
        {
            return KCLFlags[GetFlag(flag)]._flag + ", " + KCLFlags[GetFlag(flag)]._variants[GetVariant(flag)];
        }
    }
}
