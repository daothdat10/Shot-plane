using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    
    private float speed = 5;
    private float xRange = 8;
    private float yRange = 2.5f;
    public GameObject projectilePrefab;
    public GameObject explosionGo;
    private GameManager gameManager;
    private Rigidbody2D playerRb;
    public GameObject powerupIndicator;
    public bool hasPowerup = false;

    public AudioClip laser;
    private AudioSource playerAudio;

    public PowerupType currentPowerUp = PowerupType.None;
    private Coroutine powerupCountdown;

    public GameObject rocketPrefab;

    private GameObject tmpRocket;
    public TextMeshProUGUI LivesUIText;
    const int MaxLives = 3;
    int lives;
    public GameObject GameManagerGO;

    public void Init()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);


        gameObject.SetActive(true);
    }

    void Start()
    {
       playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right *x*speed * Time.deltaTime);
        transform.Translate(Vector2.up *y*speed * Time.deltaTime);
        range();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            playerAudio.PlayOneShot(laser, 10f);

        }
       
    }

    void range()
    {

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange  , transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Enemy") || collision.CompareTag("EnemyBulltag"))
        {
            PlayExplosion();
            lives--;
            LivesUIText.text= lives.ToString();
            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }


            
        }
    }
   
   

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(explosionGo);
        explosion.transform.position = transform.position;
    }


}
