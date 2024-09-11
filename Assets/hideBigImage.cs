using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideBigImage : MonoBehaviour
{
    public GameObject BigImage,panelImgs,buttoMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hideImg(){
        BigImage.SetActive(false);
         GetComponent<UnityEngine.UI.Image>().sprite = null;
        this.gameObject.SetActive(false);
        panelImgs.SetActive(true);
        buttoMenu.SetActive(true);
    }
}
