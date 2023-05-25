using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector3 offset = new Vector3(0, -50, 0);
    [SerializeField] private float blockSize = 12.5f;
    [SerializeField] private Image activePane;

    public event Action<BlockID> OnClick;

    public int Index { get; private set; }
    public BlockID ID { get; private set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(ID);
    }

    public void SetIndex(int idx)
    {
        this.Index = idx;
    }

    public void SetBlock(BlockData data)
    {
        GameObject block = Instantiate(data.Obj_Even, transform);
        block.transform.localPosition = offset;
        block.transform.localScale *= blockSize;
        ID = data.ID;
    }

    public void Active()
    {
        activePane.gameObject.SetActive(true);
    }

    public void Inactive()
    {
        activePane.gameObject.SetActive(false);
    }
}
