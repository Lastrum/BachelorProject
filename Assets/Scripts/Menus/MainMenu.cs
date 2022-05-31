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
        [SerializeField] private Button missionButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button statsButton;
        
        private void Awake()
        {
            playButton.onClick.AddListener(Play);
            missionButton.onClick.AddListener(Mission);
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

        private void Mission()
        {
            MenuManager.SwitchMenu(MenuType.MissionsMenu);
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
