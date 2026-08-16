using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float playerSpeed;
    [SerializeField] private Transform isGrounded;
    public float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 1;

    public int maxHealth = 100;
    static public int currentPlayerHealth;

    public Animator animator;


    void Start()
    {
        currentPlayerHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentPlayerHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Player Died");
        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;
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

    private void FixedUpdate()
    {
        


    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(isGrounded.position, 0.2f, groundLayer);
    }
}
