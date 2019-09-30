using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Layers
    {
        Default = 0,
        Balls = 8,
        Blocks = 9,
        Bounds = 10
    }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance; private set => _instance = value;
    }

    [SerializeField]
    private List<Transform> BlockPoints;

    private List<Block> PooledBlocks;
    private Dictionary<int, Block> ActiveBlocks;

    [SerializeField]
    private Transform PooledBlocksPoint;

    [SerializeField]
    private Transform Ball;
    [SerializeField]
    private Transform BallRespawnPoint;

    [SerializeField]
    private int Score;
    [SerializeField]
    private int Lives = 3;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ActiveBlocks = new Dictionary<int, Block>();
        PooledBlocks = new List<Block>();
    }

    void Start()
    {
        //Todo: play sound
        //Todo: visual effect
        SpawnBlocks();
        ResetBall();
    }

    private void SpawnBlocks()
    {
        for(int i = 0; i < BlockPoints.Count; ++i)
        {
            var block = PrefabManager.Instance.InstantiateBlock().GetComponent<Block>();
            block.Init(BlockPoints[i].position, i);
            ActiveBlocks.Add(i, block);
        }
    }

    private void ResetBall()
    {
        if(Ball == null)
        {
            Ball = PrefabManager.Instance.InstantiateBall().transform;
        }
        Ball.position = BallRespawnPoint.position;
    }

    public void OnBallOutOfBounds()
    {
        //Todo: play sound
        //Todo: visual effect
        Lives--;
        if(Lives <= 0)
        {
            LoseGame();
        }
        else
        {
            ResetBall();
        }
    }

    public void OnBlockHit(Block block)
    {
        //Todo: play sound
        //Todo: visual effect
        block.HitsRemaining--; 
        if(block.HitsRemaining <= 0)
        {
            RemoveBlock(block);
        }
    }

    private void RemoveBlock(Block block)
    {
        //Todo: play sound
        //Todo: visual effect
        block.transform.position = PooledBlocksPoint.position;
        ActiveBlocks.Remove(block.Id);
        PooledBlocks.Add(block);
        AddScore(block.PointValue);
        if(ActiveBlocks.Count <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        //??
        Debug.Log("You won I guess..");
    }

    private void AddScore(int score)
    {
        //Todo: visuals
        Score += score;
    }

    private void LoseGame()
    {
        //??
        Debug.Log("You LOST!");
    }

}
