
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
        private static List<MenuController> menuControllersList;
        private static MenuController lastActiveMenu;
        public static MenuType currentMenu;
        private void Awake()
        {
            menuControllersList = new List<MenuController>(GetComponentsInChildren<MenuController>());
        }

        protected void Start()
        {
            menuControllersList.ForEach(x => x.ToggleCanvas(false));
            SwitchMenu(MenuType.MainMenu);
        }

        public static void SwitchMenu(MenuType type)
        {
            if (lastActiveMenu != null)
            {
                lastActiveMenu.ToggleCanvas(false);
            }
            
            MenuController desiredMenu = menuControllersList.Find(x => x.menuType == type);
            if (desiredMenu != null)
            {
                desiredMenu.ToggleCanvas(true);
                lastActiveMenu = desiredMenu;
                currentMenu = type;
            }
            else
            {
                Debug.Log($"The {type} Canvas was not found!");
            }
        }
    }
}
