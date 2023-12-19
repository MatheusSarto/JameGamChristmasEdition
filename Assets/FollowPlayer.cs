using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform playerTransform;

    void Start()
    {
        // Gets the transf  orm from the player object.
        playerTransform = playerTransform.GetComponent<Transform>();
    }

    void Update()
    {
        // Sets the camera x and y position to focus on player.
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
