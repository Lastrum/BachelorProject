using System;
using UnityEngine;

namespace Misc
{
    public class Magnet : MonoBehaviour
    {
        public Transform player;
        public float speed;
        private bool magnet = false;

        private void Update()
        {
            if (magnet)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }

        public void StartMagnet()
        {
            magnet = true;
        }
    }
}
