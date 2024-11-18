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

    //randomize position
    private void RandomizedPosition()
    {
        this.transform.position = RandomizedPositionUtility.GetRandomPosition(gridArea);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FirstSnake>()!=null )
        {
            //choose powerups for snake A
            switch (powerUpType)
            {
                case PowerUpType.Shield:
                    collision.GetComponent<FirstSnake>().ActivateShield(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    
                    Debug.Log("Shield Activated");
                    
                    break;
                case PowerUpType.ScoreBoost:
                    collision.GetComponent<FirstSnake>().ActivateScoreBoost(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    
                    Debug.Log("ScoreBoost Activated");
                    
                    break;
                case PowerUpType.SpeedUp:
                    collision.GetComponent<FirstSnake>().ActivateSpeedUp(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    
                    Debug.Log("Speed Increased Activated");
                    
                    break;
            }
            
            RandomizedPosition();
        }

        else if(collision.gameObject.GetComponent<SecondSnake>() != null)
        {
            switch (powerUpType)
            {
                //choose powerups for Snake B
                case PowerUpType.Shield:
                    
                    collision.GetComponent<SecondSnake>().ActivateShield(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    Debug.Log("Shield Activated");

                    break;
                case PowerUpType.ScoreBoost:
                    
                    collision.GetComponent<SecondSnake>().ActivateScoreBoost(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    Debug.Log("ScoreBoost Activated");

                    break;
                case PowerUpType.SpeedUp:
                    
                    collision.GetComponent<SecondSnake>().ActivateSpeedUp(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    Debug.Log("Speed Increased Activated");

                    break;
            }
            
            RandomizedPosition();
        }
    }
}


