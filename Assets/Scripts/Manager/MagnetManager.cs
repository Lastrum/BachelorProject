using System;
using Misc;
using Player;
using UnityEngine;

namespace Manager
{
    public class MagnetManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float speed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                Magnet m = other.GetComponent<Magnet>();
                m.player = playerController.transform;
                m.speed = speed;
                m.StartMagnet();
            }
        }
    }
}
