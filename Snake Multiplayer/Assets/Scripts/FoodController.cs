using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public FoodType foodType;
    public int growthAmount = 1; // Increase/decrease by this amount
    public BoxCollider2D gridArea;

    void Start()
    {
        RandomizedPosition();
        Destroy(gameObject, Random.Range(5f, 10f)); // Auto-destroy if not eaten
    }

    private void RandomizedPosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            SnakeController snake = collision.GetComponent<SnakeController>();
            if (foodType == FoodType.MassGainer)
            {
                Debug.Log("MassGainer consumed! Growing snake by: " + growthAmount);
                snake.GrowSnake(growthAmount, initiallyHidden: false);
            }
            else if (foodType == FoodType.MassBurner && snake.Length > 1)
            {
                Debug.Log("MassBurner consumed! Shrinking snake by: " + growthAmount);
                snake.GrowSnake(-growthAmount, initiallyHidden: false);
            }
            Destroy(gameObject); // Destroy after eaten
        }
    }
}

public enum FoodType { MassGainer, MassBurner }