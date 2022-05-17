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
        
        public float score;
        public float multiplier;

        public static int coins;
        
        private float distance;

        private delegate void UpdateCoins();
        private static UpdateCoins UpdateCoinsDelegate;
        
        private void Start()
        {
            UpdateCoinsDelegate += UpdateCoinsText;
            UpdateCoinsText();
        }

        public static void AddCoins(int value)
        {
            coins += value;
            UpdateCoinsDelegate.Invoke();
            
        }
        
        public void UpdateCoinsText()
        {
            coinText.text = $"Coins: {coins}";
        }
        
        private void Update()
        {
            if (playerController.currentBehaviour != PlayerController.Behaviour.Running) return;
            
            score = transform.position.z * multiplier;
            scoreText.text = $"Score: {score}";
        }
        
    }
}
