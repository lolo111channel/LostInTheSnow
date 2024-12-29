using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    [DialogueType("dialogue")]
    public class DialogueLine : DialogueLineType
    {
        public string[] Arguments = new string[] { };
        public DialogueLine(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "dialogue";
            this.Arguments = dialogueLine["arguments"].Select(x => (string)x).ToArray();
        }
    }
}
