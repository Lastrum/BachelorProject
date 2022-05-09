using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        private static int coins;

        public static void AddCoins(int value)
        {
            coins += value;
            Debug.Log($"Total Coins: {coins}");
        }
        
    }
}
