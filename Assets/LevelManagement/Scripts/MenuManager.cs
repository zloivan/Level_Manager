using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagment
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Menu _mainMenu;
        [Space] [SerializeField] private Menu _settingsMenu;
        [SerializeField] private Menu _creditsMenu;


        [SerializeField] private Transform _menuParent;

        private static MenuManager _instance;
        public static MenuManager Instance => _instance;

        private readonly Stack<Menu> _menusStack = new Stack<Menu>();


        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }


            _instance = this;
            Initialize();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void Initialize()
        {
            if (_menuParent == null)
            {
                var parent = new GameObject("Menus");
                _menuParent = parent.transform;
            }

            var menuPrefabs = new[] {_settingsMenu, _mainMenu, _creditsMenu};

            foreach (var prefab in menuPrefabs)
            {
                if (prefab == null)
                    continue;

                var menuInstance = Instantiate(prefab, _menuParent);

                if (prefab == _mainMenu)
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