using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public FoodType foodType;
    public int growthAmount = 1; // Increase/decrease by this amount

    void Start()
    {
        Destroy(gameObject, Random.Range(5f, 10f)); // Auto-destroy if not eaten
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>() != null)
        {
            SnakeController snake = collision.GetComponent<SnakeController>();
            if (foodType == FoodType.MassGainer && snake.Length > 1)
            {
                snake.GrowSnake(growthAmount);
            }
            else if (foodType == FoodType.MassBurner)
            {
                snake.GrowSnake(-growthAmount);
            }
            Destroy(gameObject); // Destroy after eaten
        }
    }
}

public enum FoodType { MassGainer, MassBurner }