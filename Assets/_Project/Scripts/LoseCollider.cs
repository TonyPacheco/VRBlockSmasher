using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //lose collider layer only interacts with ball layer, so i don't bother checking obj type
        GameManager.Instance.OnBallOutOfBounds();
    }
}
