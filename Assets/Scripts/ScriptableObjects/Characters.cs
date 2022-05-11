using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Characters", menuName = "ScriptableObjects/Character", order = 1)]
    public class Characters : ScriptableObject
    {
        [SerializeField] private string name;
        public string Name { get => name; set => name = value; }
        
        [SerializeField] private string description;
        public string Description { get => description; set => description = value; }
        
        [SerializeField] private int price;
        public int Price { get => price; set => price = value; }
        
        [SerializeField] private bool isSelected;
        public bool IsSelected { get => isSelected; set => isSelected = value; }
        
        [SerializeField] private bool isUnlocked;
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
        
        [SerializeField] private GameObject prefab;
        public GameObject Prefab { get => prefab; set => prefab = value; }
        
        [SerializeField] private GameObject shopPrefab;
        public GameObject ShopPrefab { get => shopPrefab; set => shopPrefab = value; }
    }
}
