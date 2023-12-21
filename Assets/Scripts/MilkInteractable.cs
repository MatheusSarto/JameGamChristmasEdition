using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MilkInteractable : MonoBehaviour
{
    private PlayerManager playerManager;

    private UnityEvent<PlayerState> interactAction;
    private bool m_isInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        interactAction = new UnityEvent<PlayerState>();
        playerManager = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerManager>();

        interactAction.AddListener(playerManager.changeState);
    }

    void Update()
    {
        if (m_isInRange)
        {
            interactAction.Invoke(PlayerState.Grown);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if Player is in range to activate the evente
        if (collision.gameObject.CompareTag("Player"))
        {
            m_isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if Player is in range to activate the evente
        if (collision.gameObject.CompareTag("Player"))
        {
            m_isInRange = false;
        }
    }
}
