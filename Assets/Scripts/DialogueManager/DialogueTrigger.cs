using UnityEngine;

namespace LostInTheSnow
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueVars _vars;
        [SerializeField] private bool _canRepeat = false;

        private bool _repeated = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !_repeated)
            {
                _vars.DialogueManager.StartDialogue(_vars.PathToDialogue, _vars.Header);

                if (!_canRepeat)
                {
                    _repeated = true;
                }

            }
        }
    }
}
