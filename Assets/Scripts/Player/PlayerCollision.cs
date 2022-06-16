using System;
using Manager;
using Objects;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private void HandleDeath()
        {
            playerController.animator.SetBool(playerController.IsDead, true);
            playerController.SetPlayerBehaviour(PlayerController.Behaviour.Dead);
            playerController.SetPlayerSubBehaviour(PlayerController.SubBehaviour.Nothing);
                
            MenuManager.SwitchMenu(MenuType.DeathMenu);
                
            playerController.missionManager.CheckDistanceMission(playerController.playerStats.score);
                
            playerController.playerMovement.speed = playerController.playerMovement.forwardSpeed;
                
            playerController.playerMovement.direction.x = 0;
            playerController.playerMovement.direction.y = playerController.playerMovement.gravity;
            playerController.playerMovement.direction.z = 0;
            playerController.playerMovement.forwardSpeed = 0;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            //Obstacles
            if (other.CompareTag("Obstacle"))
            {
                if (playerController.powerUpManager.godMode)
                {
                    Destroy(other.gameObject);
                    return;
                }
                Destroy(other.gameObject);
                HandleDeath();
            }
            
            //Water
            if (other.CompareTag("Water"))
            {
                if (playerController.powerUpManager.godMode) return;
                HandleDeath();
            }
            
            
            //Power Ups
            if (other.CompareTag("PowerUp"))
            {
                playerController.audioManager.puwerUpAudio.Play();
                PowerUp p = other.GetComponent<PowerUp>();
                switch (p.power)
                {
                    case Power.Jumping:
                        playerController.powerUpManager.Jumping(playerController.powerUpManager.jumpLength);
                        break;
                    case Power.CoinMagnet:
                        playerController.powerUpManager.MagnetMode(playerController.powerUpManager.magnetLength);
                        break;
                    case Power.GodMode:
                        playerController.powerUpManager.GodMode(playerController.powerUpManager.godModeLength);
                        break;
                }
            }
            
            //Coins
            if (other.CompareTag("Coin"))
            {
                playerController.audioManager.coinAudio.Play();
            }
        }
    }
}
