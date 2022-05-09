using Player;
using UnityEngine;

namespace Objects
{
    public class Coins : MonoBehaviour
    {
        [SerializeField] private int coinWorth = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerStats.AddCoins(coinWorth);
                Destroy(gameObject);
            }
        }
    }
}
