using System;
using UnityEngine;

namespace Objects
{
    public class Twist : MonoBehaviour
    {
        [SerializeField] private bool twist;
        [SerializeField] private bool hover;
        
        [SerializeField] private float rotationSpeed = 40;
        [SerializeField] private float moveSpeed = 0.5f;
        private bool moveUp = true;

        private float max, min;

        private void Start()
        {
            max = transform.position.y + 1.25f;
            min = transform.position.y + 0.75f;
        }

        private void Update()
        {
            if(twist) transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            if(hover) MoveUpAndDown();
        }

        private void MoveUpAndDown()
        {
            if (transform.position.y >= max)
            {
                moveUp = false;
            }
            if (transform.position.y <= min)
            {
                moveUp = true;
            }
            
            if (moveUp)
            {
                transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
            }
        }
    }
}
