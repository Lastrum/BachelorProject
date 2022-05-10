using System;
using UnityEngine;

namespace Player
{
    public class PlayerDifficulty : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private void Update()
        {
            if (playerController.currentBehaviour != PlayerController.Behaviour.Running) return;
            
            if (playerController.playerMovement.forwardSpeed <= playerController.playerMovement.maxForwardSpeed)
            {
                playerController.playerMovement.forwardSpeed += 0.1f * Time.deltaTime;
            }
            else
            {
                playerController.playerMovement.forwardSpeed = 20;
            }
        }
    }
}
