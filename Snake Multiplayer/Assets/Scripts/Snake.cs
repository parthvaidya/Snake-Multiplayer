using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the snake moves
    private Vector3 moveDirection;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public ScoreController scoreController;
    public float leftBoundary = -10f;   // Custom left boundary
    public float rightBoundary = 10f;   // Custom right boundary
    public float topBoundary = 5f;      // Custom top boundary
    public float bottomBoundary = -5f;  // Custom bottom boundary

    private void Start()
    {
        moveDirection = Vector3.up;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }
    void FixedUpdate()
    {
        for (int i = _segments.Count -1 ; i > 0 ; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the snake to face the direction of movement
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        WrapAroundScreen();

    }
    void Update()
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
        
    }

    void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        // Check boundaries and wrap around using custom values
        if (transform.position.y > topBoundary)         // Upper boundary
        {
            newPosition.y = bottomBoundary;
        }
        else if (transform.position.y < bottomBoundary) // Lower boundary
        {
            newPosition.y = topBoundary;
        }

        if (transform.position.x > rightBoundary)       // Right boundary
        {
            newPosition.x = leftBoundary;
        }
        else if (transform.position.x < leftBoundary)   // Left boundary
        {
            newPosition.x = rightBoundary;
        }

        // Update the position with wrapped coordinates
        transform.position = newPosition;
    }
    public void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Food")
        {
            Grow();
            scoreController.IncreaseScore(10);
        }
        else if (collision.tag == "Obstacle")
        {
            ResetState();
            //scoreController.RefreshUI();
        }
        
    }

   


    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position ;
        _segments.Add(segment);

    }

    }
