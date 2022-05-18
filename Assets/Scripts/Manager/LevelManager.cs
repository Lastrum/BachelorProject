using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;

        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Slider levelSlider;

        private int totalXP = 250;
        private int baseXP = 250;
        private int overXP;
        
        private void Start()
        {
            //Update Delegates
            UpdateDelegates();
            
            dataManager.data.TotalXP = totalXP;
            UpdateCurrentXpText();
            UpdateTotalXpText();
            UpdateLevelText();
        }

        private void UpdateDelegates()
        {
            dataManager.data.updateCurrentXPDelegate += UpdateCurrentXpText;
            dataManager.data.updateCurrentXPDelegate += CheckIfLevel;
            dataManager.data.updateLevelDelegate += UpdateLevelText;
            dataManager.data.updateTotalXPDelegate += UpdateTotalXpText;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                dataManager.data.CurrentXP += 50;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                dataManager.data.CurrentXP += 1000;
            }
        }

        private void UpdateCurrentXpText()
        {
            levelSlider.value = dataManager.data.CurrentXP;
        }

        private void UpdateTotalXpText()
        {
            levelSlider.maxValue = dataManager.data.TotalXP;
        }
        
        private void UpdateLevelText()
        {
            levelText.text = dataManager.data.Level.ToString();
        }

        private void CheckIfLevel()
        {
            if (dataManager.data.CurrentXP >= dataManager.data.TotalXP)
            {
                if (dataManager.data.CurrentXP > dataManager.data.TotalXP)
                {
                    overXP = dataManager.data.CurrentXP - dataManager.data.TotalXP;
                }
                
                dataManager.data.CurrentXP = 0;
                dataManager.data.TotalXP += baseXP;
                dataManager.data.Level += 1;
                dataManager.data.CurrentXP = overXP;
            }
        }
    }
}
