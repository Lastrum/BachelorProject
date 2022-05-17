using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menus.Shop
{
    public class ButtonHelper : MonoBehaviour
    {
        [SerializeField] private CharactersMenu charactersMenu;

        public int position;
        public Button button;
        
        private void Awake()
        {
            charactersMenu = FindObjectOfType<CharactersMenu>();
            button = GetComponent<Button>();
        }
        
        public void SetupButton()
        {
            button.onClick.AddListener(Load);
        }
        
        private void Load()
        {
           charactersMenu.LoadCharacter(position);
           charactersMenu.currentPosition = position;
        }
        
    }
}
