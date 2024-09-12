using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotInput : MonoBehaviour
{
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
