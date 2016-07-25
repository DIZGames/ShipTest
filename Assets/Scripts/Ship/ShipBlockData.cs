using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipBlockData{

    // Saves the blocks of the ship
    Dictionary<Vector3, IBlock> blocks = new Dictionary<Vector3, IBlock>();
    Dictionary<IBlock, Vector3> blocksReverse = new Dictionary<IBlock, Vector3>();

    public IBlock getBlock(Vector3 pos)
    {
        IBlock block;
        blocks.TryGetValue(pos, out block);
        return block;
    } 

    public Vector3 getPosition(IBlock block){
        Vector3 pos;
        blocksReverse.TryGetValue(block, out pos);
        return pos;
    }

    public void addBlock(Vector3 pos, IBlock block)
    {
        blocks[pos] = block;
        blocksReverse[block] = pos;
    }

    public void removeBlock(Vector3 pos)
    {
        IBlock block;
        blocks.TryGetValue(pos, out block);
        if (block != null)
        {
            blocks.Remove(pos);
            blocksReverse.Remove(block);
        }
    }
}
