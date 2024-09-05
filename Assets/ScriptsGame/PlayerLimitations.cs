using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitations : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disablePlayerMovement(){
        player.GetComponent<PlayerMovement>().enabled=false;
    }
        public void enablePlayerMovement(){
        player.GetComponent<PlayerMovement>().enabled=true;
    }
        public void disablePlayerShooting(){
        player.GetComponent<PlayerShotInput>().enabled=false;
    }
        public void enablePlayerShooting(){
        player.GetComponent<PlayerShotInput>().enabled=true;
    }
}
