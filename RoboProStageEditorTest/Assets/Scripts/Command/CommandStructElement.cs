using Command;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<MainCommandType> commands = ((MainCommandType[])Enum.GetValues(typeof(MainCommandType))).ToList().OrderBy(x => x).ToList();
        List<string> commandOptions = new List<string>();
        for(int i = 0; i < commands.Count; i++)
        {
            commandOptions.Add(commands[i].ToString());
        }
        commandTypeDropDown.AddOptions(commandOptions);

        List<CoordinateAxis> axises = ((CoordinateAxis[])Enum.GetValues(typeof(CoordinateAxis))).ToList().OrderBy(x => x).ToList();
        List<string> axisOptions = new List<string>();
        for (int i = 0; i < axises.Count; i++)
        {
            axisOptions.Add(axises[i].ToString());
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
        int command_idx = commandTypeDropDown.options.FindIndex(x => x.text == cSt.CommandType.ToString());
        commandTypeDropDown.SetValueWithoutNotify(command_idx);
        lookCommandToggle.SetIsOnWithoutNotify(cSt.LockCommand);
        lookNumberToggle.SetIsOnWithoutNotify(cSt.LockNumber);
        lookAxisToggle.SetIsOnWithoutNotify(cSt.LockCoordinateAxis);
        valueInput.SetTextWithoutNotify(cSt.Value.ToString());

        int axis_idx = axisDropDown.options.FindIndex(x => x.text == cSt.Axis.ToString());
        axisDropDown.SetValueWithoutNotify(axis_idx);

        targetStruct = cSt;
    }

    private void SetCommandType(int id)
    {
        MainCommandType type = (MainCommandType)Enum.Parse(typeof(MainCommandType), commandTypeDropDown.options[id].text);
        targetStruct.CommandType = type;
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

    private void SetAxis(int id)
    {
        CoordinateAxis type = (CoordinateAxis)Enum.Parse(typeof(CoordinateAxis), axisDropDown.options[id].text);
        targetStruct.Axis = type;
    }
}
