using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LostInTheSnow
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int _startGameSceneID = 1;
        [SerializeField] private AudioMixer _audioMixer;

        private const float _minVolume = -80.0f;
        private const float _maxVolume = 20.0f;

        [Range(_minVolume, _maxVolume)]
        public static float Volume = 0f;
        public static float PreviouseVolume = 0f;

        public void StartGame()
        {
            SceneManager.LoadScene(_startGameSceneID);
        }

        public void QuitGame()
        {
            Application.Quit();
        }


        public void SetFullscreen(Toggle toggle)
        {
            Screen.fullScreen = toggle.isOn;
        }


        public void SetVolume(Slider slider)
        {
            Volume = slider.value;
        }

        private void Awake()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            if (!Mathf.Approximately(Volume, PreviouseVolume))
            {
                _audioMixer.SetFloat("master", Volume);
            }

            PreviouseVolume = Volume;
        }

    }
}

