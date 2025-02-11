using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movemets : MonoBehaviour
{
    public float moveSpeed = 2f;   // Speed for left/right movement
    public float fallSpeed = 2f;   // Constant falling speed

    private Rigidbody2D rb;

    void Start()
    {
        // Attach Rigidbody2D if not already attached
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0; // Disable Unity's default gravity
        rb.freezeRotation = true; // Prevents unwanted rotation
    }

    void Update()
    {
        // Get left/right input
        float move = Input.GetAxis("Horizontal"); // -1 (left), 1 (right), 0 (idle)

        // Apply constant downward movement and horizontal movement
        rb.velocity = new Vector2(move * moveSpeed, -fallSpeed);
    }
}
