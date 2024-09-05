using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    //0 easy 1 normal 2 hard
    //public int difficulty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setEasyDifficulty(){
            PlayerPrefs.SetInt("difficulty", 1);
    }
        public void setMediumDifficulty(){
            PlayerPrefs.SetInt("difficulty", 2);
    }
        public void setHardDifficulty(){
            PlayerPrefs.SetInt("difficulty", 3);
    }
}
