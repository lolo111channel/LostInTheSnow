using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LostInTheSnow
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int _startGameSceneID = 1;
        [SerializeField] private Toggle _toogle;

        public void StartGame()
        {
            SceneManager.LoadScene(_startGameSceneID);
        }

        public void QuitGame()
        {
            Application.Quit();
        }



        public void SetResolution(int value)
        {

        }

        public void SetFullscreen(Toggle toggle)
        {
            Screen.fullScreen = toggle.isOn;
            Debug.Log(toggle.isOn);

        }

        private void Awake()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
    }
}

