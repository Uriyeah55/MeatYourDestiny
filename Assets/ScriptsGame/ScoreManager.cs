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
    public GameObject rankLetterImage;
    public Sprite[] rankSprites;

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
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[5];

        }
        else if (totalScore >= AScore)
        {
            currentRanking = "A";
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[4];

        }
        else if (totalScore >= BScore)
        {
            currentRanking = "B";
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[3];

        }
        else if (totalScore >= CScore)
        {
            currentRanking = "C";
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[2];

        }
        else if (totalScore >= DScore)
        {
            currentRanking = "D";
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[1];

        }
        else
        {
            currentRanking = "F"; 
    rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[0];

        }
    }

    // Method to retrieve the localized text using the key
    string GetLocalizedText(string key)
    {
        return LocalizationSettings.StringDatabase.GetLocalizedString("Test", key); // "Test" should be your String Table name
    }
}
