using CBStuff.DialogueSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("set_active")]
    public class SetActiveDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject gameobject = args[0] as GameObject;
            if (gameobject == null)
            {
                return;
            }

            bool args1 = (args[1] as JToken).Value<bool>();
            gameobject.SetActive(args1);
        }
    }
}
