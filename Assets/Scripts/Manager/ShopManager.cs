using System;
using System.Collections.Generic;
using Menus.Shop;
using UnityEngine;

namespace Manager
{
    public enum ShopMenuType
    {
        SubMenu,
        Characters,
        Upgrades,
    }

    public class ShopManager : MonoBehaviour
    {
        private static List<ShopController> _shopControllersList;
        private static ShopController _lastActiveMenu;
        public static ShopMenuType currentShopMenu;

        private void Awake()
        {
            _shopControllersList = new List<ShopController>(GetComponentsInChildren<ShopController>());
        }

        protected void Start()
        {
            _shopControllersList.ForEach(x => x.ToggleCanvas(false));
            SwitchMenu(ShopMenuType.SubMenu);
        }

        public static void SwitchMenu(ShopMenuType type)
        {
            if (_lastActiveMenu != null)
            {
                _lastActiveMenu.ToggleCanvas(false);
            }

            ShopController desiredMenu = _shopControllersList.Find(x => x.menuType == type);
            if (desiredMenu != null)
            {
                desiredMenu.ToggleCanvas(true);
                _lastActiveMenu = desiredMenu;
                currentShopMenu = type;
            }
            else
            {
                Debug.Log($"The {type} Canvas was not found!");
            }
        }
    }
}

