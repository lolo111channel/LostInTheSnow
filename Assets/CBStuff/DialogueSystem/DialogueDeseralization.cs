using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CBStuff.DialogueSystem
{
    public class DialogueDeseralization
    {
        public static DialogueLineType[] GetDialogues(string json,string headerName)
        {
            List<DialogueLineType> dialogueLineTypes = new();

            
            var deserializedObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            bool isHasHeader = deserializedObject.Keys.Select(x => x).Where(x => x == headerName).Count() > 0 ? true : false;

            if (!isHasHeader) return dialogueLineTypes.ToArray();
            
            JArray headerDialogues = deserializedObject[headerName] as JArray;
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type baseType = typeof(DialogueLineType);
            var derivedType = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && baseType.IsAssignableFrom(x));

            foreach (var line in headerDialogues)
            {
                var selectedType = derivedType.Select(x => x).Where(x => x.GetCustomAttribute<DialogueTypeAttribute>().DialogueType == line["type"].ToString()).FirstOrDefault();
                if (selectedType == null) continue;

                object instance = Activator.CreateInstance(selectedType, line);
                dialogueLineTypes.Add(instance as DialogueLineType);
            }


            return dialogueLineTypes.ToArray();
        }
    }
}
