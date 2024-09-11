using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAllMenuSprites : MonoBehaviour
{
    public GameObject img1,img2,img3,img4;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void hideAllSprites(){
       img1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(false);
        img4.SetActive(false);
    }
}
