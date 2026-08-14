using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator animator;
    public float playerSpeed;
    [SerializeField] private Transform isGrounded;
    public float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 1;

    public int maxHealth = 100;
    int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
    }

    public void PlayerHurt(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

        void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed, rb.linearVelocity.y);

        if(horizontalInput > 0.01)
        {
            transform.localScale = new Vector2(-2, 2);
        }
        else if(horizontalInput < -0.01)
        {
            transform.localScale = new Vector2(2, 2);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        } 

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }

    }

    

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(isGrounded.position, 0.2f, groundLayer);
    }

    void Die()
    {
        Debug.Log("Player Died");
        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;
    }
}
