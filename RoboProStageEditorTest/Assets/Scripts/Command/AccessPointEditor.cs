using Command;
using UnityEngine;
using UnityEngine.UI;

public class AccessPointEditor : MonoBehaviour
{
    [SerializeField] private BlockInstantiater blockIns;
    [SerializeField] private Text text;
    [SerializeField] private CommandStructElement[] elements;
    [SerializeField] private Button addButton;
    [SerializeField] private Button removeButton;
    [SerializeField] private GameObject inactivePanel;

    private AccessPointData nowEditData;

    private void Start()
    {
        for(int i = 0; i < elements.Length; i++)
        {
            int a = i;
        }

        blockIns.OnInstantiateBlock += data =>
        {
            BlockID id = data.Item1;
            if(id >= BlockID.Command_Red && id < BlockID.Command_Black)
            {
                AccessPointData accessPointData = new AccessPointData();
                accessPointData.ColorID = BlockIDConvertTo(id);

                CommandStruct firstStruct = new CommandStruct(MainCommandType.Move, false, false, false, 1, CoordinateAxis.X, 0);
                CommandStruct secondStruct = new CommandStruct(MainCommandType.None, true, true, true, 0, CoordinateAxis.NONE, 0);
                CommandStruct thirdStruct = new CommandStruct(MainCommandType.None, true, true, true, 0, CoordinateAxis.NONE, 0);
                accessPointData.Commands.Add(firstStruct);
                accessPointData.Commands.Add(secondStruct);
                accessPointData.Commands.Add(thirdStruct);
                
                
                blockIns.StageData.AccessPointDatas.Add(accessPointData);

                data.Item4.X_Plus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item4.Y_Plus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item4.Z_Plus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item4.X_Minus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item4.Y_Minus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item4.Z_Minus.OnDownMiddle += pos =>
                {
                    StartEdit(id);
                    Debug.Log(id);
                };

                data.Item3.OnDelete += () =>
                {
                    blockIns.StageData.AccessPointDatas.Remove(accessPointData);

                    if (nowEditData != null)
                    {
                        if(nowEditData.ColorID == BlockIDConvertTo(id))
                        {
                            inactivePanel.SetActive(true);
                        }
                    }
                };
            }
        };
        addButton.onClick.AddListener(Add);
        removeButton.onClick.AddListener(Remove);
    }

    private void Add()
    {
        if (nowEditData.Commands.Count >= 3) return;
        int idx = nowEditData.Commands.Count;
        nowEditData.Commands.Add(new CommandStruct());
        elements[idx].gameObject.SetActive(true);
    }

    private void Remove()
    {
        if (nowEditData == null) return;

        if (nowEditData.Commands.Count == 0) return;
        int idx = nowEditData.Commands.Count - 1;
        nowEditData.Commands.RemoveAt(idx);
        elements[idx].gameObject.SetActive(false);

    }

    private void StartEdit(BlockID id)
    {
        inactivePanel.gameObject.SetActive(false);

        nowEditData = blockIns.StageData.AccessPointDatas.Find(x => x.ColorID == BlockIDConvertTo(id));

        text.text = BlockIDConvertTo(id).ToString();
        text.color = ColorIDConvertColor(BlockIDConvertTo(id));

        for (int i = 0; i < elements.Length;i++)
        {
            elements[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < nowEditData.Commands.Count; i++)
        {
            elements[i].SetStruct(nowEditData.Commands[i]);
            elements[i].gameObject.SetActive(true);
        }
    }

    private ColorID BlockIDConvertTo(BlockID id)
    {
        switch (id)
        {
            case BlockID.Command_Red:
                return ColorID.Red;
            case BlockID.Command_Green:
                return ColorID.Green;
            case BlockID.Command_Blue:
                return ColorID.Blue;
            case BlockID.Command_Yellow:
                return ColorID.Yellow;
            case BlockID.Command_Cyan:
                return ColorID.Cyan;
            case BlockID.Command_Purple:
                return ColorID.Purple;
            case BlockID.Command_White:
                return ColorID.White;
            case BlockID.Command_Black:
                return ColorID.Black;
        }
        return ColorID.Black;
    }

    private Color ColorIDConvertColor(ColorID id)
    {
        switch (id)
        {
            case ColorID.Red:
                return Color.red;
            case ColorID.Green:
                return Color.green;
            case ColorID.Blue:
                return Color.blue;
            case ColorID.Yellow:
                return Color.yellow;
            case ColorID.Cyan:
                return Color.cyan;
            case ColorID.Purple:
                return Color.magenta;
            case ColorID.White:
                return Color.white;
            case ColorID.Black:
                return Color.black;
        }
        return Color.black;
    }
}
