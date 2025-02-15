using System;
using UnityEngine;

namespace LostInTheSnow
{
    public class PlayerSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _footstepsInSnow;
        [SerializeField] private AudioSource _footstepsInPlank;

        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerGetSurface _playerGetSurface;

        private void Start()
        {
            _playerMovement.OnMoving += OnMoving;
            _playerMovement.OnStopped += OnStopped;
        }

        private void OnMoving()
        {
            if (!_footstepsInSnow.isPlaying)
            {
                if (_playerGetSurface.CurrentSurface == SURFACES.SNOW)
                {
                    _footstepsInPlank.Stop();
                    _footstepsInSnow.Play();
                }
            }

            if (!_footstepsInPlank.isPlaying)
            {
                if (_playerGetSurface.CurrentSurface == SURFACES.PLANK)
                {
                    _footstepsInSnow.Stop();
                    _footstepsInPlank.Play();
                }
            }

        }
        private void OnStopped()
        {
            if (_footstepsInSnow.isPlaying)
            {
                _footstepsInSnow.Stop();
            }

            if (_footstepsInPlank.isPlaying)
            {
                _footstepsInPlank.Stop();
            }
        }
    }
}
