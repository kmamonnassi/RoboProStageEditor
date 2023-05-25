using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private IsEnteredUI isEnteredUI;
    [SerializeField] private float speed = 30;
    [SerializeField] private float keyMoveSpeed = 30;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float zoomSpeed = 20;

    private Vector3 mousePos;
    private Vector3 movedPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 nowMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 movePos = (mousePos - nowMousePos) * speed;
            movedPos += movePos;
            cam.transform.position = movedPos + offset;
            mousePos = nowMousePos;
        }

        if (Input.mouseScrollDelta.y != 0 && !isEnteredUI.Entered)
        {
            cam.orthographicSize += Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime;
        }

        KeyMove();
    }

    private void KeyMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movedPos += Vector3.forward * Time.deltaTime * keyMoveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movedPos += Vector3.left * Time.deltaTime * keyMoveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movedPos += Vector3.back * Time.deltaTime * keyMoveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movedPos += Vector3.right * Time.deltaTime * keyMoveSpeed;
        }
        cam.transform.position = movedPos + offset;
    }
}
