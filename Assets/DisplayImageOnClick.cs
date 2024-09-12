using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayImageOnClick : MonoBehaviour
{
    public GameObject bigImg,buttonClose,panelImages,buttonMenu;
    public int intPicture;
    public Sprite fullaButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showThisImage(){
        bigImg.SetActive(true);
        bigImg.GetComponent<picturetodisplay>().indexToShow=intPicture;
        buttonClose.SetActive(true);
        buttonClose.GetComponent<UnityEngine.UI.Image>().sprite = fullaButton;
        panelImages.SetActive(false);
        buttonMenu.SetActive(false);
    }
}
