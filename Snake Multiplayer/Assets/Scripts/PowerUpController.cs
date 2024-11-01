using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUpType powerUpType; // Set this in Inspector for each power-up prefab
    public float cooldownDuration = 3f; // Flexible cooldown duration
    public BoxCollider2D gridArea;
    void Start()
    {
        RandomizedPosition();
        // Automatically destroy the power-up after a random duration if not picked up
        Destroy(gameObject, Random.Range(5f, 10f));
    }

    //randomize position
    private void RandomizedPosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TestSnakeLogic>()!=null )
        {
            //choose powerups for snake A
            switch (powerUpType)
            {
                case PowerUpType.Shield:
                    collision.GetComponent<TestSnakeLogic>().ActivateShield(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    
                    Debug.Log("Shield Activated");
                    
                    break;
                case PowerUpType.ScoreBoost:
                    collision.GetComponent<TestSnakeLogic>().ActivateScoreBoost(cooldownDuration);
                    SoundManager.Instance.Play(Sounds.collectItem);
                    
                    Debug.Log("ScoreBoost Activated");
                    
                    break;
                case PowerUpType.SpeedUp:
                    collision.GetComponent<TestSnakeLogic>().ActivateSpeedUp(cooldownDuration);
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

public enum PowerUpType { Shield, ScoreBoost, SpeedUp }
