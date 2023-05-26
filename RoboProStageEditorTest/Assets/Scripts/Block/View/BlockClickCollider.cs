using UnityEngine;

public class BlockClickCollider : MonoBehaviour
{
    [SerializeField] private ClickCollider x_Plus;
    [SerializeField] private ClickCollider y_Plus;
    [SerializeField] private ClickCollider z_Plus;
    [SerializeField] private ClickCollider x_Minus;
    [SerializeField] private ClickCollider y_Minus;
    [SerializeField] private ClickCollider z_Minus;

    public ClickCollider X_Plus => x_Plus;
    public ClickCollider Y_Plus => y_Plus;
    public ClickCollider Z_Plus => z_Plus;
    public ClickCollider X_Minus => x_Minus;
    public ClickCollider Y_Minus => y_Minus;
    public ClickCollider Z_Minus => z_Minus;
}
