using CBStuff.DialogueSystem;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("destroy_object")]
    public class DestroyObjectDiaglogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject gameobject = args[0] as GameObject;
            Object.Destroy(gameobject);
        }
    }
}
