using SampleGame;
using UnityEngine;

namespace LevelManagment
{
    public class Menu : MonoBehaviour
    {
        private Menu _settingsMenuInstance;
        private Menu _creditsMenuInstance;

        private void Start()
        {
            var transformParent = transform.parent;
            _settingsMenuInstance = transformParent.Find("SettingsMenu(Clone)")?.GetComponent<Menu>();
            _creditsMenuInstance = transformParent.Find("CreditsMenu(Clone)")?.GetComponent<Menu>();
        }

        public void OnPlayButtonClick()
        {
            if (GameManager.Instance != null) GameManager.Instance.LoadNextLevel();
        }

        public void OnCreditsButtonClick()
        {
            MenuManager.Instance.OpenMenu(_creditsMenuInstance);
        }

        public void OnSettingsButtonClick()
        {
            MenuManager.Instance.OpenMenu(_settingsMenuInstance);
        }

        public void OnBackButtonClick()
        {
            MenuManager.Instance.CloseMenu();
        }

        public void OnQuitButtonClick()
        {
        }

        public void Init()
        {
        }
    }
}