using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
        public bool GetTapInput()
        {
            return Input.GetKeyDown(KeyCode.Space) || SwipeManager.tap;
        }
        
        public bool GetLeftInput()
        {
            return Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft;
        }
        
        public bool GetRightInput()
        {
            return Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight;
        }
        
        public bool GetUpInput()
        {
            return Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp;
        }
        
        public bool GetDownInput()
        {
            return Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown;
        }
    }
}
