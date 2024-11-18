using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D gridArea;
    
    private void Start()
    {
        RandomizedPosition();
    }

    private void RandomizedPosition()
    {
        this.transform.position = RandomizedPositionUtility.GetRandomPosition(gridArea);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.tag == "Player")

            {
            Debug.Log("Food pickeup");
            SoundManager.Instance.Play(Sounds.collectItem);
            
            RandomizedPosition();
        } else if (collision.tag == "Player2")
        {
            Debug.Log("Food pickeup");
            SoundManager.Instance.Play(Sounds.collectItem);
            
            RandomizedPosition();
        }
    }
}
