using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the snake moves
    private Vector3 moveDirection; // Stores the current direction of movement
    private bool isShielded = false;
    private int scoreMultiplier = 1;
    public GameObject bodyPartPrefab;
    private List<Transform> bodyParts = new List<Transform>();
    public int initialBodyParts = 3;
    public int Length => bodyParts.Count;

    public delegate void BodyPartAddedHandler();
    public event BodyPartAddedHandler OnBodyPartAdded;

    public float bodyPartSpacing = 0.5f;


    void Start()
    {
        
        // Set the snake's initial position to the center of the screen
        transform.position = new Vector3(93, 36, -39);
        moveDirection = Vector3.up;
        EnableBodyRenderers();
        InitializeBody();
        
        //AddBodyPart();
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
        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, Time.deltaTime * 10);

        // Update body parts' positions to follow the previous segments
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position; // Follow the part in front
        }

        // If there are body parts, set the first body part to follow the head's previous position
        if (bodyParts.Count > 0)
        {
            //bodyParts[0].position = transform.position - (moveDirection.normalized * bodyPartSpacing); // First body part takes the head's previous position
            bodyParts[0].position = bodyParts[bodyParts.Count - 1].position - (moveDirection.normalized * bodyPartSpacing);
        }


        // Move each body part to the position of the one in front of it
        for (int i = 0; i < bodyParts.Count; i++)
        {
            Vector3 tempPosition = bodyParts[i].position;
            bodyParts[i].position = transform.position;
            transform.position = tempPosition;
        }
    }

    public void ActivatePowerUp(PowerUpType type, float duration)
    {
        switch (type)
        {
            case PowerUpType.Shield:
                StartCoroutine(ActivateShield(duration));
                break;
            case PowerUpType.ScoreBoost:
                StartCoroutine(ActivateScoreBoost(duration));
                break;
            case PowerUpType.SpeedUp:
                StartCoroutine(ActivateSpeedBoost(duration));
                break;
        }
    }

    private void InitializeBody()
    {
        Debug.Log("Initializing snake with " + initialBodyParts + " body parts.");
        for (int i = 0; i < initialBodyParts; i++)
        {
            GrowSnake(1, initiallyHidden: true); // Add parts but keep them hidden
        }
    }

    private void EnableBodyRenderers()
    {
        foreach (Transform bodyPart in bodyParts)
        {
            SpriteRenderer renderer = bodyPart.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true; // Enable rendering after positioning
            }
        }
    }

    private void OnEnable()
    {
        OnBodyPartAdded += EnableBodyRenderers;
    }

    private void OnDisable()
    {
        OnBodyPartAdded -= EnableBodyRenderers;
    }

    //public void GrowSnake(int amount, bool initiallyHidden = false)
    //{
    //    for (int i = 0; i < Mathf.Abs(amount); i++)
    //    {
    //        if (amount > 0)
    //        {
    //            GameObject newPart = Instantiate(bodyPartPrefab);

    //            // Position the new body part behind the last body part
    //            if (bodyParts.Count > 0)
    //            {
    //                newPart.transform.position = bodyParts[bodyParts.Count - 1].position; // Position it at the last part's position
    //            }
    //            else
    //            {
    //                newPart.transform.position = transform.position; // Position it at the snake head if no parts exist
    //            }

    //            // Disable the renderer initially
    //            SpriteRenderer renderer = newPart.GetComponent<SpriteRenderer>();
    //            if (renderer != null)
    //            {
    //                renderer.enabled = initiallyHidden; // Keep it hidden initially
    //            }

    //            bodyParts.Add(newPart.transform); // Add to the body parts list
    //            Debug.Log("Added body part. Total body parts: " + bodyParts.Count);
    //        }
    //        else if (bodyParts.Count > 0)
    //        {
    //            Destroy(bodyParts[bodyParts.Count - 1].gameObject);
    //            bodyParts.RemoveAt(bodyParts.Count - 1);
    //            Debug.Log("Removed body part. Total body parts: " + bodyParts.Count);
    //        }
    //    }
    //}

    public void GrowSnake(int amount, bool initiallyHidden = false)
    {
        for (int i = 0; i < Mathf.Abs(amount); i++)
        {
            if (amount > 0)
            {
                GameObject newPart = Instantiate(bodyPartPrefab);

                // Position the new body part behind the last body part
                if (bodyParts.Count > 0)
                {
                    Transform lastBodyPart = bodyParts[bodyParts.Count - 1];
                    newPart.transform.position = lastBodyPart.position - (moveDirection.normalized * bodyPartSpacing);
                }
                else
                {
                    // If no body parts exist, place it at the head's initial position
                    newPart.transform.position = transform.position - (moveDirection.normalized * bodyPartSpacing);
                }

                // Disable the renderer initially if needed
                SpriteRenderer renderer = newPart.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.enabled = initiallyHidden;
                }

                bodyParts.Add(newPart.transform); // Add the new part to the body parts list
            }
            else if (bodyParts.Count > 0)
            {
                // Remove a body part if shrinking
                Destroy(bodyParts[bodyParts.Count - 1].gameObject);
                bodyParts.RemoveAt(bodyParts.Count - 1);
            }
        }
    }


    private IEnumerator ActivateShield(float duration)
    {
        isShielded = true;
        Debug.Log("Shield activated!");
        yield return new WaitForSeconds(duration);
        isShielded = false;
        Debug.Log("Shield expired.");
    }

    private IEnumerator ActivateScoreBoost(float duration)
    {
        scoreMultiplier = 2;
        Debug.Log("Score Boost activated!");
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1;
        Debug.Log("Score Boost expired.");
    }

    private IEnumerator ActivateSpeedBoost(float duration)
    {
        moveSpeed *= 1.5f;
        Debug.Log("Speed Boost activated!");
        yield return new WaitForSeconds(duration);
        moveSpeed /= 1.5f;
        Debug.Log("Speed Boost expired.");
    }
}
