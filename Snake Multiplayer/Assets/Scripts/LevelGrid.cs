using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public float xBoundary = 100f; // Adjust this to match the game area
    public float yBoundary = 100f;

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x > xBoundary)
            newPosition.x = -xBoundary;
        else if (transform.position.x < -xBoundary)
            newPosition.x = xBoundary;

        if (transform.position.y > yBoundary)
            newPosition.y = -yBoundary;
        else if (transform.position.y < -yBoundary)
            newPosition.y = yBoundary;

        transform.position = newPosition;
    }
}
