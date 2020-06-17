using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    bool m_MoveLeft, m_MoveRight, m_Jump, m_isGrounded;

    [Range(0.1f, 1.0f)] [SerializeField] float MovementSpeed;
    [Range(0.0f, 0.5f)] [SerializeField] float JumpSpeed;

    public float JumpResetTime;
    public Rigidbody2D Rigidbody2D;

    void FixedUpdate()
    {
        if (m_MoveLeft)
        {
            transform.position += Vector3.left * MovementSpeed;
        }
        if (m_MoveRight)
        {
            transform.position += Vector3.right * MovementSpeed;
        }
        if (m_Jump)
        {
            transform.position += Vector3.up * JumpSpeed;
        }
    }

    public void MoveRight()
    {
        m_MoveRight = true;
    }
    public void MoveLeft()
    {
        m_MoveLeft = true;
    }
    public void StopMoving()
    {
        m_MoveRight = false;
        m_MoveLeft = false;
    }
    public void Jump()
    {
        if (m_isGrounded)
        {
            // jump logic
            Rigidbody2D.gravityScale = 0.0f;
            CancelInvoke("ResetJump");
            Invoke("ResetJump", JumpResetTime);
            m_isGrounded = false;
            m_Jump = true;
        }
    }

    public void ExtraJump()
    {
        CancelInvoke("ResetJump");
        Rigidbody2D.gravityScale = 0.0f;
        Rigidbody2D.velocity = Vector2.zero;
        Invoke("ResetJump", JumpResetTime);
    }

    public void ResetJump()
    {
        Rigidbody2D.gravityScale = 1.0f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            m_isGrounded = true;
            m_Jump = false;
        }
    }
}
