using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSnake : BaseSnake , ISnake
{
    //public float moveSpeed = 5f;
    //private Vector2 _direction = Vector2.right;
    //private List<Transform> _bodysegments;
    //public Transform segmentPrefab;
    //public GameOverController gameOverController;
    //public ScoreController scoreController;
    //public float leftBoundary = -10f;   // Custom left boundary
    //public float rightBoundary = 10f;   // Custom right boundary
    //public float topBoundary = 5f;      // Custom top boundary
    //public float bottomBoundary = -5f;  // Custom bottom boundary
    //private bool isGameOver = false;
    //private bool canDetectSelfCollision = true;
    //private float snakeLength = 1f;
    //public float growthSize = 0.2f;
    ////powerups
    //private bool shieldActive = false;
    //public bool scoreBoostActive = false;
    //private bool speedUpActive = false;

    //private void Start()
    //{
    //    _bodysegments = new List<Transform>();
    //    _bodysegments.Add(transform);

    //    if (GetComponent<Collider2D>() == null)
    //    {
    //        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    //    }
    //}

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        _direction = Vector2.up;
    //    }
    //    else if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        _direction = Vector2.down;
    //    }
    //    else if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        _direction = Vector2.left;
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        _direction = Vector2.right;
    //    }
    //}

    //private void FixedUpdate()
    //{

    //    for (int i = _bodysegments.Count - 1; i > 0; i--)
    //    {
    //        _bodysegments[i].position = _bodysegments[i - 1].position;
    //    }

    //    this.transform.position = new Vector3(
    //        Mathf.Round(this.transform.position.x) + _direction.x,
    //        Mathf.Round(this.transform.position.y) + _direction.y,
    //        0.0f);


    //    WrapAroundScreen();
    //}

    //public bool IsScoreBoostActive => scoreBoostActive; // Getter for scoreBoostActive

    //public int CurrentLength => _bodysegments.Count;
    //void WrapAroundScreen()
    //{
    //    Vector3 newPosition = transform.position;

    //    // Check boundaries and wrap around using custom values
    //    if (transform.position.y > topBoundary)         // Upper boundary
    //    {
    //        newPosition.y = bottomBoundary;
    //    }
    //    else if (transform.position.y < bottomBoundary) // Lower boundary
    //    {
    //        newPosition.y = topBoundary;
    //    }
    //    if (transform.position.x > rightBoundary)       // Right boundary
    //    {
    //        newPosition.x = leftBoundary;
    //    }
    //    else if (transform.position.x < leftBoundary)   // Left boundary
    //    {
    //        newPosition.x = rightBoundary;
    //    }

    //    // Update the position with wrapped coordinates
    //    transform.position = newPosition;
    //}

    //public void ResetState()
    //{
    //    for (int i = 1; i < _bodysegments.Count; i++)
    //    {
    //        Destroy(_bodysegments[i].gameObject);
    //    }
    //    _bodysegments.Clear();
    //    _bodysegments.Add(this.transform);
    //    this.transform.position = Vector3.zero;
    //}
    //public void Growing()
    //{
    //    Transform segment = Instantiate(this.segmentPrefab);
    //    segment.position = _bodysegments[_bodysegments.Count - 1].position;
    //    _bodysegments.Add(segment);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.tag == "Food")
    //    {
    //        Growing();
    //        int scoreIncrease = scoreBoostActive ? 2 : 1;
    //        scoreController.IncreaseScore(scoreIncrease);
    //    }
    //    else if (collision.tag == "Obstacle")
    //    {
    //        if (!shieldActive)  // Only reset if shield is not active
    //        {
    //            gameOverController.SnakeDied();
    //            scoreController.ResetScore();

    //        }
    //    }
    //    else if (collision.tag == "Test")
    //    {
    //        gameOverController.SnakeDied();
    //    }


    //    else if (collision.tag == "Body")
    //    {
    //        if (!shieldActive)  // Only reset if shield is not active
    //        {
    //            gameOverController.SnakeDied();
    //            scoreController.ResetScore();
    //        }

    //    }
    //    else if (collision.tag == "Player2")
    //    {

    //        if (!shieldActive)  // Only reset if shield is not active
    //        {
    //            gameOverController.SnakeDied();
    //            scoreController.ResetScore();
    //        }
    //    }

    //    else if (collision.tag == "BodyTwo")
    //    {

    //        if (!shieldActive)  // Only reset if shield is not active
    //        {
    //            gameOverController.SnakeDied();
    //            scoreController.ResetScore();
    //        }
    //    }


    //}

    //public void Shrink()
    //{
    //    if (_bodysegments.Count > 1)
    //    {
    //        Transform lastSegment = _bodysegments[_bodysegments.Count - 1];
    //        _bodysegments.RemoveAt(_bodysegments.Count - 1);
    //        Destroy(lastSegment.gameObject);
    //        Debug.Log($"Snake shrank. Current length: {_bodysegments.Count}");
    //    }
    //}


    //public void ActivateShield(float duration)
    //{
    //    shieldActive = true;
    //    StartCoroutine(DeactivatePowerUpAfterTime(() => shieldActive = false, duration));
    //}

    //public void ActivateScoreBoost(float duration)
    //{
    //    scoreBoostActive = true;
    //    StartCoroutine(DeactivatePowerUpAfterTime(() => scoreBoostActive = false, duration));
    //}

    //public void ActivateSpeedUp(float duration)
    //{
    //    speedUpActive = true;
    //    moveSpeed *= 1.5f; // Adjust as needed
    //    StartCoroutine(DeactivatePowerUpAfterTime(() => {
    //        speedUpActive = false;
    //        moveSpeed /= 1.5f;
    //    }, duration));
    //}

    //private IEnumerator DeactivatePowerUpAfterTime(System.Action deactivateAction, float duration)
    //{
    //    yield return new WaitForSeconds(duration);
    //    deactivateAction();
    //}


    public ScoreController scoreController;

    protected override void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }

    

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Food")
        {
            Growing();
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


        else if (collision.tag == "Body")
        {
            if (!shieldActive)  // Only reset if shield is not active
            {
                gameOverController.SnakeDied();
                scoreController.ResetScore();
            }

        }
        else if (collision.tag == "Player2")
        {

            if (!shieldActive)  // Only reset if shield is not active
            {
                gameOverController.SnakeDied();
                scoreController.ResetScore();
            }
        }

        else if (collision.tag == "BodyTwo")
        {

            if (!shieldActive)  // Only reset if shield is not active
            {
                gameOverController.SnakeDied();
                scoreController.ResetScore();
            }
        }

    }
    }
