using System;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class MissionMenu : MonoBehaviour
    {
        [SerializeField] private MissionManager missionManager;
        
        [SerializeField] public Button generateMissionButton;
        [SerializeField] private Button backButton;

        [SerializeField] private CanvasGroup missionHolder;
        [SerializeField] private CanvasGroup noHolder;
        
        
        [Header("Mission Stuff")] 
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private TextMeshProUGUI task;
        [SerializeField] private TextMeshProUGUI reward;
        
        private void Awake()
        {
            generateMissionButton.onClick.AddListener(CreateMission);
            backButton.onClick.AddListener(Back);
        }
        
        public void CheckIfMission()
        {
            
            Debug.Log(missionManager.currentMission.IsActive);
            
            if (missionManager.currentMission.IsActive == 0)
            {
                generateMissionButton.gameObject.SetActive(true);
                ToggleCanvas(noHolder, true);
                ToggleCanvas(missionHolder, false);
            }
            else
            {
                generateMissionButton.gameObject.SetActive(false);
                ToggleCanvas(noHolder, false);
                ToggleCanvas(missionHolder, true);
            }
        }

        private void ToggleCanvas(CanvasGroup canvas, bool value)
        {
            if (value)
            {
                canvas.alpha = 1;
                canvas.interactable = true;
                canvas.blocksRaycasts = true;
            }
            else
            {
                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;
            }
     
        }
        
        private void CreateMission()
        {
            missionManager.CreateMission();
            UpdateText();
            CheckIfMission();
        }

        public void UpdateText()
        {
            name.text = $"Name: {missionManager.currentMission.Name}";
            description.text = $"Description: {missionManager.currentMission.Description.Replace("{Replace}", missionManager.currentMission.Task.ToString())}";
            task.text = $"Task: {missionManager.currentMission.Progress.ToString()}/ {missionManager.currentMission.Task.ToString()}";
            reward.text = $"Reward: {missionManager.currentMission.Reward} xp";
        }
        
        private void Back()
        {
            MenuManager.SwitchMenu(MenuType.MainMenu);
        }
    }
}
