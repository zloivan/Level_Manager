using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManager
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Menu _mainMenuPrefab;
        [SerializeField] private Menu _settingsMenuPrefab;
        [SerializeField] private Menu _creditsMenuPrefab;

        [SerializeField] private Transform _menuHolder;


        private Stack<Menu> _menuStack = new Stack<Menu>();
        private void Awake()
        {
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            if (_menuHolder == null)
            {
                var menuObject = new GameObject("MenuHolder");
                _menuHolder = menuObject.transform;
            }

            Menu[] menuPrefabs = {_mainMenuPrefab, _settingsMenuPrefab, _creditsMenuPrefab};

            for (var i = 0; i < menuPrefabs.Length; i++)
            {
                if (menuPrefabs[i] != null)
                {
                    var menuInstance = Instantiate(menuPrefabs[i], _menuHolder);

                    if (menuPrefabs[i] != _mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
                else
                {
                    Debug.LogWarning($"MENUMANAGER InitializeMenus Error: reference to prefab {i} is not set for");
                }
                
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("MENUMANAGER OpenMenu ERROR: invalid menu instance");
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach (var menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            
            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        public void CloseCurrentMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("MENUMANAGER CloseCurrentMenu ERROR: no menus left to close.");
                return;
            }

            var currentMenu = _menuStack.Pop();
            currentMenu.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                var nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}