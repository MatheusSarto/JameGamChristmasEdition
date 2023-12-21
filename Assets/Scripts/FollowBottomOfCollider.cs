using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBottomOfCollider : MonoBehaviour
{
    private BoxCollider2D playerHurtbox;

    void Start()
    {
        playerHurtbox = GameObject.FindGameObjectWithTag("Player")?.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Adjusts the ground checker to always be on the bottom of the collider, even if the collider changes it size
        if (playerHurtbox != null)
        { 
            float bottomY = playerHurtbox.bounds.min.y;

            transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
        }
    }
}
