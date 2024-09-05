using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;  


public class PlayBtn : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    //public GameObject hoverPlay,hoverDif,hoverQuit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnPointerEnter(PointerEventData eventData)
    {/*
        hoverPlay.SetActive(true);
        hoverDif.SetActive(false);
        hoverQuit.SetActive(false);
        */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        /*
        hoverPlay.SetActive(false);
        hoverDif.SetActive(false);
        hoverQuit.SetActive(false); */
    }
    public void loadGameScene(){
SceneManager.LoadScene("testGame");
    }
 
}
