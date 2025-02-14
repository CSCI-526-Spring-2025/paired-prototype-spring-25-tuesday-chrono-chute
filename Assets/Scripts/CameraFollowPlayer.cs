using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Reference to the player
    public GameObject player;

    // Offset of the camera from the player
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 initialPosition;
    private float pastPosition;
    public Switch switchScript;
    
    // Boundaries for the camera
    public float xBoundary = 0f;

    void Start()
    {
        // Store the initial position of the camera
        initialPosition = transform.position;
        pastPosition = initialPosition.x - switchScript.switchAmount;
    }

    void LateUpdate()
    {
        // Check for boundaries
        float basePosition = switchScript.isPresent ? initialPosition.x : pastPosition;
        float xPos = Mathf.Clamp(player.transform.position.x, basePosition - xBoundary, basePosition + xBoundary);
        // Set the camera position to the player position
        Vector3 newPosition = new Vector3(xPos, player.transform.position.y, initialPosition.z);
        transform.position = newPosition + offset;
    }
}
