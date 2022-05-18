using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;
        
        [SerializeField] private Button giveCoinsButton;
        [SerializeField] private Button resetDataButton;
        [SerializeField] private Button loadDataButton;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            backButton.onClick.AddListener(BackToMainMenu);
            giveCoinsButton.onClick.AddListener(GiveCoins);
            resetDataButton.onClick.AddListener(ResetData);
            loadDataButton.onClick.AddListener(LoadData);
        }
        

        private void BackToMainMenu()
        {
            MenuManager.SwitchMenu(MenuType.MainMenu);
        }

        private void GiveCoins()
        {
            dataManager.data.TotalCoins += 5000;
        }

        private void ResetData()
        {
            dataManager.ResetData();
        }
        
        private void LoadData()
        {
            dataManager.UpdateData();
        }
    }
}
