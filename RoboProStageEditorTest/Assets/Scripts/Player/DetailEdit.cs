using System;
using UnityEngine;
using UnityEngine.UI;

public class DetailEdit : MonoBehaviour
{
    [SerializeField] private Type type;
    [SerializeField] private BlockInstantiater blockInstantiater;
    [SerializeField] private InputField xInput;
    [SerializeField] private InputField yInput;
    [SerializeField] private InputField zInput;
    [SerializeField] private Transform model;

    private void Start()
    {
        xInput.onValueChanged.AddListener(SetPositionX);
        yInput.onValueChanged.AddListener(SetPositionY);
        zInput.onValueChanged.AddListener(SetPositionZ);
    }

    private void SetPositionX(string str)
    {
        if (string.IsNullOrEmpty(str)) return;
        float x = float.Parse(str);
        model.position = new Vector3(x, model.position.y, model.position.z);
        xInput.SetTextWithoutNotify(((int)x).ToString());
        switch (type)
        {
            case Type.Camera:
                blockInstantiater.StageData.CameraPosition.x = x;
                break;
            case Type.Player:
                blockInstantiater.StageData.PlayerPosition.x = x;
                break;
        }
    }

    private void SetPositionY(string str)
    {
        if (string.IsNullOrEmpty(str)) return;
        float y = float.Parse(str);
        model.position = new Vector3(model.position.x, y, model.position.z);
        yInput.SetTextWithoutNotify(((int)y).ToString());
        switch (type)
        {
            case Type.Camera:
                blockInstantiater.StageData.CameraPosition.y = y;
                break;
            case Type.Player:
                blockInstantiater.StageData.PlayerPosition.y = y;
                break;
        }
    }

    private void SetPositionZ(string str)
    {
        if (string.IsNullOrEmpty(str)) return;
        float z = float.Parse(str);
        model.position = new Vector3(model.position.x, model.position.y, z);
        zInput.SetTextWithoutNotify(((int)z).ToString());
        switch (type)
        {
            case Type.Camera:
                blockInstantiater.StageData.CameraPosition.z = z;
                break;
            case Type.Player:
                blockInstantiater.StageData.PlayerPosition.z = z;
                break;
        }
    }

    public void SetPosition(Vector3 pos)
    {
        SetPositionX(pos.x.ToString());
        SetPositionY(pos.y.ToString());
        SetPositionZ(pos.z.ToString());
    }

    public enum Type
    {
        Player,
        Camera
    }
}
