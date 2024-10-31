using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Foody { MassGainer, MassBurner }

public class FoodsType : MonoBehaviour
{
    public Foody foody;
    public BoxCollider2D gridArea;
    public ScoreController scoreController;
    private void Start()
    {
        RandomizedPosition();
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void RandomizedPosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Snake snake = collision.GetComponent<Snake>();

        if (snake != null) 
        {
            if (foody == Foody.MassGainer)
            {
                snake.Grow();
                
               
                Debug.Log($"Mass Gainer collected");
            }
            else if (foody == Foody.MassBurner)
            {
                if (snake.CurrentLength > 1)  
                {
                    snake.Shrink();
                    Debug.Log("Mass Burner collected. Snake shrank.");
                }
                else
                {
                    Debug.Log("Mass Burner collected but snake too small to shrink.");
                }
            }
            RandomizedPosition();
        }
    }

}
