using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    public Tile Tile;
    public Block CombiningBlock;
    public bool Combining;
    public int ScoreGain;
    public Vector2 GetPos => transform.position;
    private Vector2 previousPos;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshPro text;
    public void Init(BlockData data)
    {
        Value = data.Value;
        spriteRenderer.color = data.Color;
        text.text = data.Value.ToString();
        previousPos = transform.position;
        ScoreGain = data.ScoreGain;
    }

    public void SetBlock(Tile tile)
    {
        if (previousPos != (Vector2)transform.position)
            previousPos = transform.position;

        if (Tile != null) Tile.OccupiedBlock = null;
        Tile = tile;
        tile.OccupiedBlock = this;

    }

    public void CombineBlock(Block blockToCombineWith)
    {
        // Set the block we are merging with
        CombiningBlock = blockToCombineWith;

        // Set current node as unoccupied to allow blocks to use it
        Tile.OccupiedBlock = null;

        // Set the base block as merging, so it does not get used twice.
        blockToCombineWith.Combining = true;
    }

    public bool CanCombine(int value)
    {
        if (value == Value && !Combining && CombiningBlock == null)
            return true;
        return false;
    }

    public bool HasCombinableBlocksSurround(List<Block> blocks)
    {
        // block left to this block
        var blockL = blocks.Where(b => b.GetPos.x == GetPos.x - 1 && b.GetPos.y == GetPos.y).ToArray();
        if (blockL.Count() > 0 && blockL[0].Value == Value) return true;

        // block right to this block
        var blockR = blocks.Where(b => b.GetPos.x == GetPos.x + 1 && b.GetPos.y == GetPos.y).ToArray();
        if (blockR.Count() > 0 && blockR[0].Value == Value) return true;

        // block above to this block
        var blockA = blocks.Where(b => b.GetPos.x == GetPos.x && b.GetPos.y == GetPos.y + 1).ToArray();
        if (blockA.Count() > 0 && blockA[0].Value == Value) return true;

        // block below to this block
        var blockB = blocks.Where(b => b.GetPos.x == GetPos.x && b.GetPos.y == GetPos.y - 1).ToArray();
        if (blockB.Count() > 0 && blockB[0].Value == Value) return true;

        return false;
    }
}
