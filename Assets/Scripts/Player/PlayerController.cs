using System;
using System.Threading.Tasks;
using Manager;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public DataManager dataManager;
        [SerializeField] public MissionManager missionManager;
        [SerializeField] public PowerUpManager powerUpManager;
        
        [SerializeField] public PlayerInput playerInput;
        [SerializeField] public PlayerMovement playerMovement;
        [SerializeField] public PlayerCollision playerCollision;
        [SerializeField] public PlayerStats playerStats;
        [SerializeField] public PlayerDifficulty playerDifficulty;
        [SerializeField] public PlayerCharacterSelector playerCharacterSelector;
        
        [SerializeField] public Behaviour currentBehaviour;
        [SerializeField] public SubBehaviour currentSubBehaviour;
        
        [Header("Lane")]
        [SerializeField] public int transitionSpeed;
        [SerializeField] public float laneDistance = 4; //distance between 2 lanes
        [SerializeField] public Lane currentLane;
        
        [NonSerialized] public CharacterController controller;

        [SerializeField] public Animator animator;
        public readonly int IsRunning = Animator.StringToHash("isRunning");
        public readonly int IsDead = Animator.StringToHash("isDead");

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
        
        public async void Respawning()
        {
            animator.SetBool(IsDead, false);
            animator.SetBool(IsRunning, true);
            await Task.Delay(1500);
            SetPlayerBehaviour(Behaviour.Running);
            powerUpManager.GodMode(3000);
        }
        
        private void Update()
        {
            if (MenuManager.currentMenu != MenuType.GameHud) return;
            
            if (Input.GetKeyDown(KeyCode.Alpha1) || playerInput.GetTapInput())
            {
                SetPlayerBehaviour(Behaviour.Running);
                animator.SetBool(IsRunning, true);
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

