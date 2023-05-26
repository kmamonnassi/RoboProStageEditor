using UnityEngine;

public class UI_OnOrOff : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
