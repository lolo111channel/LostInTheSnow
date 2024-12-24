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

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float mouseX = _cameraRotationXAction.action.ReadValue<float>();
            float mouseY = _cameraRotationYAction.action.ReadValue<float>();


            _body.transform.eulerAngles += new Vector3(0.0f, mouseX, 0.0f) * _sensitivity * Time.deltaTime;

            Vector3 cameraContainerEulerAngles = _cameraContainer.transform.eulerAngles;
            cameraContainerEulerAngles += new Vector3(-mouseY, 0.0f, 0.0f) * _sensitivity * Time.deltaTime;

            //cameraContainerEulerAngles.x = Mathf.Clamp(cameraContainerEulerAngles.x, -_cameraRotationYLimit, _cameraRotationYLimit);
            //Debug.Log(cameraContainerEulerAngles);
            _cameraContainer.transform.rotation = Quaternion.Euler(cameraContainerEulerAngles);

            
        }

    }

}

