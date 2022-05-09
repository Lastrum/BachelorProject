using System;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
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

        private static void Play()
        {
            MenuManager.SwitchMenu(MenuType.GameHud);
        }
        
        private static void Shop()
        {
            Debug.Log("shop");
        }
        
        private static void Settings()
        {
            Debug.Log("settings");
        }
        
        private static void Stats()
        {
            Debug.Log("stats");
        }
    }
}
