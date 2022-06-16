using System;
using Manager;
using UnityEngine;

namespace Objects
{
    public class PowerUp : MonoBehaviour
    {
        public Power power;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) Destroy(gameObject);
        }
    }
}
