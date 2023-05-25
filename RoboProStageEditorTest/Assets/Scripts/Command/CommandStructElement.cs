using Command;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandStructElement : MonoBehaviour
{
    [SerializeField] public Dropdown commandTypeDropDown;
    [SerializeField] public Toggle lookCommandToggle;
    [SerializeField] public Toggle lookNumberToggle;
    [SerializeField] public Toggle lookAxisToggle;
    [SerializeField] public InputField valueInput;
    [SerializeField] public Dropdown axisDropDown;

    private CommandStruct targetStruct;

    private void Start()
    {
        Array commands = Enum.GetValues(typeof(MainCommandType));
        List<string> commandOptions = new List<string>();
        for(int i = 0; i < commands.Length; i++)
        {
            commandOptions.Add(commands.GetValue(i).ToString());
        }
        commandTypeDropDown.AddOptions(commandOptions);

        Array axises = Enum.GetValues(typeof(CoordinateAxis));
        List<string> axisOptions = new List<string>();
        for (int i = 0; i < axises.Length; i++)
        {
            axisOptions.Add(axises.GetValue(i).ToString());
        }
        axisDropDown.AddOptions(axisOptions);

        commandTypeDropDown.onValueChanged.AddListener(SetCommandType);
        lookCommandToggle.onValueChanged.AddListener(SetLockCommand);
        lookNumberToggle.onValueChanged.AddListener(SetLockNumber);
        lookAxisToggle.onValueChanged.AddListener(SetLockAxis);
        valueInput.onValueChanged.AddListener(SetValue);
        axisDropDown.onValueChanged.AddListener(SetAxis);
    }

    public void SetStruct(CommandStruct cSt)
    {
        commandTypeDropDown.SetValueWithoutNotify((int)cSt.CommandType);
        lookCommandToggle.SetIsOnWithoutNotify(cSt.LockCommand);
        lookNumberToggle.SetIsOnWithoutNotify(cSt.LockNumber);
        lookAxisToggle.SetIsOnWithoutNotify(cSt.LockCoordinateAxis);
        valueInput.SetTextWithoutNotify(cSt.Value.ToString());
        axisDropDown.SetValueWithoutNotify((int)cSt.Axis);

        targetStruct = cSt;
    }

    private void SetCommandType(int id)
    {
        targetStruct.CommandType = (MainCommandType)id;
    }

    private void SetLockCommand(bool b)
    {
        targetStruct.LockCommand = b;
    }

    private void SetLockNumber(bool b)
    {
        targetStruct.LockNumber = b;
    }

    private void SetLockAxis(bool b)
    {
        targetStruct.LockCoordinateAxis = b;
    }

    private void SetValue(string value)
    {
        if (string.IsNullOrEmpty(value)) return;
        targetStruct.Value = int.Parse(value);
        Debug.Log(int.Parse(value));
    }

    private void SetAxis(int axis)
    {
        targetStruct.Axis = (CoordinateAxis)axis;
    }
}
