using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the snake moves
    private Vector3 moveDirection; // Stores the current direction of movement
    private bool isShielded = false;
    private int scoreMultiplier = 1;
    public Sprite snakeBodySprite; // The sprite for the snake body
    private List<GameObject> bodyParts = new List<GameObject>();

    public int Length => bodyParts.Count;

    void Start()
    {
        // Set the snake's initial position to the center of the screen
        transform.position = new Vector3(93, 36, -39);
        moveDirection = Vector3.up;
        AddBodyPart();
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


    public void GrowSnake(int amount)
    {
        // Adjust the scale to match the snake head's scale
        Vector3 headScale = transform.localScale; // Get the scale of the snake head
        Vector3 bodyPartScale = new Vector3(headScale.x, headScale.y, headScale.z); // Set body part scale to match head

        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                // Create a new GameObject for the body part
                GameObject newBodyPart = new GameObject("SnakeBodyPart");
                SpriteRenderer spriteRenderer = newBodyPart.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = snakeBodySprite; // Assign your body sprite here
                newBodyPart.transform.localScale = bodyPartScale; // Set scale to match head

                // Position the new body part behind the last part
                if (bodyParts.Count > 0)
                {
                    newBodyPart.transform.position = bodyParts[bodyParts.Count - 1].transform.position;
                }
                else
                {
                    newBodyPart.transform.position = transform.position; // Position at the head if no body parts exist
                }

                bodyParts.Add(newBodyPart); // Add the new body part to the list
            }
        }
        else if (amount < 0 && bodyParts.Count > 1)
        {
            for (int i = 0; i < Mathf.Abs(amount) && bodyParts.Count > 1; i++)
            {
                Destroy(bodyParts[bodyParts.Count - 1]);
                bodyParts.RemoveAt(bodyParts.Count - 1);
            }
        }
    }

    private void AddBodyPart()
    {
        // Create a new GameObject for the body part
        GameObject newBodyPart = new GameObject("SnakeBodyPart");
        SpriteRenderer spriteRenderer = newBodyPart.AddComponent<SpriteRenderer>();

        // Assign the snake body sprite to the new body part
        spriteRenderer.sprite = snakeBodySprite;

        // Position the new body part at the end of the snake
        if (bodyParts.Count > 0)
        {
            newBodyPart.transform.position = bodyParts[bodyParts.Count - 1].transform.position; // Position behind the last part
        }
        else
        {
            newBodyPart.transform.position = transform.position; // Start position for the first body part
        }
        newBodyPart.transform.localScale = transform.localScale;
        bodyParts.Add(newBodyPart);
        Debug.Log("Body Part added");
    }

    private void RemoveBodyPart()
    {
        GameObject lastPart = bodyParts[bodyParts.Count - 1];
        bodyParts.RemoveAt(bodyParts.Count - 1);
        Debug.Log("Body Part removed");
        Destroy(lastPart); // Destroy the last body part
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
