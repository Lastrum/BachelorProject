using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string playerName;
        public string PlayerName { get => playerName; set => playerName = value; }

        /// <summary>
        /// Coins
        /// </summary>
        public delegate void UpdateCoins();
        public UpdateCoins UpdateCoinsDelegate;
        [SerializeField] private int totalCoins;
        public int TotalCoins { get => totalCoins; set { totalCoins = value; UpdateCoinsDelegate?.Invoke(); } }

        [SerializeField] private int totalGems;
        public int TotalGems { get => totalGems; set => totalGems = value; }
        
        [SerializeField] private int level;
        public int Level { get => level; set => level = value; }
    }
}
