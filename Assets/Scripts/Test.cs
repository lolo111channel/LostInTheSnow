using UnityEngine;
using CBStuff.DialogueSystem;
using System.IO;
using System.Linq;

namespace LostInTheSnow
{

    public class Test : MonoBehaviour
    {
        private string testJson = @"
        {
            ""header1"": [
                {""type"":""dialogue"",""arguments"":[""You"", ""Test"",""""]},
                {""type"":""action"",""id"":""print"",""arguments"":[""Hello World""]},
                {
                    ""type"":""condition"",
                    ""id"":""test"",
                    ""arguments"":[true],
                    ""lines"": [
                        {""type"":""action"",""id"":""print"",""arguments"":[""Hello Condition""]}
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

        private void Start()
        {

            string path = Path.Combine(Application.dataPath, "Dialogues/ExampleDialogue.json");
            Debug.Log(path);
            DialogueLineType[] dialogueLines = GetDialogues.FromJsonFile(path,"header1");

            foreach (var line in dialogueLines)
            {

                if (line is DialogueAction)
                {

                    ((DialogueAction)line).Func.Action(((DialogueAction)line).Arguments);
                }

                if (line is DialogueCondition)
                {
  
                    DialogueCondition dialogueCondition = ((DialogueCondition)line);
                    Debug.Log(dialogueCondition.Arguments.Length);
                    if (dialogueCondition.Func.Condition(dialogueCondition.Arguments))
                    {

                        DialogueLineType[] dialogueLines1 = DialogueDeseralization.GetDialogues(dialogueCondition.Dialogue, "lines");
                        foreach (var line1 in dialogueLines1)
                        {
                            if (line1 is DialogueAction)
                            {
                                ((DialogueAction)line1).Func.Action(((DialogueAction)line1).Arguments);
                            }
                        }

                    } else
                    {
                        Debug.Log("False");
                    }
                  
                }
            }

        }
    }


}

