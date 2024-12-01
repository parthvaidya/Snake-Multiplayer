using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private float xBoundary = 100f; // Adjust this to match the game area
    [SerializeField] private float yBoundary = 100f;

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
