using System;
using Manager;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CameraType = Manager.CameraType;

namespace Menus.Shop
{
    public class CharactersMenu : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;
        
        [SerializeField] private Button backButton;
        
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI characterNameText;
        [SerializeField] private TextMeshProUGUI characterPriceText;
        [SerializeField] private GameObject priceHeader;

        [Header("Arrow Buttons")] 
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;
        
        [Header("Buy/Select Button")]
        [SerializeField] private Button actionButton;
        [SerializeField] private TextMeshProUGUI actionText;

        [Header("Character Holder")] 
        [SerializeField] private GameObject characterHolder;

        private int currentPosition = 0;
        private GameObject character;
        
        private void Awake()
        {
            backButton.onClick.AddListener(Back);
            actionButton.onClick.AddListener(ActionButtonHandler);
            previousButton.onClick.AddListener(Previous);
            nextButton.onClick.AddListener(Next);
        }

        private void Start()
        {
            LoadCharacter(currentPosition);
            UpdateCoinText();
        }

        private void Update()
        {
            if(SwipeManager.swipeLeft) Next();
            if(SwipeManager.swipeRight) Previous();
        }

        private void LoadCharacter(int index)
        {
            character = Instantiate(dataManager.CharactersList[index].ShopPrefab, characterHolder.transform);
            characterNameText.text = dataManager.CharactersList[index].Name;
            if (!dataManager.CharactersList[index].IsUnlocked)
            {
                actionButton.enabled = true;
                priceHeader.SetActive(true);
                characterPriceText.text = dataManager.CharactersList[index].Price.ToString();
                actionText.text = "Buy";
            }
            else if (!dataManager.CharactersList[index].IsSelected)
            {
                actionButton.enabled = true;
                priceHeader.SetActive(false);
                actionText.text = "Select";
            }
            else
            {
                actionButton.enabled = false;
                priceHeader.SetActive(false);
                actionText.text = "Selected";
            }
        }
        
        private static void Back()
        {
            ShopManager.SwitchMenu(ShopMenuType.SubMenu);
            CameraManager.SwitchCamera(CameraType.MainCamera);
        }
        
        private void ActionButtonHandler()
        {
            if (dataManager.CharactersList[currentPosition].IsUnlocked && !dataManager.CharactersList[currentPosition].IsSelected)
            {
                dataManager.SelectedCharacter.IsSelected = false;
                dataManager.CharactersList[currentPosition].IsSelected = true;
                dataManager.SelectedCharacter = dataManager.CharactersList[currentPosition];
                actionText.text = "Selected";
            }
            else
            {
                if (dataManager.data.TotalCoins < dataManager.CharactersList[currentPosition].Price) return;
                dataManager.data.TotalCoins -= dataManager.CharactersList[currentPosition].Price;
                UpdateCoinText();
                dataManager.CharactersList[currentPosition].IsUnlocked = true;
                priceHeader.SetActive(false);
                actionText.text = "Select";
            }
            
        }

        private void Previous()
        {
            Destroy(character);
            if (currentPosition == 0)
            {
                currentPosition = dataManager.CharactersList.Count-1;
            }
            else
            {
                currentPosition--;
            }
            LoadCharacter(currentPosition);
        }

        private void Next()
        {
            Destroy(character);
            if (currentPosition == dataManager.CharactersList.Count-1)
            {
                currentPosition = 0;
            }
            else
            {
                currentPosition++;
            }
            LoadCharacter(currentPosition);
        }

        private void UpdateCoinText()
        {
            coinsText.text = dataManager.data.TotalCoins.ToString();
        }
    }
}
