using System;
using Manager;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CameraType = Manager.CameraType;


namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
        [SerializeField] private Button playButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button statsButton;
        
        private void Awake()
        {
            playButton.onClick.AddListener(Play);
            shopButton.onClick.AddListener(Shop);
            settingsButton.onClick.AddListener(Settings);
            statsButton.onClick.AddListener(Stats);
        }

        private void Play()
        {
            MenuManager.SwitchMenu(MenuType.GameHud);
            playerController.playerCharacterSelector.SpawnCharacter();
            PlayerStats.coins = 0;
            playerController.playerStats.UpdateCoinsText();
        }
        
        private void Shop()
        {
            MenuManager.SwitchMenu(MenuType.ShopMenu);
            ShopManager.SwitchMenu(ShopMenuType.SubMenu);
        }
        
        private void Settings()
        {
            MenuManager.SwitchMenu(MenuType.SettingsMenu);
        }
        
        private void Stats()
        {
            Debug.Log("stats");
        }
        
    }
}
