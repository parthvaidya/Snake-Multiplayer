using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public ScoreController scoreController;
    private void Start()
    {
        RandomizedPosition();
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
        if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log("Food pickeup");
            //scoreController.IncreaseScore(10);
            RandomizedPosition();
        }
    }
}
