using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] public Data data;
        [SerializeField] public MissionManager missionManager;
        [SerializeField] private List<Characters> charactersList;
        public List<Characters> CharactersList => charactersList;

        public Characters SelectedCharacter { get; set; }

        public string unlockedString = "IsUnlocked";
        public string selectedString = "IsSelected";
        
        private void Awake()
        {
            PopulateCharacterList();
            FindSelected();
        }

        private void Start()
        {
            if (PlayerPrefs.GetInt("firstTime") == 0)
            {
                UnlockDefault(true);
                PlayerPrefs.SetInt("firstTime", 1);
            }
            
            UpdateData();
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
        
        private void IsUnlockedCharacterList()
        {
            foreach (var characters in charactersList)
            {
                characters.IsUnlocked = PlayerPrefs.GetInt(characters.Name + unlockedString) == 1;
            }
        }

        private void IsSelectedCharacterList()
        {
            foreach (var characters in charactersList)
            {
                characters.IsSelected = PlayerPrefs.GetInt(characters.Name + selectedString) == 1;
            }
        }
        
        private void SetSelectedCharacterList()
        {
            foreach (var characters in charactersList)
            {
                characters.IsSelected = false;
                PlayerPrefs.SetInt(characters.Name + selectedString, 0);
            }
        }
        
        private void SetIsUnlockedCharacterList()
        {
            foreach (var characters in charactersList)
            {
                characters.IsUnlocked = false;
                PlayerPrefs.SetInt(characters.Name + unlockedString, 0);
            }
        }
        
        public void UpdateData()
        {
            data.PlayerName = PlayerPrefs.GetString("PlayerName");
            data.TotalCoins = PlayerPrefs.GetInt("TotalCoins");
            data.TotalGems = PlayerPrefs.GetInt("TotalGems");

            data.HighScore = PlayerPrefs.GetInt("HighScore");
            data.Level = PlayerPrefs.GetInt("Level");
            data.CurrentXP = PlayerPrefs.GetInt("CurrentXP");
            data.TotalXP = PlayerPrefs.GetInt("TotalXP");
            
            IsUnlockedCharacterList();
            IsSelectedCharacterList();
            
            missionManager.LoadCurrentMission();
            
        }

        public void ResetData()
        {
            data.PlayerName = "";
            data.TotalCoins = 0;
            data.TotalGems = 0;
            
            data.HighScore = 0;
            data.Level = 1;
            data.CurrentXP = 0;
            data.TotalXP = 250;
  
            
            SetIsUnlockedCharacterList();
            SetSelectedCharacterList();
            UnlockDefault(true);
        }
        
        private void UnlockDefault(bool selected)
        {
            PlayerPrefs.SetInt(CharactersList[0].Name + unlockedString, 1);
            CharactersList[0].IsUnlocked = true;

            if (selected)
            {
                PlayerPrefs.SetInt(charactersList[0].Name + selectedString, 1);
                charactersList[0].IsSelected = true;
            }
            else
            {
                PlayerPrefs.SetInt(charactersList[0].Name + selectedString, 1);
                charactersList[0].IsSelected = false;
            }
        }
        
    }
}
