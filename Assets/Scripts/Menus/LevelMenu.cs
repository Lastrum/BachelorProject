using System;
using Manager;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;
        [SerializeField] private PlayerController playerController;
        
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI xpText;

        [SerializeField] private Button menuButton;

        private void Awake()
        {
            menuButton.onClick.AddListener(BackToMenuButton);
        }
        
        
        public void UpdateCoins()
        {
            coinsText.text = $"Coins: {PlayerStats.coins}";
            dataManager.data.TotalCoins += PlayerStats.coins;
            PlayerPrefs.SetInt("TotalCoins", dataManager.data.TotalCoins);
        }

        public void UpdateScore()
        {
            scoreText.text = $"Score: {playerController.playerStats.score}";

            if (playerController.playerStats.score > dataManager.data.HighScore)
            {
                dataManager.data.HighScore = (int) playerController.playerStats.score;
                scoreText.text = $"New Best Score: {playerController.playerStats.score}";
            }
        }
        
        
        public void UpdateXpText(string value)
        {
            xpText.text = value;
        }
        
        public void BackToMenuButton()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
