using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreT, rankT;

    public int totalScore, Sscore = 1000, AScore = 800, BScore = 600, CScore = 400, DScore = 200;
    public string currentRanking = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreT.text = "Score: " + totalScore;
        UpdateRanking();
        rankT.text =currentRanking;
        //track and save rank
        PlayerPrefs.SetString("MaxRank", currentRanking);

    }

    void UpdateRanking()
    {
        if (totalScore >= Sscore)
        {
            currentRanking = "S";
        }
        else if (totalScore >= AScore)
        {
            currentRanking = "A";
        }
        else if (totalScore >= BScore)
        {
            currentRanking = "B";
        }
        else if (totalScore >= CScore)
        {
            currentRanking = "C";
        }
        else if (totalScore >= DScore)
        {
            currentRanking = "D";
        }
        else
        {
            currentRanking = "F"; // If score is below DScore, rank is F or some default value.
        }
    }
}
