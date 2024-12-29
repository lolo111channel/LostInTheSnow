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
        private static string testJson = @"
        {
            ""header1"": [
                {""type"":""dialogue"",""arguments"":[""You"", ""Test"",""""]},
                {""type"":""action"",""id"":""print"",""arguments"":[""Hello World""]},
                {
                    ""type"":""condition"",
                    ""id"":""Test"",
                    ""arguments"":[true],
                    ""lines"": [
                        {""type"":""dialogue"",""arguments"":[""You"", ""Test in the condition"",""""]},
                        {""type"":""dialogue"",""arguments"":[""You"", ""Test in the condition"",""""]}
                    ]
                },

                {""type"":""dialogue"",""arguments"":[""You"", ""Test after the condition"",""""]},
                {""type"":""end""}
            ],

            ""header2"": [
                {""type"":""dialogue"",""arguments"":[""You"", ""Header 2"",""""]},
                {""type"":""end""}
        ]
        }";

        public static DialogueLineType[] GetDialogues(string json,string headerName)
        {
            List<DialogueLineType> dialogueLineTypes = new();

            json = testJson;
            var deserializedObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            bool isHasHeader = deserializedObject.Keys.Select(x => x).Where(x => x == headerName).Count() > 0 ? true : false;
            if (!isHasHeader) return null;
            
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
