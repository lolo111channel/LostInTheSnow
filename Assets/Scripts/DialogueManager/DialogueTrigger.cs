using UnityEngine;

namespace LostInTheSnow
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] DialogueVars _vars;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                _vars.DialogueManager.StartDialogue(_vars.PathToDialogue, _vars.Header);
            }
        }
    }
}
