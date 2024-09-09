using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the ship

    public float leftOffset = 0.5f;   // Offset from the left boundary
    public float rightOffset = 0.5f;  // Offset from the right boundary
    public float bottomOffset = 0.5f; // Offset from the bottom boundary
    public float topOffset = 0.5f;    // Offset from the top boundary

    private Rigidbody2D rb;          // Reference to Rigidbody2D
    private Vector2 movement;        // Movement vector

    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    private bool canMoveUp = true;
    private bool canMoveDown = true;

    private float screenHalfHeight;  // Half of the screen height

    private bool canMove = true;     // New flag to control movement

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component

        // Calculate half of the screen height in world units
        screenHalfHeight = Camera.main.orthographicSize;
    }

    private void Update()
    {
        // Only process input if movement is allowed
        if (canMove)
        {
            // Get input from user
            float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
            float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

            // Reset movement flags if no input is detected
            if (moveX == 0) { canMoveLeft = canMoveRight = true; }
            if (moveY == 0) { canMoveUp = canMoveDown = true; }

            // Determine if we can move in each direction
            if ((moveX < 0 && canMoveLeft) || (moveX > 0 && canMoveRight))
            {
                movement.x = moveX;
            }
            else
            {
                movement.x = 0;
            }

            // Limit upward movement to half of the screen height plus offset
            float newYPosition = transform.position.y + moveY * moveSpeed * Time.deltaTime;
            float maxYPosition = screenHalfHeight - topOffset;  // Adjusted max Y position with topOffset
            if (newYPosition <= maxYPosition && ((moveY < 0 && canMoveDown) || (moveY > 0 && canMoveUp)))
            {
                movement.y = moveY;
            }
            else
            {
                movement.y = 0;
            }
        }
        else
        {
            // If movement is disabled, set velocity to zero
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Move the ship using Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }

    public void DisableMovement()
    {
        canMove = false;   // Disable movement
        rb.velocity = Vector2.zero;  // Reset velocity to zero immediately
    }

    public void EnableMovement()
    {
        canMove = true;    // Enable movement
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);

        // Only process collisions with objects tagged as "Limit"
        if (collision.gameObject.CompareTag("Limit"))
        {
            if (collision.contacts.Length > 0)
            {
                ContactPoint2D contact = collision.contacts[0];
                Vector2 normal = contact.normal;

                // Calculate adjusted position based on offsets
                Bounds shipBounds = GetComponent<Collider2D>().bounds;

                // If collision from the left or right
                if (Mathf.Approximately(normal.x, 1))
                {
                    // Add left offset
                    transform.position = new Vector3(contact.point.x + shipBounds.extents.x + leftOffset, transform.position.y, transform.position.z);
                    canMoveLeft = false;
                }
                else if (Mathf.Approximately(normal.x, -1))
                {
                    // Add right offset
                    transform.position = new Vector3(contact.point.x - shipBounds.extents.x - rightOffset, transform.position.y, transform.position.z);
                    canMoveRight = false;
                }

                // If collision from the bottom
                if (Mathf.Approximately(normal.y, 1))
                {
                    // Add bottom offset
                    transform.position = new Vector3(transform.position.x, contact.point.y + shipBounds.extents.y + bottomOffset, transform.position.z);
                    canMoveDown = false;
                }
                // If collision from the top
                else if (Mathf.Approximately(normal.y, -1))
                {
                    // Add top offset
                    transform.position = new Vector3(transform.position.x, contact.point.y - shipBounds.extents.y - topOffset, transform.position.z);
                    canMoveUp = false;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Only reset movement flags if exiting a "Limit" collider
        if (collision.gameObject.CompareTag("Limit"))
        {
            // Reset movement flags when no longer colliding with limit
            canMoveLeft = canMoveRight = canMoveUp = canMoveDown = true;
        }
    }
}
