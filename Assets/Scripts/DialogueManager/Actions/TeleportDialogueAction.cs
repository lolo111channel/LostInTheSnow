using CBStuff.DialogueSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("teleport")]
    public class TeleportDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject gameObject = args[0] as GameObject;
            CharacterController characterController = gameObject.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }
    
            float posX = ((JValue)args[1]).Value<float>();
            float posY = ((JValue)args[2]).Value<float>();
            float posZ = ((JValue)args[3]).Value<float>();

            gameObject.transform.position = new(posX, posY, posZ);

            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
    }
}
