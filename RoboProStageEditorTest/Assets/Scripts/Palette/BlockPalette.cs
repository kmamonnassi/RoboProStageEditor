using System.Collections.Generic;
using UnityEngine;

public class BlockPalette : MonoBehaviour
{
    [SerializeField] private BlockDB blockDB;
    [SerializeField] private BlockSlot blockSlot;
    [SerializeField] private Transform slotParent;

    private List<BlockSlot> slots = new List<BlockSlot>();

    public BlockID NowSelectedID { get; private set; } = BlockID.GrassBlock;

    private int selectedIdx;

    private void Start()
    {
        for(int i = 0; i < blockDB.Datas.Count; i++)
        {
            int idx = i;
            BlockSlot slot = Instantiate(blockSlot, slotParent);
            slots.Add(slot);
            slot.SetIndex(idx);
            slot.SetBlock(blockDB.Datas[idx]);
            slot.OnClick += id =>
            {
                if (selectedIdx == slot.Index) return;
                NowSelectedID = id;
                slot.Active();
                slots[selectedIdx].Inactive();
                selectedIdx = idx;
                selectedIdx = slot.Index;
            };
        }
        slots[0].Active();
    }
}
