using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private IsEnteredUI isEnteredUI;
    [SerializeField] private float speed = 30;
    [SerializeField] private float verticalSpeed = 15;
    [SerializeField] private float keyMoveSpeed = 30;
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed = 20;
    [SerializeField] private float rotateSpeed = 20;

    private void Update()
    {
        Vector3 horiKey = cam.transform.TransformDirection(Vector3.right) * -Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector3 vertKey = cam.transform.TransformDirection(Vector3.forward) * -Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 horiMouse = Vector3.zero;
        Vector3 vertMouse = Vector3.zero;
        if (Input.GetMouseButton(2))
        {
            horiMouse = cam.transform.TransformDirection(Vector3.right) * Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            vertMouse = cam.transform.TransformDirection(Vector3.up) * Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
        }
        cam.transform.position += horiMouse + vertMouse + horiKey + vertKey;

        if (Input.mouseScrollDelta.y != 0 && !isEnteredUI.Entered)
        {
            cam.transform.position += cam.transform.forward * Time.deltaTime * zoomSpeed * Input.mouseScrollDelta.y;
        }

        if(Input.GetMouseButton(1))
        {
            float x = transform.eulerAngles.x + Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            float y = transform.eulerAngles.y - Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            cam.transform.eulerAngles = new Vector3(x, y, cam.transform.eulerAngles.z);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            cam.transform.position += Vector3.down * Time.deltaTime * verticalSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            cam.transform.position += Vector3.up * Time.deltaTime * verticalSpeed;
        }
    }
}
