using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_horizontal;
    public float m_speed = (float)PlayerSpeed.Normal;
    public float m_jumpingPower = 16f;
    public bool m_isFacingRight = true;

    // This should be added on the editor manually
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;


    void Start()
    {
        m_speed = (float)PlayerSpeed.Normal;
    }
    // Update is called once per frame
    void Update()
    {
        m_horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, m_jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Debug.Log($"Player Movement Speed: {m_speed}");

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(m_horizontal * m_speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (m_isFacingRight && m_horizontal < 0f || !m_isFacingRight && m_horizontal > 0f)
        {
            m_isFacingRight = !m_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}