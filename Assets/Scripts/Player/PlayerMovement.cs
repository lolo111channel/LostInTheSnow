using UnityEngine;

namespace LostInTheSnow
{
    public class PlayerMovement : MonoBehaviour
    {
        public delegate void Moving();
        public event Moving OnMoving;
        public event Moving OnStopped;


        [SerializeField] private float _movementSpeed = 100.0f;
        [SerializeField] private float _acceleration = 0.85f;
        [SerializeField] private float _friction = 0.25f;

        [SerializeField] private float _gravityStrength = 1.0f;

        [SerializeField] private Transform _body;
        [SerializeField] private Transform _cameraContainer;

        private CharacterController _characterController;
        private Vector3 _playerVelocity = new();

        private bool _isPlayerGrounded = false;

        public void Move(Vector2 dir)
        {
            float motionX = 0;
            float motionZ = 0;

            Vector2 xYVelocity = new();

            if (dir != Vector2.zero && _characterController.isGrounded)
            {

                Vector3 moveDir = gameObject.transform.TransformDirection(new(dir.x, 0.0f, dir.y));

                motionX = Mathf.Lerp(_playerVelocity.x, _movementSpeed * moveDir.x, _acceleration);
                motionZ = Mathf.Lerp(_playerVelocity.z, _movementSpeed * moveDir.z, _acceleration);



                xYVelocity = new Vector2(motionX, motionZ);
                xYVelocity = xYVelocity.normalized;
                _playerVelocity = new(xYVelocity.x, _playerVelocity.y, xYVelocity.y);

                OnMoving?.Invoke();
                return;
            }

            motionX = Mathf.Lerp(_playerVelocity.x, 0.0f, _friction);
            motionZ = Mathf.Lerp(_playerVelocity.z, 0.0f, _friction);

            xYVelocity = new Vector2(motionX, motionZ);
            xYVelocity = xYVelocity.normalized;
            _playerVelocity = new(xYVelocity.x, _playerVelocity.y, xYVelocity.y);

            OnStopped?.Invoke();
        }

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Debug.Log(_playerVelocity);
            Debug.Log(_characterController.isGrounded);
            if (!_characterController.isGrounded)
            {
                if (_isPlayerGrounded)
                {
                    _playerVelocity.y = 0.0f;
                    _isPlayerGrounded = false;
                }

                _playerVelocity.y -= _gravityStrength * Time.deltaTime;
            } 
            else
            {
                _playerVelocity.y = -2.0f;
                _isPlayerGrounded = true;
            }
            
        }

        private void FixedUpdate()
        {

            _characterController.Move(_playerVelocity);

        }
    }
}
