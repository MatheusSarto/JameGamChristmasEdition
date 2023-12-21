using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        // Gets the transform from the player object.
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    void Update()
    {
        // Sets the camera x and y position to focus on player.
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
