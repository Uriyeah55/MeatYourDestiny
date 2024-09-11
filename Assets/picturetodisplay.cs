using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picturetodisplay : MonoBehaviour
{
    public Sprite[] spritesList;
    public int indexToShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    GetComponent<UnityEngine.UI.Image>().sprite = spritesList[indexToShow];

    }
}
