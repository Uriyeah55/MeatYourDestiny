using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImageOnClick : MonoBehaviour
{
    public GameObject bigImg,buttonClose;
    public int intPicture;
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

    }
}
