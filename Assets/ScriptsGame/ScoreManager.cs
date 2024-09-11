using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreNumbersText, rankT;

    public int totalScore, Sscore = 1500, AScore = 1000, BScore = 800, CScore = 600, DScore = 400;
    public string currentRanking = "";
    string rankTextLocalized;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve localized text for the score key
        //rankTextLocalized = GetLocalizedText("scoreK");
    }

    // Update is called once per frame
    void Update()
    {
        // Display localized score text with the total score
        scoreNumbersText.text = totalScore.ToString();
        UpdateRanking();
        rankT.text = currentRanking;

        // Track and save rank
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

    // Method to retrieve the localized text using the key
    string GetLocalizedText(string key)
    {
        return LocalizationSettings.StringDatabase.GetLocalizedString("Test", key); // "Test" should be your String Table name
    }
}
