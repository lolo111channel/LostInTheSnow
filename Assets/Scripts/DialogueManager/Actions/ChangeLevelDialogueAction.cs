using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBStuff.DialogueSystem;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;


namespace LostInTheSnow
{
    [DialogueId("change_level")]
    public class ChangeLevelDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            int sceneId = (args[0] as JValue).Value<int>();
            SceneManager.LoadScene(sceneId);
        }
    }
}
