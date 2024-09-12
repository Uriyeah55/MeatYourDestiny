using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class displayRankEnd : MonoBehaviour
{
    public TMP_Text rankText;
    string rankScored;
    public Sprite[] rankSprites;
    public Image rankLetterImage;

    // Start is called before the first frame update
    void Start()
    {
        rankText.text=PlayerPrefs.GetString("MaxRank", "F");
        rankScored=PlayerPrefs.GetString("MaxRank", "F");
        switch(rankScored){
            case "S":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[6];
            break;
            case "A":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[5];
            break;
            case "B":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[4];
            break;
            case "C":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[3];
            break;
            case "D":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[2];
            break;
            case "E":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[1];
            break;
            case "F":
            rankLetterImage.GetComponent<UnityEngine.UI.Image>().sprite = rankSprites[0];
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
