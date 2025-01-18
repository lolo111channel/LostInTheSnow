using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBStuff.DialogueSystem;
using UnityEngine;
using UnityEngine.Playables;

namespace LostInTheSnow
{
    [DialogueId("play_timeline")]
    public class PlayTimelineDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject gameObject = args[0] as GameObject;
            PlayableDirector playableDirector = gameObject.GetComponent<PlayableDirector>();


            playableDirector.Play();
        }
    }
}
