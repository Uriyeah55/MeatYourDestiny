using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideBigImage : MonoBehaviour
{
    public GameObject BigImage;
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
        this.gameObject.SetActive(false);
    }
}
