using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitations : MonoBehaviour
{
    public GameObject player;
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
