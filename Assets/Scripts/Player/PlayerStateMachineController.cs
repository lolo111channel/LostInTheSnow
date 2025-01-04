using System;
using UnityEngine;


namespace LostInTheSnow
{
    public class PlayerStateMachineController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SimpleStateMachineController _stateMachine;

        private void OnEnable()
        {
            _player.DialogueManager.DialogueStarted += DialogueStarted;
            _player.DialogueManager.DialogueFinished += DialogueFinished;
        }

        private void OnDisable()
        {
            _player.DialogueManager.DialogueStarted -= DialogueStarted;
            _player.DialogueManager.DialogueFinished -= DialogueFinished;
        }

        private void DialogueStarted()
        {
            _stateMachine.ChangeStateTo("DIALOGUE");
        }

        private void DialogueFinished()
        {
            _stateMachine.ChangeStateTo("GAMEPLAY");
        }
    }

}

