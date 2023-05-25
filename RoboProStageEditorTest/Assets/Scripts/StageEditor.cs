using System;
using System.Collections.Generic;
using UnityEngine;

public class StageEditor : MonoBehaviour
{
    [SerializeField] private SaveAndLoad saveAndLoad;
    [SerializeField] private BlockInstantiater blockInstantiater;
    [SerializeField] private DetailEdit playerDetail;
    [SerializeField] private DetailEdit cameraDetail;

    private void Start()
    {
        saveAndLoad.OnLoad += LoadStage;
    }

    public void LoadStage(StageData data)
    {
        blockInstantiater.Clear();
        int maxY = 0;
        int maxX = 0;
        for (int y = 0; y < data.Blocks.Blocks.Count; y++)
        {
            maxY = Mathf.Max(data.Blocks.Blocks[y].Blocks.Count, maxY);

            for (int x = 0; x < data.Blocks.Blocks[y].Blocks.Count; x++)
            {
                maxX = Mathf.Max(data.Blocks.Blocks[y].Blocks[x].Blocks.Count, maxX);
            }
        }

        for (int z = 0; z < data.Blocks.Blocks.Count; z++)
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    blockInstantiater.InstantiateBlock(data.Blocks.GetBlock(x, y, z), new Vector3Int(x, y, z));
                }
            }
        }

        playerDetail.SetPosition(data.PlayerPosition);
        cameraDetail.SetPosition(data.CameraPosition);

        blockInstantiater.StageData.AccessPointDatas = data.AccessPointDatas;
    }
}
