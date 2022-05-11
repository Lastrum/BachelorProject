using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] public Data data;
        [SerializeField] private List<Characters> charactersList;
        public List<Characters> CharactersList => charactersList;

        public Characters SelectedCharacter { get; set; }

        private void Awake()
        {
            PopulateCharacterList();
            FindSelected();
        }
        
        private void FindSelected()
        {
            foreach (var character in charactersList.Where(character => character.IsSelected))
            {
                SelectedCharacter = character;
            }
        }
        
        private void PopulateCharacterList()
        {
           var objectArray = Resources.LoadAll("Characters", typeof(Characters));

            foreach (Characters character in objectArray)
            {
                charactersList.Add(character);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log($"Name: {SelectedCharacter.Name} | Prefab: {SelectedCharacter.Prefab.name}");
            }
        }
    }
}
