using System;
using UnityEngine;

namespace Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public static bool gameOver;
        public static bool isGameStarted;
        [SerializeField] private CanvasGroup gameOverMenu;
        [SerializeField] private CanvasGroup startMenu;
        private void Awake()
        {
            Time.timeScale = 1;
            gameOver = false;
            isGameStarted = false;
        }

        private void Start()
        {
            ToggleStartMenu(true);
            ToggleGameOverMenu(false);
        }

        private void Update()
        {
            if (gameOver)
            {
                Time.timeScale = 0;
                ToggleGameOverMenu(true);
            }

            if (Input.GetKeyDown(KeyCode.Space) || SwipeManager.tap)
            {
                isGameStarted = true;
                ToggleStartMenu(false);
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

        private void ToggleStartMenu(bool value)
        {
            if (value)
            {
                startMenu.alpha = 1;
                startMenu.blocksRaycasts = true;
                startMenu.interactable = true;
            }
            else
            {
                startMenu.alpha = 0;
                startMenu.blocksRaycasts = false;
                startMenu.interactable = false;
            }
        }
    }
}
