using SampleGame;
using UnityEngine;

namespace LevelManagement.Menus
{
    public class MainMenu : Menu
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

        public override void OnBackButtonClick()
        {
            Application.Quit();
        }
    }
}