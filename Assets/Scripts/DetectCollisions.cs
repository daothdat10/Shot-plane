using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
         if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBulltag"))
        {
            

            Destroy(gameObject);
        }
        

    }
}
