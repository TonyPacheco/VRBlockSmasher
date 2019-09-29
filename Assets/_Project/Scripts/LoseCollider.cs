using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    void Start()
    {
        gameObject.layer = (int) GameManager.Layers.Bounds;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //lose collider layer only interacts with ball layer, so i don't bother checking obj type
        GameManager.Instance.OnBallOutOfBounds();
    }
}
