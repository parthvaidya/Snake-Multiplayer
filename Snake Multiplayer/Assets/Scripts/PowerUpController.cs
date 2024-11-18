using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    [SerializeField] private PowerUpType powerUpType; // Set this in Inspector for each power-up prefab
    [SerializeField] private float cooldownDuration = 3f; // Flexible cooldown duration
    [SerializeField] private BoxCollider2D gridArea;

    void Start()
    {
        RandomizedPosition();
        // Automatically destroy the power-up after a random duration if not picked up
        Destroy(gameObject, Random.Range(5f, 10f));
    }

    // Randomize position
    private void RandomizedPosition()
    {
        this.transform.position = RandomizedPositionUtility.GetRandomPosition(gridArea);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ISnake snake = collision.GetComponent<ISnake>();

        if (snake != null)
        {
            ActivatePowerUp(snake);
            RandomizedPosition();
        }
    }

    private void ActivatePowerUp(ISnake snake)
    {
        switch (powerUpType)
        {
            case PowerUpType.Shield:
                snake.ActivateShield(cooldownDuration);
                Debug.Log("Shield Activated");
                break;
            case PowerUpType.ScoreBoost:
                snake.ActivateScoreBoost(cooldownDuration);
                Debug.Log("Score Boost Activated");
                break;
            case PowerUpType.SpeedUp:
                snake.ActivateSpeedUp(cooldownDuration);
                Debug.Log("Speed Increased Activated");
                break;
        }

        SoundManager.Instance.Play(Sounds.collectItem);
    }
}


