using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<UbhShotCtrl>().StartShotRoutine();
        }
        else{
            gameObject.GetComponent<UbhShotCtrl>().StopShotRoutine();

        }
        
    }
}
