using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedPositionUtility : MonoBehaviour
{
    public static Vector3 GetRandomPosition(BoxCollider2D gridArea)
    { //added randomization

        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}
