using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    [DialogueType("end")]
    public class DialogueEnd : DialogueLineType
    {
        public DialogueEnd(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "end";
        }
    }
}
