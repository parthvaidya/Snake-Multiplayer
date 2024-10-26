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


    public void ResetState()
    {

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
        }
        
    }

   


    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

    }

    }
