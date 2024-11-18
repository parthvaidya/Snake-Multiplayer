using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSnake : MonoBehaviour
{
    public float moveSpeed = 5f;
    protected Vector2 _direction = Vector2.right;
    protected List<Transform> _bodysegments;
    public Transform segmentPrefab;
    public GameOverController gameOverController;
    public float leftBoundary = -10f;
    public float rightBoundary = 10f;
    public float topBoundary = 5f;
    public float bottomBoundary = -5f;
    protected bool shieldActive = false;
    protected bool scoreBoostActive = false;
    protected bool speedUpActive = false;

    protected virtual void Start()
    {
        _bodysegments = new List<Transform>();
        _bodysegments.Add(transform);

        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    protected virtual void Update()
    {
        // To be overridden in subclasses for specific controls
    }

    protected virtual void FixedUpdate()
    {
        for (int i = _bodysegments.Count - 1; i > 0; i--)
        {
            _bodysegments[i].position = _bodysegments[i - 1].position;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _direction.x,
            Mathf.Round(transform.position.y) + _direction.y,
            0.0f);

        WrapAroundScreen();
    }



    public bool IsScoreBoostActive => scoreBoostActive;

    public int CurrentLength => _bodysegments.Count;

    protected void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.y > topBoundary)
        {
            newPosition.y = bottomBoundary;
        }
        else if (transform.position.y < bottomBoundary)
        {
            newPosition.y = topBoundary;
        }
        if (transform.position.x > rightBoundary)
        {
            newPosition.x = leftBoundary;
        }
        else if (transform.position.x < leftBoundary)
        {
            newPosition.x = rightBoundary;
        }

        transform.position = newPosition;
    }

    public void ResetState()
    {
        for (int i = 1; i < _bodysegments.Count; i++)
        {
            Destroy(_bodysegments[i].gameObject);
        }
        _bodysegments.Clear();
        _bodysegments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }

    

    public void Growing()
    {
        Transform segment = Instantiate(segmentPrefab);
        Vector3 lastSegmentPosition = _bodysegments[_bodysegments.Count - 1].position;

        // Offset the new segment slightly to ensure no gap
        segment.position = lastSegmentPosition - new Vector3(0, 0.2f, 0); // Adjust the offset as needed
        _bodysegments.Add(segment);
    }

    public void Shrink()
    {
        if (_bodysegments.Count > 1)
        {
            Transform lastSegment = _bodysegments[_bodysegments.Count - 1];
            _bodysegments.RemoveAt(_bodysegments.Count - 1);
            Destroy(lastSegment.gameObject);
            Debug.Log($"Snake shrank. Current length: {_bodysegments.Count}");
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
        moveSpeed *= 1.5f;
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
