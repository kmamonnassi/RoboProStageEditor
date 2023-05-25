using UnityEngine;

public class BlockClickCollider : MonoBehaviour
{
    [SerializeField] private ClickCollider x;
    [SerializeField] private ClickCollider y;
    [SerializeField] private ClickCollider z;

    public ClickCollider X => x;
    public ClickCollider Y => y;
    public ClickCollider Z => z;
}
