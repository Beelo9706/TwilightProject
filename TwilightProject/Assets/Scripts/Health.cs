using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    static public int currentHealth;

    public Animator animator;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {

        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;
    }
}
