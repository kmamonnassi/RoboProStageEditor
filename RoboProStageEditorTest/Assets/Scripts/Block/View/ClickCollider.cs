using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCollider : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] ClickAxis axis;
    [SerializeField] Transform master;

    public event Action<Vector3Int> OnClickRight;
    public event Action<Vector3Int> OnClickLeft;
    public event Action<Vector3Int> OnClickMiddle;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickRight?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnClickLeft?.Invoke(new Vector3Int(
                Mathf.RoundToInt(master.position.x),
                Mathf.RoundToInt(master.position.y),
                Mathf.RoundToInt(master.position.z)));
        }
        if (Input.GetMouseButtonDown(2))
        {
            OnClickMiddle?.Invoke(new Vector3Int(
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