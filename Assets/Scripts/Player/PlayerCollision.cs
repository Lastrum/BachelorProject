using System;
using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Destroy(other.gameObject);
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
        }
    }
}
