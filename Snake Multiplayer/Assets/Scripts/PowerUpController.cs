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

    private void RandomizedPosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Snake>()!=null)
        {
            switch (powerUpType)
            {
                case PowerUpType.Shield:
                    collision.GetComponent<Snake>().ActivateShield(cooldownDuration);
                    Debug.Log("Shield Activated");
                    break;
                case PowerUpType.ScoreBoost:
                    collision.GetComponent<Snake>().ActivateScoreBoost(cooldownDuration);
                    Debug.Log("ScoreBoost Activated");
                    break;
                case PowerUpType.SpeedUp:
                    collision.GetComponent<Snake>().ActivateSpeedUp(cooldownDuration);
                    Debug.Log("Speed Increased Activated");
                    break;
            }
            Destroy(gameObject);
        }
    }
}

public enum PowerUpType { Shield, ScoreBoost, SpeedUp }
