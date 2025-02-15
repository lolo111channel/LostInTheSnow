using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBStuff.DialogueSystem;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("play_sound")]
    public class PlaySoundDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject obj = (GameObject)args[0];
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null )
            {
                audioSource.Play();
            }
        }
    }
}
