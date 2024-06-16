using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject scoreUITextGO;
    private float speed = 2;
    private float x;
    private float yRage = 4;
    
    public GameObject enemybullets;
    private GameObject player;
    public GameObject ExplosionGo;
    //boss
    public bool isboss = false;
    public float spawnInterval;
    public float nextSpawn;
    public int miniEnemySpawnCount;
    private EnemySpawn spawnManager;



    // Start is called before the first frame update



    public void Start()
    {
          
        player = GameObject.Find("Player");
        if (isboss)
        {
            spawnManager = FindObjectOfType<EnemySpawn>();
        }
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTag");
    }
    void Update()
    {
        
        x = Input.GetAxis("Vertical");
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -yRage)
        {
            Destroy(gameObject);
        }
        if (isboss)
        {
            if(Time.time > nextSpawn)
            {
                nextSpawn = Time.time+spawnInterval;
                spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || (collision.CompareTag("PlayerBulltag")))
        {


            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            PlayExplosion();
            Destroy(gameObject) ;
        }
       
    }
    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;
    }
   

}