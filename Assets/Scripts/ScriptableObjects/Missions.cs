using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Missions", menuName = "ScriptableObjects/Missions")]
    public class Missions : ScriptableObject
    {
        [SerializeField] private string name;
        public string Name { get => name; set => name = value; }
        
        [SerializeField] private int isActive;
        public int IsActive { get => isActive; set => isActive = value; }
        
        [SerializeField] private string tag;
        public string Tag { get => tag; set => tag = value; }
        
        [SerializeField] private string description;
        public string Description { get => description; set => description = value; }
        
        [SerializeField] private int task;
        public int Task { get => task; set => task = value; }
        
        public delegate void UpdateProgress();
        public UpdateProgress UpdateProgressDelegate;
        
        [SerializeField] private int progress;
        public int Progress { get => progress;  set { progress = value; UpdateProgressDelegate?.Invoke(); PlayerPrefs.SetInt($"currentMissionProgress", progress); } }
        
        [SerializeField] private int reward;
        public int Reward { get => reward; set => reward = value; }
    }
}
