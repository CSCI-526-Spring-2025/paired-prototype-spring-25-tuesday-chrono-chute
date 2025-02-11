using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Reference to the player
    public GameObject player;

    // Offset of the camera from the player
    private Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        // Set the camera position to the player position
        transform.position = player.transform.position + offset;
    }
}
