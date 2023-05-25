using System;
using UnityEngine;

public class ScreenTap : MonoBehaviour
{
    public event Action<Vector3> OnTapScreen;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnTapScreen?.Invoke(Input.mousePosition);
        }
    }
}
