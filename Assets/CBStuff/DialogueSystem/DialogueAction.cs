using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;

namespace CBStuff.DialogueSystem
{
    [DialogueType("action")]
    public class DialogueAction : DialogueLineType
    {
        public string Id = "";
        public object[] Arguments = new object[]{ };
        public IDialogueActionFunc Func;
        public DialogueAction(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "action";
            this.Id = dialogueLine["id"].ToString();
            this.Arguments = dialogueLine["arguments"].Select(x => x).ToArray();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = typeof(IDialogueActionFunc);
            var inheritingClasses = assembly.GetTypes().Select(x => x).Where(x => x.IsClass && !x.IsAbstract && type.IsAssignableFrom(x));

            if (inheritingClasses.Count() <= 0) return;

            var suitableClass = inheritingClasses.Select(x => x).Where(x => x.GetAttribute<DialogueActionIdAttribute>().Id == this.Id).FirstOrDefault();

            if (suitableClass != null)
                Func = Activator.CreateInstance(suitableClass) as IDialogueActionFunc;


        }
    }
}
