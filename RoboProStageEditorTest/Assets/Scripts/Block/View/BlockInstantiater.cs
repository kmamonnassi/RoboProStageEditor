using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiater : MonoBehaviour
{
    [SerializeField] private BlockDB db;
    [SerializeField] private BlockClickCollider blockClickPrfeab;
    [SerializeField] private ClickCollider groundPrefab;
    [SerializeField] private Transform groundParent;
    [SerializeField] private BlockPalette palette;
    [SerializeField] private StageData stageData;

    private List<BlockView> blocks = new List<BlockView>();

    private List<(BlockID, Vector3Int)> backLog = new List<(BlockID, Vector3Int)>();
    private List<BlockID> log = new List<BlockID>();

    private int logIndex = 0;

    public event Action<(BlockID, Vector3Int, BlockView, BlockClickCollider)> OnInstantiateBlock;

    public StageData StageData => stageData;

    private void Start()
    {
        stageData = new StageData();
        InstantiateBlock(BlockID.GrassBlock, new Vector3Int(0, 0, 0));

        for(int x = 0; x < 100; x++)
        {
            for(int z = 0; z < 100; z++)
            {
                ClickCollider col = Instantiate(groundPrefab, new Vector3(x, -1, z), Quaternion.identity, groundParent);
                col.OnDownLeft += pos =>
                {
                    InstantiateBlockByClick(new Vector3Int(pos.x, 0, pos.z));
                };
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
        {
            Undo();
        }
        if (Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.LeftShift))
        {
            Redo();
        }
    }

    public void Undo()
    {
        if (backLog.Count - logIndex - 1 < 0) return;

        int idx = backLog.Count - logIndex - 1;
        logIndex++;

        InstantiateBlock(backLog[idx].Item1, backLog[idx].Item2);
    }

    public void Redo()
    {
        if (backLog.Count - logIndex - 1 > backLog.Count - 2) return;

        logIndex--;
        int idx = backLog.Count - logIndex - 1;

        InstantiateBlock(log[idx], backLog[idx].Item2);
    }

    public void InstantiateBlockByClick(BlockID blockID, Vector3Int position)
    {
        ResetBackLog();
        backLog.Add((StageData.Blocks.GetBlock(position.x, position.y, position.z), position));
        log.Add(blockID);

        InstantiateBlock(blockID, position);
    }

    public void InstantiateBlockByClick(Vector3Int position)
    {
        ResetBackLog();
        backLog.Add((StageData.Blocks.GetBlock(position.x, position.y, position.z), position));
        log.Add(palette.NowSelectedID);

        InstantiateBlock(position);
    }

    private void ResetBackLog()
    {
        int idx = backLog.Count - logIndex;
        backLog.RemoveRange(idx, backLog.Count - idx);
        log.RemoveRange(idx, backLog.Count - idx);
        logIndex = 0;
    }

    public void InstantiateBlock(BlockID blockID, Vector3Int position)
    {
        StageData.Blocks.SetBlock(blockID, position.x, position.y, position.z);

        if (blockID == BlockID.Null)
        {
            BlockView deleteBlock = GetBlockView(position);
            blocks.Remove(deleteBlock);
            if(deleteBlock != null) Destroy(deleteBlock.gameObject);
            OnInstantiateBlock?.Invoke((blockID, position, null, null));
            return;
        }
        GameObject prefab = db.GetPrefab(blockID, position.x + position.y + position.z);
        BlockView block = Instantiate(prefab, position, Quaternion.identity, transform).GetComponent<BlockView>();
        block.SetPosition(position);
        blocks.Add(block);

        BlockClickCollider clickCollider = Instantiate(blockClickPrfeab, block.transform);
        clickCollider.transform.localPosition = Vector3.zero;

        clickCollider.X_Plus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(1, 0, 0));
        };
        clickCollider.Y_Plus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(0, 1, 0));
        };
        clickCollider.Z_Plus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(0, 0, 1));
        };

        clickCollider.X_Minus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(-1, 0, 0));
        };
        clickCollider.Y_Minus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(0, -1, 0));
        };
        clickCollider.Z_Minus.OnDownLeft += pos =>
        {
            InstantiateBlockByClick(position + new Vector3Int(0, 0, -1));
        };

        clickCollider.X_Plus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };
        clickCollider.Y_Plus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };
        clickCollider.Z_Plus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };

        clickCollider.X_Minus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };
        clickCollider.Y_Minus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };
        clickCollider.Z_Minus.OnClickRight += pos =>
        {
            InstantiateBlockByClick(BlockID.Null, pos);
        };

        OnInstantiateBlock?.Invoke((blockID, position, block, clickCollider));
    }

    public void InstantiateBlock(Vector3Int position)
    {
        InstantiateBlock(palette.NowSelectedID, position);
    }

    private BlockView GetBlockView(Vector3Int pos)
    {
        foreach(BlockView b in blocks)
        {
            if (b.Position.x == pos.x)
                if (b.Position.y == pos.y)
                    if (b.Position.z == pos.z)
                        return b;
        }
        return null;
    }

    public void Clear()
    {
        List<BlockView> copy = new List<BlockView>(blocks);
        for(int i = 0; i < copy.Count;i++)
        {
            InstantiateBlock(BlockID.Null, copy[i].Position);
        }
    }
}
