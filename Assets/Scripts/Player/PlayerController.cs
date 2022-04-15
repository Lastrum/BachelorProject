using System;
using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float maxSpeed;
        
        [SerializeField] private float laneDistance = 4; //distance between 2 lanes
        [SerializeField] private int transitionSpeed;

        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity = -12f;
        private Vector3 velocity;
        
        [SerializeField] private Animator animator;

        [Header("Grounded")]
        [SerializeField] private bool isGrounded;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        
        [Header("Sliding")]
        [SerializeField] private bool isSliding = false;
        [SerializeField] private float slideDuration = 1.5f;
        
        private CharacterController controller;
        private Vector3 direction;
        private int desiredLane = 1; //0:Left 1:Middle 2:Right
        private static readonly int IsSliding = Animator.StringToHash("isSliding");
        private static readonly int IsGameStarted = Animator.StringToHash("isGameStarted");
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");

        private void Start()
        {
            isGrounded = true;
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (!PlayerManager.isGameStarted || PlayerManager.gameOver) return;

            animator.SetBool(IsGameStarted, true);
            
            //Increase Speed
            if (forwardSpeed < maxSpeed)
            {            
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
            }
            
            direction.z = forwardSpeed;
            direction.y += gravity * Time.deltaTime;
            
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
            animator.SetBool(IsGrounded, isGrounded);
            
            Debug.Log(isGrounded);
            
            if (isGrounded && velocity.y < 0)
                velocity.y = -1f;
            
            //Jump Check
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
                    Jump();

                if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown && !isSliding)
                    StartCoroutine(Slide());
            }
            
            //Swipe
            if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown)
            {
                StartCoroutine(Slide());
            }
            
            //Get Input
            if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }

            //Calculate where we should be in the future
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.fixedDeltaTime);
            controller.center = controller.center;
            
        }
        
        private void FixedUpdate()
        {
            if (!PlayerManager.isGameStarted || PlayerManager.gameOver) return;
            controller.Move(direction * Time.deltaTime);
        }

        private void Jump()
        {
            StopCoroutine(Slide());
            //animator.SetBool("isSliding", false);
            //animator.SetTrigger("jump");
            controller.center = Vector3.zero;
            controller.height = 2;
            isSliding = false;
   
            //velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
            direction.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
        }

        private IEnumerator Slide()
        {
            //animator.SetBool(IsSliding, true);
            controller.center = new Vector3(0, -0.5f, 0);
            controller.height = 1;
            yield return new WaitForSeconds(1.3f);
            controller.center = new Vector3(0, 0, 0);
            controller.height = 2;
            //animator.SetBool(IsSliding, false);
        }
        
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("Obstacle"))
            {
                PlayerManager.gameOver = true;
            }
        }
    }
}
