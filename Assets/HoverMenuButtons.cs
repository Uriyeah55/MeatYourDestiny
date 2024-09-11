using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  


public class HoverMenuButtons : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject img1,img2,img3,img4;
    public int buttonToShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnPointerEnter(PointerEventData eventData)
    {
        switch (buttonToShow){
        case 1:
        img1.SetActive(true);
        img2.SetActive(false);
        img3.SetActive(false);
        img4.SetActive(false);
        break;
                case 2:
        img1.SetActive(false);
        img2.SetActive(true);
        img3.SetActive(false);
        img4.SetActive(false);
        break;
                case 3:
        img1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(true);
        img4.SetActive(false);
        break;
                case 4:
        img1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(false);
        img4.SetActive(true);
        break;
        }
  

    }

    public void OnPointerExit(PointerEventData eventData)
    {
                img1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(false);
        img4.SetActive(false);
    }
        public void quitapp(){
        Application.Quit();
    }
}
