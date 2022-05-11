using Manager;
using UnityEngine;

namespace Menus.Shop
{
    public class ShopController : MonoBehaviour
    {
        public ShopMenuType menuType;
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void ToggleCanvas(bool value)
        {
            if (value)
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }
}
