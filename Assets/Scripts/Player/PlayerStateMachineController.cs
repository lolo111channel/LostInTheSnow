using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace LostInTheSnow
{
    public class PlayerStateMachineController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SimpleStateMachineController _stateMachine;
        [SerializeField] private InputActionReference _escInput;
        [SerializeField] private GameObject _pauseMenu;

        private void OnEnable()
        {
            _player.DialogueManager.DialogueStarted += DialogueStarted;
            _player.DialogueManager.DialogueFinished += DialogueFinished;

            _escInput.action.performed += ESCInput;
        }


        private void OnDisable()
        {
            _player.DialogueManager.DialogueStarted -= DialogueStarted;
            _player.DialogueManager.DialogueFinished -= DialogueFinished;

            _escInput.action.performed -= ESCInput;
        }

        private void DialogueStarted()
        {
            if (_stateMachine.GetCurrentState().StateName != "PAUSEMENU")
            {
                _stateMachine.ChangeStateTo("DIALOGUE");
            }
        }

        private void DialogueFinished()
        {
            _stateMachine.ChangeStateTo("GAMEPLAY");
        }
        private void ESCInput(InputAction.CallbackContext context)
        {
            OpenOrClosePauseMenu();
        }
        public void OpenOrClosePauseMenu()
        {
            if (_stateMachine.GetCurrentState().StateName != "DIALOGUE")
            {
                if (_pauseMenu.activeSelf)
                {
                    _stateMachine.ChangeStateTo("GAMEPLAY");
                    _pauseMenu.SetActive(false);
                }
                else
                {
                    _stateMachine.ChangeStateTo("PAUSEMENU");
                    _pauseMenu.SetActive(true);
                }

            }
        }
    }


}

