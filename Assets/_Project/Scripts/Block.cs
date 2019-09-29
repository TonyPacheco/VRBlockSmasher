using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public new Transform transform;

    public int HitsRemaining;
    public int PointValue;
    public int Id;

    void Awake()
    {
        transform = gameObject.transform;
        gameObject.layer = (int) GameManager.Layers.Blocks;
    }

    public void Init(Vector3 pos, int id, int hitsToBreak = 1, int pointValue = 10)
    {
        Id = id;
        PointValue = pointValue;
        transform.position = pos;
        HitsRemaining = hitsToBreak;
    }

    void OnCollisionEnter(Collision collision)
    {
        //block layer only interacts with ball layer, so i don't bother checking obj type
        GameManager.Instance.OnBlockHit(this);
    }

}
