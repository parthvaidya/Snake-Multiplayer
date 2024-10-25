using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUpType powerUpType; // Set this in Inspector for each power-up prefab
    public float cooldownDuration = 3f; // Flexible cooldown duration

    void Start()
    {
        // Automatically destroy the power-up after a random duration if not picked up
        //Destroy(gameObject, Random.Range(5f, 10f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeController>()!=null)
        {
            Debug.Log("Pickedup");
            // Apply power-up effect to the snake
            collision.GetComponent<SnakeController>().ActivatePowerUp(powerUpType, cooldownDuration);
            Destroy(gameObject); // Destroy the power-up after collision
        }
    }
}

public enum PowerUpType { Shield, ScoreBoost, SpeedUp }
