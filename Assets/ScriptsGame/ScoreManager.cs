using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
        public TMP_Text scoreT,rankT;

    public int totalScore;
    public string currentRanking="S";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       scoreT.text="Score: " + totalScore;
       rankT.text=currentRanking;

    }
}
