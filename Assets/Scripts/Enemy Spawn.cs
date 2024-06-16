using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
  


    public int enemyCount = 1;
    private float spawnRangeX = 8;
    private float spawnRangeY = 10;
    public int waveNumber = 1;
    float Seconds = 5f;

    //boss 
    public GameObject bossPrefabs;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;


    
    void Start()
    {
        SpawnEnemyWare(waveNumber);
        
        
    
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWare(waveNumber);
            if(waveNumber %bossRound == 0)
            {
                SpawnBossWare(waveNumber);
            }
            else
            {

                SpawnEnemyWare(waveNumber);
            }
            
            

        }
        
    }
    private Vector2 GenerateSpawnPosition() {
        float spawnX = Random.Range(-spawnRangeX,spawnRangeX);
        float spawnY = Random.Range(spawnRangeY, spawnRangeY);
        Vector2 randomPos = new Vector2(spawnX, spawnY);
        return randomPos;


    }
    void SpawnEnemyWare(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
           int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
    }
    void SpawnBossWare(int currentRount)
    {
        int miniEnemysToSpawn;
        if(bossRound != 0)
        {
            miniEnemysToSpawn = currentRount/bossRound;
        }
        else
        {
            miniEnemysToSpawn=1;
        }
        var boss = Instantiate(bossPrefabs,GenerateSpawnPosition(),bossPrefabs.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(), miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }

    public void ScheduleNextEnemySpawn()
    {

        Seconds = 5f;
        float spawnInSeconds;
        if (Seconds > 1f)
        {
            spawnInSeconds = Random.Range(1f,Seconds);

        }
        else
        {
            spawnInSeconds = 1f;

        }
        Invoke("SpawnEnemyWare",spawnInSeconds);
    }
    void increaseSpawnRate()
    {
        if (Seconds > 1f)
        {
            Seconds--;
        }
        if(Seconds==1f)
            CancelInvoke("increaseSpawnRate");
    }
    public void stopManager()
    {
        Invoke("SpawnEnemyWare", Seconds);
        InvokeRepeating("increaseSpawnRate", 0, 30);
    }

    public void stopEnemySpawner()
    {
        CancelInvoke("SpawnEnemyWare");
        CancelInvoke("SpawnBossWare");
        CancelInvoke("SpawnMiniEnemy");
       

    }
}
