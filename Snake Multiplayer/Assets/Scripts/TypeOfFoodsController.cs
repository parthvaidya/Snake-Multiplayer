using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class TypeOfFoodsController : MonoBehaviour
{
   
    [SerializeField] private Foody foody;
    [SerializeField] private BoxCollider2D gridArea;
    private ScoreController scoreController;

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
        this.transform.position = RandomizedPositionUtility.GetRandomPosition(gridArea);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FirstSnake snake = collision.GetComponent<FirstSnake>();
        SecondSnake secondSnake = collision.GetComponent<SecondSnake>();

        if (snake != null)
        {
            HandleFoodCollection(snake);
        }
        else if (secondSnake != null)
        {
            HandleFoodCollection(secondSnake);
        }
    }

    private void HandleFoodCollection(ISnake snake)
    {
        if (foody == Foody.MassGainer)
        {
            SoundManager.Instance.Play(Sounds.collectItem);
            snake.Growing();
            Debug.Log("Mass Gainer collected");
        }
        else if (foody == Foody.MassBurner)
        {
            if (snake.CurrentLength > 1)
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

}
public interface ISnake
{
    void ActivateShield(float duration);
    void ActivateScoreBoost(float duration);
    void ActivateSpeedUp(float duration);
    int CurrentLength { get; }
    void Growing();
    void Shrink();
}

