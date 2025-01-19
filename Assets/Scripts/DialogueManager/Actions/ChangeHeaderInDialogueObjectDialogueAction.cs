using CBStuff.DialogueSystem;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("change_header_in_dialogue_object")]
    public class ChangeHeaderInDialogueObjectDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject gameObject = args[0] as GameObject;
            if (gameObject == null)
            {
                return;
            }

            DialogueObject dialogueObject = gameObject.GetComponent<DialogueObject>();
            dialogueObject.SetHeader(args[1].ToString());
        }
    }
}
