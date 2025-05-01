using UnityEngine;

public class Modifier : MonoBehaviour
{
    public float newMoveSpeed;
    public float newJumpForce;
    public float newGravity;
    public float rotationSpeed = 20f; // Speed of rotation

    void Update()
    {
        // Rotate the object passively around the Y-axis only
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movement playerMovement = other.GetComponent<Movement>();
            if (playerMovement != null)
            {
                playerMovement.moveSpeed = newMoveSpeed;
                playerMovement.jumpForce = newJumpForce;
                playerMovement.g = newGravity;
                Destroy(gameObject); // Destroy the modifier after applying it
            }
        }
    }
}
