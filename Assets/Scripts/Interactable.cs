using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] public UnityEvent interactAction;
    private bool m_isInRange = false;
    private KeyCode m_interactKey = KeyCode.E;

    // Update is called once per frame
    void Update()
    {
        if (m_isInRange && Input.GetKeyDown(m_interactKey))
        { 
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_isInRange = false;
        }
    }
}
