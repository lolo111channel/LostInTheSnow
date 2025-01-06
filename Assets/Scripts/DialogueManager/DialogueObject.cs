using UnityEngine;

namespace LostInTheSnow
{
    public class DialogueObject : MonoBehaviour, IInteractionable, IHint
    {
        [SerializeField] private DialogueVars _vars;
        [SerializeField] private string _objectName = "";

        public bool Interaction(GameObject whoInteracted, float time = 0)
        {
            _vars.DialogueManager.StartDialogue(_vars.PathToDialogue, _vars.Header);
            return true;
        }
        public string GetHint()
        {
            return $"Interact with {_objectName}";
        }
    }

}

