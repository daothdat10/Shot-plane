using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyHungry : MonoBehaviour
{
    public Slider enemySlider;
    public int amountTobeFed;
    private int currentFedAmount = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemySlider.maxValue = amountTobeFed;
        enemySlider.value = 0; 

        enemySlider.fillRect.gameObject.SetActive(false);
        
    }
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        enemySlider.fillRect.gameObject.SetActive(true);
        enemySlider.value = currentFedAmount;
        if (currentFedAmount >= amountTobeFed)
        {
            
            Destroy(gameObject, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
