using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI;
    public int score;

   

    public int Score
    {
        get
        {
            return this.score;

        }
        set
        {
            this.score = value;
            UpdateScoreTextUi();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    void UpdateScoreTextUi()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }
}
