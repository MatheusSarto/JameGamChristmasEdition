using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // This class should be on an object that has a Collider2D, and if in range of the collider, and pressing a Key
    // an event will be fired ( interactAction ).
    // The interactAction needs to be set on editor, and it's a public function of whatever gameObject you choose.


    [SerializeField] public UnityEvent interactAction;
    private bool m_isInRange = false;
    private KeyCode m_interactKey = KeyCode.E;

    void Update()
    {
        if (m_isInRange && Input.GetKeyDown(m_interactKey))
        { 
            interactAction.Invoke();
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
