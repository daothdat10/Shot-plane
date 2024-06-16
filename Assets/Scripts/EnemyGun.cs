using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireEnenmyBullet", 1,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnenmyBullet()
    {
        GameObject playership = GameObject.Find("PlayerGO");    
        if (playership != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO); 
            bullet.transform.position = transform.position;
            Vector2 direction = playership.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);



        }
    }


}
