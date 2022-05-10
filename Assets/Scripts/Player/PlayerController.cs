using System;
using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public PlayerInput playerInput;
        [SerializeField] public PlayerMovement playerMovement;
        [SerializeField] public PlayerCollision playerCollision;
        [SerializeField] public PlayerStats playerStats;
        [SerializeField] public PlayerDifficulty playerDifficulty;
        
        [SerializeField] public Behaviour currentBehaviour;
        [SerializeField] public SubBehaviour currentSubBehaviour;
        
        [Header("Lane")]
        [SerializeField] public int transitionSpeed;
        [SerializeField] public float laneDistance = 4; //distance between 2 lanes
        [SerializeField] public Lane currentLane;
        
        [NonSerialized] public CharacterController controller;

        [SerializeField] public Animator animator;
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsDead = Animator.StringToHash("isDead");

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            currentLane = Lane.Middle;

            currentBehaviour = Behaviour.Idle;
            currentSubBehaviour = SubBehaviour.Nothing;
        }
        
        public void SetPlayerBehaviour(Behaviour value)
        {
            currentBehaviour = value;
        }

        public void SetPlayerSubBehaviour(SubBehaviour value)
        {
            currentSubBehaviour = value;
        }
        
        private void Update()
        {
            if (MenuManager.currentMenu != MenuType.GameHud) return;
            
            if (Input.GetKeyDown(KeyCode.Alpha1) || playerInput.GetTapInput())
            {
                SetPlayerBehaviour(Behaviour.Running);
                animator.SetBool(IsRunning, true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Dead");
                animator.SetBool(IsDead, true);
                SetPlayerBehaviour(Behaviour.Dead);
            }
        }

        public enum Lane
        {
            Left,
            Middle,
            Right
        }

        public enum Behaviour
        {
            Idle,
            Running,
            Dead
        }

        public enum SubBehaviour
        {
            Nothing,
            Jumping,
            Sliding,
        }
    }
}

