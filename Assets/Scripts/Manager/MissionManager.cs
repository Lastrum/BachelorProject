using System;
using System.Collections.Generic;
using Menus;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;
        [SerializeField] private MissionMenu missionMenu;
        [SerializeField] private LevelMenu levelMenu;
        
        [SerializeField] private List<Missions> listOfMissionList;
        public List<Missions> ListOfMissionList => listOfMissionList;
        
        public Missions currentMission;
        public Missions lastMission;
        
        private string missionPath = "Assets/Resources/Missions/Missions/";
        
        //Tags
        private string coinsTag = "Coins";
        private string distanceTag = "Distance";
        
        
        private void Awake()
        {
            currentMission = ScriptableObject.CreateInstance<Missions>();
            
            PopulateList();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                missionMenu.UpdateText();
                Debug.Log("Pressed");
            }
        }

        private void PopulateList()
        {
            var objectArray = Resources.LoadAll("Missions/Template", typeof(Missions));

            foreach (Missions missions in objectArray)
            {
                listOfMissionList.Add(missions);
            }
        }

        public void CreateMission()
        {
            if (currentMission.IsActive == 1) return;
            
            int random = GetRandomNumber();
            
            if (lastMission != null)
            {
                if (listOfMissionList[random].Name == lastMission.Name)
                {
                    CreateMission();
                    return;
                }
            }
            
            currentMission.Name = listOfMissionList[random].Name;
            currentMission.IsActive = 1;
            currentMission.Tag = listOfMissionList[random].Tag;
            currentMission.Description = listOfMissionList[random].Description;
            currentMission.Task = listOfMissionList[random].Task;
            currentMission.Progress = listOfMissionList[random].Progress;
            currentMission.Reward = listOfMissionList[random].Reward;
            
            SaveCurrentMission();
            
        }

        private int GetRandomNumber()
        {
            return Random.Range(0, listOfMissionList.Count);
        }
        
        public void CheckCoinMission(int value)
        {
            if(currentMission == null) return;

            if (currentMission.Tag == coinsTag)
            {
                currentMission.Progress += value;

                if (currentMission.Progress >= currentMission.Task)
                {
                    MissionComplete(currentMission);
                }
            }
        }

        public void CheckDistanceMission(float value)
        {
            if(currentMission == null) return;
            
            if (currentMission.Tag == distanceTag)
            {
                currentMission.Progress += (int)value;
                    
                if (currentMission.Progress >= currentMission.Task)
                {
                    MissionComplete(currentMission);
                }
            }
        }

        private void MissionComplete(Missions mission)
        {
            lastMission = currentMission;
            dataManager.data.CurrentXP += mission.Reward;
            
            levelMenu.UpdateXpText($"Completed Quest: {mission.Reward} xp reward!");
            
            ResetCurrentMission();
            missionMenu.CheckIfMission();
        }

        public void SaveCurrentMission()
        {
            PlayerPrefs.SetString("currentMissionName", currentMission.Name);
            PlayerPrefs.SetInt("currentMissionActive", currentMission.IsActive);
            PlayerPrefs.SetString("currentMissionTag", currentMission.Tag);
            PlayerPrefs.SetString("currentMissionDescription", currentMission.Description);
            PlayerPrefs.SetInt("currentMissionTask", currentMission.Task);
            PlayerPrefs.SetInt("currentMissionProgress", currentMission.Progress);
            PlayerPrefs.SetInt("currentMissionReward", currentMission.Reward);
            
        }
        
        public void ResetCurrentMission()
        {
            PlayerPrefs.SetString("currentMissionName", "");
            PlayerPrefs.SetInt("currentMissionActive", 0);
            PlayerPrefs.SetString("currentMissionTag", "");
            PlayerPrefs.SetString("currentMissionDescription", "");
            PlayerPrefs.SetInt("currentMissionTask", 0);
            PlayerPrefs.SetInt("currentMissionProgress", 0);
            PlayerPrefs.SetInt("currentMissionReward", 0);
            
            LoadCurrentMission();
        }
        
        public void LoadCurrentMission()
        {
            currentMission.Name = PlayerPrefs.GetString("currentMissionName");
            currentMission.IsActive = PlayerPrefs.GetInt("currentMissionActive");
            currentMission.Tag = PlayerPrefs.GetString("currentMissionTag");
            currentMission.Description = PlayerPrefs.GetString("currentMissionDescription");
            currentMission.Task = PlayerPrefs.GetInt("currentMissionTask");
            currentMission.Progress = PlayerPrefs.GetInt("currentMissionProgress");
            currentMission.Reward = PlayerPrefs.GetInt("currentMissionReward");
            
            missionMenu.UpdateText();
            missionMenu.CheckIfMission();
        }
        
    }
}
