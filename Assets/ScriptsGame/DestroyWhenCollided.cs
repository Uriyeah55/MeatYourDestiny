using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCollided : MonoBehaviour
{
    public UbhObjectPool pool; // Reference to the object pool (should be assigned in the inspector)

    private UbhBullet bullet; // Reference to the UbhBullet component

    private void Start()
    {
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
        if (other.CompareTag("BulletLimit"))
        {
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
