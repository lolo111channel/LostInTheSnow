using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DialogueTypeAttribute : Attribute
    {
        public string DialogueType { get; private set; } = "";

        public DialogueTypeAttribute(string dialogueType) 
        { 
            this.DialogueType = dialogueType;
        }
    }
}
