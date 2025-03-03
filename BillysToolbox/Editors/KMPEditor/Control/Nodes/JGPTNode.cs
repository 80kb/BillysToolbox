﻿using kartlib.Serial;
using static kartlib.Serial.KMP;

namespace KMP_Editor.Control.Nodes
{
    public class JGPTNode : Node
    {
        public _Section<_JGPT> JGPT { get; set; }

        public JGPTNode(KMP kmp)
        {
            JGPT = kmp.JGPT;
        }

        public override List<_ISectionEntry> GetData()
        {
            List<_ISectionEntry> result = new List<_ISectionEntry>();
            foreach (_JGPT jgpt in JGPT.Entries)
                result.Add(jgpt);

            return result;
        }

        public override string GetTitle(int index)
        {
            return "Respawn " + index;
        }

        public override void AddEntry()
        {
            JGPT.AddEntry();
        }

        public override void RemoveEntry(int index)
        {
            JGPT.RemoveEntry(index);
        }
    }
}
