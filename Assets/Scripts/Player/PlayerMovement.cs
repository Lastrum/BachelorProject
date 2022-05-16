using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static Player.PlayerController;
using Debug = UnityEngine.Debug;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        [SerializeField] private TextMeshProUGUI modeText;
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        private bool isGrounded;

        [Header("Movement")]
        [SerializeField] public float maxForwardSpeed;
        [SerializeField] public float forwardSpeed;
        [SerializeField] public float jumpForce;
        [SerializeField] public float gravity;
        [SerializeField] public float slideLength;
        
        [NonSerialized] public Vector3 direction;
        [NonSerialized] public float speed;
        private Vector3 targetPosition;
        private Vector3 velocity;
        
        private bool jumped;
        private bool sliding;

        private void Awake()
        {
            jumped = false;
            sliding = false;
        }

        private void Update()
        {
            if (playerController.currentBehaviour is PlayerController.Behaviour.Idle) return;
            if (playerController.currentBehaviour is PlayerController.Behaviour.Dead)
            {
                return;
            }
            
            //Temp Remove later
            UpdateText();

            //IfGrounded
            if (isGrounded && jumped)
            {
                playerController.SetPlayerSubBehaviour(SubBehaviour.Nothing);
                jumped = false;
            }
            
            //Moves Forward
            direction.z = forwardSpeed;
            direction.y += gravity * Time.deltaTime;


            if (playerController.playerInput.GetUpInput())
            {
                playerController.currentSubBehaviour = SubBehaviour.Jumping;
            }
            
            if (playerController.playerInput.GetDownInput())
            {
                playerController.currentSubBehaviour = SubBehaviour.Sliding;
            }
            
            //Input for moving Left
            if (playerController.playerInput.GetLeftInput())
            {
                SwitchLane(Vector2.left);
            }
            //Input for moving Right
            if (playerController.playerInput.GetRightInput())
            {
                SwitchLane(Vector2.right);
            }
            
            HandleLane();
            SubBehaviourChecker();
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, playerController.transitionSpeed * Time.fixedDeltaTime);
            playerController.controller.center = playerController.controller.center;
        }
        
        private void FixedUpdate()
        {
            if (playerController.currentBehaviour is PlayerController.Behaviour.Idle) return;
            if (playerController.currentBehaviour is PlayerController.Behaviour.Dead)
            {
                playerController.controller.Move(direction * Time.deltaTime);
                return;
            };
            
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(groundCheck.transform.position, transform.TransformDirection(Vector3.down), out hit, 1, groundLayer))
            {
                //Debug.DrawRay(groundCheck.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            playerController.controller.Move(direction * Time.deltaTime);
        }
        
        private void SwitchLane(Vector2 direction)
        {
            if (direction == Vector2.left)
            {
                playerController.currentLane = playerController.currentLane switch
                {
                    Lane.Right => Lane.Middle,
                    Lane.Middle => Lane.Left,
                    Lane.Left => Lane.Left,
                    _ => Lane.Left
                };
            }
            if (direction == Vector2.right)
            {
                playerController.currentLane = playerController.currentLane switch
                {
                    Lane.Right => Lane.Right,
                    Lane.Middle => Lane.Right,
                    Lane.Left => Lane.Middle,
                    _ => Lane.Right
                };
            }
        }

        private void HandleLane()
        {
            //Calculate where we should be in the future
            targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            
            switch (playerController.currentLane)
            {
                case Lane.Left:
                    targetPosition += Vector3.left * playerController.laneDistance;
                    break;
                case Lane.Right:
                    targetPosition += Vector3.right * playerController.laneDistance;
                    break;
            }
        }

        private void SubBehaviourChecker()
        {
            switch (playerController.currentSubBehaviour)
            {
                case SubBehaviour.Jumping:
                    Jump();
                    break;
                case SubBehaviour.Sliding:
                    Slide();
                    break;
            }
        }

       private async void Jump()
        {
            if (isGrounded && !jumped)
            {
                direction.y = jumpForce;
                await Task.Delay(TimeSpan.FromSeconds(0.5f));
                jumped = true;
            }
        }
        
        private async void Slide()
        {
            jumped = false;
            direction.y = gravity;
            
            playerController.animator.SetBool("isSliding", true);
            
            await Task.Delay(TimeSpan.FromSeconds(slideLength));
            playerController.SetPlayerSubBehaviour(SubBehaviour.Nothing);
            playerController.animator.SetBool("isSliding", false);
        }
        
        private void UpdateText()
        {
            modeText.text = $"Mode: {playerController.currentSubBehaviour}";
        }

    }
}
