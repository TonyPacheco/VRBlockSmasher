using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager _instance;
    public static PrefabManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }
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
    }

    public GameObject Ball;
    public GameObject Block;

    public GameObject InstantiateBall()
    {
        GameObject ball = Instantiate(Ball);
        return ball;
    }

    public GameObject InstantiateBlock()
    {
        GameObject block = Instantiate(Block);
        return block;
    }
}
