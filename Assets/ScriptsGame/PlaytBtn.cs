using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;  


public class PlayBtn : MonoBehaviour
{
    public void loadGameScene()
    {
        SceneManager.LoadScene("testGame");
    }
}
