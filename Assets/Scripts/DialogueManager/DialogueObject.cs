using LostInTheSnow;
using UnityEngine;

public class DialogueObject : MonoBehaviour, IInteractionable, IHint
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private string _pathToDialogue;
    [SerializeField] private string _headerName;
    [SerializeField] private string _objectName = "";

    public bool Interaction(GameObject whoInteracted, float time = 0)
    {
        _dialogueManager.StartDialogue(_pathToDialogue, _headerName);
        return true;
    }
    public string GetHint()
    {
        return $"Interact with {_objectName}";
    }
}
