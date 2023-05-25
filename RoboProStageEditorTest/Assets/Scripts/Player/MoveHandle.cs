using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Axis axis;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(24, 35, 24);
    [SerializeField] private DetailEdit edit;

    private Vector3 multiplyAxis;
    private Vector3 nowMousePosition;

    private void Start()
    {
        switch (axis)
        {
            case Axis.X:
                multiplyAxis = Vector3.right;
                break;
            case Axis.Y:
                multiplyAxis = Vector3.up;
                break;
            case Axis.Z:
                multiplyAxis = Vector3.forward;
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        nowMousePosition = (Camera.main.ScreenToWorldPoint(eventData.position) - offset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = (Camera.main.ScreenToWorldPoint(eventData.position) - offset);
        Vector3 move = mousePos - nowMousePosition;
        
        move.x *= multiplyAxis.x;
        move.y *= multiplyAxis.y;
        move.z *= multiplyAxis.z;
        
        target.position += move;

        nowMousePosition = mousePos;

        edit.SetPosition(target.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    private void Update()
    {
        
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
