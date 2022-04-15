using System;
using UnityEngine;

namespace Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public static bool gameOver;
        [SerializeField] private CanvasGroup gameOverMenu;
        private void Awake()
        {
            Time.timeScale = 1;
            gameOver = false;
            ToggleGameOverMenu(false);
        }

        private void Update()
        {
            if (gameOver)
            {
                Time.timeScale = 0;
                ToggleGameOverMenu(true);
            }
        }

        private void ToggleGameOverMenu(bool value)
        {
            if (value)
            {
                gameOverMenu.alpha = 1;
                gameOverMenu.blocksRaycasts = true;
                gameOverMenu.interactable = true;
            }
            else
            {
                gameOverMenu.alpha = 0;
                gameOverMenu.blocksRaycasts = false;
                gameOverMenu.interactable = false;
            }
        }
    }
}
