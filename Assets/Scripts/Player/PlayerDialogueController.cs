using System;
using LostInTheSnow;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDialogueController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InputActionReference _nextDialogueAction;

    private void OnEnable()
    {
        _nextDialogueAction.action.performed += NextDialoguePerformed;
    }

    private void OnDisable()
    {
        _nextDialogueAction.action.performed -= NextDialoguePerformed;
    }

    private void NextDialoguePerformed(InputAction.CallbackContext context)
    {
        _player.DialogueManager.NextLine();
    }
}
