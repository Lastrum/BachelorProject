using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] public PlayerController playerController;
        [SerializeField] public TextMeshProUGUI scoreText;
        [SerializeField] public TextMeshProUGUI coinText;

        private static PlayerController staticPlayerController;
        
        public float score;
        public float multiplier;

        public static int coins;
        
        private float distance;

        private delegate void UpdateCoins();
        private static UpdateCoins UpdateCoinsDelegate;
        
        private void Start()
        {
            staticPlayerController = playerController;
            
            UpdateCoinsDelegate += UpdateCoinsText;
            UpdateCoinsText();
        }

        public static void AddCoins(int value)
        {
            coins += value;
            UpdateCoinsDelegate.Invoke();
            MissionChecker(value);
        }
        
        public void UpdateCoinsText()
        {
            coinText.text = $"Coins: {coins}";
        }

        private static void MissionChecker(int value)
        {
            staticPlayerController.missionManager.CheckCoinMission(value);
        }
        
        private void Update()
        {
            if (playerController.currentBehaviour != PlayerController.Behaviour.Running) return;
            
            score = transform.position.z * multiplier;
            score = Mathf.Round(score);
            scoreText.text = $"Score: {score}";
        }
        
    }
}
