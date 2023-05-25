using UnityEngine;
using UnityEngine.EventSystems;

public class IsEnteredUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool Entered { get; private set; }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Entered = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Entered = false;
    }
}
