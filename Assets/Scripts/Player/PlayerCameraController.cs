using UnityEngine;
using UnityEngine.InputSystem;

namespace LostInTheSnow
{ 
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _cameraContainer;
        [SerializeField] private GameObject _body;

        [SerializeField] private float _sensitivity = 50.0f;

        [SerializeField] private InputActionReference _cameraRotationXAction;
        [SerializeField] private InputActionReference _cameraRotationYAction;
        [SerializeField] private float _cameraRotationYLimit = 85.0f;

        private float _cameraRotX;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cameraRotX = _cameraContainer.transform.localRotation.x;
        }

        private void Update()
        {
            float mouseX = _cameraRotationXAction.action.ReadValue<float>();
            float mouseY = _cameraRotationYAction.action.ReadValue<float>();


            _body.transform.eulerAngles += new Vector3(0.0f, mouseX, 0.0f) * _sensitivity * Time.deltaTime;

           
            _cameraRotX -= (mouseY * _sensitivity) * Time.deltaTime;
            _cameraRotX = Mathf.Clamp(_cameraRotX, -_cameraRotationYLimit, _cameraRotationYLimit); 
            _cameraContainer.transform.localRotation = Quaternion.Euler(_cameraRotX, 0.0f, 0.0f);
            
        }

    }

}

