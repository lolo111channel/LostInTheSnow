using UnityEngine;
using CBStuff.DialogueSystem;

namespace LostInTheSnow
{

    public class Test : MonoBehaviour
    {
        private void Start()
        {
            DialogueLineType[] dialogueLines = DialogueDeseralization.GetDialogues("", "header1");

            foreach (var line in dialogueLines)
            {
                if (line is DialogueLine)
                {
                    Debug.Log("Dialogue");
                }

                if (line is DialogueAction)
                {
                    Debug.Log("Action");
                    ((DialogueAction)line).Func.Action(((DialogueAction)line).Arguments);
                }

                if (line is DialogueCondition)
                {
                    Debug.Log("Condition");
                  
                }

                if (line is DialogueEnd)
                {
                    Debug.Log("End");
                }
            }

        }
    }


}

