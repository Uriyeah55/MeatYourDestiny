using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 2f; 
    private Vector3 direction = Vector3.right; 

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("BulletLimit"))
    {
        direction = -direction;
    }
}

}
