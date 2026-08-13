using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator animator; 


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy Died");
        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;
    }


}
