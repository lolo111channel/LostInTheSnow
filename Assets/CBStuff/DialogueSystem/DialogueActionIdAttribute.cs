using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DialogueActionIdAttribute : Attribute
    {
        public string Id { get; private set; } = "";
        public DialogueActionIdAttribute(string id) 
        {
            this.Id = id;
        }
    }
}
