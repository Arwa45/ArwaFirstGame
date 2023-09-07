using UnityEngine;

public class GroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 5f; // Speed at which the ground scrolls
    public float resetPosition = -30f; // X position at which the ground resets

    // Update is called once per frame
    void Update()
    {
        // Move the ground based on the scroll speed
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reset the ground position if it reaches the reset point
        if (transform.position.x <= resetPosition)
        {
            // Corrected reset logic
            transform.position = new Vector3(transform.position.x + resetPosition, transform.position.y, transform.position.z);
        }
    }
}
