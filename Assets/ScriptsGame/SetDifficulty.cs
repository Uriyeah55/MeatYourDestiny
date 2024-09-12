using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    //0 easy 1 normal 2 hard
    public void setEasyDifficulty(){
            PlayerPrefs.SetInt("difficulty", 1);
            Debug.Log("difficulty set to" + PlayerPrefs.GetInt("difficulty", 0));
    }
        public void setMediumDifficulty(){
            PlayerPrefs.SetInt("difficulty", 2);
            Debug.Log("difficulty set to" + PlayerPrefs.GetInt("difficulty", 0));

    }
        public void setHardDifficulty(){
            PlayerPrefs.SetInt("difficulty", 3);
            Debug.Log("difficulty set to" + PlayerPrefs.GetInt("difficulty", 0));
    }
}
