using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCollider : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField] ClickAxis axis;
    [SerializeField] Transform master;

    public event Action<Vector3Int> OnDownLeft;
    public event Action<Vector3Int> OnDownRight;
    public event Action<Vector3Int> OnDownMiddle;
    public event Action<Vector3Int> OnClickRight;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDownLeft?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnDownRight?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
        if (Input.GetMouseButtonDown(2))
        {
            OnDownMiddle?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(1))
        {
            OnClickRight?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if(Input.GetMouseButton(0))
        //{
        //    OnClick?.Invoke(new Vector3Int(
        //        Mathf.RoundToInt(master.position.x),
        //        Mathf.RoundToInt(master.position.y),
        //        Mathf.RoundToInt(master.position.z)));
        //}
    }
}
public enum ClickAxis
{
    X,
    Y,
    Z
}