using UnityEngine;
using CBStuff.DialogueSystem;
using System.IO;
using System.Linq;

namespace LostInTheSnow
{

    public class Test : MonoBehaviour
    {

        [SerializeField] private DialogueManager dialogueManager;

        private void Start()
        {
            string path = "Dialogues/ExampleDialogue.json";
            dialogueManager.StartDialogue(path,"header1");


        }
    }


}

