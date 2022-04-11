using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
    
        private CharacterController controller;
        private Vector3 direction;

        private int desiredLane = 1; //0:Left 1:Middle 2:Right
        [SerializeField] private float laneDistance = 4; //distance between 2 lanes
        [SerializeField] private int transitionSpeed;

        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity = -20;
        
        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            direction.z = forwardSpeed;
            direction.y += gravity * Time.deltaTime;
            
            //Jump Check
            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
                {
                    Jump();
                }
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

            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.fixedDeltaTime);

        }

        private void FixedUpdate()
        {
            controller.Move(direction * Time.deltaTime);
        }

        private void Jump()
        {
            direction.y = jumpForce;
        }
    }
}
