using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string playerName;
        public string PlayerName { get => playerName; set => playerName = value; }

        [SerializeField] private int totalCoins;
        public int TotalCoins { get => totalCoins; set => totalCoins = value; }

        [SerializeField] private int totalGems;
        public int TotalGems { get => totalGems; set => totalGems = value; }
        
        [SerializeField] private int level;
        public int Level { get => level; set => level = value; }
    }
}
