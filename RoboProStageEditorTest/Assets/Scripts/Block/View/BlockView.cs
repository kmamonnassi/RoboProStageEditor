using System;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] private BlockID id;
    [SerializeField] private Vector3 offset;

    public BlockID ID => id;
    public Vector3Int Position { get; private set; }

    public event Action OnDelete;

    private void Start()
    {
        transform.position += offset;
    }

    public void SetPosition(Vector3Int position)
    {
        Position = position;
    }

    private void OnDestroy()
    {
        OnDelete?.Invoke();
    }
}
