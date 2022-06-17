using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Menus.Shop
{
    public class CharacterSlider : MonoBehaviour
    {
        [SerializeField] private CharactersMenu charactersMenu;
        [SerializeField] private Transform contentPort;
        [SerializeField] private GameObject imagePrefab;

        [SerializeField] private int miniumImage;
        [SerializeField] private int imageSize; 
        [SerializeField] private int paddingSize; 
        
        private GameObject go;
        private Image characterImage;
        private Button characterButton;
        private ButtonHelper buttonHelper;
        

        private void Start()
        {

            LoadImages();
        }

        private void LoadImages()
        {
            if (miniumImage < charactersMenu.dataManager.CharactersList.Count - 1)
            {
                contentPort.GetComponent<RectTransform>().offsetMax = new Vector2((imageSize + paddingSize) * ((charactersMenu.dataManager.CharactersList.Count) - miniumImage), 0);
            }

            for (var index = 0; index < charactersMenu.dataManager.CharactersList.Count; index++)
            {
                Characters character = charactersMenu.dataManager.CharactersList[index];
                go = Instantiate(imagePrefab, contentPort.transform);
                
                buttonHelper = go.GetComponent<ButtonHelper>();
                buttonHelper.position = index;
                buttonHelper.SetupButton();

                characterImage = go.transform.GetChild(0).GetComponent<Image>();
                characterImage.sprite = character.ShopImage;
            }
        }
    }
}
