using UnityEngine;

namespace LostInTheSnow
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 100.0f;
        [SerializeField] private float _acceleration = 0.85f;
        [SerializeField] private float _friction = 0.25f;

        [SerializeField] private float _gravityStrength = 1.0f;

        [SerializeField] private Transform _body;
        [SerializeField] private Transform _cameraContainer;

        private CharacterController _characterController;
        private Vector3 _playerVelocity = new();

        public void Move(Vector2 dir)
        {
            float motionX = 0;
            float motionZ = 0;

            if (dir != Vector2.zero)
            {

                Vector3 moveDir = gameObject.transform.TransformDirection(new(dir.x, 0.0f, dir.y));

                motionX = Mathf.Lerp(_playerVelocity.x, _movementSpeed * moveDir.x, _acceleration);
                motionZ = Mathf.Lerp(_playerVelocity.z, _movementSpeed * moveDir.z, _acceleration);

                _playerVelocity = _playerVelocity.normalized;
                _playerVelocity = new Vector3(motionX, _playerVelocity.y ,motionZ);
                return;
            }

            motionX = Mathf.Lerp(_playerVelocity.x, 0.0f, _friction);
            motionZ = Mathf.Lerp(_playerVelocity.z, 0.0f, _friction);

            _playerVelocity = _playerVelocity.normalized;
            _playerVelocity = new Vector3(motionX, _playerVelocity.y, motionZ);


        }

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void FixedUpdate()
        {
            //_body.transform.forward = _cameraContainer.transform.forward;
            _characterController.Move(_playerVelocity);
        }
    }
}
