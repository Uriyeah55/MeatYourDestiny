

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnCollision : MonoBehaviour
{
    public UbhObjectPool pool; // Reference to the object pool (should be assigned in the inspector)

    private UbhBullet bullet; // Reference to the UbhBullet component
    public GameObject manager,audioHurtManager;

    private void Start()
    {
        manager=GameObject.Find("MANAGER");
        audioHurtManager=GameObject.Find("PlayerHurtManager");


        pool=GameObject.Find("Pool").GetComponent<UbhObjectPool>();
        // Get the UbhBullet component from the same GameObject
        bullet = GetComponent<UbhBullet>();

        if (bullet == null)
        {
            Debug.LogError("UbhBullet component not found on the bullet GameObject.");
            return;
        }

        // Start a timer to deactivate the bullet after 5 seconds
        Invoke("ReleaseBullet", 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        // If the bullet collides with an object tagged "Limit"
        if (other.CompareTag("Player"))
        {
            audioHurtManager.GetComponent<AudioSource>().Play();
            manager.GetComponent<ScoreManager>().totalScore-=10;
            if(manager.GetComponent<ScoreManager>().totalScore<0)
            {
                manager.GetComponent<ScoreManager>().totalScore=0;
            }

            ReleaseBullet();
        }

    }

    private void ReleaseBullet()
    {
        // Check if the pool is set and the bullet is still active
        if (pool != null && bullet != null)
        {
            pool.ReleaseBullet(bullet);  // Correctly pass the UbhBullet type to the pool
        }
        else
        {
            Debug.LogError("Pool is not set or UbhBullet is missing for bullet: " + gameObject.name);
        }
    }

    // Method to be called directly if needed
    private void SelfDestroy()
    {
        ReleaseBullet();
    }
}
