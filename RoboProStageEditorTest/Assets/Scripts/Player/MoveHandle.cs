using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Axis axis;
    [SerializeField] private Transform target;
    [SerializeField] private DetailEdit edit;
    [SerializeField] private float moveSpeed = 10;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Plane plane = new Plane();

        switch(axis)
        {
            case Axis.X:
                plane = new Plane(Vector3.forward, 0);
                break;
            case Axis.Y:
                plane = new Plane(Vector3.right, 0);
                break;
            case Axis.Z:
                plane = new Plane(Vector3.up, 0);
                break;
        }

        plane.Raycast(ray, out float distance);
        Vector3 pos = ray.GetPoint(distance);

        switch (axis)
        {
            case Axis.X:
                pos = new Vector3(pos.x, target.position.y, target.position.z);
                break;
            case Axis.Y:
                pos = new Vector3(target.position.x, pos.y, target.position.z);
                break;
            case Axis.Z:
                pos = new Vector3(target.position.x, target.position.y, pos.z);
                break;
        }

        edit.SetPosition(pos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
