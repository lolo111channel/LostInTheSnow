using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LostInTheSnow
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerInteraction _playerInteraction;
        
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private InputActionReference _interactionAction;

        private bool _interactionStart = false;
        private float _interactionTime = 0.0f;

        private void OnEnable()
        {
            _interactionAction.action.started += InteractionStarted;
            _interactionAction.action.canceled += InteractionCanceled;
        }

        private void OnDisable()
        {
            _interactionAction.action.started -= InteractionStarted;
            _interactionAction.action.canceled -= InteractionCanceled;
        }

        private void InteractionStarted(InputAction.CallbackContext context)
        {
            _interactionTime = 0.0f;
            _interactionStart = true;
        }

        private void InteractionCanceled(InputAction.CallbackContext context)
        {
            _interactionStart = false;
        }



        private void FixedUpdate()
        {
            if (_interactionStart) 
            { 
                _interactionTime += Time.deltaTime;
                if (_playerInteraction.Interaction(_interactionTime))
                {
                    _interactionStart = false;
                }

            }

            _playerMovement.Move(_moveAction.action.ReadValue<Vector2>());
        }
    }

}
