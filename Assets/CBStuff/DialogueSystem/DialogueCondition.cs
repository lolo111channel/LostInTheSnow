using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    [DialogueType("condition")]
    public class DialogueCondition : DialogueLineType
    {
        public string Id = "";
        public object[] Arguments = new object[] { };
        public JToken Dialogue;

        public DialogueCondition(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "condition";
            this.Id = dialogueLine["id"].ToString();
            this.Arguments = dialogueLine["arguments"].Select(x => x).ToArray();
            this.Dialogue = dialogueLine;
        }
    }
}
