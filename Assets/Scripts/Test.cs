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

            if (dialogueManager.CurrentLine is DialogueLine)
            {
                DialogueLine line = (DialogueLine)dialogueManager.CurrentLine;
                Debug.Log(line.Arguments[1]);
                dialogueManager.NextLine();
            }

        }

        private void Update()
        {
            if (dialogueManager.IsDialogueRunning)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (dialogueManager.CurrentLine is DialogueLine)
                    {
                        DialogueLine line = (DialogueLine)dialogueManager.CurrentLine;
                        Debug.Log(line.Arguments[1]);
                    }
                    dialogueManager.NextLine();
                }
            }
        }
    }


}

