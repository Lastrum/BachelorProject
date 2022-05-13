using System;
using Manager;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class DeathMenu : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Button respawnButton;
        [SerializeField] private Button menuButton;

        private void Awake()
        {
            respawnButton.onClick.AddListener(RespawnButton);
            menuButton.onClick.AddListener(BackToMenuButton);
        }

        public void RespawnButton()
        {
            playerController.playerMovement.forwardSpeed = playerController.playerMovement.speed;
            MenuManager.SwitchMenu(MenuType.GameHud);
            playerController.Respawning();
        }

        public void BackToMenuButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}
