using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Random = UnityEngine.Random;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;

public enum GameState { GenerateLevel, SpawningBlocks, WaitingInput, Moving, Win, Lose }

public class GameManager : MonoBehaviour
{
    [SerializeField] private int size = 4;

    [SerializeField] private int tileSpawnPerRound = 1;

    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Block blockPrefab;
    [SerializeField] private SpriteRenderer boardPrefab;
    [SerializeField] private float blockTravelTime = 0.2f;
    [SerializeField] private BlockData[] blockDatas;
    [SerializeField] private int winCondition = 16384;
    [SerializeField] private GameObject winScreen, loseScreen;

    [SerializeField] private TextMeshProUGUI moveText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI sizeText;

    private int Score;

    private List<Tile> tileList;
    private List<Block> blockList;
    private SpriteRenderer board;
    private GameState state;
    private int move;

    private void Start()
    {
        ChangeState(GameState.GenerateLevel);
    }

    private void Update()
    {
        if (state != GameState.WaitingInput) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) Move(Vector2.left);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) Move(Vector2.right);
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) Move(Vector2.up);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) Move(Vector2.down);
    }

    private void ChangeState(GameState state)
    {
        this.state = state;
        switch (state)
        {
            case GameState.GenerateLevel:
                GenerateGrid();
                break;
            case GameState.SpawningBlocks:
                move++;
                SpawnBlocks(move <= 0 ? 2 : 1);
                break;
            case GameState.WaitingInput:
                break;
            case GameState.Moving:
                break;
            case GameState.Win:
                winScreen.SetActive(true);
                break;
            case GameState.Lose:
                loseScreen.SetActive(true);
                break;
        }
    }

    private void GenerateGrid()
    {
        move = -1; moveText.text = "move: 0";
        Score = 0; scoreText.text = "score: 0";
        sizeText.text = $"{size}";

        tileList = new List<Tile>();
        blockList = new List<Block>();

        var center = new Vector2(size / 2f - 0.5f, size / 2f - 0.5f);
        board = Instantiate(boardPrefab, center, quaternion.identity);
        board.size = new Vector2(size, size);

        Camera.main.transform.position = new Vector3(center.x, center.y, Camera.main.transform.position.z);
        Camera.main.orthographicSize = Mathf.Clamp(size - 2, 3, 8);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector2(x, y), quaternion.identity);
                tileList.Add(tile);
            }
        }

        ChangeState(GameState.SpawningBlocks);
    }

    private void SpawnBlocks(int amount)
    {
        var availableTiles = tileList.Where(t => t.OccupiedBlock == null).OrderBy(b => Random.value).ToList();

        foreach (var tile in availableTiles.Take(amount))
        {
            float ran = Random.value;
            int value = 0;
            if (ran <= 0.7f) value = 2;
            else if (ran > 0.7f && ran < 0.9f) value = 4;
            else value = 8;

            SpawnBlock(tile, value);
        }

        if (availableTiles.Count() <= 0)
        {
            // gameover

            // check if any block as combinable block in surround 4 tiles
            foreach (Block block in blockList)
            {
                if (block.HasCombinableBlocksSurround(blockList))
                {
                    ChangeState(GameState.WaitingInput);
                    return;
                }
            }
            ChangeState(GameState.Lose);
            return;
        }

        ChangeState(blockList.Any(b => b.Value >= winCondition) ? GameState.Win : GameState.WaitingInput);
    }

    private void SpawnBlock(Tile tile, int value)
    {
        var block = Instantiate(blockPrefab, tile.GetPos, quaternion.identity);
        block.Init(GetBlockDataByValue(value));
        Score += move > 0 ? block.ScoreGain : 0;
        block.SetBlock(tile);
        blockList.Add(block);

        moveText.text = $"move: {move}";
        scoreText.text = $"score: {Score}";
    }

    private void Move(Vector2 dir)
    {
        ChangeState(GameState.Moving);

        var sortedBlockList = blockList.OrderBy(b => b.GetPos.x).ThenBy(b => b.GetPos.y).ToList();
        if (dir == Vector2.right || dir == Vector2.up) sortedBlockList.Reverse();


        foreach (var block in sortedBlockList)
        {
            var next = block.Tile;
            do
            {
                block.SetBlock(next);

                var possilbeTile = GetTileAtPosition(next.GetPos + dir);
                if (possilbeTile != null)
                {
                    // We know a tile is present
                    // If it's possible to combine, set combine
                    if (possilbeTile.OccupiedBlock != null && possilbeTile.OccupiedBlock.CanCombine(block.Value))
                    {
                        block.CombineBlock(possilbeTile.OccupiedBlock);
                    }
                    // Otherwise, can we move to this spot?
                    else if (possilbeTile.OccupiedBlock == null) next = possilbeTile;
                    // None hit? End do while loop
                }
            } while (next != block.Tile);
        }


        var sequence = DOTween.Sequence();

        foreach (var block in sortedBlockList)
        {
            var movePoint = block.CombiningBlock != null ? block.CombiningBlock.Tile.GetPos : block.Tile.GetPos;
            sequence.Insert(0, block.transform.DOMove(movePoint, blockTravelTime).SetEase(Ease.InQuad));
        }

        sequence.OnComplete(() =>
        {
            var combineBlocks = sortedBlockList.Where(b => b.CombiningBlock != null).ToList();
            foreach (var block in combineBlocks)
            {
                CombineBlock(block.CombiningBlock, block);
            }
            ChangeState(GameState.SpawningBlocks);
        });
    }

    private void CombineBlock(Block baseBlock, Block combiningBlock)
    {
        SpawnBlock(baseBlock.Tile, baseBlock.Value * 2);
        RemoveBlock(baseBlock);
        RemoveBlock(combiningBlock);
    }

    private void RemoveBlock(Block block)
    {
        blockList.Remove(block);
        Destroy(block.gameObject);
    }

    private Tile GetTileAtPosition(Vector2 pos)
    {
        return tileList.FirstOrDefault(t => t.GetPos == pos);
    }

    private BlockData GetBlockDataByValue(int value)
    {
        return blockDatas.First(d => d.Value == value);
    }

    public void OnRestartBtnClicked()
    {
        Destroy(board.gameObject);

        Block[] tempBlockArray = blockList.ToArray();
        foreach (Block block in tempBlockArray)
        {
            RemoveBlock(block);
        }
        foreach (Tile tile in tileList)
        {
            Destroy(tile.gameObject);
        }
        if (loseScreen.activeSelf) loseScreen.SetActive(false);
        GenerateGrid();
    }
    public void OnIncreaseBtnclicked()
    {
        size += 1;
        size = Mathf.Clamp(size, 3, 8);
        sizeText.text = $"{size}";
    }
    public void OnDecreaseBtnclicked()
    {
        size -= 1;
        size = Mathf.Clamp(size, 3, 8);
        sizeText.text = $"{size}";
    }
}