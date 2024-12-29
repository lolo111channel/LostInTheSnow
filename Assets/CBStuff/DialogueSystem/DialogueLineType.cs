using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    abstract public class DialogueLineType
    {
        public string Type { get; protected set; } = "";
        public DialogueLineType(JToken dialogueLine)
        {

        }
    }
}
