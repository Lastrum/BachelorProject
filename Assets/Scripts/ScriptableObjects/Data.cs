using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string playerName;
        public string PlayerName { get => playerName; set => playerName = value; }

        /// <summary>
        /// Score
        /// </summary>
        public delegate void UpdateScore();
        public UpdateScore UpdateScoreDelegate;
        [SerializeField] private int highScore;
        public int HighScore { get => highScore; set { highScore = value; UpdateScoreDelegate?.Invoke(); PlayerPrefs.SetInt("HighScore", HighScore); }}
        
        /// <summary>
        /// Coins
        /// </summary>
        public delegate void UpdateCoins();
        public UpdateCoins UpdateCoinsDelegate;
        [SerializeField] private int totalCoins;
        public int TotalCoins { get => totalCoins; set { totalCoins = value; UpdateCoinsDelegate?.Invoke(); PlayerPrefs.SetInt("TotalCoins", totalCoins); }}
        
        /// <summary>
        /// Gems
        /// </summary>
        public delegate void UpdateGems();
        public UpdateGems UpdateGemsDelegate;
        
        [SerializeField] private int totalGems;
        public int TotalGems { get => totalGems; set { totalGems = value; UpdateGemsDelegate?.Invoke(); PlayerPrefs.SetInt("TotalGems", totalGems); } }
        
        /// <summary>
        /// Level 
        /// </summary>
        public delegate void UpdateLevel();
        public UpdateLevel updateLevelDelegate;
        
        [SerializeField] private int level;
        public int Level { get => level; set { level = value; updateLevelDelegate?.Invoke(); PlayerPrefs.SetInt("Level", level); } }
        
        /// <summary>
        /// currentXP
        /// </summary>
        public delegate void UpdateCurrentXP();
        public UpdateCurrentXP updateCurrentXPDelegate;
        
        [SerializeField] private int currentXP;
        public int CurrentXP { get => currentXP; set { currentXP = value; updateCurrentXPDelegate?.Invoke(); PlayerPrefs.SetInt("CurrentXP", currentXP);} }
        
        /// <summary>
        /// TotalXP
        /// </summary>
        public delegate void UpdateTotalXP();
        public UpdateTotalXP updateTotalXPDelegate;
        
        [SerializeField] private int totalXP;
        public int TotalXP { get => totalXP; set { totalXP = value; updateTotalXPDelegate?.Invoke(); PlayerPrefs.SetInt("TotalXP", totalXP); } }
        
    }
}
