using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public string Dialogue;

        public IDialogueConditionFunc Func;
        public DialogueCondition(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "condition";
            this.Id = dialogueLine["id"].ToString();
            this.Arguments = dialogueLine["arguments"].Select(x => x).ToArray();
            this.Dialogue = dialogueLine.ToString();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = typeof(IDialogueConditionFunc);
            var inheritingClasses = assembly.GetTypes().Select(x => x).Where(x => x.IsClass && !x.IsAbstract && type.IsAssignableFrom(x));

            if (inheritingClasses.Count() <= 0) return;

            var suitableClass = inheritingClasses.Select(x => x).Where(x => x.GetCustomAttribute<DialogueIdAttribute>().Id == this.Id).FirstOrDefault();

            if (suitableClass != null)
                Func = Activator.CreateInstance(suitableClass) as IDialogueConditionFunc;
        }
    }
}
