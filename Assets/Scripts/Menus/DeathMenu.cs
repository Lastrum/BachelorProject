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
        [SerializeField] private LevelMenu levelMenu;
        
        [SerializeField] private Button respawnButton;
        [SerializeField] private Button completeRun;

        private void Awake()
        {
            respawnButton.onClick.AddListener(RespawnButton);
            completeRun.onClick.AddListener(CompleteRunButton);
        }

        public void RespawnButton()
        {
            playerController.playerMovement.forwardSpeed = playerController.playerMovement.speed;
            MenuManager.SwitchMenu(MenuType.GameHud);
            playerController.Respawning();
        }

        public void CompleteRunButton()
        {
            MenuManager.SwitchMenu(MenuType.LevelMenu);
            levelMenu.UpdateCoins();
            levelMenu.UpdateScore();
        }
    }
}
