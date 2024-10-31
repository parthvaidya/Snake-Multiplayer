using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the snake moves
    private Vector3 moveDirection;
    public Transform segmentPrefab;
    private List<Transform> _segments = new List<Transform>();
    public GameOverController gameOverController;
    public ScoreController scoreController;
    public float leftBoundary = -10f;   // Custom left boundary
    public float rightBoundary = 10f;   // Custom right boundary
    public float topBoundary = 5f;      // Custom top boundary
    public float bottomBoundary = -5f;  // Custom bottom boundary
    private bool isGameOver = false;
    private bool canDetectSelfCollision = true;
    private float snakeLength = 1f;
    public float growthSize = 0.2f;
    //powerups
    private bool shieldActive = false;
    public bool scoreBoostActive = false;
    private bool speedUpActive = false;
    private void Start()
    {
        moveDirection = Vector3.up;
        _segments = new List<Transform>();
        _segments.Add(this.transform);


        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void FixedUpdate()
    {
        // Move the head of the snake
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotate the snake to face the direction of movement
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Move the body segments
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }




        WrapAroundScreen();

        //for (int i = 1; i < _segments.Count; i++)
        //{
        //    if (Vector3.Distance(transform.position, _segments[i].position) < 0.1f)
        //    {
        //        ResetState();  // Resets the game state
        //        scoreController.ResetScore();
        //        break;
        //    }
        //}
    }

    public bool IsScoreBoostActive => scoreBoostActive; // Getter for scoreBoostActive

    public int CurrentLength => _segments.Count;
    void Update()
    {
        // Detect key inputs for movement
        UpdateMoveDirection();
    }

    void UpdateMoveDirection()
    {
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
            int scoreIncrease = scoreBoostActive ? 2 : 1;
            scoreController.IncreaseScore(scoreIncrease);
        }
        else if (collision.tag == "Obstacle")
        {
            if (!shieldActive)  // Only reset if shield is not active
            {
                gameOverController.SnakeDied();
                scoreController.ResetScore();

            }
        }
        else if (collision.tag == "Test")
        {
            gameOverController.SnakeDied();
        }


    }




    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position  ;
        _segments.Add(segment);
    }

    public void Shrink()
    {
        if (_segments.Count > 1)
        {
            Transform lastSegment = _segments[_segments.Count - 1];
            _segments.RemoveAt(_segments.Count - 1);
            Destroy(lastSegment.gameObject);
            Debug.Log($"Snake shrank. Current length: {_segments.Count}");
        }
    }


    public void ActivateShield(float duration)
    {
        shieldActive = true;
        StartCoroutine(DeactivatePowerUpAfterTime(() => shieldActive = false, duration));
    }

    public void ActivateScoreBoost(float duration)
    {
        scoreBoostActive = true;
        StartCoroutine(DeactivatePowerUpAfterTime(() => scoreBoostActive = false, duration));
    }

    public void ActivateSpeedUp(float duration)
    {
        speedUpActive = true;
        moveSpeed *= 1.5f; // Adjust as needed
        StartCoroutine(DeactivatePowerUpAfterTime(() => {
            speedUpActive = false;
            moveSpeed /= 1.5f;
        }, duration));
    }

    private IEnumerator DeactivatePowerUpAfterTime(System.Action deactivateAction, float duration)
    {
        yield return new WaitForSeconds(duration);
        deactivateAction();
    }

}
