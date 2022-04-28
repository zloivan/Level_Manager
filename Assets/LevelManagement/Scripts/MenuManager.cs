using System;
using UnityEngine;

namespace LevelManagment
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Menu _mainMenu;
        [Space] [SerializeField] private Menu _settingsMenu;
        [SerializeField] private Menu _creditsMenu;


        [SerializeField] private Transform _menuParent;

        private void Awake()
        {
            Initialize();
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
                    menuInstance.gameObject.SetActive(true);
                    menuInstance.Init();
                }
                else
                {
                    menuInstance.gameObject.SetActive(false);
                }
            }
        }
    }
}