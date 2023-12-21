using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public BoxCollider2D hurtBox;
    [SerializeField] public PlayerMovement playerController;
    // Delay in Seconds
    [SerializeField] public float transformationTime = 3.0f;

    public bool isTransformed = false;

    PlayerState state = PlayerState.Normal;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(hurtBox.bounds.center, hurtBox.bounds.size);
    }

    // Public function to be called by Anvil on event, using the Interactable class.
    public void Trhow(GameObject player)
    {
        PlayerManager manager = player.GetComponent<PlayerManager>();

        if (manager)
        {

        }
    }

    // Public function to be called by Anvil on event, using the Interactable class.
    public void Kick(GameObject player)
    {
        PlayerManager manager = player.GetComponent<PlayerManager>();

        if (manager)
        {

        }
    }

    private IEnumerator DelayedCallBack()
    {
        yield return new WaitForSeconds(5);

        changeState(PlayerState.Normal);
        Debug.Log("Transformation Time over");
    }

    // Public function to be called by Anvil on event, using the Interactable class.
    public void changeState(PlayerState newState)
    { 
        // Switch case to check which state the player current is when the function is called.
        // This function changes player state variable and also it's speed and hurtbox.
        Debug.Log($"Current state: {state}");
        Debug.Log($"New state Param: {Enum.GetName(typeof(PlayerState), newState)}");
        switch (state) 
        { 
        case PlayerState.Normal:
                Debug.Log($"On Normal state;");

                if (newState == PlayerState.Shrink)
                {
                    Vector2 currentOffset = hurtBox.offset;
                    hurtBox.size = new Vector2(hurtBox.size.x, hurtBox.size.y / 2);
                    hurtBox.offset = currentOffset;
                    playerController.m_speed = (float)PlayerSpeed.Shrink;

                    state = PlayerState.Shrink;
                    isTransformed = true;
                    StartCoroutine(DelayedCallBack());
                    return;
                }
                else if(newState == PlayerState.Grown)
                {
                    hurtBox.size = new Vector2(hurtBox.size.x, hurtBox.size.y * 2);
                    playerController.m_speed = (float)PlayerSpeed.Grown;

                    state = PlayerState.Grown;
                    isTransformed = true;
                    StartCoroutine(DelayedCallBack());
                    return;
                }
                break;

        case PlayerState.Shrink:
                Debug.Log($"On Shrink state;");

                if (newState == PlayerState.Normal)
                {
                    hurtBox.size = new Vector2(hurtBox.size.x, hurtBox.size.y * 2);
                    playerController.m_speed = (float)PlayerSpeed.Normal;

                    state = PlayerState.Normal;
                    isTransformed = false;
                }
                break;
        
        case PlayerState.Grown:
                Debug.Log($"On Grown state;");

                if (newState == PlayerState.Normal)
                {
                    hurtBox.size = new Vector2(hurtBox.size.x, hurtBox.size.y / 2);
                    playerController.m_speed = (float)PlayerSpeed.Normal;

                    state = PlayerState.Normal;
                    isTransformed = false;
                }
                break;  
        }

        Debug.Log($"New state: {Enum.GetName(typeof(PlayerState), state)}");
    }
}
