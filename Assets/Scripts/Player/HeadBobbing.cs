using System;
using UnityEngine;

namespace LostInTheSnow
{
    public class HeadBobbing : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private float _maxPosY = 0.01f;
        [SerializeField] private float _frequency = 1.0f;

        private float _currentPosY = 0.0f;
        private float _time = 0.0f;


        private void OnEnable()
        {
            _playerMovement.OnMoving += OnMoving;
            _playerMovement.OnStopped += OnStopped;
        }

        private void Start()
        {
            _currentPosY = gameObject.transform.localPosition.y;
        }

        private void OnMoving()
        {
            // y = sin(4x) * (5/10) + 0.6 -> pattern
            float newLocalPosY = (Mathf.Sin(_frequency * _time) * _maxPosY * Time.deltaTime) + _currentPosY;

            Vector3 newLocalPos = new();
            newLocalPos.x = gameObject.transform.localPosition.x;
            newLocalPos.y = newLocalPosY;
            newLocalPos.z = gameObject.transform.localPosition.z;

            gameObject.transform.localPosition = newLocalPos;
            _time += Time.deltaTime;
        }

        private void OnStopped()
        {
            _time = 0.0f;
      
            Vector3 newLocalPos = new();
            newLocalPos.x = gameObject.transform.localPosition.x;
            newLocalPos.y = _currentPosY;
            newLocalPos.z = gameObject.transform.localPosition.z;

            gameObject.transform.localPosition = newLocalPos;
        }
    }
}
