using UnityEngine;

public class GoalCameraEditor : MonoBehaviour
{
    [SerializeField] private BlockInstantiater blockInstantiater;
    [SerializeField] private DetailEdit edit;

    //public enum Direction

    private void Start()
    {
        blockInstantiater.OnInstantiateBlock += data =>
        {

            data.Item4.X_Plus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };

            data.Item4.Y_Plus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };

            data.Item4.Z_Plus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };

            data.Item4.X_Minus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };

            data.Item4.Y_Minus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };

            data.Item4.Z_Minus.OnDownMiddle += pos =>
            {
                StartEdit(pos);
            };
        };
    }

    private void StartEdit(Vector3Int pos)
    {
        //edit.SetPosition(pos + );
    }
}
