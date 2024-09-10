using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayRankEnd : MonoBehaviour
{
    public TMP_Text rankText;

    // Start is called before the first frame update
    void Start()
    {
        rankText.text=PlayerPrefs.GetString("MaxRank", "F");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
