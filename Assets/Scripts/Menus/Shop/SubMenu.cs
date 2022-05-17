using Manager;
using UnityEngine;
using UnityEngine.UI;
using CameraType = Manager.CameraType;

namespace Menus.Shop
{
    public class SubMenu : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button charactersButton;
        [SerializeField] private Button upgradesButton;

        private void Awake()
        {
            backButton.onClick.AddListener(BackToMainMenu);
            charactersButton.onClick.AddListener(CharactersMenu);
            upgradesButton.onClick.AddListener(UpgradesMenu);
        }
        
        private static void BackToMainMenu()
        {
            MenuManager.SwitchMenu(MenuType.MainMenu);
        }

        private static void CharactersMenu()
        {
            ShopManager.SwitchMenu(ShopMenuType.Characters);
            CameraManager.SwitchCamera(CameraType.ShopCamera);
        }

        private static void UpgradesMenu()
        {
            ShopManager.SwitchMenu(ShopMenuType.Upgrades);
        }
    }
}
