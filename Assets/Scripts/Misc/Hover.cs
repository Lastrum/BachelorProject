using UnityEngine;
using UnityEngine.EventSystems;

namespace Misc
{
    public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool isOver;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            isOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isOver = false;
        }
    }
}
