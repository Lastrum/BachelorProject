using System;
using System.Collections.Generic;
using System.Linq;
using Menus;
using UnityEngine;

namespace Manager
{
    public enum MenuType
    {
        MainMenu,
        DeathMenu,
        GameHud,
        ShopMenu,
        SettingsMenu,
        StatsMenu,
        LoadingScreen
    }
    
    public class MenuManager : MonoBehaviour
    {
        private static List<MenuController> _menuControllersList;
        private static MenuController _lastActiveMenu;
        public static MenuType currentMenu;
        private void Awake()
        {
            _menuControllersList = new List<MenuController>(GetComponentsInChildren<MenuController>());
        }

        protected void Start()
        {
            _menuControllersList.ForEach(x => x.ToggleCanvas(false));
            SwitchMenu(MenuType.MainMenu);
        }

        public static void SwitchMenu(MenuType type)
        {
            if (_lastActiveMenu != null)
            {
                _lastActiveMenu.ToggleCanvas(false);
            }
            
            MenuController desiredMenu = _menuControllersList.Find(x => x.menuType == type);
            if (desiredMenu != null)
            {
                desiredMenu.ToggleCanvas(true);
                _lastActiveMenu = desiredMenu;
                currentMenu = type;
            }
            else
            {
                Debug.Log($"The {type} Canvas was not found!");
            }
        }
    }
}
