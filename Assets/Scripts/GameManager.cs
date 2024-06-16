using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playship;
    public GameObject enemySpawner;
    public GameObject scoreUITextGO;
    
    public GameObject GameOver;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;
    // Start is called before the first frame update
   
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                GameOver.SetActive(false);
                playButton.SetActive(true);
                
                break;
            case GameManagerState.Gameplay:
                playButton.SetActive(false);

                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playship.GetComponent<PlayerController>().Init();

                enemySpawner.GetComponent<EnemySpawn>().ScheduleNextEnemySpawn();

                break;
            case GameManagerState.GameOver:
                enemySpawner.GetComponent <EnemySpawn>().stopEnemySpawner();
                Invoke("ChangeToOpeningState", 5f);
                GameOver.SetActive(true);
                break;  
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();


    }
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
