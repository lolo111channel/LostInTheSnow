using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    [DialogueType("action")]
    public class DialogueAction : DialogueLineType
    {
        public string Id = "";
        public object[] Arguments = new object[]{ };
        public IDialogueActionFunc Func;
        public float Seconds = 0;
        public DialogueAction(JToken dialogueLine) : base(dialogueLine)
        {
            this.Type = "action";
            this.Id = dialogueLine["id"].ToString();
            this.Arguments = dialogueLine["arguments"].Select(x => x).ToArray();
            this.Seconds = dialogueLine["sec"].Value<float>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = typeof(IDialogueActionFunc);
            var inheritingClasses = assembly.GetTypes().Select(x => x).Where(x => x.IsClass && !x.IsAbstract && type.IsAssignableFrom(x));

            if (inheritingClasses.Count() <= 0) return;

            var suitableClass = inheritingClasses.Select(x => x).Where(x => x.GetCustomAttribute<DialogueIdAttribute>().Id == this.Id).FirstOrDefault();

            if (suitableClass != null)
                Func = Activator.CreateInstance(suitableClass) as IDialogueActionFunc;


        }
    }
}
