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
        
        TestSnakeLogic snake = collision.GetComponent<TestSnakeLogic>();
        SecondSnake secondsnake = collision.GetComponent<SecondSnake>();

        if (snake != null) 
        {
            if (foody == Foody.MassGainer)
            {
                SoundManager.Instance.Play(Sounds.collectItem);
                snake.Growing();
                
               
                Debug.Log($"Mass Gainer collected");
            }
            else if (foody == Foody.MassBurner)
            {
                if (snake.CurrentLength > 1 )  
                {
                    SoundManager.Instance.Play(Sounds.collectItem);
                    snake.Shrink();
                    
                    Debug.Log("Mass Burner collected. Snake shrank.");
                }
                else
                {
                    SoundManager.Instance.Play(Sounds.collectItem);
                    Debug.Log("Mass Burner collected but snake too small to shrink.");
                }
            }
            RandomizedPosition();
        }

        else if(secondsnake!=null) {
            if (foody == Foody.MassGainer)
            {
                SoundManager.Instance.Play(Sounds.collectItem);
                secondsnake.Growing();


                Debug.Log($"Mass Gainer collected");
            }
            else if (foody == Foody.MassBurner)
            {
                if (secondsnake.CurrentLength > 1)
                {
                    SoundManager.Instance.Play(Sounds.collectItem);
                    secondsnake.Shrink();

                    Debug.Log("Mass Burner collected. Snake shrank.");
                }
                else
                {
                    SoundManager.Instance.Play(Sounds.collectItem);
                    Debug.Log("Mass Burner collected but snake too small to shrink.");
                }
            }
            RandomizedPosition();

        }
    }

}
