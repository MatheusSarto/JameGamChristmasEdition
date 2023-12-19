using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBottomOfCollider : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerHurtbox;

    void Start()
    {
        playerHurtbox = playerHurtbox.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHurtbox != null)
        { 
            float bottomY = playerHurtbox.bounds.min.y;

            transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
        }
    }
}
