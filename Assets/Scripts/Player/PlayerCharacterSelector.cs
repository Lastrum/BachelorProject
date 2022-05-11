using System;
using UnityEngine;

namespace Player
{
    public class PlayerCharacterSelector : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
        public void SpawnCharacter()
        {
          Instantiate(playerController.dataManager.SelectedCharacter.Prefab, transform);
          GetAnimator();
        }

        private void GetAnimator()
        {
            playerController.animator = GetComponentInChildren<Animator>();
        }
    }
}
