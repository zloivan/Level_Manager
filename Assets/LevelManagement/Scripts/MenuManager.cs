using System.Collections.Generic;
using LevelManagement.Menus;
using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        #region SerielizedFields

        [SerializeField] private MainMenu _mainMenuPrefab;

        [Space] [SerializeField] private SettingsMenu _settingsMenuPrefab;
        [SerializeField] private CreditsMenu _creditsMenuPrefab;
        [SerializeField] private Transform _menuParent;

        #endregion


        #region Fields

        private readonly Stack<Menu> _menusStack = new Stack<Menu>();

        #endregion


        #region Properties

        private static MenuManager instance;
        public static MenuManager Instance => instance;

        #endregion


        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }


            instance = this;
            Initialize();
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        private void Initialize()
        {
            if (_menuParent == null)
            {
                var parent = new GameObject("Menus");
                _menuParent = parent.transform;
            }

            Menu[] menuPrefabs = {_settingsMenuPrefab, _mainMenuPrefab, _creditsMenuPrefab};

            foreach (var prefab in menuPrefabs)
            {
                if (prefab == null)
                    continue;

                var menuInstance = Instantiate(prefab, _menuParent);

                if (prefab == _mainMenuPrefab)
                {
                    OpenMenu(menuInstance);
                }
                else
                {
                    menuInstance.gameObject.SetActive(false);
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("MENUMANAGER OpenMenu Error: Trying to open instance of menu that is null");
                return;
            }

            menuInstance.gameObject.SetActive(true);
            menuInstance.Init();
            _menusStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (_menusStack.Count == 0)
            {
                return;
            }

            var previewMenu = _menusStack.Pop();
            previewMenu.gameObject.SetActive(false);

            if (_menusStack.Count > 0)
            {
                var nextMenu = _menusStack.Peek();
                nextMenu.gameObject.SetActive(true);
                nextMenu.Init();
            }
        }
    }
}