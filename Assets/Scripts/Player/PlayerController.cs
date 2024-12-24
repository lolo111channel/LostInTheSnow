using UnityEngine;
using UnityEngine.InputSystem;

namespace LostInTheSnow
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private InputActionReference _moveAction;


        private void FixedUpdate()
        {
            _playerMovement.Move(_moveAction.action.ReadValue<Vector2>());
        }
    }

}
