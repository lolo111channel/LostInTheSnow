using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DialogueIdAttribute : Attribute
    {
        public string Id { get; private set; } = "";
        public DialogueIdAttribute(string id) 
        {
            this.Id = id;
        }
    }
}
