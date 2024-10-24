using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the snake moves
    private Vector3 moveDirection; // Stores the current direction of movement

    void Start()
    {
        // Set the snake's initial position to the center of the screen
        transform.position = new Vector3(93, 36, -39);
        moveDirection = Vector3.up; 
    }

    void Update()
    {
        MoveSnake();
    }

    void MoveSnake()
    {
        // Detect key inputs for movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Vector3.right;
        }

        // Move the snake in the current direction
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the snake to face the direction of movement
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
